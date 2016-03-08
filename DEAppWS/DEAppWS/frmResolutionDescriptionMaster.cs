using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
using FormControls;

namespace DEAppWS
{
    public partial class frmResolutionDescriptionMaster : frmMasterBase
    {
        ResolutionDescriptionBL.ResolutionDescriptionBL bl = new ResolutionDescriptionBL.ResolutionDescriptionBL();
        private DataSet dsCode = new DataSet();
        private DataView dvCode = new DataView();
        private DataSet dsCategory = new DataSet();
        private DataView dvCategory = new DataView();
        private DataSet dsType = new DataSet();
        private DataView dvType = new DataView();
        private int temp = 0;
        public frmResolutionDescriptionMaster()
        {
            this.searchFilter = "[Description] LIKE '{0}%'  OR [Category] LIKE '{0}%' OR [Type] LIKE '{0}%'";
            InitializeComponent();
            dsCategory = bl.selectCategory();
            dsType = bl.selectType();
            setDropDownList();            
        }

        #region override

        protected override void InitGridColumns(DataGridViewColumnCollection columns)
        {
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ds = bl.SelectAll();
            grdInvisibleColumns.Clear();
            grdInvisibleColumns.Add(ds.Tables[0].Columns["ID"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["Code"].ColumnName);
            base.InitGridColumns(columns);
        }

        protected override void SetReadOnlyControlsEdit()
        {
            base.SetReadOnlyControlsEdit();
            readOnlyControlEdit.Add("txtID");
            readOnlyControlEdit.Add("txtCode");
        }

        protected override void SetReadOnlyControlsNew()
        {
            base.SetReadOnlyControlsNew();
            readOnlyControlNew.Add("txtID");
            readOnlyControlNew.Add("txtCode");
        }

        protected override void SetPrimaryKeys()
        {
            base.SetPrimaryKeys();
            primaryKeys.Add("ID");
        }

        protected override void Save()
        {
            switch (currentFormState)
            {
                case CommonEnum.FormState.NEW_STATE:
                    {
                        testRun();
                        if (temp != 0)
                        {
                            this.txtCode.Text = temp.ToString();
                            populateDataRow();
                            bl.Insert(dt);
                        }
                        else

                            MessageBox.Show("Please pick a different combination.", "You can't do that.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        base.Save();
                        bl.Update(dt);
                        break;
                    }
            }
            ds = bl.SelectAll();
        }

        protected override void Delete()
        {
            base.Delete();
            bl.Delete(primaryKeysString, primaryKeyValuesString);
            ds = bl.SelectAll();
        }

        #endregion

        #region others
        private void setDropDownList()
        {
            this.dvType.Table = dsType.Tables[0];
            this.ddlType.DisplayMember = "Type";
            this.ddlType.ValueMember = "Type";
            this.ddlType.DataSource = dvType;
            this.ddlType.Refresh();

            this.dvCategory.Table = dsCategory.Tables[0];
            this.ddlCategory.DisplayMember = "Category";
            this.ddlCategory.ValueMember = "Category";
            this.ddlCategory.DataSource = dvCategory;
            this.ddlCategory.Refresh();
        }

        private void populateDataRow()
        {
            dt.Clear();
            dr = dt.NewRow();
            foreach (Control control in grpBoxDetail.Controls)
            {
                if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != "ID")
                {
                    dr[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                }
                else if (control is TraxDEComboBox)
                {
                    dr[((TraxDEComboBox)control).DatabaseFieldLink] = ((TraxDEComboBox)control).SelectedValue == null ? ((TraxDEComboBox)control).SelectedItem : ((TraxDEComboBox)control).SelectedValue;
                }
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != "ID")
                        {
                            dr[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                        }
                    }
                }
            }
            dt.Rows.Add(dr);
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.NEW_STATE || currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                testRun();
                if (temp != 0)
                    txtCode.Text = temp.ToString();
                else
                    MessageBox.Show("Please pick a different combination.", "You can't do that.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.NEW_STATE || currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                testRun();
                if (temp != 0)
                    this.txtCode.Text = temp.ToString();
                else
                    MessageBox.Show("Please pick a different combination.", "You can't do that.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void testRun()
        {
            temp = 0;
            bool flag = false;
            int b = 0;
            dsCode = bl.selectCode(ddlType.SelectedValue.ToString(), ddlCategory.SelectedValue.ToString());
            b = Convert.ToInt32(dsCode.Tables[0].Rows[0].ItemArray[0]) / 10 * 10;
            if (b == 0)
                b += 1;
            
            for (int i = 0; i <= 9; i++)
            {
                flag = false;
                for (int k = 0; k <= dsCode.Tables[0].Rows.Count - 1; k++)
                {
                    if ((b + i).Equals(dsCode.Tables[0].Rows[k].ItemArray[0]))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    temp = b + i;
                    break;
                }
            }

        }
        #endregion
    }
        
}
