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
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmDataEntry : Form
    {
        private BatchEntryBL.BatchEntryBL bl = new BatchEntryBL.BatchEntryBL();        
        private CommonEnum.FormState currentFormState = CommonEnum.FormState.NORMAL_STATE;
        private DataSet dsBatch = new DataSet();
        //private DataSet dsBatchObj = new DataSet();
        private DataSet dsBatches = new DataSet();
        private DataSet dsChargeCode = new DataSet();
        private DataSet dsShipperConsignee = new DataSet();

        private DataView dvInvoice = new DataView();
        private DataView dvFreightBill = new DataView();
        private DataView dvFXI = new DataView();
        private DataView dvFreightBillControls = new DataView();
        private DataView dvFBLine = new DataView();
        private DataView dvBatches = new DataView();
        private DataView dvChargeCode = new DataView();
        private DataView dvShipper = new DataView();
        private DataView dvConsignee = new DataView();

        private DataTable tdTraceDE = new DataTable("Trace");
        private DataRow drVendorInfo;        
        private string MXXDatabase = string.Empty;
        private string MXXOwnerKey = string.Empty;
        private string MXXSCAC = string.Empty;
        private string STATUS = string.Empty;
        private decimal Total;
        private decimal FBTotal;
        private int indexToCopy = -1;
        private bool Secure = false;
        private bool DeleteTriggered = false;
        private bool isInvoiceKeyAlphaNumeric = false;
        private bool isFreightBillKeyAlphaNumeric = false;
        private DataSet dsOwnerKeyAlphaNumeric = new DataSet();
        private AutoCompleteStringCollection orig1 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection orig2 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection orig3 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection orig4 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection cityOrig = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection stateProvOrig = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection postCodeOrig = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection cntryCodeOrig = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection dest1 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection dest2 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection dest3 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection dest4 = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection cityDest = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection stateProvDest = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection postCodeDest = new AutoCompleteStringCollection();
        private AutoCompleteStringCollection cntryCodeDest = new AutoCompleteStringCollection();

        public frmDataEntry()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            this.InvoiceInvCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList());
            this.FBFbCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList());
            this.FBLnT003.Items.AddRange(CommonMethod.getCurrencyList());
            enableToolStripButtons(currentFormState);
            drVendorInfo = getVendorInfoStructure();
            Secure = Convert.ToBoolean(ConfigurationManager.AppSettings["Secure"]);
            dsOwnerKeyAlphaNumeric = bl.selectAlphaNumericKey();
        }

        #region events
        #region grid
        private void grdImageGroup_SelectionChanged(object sender, EventArgs e)
        {   
            populateParameter();
            if (MXXDatabase.Trim() != string.Empty)
            {
                tdTraceDE.Clear();
                dsBatch = Secure ? bl.selectBatch(MXXDatabase.Trim()) : bl.selectBatchObj(MXXDatabase.Trim());
                //dsBatchObj = bl.selectBatchObj(MXXDatabase.Trim());
                bindgrdInvoice();
                grdInvoice_SelectionChanged(null, null);
                setVendorInfo();                
            }
            else
            {
                if (dsBatch != null && dsBatch.Tables.Count > 0)
                {
                    dsBatch.Tables["InvBat"].Clear();
                    dsBatch.Tables["Invoice"].Clear();
                    dsBatch.Tables["FB"].Clear();
                    dsBatch.Tables["FBLn"].Clear();
                }
                bindgrdInvoice();
                this.clearControls();
            }
            indexToCopy = -1;
            enableToolStripButtons(currentFormState);
            determineMode();
            determineMultipleCurrencyMode();
            chkBoxInvoiceAdd.Checked = false;
            chkBoxFBAdd.Checked = false;
            chkBoxFBLnAdd.Checked = false;
        }

        private void grdInvoice_SelectionChanged(object sender, EventArgs e)
        {
            populateParameter();            
            if (MXXDatabase.Trim() != string.Empty)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
                {
                    if (grdInvoice.Rows.Count > 0 && grdInvoice.SelectedRows.Count>0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"].Value.ToString().Trim() == string.Empty)
                        enableControls(false, grpBoxFreightBill.Controls);
                    else
                    {
                        enableControls(true, grpBoxFreightBill.Controls);
                        enableControls(false, grpBoxFbLine.Controls);
                    }
                }
                bindgrdFreightBill();
                grdFreightBill_SelectionChanged(null, null);
                updateInvoiceCounter();                
            }
        }

        private void grdFreightBill_SelectionChanged(object sender, EventArgs e)
        {
            populateParameter();            
            if (MXXDatabase.Trim() != string.Empty)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
                {
                    if (grdFreightBill.Rows.Count>0 && grdFreightBill.SelectedRows.Count > 0)
                    {
                        if (grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbKey"].Value.ToString().Trim() == string.Empty)
                            enableControls(false,grpBoxFbLine.Controls);
                        else
                            enableControls(true, grpBoxFbLine.Controls);
                    }
                    else
                        enableControls(false, grpBoxFbLine.Controls);
                }
                bindControls();
                bindgrdFBLine();
                updateFBCounter();
            }
        }

        private void grdInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            {
                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    if (grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim() != string.Empty)
                    {
                        int length = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Length;
                        int remitId = Convert.ToInt32(grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Substring(length - 5, 5));
                        string SCAC = MXXSCAC;
                        frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC, remitId);
                        frmVendorInfo.ShowDialog();
                        if (frmVendorInfo.VendorInfoSelected)
                        {
                            drVendorInfo = frmVendorInfo.VendorInfoRow;
                            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = drVendorInfo["LocIdRemit"];
                            foreach (DataRow row in ((DataView)grdInvoice.DataSource).Table.Rows)
                            {
                                row["LocIdRemit"] = drVendorInfo["LocIdRemit"];
                                row["AlRemit1"] = drVendorInfo["AlRemit1"];
                                row["AlRemit2"] = drVendorInfo["AlRemit2"];
                                row["AlRemit3"] = drVendorInfo["AlRemit3"];
                                row["AlRemit4"] = drVendorInfo["AlRemit4"];
                                row["AlCityRemit"] = drVendorInfo["AlCityRemit"];
                                row["AlStateProvRemit"] = drVendorInfo["AlStateProvRemit"];
                                row["AlPostCodeRemit"] = drVendorInfo["AlPostCodeRemit"];
                                row["AlCntryCodeRemit"] = drVendorInfo["AlCntryCodeRemit"];
                            }
                        }
                        grdInvoice.Select();
                        grdInvoice.CurrentCell = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"];
                    }
                }
            }
        }

        private void grdInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataView dv = new DataView();
            dv.Table = dsBatch.Tables["Invoice"];
            dv.RowFilter = string.Format("InvId = '{0}'", grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvId"].Value.ToString().Trim());
            dv[0].BeginEdit();
            if (e.ColumnIndex == 3)
            {
                if (grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvKey"].Value.ToString().Trim() != string.Empty)
                {
                    string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvKey"].Value.ToString().Trim().Replace(" ", string.Empty);
                    string invId = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvId"].Value.ToString().Trim();
                    if (isInvoiceKeyAlphaNumeric)
                    {
                        Regex regStr = new Regex("[^a-zA-Z0-9]");
                        value = regStr.Replace(value, string.Empty);                        
                    }
                    grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvKey"].Value = value;
                    checkInvoiceKeyDuplicate(value, invId);
                    enableControls(true, grpBoxFreightBill.Controls);
                    if (grdFreightBill.SelectedRows.Count > 0 && grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbKey"].Value.ToString().Trim() != string.Empty)
                        enableControls(true, grpBoxFbLine.Controls);
                    else
                        enableControls(false, grpBoxFbLine.Controls);
                    updateInvKey(value, invId);
                }
                else
                    if (grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvKey"].Value.ToString().Trim() == string.Empty)
                        enableControls(false, grpBoxFreightBill.Controls);                
            }
            else if (e.ColumnIndex == 4)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvCurrencyQual"].Value.ToString().Trim();
                if (chkBoxMultipleCurr.Checked)
                {
                    if (MessageBox.Show("Your action will reset all amount in your multiple currency line items, proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)                                            
                        updateCurrencyQual(value);
                }
                else                
                    updateCurrencyQual(value);                
            }
            else if (e.ColumnIndex == 5)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceVendInvAmt"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                {
                    if (Convert.ToDecimal(value) >= 0)
                        grdInvoice.Rows[e.RowIndex].Cells["InvoiceVendInvAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                    
                    else
                        grdInvoice.Rows[e.RowIndex].Cells["InvoiceVendInvAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");                    
                }
                setFBTotalLable();
            }
            else if (e.ColumnIndex == 6)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceAcctIdVendBlng"].Value.ToString().Trim().Replace(" ", string.Empty);
                string invId = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvId"].Value.ToString().Trim();
                grdInvoice.Rows[e.RowIndex].Cells["InvoiceAcctIdVendBlng"].Value = value;
                updateAcctNumVendBlng(value, invId);
            }
            dv[0].EndEdit();
        }

        private void grdFreightBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataView dv = new DataView();
            dv.Table = dsBatch.Tables["FB"];
            dv.RowFilter = string.Format("FbId = '{0}'", grdFreightBill.Rows[e.RowIndex].Cells["FBFbId"].Value.ToString().Trim());
            dv[0].BeginEdit();
            if (e.ColumnIndex == 3 )
            {
                if (grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value.ToString().Trim() != string.Empty)
                {
                    string value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value.ToString().Trim().Replace(" ", string.Empty);
                    string invId = grdFreightBill.Rows[e.RowIndex].Cells["FBFbId"].Value.ToString().Trim();
                    if (isFreightBillKeyAlphaNumeric)
                    {
                        Regex regStr = new Regex("[^a-zA-Z0-9]");
                        value = regStr.Replace(value, string.Empty);
                    }
                    if (radioSingleFB.Checked)
                    {
                        grdInvoice.Rows[0].Cells["InvoiceInvKey"].Value = value;
                        grdFreightBill.Rows[e.RowIndex].Cells["FBInvKey"].Value = value;
                    }                    
                    grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value = value;
                    checkFBKeyDuplicate(value, invId);
                    enableControls(true, grpBoxFbLine.Controls);
                }
                else
                    if (grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value.ToString().Trim() == string.Empty)
                        enableControls(false, grpBoxFbLine.Controls);
                
            }
            else if (e.ColumnIndex == 4)
            {
                string value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbCurrencyQual"].Value.ToString().Trim();
                if (chkBoxMultipleCurr.Checked)
                {
                    if (MessageBox.Show("Your action will reset all amount in your multiple currency line items, proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)                                            
                        updateCurrencyQual(value);                    
                }
                else
                    updateCurrencyQual(value);
            }
            else if (e.ColumnIndex == 5)
            {
                string value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                {
                    if (Convert.ToDecimal(value) >= 0)                    
                        grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");                    
                    else                    
                        grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                }
                
                FBTotal = 0;
                if (grdFreightBill.Rows.Count > 0) 
                {
                    foreach (DataGridViewRow row in grdFreightBill.Rows)
                    {
                        if (row.Cells["FBFbAmt"].Value.ToString() != string.Empty)
                            FBTotal = FBTotal + Convert.ToDecimal(row.Cells["FBFbAmt"].Value);
                    }                    
                }
                else                
                    FBTotal = 0;
                
                if (grdInvoice.Rows.Count > 0 && grdInvoice.SelectedRows.Count > 0)
                {
                    DataView dvInvoice = new DataView();
                    dvInvoice.Table = dsBatch.Tables["Invoice"];
                    dvInvoice.RowFilter = string.Format("InvId = '{0}'", grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim());
                    if (dvInvoice[0].Row.RowState != DataRowState.Modified && dvInvoice[0].Row.RowState != DataRowState.Added)
                        dvInvoice[0].Row.SetModified();
                    grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvAmt"].Value = FBTotal.ToString();
                }
                if (radioSingleFB.Checked)
                    grdInvoice.Rows[0].Cells["InvoiceVendInvAmt"].Value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value.ToString();

                setFBTotalLable();
                setFBLnTotalLable();
            }
            else if (e.ColumnIndex == 39)
            {
                if (radioSingleFB.Checked)
                    grdInvoice.Rows[0].Cells["InvoiceAcctIdVendBlng"].Value = grdFreightBill.Rows[e.RowIndex].Cells["FBAcctNumVendBlng"].Value.ToString();
            }
            dv[0].EndEdit();
        }
        
        private void grdFBLine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataView dv = new DataView();
            try
            {                
                dv.Table = dsBatch.Tables["FBLn"];
                dv.RowFilter = string.Format("FbId = '{0}' AND LineItemNum = '{1}'", grdFBLine.Rows[e.RowIndex].Cells["FBLnFbId"].Value.ToString().Trim(), grdFBLine.Rows[e.RowIndex].Cells["FBLnLineItemNum"].Value.ToString().Trim());
                dv[0].BeginEdit();
                if (e.ColumnIndex == 3)
                {
                    if (grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value.ToString().Trim() != string.Empty)
                    {
                        dvChargeCode.RowFilter = string.Format("LnChrgCode = '{0}'", grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value.ToString().Trim());
                        if (dvChargeCode.Count == 1)
                        {
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgDesc"].Value = dvChargeCode[0]["LnChrgDesc"].ToString();
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value = dvChargeCode[0]["LnCat"].ToString();
                        }
                        else
                        {
                            dvChargeCode.RowFilter = string.Empty;
                            frmChargeCodeLookUp frmChargeCodeLookUp = new frmChargeCodeLookUp(dvChargeCode);
                            frmChargeCodeLookUp.ShowDialog();
                            if (frmChargeCodeLookUp.ChargeCodeSelected)
                            {
                                grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value = frmChargeCodeLookUp.ChargeCodeRow["LnChrgCode"].ToString();
                                grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgDesc"].Value = frmChargeCodeLookUp.ChargeCodeRow["LnChrgDesc"].ToString();
                                grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value = frmChargeCodeLookUp.ChargeCodeRow["LnCat"].ToString();
                            }
                            else
                            {
                                grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value = string.Empty;
                                grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgDesc"].Value = string.Empty;
                                grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value = string.Empty;
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgDesc"].Value = string.Empty;
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value = string.Empty;
                    }
                }
                else if (e.ColumnIndex == 11 && grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value.ToString().Trim() != string.Empty)
                {
                    bool flag = false;
                    if (grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value.ToString().Trim() == "FREIGHT")
                    {
                        flag = true;
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value = "400";
                    }
                    else if (grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value.ToString().Trim() == "TAX")
                    {
                        flag = true;
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value = "TAX";
                    }
                    else if (grdFBLine.Rows[e.RowIndex].Cells["FBLnCat"].Value.ToString().Trim() == "DISCOUNT")
                    {
                        flag = true;
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value = "DSC";
                    }
                    if (flag)
                    {
                        dvChargeCode.RowFilter = string.Format("LnChrgCode = '{0}'", grdFBLine.Rows[e.RowIndex].Cells["FBLnLnChrgCode"].Value.ToString().Trim());
                        if (dvChargeCode.Count == 1)
                        {
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgDesc"].Value = dvChargeCode[0]["LnChrgDesc"].ToString();
                        }
                    }
                }

                if (e.ColumnIndex == 12)
                {
                    if (grdFBLine.Rows[e.RowIndex].Cells["FBLnLnRateAsWt"].Value.ToString().Trim() == string.Empty)
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnLnRateAsWt"].Value = grdFBLine.Rows[e.RowIndex].Cells["FBLnLnActualWt"].Value.ToString();
                }

                if (e.ColumnIndex == 15)
                {
                    string value = grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value.ToString().Trim();
                    if (value != string.Empty && !value.Contains('.'))
                    {
                        if (Convert.ToDecimal(value) >= 0)
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                        else
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    }
                    setFBLnTotal();
                }

                if (e.ColumnIndex == 17)
                {
                    string value = grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value.ToString().Trim();
                    if (value != string.Empty && !value.Contains('.'))
                    {
                        if (Convert.ToDecimal(value) >= 0)
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                        else
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    }
                    if (grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value != DBNull.Value && grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value != DBNull.Value)
                    {
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value = Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value).ToString("###,###,###,###.#000000");
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = decimal.Round(Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value) * Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value) * Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT004"].Value), 2).ToString();
                    }
                    else
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = "0.0000";

                    setFBLnTotal();
                }

                if (e.ColumnIndex == 18)
                {
                    string value = grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value.ToString().Trim();
                    if (value != string.Empty && !value.Contains('.'))
                    {
                        if (Convert.ToDecimal(value) >= 0)
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                        else
                            grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    }
                    if (grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value != DBNull.Value && grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value != DBNull.Value)
                    {
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value = Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value).ToString("###,###,###,###.#000");
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = decimal.Round(Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT002"].Value) * Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT001"].Value) * Convert.ToDecimal(grdFBLine.Rows[e.RowIndex].Cells["FBLnT004"].Value), 2).ToString();
                    }
                    else
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = "0.0000";

                    setFBLnTotal();
                }
                if (e.ColumnIndex == 19)
                {
                    //set rate
                }                
            }
            catch (System.FormatException error)
            {
                MessageBox.Show(error.Message, "Data Entry");
                grdFBLine.CurrentCell = grdFBLine.Rows[e.RowIndex].Cells[e.ColumnIndex];
                grdFBLine.CancelEdit();
            }
            finally
            {
                dv[0].EndEdit();
            }
        }

        private void grdFXI_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataView dv = new DataView();
            dv.Table = dsBatch.Tables["FXI"];
            dv.RowFilter = string.Format("FbId = '{0}'", grdFXI.Rows[e.RowIndex].Cells["FbId"].Value.ToString().Trim());
            dv[0].BeginEdit();
            dv[0].EndEdit();
        }

        private void grdInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            {
                if (e.KeyChar == 13)
                {
                    if ((grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"] || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"]) && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim() != string.Empty)
                    {
                        int length = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Length;
                        int remitId = Convert.ToInt32(grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Substring(length - 5, 5));
                        string SCAC = MXXSCAC;
                        frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC, remitId);
                        frmVendorInfo.ShowDialog();
                        if (frmVendorInfo.VendorInfoSelected)
                        {
                            drVendorInfo = frmVendorInfo.VendorInfoRow;
                            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = drVendorInfo["LocIdRemit"];
                            foreach (DataRow row in ((DataView)grdInvoice.DataSource).Table.Rows)
                            {
                                row["LocIdRemit"] = drVendorInfo["LocIdRemit"];
                                row["AlRemit1"] = drVendorInfo["AlRemit1"];
                                row["AlRemit2"] = drVendorInfo["AlRemit2"];
                                row["AlRemit3"] = drVendorInfo["AlRemit3"];
                                row["AlRemit4"] = drVendorInfo["AlRemit4"];
                                row["AlCityRemit"] = drVendorInfo["AlCityRemit"];
                                row["AlStateProvRemit"] = drVendorInfo["AlStateProvRemit"];
                                row["AlPostCodeRemit"] = drVendorInfo["AlPostCodeRemit"];
                                row["AlCntryCodeRemit"] = drVendorInfo["AlCntryCodeRemit"];
                            }
                        }
                        grdInvoice.Select();
                        grdInvoice.CurrentCell = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"];
                    }
                }
            }
        }
        #endregion

        #region toolStrip
        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {                        
            if (this.grdImageGroup.SelectedRows.Count > 0)
            {
                populateParameter();
                if (MXXDatabase.Trim() != string.Empty)
                {
                    try
                    {
                        if (bl.isAllowBatchStart(MXXDatabase) && bl.isAllowEdit(MXXDatabase, System.Environment.UserName))
                        {
                            if (bl.startBatch(MXXDatabase.Trim(), CommonUserLogin.getUser().UserInitials))//update ang Batch_DE Oper_Init, DE_START_DTM, DE_File_Name
                            {
                                bl.auditTrailBatch(MXXDatabase, "102", System.Environment.UserName);
                                STATUS = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["BatchStatus"].Value.ToString();
                                if (Secure)
                                {
                                    this.makeMDBCopy(MXXDatabase.Trim());
                                    bl.insertTRBat(MXXOwnerKey, "MXX" + MXXDatabase.Trim(), CommonUserLogin.getUser().UserInitials);
                                    dsBatch = bl.selectBatch(MXXDatabase.Trim());
                                }
                                else
                                    dsBatch = bl.selectBatchObj(MXXDatabase.Trim());
                                
                                bindgrdInvoice();
                                currentFormState = CommonEnum.FormState.EDIT_STATE;
                                enableToolStripButtons(currentFormState);
                            }
                            else
                                MessageBox.Show("There was a problem when starting this batch.", "Data Entry");
                        }
                        else
                            MessageBox.Show("This batch was started by a different user.", "Data Entry");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }   
                }
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (bl.isAllowUserEntry(MXXDatabase, CommonUserLogin.getUser().UserInitials))
                {
                    if (bl.isAllowEdit(MXXDatabase, System.Environment.UserName))
                    {
                        STATUS = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["BatchStatus"].Value.ToString();
                        currentFormState = CommonEnum.FormState.EDIT_STATE;
                        enableToolStripButtons(currentFormState);
                    }
                    else
                        MessageBox.Show("There was a problem when setting this batch to edit mode.", "Data Entry");
                }
                else
                    MessageBox.Show("This batch was started by a different user or was not started properly.", "Data Entry");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void toolStripButtonSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteTriggered)
                {
                    updateInvoiceID();
                    updateFBID();
                    updateFBLnLineNumber();
                    DeleteTriggered = false;
                }
                updateCounter();
                if (Secure ? bl.saveBatch(dsBatch, MXXDatabase, MXXOwnerKey) : bl.saveBatchObj(dsBatch, MXXDatabase, MXXOwnerKey))
                {                    
                    bl.updateStatus(MXXDatabase, "IN DE");
                    bl.auditTrailBatch(MXXDatabase, "103", System.Environment.UserName);
                    //if (Secure)
                    //    bl.repairDatabase(MXXDatabase);
                    dsBatches = bl.selectBatches();
                    dsBatch = Secure ? bl.selectBatch(MXXDatabase.Trim()) : bl.selectBatchObj(MXXDatabase.Trim());
                    bindgrdBatches();
                    bindgrdInvoice();
                    bindgrdFreightBill();
                    bindgrdFBLine();
                    MessageBox.Show("Saving successful.", "Data Entry");
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    enableToolStripButtons(currentFormState);
                    STATUS = string.Empty;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteTriggered)
                {
                    updateInvoiceID();
                    updateFBID();
                    updateFBLnLineNumber();
                    DeleteTriggered = false;
                }
                updateCounter();
                if (Secure)
                {
                    if (bl.saveBatch(dsBatch, MXXDatabase, MXXOwnerKey))
                    {                        
                        //bl.repairDatabase(MXXDatabase);
                        dsBatch = bl.selectBatch(MXXDatabase.Trim());
                        bindgrdInvoice();
                        bindgrdFreightBill();
                        bindgrdFBLine();
                        MessageBox.Show("Saving successful.", "Data Entry");
                    }
                }
                else
                {
                    if (bl.saveBatchObj(dsBatch, MXXDatabase, MXXOwnerKey))
                    {
                        dsBatch = bl.selectBatchObj(MXXDatabase.Trim());
                        bindgrdInvoice();
                        bindgrdFreightBill();
                        bindgrdFBLine();
                        MessageBox.Show("Saving successful.", "Data Entry");
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void toolStripButtonRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to restart this batch?", "Batch Restart", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (Secure ? bl.restartBatch(MXXDatabase) : deleteObject(MXXDatabase))
                    {
                        //if (Secure)
                        //    bl.repairDatabase(MXXDatabase);
                        bl.updateStatus(MXXDatabase, "IN DE");
                        bl.auditTrailBatch(MXXDatabase, "105", System.Environment.UserName);
                        dsBatches = bl.selectBatches();
                        bindgrdBatches();
                        MessageBox.Show("Batch restarted successfully.", "Data Entry");
                        this.clearControls();
                        grdImageGroup_SelectionChanged(null, null);
                        currentFormState = CommonEnum.FormState.NORMAL_STATE;
                        enableToolStripButtons(currentFormState);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private void toolStripButtonSendReview_Click(object sender, EventArgs e)
        {
            if (isAllowedSendForReview())
            {
                isCurrencyAdjustmentAllowed();
                if (MessageBox.Show(isTotalEqual() == true ? "Are you sure to send this batch for review?" : "The amount did not sum up correctly. Do you wish to proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (DeleteTriggered)
                        {
                            updateInvoiceID();
                            updateFBID();
                            updateFBLnLineNumber();
                            DeleteTriggered = false;
                        }
                        updateFBValues();
                        updateCounter();
                        if (Secure ? bl.saveBatch(dsBatch, MXXDatabase, MXXOwnerKey) : bl.saveBatchObj(dsBatch, MXXDatabase, MXXOwnerKey))
                        {
                            bl.saveShipperConsigneeInfo(dsBatch.Tables["FB"]);
                            
                            //if (Secure)
                            //    bl.repairDatabase(MXXDatabase);
                            this.clearControls();
                            bl.sendForReview(MXXDatabase);//update Batch_DE DE_FIN_DTM
                            bl.auditTrailBatch(MXXDatabase, "106", System.Environment.UserName);
                            dsBatches.AcceptChanges();
                            bindgrdBatches();
                            grdImageGroup_SelectionChanged(null, null);
                            MessageBox.Show("Batch successfully sent for review.", "Data Entry");
                            currentFormState = CommonEnum.FormState.NORMAL_STATE;
                            enableToolStripButtons(currentFormState);
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel all changes done?", "Cancel updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    this.clearControls();
                    bl.updateStatus(MXXDatabase, STATUS);
                    bl.auditTrailBatch(MXXDatabase, "104", System.Environment.UserName);
                    dsBatches = bl.selectBatches();
                    bindgrdBatches();
                    grdImageGroup_SelectionChanged(null, null);
                    enableToolStripButtons(currentFormState);
                    STATUS = string.Empty;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region others
        private void frmDataEntry_Load(object sender, EventArgs e)
        {
            dsChargeCode = bl.selectChargeCode();
            dvChargeCode.Table = dsChargeCode.Tables[0];
            //dsShipperConsignee = bl.selectShipperConsignee();
            //dvShipper.Table = dsShipperConsignee.Tables["Shipper"];
            //dvConsignee.Table = dsShipperConsignee.Tables["Consignee"];
            //this.setAutoCompleteData(true);
            //this.setAutoCompleteData(false);
        }

        private void frmDataEntry_Enter(object sender, EventArgs e)
        {
            dsBatches = bl.selectBatches();
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
            if (dsBatches.Tables[0].Rows.Count == 0)
                enableToolStripButtons(currentFormState);
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {            
            string SCAC = MXXSCAC;
            string ownerKey = MXXOwnerKey.Remove(3, 1);
            string batchNumber = "MXX" + MXXDatabase;
            if (drVendorInfo["LocIdRemit"].ToString().Trim() == string.Empty)//check if need to pick remit address. 
            {
                frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC);
                frmVendorInfo.ShowDialog();
                if (frmVendorInfo.VendorInfoSelected)
                    drVendorInfo = frmVendorInfo.VendorInfoRow;
            }
            if (drVendorInfo["LocIdRemit"].ToString().Trim() != string.Empty)
            {
                if (dsBatch.Tables["InvBat"].Rows.Count == 0 || dsBatch.Tables["InvBat"].Rows[0].RowState == DataRowState.Deleted)
                {
                    DataRow rowInvBat = dsBatch.Tables["InvBat"].NewRow();
                    rowInvBat["BatId"] = "BACH" + ownerKey + batchNumber + (0).ToString().PadLeft(4, '0');
                    rowInvBat["OwnerKey"] = MXXOwnerKey;
                    rowInvBat["VendBatKey"] = batchNumber;
                    rowInvBat["VendBatDtm"] = DateTime.Now;
                    rowInvBat["VendLabl"] = SCAC;
                    rowInvBat["VendFeed"] = batchNumber;
                    rowInvBat["BatKey"] = "MXX" + MXXDatabase.Trim();
                    rowInvBat["BatCreatDtm"] = DateTime.Now;
                    rowInvBat["BatLocIdRemit"] = drVendorInfo["LocIdRemit"];
                    dsBatch.Tables["InvBat"].Rows.InsertAt(rowInvBat, 0);// Add(rowInvBat);
                }
                DataRow row = ((DataView)grdInvoice.DataSource).Table.NewRow();
                string invoiceCount = dsBatch.Tables["Invoice"].DefaultView.Count == 0 ? (1).ToString().PadLeft(4, '0') : (Convert.ToInt16(dsBatch.Tables["Invoice"].DefaultView[dsBatch.Tables["Invoice"].DefaultView.Count - 1]["InvId"].ToString().Substring(19, 4)) + 1).ToString().PadLeft(4, '0');
                row["InvId"] = "INVC" + ownerKey + batchNumber + invoiceCount;
                row["VendLabl"] = SCAC;
                row["LocIdRemit"] = drVendorInfo["LocIdRemit"];
                row["AlRemit1"] = drVendorInfo["AlRemit1"];
                row["AlRemit2"] = drVendorInfo["AlRemit2"];
                row["AlRemit3"] = drVendorInfo["AlRemit3"];
                row["AlRemit4"] = drVendorInfo["AlRemit4"];
                row["AlCityRemit"] = drVendorInfo["AlCityRemit"];
                row["AlStateProvRemit"] = drVendorInfo["AlStateProvRemit"];
                row["AlPostCodeRemit"] = drVendorInfo["AlPostCodeRemit"];
                row["AlCntryCodeRemit"] = drVendorInfo["AlCntryCodeRemit"];
                row["VendInvAmt"] = 0;
                row["InvAmt"] = 0;
                row["InvFbCnt"] = 0;
                if (dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"].ToString().Trim() != string.Empty)
                    row["InvCurrencyQual"] = dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"];
                else
                {
                    dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"] = "USD";
                    row["InvCurrencyQual"] = dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"];
                }
                if (radioSingleFB.Checked)
                    row["InvStat"] = "SingleBill";
                dsBatch.Tables["Invoice"].Rows.Add(row);
                bindgrdInvoice();
                grdInvoice.Select();
                grdInvoice.Rows[grdInvoice.Rows.Count - 1].Selected = true;
                if (grdInvoice.SelectedRows.Count > 0 && !radioSingleFB.Checked)
                    grdInvoice.CurrentCell = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"];
                setReadOnlyGridColumns(grdInvoice);
                updateInvoiceCounter();                
            }
            enableModeGroupControl(grdInvoice.Rows.Count > 0 ? false : true);
            if (chkBoxInvoiceAdd.Checked && grdInvoice.Rows.Count > 0)
                autoSave();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            string messege = string.Empty;
            string header = string.Empty;
            if (radioSingleFB.Checked)
            {
                messege = "Are you sure you want to delete this freight bill and all the line items under this bill?";
                header = "Delete Freight Bill";
            }
            else
            {
                messege = "Are you sure you want to delete this invoice and all freight bills and line items under this invoice?";
                header = "Delete Invoice";
            }

            if (grdInvoice.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(messege, header, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.dvFreightBill.RowFilter = string.Format("InvId = '{0}'", grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim());
                    foreach (DataRow row in dvFreightBill.ToTable().Rows)
                        deleteFBLn(string.Format("FbId = '{0}'", row["FbId"].ToString().Trim()));
                    deleteFB(string.Format("InvId = '{0}'", grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim()));
                    deleteInvoice(string.Format("InvId = '{0}'", grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim()));
                    bindgrdInvoice();
                    bindgrdFreightBill();
                    bindControls();
                    bindgrdFBLine();
                    if (dvInvoice.Count == 0)
                    {
                        dsBatch.Tables["InvBat"].Rows[0].Delete();
                        setVendorInfo();
                        if (radioSingleFB.Checked)
                        {
                            enableControls(true, grpBoxFreightBill.Controls);
                            enableControls(false, grpBoxFbLine.Controls);
                        }
                        else                        
                            enableControls(false, grpBoxFreightBill.Controls);
                        
                    }
                    updateInvoiceCounter();
                    DeleteTriggered = true;
                    //add audit trail : Delete invoice
                }
            }
        }

        private void btnAddFB_Click(object sender, EventArgs e)
        {            
            if (radioSingleFB.Checked)
            {
                btnAddInvoice_Click(null, null);
                enableControls(true , grpBoxFreightBill.Controls);
                enableControls(false, grpBoxFbLine.Controls);
                btnAddFB.Enabled =  grdInvoice.Rows.Count > 0 ? false : true;                
            }

            if (grdInvoice.SelectedRows.Count > 0)
            {
                DataRow row = ((DataView)grdFreightBill.DataSource).Table.NewRow();
                string ownerKey = MXXOwnerKey.Remove(3, 1);
                string batchNumber = "MXX" + MXXDatabase;
                string FBCount = dsBatch.Tables["FB"].DefaultView.Count == 0 ? (1).ToString().PadLeft(4, '0') : (Convert.ToInt16(dsBatch.Tables["FB"].DefaultView[dsBatch.Tables["FB"].DefaultView.Count - 1]["FbId"].ToString().Substring(19, 4)) + 1).ToString().PadLeft(4, '0');
                row["InvId"] = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim();
                row["InvKey"] = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"].Value.ToString().Trim();
                row["FbId"] = "FBLL" + ownerKey + batchNumber + FBCount;
                row["VendLabl"] = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceVendLabl"].Value.ToString().Trim();
                row["AcctNumVendBlng"] = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAcctIdVendBlng"].Value.ToString().Trim();
                row["FbAmt"] = 0;
                row["FbLnCnt"] = 0;
                if (dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"].ToString().Trim() != string.Empty)
                    row["FbCurrencyQual"] = dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"];
                dsBatch.Tables["FB"].Rows.Add(row);
                bindgrdFreightBill();
                grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvFbCnt"].Value = grdFreightBill.Rows.Count.ToString();
                grdFreightBill.Select();
                grdFreightBill.Rows[grdFreightBill.Rows.Count - 1].Selected = true;
                if (grdFreightBill.SelectedRows.Count > 0)
                    grdFreightBill.CurrentCell = grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbKey"];
                updateFBCounter();
                DataRow rowFXI = dsBatch.Tables["FXI"].NewRow();
                rowFXI["FbId"] = "FBLL" + ownerKey + batchNumber + FBCount;
                rowFXI["VendLabl"] = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceVendLabl"].Value.ToString().Trim();
                rowFXI["InvId"] = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim();
                rowFXI["BatId"] = "BACH" + ownerKey + batchNumber + (0).ToString().PadLeft(4, '0');
                dsBatch.Tables["FXI"].Rows.Add(rowFXI);
                if (chkBoxFBAdd.Checked && grdFreightBill.Rows.Count > 0)
                    autoSave();
            }
        }

        private void btnDeleteFB_Click(object sender, EventArgs e)
        {
            if (radioSingleFB.Checked)
            {
                btnDeleteInvoice_Click(null, null);
                enableModeGroupControl(grdInvoice.Rows.Count > 0 ? false : true);
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete this freight bill and all the line items under this bill?", "Delete Freight Bill", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (grdFreightBill.SelectedRows.Count > 0)
                    {
                        deleteFBLn(string.Format("FbId = '{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim()));
                        deleteFB(string.Format("FbId = '{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim()));
                        bindgrdFreightBill();
                        bindControls();
                        bindgrdFBLine();
                        FBTotal = 0;
                        if (grdFreightBill.Rows.Count > 0)
                        {
                            foreach (DataGridViewRow row in grdFreightBill.Rows)
                            {
                                if (row.Cells["FBFbAmt"].Value.ToString() != string.Empty)
                                    FBTotal = FBTotal + Convert.ToDecimal(row.Cells["FBFbAmt"].Value);
                            }
                        }
                        else
                            FBTotal = 0;
                        if (grdInvoice.Rows.Count > 0 && grdInvoice.SelectedRows.Count > 0)
                        {
                            grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvFbCnt"].Value = grdFreightBill.Rows.Count.ToString();
                            grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvAmt"].Value = FBTotal.ToString();
                        }
                        updateFBCounter();
                        DeleteTriggered = true;
                        //add audit trail : Deleted freight bill
                    }                    
                }
            }
        }

        private void btnAddFBLn_Click(object sender, EventArgs e)
        {       
            if (grdFreightBill.SelectedRows.Count > 0)
            {                
                DataRow row = ((DataView)grdFBLine.DataSource).Table.NewRow();
                row["LineItemNum"] = grdFBLine.Rows.Count == 0 ? 1 : Convert.ToInt16(grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLineItemNum"].Value) + 1;
                row["FbId"] = grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim();
                row["RateType"] = "PER";
                row["ChrgAmt"] = 0;                
                if (dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"].ToString().Trim() != string.Empty)
                    row["CurrencyQual"] = dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"];
                if (chkBoxMultipleCurr.Checked)
                {
                    row["T001"] = "1.0000000";
                    row["T002"] = Convert.ToDecimal(row["ChrgAmt"]).ToString("###,###,###,###.#000");
                    row["T003"] = row["CurrencyQual"];
                    row["T004"] = "1.0000000";
                    row["T005"] = row["CurrencyQual"];
                    row["T006"] = "MultipleCurrency";
                }
                dsBatch.Tables["FBLn"].Rows.Add(row);
                bindgrdFBLine();
                grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbLnCnt"].Value = grdFBLine.Rows.Count.ToString();
                grdFBLine.Select();
                grdFBLine.Rows[grdFBLine.Rows.Count - 1].Selected = true;
                grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells[3];
                if (chkBoxFBLnAdd.Checked)
                    autoSave();                
            }
        }

        private void btnDeleteFBLn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Line Item?", "Delete Line Item", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                deleteFBLn(string.Format("FbId = '{0}' AND LineItemNum = '{1}'", grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnFbId"].Value.ToString().Trim(), grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnLineItemNum"].Value.ToString().Trim()));
                bindgrdFBLine();
                if (grdFreightBill.SelectedRows.Count > 0)
                    grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbLnCnt"].Value = grdFBLine.Rows.Count.ToString();
                DeleteTriggered = true;
                //add audit trail : Deleted freight bill Line
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
        }

        private void txtTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!txtTerm.ReadOnly)
            {
                if (e.KeyChar == 't' || e.KeyChar == 'T')
                    txtTerm.Text = "P";
                else if (e.KeyChar == 'p' || e.KeyChar == 'P')
                    txtTerm.Text = "P";
                else if (e.KeyChar == 'c' || e.KeyChar == 'C')
                    txtTerm.Text = "C";
                else
                    e.Handled = true;
            }
        }

        private void frmDataEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            {
                MessageBox.Show("Cannot close in Edit or Open mode.", "Data Entry");
                e.Cancel = true;
            }
        }

        private void frmDataEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            {
                if (e.Control == true && e.KeyValue == 66)//Ctrl+B
                {
                    if (chkBoxMultipleCurr.Checked)
                    {
                        ArrayList content = new ArrayList();
                        content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT003"].Value.ToString());//Currency1
                        content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT005"].Value.ToString()); //Currency2
                        content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnCurrencyQual"].Value.ToString());//OutputCurrency
                        content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnFacsimile02"].Value.ToString());//OriginalItem
                        content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT001"].Value.ToString());//Exchange Rate 1
                        content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT004"].Value.ToString());//Exchange Rate 2
                        content.Add(grdFBLine.Rows.Count);//RowCount
                        content.Add(grdFBLine.SelectedRows[0].Index);//Selected LineItem
                        frmCurrencyBreakDown frmCurrencyBreakDown = new frmCurrencyBreakDown(content);

                        //frmCurrencyBreakDown frmCurrencyBreakDown = new frmCurrencyBreakDown(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT003"].Value.ToString(), grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT005"].Value.ToString(), grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnCurrencyQual"].Value.ToString(), grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnFacsimile02"].Value.ToString(), grdFBLine.Rows.Count, grdFBLine.SelectedRows[0].Index);
                        frmCurrencyBreakDown.ShowDialog();
                        if (frmCurrencyBreakDown.ComputedBreakdown)
                        {
                            int index = 0;
                            foreach (object lineItem in frmCurrencyBreakDown.LineItemRange)
                            {
                                index = Convert.ToInt16(lineItem) - 1;
                                grdFBLine.Rows[index].Cells["FBLnT001"].Value = frmCurrencyBreakDown.ExchangeRateAmount1.ToString("###,###,###,###.#000000");
                                grdFBLine.Rows[index].Cells["FBLnT003"].Value = frmCurrencyBreakDown.InitialCurrency;
                                grdFBLine.Rows[index].Cells["FBLnT004"].Value = frmCurrencyBreakDown.ExchangeRateAmount2.ToString();
                                grdFBLine.Rows[index].Cells["FBLnT005"].Value = frmCurrencyBreakDown.SecondaryCurrency;
                                grdFBLine.Rows[index].Cells["FBLnFacsimile02"].Value = frmCurrencyBreakDown.OriginalLineItem;
                                if (grdFBLine.Rows[index].Cells["FBLnT001"].Value != DBNull.Value && grdFBLine.Rows[index].Cells["FBLnT002"].Value != DBNull.Value)
                                {
                                    grdFBLine.Rows[index].Cells["FBLnT001"].Value = Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnT001"].Value).ToString("###,###,###,###.#000000");
                                    grdFBLine.Rows[index].Cells["FBLnChrgAmt"].Value = decimal.Round(Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnT002"].Value) * Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnT001"].Value) * Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnT004"].Value), 2).ToString();
                                }
                                else
                                    grdFBLine.Rows[index].Cells["FBLnChrgAmt"].Value = "0.0000";
                            }
                        }
                        setFBLnTotal();
                        grdFBLine.Select();
                        grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells[18];
                    }
                
                }
                else if (e.Control == true && e.KeyValue == 70)//Ctrl+F
                {
                    if (btnAddFB.Enabled)
                        btnAddFB_Click(null, null);
                }
                else if (e.Control == true && e.KeyValue == 73)//Ctrl+I
                {
                    if (btnAddInvoice.Enabled)
                        btnAddInvoice_Click(null, null);
                }
                else if (e.Control == true && e.KeyValue == 75)//Ctrl+K                
                {
                    if (grdFBLine.SelectedRows.Count > 0)
                    {
                        dvChargeCode.RowFilter = string.Empty;
                        frmChargeCodeLookUp frmChargeCodeLookUp = new frmChargeCodeLookUp(dvChargeCode);
                        frmChargeCodeLookUp.ShowDialog();
                        if (frmChargeCodeLookUp.ChargeCodeSelected)
                        {
                            grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnLnChrgCode"].Value = frmChargeCodeLookUp.ChargeCodeRow["LnChrgCode"].ToString();
                            grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnChrgDesc"].Value = frmChargeCodeLookUp.ChargeCodeRow["LnChrgDesc"].ToString();
                            grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnCat"].Value = frmChargeCodeLookUp.ChargeCodeRow["LnCat"].ToString();
                            SendKeys.Send("{ENTER}");
                        }
                    }
                }
                else if (e.Control == true && e.KeyValue == 76)//Ctrl+L                
                {
                    if (btnAddFBLn.Enabled)
                    {
                        grdFBLine.EndEdit();
                        btnAddFBLn_Click(null, null);
                    }
                }
                else if ((e.Control == true && e.KeyValue == 69))//Ctrl+E
                {
                    if (grdInvoice.Rows.Count == 0)//check needed to add invoice
                    {
                        btnAddInvoice_Click(null, null);
                    }
                    else
                    {
                        if (grdInvoice.SelectedRows.Count > 0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim() != string.Empty)
                        {
                            int length = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Length;
                            int remitId = Convert.ToInt32(grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Substring(length - 5, 5));
                            string SCAC = MXXSCAC;
                            frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC, remitId);
                            frmVendorInfo.ShowDialog();
                            if (frmVendorInfo.VendorInfoSelected)
                            {
                                drVendorInfo = frmVendorInfo.VendorInfoRow;
                                if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                    dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = drVendorInfo["LocIdRemit"];
                                foreach (DataRow row in ((DataView)grdInvoice.DataSource).Table.Rows)
                                {
                                    row["LocIdRemit"] = drVendorInfo["LocIdRemit"];
                                    row["AlRemit1"] = drVendorInfo["AlRemit1"];
                                    row["AlRemit2"] = drVendorInfo["AlRemit2"];
                                    row["AlRemit3"] = drVendorInfo["AlRemit3"];
                                    row["AlRemit4"] = drVendorInfo["AlRemit4"];
                                    row["AlCityRemit"] = drVendorInfo["AlCityRemit"];
                                    row["AlStateProvRemit"] = drVendorInfo["AlStateProvRemit"];
                                    row["AlPostCodeRemit"] = drVendorInfo["AlPostCodeRemit"];
                                    row["AlCntryCodeRemit"] = drVendorInfo["AlCntryCodeRemit"];
                                }
                            }
                            if (!radioSingleFB.Checked)
                            {
                                grdInvoice.Select();
                                grdInvoice.CurrentCell = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"];
                            }
                        }
                    }
                }
                else if (e.Control == true && e.KeyValue == 79)//Ctrl+O
                {
                    if (dsBatch != null && this.grdFreightBill.SelectedRows.Count > 0 && grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim() != string.Empty)
                    {
                        DataView dvFBCurrentRow = new DataView();
                        dvFBCurrentRow.Table = dsBatch.Tables["FB"];
                        dvFBCurrentRow.RowFilter = string.Format("FbId = '{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim());
                        indexToCopy = dsBatch.Tables["FB"].Rows.IndexOf(dvFBCurrentRow[0].Row);
                        dvFBCurrentRow.Dispose();
                    }
                }
                else if (e.Control == true && e.KeyValue == 80)//Ctrl+P
                {
                    int index = indexToCopy;
                    if (index != -1)
                    {
                        if (txtShipperName1.Focused || txtShipperName2.Focused || txtShipperAddress1.Focused || txtShipperAddress2.Focused || txtShipperCity.Focused || txtShipperSt.Focused || txtShipperZip.Focused || txtShipperCountry.Focused)
                        {
                            txtShipperName1.Text = dsBatch.Tables["FB"].Rows[index]["AlOrig1"].ToString().Trim();
                            txtShipperName2.Text = dsBatch.Tables["FB"].Rows[index]["AlOrig2"].ToString().Trim();
                            txtShipperAddress1.Text = dsBatch.Tables["FB"].Rows[index]["AlOrig3"].ToString().Trim();
                            txtShipperAddress2.Text = dsBatch.Tables["FB"].Rows[index]["AlOrig4"].ToString().Trim();
                            txtShipperCity.Text = dsBatch.Tables["FB"].Rows[index]["AlCityOrig"].ToString().Trim();
                            txtShipperSt.Text = dsBatch.Tables["FB"].Rows[index]["AlStateProvOrig"].ToString().Trim();
                            txtShipperZip.Text = dsBatch.Tables["FB"].Rows[index]["AlPostCodeOrig"].ToString().Trim();
                            txtShipperCountry.Text = dsBatch.Tables["FB"].Rows[index]["AlCntryCodeOrig"].ToString().Trim();
                        }
                        else if (txtConsigneeName1.Focused || txtConsigneeName2.Focused || txtConsigneeAddress1.Focused || txtConsigneeAddress2.Focused || txtConsigneeCity.Focused || txtConsigneeSt.Focused || txtConsigneeZip.Focused || txtConsigneeCountry.Focused)
                        {
                            txtConsigneeName1.Text = dsBatch.Tables["FB"].Rows[index]["AlDest1"].ToString().Trim();
                            txtConsigneeName2.Text = dsBatch.Tables["FB"].Rows[index]["AlDest2"].ToString().Trim();
                            txtConsigneeAddress1.Text = dsBatch.Tables["FB"].Rows[index]["AlDest3"].ToString().Trim();
                            txtConsigneeAddress2.Text = dsBatch.Tables["FB"].Rows[index]["AlDest4"].ToString().Trim();
                            txtConsigneeCity.Text = dsBatch.Tables["FB"].Rows[index]["AlCityDest"].ToString().Trim();
                            txtConsigneeSt.Text = dsBatch.Tables["FB"].Rows[index]["AlStateProvDest"].ToString().Trim();
                            txtConsigneeZip.Text = dsBatch.Tables["FB"].Rows[index]["AlPostCodeDest"].ToString().Trim();
                            txtConsigneeCountry.Text = dsBatch.Tables["FB"].Rows[index]["AlCntryCodeDest"].ToString().Trim();
                        }
                    }
                }
                else if (e.Control == true && e.KeyValue == 71)//Ctrl+G
                {
                    frmShipperConsignee frmShipperConsignee = new frmShipperConsignee(dsShipperConsignee.Tables["Consignee"], "Consignee");
                    frmShipperConsignee.ShowDialog();
                    if (frmShipperConsignee.InfoSelected)
                    {
                        this.txtConsigneeName1.Text = frmShipperConsignee.InfoRow["Name1"].ToString();
                        this.txtConsigneeName2.Text = frmShipperConsignee.InfoRow["Name2"].ToString();
                        this.txtConsigneeAddress1.Text = frmShipperConsignee.InfoRow["Address1"].ToString();
                        this.txtConsigneeAddress2.Text = frmShipperConsignee.InfoRow["Address2"].ToString();
                        this.txtConsigneeCity.Text = frmShipperConsignee.InfoRow["City"].ToString();
                        this.txtConsigneeSt.Text = frmShipperConsignee.InfoRow["St"].ToString();
                        this.txtConsigneeZip.Text = frmShipperConsignee.InfoRow["Zip"].ToString();
                        this.txtConsigneeCountry.Text = frmShipperConsignee.InfoRow["Country"].ToString();
                    }
                }
                else if (e.Control == true && e.KeyValue == 72)//Ctrl+H
                {
                    frmShipperConsignee frmShipperConsignee = new frmShipperConsignee(dsShipperConsignee.Tables["Shipper"], "Shipper");
                    frmShipperConsignee.ShowDialog();
                    if (frmShipperConsignee.InfoSelected)
                    {
                        this.txtShipperName1.Text = frmShipperConsignee.InfoRow["Name1"].ToString();
                        this.txtShipperName2.Text = frmShipperConsignee.InfoRow["Name2"].ToString();
                        this.txtShipperAddress1.Text = frmShipperConsignee.InfoRow["Address1"].ToString();
                        this.txtShipperAddress2.Text = frmShipperConsignee.InfoRow["Address2"].ToString();
                        this.txtShipperCity.Text = frmShipperConsignee.InfoRow["City"].ToString();
                        this.txtShipperSt.Text = frmShipperConsignee.InfoRow["St"].ToString();
                        this.txtShipperZip.Text = frmShipperConsignee.InfoRow["Zip"].ToString();
                        this.txtShipperCountry.Text = frmShipperConsignee.InfoRow["Country"].ToString();
                    }
                } 
                else if (e.Control == true && e.KeyValue == 49)//Ctrl+1
                {
                    if (grdInvoice.SelectedRows.Count > 0)
                        grdInvoice.CurrentCell = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"];
                    grdInvoice.Focus();
                    e.Handled = true;
                }
                else if (e.Control == true && e.KeyValue == 50)//Ctrl+2
                {
                    if (grdFreightBill.SelectedRows.Count > 0)
                        grdFreightBill.CurrentCell = grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbKey"];
                    grdFreightBill.Focus();
                    e.Handled = true;
                }
                else if (e.Control == true && e.KeyValue == 51)//Ctrl+3                
                    mtxtDate.Focus();
                else if (e.Control == true && e.KeyValue == 52)//Ctrl+4                
                    txtShipperName1.Focus();
                else if (e.Control == true && e.KeyValue == 53)//Ctrl+5
                    txtConsigneeName1.Focus();
                else if (e.Control == true && e.KeyValue == 54)//Ctrl+6                
                    txtActualWt.Focus();
                else if (e.Control == true && e.KeyValue == 55)//Ctrl+7                
                    txtCustRef1.Focus();
                else if (e.Control == true && e.KeyValue == 56)//Ctrl+8                
                    txtPriceLane.Focus();
                else if (e.Control == true && e.KeyValue == 57)//Ctrl+9                
                    mtxtPickUp.Focus();
                else if (e.Control == true && e.KeyValue == 48)//Ctrl+0
                {
                    if (grdFBLine.SelectedRows.Count > 0)
                        grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells[3];
                    grdFBLine.Focus();
                    e.Handled = true;
                }
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                try
                {
                    dvFreightBillControls.Table = dsBatch.Tables["FB"];
                    if (this.grdFreightBill.SelectedRows.Count > 0 && grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim() != string.Empty)
                    {
                        dvFreightBillControls.RowFilter = string.Format("FbId = '{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim());

                        if (sender is TraxDETextBox)
                        {
                            if (((TraxDETextBox)sender).Text.Trim() == string.Empty)
                            {
                                if (dvFreightBillControls[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Single" ||
                                    dvFreightBillControls[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int32" ||
                                    dvFreightBillControls[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int16" ||
                                    dvFreightBillControls[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Decimal")
                                    ((TraxDETextBox)sender).Text = "0";
                                else
                                    dvFreightBillControls[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();
                            }
                            else
                                dvFreightBillControls[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();
                        }
                        else if (sender is TraxDEMaskedTextBox)
                        {
                            if (((TraxDEMaskedTextBox)sender).ValueType == CommonEnum.ValueType.DATELONG)
                            {
                                if (((TraxDEMaskedTextBox)sender).Text == "  /  /       :")
                                    dvFreightBillControls[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvFreightBillControls[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy HH:mm}", ((TraxDEMaskedTextBox)sender).Text.Substring(((TraxDEMaskedTextBox)sender).Text.Length - 1, 1) == ":" ? ((TraxDEMaskedTextBox)sender).Text.Remove(((TraxDEMaskedTextBox)sender).Text.Length - 1, 1).Trim() : ((TraxDEMaskedTextBox)sender).Text));
                            }
                            else if (((TraxDEMaskedTextBox)sender).ValueType == CommonEnum.ValueType.DATESHORT)
                            {
                                if (((TraxDEMaskedTextBox)sender).Text == "  /  /")
                                    dvFreightBillControls[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvFreightBillControls[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", ((TraxDEMaskedTextBox)sender).Text));
                            }
                            else
                                dvFreightBillControls[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = ((TraxDEMaskedTextBox)sender).Text.ToString();
                        }
                    }
                    else
                    {
                        if (sender is TraxDETextBox)
                            ((TraxDETextBox)sender).Text = string.Empty;
                        else if (sender is TraxDEMaskedTextBox)
                            ((TraxDEMaskedTextBox)sender).Text = string.Empty;
                    }

                }
                catch
                { }
            }
        }

        private void txtActualWt_Validated(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            {
                if (txtFnclWt.Text.Trim() == string.Empty)
                    txtFnclWt.Text = txtActualWt.Text;
            }
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {            
            if (radioInvoiceFB.Checked)
            {
                enableInvoiceGroup(true);
                enableControls(false, grpBoxFreightBill.Controls);
                FBAcctNumVendBlng.Visible = false;
                chkBoxInvoiceAdd.Enabled = currentFormState == CommonEnum.FormState.NORMAL_STATE ? false : true;
                chkBoxFBAdd.Enabled = currentFormState == CommonEnum.FormState.NORMAL_STATE ? false : true;
                chkBoxFBAdd.Enabled = currentFormState == CommonEnum.FormState.EDIT_STATE ? true : false;
                chkBoxInvoiceAdd.Enabled = currentFormState == CommonEnum.FormState.EDIT_STATE ? true : false;
            }
            else
            {
                enableInvoiceGroup(false);
                enableControls(currentFormState == CommonEnum.FormState.NORMAL_STATE?false:true, grpBoxFreightBill.Controls);
                enableControls(false, grpBoxFbLine.Controls);
                FBAcctNumVendBlng.Visible = true;
                chkBoxFBAdd.Enabled = false;
                chkBoxInvoiceAdd.Enabled = false;
                chkBoxFBAdd.Checked = false;
                chkBoxInvoiceAdd.Checked = false;
            }
            grdFreightBill.UpdateVisibleColumnCount();

        }

        private void mtxtDate_Leave(object sender, EventArgs e)
        {
            if(radioSingleFB.Checked && mtxtDate.Text.Trim() != "/  /" )
                grdInvoice.Rows[0].Cells["InvoiceInvCreatDtm"].Value = mtxtDate.Text;
        }

        private void chkBoxMultipleCurr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxMultipleCurr.Checked)
            {
                FBLnT001.Visible = true;
                FBLnT002.Visible = true;
                FBLnT003.Visible = true;
                FBLnFacsimile02.Visible = true;
                FBLnChrgAmt.ReadOnly = true;
                if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                {
                    foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            row["T001"] = "1.0000000";
                            row["T002"] = Convert.ToDecimal(row["ChrgAmt"]).ToString("###,###,###,###.#000");
                            row["T003"] = row["CurrencyQual"];
                            row["T004"] = "1.0000000";
                            row["T005"] = row["CurrencyQual"];
                            row["T006"] = "MultipleCurrency";
                        }
                    }
                }
            }
            else
            {
                FBLnT001.Visible = false;
                FBLnT002.Visible = false;
                FBLnT003.Visible = false;
                FBLnFacsimile02.Visible = false;
                FBLnChrgAmt.ReadOnly = false;
                if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                {
                    foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            row["T001"] = string.Empty;
                            row["T002"] = string.Empty;
                            row["T003"] = string.Empty;
                            row["T004"] = string.Empty;
                            row["T005"] = string.Empty;
                            row["T006"] = string.Empty;
                            row["Facsimile02"] = string.Empty;
                        }
                    }
                }
            }
            grdFBLine.UpdateVisibleColumnCount();
        }

        private void txtShipperEnter(object sender, EventArgs e)
        {
            //if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            //{
            //    this.txtShipperName1.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperName2.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperAddress1.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperAddress2.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperCity.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperSt.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperZip.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperCountry.Enter -= new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperName1.AutoCompleteCustomSource = null;
            //    this.setAutoCompleteData(true);
            //    if (sender is TraxDETextBox)
            //    {
            //        switch (((TraxDETextBox)sender).Name)
            //        {
            //            case "txtShipperName1":
            //                {
            //                    this.txtShipperName1.Focus();
            //                    break;
            //                }
            //            case "txtShipperName2":
            //                {
            //                    this.txtShipperName2.Focus();
            //                    break;
            //                }
            //            case "txtShipperAddress1":
            //                {
            //                    this.txtShipperAddress1.Focus();
            //                    break;
            //                }
            //            case "txtShipperAddress2":
            //                {
            //                    this.txtShipperAddress2.Focus();
            //                    break;
            //                }
            //            case "txtShipperCity":
            //                {
            //                    this.txtShipperCity.Focus();
            //                    break;
            //                }
            //            case "txtShipperSt":
            //                {
            //                    this.txtShipperSt.Focus();
            //                    break;
            //                }
            //            case "txtShipperZip":
            //                {
            //                    this.txtShipperZip.Focus();
            //                    break;
            //                }
            //            case "txtShipperCountry":
            //                {
            //                    this.txtShipperCountry.Focus();
            //                    break;
            //                }
            //        }
            //    }
            //    this.txtShipperName1.Enter += new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperName2.Enter += new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperAddress1.Enter += new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperAddress2.Enter += new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperCity.Enter += new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperSt.Enter += new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperZip.Enter += new System.EventHandler(this.txtShipperEnter);
            //    this.txtShipperCountry.Enter += new System.EventHandler(this.txtShipperEnter);
            //}
        }

        private void txtConsigneeEnter(object sender, EventArgs e)
        {
            //if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            //{
            //    this.txtConsigneeName1.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeName2.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeAddress1.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeAddress2.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeCity.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeSt.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeZip.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeCountry.Enter -= new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeName1.AutoCompleteCustomSource = null;
            //    this.setAutoCompleteData(false);
            //    if (sender is TraxDETextBox)
            //    {
            //        switch (((TraxDETextBox)sender).Name)
            //        {
            //            case "txtConsigneeName1":
            //                {
            //                    this.txtConsigneeName1.Focus();
            //                    break;
            //                }
            //            case "txtConsigneeName2":
            //                {
            //                    this.txtConsigneeName2.Focus();
            //                    break;
            //                }
            //            case "txtConsigneeAddress1":
            //                {
            //                    this.txtConsigneeAddress1.Focus();
            //                    break;
            //                }
            //            case "txtConsigneeAddress2":
            //                {
            //                    this.txtConsigneeAddress2.Focus();
            //                    break;
            //                }
            //            case "txtConsigneeCity":
            //                {
            //                    this.txtConsigneeCity.Focus();
            //                    break;
            //                }
            //            case "txtConsigneeSt":
            //                {
            //                    this.txtConsigneeSt.Focus();
            //                    break;
            //                }
            //            case "txtConsigneeZip":
            //                {
            //                    this.txtConsigneeZip.Focus();
            //                    break;
            //                }
            //            case "txtConsigneeCountry":
            //                {
            //                    this.txtConsigneeCountry.Focus();
            //                    break;
            //                }
            //        }
            //    }
            //    this.txtConsigneeName1.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeName2.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeAddress1.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeAddress2.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeCity.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeSt.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeZip.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //    this.txtConsigneeCountry.Enter += new System.EventHandler(this.txtConsigneeEnter);
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsChargeCode = bl.selectChargeCode();
            dvChargeCode.Table = dsChargeCode.Tables[0];
            dsShipperConsignee = bl.selectShipperConsignee();
            dvShipper.Table = dsShipperConsignee.Tables["Shipper"];
            dvConsignee.Table = dsShipperConsignee.Tables["Consignee"];            
            dsBatches = bl.selectBatches();
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
            if (dsBatches.Tables[0].Rows.Count == 0)
                enableToolStripButtons(currentFormState);
            dsOwnerKeyAlphaNumeric = bl.selectAlphaNumericKey();
            this.Cursor = Cursors.Default;
        }
        #endregion
        #endregion

        #region Developer Designed method
        private void populateParameter()
        {            
            MXXDatabase = string.Empty;
            MXXOwnerKey = string.Empty;
            MXXSCAC = string.Empty;
            if (this.grdImageGroup.Rows.Count > 0 && this.grdImageGroup.SelectedRows.Count > 0)
            {
                MXXDatabase = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["BatchNumber"].Value.ToString();
                MXXOwnerKey = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString();
                MXXSCAC = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["VendSCAC"].Value.ToString();
                if (dsOwnerKeyAlphaNumeric != null && dsOwnerKeyAlphaNumeric.Tables.Count > 0)
                {
                    if (dsOwnerKeyAlphaNumeric.Tables[0].Select(string.Format("Owner_Key = '{0}'", MXXOwnerKey)).Count() > 0)
                    {
                        isInvoiceKeyAlphaNumeric = Convert.ToBoolean(dsOwnerKeyAlphaNumeric.Tables[0].Select(string.Format("Owner_Key = '{0}'", MXXOwnerKey))[0]["Invoice"]);
                        isFreightBillKeyAlphaNumeric = Convert.ToBoolean(dsOwnerKeyAlphaNumeric.Tables[0].Select(string.Format("Owner_Key = '{0}'", MXXOwnerKey))[0]["FreightBill"]);
                    }
                    else
                    {
                        isInvoiceKeyAlphaNumeric = false;
                        isFreightBillKeyAlphaNumeric = false;
                    }
                }
                else
                {
                    isInvoiceKeyAlphaNumeric = false;
                    isFreightBillKeyAlphaNumeric = false;
                }
            }
        }

        private void bindgrdBatches()
        {
            grdImageGroup.SelectionChanged -= new EventHandler(grdImageGroup_SelectionChanged);
            dvBatches.Table = dsBatches.Tables[0];
            this.dvBatches.RowFilter = string.Format("[Batch Number] LIKE '{0}%' OR [Vendor SCAC] LIKE '{0}%' OR [OwnerCode] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdImageGroup.DataSource = dvBatches;
            this.grdImageGroup.Refresh();
            grdImageGroup.SelectionChanged += new EventHandler(grdImageGroup_SelectionChanged);            
        }

        private void bindgrdInvoice()
        {
            if (dsBatch == null)
            {
                if ((DataView)grdInvoice.DataSource != null)
                {
                    if (dvInvoice.Table != null)                    
                        dvInvoice.Table.Rows.Clear();                    
                    grdInvoice.DataSource = dvInvoice;
                    grdInvoice.ClearSelection();
                }
            }
            else
            {
                grdInvoice.SelectionChanged -= new EventHandler(grdInvoice_SelectionChanged);
                dvInvoice.Table = dsBatch.Tables["Invoice"];                
                this.grdInvoice.DataSource = dvInvoice;                
                this.grdInvoice.Refresh();                
                grdInvoice.SelectionChanged += new EventHandler(grdInvoice_SelectionChanged);
            }
        }

        private void bindgrdFreightBill()
        {
            FBTotal = 0;
            if (dsBatch == null)
            {
                if ((DataView)grdFreightBill.DataSource != null )
                {
                    if (dvFreightBill.Table != null)
                    {
                        dvFreightBill.Table.Rows.Clear();
                        dvFXI.Table.Rows.Clear();
                    }
                    grdFreightBill.DataSource = dvFreightBill;
                    grdFXI.DataSource = dvFXI;
                }
            }
            else
            {                
                grdFreightBill.SelectionChanged -= new EventHandler(grdFreightBill_SelectionChanged);
                dvFreightBill.Table = dsBatch.Tables["FB"];
                
                if (grdInvoice.SelectedRows.Count > 0 && grdInvoice.SelectedRows.Count>0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim() != string.Empty)
                    this.dvFreightBill.RowFilter = string.Format("InvId = '{0}'", grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim());
                else if (grdInvoice.SelectedRows.Count > 0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim() == string.Empty)
                {
                    this.dvFreightBill.RowFilter = string.Format("InvId = '{0}'", "");
                }
                this.grdFreightBill.DataSource = dvFreightBill;
                this.grdFreightBill.Refresh();                
                grdFreightBill.SelectionChanged += new EventHandler(grdFreightBill_SelectionChanged);

                if (grdFreightBill.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in grdFreightBill.Rows)
                    {
                        if (row.Cells["FBFbAmt"].Value.ToString() != string.Empty)
                            FBTotal = FBTotal + Convert.ToDecimal(row.Cells["FBFbAmt"].Value);
                    }
                }
                else
                    FBTotal = 0;
            }
            setFBTotalLable();
            
        }

        private void bindControls()
        {
            if (dsBatch == null)
            {
                if ((DataView)grdFreightBill.DataSource != null)
                    clearControls();
            }
            else
            {
                dvFreightBillControls.Table = dsBatch.Tables["FB"];
                dvFXI.Table = dsBatch.Tables["FXI"];
                if (this.grdFreightBill.SelectedRows.Count > 0 && grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim() != string.Empty)
                {
                    dvFreightBillControls.RowFilter = string.Format("FbId = '{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim());
                    foreach (Control control in grpBoxFreightBill.Controls)
                    {
                        if (control is TraxDETextBox)
                        {
                            ((TraxDETextBox)control).Text = dvFreightBillControls[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                        }
                        else if (control is TraxDEMaskedTextBox)
                        {
                            if (dvFreightBillControls[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty)
                            {
                                if (Secure)
                                {
                                    if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.ValueType.DATELONG)
                                        ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy HH:mm}", dvFreightBillControls[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]);
                                    else if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.ValueType.DATESHORT)
                                        ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy}", dvFreightBillControls[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]);
                                    else
                                        ((TraxDEMaskedTextBox)control).Text = dvFreightBillControls[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString();
                                }
                                else
                                {
                                    if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.ValueType.DATELONG)
                                        ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy HH:mm}", Convert.ToDateTime(dvFreightBillControls[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                                    else if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.ValueType.DATESHORT)
                                        ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dvFreightBillControls[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                                    else
                                        ((TraxDEMaskedTextBox)control).Text = dvFreightBillControls[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString();
                                }
                            }
                            else
                                ((TraxDEMaskedTextBox)control).Text = string.Empty;
                        }
                        else if (control is GroupBox)
                        {
                            foreach (Control controls in ((GroupBox)control).Controls)
                            {
                                if (controls is TraxDETextBox)
                                {
                                    ((TraxDETextBox)controls).Text = dvFreightBillControls[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString();
                                }
                                else if (controls is TraxDEMaskedTextBox)
                                {
                                    ((TraxDEMaskedTextBox)controls).Text = dvFreightBillControls[0][((TraxDEMaskedTextBox)controls).DatabaseFieldLink].ToString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    dvFreightBillControls.RowFilter = string.Format("FbId = '{0}'", "");
                    clearControls();
                }
                if (grdFreightBill.SelectedRows.Count > 0)
                    dvFXI.RowFilter = string.Format("FbId  ='{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim(), grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbKey"].Value.ToString().Trim());
                else
                    dvFXI.RowFilter = string.Format("FbId  ='{0}'", "");                
                this.grdFXI.DataSource = dvFXI;
                this.grdFXI.Refresh();
            }
        }

        private void bindgrdFBLine()
        {
            Total = 0;            
            if (dsBatch == null)
            {
                if ((DataView)grdFBLine.DataSource != null)
                {
                    if(dvFBLine.Table != null)
                        dvFBLine.Table.Rows.Clear();
                    grdFBLine.DataSource = dvFBLine;
                }
            }
            else
            {   
                dvFBLine.Table = dsBatch.Tables["FBLn"];
                if (this.grdFreightBill.SelectedRows.Count > 0 && grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim() != string.Empty)
                    this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim());
                else
                    dvFBLine.RowFilter = string.Format("FbId = '{0}'", "");
                
                this.grdFBLine.DataSource = dvFBLine;
                this.grdFBLine.Refresh();

                if (grdFBLine.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in grdFBLine.Rows)
                    {
                        if(row.Cells["FBLnChrgAmt"].Value.ToString() != string.Empty)
                            Total = Total + Convert.ToDecimal(row.Cells["FBLnChrgAmt"].Value);
                    }
                }
                else
                    Total = 0;
                
            }
            setFBLnTotalLable();
        }

        private void determineMode()
        {
            if (dsBatch != null && dsBatch.Tables.Count > 0 && dsBatch.Tables["Invoice"].Rows.Count > 0)
            {
                if (dsBatch.Tables["Invoice"].Rows[0]["InvStat"].ToString().Trim() == "SingleBill")
                {
                    radioInvoiceFB.Checked = false;
                    radioSingleFB.Checked = true;
                }
                else
                {
                    radioInvoiceFB.Checked = true;
                    radioSingleFB.Checked = false;
                }
            }
            else
            {
                radioInvoiceFB.Checked = true;
                radioSingleFB.Checked = false;
            }
        }

        private void determineMultipleCurrencyMode()
        {
            if (dsBatch != null && dsBatch.Tables.Count > 0 && dsBatch.Tables["FBLn"].Rows.Count > 0)
            {
                if (dsBatch.Tables["FBLn"].Rows[0]["T006"].ToString().Trim() == "MultipleCurrency")
                    chkBoxMultipleCurr.Checked = true;                
                else                
                    chkBoxMultipleCurr.Checked = false;
            }
            else            
                chkBoxMultipleCurr.Checked = false;
        }
        
        private void enableToolStripButtons(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        toolStripButtonStart.Enabled = !isBatchStarted();
                        toolStripButtonEdit.Enabled = isEditAllowed() == true ? isBatchStarted() : false;
                        toolStripButtonSave.Enabled = false;
                        toolStripButtonSaveClose.Enabled = false;
                        toolStripButtonRestart.Enabled = false;
                        toolStripButtonSendReview.Enabled = false;
                        toolStripButtonCancel.Enabled = false;
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        toolStripButtonStart.Enabled = false;
                        toolStripButtonEdit.Enabled = false;
                        toolStripButtonSave.Enabled = true;
                        toolStripButtonSaveClose.Enabled = true;
                        toolStripButtonRestart.Enabled = true;
                        toolStripButtonSendReview.Enabled = true;
                        toolStripButtonCancel.Enabled = true;
                        break;
                    }
            }
            enableStateControls(currentFormState);
        }

        private void enableStateControls(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        grpBoxImageGroup.Enabled = true;
                        enableControls(false, grpBoxInvoice.Controls);
                        enableControls(false, grpBoxFreightBill.Controls);
                        enableControls(false, grpBoxMode.Controls);
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        grpBoxImageGroup.Enabled = false;
                        enableControls(true, grpBoxInvoice.Controls);
                        enableControls(grdInvoice.Rows.Count>0 ? true : false, grpBoxFreightBill.Controls);
                        enableControls(grdFreightBill.Rows.Count > 0 ? true : false, grpBoxFbLine.Controls);
                        enableModeGroupControl(grdInvoice.Rows.Count > 0 ? false : true);
                        break;
                    }
            }
        }

        private void enableControls(bool isEnable, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                {
                    if (((Button)control).Name == "btnAddFB")
                    {
                        if (radioSingleFB.Checked && grdFreightBill.Rows.Count > 0)
                            ((Button)control).Enabled = false;
                        else
                            ((Button)control).Enabled = isEnable;
                    }
                    else                    
                        ((Button)control).Enabled = isEnable;
                }
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = isEnable;
                else if (control is TraxDETextBox)
                    ((TraxDETextBox)control).ReadOnly = !isEnable;
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).ReadOnly = !isEnable;
                else if (control is TraxDEDataGridView)
                {
                    ((TraxDEDataGridView)control).ReadOnly = !isEnable;
                    ((TraxDEDataGridView)control).StandardTab = !isEnable;
                    if (isEnable)
                        setReadOnlyGridColumns((TraxDEDataGridView)control);
                }
                else if (control is GroupBox)
                    enableControls(isEnable, ((GroupBox)control).Controls);
                else if (control is RadioButton)
                    control.Enabled = isEnable;
            }            
        }

        private void enableInvoiceGroup(bool isEnable)
        {
            grpBoxInvoice.Enabled = isEnable;            
        }

        private void enableModeGroupControl(bool isEnable)
        {
            radioSingleFB.Enabled = isEnable;
            radioInvoiceFB.Enabled = isEnable;

            if (radioSingleFB.Checked)
            {
                chkBoxFBAdd.Enabled = false;
                chkBoxInvoiceAdd.Enabled = false;
                chkBoxFBAdd.Checked = false;
                chkBoxInvoiceAdd.Checked = false;                
            }
            else
            {
                chkBoxInvoiceAdd.Enabled = currentFormState == CommonEnum.FormState.EDIT_STATE ? true : false;
                chkBoxFBAdd.Enabled = currentFormState == CommonEnum.FormState.EDIT_STATE ? true : false;                                
            }
            chkBoxFBLnAdd.Enabled = currentFormState == CommonEnum.FormState.EDIT_STATE ? true : false;
        }

        private bool isBatchStarted()
        {
            bool retval = false;
            if (this.grdImageGroup.SelectedRows.Count > 0)     
                if(Secure)
                    retval = dsBatch == null && (grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value == null || grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value.ToString().Trim() == "") ? false : true;            
                else
                    retval = (grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value == null || grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value.ToString().Trim() == "") ? false : true;            
            return retval;           
        }

        private bool isEditAllowed()
        {
            bool retval = false;
            if (this.grdImageGroup.Rows.Count > 0)            
                retval = true;                        
            return retval;
        }

        private bool isAllowedSendForReview()
        {
            bool retval = true;
            string message = string.Empty;
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["InvKey"].ToString().Trim() == string.Empty)
                {
                    retval = false;
                    message = "There are some blank invoice key, please review this batch.";
                    break;
                }
            }
            if (retval)
            {
                foreach (DataRow row in dsBatch.Tables["FB"].Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row["FbKey"].ToString().Trim() == string.Empty)
                        {
                            retval = false;
                            message = "There are some blank freight bill key, please review this batch.";
                            break;
                        }
                        if (row["FbPaymtTermsCode"].ToString().Trim() == string.Empty || (row["FbPaymtTermsCode"].ToString().Trim() != "TP" && row["FbPaymtTermsCode"].ToString().Trim() != "PP" && row["FbPaymtTermsCode"].ToString().Trim() != "CC"))
                        {
                            retval = false;
                            message = "There are some blank or invalid terms, please review this batch.";
                            break;
                        }
                        try
                        {
                            if (row["FbCreatDtm"].ToString().Trim() != string.Empty)
                                if (Convert.ToDateTime(row["FbCreatDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["FbCreatDtm"].ToString().Trim()) > (bl.GetServerDate().AddDays(30)))
                                    throw new Exception();
                            if (row["LmPkupActualDtm"].ToString().Trim() != string.Empty)
                                if (Convert.ToDateTime(row["LmPkupActualDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["LmPkupActualDtm"].ToString().Trim()) > bl.GetServerDate().AddDays(30))
                                    throw new Exception();
                            if (row["LmAtaDtm"].ToString().Trim() != string.Empty)
                                if (Convert.ToDateTime(row["LmAtaDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["LmAtaDtm"].ToString().Trim()) > bl.GetServerDate().AddDays(30))
                                    throw new Exception();
                        }
                        catch
                        {
                            retval = false;
                            message = "There are some invalid date or date format, please review this batch.";
                            break;
                        }
                    }
                }
            }            
            if (retval)
                if (!isInvAmtEqualVendInvAmt())
                {
                    retval = false;
                    message = "There are some VendInvAmt that does not match the InvAmt value, please review this batch.";
                }
            if(!retval)
                MessageBox.Show(message, "Data Entry");
            return retval;
        }

        private bool isCurrencyAdjustmentAllowed()
        {
            bool retval = true;
           
            foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["LnChrgCode"].ToString().Trim() == ConfigurationManager.AppSettings["CurrencyAdjustmentCode"].ToString())
                {
                    if (Math.Abs(Convert.ToDecimal(row["ChrgAmt"])) > Convert.ToDecimal(ConfigurationManager.AppSettings["CurrencyAdjustmentTolerance"]))
                    {
                        retval = false;
                        MessageBox.Show("There are currency adjustments that exeeded the tolerance level.","Data Entry");
                        break;
                    }
                }
            }            
            return retval;
        }

        private bool isTotalEqual()
        {
            bool retval = false;
            decimal invoiceOverAllTotal = 0;
            decimal FBOverAllTotal = 0;
            decimal FBLnOverAllTotal = 0;

            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["VendInvAmt"].ToString() != string.Empty)
                    invoiceOverAllTotal = invoiceOverAllTotal + Convert.ToDecimal(row["VendInvAmt"]);
            }

            foreach (DataRow row in dsBatch.Tables["FB"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["FbAmt"].ToString() != string.Empty)
                    FBOverAllTotal = FBOverAllTotal + Convert.ToDecimal(row["FbAmt"]);
            }

            foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["ChrgAmt"].ToString() != string.Empty)
                    FBLnOverAllTotal = FBLnOverAllTotal + Convert.ToDecimal(row["ChrgAmt"]);
            }
            if (invoiceOverAllTotal == FBOverAllTotal && FBOverAllTotal == FBLnOverAllTotal)
                retval = true;
            return retval;
        }
        
        private bool deleteFBLn(string filter)
        {
            bool retval = false;
            try
            {
                this.dvFBLine.RowFilter = filter;
                int count = dvFBLine.Count;
                ArrayList deleteList = new ArrayList();
                for (int i = 0;i< count; i++)
                    deleteList.Add(dsBatch.Tables["FBLn"].Rows.IndexOf(dvFBLine[i].Row));
                foreach(object item in deleteList)
                    dsBatch.Tables["FBLn"].Rows[(int)item].Delete();                                
                retval = true;
            }
            catch (Exception error)
            {
                retval = false;
                throw error;
            }
            return retval;
        }

        private bool deleteFB(string filter)
        {
            bool retval = false;
            try
            {
                this.dvFreightBill.RowFilter = filter;
                this.dvFXI.RowFilter = filter;
                int count = dvFreightBill.Count;
                int countFXI = dvFXI.Count;
                ArrayList deleteList = new ArrayList();
                ArrayList deleteListFXI = new ArrayList();
                for (int i = 0; i < count; i++)
                    deleteList.Add(dsBatch.Tables["FB"].Rows.IndexOf(dvFreightBill[i].Row));
                for (int j = 0; j < countFXI; j++)
                    deleteListFXI.Add(dsBatch.Tables["FXI"].Rows.IndexOf(dvFXI[j].Row));
                foreach(object item in deleteList)
                    dsBatch.Tables["FB"].Rows[(int)item].Delete();
                foreach (object itemFXI in deleteListFXI)
                    dsBatch.Tables["FXI"].Rows[(int)itemFXI].Delete();
                retval = true;
            }
            catch (Exception error)
            {
                retval = false;
                throw error;
            }
            return retval;
        }

        private bool deleteInvoice(string filter)
        {
            bool retval = false;
            try
            {
                this.dvInvoice.RowFilter = filter;

                int count = dvInvoice.Count;
                ArrayList deleteList = new ArrayList();
                for (int i = 0; i < count; i++)
                    deleteList.Add(dsBatch.Tables["Invoice"].Rows.IndexOf(dvInvoice[0].Row));
                foreach (object item in deleteList)
                    dsBatch.Tables["Invoice"].Rows[(int)item].Delete();
                this.dvInvoice.RowFilter = "";
                retval = true;
            }
            catch (Exception error)
            {
                retval = false;
                throw error;
            }
            return retval;
        }

        private bool deleteObject(string MXXDatabase)
        {
            bool retval = false;
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".mxx"))
                    File.Delete(ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".mxx");
                retval = true;
            }
            catch (Exception error)
            {
                throw error;
            }
            return retval;
        }

        private void updateFBLnLineNumber()
        {
            for (int fb = 0; fb < dsBatch.Tables["FB"].DefaultView.Count; fb++)
            {
                dvFBLine.RowFilter = string.Format("FbId = '{0}'", dsBatch.Tables["FB"].DefaultView[fb]["FbId"].ToString().Trim());
                for (int i = 0; i < dvFBLine.Count; i++)
                {
                    int ID = Convert.ToInt32(dvFBLine[i]["LineItemNum"]);//int ID = Convert.ToInt32(dsBatch.Tables["FBLn"].Rows[dsBatch.Tables["FBLn"].Rows.IndexOf(dvFBLine[i].Row)]["LineItemNum"]);
                    if (ID != i + 1)
                    {
                        dvFBLine[i]["LineItemNum"] = i + 1;//dsBatch.Tables["FBLn"].Rows[dsBatch.Tables["FBLn"].Rows.IndexOf(dvFBLine[i].Row)]["LineItemNum"] = i + 1;
                    }
                }
            }
        }

        private void updateFBID()
        {
            ArrayList updateList = new ArrayList();
            for (int i = 0; i < dsBatch.Tables["FB"].DefaultView.Count; i++)
            {
                int length = dsBatch.Tables["FB"].DefaultView[i]["FbId"].ToString().Trim().Length;
                int ID = Convert.ToInt32(dsBatch.Tables["FB"].DefaultView[i]["FbId"].ToString().Trim().Substring(length - 4, 4));
                if (ID != i + 1)
                {
                    updateList.Add(new IDUpdate(dsBatch.Tables["FB"].DefaultView[i]["FbId"].ToString().Trim(), dsBatch.Tables["FB"].DefaultView[i]["FbId"].ToString().Trim().Substring(0, length - 4) + (i + 1).ToString().PadLeft(4, '0')));
                    dsBatch.Tables["FB"].DefaultView[i]["FbId"] = dsBatch.Tables["FB"].DefaultView[i]["FbId"].ToString().Trim().Substring(0, length - 4) + (i + 1).ToString().PadLeft(4, '0');
                }
            }
            foreach (object item in updateList)
            {
                this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", ((IDUpdate)item).OriginalID);
                this.dvFXI.RowFilter = string.Format("FbId = '{0}'", ((IDUpdate)item).OriginalID);
                int count = dvFBLine.Count;
                int countFXI = dvFXI.Count;

                ArrayList IndexList = new ArrayList();
                for (int i = 0; i < count; i++)
                    IndexList.Add(dsBatch.Tables["FBLn"].Rows.IndexOf(dvFBLine[i].Row));

                ArrayList IndexListFXI = new ArrayList();
                for (int i = 0; i < countFXI; i++)
                    IndexListFXI.Add(dsBatch.Tables["FXI"].Rows.IndexOf(dvFXI[i].Row));

                foreach (object index in IndexList)
                    dsBatch.Tables["FBLn"].Rows[(int)index]["FbId"] = ((IDUpdate)item).NewID;

                foreach (object index in IndexListFXI)
                    dsBatch.Tables["FXI"].Rows[(int)index]["FbId"] = ((IDUpdate)item).NewID;
            }
        }

        private void updateInvoiceID()
        {
            ArrayList updateList = new ArrayList();

            for (int i = 0; i < dsBatch.Tables["Invoice"].DefaultView.Count; i++)//for (int i = 0; i < dsBatch.Tables["Invoice"].Rows.Count; i++)
            {
                int length = dsBatch.Tables["Invoice"].DefaultView[i]["InvId"].ToString().Trim().Length;
                int ID = Convert.ToInt32(dsBatch.Tables["Invoice"].DefaultView[i]["InvId"].ToString().Trim().Substring(length - 4, 4));
                if (ID != i + 1)
                {
                    updateList.Add(new IDUpdate(dsBatch.Tables["Invoice"].DefaultView[i]["InvId"].ToString().Trim(), dsBatch.Tables["Invoice"].DefaultView[i]["InvId"].ToString().Trim().Substring(0, length - 4) + (i + 1).ToString().PadLeft(4, '0')));
                    dsBatch.Tables["Invoice"].DefaultView[i]["InvId"] = dsBatch.Tables["Invoice"].DefaultView[i]["InvId"].ToString().Trim().Substring(0, length - 4) + (i + 1).ToString().PadLeft(4, '0');
                }
            }
            foreach (object item in updateList)
            {
                this.dvFreightBill.RowFilter = string.Format("InvId = '{0}'", ((IDUpdate)item).OriginalID);
                int count = dvFreightBill.Count;

                this.dvFXI.RowFilter = string.Format("InvId = '{0}'", ((IDUpdate)item).OriginalID);
                int countFXI = dvFXI.Count;
                
                ArrayList IndexList = new ArrayList();
                for (int i = 0; i < count; i++)
                    IndexList.Add(dsBatch.Tables["FB"].Rows.IndexOf(dvFreightBill[i].Row));
                ArrayList IndexListFXI = new ArrayList();
                for (int j = 0; j < countFXI; j++)
                    IndexListFXI.Add(dsBatch.Tables["FXI"].Rows.IndexOf(dvFXI[j].Row));

                foreach (object index in IndexList)
                    dsBatch.Tables["FB"].Rows[(int)index]["InvId"] = ((IDUpdate)item).NewID;
                foreach (object index in IndexListFXI)
                    dsBatch.Tables["FXI"].Rows[(int)index]["InvId"] = ((IDUpdate)item).NewID;
            }
        }

        private void updateCurrencyQual(string value)
        {
            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"] = value;
            foreach (DataRow rowInvoice in dsBatch.Tables["Invoice"].Rows)
                if (rowInvoice.RowState != DataRowState.Deleted) 
                    rowInvoice["InvCurrencyQual"] = value;
            foreach (DataRow rowFB in dsBatch.Tables["FB"].Rows)
                if (rowFB.RowState != DataRowState.Deleted) 
                    rowFB["FbCurrencyQual"] = value;
            foreach (DataRow rowFBLn in dsBatch.Tables["FBLn"].Rows)
                if (rowFBLn.RowState != DataRowState.Deleted)
                {
                    rowFBLn["CurrencyQual"] = value;
                    if (chkBoxMultipleCurr.Checked)
                    {
                        rowFBLn["T001"] = "1.0000000";
                        rowFBLn["T002"] = Convert.ToDecimal(rowFBLn["ChrgAmt"]).ToString("###,###,###,###.#000");
                        rowFBLn["T003"] = rowFBLn["CurrencyQual"];
                        rowFBLn["T004"] = "1.0000000";
                        rowFBLn["T005"] = rowFBLn["CurrencyQual"];
                    }
                }
            bindgrdInvoice();
            bindgrdFreightBill();
            bindgrdFBLine();
        }

        private void updateAcctNumVendBlng(string value, string invID)
        {
            foreach (DataRow rowFB in dsBatch.Tables["FB"].Select(string.Format("InvId = '{0}'", invID)))
                if (rowFB.RowState != DataRowState.Deleted) 
                    rowFB["AcctNumVendBlng"] = value;
            bindgrdFreightBill();
        }

        private void updateInvKey(string value, string invID)
        {
            foreach (DataRow rowFB in dsBatch.Tables["FB"].Select(string.Format("InvId = '{0}'", invID)))
                if (rowFB.RowState != DataRowState.Deleted) 
                    rowFB["InvKey"] = value;
            bindgrdFreightBill();
        }

        private void updateInvoiceCounter()
        {
            if (grdInvoice.DataSource != null && grdInvoice.SelectedRows.Count > 0)
                lblInvoiceCounter.Text = (grdInvoice.SelectedRows[0].Index + 1).ToString() + "/" + grdInvoice.Rows.Count.ToString();
            else
                lblInvoiceCounter.Text = "0/0";
        }

        private void updateFBCounter()
        {
            if (grdFreightBill.DataSource != null && grdFreightBill.SelectedRows.Count > 0)
                lblFBCounter.Text = (grdFreightBill.SelectedRows[0].Index + 1).ToString() + "/" + grdFreightBill.Rows.Count.ToString();
            else
                lblFBCounter.Text = "0/0";
        }

        private void updateFBValues()
        {
            for (int i = 0; i < dsBatch.Tables["FB"].DefaultView.Count; i++)
            {
                dsBatch.Tables["FB"].DefaultView[i]["FbFrghtAmt"] = 0;
                dsBatch.Tables["FB"].DefaultView[i]["FbAccAmt"] = 0;
                dsBatch.Tables["FB"].DefaultView[i]["FbDscntAmt"] = 0;
                dsBatch.Tables["FB"].DefaultView[i]["FbTaxAmt"] = 0;
                foreach (DataRow fbLnRow in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", dsBatch.Tables["FB"].DefaultView[i]["FbId"].ToString().Trim())))
                {
                    if (fbLnRow["Cat"].ToString().Trim() == "ACCESSORIAL")
                        dsBatch.Tables["FB"].DefaultView[i]["FbAccAmt"] = Convert.ToDecimal(dsBatch.Tables["FB"].DefaultView[i]["FbAccAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "FREIGHT")
                        dsBatch.Tables["FB"].DefaultView[i]["FbFrghtAmt"] = Convert.ToDecimal(dsBatch.Tables["FB"].DefaultView[i]["FbFrghtAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "DISCOUNT")
                        dsBatch.Tables["FB"].DefaultView[i]["FbDscntAmt"] = Convert.ToDecimal(dsBatch.Tables["FB"].DefaultView[i]["FbDscntAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "TAX")
                        dsBatch.Tables["FB"].DefaultView[i]["FbTaxAmt"] = Convert.ToDecimal(dsBatch.Tables["FB"].DefaultView[i]["FbTaxAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);
                }
            }
        }

        private void updateCounter()
        {
            DataView dvFB = new DataView();
            DataView dvFBLn = new DataView();
            dvFB.Table = dsBatch.Tables["FB"];
            dvFBLn.Table = dsBatch.Tables["FBLn"];
            if (dvFB.Count > 0)
            {
                for (int i = 0; i < dsBatch.Tables["Invoice"].DefaultView.Count; i++)
                {
                    dvFB.RowFilter = string.Format("InvId = '{0}'", dsBatch.Tables["FB"].DefaultView[i]["InvId"].ToString().Trim());
                    dsBatch.Tables["Invoice"].DefaultView[i]["InvFbCnt"] = dvFB.Count;
                }
            }
            if (dvFBLn.Count > 0)
            {
                for (int i = 0; i < dsBatch.Tables["FB"].DefaultView.Count; i++)
                {
                    dvFBLn.RowFilter = string.Format("FbId = '{0}'", dsBatch.Tables["FB"].DefaultView[i]["FbId"].ToString().Trim());
                    dsBatch.Tables["FB"].DefaultView[i]["FbLnCnt"] = dvFBLn.Count;
                }
            }
        }

        private void setReadOnlyGridColumns(TraxDEDataGridView grd)
        {
            foreach (DataGridViewColumn column in grd.Columns)
            {
                if (column is TraxDEDataGridViewTextBoxColumn)
                {
                    if (column.Name == "InvoiceVendLabl" || column.Name == "InvoiceLocIdRemit" || column.Name == "FBLnLineItemNum" || column.Name == "FBLnChrgDesc")
                        column.ReadOnly = true;
                    else if (chkBoxMultipleCurr.Checked && column.Name == "FBLnChrgAmt")
                        column.ReadOnly = true;
                    else
                        column.ReadOnly = false;
                }
            }
        }

        private void setVendorInfo()
        {
            if (dvInvoice.Count <= 0)
            {
                drVendorInfo["VendLabl"] = string.Empty;
                drVendorInfo["LocIdRemit"] = string.Empty;
                drVendorInfo["AlRemit1"] = string.Empty;
                drVendorInfo["AlRemit2"] = string.Empty;
                drVendorInfo["AlRemit3"] = string.Empty;
                drVendorInfo["AlRemit4"] = string.Empty;
                drVendorInfo["AlCityRemit"] = string.Empty;
                drVendorInfo["AlStateProvRemit"] = string.Empty;
                drVendorInfo["AlPostCodeRemit"] = string.Empty;
                drVendorInfo["AlCntryCodeRemit"] = string.Empty;
            }
            else
            {
                drVendorInfo["VendLabl"] = dvInvoice[0]["VendLabl"].ToString();
                drVendorInfo["LocIdRemit"] = dvInvoice[0]["LocIdRemit"].ToString();
                drVendorInfo["AlRemit1"] = dvInvoice[0]["AlRemit1"].ToString();
                drVendorInfo["AlRemit2"] = dvInvoice[0]["AlRemit2"].ToString();
                drVendorInfo["AlRemit3"] = dvInvoice[0]["AlRemit3"].ToString();
                drVendorInfo["AlRemit4"] = dvInvoice[0]["AlRemit4"].ToString();
                drVendorInfo["AlCityRemit"] = dvInvoice[0]["AlCityRemit"].ToString();
                drVendorInfo["AlStateProvRemit"] = dvInvoice[0]["AlStateProvRemit"].ToString();
                drVendorInfo["AlPostCodeRemit"] = dvInvoice[0]["AlPostCodeRemit"].ToString();
                drVendorInfo["AlCntryCodeRemit"] = dvInvoice[0]["AlCntryCodeRemit"].ToString();
            }
        }

        private void setFBTotalLable()
        {
            if (FBTotal != 0)
                lblFBTotal.Text = FBTotal.ToString("###,###,###,###.#000");
            else
                lblFBTotal.Text = "0.0000";
            if (grdInvoice.SelectedRows.Count > 0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceVendInvAmt"].Value.ToString().Trim() != string.Empty && FBTotal == Convert.ToDecimal(grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceVendInvAmt"].Value))            
                lblFBTotal.ForeColor = Color.Black;
            else
                lblFBTotal.ForeColor = Color.Red;
        }

        private void setFBLnTotalLable()
        {
            if (Total != 0)
                lblTotal.Text = Total.ToString("###,###,###,###.#000");
            else
                lblTotal.Text = "0.0000";
            if (grdFreightBill.SelectedRows.Count > 0 && grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbAmt"].Value.ToString().Trim() != string.Empty && Total == Convert.ToDecimal(grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbAmt"].Value))            
                lblTotal.ForeColor = Color.Black;
            else
                lblTotal.ForeColor = Color.Red;
        }

        private void setFBLnTotal()
        {
            Total = 0;
            if (grdFBLine.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grdFBLine.Rows)
                {
                    if (row.Cells["FBLnChrgAmt"].Value.ToString() != string.Empty)
                        Total = Total + Convert.ToDecimal(row.Cells["FBLnChrgAmt"].Value);
                }
            }
            else
                Total = 0;
            setFBLnTotalLable();
        }

        private DataRow getVendorInfoStructure()
        {
            DataRow retval;
            DataTable dtVendorInfo = new DataTable();
            dtVendorInfo.Columns.Add("VendLabl");
            dtVendorInfo.Columns.Add("LocIdRemit");
            dtVendorInfo.Columns.Add("AlRemit1");
            dtVendorInfo.Columns.Add("AlRemit2");
            dtVendorInfo.Columns.Add("AlRemit3");
            dtVendorInfo.Columns.Add("AlRemit4");
            dtVendorInfo.Columns.Add("AlCityRemit");
            dtVendorInfo.Columns.Add("AlStateProvRemit");
            dtVendorInfo.Columns.Add("AlPostCodeRemit");
            dtVendorInfo.Columns.Add("AlCntryCodeRemit");
            retval = dtVendorInfo.NewRow();
            return retval;
        }
                
        private void checkInvoiceKeyDuplicate(string invoiceKey, string invID)
        {
            bool invoiceKeyExist = false;
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["InvKey"].ToString().Trim() == invoiceKey && row["InvId"].ToString().Trim() != invID)
                {
                    invoiceKeyExist = true;
                    break;
                }
            }
            if (invoiceKeyExist)
                MessageBox.Show("Invoice key duplicate.", "Data Entry");
        }

        private void checkFBKeyDuplicate(string fbKey, string fbID)
        {
            bool fbKeyExist = false;
            foreach (DataRow row in dsBatch.Tables["FB"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["FbKey"].ToString().Trim() == fbKey && row["FbId"].ToString().Trim() != fbID)
                {
                    fbKeyExist = true;
                    break;
                }
            }
            if (fbKeyExist)
                MessageBox.Show("Freight bill key duplicate.", "Data Entry");
        }

        private void makeMDBCopy(string batchNumber)
        {
            string filePath = ConfigurationManager.AppSettings["MDBSourcePath"] + "batchxxx";
            string newfile = ConfigurationManager.AppSettings["MDBSourcePath"] + "MXX" + batchNumber + ".mdb";
            if (!File.Exists(newfile))
            {
                try
                {
                    File.Copy(filePath, newfile);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private void clearControls()
        {
            foreach (Control control in grpBoxFreightBill.Controls)
            {
                if (control is TraxDETextBox)
                    ((TraxDETextBox)control).Clear();
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).Clear();
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                            ((TraxDETextBox)controls).Clear();
                    }
                }
            }
        }

        private void autoSave()
        {
            try
            {
                if (DeleteTriggered)
                {
                    updateInvoiceID();
                    updateFBID();
                    updateFBLnLineNumber();
                    DeleteTriggered = false;
                }
                if (Secure)
                {
                    bl.saveBatch(dsBatch, MXXDatabase, MXXOwnerKey);
                    dsBatch = bl.selectBatch(MXXDatabase.Trim());
                }
                else
                {
                    bl.saveBatchObj(dsBatch, MXXDatabase, MXXOwnerKey);
                    dsBatch = bl.selectBatchObj(MXXDatabase.Trim());
                }
                
                bindgrdInvoice();
                bindgrdFreightBill();
                bindgrdFBLine();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isInvAmtEqualVendInvAmt()
        {
            bool retval = false;
            decimal fbTotal;
            try
            {
                foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                {
                    if (Convert.ToDecimal(row["InvAmt"]) == Convert.ToDecimal(row["VendInvAmt"]))
                        retval = true;
                    else
                    {
                        fbTotal = 0;
                        this.dvFreightBill.RowFilter = string.Format("InvId = '{0}'", row["InvId"].ToString().Trim());
                        if (dvFreightBill.Count > 0)
                        {
                            foreach (DataRowView rowFB in dvFreightBill)
                            {
                                if (rowFB["FbAmt"].ToString() != string.Empty)
                                    fbTotal = fbTotal + Convert.ToDecimal(rowFB["FbAmt"]);
                            }
                        }
                        else
                            fbTotal = 0;

                        row.SetModified();
                        row["InvAmt"] = fbTotal.ToString();
                        if (Convert.ToDecimal(row["InvAmt"]) == Convert.ToDecimal(row["VendInvAmt"]))
                            retval = true;
                        else
                        {
                            retval = false;
                            break;
                        }
                    }
                }
            }
            catch
            {
                retval = false;
                MessageBox.Show("There are some VendInvAmt that does not match the InvAmt value, please review this batch.", "Data Entry");
            }
            return retval;
        }

        private void setAutoCompleteData(bool isShipper)
        {
            #region shipper
            if (isShipper)
            {
                orig1.Clear();
                orig2.Clear();
                orig3.Clear();
                orig4.Clear();
                cityOrig.Clear();
                stateProvOrig.Clear();
                postCodeOrig.Clear();
                cntryCodeOrig.Clear();
                dvShipper.RowFilter = string.Empty;
                //if (this.txtShipperName1.Text.Trim() != string.Empty)
                //    this.dvShipper.RowFilter = string.Format("Name1 = '{0}'", this.txtShipperName1.Text.Trim());
                //if (this.txtShipperName2.Text.Trim() != string.Empty)
                //{
                //    if (dvShipper.RowFilter.Trim() == string.Empty)
                //        this.dvShipper.RowFilter = string.Format("Name2 = '{0}'", this.txtShipperName2.Text.Trim());
                //    else
                //        this.dvShipper.RowFilter = this.dvShipper.RowFilter + string.Format(" AND Name2 = '{0}'", this.txtShipperName2.Text.Trim());
                //}
                //if (this.txtShipperAddress1.Text.Trim() != string.Empty)
                //{
                //    if (dvShipper.RowFilter.Trim() == string.Empty)
                //        this.dvShipper.RowFilter = string.Format("Address1 = '{0}'", this.txtShipperAddress1.Text.Trim());
                //    else
                //        this.dvShipper.RowFilter = this.dvShipper.RowFilter + string.Format(" AND Address1 = '{0}'", this.txtShipperAddress1.Text.Trim());
                //}
                //if (this.txtShipperAddress2.Text.Trim() != string.Empty)
                //{
                //    if (dvShipper.RowFilter.Trim() == string.Empty)
                //        this.dvShipper.RowFilter = string.Format("Address2 = '{0}'", this.txtShipperAddress2.Text.Trim());
                //    else
                //        this.dvShipper.RowFilter = this.dvShipper.RowFilter + string.Format(" AND Address2 = '{0}'", this.txtShipperAddress2.Text.Trim());
                //}
                //if (this.txtShipperCity.Text.Trim() != string.Empty)
                //{
                //    if (dvShipper.RowFilter.Trim() == string.Empty)
                //        this.dvShipper.RowFilter = string.Format("City = '{0}'", this.txtShipperCity.Text.Trim());
                //    else
                //        this.dvShipper.RowFilter = this.dvShipper.RowFilter + string.Format(" AND City = '{0}'", this.txtShipperCity.Text.Trim());
                //}
                //if (this.txtShipperSt.Text.Trim() != string.Empty)
                //{
                //    if (dvShipper.RowFilter.Trim() == string.Empty)
                //        this.dvShipper.RowFilter = string.Format("St = '{0}'", this.txtShipperSt.Text.Trim());
                //    else
                //        this.dvShipper.RowFilter = this.dvShipper.RowFilter + string.Format(" AND St = '{0}'", this.txtShipperSt.Text.Trim());
                //}
                //if (this.txtShipperZip.Text.Trim() != string.Empty)
                //{
                //    if (dvShipper.RowFilter.Trim() == string.Empty)
                //        this.dvShipper.RowFilter = string.Format("Zip = '{0}'", this.txtShipperZip.Text.Trim());
                //    else
                //        this.dvShipper.RowFilter = this.dvShipper.RowFilter + string.Format(" AND Zip = '{0}'", this.txtShipperZip.Text.Trim());
                //}
                //if (this.txtShipperCountry.Text.Trim() != string.Empty)
                //{
                //    if (dvShipper.RowFilter.Trim() == string.Empty)
                //        this.dvShipper.RowFilter = string.Format("Country = '{0}'", this.txtShipperCountry.Text.Trim());
                //    else
                //        this.dvShipper.RowFilter = this.dvShipper.RowFilter + string.Format(" AND Country = '{0}'", this.txtShipperCountry.Text.Trim());
                //}

                foreach (DataRowView row in dvShipper)
                {
                    //if (row["Name1"].ToString().Trim() != string.Empty && !orig1.Contains(row["Name1"].ToString().Trim()))
                        orig1.Add(row["Name1"].ToString().Trim());
                    //if (row["Name2"].ToString().Trim() != string.Empty && !orig2.Contains(row["Name2"].ToString().Trim()))
                        orig2.Add(row["Name2"].ToString().Trim());
                    //if (row["Address1"].ToString().Trim() != string.Empty && !orig3.Contains(row["Address1"].ToString().Trim()))
                        orig3.Add(row["Address1"].ToString());
                    //if (row["Address2"].ToString().Trim() != string.Empty && !orig4.Contains(row["Address2"].ToString().Trim()))
                        orig4.Add(row["Address2"].ToString());
                    //if (row["City"].ToString().Trim() != string.Empty && !cityOrig.Contains(row["City"].ToString().Trim()))
                        cityOrig.Add(row["City"].ToString());
                    //if (row["St"].ToString().Trim() != string.Empty && !stateProvOrig.Contains(row["St"].ToString().Trim()))
                        stateProvOrig.Add(row["St"].ToString());
                    //if (row["Zip"].ToString().Trim() != string.Empty && !postCodeOrig.Contains(row["Zip"].ToString().Trim()))
                        postCodeOrig.Add(row["Zip"].ToString());
                    //if (row["Country"].ToString().Trim() != string.Empty && !cntryCodeOrig.Contains(row["Country"].ToString().Trim()))
                        cntryCodeOrig.Add(row["Country"].ToString());
                }

                this.txtShipperName1.AutoCompleteCustomSource = orig1;
                this.txtShipperName2.AutoCompleteCustomSource = orig2;
                this.txtShipperAddress1.AutoCompleteCustomSource = orig3;
                this.txtShipperAddress2.AutoCompleteCustomSource = orig4;
                this.txtShipperCity.AutoCompleteCustomSource = cityOrig;
                this.txtShipperSt.AutoCompleteCustomSource = stateProvOrig;
                this.txtShipperZip.AutoCompleteCustomSource = postCodeOrig;
                this.txtShipperCountry.AutoCompleteCustomSource = cntryCodeOrig;
            }
            #endregion
            #region consignee
            else
            {
                dest1.Clear();
                dest2.Clear();
                dest3.Clear();
                dest4.Clear();
                cityDest.Clear();
                stateProvDest.Clear();
                postCodeDest.Clear();
                cntryCodeDest.Clear();
                dvConsignee.RowFilter = string.Empty;
                //if (this.txtConsigneeName1.Text.Trim() != string.Empty)
                //    this.dvConsignee.RowFilter = string.Format("Name1 = '{0}'", this.txtConsigneeName1.Text.Trim());
                //if (this.txtConsigneeName2.Text.Trim() != string.Empty)
                //{
                //    if (dvConsignee.RowFilter.Trim() == string.Empty)
                //        this.dvConsignee.RowFilter = string.Format("Name2 = '{0}'", this.txtConsigneeName2.Text.Trim());
                //    else
                //        this.dvConsignee.RowFilter = this.dvConsignee.RowFilter + string.Format(" AND Name2 = '{0}'", this.txtConsigneeName2.Text.Trim());
                //}
                //if (this.txtConsigneeAddress1.Text.Trim() != string.Empty)
                //{
                //    if (dvConsignee.RowFilter.Trim() == string.Empty)
                //        this.dvConsignee.RowFilter = string.Format("Address1 = '{0}'", this.txtConsigneeAddress1.Text.Trim());
                //    else
                //        this.dvConsignee.RowFilter = this.dvConsignee.RowFilter + string.Format(" AND Address1 = '{0}'", this.txtConsigneeAddress1.Text.Trim());
                //}
                //if (this.txtConsigneeAddress2.Text.Trim() != string.Empty)
                //{
                //    if (dvConsignee.RowFilter.Trim() == string.Empty)
                //        this.dvConsignee.RowFilter = string.Format("Address2 = '{0}'", this.txtConsigneeAddress2.Text.Trim());
                //    else
                //        this.dvConsignee.RowFilter = this.dvConsignee.RowFilter + string.Format(" AND Address2 = '{0}'", this.txtConsigneeAddress2.Text.Trim());
                //}
                //if (this.txtConsigneeCity.Text.Trim() != string.Empty)
                //{
                //    if (dvConsignee.RowFilter.Trim() == string.Empty)
                //        this.dvConsignee.RowFilter = string.Format("City = '{0}'", this.txtConsigneeCity.Text.Trim());
                //    else
                //        this.dvConsignee.RowFilter = this.dvConsignee.RowFilter + string.Format(" AND City = '{0}'", this.txtConsigneeCity.Text.Trim());
                //}
                //if (this.txtConsigneeSt.Text.Trim() != string.Empty)
                //{
                //    if (dvConsignee.RowFilter.Trim() == string.Empty)
                //        this.dvConsignee.RowFilter = string.Format("St = '{0}'", this.txtConsigneeSt.Text.Trim());
                //    else
                //        this.dvConsignee.RowFilter = this.dvConsignee.RowFilter + string.Format(" AND St = '{0}'", this.txtConsigneeSt.Text.Trim());
                //}
                //if (this.txtConsigneeZip.Text.Trim() != string.Empty)
                //{
                //    if (dvConsignee.RowFilter.Trim() == string.Empty)
                //        this.dvConsignee.RowFilter = string.Format("Zip = '{0}'", this.txtConsigneeZip.Text.Trim());
                //    else
                //        this.dvConsignee.RowFilter = this.dvConsignee.RowFilter + string.Format(" AND Zip = '{0}'", this.txtConsigneeZip.Text.Trim());
                //}
                //if (this.txtConsigneeCountry.Text.Trim() != string.Empty)
                //{
                //    if (dvConsignee.RowFilter.Trim() == string.Empty)
                //        this.dvConsignee.RowFilter = string.Format("Country = '{0}'", this.txtConsigneeCountry.Text.Trim());
                //    else
                //        this.dvConsignee.RowFilter = this.dvConsignee.RowFilter + string.Format(" AND Country = '{0}'", this.txtConsigneeCountry.Text.Trim());
                //}

                foreach (DataRowView row in dvConsignee)
                {
                    //if (row["Name1"].ToString().Trim() != string.Empty && !dest1.Contains(row["Name1"].ToString().Trim()))
                        dest1.Add(row["Name1"].ToString().Trim());
                    //if (row["Name2"].ToString().Trim() != string.Empty && !dest2.Contains(row["Name2"].ToString().Trim()))
                        dest2.Add(row["Name2"].ToString().Trim());
                    //if (row["Address1"].ToString().Trim() != string.Empty && !dest3.Contains(row["Address1"].ToString().Trim()))
                        dest3.Add(row["Address1"].ToString());
                    //if (row["Address2"].ToString().Trim() != string.Empty && !dest4.Contains(row["Address2"].ToString().Trim()))
                        dest4.Add(row["Address2"].ToString());
                    //if (row["City"].ToString().Trim() != string.Empty && !cityDest.Contains(row["City"].ToString().Trim()))
                        cityDest.Add(row["City"].ToString());
                    //if (row["St"].ToString().Trim() != string.Empty && !stateProvDest.Contains(row["St"].ToString().Trim()))
                        stateProvDest.Add(row["St"].ToString());
                    //if (row["Zip"].ToString().Trim() != string.Empty && !postCodeDest.Contains(row["Zip"].ToString().Trim()))
                        postCodeDest.Add(row["Zip"].ToString());
                    //if (row["Country"].ToString().Trim() != string.Empty && !cntryCodeDest.Contains(row["Country"].ToString().Trim()))
                        cntryCodeDest.Add(row["Country"].ToString());
                }

                this.txtConsigneeName1.AutoCompleteCustomSource = dest1;
                this.txtConsigneeName2.AutoCompleteCustomSource = dest2;
                this.txtConsigneeAddress1.AutoCompleteCustomSource = dest3;
                this.txtConsigneeAddress2.AutoCompleteCustomSource = dest4;
                this.txtConsigneeCity.AutoCompleteCustomSource = cityDest;
                this.txtConsigneeSt.AutoCompleteCustomSource = stateProvDest;
                this.txtConsigneeZip.AutoCompleteCustomSource = postCodeDest;
                this.txtConsigneeCountry.AutoCompleteCustomSource = cntryCodeDest;
            }
            #endregion
        }
        #endregion
    }
}