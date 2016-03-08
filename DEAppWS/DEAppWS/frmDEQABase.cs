using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
//using BLogic;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmDEQABase : Form
    {
        public Form parentForm;
        private CommonEnum.FormView formView = CommonEnum.FormView.LIST_VIEW;
        private CommonEnum.FormMode formMode = CommonEnum.FormMode.DATA_ENTRY;
        private DataEntryQABL.DataEntryQABL bl;
        private CommonEnum.FormState currentFormState = CommonEnum.FormState.EDIT_STATE;
        private DataSet dsBatch = new DataSet();
        private DataSet dsBatchEphesoft = new DataSet();
        private DataSet dsKeyIdentifier = new DataSet();
        private DataSet dsShipperConsignee = new DataSet();
        private DataSet dsOwnerKeyAlphaNumeric = new DataSet();
        private DataSet dsOwnerKeyCustRef = new DataSet();
        private DataRow drVendorInfo;
        private DataView dvKeyIdentifier = new DataView();
        private DataView dvBatches = new DataView();
        private DataView dvInvoice = new DataView();
        private DataView dvFreightBill = new DataView();
        private DataView dvKeyIdents = new DataView();
        private DataView dvAddrs = new DataView();
        private DataView dvCntnrs = new DataView();
        private DataView dvProdDtl = new DataView();
        private DataView dvFBLine = new DataView();
        private DataView dvEphesoftInvoice = new DataView();
        private DataView dvEphesoftFreightBill = new DataView();

        private DataView dvEphesoftKeyIdents = new DataView();
        private DataView dvEphesoftAddrs = new DataView();
        private DataView dvEphesoftCntnrs = new DataView();
        private DataView dvEphesoftProdDtl = new DataView();
        private DataView dvEphesoftFBLine = new DataView();
        
        private DataTable dtError = new DataTable();
        private DataView dvError = new DataView();
        private BindingSource bsFBLn = new BindingSource();
        private BindingSource bsKeyIdents = new BindingSource();
        private BindingSource bsCntnrs = new BindingSource();
        private BindingSource bsProdDtl = new BindingSource();
        private string MXXDatabase = string.Empty;
        private string MXXOwnerKey = string.Empty;
        private string MXXSCAC = string.Empty;
        private string MXXOwnerCode = string.Empty;
        private bool isInvoiceKeyAlphaNumeric = false;

        private bool isAccountAlphaNumeric = false;
        private bool isTaxNumberAlphaNumeric = false;
        private bool isVatRegAlphaNumeric = false;

        private bool isFreightBillKeyAlphaNumeric = false;        
        private bool DeleteTriggered = false;        
        private int indexToCopy = -1;
        private decimal FBTotal;
        private decimal FBLnTotal;
        private DateTime dateStart = new DateTime();
        private string[] identifier;        
        string keystroke = string.Empty;
        bool singlePress = false;
        bool isFormLoad = true;
        private Control[] grpBoxInnerInvoice = new Control[28];
        private Control[] grpBoxFreightBill = new Control[88];
        private Control activeControl = new Control();
        private string guide = string.Empty;
        public frmDEQABase()
        {
            InitializeComponent();
            populateGroupBox();
        }

        public frmDEQABase(CommonEnum.FormMode mode, string batch, string ownerKey, string scac, string ownerCode, Form parent)
        {
            InitializeComponent();
            activeControl = null;
            populateGroupBox();
            this.parentForm = parent;
            this.WindowState = parentForm.WindowState;
            bl = new DataEntryQABL.DataEntryQABL();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            MXXDatabase = batch;
            MXXOwnerKey = ownerKey;
            MXXSCAC = scac;
            MXXOwnerCode = ownerCode;
            this.formMode = mode;
            if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
            {
                toolStripButtonSaveClose.Text = "On &Hold";
                toolStripButtonRestart.Text = "QA &Pass";
                toolStripButtonSendReview.Text = "Ch&eck";
                grdKeyIdents.IsQAForm = true;
                grdCntnrs.IsQAForm = true;
                grdProdDtl.IsQAForm = true;
                grdFBLine.IsQAForm = true;
                isQAControls(grpBoxInvoice.Controls);
                dsOwnerKeyAlphaNumeric = bl.selectAlphaNumericKey();
            }
            else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
            {
                toolStripButtonEdit.Visible = false;
                toolStripButtonSaveClose.Visible = false;
                toolStripButtonRestart.Visible = false;
                toolStripButtonCancel.Text = "E&nd";
                toolStripMenuGuidelines.Visible = false;
                btnGuide.Visible = false;
                setDefaultControls();
                dateStart = bl.GetServerDate();
                bl.deleteObject(MXXDatabase.Trim());
            }
            else if (formMode == CommonEnum.FormMode.DATA_ENTRY)
            {
                dsBatchEphesoft = bl.selectBatchEphesoftXML(MXXDatabase.Trim());
                dvEphesoftInvoice.Table = dsBatchEphesoft.Tables["Invoice"];
                dvEphesoftFreightBill.Table = dsBatchEphesoft.Tables["FrghtBl"];
                dvEphesoftKeyIdents.Table = dsBatchEphesoft.Tables["KeyIdents"];
                dvEphesoftAddrs.Table = dsBatchEphesoft.Tables["Addrs"];
                dvEphesoftCntnrs.Table = dsBatchEphesoft.Tables["Cntnrs"];
                dvEphesoftProdDtl.Table = dsBatchEphesoft.Tables["ProdDtl"];
                dvEphesoftFBLine.Table = dsBatchEphesoft.Tables["FBLn"];
                dsOwnerKeyAlphaNumeric = bl.selectAlphaNumericKey();
            }
            dsBatch = bl.selectBatchXML(MXXDatabase.Trim(), formMode);
            bindTree();            
            enableToolStripButtons(currentFormState);
            determineMultipleCurrencyMode();
            drVendorInfo = getVendorInfoStructure();            
            dsOwnerKeyCustRef = bl.selectCustRef();            
            dsKeyIdentifier = bl.selectKeyIdentifier();
            //dsShipperConsignee = bl.selectShipperConsignee();            
            dvKeyIdentifier.Table = dsKeyIdentifier.Tables[0];
            setAlphaNumeric();
            setIdentifier();
            this.txtInvCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList()); 
            this.ProdDtlProdUnitCurr.Items.AddRange(CommonMethod.getCurrencyList());
            this.ProdDtlProdTotalCurr.Items.AddRange(CommonMethod.getCurrencyList());
            this.FBLnLocalCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList());
            this.ddlSQCurrencyQual.Items.AddRange(CommonMethod.getCurrencyList());
            this.ddlSQCurrencyQual.Items.Add(string.Empty);
            setVendorInfo();
            dsBatch.Tables["KeyIdents"].TableNewRow += new DataTableNewRowEventHandler(grdKeyIdentsNewRow);
            dsBatch.Tables["Cntnrs"].TableNewRow += new DataTableNewRowEventHandler(grdCntnrsNewRow);
            dsBatch.Tables["ProdDtl"].TableNewRow += new DataTableNewRowEventHandler(grdProdDtlNewRow);
            dsBatch.Tables["FBLn"].TableNewRow += new DataTableNewRowEventHandler(grdFBLineNewRow);
            this.Text = formMode.ToString() + " - " + batch;            
        }

        public CommonEnum.FormState CurrentFormState
        {
            get
            {
                return this.currentFormState;
            }
        }

        public DataSet DSBatch
        {
            get
            {
                return this.dsBatch;
            }
            set
            {
                dsBatch = value;
            }
        }

        #region events
        #region others
        private void frmDEQABase_Load(object sender, EventArgs e)
        {                        
            if (currentFormState != CommonEnum.FormState.OPEN_STATE)
                this.updateQADataSet();
            if (formView == CommonEnum.FormView.LIST_VIEW)
                if (lstBoxSelection.Items.Count > 0)
                {
                    if (lstBoxSelection.SelectedItems.Count > 0 && lstBoxSelection.SelectedItems[0] == lstBoxSelection.Items[0])
                        lstBoxSelection.Items[0].Selected = false;
                    lstBoxSelection.Items[0].Selected = true;
                }
                else
                    lstBoxSelection_ItemSelectionChanged(null, null);
            else
                treeInvBat_AfterSelect(null, null);            
            isFormLoad = false;
        }

        private void frmDEQABase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || ((formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER || formMode == CommonEnum.FormMode.QUALITY_ASSURANCE )&& currentFormState == CommonEnum.FormState.OPEN_STATE))
            {
                MessageBox.Show("Cannot close in Edit or Open mode.", formMode.ToString());
                e.Cancel = true;
            }
            else
            {
                this.parentForm.Visible = true;                
            }
        }

        private void frmDEQABase_KeyDown(object sender, KeyEventArgs e)
        {
             if (currentFormState == CommonEnum.FormState.EDIT_STATE)
             {
                 if (e.Control == true)
                 {
                     if (this.activeControl == null)
                         activeControl = this.ActiveControl;
                     this.ActiveControl = null;
                     /*
                     if (e.KeyValue == 66)//Ctrl+B
                     {
                         if (toolStripMenuMultiCurr.Checked && grdFBLine.SelectedRows.Count > 0)
                         {
                             ArrayList content = new ArrayList();
                             content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnLocalCurrencyQual"].Value.ToString());//Currency1
                             //content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT005"].Value.ToString()); //Currency2
                             content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnCurrencyQual"].Value.ToString());//OutputCurrency
                             //content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnFacsimile02"].Value.ToString());//OriginalItem
                             content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnExchRate"].Value.ToString());//Exchange Rate 1
                             //content.Add(grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells["FBLnT004"].Value.ToString());//Exchange Rate 2
                             content.Add(grdFBLine.Rows.Count);//RowCount
                             content.Add(grdFBLine.SelectedRows[0].Index);//Selected LineItem
                             frmCurrencyBreakDown frmCurrencyBreakDown = new frmCurrencyBreakDown(content);

                             frmCurrencyBreakDown.ShowDialog();
                             if (frmCurrencyBreakDown.ComputedBreakdown)
                             {
                                 int index = 0;
                                 foreach (object lineItem in frmCurrencyBreakDown.LineItemRange)
                                 {
                                     index = Convert.ToInt16(lineItem) - 1;
                                     grdFBLine.Rows[index].Cells["FBLnExchRate"].Value = frmCurrencyBreakDown.ExchangeRateAmount1.ToString("###,###,###,###.#000000");
                                     grdFBLine.Rows[index].Cells["FBLnLocalCurrencyQual"].Value = frmCurrencyBreakDown.InitialCurrency;
                                     //grdFBLine.Rows[index].Cells["FBLnT004"].Value = frmCurrencyBreakDown.ExchangeRateAmount2.ToString();
                                     //grdFBLine.Rows[index].Cells["FBLnT005"].Value = frmCurrencyBreakDown.SecondaryCurrency;
                                     //grdFBLine.Rows[index].Cells["FBLnFacsimile02"].Value = frmCurrencyBreakDown.OriginalLineItem;
                                     if (grdFBLine.Rows[index].Cells["FBLnExchRate"].Value != DBNull.Value && grdFBLine.Rows[index].Cells["FBLnLocalAmt"].Value != DBNull.Value)
                                     {
                                         grdFBLine.Rows[index].Cells["FBLnExchRate"].Value = Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnExchRate"].Value).ToString("###,###,###,###.#000000");
                                         grdFBLine.Rows[index].Cells["FBLnChrgAmt"].Value = decimal.Round(Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnLocalAmt"].Value) * Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnExchRate"].Value), 2).ToString();// * Convert.ToDecimal(grdFBLine.Rows[index].Cells["FBLnT004"].Value), 2).ToString();
                                     }
                                     else
                                         grdFBLine.Rows[index].Cells["FBLnChrgAmt"].Value = "0.0000";
                                 }
                             }
                             //setFBLnTotal();
                             grdFBLine.Select();
                             grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.SelectedRows[0].Index].Cells[18];
                             setFBLnTotalLable();
                         }
                         this.activeControl = null;
                     }
                     else*/
                     if (e.KeyValue == 70)//Ctrl+F
                     {
                         if (btnFBAdd.Enabled)
                         {
                             btnFBAdd.Focus();
                             btnFBAdd_Click(null, null);
                         }
                         this.activeControl = null;
                     }
                     else if (e.KeyValue == 73)//Ctrl+I
                     {
                         if (btnInvoiceAdd.Enabled)
                         {
                             btnInvoiceAdd.Focus();
                             btnInvoiceAdd_Click(null, null);
                         }
                         this.activeControl = null;
                     }
                     else if (e.KeyValue == 69)//Ctrl+E
                     {

                         if (dvInvoice.Count == 0)//check needed to add invoice
                         {
                             btnInvoiceAdd_Click(null, null);
                         }
                         else
                         {
                             if (dvInvoice.Count > 0)
                             {
                                 int length = dvInvoice[0]["LocIdRemit"].ToString().Trim().Length;
                                 frmVendorInfo frmVendorInfo;
                                 if (dvInvoice[0]["LocIdRemit"] != DBNull.Value)
                                 {
                                     int remitId = Convert.ToInt32(dvInvoice[0]["LocIdRemit"].ToString().Trim().Substring(length - 5, 5));
                                     frmVendorInfo = new frmVendorInfo(MXXSCAC, remitId, getVendorInfoContent());
                                 }
                                 else
                                 {
                                     frmVendorInfo = new frmVendorInfo(MXXSCAC);
                                 }
                                 frmVendorInfo.ShowDialog();
                                 if (frmVendorInfo.VendorInfoSelected)
                                 {
                                     drVendorInfo = frmVendorInfo.VendorInfoRow;
                                     if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                         dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = drVendorInfo["LocIdRemit"];
                                     foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
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
                                     string[] txt = new string[4];
                                     txt[0] = dvInvoice[0]["AlRemit1"].ToString() + ",";
                                     txt[1] = dvInvoice[0]["AlRemit3"].ToString() + ",";
                                     txt[2] = dvInvoice[0]["AlCityRemit"].ToString() + ",";
                                     txt[3] = dvInvoice[0]["AlStateProvRemit"].ToString() + " " + dvInvoice[0]["AlPostCodeRemit"].ToString() + " " + dvInvoice[0]["AlCntryCodeRemit"].ToString();
                                     txtLocIdRemit.Lines = txt;

                                 }
                                 txtLocIdBlng.Focus();
                             }
                         }
                         this.activeControl = null;
                     }

                     else if (e.KeyValue == 84)//Ctrl+T
                     {
                         if (dvInvoice.Count == 0)//check needed to add invoice                    
                             btnInvoiceAdd_Click(null, null);
                         else
                         {
                             if (dvInvoice.Count > 0)
                             {
                                 frmBillToInfo frmBillToInfo = null;
                                 if (dvInvoice[0]["LocIdBlng"].ToString().Trim() != string.Empty)
                                 {
                                     int length = dvInvoice[0]["LocIdBlng"].ToString().Trim().Length;
                                     int billToId = Convert.ToInt32(dvInvoice[0]["LocIdBlng"].ToString().Trim().Substring(length - 5, 5));
                                     frmBillToInfo = new frmBillToInfo(MXXSCAC, billToId, getBillToContent());
                                 }
                                 else
                                 {
                                     frmBillToInfo = new frmBillToInfo(MXXSCAC);
                                 }
                                 frmBillToInfo.ShowDialog();
                                 if (frmBillToInfo.BillToInfoSelected)
                                 {
                                     dvInvoice[0].BeginEdit();
                                     dvInvoice[0]["LocIdBlng"] = frmBillToInfo.BillToRow["LocIdBlng"];
                                     dvInvoice[0]["AlBlng1"] = frmBillToInfo.BillToRow["AlBlng1"];
                                     dvInvoice[0]["AlBlng2"] = frmBillToInfo.BillToRow["AlBlng2"];
                                     dvInvoice[0]["AlBlng3"] = frmBillToInfo.BillToRow["AlBlng3"];
                                     dvInvoice[0]["AlBlng4"] = frmBillToInfo.BillToRow["AlBlng4"];
                                     dvInvoice[0]["AlCityBlng"] = frmBillToInfo.BillToRow["AlCityBlng"];
                                     dvInvoice[0]["AlStateProvBlng"] = frmBillToInfo.BillToRow["AlStateProvBlng"];
                                     dvInvoice[0]["AlPostCodeBlng"] = frmBillToInfo.BillToRow["AlPostCodeBlng"];
                                     dvInvoice[0]["AlCntryCodeBlng"] = frmBillToInfo.BillToRow["AlCntryCodeBlng"];
                                     dvInvoice[0].EndEdit();
                                     string[] txt = new string[4];
                                     txt[0] = dvInvoice[0]["AlBlng1"].ToString() + ",";
                                     txt[1] = dvInvoice[0]["AlBlng3"].ToString() + ",";
                                     txt[2] = dvInvoice[0]["AlCityBlng"].ToString() + ",";
                                     txt[3] = dvInvoice[0]["AlStateProvBlng"].ToString() + " " + dvInvoice[0]["AlPostCodeBlng"].ToString() + " " + dvInvoice[0]["AlCntryCodeBlng"].ToString();
                                     txtLocIdBlng.Lines = txt;
                                     foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"])))
                                     {
                                         row.BeginEdit();
                                         row["LocIdBlng"] = frmBillToInfo.BillToRow["LocIdBlng"];
                                         row.EndEdit();
                                     }
                                 }
                             }
                         }
                         this.activeControl = null;
                     }
                     else if (e.KeyValue == 79)//Ctrl+O
                     {
                         if(activeControl != null)
                             if (activeControl.Name == "txtShipperInv" || activeControl.Name == "txtShipperBOL" || activeControl.Name == "txtShipperCom" || activeControl.Name == "txtConsigneeInv" || activeControl.Name == "txtConsigneeBOL" || activeControl.Name == "txtConsigneeCom")
                             {
                                 DataView dvFBAddressRow = new DataView();
                                 string cat = string.Empty;
                                 dvFBAddressRow.Table = dsBatch.Tables["Addrs"];
                                 if (activeControl.Name == "txtShipperInv")
                                     cat = CommonEnum.AddressType.SHIPPER_INVOICE.ToString();
                                 else if (activeControl.Name == "txtShipperBOL")
                                     cat = CommonEnum.AddressType.SHIPPER_BOL.ToString();
                                 else if (activeControl.Name == "txtShipperCom")
                                     cat = CommonEnum.AddressType.SHIPPER_COM_INV.ToString();
                                 else if (activeControl.Name == "txtConsigneeInv")
                                     cat = CommonEnum.AddressType.CONSIGNEE_INVOICE.ToString();
                                 else if (activeControl.Name == "txtConsigneeBOL")
                                     cat = CommonEnum.AddressType.CONSIGNEE_BOL.ToString();
                                 else if (activeControl.Name == "txtConsigneeCom")
                                     cat = CommonEnum.AddressType.CONSIGNEE_COM_INV.ToString();

                                 dvFBAddressRow.RowFilter = string.Format("FbId = '{0}' AND AddrCat = '{1}'", this.dvFreightBill[0]["FbId"].ToString().Trim(), cat);
                                 if (dvFBAddressRow.Count > 0)
                                     indexToCopy = dsBatch.Tables["Addrs"].Rows.IndexOf(dvFBAddressRow[0].Row);
                                 else
                                     indexToCopy = -1;
                                 dvFBAddressRow.Dispose();
                             }
                         this.activeControl = null;
                     }
                     else if (e.KeyValue == 80)//Ctrl+P
                     {
                         int index = indexToCopy;
                         bool allowCopyUpdate = false;
                         if (index != -1 && activeControl != null)
                         {
                             if (activeControl.Name == "txtShipperInv" && dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString() == CommonEnum.AddressType.SHIPPER_INVOICE.ToString())
                                 allowCopyUpdate = true;
                             else if (activeControl.Name == "txtShipperBOL" && dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString() == CommonEnum.AddressType.SHIPPER_BOL.ToString())
                                 allowCopyUpdate = true;
                             else if (activeControl.Name == "txtShipperCom" && dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString() == CommonEnum.AddressType.SHIPPER_COM_INV.ToString())
                                 allowCopyUpdate = true;
                             else if (activeControl.Name == "txtConsigneeInv" && dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString() == CommonEnum.AddressType.CONSIGNEE_INVOICE.ToString())
                                 allowCopyUpdate = true;
                             else if (activeControl.Name == "txtConsigneeBOL" && dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString() == CommonEnum.AddressType.CONSIGNEE_BOL.ToString())
                                 allowCopyUpdate = true;
                             else if (activeControl.Name == "txtConsigneeCom" && dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString() == CommonEnum.AddressType.CONSIGNEE_COM_INV.ToString())
                                 allowCopyUpdate = true;
                             if (allowCopyUpdate)//add or update record
                             {
                                 DataRow dr = dsBatch.Tables["Addrs"].NewRow();
                                 DataView dvFBAddressRow = new DataView();
                                 try
                                 {
                                     dvFBAddressRow.Table = dsBatch.Tables["Addrs"];
                                     dvFBAddressRow.RowFilter = string.Format("FbId = '{0}' AND AddrCat = '{1}'", dvFreightBill[0]["FbId"].ToString(), dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString());

                                     if (dvFBAddressRow.Count > 0)//update if existing
                                     {
                                         dvFBAddressRow[0]["AlAddr1"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr1"].ToString();
                                         dvFBAddressRow[0]["AlAddr2"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr2"].ToString();
                                         dvFBAddressRow[0]["AlAddr3"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr3"].ToString();
                                         dvFBAddressRow[0]["AlAddr4"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr4"].ToString();
                                         dvFBAddressRow[0]["AlCityAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlCityAddr"].ToString();
                                         dvFBAddressRow[0]["AlStateProvAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlStateProvAddr"].ToString();
                                         dvFBAddressRow[0]["AlPostCodeAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlPostCodeAddr"].ToString();
                                         dvFBAddressRow[0]["AlCntryCodeAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlCntryCodeAddr"].ToString();
                                         dvFBAddressRow[0]["AlPortAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlPortAddr"].ToString();
                                     }
                                     else//add
                                     {
                                         dr["FbId"] = this.dvFreightBill[0]["FbId"].ToString().Trim();
                                         dr["AddrNum"] = 1;
                                         dr["AddrCat"] = dsBatch.Tables["Addrs"].Rows[index]["AddrCat"].ToString();
                                         dr["AlAddr1"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr1"].ToString();
                                         dr["AlAddr2"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr2"].ToString();
                                         dr["AlAddr3"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr3"].ToString();
                                         dr["AlAddr4"] = dsBatch.Tables["Addrs"].Rows[index]["AlAddr4"].ToString();
                                         dr["AlCityAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlCityAddr"].ToString();
                                         dr["AlStateProvAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlStateProvAddr"].ToString();
                                         dr["AlPostCodeAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlPostCodeAddr"].ToString();
                                         dr["AlCntryCodeAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlCntryCodeAddr"].ToString();
                                         dr["AlPortAddr"] = dsBatch.Tables["Addrs"].Rows[index]["AlPortAddr"].ToString();
                                         dsBatch.Tables["Addrs"].Rows.Add(dr);
                                     }
                                 }
                                 catch { }
                                 finally
                                 {
                                     dvFBAddressRow.Dispose();
                                 }
                                 bindAddress();
                             }
                         }
                         this.activeControl = null;
                     }
                     else if (e.KeyValue >= 48 && e.KeyValue <= 57)
                     {
                         if (singlePress)
                         {
                             keystroke = keystroke + char.ConvertFromUtf32(e.KeyValue);
                         }
                         else
                         {
                             singlePress = true;
                             keystroke = char.ConvertFromUtf32(e.KeyValue);
                         }
                         this.activeControl = null;
                     }

                     else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                     {
                         string num = string.Empty;
                         if (e.KeyCode == Keys.NumPad0)
                             num = "0";
                         else if (e.KeyCode == Keys.NumPad1)
                             num = "1";
                         else if (e.KeyCode == Keys.NumPad2)
                             num = "2";
                         else if (e.KeyCode == Keys.NumPad3)
                             num = "3";
                         else if (e.KeyCode == Keys.NumPad4)
                             num = "4";
                         else if (e.KeyCode == Keys.NumPad5)
                             num = "5";
                         else if (e.KeyCode == Keys.NumPad6)
                             num = "6";
                         else if (e.KeyCode == Keys.NumPad7)
                             num = "7";
                         else if (e.KeyCode == Keys.NumPad8)
                             num = "8";
                         else if (e.KeyCode == Keys.NumPad9)
                             num = "9";

                         if (singlePress)
                         {
                             keystroke = keystroke + num;
                         }
                         else
                         {
                             singlePress = true;
                             keystroke = num;
                         }
                         this.activeControl = null;
                     }                     
                 }
                 if (e.KeyValue == 38)
                 {
                     if (!ddlSQCurrencyQual.Focused && !txtInvCurrencyQual.Focused && !grdKeyIdents.Focused && !grdFBLine.Focused && !grdCntnrs.Focused && !grdProdDtl.Focused)
                     {
                         if (formView == CommonEnum.FormView.LIST_VIEW)
                         {
                             if (lstBoxSelection.SelectedItems.Count > 0)
                                 if (lstBoxSelection.SelectedIndices[0] > 0)
                                     lstBoxSelection.Items[lstBoxSelection.SelectedIndices[0] - 1].Selected = true;
                         }
                         else
                         {
                             if (!treeInvBat.Focused && treeInvBat.SelectedNode.PrevVisibleNode != null)
                                 treeInvBat.SelectedNode = treeInvBat.SelectedNode.PrevVisibleNode;
                         }
                     }
                 }
                 else if (e.KeyValue == 40)
                 {
                     if (!ddlSQCurrencyQual.Focused && !txtInvCurrencyQual.Focused && !grdKeyIdents.Focused && !grdFBLine.Focused && !grdCntnrs.Focused && !grdProdDtl.Focused)
                     {
                         if (formView == CommonEnum.FormView.LIST_VIEW)
                         {
                             if (lstBoxSelection.SelectedItems.Count > 0)
                                 if (lstBoxSelection.SelectedIndices[0] < lstBoxSelection.Items.Count - 1)
                                     lstBoxSelection.Items[lstBoxSelection.SelectedIndices[0] + 1].Selected = true;
                         }
                         else
                         {
                             if (!treeInvBat.Focused && treeInvBat.SelectedNode.NextVisibleNode != null)
                                 treeInvBat.SelectedNode = treeInvBat.SelectedNode.NextVisibleNode;
                         }
                     }
                 }                 
             }
        }

        private void frmDEQABase_KeyUp(object sender, KeyEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (e.KeyValue == 17)
                {
                    shortCutPress();
                    singlePress = false;
                    keystroke = string.Empty;
                }
                if (this.activeControl != null)
                {
                    this.ActiveControl = this.activeControl;
                    this.activeControl = null;
                }
            }
        }

        protected virtual void txt_InvTextChanged(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                try
                {
                    if (dvInvoice.Count > 0)
                    {
                        if (sender is TraxDETextBox)
                        {
                            if (((TraxDETextBox)sender).Text.Trim() == string.Empty)
                            {
                                if (dvInvoice[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Single" ||
                                    dvInvoice[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int32" ||
                                    dvInvoice[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int16" ||
                                    dvInvoice[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Decimal")
                                    dvInvoice[0][((TraxDETextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvInvoice[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();
                            }
                            else
                                dvInvoice[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();

                            if (((TraxDETextBox)sender).DatabaseFieldLink == "VendInvAmt")
                            {
                                dvInvoice[0]["InvAmt"] = ((TraxDETextBox)sender).Text.Trim();
                                setFBTotalLable();
                            }
                            
                        }
                        else if (sender is TraxDEMaskedTextBox)
                        {
                            if (((TraxDEMaskedTextBox)sender).ValueType == CommonEnum.MaskValueType.DATELONG)
                            {
                                if (((TraxDEMaskedTextBox)sender).Text == "  /  /       :")
                                    dvInvoice[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvInvoice[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy HH:mm}", ((TraxDEMaskedTextBox)sender).Text.Substring(((TraxDEMaskedTextBox)sender).Text.Length - 1, 1) == ":" ? ((TraxDEMaskedTextBox)sender).Text.Remove(((TraxDEMaskedTextBox)sender).Text.Length - 1, 1).Trim() : ((TraxDEMaskedTextBox)sender).Text));
                            }
                            else if (((TraxDEMaskedTextBox)sender).ValueType == CommonEnum.MaskValueType.DATESHORT)
                            {
                                if (((TraxDEMaskedTextBox)sender).Text == "  /  /")
                                    dvInvoice[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvInvoice[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", ((TraxDEMaskedTextBox)sender).Text));
                            }                            
                            else
                                dvInvoice[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = ((TraxDEMaskedTextBox)sender).Text.ToString();
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

        private void txt_FBTextChanged(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                try
                {
                    if (dvFreightBill.Count > 0)
                    {
                        if (sender is TraxDETextBox)
                        {
                            if (((TraxDETextBox)sender).Text.Trim() == string.Empty)
                            {
                                if (dvFreightBill[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Single" ||
                                    dvFreightBill[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int32" ||
                                    dvFreightBill[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int16" ||
                                    dvFreightBill[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Decimal")
                                    dvFreightBill[0][((TraxDETextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvFreightBill[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();
                            }
                            else
                            {       
                                dvFreightBill[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();
                            }
                            if (((TraxDETextBox)sender).DatabaseFieldLink == "FbAmt")
                            {
                                setFBTotalLable();
                                setFBLnTotalLable();
                            }
                        }
                        else if (sender is TraxDEMaskedTextBox)
                        {
                            if (((TraxDEMaskedTextBox)sender).ValueType == CommonEnum.MaskValueType.DATELONG)
                            {
                                if (((TraxDEMaskedTextBox)sender).Text == "  /  /       :")
                                    dvFreightBill[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvFreightBill[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy HH:mm}", ((TraxDEMaskedTextBox)sender).Text.Substring(((TraxDEMaskedTextBox)sender).Text.Length - 1, 1) == ":" ? ((TraxDEMaskedTextBox)sender).Text.Remove(((TraxDEMaskedTextBox)sender).Text.Length - 1, 1).Trim() : ((TraxDEMaskedTextBox)sender).Text));
                            }
                            else if (((TraxDEMaskedTextBox)sender).ValueType == CommonEnum.MaskValueType.DATESHORT)
                            {
                                if (((TraxDEMaskedTextBox)sender).Text == "  /  /")
                                    dvFreightBill[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvFreightBill[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", ((TraxDEMaskedTextBox)sender).Text));
                            }
                            else if (((TraxDEMaskedTextBox)sender).ValueType == CommonEnum.MaskValueType.DIMENSION)
                            {
                                if (((TraxDEMaskedTextBox)sender).Text == "    x    x")
                                    dvFreightBill[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = DBNull.Value;
                                else
                                    dvFreightBill[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = ((TraxDEMaskedTextBox)sender).Text.ToString();
                            }
                            else
                                dvFreightBill[0][((TraxDEMaskedTextBox)sender).DatabaseFieldLink] = ((TraxDEMaskedTextBox)sender).Text.ToString();
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

        private void txtInvKey_Validating(object sender, CancelEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (isInvoiceKeyAlphaNumeric)
                {
                    Regex regStr = new Regex("[^a-zA-Z0-9]");
                    txtInvKey.Text = regStr.Replace(txtInvKey.Text, string.Empty);
                }
                if (txtInvKey.Text.Trim() != string.Empty)
                {
                    if (!checkInvoiceKeyDuplicate(txtInvKey.Text, dvInvoice[0]["InvId"].ToString()))
                        e.Cancel = true;
                }                
            }
        }

        private void txtFbKey_Validating(object sender, CancelEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (isFreightBillKeyAlphaNumeric)
                {
                    Regex regStr = new Regex("[^a-zA-Z0-9]");
                    txtFbKey.Text = regStr.Replace(txtFbKey.Text, string.Empty);
                }
                if (txtFbKey.Text.Trim() != string.Empty)
                {
                    if(checkFBKeyDuplicate(txtFbKey.Text, dvFreightBill[0]["FbId"].ToString()))                        
                        enableLineItem(true);//enableControls(true, grpBoxFbLine.Controls);                    
                    else
                        e.Cancel = true;
                }
            }
        }

        protected virtual void txtInvKey_Validated(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if(dvInvoice != null && dvInvoice.Count>0)
                    updateInvKey(txtInvKey.Text, dvInvoice[0]["InvId"].ToString());
                if (toolStripMenuSingleFB.Checked)
                    txtFbKey.Text = txtInvKey.Text;
                int indexList = lstBoxSelection.SelectedItems.Count > 0 ? lstBoxSelection.SelectedItems[0].Index : -1;
                string selectedNode = (treeInvBat.SelectedNode != null && treeInvBat.SelectedNode.Tag != null) ? treeInvBat.SelectedNode.Tag.ToString() : string.Empty;
                bindTree();
                if(indexList>=0)
                    lstBoxSelection.Items[indexList].Selected = true;
                if (selectedNode != null && selectedNode != string.Empty)
                    treeInvBat.SelectedNode = treeInvBat.Nodes.Find(selectedNode, true)[0];
                else
                    treeInvBat.SelectedNode = treeInvBat.Nodes[0];
            }
        }

        private void txtFbKey_Validated(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE )
            {
                if (txtFbKey.Text.Trim() != string.Empty)
                    enableLineItem(true);//enableControls(true, grpBoxFbLine.Controls);
                int indexList = lstBoxSelection.SelectedItems.Count > 0 ? lstBoxSelection.SelectedItems[0].Index : -1;
                string selectedNode = (treeInvBat.SelectedNode != null && treeInvBat.SelectedNode.Tag != null) ? treeInvBat.SelectedNode.Tag.ToString() : string.Empty;                
                bindTree();                
                if (indexList >= 0)
                    lstBoxSelection.Items[indexList].Selected = true;
                if (selectedNode != null && selectedNode != string.Empty)
                    treeInvBat.SelectedNode = treeInvBat.Nodes.Find(selectedNode, true)[0];
                else
                    treeInvBat.SelectedNode = treeInvBat.Nodes[0];                
            }
        }

        protected virtual void txtVendInvAmt_Validated(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (toolStripMenuSingleFB.Checked)
                    txtFbAmt.Text = txtVendInvAmt.Text;
            }
        }       

        private void txtLocIdBlng_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                {
                    if (dvInvoice.Count == 0)//check needed to add invoice                    
                        btnInvoiceAdd_Click(null, null);
                    else
                    {
                        if (dvInvoice.Count > 0)
                        {                            
                            frmBillToInfo frmBillToInfo = null;
                            if (dvInvoice[0]["LocIdBlng"].ToString().Trim() != string.Empty)
                            {
                                int length = dvInvoice[0]["LocIdBlng"].ToString().Trim().Length;
                                int billToId = Convert.ToInt32(dvInvoice[0]["LocIdBlng"].ToString().Trim().Substring(length - 5, 5));
                                frmBillToInfo = new frmBillToInfo(MXXSCAC, billToId, getBillToContent());
                            }
                            else
                            {
                                frmBillToInfo = new frmBillToInfo(MXXSCAC);
                            }
                            frmBillToInfo.ShowDialog();
                            if (frmBillToInfo.BillToInfoSelected)
                            {                                
                                dvInvoice[0].BeginEdit();
                                dvInvoice[0]["LocIdBlng"] = frmBillToInfo.BillToRow["LocIdBlng"];
                                dvInvoice[0]["AlBlng1"] = frmBillToInfo.BillToRow["AlBlng1"];
                                dvInvoice[0]["AlBlng2"] = frmBillToInfo.BillToRow["AlBlng2"];
                                dvInvoice[0]["AlBlng3"] = frmBillToInfo.BillToRow["AlBlng3"];
                                dvInvoice[0]["AlBlng4"] = frmBillToInfo.BillToRow["AlBlng4"];
                                dvInvoice[0]["AlCityBlng"] = frmBillToInfo.BillToRow["AlCityBlng"];
                                dvInvoice[0]["AlStateProvBlng"] = frmBillToInfo.BillToRow["AlStateProvBlng"];
                                dvInvoice[0]["AlPostCodeBlng"] = frmBillToInfo.BillToRow["AlPostCodeBlng"];
                                dvInvoice[0]["AlCntryCodeBlng"] = frmBillToInfo.BillToRow["AlCntryCodeBlng"];
                                dvInvoice[0].EndEdit();
                                string[] txt = new string[4];
                                txt[0] = dvInvoice[0]["AlBlng1"].ToString() + ",";
                                txt[1] = dvInvoice[0]["AlBlng3"].ToString() + ",";
                                txt[2] = dvInvoice[0]["AlCityBlng"].ToString() + ",";
                                txt[3] = dvInvoice[0]["AlStateProvBlng"].ToString() + " " + dvInvoice[0]["AlPostCodeBlng"].ToString() + " " + dvInvoice[0]["AlCntryCodeBlng"].ToString();
                                txtLocIdBlng.Lines = txt;
                                foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"])))
                                {
                                    row.BeginEdit();
                                    row["LocIdBlng"] = frmBillToInfo.BillToRow["LocIdBlng"];
                                    row.EndEdit();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtLocIdRemit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                {
                    if (dvInvoice.Count == 0)//check needed to add invoice
                    {
                        btnInvoiceAdd_Click(null, null);
                    }
                    else
                    {
                        if (dvInvoice.Count > 0)
                            {
                            int length = dvInvoice[0]["LocIdRemit"].ToString().Trim().Length;
                            frmVendorInfo frmVendorInfo;
                            if (dvInvoice[0]["LocIdRemit"] != DBNull.Value)
                            {
                                int remitId = Convert.ToInt32(dvInvoice[0]["LocIdRemit"].ToString().Trim().Substring(length - 5, 5));
                                frmVendorInfo = new frmVendorInfo(MXXSCAC, remitId, getVendorInfoContent());
                            }
                            else
                            {
                                frmVendorInfo = new frmVendorInfo(MXXSCAC);
                            }
                            frmVendorInfo.ShowDialog();
                            if (frmVendorInfo.VendorInfoSelected)
                            {
                                drVendorInfo = frmVendorInfo.VendorInfoRow;
                                if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                                    dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = drVendorInfo["LocIdRemit"];
                                foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
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
                                string[] txt = new string[4];
                                txt[0] = dvInvoice[0]["AlRemit1"].ToString() + ",";
                                txt[1] = dvInvoice[0]["AlRemit3"].ToString() + ",";
                                txt[2] = dvInvoice[0]["AlCityRemit"].ToString() + ",";
                                txt[3] = dvInvoice[0]["AlStateProvRemit"].ToString() + " " + dvInvoice[0]["AlPostCodeRemit"].ToString() + " " + dvInvoice[0]["AlCntryCodeRemit"].ToString();
                                txtLocIdRemit.Lines = txt;                                
                            }                            
                        }
                    }
                    txtLocIdRemit.Focus();
                }
            }
        }

        private void txtPickUpAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered);
                    frmAddressInfo.ShowDialog();
                    DeleteTriggered = frmAddressInfo.DeleteTriggered;
                    bindAddress();
                }
            }
        }

        private void txtDeliveryAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered);
                    frmAddressInfo.ShowDialog();
                    DeleteTriggered = frmAddressInfo.DeleteTriggered;
                    bindAddress();
                }
            }
        }

        private void txtStopOffLoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered);
                    frmAddressInfo.ShowDialog();
                    DeleteTriggered = frmAddressInfo.DeleteTriggered;
                    bindAddress();
                }
            }
        }

        private void txtInvCurrencyQual_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isFormLoad)
            {
                if (toolStripMenuMultiCurr.Checked)
                {
                    if (MessageBox.Show("Your action will reset all amount in your multiple currency line items, proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        updateCurrencyQual(txtInvCurrencyQual.SelectedItem.ToString());
                }
                else
                    updateCurrencyQual(txtInvCurrencyQual.SelectedItem.ToString());
            }
        }

        private void ddlSQCurrencyQual_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                try
                {
                    if (dvFreightBill.Count > 0)
                    {
                        dvFreightBill[0]["FbSpotQuoteCurrencyQual"] = ddlSQCurrencyQual.SelectedItem.ToString();
                    }
                }
                catch
                { }
            }
        }

        protected virtual void btnInvoiceAdd_Click(object sender, EventArgs e)
        {
            string SCAC = MXXSCAC;
            string ownerKey = MXXOwnerKey.Remove(3, 1);
            string batchNumber = "MXX" + MXXDatabase;
            //if (guide == string.Empty && formMode != CommonEnum.FormMode.DATA_ENTRY_TRAINER)
            //{
            //    frmGuideView frmGuideView = new frmGuideView(MXXOwnerKey, MXXSCAC, true);
            //    frmGuideView.ShowDialog();
            //    this.guide = frmGuideView.Guide;
            //}
            if (drVendorInfo["LocIdRemit"].ToString().Trim() == string.Empty)//check if need to pick remit address. 
            {
                
                frmVendorInfo frmVendorInfo = new frmVendorInfo(SCAC);
                frmVendorInfo.ShowDialog();
                if (frmVendorInfo.VendorInfoSelected)
                {
                    drVendorInfo = frmVendorInfo.VendorInfoRow;
                }                
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
                DataRow row = dsBatch.Tables["Invoice"].NewRow();
                string invoiceCount = dsBatch.Tables["Invoice"].DefaultView.Count == 0 ? (1).ToString().PadLeft(4, '0') : (Convert.ToInt16(dsBatch.Tables["Invoice"].DefaultView[dsBatch.Tables["Invoice"].DefaultView.Count - 1]["InvId"].ToString().Substring(19, 4)) + 1).ToString().PadLeft(4, '0');
                row["BatId"] = dsBatch.Tables["InvBat"].Rows[0]["BatId"];
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
                    dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"] = "ZZZ";
                    row["InvCurrencyQual"] = dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"];
                }
                if (this.toolStripMenuSingleFB.Checked)
                    row["InvStat"] = "SingleBill";
                //row["VendName"] = this.guide;
                dsBatch.Tables["Invoice"].Rows.Add(row);
                bindTree();                
                lstBoxSelection.Items[lstBoxSelection.Items.IndexOfKey("INVC" + ownerKey + batchNumber + invoiceCount)].Selected = true;            
                treeInvBat.SelectedNode = treeInvBat.Nodes.Find("INVC" + ownerKey + batchNumber + invoiceCount, true)[0];
                btnFBAdd_Click(null, null);
                txtLocIdBlng.Focus();
            }
            toolStripButtonMode.Enabled = dvInvoice.Count > 0 ? false : true;            
            if (this.toolStripMenuInvoice.Checked && dvInvoice.Count > 0)
                autoSave();
        }

        protected virtual void btnInvoiceDelete_Click(object sender, EventArgs e)
        {            
            if (dvInvoice.Count>0)
            {
                if (MessageBox.Show("Are you sure you want to delete this invoice and all freight bills and line items under this invoice?", "Delete Invoice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"].ToString())))
                    {
                        deleteFBLn(row["FbId"].ToString());
                        deleteFB(row["FbId"].ToString());
                    }
                    deleteInvoice(dvInvoice[0]["InvId"].ToString());
                    
                    if (dsBatch.Tables["Invoice"].Rows.Count == 0)
                    {
                        dsBatch.Tables["InvBat"].Rows[0].Delete();
                        setVendorInfo();
                    }                    
                    DeleteTriggered = true;
                    bindTree();
                    if (dsBatch.Tables["Invoice"].Rows.Count==0)
                    {
                        if (formView == CommonEnum.FormView.LIST_VIEW)
                            lstBoxSelection_ItemSelectionChanged(null, null);
                        else
                            treeInvBat_AfterSelect(null, null);
                    }
                    setFBTotalLable();
                }
            }
        }

        private void btnFBAdd_Click(object sender, EventArgs e)
        {
            if (this.formView != CommonEnum.FormView.TREE_VIEW || this.treeInvBat.SelectedNode.Parent != null)//not root
            {
                DataRow row = dsBatch.Tables["FrghtBl"].NewRow();
                string ownerKey = MXXOwnerKey.Remove(3, 1);
                string batchNumber = "MXX" + MXXDatabase;
                string FBCount = dsBatch.Tables["FrghtBl"].DefaultView.Count == 0 ? (1).ToString().PadLeft(4, '0') : (Convert.ToInt16(dsBatch.Tables["FrghtBl"].DefaultView.Table.Select("", "FbId DESC")[0]["FbId"].ToString().Substring(19, 4)) + 1).ToString().PadLeft(4, '0');

                row["InvId"] = dvInvoice[0]["InvId"].ToString().Trim();
                row["InvKey"] = dvInvoice[0]["InvKey"].ToString().Trim();
                row["FbId"] = "FBLL" + ownerKey + batchNumber + FBCount;
                row["VendLabl"] = dvInvoice[0]["VendLabl"].ToString().Trim();
                row["AcctNumVendBlng"] = dvInvoice[0]["AcctNumVendBlng"].ToString().Trim();
                row["LocIdBlng"] = dvInvoice[0]["LocIdBlng"].ToString().Trim();
                row["FbAmt"] = 0;
                row["FbLnCnt"] = 0;
                if (dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"].ToString().Trim() != string.Empty)
                    row["FbCurrencyQual"] = dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"];
                dsBatch.Tables["FrghtBl"].Rows.Add(row);
                if (this.toolStripMenuFB.Checked && dvFreightBill.Count > 0)
                    autoSave();
                bindTree();
                lstBoxSelection.Items[lstBoxSelection.Items.IndexOfKey("FBLL" + ownerKey + batchNumber + FBCount)].Selected = true;                
                treeInvBat.SelectedNode = treeInvBat.Nodes.Find("FBLL" + ownerKey + batchNumber + FBCount, true)[0];
                //addGuide();
                txtFbKey.Focus();
            }
        }

        private void btnFBDelete_Click(object sender, EventArgs e)
        {
            if (dvFreightBill.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this freight bill and all the line items under this bill?", "Delete Freight Bill", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                    
                    deleteFBLn(dvFreightBill[0]["FbId"].ToString());
                    deleteFB(dvFreightBill[0]["FbId"].ToString());
                    setFBTotalLable();
                    setFBLnTotalLable();
                    DeleteTriggered = true;
                    bindTree();
                }
            }
        }
        
        private void toolStripMenuMultiCurr_CheckedChanged(object sender, EventArgs e)
        {
            if (toolStripMenuMultiCurr.Checked)
            {
                FBLnExchRate.Visible = true;
                FBLnLocalAmt.Visible = true;
                FBLnLocalCurrencyQual.Visible = true;
                //FBLnFacsimile02.Visible = true;
                //FBLnChrgAmt.ReadOnly = true;
                FBLnVendDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                FBLnTaxable.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!isFormLoad)
                {
                    foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            row["ExchRate"] = "1.0000000";
                            row["LocalAmt"] = Convert.ToDecimal(row["ChrgAmt"]).ToString("###,###,###,###.#000");
                            row["LocalCurrencyQual"] = row["CurrencyQual"];
                            //row["T004"] = "1.0000000";
                            //row["T005"] = row["CurrencyQual"];
                            row["T006"] = "MultipleCurrency";
                        }
                    }
                }
            }
            else
            {
                FBLnExchRate.Visible = false;
                FBLnLocalAmt.Visible = false;
                FBLnLocalCurrencyQual.Visible = false;
                //FBLnFacsimile02.Visible = false;
                //FBLnChrgAmt.ReadOnly = false;
                FBLnVendDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                FBLnTaxable.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                if (!isFormLoad)
                {
                    foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                    {
                        if (row.RowState != DataRowState.Deleted)
                        {
                            row["ExchRate"] = string.Empty;
                            row["LocalAmt"] = string.Empty;
                            row["LocalCurrencyQual"] = string.Empty;
                            //row["T004"] = string.Empty;
                            //row["T005"] = string.Empty;
                            row["T006"] = string.Empty;
                            //row["Facsimile02"] = string.Empty;
                        }
                    }
                }
            }
            grdFBLine.UpdateVisibleColumnCount();
            this.grdFBLine.AutoResizeColumns();
            this.grdFBLine.Refresh();
        }

        private void toolStripMenuGuidelines_Click(object sender, EventArgs e)
        {
            frmGuideView frmGuideView = new frmGuideView(MXXOwnerKey, MXXSCAC, false);
            frmGuideView.ShowDialog();
            if (frmGuideView.PickGuide)
            {
                if (MessageBox.Show("Do you wish to update the guide for the current invoice?", "Guide update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.guide = frmGuideView.Guide;
                    dvInvoice[0]["VendName"] = this.guide;
                    //if (dsBatch.Tables["KeyIdents"].Rows.Count > 0)
                    //    foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"])))
                    //    {
                    //        foreach (DataRow rowKey in dsBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}' and KeyQual = 'DEG'", row["FbId"].ToString())))
                    //        {
                    //            rowKey.BeginEdit();
                    //            rowKey["KeyVal"] = guide;
                    //            rowKey.EndEdit();
                    //        }
                    //    }
                }
            }
        }

        private void txtConsigneeInv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE);
                    frmAddressInfoSC.ShowDialog();
                    bindAddress();
                }
            }
        }

        private void txtConsigneeBOL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL);
                    frmAddressInfoSC.ShowDialog();
                    bindAddress();
                }
            }
        }

        private void txtConsigneeCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV);
                    frmAddressInfoSC.ShowDialog();
                    bindAddress();
                }
            }
        }

        private void txtShipperInv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE);
                    frmAddressInfoSC.ShowDialog();
                    bindAddress();
                }
            }
        }

        private void txtShipperBOL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL);
                    frmAddressInfoSC.ShowDialog();
                    bindAddress();
                }
            }
        }

        private void txtShipperCom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                {
                    frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV);
                    frmAddressInfoSC.ShowDialog();
                    bindAddress();
                }
            }
        }

        private void txtActualWt_Validated(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (txtFnclWt.Text.Trim() == string.Empty)
                    txtFnclWt.Text = txtActualWt.Text;
            }
        }

        private void txtFbWtQual_Validated(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (txtFbFnclWtQual.Text.Trim() == string.Empty)
                    txtFbFnclWtQual.Text = txtFbWtQual.Text;
            }
        }

        private void txtAcctNumVendBlng_Validated(object sender, EventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                updateAcctNumVendBlng(txtAcctNumVendBlng.Text.Trim());
            }
        }
        
        private void txtVendTaxKey_Validating(object sender, CancelEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (isTaxNumberAlphaNumeric)
                {
                    Regex regStr = new Regex("[^a-zA-Z0-9]");
                    txtVendTaxKey.Text = regStr.Replace(txtVendTaxKey.Text, string.Empty);
                }
            }
        }

        private void txtAcctNumVendBlng_Validating(object sender, CancelEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (isAccountAlphaNumeric)
                {
                    Regex regStr = new Regex("[^a-zA-Z0-9]");
                    txtAcctNumVendBlng.Text = regStr.Replace(txtAcctNumVendBlng.Text, string.Empty);
                }
            }
        }

        private void txtCustTaxKey_Validating(object sender, CancelEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (isVatRegAlphaNumeric)
                {
                    Regex regStr = new Regex("[^a-zA-Z0-9]");
                    txtCustTaxKey.Text = regStr.Replace(txtCustTaxKey.Text, string.Empty);
                }
            }
        }

        private void btnGuide_Click(object sender, EventArgs e)
        {
            frmGuideView frmGuideView = new frmGuideView(MXXOwnerKey, MXXSCAC, false);
            frmGuideView.ShowDialog();
            if (frmGuideView.PickGuide)
            {
                if (MessageBox.Show("Do you wish to update the guide for the current invoice?", "Guide update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.guide = frmGuideView.Guide;
                    dvInvoice[0]["VendName"] = this.guide;
                    //if (dsBatch.Tables["KeyIdents"].Rows.Count>0)
                    //    foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"])))
                    //    {
                    //        foreach (DataRow rowKey in dsBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}' and KeyQual = 'DEG'", row["FbId"].ToString())))
                    //        {
                    //            rowKey.BeginEdit();
                    //            rowKey["KeyVal"] = guide;
                    //            rowKey.EndEdit();
                    //        }
                    //    }
                }
            }
            
        }
        #endregion

        #region grid events
        private void grdFBLineNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE && !grdFBLine.ReadOnly)
            {
                if (dvFreightBill != null && dvFreightBill.Count > 0)
                {
                    e.Row["FbId"] = dvFreightBill[0]["FbId"];
                    e.Row["LineItemNum"] = grdFBLine.Rows.Count;

                    e.Row["RateType"] = "PER";
                    e.Row["ChrgAmt"] = 0.0000;
                    e.Row["CurrencyQual"] = txtInvCurrencyQual.SelectedItem.ToString();
                    if (toolStripMenuMultiCurr.Checked)
                    {
                        e.Row["ExchRate"] = "1.0000000";
                        e.Row["LocalAmt"] = Convert.ToDecimal(e.Row["ChrgAmt"]).ToString("###,###,###,###.#000");
                        e.Row["LocalCurrencyQual"] = e.Row["CurrencyQual"];
                        //e.Row["T004"] = "1.0000000";
                        //e.Row["T005"] = e.Row["CurrencyQual"];
                        e.Row["T006"] = "MultipleCurrency";
                    }
                }
            }
        }
        
        private void grdFBLine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 12)
                {
                    if (grdFBLine.Rows[e.RowIndex].Cells["FBLnLnRateAsWt"].Value.ToString().Trim() == string.Empty)
                        grdFBLine.Rows[e.RowIndex].Cells["FBLnLnRateAsWt"].Value = grdFBLine.Rows[e.RowIndex].Cells["FBLnLnActualWt"].Value.ToString();
                }

                if (e.ColumnIndex == 19)
                {
                    //string value = grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value.ToString().Trim();
                    //if (value != string.Empty && !value.Contains('.'))
                    //{
                    //    if (Convert.ToDecimal(value) >= 0)
                    //        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                    //    else
                    //        grdFBLine.Rows[e.RowIndex].Cells["FBLnChrgAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    //}
                    setFBLnTotalLable();
                }

                if (e.ColumnIndex == 21)
                {
                    //string value = grdFBLine.Rows[e.RowIndex].Cells["FBLnExchRate"].Value.ToString().Trim();
                    //if (value != string.Empty && !value.Contains('.'))
                    //{
                    //    if (Convert.ToDecimal(value) >= 0)
                    //        grdFBLine.Rows[e.RowIndex].Cells["FBLnExchRate"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                    //    else
                    //        grdFBLine.Rows[e.RowIndex].Cells["FBLnExchRate"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    //}
                    setFBLnTotalLable();
                }

                if (e.ColumnIndex == 22)
                {
                    //string value = grdFBLine.Rows[e.RowIndex].Cells["FBLnLocalAmt"].Value.ToString().Trim();
                    //if (value != string.Empty && !value.Contains('.'))
                    //{
                    //    if (Convert.ToDecimal(value) >= 0)
                    //        grdFBLine.Rows[e.RowIndex].Cells["FBLnLocalAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                    //    else
                    //        grdFBLine.Rows[e.RowIndex].Cells["FBLnLocalAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    //}                    
                    setFBLnTotalLable();
                }
                this.grdFBLine.AutoResizeColumns();
                this.grdFBLine.Refresh();
            }
            catch (System.FormatException error)
            {
                MessageBox.Show(error.Message, "Data Entry");
                grdFBLine.CurrentCell = grdFBLine.Rows[e.RowIndex].Cells[e.ColumnIndex];
                grdFBLine.CancelEdit();
            }
            finally
            {
                //dv[0].EndEdit();
            }            
        }

        private void grdFBLine_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this freight bill Line item?", "Delete Freight Bill Line Item", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
                if (grdFBLine.Rows.Count == 2)//one row left
                {
                    grdFBLine_UserDeletedRow(null, null);
                }
        }

        private void grdFBLine_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            setFBLnTotalLable();
            DeleteTriggered = true;
        }

        private void grdKeyIdents_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl te = (DataGridViewTextBoxEditingControl)e.Control;
                te.AutoCompleteMode = AutoCompleteMode.Append;
                te.AutoCompleteSource = AutoCompleteSource.CustomSource;
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 2)
                {
                    te.AutoCompleteCustomSource.AddRange(identifier);
                }
            }
        }

        private void grdKeyIdentsNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE && !grdKeyIdents.ReadOnly)
            {
                if (dvFreightBill != null && dvFreightBill.Count > 0)
                {
                    e.Row["FbId"] = dvFreightBill[0]["FbId"];
                    e.Row["KeyNum"] = grdKeyIdents.Rows.Count;
                }
            }
        }

        private void grdKeyIdents_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Key Identifier item?", "Delete Key Identifier Item", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
                if (grdKeyIdents.Rows.Count == 2)//one row left
                {
                    grdKeyIdents_UserDeletedRow(null, null);
                }
        }
        
        private void grdKeyIdents_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DeleteTriggered = true;            
        }

        private void grdCntnrs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Trailer/Container item?", "Delete Trailer/Container  Item", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
                if (grdCntnrs.Rows.Count == 2)//one row left
                {
                    grdCntnrs_UserDeletedRow(null, null);
                }
        }
                
        private void grdCntnrsNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE && !grdCntnrs.ReadOnly)
            {
                if (dvFreightBill != null && dvFreightBill.Count > 0)
                {
                    e.Row["FbId"] = dvFreightBill[0]["FbId"];
                    e.Row["CntnrNum"] = grdCntnrs.Rows.Count;
                }
            }
        }

        private void grdCntnrs_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DeleteTriggered = true;
        }

        private void grdProdDtlNewRow(object sender, DataTableNewRowEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE && !grdProdDtl.ReadOnly)
            {
                if (dvFreightBill != null && dvFreightBill.Count > 0)
                {
                    e.Row["FbId"] = dvFreightBill[0]["FbId"];
                    e.Row["ProdInstNum"] = grdProdDtl.Rows.Count;
                }
            }
        }
        
        private void grdProdDtl_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this product?", "Delete product Item", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
                if (grdProdDtl.Rows.Count == 2)//one row left
                {
                    grdProdDtl_UserDeletedRow(null, null);
                }
        }

        private void grdProdDtl_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            DeleteTriggered = true;
        }

        private void grdProdDtl_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    //string value = grdProdDtl.Rows[e.RowIndex].Cells["ProdDtlProdUnitAmt"].Value.ToString().Trim();
                    //if (value != string.Empty && !value.Contains('.'))
                    //{
                    //    if (Convert.ToDecimal(value) >= 0)
                    //        grdProdDtl.Rows[e.RowIndex].Cells["ProdDtlProdUnitAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                    //    else
                    //        grdProdDtl.Rows[e.RowIndex].Cells["ProdDtlProdUnitAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    //}
                }
                if (e.ColumnIndex == 8)
                {
                    //string value = grdProdDtl.Rows[e.RowIndex].Cells["ProdDtlProdTotalAmt"].Value.ToString().Trim();
                    //if (value != string.Empty && !value.Contains('.'))
                    //{
                    //    if (Convert.ToDecimal(value) >= 0)
                    //        grdProdDtl.Rows[e.RowIndex].Cells["ProdDtlProdTotalAmt"].Value = value.Length == 1 ? value.PadLeft(2, '0').Insert(0, ".") : value.Insert(value.Length - 2, ".");
                    //    else
                    //        grdProdDtl.Rows[e.RowIndex].Cells["ProdDtlProdTotalAmt"].Value = value.Length == 2 ? value.Insert(1, ".0") : value.Insert(value.Length - 2, ".");
                    //}
                }

                this.grdProdDtl.AutoResizeColumns();
                this.grdProdDtl.Refresh();
            }
            catch
            { }
        }

        #endregion

        #region toolStrip
        protected virtual void toolStripButtonSaveClose_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteTriggered)
                {
                    updateInvoiceID();
                    updateFBID();
                    updateFBLnLineNumber();
                    updateTempID();
                    DeleteTriggered = false;
                }
                updateCounter();
                if (MessageBox.Show(formMode == CommonEnum.FormMode.DATA_ENTRY ? "You sure to save and close?" : "All changes will be lost, do you wish to proceed?", formMode == CommonEnum.FormMode.DATA_ENTRY ? "Data Entry" : "Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //if (this.deleteTempFiles())
                    //{
                        if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                        {
                            if (bl.saveBatchXML(dsBatch, MXXDatabase, formMode))
                            {

                                bl.updateStatus(MXXDatabase, "IN DE");
                                bl.auditTrailBatch(MXXDatabase, "103", System.Environment.UserName);
                            }
                        }
                        else
                        {
                            
                            bl.updateStatus(MXXDatabase, "IN DE");
                            bl.auditTrailBatch(MXXDatabase, "103", System.Environment.UserName);
                        }
                        dsBatch = bl.selectBatchXML(MXXDatabase.Trim(), formMode);
                        dsBatch.Tables["KeyIdents"].TableNewRow += new DataTableNewRowEventHandler(grdKeyIdentsNewRow);
                        dsBatch.Tables["Cntnrs"].TableNewRow += new DataTableNewRowEventHandler(grdCntnrsNewRow);
                        dsBatch.Tables["ProdDtl"].TableNewRow += new DataTableNewRowEventHandler(grdProdDtlNewRow);
                        dsBatch.Tables["FBLn"].TableNewRow += new DataTableNewRowEventHandler(grdFBLineNewRow);
                        //bl.completeReview(MXXDatabase, MXXOwnerKey, dsBatch.Tables["Invoice"].Rows.Count, dsBatch.Tables["FrghtBl"].Rows.Count, dsBatch.Tables["FBLn"].Rows.Count, toolStripMenuMultiCurr.Checked, true);
                        MessageBox.Show(formMode == CommonEnum.FormMode.DATA_ENTRY ? "Saving successful." : "On Hold successful.", formMode == CommonEnum.FormMode.DATA_ENTRY ? "Data Entry" : "Quality Assurance");
                        currentFormState = CommonEnum.FormState.NORMAL_STATE;
                        this.Close();
                    //}
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        protected virtual void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DeleteTriggered)
                {
                    updateInvoiceID();
                    updateFBID();
                    updateFBLnLineNumber();
                    updateTempID();
                    DeleteTriggered = false;
                }
                updateCounter();
                if (bl.saveBatchXML(dsBatch, MXXDatabase, formMode))
                {                   
                    int selectedIndex = 0;
                    dsBatch = bl.selectBatchXML(MXXDatabase.Trim(), formMode);
                    dsBatch.Tables["KeyIdents"].TableNewRow += new DataTableNewRowEventHandler(grdKeyIdentsNewRow);
                    dsBatch.Tables["Cntnrs"].TableNewRow += new DataTableNewRowEventHandler(grdCntnrsNewRow);
                    dsBatch.Tables["ProdDtl"].TableNewRow += new DataTableNewRowEventHandler(grdProdDtlNewRow);
                    dsBatch.Tables["FBLn"].TableNewRow += new DataTableNewRowEventHandler(grdFBLineNewRow);
                    if (formView == CommonEnum.FormView.LIST_VIEW && lstBoxSelection.SelectedItems.Count > 0)
                        selectedIndex = lstBoxSelection.SelectedItems[0].Index;
                    bindTree();
                    if (formView == CommonEnum.FormView.LIST_VIEW)
                    {
                        if (lstBoxSelection.Items.Count > 0)
                            lstBoxSelection.Items[selectedIndex].Selected = true;
                    }
                    else
                        treeInvBat_AfterSelect(null, null);
                    MessageBox.Show("Saving successful.", "Data Entry");
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        protected virtual void toolStripButtonSendReview_Click(object sender, EventArgs e)
        {
            if (isAllowedSendForReview())
            {                
                isCurrencyAdjustmentAllowed();
                string message = formMode == CommonEnum.FormMode.DATA_ENTRY ? "Are you sure to send this batch for review?" : "Are you sure to check results?";
                if (MessageBox.Show(isTotalEqual() == true ? message : "The amount did not sum up correctly. Do you wish to proceed?", formMode == CommonEnum.FormMode.DATA_ENTRY ? "Data Entry" : "Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (DeleteTriggered)
                        {
                            updateInvoiceID();
                            updateFBID();
                            updateFBLnLineNumber();
                            updateTempID();
                            DeleteTriggered = false;
                        }
                        updateFBValues();
                        updateCounter();
                        if (bl.saveBatchXML(dsBatch, MXXDatabase, formMode))
                        {                            
                            if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                            {
                                //if (this.deleteTempFiles())
                                //{
                                    bl.saveShipperConsigneeInfo(dsBatch.Tables["FrghtBl"]);
                                    this.clearControls(grpBoxInvoice);
                                    bl.sendForReview(MXXDatabase);//update Batch_DE DE_FIN_DTM
                                    bl.auditTrailBatch(MXXDatabase, "106", System.Environment.UserName);
                                    MessageBox.Show("Batch successfully sent for review.", "Data Entry");
                                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                                    this.Close();
                                //}
                            }
                            else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                            {
                                if (dtError != null && dtError.Rows.Count > 0)
                                    dtError.Clear();
                                try
                                {
                                    dtError = bl.graphDiffQAXML(MXXDatabase, MXXOwnerKey, MXXSCAC, ConfigurationManager.AppSettings["SiteID"]);
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message, formMode.ToString());
                                }
                                dvError.Table = dtError;
                                currentFormState = CommonEnum.FormState.OPEN_STATE;
                                enableToolStripButtons(currentFormState);
                                if (dtError == null)
                                    MessageBox.Show("There was an error during checking.", "Quality Assurance");
                                else if (dtError != null && dtError.Rows.Count > 0)
                                {                                    
                                    //frmErrorList frmErrorList = new frmErrorList(dtError);
                                    //frmErrorList.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Validation is successful.", "Data Entry Trainer");
                                    
                                }
                                dsBatch = bl.selectBatchXML(MXXDatabase.Trim(), formMode);
                                if (formView == CommonEnum.FormView.LIST_VIEW)
                                    if (lstBoxSelection.Items.Count > 0)
                                    {
                                        if (lstBoxSelection.SelectedItems.Count > 0 && lstBoxSelection.SelectedItems[0] == lstBoxSelection.Items[0])
                                            lstBoxSelection.Items[0].Selected = false;
                                        lstBoxSelection.Items[0].Selected = true;
                                    }
                                    else
                                        lstBoxSelection_ItemSelectionChanged(null, null);
                                else
                                    treeInvBat_AfterSelect(null, null);                                    
                            }
                            else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
                            {
                                try
                                {
                                    dtError = bl.graphDiffTrainerXML(MXXDatabase, dateStart, ConfigurationManager.AppSettings["SiteID"]);
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message, formMode.ToString());
                                }
                                dvError.Table = dtError;
                                currentFormState = CommonEnum.FormState.OPEN_STATE;
                                enableToolStripButtons(currentFormState);
                                if (dtError == null)
                                    MessageBox.Show("There was an error during checking.", "Data Entry Trainer");

                                else if (dtError != null && dtError.Rows.Count > 0)
                                {                                    
                                    frmErrorList frmErrorList = new frmErrorList(dtError);
                                    frmErrorList.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Validation is successful.", "Data Entry Trainer");                                    
                                }
                                dsBatch = bl.selectBatchXML(MXXDatabase.Trim(), formMode);
                                if (formView == CommonEnum.FormView.LIST_VIEW)
                                    if (lstBoxSelection.Items.Count > 0)
                                    {
                                        if (lstBoxSelection.SelectedItems.Count > 0 && lstBoxSelection.SelectedItems[0] == lstBoxSelection.Items[0])
                                            lstBoxSelection.Items[0].Selected = false;
                                        lstBoxSelection.Items[0].Selected = true;
                                    }
                                    else
                                        lstBoxSelection_ItemSelectionChanged(null, null);
                                else
                                    treeInvBat_AfterSelect(null, null);
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        protected virtual void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(formMode != CommonEnum.FormMode.DATA_ENTRY_TRAINER ? "Are you sure to cancel all changes done?" : (currentFormState == CommonEnum.FormState.OPEN_STATE ? "Are you sure to end test?" : "This action will erase all information keyed and forces you to start all over again for this batch.\nAre you sure to cancel the test?"), "Cancel/End", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                    {
                        //if (this.deleteTempFiles())
                        //{
                            currentFormState = CommonEnum.FormState.NORMAL_STATE;
                            this.clearControls(grpBoxInvoice);
                            bl.updateStatus(MXXDatabase, "IN DE");
                            bl.auditTrailBatch(MXXDatabase, "104", System.Environment.UserName);
                            this.Close();
                        //}
                    }
                    else if(formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                    {
                        if(dtError != null)
                            dtError.Clear();                        
                        currentFormState = CommonEnum.FormState.EDIT_STATE;
                        enableToolStripButtons(currentFormState);
                    }
                    else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
                    {
                        currentFormState = CommonEnum.FormState.NORMAL_STATE;
                        if(bl.deleteObject(MXXDatabase))
                        {
                            //if (this.deleteTempFiles())
                                this.Close();
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        protected virtual void toolStripButtonRestart_Click(object sender, EventArgs e)
        {
            try
            {
                if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                {
                    if (MessageBox.Show("Are you sure to restart this batch?", "Batch Restart", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (deleteObject(MXXDatabase))
                        {
                            //if (this.deleteTempFiles())
                            //{
                                bl.updateStatus(MXXDatabase, "IN DE");
                                bl.auditTrailBatch(MXXDatabase, "105", System.Environment.UserName);
                                MessageBox.Show("Batch restarted successfully.", "Data Entry");
                                this.clearControls(grpBoxInvoice);
                                currentFormState = CommonEnum.FormState.NORMAL_STATE;
                                this.Close();
                            //}
                        }
                    }
                }
                else
                {
                    if (isQAPassAllowed())
                    {
                        isCurrencyAdjustmentAllowed();
                        if (MessageBox.Show(isTotalEqual() == true ? "QA pass batch will be moved to production." : "The amount did not sum up correctly. Do you wish to proceed?", "Quality Assurance", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (bl.completeReview(MXXDatabase, MXXOwnerKey, MXXOwnerCode, dsBatch.Tables["Invoice"].Rows.Count, dsBatch.Tables["FrghtBl"].Rows.Count, dsBatch.Tables["FBLn"].Rows.Count, toolStripMenuMultiCurr.Checked, true, CommonUserLogin.getUser().UserInitials))
                            {
                                bl.auditTrailBatch(MXXDatabase, "123", System.Environment.UserName);
                                currentFormState = CommonEnum.FormState.NORMAL_STATE;
                                MessageBox.Show("Batch successfully sent for production.", "Quality Assurance");
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected virtual void toolStripMenuSingleFB_CheckedChanged(object sender, EventArgs e)
        {
            if (formView == CommonEnum.FormView.LIST_VIEW)
                lstBoxSelection_ItemSelectionChanged(null, null);
            else
                treeInvBat_AfterSelect(null, null);

            txtFbAmt.ReadOnly = true;
            txtFbKey.ReadOnly = true;
        }

        protected virtual void toolStripMenuListView_CheckedChanged(object sender, EventArgs e)
        {
            this.toolStripMenuTreeView.Checked = !toolStripMenuListView.Checked;
            this.changeFormView();
        }

        protected virtual void toolStripMenuTreeView_CheckedChanged(object sender, EventArgs e)
        {
            this.toolStripMenuListView.Checked = !toolStripMenuTreeView.Checked;
            this.changeFormView();
        }
        #endregion

        #region navigation events
        private void treeInvBat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (formView == CommonEnum.FormView.TREE_VIEW)
            {
                if (this.treeInvBat.SelectedNode.Parent == null)
                {
                    this.dvInvoice.RowFilter = string.Format("InvId = '{0}'", string.Empty);
                    this.dvFreightBill.RowFilter = dvFreightBill.RowFilter = string.Format("FbId = '{0}'", string.Empty);
                    this.dvKeyIdents.RowFilter = string.Format("FbId = '{0}'", string.Empty);
                    this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", string.Empty);
                    
                    this.clearControls(grpBoxInvoice);
                    btnInvoiceDelete.Enabled = false;
                    btnFBAdd.Enabled = false;
                    btnFBDelete.Enabled = false;
                    if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                    {
                        btnInvoiceAdd.Enabled = true;
                        enableControls(false, grpBoxInvoice.Controls);
                        enableControls(false, grpBoxFreightBillX.Controls);
                        enableLineItem(false);//enableControls(false, grpBoxFbLine.Controls);
                    }
                    else
                    {
                        btnInvoiceAdd.Enabled = false;
                    }
                }
                else if (this.treeInvBat.SelectedNode.Parent.Parent == null)
                {                    
                    if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                    {
                        btnInvoiceAdd.Enabled = true;
                        btnInvoiceDelete.Enabled = true;
                        btnFBAdd.Enabled = toolStripMenuSingleFB.Checked ? false : true;
                        btnFBDelete.Enabled = false;
                        enableControls(true, grpBoxInvoice.Controls);
                        enableControls(false, grpBoxFreightBillX.Controls);
                        enableLineItem(false);//enableControls(false, grpBoxFbLine.Controls);
                    }
                    else
                    {
                        btnInvoiceAdd.Enabled = false;
                        btnInvoiceDelete.Enabled = false;
                        btnFBAdd.Enabled = false;
                        btnFBDelete.Enabled = false;
                    }
                    bindControls(true);
                }
                else
                {
                    bindControls(false);
                    if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                    {
                        btnInvoiceAdd.Enabled = true;
                        btnInvoiceDelete.Enabled = true;
                        btnFBAdd.Enabled = toolStripMenuSingleFB.Checked ? false : true;
                        btnFBDelete.Enabled = toolStripMenuSingleFB.Checked ? false : true;
                        enableControls(true, grpBoxInvoice.Controls);
                        enableControls(true, grpBoxFreightBillX.Controls);
                        enableLineItem(true);//enableControls(true, grpBoxFbLine.Controls);
                    }
                    else
                    {
                        btnInvoiceAdd.Enabled = false;
                        btnInvoiceDelete.Enabled = false;
                        btnFBAdd.Enabled = false;
                        btnFBDelete.Enabled = false;
                    }
                }
                //setGuide();
            }
        }

        private void lstBoxSelection_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (formView == CommonEnum.FormView.LIST_VIEW)
            {                
                if (e != null)
                {
                    if (!e.IsSelected)
                    {                        
                        this.BeginInvoke(new ListViewItemSelectionChangedEventHandler(FixupSelection), new object[] { sender, e });
                    }
                    bindControls(e.Item);
                    enableControls(currentFormState == CommonEnum.FormState.EDIT_STATE, grpBoxInvoice.Controls);
                    enableControls(dvFreightBill.Count > 0 ? currentFormState == CommonEnum.FormState.EDIT_STATE : false, grpBoxFreightBillX.Controls);
                    enableLineItem(dvFreightBill.Count > 0 ? currentFormState == CommonEnum.FormState.EDIT_STATE : false);//enableControls(dvFreightBill.Count > 0 ? currentFormState == CommonEnum.FormState.EDIT_STATE : false, grpBoxFbLine.Controls);                    
                }
                else
                {
                    this.clearControls(grpBoxInvoice);
                    enableControls(false, grpBoxInvoice.Controls);
                    enableControls(false, grpBoxFreightBillX.Controls);
                    enableLineItem(false);//enableControls(false, grpBoxFbLine.Controls);
                }
                if (currentFormState == CommonEnum.FormState.EDIT_STATE)
                {
                    btnInvoiceAdd.Enabled = true;
                    if (e != null && e.Item != null)
                    {
                        btnFBAdd.Enabled = toolStripMenuSingleFB.Checked ? false : true;
                        if (dvInvoice.Count > 0)
                            btnFBDelete.Enabled = dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"].ToString())).Count() > 1 ? (toolStripMenuSingleFB.Checked ? false : true) : false;
                        else
                            btnFBDelete.Enabled = toolStripMenuSingleFB.Checked ? false : true;
                        btnInvoiceDelete.Enabled = true;
                    }
                    else
                    {
                        btnFBAdd.Enabled = false;
                        btnFBDelete.Enabled = false;
                        btnInvoiceDelete.Enabled = false;
                    }
                }                
            }
        }

        private void FixupSelection(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            this.lstBoxSelection.ItemSelectionChanged -= new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstBoxSelection_ItemSelectionChanged);
            if (lstBoxSelection.SelectedItems.Count == 0)
            {
                e.Item.Selected = true;
                lstBoxSelection.FocusedItem = e.Item;
            }
            this.lstBoxSelection.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstBoxSelection_ItemSelectionChanged);
        }
        #endregion
        #endregion

        #region Developer Designed method
        private void autoSave()
        {
            try
            {
                if (DeleteTriggered)
                {
                    updateInvoiceID();
                    updateFBID();
                    updateFBLnLineNumber();
                    updateTempID();
                    DeleteTriggered = false;
                }

                bl.saveBatchXML(dsBatch, MXXDatabase, formMode);
                dsBatch = bl.selectBatchXML(MXXDatabase.Trim(), formMode);
                dsBatch.Tables["KeyIdents"].TableNewRow += new DataTableNewRowEventHandler(grdKeyIdentsNewRow);
                dsBatch.Tables["Cntnrs"].TableNewRow += new DataTableNewRowEventHandler(grdCntnrsNewRow);
                dsBatch.Tables["ProdDtl"].TableNewRow += new DataTableNewRowEventHandler(grdProdDtlNewRow);
                dsBatch.Tables["FBLn"].TableNewRow += new DataTableNewRowEventHandler(grdFBLineNewRow);
                if (formView == CommonEnum.FormView.LIST_VIEW)
                    if (lstBoxSelection.Items.Count > 0)
                    {
                        if (lstBoxSelection.SelectedItems.Count > 0 && lstBoxSelection.SelectedItems[0] == lstBoxSelection.Items[0])
                            lstBoxSelection.Items[0].Selected = false;
                        lstBoxSelection.Items[0].Selected = true;
                    }
                    else
                        lstBoxSelection_ItemSelectionChanged(null, null);
                else
                    treeInvBat_AfterSelect(null, null);         
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindAddress()
        {
            string[] PickUpAddressTxt;
            string[] DeliveryAddressTxt;
            string[] StopOffAddressTxt;
            string[] txt = new string[4];
            DataView dvAddressTemp = new DataView();
            dvAddressTemp.Table = dsBatch.Tables["Addrs"];
            //Pickup Address
            
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.PICKUP.ToString());            
            PickUpAddressTxt = new string[dvAddressTemp.Count];
            for (int ctr = 0; ctr < dvAddressTemp.Count; ctr++)
            {
                PickUpAddressTxt[ctr] = dvAddressTemp[ctr]["AlAddr1"].ToString() + "; " + dvAddressTemp[ctr]["AlAddr3"].ToString() + "; " + dvAddressTemp[ctr]["AlCityAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlStateProvAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlPostCodeAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlCntryCodeAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlPortAddr"].ToString();
            }
            txtPickUpAdd.Lines = PickUpAddressTxt;

            //Delivery Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.DELIVERY.ToString());            
            DeliveryAddressTxt = new string[dvAddressTemp.Count];
            for (int ctr = 0; ctr < dvAddressTemp.Count; ctr++)
            {
                DeliveryAddressTxt[ctr] = dvAddressTemp[ctr]["AlAddr1"].ToString() + "; " + dvAddressTemp[ctr]["AlAddr3"].ToString() + "; " + dvAddressTemp[ctr]["AlCityAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlStateProvAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlPostCodeAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlCntryCodeAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlPortAddr"].ToString();
            }            
            txtDeliveryAdd.Lines = DeliveryAddressTxt;
            //StopOff Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.STOP_OFF.ToString());
            StopOffAddressTxt = new string[dvAddressTemp.Count];
            for (int ctr = 0; ctr < dvAddressTemp.Count; ctr++)
            {
                StopOffAddressTxt[ctr] = dvAddressTemp[ctr]["AlAddr1"].ToString() + "; " + dvAddressTemp[ctr]["AlAddr3"].ToString() + "; " + dvAddressTemp[ctr]["AlCityAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlStateProvAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlPostCodeAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlCntryCodeAddr"].ToString() + "; " + dvAddressTemp[ctr]["AlPortAddr"].ToString();
            }            
            txtStopOffLoc.Lines = StopOffAddressTxt;


            //Shipper Invoice Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.SHIPPER_INVOICE.ToString());
            if (dvAddressTemp.Count > 0)
            {
                txt[0] = dvAddressTemp[0]["AlAddr1"].ToString();
                txt[1] = dvAddressTemp[0]["AlAddr3"].ToString();
                txt[2] = dvAddressTemp[0]["AlCityAddr"].ToString();
                txt[3] = dvAddressTemp[0]["AlStateProvAddr"].ToString() + " " + dvAddressTemp[0]["AlPostCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlCntryCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlPortAddr"].ToString();
                txtShipperInv.Lines = txt;
            }
            else
                txtShipperInv.Text = string.Empty;

            //Shipper BOL Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.SHIPPER_BOL.ToString());
            if (dvAddressTemp.Count > 0)
            {
                txt[0] = dvAddressTemp[0]["AlAddr1"].ToString();
                txt[1] = dvAddressTemp[0]["AlAddr3"].ToString();
                txt[2] = dvAddressTemp[0]["AlCityAddr"].ToString();
                txt[3] = dvAddressTemp[0]["AlStateProvAddr"].ToString() + " " + dvAddressTemp[0]["AlPostCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlCntryCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlPortAddr"].ToString();
                txtShipperBOL.Lines = txt;
            }
            else
                txtShipperBOL.Text = string.Empty;

            //Shipper Com Inv Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.SHIPPER_COM_INV.ToString());
            if (dvAddressTemp.Count > 0)
            {
                txt[0] = dvAddressTemp[0]["AlAddr1"].ToString();
                txt[1] = dvAddressTemp[0]["AlAddr3"].ToString();
                txt[2] = dvAddressTemp[0]["AlCityAddr"].ToString();
                txt[3] = dvAddressTemp[0]["AlStateProvAddr"].ToString() + " " + dvAddressTemp[0]["AlPostCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlCntryCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlPortAddr"].ToString();
                txtShipperCom.Lines = txt;
            }
            else
                txtShipperCom.Text = string.Empty;


            //Consignee Invoice Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.CONSIGNEE_INVOICE.ToString());
            if (dvAddressTemp.Count > 0)
            {
                txt[0] = dvAddressTemp[0]["AlAddr1"].ToString();
                txt[1] = dvAddressTemp[0]["AlAddr3"].ToString();
                txt[2] = dvAddressTemp[0]["AlCityAddr"].ToString();
                txt[3] = dvAddressTemp[0]["AlStateProvAddr"].ToString() + " " + dvAddressTemp[0]["AlPostCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlCntryCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlPortAddr"].ToString();
                txtConsigneeInv.Lines = txt;
            }
            else
                txtConsigneeInv.Text = string.Empty;

            //Consignee BOL Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.CONSIGNEE_BOL.ToString());
            if (dvAddressTemp.Count > 0)
            {
                txt[0] = dvAddressTemp[0]["AlAddr1"].ToString();
                txt[1] = dvAddressTemp[0]["AlAddr3"].ToString();
                txt[2] = dvAddressTemp[0]["AlCityAddr"].ToString();
                txt[3] = dvAddressTemp[0]["AlStateProvAddr"].ToString() + " " + dvAddressTemp[0]["AlPostCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlCntryCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlPortAddr"].ToString();
                txtConsigneeBOL.Lines = txt;
            }
            else
                txtConsigneeBOL.Text = string.Empty;

            //Consignee Com Inv Address
            dvAddressTemp.RowFilter = this.dvKeyIdents.RowFilter + string.Format(" AND AddrCat = '{0}'", CommonEnum.AddressType.CONSIGNEE_COM_INV.ToString());
            if (dvAddressTemp.Count > 0)
            {
                txt[0] = dvAddressTemp[0]["AlAddr1"].ToString();
                txt[1] = dvAddressTemp[0]["AlAddr3"].ToString();
                txt[2] = dvAddressTemp[0]["AlCityAddr"].ToString();
                txt[3] = dvAddressTemp[0]["AlStateProvAddr"].ToString() + " " + dvAddressTemp[0]["AlPostCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlCntryCodeAddr"].ToString() + " " + dvAddressTemp[0]["AlPortAddr"].ToString();
                txtConsigneeCom.Lines = txt;
            }
            else
                txtConsigneeCom.Text = string.Empty;

        }

        private void bindControls(bool isInvoiceSelected)
        {
            if (dsBatch == null)
            {
                clearControls(grpBoxInvoice);
                if ((DataView)grdFBLine.DataSource != null)
                {
                    if (dvFBLine.Table != null)
                        dvFBLine.Table.Rows.Clear();
                    grdFBLine.DataSource = dvFBLine;
                }
            }
            else
            {
                //invoice controls
                this.dvInvoice.Table = dsBatch.Tables["Invoice"];
                this.dvInvoice.RowFilter = string.Format("InvId = '{0}'", isInvoiceSelected ? this.treeInvBat.SelectedNode.Tag : this.treeInvBat.SelectedNode.Parent.Tag);
                setFBTotalLable();
                //freightBill controls
                this.dvFreightBill.Table = dsBatch.Tables["FrghtBl"];
                this.dvFreightBill.RowFilter = dvFreightBill.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //KeyIdents grid
                this.dvKeyIdents.Table = dsBatch.Tables["KeyIdents"];
                this.dvKeyIdents.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //Addrs
                this.dvAddrs.Table = dsBatch.Tables["Addrs"];
                this.dvAddrs.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //Cntnrs
                this.dvCntnrs.Table = dsBatch.Tables["Cntnrs"];
                this.dvCntnrs.RowFilter = string.Format("FbId = '{0}'", string.Empty);
                
                //ProdDtl
                this.dvProdDtl.Table = dsBatch.Tables["ProdDtl"];
                this.dvProdDtl.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //FBLine
                dvFBLine.Table = dsBatch.Tables["FBLn"];
                this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //controls
                foreach (Control control in grpBoxInnerInvoice)
                {
                    if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != null)
                    {
                        if (((TraxDETextBox)control).DatabaseFieldLink == "CompleteLocIdRemit")
                        {

                            string[] txt = new string[4];
                            txt[0] = dvInvoice[0]["AlRemit1"].ToString();
                            txt[1] = dvInvoice[0]["AlRemit3"].ToString();
                            txt[2] = dvInvoice[0]["AlCityRemit"].ToString();
                            txt[3] = dvInvoice[0]["AlStateProvRemit"].ToString() + " " + dvInvoice[0]["AlPostCodeRemit"].ToString() + " " + dvInvoice[0]["AlCntryCodeRemit"].ToString();
                            ((TraxDETextBox)control).Lines = txt;
                        }
                        else if (((TraxDETextBox)control).DatabaseFieldLink == "CompleteLocIdBlng")
                        {
                            string[] txt = new string[4];
                            txt[0] = dvInvoice[0]["AlBlng1"].ToString();
                            txt[1] = dvInvoice[0]["AlBlng3"].ToString();
                            txt[2] = dvInvoice[0]["AlCityBlng"].ToString();
                            txt[3] = dvInvoice[0]["AlStateProvBlng"].ToString() + " " + dvInvoice[0]["AlPostCodeBlng"].ToString() + " " + dvInvoice[0]["AlCntryCodeBlng"].ToString();
                            ((TraxDETextBox)control).Lines = txt;
                        }
                        else
                            ((TraxDETextBox)control).Text = dvInvoice[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                        dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "INVOICE", isInvoiceSelected ? this.treeInvBat.SelectedNode.Tag : this.treeInvBat.SelectedNode.Parent.Tag, ((TraxDETextBox)control).DatabaseFieldLink);
                        if (dvError.Count > 0)
                            ((TraxDETextBox)control).IsCorrectValue = false;
                        else
                            ((TraxDETextBox)control).IsCorrectValue = true;
                        dvEphesoftInvoice.RowFilter = string.Format("InvId = '{0}'", isInvoiceSelected ? this.treeInvBat.SelectedNode.Tag : this.treeInvBat.SelectedNode.Parent.Tag);
                        if (dvEphesoftInvoice.Count > 0 && (dvEphesoftInvoice.Table.Columns.Contains(((TraxDETextBox)control).DatabaseFieldLink) && dvEphesoftInvoice[0][((TraxDETextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                            ((TraxDETextBox)control).IsOCRValue = true;
                        else
                            ((TraxDETextBox)control).IsOCRValue = false;
                        ((TraxDETextBox)control).updateBackColor();
                    }
                    else if (control is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)control).DatabaseFieldLink != null)
                    {
                        if (dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty)
                        {
                            if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATELONG)
                                ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy HH:mm}", Convert.ToDateTime(dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                            else if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATESHORT)
                                ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                            else
                                ((TraxDEMaskedTextBox)control).Text = dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString();
                        }
                        else
                            ((TraxDEMaskedTextBox)control).Text = string.Empty;
                        dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "INVOICE", isInvoiceSelected ? this.treeInvBat.SelectedNode.Tag : this.treeInvBat.SelectedNode.Parent.Tag, ((TraxDEMaskedTextBox)control).DatabaseFieldLink);
                        if (dvError.Count > 0)
                            ((TraxDEMaskedTextBox)control).IsCorrectValue = false;
                        else
                            ((TraxDEMaskedTextBox)control).IsCorrectValue = true;
                        dvEphesoftInvoice.RowFilter = string.Format("InvId = '{0}'", isInvoiceSelected ? this.treeInvBat.SelectedNode.Tag : this.treeInvBat.SelectedNode.Parent.Tag);
                        if (dvEphesoftInvoice.Count > 0 && (dvEphesoftInvoice.Table.Columns.Contains(((TraxDEMaskedTextBox)control).DatabaseFieldLink) && dvEphesoftInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                            ((TraxDEMaskedTextBox)control).IsOCRValue = true;
                        else
                            ((TraxDEMaskedTextBox)control).IsOCRValue = false;
                        ((TraxDEMaskedTextBox)control).updateBackColor();
                    }
                    else if (control is TraxDEComboBox)
                    {
                        ((TraxDEComboBox)control).SelectedItem = dvInvoice[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                        ((TraxDEComboBox)control).SelectedValue = dvInvoice[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                    }

                }

                //freightBill
                if (!isInvoiceSelected)
                {
                    dvFreightBill.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);

                    foreach (Control control in grpBoxFreightBill)
                    {
                        if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != null)
                        {
                            if (((TraxDETextBox)control).DatabaseFieldLink != "InvPageNum")
                            {
                                ((TraxDETextBox)control).Text = dvFreightBill[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                                dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", this.treeInvBat.SelectedNode.Tag, ((TraxDETextBox)control).DatabaseFieldLink);
                                if (dvError.Count > 0)
                                    ((TraxDETextBox)control).IsCorrectValue = false;
                                else
                                    ((TraxDETextBox)control).IsCorrectValue = true;

                                dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);
                                if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDETextBox)control).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDETextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                    ((TraxDETextBox)control).IsOCRValue = true;
                                else
                                    ((TraxDETextBox)control).IsOCRValue = false;
                            }
                            ((TraxDETextBox)control).updateBackColor();
                        }
                        else if (control is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)control).DatabaseFieldLink != null)
                        {
                            if (dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty)
                            {
                                if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATELONG)
                                    ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy HH:mm}", Convert.ToDateTime(dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                                else if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATESHORT)
                                    ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                                else
                                    ((TraxDEMaskedTextBox)control).Text = dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString();
                            }
                            else
                                ((TraxDEMaskedTextBox)control).Text = string.Empty;
                            dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", this.treeInvBat.SelectedNode.Tag, ((TraxDEMaskedTextBox)control).DatabaseFieldLink);
                            if (dvError.Count > 0)
                                ((TraxDEMaskedTextBox)control).IsCorrectValue = false;
                            else
                                ((TraxDEMaskedTextBox)control).IsCorrectValue = true;

                            dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);
                            if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDEMaskedTextBox)control).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                ((TraxDEMaskedTextBox)control).IsOCRValue = true;
                            else
                                ((TraxDEMaskedTextBox)control).IsOCRValue = false;

                            ((TraxDEMaskedTextBox)control).updateBackColor();
                        }
                        else if (control is TraxDEComboBox)
                        {
                            ((TraxDEComboBox)control).SelectedItem = dvFreightBill[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                            ((TraxDEComboBox)control).SelectedValue = dvFreightBill[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                        }
                        else if (control is GroupBox)
                        {
                            foreach (Control controls in ((GroupBox)control).Controls)
                            {
                                if (controls is TraxDETextBox && ((TraxDETextBox)controls).DatabaseFieldLink != null)
                                {
                                    ((TraxDETextBox)controls).Text = dvFreightBill[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString();
                                    dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", this.treeInvBat.SelectedNode.Tag, ((TraxDETextBox)controls).DatabaseFieldLink);
                                    if (dvError.Count > 0)
                                        ((TraxDETextBox)controls).IsCorrectValue = false;
                                    else
                                        ((TraxDETextBox)controls).IsCorrectValue = true;

                                    dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);
                                    if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDETextBox)controls).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                        ((TraxDETextBox)controls).IsOCRValue = true;
                                    else
                                        ((TraxDETextBox)controls).IsOCRValue = false;

                                    ((TraxDETextBox)controls).updateBackColor();

                                }
                                else if (controls is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)controls).DatabaseFieldLink != null)
                                {
                                    ((TraxDEMaskedTextBox)controls).Text = dvFreightBill[0][((TraxDEMaskedTextBox)controls).DatabaseFieldLink].ToString();
                                    dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", this.treeInvBat.SelectedNode.Tag, ((TraxDEMaskedTextBox)controls).DatabaseFieldLink);
                                    if (dvError.Count > 0)
                                        ((TraxDEMaskedTextBox)controls).IsCorrectValue = false;
                                    else
                                        ((TraxDEMaskedTextBox)controls).IsCorrectValue = true;
                                    dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);
                                    if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDEMaskedTextBox)controls).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDEMaskedTextBox)controls).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                        ((TraxDEMaskedTextBox)controls).IsOCRValue = true;
                                    else
                                        ((TraxDEMaskedTextBox)controls).IsOCRValue = false;

                                    ((TraxDEMaskedTextBox)controls).updateBackColor();
                                }
                                else if (controls is TraxDEComboBox)
                                {
                                    ((TraxDEComboBox)controls).SelectedItem = dvFreightBill[0][((TraxDEComboBox)controls).DatabaseFieldLink].ToString();
                                    ((TraxDEComboBox)controls).SelectedValue = dvFreightBill[0][((TraxDEComboBox)controls).DatabaseFieldLink].ToString();
                                }
                            }
                        }
                    }
                    //KeyIdents
                    this.dvKeyIdents.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);                    
                    this.grdKeyIdents.DataSource = dvKeyIdents;
                    this.grdKeyIdents.AutoResizeColumns();
                    this.grdKeyIdents.Refresh();
                    bsKeyIdents.DataSource = dvKeyIdents;
                    if (grdKeyIdents.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdKeyIdents.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = 'KEY_IDENTS' AND ID = '{0}' AND LineItemNum = '{1}'", row.Cells["KeyIdentsFbId"].Value != null ? row.Cells["KeyIdentsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["KeyIdentsKeyNum"].Value != null ? row.Cells["KeyIdentsKeyNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.ForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.BackColor = Color.Red;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.SelectionForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.SelectionBackColor = Color.Red;

                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.ForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.BackColor = Color.Red;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.SelectionForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.SelectionBackColor = Color.Red;
                                }
                            }
                            dvEphesoftKeyIdents.RowFilter = string.Format("FbId = '{0}' AND KeyNum = '{1}'", row.Cells["KeyIdentsFbId"].Value != null ? row.Cells["KeyIdentsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["KeyIdentsKeyNum"].Value != null ? row.Cells["KeyIdentsKeyNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftKeyIdents != null && dvEphesoftKeyIdents.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftKeyIdents.Table.Columns)
                                {
                                    if (dvEphesoftKeyIdents[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", dvEphesoftKeyIdents[0]["KeyNum"])].Cells["KeyIdents" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }

                    //Addrs
                    bindAddress();

                    //Cntnrs
                    this.dvCntnrs.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);
                    this.grdCntnrs.DataSource = dvCntnrs;
                    this.grdCntnrs.AutoResizeColumns();
                    this.grdCntnrs.Refresh();
                    bsCntnrs.DataSource = dvCntnrs;
                    if (grdCntnrs.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdCntnrs.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = '{0}' AND ID = '{1}' AND LineItemNum = '{2}'", "CNTNRS", row.Cells["CntnrsFbId"].Value != null ? row.Cells["CntnrsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["CntnrsCntnrNum"].Value != null ? row.Cells["CntnrsCntnrNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.ForeColor = Color.White;
                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.BackColor = Color.Red;

                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.SelectionForeColor = Color.White;
                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.SelectionBackColor = Color.Red;
                                }
                            }
                            dvEphesoftCntnrs.RowFilter = string.Format("FbId = '{0}' AND CntnrNum = '{1}'", row.Cells["CntnrsFbId"].Value != null ? row.Cells["CntnrsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["CntnrsCntnrNum"].Value != null ? row.Cells["CntnrsCntnrNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftCntnrs != null && dvEphesoftCntnrs.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftCntnrs.Table.Columns)
                                {
                                    if (dvEphesoftCntnrs[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", dvEphesoftCntnrs[0]["CntnrNum"])].Cells["Cntnrs" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }                    

                    //ProdDtl
                    this.dvProdDtl.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);
                    this.grdProdDtl.DataSource = dvProdDtl;
                    this.grdProdDtl.AutoResizeColumns();
                    this.grdProdDtl.Refresh();
                    bsProdDtl.DataSource = dvProdDtl;
                    if (grdProdDtl.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdProdDtl.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = '{0}' AND ID = '{1}' AND LineItemNum = '{2}'", "PRODDTL", row.Cells["ProdDtlFbId"].Value != null ? row.Cells["ProdDtlFbId"].Value.ToString().Trim() : string.Empty, row.Cells["ProdDtlProdInstNum"].Value != null ? row.Cells["ProdDtlProdInstNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.ForeColor = Color.White;
                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.BackColor = Color.Red;

                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.SelectionForeColor = Color.White;
                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.SelectionBackColor = Color.Red;
                                }
                            }
                            dvEphesoftProdDtl.RowFilter = string.Format("FbId = '{0}' AND ProdInstNum = '{1}'", row.Cells["ProdDtlFbId"].Value != null ? row.Cells["ProdDtlFbId"].Value.ToString().Trim() : string.Empty, row.Cells["ProdDtlProdInstNum"].Value != null ? row.Cells["ProdDtlProdInstNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftProdDtl != null && dvEphesoftProdDtl.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftProdDtl.Table.Columns)
                                {
                                    if (dvEphesoftProdDtl[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", dvEphesoftProdDtl[0]["ProdInstNum"])].Cells["ProdDtl" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }

                    //Line Item grid                    
                    this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", this.treeInvBat.SelectedNode.Tag);
                    this.grdFBLine.DataSource = dvFBLine;
                    this.grdFBLine.AutoResizeColumns();
                    this.grdFBLine.Refresh();                    
                    bsFBLn.DataSource = dvFBLine;
                    if (grdFBLine.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdFBLine.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = '{0}' AND ID = '{1}' AND LineItemNum = '{2}'", "FB_LN", row.Cells["FBLnFbId"].Value != null ? row.Cells["FBLnFbId"].Value.ToString().Trim() : string.Empty, row.Cells["FBLnLineItemNum"].Value != null ? row.Cells["FBLnLineItemNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.ForeColor = Color.White;
                                    grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.BackColor = Color.Red;

                                    grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.SelectionForeColor = Color.White;
                                    grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.SelectionBackColor = Color.Red;
                                }
                            }
                            dvEphesoftFBLine.RowFilter = string.Format("FbId = '{0}' AND LineItemNum = '{1}'", row.Cells["FBLnFbId"].Value != null ? row.Cells["FBLnFbId"].Value.ToString().Trim() : string.Empty, row.Cells["FBLnLineItemNum"].Value != null ? row.Cells["FBLnLineItemNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftFBLine != null && dvEphesoftFBLine.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftFBLine.Table.Columns)
                                {
                                    if (dvEphesoftFBLine[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdFBLine.Rows[bsFBLn.Find("LineItemNum", dvEphesoftFBLine[0]["LineItemNum"])].Cells["FBLn" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    clearControls(grpBoxFreightBillX);                    
                    this.grdFBLine.DataSource = dvFBLine;
                }
                setFBLnTotalLable();
            }
        }

        private void bindControls(ListViewItem item)
        {            
            if (dsBatch == null)
            {
                clearControls(grpBoxInvoice);
                if ((DataView)grdFBLine.DataSource != null)
                {
                    if (dvFBLine.Table != null)
                        dvFBLine.Table.Rows.Clear();
                    grdFBLine.DataSource = dvFBLine;
                }
            }
            else
            {
                //invoice controls
                this.dvInvoice.Table = dsBatch.Tables["Invoice"];
                this.dvInvoice.RowFilter = string.Format("InvId = '{0}'", getID(true, item));
                setFBTotalLable();
                //freightBill controls
                this.dvFreightBill.Table = dsBatch.Tables["FrghtBl"];
                this.dvFreightBill.RowFilter = dvFreightBill.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //KeyIdents grid
                this.dvKeyIdents.Table = dsBatch.Tables["KeyIdents"];
                this.dvKeyIdents.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //Addrs
                this.dvAddrs.Table = dsBatch.Tables["Addrs"];
                this.dvAddrs.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //Cntnrs
                this.dvCntnrs.Table = dsBatch.Tables["Cntnrs"];
                this.dvCntnrs.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //ProdDtl
                this.dvProdDtl.Table = dsBatch.Tables["ProdDtl"];
                this.dvProdDtl.RowFilter = string.Format("FbId = '{0}'", string.Empty);

                //FBLine
                dvFBLine.Table = dsBatch.Tables["FBLn"];
                this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", string.Empty);                
                //controls
                foreach (Control control in grpBoxInnerInvoice)
                {
                    if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != null)
                    {
                        if (((TraxDETextBox)control).DatabaseFieldLink == "CompleteLocIdRemit")
                        {

                            string[] txt = new string[4];
                            txt[0] = dvInvoice[0]["AlRemit1"].ToString();
                            txt[1] = dvInvoice[0]["AlRemit3"].ToString();
                            txt[2] = dvInvoice[0]["AlCityRemit"].ToString();
                            txt[3] = dvInvoice[0]["AlStateProvRemit"].ToString() + " " + dvInvoice[0]["AlPostCodeRemit"].ToString() + " " + dvInvoice[0]["AlCntryCodeRemit"].ToString();
                            ((TraxDETextBox)control).Lines = txt;
                        }
                        else if (((TraxDETextBox)control).DatabaseFieldLink == "CompleteLocIdBlng")
                        {
                            string[] txt = new string[4];
                            txt[0] = dvInvoice[0]["AlBlng1"].ToString();
                            txt[1] = dvInvoice[0]["AlBlng3"].ToString();
                            txt[2] = dvInvoice[0]["AlCityBlng"].ToString();
                            txt[3] = dvInvoice[0]["AlStateProvBlng"].ToString() + " " + dvInvoice[0]["AlPostCodeBlng"].ToString() + " " + dvInvoice[0]["AlCntryCodeBlng"].ToString();
                            ((TraxDETextBox)control).Lines = txt;
                        }
                        else
                            ((TraxDETextBox)control).Text = dvInvoice[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                        dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "INVOICE", getID(true, item), ((TraxDETextBox)control).DatabaseFieldLink);
                        if (dvError.Count > 0)
                            ((TraxDETextBox)control).IsCorrectValue = false;
                        else
                            ((TraxDETextBox)control).IsCorrectValue = true;
                        dvEphesoftInvoice.RowFilter = string.Format("InvId = '{0}'", getID(true, item));
                        if (dvEphesoftInvoice.Count > 0 && (dvEphesoftInvoice.Table.Columns.Contains(((TraxDETextBox)control).DatabaseFieldLink) && dvEphesoftInvoice[0][((TraxDETextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                            ((TraxDETextBox)control).IsOCRValue = true;
                        else
                            ((TraxDETextBox)control).IsOCRValue = false;
                        ((TraxDETextBox)control).updateBackColor();
                    }
                    else if (control is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)control).DatabaseFieldLink != null)
                    {
                        if (dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty)
                        {
                            if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATELONG)
                                ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy HH:mm}", Convert.ToDateTime(dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                            else if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATESHORT)
                                ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                            else
                                ((TraxDEMaskedTextBox)control).Text = dvInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString();
                        }
                        else
                            ((TraxDEMaskedTextBox)control).Text = string.Empty;
                        dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "INVOICE", getID(true, item), ((TraxDEMaskedTextBox)control).DatabaseFieldLink);
                        if (dvError.Count > 0)
                            ((TraxDEMaskedTextBox)control).IsCorrectValue = false;
                        else
                            ((TraxDEMaskedTextBox)control).IsCorrectValue = true;
                        dvEphesoftInvoice.RowFilter = string.Format("InvId = '{0}'", getID(true, item));
                        if (dvEphesoftInvoice.Count > 0 && (dvEphesoftInvoice.Table.Columns.Contains(((TraxDEMaskedTextBox)control).DatabaseFieldLink) && dvEphesoftInvoice[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                            ((TraxDEMaskedTextBox)control).IsOCRValue = true;
                        else
                            ((TraxDEMaskedTextBox)control).IsOCRValue = false;

                        ((TraxDEMaskedTextBox)control).updateBackColor();
                    }
                    else if (control is TraxDEComboBox)
                    {
                        ((TraxDEComboBox)control).SelectedItem = dvInvoice[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                        ((TraxDEComboBox)control).SelectedValue = dvInvoice[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                    }
                }

                //freightBill

                dvFreightBill.RowFilter = string.Format("FbId = '{0}'", getID(false, item));

                if (dvFreightBill.Count > 0)
                {
                    foreach (Control control in grpBoxFreightBill)
                    {
                        if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != null)
                        {
                            if (((TraxDETextBox)control).DatabaseFieldLink != "InvPageNum")
                            {
                                ((TraxDETextBox)control).Text = dvFreightBill[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                                dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", getID(false, item), ((TraxDETextBox)control).DatabaseFieldLink);
                                if (dvError.Count > 0)
                                    ((TraxDETextBox)control).IsCorrectValue = false;
                                else
                                    ((TraxDETextBox)control).IsCorrectValue = true;

                                dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                                if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDETextBox)control).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDETextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                    ((TraxDETextBox)control).IsOCRValue = true;
                                else
                                    ((TraxDETextBox)control).IsOCRValue = false;
                            }
                            ((TraxDETextBox)control).updateBackColor();
                        }
                        else if (control is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)control).DatabaseFieldLink != null)
                        {
                            if (dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty)
                            {
                                if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATELONG)
                                    ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy HH:mm}", Convert.ToDateTime(dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                                else if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.MaskValueType.DATESHORT)
                                    ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink]));
                                else
                                    ((TraxDEMaskedTextBox)control).Text = dvFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString();
                            }
                            else
                                ((TraxDEMaskedTextBox)control).Text = string.Empty;
                            dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", getID(false, item), ((TraxDEMaskedTextBox)control).DatabaseFieldLink);
                            if (dvError.Count > 0)
                                ((TraxDEMaskedTextBox)control).IsCorrectValue = false;
                            else
                                ((TraxDEMaskedTextBox)control).IsCorrectValue = true;

                            dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                            if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDEMaskedTextBox)control).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                ((TraxDEMaskedTextBox)control).IsOCRValue = true;
                            else
                                ((TraxDEMaskedTextBox)control).IsOCRValue = false;
                            ((TraxDEMaskedTextBox)control).updateBackColor();
                        }
                        else if (control is TraxDEComboBox)
                        {
                            ((TraxDEComboBox)control).SelectedItem = dvFreightBill[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                            ((TraxDEComboBox)control).SelectedValue = dvFreightBill[0][((TraxDEComboBox)control).DatabaseFieldLink].ToString();
                        }
                        else if (control is GroupBox)
                        {
                            foreach (Control controls in ((GroupBox)control).Controls)
                            {
                                if (controls is TraxDETextBox && ((TraxDETextBox)controls).DatabaseFieldLink != null)
                                {
                                    ((TraxDETextBox)controls).Text = dvFreightBill[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString();
                                    dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", getID(false, item), ((TraxDETextBox)controls).DatabaseFieldLink);
                                    if (dvError.Count > 0)
                                        ((TraxDETextBox)controls).IsCorrectValue = false;
                                    else
                                        ((TraxDETextBox)controls).IsCorrectValue = true;

                                    dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                                    if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDETextBox)controls).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                        ((TraxDETextBox)controls).IsOCRValue = true;
                                    else
                                        ((TraxDETextBox)controls).IsOCRValue = false;

                                    ((TraxDETextBox)controls).updateBackColor();

                                }
                                else if (controls is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)controls).DatabaseFieldLink != null)
                                {
                                    ((TraxDEMaskedTextBox)controls).Text = dvFreightBill[0][((TraxDEMaskedTextBox)controls).DatabaseFieldLink].ToString();
                                    dvError.RowFilter = string.Format("NodeName = '{0}' AND ID = '{1}' AND FieldName = '{2}'", "FRGHT_BL", getID(false, item), ((TraxDEMaskedTextBox)controls).DatabaseFieldLink);
                                    if (dvError.Count > 0)
                                        ((TraxDEMaskedTextBox)controls).IsCorrectValue = false;
                                    else
                                        ((TraxDEMaskedTextBox)controls).IsCorrectValue = true;
                                    dvEphesoftFreightBill.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                                    if (dvEphesoftFreightBill.Count > 0 && (dvEphesoftFreightBill.Table.Columns.Contains(((TraxDEMaskedTextBox)controls).DatabaseFieldLink) && dvEphesoftFreightBill[0][((TraxDEMaskedTextBox)controls).DatabaseFieldLink].ToString().Trim() != string.Empty))
                                        ((TraxDEMaskedTextBox)controls).IsOCRValue = true;
                                    else
                                        ((TraxDEMaskedTextBox)controls).IsOCRValue = false;
                                    ((TraxDEMaskedTextBox)controls).updateBackColor();
                                }
                                else if (controls is TraxDEComboBox)
                                {
                                    ((TraxDEComboBox)controls).SelectedItem = dvFreightBill[0][((TraxDEComboBox)controls).DatabaseFieldLink].ToString();
                                    ((TraxDEComboBox)controls).SelectedValue = dvFreightBill[0][((TraxDEComboBox)controls).DatabaseFieldLink].ToString();
                                }
                            }
                        }
                    }
                    //KeyIdents
                    this.dvKeyIdents.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                    this.grdKeyIdents.DataSource = dvKeyIdents;
                    this.grdKeyIdents.AutoResizeColumns();
                    this.grdKeyIdents.Refresh();                    
                    bsKeyIdents.DataSource = dvKeyIdents;
                    if (grdKeyIdents.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdKeyIdents.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = 'KEY_IDENTS' AND ID = '{0}' AND LineItemNum = '{1}'", row.Cells["KeyIdentsFbId"].Value != null ? row.Cells["KeyIdentsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["KeyIdentsKeyNum"].Value != null ? row.Cells["KeyIdentsKeyNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {                                
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.ForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.BackColor = Color.Red;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.SelectionForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyQual"].Style.SelectionBackColor = Color.Red;

                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.ForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.BackColor = Color.Red;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.SelectionForeColor = Color.White;
                                    grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", rowTemp["LineItemNum"])].Cells["KeyIdentsKeyVal"].Style.SelectionBackColor = Color.Red;
                                }                                
                            }
                            dvEphesoftKeyIdents.RowFilter = string.Format("FbId = '{0}' AND KeyNum = '{1}'", row.Cells["KeyIdentsFbId"].Value != null ? row.Cells["KeyIdentsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["KeyIdentsKeyNum"].Value != null ? row.Cells["KeyIdentsKeyNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftKeyIdents != null && dvEphesoftKeyIdents.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftKeyIdents.Table.Columns)
                                {
                                    if (dvEphesoftKeyIdents[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdKeyIdents.Rows[bsKeyIdents.Find("KeyNum", dvEphesoftKeyIdents[0]["KeyNum"])].Cells["KeyIdents" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }
                    
                    //Addrs
                    bindAddress();

                    //Cntnrs
                    this.dvCntnrs.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                    this.grdCntnrs.DataSource = dvCntnrs;
                    this.grdCntnrs.AutoResizeColumns();
                    this.grdCntnrs.Refresh();
                    bsCntnrs.DataSource = dvCntnrs;
                    if (grdCntnrs.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdCntnrs.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = '{0}' AND ID = '{1}' AND LineItemNum = '{2}'", "CNTNRS", row.Cells["CntnrsFbId"].Value != null ? row.Cells["CntnrsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["CntnrsCntnrNum"].Value != null ? row.Cells["CntnrsCntnrNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.ForeColor = Color.White;
                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.BackColor = Color.Red;

                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.SelectionForeColor = Color.White;
                                    grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", rowTemp["LineItemNum"])].Cells["Cntnrs" + rowTemp["FieldName"].ToString()].Style.SelectionBackColor = Color.Red;
                                }
                            }

                            dvEphesoftCntnrs.RowFilter = string.Format("FbId = '{0}' AND CntnrNum = '{1}'", row.Cells["CntnrsFbId"].Value != null ? row.Cells["CntnrsFbId"].Value.ToString().Trim() : string.Empty, row.Cells["CntnrsCntnrNum"].Value != null ? row.Cells["CntnrsCntnrNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftCntnrs != null && dvEphesoftCntnrs.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftCntnrs.Table.Columns)
                                {
                                    if (dvEphesoftCntnrs[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdCntnrs.Rows[bsCntnrs.Find("CntnrNum", dvEphesoftCntnrs[0]["CntnrNum"])].Cells["Cntnrs" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }


                    //ProdDtl
                    this.dvProdDtl.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                    this.grdProdDtl.DataSource = dvProdDtl;
                    this.grdProdDtl.AutoResizeColumns();
                    this.grdProdDtl.Refresh();
                    bsProdDtl.DataSource = dvProdDtl;
                    if (grdProdDtl.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdProdDtl.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = '{0}' AND ID = '{1}' AND LineItemNum = '{2}'", "PRODDTL", row.Cells["ProdDtlFbId"].Value != null ? row.Cells["ProdDtlFbId"].Value.ToString().Trim() : string.Empty, row.Cells["ProdDtlProdInstNum"].Value != null ? row.Cells["ProdDtlProdInstNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.ForeColor = Color.White;
                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.BackColor = Color.Red;

                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.SelectionForeColor = Color.White;
                                    grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", rowTemp["LineItemNum"])].Cells["ProdDtl" + rowTemp["FieldName"].ToString()].Style.SelectionBackColor = Color.Red;
                                }
                            }

                            dvEphesoftProdDtl.RowFilter = string.Format("FbId = '{0}' AND ProdInstNum = '{1}'", row.Cells["ProdDtlFbId"].Value != null ? row.Cells["ProdDtlFbId"].Value.ToString().Trim() : string.Empty, row.Cells["ProdDtlProdInstNum"].Value != null ? row.Cells["ProdDtlProdInstNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftProdDtl != null && dvEphesoftProdDtl.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftProdDtl.Table.Columns)
                                {
                                    if (dvEphesoftProdDtl[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdProdDtl.Rows[bsProdDtl.Find("ProdInstNum", dvEphesoftProdDtl[0]["ProdInstNum"])].Cells["ProdDtl" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }


                    //Line Item grid                    
                    this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", getID(false, item));
                    this.grdFBLine.DataSource = dvFBLine;
                    this.grdFBLine.AutoResizeColumns();
                    this.grdFBLine.Refresh();
                    
                    bsFBLn.DataSource = dvFBLine;
                    if (grdFBLine.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grdFBLine.Rows)
                        {
                            dvError.RowFilter = string.Format("KeyedValue <> 'Missing record' AND NodeName = '{0}' AND ID = '{1}' AND LineItemNum = '{2}'", "FB_LN", row.Cells["FBLnFbId"].Value != null ? row.Cells["FBLnFbId"].Value.ToString().Trim() : string.Empty, row.Cells["FBLnLineItemNum"].Value != null ? row.Cells["FBLnLineItemNum"].Value.ToString().Trim() : string.Empty);
                            if (dvError != null && dvError.Count > 0)
                            {
                                foreach (DataRowView rowTemp in dvError)
                                {
                                    if (rowTemp["FieldName"].ToString() != "")
                                    {
                                        grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.ForeColor = Color.White;
                                        grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.BackColor = Color.Red;

                                        grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.SelectionForeColor = Color.White;
                                        grdFBLine.Rows[bsFBLn.Find("LineItemNum", rowTemp["LineItemNum"])].Cells["FBLn" + rowTemp["FieldName"].ToString()].Style.SelectionBackColor = Color.Red;
                                    }
                                }
                            }

                            dvEphesoftFBLine.RowFilter = string.Format("FbId = '{0}' AND LineItemNum = '{1}'", row.Cells["FBLnFbId"].Value != null ? row.Cells["FBLnFbId"].Value.ToString().Trim() : string.Empty, row.Cells["FBLnLineItemNum"].Value != null ? row.Cells["FBLnLineItemNum"].Value.ToString().Trim() : string.Empty);
                            if (dvEphesoftFBLine != null && dvEphesoftFBLine.Count > 0)
                            {
                                foreach (DataColumn colTemp in dvEphesoftFBLine.Table.Columns)
                                {
                                    if (dvEphesoftFBLine[0][colTemp.ColumnName].ToString().Trim() != string.Empty)
                                    {
                                        grdFBLine.Rows[bsFBLn.Find("LineItemNum", dvEphesoftFBLine[0]["LineItemNum"])].Cells["FBLn" + colTemp.ColumnName].Style.BackColor = Color.Aqua;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    clearControls(grpBoxFreightBillX);                   
                    this.grdFBLine.DataSource = dvFBLine;
                }
                setFBLnTotalLable();
            }
            
        }
        
        private void bindTree()
        {
            this.Cursor = Cursors.WaitCursor;
            TreeNode nodeID;
            TreeNode currentNode = null;            

            clearTree();

            this.treeInvBat.BeginUpdate();
            this.treeInvBat.Nodes[0].Text = "Batch - " + MXXDatabase;
            int invoice = 0;
            int fb = 0;
            foreach (DataRow rowInvoice in this.dsBatch.Tables["Invoice"].DefaultView.ToTable().Rows)
            {
                invoice++;
                fb = 0;
                currentNode = this.treeInvBat.Nodes[0];//root
                nodeID = generateNode(rowInvoice["InvID"].ToString(), invoice.ToString() + " - " + rowInvoice["InvKey"].ToString());
                currentNode.Nodes.Add(nodeID);
                currentNode = nodeID;
                
                foreach (DataRow rowFB in this.dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", rowInvoice["InvId"].ToString())))
                {
                    fb++;
                    nodeID = generateNode(rowFB["FbId"].ToString(), fb.ToString() + " - " + rowFB["FbKey"].ToString());
                    currentNode.Nodes.Add(nodeID);                    
                }
            }
            foreach(TreeNode node in this.treeInvBat.Nodes[0].Nodes)
            {
                node.Expand();
            }
            this.treeInvBat.Nodes[0].Expand();
            this.treeInvBat.SelectedNode = this.treeInvBat.Nodes[0];
            this.treeInvBat.Nodes[0].EnsureVisible();

            this.treeInvBat.EndUpdate();

            this.lstBoxSelection.ItemSelectionChanged -= new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstBoxSelection_ItemSelectionChanged);

            string text = string.Empty;
            string tag = string.Empty;

            string fbtext = string.Empty;
            string fbtag = string.Empty;

            string name = string.Empty;
            lstBoxSelection.Items.Clear();
            ListViewItem item;
            int invoiceList = 0;
            int fbList = 0;
            foreach (DataRow rowInvoice in dsBatch.Tables["Invoice"].DefaultView.ToTable().Rows)
            {
                text = string.Empty;
                tag = string.Empty;
                name = string.Empty;
                invoiceList++;
                fbList = 0;
                text = invoiceList.ToString() + " - " + rowInvoice["InvKey"].ToString();
                tag = rowInvoice["InvId"].ToString() + ":";
                name = rowInvoice["InvId"].ToString();
                if (this.dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", rowInvoice["InvId"].ToString())).Count() > 0)
                {
                    foreach (DataRow rowFB in this.dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", rowInvoice["InvId"].ToString())))
                    {
                        fbtext = string.Empty;
                        fbtag = string.Empty;
                        fbList++;
                        fbtext = text + " : " + fbList.ToString() + " - " + rowFB["FbKey"].ToString();
                        fbtag = tag.ToString() + rowFB["FbId"].ToString();
                        name = rowFB["FbId"].ToString();
                        item = new ListViewItem();
                        item.Text = fbtext;
                        item.Tag = fbtag;
                        item.Name = name;
                        lstBoxSelection.Items.Add(item);
                    }
                }
                else
                {
                    item = new ListViewItem();
                    item.Text = text;
                    item.Tag = tag;
                    item.Name = name;
                    lstBoxSelection.Items.Add(item);
                }
            }
            this.lstBoxSelection.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lstBoxSelection_ItemSelectionChanged);
            //if (lstBoxSelection.Items.Count > 0)
            //    lstBoxSelection.Items[0].Selected = true;            
            this.Cursor = Cursors.Default;

            
        }
        
        private void clearTree()
        {
            this.treeInvBat.Nodes[0].Nodes.Clear();
        }

        private void clearControls(GroupBox group)
        {

            foreach (Control control in group.Controls)
            {
                if (control is TraxDETextBox)
                {
                    ((TraxDETextBox)control).Clear();
                    ((TraxDETextBox)control).showHint();
                }
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).Clear();

                else if (control is GroupBox)
                {
                    clearControls(((GroupBox)control));
                }
                else if (control is Panel)
                {
                    foreach (Control grd in control.Controls)
                    {
                        if (grd is TraxDEDataGridView)
                        {
                            if (((TraxDEDataGridView)grd).Name == "grdKeyIdents")
                            {
                                this.dvKeyIdents.RowFilter = string.Format("FbId = '{0}'", string.Empty);
                                this.grdKeyIdents.DataSource = dvKeyIdents;

                            }
                            else if (((TraxDEDataGridView)grd).Name == "grdFBLine")
                            {
                                this.dvFBLine.RowFilter = string.Format("FbId = '{0}'", string.Empty);
                                this.grdFBLine.DataSource = dvFBLine;
                            }
                        }
                    }
                }
            }

        }

        private void changeFormView()
        {
            formView = this.toolStripMenuTreeView.Checked ? CommonEnum.FormView.TREE_VIEW : CommonEnum.FormView.LIST_VIEW;
            if (formView == CommonEnum.FormView.LIST_VIEW)
            {
                lstBoxSelection.Visible = true;
                lstBoxSelection.Focus();
                if (lstBoxSelection.Items.Count > 0)
                {
                    if (lstBoxSelection.SelectedItems.Count>0 && lstBoxSelection.SelectedItems[0] == lstBoxSelection.Items[0])                    
                        lstBoxSelection.Items[0].Selected = false;                    
                    lstBoxSelection.Items[0].Selected = true;
                }
                else
                    lstBoxSelection_ItemSelectionChanged(null, null);
            }
            else
            {
                lstBoxSelection.Visible = false;
                treeInvBat.Focus();
                if(treeInvBat.SelectedNode == treeInvBat.Nodes[0])                
                    treeInvBat.SelectedNode = null;                
                treeInvBat.SelectedNode = treeInvBat.Nodes[0];
            }
        }

        private bool checkInvoiceKeyDuplicate(string invoiceKey, string invID)
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
            {
                if (MessageBox.Show("Invoice key duplicate.\nDo you wish to proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        private bool checkFBKeyDuplicate(string fbKey, string fbID)
        {
            bool fbKeyExist = false;
            foreach (DataRow row in dsBatch.Tables["FrghtBl"].Rows)
            {
                if (row.RowState != DataRowState.Deleted && row["FbKey"].ToString().Trim() == fbKey && row["FbId"].ToString().Trim() != fbID)
                {
                    fbKeyExist = true;
                    break;
                }
            }
            if (fbKeyExist)
            {
                if (MessageBox.Show("Freight bill key duplicate.\nDo you wish to proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }

        private bool deleteFBLn(string FbId)
        {
            bool retval = false;
            try
            {                
                foreach (DataRow row in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", FbId)))
                {                    
                    row.Delete();
                }

                //KeyIdents
                foreach (DataRow row in dsBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}'", FbId)))
                {
                    row.Delete();
                }
                //Addrs
                foreach (DataRow row in dsBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}'", FbId)))
                {
                    row.Delete();
                }
                //Cntnrs
                foreach (DataRow row in dsBatch.Tables["Cntnrs"].Select(string.Format("FbId = '{0}'", FbId)))
                {
                    row.Delete();
                }
                //ProdDtl
                foreach (DataRow row in dsBatch.Tables["ProdDtl"].Select(string.Format("FbId = '{0}'", FbId)))
                {
                    row.Delete();
                }
                retval = true;
            }
            catch (Exception error)
            {
                retval = false;
                throw error;
            }
            return retval;
        }

        private bool deleteFB(string FbId)
        {
            bool retval = false;
            try
            {
                foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("FbId = '{0}'", FbId)))
                {
                    row.Delete();
                }                
                retval = true;
            }
            catch (Exception error)
            {
                retval = false;
                throw error;
            }
            return retval;
        }

        private bool deleteInvoice(string InvId)
        {
            bool retval = false;
            try
            {                
                foreach (DataRow row in dsBatch.Tables["Invoice"].Select(string.Format("InvId = '{0}'", InvId)))
                {
                    row.Delete();
                }
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
                if (File.Exists(ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".xml"))
                    File.Delete(ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".xml");
                retval = true;
            }
            catch (Exception error)
            {
                throw error;
            }
            return retval;
        }

        private void determineMode()
        {
            if (dsBatch != null && dsBatch.Tables.Count > 0 && dsBatch.Tables["Invoice"].Rows.Count > 0)            
                if (dsBatch.Tables["Invoice"].Rows[0]["InvStat"].ToString().Trim() == "SingleBill")                
                    this.toolStripMenuSingleFB.Checked = true;                
                else                
                    this.toolStripMenuSingleFB.Checked = false;
            else            
                this.toolStripMenuSingleFB.Checked = false;            
        }

        private void determineMultipleCurrencyMode()
        {
            if (dsBatch != null && dsBatch.Tables.Count > 0 && dsBatch.Tables["FBLn"].Rows.Count > 0)
            {
                if (dsBatch.Tables["FBLn"].Rows[0]["T006"].ToString().Trim() == "MultipleCurrency")
                    toolStripMenuMultiCurr.Checked = true;
                else
                    toolStripMenuMultiCurr.Checked = false;
            }
            else
                toolStripMenuMultiCurr.Checked = false;
        }

        private void enableStateControls(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {                           
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        if(formView == CommonEnum.FormView.LIST_VIEW)
                            if (lstBoxSelection.Items.Count > 0)
                            {
                                if (lstBoxSelection.SelectedItems.Count > 0 && lstBoxSelection.SelectedItems[0] == lstBoxSelection.Items[0])
                                    lstBoxSelection.Items[0].Selected = false;
                                lstBoxSelection.Items[0].Selected = true;
                            }
                            else
                                lstBoxSelection_ItemSelectionChanged(null, null);
                        else
                            treeInvBat_AfterSelect(null, null);
                        grpBoxInvoice.Focus();
                        break;
                    }
                case CommonEnum.FormState.OPEN_STATE:
                    {
                        enableControls(false, grpBoxInvoice.Controls);
                        enableControls(false, grpBoxFreightBillX.Controls);
                        enableLineItem(false);//enableControls(false, grpBoxFbLine.Controls);
                        btnInvoiceAdd.Enabled = false;
                        btnInvoiceDelete.Enabled = false;
                        btnFBAdd.Enabled = false;
                        btnFBDelete.Enabled = false;                
                        break;
                    }
            }
        }

        private void enableToolStripButtons(CommonEnum.FormState state)
        {
            if ((formMode == CommonEnum.FormMode.DATA_ENTRY))
            {
                switch (state)
                {

                    case CommonEnum.FormState.NORMAL_STATE:
                        {                            
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
                            toolStripButtonMode.Enabled = dsBatch.Tables["Invoice"].Rows.Count > 0 ? false : true;
                            toolStripButtonOption.Enabled = true;
                            break;
                        }
                    case CommonEnum.FormState.OPEN_STATE:
                        {
                            toolStripButtonStart.Enabled = false;
                            toolStripButtonEdit.Enabled = false;
                            toolStripButtonSave.Enabled = false;
                            toolStripButtonSaveClose.Enabled = false;
                            toolStripButtonRestart.Enabled = false;
                            toolStripButtonSendReview.Enabled = false;
                            toolStripButtonCancel.Enabled = true;
                            toolStripButtonMode.Enabled = false;
                            toolStripButtonOption.Enabled = true;
                            break;
                        }
                }
            }
            else
            {
                switch (state)
                {
                    case CommonEnum.FormState.NORMAL_STATE:
                        {                            
                            break;
                        }
                    case CommonEnum.FormState.EDIT_STATE:
                        {
                            toolStripButtonStart.Enabled = false;
                            toolStripButtonEdit.Enabled = false;
                            toolStripButtonSave.Enabled = true;
                            toolStripButtonSaveClose.Enabled = true;
                            toolStripButtonSendReview.Enabled = true;
                            toolStripButtonRestart.Enabled = false;
                            toolStripButtonCancel.Enabled = formMode == CommonEnum.FormMode.QUALITY_ASSURANCE ? false : true;
                            toolStripButtonMode.Enabled = false;
                            toolStripButtonMode.Enabled = false;
                            toolStripButtonOption.Enabled = true;
                            break;
                        }
                    case CommonEnum.FormState.OPEN_STATE:
                        {
                            toolStripButtonStart.Enabled = false;
                            toolStripButtonEdit.Enabled = false;
                            toolStripButtonSave.Enabled = false;
                            toolStripButtonSaveClose.Enabled = false;
                            toolStripButtonSendReview.Enabled = false;
                            toolStripButtonRestart.Enabled = true;
                            toolStripButtonCancel.Enabled = true;
                            toolStripButtonMode.Enabled = false;
                            toolStripButtonMode.Enabled = false;
                            toolStripButtonOption.Enabled = true;
                            break;
                        }
                }
            }

            enableStateControls(currentFormState);
        }

        private void enableControls(bool isEnable, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = isEnable;
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = isEnable;
                else if (control is TraxDETextBox && (((TraxDETextBox)control).DatabaseFieldLink != "VendLabl" 
                    && ((TraxDETextBox)control).DatabaseFieldLink != "CompleteLocIdRemit" && ((TraxDETextBox)control).DatabaseFieldLink != "CompleteLocIdBlng" 
                    && ((TraxDETextBox)control).Name != "txtPickUpAdd" && ((TraxDETextBox)control).Name != "txtDeliveryAdd" && ((TraxDETextBox)control).Name != "txtStopOffLoc"
                    && ((TraxDETextBox)control).Name != "txtShipperInv" && ((TraxDETextBox)control).Name != "txtShipperBOL" && ((TraxDETextBox)control).Name != "txtShipperCom"
                    && ((TraxDETextBox)control).Name != "txtConsigneeInv" && ((TraxDETextBox)control).Name != "txtConsigneeBOL" && ((TraxDETextBox)control).Name != "txtConsigneeCom"))
                    ((TraxDETextBox)control).ReadOnly = !isEnable;

                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).ReadOnly = !isEnable;
                else if (control is TraxDEComboBox)
                    ((TraxDEComboBox)control).Enabled = isEnable;
                else if (control is TraxDEDataGridView)
                {
                    ((TraxDEDataGridView)control).ReadOnly = !isEnable;
                    ((TraxDEDataGridView)control).StandardTab = !isEnable;
                    ((TraxDEDataGridView)control).AllowUserToAddRows = isEnable;
                    if (isEnable)
                        setReadOnlyGridColumns((TraxDEDataGridView)control);
                }
                else if (control is GroupBox && ((GroupBox)control).Name != "grpBoxFreightBill" && ((GroupBox)control).Name != "grpBoxFbLine")
                    enableControls(isEnable, ((GroupBox)control).Controls);
                else if (control is Panel)
                    enableControls(isEnable, ((Panel)control).Controls);
                else if (control is RadioButton)
                    control.Enabled = isEnable;

                if (this.toolStripMenuSingleFB.Checked && control is TraxDETextBox && (((TraxDETextBox)control).DatabaseFieldLink == "FbKey" || ((TraxDETextBox)control).DatabaseFieldLink == "FbAmt"))
                    ((TraxDETextBox)control).ReadOnly = true;
            }
        }

        private void enableLineItem(bool isEnable)
        {
            grdFBLine.ReadOnly = !isEnable;
            grdFBLine.StandardTab = !isEnable;
            grdFBLine.AllowUserToAddRows = isEnable;
            if (isEnable)
                setReadOnlyGridColumns(grdFBLine);
            toolStripMenuMultiCurr.Enabled = isEnable;
        }

        private TreeNode generateNode(string id, string key)
        {
            TreeNode node = new TreeNode();
            node.Name = id;
            node.Text = key;
            node.Tag = id;            
            if (id.Equals("HOME"))
            {
                node.ImageIndex = 0;
                node.SelectedImageIndex = 0;
            }
            else
            {
                node.ImageIndex = 1;
                node.SelectedImageIndex = 1;
            }
            return node;
        }

        private DataTable getVendorInfoContent()
        {
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
            DataRow drVendorInfo = dtVendorInfo.NewRow();

            drVendorInfo["VendLabl"] = dvInvoice[0]["VendLabl"].ToString().Trim();
            drVendorInfo["LocIdRemit"] = dvInvoice[0]["LocIdRemit"].ToString().Trim();
            drVendorInfo["AlRemit1"] = dvInvoice[0]["AlRemit1"].ToString().Trim();
            drVendorInfo["AlRemit2"] = dvInvoice[0]["AlRemit2"].ToString().Trim();
            drVendorInfo["AlRemit3"] = dvInvoice[0]["AlRemit3"].ToString().Trim();
            drVendorInfo["AlRemit4"] = dvInvoice[0]["AlRemit4"].ToString().Trim();
            drVendorInfo["AlCityRemit"] = dvInvoice[0]["AlCityRemit"].ToString().Trim();
            drVendorInfo["AlStateProvRemit"] = dvInvoice[0]["AlStateProvRemit"].ToString().Trim();
            drVendorInfo["AlPostCodeRemit"] = dvInvoice[0]["AlPostCodeRemit"].ToString().Trim();
            drVendorInfo["AlCntryCodeRemit"] = dvInvoice[0]["AlCntryCodeRemit"].ToString().Trim();
            dtVendorInfo.Rows.Add(drVendorInfo);
            return dtVendorInfo;
        }

        private DataTable getBillToContent()
        {
            DataTable dtBillTo = new DataTable();
            dtBillTo.Columns.Add("VendLabl");
            dtBillTo.Columns.Add("LocIdBlng");
            dtBillTo.Columns.Add("AlBlng1");
            dtBillTo.Columns.Add("AlBlng2");
            dtBillTo.Columns.Add("AlBlng3");
            dtBillTo.Columns.Add("AlBlng4");
            dtBillTo.Columns.Add("AlCityBlng");
            dtBillTo.Columns.Add("AlStateProvBlng");
            dtBillTo.Columns.Add("AlPostCodeBlng");
            dtBillTo.Columns.Add("AlCntryCodeBlng");
            DataRow drBillTo = dtBillTo.NewRow();
            drBillTo["VendLabl"] = dvInvoice[0]["VendLabl"].ToString().Trim();
            drBillTo["LocIdBlng"] = dvInvoice[0]["LocIdBlng"].ToString().Trim();
            drBillTo["AlBlng1"] = dvInvoice[0]["AlBlng1"].ToString().Trim();
            drBillTo["AlBlng2"] = dvInvoice[0]["AlBlng2"].ToString().Trim();
            drBillTo["AlBlng3"] = dvInvoice[0]["AlBlng3"].ToString().Trim();
            drBillTo["AlBlng4"] = dvInvoice[0]["AlBlng4"].ToString().Trim();
            drBillTo["AlCityBlng"] = dvInvoice[0]["AlCityBlng"].ToString().Trim();
            drBillTo["AlStateProvBlng"] = dvInvoice[0]["AlStateProvBlng"].ToString().Trim();
            drBillTo["AlPostCodeBlng"] = dvInvoice[0]["AlPostCodeBlng"].ToString().Trim();
            drBillTo["AlCntryCodeBlng"] = dvInvoice[0]["AlCntryCodeBlng"].ToString().Trim();
            dtBillTo.Rows.Add(drBillTo);
            return dtBillTo;
        }

        private string getID(bool isInvoice, ListViewItem item)
        {
            string[] id = item.Tag.ToString().Split(':');
            if (isInvoice)
                return id[0];
            else
                return id[1];
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

        private bool isAllowedSendForReview()
        {
            bool retval = true;
            string message = string.Empty;
            bool isTraxAddress = false;
            bool isFBTermMissing = false;
            bool isDateOutOfRange = false;
            bool isInvoicekeyBlank = false;
            bool isFrghtblKeyBlank = false;
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    if (row["InvKey"].ToString().Trim() == string.Empty)
                    {
                        isInvoicekeyBlank = true;
                        //retval = false;
                        //message = "There are some blank invoice key, please review this batch.";
                        //break;
                    }
                    try
                    {
                        if (row["InvCreatDtm"].ToString().Trim() != string.Empty)
                            if (Convert.ToDateTime(row["InvCreatDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["InvCreatDtm"].ToString().Trim()) > (bl.GetServerDate()))
                                throw new Exception();
                    }
                    catch
                    {
                        retval = false;
                        message = "There are some invalid date or date format, please review this Invoice Key : " + row["InvKey"].ToString().Trim();
                        break;
                    }
                }
            }
            if (retval)
            {
                foreach (DataRow row in dsBatch.Tables["FrghtBl"].Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        if (row["FbKey"].ToString().Trim() == string.Empty)
                        {
                            isFrghtblKeyBlank = true;
                            //retval = false;
                            //message = "There are some blank freight bill key, please review this batch.";
                            //break;
                        }
                        if (!isFBTermMissing && row["FbPaymtTermsCode"].ToString().Trim() == string.Empty)// || (row["FbPaymtTermsCode"].ToString().Trim() != "TP" && row["FbPaymtTermsCode"].ToString().Trim() != "PP" && row["FbPaymtTermsCode"].ToString().Trim() != "CC"))
                        {
                            isFBTermMissing = true;
                            //retval = false;
                            //message = "There are some blank or invalid terms, please review this batch.";
                            //break;
                        }                        

                        try
                        {
                            if (!isDateOutOfRange)
                            {
                                if (row["FbCreatDtm"].ToString().Trim() != string.Empty)
                                    if (Convert.ToDateTime(row["FbCreatDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["FbCreatDtm"].ToString().Trim()) > (bl.GetServerDate()))
                                        isDateOutOfRange = true;//throw new Exception();
                                if (row["LmPkupActualDtm"].ToString().Trim() != string.Empty)
                                    if (!isDateOutOfRange && Convert.ToDateTime(row["LmPkupActualDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["LmPkupActualDtm"].ToString().Trim()) > bl.GetServerDate().AddDays(30))
                                        isDateOutOfRange = true;//throw new Exception();
                                if (row["LmAtaDtm"].ToString().Trim() != string.Empty)
                                    if (Convert.ToDateTime(row["LmAtaDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["LmAtaDtm"].ToString().Trim()) > bl.GetServerDate().AddDays(30))
                                        isDateOutOfRange = true;//throw new Exception();
                            }
                        }
                        catch
                        {
                            retval = false;
                            message = "There are some invalid date or date format, please review this Freight Bill Key : " + row["FbKey"].ToString().Trim();
                            break;
                        }
                    }
                }
                int score;
                foreach (DataRow row in dsBatch.Tables["Addrs"].Rows)
                {
                    if (!isTraxAddress)
                    {
                        score = 0;
                        if (row["AlCityAddr"].ToString().Trim() == "SCOTTSDALE")
                            score = score + 1;
                        if (row["AlStateProvAddr"].ToString().Trim() == "AZ")
                            score = score + 1;
                        if (row["AlPostCodeAddr"].ToString().Trim() == "85260")
                            score = score + 1;
                        if (row["AlCntryCodeAddr"].ToString().Trim() == "US")
                            score = score + 1;
                        if (row["AlAddr3"].ToString().Contains("14500") || row["AlAddr4"].ToString().Contains("14500"))
                            score = score + 1;
                        if (row["AlAddr3"].ToString().Contains("Northsight") || row["AlAddr4"].ToString().Contains("Northsight"))
                            score = score + 1;
                        if (row["AlAddr3"].ToString().Contains("113") || row["AlAddr4"].ToString().Contains("113"))
                            score = score + 1;
                        if (score > 3)
                        {
                            isTraxAddress = true;
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
            if (!retval)
                MessageBox.Show(message, "Data Entry");
            else
            {
                if (isTraxAddress)
                    MessageBox.Show("One or more of the addresses is possibly pointing to a Trax address. Please review.", "Data Entry");
                if (isInvoicekeyBlank && MessageBox.Show("There are some blank invoice key.\nDo you wish to proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.No)
                    retval = false;
                if (retval && isFrghtblKeyBlank && MessageBox.Show("There are some blank freight bill key.\nDo you wish to proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.No)
                    retval = false;
                if (retval && isFBTermMissing && MessageBox.Show("There are some blank or invalid terms, please review this batch.\nDo you wish to proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.No)
                    retval = false;
                if (retval && isDateOutOfRange && MessageBox.Show("There are some invalid dates, please review this batch.\nDo you wish to proceed?", "Data Entry", MessageBoxButtons.YesNo) == DialogResult.No)
                    retval = false;
            }
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
        
        private bool isInvAmtEqualVendInvAmt()
        {
            bool retval = false;
            DataView dv = new DataView();
            decimal fbTotal;
            try
            {
                dv.Table = dsBatch.Tables["FrghtBl"];
                foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                {
                    if (Convert.ToDecimal(row["InvAmt"]) == Convert.ToDecimal(row["VendInvAmt"]))
                        retval = true;
                    else
                    {
                        fbTotal = 0;
                        dv.RowFilter = string.Format("InvId = '{0}'", row["InvId"].ToString().Trim());
                        if (dv.Count > 0)
                        {
                            foreach (DataRowView rowFB in dv)
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
                //MessageBox.Show("There are some VendInvAmt that does not match the InvAmt value, please review this batch.", "Data Entry");
            }
            return retval;
        }
                
        private bool isQAPassAllowed()
        {
            bool retval = true;
            //bool isDateValidated = true;
            string message = string.Empty;
            bool isFBTermMissing = false;
            bool isDateOutOfRange = false;
            bool isInvoicekeyBlank = false;
            bool isFrghtblKeyBlank = false;
            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
            {
                if (row["InvKey"].ToString().Trim() == string.Empty)
                {
                    isInvoicekeyBlank = true;
                    //retval = false;
                    //message = "There are some blank invoice key, please review this batch.";
                    //break;
                }
                if (row["InvCurrencyQual"].ToString().Trim() == string.Empty)
                {
                    retval = false;
                    message = "Currency is empty, please review this batch.";
                    break;
                }
                try
                {
                    if (row["InvCreatDtm"].ToString().Trim() != string.Empty)
                        if (Convert.ToDateTime(row["InvCreatDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["InvCreatDtm"].ToString().Trim()) > (bl.GetServerDate()))
                            throw new Exception();
                }
                catch
                {
                    retval = false;
                    message = "There are some invalid date or date format, please review this Invoice Key : " + row["InvKey"].ToString().Trim();
                    break;
                    //isDateValidated = false;
                }
            }
            if (retval)
            {
                foreach (DataRow row in dsBatch.Tables["FrghtBl"].Rows)
                {
                    if (row["FbKey"].ToString().Trim() == string.Empty)
                    {
                        isFrghtblKeyBlank = true;
                        //retval = false;
                        //message = "There are some blank freight bill key, please review this batch.";
                        //break;
                    }
                    if (!isFBTermMissing && row["FbPaymtTermsCode"].ToString().Trim() == string.Empty) //|| (row["FbPaymtTermsCode"].ToString().Trim() != "TP" && row["FbPaymtTermsCode"].ToString().Trim() != "PP" && row["FbPaymtTermsCode"].ToString().Trim() != "CC"))
                    {
                        isFBTermMissing = true;                        
                    }
                    try
                    {
                        if (!isDateOutOfRange)
                        {
                            if (row["FbCreatDtm"].ToString().Trim() != string.Empty)
                                if (Convert.ToDateTime(row["FbCreatDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["FbCreatDtm"].ToString().Trim()) > (bl.GetServerDate()))
                                    isDateOutOfRange = true;//throw new Exception();
                            if (row["LmPkupActualDtm"].ToString().Trim() != string.Empty)
                                if (Convert.ToDateTime(row["LmPkupActualDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["LmPkupActualDtm"].ToString().Trim()) > bl.GetServerDate().AddDays(30))
                                    isDateOutOfRange = true;//throw new Exception();
                            if (row["LmAtaDtm"].ToString().Trim() != string.Empty)
                                if (Convert.ToDateTime(row["LmAtaDtm"].ToString().Trim()) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(row["LmAtaDtm"].ToString().Trim()) > bl.GetServerDate().AddDays(30))
                                    isDateOutOfRange = true;//throw new Exception();
                        }
                    }
                    catch
                    {
                        retval = false;
                        message = "There are some invalid date or date format, please review this Freight Bill Key : " + row["FbKey"].ToString().Trim();
                        break;
                        //isDateValidated = false;
                    }
                }
            }
            //if (toolStripMenuMultiCurr.Checked && retval)
            //{
            //    foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
            //    {
            //        if (row["Facsimile01"].ToString().Trim() == string.Empty)
            //        {
            //            retval = false;
            //            message = "There are some blank Line item description which would cause error, please review this batch.";
            //            break;
            //        }
            //    }
            //}
            if (retval)
            {
                retval = isInvAmtEqualVendInvAmt();
            }
            else
                MessageBox.Show(message, "Quality Assurance");

            if (isInvoicekeyBlank && MessageBox.Show("There are some blank invoice key.\nDo you wish to proceed?", "Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.No)
                retval = false;
            if (retval && isFrghtblKeyBlank && MessageBox.Show("There are some blank freight bill key.\nDo you wish to proceed?", "Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.No)
                retval = false;
            if (retval && isFBTermMissing && MessageBox.Show("There are some blank or invalid terms, please review this batch.\nDo you wish to proceed?", "Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.No)
                retval = false;
            if (retval && isDateOutOfRange && MessageBox.Show("There are some invalid dates, please review this batch.\nDo you wish to proceed?", "Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.No)
                retval = false;
            return retval;
        }
        
        private void isQAControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TraxDETextBox)
                    ((TraxDETextBox)control).IsQualityAssuranceForm = true;
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).IsQualityAssuranceForm = true;
                else if (control is GroupBox)
                    isQAControls(((GroupBox)control).Controls);
            }
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

            foreach (DataRow row in dsBatch.Tables["FrghtBl"].Rows)
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

        private void setAlphaNumeric()
        {
            if (dsOwnerKeyAlphaNumeric != null && dsOwnerKeyAlphaNumeric.Tables.Count > 0)
            {
                if (dsOwnerKeyAlphaNumeric.Tables[0].Select(string.Format("Owner_Key = '{0}'", MXXOwnerKey)).Count() > 0)
                {
                    DataRow rowTemp = dsOwnerKeyAlphaNumeric.Tables[0].Select(string.Format("Owner_Key = '{0}'", MXXOwnerKey))[0];
                    isInvoiceKeyAlphaNumeric = Convert.ToBoolean(rowTemp["Invoice"]);
                    isFreightBillKeyAlphaNumeric = Convert.ToBoolean(rowTemp["FreightBill"]);
                    isAccountAlphaNumeric = Convert.ToBoolean(rowTemp["Account"] == DBNull.Value ? 0 : rowTemp["Account"]);
                    isTaxNumberAlphaNumeric = Convert.ToBoolean(rowTemp["TaxNumber"] == DBNull.Value ? 0 : rowTemp["TaxNumber"]);
                    isVatRegAlphaNumeric = Convert.ToBoolean(rowTemp["VatReg"] == DBNull.Value ? 0 : rowTemp["VatReg"]);
                }
                else
                {
                    isInvoiceKeyAlphaNumeric = false;
                    isFreightBillKeyAlphaNumeric = false;
                    isAccountAlphaNumeric = false;
                    isTaxNumberAlphaNumeric = false;
                    isVatRegAlphaNumeric = false;
                }
            }
            else
            {
                isInvoiceKeyAlphaNumeric = false;
                isFreightBillKeyAlphaNumeric = false;
                isAccountAlphaNumeric = false;
                isTaxNumberAlphaNumeric = false;
                isVatRegAlphaNumeric = false;
            }
        
        }

        private void setDefaultControls()
        {
            foreach (Control control in grpBoxFreightBillX.Controls)
            {
                if (control is TraxDETextBox)
                {
                    ((TraxDETextBox)control).IsCorrectValue = true;
                    ((TraxDETextBox)control).updateBackColor();
                }
                else if (control is TraxDEMaskedTextBox)
                {
                    ((TraxDEMaskedTextBox)control).IsCorrectValue = true;
                    ((TraxDEMaskedTextBox)control).updateBackColor();
                }
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                        {
                            ((TraxDETextBox)controls).IsCorrectValue = true;
                            ((TraxDETextBox)controls).updateBackColor();
                        }
                        else if (controls is TraxDEMaskedTextBox)
                        {
                            ((TraxDEMaskedTextBox)controls).IsCorrectValue = true;
                            ((TraxDEMaskedTextBox)controls).updateBackColor();
                        }
                    }
                }
            }
        }        

        private void setFBTotalLable()
        {
            FBTotal = 0;
            if (dvInvoice.Count > 0)
            {
                foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"].ToString())))
                {
                    if (row["FbAmt"].ToString() != null && row["FbAmt"].ToString() != string.Empty)
                        FBTotal = FBTotal + Convert.ToDecimal(row["FbAmt"]);
                }
            }

            if (FBTotal != 0)
                lblFBTotal.Text = FBTotal.ToString("###,###,###,###.#0");
            else
                lblFBTotal.Text = "0.00";
            if (dvInvoice.Count > 0 && dvInvoice[0]["VendInvAmt"] != null && dvInvoice[0]["VendInvAmt"].ToString().Trim() != string.Empty && FBTotal == Convert.ToDecimal(dvInvoice[0]["VendInvAmt"]))
                lblFBTotal.ForeColor = Color.Black;
            else
                lblFBTotal.ForeColor = Color.Red;
            
        }

        private void setFBLnTotalLable()
        {
            FBLnTotal = 0;
            if (grdFBLine.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grdFBLine.Rows)
                {
                    if (row.Cells["FBLnChrgAmt"].Value != null && row.Cells["FBLnChrgAmt"].Value.ToString() != string.Empty)
                        FBLnTotal = FBLnTotal + Convert.ToDecimal(row.Cells["FBLnChrgAmt"].Value);
                }
            }
                
            if (FBLnTotal != 0)
                lblTotal.Text = FBLnTotal.ToString("###,###,###,###.#000");
            else
                lblTotal.Text = "0.0000";

            if (dvFreightBill.Count > 0 && dvFreightBill[0]["FbAmt"] != null && dvFreightBill[0]["FbAmt"].ToString().Trim() != string.Empty && FBLnTotal == Convert.ToDecimal(dvFreightBill[0]["FbAmt"]))
                lblTotal.ForeColor = Color.Black;
            else
                lblTotal.ForeColor = Color.Red;
        }

        private void setReadOnlyGridColumns(TraxDEDataGridView grd)
        {
            foreach (DataGridViewColumn column in grd.Columns)
            {
                if (column is TraxDEDataGridViewTextBoxColumn)
                {
                    if (column.Name == "InvoiceVendLabl" || column.Name == "InvoiceLocIdRemit" || column.Name == "FBLnLineItemNum" || column.Name == "FBLnChrgDesc" || column.Name == "InvoiceLocIdBlng" || column.Name == "InvPageNum" || (column.Name.Contains("T0") && !column.Name.Contains("FBLn")))
                        column.ReadOnly = true;
                    else if (column.Name == "FBLnFbId" || column.Name == "KeyIdentsFbId" || column.Name == "ProdDtlFbId")
                        column.Visible = false;
                    //else if (toolStripMenuMultiCurr.Checked && column.Name == "FBLnChrgAmt")
                    //    column.ReadOnly = true;
                    else
                        column.ReadOnly = false;
                }
            }
        }

        private void setVendorInfo()
        {
            if (dsBatch.Tables["Invoice"].Rows.Count <= 0)
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
                drVendorInfo["VendLabl"] = dsBatch.Tables["Invoice"].Rows[0]["VendLabl"].ToString();
                drVendorInfo["LocIdRemit"] = dsBatch.Tables["Invoice"].Rows[0]["LocIdRemit"].ToString();
                drVendorInfo["AlRemit1"] = dsBatch.Tables["Invoice"].Rows[0]["AlRemit1"].ToString();
                drVendorInfo["AlRemit2"] = dsBatch.Tables["Invoice"].Rows[0]["AlRemit2"].ToString();
                drVendorInfo["AlRemit3"] = dsBatch.Tables["Invoice"].Rows[0]["AlRemit3"].ToString();
                drVendorInfo["AlRemit4"] = dsBatch.Tables["Invoice"].Rows[0]["AlRemit4"].ToString();
                drVendorInfo["AlCityRemit"] = dsBatch.Tables["Invoice"].Rows[0]["AlCityRemit"].ToString();
                drVendorInfo["AlStateProvRemit"] = dsBatch.Tables["Invoice"].Rows[0]["AlStateProvRemit"].ToString();
                drVendorInfo["AlPostCodeRemit"] = dsBatch.Tables["Invoice"].Rows[0]["AlPostCodeRemit"].ToString();
                drVendorInfo["AlCntryCodeRemit"] = dsBatch.Tables["Invoice"].Rows[0]["AlCntryCodeRemit"].ToString();
            }
        }

        //private void setGuide()
        //{
        //    if (dvInvoice != null && dvInvoice.Count > 0)
        //    {
        //        this.guide = dvInvoice[0]["VendName"].ToString();//need to know what field
        //    }
        //    else
        //    {
        //        this.guide = string.Empty;
        //    }
        //}

        private void setIdentifier()
        {
            identifier = new string[dsKeyIdentifier.Tables[0].Rows.Count];
            for (int ctr = 0; dsKeyIdentifier.Tables[0].Rows.Count > ctr; ctr++)
            {
                identifier[ctr] = dsKeyIdentifier.Tables[0].Rows[ctr]["Identifier"].ToString();
            }
        }

        private void shortCutPress()
        {
            switch (keystroke)
            {

                case "1":
                    {
                        txtLocIdRemit.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "2":
                    {
                        txtLocIdBlng.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "3":
                    {
                        txtInvKey.Focus();
                        break;
                    }
                case "4":
                    {
                        txtVendTaxKey.Focus();
                        break;
                    }
                case "5":
                    {
                        txtAcctNumVendBlng.Focus();
                        break;
                    }
                case "6":
                    {
                        txtInvBeforeTaxAmt.Focus();
                        break;
                    }
                case "7":
                    {
                        txtInvTaxAmt.Focus();
                        break;
                    }
                case "8":
                    {
                        txtVendInvAmt.Focus();
                        break;
                    }
                case "9":
                    {
                        txtInvCurrencyQual.Focus();
                        break;
                    }
                case "10":
                    {
                        mtxtInvCreatDtm.Focus();
                        break;
                    }
                case "11":
                    {
                        mtxtInvDueDtm.Focus();
                        break;
                    }
                case "12":
                    {
                        txtInvType.Focus();
                        break;
                    }
                case "13":
                    {
                        txtFbKey.Focus();
                        break;
                    }
                case "14":
                    {
                        txtFbAmt.Focus();
                        break;
                    }
                case "15":
                    {
                        txtFbPageNum.Focus();
                        break;
                    }
                case "16":
                    {
                        txtFbSpotQuoteKey.Focus();
                        break;
                    }
                case "17":
                    {
                        txtFbSpotQuoteAmt.Focus();
                        break;
                    }
                case "18":
                    {
                        txtFbType.Focus();
                        break;
                    }
                case "19":
                    {
                        txtFbPreAuthType.Focus();
                        break;
                    }

                case "20":
                    {
                        txtFbPreAuthAmt.Focus();
                        break;
                    }

                case "21":
                    {
                        txtFbPreAuthBy.Focus();
                        break;
                    }
                case "22":
                    {
                        txtCustTaxKey.Focus();
                        break;
                    }
                case "23":
                    {
                        txtFbTaxPcnt.Focus();
                        break;
                    }
                case "24":
                    {
                        txtIncoTerms.Focus();
                        break;
                    }
                case "25":
                    {
                        mtxtFbExchDtm.Focus();
                        break;
                    }
                case "26":
                    {
                        txtFbExchRate.Focus();
                        break;
                    }
                case "27":
                    {
                        txtShipperInv.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "28":
                    {
                        txtShipperBOL.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "29":
                    {
                        txtShipperCom.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "30":
                    {
                        txtConsigneeInv.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "31":
                    {
                        txtConsigneeBOL.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "32":
                    {
                        txtConsigneeCom.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "33":
                    {
                        txtPickUpAdd.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "34":
                    {
                        txtDeliveryAdd.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "35":
                    {
                        txtStopOffLoc.Focus();
                        SendKeys.Send("{ENTER}");
                        break;
                    }
                case "36":
                    {
                        txtTerm.Focus();
                        break;
                    }
                case "37":
                    {
                        txtVendTariff.Focus();
                        break;
                    }
                case "38":
                    {
                        txtVendSrvcName.Focus();
                        break;
                    }
                case "39":
                    {
                        txtVendSrvcType.Focus();
                        break;
                    }
                case "40":
                    {
                        txtVendSrvcZone.Focus();
                        break;
                    }
                case "41":
                    {
                        txtVendSrvcScope.Focus();
                        break;
                    }
                case "42":
                    {
                        txtActualWt.Focus();
                        break;
                    }
                case "43":
                    {
                        txtFnclWt.Focus();
                        break;
                    }
                case "44":
                    {
                        txtFbWtQual.Focus();
                        break;
                    }
                case "45":
                    {
                        txtFbFnclWtQual.Focus();
                        break;
                    }
                case "46":
                    {
                        txtPieces.Focus();
                        break;
                    }
                case "47":
                    {
                        txtPkgType.Focus();
                        break;
                    }
                case "48":
                    {
                        txtDistance.Focus();
                        break;
                    }
                case "49":
                    {
                        txtLmDistQual.Focus();
                        break;
                    }
                case "50":
                    {
                        txtFbDim.Focus();
                        break;
                    }

                case "51":
                    {
                        txtFbDimFactor.Focus();
                        break;
                    }
                case "52":
                    {
                        txtFbDimQual.Focus();
                        break;
                    }
                case "53":
                    {
                        txtFbVol.Focus();
                        break;
                    }
                case "54":
                    {
                        txtFbVolQual.Focus();
                        break;
                    }
                case "55":
                    {
                        txtInterLineField1.Focus();
                        break;
                    }
                case "56":
                    {
                        txtInterLineField3.Focus();
                        break;
                    }
                case "57":
                    {
                        txtInterLineField2.Focus();
                        break;
                    }
                case "58":
                    {
                        txtFbRcvdBy.Focus();
                        break;
                    }
                case "59":
                    {
                        txtFbExtRoute.Focus();
                        break;
                    }
                case "60":
                    {
                        txtFbLoadMeters.Focus();
                        break;
                    }

                case "61":
                    {
                        mtxtPickUp.Focus();
                        break;
                    }
                case "62":
                    {
                        mtxtDelivered.Focus();
                        break;
                    }
                case "63":
                    {
                        txtVesselName.Focus();
                        break;
                    }
                case "64":
                    {
                        grdCntnrs.Focus();
                        if (grdCntnrs.Enabled && grdCntnrs.AllowUserToAddRows)
                            grdCntnrs.CurrentCell = grdCntnrs.Rows[grdCntnrs.Rows.Count - 1].Cells["CntnrsCntnrKey"];
                        break;
                    }
                case "65":
                    {
                        grdCntnrs.Focus();
                        if (grdCntnrs.Enabled && grdCntnrs.AllowUserToAddRows)
                            grdCntnrs.CurrentCell = grdCntnrs.Rows[grdCntnrs.Rows.Count - 1].Cells["CntnrsCntnrType"];
                        break;
                    }
                case "66":
                    {
                        grdCntnrs.Focus();
                        if (grdCntnrs.Enabled && grdCntnrs.AllowUserToAddRows)
                            grdCntnrs.CurrentCell = grdCntnrs.Rows[grdCntnrs.Rows.Count - 1].Cells["CntnrsCntnrSize"];
                        break;
                    }
                case "67":
                    {
                        grdCntnrs.Focus();
                        if (grdCntnrs.Enabled && grdCntnrs.AllowUserToAddRows)
                            grdCntnrs.CurrentCell = grdCntnrs.Rows[grdCntnrs.Rows.Count - 1].Cells["CntnrsCntnrQty"];
                        break;
                    }
                case "68":
                    {
                        grdKeyIdents.Focus();
                        if (grdKeyIdents.Enabled && grdKeyIdents.AllowUserToAddRows)
                            grdKeyIdents.CurrentCell = grdKeyIdents.Rows[grdKeyIdents.Rows.Count - 1].Cells["KeyIdentsKeyQual"];
                        break;
                    }
                case "69":
                    {
                        grdKeyIdents.Focus();
                        if (grdKeyIdents.Enabled && grdKeyIdents.AllowUserToAddRows)
                            grdKeyIdents.CurrentCell = grdKeyIdents.Rows[grdKeyIdents.Rows.Count - 1].Cells["KeyIdentsKeyVal"];
                        break;
                    }
                case "70":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnPcsCnt"];
                        break;
                    }

                case "71":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLnChrgCode"];
                        break;
                    }
                case "72":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnVendDesc"];
                        break;
                    }
                case "73":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnCmdtyClass"];
                        break;
                    }
                case "74":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnQtyLabl"];
                        break;
                    }
                case "75":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnRateAmt"];
                        break;
                    }
                case "76":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnRateType"];
                        break;
                    }
                case "77":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnRateUntLabl"];
                        break;
                    }
                case "78":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLnActualWt"];
                        break;
                    }
                case "79":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLnRateAsWt"];
                        break;
                    }
                case "80":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnPkgType"];
                        break;
                    }

                case "81":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLnDim"];
                        break;
                    }
                case "82":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLnDimQual"];
                        break;
                    }
                case "83":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLnVol"];
                        break;
                    }
                case "84":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnLnVolQual"];
                        break;
                    }
                case "85":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnChrgAmt"];
                        break;
                    }
                case "86":
                    {
                        grdFBLine.Focus();
                        if (grdFBLine.Enabled && grdFBLine.AllowUserToAddRows)
                            grdFBLine.CurrentCell = grdFBLine.Rows[grdFBLine.Rows.Count - 1].Cells["FBLnTaxable"];                        
                        break;
                    }
                case "87":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdKey"];
                        break;
                    }
                case "88":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdLine"];
                        break;
                    }
                case "89":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdType"];
                        break;
                    }
                case "90":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdDesc"];
                        break;
                    }
                case "91":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdUnitAmt"];
                        break;
                    }

                case "92":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdUnitCurr"];
                        break;
                    }
                case "93":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdTotalAmt"];
                        break;
                    }
                case "94":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdTotalCurr"];
                        break;
                    }
                case "95":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdPcsCnt"];
                        break;
                    }
                case "96":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdGrossWt"];
                        break;
                    }
                case "97":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdNetWt"];
                        break;
                    }
                case "98":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdWtUom"];
                        break;
                    }
                case "99":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdDim"];
                        break;
                    }
                case "100":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdDimUom"];
                        break;
                    }
                case "101":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdVol"];
                        break;
                    }
                case "102":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlProdVolUom"];
                        break;
                    }
                case "103":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlHazmatFlag"];
                        break;
                    }
                case "104":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlHazmatType"];
                        break;
                    }
                case "105":
                    {
                        grdProdDtl.Focus();
                        if (grdProdDtl.Enabled && grdProdDtl.AllowUserToAddRows)
                            grdProdDtl.CurrentCell = grdProdDtl.Rows[grdProdDtl.Rows.Count - 1].Cells["ProdDtlOverDimFlag"];
                        break;
                    }
                case "271":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "1");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "272":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "2");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "273":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "3");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "274":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "4");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "275":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "5");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "276":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "6");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "277":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "7");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "278":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "8");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "279":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "9");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "270":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_INVOICE, "0");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "281":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "1");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "282":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "2");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "283":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "3");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "284":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "4");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "285":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "5");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "286":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "6");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "287":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "7");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "288":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "8");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "289":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "9");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "280":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_BOL, "0");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "291":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "1");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "292":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "2");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "293":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "3");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "294":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "4");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "295":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "5");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "296":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "6");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "297":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "7");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "298":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "8");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "299":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "9");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "290":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.SHIPPER_COM_INV, "0");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "301":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "1");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "302":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "2");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "303":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "3");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "304":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "4");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "305":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "5");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "306":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "6");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "307":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "7");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "308":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "8");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "309":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "9");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "300":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_INVOICE, "0");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "311":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "1");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "312":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "2");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "313":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "3");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "314":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "4");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "315":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "5");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "316":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "6");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "317":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "7");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "318":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "8");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "319":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "9");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "310":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_BOL, "0");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "321":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "1");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "322":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "2");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "323":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "3");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "324":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "4");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "325":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "5");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "326":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "6");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "327":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "7");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "328":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "8");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "329":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "9");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "320":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfoSC frmAddressInfoSC = new frmAddressInfoSC(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.CONSIGNEE_COM_INV, "0");
                            frmAddressInfoSC.ShowDialog();
                            bindAddress();
                        }
                        break;
                    }
                case "331":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "1");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "332":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "2");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "333":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "3");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "334":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "4");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "335":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "5");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "336":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "6");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "337":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "7");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "338":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "8");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "339":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "9");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "330":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.PICKUP, DeleteTriggered, "0");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "341":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "1");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "342":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "2");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "343":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "3");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "344":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "4");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "345":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "5");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "346":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "6");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "347":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "7");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "348":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "8");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "349":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "9");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "340":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.DELIVERY, DeleteTriggered, "0");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "351":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "1");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "352":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "2");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "353":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "3");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "354":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "4");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "355":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "5");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "356":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "6");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "357":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "7");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "358":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "8");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "359":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "9");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
                case "350":
                    {
                        if (currentFormState == CommonEnum.FormState.EDIT_STATE && dvFreightBill.Count > 0)
                        {
                            frmAddressInfo frmAddressInfo = new frmAddressInfo(dsBatch.Tables["Addrs"], dvFreightBill[0]["FbId"].ToString(), CommonEnum.AddressType.STOP_OFF, DeleteTriggered, "0");
                            frmAddressInfo.ShowDialog();
                            DeleteTriggered = frmAddressInfo.DeleteTriggered;
                            bindAddress();
                        }
                        break;
                    }
            }
        }

        private void updateAcctNumVendBlng(string value)
        {
            if (dvInvoice.Count > 0)
                foreach (DataRow rowFB in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", dvInvoice[0]["InvId"].ToString().Trim())))
                    if (rowFB.RowState != DataRowState.Deleted)
                        rowFB["AcctNumVendBlng"] = value;
        }

        private void updateCounter()
        {
            DataView dvFB = new DataView();
            DataView dvFBLn = new DataView();
            dvFB.Table = dsBatch.Tables["FrghtBl"];
            dvFBLn.Table = dsBatch.Tables["FBLn"];
            if (dvFB.Count > 0)
            {
                for (int i = 0; i < dsBatch.Tables["Invoice"].DefaultView.Count; i++)
                {
                    dvFB.RowFilter = string.Format("InvId = '{0}'", dsBatch.Tables["Invoice"].DefaultView[i]["InvId"].ToString().Trim());
                    dsBatch.Tables["Invoice"].DefaultView[i]["InvFbCnt"] = dvFB.Count;
                    dsBatch.Tables["Invoice"].DefaultView[i]["InvPageNum"] = DBNull.Value;
                    try
                    {
                        foreach (DataRow dr in dvFB.ToTable().Rows)
                        {
                            if (dr["FbPageNum"] != DBNull.Value)
                            {
                                if (dsBatch.Tables["Invoice"].DefaultView[i]["InvPageNum"] == DBNull.Value || Convert.ToInt16(dsBatch.Tables["Invoice"].DefaultView[i]["InvPageNum"]) > Convert.ToInt16(dr["FbPageNum"]))
                                {
                                    dsBatch.Tables["Invoice"].DefaultView[i]["InvPageNum"] = dr["FbPageNum"];
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            if (dvFBLn.Count > 0)
            {
                for (int i = 0; i < dsBatch.Tables["FrghtBl"].DefaultView.Count; i++)
                {
                    dvFBLn.RowFilter = string.Format("FbId = '{0}'", dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim());
                    dsBatch.Tables["FrghtBl"].DefaultView[i]["FbLnCnt"] = dvFBLn.Count;
                }
            }
        }

        private void updateCurrencyQual(string value)
        {
            if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                dsBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"] = value;
            foreach (DataRow rowInvoice in dsBatch.Tables["Invoice"].Rows)
                if (rowInvoice.RowState != DataRowState.Deleted)
                    rowInvoice["InvCurrencyQual"] = value;
            foreach (DataRow rowFB in dsBatch.Tables["FrghtBl"].Rows)
                if (rowFB.RowState != DataRowState.Deleted)
                    rowFB["FbCurrencyQual"] = value;
            foreach (DataRow rowFBLn in dsBatch.Tables["FBLn"].Rows)
                if (rowFBLn.RowState != DataRowState.Deleted)
                {
                    rowFBLn["CurrencyQual"] = value;
                    if (toolStripMenuMultiCurr.Checked)
                    {
                        rowFBLn["ExchRate"] = "1.0000000";
                        rowFBLn["LocalAmt"] = Convert.ToDecimal(rowFBLn["ChrgAmt"]).ToString("###,###,###,###.#000");
                        rowFBLn["LocalCurrencyQual"] = rowFBLn["CurrencyQual"];
                        //rowFBLn["T004"] = "1.0000000";
                        //rowFBLn["T005"] = rowFBLn["CurrencyQual"];
                    }
                }
        }

        private void updateFBValues()
        {
            for (int i = 0; i < dsBatch.Tables["FrghtBl"].DefaultView.Count; i++)
            {
                dsBatch.Tables["FrghtBl"].DefaultView[i]["FbFrghtAmt"] = DBNull.Value;
                dsBatch.Tables["FrghtBl"].DefaultView[i]["FbAccAmt"] = DBNull.Value;
                dsBatch.Tables["FrghtBl"].DefaultView[i]["FbDscntAmt"] = DBNull.Value;
                dsBatch.Tables["FrghtBl"].DefaultView[i]["FbTaxAmt"] = DBNull.Value;
                /*
                foreach (DataRow fbLnRow in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim())))
                {
                    if (fbLnRow["Cat"].ToString().Trim() == "ACCESSORIAL")
                        dsBatch.Tables["FrghtBl"].DefaultView[i]["FbAccAmt"] = Convert.ToDecimal(dsBatch.Tables["FrghtBl"].DefaultView[i]["FbAccAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "FREIGHT")
                        dsBatch.Tables["FrghtBl"].DefaultView[i]["FbFrghtAmt"] = Convert.ToDecimal(dsBatch.Tables["FrghtBl"].DefaultView[i]["FbFrghtAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "DISCOUNT")
                        dsBatch.Tables["FrghtBl"].DefaultView[i]["FbDscntAmt"] = Convert.ToDecimal(dsBatch.Tables["FrghtBl"].DefaultView[i]["FbDscntAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);

                    else if (fbLnRow["Cat"].ToString().Trim() == "TAX")
                        dsBatch.Tables["FrghtBl"].DefaultView[i]["FbTaxAmt"] = Convert.ToDecimal(dsBatch.Tables["FrghtBl"].DefaultView[i]["FbTaxAmt"]) + Convert.ToDecimal(fbLnRow["ChrgAmt"]);
                }*/
            }
        }

        private void updateInvKey(string value, string invID)
        {
            foreach (DataRow rowFB in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", invID)))
                if (rowFB.RowState != DataRowState.Deleted)
                    rowFB["InvKey"] = value;            
        }

        private void updateFBLnLineNumber()
        {
            int ID;
            int i;            
            for(int fb = 0; fb < dsBatch.Tables["FrghtBl"].DefaultView.Count; fb++)
            {                
                i = 0;
                foreach (DataRow row in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", dsBatch.Tables["FrghtBl"].DefaultView[fb]["FbId"].ToString().Trim())))
                {
                    row.BeginEdit();
                    ID = Convert.ToInt32(row["LineItemNum"]);
                    if (ID != i + 1)
                        row["LineItemNum"] = i + 1;
                    row.EndEdit();
                    i++;
                }

                //KeyIdents
                i = 0;
                foreach (DataRow row in dsBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}'", dsBatch.Tables["FrghtBl"].DefaultView[fb]["FbId"].ToString().Trim())))
                {
                    row.BeginEdit();
                    ID = Convert.ToInt32(row["KeyNum"]);
                    if (ID != i + 1)
                        row["KeyNum"] = i + 1;
                    row.EndEdit();
                    i++;
                }

                //Addrs Pickup
                i = 0;
                foreach (DataRow row in dsBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}' AND AddrCat = '{1}' ", dsBatch.Tables["FrghtBl"].DefaultView[fb]["FbId"].ToString().Trim(),CommonEnum.AddressType.PICKUP.ToString())))
                {
                    row.BeginEdit();
                    ID = Convert.ToInt32(row["AddrNum"]);
                    if (ID != i + 1)
                        row["AddrNum"] = i + 1;
                    row.EndEdit();
                    i++;
                }
                //Addrs Delivery
                i = 0;
                foreach (DataRow row in dsBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}' AND AddrCat = '{1}' ", dsBatch.Tables["FrghtBl"].DefaultView[fb]["FbId"].ToString().Trim(), CommonEnum.AddressType.DELIVERY.ToString())))
                {
                    row.BeginEdit();
                    ID = Convert.ToInt32(row["AddrNum"]);
                    if (ID != i + 1)
                        row["AddrNum"] = i + 1;
                    row.EndEdit();
                    i++;
                }
                //Addrs Stop off
                i = 0;
                foreach (DataRow row in dsBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}' AND AddrCat = '{1}'", dsBatch.Tables["FrghtBl"].DefaultView[fb]["FbId"].ToString().Trim(), CommonEnum.AddressType.STOP_OFF.ToString())))
                {
                    row.BeginEdit();
                    ID = Convert.ToInt32(row["AddrNum"]);
                    if (ID != i + 1)
                        row["AddrNum"] = i + 1;
                    row.EndEdit();
                    i++;
                }

                //Cntnrs
                i = 0;
                foreach (DataRow row in dsBatch.Tables["Cntnrs"].Select(string.Format("FbId = '{0}'", dsBatch.Tables["FrghtBl"].DefaultView[fb]["FbId"].ToString().Trim())))
                {
                    row.BeginEdit();
                    ID = Convert.ToInt32(row["CntnrNum"]);
                    if (ID != i + 1)
                        row["CntnrNum"] = i + 1;
                    row.EndEdit();
                    i++;
                }
                //ProdDtl
                i = 0;
                foreach (DataRow row in dsBatch.Tables["ProdDtl"].Select(string.Format("FbId = '{0}'", dsBatch.Tables["FrghtBl"].DefaultView[fb]["FbId"].ToString().Trim())))
                {
                    row.BeginEdit();
                    ID = Convert.ToInt32(row["ProdInstNum"]);
                    if (ID != i + 1)
                        row["ProdInstNum"] = i + 1;
                    row.EndEdit();
                    i++;
                }
            }
        }

        private void updateFBID()
        {
            ArrayList updateList = new ArrayList();
            for (int i = 0; i < dsBatch.Tables["FrghtBl"].DefaultView.Count; i++)
            {
                int length = dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim().Length;
                int ID = Convert.ToInt32(dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim().Substring(length - 4, 4));
                if (ID != i + 1)
                {
                    //updateList.Add(new IDUpdate(dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim(), dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim().Substring(0, length - 4) + (i + 1).ToString().PadLeft(4, '0')));
                    //dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"] = dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim().Substring(0, length - 4) + (i + 1).ToString().PadLeft(4, '0');
                    updateList.Add(new IDUpdate(dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"].ToString().Trim(), (i + 1).ToString().PadLeft(4, '0')));
                    dsBatch.Tables["FrghtBl"].DefaultView[i]["FbId"] = (i + 1).ToString().PadLeft(4, '0');
                }
            }
            foreach (object item in updateList)
            {                
                ArrayList IndexListFBLn = new ArrayList();
                ArrayList IndexListKeyIdents = new ArrayList();
                ArrayList IndexListAddrs = new ArrayList();
                ArrayList IndexListCntnrs = new ArrayList();
                ArrayList IndexListProdDtl = new ArrayList();
                //FBLn
                foreach (DataRow row in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", ((IDUpdate)item).OriginalID)))
                    IndexListFBLn.Add(dsBatch.Tables["FBLn"].Rows.IndexOf(row));
                foreach (object index in IndexListFBLn)
                    dsBatch.Tables["FBLn"].Rows[(int)index]["FbId"] = ((IDUpdate)item).NewID;
                //KeyIdents
                foreach (DataRow row in dsBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}'", ((IDUpdate)item).OriginalID)))
                    IndexListKeyIdents.Add(dsBatch.Tables["KeyIdents"].Rows.IndexOf(row));
                foreach (object index in IndexListKeyIdents)
                    dsBatch.Tables["KeyIdents"].Rows[(int)index]["FbId"] = ((IDUpdate)item).NewID;
                //Addrs
                foreach (DataRow row in dsBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}'", ((IDUpdate)item).OriginalID)))
                    IndexListAddrs.Add(dsBatch.Tables["Addrs"].Rows.IndexOf(row));
                foreach (object index in IndexListAddrs)
                    dsBatch.Tables["Addrs"].Rows[(int)index]["FbId"] = ((IDUpdate)item).NewID;
                //Cntnrs
                foreach (DataRow row in dsBatch.Tables["Cntnrs"].Select(string.Format("FbId = '{0}'", ((IDUpdate)item).OriginalID)))
                    IndexListCntnrs.Add(dsBatch.Tables["Cntnrs"].Rows.IndexOf(row));
                foreach (object index in IndexListCntnrs)
                    dsBatch.Tables["Cntnrs"].Rows[(int)index]["FbId"] = ((IDUpdate)item).NewID;
                //ProdDtl
                foreach (DataRow row in dsBatch.Tables["ProdDtl"].Select(string.Format("FbId = '{0}'", ((IDUpdate)item).OriginalID)))
                    IndexListProdDtl.Add(dsBatch.Tables["ProdDtl"].Rows.IndexOf(row));
                foreach (object index in IndexListProdDtl)
                    dsBatch.Tables["ProdDtl"].Rows[(int)index]["FbId"] = ((IDUpdate)item).NewID;
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
                ArrayList IndexList = new ArrayList();
                ArrayList IndexListFXI = new ArrayList();
                foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", ((IDUpdate)item).OriginalID)))
                    IndexList.Add(dsBatch.Tables["FrghtBl"].Rows.IndexOf(row));                
                foreach (object index in IndexList)
                    dsBatch.Tables["FrghtBl"].Rows[(int)index]["InvId"] = ((IDUpdate)item).NewID;                
            }
        }

        private void updateTempID()
        {            
            string ID = "FBLL" + MXXOwnerKey.Remove(3, 1) + "MXX" + MXXDatabase;
            foreach (DataRow row in dsBatch.Tables["FrghtBl"].DefaultView.Table.Select("LEN(FbId)=4"))
            {
                row["FbId"] = ID + row["FbId"].ToString();
            }
            foreach (DataRow row in dsBatch.Tables["FBLn"].DefaultView.Table.Select("LEN(FbId)=4"))
            {
                row["FbId"] = ID + row["FbId"].ToString();
            }
            foreach (DataRow row in dsBatch.Tables["KeyIdents"].DefaultView.Table.Select("LEN(FbId)=4"))//KeyIdents
            {
                row["FbId"] = ID + row["FbId"].ToString();
            }
            foreach (DataRow row in dsBatch.Tables["Addrs"].DefaultView.Table.Select("LEN(FbId)=4"))//Addrs
            {
                row["FbId"] = ID + row["FbId"].ToString();
            }
            foreach (DataRow row in dsBatch.Tables["Cntnrs"].DefaultView.Table.Select("LEN(FbId)=4"))//Cntnrs
            {
                row["FbId"] = ID + row["FbId"].ToString();
            }
            foreach (DataRow row in dsBatch.Tables["ProdDtl"].DefaultView.Table.Select("LEN(FbId)=4"))//ProdDtl
            {
                row["FbId"] = ID + row["FbId"].ToString();
            }            
        }

        private void updateQADataSet()
        {
            if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
            {
                DataSet dsQAConfig = new DataSet();
                DataView dv = new DataView();
                dsQAConfig = bl.selectQAConfig(dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString(), dsBatch.Tables["InvBat"].Rows[0]["VendLabl"].ToString(), MXXDatabase);
                grdKeyIdents.QAValidationColumns.Clear();
                grdCntnrs.QAValidationColumns.Clear();
                grdProdDtl.QAValidationColumns.Clear();
                grdFBLine.QAValidationColumns.Clear();
                this.txtInvCurrencyQual.Items.Add(string.Empty);
                if (dsQAConfig != null && (dsQAConfig.Tables[0].Rows.Count > 0 || dsQAConfig.Tables[1].Rows.Count > 0))
                {
                    if (dsQAConfig.Tables[1].Rows.Count > 0)                    
                        dv.Table = dsQAConfig.Tables[1];                    
                    else                    
                        dv.Table = dsQAConfig.Tables[0];

                    dv.RowFilter = "NodeName = 'INVOICE'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRow dr in dv.ToTable().Rows)
                        {
                            foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                            {
                                row[dr["FieldName"].ToString()] = DBNull.Value;
                                if (dr["FieldName"].ToString() == "InvAmt")
                                    row["VendInvAmt"] = DBNull.Value;
                            }
                        }
                        foreach (Control control in grpBoxInnerInvoice)
                        {
                            if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != null)
                            {
                                dv.RowFilter = string.Format("NodeName = 'INVOICE' AND FieldName = '{0}'", ((TraxDETextBox)control).DatabaseFieldLink == "VendInvAmt" ? "InvAmt" : ((TraxDETextBox)control).DatabaseFieldLink);
                                if (dv.Count > 0)
                                    ((TraxDETextBox)control).IsValidateValue = true;
                            }
                            else if (control is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)control).DatabaseFieldLink != null)
                            {
                                dv.RowFilter = string.Format("NodeName = 'INVOICE' AND FieldName = '{0}'", ((TraxDEMaskedTextBox)control).DatabaseFieldLink);
                                if (dv.Count > 0)
                                    ((TraxDEMaskedTextBox)control).IsValidateValue = true;
                            }
                        }
                    }
                    dv.RowFilter = "NodeName = 'FRGHT_BL'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRow dr in dv.ToTable().Rows)
                        {
                            foreach (DataRow row in dsBatch.Tables["FrghtBl"].Rows)
                            {
                                row[dr["FieldName"].ToString()] = DBNull.Value;
                            }
                        }

                        foreach (Control control in grpBoxFreightBillX.Controls)
                        {
                            if (control is TraxDETextBox && ((TraxDETextBox)control).DatabaseFieldLink != null)
                            {
                                dv.RowFilter = string.Format("NodeName = 'FRGHT_BL' AND FieldName = '{0}'", ((TraxDETextBox)control).DatabaseFieldLink);
                                if (dv.Count > 0)
                                    ((TraxDETextBox)control).IsValidateValue = true;
                            }
                            else if (control is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)control).DatabaseFieldLink != null)
                            {
                                dv.RowFilter = string.Format("NodeName = 'FRGHT_BL' AND FieldName = '{0}'", ((TraxDEMaskedTextBox)control).DatabaseFieldLink);
                                if (dv.Count > 0)
                                    ((TraxDEMaskedTextBox)control).IsValidateValue = true;
                            }
                            else if (control is GroupBox)
                            {
                                foreach (Control controls in ((GroupBox)control).Controls)
                                {
                                    if (controls is TraxDETextBox && ((TraxDETextBox)controls).DatabaseFieldLink != null)
                                    {
                                        dv.RowFilter = string.Format("NodeName = 'FRGHT_BL' AND FieldName = '{0}'", ((TraxDETextBox)controls).DatabaseFieldLink);
                                        if (dv.Count > 0)
                                            ((TraxDETextBox)controls).IsValidateValue = true;
                                    }
                                    else if (controls is TraxDEMaskedTextBox && ((TraxDEMaskedTextBox)controls).DatabaseFieldLink != null)
                                    {

                                        dv.RowFilter = string.Format("NodeName = 'FRGHT_BL' AND FieldName = '{0}'", ((TraxDEMaskedTextBox)controls).DatabaseFieldLink);
                                        if (dv.Count > 0)
                                            ((TraxDEMaskedTextBox)controls).IsValidateValue = true;
                                    }
                                }
                            }
                        }
                    }
                    dv.RowFilter = "NodeName = 'KEY_IDENTS'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRow dr in dv.ToTable().Rows)
                        {
                            grdKeyIdents.QAValidationColumns.Add("KeyIdents" + dr["FieldName"].ToString());
                            foreach (DataRow row in dsBatch.Tables["KeyIdents"].Rows)
                            {
                                if (row[dr["FieldName"].ToString()].ToString() == dr["ValueName"].ToString())
                                {
                                    row["KeyVal"] = DBNull.Value;
                                }
                            }
                        }
                    }
                    dv.RowFilter = "NodeName = 'FB_LN'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRow dr in dv.ToTable().Rows)
                        {
                            grdFBLine.QAValidationColumns.Add("FBLn" + dr["FieldName"].ToString());
                            foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                            {                                
                                row[dr["FieldName"].ToString()] = DBNull.Value;                                
                            }                            
                        }
                    }
                    //CNTNRS
                    dv.RowFilter = "NodeName = 'CNTNRS'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRow dr in dv.ToTable().Rows)
                        {
                            grdCntnrs.QAValidationColumns.Add("Cntnrs" + dr["FieldName"].ToString());
                            foreach (DataRow row in dsBatch.Tables["Cntnrs"].Rows)
                            {                                
                                row[dr["FieldName"].ToString()] = DBNull.Value;                                
                            }                            
                        }
                    }
                    
                    //PROD_DTL
                    dv.RowFilter = "NodeName = 'PROD_DTL'";
                    if (dv.Count > 0)
                    {
                        foreach (DataRow dr in dv.ToTable().Rows)
                        {
                            grdProdDtl.QAValidationColumns.Add("ProdDtl" + dr["FieldName"].ToString());
                            foreach (DataRow row in dsBatch.Tables["ProdDtl"].Rows)
                            {
                                row[dr["FieldName"].ToString()] = DBNull.Value;                                
                            }                            
                        }
                    }
                }
                else
                {
                    this.txtInvKey.IsValidateValue = true;
                    this.txtVendInvAmt.IsValidateValue = true;
                    this.mtxtInvCreatDtm.IsValidateValue = true;
                    //this.txtInvCurrencyQual.IsValidateValue = true;
                    foreach (DataRow dr in dsBatch.Tables["Invoice"].Rows)
                    {
                        dr["VendInvAmt"] = DBNull.Value;
                        dr["InvAmt"] = DBNull.Value;
                        dr["InvKey"] = DBNull.Value;
                        dr["InvCreatDtm"] = DBNull.Value;
                        dr["InvCurrencyQual"] = DBNull.Value;
                    }                    
                }                
                bindTree();
                grdCntnrs.updateBackColor();
                grdCntnrs.Refresh();
                grdProdDtl.updateBackColor();
                grdProdDtl.Refresh();
                grdKeyIdents.updateBackColor();
                grdKeyIdents.Refresh();
                grdFBLine.updateBackColor();
                grdFBLine.Refresh();                
            }
        }        

        private void populateGroupBox()
        {
            //innerInvoice
            this.grpBoxInnerInvoice[0] = this.traxDELabel37;
            this.grpBoxInnerInvoice[1] = this.txtInvType;
            this.grpBoxInnerInvoice[2] = this.txtInvBeforeTaxAmt;
            this.grpBoxInnerInvoice[3] = this.txtInvTaxAmt;
            this.grpBoxInnerInvoice[4] = this.lblLocIdBlng;
            this.grpBoxInnerInvoice[5] = this.traxDELabel6;
            this.grpBoxInnerInvoice[6] = this.lblInvKey;
            this.grpBoxInnerInvoice[7] = this.txtInvKey;
            this.grpBoxInnerInvoice[8] = this.traxDELabel4;
            this.grpBoxInnerInvoice[9] = this.txtLocIdBlng;
            this.grpBoxInnerInvoice[10] = this.lblInvCreatDtm;
            this.grpBoxInnerInvoice[11] = this.txtVendTaxKey;
            this.grpBoxInnerInvoice[12] = this.mtxtInvCreatDtm;
            this.grpBoxInnerInvoice[13] = this.lblVendLabl;
            this.grpBoxInnerInvoice[14] = this.traxDELabel5;
            this.grpBoxInnerInvoice[15] = this.lblLocIdRemit;
            this.grpBoxInnerInvoice[16] = this.txtVendInvAmt;
            this.grpBoxInnerInvoice[17] = this.txtLocIdRemit;
            this.grpBoxInnerInvoice[18] = this.lblVendInvAmt;
            this.grpBoxInnerInvoice[19] = this.txtVendLabl;
            this.grpBoxInnerInvoice[20] = this.lblInvCurrencyQual;
            this.grpBoxInnerInvoice[21] = this.txtInvCurrencyQual;
            this.grpBoxInnerInvoice[22] = this.traxDELabel3;
            this.grpBoxInnerInvoice[23] = this.txtAcctNumVendBlng;
            this.grpBoxInnerInvoice[24] = this.mtxtInvDueDtm;
            this.grpBoxInnerInvoice[25] = this.lblAcctNumVendBlng;
            this.grpBoxInnerInvoice[26] = this.txtCustTaxKey;
            this.grpBoxInnerInvoice[27] = this.traxDELabel38;

            //grpBoxFreightBill
            this.grpBoxFreightBill[0] = this.pnlProdDtl;
            this.grpBoxFreightBill[1] = this.txtFbTaxPcnt;
            this.grpBoxFreightBill[2] = this.traxDELabel31;
            this.grpBoxFreightBill[3] = this.traxDELabel29;
            this.grpBoxFreightBill[4] = this.txtFbPreAuthAmt;
            this.grpBoxFreightBill[5] = this.traxDELabel28;
            this.grpBoxFreightBill[6] = this.traxDELabel27;
            this.grpBoxFreightBill[7] = this.txtFbPreAuthType;
            this.grpBoxFreightBill[8] = this.traxDELabel20;
            this.grpBoxFreightBill[9] = this.txtFbSpotQuoteAmt;
            this.grpBoxFreightBill[10] = this.traxDELabel18;
            this.grpBoxFreightBill[11] = this.txtFbSpotQuoteKey;
            this.grpBoxFreightBill[12] = this.traxDELabel19;
            this.grpBoxFreightBill[13] = this.traxDELabel16;
            this.grpBoxFreightBill[14] = this.txtFbAmt;
            this.grpBoxFreightBill[15] = this.lblFbAmt;
            this.grpBoxFreightBill[16] = this.txtFbKey;
            this.grpBoxFreightBill[17] = this.lblFbKey;
            this.grpBoxFreightBill[18] = this.lblFBAmountTotal;
            this.grpBoxFreightBill[19] = this.txtIncoTerms;
            this.grpBoxFreightBill[20] = this.traxDELabel30;
            this.grpBoxFreightBill[21] = this.txtFbPreAuthBy;
            this.grpBoxFreightBill[22] = this.mtxtFbExchDtm;
            this.grpBoxFreightBill[23] = this.txtFbType;
            this.grpBoxFreightBill[24] = this.traxDELabel26;
            this.grpBoxFreightBill[25] = this.pnlCntnrs;
            this.grpBoxFreightBill[26] = this.pnlFXI;
            this.grpBoxFreightBill[27] = this.txtFbExchRate;
            this.grpBoxFreightBill[28] = this.txtFbPageNum;
            this.grpBoxFreightBill[29] = this.txtFbDim;
            this.grpBoxFreightBill[30] = this.txtFbFnclWtQual;
            this.grpBoxFreightBill[31] = this.txtFbDimFactor;
            this.grpBoxFreightBill[32] = this.traxDELabel25;
            this.grpBoxFreightBill[33] = this.traxDELabel21;
            this.grpBoxFreightBill[34] = this.txtFbExtRoute;
            this.grpBoxFreightBill[35] = this.traxDELabel22;
            this.grpBoxFreightBill[36] = this.txtVesselName;
            this.grpBoxFreightBill[37] = this.traxDELabel17;
            this.grpBoxFreightBill[38] = this.txtFbLoadMeters;
            this.grpBoxFreightBill[39] = this.traxDELabel15;
            this.grpBoxFreightBill[40] = this.txtStopOffLoc;
            this.grpBoxFreightBill[41] = this.txtFbRcvdBy;
            this.grpBoxFreightBill[42] = this.traxDELabel13;
            this.grpBoxFreightBill[43] = this.txtVendTariff;
            this.grpBoxFreightBill[44] = this.traxDELabel12;
            this.grpBoxFreightBill[45] = this.txtPickUpAdd;
            this.grpBoxFreightBill[46] = this.traxDELabel11;
            this.grpBoxFreightBill[47] = this.txtDeliveryAdd;
            this.grpBoxFreightBill[48] = this.traxDELabel10;
            this.grpBoxFreightBill[49] = this.txtVendSrvcZone;
            this.grpBoxFreightBill[50] = this.traxDELabel9;
            this.grpBoxFreightBill[51] = this.txtFbVolQual;
            this.grpBoxFreightBill[52] = this.txtFbVol;
            this.grpBoxFreightBill[53] = this.traxDELabel8;
            this.grpBoxFreightBill[54] = this.txtFbDimQual;
            this.grpBoxFreightBill[55] = this.traxDELabel7;
            this.grpBoxFreightBill[56] = this.txtVendSrvcScope;
            this.grpBoxFreightBill[57] = this.traxDELabel2;
            this.grpBoxFreightBill[58] = this.txtVendSrvcType;
            this.grpBoxFreightBill[59] = this.traxDELabel1;
            //this.grpBoxFreightBill62] = this.grpBoxFbLine;
            this.grpBoxFreightBill[60] = this.txtLmDistQual;
            this.grpBoxFreightBill[61] = this.txtFbWtQual;
            this.grpBoxFreightBill[62] = this.lblFBTotal;
            this.grpBoxFreightBill[63] = this.mtxtDelivered;
            this.grpBoxFreightBill[64] = this.mtxtPickUp;
            this.grpBoxFreightBill[65] = this.lblDelivered;
            this.grpBoxFreightBill[66] = this.lblPickUp;
            //this.grpBoxFreightBill[70] = this.grpBoxConsigneeAddress;
            this.grpBoxFreightBill[67] = this.txtInterLineField3;
            this.grpBoxFreightBill[68] = this.txtInterLineField2;
            this.grpBoxFreightBill[69] = this.txtInterLineField1;
            this.grpBoxFreightBill[70] = this.txtTerm;
            this.grpBoxFreightBill[71] = this.txtVendSrvcName;
            this.grpBoxFreightBill[72] = this.txtDistance;
            this.grpBoxFreightBill[73] = this.txtPieces;
            this.grpBoxFreightBill[74] = this.txtPkgType;
            this.grpBoxFreightBill[75] = this.txtFnclWt;
            this.grpBoxFreightBill[76] = this.txtActualWt;
            this.grpBoxFreightBill[77] = this.lblInterLineField;
            this.grpBoxFreightBill[78] = this.lblDistance;
            this.grpBoxFreightBill[79] = this.lblPkgType;
            this.grpBoxFreightBill[80] = this.lblFnclWt;
            this.grpBoxFreightBill[81] = this.lblActualWt;
            this.grpBoxFreightBill[82] = this.lblService;
            this.grpBoxFreightBill[83] = this.lblTerm;
            this.grpBoxFreightBill[84] = this.traxDELabel14;
            this.grpBoxFreightBill[85] = this.ddlSQCurrencyQual;
            this.grpBoxFreightBill[86] = this.lblSQCurrencyQual;
        }

        //private bool deleteTempFiles()
        //{
        //    //delete temp files
        //    bool retval = false;
        //    string folder = string.Format("{0}{1}", Environment.SystemDirectory.Split('\\')[0], "\\TempGuideline");


        //    if (Directory.Exists(folder))
        //        try
        //        {
        //            Directory.Delete(folder, true);
        //            retval = true;
        //        }
        //        catch
        //        {
        //            throw new Exception("Please close all open guidelines.");
        //        }
        //    else
        //        retval = true;
        //    return retval;
        //}

       

        //private void addGuide()
        //{
        //    DSBatch.Tables["KeyIdents"].Rows.Add(DSBatch.Tables["KeyIdents"].NewRow());
        //    dvKeyIdents[0]["KeyQual"] = "DEG";
        //    dvKeyIdents[0]["KeyVal"] = this.guide;
        //}
        #endregion         

    }
}
