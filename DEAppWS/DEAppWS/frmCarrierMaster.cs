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
    public partial class frmCarrierMaster : frmMasterBase
    {
        CarrierMasterBL.CarrierMasterBL bl = new CarrierMasterBL.CarrierMasterBL();
       
        public frmCarrierMaster()
        {
            this.searchFilter = "[DeScac] LIKE '{0}%' OR [Mode] LIKE '{0}%' OR [Level] LIKE '{0}%'";
            InitializeComponent();
        }
        #region override
        protected override void InitGridColumns(DataGridViewColumnCollection columns)
        {
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ds = bl.SelectAll();
            grdInvisibleColumns.Clear();
            grdInvisibleColumns.Add(ds.Tables[0].Columns["KeyingInstructions"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["UpdateTimestamp"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["UpdateUsername"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["UpdateMachine"].ColumnName);
            base.InitGridColumns(columns);
        }

        protected override void SetPrimaryKeys()
        {
            base.SetPrimaryKeys();
            primaryKeys.Add("DeScac");
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
        }

        protected override void Delete()
        {            
            base.Delete();
            bl.Delete(primaryKeysString, primaryKeyValuesString);
            ds = bl.SelectAll();
        }
        #endregion
    }
}
