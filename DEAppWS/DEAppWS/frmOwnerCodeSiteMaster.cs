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

namespace DEAppWS
{
    public partial class frmOwnerCodeSiteMaster : frmMasterBase
    {
        private OwnerCodeSiteMasterBL.OwnerCodeSiteMasterBL bl = new OwnerCodeSiteMasterBL.OwnerCodeSiteMasterBL();
        private DataSet dsAssignedSite = new DataSet();
        private DataView dvAssignedSite = new DataView();

        public frmOwnerCodeSiteMaster()
        {
            this.searchFilter = "[Owner_Code] LIKE '{0}%' OR [Assigned_Site] LIKE '{0}%'";
            InitializeComponent();
            dsAssignedSite = bl.selectAssignedSite();
            setDropDownList();
        }

        #region override

        protected override void InitGridColumns(DataGridViewColumnCollection columns)
        {
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ds = bl.SelectAll();
            grdInvisibleColumns.Clear();
            base.InitGridColumns(columns);
        }

        protected override void SetPrimaryKeys()
        {
            base.SetPrimaryKeys();
            primaryKeys.Add("Owner_Code");
        }

        protected override void Save()
        {
            base.Save();
            switch (currentFormState)
            {
                case CommonEnum.FormState.NEW_STATE:
                    {
                        //populateInsertDataRow();
                        bl.Insert(dt);
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        //base.Save();
                        bl.Update(dt);
                        break;
                    }
            }
            ds = bl.SelectAll();
            dsAssignedSite = bl.selectAssignedSite();
            setDropDownList();
        }

        protected override void Delete()
        {
            base.Delete();
            bl.Delete(primaryKeysString, primaryKeyValuesString);
            ds = bl.SelectAll();
        }

        protected override void SetReadOnlyControlsEdit()
        {
            base.SetReadOnlyControlsEdit();
            readOnlyControlEdit.Add("txtOwnerCode");
        }

        #endregion


        private void setDropDownList()
        {
            this.dvAssignedSite.Table = dsAssignedSite.Tables[0];
            this.ddlAssignedSite.DisplayMember = "Assigned_Site";
            this.ddlAssignedSite.ValueMember = "Assigned_Site";
            this.ddlAssignedSite.DataSource = dvAssignedSite;
        }
    }
}
