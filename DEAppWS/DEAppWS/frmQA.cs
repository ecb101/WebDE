using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CommonLibrary;
using FormControls;
using System.Configuration;
namespace DEAppWS
{
    public partial class frmQA : Form
    {
        //frmQAValidation frmQAV = null;
        private BatchEntryBL.BatchEntryBL batchEntryBL = new BatchEntryBL.BatchEntryBL();
        private QABL.QABL bl = new QABL.QABL();
        private DataSet dsBatch = new DataSet();
        private DataSet dsBatches = new DataSet();
        private DataSet dsChargeCode = new DataSet();
        private DataView dvBatches = new DataView();
        private DataView dvInvoice = new DataView();
        private DataView dvFreightBill = new DataView();
        private DataView dvFXI = new DataView();
        private DataView dvFBLine = new DataView();
        private DataView dvChargeCode = new DataView();
        private DataTable tdTraceDE = new DataTable("Trace");
        private string MXXDatabase = string.Empty;
        private string MXXOwnerCode = string.Empty;        
        private decimal Total;
        private decimal FBTotal;
        private bool singleFB = false;
        private bool multipleCurrency = false;
        private bool isInvoiceKeyAlphaNumeric = false;
        private bool isFreightBillKeyAlphaNumeric = false;
        private DataSet dsOwnerKeyAlphaNumeric = new DataSet();
        private CommonEnum.FormState currentFormState = CommonEnum.FormState.NORMAL_STATE;
        //private DataView dvInvoiceTemp = new DataView();
        //private DataView dvFBTemp = new DataView();
        //private bool checkRandomQA =  true;
        private bool isFullQA = false;
        
