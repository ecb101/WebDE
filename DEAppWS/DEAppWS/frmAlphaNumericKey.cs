using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmAlphaNumericKey : frmMasterBase
    {
        AlphaNumericKeyBL.AlphaNumericKeyBL bl = new AlphaNumericKeyBL.AlphaNumericKeyBL();
        private DataSet dsOwnerKey = new DataSet();
        private DataView dvOwnerKey = new DataView();
        

        public frmAlphaNumericKey()
        {
            this.searchFilter = "[Owner_Key] LIKE '{0}%' OR [Invoice] LIKE '{0}%' OR [FreightBill] LIKE '{0}%'";
            InitializeComponent();
            dsOwnerKey = bl.selectOwnerKey(false);
            setDropDownList();
        }

        #region override
        protected override void setNewRecord()
        {
            base.setNewRecord();
            dsOwnerKey = bl.selectOwnerKey(true);
            setDropDownList();
        }

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
            primaryKeys.Add("Owner_Key");
        }

        protected override void SetReadOnlyControlsEdit()
        {
            base.SetReadOnlyControlsEdit();
            readOnlyControlEdit.Add("ddlOwnerKey");
        }

        protected override void Save()
        {
            base.Save();
            switch (currentFormState)
            {
                case CommonEnum.FormState.NEW_STATE:
                    {
                        bl.Insert(dt);
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        bl.Update(dt);
                        break;
                    }
            }
            ds = bl.SelectAll();
            dsOwnerKey = bl.selectOwnerKey(false);
            setDropDownList();
        }

        protected override void Delete()
        {
            base.Delete();
            bl.Delete(primaryKeysString, primaryKeyValuesString);
            ds = bl.SelectAll();
        }
        #endregion

        private void setDropDownList()
        {
            this.dvOwnerKey.Table = dsOwnerKey.Tables[0];
            this.ddlOwnerKey.DisplayMember = "Owner_Key";
            this.ddlOwnerKey.ValueMember = "Owner_Key";
            this.ddlOwnerKey.DataSource = dvOwnerKey;
            this.ddlOwnerKey.Refresh();
            
        }

    }
}