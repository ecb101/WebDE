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
    public partial class frmQAConfigMaster : frmMasterBase
    {
        private QAConfigMasterBL.QAConfigMasterBL bl = new QAConfigMasterBL.QAConfigMasterBL();
        private DataSet dsOwnerKey = new DataSet();
        private DataSet dsVendSCAC = new DataSet();
        private DataView dvOwnerKey = new DataView();
        private DataView dvVendSCAC = new DataView();

        public frmQAConfigMaster()
        {
            this.searchFilter = "[Owner_Key] LIKE '{0}%' OR [Vend_SCAC] LIKE '{0}%'";
            InitializeComponent();
            dsOwnerKey = bl.selectOwnerKey();
            dsVendSCAC = bl.selectSCAC("", false);
            setDropDownList();
        }

        #region override

        protected override void InitGridColumns(DataGridViewColumnCollection columns)
        {
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ds = bl.SelectAll();
            grdInvisibleColumns.Clear();
            grdInvisibleColumns.Add(ds.Tables[0].Columns["InvAmt"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["AcctNumVendBlng"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["InvCreatDtm"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["FbAmt"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["FbCreatDtm"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["FbPaymtTermsCode"].ColumnName);
            grdInvisibleColumns.Add(ds.Tables[0].Columns["FbFullQAPercent"].ColumnName);
            base.InitGridColumns(columns);
        }

        protected override void SetPrimaryKeys()
        {
            base.SetPrimaryKeys();
            primaryKeys.Add("Owner_Key");
            primaryKeys.Add("Vend_SCAC");
        }

        protected override void Save()
        {
            base.Save();
            try
            {
                if (Convert.ToInt16(dr["FbFullQAPercent"].ToString()) > 100 || Convert.ToInt16(dr["FbFullQAPercent"].ToString()) < 0)
                {
                    MessageBox.Show("Saving failed, invalid percentage input. ", "QA Config Master");
                }
                else
                {
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
                    dsOwnerKey = bl.selectOwnerKey();
                    dsVendSCAC = bl.selectSCAC(ddlOwnerKey.SelectedValue.ToString(), false);
                    setDropDownList();
                }
            }
            catch
            {
                MessageBox.Show("Saving failed, invalid percentage input.", "QA Config Master");
            }
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
            readOnlyControlEdit.Add("ddlOwnerKey");
            readOnlyControlEdit.Add("ddlVendSCAC");
        }

        protected override void setNewRecord()
        {
            this.clearControls();
            dsVendSCAC = bl.selectSCAC(ddlOwnerKey.SelectedValue.ToString(), true);
            setDropDownList();            
        }
        #endregion

        private void setDropDownList()
        {
            this.dvOwnerKey.Table = dsOwnerKey.Tables[0];
            this.ddlOwnerKey.DisplayMember = "OwnerKey";
            this.ddlOwnerKey.ValueMember = "OwnerKey";
            this.ddlOwnerKey.DataSource = dvOwnerKey;
            //this.ddlOwnerKey.Refresh();
            
            this.dvVendSCAC.Table = dsVendSCAC.Tables[0];
            this.ddlVendSCAC.DisplayMember = "DeScac";
            this.ddlVendSCAC.ValueMember = "DeScac";
            this.ddlVendSCAC.DataSource = dvVendSCAC;
            //this.ddlVendSCAC.Refresh();
        }

        private void ddlOwnerKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsVendSCAC = bl.selectSCAC(ddlOwnerKey.SelectedValue.ToString(), this.currentFormState == CommonEnum.FormState.NEW_STATE? true:false);
            setDropDownList();
        }
    }
}