        public frmQA()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            batchEntryBL.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(batchEntryBL.Url);
            this.InvoiceInvCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList());
            this.FBFbCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList());
            this.FBLnCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList());
            this.FBLnT003.Items.AddRange(CommonMethod.getCurrencyList());
            dsOwnerKeyAlphaNumeric = batchEntryBL.selectAlphaNumericKey();
        }

        #region events
        #region grid
        private void grdImageGroup_SelectionChanged(object sender, EventArgs e)
        {
            populateParameter();
            if (MXXDatabase.Trim() != string.Empty)
            {
                tdTraceDE.Clear();
                dsBatch = batchEntryBL.selectBatch(MXXDatabase.Trim());
                bindgrdInvoice();
                grdInvoice_SelectionChanged(null, null);
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
            }
            setTotal();
            enableToolStripButtons(currentFormState);
            determineMode();
            determineMultipleCurrencyMode();
        }

        private void grdInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (MXXDatabase.Trim() != string.Empty)
            {
                bindgrdFreightBill();
                grdFreightBill_SelectionChanged(null, null);
                updateInvoiceCounter();
            }
        }

        private void grdFreightBill_SelectionChanged(object sender, EventArgs e)
        {
            if (MXXDatabase.Trim() != string.Empty)
            {
                bindgrdFBLine();
                updateFBCounter();
            }
        }

        private void grdInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataView dv = new DataView();
            dv.Table = dsBatch.Tables["Invoice"];
            dv.RowFilter = string.Format("InvId = '{0}'", grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvId"].Value.ToString().Trim());
            dv[0].BeginEdit();
            if (e.ColumnIndex == 2)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvKey"].Value.ToString().Trim();
                string invId = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvId"].Value.ToString().Trim();
                if (isInvoiceKeyAlphaNumeric)
                {
                    Regex regStr = new Regex("[^a-zA-Z0-9]");
                    value = regStr.Replace(value, string.Empty);
                }
                grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvKey"].Value = value;
                checkInvoiceKeyDuplicate(value, invId);
                updateInvKey(value, invId);
            }
            else if (e.ColumnIndex == 3)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceVendInvAmt"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                {
                    grdInvoice.Rows[e.RowIndex].Cells["InvoiceVendInvAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                }
                setFBTotalLable();
                setTotal();
            }
            else if (e.ColumnIndex == 5)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvCurrencyQual"].Value.ToString().Trim();
                if (multipleCurrency)
                {
                    if (MessageBox.Show("Your action will reset all amount in your multiple currency line items, proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        updateCurrencyQual(value);
                }
                else
                    updateCurrencyQual(value);
            }
            else if (e.ColumnIndex == 6)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceAcctIdVendBlng"].Value.ToString().Trim();
                string invId = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvId"].Value.ToString().Trim();
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
            if (e.ColumnIndex == 4)
            {
                string value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value.ToString().Trim().Replace(" ", string.Empty);
                string invId = grdFreightBill.Rows[e.RowIndex].Cells["FBFbId"].Value.ToString().Trim();
                if (isFreightBillKeyAlphaNumeric)
                {
                    Regex regStr = new Regex("[^a-zA-Z0-9]");
                    value = regStr.Replace(value, string.Empty);
                }
                if (singleFB)
                {
                    grdInvoice.Rows[0].Cells["InvoiceInvKey"].Value = value;// grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value.ToString();
                    grdFreightBill.Rows[e.RowIndex].Cells["FBInvKey"].Value = invId;//grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value.ToString();
                }
                grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value = value;
                checkFBKeyDuplicate(grdFreightBill.Rows[e.RowIndex].Cells["FBFbKey"].Value.ToString().Trim(), grdFreightBill.Rows[e.RowIndex].Cells["FBFbId"].Value.ToString().Trim());
            }
            if (e.ColumnIndex == 5)
            {
                string value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                    grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
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
                if (singleFB)
                    grdInvoice.Rows[0].Cells["InvoiceVendInvAmt"].Value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value.ToString();
                setFBTotalLable();
                setFBLnTotal();
                setTotal();
            }
            else if (e.ColumnIndex == 7)
            {
                string value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbCurrencyQual"].Value.ToString().Trim();
                if (multipleCurrency)
                {
                    if (MessageBox.Show("Your action will reset all amount in your multiple currency line items, proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        updateCurrencyQual(value);
                }
                else
                    updateCurrencyQual(value);
            }
            else if (e.ColumnIndex == 8)
            {
                grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAcctIdVendBlng"].Value = grdFreightBill.Rows[e.RowIndex].Cells["FBAcctNumVendBlng"].Value.ToString();
                string value = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAcctIdVendBlng"].Value.ToString().Trim();
                string invId = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim();
                updateAcctNumVendBlng(value, invId);
            }

            else if (e.ColumnIndex == 9)
            {
                if (grdFreightBill.Rows[e.RowIndex].Cells["FBFbCreatDtm"].Value.ToString().Trim() != string.Empty)
                    if (Convert.ToDateTime(grdFreightBill.Rows[e.RowIndex].Cells["FBFbCreatDtm"].Value.ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(grdFreightBill.Rows[e.RowIndex].Cells["FBFbCreatDtm"].Value.ToString().Trim()) > (bl.GetServerDate().AddDays(30)))
                        MessageBox.Show("Date out of range.", "Quality Assurance");
            }
            else if (e.ColumnIndex == 39)
            {
                if (grdFreightBill.Rows[e.RowIndex].Cells["FBLmPkupActualDtm"].Value.ToString().Trim() != string.Empty)
                    if (Convert.ToDateTime(grdFreightBill.Rows[e.RowIndex].Cells["FBLmPkupActualDtm"].Value.ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(grdFreightBill.Rows[e.RowIndex].Cells["FBLmPkupActualDtm"].Value.ToString().Trim()) > (bl.GetServerDate().AddDays(30)))
                        MessageBox.Show("Date out of range.", "Quality Assurance");
            }
            else if (e.ColumnIndex == 40)
            {
                if (grdFreightBill.Rows[e.RowIndex].Cells["FBLmAtaDtm"].Value.ToString().Trim() != string.Empty)
                    if (Convert.ToDateTime(grdFreightBill.Rows[e.RowIndex].Cells["FBLmAtaDtm"].Value.ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(grdFreightBill.Rows[e.RowIndex].Cells["FBLmAtaDtm"].Value.ToString().Trim()) > (bl.GetServerDate().AddDays(30)))
                        MessageBox.Show("Date out of range.", "Quality Assurance");
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
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                    }
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
                    setFBLnTotal();
                    setTotal();
                }

                else if (e.ColumnIndex == 16)
                {
                    string value = grdFBLine.Rows[e.RowIndex].Cells["FBLnCurrencyQual"].Value.ToString().Trim();
                    if (multipleCurrency)
                    {
                        if (MessageBox.Show("Your action will reset all amount in your multiple currency line items, proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            updateCurrencyQual(value);
                    }
                    else
                        updateCurrencyQual(value);
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

        private void grdInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE && !singleFB)
            {
                if (e.ColumnIndex == 8 ||
                    e.ColumnIndex == 9 ||
                    e.ColumnIndex == 10 ||
                    e.ColumnIndex == 11 ||
                    e.ColumnIndex == 12 ||
                    e.ColumnIndex == 13 ||
                    e.ColumnIndex == 14 ||
                    e.ColumnIndex == 15 ||
                    e.ColumnIndex == 16)
                {
                    if (grdInvoice.Rows[e.RowIndex].Cells["InvoiceLocIdRemit"].Value.ToString().Trim() != string.Empty)
                    {
                        int length = grdInvoice.Rows[e.RowIndex].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Length;
                        int remitId = Convert.ToInt32(grdInvoice.Rows[e.RowIndex].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Substring(length - 5, 5));
                        string SCAC = grdInvoice.Rows[e.RowIndex].Cells["InvoiceVendLabl"].Value.ToString().Trim();
                        frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC, remitId);
                        frmVendorInfo.ShowDialog();
                        if (frmVendorInfo.VendorInfoSelected)
                        {
                            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = frmVendorInfo.VendorInfoRow["LocIdRemit"];
                            foreach (DataRow row in ((DataView)grdInvoice.DataSource).Table.Rows)
                            {
                                row["LocIdRemit"] = frmVendorInfo.VendorInfoRow["LocIdRemit"];
                                row["AlRemit1"] = frmVendorInfo.VendorInfoRow["AlRemit1"];
                                row["AlRemit2"] = frmVendorInfo.VendorInfoRow["AlRemit2"];
                                row["AlRemit3"] = frmVendorInfo.VendorInfoRow["AlRemit3"];
                                row["AlRemit4"] = frmVendorInfo.VendorInfoRow["AlRemit4"];
                                row["AlCityRemit"] = frmVendorInfo.VendorInfoRow["AlCityRemit"];
                                row["AlStateProvRemit"] = frmVendorInfo.VendorInfoRow["AlStateProvRemit"];
                                row["AlPostCodeRemit"] = frmVendorInfo.VendorInfoRow["AlPostCodeRemit"];
                                row["AlCntryCodeRemit"] = frmVendorInfo.VendorInfoRow["AlCntryCodeRemit"];
                            }
                        }
                        grdInvoice.Select();
                        grdInvoice.CurrentCell = grdInvoice.Rows[e.RowIndex].Cells["InvoiceLocIdRemit"];
                    }
                }
            }
        }

        private void grdInvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE && !singleFB)
            {
                if (e.KeyChar == 13)
                {
                    if ((grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlRemit1"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlRemit2"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlRemit3"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlRemit4"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlCityRemit"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlStateProvRemit"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlPostCodeRemit"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceAlCntryCodeRemit"]
                        || grdInvoice.CurrentCell == grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvFbCnt"]) && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim() != string.Empty)
                    {
                        int length = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Length;
                        int remitId = Convert.ToInt32(grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Substring(length - 5, 5));
                        string SCAC = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceVendLabl"].Value.ToString().Trim();
                        frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC, remitId);
                        frmVendorInfo.ShowDialog();
                        if (frmVendorInfo.VendorInfoSelected)
                        {
                            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = frmVendorInfo.VendorInfoRow["LocIdRemit"];
                            foreach (DataRow row in ((DataView)grdInvoice.DataSource).Table.Rows)
                            {
                                row["LocIdRemit"] = frmVendorInfo.VendorInfoRow["LocIdRemit"];
                                row["AlRemit1"] = frmVendorInfo.VendorInfoRow["AlRemit1"];
                                row["AlRemit2"] = frmVendorInfo.VendorInfoRow["AlRemit2"];
                                row["AlRemit3"] = frmVendorInfo.VendorInfoRow["AlRemit3"];
                                row["AlRemit4"] = frmVendorInfo.VendorInfoRow["AlRemit4"];
                                row["AlCityRemit"] = frmVendorInfo.VendorInfoRow["AlCityRemit"];
                                row["AlStateProvRemit"] = frmVendorInfo.VendorInfoRow["AlStateProvRemit"];
                                row["AlPostCodeRemit"] = frmVendorInfo.VendorInfoRow["AlPostCodeRemit"];
                                row["AlCntryCodeRemit"] = frmVendorInfo.VendorInfoRow["AlCntryCodeRemit"];
                            }
                        }
                        grdInvoice.Select();
                        grdInvoice.CurrentCell = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"];
                    }
                }
            }
        }

        private void grdFreightBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (currentFormState == CommonEnum.FormState.OPEN_STATE)
            //{
            //    if (frmQAV == null || frmQAV.IsDisposed)
            //    {
            //        frmQAV = new frmQAValidation(Convert.ToString(grdInvoice.CurrentRow.Cells["InvoiceInvKey"].Value), Convert.ToDecimal(grdInvoice.CurrentRow.Cells["InvoiceInvAmt"].Value), Convert.ToString(grdFreightBill.CurrentRow.Cells["FBFbKey"].Value), Convert.ToDecimal(grdFreightBill.CurrentRow.Cells["FBfbAmt"].Value));
            //    }
            //    frmQAV.Show();
            //}
        }
        #endregion

        #region toolStrip
        private void toolStripButtonStartQA_Click(object sender, EventArgs e)
        {
            try
            {
                if (bl.isAllowQA(MXXDatabase) && bl.isAllowQAEdit(MXXDatabase, System.Environment.UserName))
                {
                    if (bl.startReview(MXXDatabase, CommonUserLogin.getUser().UserInitials))//update Batch_DE Rev_Init, REV_START_DTM
                    {
                        bl.auditTrailBatch(MXXDatabase, "121", System.Environment.UserName);
                        currentFormState = CommonEnum.FormState.OPEN_STATE;
                        enableToolStripButtons(currentFormState);
                        DataSet dsQAConfig = new DataSet();
                        dsQAConfig = bl.selectQAConfig(grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString(), grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["VendSCAC"].Value.ToString());
                        
                        if (dsQAConfig.Tables.Count > 0 && dsQAConfig.Tables[0].Rows.Count > 0)
                        {
                            Random random = new Random();
                            int randomNumber = random.Next(0, 100);
                            if (randomNumber <= Convert.ToInt16(dsQAConfig.Tables[0].Rows[0]["FBFullQAPercent"]))
                                isFullQA = true;
                            else
                                isFullQA = false;
                        }
                        else
                            isFullQA = false;

                        frmValidation frmCurrencyValidation = new frmValidation(dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"].ToString().Trim(), dsBatch.Tables["InvBat"].Rows[0]["VendLabl"].ToString().Trim(), getInvoiceValidationTable(), getFBValidationTable(), dsQAConfig.Tables[0], isFullQA, MXXDatabase, grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString(), grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value.ToString());
                        this.Hide();
                        frmCurrencyValidation.ShowDialog();
                        if (frmCurrencyValidation.isValidationCancelled)
                        {
                            toolStripButtonQAOnHold_Click(null, null);
                        }
                        else if (frmCurrencyValidation.isForRekey)
                        {
                            toolStripButtonRekey_Click(null, null);
                        }
                        else if (frmCurrencyValidation.isForDeactivation)
                        {
                            try
                            {
                                if (batchEntryBL.updateStatus(MXXDatabase, "DEACTIVATION"))//update status
                                {
                                    bl.auditTrailBatch(MXXDatabase, "125", System.Environment.UserName);
                                    dsBatches = bl.selectBatches();//refresh grid
                                    bindgrdBatches();
                                    grdImageGroup_SelectionChanged(null, null);
                                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                                    enableToolStripButtons(currentFormState);
                                    MessageBox.Show("Successfully set for Deactivation.", "Quality Assurance");
                                }
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                isFullQA = false;
                                grdFreightBill.DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }
                        else
                        {
                            if (frmCurrencyValidation.isUpdateCurrency)
                            {
                                updateCurrencyQual(frmCurrencyValidation.ValidatedCurrency);
                            }
                            if (frmCurrencyValidation.isWrongInvoiceFBKey)
                            {
                                DataView dvInv = new DataView();
                                dvInv.Table = dsBatch.Tables["Invoice"];
                                foreach (DataRow row in frmCurrencyValidation.CorrectionSet.Tables["Invoice"].Rows)
                                {
                                    dvInv.RowFilter = string.Format("InvId = '{0}'", row["InvId"].ToString().Trim());
                                    dvInv[0].BeginEdit();
                                    dvInv[0]["InvKey"] = row["InvKey"];
                                    dvInv[0]["InvAmt"] = row["InvAmt"];
                                    dvInv[0]["VendInvAmt"] = row["InvAmt"];
                                    dvInv[0]["AcctNumVendBlng"] = row["AcctNumVendBlng"];
                                    dvInv[0]["InvCreatDtm"] = row["InvCreatDtm"];
                                    updateInvKey(row["InvKey"].ToString().Trim(), row["InvId"].ToString().Trim());
                                    dvInv[0].EndEdit();
                                }
                                if (frmCurrencyValidation.isFBValidated)
                                {
                                    DataView dvFb = new DataView();
                                    dvFb.Table = dsBatch.Tables["FB"];
                                    foreach (DataRow row in frmCurrencyValidation.CorrectionSet.Tables["FB"].Rows)
                                    {
                                        dvFb.RowFilter = string.Format("FbId = '{0}'", row["FbId"].ToString().Trim());
                                        dvFb[0].BeginEdit();
                                        dvFb[0]["FbKey"] = row["FbKey"];
                                        dvFb[0]["FbAmt"] = row["FbAmt"];
                                        dvFb[0]["FbCreatDtm"] = row["FbCreatDtm"];
                                        dvFb[0]["FbPaymtTermsCode"] = row["FbPaymtTermsCode"];
                                        dvFb[0].EndEdit();
                                    }
                                }
                            }
                            toolStripButtonSave_Click(null, null);
                        }
                    }
                    else
                        MessageBox.Show("There was a problem when starting to review this batch.", "Quality Assurance");
                }
                else
                    MessageBox.Show("This batch is currently QA by a different user.", "Quality Assurance");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Show();
            }
        }

        private void toolStripButtonContQA_Click(object sender, EventArgs e)
        {
            try
            {
                if (bl.isAllowUserQA(MXXDatabase, CommonUserLogin.getUser().UserInitials))
                {
                    if (bl.isAllowQAEdit(MXXDatabase, System.Environment.UserName))
                    {
                        currentFormState = CommonEnum.FormState.OPEN_STATE;
                        enableToolStripButtons(currentFormState);
                        DataSet dsQAConfig = new DataSet();
                        dsQAConfig = bl.selectQAConfig(grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString(), grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["VendSCAC"].Value.ToString());
                        
                        if (dsQAConfig.Tables.Count > 0 && dsQAConfig.Tables[0].Rows.Count > 0)
                        {
                            Random random = new Random();
                            int randomNumber = random.Next(0, 100);
                            if (randomNumber <= Convert.ToInt16(dsQAConfig.Tables[0].Rows[0]["FBFullQAPercent"]))
                                isFullQA = true;
                            else
                                isFullQA = false;
                        }
                        else
                            isFullQA = false;
                        frmValidation frmCurrencyValidation = new frmValidation(dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"].ToString().Trim(), dsBatch.Tables["InvBat"].Rows[0]["VendLabl"].ToString().Trim(), getInvoiceValidationTable(), getFBValidationTable(), dsQAConfig.Tables[0], isFullQA, MXXDatabase, grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString(), grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value.ToString());
                        this.Hide();
                        frmCurrencyValidation.ShowDialog();
                        if (frmCurrencyValidation.isValidationCancelled)
                        {
                            toolStripButtonQAOnHold_Click(null, null);
                        }
                        else if (frmCurrencyValidation.isForRekey)
                        {
                            toolStripButtonRekey_Click(null, null);
                        }
                        else if (frmCurrencyValidation.isForDeactivation)
                        {
                            try
                            {
                                if (batchEntryBL.updateStatus(MXXDatabase, "DEACTIVATION"))//update status
                                {
                                    bl.auditTrailBatch(MXXDatabase, "125", System.Environment.UserName);
                                    dsBatches = bl.selectBatches();//refresh grid
                                    bindgrdBatches();
                                    grdImageGroup_SelectionChanged(null, null);
                                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                                    enableToolStripButtons(currentFormState);
                                    MessageBox.Show("Successfully set for Deactivation.", "Quality Assurance");
                                }
                            }
                            catch (Exception error)
                            {
                                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            finally
                            {
                                isFullQA = false;
                                grdFreightBill.DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }
                        else
                        {
                            if (frmCurrencyValidation.isUpdateCurrency)
                            {
                                updateCurrencyQual(frmCurrencyValidation.ValidatedCurrency);
                            }
                            if (frmCurrencyValidation.isWrongInvoiceFBKey)
                            {
                                DataView dvInv = new DataView();
                                dvInv.Table = dsBatch.Tables["Invoice"];
                                foreach (DataRow row in frmCurrencyValidation.CorrectionSet.Tables["Invoice"].Rows)
                                {
                                    dvInv.RowFilter = string.Format("InvId = '{0}'", row["InvId"].ToString().Trim());
                                    dvInv[0].BeginEdit();
                                    dvInv[0]["InvKey"] = row["InvKey"];
                                    dvInv[0]["InvAmt"] = row["InvAmt"];
                                    dvInv[0]["VendInvAmt"] = row["InvAmt"];
                                    dvInv[0]["AcctNumVendBlng"] = row["AcctNumVendBlng"];
                                    dvInv[0]["InvCreatDtm"] = row["InvCreatDtm"];
                                    updateInvKey(row["InvKey"].ToString().Trim(), row["InvId"].ToString().Trim());
                                    dvInv[0].EndEdit();
                                }
                                if (frmCurrencyValidation.isFBValidated)
                                {
                                    DataView dvFb = new DataView();
                                    dvFb.Table = dsBatch.Tables["FB"];
                                    foreach (DataRow row in frmCurrencyValidation.CorrectionSet.Tables["FB"].Rows)
                                    {
                                        dvFb.RowFilter = string.Format("FbId = '{0}'", row["FbId"].ToString().Trim());
                                        dvFb[0].BeginEdit();
                                        dvFb[0]["FbKey"] = row["FbKey"];
                                        dvFb[0]["FbAmt"] = row["FbAmt"];
                                        dvFb[0]["FbCreatDtm"] = row["FbCreatDtm"];
                                        dvFb[0]["FbPaymtTermsCode"] = row["FbPaymtTermsCode"];
                                        dvFb[0].EndEdit();
                                    }
                                }
                            }
                            toolStripButtonSave_Click(null, null);
                        }
                    }
                    else
                        MessageBox.Show("There was a problem when setting this batch to edit mode.", "Quality Assurance");
                }
                else
                    MessageBox.Show("This batch is currently QA by a different user.", "Quality Assurance");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Show();
            }
        }

        private void toolStripButtonQAPass_Click(object sender, EventArgs e)
        {            
            try
            {
                if (isQAPassAllowed())
                {
                    isCurrencyAdjustmentAllowed();
                    if (MessageBox.Show(isTotalMatch() == true ? "QA pass batch will be moved to production." : "The amount did not sum up correctly. Do you wish to proceed?", "Quality Assurance", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (bl.completeReview(MXXDatabase, MXXOwnerCode, dsBatch.Tables["Invoice"].Rows.Count, dsBatch.Tables["FB"].Rows.Count, dsBatch.Tables["FBLn"].Rows.Count, multipleCurrency, isFullQA, CommonUserLogin.getUser().UserInitials))
                        {
                            bl.auditTrailBatch(MXXDatabase, "123", System.Environment.UserName);
                            dsBatches = bl.selectBatches();//refresh grid                        
                            grdImageGroup.ClearSelection();
                            bindgrdBatches();
                            grdImageGroup_SelectionChanged(null, null);
                            currentFormState = CommonEnum.FormState.NORMAL_STATE;
                            enableToolStripButtons(currentFormState);
                            MessageBox.Show("Batch successfully sent for production.", "Quality Assurance");                                
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void toolStripButtonRekey_Click(object sender, EventArgs e)
        {
            try
            {
                if (batchEntryBL.updateStatus(MXXDatabase, "RE-KEY"))//update status
                {
                    bl.auditTrailBatch(MXXDatabase, "122", System.Environment.UserName);
                    dsBatches = bl.selectBatches();//refresh grid
                    bindgrdBatches();                    
                    grdImageGroup_SelectionChanged(null, null);
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    enableToolStripButtons(currentFormState);
                    MessageBox.Show("Successfully sent back for re-key.", "Quality Assurance");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {   
                isFullQA = false;
                grdFreightBill.DefaultCellStyle.ForeColor = Color.Black;                
            }
        }

        private void toolStripButtonQAOnHold_Click(object sender, EventArgs e)
        {
            try
            {
                batchEntryBL.updateStatus(MXXDatabase, "REVIEW");
                bl.auditTrailBatch(MXXDatabase, "124", System.Environment.UserName);
                currentFormState = CommonEnum.FormState.NORMAL_STATE;
                dsBatches = bl.selectBatches();
                bindgrdBatches();
                
                grdImageGroup_SelectionChanged(null, null);
                enableToolStripButtons(currentFormState);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {   
                isFullQA = false;
                grdInvoice.DefaultCellStyle.ForeColor = Color.Black;                
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            currentFormState = CommonEnum.FormState.EDIT_STATE;
            enableToolStripButtons(currentFormState);
        }

        private void toolStripButtonSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                updateFBValues();
                updateCounter();
                if (batchEntryBL.saveBatch(dsBatch, MXXDatabase, grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString()))
                {
                    //batchEntryBL.repairDatabase(MXXDatabase);
                    //batchEntryBL.saveBatchObj(dsBatch, MXXDatabase, grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString());
                    dsBatch = batchEntryBL.selectBatch(MXXDatabase.Trim());
                    bindgrdInvoice();
                    bindgrdFreightBill();
                    bindgrdFBLine();
                    MessageBox.Show("Saving successful.", "Quality Assurance");
                    setTotal();
                    currentFormState = CommonEnum.FormState.OPEN_STATE;
                    enableToolStripButtons(currentFormState);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (batchEntryBL.saveBatch(dsBatch, MXXDatabase, grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString()))
                {
                    //batchEntryBL.repairDatabase(MXXDatabase);
                    //batchEntryBL.saveBatchObj(dsBatch, MXXDatabase, grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString());
                    dsBatch = batchEntryBL.selectBatch(MXXDatabase.Trim());
                    bindgrdInvoice();
                    bindgrdFreightBill();
                    bindgrdFBLine();
                    MessageBox.Show("Saving successful.", "Quality Assurance");
                    setTotal();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel all changes done?", "Cancel updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    currentFormState = CommonEnum.FormState.OPEN_STATE;
                    batchEntryBL.updateStatus(MXXDatabase, "REVIEW");
                    dsBatch = batchEntryBL.selectBatch(MXXDatabase.Trim());
                    bindgrdInvoice();
                    grdInvoice_SelectionChanged(null, null);
                    setTotal();
                    enableToolStripButtons(currentFormState);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region others
        private void frmQA_Load(object sender, EventArgs e)
        {
            dsChargeCode = batchEntryBL.selectChargeCode();
            dvChargeCode.Table = dsChargeCode.Tables[0];
        }

        private void frmQA_Enter(object sender, EventArgs e)
        {
            if (currentFormState != CommonEnum.FormState.OPEN_STATE || currentFormState != CommonEnum.FormState.EDIT_STATE)
            {
                dsBatches = bl.selectBatches();
                bindgrdBatches();
                grdImageGroup_SelectionChanged(null, null);
                if (dsBatches.Tables[0].Rows.Count == 0)
                    enableToolStripButtons(currentFormState);
            }
        }

        private void frmQA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.OPEN_STATE)
            {
                MessageBox.Show("Cannot close in Edit or Open mode.", "Quality Assurance");
                e.Cancel = true;
            }
        }

        private void frmQA_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (e.Control == true && e.KeyValue == 66)//Ctrl+B
                {
                    if (multipleCurrency)
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
                if (e.Control == true && e.KeyValue == 75)//Ctrl+K 
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
                else if ((e.Control == true && e.KeyValue == 69))//Ctrl+E
                {
                    if (grdInvoice.SelectedRows.Count > 0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim() != string.Empty)
                    {
                        int length = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Length;
                        int remitId = Convert.ToInt32(grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceLocIdRemit"].Value.ToString().Trim().Substring(length - 5, 5));
                        string SCAC = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["VendSCAC"].Value.ToString();
                        frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC, remitId);
                        frmVendorInfo.ShowDialog();
                        if (frmVendorInfo.VendorInfoSelected)
                        {
                            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = frmVendorInfo.VendorInfoRow["LocIdRemit"];
                            foreach (DataRow row in ((DataView)grdInvoice.DataSource).Table.Rows)
                            {
                                row["LocIdRemit"] = frmVendorInfo.VendorInfoRow["LocIdRemit"];
                                row["AlRemit1"] = frmVendorInfo.VendorInfoRow["AlRemit1"];
                                row["AlRemit2"] = frmVendorInfo.VendorInfoRow["AlRemit2"];
                                row["AlRemit3"] = frmVendorInfo.VendorInfoRow["AlRemit3"];
                                row["AlRemit4"] = frmVendorInfo.VendorInfoRow["AlRemit4"];
                                row["AlCityRemit"] = frmVendorInfo.VendorInfoRow["AlCityRemit"];
                                row["AlStateProvRemit"] = frmVendorInfo.VendorInfoRow["AlStateProvRemit"];
                                row["AlPostCodeRemit"] = frmVendorInfo.VendorInfoRow["AlPostCodeRemit"];
                                row["AlCntryCodeRemit"] = frmVendorInfo.VendorInfoRow["AlCntryCodeRemit"];
                            }
                        }

                        grdInvoice.Select();
                        grdInvoice.CurrentCell = grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvKey"];
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsChargeCode = batchEntryBL.selectChargeCode();
            dvChargeCode.Table = dsChargeCode.Tables[0];
            dsBatches = bl.selectBatches();
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
            if (dsBatches.Tables[0].Rows.Count == 0)
                enableToolStripButtons(currentFormState);
            dsOwnerKeyAlphaNumeric = batchEntryBL.selectAlphaNumericKey();
            this.Cursor = Cursors.Default;
        }
        #endregion
        #endregion

        #region Developer Designed method
        private void populateParameter()
        {
            MXXDatabase = string.Empty;
            MXXOwnerCode = string.Empty;
            if (this.grdImageGroup.Rows.Count > 0 && this.grdImageGroup.SelectedRows.Count > 0)
            {
                MXXDatabase = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["BatchNumber"].Value.ToString();
                MXXOwnerCode = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerCode"].Value.ToString();
                string MXXOwnerKey = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString();
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
            }
        }

        private void bindgrdBatches()
        {
            grdImageGroup.SelectionChanged -= new EventHandler(grdImageGroup_SelectionChanged);
            dvBatches.Table = dsBatches.Tables[0];
            this.dvBatches.RowFilter = string.Format("[Batch Number] LIKE '{0}%' OR [QA By] LIKE '{0}%' OR [Operator] LIKE '{0}%' OR [Vendor SCAC] LIKE '{0}%' OR [OwnerCode] LIKE '{0}%'", this.txtSearch.Text.Trim());
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
                if ((DataView)grdFreightBill.DataSource != null)
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
                if (grdInvoice.SelectedRows.Count > 0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim() != string.Empty)
                    this.dvFreightBill.RowFilter = string.Format("InvId = '{0}'", grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim());
                else if (grdInvoice.SelectedRows.Count > 0 && grdInvoice.Rows[grdInvoice.SelectedRows[0].Index].Cells["InvoiceInvId"].Value.ToString().Trim() == string.Empty)
                    this.dvFreightBill.RowFilter = string.Format("InvId = '{0}'", "");
                this.grdFreightBill.DataSource = dvFreightBill;
                this.grdFreightBill.AutoResizeColumns();
                this.grdFreightBill.Refresh();
                grdFreightBill.SelectionChanged += new EventHandler(grdFreightBill_SelectionChanged);
                //BindingSource bsFB = new BindingSource();
                //bsFB.DataSource = dvFreightBill;
                if (grdFreightBill.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in grdFreightBill.Rows)
                    {
                        if (row.Cells["FBFbAmt"].Value.ToString() != string.Empty)
                            FBTotal = FBTotal + Convert.ToDecimal(row.Cells["FBFbAmt"].Value);
                        //if (dvFBTemp != null && dvFBTemp.Count>0)
                        //{
                        //    dvFBTemp.RowFilter = string.Format("FbKey = '{0}'", row.Cells["FBFbKey"].Value.ToString().Trim());
                        //    if (dvFBTemp.Count > 0)
                        //    {
                        //        if (Convert.ToBoolean(dvFBTemp[0]["isCorrect"]))
                        //            grdFreightBill.Rows[bsFB.Find("FbKey", dvFBTemp[0][1])].DefaultCellStyle.ForeColor = Color.Black;
                        //        else
                        //            grdFreightBill.Rows[bsFB.Find("FbKey", dvFBTemp[0][1])].DefaultCellStyle.ForeColor = Color.Red;
                        //    }
                        //    else
                        //        grdFreightBill.DefaultCellStyle.ForeColor = Color.Black;
                        //}
                    }
                }
                else
                    FBTotal = 0;
            }
            setFBTotalLable();
        }

        private void bindgrdFBLine()
        {
            Total = 0;
            if (dsBatch == null)
            {
                if ((DataView)grdFBLine.DataSource != null)
                {
                    if (dvFBLine.Table != null)
                        dvFBLine.Table.Rows.Clear();
                    grdFBLine.DataSource = dvFBLine;
                }
            }
            else
            {
                dvFBLine.Table = dsBatch.Tables["FBLn"];
                dvFXI.Table = dsBatch.Tables["FXI"];
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
                        if (row.Cells["FBLnChrgAmt"].Value.ToString() != string.Empty)
                            Total = Total + Convert.ToDecimal(row.Cells["FBLnChrgAmt"].Value);
                    }
                }
                else
                    Total = 0;
                if (grdFreightBill.SelectedRows.Count > 0)
                    dvFXI.RowFilter = string.Format("FbId  ='{0}'", grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbId"].Value.ToString().Trim(), grdFreightBill.Rows[grdFreightBill.SelectedRows[0].Index].Cells["FBFbKey"].Value.ToString().Trim());
                else
                    dvFXI.RowFilter = string.Format("FbId  ='{0}'", "");
                this.grdFXI.DataSource = dvFXI;
                this.grdFXI.AutoResizeColumns();
                this.grdFXI.Refresh();

            }
            setFBLnTotal();

        }

        private void checkInvoiceKeyDuplicate(string invoiceKey, string invID)
        {
            bool invoiceKeyExist = false;
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                if (row["InvKey"].ToString().Trim() == invoiceKey && row["InvId"].ToString().Trim() != invID)
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
                if (row["FbKey"].ToString().Trim() == fbKey && row["FbId"].ToString().Trim() != fbID)
                {
                    fbKeyExist = true;
                    break;
                }
            }
            if (fbKeyExist)
                MessageBox.Show("Freight bill key duplicate.", "Data Entry");
        }

        private void determineMode()
        {
            if (dsBatch != null && dsBatch.Tables.Count > 0 && dsBatch.Tables["Invoice"].Rows.Count > 0 && dsBatch.Tables["Invoice"].Rows[0]["InvStat"].ToString().Trim() == "SingleBill")
                singleFB = true;
            else
                singleFB = false;
        }

        private void determineMultipleCurrencyMode()
        {
            if (dsBatch != null && dsBatch.Tables.Count > 0 && dsBatch.Tables["FBLn"].Rows.Count > 0)
            {
                if (dsBatch.Tables["FBLn"].Rows[0]["T006"].ToString().Trim() == "MultipleCurrency")
                {
                    FBLnT001.Visible = true;
                    FBLnT002.Visible = true;
                    FBLnT003.Visible = true;
                    FBLnFacsimile02.Visible = true;
                    FBLnChrgAmt.ReadOnly = true;
                    multipleCurrency = true;
                }
                else
                {
                    FBLnT001.Visible = false;
                    FBLnT002.Visible = false;
                    FBLnT003.Visible = false;
                    FBLnFacsimile02.Visible = false;
                    FBLnChrgAmt.ReadOnly = false;
                    multipleCurrency = false;
                }
            }
            else
                multipleCurrency = false;

            grdFBLine.UpdateVisibleColumnCount();
        }

        private void enableToolStripButtons(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        toolStripButtonStartQA.Enabled = !isReviewStarted();
                        toolStripButtonContQA.Enabled = isReviewContAllowed() == true ? isReviewStarted() : false;
                        toolStripButtonQAPass.Enabled = false;
                        toolStripButtonRekey.Enabled = false;
                        toolStripButtonQAOnHold.Enabled = false;
                        toolStripButtonEdit.Enabled = false;
                        toolStripButtonSaveClose.Enabled = false;
                        toolStripButtonSave.Enabled = false;
                        toolStripButtonCancel.Enabled = false;
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        toolStripButtonStartQA.Enabled = false;
                        toolStripButtonContQA.Enabled = false;
                        toolStripButtonQAPass.Enabled = false;
                        toolStripButtonRekey.Enabled = false;
                        toolStripButtonQAOnHold.Enabled = false;
                        toolStripButtonEdit.Enabled = false;
                        toolStripButtonSaveClose.Enabled = true;
                        toolStripButtonSave.Enabled = true;
                        toolStripButtonCancel.Enabled = true;
                        break;
                    }
                case CommonEnum.FormState.OPEN_STATE:
                    {
                        toolStripButtonStartQA.Enabled = false;
                        toolStripButtonContQA.Enabled = false;
                        toolStripButtonQAPass.Enabled = true;
                        toolStripButtonRekey.Enabled = true;
                        toolStripButtonQAOnHold.Enabled = true;
                        toolStripButtonEdit.Enabled = true;
                        toolStripButtonSaveClose.Enabled = false;
                        toolStripButtonSave.Enabled = false;
                        toolStripButtonCancel.Enabled = false;
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
                        enableControls(false, grpBoxFbLine.Controls);
                        grpBoxInvoice.Visible = false;
                        grpBoxFreightBill.Visible = false;
                        grpBoxFbLine.Visible = false;
                        grpBoxTotal.Visible = false;
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        grpBoxImageGroup.Enabled = false;
                        enableControls(!singleFB, grpBoxInvoice.Controls);
                        enableControls(grdInvoice.Rows.Count > 0 ? true : false, grpBoxFreightBill.Controls);
                        enableControls(grdFreightBill.Rows.Count > 0 ? true : false, grpBoxFbLine.Controls);
                        enableControls(grdFBLine.Rows.Count > 0 ? true : false, grpBoxFbLine.Controls);
                        grpBoxInvoice.Visible = true;
                        grpBoxFreightBill.Visible = true;
                        grpBoxFbLine.Visible = true;
                        grpBoxTotal.Visible = true;
                        break;
                    }
                case CommonEnum.FormState.OPEN_STATE:
                    {
                        grpBoxImageGroup.Enabled = false;
                        enableControls(false, grpBoxInvoice.Controls);
                        enableControls(false, grpBoxFreightBill.Controls);
                        enableControls(false, grpBoxFbLine.Controls);
                        grpBoxInvoice.Visible = true;
                        grpBoxFreightBill.Visible = true;
                        grpBoxFbLine.Visible = true;
                        grpBoxTotal.Visible = true;
                        break;
                    }
            }
            this.InvoiceInvId.Visible = false;
            this.FBInvId.Visible = false;
            this.FBLnFbId.Visible = false;
        }

        private void enableControls(bool isEnable, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = isEnable;
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
            }
        }

        private void setReadOnlyGridColumns(TraxDEDataGridView grd)
        {
            foreach (DataGridViewColumn column in grd.Columns)
            {
                if (column is TraxDEDataGridViewTextBoxColumn)
                {
                    if (column.Name == "InvoiceInvAmt" ||
                        column.Name == "InvoiceVendLabl" ||
                        column.Name == "InvoiceLocIdRemit" ||
                        column.Name == "InvoiceLocIdRemit" ||
                        column.Name == "InvoiceAlRemit1" ||
                        column.Name == "InvoiceAlRemit2" ||
                        column.Name == "InvoiceAlRemit3" ||
                        column.Name == "InvoiceAlRemit4" ||
                        column.Name == "InvoiceAlCityRemit" ||
                        column.Name == "InvoiceAlStateProvRemit" ||
                        column.Name == "InvoiceAlPostCodeRemit" ||
                        column.Name == "InvoiceAlCntryCodeRemit" ||
                        column.Name == "InvoiceInvFbCnt" ||
                        column.Name == "FBVendLabl" ||
                        column.Name == "FBFbLnCnt" ||
                        column.Name == "FBLnChrgDesc" ||
                        column.Name == "FBLnLineItemNum")
                    {
                        column.ReadOnly = true;
                    }
                    if (multipleCurrency && column.Name == "FBLnChrgAmt")
                        column.ReadOnly = true;
                }
            }
        }

        private void updateCurrencyQual(string value)
        {
            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"] = value;
            foreach (DataRow rowInvoice in dsBatch.Tables["Invoice"].Rows)
                rowInvoice["InvCurrencyQual"] = value;
            foreach (DataRow rowFB in dsBatch.Tables["FB"].Rows)
                rowFB["FbCurrencyQual"] = value;
            foreach (DataRow rowFBLn in dsBatch.Tables["FBLn"].Rows)
            {
                rowFBLn["CurrencyQual"] = value;
                if (multipleCurrency)
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

        private void updateAcctNumVendBlng(string value, string InvID)
        {
            foreach (DataRow rowFB in dsBatch.Tables["FB"].Select(string.Format("InvId = '{0}'", InvID)))
                rowFB["AcctNumVendBlng"] = value;
            bindgrdFreightBill();
        }

        private void updateInvKey(string value, string InvID)
        {
            foreach (DataRow rowFB in dsBatch.Tables["FB"].Select(string.Format("InvId = '{0}'", InvID)))
                rowFB["InvKey"] = value;
            bindgrdFreightBill();
        }

        private void updateFBValues()
        {
            foreach (DataRow fbRow in dsBatch.Tables["FB"].Rows)
            {
                fbRow["FbFrghtAmt"] = 0;
                fbRow["FbAccAmt"] = 0;
                fbRow["FbDscntAmt"] = 0;
                fbRow["FbTaxAmt"] = 0;
                foreach (DataRow fbLnRow in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", fbRow["FbId"].ToString().Trim())))
                {
                    if (fbLnRow["Cat"].ToString().Trim() == "ACCESSORIAL")
                        fbRow["FbAccAmt"] = Convert.ToDecimal(fbRow["FbAccAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "FREIGHT")
                        fbRow["FbFrghtAmt"] = Convert.ToDecimal(fbRow["FbFrghtAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "DISCOUNT")
                        fbRow["FbDscntAmt"] = Convert.ToDecimal(fbRow["FbDscntAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "TAX")
                        fbRow["FbTaxAmt"] = Convert.ToDecimal(fbRow["FbTaxAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);
                }
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

        private void setTotal()
        {
            decimal invoiceOverAllTotal = 0;
            decimal FBOverAllTotal = 0;
            decimal FBLnOverAllTotal = 0;

            if (dsBatch != null && dsBatch.Tables.Count > 0)
            {
                foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                {
                    if (row["VendInvAmt"].ToString() != string.Empty)
                        invoiceOverAllTotal = invoiceOverAllTotal + Convert.ToDecimal(row["VendInvAmt"]);
                }

                foreach (DataRow row in dsBatch.Tables["FB"].Rows)
                {
                    if (row["FbAmt"].ToString() != string.Empty)
                        FBOverAllTotal = FBOverAllTotal + Convert.ToDecimal(row["FbAmt"]);
                }

                foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                {
                    if (row["ChrgAmt"].ToString() != string.Empty)
                        FBLnOverAllTotal = FBLnOverAllTotal + Convert.ToDecimal(row["ChrgAmt"]);
                }
                lblTotalInvoiceCountValue.Text = dsBatch.Tables["Invoice"].Rows.Count.ToString();
                lblTotalFBCountValue.Text = dsBatch.Tables["FB"].Rows.Count.ToString();
            }
            else
            {
                invoiceOverAllTotal = 0;
                FBOverAllTotal = 0;
                FBLnOverAllTotal = 0;
                lblTotalInvoiceCountValue.Text = "0";
                lblTotalFBCountValue.Text = "0";
            }


            if (invoiceOverAllTotal > 0)
                lblOInvoiceTotal.Text = invoiceOverAllTotal.ToString("###,###,###,###.#000");
            else
                lblOInvoiceTotal.Text = "0.0000";

            if (FBOverAllTotal > 0)
                lblOFBTotal.Text = FBOverAllTotal.ToString("###,###,###,###.#000");
            else
                lblOFBTotal.Text = "0.0000";

            if (FBLnOverAllTotal > 0)
                lblOFBLnTotal.Text = FBLnOverAllTotal.ToString("###,###,###,###.#000");
            else
                lblOFBLnTotal.Text = "0.0000";


            if (lblOInvoiceTotal.Text != lblOFBTotal.Text || lblOFBTotal.Text != lblOFBLnTotal.Text)
            {
                lblOInvoiceTotal.ForeColor = Color.Red;
                lblOFBTotal.ForeColor = Color.Red;
                lblOFBLnTotal.ForeColor = Color.Red;
            }
            else
            {
                lblOInvoiceTotal.ForeColor = Color.Black;
                lblOFBTotal.ForeColor = Color.Black;
                lblOFBLnTotal.ForeColor = Color.Black;
            }

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

        private bool isReviewStarted()
        {
            bool retval = false;
            if (this.grdImageGroup.SelectedRows.Count > 0)
                retval = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["QABy"].Value == null || grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["QABy"].Value.ToString().Trim() == "" ? false : true;
            return retval;
        }

        private bool isReviewContAllowed()
        {
            bool retval = false;
            if (this.grdImageGroup.Rows.Count > 0)
                retval = true;
            return retval;
        }

        private bool isQAPassAllowed()
        {
            bool retval = true;
            bool isDateValidated = true;
            string message = string.Empty;
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                if (row["InvKey"].ToString().Trim() == string.Empty)
                {
                    retval = false;
                    message = "There are some blank invoice key, please review this batch.";
                    break;
                }
                try
                {
                    if (row["InvCreatDtm"].ToString().Trim() != string.Empty)
                        if (Convert.ToDateTime(row["InvCreatDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["InvCreatDtm"].ToString().Trim()) > (bl.GetServerDate().AddDays(30)))
                            throw new Exception();
                }
                catch
                {
                    //retval = false;
                    //message = "There are some invalid date or date format, please review this batch.";
                    //break;
                    isDateValidated = false;
                }
            }
            if (retval)
            {
                foreach (DataRow row in dsBatch.Tables["FB"].Rows)
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
                        //retval = false;
                        //message = "There are some invalid date or date format, please review this batch.";
                        //break;
                        isDateValidated = false;
                    }
                }
            }
            if (multipleCurrency && retval)
            {
                foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                {
                    if (row["Facsimile01"].ToString().Trim() == string.Empty)
                    {
                        retval = false;
                        message = "There are some blank Line item description which would cause error, please review this batch.";
                        break;
                    }
                }
            }
            if (retval)
            {
                retval = isInvAmtEqualVendInvAmt();
                if (retval && !isDateValidated)
                {
                    if (MessageBox.Show("There are some invalid date or date format. Do you wish to proceed or review the invalid date values of this batch?", "Quality Validation", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    {
                        retval = false;                        
                    }
                }
            }
            else
                MessageBox.Show(message, "Quality Assurance");
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
                        MessageBox.Show("There are currency adjustments that exeeded the tolerance level.", "Data Entry");
                        break;
                    }
                }
            }
            return retval;
        }

        private bool isTotalMatch()
        {
            bool retval = false;
            retval = (lblOInvoiceTotal.Text == lblOFBTotal.Text && lblOFBTotal.Text == lblOFBLnTotal.Text) ? true : false;
            return retval;
        }

        private bool isInvAmtEqualVendInvAmt()
        {
            bool retval = false;
            try
            {
                foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                {
                    if (Convert.ToDecimal(row["InvAmt"]) == Convert.ToDecimal(row["VendInvAmt"]))
                        retval = true;
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                retval = false;
                MessageBox.Show("There are some VendInvAmt that does not match the InvAmt value, please review this batch.", "Quality Assurance");
            }
            return retval;
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

        private DataTable getInvoiceValidationTable()
        {
            DataTable retval = new DataTable("Invoice");
            retval.Columns.Add("InvId");
            retval.Columns.Add("InvKey");
            retval.Columns.Add("InvAmt");
            retval.Columns.Add("AcctNumVendBlng");
            retval.Columns.Add("InvCreatDtm");
            retval.Columns.Add("isCorrect");            
            DataRow newRow;
            
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                newRow = retval.NewRow();
                newRow["InvId"] = row["InvId"];
                newRow["InvKey"] = row["InvKey"];
                newRow["InvAmt"] = row["InvAmt"];
                newRow["AcctNumVendBlng"] = row["AcctNumVendBlng"];
                newRow["InvCreatDtm"] = row["InvCreatDtm"];                
                newRow["isCorrect"] = false;
                retval.Rows.Add(newRow);
            }
            return retval;
        }

        private DataTable getFBValidationTable()
        {
            DataTable retval = new DataTable("FB");
            retval.Columns.Add("FbId");
            retval.Columns.Add("FbKey");
            retval.Columns.Add("FbAmt");
            retval.Columns.Add("FbCreatDtm");
            retval.Columns.Add("FbPaymtTermsCode");
            retval.Columns.Add("isCorrect");
            DataRow newRow;
            
            foreach (DataRow row in dsBatch.Tables["FB"].Rows)
            {
                newRow = retval.NewRow();
                newRow["FbId"] = row["FbId"];
                newRow["FbKey"] = row["FbKey"];
                newRow["FbAmt"] = row["FbAmt"];
                newRow["FbCreatDtm"] = row["FbCreatDtm"];
                newRow["FbPaymtTermsCode"] = row["FbPaymtTermsCode"];                
                newRow["isCorrect"] = false;
                retval.Rows.Add(newRow);
            }
            return retval;
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
        #endregion
    }
}
