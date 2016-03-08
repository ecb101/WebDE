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
    public partial class frmDeactivationDescriptionMaster : frmMasterBase
    {
        DeactivationDescriptionMasterBL.DeactivationDescriptionMasterBL bl = new DeactivationDescriptionMasterBL.DeactivationDescriptionMasterBL();
        public frmDeactivationDescriptionMaster()
        {
            this.searchFilter = "[Description] LIKE '{0}%'";
            InitializeComponent();            
        }

        #region override

        protected override void InitGridColumns(DataGridViewColumnCollection columns)
        {
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ds = bl.SelectAll();
            grdInvisibleColumns.Clear();
            grdInvisibleColumns.Add(ds.Tables[0].Columns["DeactivationReasonID"].ColumnName);
            base.InitGridColumns(columns);
        }

        protected override void SetPrimaryKeys()
        {
            base.SetPrimaryKeys();
            primaryKeys.Add("DeactivationReasonID");
        }

        protected override void Save()
        {
            
            switch (currentFormState)
            {
                case CommonEnum.FormState.NEW_STATE:
                    {                        
                        bl.Insert(populateInsertDataRow());
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

        private DataTable populateInsertDataRow()
        {
            DataTable dt = new DataTable();
            DataRow drTemp;
            dt.Columns.Add("Description");
            dt.Columns.Add("Note");
            drTemp = dt.NewRow();//ds.Tables[0].NewRow();
            foreach (Control control in grpBoxDetail.Controls)
            {
                if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != "DeactivationReasonID")
                {
                    drTemp[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                }                
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != "DeactivationReasonID")
                        {
                            drTemp[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                        }
                    }
                }
            }
            dt.Rows.Add(dr);
            return dt;
        }
    }
}
