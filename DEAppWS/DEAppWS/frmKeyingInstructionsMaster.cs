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
    public partial class frmKeyingInstructionsMaster : frmMasterBase
    {
        private KeyingInstructionsBL.KeyingInstructionsBL bl = new KeyingInstructionsBL.KeyingInstructionsBL();
        private DataSet dsOwnerKey = new DataSet();
        private DataSet dsDeScac = new DataSet();
        private DataView dvOwnerKey = new DataView();
        private DataView dvDeScac = new DataView();

        public frmKeyingInstructionsMaster()
        {
            
            this.searchFilter = "[OwnerKey] LIKE '{0}%' OR [DeScac] LIKE '{0}%' OR [UpdateMachine] LIKE '{0}%'";
            InitializeComponent();
            dsOwnerKey = bl.selectOwnerKey();            
            dsDeScac = bl.selectSCAC("", false);
            setDropDownList();
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
            primaryKeys.Add("OwnerKey");
            primaryKeys.Add("DeScac");
        }

        protected override void Save()
        {
            //base.Save();
            populateDataRow();
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
            dsOwnerKey = bl.selectOwnerKey();
            dsDeScac = bl.selectSCAC(ddlOwnerKey.SelectedValue.ToString(), true);
           // setDropDownList();
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
            readOnlyControlEdit.Add("ddlDeScac");
            readOnlyControlEdit.Add("txtUpdateTimestamp");
            readOnlyControlEdit.Add("txtUpdateUsername");
            readOnlyControlEdit.Add("txtUpdateMachine");
        }

        protected override void SetReadOnlyControlsNew()
        {
            base.SetReadOnlyControlsNew();
            readOnlyControlNew.Add("txtUpdateTimestamp");
            readOnlyControlNew.Add("txtUpdateUsername");
            readOnlyControlNew.Add("txtUpdateMachine");
        }

        protected override void setNewRecord()
        {
            this.clearControls();
            dsDeScac = bl.selectSCAC(ddlOwnerKey.SelectedValue.ToString(), true);
            setDropDownList();            
        }
        #endregion

        private void populateDataRow()
        {
            dt.Clear();
            dr = dt.NewRow();
            foreach (Control control in grpBoxDetail.Controls)
            {
                if (control is TraxDETextBox)
                {
                    if (((TraxDETextBox)control).DatabaseFieldLink == "KeyingInstructions")
                    {
                        dr[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                    }
                   else
                    {
                        switch (((TraxDETextBox)control).DatabaseFieldLink)
                        {
                            case "UpdateUsername":
                                dr[((TraxDETextBox)control).DatabaseFieldLink] = System.Environment.UserName;
                                ((TraxDETextBox)control).Text = System.Environment.UserName;
                                break;
                            case "UpdateMachine":
                                dr[((TraxDETextBox)control).DatabaseFieldLink] = System.Environment.MachineName;
                                ((TraxDETextBox)control).Text = System.Environment.MachineName;
                                break;
                        }
                    }
                }
                else if (control is TraxDEComboBox)
                {
                    dr[((TraxDEComboBox)control).DatabaseFieldLink] = ((TraxDEComboBox)control).SelectedValue;
                }
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                        {
                            if (((TraxDETextBox)control).DatabaseFieldLink == "KeyingInstructions")
                            {
                                dr[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                            }
                          else
                            {
                                switch (((TraxDETextBox)control).DatabaseFieldLink)
                                {
                                    case "UpdateUsername":
                                        dr[((TraxDETextBox)control).DatabaseFieldLink] = System.Environment.UserName;
                                        ((TraxDETextBox)control).Text = System.Environment.UserName;
                                        break;
                                    case "UpdateMachine":
                                        dr[((TraxDETextBox)control).DatabaseFieldLink] = System.Environment.MachineName;
                                        ((TraxDETextBox)control).Text = System.Environment.MachineName;
                                        break;
                                }
                            } 
                        }
                    }
                }
            }
            dt.Rows.Add(dr);
        }

        private void setDropDownList()
        {
            this.dvOwnerKey.Table = dsOwnerKey.Tables[0];
            this.ddlOwnerKey.DisplayMember = "OwnerKey";
            this.ddlOwnerKey.ValueMember = "OwnerKey";
            this.ddlOwnerKey.DataSource = dvOwnerKey;
            //this.ddlOwnerKey.Refresh();
            this.dvDeScac.Table = dsDeScac.Tables[0];
            this.ddlDeScac.DisplayMember = "DeScac";
            this.ddlDeScac.ValueMember = "DeScac";
            this.ddlDeScac.DataSource = dvDeScac;
            //this.ddlVendSCAC.Refresh();
        }

        private void ddlOwnerKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            dsDeScac = bl.selectSCAC(ddlOwnerKey.SelectedValue.ToString(), this.currentFormState == CommonEnum.FormState.NEW_STATE ? true : false);
            setDropDownList();
        } 
    }
}
