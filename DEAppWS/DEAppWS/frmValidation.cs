using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;

namespace DEAppWS
{
    public partial class frmValidation : Form
    {
        private QABL.QABL bl =  new QABL.QABL();
        private bool validation;
        private string currency;
        private string newCurrency;
        private string scac;
        private DataTable dtInvoice;
        private DataTable dtFB;
        private DataSet dsBatch = new DataSet();
        private DataView dvInvoice = new DataView();
        private DataView dvFreightBill = new DataView();
        private string mistakeDescription = string.Empty;
        private decimal invoiceAccuracy = 0;
        private decimal fbAccuracy = 0;
        private bool fbValidated = false;
        private bool defaultQA = false;
        private DataSet correctionSet = new DataSet();
        private bool isInvAmtValidated = false;
        private bool isAcctNumVendBlngValidated = false;
        private bool isInvCreatDtmValidated = false;
        private bool isFbAmtValidated = false;
        private bool isFbCreatDtmValidated = false;
        private bool isFbPaymtTermsCodeValidated = false;
        private bool isFirstTry = true;
        private bool isWrongSCAC = false;
        private bool isWrongCurrency = false;
        private bool isWrongCount = false;
        private bool isCancel = false;
        private bool isWrongInvoiceFB = false;
        private bool isRekey = false;
        private bool isDeactivation = false;
        private bool updateCurrency = false;
        private string batCtrlNum = string.Empty;
        private string ownerKey = string.Empty;        
        private string deOperator = string.Empty;
        public bool Validation
        { 
            get
            {
                return this.validation;
            }
        }

        public DataSet CorrectionSet
        {
            get
            {
                return this.correctionSet;
            }
        }

        public string MistakeDescription
        {
            get
            {
                return this.mistakeDescription;
            }
        }

        public string ValidatedCurrency
        {
            get
            {
                return this.newCurrency;
            }
        }

        public decimal InvoiceAccuracy
        {
            get
            {
                return this.invoiceAccuracy;
            }
        }

        public decimal FBAccuracy
        {
            get
            {
                return this.fbAccuracy;
            }
        }

        public bool isFBValidated
        {
            get
            {
                return this.fbValidated;
            }
        }

        public bool isValidationCancelled
        { 
            get
            {
                return this.isCancel;
            }
        }

        public bool isForRekey
        {
            get
            {
                return this.isRekey;
            }
        }

        public bool isForDeactivation
        {
            get
            {
                return this.isDeactivation;
            }
        }

        public bool isUpdateCurrency
        {
            get
            {
                return this.updateCurrency;
            }
        }
        public bool isWrongInvoiceFBKey
        {
            get
            {
                return this.isWrongInvoiceFB;
            }
        }
        public frmValidation()
        {
            validation = false;
            InitializeComponent();
        }

