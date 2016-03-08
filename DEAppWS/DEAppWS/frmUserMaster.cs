using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmUserMaster : frmMasterBase
    {
        private UserMasterBL.UserMasterBL bl = new UserMasterBL.UserMasterBL();
        DataSet dsDetail = new DataSet();
        DataView dvDetail = new DataView();
        private DataSet dsGroup = new DataSet();
        public frmUserMaster()
        {
            this.searchFilter = "[UserID] LIKE '{0}%' OR [UserLastName] LIKE '{0}%' OR [UserType] LIKE '{0}%'";
            InitializeComponent();            
        }

        #region events
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            txtUserPassword.Text = txtUserID.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGroupLookup frmGroupLookup = new frmGroupLookup(dsGroup);
            frmGroupLookup.ShowDialog();
            if (frmGroupLookup.Selected)
            {
                if (!isUserMemberOfGroup(frmGroupLookup.Row["UserGroupID"].ToString()))
                {
                    DataRow row = ((DataView)grdDetail.DataSource).Table.NewRow();

                    row["UserGroupID"] = frmGroupLookup.Row["UserGroupID"];
                    row["UserID"] = txtUserID.Text;
                    row["SiteID"] = txtSiteID.Text;
                    row["UserGroupDescription"] = frmGroupLookup.Row["UserGroupDescription"];
                    row["Mode"] = frmGroupLookup.Row["Mode"];
                    row["Client"] = frmGroupLookup.Row["Client"];
                    row["SCAC"] = frmGroupLookup.Row["SCAC"];
                    row["DocumentType"] = frmGroupLookup.Row["DocumentType"];
                    row["Language"] = frmGroupLookup.Row["Language"];                    
                    dsDetail.Tables[0].Rows.Add(row);
                    bindgrdDetail();
                    grdDetail.Select();
                    grdDetail.Rows[grdDetail.Rows.Count - 1].Selected = true;
                    grdDetail.CurrentCell = grdDetail.Rows[grdDetail.SelectedRows[0].Index].Cells[3];
                    if (grdDetail.SelectedRows.Count > 0)
                        btnDelete.Enabled = true;
                }
                else
                    MessageBox.Show("User is already member of the group.", "User Master");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete(string.Format("UserGroupID = '{0}'", grdDetail.Rows[grdDetail.SelectedRows[0].Index].Cells["UserGroupID"].Value.ToString().Trim()));
            bindgrdDetail();
            if (grdDetail.Rows.Count <= 0)
                btnDelete.Enabled = false;
        }

        private void frmUserMaster_Load(object sender, EventArgs e)
        {
            dsGroup = bl.selectGroup();
        }
        #endregion

        #region Developer Designed method
        private void bindgrdDetail()
        {   
            if (dsDetail == null)
            {
                if ((DataView)grdDetail.DataSource != null)
                {
                    if (dvDetail.Table != null)
                        dvDetail.Table.Rows.Clear();
                    grdDetail.DataSource = dvDetail;
                    grdDetail.ClearSelection();
                }
            }
            else
            {
                dvDetail.Table = dsDetail.Tables[0];
                this.grdDetail.DataSource = dvDetail;
                this.grdDetail.Refresh();
            }
        }

        private bool isUserMemberOfGroup(string GroupID)
        {
            bool retval = false;

            this.dvDetail.RowFilter = string.Format("UserGroupID ='{0}'", GroupID);
            retval = dvDetail.Count > 0;
            this.dvDetail.RowFilter = string.Empty;
            return retval;
        }

        private bool delete(string filter)
        {
            bool retval = false;
            try
            {
                this.dvDetail.RowFilter = filter;
                int count = dvDetail.Count;
                ArrayList deleteList = new ArrayList();
                for (int i = 0; i < count; i++)
                    deleteList.Add(dsDetail.Tables[0].Rows.IndexOf(dvDetail[i].Row));
                foreach (object item in deleteList)
                    dsDetail.Tables[0].Rows[(int)item].Delete();
                retval = true;
            }
            catch
            {
                retval = false;
            }
            this.dvDetail.RowFilter = string.Empty;
            return retval;
        }
        #endregion

        #region override
        protected override void enableControls(bool isEnable, ArrayList readOnlyControls, Control.ControlCollection controls)
        {
            base.enableControls(isEnable, readOnlyControls, controls);
            if (grdDetail.Rows.Count > 0 && this.currentFormState == CommonEnum.FormState.EDIT_STATE)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }
        
        protected override void bindListDetail()
        {
            base.bindListDetail();
            if(txtUserPassword.Text != string.Empty)
                txtUserPassword.Text = CommonEncrytion.Decrypt(txtUserPassword.Text);

            if (grdList.SelectedRows.Count > 0)            
                dsDetail = bl.selectGroupDetail(grdList.SelectedRows[0].Cells["UserID"].Value.ToString());
            else
                dsDetail = null;
            bindgrdDetail();            
        }

        protected override void InitGridColumns(DataGridViewColumnCollection columns)
        {
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ds = bl.SelectAll();
            grdInvisibleColumns.Clear();
            grdInvisibleColumns.Add(ds.Tables[0].Columns["UserPassword"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["UserInitials"].ColumnName);            
            grdInvisibleColumns.Add(ds.Tables[0].Columns["SiteID"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["Status"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["LastLoginDateTime"].ColumnName);            
            base.InitGridColumns(columns);
        }

        protected override void SetReadOnlyControlsNew()
        {
            base.SetReadOnlyControlsNew();
            readOnlyControlNew.Add("txtUserID");
            readOnlyControlNew.Add("txtUserPassword");
            readOnlyControlNew.Add("txtSiteID");
        }

        protected override void SetReadOnlyControlsEdit()
        {
            base.SetReadOnlyControlsEdit();
            readOnlyControlEdit.Add("txtUserID");
            readOnlyControlEdit.Add("txtUserPassword");
            readOnlyControlEdit.Add("txtSiteID");
        }

        protected override void SetPrimaryKeys()
        {
            base.SetPrimaryKeys();
            primaryKeys.Add("UserID");
        }
                
        protected override void setNewRecord()
        {
            base.setNewRecord();
            txtUserID.Text = (bl.selectLastID() + 1).ToString().PadLeft(5, '0');
            txtUserPassword.Text = txtUserID.Text;
            txtSiteID.Text = ConfigurationManager.AppSettings["SiteID"];
            dsDetail = bl.selectGroupDetail(txtUserID.Text);
            bindgrdDetail();
        }

        protected override void Save()
        {
            base.Save();
            dr["UserPassword"] = CommonEncrytion.Encrypt(dr["UserPassword"].ToString());
            bl.saveUser(dt, dsDetail, currentFormState == CommonEnum.FormState.NEW_STATE ? true : false);            
            ds = bl.SelectAll();
        }

        protected override void Delete()
        {
            if (CommonUserLogin.getUser().UserID != txtUserID.Text.Trim())
            {
                bl.deleteUser(txtUserID.Text, txtSiteID.Text);
                ds = bl.SelectAll();
            }
            else            
                MessageBox.Show("This user is currently active.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        protected override bool ValidateSave()
        {
            if (txtUserInitials.Text.Trim() == string.Empty)
                return false;
            else
                return base.ValidateSave();
        }
        #endregion
    }
}