        public frmValidation(string Currency, string SCAC, DataTable Invoice, DataTable FB, DataTable QAConfig, bool isFullQAFB, string BatCtrlNum, string OwnerKey, string DEOperator)
        {
            mistakeDescription = string.Empty;
            validation = false;
            InitializeComponent();
            this.currency = Currency.ToUpper();
            this.dtInvoice = Invoice;
            this.dtFB = FB;
            this.scac = SCAC.ToUpper();
            this.batCtrlNum = BatCtrlNum;
            this.ownerKey = OwnerKey;            
            this.deOperator = DEOperator;
            defaultQA = QAConfig.Rows.Count > 0 ? false : true;
            grpBoxInvoice.Height = grpBoxInvoice.Height + grpBoxInvoiceOperator.Height + 5;
            grpBoxFB.Height = grpBoxFB.Height + grpBoxFBOperator.Height + 5;
            if (defaultQA)
            {
                isInvAmtValidated = true;                
                isInvCreatDtmValidated = true;                
                grpBoxFB.Visible = false;
                grdInvoice.Columns["InvoiceAcctNumVendBlng"].Visible = isAcctNumVendBlngValidated;
                grdInvoiceOperator.Columns["InvoiceAcctNumVendBlngOperator"].Visible = isAcctNumVendBlngValidated;
                grpBoxInvoice.Width = grpBoxInvoice.Width + grpBoxFB.Width + 5;
            }
            else
            {                
                isInvAmtValidated = Convert.ToBoolean(QAConfig.Rows[0]["InvAmt"]);
                isAcctNumVendBlngValidated = Convert.ToBoolean(QAConfig.Rows[0]["AcctNumVendBlng"]);
                isInvCreatDtmValidated = Convert.ToBoolean(QAConfig.Rows[0]["InvCreatDtm"]);
                isFbAmtValidated = (isFullQAFB == true ? Convert.ToBoolean(QAConfig.Rows[0]["FbAmt"]) : false);
                isFbCreatDtmValidated = (isFullQAFB == true ? Convert.ToBoolean(QAConfig.Rows[0]["FbCreatDtm"]) : false);
                isFbPaymtTermsCodeValidated = (isFullQAFB == true ? Convert.ToBoolean(QAConfig.Rows[0]["FbPaymtTermsCode"]) : false);
                if (!isFbAmtValidated && !isFbCreatDtmValidated && !isFbPaymtTermsCodeValidated)
                {
                    grpBoxFB.Visible = false;
                    grpBoxInvoice.Width = grpBoxInvoice.Width + grpBoxFB.Width + 5;
                    grdInvoice.Columns["InvoiceInvAmt"].Visible = isInvAmtValidated;
                    grdInvoice.Columns["InvoiceAcctNumVendBlng"].Visible = isAcctNumVendBlngValidated;
                    grdInvoice.Columns["InvoiceInvCreatDtm"].Visible = isInvCreatDtmValidated;

                    grdInvoiceOperator.Columns["InvoiceInvAmtOperator"].Visible = isInvAmtValidated;
                    grdInvoiceOperator.Columns["InvoiceAcctNumVendBlngOperator"].Visible = isAcctNumVendBlngValidated;
                    grdInvoiceOperator.Columns["InvoiceInvCreatDtmOperator"].Visible = isInvCreatDtmValidated;
                }
                else
                {
                    grpBoxFB.Visible = true;
                    grdInvoice.Columns["InvoiceInvAmt"].Visible = isInvAmtValidated;
                    grdInvoice.Columns["InvoiceAcctNumVendBlng"].Visible = isAcctNumVendBlngValidated;
                    grdInvoice.Columns["InvoiceInvCreatDtm"].Visible = isInvCreatDtmValidated;
                    grdInvoiceOperator.Columns["InvoiceInvAmtOperator"].Visible = isInvAmtValidated;
                    grdInvoiceOperator.Columns["InvoiceAcctNumVendBlngOperator"].Visible = isAcctNumVendBlngValidated;
                    grdInvoiceOperator.Columns["InvoiceInvCreatDtmOperator"].Visible = isInvCreatDtmValidated;

                    grdFreightBill.Columns["FBFbAmt"].Visible = isFbAmtValidated;
                    grdFreightBill.Columns["FBFbCreatDtm"].Visible = isFbCreatDtmValidated;
                    grdFreightBill.Columns["FBFbPaymtTermsCode"].Visible = isFbPaymtTermsCodeValidated;
                    grdFreightBillOperator.Columns["FBFbAmtOperator"].Visible = isFbAmtValidated;
                    grdFreightBillOperator.Columns["FBFbCreatDtmOperator"].Visible = isFbCreatDtmValidated;
                    grdFreightBillOperator.Columns["FBFbPaymtTermsCodeOperator"].Visible = isFbPaymtTermsCodeValidated;
                }
            }
        }

        #region events
        private void btnOK_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel validation?", "Quality Validation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                isCancel = true;
                this.Close();
            }
        }

        private void frmValidation_Load(object sender, EventArgs e)
        {
            setDataSet();
            bindgrdInvoice();
            DataView tempInvoice = new DataView();
            tempInvoice.Table = this.dtInvoice;
            tempInvoice.RowFilter = "isCorrect = true";
            DataRow row;
            foreach (DataRowView correctRecord in tempInvoice)
            {
                row = ((DataView)grdInvoice.DataSource).Table.NewRow();
                row["InvId"] = correctRecord["InvId"];
                row["InvKey"] = correctRecord["InvKey"];
                row["InvAmt"] = correctRecord["InvAmt"];
                row["AcctNumVendBlng"] = correctRecord["AcctNumVendBlng"];
                row["InvCreatDtm"] = Convert.ToDateTime(correctRecord["InvCreatDtm"]).ToShortDateString();
                row["isCorrect"] = true;                
                dsBatch.Tables["Invoice"].Rows.Add(row);
            }
            bindgrdInvoice();
            bindgrdFreightBill();
            DataView tempFB = new DataView();
            tempFB.Table = this.dtFB;
            tempFB.RowFilter = "isCorrect = true";
            DataRow rowFB;
            foreach (DataRowView correctRecord in tempFB)
            {
                rowFB = ((DataView)grdFreightBill.DataSource).Table.NewRow();
                rowFB["FbId"] = correctRecord["FbId"];
                rowFB["FbKey"] = correctRecord["FbKey"];
                rowFB["FbAmt"] = correctRecord["FbAmt"];                
                rowFB["FbCreatDtm"] = Convert.ToDateTime(correctRecord["FbCreatDtm"]).ToShortDateString();
                rowFB["FbPaymtTermsCode"] = correctRecord["FbPaymtTermsCode"];
                rowFB["isCorrect"] = true;
                dsBatch.Tables["FB"].Rows.Add(rowFB);
            }
            bindgrdFreightBill();
            enableButtons();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            DataRow row = ((DataView)grdInvoice.DataSource).Table.NewRow();
            row["InvAmt"] = 0;
            row["isCorrect"] = false;
            dsBatch.Tables["Invoice"].Rows.Add(row);
            bindgrdInvoice();
            enableButtons();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (grdInvoice.SelectedRows.Count > 0)
            {
                dsBatch.Tables["Invoice"].Rows.RemoveAt(grdInvoice.SelectedRows[0].Index);
                bindgrdInvoice();
                enableButtons();
            }
        }

        private void btnAddFB_Click(object sender, EventArgs e)
        {
            DataRow row = ((DataView)grdFreightBill.DataSource).Table.NewRow();
            row["FbAmt"] = 0;
            row["isCorrect"] = false;
            dsBatch.Tables["FB"].Rows.Add(row);
            bindgrdFreightBill();
            enableButtons();
        }

        private void btnDeleteFB_Click(object sender, EventArgs e)
        {
            if (grdFreightBill.SelectedRows.Count > 0)
            {
                dsBatch.Tables["FB"].Rows.RemoveAt(grdFreightBill.SelectedRows[0].Index);
                bindgrdFreightBill();
                enableButtons();
            }
                
        }

        private void grdInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string value = grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvAmt"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                {
                    if (Convert.ToDecimal(value) >= 0)
                        grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");

                    else
                        grdInvoice.Rows[e.RowIndex].Cells["InvoiceInvAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                }
            }
        }

        private void grdInvoiceOperator_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string value = grdInvoiceOperator.Rows[e.RowIndex].Cells["InvoiceInvAmtOperator"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                {
                    if (Convert.ToDecimal(value) >= 0)
                        grdInvoiceOperator.Rows[e.RowIndex].Cells["InvoiceInvAmtOperator"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");

                    else
                        grdInvoiceOperator.Rows[e.RowIndex].Cells["InvoiceInvAmtOperator"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                }
            }
        }

        private void grdFreightBill_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string value = grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                {
                    if (Convert.ToDecimal(value) >= 0)
                        grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");

                    else
                        grdFreightBill.Rows[e.RowIndex].Cells["FBFbAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                }
            }
        }

        private void grdFreightBillOperator_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string value = grdFreightBillOperator.Rows[e.RowIndex].Cells["FBFbAmtOperator"].Value.ToString().Trim();
                if (value != string.Empty && !value.Contains('.'))
                {
                    if (Convert.ToDecimal(value) >= 0)
                        grdFreightBillOperator.Rows[e.RowIndex].Cells["FBFbAmtOperator"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");

                    else
                        grdFreightBillOperator.Rows[e.RowIndex].Cells["FBFbAmtOperator"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                }
            }
        }

        private void frmValidation_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (!isCancel)
            {
                if (validateData())
                {
                    validation = true;
                    this.correctionSet.Tables.Add(dtInvoice.Copy());
                    this.correctionSet.Tables[0].AcceptChanges();
                    this.correctionSet.Tables.Add(dtFB.Copy());
                    this.correctionSet.Tables[1].AcceptChanges();
                }
                else if (isWrongSCAC)
                {
                    if (MessageBox.Show("Wrong SCAC. Do you wish to proceed and mark this as for deactivation?", "Quality Validation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        isDeactivation = true;
                    }
                    else
                    {
                        isWrongCurrency = false;                        
                        isWrongSCAC = false;
                        isWrongCount = false;
                        updateCurrency = false;
                        isWrongInvoiceFB = false;
                        e.Cancel = true;
                    }
                }
                else if (isWrongCount)
                {
                    if (MessageBox.Show("Wrong Invoice or Freight bill count. Do you wish to proceed and send back for re-key?", "Quality Validation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        isRekey = true;
                    }
                    else
                    {
                        isWrongCurrency = false;
                        isWrongSCAC = false;
                        isWrongCount = false;
                        updateCurrency = false;
                        isWrongInvoiceFB = false;
                        e.Cancel = true;
                    }
                }
                else
                {
                    //if (MessageBox.Show("Invoice or Freight bill values did not match. Do you wish to proceed and apply these values to the batch?", "Quality Validation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //{
                    //    
                    //}
                    if (isWrongCurrency)
                    {
                        if (MessageBox.Show("Wrong currency. Do you wish to proceed and update currency?", "Quality Validation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            object[] obj = CommonMethod.getCurrencyList();
                            if (obj.Contains(newCurrency))
                            {
                                updateCurrency = true;
                                this.correctionSet.Tables.Add(dtInvoice.Copy());
                                this.correctionSet.Tables[0].AcceptChanges();
                                this.correctionSet.Tables.Add(dtFB.Copy());
                                this.correctionSet.Tables[1].AcceptChanges();
                            }
                            else
                            {
                                MessageBox.Show("Currency is not valid.", "Quality Validation");
                            }
                        }
                        else
                        {
                            updateCurrency = false;
                        }
                    }
                    if (isWrongInvoiceFB)
                    {
                        MessageBox.Show("Invoice or Freight bill contents did not validate.", "Quality Validation");
                        isWrongCurrency = false;
                        isWrongSCAC = false;
                        isWrongCount = false;
                        e.Cancel = true;

                        DataView dvInv = new DataView();
                        dvInv.Table = dtInvoice;
                        dvInv.RowFilter = string.Format("isCorrect = false");
                        grdInvoiceOperator.DataSource = dvInv;
                        grdInvoiceOperator.Refresh();

                        DataView dvFB = new DataView();
                        dvFB.Table = dtFB;
                        dvFB.RowFilter = string.Format("isCorrect = false");
                        grdFreightBillOperator.DataSource = dvFB;
                        grdFreightBillOperator.Refresh();

                        if (isFirstTry)
                        {
                            isFirstTry = false;
                            grpBoxInvoice.Height = grpBoxInvoice.Height - grpBoxInvoiceOperator.Height - 5;
                            grpBoxFB.Height = grpBoxFB.Height - grpBoxFBOperator.Height - 5;
                            if (!fbValidated)
                            {
                                grpBoxInvoiceOperator.Width = grpBoxInvoiceOperator.Width + grpBoxFBOperator.Width + 5;
                            }
                            else
                                grpBoxFBOperator.Visible = true;
                            grpBoxInvoiceOperator.Visible = true;

                        }
                    }
                }
                bl.QAValidationInsert(this.batCtrlNum, this.ownerKey, this.scac, this.invoiceAccuracy, this.fbAccuracy, this.fbValidated, mistakeDescription, CommonUserLogin.getUser().UserInitials, deOperator);
                
            }
        }        
        #endregion

        #region Developer Designed method
        private bool validateData()
        {
            bool retval = true;
            this.mistakeDescription = string.Empty;
            DataView dvInv = new DataView();
            DataView dvFB = new DataView();

            dvInv.Table = dtInvoice;
            dvFB.Table = dtFB;
            #region InvoiceValidation
            if (dsBatch.Tables["Invoice"].Select("LEN(InvKey)>0").Count() != dtInvoice.Rows.Count)
            {                
                retval = false;
                this.mistakeDescription = "Invoice count did not match; ";
                isWrongCount = true;
            }
            
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {               
                dvInv.RowFilter = string.Format("InvKey = '{0}'", row["InvKey"].ToString().Trim());
                if (dvInv.Count == 0)
                {
                    retval = false;
                    if (!this.mistakeDescription.Contains("Missing invoice key"))
                        this.mistakeDescription = mistakeDescription + "Missing invoice key; ";

                    if (row["InvId"].ToString().Trim() != string.Empty)
                    {
                        dvInv.RowFilter = string.Format("InvId = '{0}'", row["InvId"].ToString().Trim());
                        dvInv[0]["isCorrect"] = false;
                    }
                    row["isCorrect"] = false;
                    row["InvId"] = string.Empty;
                }
                else
                {
                    foreach (DataRowView invoice in dvInv)
                    {
                        if (!Convert.ToBoolean(invoice["isCorrect"]))
                        {
                            if ((isInvAmtValidated && Convert.ToDecimal(invoice["InvAmt"]) != Convert.ToDecimal(row["InvAmt"])) ||
                                (isAcctNumVendBlngValidated && invoice["AcctNumVendBlng"].ToString().Trim() != row["AcctNumVendBlng"].ToString().Trim()) ||
                                (isInvCreatDtmValidated && (invoice["InvCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(invoice["InvCreatDtm"]).ToShortDateString()) != (row["InvCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["InvCreatDtm"]).ToShortDateString())))
                            {
                                //retval = false;
                                //if (!this.mistakeDescription.Contains("Wrong invoice details"))
                                //    this.mistakeDescription = mistakeDescription + "Wrong invoice details; ";
                            }
                            else
                            {
                                invoice["isCorrect"] = true;
                                row["isCorrect"] = true;
                                row["InvId"] = invoice["InvId"];
                            }
                        }
                        else
                        {
                            if (row["InvId"] == invoice["InvId"])
                            {
                                if ((isInvAmtValidated && Convert.ToDecimal(invoice["InvAmt"]) != Convert.ToDecimal(row["InvAmt"])) ||
                                    (isAcctNumVendBlngValidated && invoice["AcctNumVendBlng"].ToString().Trim() != row["AcctNumVendBlng"].ToString().Trim()) ||
                                    (isInvCreatDtmValidated && (invoice["InvCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(invoice["InvCreatDtm"]).ToShortDateString()) != (row["InvCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["InvCreatDtm"]).ToShortDateString())))
                                {
                                    //retval = false;
                                    invoice["isCorrect"] = false;
                                    row["isCorrect"] = false;
                                    row["InvId"] = string.Empty;
                                    //if (!this.mistakeDescription.Contains("Wrong invoice details"))
                                    //    this.mistakeDescription = mistakeDescription + "Wrong invoice details; ";
                                }
                            }
                        }
                    }
                }
            }
            
            dvInv.RowFilter = string.Format("isCorrect = false");
            if (dvInv.Count > 0)
            {
                retval = false;
                isWrongInvoiceFB = true;
                this.mistakeDescription = mistakeDescription + "Unaccounted invoice; ";
            }
            this.invoiceAccuracy = (Convert.ToDecimal(dtInvoice.Rows.Count - dvInv.Count) / Convert.ToDecimal(dtInvoice.Rows.Count)) * 100;
            #endregion
            #region FreightBillValidation
            if (!defaultQA && (isFbAmtValidated || isFbCreatDtmValidated || isFbPaymtTermsCodeValidated))
            {
                fbValidated = true;
                if (dsBatch.Tables["FB"].Select("LEN(FbKey)>0").Count() != dtFB.Rows.Count)
                {
                    retval = false;                    
                    this.mistakeDescription = mistakeDescription + "Freightbill count did not match; ";
                    isWrongCount = true;
                }

                foreach (DataRow row in dsBatch.Tables["FB"].Rows)
                {
                    dvFB.RowFilter = string.Format("FbKey = '{0}'", row["FbKey"].ToString().Trim());
                    if (dvFB.Count == 0)
                    {
                        retval = false;                        
                        if (!this.mistakeDescription.Contains("Missing freightbill key"))
                            this.mistakeDescription = mistakeDescription + "Missing freightbill key; ";
                        if (row["FbId"].ToString().Trim() != string.Empty)
                        {
                            dvFB.RowFilter = string.Format("FbId = '{0}'", row["FbId"].ToString().Trim());
                            dvFB[0]["isCorrect"] = false;
                        }
                        row["isCorrect"] = false;
                        row["FbId"] = string.Empty;
                    }
                    else
                    {
                        foreach (DataRowView fb in dvFB)
                        {
                            if (!Convert.ToBoolean(fb["isCorrect"]))
                            {
                                if ((isFbAmtValidated && Convert.ToDecimal(fb["FbAmt"]) != Convert.ToDecimal(row["FbAmt"])) ||
                                    (isFbCreatDtmValidated && (fb["FbCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(fb["FbCreatDtm"]).ToShortDateString()) != (row["FbCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["FbCreatDtm"]).ToShortDateString())) ||
                                    (isFbPaymtTermsCodeValidated && fb["FbPaymtTermsCode"].ToString().Trim() != row["FbPaymtTermsCode"].ToString().Trim()))
                                {
                                    //retval = false;
                                    //if (!this.mistakeDescription.Contains("Wrong freightbill details"))
                                    //    this.mistakeDescription = mistakeDescription + "Wrong freightbill details; ";
                                }
                                else
                                {
                                    fb["isCorrect"] = true;
                                    row["isCorrect"] = true;
                                    row["FbId"] = fb["FbId"];
                                }
                            }
                            else
                            {
                                if (row["FbId"] == fb["FbId"])
                                {
                                    if ((isFbAmtValidated && Convert.ToDecimal(fb["FbAmt"]) != Convert.ToDecimal(row["FbAmt"])) ||
                                       (isFbCreatDtmValidated && (fb["FbCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(fb["FbCreatDtm"]).ToShortDateString()) != (row["FbCreatDtm"] == DBNull.Value ? string.Empty : Convert.ToDateTime(row["FbCreatDtm"]).ToShortDateString())) ||
                                       (isFbPaymtTermsCodeValidated && fb["FbPaymtTermsCode"].ToString().Trim() != row["FbPaymtTermsCode"].ToString().Trim()))
                                    {
                                        //retval = false;
                                        fb["isCorrect"] = false;
                                        row["isCorrect"] = false;
                                        row["FbId"] = string.Empty;
                                        //if (!this.mistakeDescription.Contains("Wrong freightbill details"))
                                        //    this.mistakeDescription = mistakeDescription + "Wrong freightbill details; ";
                                    }
                                }
                            }
                        }
                    }
                }

                dvFB.RowFilter = string.Format("isCorrect = false");
                if (dvFB.Count > 0)
                {
                    retval = false;
                    isWrongInvoiceFB = true;
                    this.mistakeDescription = mistakeDescription + "Unaccounted freightbill; ";
                }
                this.fbAccuracy = (Convert.ToDecimal(dtFB.Rows.Count - dvFB.Count) / Convert.ToDecimal(dtFB.Rows.Count)) * 100;
            }
            else
            {
                fbValidated = false;
                foreach (DataRowView record in dvFB)
                {
                    record["isCorrect"] = true;
                }
            }
            #endregion
            if (this.scac != txtSCAC.Text.Trim())
            {
                isWrongSCAC = true;
                retval = false;
                this.mistakeDescription = mistakeDescription + "SCAC did not match; ";
            }
            if (this.currency!= txtCurrency.Text.Trim())
            {
                newCurrency = txtCurrency.Text.Trim();
                isWrongCurrency = true;
                retval = false;
                this.mistakeDescription = mistakeDescription + "Currency did not match; ";
            }
            return retval;
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
                //grdInvoice.SelectionChanged -= new EventHandler(grdInvoice_SelectionChanged);
                dvInvoice.Table = dsBatch.Tables["Invoice"];
                this.grdInvoice.DataSource = dvInvoice;                
                this.grdInvoice.Refresh();
                //grdInvoice.SelectionChanged += new EventHandler(grdInvoice_SelectionChanged);
            }
        }

        private void bindgrdFreightBill()
        {
            if (dsBatch == null)
            {
                if ((DataView)grdFreightBill.DataSource != null)
                {
                    if (dvFreightBill.Table != null)                    
                        dvFreightBill.Table.Rows.Clear();
                    grdFreightBill.DataSource = dvFreightBill;                    
                }
            }
            else
            {                
                dvFreightBill.Table = dsBatch.Tables["FB"];
                this.grdFreightBill.DataSource = dvFreightBill;
                this.grdInvoice.AutoResizeColumns();
                this.grdFreightBill.Refresh();                
            }
        }

        private void setDataSet()
        { 
            DataTable invoice = new DataTable("Invoice");
            invoice.Columns.Add("InvId");
            invoice.Columns.Add("InvKey");
            invoice.Columns.Add("InvAmt", typeof(decimal));
            invoice.Columns.Add("AcctNumVendBlng");
            invoice.Columns.Add("InvCreatDtm");
            invoice.Columns.Add("isCorrect");            
            dsBatch.Tables.Add(invoice);

            DataTable fb = new DataTable("FB");

            fb.Columns.Add("FbId");
            fb.Columns.Add("FbKey");
            fb.Columns.Add("FbAmt", typeof(decimal));
            fb.Columns.Add("FbCreatDtm", typeof(DateTime));
            fb.Columns.Add("FbPaymtTermsCode");
            fb.Columns.Add("isCorrect");
            dsBatch.Tables.Add(fb);
        }

        private void enableButtons()
        {
            if (grdFreightBill.Rows.Count > 0)            
                btnDeleteFB.Enabled = true;            
            else
                btnDeleteFB.Enabled = false;

            if (grdInvoice.Rows.Count > 0)
                btnDeleteInvoice.Enabled = true;
            else
                btnDeleteInvoice.Enabled = false;
        }
        #endregion               
    }
}
