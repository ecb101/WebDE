using FormControls;
namespace DEAppWS
{
    partial class frmDataEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataEntry));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBoxInvoice = new System.Windows.Forms.GroupBox();
            this.lblInvoiceCount = new FormControls.TraxDELabel();
            this.lblInvoiceCounter = new FormControls.TraxDELabel();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.grdInvoice = new FormControls.TraxDEDataGridView();
            this.InvoiceInvId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceVendLabl = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceLocIdRemit = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvKey = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvCurrencyQual = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.InvoiceVendInvAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAcctIdVendBlng = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlRemit1 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlRemit2 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlRemit3 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlRemit4 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlCityRemit = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlStateProvRemit = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlPostCodeRemit = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAlCntryCodeRemit = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvFbCnt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvStat = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvCreatDtm = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.grpBoxImageGroup = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.lblSearch = new FormControls.TraxDELabel();
            this.grdImageGroup = new FormControls.TraxDEDataGridView();
            this.BatchNumber = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatchStatus = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.OwnerKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendSCAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.OwnerCode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSaveClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRestart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSendReview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.grpBoxFbLine = new System.Windows.Forms.GroupBox();
            this.grdFBLine = new FormControls.TraxDEDataGridView();
            this.FBLnFbId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnLineItemNum = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnPcsCnt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnLnChrgCode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnChrgDesc = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnFacsimile01 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnCmdtyClass = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnQtyLabl = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnRateAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnRateType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FBLnRateUntLabl = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnCat = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FBLnLnActualWt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnLnRateAsWt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnPkgType = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnChrgAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnCurrencyQual = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnT001 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnT002 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnT003 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FBLnT004 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnT005 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnFacsimile02 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLnT006 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.chkBoxMultipleCurr = new System.Windows.Forms.CheckBox();
            this.lblMultipleCurrency = new FormControls.TraxDELabel();
            this.btnDeleteFBLn = new System.Windows.Forms.Button();
            this.btnAddFBLn = new System.Windows.Forms.Button();
            this.grpBoxShipperAddress = new System.Windows.Forms.GroupBox();
            this.txtShipperCountry = new FormControls.TraxDETextBox();
            this.txtShipperZip = new FormControls.TraxDETextBox();
            this.txtShipperSt = new FormControls.TraxDETextBox();
            this.txtShipperCity = new FormControls.TraxDETextBox();
            this.txtShipperAddress2 = new FormControls.TraxDETextBox();
            this.txtShipperAddress1 = new FormControls.TraxDETextBox();
            this.txtShipperName2 = new FormControls.TraxDETextBox();
            this.txtShipperName1 = new FormControls.TraxDETextBox();
            this.lblShipperCountry = new FormControls.TraxDELabel();
            this.lblShipperZip = new FormControls.TraxDELabel();
            this.lblShipperAddress = new FormControls.TraxDELabel();
            this.lblShipperName = new FormControls.TraxDELabel();
            this.lblShipperSt = new FormControls.TraxDELabel();
            this.lblShipperCity = new FormControls.TraxDELabel();
            this.grpBoxConsigneeAddress = new System.Windows.Forms.GroupBox();
            this.txtConsigneeCountry = new FormControls.TraxDETextBox();
            this.txtConsigneeZip = new FormControls.TraxDETextBox();
            this.txtConsigneeSt = new FormControls.TraxDETextBox();
            this.txtConsigneeCity = new FormControls.TraxDETextBox();
            this.txtConsigneeAddress2 = new FormControls.TraxDETextBox();
            this.txtConsigneeAddress1 = new FormControls.TraxDETextBox();
            this.txtConsigneeName2 = new FormControls.TraxDETextBox();
            this.txtConsigneeName1 = new FormControls.TraxDETextBox();
            this.lblConsigneeCountry = new FormControls.TraxDELabel();
            this.lblConsigneeZip = new FormControls.TraxDELabel();
            this.lblConsigneeAddress = new FormControls.TraxDELabel();
            this.lblConsigneeName = new FormControls.TraxDELabel();
            this.lblConsigneeSt = new FormControls.TraxDELabel();
            this.lblConsigneeCity = new FormControls.TraxDELabel();
            this.btnAddFB = new System.Windows.Forms.Button();
            this.btnDeleteFB = new System.Windows.Forms.Button();
            this.grpBoxFreightBill = new System.Windows.Forms.GroupBox();
            this.grdFXI = new FormControls.TraxDEDataGridView();
            this.FbId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.VendLabl = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T001 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T002 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T003 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T004 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T005 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T006 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T007 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T008 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T009 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T010 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T011 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T012 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T013 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T014 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T015 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T016 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T017 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T018 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T019 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T020 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T021 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T022 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T023 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T024 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T025 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T026 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T027 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T028 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T029 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T030 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T031 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T032 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T033 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T034 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T035 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T036 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T037 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T038 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T039 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T040 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T041 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T042 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T043 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T044 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T045 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T046 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T047 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T048 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T049 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T050 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T051 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T052 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T053 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T054 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T055 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T056 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T057 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T058 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T059 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T060 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T061 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T062 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T063 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T064 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T065 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T066 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T067 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T068 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T069 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T070 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T071 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T072 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T073 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T074 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T075 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T076 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T077 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T078 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T079 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T080 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T081 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T082 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T083 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T084 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T085 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T086 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T087 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T088 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T089 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T090 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T091 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T092 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T093 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T094 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T095 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T096 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T097 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T098 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T099 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T100 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T101 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T102 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T103 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T104 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T105 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T106 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T107 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T108 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T109 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T110 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T111 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T112 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T113 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T114 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T115 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T116 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T117 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T118 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T119 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.T120 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.lblFBCount = new FormControls.TraxDELabel();
            this.lblFBCounter = new FormControls.TraxDELabel();
            this.lblFBAmountTotal = new FormControls.TraxDELabel();
            this.lblFBTotal = new FormControls.TraxDELabel();
            this.txtPriceLane = new FormControls.TraxDETextBox();
            this.txtLaneLabel = new FormControls.TraxDETextBox();
            this.lblLaneLabel = new FormControls.TraxDELabel();
            this.lblPriceLane = new FormControls.TraxDELabel();
            this.mtxtDelivered = new FormControls.TraxDEMaskedTextBox();
            this.mtxtPickUp = new FormControls.TraxDEMaskedTextBox();
            this.mtxtDate = new FormControls.TraxDEMaskedTextBox();
            this.lblTotal = new FormControls.TraxDELabel();
            this.lblFBAmount = new FormControls.TraxDELabel();
            this.lblDelivered = new FormControls.TraxDELabel();
            this.lblPickUp = new FormControls.TraxDELabel();
            this.txtInterLineField3 = new FormControls.TraxDETextBox();
            this.txtInterLineField2 = new FormControls.TraxDETextBox();
            this.txtCustRef1 = new FormControls.TraxDETextBox();
            this.txtCustRef2 = new FormControls.TraxDETextBox();
            this.txtInterLineField1 = new FormControls.TraxDETextBox();
            this.txtTerm = new FormControls.TraxDETextBox();
            this.txtServiceCode = new FormControls.TraxDETextBox();
            this.txtDistance = new FormControls.TraxDETextBox();
            this.txtPieces = new FormControls.TraxDETextBox();
            this.txtPkgType = new FormControls.TraxDETextBox();
            this.txtFnclWt = new FormControls.TraxDETextBox();
            this.txtActualWt = new FormControls.TraxDETextBox();
            this.lblInterLineField = new FormControls.TraxDELabel();
            this.lblCustRef2 = new FormControls.TraxDELabel();
            this.lblCustRef1 = new FormControls.TraxDELabel();
            this.lblDistance = new FormControls.TraxDELabel();
            this.lblPieces = new FormControls.TraxDELabel();
            this.lblPkgType = new FormControls.TraxDELabel();
            this.lblFnclWt = new FormControls.TraxDELabel();
            this.lblActualWt = new FormControls.TraxDELabel();
            this.lblService = new FormControls.TraxDELabel();
            this.lblTerm = new FormControls.TraxDELabel();
            this.lblDate = new FormControls.TraxDELabel();
            this.grdFreightBill = new FormControls.TraxDEDataGridView();
            this.FBInvId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBInvKey = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbKey = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbCurrencyQual = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FBFbAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbCreatDtm = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbPaymtTermsCode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBSrvcReqCode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlOrig1 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlOrig2 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlOrig3 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlOrig4 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlCityOrig = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlStateProvOrig = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlPostCodeOrig = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlCntryCodeOrig = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlDest1 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlDest2 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlDest3 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlDest4 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlCityDest = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlStateProvDest = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlPostCodeDest = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBAlCntryCodeDest = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbActualWt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbFnclWt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbPkgType = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbPcsCnt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLmDist = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBCaInfo1Raw = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBCaInfo2Raw = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBInterlineScac = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBInterlineQual = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBInterlineAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLmPkupActualDtm = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBLmAtaDtm = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbLnCnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FBVendLabl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FBAcctNumVendBlng = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBPriceLaneLabl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FBLmLaneLabl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FBFbFrghtAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbDscntAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbAccAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbTaxAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.grpBoxMode = new System.Windows.Forms.GroupBox();
            this.chkBoxFBLnAdd = new System.Windows.Forms.CheckBox();
            this.lblFBLnAdd = new FormControls.TraxDELabel();
            this.chkBoxFBAdd = new System.Windows.Forms.CheckBox();
            this.lblFBAdd = new FormControls.TraxDELabel();
            this.lblInvoiceAdd = new FormControls.TraxDELabel();
            this.lblAutosave = new FormControls.TraxDELabel();
            this.chkBoxInvoiceAdd = new System.Windows.Forms.CheckBox();
            this.lblMode2 = new FormControls.TraxDELabel();
            this.lblMode1 = new FormControls.TraxDELabel();
            this.radioSingleFB = new System.Windows.Forms.RadioButton();
            this.radioInvoiceFB = new System.Windows.Forms.RadioButton();
            this.grpBoxInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).BeginInit();
            this.grpBoxImageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.grpBoxFbLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBLine)).BeginInit();
            this.grpBoxShipperAddress.SuspendLayout();
            this.grpBoxConsigneeAddress.SuspendLayout();
            this.grpBoxFreightBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFXI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightBill)).BeginInit();
            this.grpBoxMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxInvoice
            // 
            this.grpBoxInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxInvoice.Controls.Add(this.lblInvoiceCount);
            this.grpBoxInvoice.Controls.Add(this.lblInvoiceCounter);
            this.grpBoxInvoice.Controls.Add(this.btnDeleteInvoice);
            this.grpBoxInvoice.Controls.Add(this.btnAddInvoice);
            this.grpBoxInvoice.Controls.Add(this.grdInvoice);
            this.grpBoxInvoice.Location = new System.Drawing.Point(450, 28);
            this.grpBoxInvoice.Name = "grpBoxInvoice";
            this.grpBoxInvoice.Size = new System.Drawing.Size(730, 165);
            this.grpBoxInvoice.TabIndex = 1;
            this.grpBoxInvoice.TabStop = false;
            this.grpBoxInvoice.Text = "Invoice";
            // 
            // lblInvoiceCount
            // 
            this.lblInvoiceCount.AutoSize = true;
            this.lblInvoiceCount.Location = new System.Drawing.Point(6, 68);
            this.lblInvoiceCount.Name = "lblInvoiceCount";
            this.lblInvoiceCount.Size = new System.Drawing.Size(73, 13);
            this.lblInvoiceCount.TabIndex = 76;
            this.lblInvoiceCount.Text = "Invoice Count";
            // 
            // lblInvoiceCounter
            // 
            this.lblInvoiceCounter.AutoSize = true;
            this.lblInvoiceCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceCounter.Location = new System.Drawing.Point(9, 91);
            this.lblInvoiceCounter.Name = "lblInvoiceCounter";
            this.lblInvoiceCounter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInvoiceCounter.Size = new System.Drawing.Size(27, 13);
            this.lblInvoiceCounter.TabIndex = 75;
            this.lblInvoiceCounter.Text = "0/0";
            this.lblInvoiceCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(6, 42);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(72, 23);
            this.btnDeleteInvoice.TabIndex = 0;
            this.btnDeleteInvoice.TabStop = false;
            this.btnDeleteInvoice.Text = "Delete";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(6, 14);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(72, 23);
            this.btnAddInvoice.TabIndex = 0;
            this.btnAddInvoice.Text = "Add";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // grdInvoice
            // 
            this.grdInvoice.AllowUserToAddRows = false;
            this.grdInvoice.AllowUserToDeleteRows = false;
            this.grdInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceInvId,
            this.InvoiceVendLabl,
            this.InvoiceLocIdRemit,
            this.InvoiceInvKey,
            this.InvoiceInvCurrencyQual,
            this.InvoiceVendInvAmt,
            this.InvoiceAcctIdVendBlng,
            this.InvoiceAlRemit1,
            this.InvoiceAlRemit2,
            this.InvoiceAlRemit3,
            this.InvoiceAlRemit4,
            this.InvoiceAlCityRemit,
            this.InvoiceAlStateProvRemit,
            this.InvoiceAlPostCodeRemit,
            this.InvoiceAlCntryCodeRemit,
            this.InvoiceInvFbCnt,
            this.InvoiceInvAmt,
            this.InvoiceInvStat,
            this.InvoiceInvCreatDtm});
            this.grdInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdInvoice.Location = new System.Drawing.Point(84, 14);
            this.grdInvoice.MultiSelect = false;
            this.grdInvoice.Name = "grdInvoice";
            this.grdInvoice.RowHeadersVisible = false;
            this.grdInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoice.Size = new System.Drawing.Size(640, 145);
            this.grdInvoice.TabIndex = 1;
            this.grdInvoice.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoice_CellDoubleClick);
            this.grdInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoice_CellEndEdit);
            this.grdInvoice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdInvoice_KeyPress);
            this.grdInvoice.SelectionChanged += new System.EventHandler(this.grdInvoice_SelectionChanged);
            // 
            // InvoiceInvId
            // 
            this.InvoiceInvId.DataPropertyName = "InvId";
            this.InvoiceInvId.HeaderText = "InvId";
            this.InvoiceInvId.Name = "InvoiceInvId";
            this.InvoiceInvId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.InvoiceInvId.Visible = false;
            // 
            // InvoiceVendLabl
            // 
            this.InvoiceVendLabl.DataPropertyName = "VendLabl";
            this.InvoiceVendLabl.HeaderText = "Vendor";
            this.InvoiceVendLabl.Name = "InvoiceVendLabl";
            this.InvoiceVendLabl.ReadOnly = true;
            this.InvoiceVendLabl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceVendLabl.Width = 80;
            // 
            // InvoiceLocIdRemit
            // 
            this.InvoiceLocIdRemit.DataPropertyName = "LocIdRemit";
            this.InvoiceLocIdRemit.HeaderText = "Remit ID";
            this.InvoiceLocIdRemit.Name = "InvoiceLocIdRemit";
            this.InvoiceLocIdRemit.ReadOnly = true;
            this.InvoiceLocIdRemit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvoiceInvKey
            // 
            this.InvoiceInvKey.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InvoiceInvKey.DataPropertyName = "InvKey";
            this.InvoiceInvKey.HeaderText = "Invoice Key";
            this.InvoiceInvKey.MaxInputLength = 50;
            this.InvoiceInvKey.Name = "InvoiceInvKey";
            this.InvoiceInvKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvoiceInvCurrencyQual
            // 
            this.InvoiceInvCurrencyQual.DataPropertyName = "InvCurrencyQual";
            this.InvoiceInvCurrencyQual.HeaderText = "Currency";
            this.InvoiceInvCurrencyQual.Name = "InvoiceInvCurrencyQual";
            this.InvoiceInvCurrencyQual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceInvCurrencyQual.Width = 60;
            // 
            // InvoiceVendInvAmt
            // 
            this.InvoiceVendInvAmt.DataPropertyName = "VendInvAmt";
            dataGridViewCellStyle1.Format = "C4";
            dataGridViewCellStyle1.NullValue = "0.0000";
            this.InvoiceVendInvAmt.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceVendInvAmt.HeaderText = "Invoice Amount";
            this.InvoiceVendInvAmt.Name = "InvoiceVendInvAmt";
            this.InvoiceVendInvAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvoiceAcctIdVendBlng
            // 
            this.InvoiceAcctIdVendBlng.DataPropertyName = "AcctNumVendBlng";
            this.InvoiceAcctIdVendBlng.HeaderText = "Account";
            this.InvoiceAcctIdVendBlng.MaxInputLength = 50;
            this.InvoiceAcctIdVendBlng.MinimumWidth = 100;
            this.InvoiceAcctIdVendBlng.Name = "InvoiceAcctIdVendBlng";
            this.InvoiceAcctIdVendBlng.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvoiceAlRemit1
            // 
            this.InvoiceAlRemit1.DataPropertyName = "AlRemit1";
            this.InvoiceAlRemit1.HeaderText = "AlRemit1";
            this.InvoiceAlRemit1.Name = "InvoiceAlRemit1";
            this.InvoiceAlRemit1.Visible = false;
            // 
            // InvoiceAlRemit2
            // 
            this.InvoiceAlRemit2.DataPropertyName = "AlRemit2";
            this.InvoiceAlRemit2.HeaderText = "AlRemit2";
            this.InvoiceAlRemit2.Name = "InvoiceAlRemit2";
            this.InvoiceAlRemit2.Visible = false;
            // 
            // InvoiceAlRemit3
            // 
            this.InvoiceAlRemit3.DataPropertyName = "AlRemit3";
            this.InvoiceAlRemit3.HeaderText = "AlRemit3";
            this.InvoiceAlRemit3.Name = "InvoiceAlRemit3";
            this.InvoiceAlRemit3.Visible = false;
            // 
            // InvoiceAlRemit4
            // 
            this.InvoiceAlRemit4.DataPropertyName = "AlRemit4";
            this.InvoiceAlRemit4.HeaderText = "AlRemit4";
            this.InvoiceAlRemit4.Name = "InvoiceAlRemit4";
            this.InvoiceAlRemit4.Visible = false;
            // 
            // InvoiceAlCityRemit
            // 
            this.InvoiceAlCityRemit.DataPropertyName = "AlCityRemit";
            this.InvoiceAlCityRemit.HeaderText = "AlCityRemit";
            this.InvoiceAlCityRemit.Name = "InvoiceAlCityRemit";
            this.InvoiceAlCityRemit.Visible = false;
            // 
            // InvoiceAlStateProvRemit
            // 
            this.InvoiceAlStateProvRemit.DataPropertyName = "AlStateProvRemit";
            this.InvoiceAlStateProvRemit.HeaderText = "AlStateProvRemit";
            this.InvoiceAlStateProvRemit.Name = "InvoiceAlStateProvRemit";
            this.InvoiceAlStateProvRemit.Visible = false;
            // 
            // InvoiceAlPostCodeRemit
            // 
            this.InvoiceAlPostCodeRemit.DataPropertyName = "AlPostCodeRemit";
            this.InvoiceAlPostCodeRemit.HeaderText = "AlPostCodeRemit";
            this.InvoiceAlPostCodeRemit.Name = "InvoiceAlPostCodeRemit";
            this.InvoiceAlPostCodeRemit.Visible = false;
            // 
            // InvoiceAlCntryCodeRemit
            // 
            this.InvoiceAlCntryCodeRemit.DataPropertyName = "AlCntryCodeRemit";
            this.InvoiceAlCntryCodeRemit.HeaderText = "AlCntryCodeRemit";
            this.InvoiceAlCntryCodeRemit.Name = "InvoiceAlCntryCodeRemit";
            this.InvoiceAlCntryCodeRemit.Visible = false;
            // 
            // InvoiceInvFbCnt
            // 
            this.InvoiceInvFbCnt.DataPropertyName = "InvFbCnt";
            this.InvoiceInvFbCnt.HeaderText = "InvFbCnt";
            this.InvoiceInvFbCnt.Name = "InvoiceInvFbCnt";
            this.InvoiceInvFbCnt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceInvFbCnt.Visible = false;
            // 
            // InvoiceInvAmt
            // 
            this.InvoiceInvAmt.DataPropertyName = "InvAmt";
            this.InvoiceInvAmt.HeaderText = "InvAmt";
            this.InvoiceInvAmt.Name = "InvoiceInvAmt";
            this.InvoiceInvAmt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceInvAmt.Visible = false;
            // 
            // InvoiceInvStat
            // 
            this.InvoiceInvStat.DataPropertyName = "InvStat";
            this.InvoiceInvStat.HeaderText = "InvStat";
            this.InvoiceInvStat.Name = "InvoiceInvStat";
            this.InvoiceInvStat.Visible = false;
            // 
            // InvoiceInvCreatDtm
            // 
            this.InvoiceInvCreatDtm.DataPropertyName = "InvCreatDtm";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.InvoiceInvCreatDtm.DefaultCellStyle = dataGridViewCellStyle2;
            this.InvoiceInvCreatDtm.HeaderText = "Date(mm/dd/yyyy)";
            this.InvoiceInvCreatDtm.MinimumWidth = 100;
            this.InvoiceInvCreatDtm.Name = "InvoiceInvCreatDtm";
            this.InvoiceInvCreatDtm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // grpBoxImageGroup
            // 
            this.grpBoxImageGroup.Controls.Add(this.btnRefresh);
            this.grpBoxImageGroup.Controls.Add(this.txtSearch);
            this.grpBoxImageGroup.Controls.Add(this.lblSearch);
            this.grpBoxImageGroup.Controls.Add(this.grdImageGroup);
            this.grpBoxImageGroup.Location = new System.Drawing.Point(12, 28);
            this.grpBoxImageGroup.Name = "grpBoxImageGroup";
            this.grpBoxImageGroup.Size = new System.Drawing.Size(311, 165);
            this.grpBoxImageGroup.TabIndex = 0;
            this.grpBoxImageGroup.TabStop = false;
            this.grpBoxImageGroup.Text = "Choose Batch";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(230, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(59, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(165, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search :";
            // 
            // grdImageGroup
            // 
            this.grdImageGroup.AllowUserToAddRows = false;
            this.grdImageGroup.AllowUserToDeleteRows = false;
            this.grdImageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdImageGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImageGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchNumber,
            this.BatchStatus,
            this.OwnerKey,
            this.VendSCAC,
            this.Operator,
            this.OwnerCode});
            this.grdImageGroup.Location = new System.Drawing.Point(6, 42);
            this.grdImageGroup.MultiSelect = false;
            this.grdImageGroup.Name = "grdImageGroup";
            this.grdImageGroup.ReadOnly = true;
            this.grdImageGroup.RowHeadersVisible = false;
            this.grdImageGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdImageGroup.Size = new System.Drawing.Size(299, 117);
            this.grdImageGroup.StandardTab = true;
            this.grdImageGroup.TabIndex = 2;
            this.grdImageGroup.SelectionChanged += new System.EventHandler(this.grdImageGroup_SelectionChanged);
            // 
            // BatchNumber
            // 
            this.BatchNumber.DataPropertyName = "Batch Number";
            this.BatchNumber.HeaderText = "Batch";
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.ReadOnly = true;
            this.BatchNumber.Width = 50;
            // 
            // BatchStatus
            // 
            this.BatchStatus.DataPropertyName = "Batch Status";
            this.BatchStatus.HeaderText = "Status";
            this.BatchStatus.Name = "BatchStatus";
            this.BatchStatus.ReadOnly = true;
            this.BatchStatus.Width = 60;
            // 
            // OwnerKey
            // 
            this.OwnerKey.DataPropertyName = "Owner Key";
            this.OwnerKey.HeaderText = "OwnerKey";
            this.OwnerKey.Name = "OwnerKey";
            this.OwnerKey.ReadOnly = true;
            this.OwnerKey.Visible = false;
            // 
            // VendSCAC
            // 
            this.VendSCAC.DataPropertyName = "Vendor SCAC";
            this.VendSCAC.HeaderText = "SCAC";
            this.VendSCAC.Name = "VendSCAC";
            this.VendSCAC.ReadOnly = true;
            this.VendSCAC.Width = 70;
            // 
            // Operator
            // 
            this.Operator.DataPropertyName = "Operator";
            this.Operator.HeaderText = "Operator";
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            this.Operator.Visible = false;
            // 
            // OwnerCode
            // 
            this.OwnerCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OwnerCode.DataPropertyName = "OwnerCode";
            this.OwnerCode.HeaderText = "Client";
            this.OwnerCode.Name = "OwnerCode";
            this.OwnerCode.ReadOnly = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonEdit,
            this.toolStripSeparator1,
            this.toolStripButtonSaveClose,
            this.toolStripButtonSave,
            this.toolStripButtonRestart,
            this.toolStripButtonSendReview,
            this.toolStripSeparator2,
            this.toolStripButtonCancel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1192, 25);
            this.toolStrip.TabIndex = 2;
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonStart.Text = "S&tart";
            this.toolStripButtonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonStart.ToolTipText = "Start Data Entry for a Batch";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(29, 22);
            this.toolStripButtonEdit.Text = "&Edit";
            this.toolStripButtonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEdit.ToolTipText = "Edit Batch";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSaveClose
            // 
            this.toolStripButtonSaveClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSaveClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveClose.Image")));
            this.toolStripButtonSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveClose.Name = "toolStripButtonSaveClose";
            this.toolStripButtonSaveClose.Size = new System.Drawing.Size(65, 22);
            this.toolStripButtonSaveClose.Text = "Save/Cl&ose";
            this.toolStripButtonSaveClose.Click += new System.EventHandler(this.toolStripButtonSaveClose_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonSave.Text = "&Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonRestart
            // 
            this.toolStripButtonRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRestart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRestart.Image")));
            this.toolStripButtonRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRestart.Name = "toolStripButtonRestart";
            this.toolStripButtonRestart.Size = new System.Drawing.Size(47, 22);
            this.toolStripButtonRestart.Text = "&Restart";
            this.toolStripButtonRestart.ToolTipText = "Restart Batch";
            this.toolStripButtonRestart.Click += new System.EventHandler(this.toolStripButtonRestart_Click);
            // 
            // toolStripButtonSendReview
            // 
            this.toolStripButtonSendReview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSendReview.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSendReview.Image")));
            this.toolStripButtonSendReview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendReview.Name = "toolStripButtonSendReview";
            this.toolStripButtonSendReview.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonSendReview.Text = "Se&nd";
            this.toolStripButtonSendReview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSendReview.ToolTipText = "Send for Review";
            this.toolStripButtonSendReview.Click += new System.EventHandler(this.toolStripButtonSendReview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(43, 22);
            this.toolStripButtonCancel.Text = "&Cancel";
            this.toolStripButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCancel.ToolTipText = "Cancel Updates";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // grpBoxFbLine
            // 
            this.grpBoxFbLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxFbLine.Controls.Add(this.grdFBLine);
            this.grpBoxFbLine.Controls.Add(this.chkBoxMultipleCurr);
            this.grpBoxFbLine.Controls.Add(this.lblMultipleCurrency);
            this.grpBoxFbLine.Controls.Add(this.btnDeleteFBLn);
            this.grpBoxFbLine.Controls.Add(this.btnAddFBLn);
            this.grpBoxFbLine.Location = new System.Drawing.Point(6, 354);
            this.grpBoxFbLine.Name = "grpBoxFbLine";
            this.grpBoxFbLine.Size = new System.Drawing.Size(1156, 145);
            this.grpBoxFbLine.TabIndex = 21;
            this.grpBoxFbLine.TabStop = false;
            this.grpBoxFbLine.Text = "Line Item";
            // 
            // grdFBLine
            // 
            this.grdFBLine.AllowUserToAddRows = false;
            this.grdFBLine.AllowUserToDeleteRows = false;
            this.grdFBLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFBLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFBLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FBLnFbId,
            this.FBLnLineItemNum,
            this.FBLnPcsCnt,
            this.FBLnLnChrgCode,
            this.FBLnChrgDesc,
            this.FBLnFacsimile01,
            this.FBLnCmdtyClass,
            this.FBLnQtyLabl,
            this.FBLnRateAmt,
            this.FBLnRateType,
            this.FBLnRateUntLabl,
            this.FBLnCat,
            this.FBLnLnActualWt,
            this.FBLnLnRateAsWt,
            this.FBLnPkgType,
            this.FBLnChrgAmt,
            this.FBLnCurrencyQual,
            this.FBLnT001,
            this.FBLnT002,
            this.FBLnT003,
            this.FBLnT004,
            this.FBLnT005,
            this.FBLnFacsimile02,
            this.FBLnT006});
            this.grdFBLine.Location = new System.Drawing.Point(72, 8);
            this.grdFBLine.MultiSelect = false;
            this.grdFBLine.Name = "grdFBLine";
            this.grdFBLine.RowHeadersVisible = false;
            this.grdFBLine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFBLine.Size = new System.Drawing.Size(1076, 131);
            this.grdFBLine.TabIndex = 88;
            this.grdFBLine.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFBLine_CellEndEdit);
            // 
            // FBLnFbId
            // 
            this.FBLnFbId.DataPropertyName = "FbId";
            this.FBLnFbId.HeaderText = "FbId";
            this.FBLnFbId.Name = "FBLnFbId";
            this.FBLnFbId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnFbId.Visible = false;
            this.FBLnFbId.Width = 34;
            // 
            // FBLnLineItemNum
            // 
            this.FBLnLineItemNum.DataPropertyName = "LineItemNum";
            this.FBLnLineItemNum.HeaderText = "#";
            this.FBLnLineItemNum.Name = "FBLnLineItemNum";
            this.FBLnLineItemNum.ReadOnly = true;
            this.FBLnLineItemNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnLineItemNum.Width = 30;
            // 
            // FBLnPcsCnt
            // 
            this.FBLnPcsCnt.DataPropertyName = "PcsCnt";
            this.FBLnPcsCnt.HeaderText = "Pcs";
            this.FBLnPcsCnt.Name = "FBLnPcsCnt";
            this.FBLnPcsCnt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnPcsCnt.Width = 40;
            // 
            // FBLnLnChrgCode
            // 
            this.FBLnLnChrgCode.DataPropertyName = "LnChrgCode";
            this.FBLnLnChrgCode.HeaderText = "Chrg";
            this.FBLnLnChrgCode.Name = "FBLnLnChrgCode";
            this.FBLnLnChrgCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnLnChrgCode.Width = 50;
            // 
            // FBLnChrgDesc
            // 
            this.FBLnChrgDesc.DataPropertyName = "ChrgDesc";
            this.FBLnChrgDesc.HeaderText = "Chrg Desc";
            this.FBLnChrgDesc.Name = "FBLnChrgDesc";
            this.FBLnChrgDesc.ReadOnly = true;
            this.FBLnChrgDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnChrgDesc.Width = 160;
            // 
            // FBLnFacsimile01
            // 
            this.FBLnFacsimile01.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FBLnFacsimile01.DataPropertyName = "Facsimile01";
            this.FBLnFacsimile01.HeaderText = "Description";
            this.FBLnFacsimile01.MinimumWidth = 100;
            this.FBLnFacsimile01.Name = "FBLnFacsimile01";
            this.FBLnFacsimile01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FBLnCmdtyClass
            // 
            this.FBLnCmdtyClass.DataPropertyName = "CmdtyClass";
            this.FBLnCmdtyClass.HeaderText = "Cmdty";
            this.FBLnCmdtyClass.Name = "FBLnCmdtyClass";
            this.FBLnCmdtyClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnCmdtyClass.Width = 50;
            // 
            // FBLnQtyLabl
            // 
            this.FBLnQtyLabl.DataPropertyName = "QtyLabl";
            this.FBLnQtyLabl.HeaderText = "Qty Q";
            this.FBLnQtyLabl.Name = "FBLnQtyLabl";
            this.FBLnQtyLabl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnQtyLabl.Width = 60;
            // 
            // FBLnRateAmt
            // 
            this.FBLnRateAmt.DataPropertyName = "RateAmt";
            this.FBLnRateAmt.HeaderText = "Rate";
            this.FBLnRateAmt.Name = "FBLnRateAmt";
            this.FBLnRateAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnRateAmt.Width = 50;
            // 
            // FBLnRateType
            // 
            this.FBLnRateType.DataPropertyName = "RateType";
            this.FBLnRateType.HeaderText = "RTyp";
            this.FBLnRateType.Items.AddRange(new object[] {
            "",
            "PER",
            "PERCENT",
            "FLAT",
            "CWT",
            "MIN"});
            this.FBLnRateType.Name = "FBLnRateType";
            this.FBLnRateType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FBLnRateType.Width = 80;
            // 
            // FBLnRateUntLabl
            // 
            this.FBLnRateUntLabl.DataPropertyName = "RateUntLabl";
            this.FBLnRateUntLabl.HeaderText = "RtUnt";
            this.FBLnRateUntLabl.Name = "FBLnRateUntLabl";
            this.FBLnRateUntLabl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnRateUntLabl.Width = 50;
            // 
            // FBLnCat
            // 
            this.FBLnCat.DataPropertyName = "Cat";
            this.FBLnCat.HeaderText = "CAT";
            this.FBLnCat.Items.AddRange(new object[] {
            "",
            "TAX",
            "ACCESSORIAL",
            "DISCOUNT",
            "FREIGHT"});
            this.FBLnCat.Name = "FBLnCat";
            this.FBLnCat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FBLnCat.Width = 120;
            // 
            // FBLnLnActualWt
            // 
            this.FBLnLnActualWt.DataPropertyName = "LnActualWt";
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.FBLnLnActualWt.DefaultCellStyle = dataGridViewCellStyle3;
            this.FBLnLnActualWt.HeaderText = "Weight";
            this.FBLnLnActualWt.Name = "FBLnLnActualWt";
            this.FBLnLnActualWt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnLnActualWt.Width = 50;
            // 
            // FBLnLnRateAsWt
            // 
            this.FBLnLnRateAsWt.DataPropertyName = "LnRateAsWt";
            dataGridViewCellStyle4.Format = "N4";
            dataGridViewCellStyle4.NullValue = null;
            this.FBLnLnRateAsWt.DefaultCellStyle = dataGridViewCellStyle4;
            this.FBLnLnRateAsWt.HeaderText = "Wt As";
            this.FBLnLnRateAsWt.Name = "FBLnLnRateAsWt";
            this.FBLnLnRateAsWt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnLnRateAsWt.Width = 60;
            // 
            // FBLnPkgType
            // 
            this.FBLnPkgType.DataPropertyName = "PkgType";
            this.FBLnPkgType.HeaderText = "Pkg";
            this.FBLnPkgType.Name = "FBLnPkgType";
            this.FBLnPkgType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnPkgType.Width = 50;
            // 
            // FBLnChrgAmt
            // 
            this.FBLnChrgAmt.DataPropertyName = "ChrgAmt";
            dataGridViewCellStyle5.Format = "C4";
            dataGridViewCellStyle5.NullValue = "0.0000";
            this.FBLnChrgAmt.DefaultCellStyle = dataGridViewCellStyle5;
            this.FBLnChrgAmt.HeaderText = "Amount";
            this.FBLnChrgAmt.Name = "FBLnChrgAmt";
            this.FBLnChrgAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnChrgAmt.Width = 80;
            // 
            // FBLnCurrencyQual
            // 
            this.FBLnCurrencyQual.DataPropertyName = "CurrencyQual";
            this.FBLnCurrencyQual.HeaderText = "CurrencyQual";
            this.FBLnCurrencyQual.Name = "FBLnCurrencyQual";
            this.FBLnCurrencyQual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FBLnCurrencyQual.Visible = false;
            // 
            // FBLnT001
            // 
            this.FBLnT001.DataPropertyName = "T001";
            dataGridViewCellStyle6.NullValue = "0.0000";
            this.FBLnT001.DefaultCellStyle = dataGridViewCellStyle6;
            this.FBLnT001.HeaderText = "Ex Rate";
            this.FBLnT001.Name = "FBLnT001";
            this.FBLnT001.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnT001.Visible = false;
            this.FBLnT001.Width = 60;
            // 
            // FBLnT002
            // 
            this.FBLnT002.DataPropertyName = "T002";
            dataGridViewCellStyle7.Format = "C4";
            dataGridViewCellStyle7.NullValue = "0.0000";
            this.FBLnT002.DefaultCellStyle = dataGridViewCellStyle7;
            this.FBLnT002.HeaderText = "Amt";
            this.FBLnT002.Name = "FBLnT002";
            this.FBLnT002.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnT002.Visible = false;
            this.FBLnT002.Width = 60;
            // 
            // FBLnT003
            // 
            this.FBLnT003.DataPropertyName = "T003";
            this.FBLnT003.HeaderText = "Cur";
            this.FBLnT003.Name = "FBLnT003";
            this.FBLnT003.Visible = false;
            this.FBLnT003.Width = 60;
            // 
            // FBLnT004
            // 
            this.FBLnT004.DataPropertyName = "T004";
            this.FBLnT004.HeaderText = "Ex Rate 2";
            this.FBLnT004.Name = "FBLnT004";
            this.FBLnT004.Visible = false;
            // 
            // FBLnT005
            // 
            this.FBLnT005.DataPropertyName = "T005";
            this.FBLnT005.HeaderText = "Cur 2";
            this.FBLnT005.Name = "FBLnT005";
            this.FBLnT005.Visible = false;
            // 
            // FBLnFacsimile02
            // 
            this.FBLnFacsimile02.DataPropertyName = "Facsimile02";
            this.FBLnFacsimile02.HeaderText = "Original";
            this.FBLnFacsimile02.Name = "FBLnFacsimile02";
            this.FBLnFacsimile02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnFacsimile02.Visible = false;
            this.FBLnFacsimile02.Width = 80;
            // 
            // FBLnT006
            // 
            this.FBLnT006.DataPropertyName = "T006";
            this.FBLnT006.HeaderText = "IsMultipleCurrency";
            this.FBLnT006.Name = "FBLnT006";
            this.FBLnT006.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBLnT006.Visible = false;
            // 
            // chkBoxMultipleCurr
            // 
            this.chkBoxMultipleCurr.AutoSize = true;
            this.chkBoxMultipleCurr.Location = new System.Drawing.Point(6, 103);
            this.chkBoxMultipleCurr.Name = "chkBoxMultipleCurr";
            this.chkBoxMultipleCurr.Size = new System.Drawing.Size(15, 14);
            this.chkBoxMultipleCurr.TabIndex = 87;
            this.chkBoxMultipleCurr.UseVisualStyleBackColor = true;
            this.chkBoxMultipleCurr.CheckedChanged += new System.EventHandler(this.chkBoxMultipleCurr_CheckedChanged);
            // 
            // lblMultipleCurrency
            // 
            this.lblMultipleCurrency.AutoSize = true;
            this.lblMultipleCurrency.Location = new System.Drawing.Point(6, 74);
            this.lblMultipleCurrency.Name = "lblMultipleCurrency";
            this.lblMultipleCurrency.Size = new System.Drawing.Size(55, 26);
            this.lblMultipleCurrency.TabIndex = 86;
            this.lblMultipleCurrency.Text = "Multiple\r\nCurrency :";
            // 
            // btnDeleteFBLn
            // 
            this.btnDeleteFBLn.Location = new System.Drawing.Point(6, 48);
            this.btnDeleteFBLn.Name = "btnDeleteFBLn";
            this.btnDeleteFBLn.Size = new System.Drawing.Size(62, 23);
            this.btnDeleteFBLn.TabIndex = 0;
            this.btnDeleteFBLn.TabStop = false;
            this.btnDeleteFBLn.Text = "Delete";
            this.btnDeleteFBLn.UseVisualStyleBackColor = true;
            this.btnDeleteFBLn.Click += new System.EventHandler(this.btnDeleteFBLn_Click);
            // 
            // btnAddFBLn
            // 
            this.btnAddFBLn.Location = new System.Drawing.Point(6, 19);
            this.btnAddFBLn.Name = "btnAddFBLn";
            this.btnAddFBLn.Size = new System.Drawing.Size(62, 23);
            this.btnAddFBLn.TabIndex = 0;
            this.btnAddFBLn.Text = "Add";
            this.btnAddFBLn.UseVisualStyleBackColor = true;
            this.btnAddFBLn.Click += new System.EventHandler(this.btnAddFBLn_Click);
            // 
            // grpBoxShipperAddress
            // 
            this.grpBoxShipperAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperCountry);
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperZip);
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperSt);
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperCity);
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperAddress2);
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperAddress1);
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperName2);
            this.grpBoxShipperAddress.Controls.Add(this.txtShipperName1);
            this.grpBoxShipperAddress.Controls.Add(this.lblShipperCountry);
            this.grpBoxShipperAddress.Controls.Add(this.lblShipperZip);
            this.grpBoxShipperAddress.Controls.Add(this.lblShipperAddress);
            this.grpBoxShipperAddress.Controls.Add(this.lblShipperName);
            this.grpBoxShipperAddress.Controls.Add(this.lblShipperSt);
            this.grpBoxShipperAddress.Controls.Add(this.lblShipperCity);
            this.grpBoxShipperAddress.Location = new System.Drawing.Point(6, 117);
            this.grpBoxShipperAddress.Name = "grpBoxShipperAddress";
            this.grpBoxShipperAddress.Size = new System.Drawing.Size(461, 179);
            this.grpBoxShipperAddress.TabIndex = 5;
            this.grpBoxShipperAddress.TabStop = false;
            this.grpBoxShipperAddress.Text = "Shipper Address";
            // 
            // txtShipperCountry
            // 
            this.txtShipperCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperCountry.DatabaseFieldLink = "AlCntryCodeOrig";
            this.txtShipperCountry.Location = new System.Drawing.Point(335, 149);
            this.txtShipperCountry.MaxLength = 30;
            this.txtShipperCountry.Name = "txtShipperCountry";
            this.txtShipperCountry.Size = new System.Drawing.Size(117, 20);
            this.txtShipperCountry.TabIndex = 7;
            this.txtShipperCountry.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperCountry.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperCountry.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // txtShipperZip
            // 
            this.txtShipperZip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperZip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperZip.DatabaseFieldLink = "AlPostCodeOrig";
            this.txtShipperZip.Location = new System.Drawing.Point(193, 149);
            this.txtShipperZip.MaxLength = 30;
            this.txtShipperZip.Name = "txtShipperZip";
            this.txtShipperZip.Size = new System.Drawing.Size(81, 20);
            this.txtShipperZip.TabIndex = 6;
            this.txtShipperZip.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperZip.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperZip.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // txtShipperSt
            // 
            this.txtShipperSt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperSt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperSt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperSt.DatabaseFieldLink = "AlStateProvOrig";
            this.txtShipperSt.Location = new System.Drawing.Point(72, 149);
            this.txtShipperSt.MaxLength = 70;
            this.txtShipperSt.Name = "txtShipperSt";
            this.txtShipperSt.Size = new System.Drawing.Size(81, 20);
            this.txtShipperSt.TabIndex = 5;
            this.txtShipperSt.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperSt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperSt.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // txtShipperCity
            // 
            this.txtShipperCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperCity.DatabaseFieldLink = "AlCityOrig";
            this.txtShipperCity.Location = new System.Drawing.Point(72, 123);
            this.txtShipperCity.MaxLength = 70;
            this.txtShipperCity.Name = "txtShipperCity";
            this.txtShipperCity.Size = new System.Drawing.Size(380, 20);
            this.txtShipperCity.TabIndex = 4;
            this.txtShipperCity.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperCity.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperCity.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // txtShipperAddress2
            // 
            this.txtShipperAddress2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperAddress2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperAddress2.DatabaseFieldLink = "AlOrig4";
            this.txtShipperAddress2.Location = new System.Drawing.Point(72, 97);
            this.txtShipperAddress2.MaxLength = 70;
            this.txtShipperAddress2.Name = "txtShipperAddress2";
            this.txtShipperAddress2.Size = new System.Drawing.Size(380, 20);
            this.txtShipperAddress2.TabIndex = 3;
            this.txtShipperAddress2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperAddress2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperAddress2.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // txtShipperAddress1
            // 
            this.txtShipperAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperAddress1.DatabaseFieldLink = "AlOrig3";
            this.txtShipperAddress1.Location = new System.Drawing.Point(72, 71);
            this.txtShipperAddress1.MaxLength = 70;
            this.txtShipperAddress1.Name = "txtShipperAddress1";
            this.txtShipperAddress1.Size = new System.Drawing.Size(380, 20);
            this.txtShipperAddress1.TabIndex = 2;
            this.txtShipperAddress1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperAddress1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperAddress1.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // txtShipperName2
            // 
            this.txtShipperName2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperName2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperName2.DatabaseFieldLink = "AlOrig2";
            this.txtShipperName2.Location = new System.Drawing.Point(72, 45);
            this.txtShipperName2.MaxLength = 70;
            this.txtShipperName2.Name = "txtShipperName2";
            this.txtShipperName2.Size = new System.Drawing.Size(380, 20);
            this.txtShipperName2.TabIndex = 1;
            this.txtShipperName2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperName2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperName2.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // txtShipperName1
            // 
            this.txtShipperName1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtShipperName1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtShipperName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtShipperName1.DatabaseFieldLink = "AlOrig1";
            this.txtShipperName1.Location = new System.Drawing.Point(72, 19);
            this.txtShipperName1.MaxLength = 70;
            this.txtShipperName1.Name = "txtShipperName1";
            this.txtShipperName1.Size = new System.Drawing.Size(380, 20);
            this.txtShipperName1.TabIndex = 0;
            this.txtShipperName1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtShipperName1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtShipperName1.Enter += new System.EventHandler(this.txtShipperEnter);
            // 
            // lblShipperCountry
            // 
            this.lblShipperCountry.AutoSize = true;
            this.lblShipperCountry.Location = new System.Drawing.Point(280, 152);
            this.lblShipperCountry.Name = "lblShipperCountry";
            this.lblShipperCountry.Size = new System.Drawing.Size(49, 13);
            this.lblShipperCountry.TabIndex = 49;
            this.lblShipperCountry.Text = "Country :";
            // 
            // lblShipperZip
            // 
            this.lblShipperZip.AutoSize = true;
            this.lblShipperZip.Location = new System.Drawing.Point(159, 152);
            this.lblShipperZip.Name = "lblShipperZip";
            this.lblShipperZip.Size = new System.Drawing.Size(28, 13);
            this.lblShipperZip.TabIndex = 48;
            this.lblShipperZip.Text = "Zip :";
            // 
            // lblShipperAddress
            // 
            this.lblShipperAddress.AutoSize = true;
            this.lblShipperAddress.Location = new System.Drawing.Point(6, 74);
            this.lblShipperAddress.Name = "lblShipperAddress";
            this.lblShipperAddress.Size = new System.Drawing.Size(51, 13);
            this.lblShipperAddress.TabIndex = 47;
            this.lblShipperAddress.Text = "Address :";
            // 
            // lblShipperName
            // 
            this.lblShipperName.AutoSize = true;
            this.lblShipperName.Location = new System.Drawing.Point(6, 22);
            this.lblShipperName.Name = "lblShipperName";
            this.lblShipperName.Size = new System.Drawing.Size(38, 13);
            this.lblShipperName.TabIndex = 46;
            this.lblShipperName.Text = "Name:";
            // 
            // lblShipperSt
            // 
            this.lblShipperSt.AutoSize = true;
            this.lblShipperSt.Location = new System.Drawing.Point(6, 152);
            this.lblShipperSt.Name = "lblShipperSt";
            this.lblShipperSt.Size = new System.Drawing.Size(23, 13);
            this.lblShipperSt.TabIndex = 45;
            this.lblShipperSt.Text = "St :";
            // 
            // lblShipperCity
            // 
            this.lblShipperCity.AutoSize = true;
            this.lblShipperCity.Location = new System.Drawing.Point(6, 126);
            this.lblShipperCity.Name = "lblShipperCity";
            this.lblShipperCity.Size = new System.Drawing.Size(30, 13);
            this.lblShipperCity.TabIndex = 44;
            this.lblShipperCity.Text = "City :";
            // 
            // grpBoxConsigneeAddress
            // 
            this.grpBoxConsigneeAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeCountry);
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeZip);
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeSt);
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeCity);
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeAddress2);
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeAddress1);
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeName2);
            this.grpBoxConsigneeAddress.Controls.Add(this.txtConsigneeName1);
            this.grpBoxConsigneeAddress.Controls.Add(this.lblConsigneeCountry);
            this.grpBoxConsigneeAddress.Controls.Add(this.lblConsigneeZip);
            this.grpBoxConsigneeAddress.Controls.Add(this.lblConsigneeAddress);
            this.grpBoxConsigneeAddress.Controls.Add(this.lblConsigneeName);
            this.grpBoxConsigneeAddress.Controls.Add(this.lblConsigneeSt);
            this.grpBoxConsigneeAddress.Controls.Add(this.lblConsigneeCity);
            this.grpBoxConsigneeAddress.Location = new System.Drawing.Point(473, 117);
            this.grpBoxConsigneeAddress.Name = "grpBoxConsigneeAddress";
            this.grpBoxConsigneeAddress.Size = new System.Drawing.Size(461, 179);
            this.grpBoxConsigneeAddress.TabIndex = 6;
            this.grpBoxConsigneeAddress.TabStop = false;
            this.grpBoxConsigneeAddress.Text = "Consignee Address";
            // 
            // txtConsigneeCountry
            // 
            this.txtConsigneeCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeCountry.DatabaseFieldLink = "AlCntryCodeDest";
            this.txtConsigneeCountry.Location = new System.Drawing.Point(338, 149);
            this.txtConsigneeCountry.MaxLength = 30;
            this.txtConsigneeCountry.Name = "txtConsigneeCountry";
            this.txtConsigneeCountry.Size = new System.Drawing.Size(117, 20);
            this.txtConsigneeCountry.TabIndex = 7;
            this.txtConsigneeCountry.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeCountry.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeCountry.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // txtConsigneeZip
            // 
            this.txtConsigneeZip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeZip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeZip.DatabaseFieldLink = "AlPostCodeDest";
            this.txtConsigneeZip.Location = new System.Drawing.Point(196, 149);
            this.txtConsigneeZip.MaxLength = 30;
            this.txtConsigneeZip.Name = "txtConsigneeZip";
            this.txtConsigneeZip.Size = new System.Drawing.Size(81, 20);
            this.txtConsigneeZip.TabIndex = 6;
            this.txtConsigneeZip.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeZip.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeZip.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // txtConsigneeSt
            // 
            this.txtConsigneeSt.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeSt.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeSt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeSt.DatabaseFieldLink = "AlStateProvDest";
            this.txtConsigneeSt.Location = new System.Drawing.Point(75, 149);
            this.txtConsigneeSt.MaxLength = 70;
            this.txtConsigneeSt.Name = "txtConsigneeSt";
            this.txtConsigneeSt.Size = new System.Drawing.Size(81, 20);
            this.txtConsigneeSt.TabIndex = 5;
            this.txtConsigneeSt.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeSt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeSt.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // txtConsigneeCity
            // 
            this.txtConsigneeCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeCity.DatabaseFieldLink = "AlCityDest";
            this.txtConsigneeCity.Location = new System.Drawing.Point(75, 123);
            this.txtConsigneeCity.MaxLength = 70;
            this.txtConsigneeCity.Name = "txtConsigneeCity";
            this.txtConsigneeCity.Size = new System.Drawing.Size(380, 20);
            this.txtConsigneeCity.TabIndex = 4;
            this.txtConsigneeCity.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeCity.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeCity.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // txtConsigneeAddress2
            // 
            this.txtConsigneeAddress2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeAddress2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeAddress2.DatabaseFieldLink = "AlDest4";
            this.txtConsigneeAddress2.Location = new System.Drawing.Point(75, 97);
            this.txtConsigneeAddress2.MaxLength = 70;
            this.txtConsigneeAddress2.Name = "txtConsigneeAddress2";
            this.txtConsigneeAddress2.Size = new System.Drawing.Size(380, 20);
            this.txtConsigneeAddress2.TabIndex = 3;
            this.txtConsigneeAddress2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeAddress2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeAddress2.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // txtConsigneeAddress1
            // 
            this.txtConsigneeAddress1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeAddress1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeAddress1.DatabaseFieldLink = "AlDest3";
            this.txtConsigneeAddress1.Location = new System.Drawing.Point(75, 71);
            this.txtConsigneeAddress1.MaxLength = 70;
            this.txtConsigneeAddress1.Name = "txtConsigneeAddress1";
            this.txtConsigneeAddress1.Size = new System.Drawing.Size(380, 20);
            this.txtConsigneeAddress1.TabIndex = 2;
            this.txtConsigneeAddress1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeAddress1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeAddress1.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // txtConsigneeName2
            // 
            this.txtConsigneeName2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeName2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeName2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeName2.DatabaseFieldLink = "AlDest2";
            this.txtConsigneeName2.Location = new System.Drawing.Point(75, 45);
            this.txtConsigneeName2.MaxLength = 70;
            this.txtConsigneeName2.Name = "txtConsigneeName2";
            this.txtConsigneeName2.Size = new System.Drawing.Size(380, 20);
            this.txtConsigneeName2.TabIndex = 1;
            this.txtConsigneeName2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeName2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeName2.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // txtConsigneeName1
            // 
            this.txtConsigneeName1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConsigneeName1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConsigneeName1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConsigneeName1.DatabaseFieldLink = "AlDest1";
            this.txtConsigneeName1.Location = new System.Drawing.Point(75, 19);
            this.txtConsigneeName1.MaxLength = 70;
            this.txtConsigneeName1.Name = "txtConsigneeName1";
            this.txtConsigneeName1.Size = new System.Drawing.Size(380, 20);
            this.txtConsigneeName1.TabIndex = 0;
            this.txtConsigneeName1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtConsigneeName1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtConsigneeName1.Enter += new System.EventHandler(this.txtConsigneeEnter);
            // 
            // lblConsigneeCountry
            // 
            this.lblConsigneeCountry.AutoSize = true;
            this.lblConsigneeCountry.Location = new System.Drawing.Point(283, 152);
            this.lblConsigneeCountry.Name = "lblConsigneeCountry";
            this.lblConsigneeCountry.Size = new System.Drawing.Size(49, 13);
            this.lblConsigneeCountry.TabIndex = 57;
            this.lblConsigneeCountry.Text = "Country :";
            // 
            // lblConsigneeZip
            // 
            this.lblConsigneeZip.AutoSize = true;
            this.lblConsigneeZip.Location = new System.Drawing.Point(162, 152);
            this.lblConsigneeZip.Name = "lblConsigneeZip";
            this.lblConsigneeZip.Size = new System.Drawing.Size(28, 13);
            this.lblConsigneeZip.TabIndex = 56;
            this.lblConsigneeZip.Text = "Zip :";
            // 
            // lblConsigneeAddress
            // 
            this.lblConsigneeAddress.AutoSize = true;
            this.lblConsigneeAddress.Location = new System.Drawing.Point(6, 74);
            this.lblConsigneeAddress.Name = "lblConsigneeAddress";
            this.lblConsigneeAddress.Size = new System.Drawing.Size(51, 13);
            this.lblConsigneeAddress.TabIndex = 55;
            this.lblConsigneeAddress.Text = "Address :";
            // 
            // lblConsigneeName
            // 
            this.lblConsigneeName.AutoSize = true;
            this.lblConsigneeName.Location = new System.Drawing.Point(6, 19);
            this.lblConsigneeName.Name = "lblConsigneeName";
            this.lblConsigneeName.Size = new System.Drawing.Size(38, 13);
            this.lblConsigneeName.TabIndex = 54;
            this.lblConsigneeName.Text = "Name:";
            // 
            // lblConsigneeSt
            // 
            this.lblConsigneeSt.AutoSize = true;
            this.lblConsigneeSt.Location = new System.Drawing.Point(6, 152);
            this.lblConsigneeSt.Name = "lblConsigneeSt";
            this.lblConsigneeSt.Size = new System.Drawing.Size(23, 13);
            this.lblConsigneeSt.TabIndex = 53;
            this.lblConsigneeSt.Text = "St :";
            // 
            // lblConsigneeCity
            // 
            this.lblConsigneeCity.AutoSize = true;
            this.lblConsigneeCity.Location = new System.Drawing.Point(6, 126);
            this.lblConsigneeCity.Name = "lblConsigneeCity";
            this.lblConsigneeCity.Size = new System.Drawing.Size(30, 13);
            this.lblConsigneeCity.TabIndex = 52;
            this.lblConsigneeCity.Text = "City :";
            // 
            // btnAddFB
            // 
            this.btnAddFB.Location = new System.Drawing.Point(6, 19);
            this.btnAddFB.Name = "btnAddFB";
            this.btnAddFB.Size = new System.Drawing.Size(68, 23);
            this.btnAddFB.TabIndex = 0;
            this.btnAddFB.Text = "Add";
            this.btnAddFB.UseVisualStyleBackColor = true;
            this.btnAddFB.Click += new System.EventHandler(this.btnAddFB_Click);
            // 
            // btnDeleteFB
            // 
            this.btnDeleteFB.Location = new System.Drawing.Point(6, 47);
            this.btnDeleteFB.Name = "btnDeleteFB";
            this.btnDeleteFB.Size = new System.Drawing.Size(68, 23);
            this.btnDeleteFB.TabIndex = 0;
            this.btnDeleteFB.TabStop = false;
            this.btnDeleteFB.Text = "Delete";
            this.btnDeleteFB.UseVisualStyleBackColor = true;
            this.btnDeleteFB.Click += new System.EventHandler(this.btnDeleteFB_Click);
            // 
            // grpBoxFreightBill
            // 
            this.grpBoxFreightBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxFreightBill.Controls.Add(this.grdFXI);
            this.grpBoxFreightBill.Controls.Add(this.lblFBCount);
            this.grpBoxFreightBill.Controls.Add(this.lblFBCounter);
            this.grpBoxFreightBill.Controls.Add(this.lblFBAmountTotal);
            this.grpBoxFreightBill.Controls.Add(this.lblFBTotal);
            this.grpBoxFreightBill.Controls.Add(this.txtPriceLane);
            this.grpBoxFreightBill.Controls.Add(this.txtLaneLabel);
            this.grpBoxFreightBill.Controls.Add(this.lblLaneLabel);
            this.grpBoxFreightBill.Controls.Add(this.lblPriceLane);
            this.grpBoxFreightBill.Controls.Add(this.mtxtDelivered);
            this.grpBoxFreightBill.Controls.Add(this.mtxtPickUp);
            this.grpBoxFreightBill.Controls.Add(this.mtxtDate);
            this.grpBoxFreightBill.Controls.Add(this.lblTotal);
            this.grpBoxFreightBill.Controls.Add(this.btnDeleteFB);
            this.grpBoxFreightBill.Controls.Add(this.btnAddFB);
            this.grpBoxFreightBill.Controls.Add(this.lblFBAmount);
            this.grpBoxFreightBill.Controls.Add(this.lblDelivered);
            this.grpBoxFreightBill.Controls.Add(this.lblPickUp);
            this.grpBoxFreightBill.Controls.Add(this.grpBoxConsigneeAddress);
            this.grpBoxFreightBill.Controls.Add(this.grpBoxShipperAddress);
            this.grpBoxFreightBill.Controls.Add(this.txtInterLineField3);
            this.grpBoxFreightBill.Controls.Add(this.txtInterLineField2);
            this.grpBoxFreightBill.Controls.Add(this.txtCustRef1);
            this.grpBoxFreightBill.Controls.Add(this.txtCustRef2);
            this.grpBoxFreightBill.Controls.Add(this.txtInterLineField1);
            this.grpBoxFreightBill.Controls.Add(this.txtTerm);
            this.grpBoxFreightBill.Controls.Add(this.txtServiceCode);
            this.grpBoxFreightBill.Controls.Add(this.txtDistance);
            this.grpBoxFreightBill.Controls.Add(this.txtPieces);
            this.grpBoxFreightBill.Controls.Add(this.txtPkgType);
            this.grpBoxFreightBill.Controls.Add(this.txtFnclWt);
            this.grpBoxFreightBill.Controls.Add(this.txtActualWt);
            this.grpBoxFreightBill.Controls.Add(this.lblInterLineField);
            this.grpBoxFreightBill.Controls.Add(this.lblCustRef2);
            this.grpBoxFreightBill.Controls.Add(this.lblCustRef1);
            this.grpBoxFreightBill.Controls.Add(this.lblDistance);
            this.grpBoxFreightBill.Controls.Add(this.lblPieces);
            this.grpBoxFreightBill.Controls.Add(this.lblPkgType);
            this.grpBoxFreightBill.Controls.Add(this.lblFnclWt);
            this.grpBoxFreightBill.Controls.Add(this.lblActualWt);
            this.grpBoxFreightBill.Controls.Add(this.lblService);
            this.grpBoxFreightBill.Controls.Add(this.lblTerm);
            this.grpBoxFreightBill.Controls.Add(this.lblDate);
            this.grpBoxFreightBill.Controls.Add(this.grdFreightBill);
            this.grpBoxFreightBill.Controls.Add(this.grpBoxFbLine);
            this.grpBoxFreightBill.Location = new System.Drawing.Point(12, 199);
            this.grpBoxFreightBill.Name = "grpBoxFreightBill";
            this.grpBoxFreightBill.Size = new System.Drawing.Size(1168, 518);
            this.grpBoxFreightBill.TabIndex = 2;
            this.grpBoxFreightBill.TabStop = false;
            this.grpBoxFreightBill.Text = "Freight Bill";
            // 
            // grdFXI
            // 
            this.grdFXI.AllowUserToAddRows = false;
            this.grdFXI.AllowUserToDeleteRows = false;
            this.grdFXI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFXI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFXI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FbId,
            this.VendLabl,
            this.InvId,
            this.BatId,
            this.T001,
            this.T002,
            this.T003,
            this.T004,
            this.T005,
            this.T006,
            this.T007,
            this.T008,
            this.T009,
            this.T010,
            this.T011,
            this.T012,
            this.T013,
            this.T014,
            this.T015,
            this.T016,
            this.T017,
            this.T018,
            this.T019,
            this.T020,
            this.T021,
            this.T022,
            this.T023,
            this.T024,
            this.T025,
            this.T026,
            this.T027,
            this.T028,
            this.T029,
            this.T030,
            this.T031,
            this.T032,
            this.T033,
            this.T034,
            this.T035,
            this.T036,
            this.T037,
            this.T038,
            this.T039,
            this.T040,
            this.T041,
            this.T042,
            this.T043,
            this.T044,
            this.T045,
            this.T046,
            this.T047,
            this.T048,
            this.T049,
            this.T050,
            this.T051,
            this.T052,
            this.T053,
            this.T054,
            this.T055,
            this.T056,
            this.T057,
            this.T058,
            this.T059,
            this.T060,
            this.T061,
            this.T062,
            this.T063,
            this.T064,
            this.T065,
            this.T066,
            this.T067,
            this.T068,
            this.T069,
            this.T070,
            this.T071,
            this.T072,
            this.T073,
            this.T074,
            this.T075,
            this.T076,
            this.T077,
            this.T078,
            this.T079,
            this.T080,
            this.T081,
            this.T082,
            this.T083,
            this.T084,
            this.T085,
            this.T086,
            this.T087,
            this.T088,
            this.T089,
            this.T090,
            this.T091,
            this.T092,
            this.T093,
            this.T094,
            this.T095,
            this.T096,
            this.T097,
            this.T098,
            this.T099,
            this.T100,
            this.T101,
            this.T102,
            this.T103,
            this.T104,
            this.T105,
            this.T106,
            this.T107,
            this.T108,
            this.T109,
            this.T110,
            this.T111,
            this.T112,
            this.T113,
            this.T114,
            this.T115,
            this.T116,
            this.T117,
            this.T118,
            this.T119,
            this.T120});
            this.grdFXI.Location = new System.Drawing.Point(961, 234);
            this.grdFXI.Name = "grdFXI";
            this.grdFXI.ReadOnly = true;
            this.grdFXI.RowHeadersVisible = false;
            this.grdFXI.Size = new System.Drawing.Size(201, 62);
            this.grdFXI.TabIndex = 12;
            this.grdFXI.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFXI_CellEndEdit);
            // 
            // FbId
            // 
            this.FbId.DataPropertyName = "FbId";
            this.FbId.Frozen = true;
            this.FbId.HeaderText = "FbId";
            this.FbId.Name = "FbId";
            this.FbId.ReadOnly = true;
            this.FbId.Visible = false;
            this.FbId.Width = 160;
            // 
            // VendLabl
            // 
            this.VendLabl.DataPropertyName = "VendLabl";
            this.VendLabl.Frozen = true;
            this.VendLabl.HeaderText = "VendLabl";
            this.VendLabl.Name = "VendLabl";
            this.VendLabl.ReadOnly = true;
            this.VendLabl.Visible = false;
            this.VendLabl.Width = 80;
            // 
            // InvId
            // 
            this.InvId.DataPropertyName = "InvId";
            this.InvId.Frozen = true;
            this.InvId.HeaderText = "InvId";
            this.InvId.Name = "InvId";
            this.InvId.ReadOnly = true;
            this.InvId.Visible = false;
            // 
            // BatId
            // 
            this.BatId.DataPropertyName = "BatId";
            this.BatId.Frozen = true;
            this.BatId.HeaderText = "BatId";
            this.BatId.Name = "BatId";
            this.BatId.ReadOnly = true;
            this.BatId.Visible = false;
            // 
            // T001
            // 
            this.T001.DataPropertyName = "T001";
            this.T001.HeaderText = "T001";
            this.T001.MaxInputLength = 255;
            this.T001.Name = "T001";
            this.T001.ReadOnly = true;
            // 
            // T002
            // 
            this.T002.DataPropertyName = "T002";
            this.T002.HeaderText = "T002";
            this.T002.MaxInputLength = 255;
            this.T002.Name = "T002";
            this.T002.ReadOnly = true;
            // 
            // T003
            // 
            this.T003.DataPropertyName = "T003";
            this.T003.HeaderText = "T003";
            this.T003.MaxInputLength = 255;
            this.T003.Name = "T003";
            this.T003.ReadOnly = true;
            // 
            // T004
            // 
            this.T004.DataPropertyName = "T004";
            this.T004.HeaderText = "T004";
            this.T004.MaxInputLength = 255;
            this.T004.Name = "T004";
            this.T004.ReadOnly = true;
            // 
            // T005
            // 
            this.T005.DataPropertyName = "T005";
            this.T005.HeaderText = "T005";
            this.T005.MaxInputLength = 255;
            this.T005.Name = "T005";
            this.T005.ReadOnly = true;
            // 
            // T006
            // 
            this.T006.DataPropertyName = "T006";
            this.T006.HeaderText = "T006";
            this.T006.MaxInputLength = 255;
            this.T006.Name = "T006";
            this.T006.ReadOnly = true;
            // 
            // T007
            // 
            this.T007.DataPropertyName = "T007";
            this.T007.HeaderText = "T007";
            this.T007.MaxInputLength = 255;
            this.T007.Name = "T007";
            this.T007.ReadOnly = true;
            // 
            // T008
            // 
            this.T008.DataPropertyName = "T008";
            this.T008.HeaderText = "T008";
            this.T008.MaxInputLength = 255;
            this.T008.Name = "T008";
            this.T008.ReadOnly = true;
            // 
            // T009
            // 
            this.T009.DataPropertyName = "T009";
            this.T009.HeaderText = "T009";
            this.T009.MaxInputLength = 255;
            this.T009.Name = "T009";
            this.T009.ReadOnly = true;
            // 
            // T010
            // 
            this.T010.DataPropertyName = "T010";
            this.T010.HeaderText = "T010";
            this.T010.MaxInputLength = 255;
            this.T010.Name = "T010";
            this.T010.ReadOnly = true;
            // 
            // T011
            // 
            this.T011.DataPropertyName = "T011";
            this.T011.HeaderText = "T011";
            this.T011.MaxInputLength = 255;
            this.T011.Name = "T011";
            this.T011.ReadOnly = true;
            // 
            // T012
            // 
            this.T012.DataPropertyName = "T012";
            this.T012.HeaderText = "T012";
            this.T012.MaxInputLength = 255;
            this.T012.Name = "T012";
            this.T012.ReadOnly = true;
            // 
            // T013
            // 
            this.T013.DataPropertyName = "T013";
            this.T013.HeaderText = "T013";
            this.T013.MaxInputLength = 255;
            this.T013.Name = "T013";
            this.T013.ReadOnly = true;
            // 
            // T014
            // 
            this.T014.DataPropertyName = "T014";
            this.T014.HeaderText = "T014";
            this.T014.MaxInputLength = 255;
            this.T014.Name = "T014";
            this.T014.ReadOnly = true;
            // 
            // T015
            // 
            this.T015.DataPropertyName = "T015";
            this.T015.HeaderText = "T015";
            this.T015.MaxInputLength = 255;
            this.T015.Name = "T015";
            this.T015.ReadOnly = true;
            // 
            // T016
            // 
            this.T016.DataPropertyName = "T016";
            this.T016.HeaderText = "T016";
            this.T016.MaxInputLength = 255;
            this.T016.Name = "T016";
            this.T016.ReadOnly = true;
            // 
            // T017
            // 
            this.T017.DataPropertyName = "T017";
            this.T017.HeaderText = "T017";
            this.T017.MaxInputLength = 255;
            this.T017.Name = "T017";
            this.T017.ReadOnly = true;
            // 
            // T018
            // 
            this.T018.DataPropertyName = "T018";
            this.T018.HeaderText = "T018";
            this.T018.MaxInputLength = 255;
            this.T018.Name = "T018";
            this.T018.ReadOnly = true;
            // 
            // T019
            // 
            this.T019.DataPropertyName = "T019";
            this.T019.HeaderText = "T019";
            this.T019.MaxInputLength = 255;
            this.T019.Name = "T019";
            this.T019.ReadOnly = true;
            // 
            // T020
            // 
            this.T020.DataPropertyName = "T020";
            this.T020.HeaderText = "T020";
            this.T020.MaxInputLength = 255;
            this.T020.Name = "T020";
            this.T020.ReadOnly = true;
            // 
            // T021
            // 
            this.T021.DataPropertyName = "T021";
            this.T021.HeaderText = "T021";
            this.T021.MaxInputLength = 255;
            this.T021.Name = "T021";
            this.T021.ReadOnly = true;
            // 
            // T022
            // 
            this.T022.DataPropertyName = "T022";
            this.T022.HeaderText = "T022";
            this.T022.MaxInputLength = 255;
            this.T022.Name = "T022";
            this.T022.ReadOnly = true;
            // 
            // T023
            // 
            this.T023.DataPropertyName = "T023";
            this.T023.HeaderText = "T023";
            this.T023.MaxInputLength = 255;
            this.T023.Name = "T023";
            this.T023.ReadOnly = true;
            // 
            // T024
            // 
            this.T024.DataPropertyName = "T024";
            this.T024.HeaderText = "T024";
            this.T024.MaxInputLength = 255;
            this.T024.Name = "T024";
            this.T024.ReadOnly = true;
            // 
            // T025
            // 
            this.T025.DataPropertyName = "T025";
            this.T025.HeaderText = "T025";
            this.T025.MaxInputLength = 255;
            this.T025.Name = "T025";
            this.T025.ReadOnly = true;
            // 
            // T026
            // 
            this.T026.DataPropertyName = "T026";
            this.T026.HeaderText = "T026";
            this.T026.MaxInputLength = 255;
            this.T026.Name = "T026";
            this.T026.ReadOnly = true;
            // 
            // T027
            // 
            this.T027.DataPropertyName = "T027";
            this.T027.HeaderText = "T027";
            this.T027.MaxInputLength = 255;
            this.T027.Name = "T027";
            this.T027.ReadOnly = true;
            // 
            // T028
            // 
            this.T028.DataPropertyName = "T028";
            this.T028.HeaderText = "T028";
            this.T028.MaxInputLength = 255;
            this.T028.Name = "T028";
            this.T028.ReadOnly = true;
            // 
            // T029
            // 
            this.T029.DataPropertyName = "T029";
            this.T029.HeaderText = "T029";
            this.T029.MaxInputLength = 255;
            this.T029.Name = "T029";
            this.T029.ReadOnly = true;
            // 
            // T030
            // 
            this.T030.DataPropertyName = "T030";
            this.T030.HeaderText = "T030";
            this.T030.MaxInputLength = 255;
            this.T030.Name = "T030";
            this.T030.ReadOnly = true;
            // 
            // T031
            // 
            this.T031.DataPropertyName = "T031";
            this.T031.HeaderText = "T031";
            this.T031.MaxInputLength = 255;
            this.T031.Name = "T031";
            this.T031.ReadOnly = true;
            // 
            // T032
            // 
            this.T032.DataPropertyName = "T032";
            this.T032.HeaderText = "T032";
            this.T032.MaxInputLength = 255;
            this.T032.Name = "T032";
            this.T032.ReadOnly = true;
            // 
            // T033
            // 
            this.T033.DataPropertyName = "T033";
            this.T033.HeaderText = "T033";
            this.T033.MaxInputLength = 255;
            this.T033.Name = "T033";
            this.T033.ReadOnly = true;
            // 
            // T034
            // 
            this.T034.DataPropertyName = "T034";
            this.T034.HeaderText = "T034";
            this.T034.MaxInputLength = 255;
            this.T034.Name = "T034";
            this.T034.ReadOnly = true;
            // 
            // T035
            // 
            this.T035.DataPropertyName = "T035";
            this.T035.HeaderText = "T035";
            this.T035.MaxInputLength = 255;
            this.T035.Name = "T035";
            this.T035.ReadOnly = true;
            // 
            // T036
            // 
            this.T036.DataPropertyName = "T036";
            this.T036.HeaderText = "T036";
            this.T036.MaxInputLength = 255;
            this.T036.Name = "T036";
            this.T036.ReadOnly = true;
            // 
            // T037
            // 
            this.T037.DataPropertyName = "T037";
            this.T037.HeaderText = "T037";
            this.T037.MaxInputLength = 255;
            this.T037.Name = "T037";
            this.T037.ReadOnly = true;
            // 
            // T038
            // 
            this.T038.DataPropertyName = "T038";
            this.T038.HeaderText = "T038";
            this.T038.MaxInputLength = 255;
            this.T038.Name = "T038";
            this.T038.ReadOnly = true;
            // 
            // T039
            // 
            this.T039.DataPropertyName = "T039";
            this.T039.HeaderText = "T039";
            this.T039.MaxInputLength = 255;
            this.T039.Name = "T039";
            this.T039.ReadOnly = true;
            // 
            // T040
            // 
            this.T040.DataPropertyName = "T040";
            this.T040.HeaderText = "T040";
            this.T040.MaxInputLength = 255;
            this.T040.Name = "T040";
            this.T040.ReadOnly = true;
            // 
            // T041
            // 
            this.T041.DataPropertyName = "T041";
            this.T041.HeaderText = "T041";
            this.T041.MaxInputLength = 255;
            this.T041.Name = "T041";
            this.T041.ReadOnly = true;
            // 
            // T042
            // 
            this.T042.DataPropertyName = "T042";
            this.T042.HeaderText = "T042";
            this.T042.MaxInputLength = 255;
            this.T042.Name = "T042";
            this.T042.ReadOnly = true;
            // 
            // T043
            // 
            this.T043.DataPropertyName = "T043";
            this.T043.HeaderText = "T043";
            this.T043.MaxInputLength = 255;
            this.T043.Name = "T043";
            this.T043.ReadOnly = true;
            // 
            // T044
            // 
            this.T044.DataPropertyName = "T044";
            this.T044.HeaderText = "T044";
            this.T044.MaxInputLength = 255;
            this.T044.Name = "T044";
            this.T044.ReadOnly = true;
            // 
            // T045
            // 
            this.T045.DataPropertyName = "T045";
            this.T045.HeaderText = "T045";
            this.T045.MaxInputLength = 255;
            this.T045.Name = "T045";
            this.T045.ReadOnly = true;
            // 
            // T046
            // 
            this.T046.DataPropertyName = "T046";
            this.T046.HeaderText = "T046";
            this.T046.MaxInputLength = 255;
            this.T046.Name = "T046";
            this.T046.ReadOnly = true;
            // 
            // T047
            // 
            this.T047.DataPropertyName = "T047";
            this.T047.HeaderText = "T047";
            this.T047.MaxInputLength = 255;
            this.T047.Name = "T047";
            this.T047.ReadOnly = true;
            // 
            // T048
            // 
            this.T048.DataPropertyName = "T048";
            this.T048.HeaderText = "T048";
            this.T048.MaxInputLength = 255;
            this.T048.Name = "T048";
            this.T048.ReadOnly = true;
            // 
            // T049
            // 
            this.T049.DataPropertyName = "T049";
            this.T049.HeaderText = "T049";
            this.T049.MaxInputLength = 255;
            this.T049.Name = "T049";
            this.T049.ReadOnly = true;
            // 
            // T050
            // 
            this.T050.DataPropertyName = "T050";
            this.T050.HeaderText = "T050";
            this.T050.MaxInputLength = 255;
            this.T050.Name = "T050";
            this.T050.ReadOnly = true;
            // 
            // T051
            // 
            this.T051.DataPropertyName = "T051";
            this.T051.HeaderText = "T051";
            this.T051.MaxInputLength = 255;
            this.T051.Name = "T051";
            this.T051.ReadOnly = true;
            // 
            // T052
            // 
            this.T052.DataPropertyName = "T052";
            this.T052.HeaderText = "T052";
            this.T052.MaxInputLength = 255;
            this.T052.Name = "T052";
            this.T052.ReadOnly = true;
            // 
            // T053
            // 
            this.T053.DataPropertyName = "T053";
            this.T053.HeaderText = "T053";
            this.T053.MaxInputLength = 255;
            this.T053.Name = "T053";
            this.T053.ReadOnly = true;
            // 
            // T054
            // 
            this.T054.DataPropertyName = "T054";
            this.T054.HeaderText = "T054";
            this.T054.MaxInputLength = 255;
            this.T054.Name = "T054";
            this.T054.ReadOnly = true;
            // 
            // T055
            // 
            this.T055.DataPropertyName = "T055";
            this.T055.HeaderText = "T055";
            this.T055.MaxInputLength = 255;
            this.T055.Name = "T055";
            this.T055.ReadOnly = true;
            // 
            // T056
            // 
            this.T056.DataPropertyName = "T056";
            this.T056.HeaderText = "T056";
            this.T056.MaxInputLength = 255;
            this.T056.Name = "T056";
            this.T056.ReadOnly = true;
            // 
            // T057
            // 
            this.T057.DataPropertyName = "T057";
            this.T057.HeaderText = "T057";
            this.T057.MaxInputLength = 255;
            this.T057.Name = "T057";
            this.T057.ReadOnly = true;
            // 
            // T058
            // 
            this.T058.DataPropertyName = "T058";
            this.T058.HeaderText = "T058";
            this.T058.MaxInputLength = 255;
            this.T058.Name = "T058";
            this.T058.ReadOnly = true;
            // 
            // T059
            // 
            this.T059.DataPropertyName = "T059";
            this.T059.HeaderText = "T059";
            this.T059.MaxInputLength = 255;
            this.T059.Name = "T059";
            this.T059.ReadOnly = true;
            // 
            // T060
            // 
            this.T060.DataPropertyName = "T060";
            this.T060.HeaderText = "T060";
            this.T060.MaxInputLength = 255;
            this.T060.Name = "T060";
            this.T060.ReadOnly = true;
            // 
            // T061
            // 
            this.T061.DataPropertyName = "T061";
            this.T061.HeaderText = "T061";
            this.T061.MaxInputLength = 255;
            this.T061.Name = "T061";
            this.T061.ReadOnly = true;
            // 
            // T062
            // 
            this.T062.DataPropertyName = "T062";
            this.T062.HeaderText = "T062";
            this.T062.MaxInputLength = 255;
            this.T062.Name = "T062";
            this.T062.ReadOnly = true;
            // 
            // T063
            // 
            this.T063.DataPropertyName = "T063";
            this.T063.HeaderText = "T063";
            this.T063.MaxInputLength = 255;
            this.T063.Name = "T063";
            this.T063.ReadOnly = true;
            // 
            // T064
            // 
            this.T064.DataPropertyName = "T064";
            this.T064.HeaderText = "T064";
            this.T064.MaxInputLength = 255;
            this.T064.Name = "T064";
            this.T064.ReadOnly = true;
            // 
            // T065
            // 
            this.T065.DataPropertyName = "T065";
            this.T065.HeaderText = "T065";
            this.T065.MaxInputLength = 255;
            this.T065.Name = "T065";
            this.T065.ReadOnly = true;
            // 
            // T066
            // 
            this.T066.DataPropertyName = "T066";
            this.T066.HeaderText = "T066";
            this.T066.MaxInputLength = 255;
            this.T066.Name = "T066";
            this.T066.ReadOnly = true;
            // 
            // T067
            // 
            this.T067.DataPropertyName = "T067";
            this.T067.HeaderText = "T067";
            this.T067.MaxInputLength = 255;
            this.T067.Name = "T067";
            this.T067.ReadOnly = true;
            // 
            // T068
            // 
            this.T068.DataPropertyName = "T068";
            this.T068.HeaderText = "T068";
            this.T068.MaxInputLength = 255;
            this.T068.Name = "T068";
            this.T068.ReadOnly = true;
            // 
            // T069
            // 
            this.T069.DataPropertyName = "T069";
            this.T069.HeaderText = "T069";
            this.T069.MaxInputLength = 255;
            this.T069.Name = "T069";
            this.T069.ReadOnly = true;
            // 
            // T070
            // 
            this.T070.DataPropertyName = "T070";
            this.T070.HeaderText = "T070";
            this.T070.MaxInputLength = 255;
            this.T070.Name = "T070";
            this.T070.ReadOnly = true;
            // 
            // T071
            // 
            this.T071.DataPropertyName = "T071";
            this.T071.HeaderText = "T071";
            this.T071.MaxInputLength = 255;
            this.T071.Name = "T071";
            this.T071.ReadOnly = true;
            // 
            // T072
            // 
            this.T072.DataPropertyName = "T072";
            this.T072.HeaderText = "T072";
            this.T072.MaxInputLength = 255;
            this.T072.Name = "T072";
            this.T072.ReadOnly = true;
            // 
            // T073
            // 
            this.T073.DataPropertyName = "T073";
            this.T073.HeaderText = "T073";
            this.T073.MaxInputLength = 255;
            this.T073.Name = "T073";
            this.T073.ReadOnly = true;
            // 
            // T074
            // 
            this.T074.DataPropertyName = "T074";
            this.T074.HeaderText = "T074";
            this.T074.MaxInputLength = 255;
            this.T074.Name = "T074";
            this.T074.ReadOnly = true;
            // 
            // T075
            // 
            this.T075.DataPropertyName = "T075";
            this.T075.HeaderText = "T075";
            this.T075.MaxInputLength = 255;
            this.T075.Name = "T075";
            this.T075.ReadOnly = true;
            // 
            // T076
            // 
            this.T076.DataPropertyName = "T076";
            this.T076.HeaderText = "T076";
            this.T076.MaxInputLength = 255;
            this.T076.Name = "T076";
            this.T076.ReadOnly = true;
            // 
            // T077
            // 
            this.T077.DataPropertyName = "T077";
            this.T077.HeaderText = "T077";
            this.T077.MaxInputLength = 255;
            this.T077.Name = "T077";
            this.T077.ReadOnly = true;
            // 
            // T078
            // 
            this.T078.DataPropertyName = "T078";
            this.T078.HeaderText = "T078";
            this.T078.MaxInputLength = 255;
            this.T078.Name = "T078";
            this.T078.ReadOnly = true;
            // 
            // T079
            // 
            this.T079.DataPropertyName = "T079";
            this.T079.HeaderText = "T079";
            this.T079.MaxInputLength = 255;
            this.T079.Name = "T079";
            this.T079.ReadOnly = true;
            // 
            // T080
            // 
            this.T080.DataPropertyName = "T080";
            this.T080.HeaderText = "T080";
            this.T080.MaxInputLength = 255;
            this.T080.Name = "T080";
            this.T080.ReadOnly = true;
            // 
            // T081
            // 
            this.T081.DataPropertyName = "T081";
            this.T081.HeaderText = "T081";
            this.T081.MaxInputLength = 255;
            this.T081.Name = "T081";
            this.T081.ReadOnly = true;
            // 
            // T082
            // 
            this.T082.DataPropertyName = "T082";
            this.T082.HeaderText = "T082";
            this.T082.MaxInputLength = 255;
            this.T082.Name = "T082";
            this.T082.ReadOnly = true;
            // 
            // T083
            // 
            this.T083.DataPropertyName = "T083";
            this.T083.HeaderText = "T083";
            this.T083.MaxInputLength = 255;
            this.T083.Name = "T083";
            this.T083.ReadOnly = true;
            // 
            // T084
            // 
            this.T084.DataPropertyName = "T084";
            this.T084.HeaderText = "T084";
            this.T084.MaxInputLength = 255;
            this.T084.Name = "T084";
            this.T084.ReadOnly = true;
            // 
            // T085
            // 
            this.T085.DataPropertyName = "T085";
            this.T085.HeaderText = "T085";
            this.T085.MaxInputLength = 255;
            this.T085.Name = "T085";
            this.T085.ReadOnly = true;
            // 
            // T086
            // 
            this.T086.DataPropertyName = "T086";
            this.T086.HeaderText = "T086";
            this.T086.MaxInputLength = 255;
            this.T086.Name = "T086";
            this.T086.ReadOnly = true;
            // 
            // T087
            // 
            this.T087.DataPropertyName = "T087";
            this.T087.HeaderText = "T087";
            this.T087.MaxInputLength = 255;
            this.T087.Name = "T087";
            this.T087.ReadOnly = true;
            // 
            // T088
            // 
            this.T088.DataPropertyName = "T088";
            this.T088.HeaderText = "T088";
            this.T088.MaxInputLength = 255;
            this.T088.Name = "T088";
            this.T088.ReadOnly = true;
            // 
            // T089
            // 
            this.T089.DataPropertyName = "T089";
            this.T089.HeaderText = "T089";
            this.T089.MaxInputLength = 255;
            this.T089.Name = "T089";
            this.T089.ReadOnly = true;
            // 
            // T090
            // 
            this.T090.DataPropertyName = "T090";
            this.T090.HeaderText = "T090";
            this.T090.MaxInputLength = 255;
            this.T090.Name = "T090";
            this.T090.ReadOnly = true;
            // 
            // T091
            // 
            this.T091.DataPropertyName = "T091";
            this.T091.HeaderText = "T091";
            this.T091.MaxInputLength = 255;
            this.T091.Name = "T091";
            this.T091.ReadOnly = true;
            // 
            // T092
            // 
            this.T092.DataPropertyName = "T092";
            this.T092.HeaderText = "T092";
            this.T092.MaxInputLength = 255;
            this.T092.Name = "T092";
            this.T092.ReadOnly = true;
            // 
            // T093
            // 
            this.T093.DataPropertyName = "T093";
            this.T093.HeaderText = "T093";
            this.T093.MaxInputLength = 255;
            this.T093.Name = "T093";
            this.T093.ReadOnly = true;
            // 
            // T094
            // 
            this.T094.DataPropertyName = "T094";
            this.T094.HeaderText = "T094";
            this.T094.MaxInputLength = 255;
            this.T094.Name = "T094";
            this.T094.ReadOnly = true;
            // 
            // T095
            // 
            this.T095.DataPropertyName = "T095";
            this.T095.HeaderText = "T095";
            this.T095.MaxInputLength = 255;
            this.T095.Name = "T095";
            this.T095.ReadOnly = true;
            // 
            // T096
            // 
            this.T096.DataPropertyName = "T096";
            this.T096.HeaderText = "T096";
            this.T096.MaxInputLength = 255;
            this.T096.Name = "T096";
            this.T096.ReadOnly = true;
            // 
            // T097
            // 
            this.T097.DataPropertyName = "T097";
            this.T097.HeaderText = "T097";
            this.T097.MaxInputLength = 255;
            this.T097.Name = "T097";
            this.T097.ReadOnly = true;
            // 
            // T098
            // 
            this.T098.DataPropertyName = "T099";
            this.T098.HeaderText = "T098";
            this.T098.MaxInputLength = 255;
            this.T098.Name = "T098";
            this.T098.ReadOnly = true;
            // 
            // T099
            // 
            this.T099.DataPropertyName = "T099";
            this.T099.HeaderText = "T099";
            this.T099.MaxInputLength = 255;
            this.T099.Name = "T099";
            this.T099.ReadOnly = true;
            // 
            // T100
            // 
            this.T100.DataPropertyName = "T100";
            this.T100.HeaderText = "T100";
            this.T100.MaxInputLength = 255;
            this.T100.Name = "T100";
            this.T100.ReadOnly = true;
            // 
            // T101
            // 
            this.T101.DataPropertyName = "T101";
            this.T101.HeaderText = "T101";
            this.T101.MaxInputLength = 255;
            this.T101.Name = "T101";
            this.T101.ReadOnly = true;
            // 
            // T102
            // 
            this.T102.DataPropertyName = "T102";
            this.T102.HeaderText = "T102";
            this.T102.MaxInputLength = 255;
            this.T102.Name = "T102";
            this.T102.ReadOnly = true;
            // 
            // T103
            // 
            this.T103.DataPropertyName = "T103";
            this.T103.HeaderText = "T103";
            this.T103.MaxInputLength = 255;
            this.T103.Name = "T103";
            this.T103.ReadOnly = true;
            // 
            // T104
            // 
            this.T104.DataPropertyName = "T104";
            this.T104.HeaderText = "T104";
            this.T104.MaxInputLength = 255;
            this.T104.Name = "T104";
            this.T104.ReadOnly = true;
            // 
            // T105
            // 
            this.T105.DataPropertyName = "T105";
            this.T105.HeaderText = "T105";
            this.T105.MaxInputLength = 255;
            this.T105.Name = "T105";
            this.T105.ReadOnly = true;
            // 
            // T106
            // 
            this.T106.DataPropertyName = "T106";
            this.T106.HeaderText = "T106";
            this.T106.MaxInputLength = 255;
            this.T106.Name = "T106";
            this.T106.ReadOnly = true;
            // 
            // T107
            // 
            this.T107.DataPropertyName = "T107";
            this.T107.HeaderText = "T107";
            this.T107.MaxInputLength = 255;
            this.T107.Name = "T107";
            this.T107.ReadOnly = true;
            // 
            // T108
            // 
            this.T108.DataPropertyName = "T108";
            this.T108.HeaderText = "T108";
            this.T108.MaxInputLength = 255;
            this.T108.Name = "T108";
            this.T108.ReadOnly = true;
            // 
            // T109
            // 
            this.T109.DataPropertyName = "T109";
            this.T109.HeaderText = "T109";
            this.T109.MaxInputLength = 255;
            this.T109.Name = "T109";
            this.T109.ReadOnly = true;
            // 
            // T110
            // 
            this.T110.DataPropertyName = "T110";
            this.T110.HeaderText = "T110";
            this.T110.MaxInputLength = 255;
            this.T110.Name = "T110";
            this.T110.ReadOnly = true;
            // 
            // T111
            // 
            this.T111.DataPropertyName = "T111";
            this.T111.HeaderText = "T111";
            this.T111.MaxInputLength = 255;
            this.T111.Name = "T111";
            this.T111.ReadOnly = true;
            // 
            // T112
            // 
            this.T112.DataPropertyName = "T112";
            this.T112.HeaderText = "T112";
            this.T112.MaxInputLength = 255;
            this.T112.Name = "T112";
            this.T112.ReadOnly = true;
            // 
            // T113
            // 
            this.T113.DataPropertyName = "T113";
            this.T113.HeaderText = "T113";
            this.T113.MaxInputLength = 255;
            this.T113.Name = "T113";
            this.T113.ReadOnly = true;
            // 
            // T114
            // 
            this.T114.DataPropertyName = "T114";
            this.T114.HeaderText = "T114";
            this.T114.MaxInputLength = 255;
            this.T114.Name = "T114";
            this.T114.ReadOnly = true;
            // 
            // T115
            // 
            this.T115.DataPropertyName = "T115";
            this.T115.HeaderText = "T115";
            this.T115.MaxInputLength = 255;
            this.T115.Name = "T115";
            this.T115.ReadOnly = true;
            // 
            // T116
            // 
            this.T116.DataPropertyName = "T116";
            this.T116.HeaderText = "T116";
            this.T116.MaxInputLength = 255;
            this.T116.Name = "T116";
            this.T116.ReadOnly = true;
            // 
            // T117
            // 
            this.T117.DataPropertyName = "T117";
            this.T117.HeaderText = "T117";
            this.T117.MaxInputLength = 255;
            this.T117.Name = "T117";
            this.T117.ReadOnly = true;
            // 
            // T118
            // 
            this.T118.DataPropertyName = "T118";
            this.T118.HeaderText = "T118";
            this.T118.MaxInputLength = 255;
            this.T118.Name = "T118";
            this.T118.ReadOnly = true;
            // 
            // T119
            // 
            this.T119.DataPropertyName = "T119";
            this.T119.HeaderText = "T119";
            this.T119.MaxInputLength = 255;
            this.T119.Name = "T119";
            this.T119.ReadOnly = true;
            // 
            // T120
            // 
            this.T120.DataPropertyName = "T120";
            this.T120.HeaderText = "T120";
            this.T120.MaxInputLength = 255;
            this.T120.Name = "T120";
            this.T120.ReadOnly = true;
            // 
            // lblFBCount
            // 
            this.lblFBCount.AutoSize = true;
            this.lblFBCount.Location = new System.Drawing.Point(6, 73);
            this.lblFBCount.Name = "lblFBCount";
            this.lblFBCount.Size = new System.Drawing.Size(51, 13);
            this.lblFBCount.TabIndex = 78;
            this.lblFBCount.Text = "FB Count";
            // 
            // lblFBCounter
            // 
            this.lblFBCounter.AutoSize = true;
            this.lblFBCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFBCounter.Location = new System.Drawing.Point(9, 96);
            this.lblFBCounter.Name = "lblFBCounter";
            this.lblFBCounter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFBCounter.Size = new System.Drawing.Size(27, 13);
            this.lblFBCounter.TabIndex = 77;
            this.lblFBCounter.Text = "0/0";
            this.lblFBCounter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFBAmountTotal
            // 
            this.lblFBAmountTotal.AutoSize = true;
            this.lblFBAmountTotal.Location = new System.Drawing.Point(796, 16);
            this.lblFBAmountTotal.Name = "lblFBAmountTotal";
            this.lblFBAmountTotal.Size = new System.Drawing.Size(95, 13);
            this.lblFBAmountTotal.TabIndex = 74;
            this.lblFBAmountTotal.Text = "Total FB Amount : ";
            // 
            // lblFBTotal
            // 
            this.lblFBTotal.AutoSize = true;
            this.lblFBTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFBTotal.Location = new System.Drawing.Point(799, 39);
            this.lblFBTotal.Name = "lblFBTotal";
            this.lblFBTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFBTotal.Size = new System.Drawing.Size(46, 13);
            this.lblFBTotal.TabIndex = 73;
            this.lblFBTotal.Text = "0.0000";
            this.lblFBTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtPriceLane
            // 
            this.txtPriceLane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPriceLane.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPriceLane.DatabaseFieldLink = "PriceLaneLabl";
            this.txtPriceLane.Location = new System.Drawing.Point(488, 302);
            this.txtPriceLane.MaxLength = 50;
            this.txtPriceLane.Name = "txtPriceLane";
            this.txtPriceLane.Size = new System.Drawing.Size(270, 20);
            this.txtPriceLane.TabIndex = 15;
            this.txtPriceLane.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtPriceLane.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtLaneLabel
            // 
            this.txtLaneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLaneLabel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLaneLabel.DatabaseFieldLink = "LmLaneLabl";
            this.txtLaneLabel.Location = new System.Drawing.Point(488, 328);
            this.txtLaneLabel.MaxLength = 50;
            this.txtLaneLabel.Name = "txtLaneLabel";
            this.txtLaneLabel.Size = new System.Drawing.Size(270, 20);
            this.txtLaneLabel.TabIndex = 16;
            this.txtLaneLabel.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtLaneLabel.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblLaneLabel
            // 
            this.lblLaneLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLaneLabel.AutoSize = true;
            this.lblLaneLabel.Location = new System.Drawing.Point(416, 331);
            this.lblLaneLabel.Name = "lblLaneLabel";
            this.lblLaneLabel.Size = new System.Drawing.Size(66, 13);
            this.lblLaneLabel.TabIndex = 72;
            this.lblLaneLabel.Text = "Lane Label :";
            // 
            // lblPriceLane
            // 
            this.lblPriceLane.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriceLane.AutoSize = true;
            this.lblPriceLane.Location = new System.Drawing.Point(416, 305);
            this.lblPriceLane.Name = "lblPriceLane";
            this.lblPriceLane.Size = new System.Drawing.Size(64, 13);
            this.lblPriceLane.TabIndex = 71;
            this.lblPriceLane.Text = "Price Lane :";
            // 
            // mtxtDelivered
            // 
            this.mtxtDelivered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtDelivered.DatabaseFieldLink = "LmAtaDtm";
            this.mtxtDelivered.Location = new System.Drawing.Point(1030, 328);
            this.mtxtDelivered.Mask = "##/##/#### ##:##";
            this.mtxtDelivered.Name = "mtxtDelivered";
            this.mtxtDelivered.Size = new System.Drawing.Size(132, 20);
            this.mtxtDelivered.TabIndex = 21;
            this.mtxtDelivered.ValueType = CommonLibrary.CommonEnum.ValueType.DATELONG;
            this.mtxtDelivered.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // mtxtPickUp
            // 
            this.mtxtPickUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mtxtPickUp.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mtxtPickUp.DatabaseFieldLink = "LmPkupActualDtm";
            this.mtxtPickUp.Location = new System.Drawing.Point(828, 328);
            this.mtxtPickUp.Mask = "##/##/#### ##:##";
            this.mtxtPickUp.Name = "mtxtPickUp";
            this.mtxtPickUp.ResetOnPrompt = false;
            this.mtxtPickUp.ResetOnSpace = false;
            this.mtxtPickUp.Size = new System.Drawing.Size(132, 20);
            this.mtxtPickUp.TabIndex = 20;
            this.mtxtPickUp.ValueType = CommonLibrary.CommonEnum.ValueType.DATELONG;
            this.mtxtPickUp.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // mtxtDate
            // 
            this.mtxtDate.DatabaseFieldLink = "FbCreatDtm";
            this.mtxtDate.Location = new System.Drawing.Point(1047, 13);
            this.mtxtDate.Mask = "##/##/####";
            this.mtxtDate.Name = "mtxtDate";
            this.mtxtDate.RejectInputOnFirstFailure = true;
            this.mtxtDate.Size = new System.Drawing.Size(115, 20);
            this.mtxtDate.TabIndex = 2;
            this.mtxtDate.ValueType = CommonLibrary.CommonEnum.ValueType.DATESHORT;
            this.mtxtDate.Leave += new System.EventHandler(this.mtxtDate_Leave);
            this.mtxtDate.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1047, 502);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotal.Size = new System.Drawing.Size(46, 13);
            this.lblTotal.TabIndex = 68;
            this.lblTotal.Text = "0.0000";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFBAmount
            // 
            this.lblFBAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFBAmount.AutoSize = true;
            this.lblFBAmount.Location = new System.Drawing.Point(937, 502);
            this.lblFBAmount.Name = "lblFBAmount";
            this.lblFBAmount.Size = new System.Drawing.Size(104, 13);
            this.lblFBAmount.TabIndex = 67;
            this.lblFBAmount.Text = "Fb_Amt - Line Item : ";
            // 
            // lblDelivered
            // 
            this.lblDelivered.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDelivered.AutoSize = true;
            this.lblDelivered.Location = new System.Drawing.Point(966, 331);
            this.lblDelivered.Name = "lblDelivered";
            this.lblDelivered.Size = new System.Drawing.Size(58, 13);
            this.lblDelivered.TabIndex = 64;
            this.lblDelivered.Text = "Delivered :";
            // 
            // lblPickUp
            // 
            this.lblPickUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPickUp.AutoSize = true;
            this.lblPickUp.Location = new System.Drawing.Point(764, 331);
            this.lblPickUp.Name = "lblPickUp";
            this.lblPickUp.Size = new System.Drawing.Size(51, 13);
            this.lblPickUp.TabIndex = 63;
            this.lblPickUp.Text = "Pick Up :";
            // 
            // txtInterLineField3
            // 
            this.txtInterLineField3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInterLineField3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInterLineField3.DatabaseFieldLink = "InterlineAmt";
            this.txtInterLineField3.Location = new System.Drawing.Point(1060, 302);
            this.txtInterLineField3.Name = "txtInterLineField3";
            this.txtInterLineField3.Size = new System.Drawing.Size(102, 20);
            this.txtInterLineField3.TabIndex = 19;
            this.txtInterLineField3.ValueType = CommonLibrary.CommonEnum.ValueType.MONEY;
            this.txtInterLineField3.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtInterLineField2
            // 
            this.txtInterLineField2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInterLineField2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInterLineField2.DatabaseFieldLink = "InterlineQual";
            this.txtInterLineField2.Location = new System.Drawing.Point(955, 302);
            this.txtInterLineField2.MaxLength = 50;
            this.txtInterLineField2.Name = "txtInterLineField2";
            this.txtInterLineField2.Size = new System.Drawing.Size(99, 20);
            this.txtInterLineField2.TabIndex = 18;
            this.txtInterLineField2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtInterLineField2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtCustRef1
            // 
            this.txtCustRef1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustRef1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustRef1.DatabaseFieldLink = "CaInfo1Raw";
            this.txtCustRef1.Location = new System.Drawing.Point(78, 302);
            this.txtCustRef1.MaxLength = 100;
            this.txtCustRef1.Name = "txtCustRef1";
            this.txtCustRef1.Size = new System.Drawing.Size(332, 20);
            this.txtCustRef1.TabIndex = 13;
            this.txtCustRef1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtCustRef1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtCustRef2
            // 
            this.txtCustRef2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustRef2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCustRef2.DatabaseFieldLink = "CaInfo2Raw";
            this.txtCustRef2.Location = new System.Drawing.Point(78, 328);
            this.txtCustRef2.MaxLength = 100;
            this.txtCustRef2.Name = "txtCustRef2";
            this.txtCustRef2.Size = new System.Drawing.Size(332, 20);
            this.txtCustRef2.TabIndex = 14;
            this.txtCustRef2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtCustRef2.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtInterLineField1
            // 
            this.txtInterLineField1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInterLineField1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInterLineField1.DatabaseFieldLink = "InterlineScac";
            this.txtInterLineField1.Location = new System.Drawing.Point(857, 302);
            this.txtInterLineField1.MaxLength = 50;
            this.txtInterLineField1.Name = "txtInterLineField1";
            this.txtInterLineField1.Size = new System.Drawing.Size(92, 20);
            this.txtInterLineField1.TabIndex = 17;
            this.txtInterLineField1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtInterLineField1.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtTerm
            // 
            this.txtTerm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTerm.DatabaseFieldLink = "FbPaymtTermsCode";
            this.txtTerm.Location = new System.Drawing.Point(1047, 39);
            this.txtTerm.MaxLength = 20;
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(115, 20);
            this.txtTerm.TabIndex = 3;
            this.txtTerm.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtTerm.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTerm_KeyPress);
            // 
            // txtServiceCode
            // 
            this.txtServiceCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServiceCode.DatabaseFieldLink = "SrvcReqCode";
            this.txtServiceCode.Location = new System.Drawing.Point(1047, 65);
            this.txtServiceCode.MaxLength = 50;
            this.txtServiceCode.Name = "txtServiceCode";
            this.txtServiceCode.Size = new System.Drawing.Size(115, 20);
            this.txtServiceCode.TabIndex = 4;
            this.txtServiceCode.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtServiceCode.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtDistance
            // 
            this.txtDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDistance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDistance.DatabaseFieldLink = "LmDist";
            this.txtDistance.Location = new System.Drawing.Point(1047, 208);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(115, 20);
            this.txtDistance.TabIndex = 11;
            this.txtDistance.ValueType = CommonLibrary.CommonEnum.ValueType.MEASUREMENT;
            this.txtDistance.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtPieces
            // 
            this.txtPieces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPieces.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPieces.DatabaseFieldLink = "FbPcsCnt";
            this.txtPieces.Location = new System.Drawing.Point(1047, 182);
            this.txtPieces.Name = "txtPieces";
            this.txtPieces.Size = new System.Drawing.Size(115, 20);
            this.txtPieces.TabIndex = 10;
            this.txtPieces.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            this.txtPieces.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtPkgType
            // 
            this.txtPkgType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPkgType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPkgType.DatabaseFieldLink = "FbPkgType";
            this.txtPkgType.Location = new System.Drawing.Point(1047, 156);
            this.txtPkgType.Name = "txtPkgType";
            this.txtPkgType.Size = new System.Drawing.Size(115, 20);
            this.txtPkgType.TabIndex = 9;
            this.txtPkgType.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtPkgType.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtFnclWt
            // 
            this.txtFnclWt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFnclWt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFnclWt.DatabaseFieldLink = "FbFnclWt";
            this.txtFnclWt.Location = new System.Drawing.Point(1047, 130);
            this.txtFnclWt.Name = "txtFnclWt";
            this.txtFnclWt.Size = new System.Drawing.Size(115, 20);
            this.txtFnclWt.TabIndex = 8;
            this.txtFnclWt.ValueType = CommonLibrary.CommonEnum.ValueType.MEASUREMENT;
            this.txtFnclWt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            // 
            // txtActualWt
            // 
            this.txtActualWt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtActualWt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtActualWt.DatabaseFieldLink = "FbActualWt";
            this.txtActualWt.Location = new System.Drawing.Point(1047, 104);
            this.txtActualWt.Name = "txtActualWt";
            this.txtActualWt.Size = new System.Drawing.Size(115, 20);
            this.txtActualWt.TabIndex = 7;
            this.txtActualWt.ValueType = CommonLibrary.CommonEnum.ValueType.MEASUREMENT;
            this.txtActualWt.TextChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtActualWt.Validated += new System.EventHandler(this.txtActualWt_Validated);
            // 
            // lblInterLineField
            // 
            this.lblInterLineField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInterLineField.AutoSize = true;
            this.lblInterLineField.Location = new System.Drawing.Point(764, 305);
            this.lblInterLineField.Name = "lblInterLineField";
            this.lblInterLineField.Size = new System.Drawing.Size(87, 13);
            this.lblInterLineField.TabIndex = 30;
            this.lblInterLineField.Text = "InterLine Fields  :";
            // 
            // lblCustRef2
            // 
            this.lblCustRef2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCustRef2.AutoSize = true;
            this.lblCustRef2.Location = new System.Drawing.Point(7, 331);
            this.lblCustRef2.Name = "lblCustRef2";
            this.lblCustRef2.Size = new System.Drawing.Size(60, 13);
            this.lblCustRef2.TabIndex = 29;
            this.lblCustRef2.Text = "Cust Ref2 :";
            // 
            // lblCustRef1
            // 
            this.lblCustRef1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCustRef1.AutoSize = true;
            this.lblCustRef1.Location = new System.Drawing.Point(7, 305);
            this.lblCustRef1.Name = "lblCustRef1";
            this.lblCustRef1.Size = new System.Drawing.Size(60, 13);
            this.lblCustRef1.TabIndex = 28;
            this.lblCustRef1.Text = "Cust Ref1 :";
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(964, 211);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(55, 13);
            this.lblDistance.TabIndex = 27;
            this.lblDistance.Text = "Distance :";
            // 
            // lblPieces
            // 
            this.lblPieces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPieces.AutoSize = true;
            this.lblPieces.Location = new System.Drawing.Point(964, 185);
            this.lblPieces.Name = "lblPieces";
            this.lblPieces.Size = new System.Drawing.Size(45, 13);
            this.lblPieces.TabIndex = 26;
            this.lblPieces.Text = "Pieces :";
            // 
            // lblPkgType
            // 
            this.lblPkgType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPkgType.AutoSize = true;
            this.lblPkgType.Location = new System.Drawing.Point(964, 159);
            this.lblPkgType.Name = "lblPkgType";
            this.lblPkgType.Size = new System.Drawing.Size(59, 13);
            this.lblPkgType.TabIndex = 25;
            this.lblPkgType.Text = "Pkg Type :";
            // 
            // lblFnclWt
            // 
            this.lblFnclWt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFnclWt.AutoSize = true;
            this.lblFnclWt.Location = new System.Drawing.Point(964, 133);
            this.lblFnclWt.Name = "lblFnclWt";
            this.lblFnclWt.Size = new System.Drawing.Size(50, 13);
            this.lblFnclWt.TabIndex = 14;
            this.lblFnclWt.Text = "Fncl Wt :";
            // 
            // lblActualWt
            // 
            this.lblActualWt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblActualWt.AutoSize = true;
            this.lblActualWt.Location = new System.Drawing.Point(964, 107);
            this.lblActualWt.Name = "lblActualWt";
            this.lblActualWt.Size = new System.Drawing.Size(60, 13);
            this.lblActualWt.TabIndex = 13;
            this.lblActualWt.Text = "Actual Wt :";
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Location = new System.Drawing.Point(964, 68);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(77, 13);
            this.lblService.TabIndex = 7;
            this.lblService.Text = "Service Code :";
            // 
            // lblTerm
            // 
            this.lblTerm.AutoSize = true;
            this.lblTerm.Location = new System.Drawing.Point(964, 42);
            this.lblTerm.Name = "lblTerm";
            this.lblTerm.Size = new System.Drawing.Size(37, 13);
            this.lblTerm.TabIndex = 6;
            this.lblTerm.Text = "Term :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(964, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date :";
            // 
            // grdFreightBill
            // 
            this.grdFreightBill.AllowUserToAddRows = false;
            this.grdFreightBill.AllowUserToDeleteRows = false;
            this.grdFreightBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdFreightBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFreightBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FBInvId,
            this.FBInvKey,
            this.FBFbId,
            this.FBFbKey,
            this.FBFbCurrencyQual,
            this.FBFbAmt,
            this.FBFbCreatDtm,
            this.FBFbPaymtTermsCode,
            this.FBSrvcReqCode,
            this.FBAlOrig1,
            this.FBAlOrig2,
            this.FBAlOrig3,
            this.FBAlOrig4,
            this.FBAlCityOrig,
            this.FBAlStateProvOrig,
            this.FBAlPostCodeOrig,
            this.FBAlCntryCodeOrig,
            this.FBAlDest1,
            this.FBAlDest2,
            this.FBAlDest3,
            this.FBAlDest4,
            this.FBAlCityDest,
            this.FBAlStateProvDest,
            this.FBAlPostCodeDest,
            this.FBAlCntryCodeDest,
            this.FBFbActualWt,
            this.FBFbFnclWt,
            this.FBFbPkgType,
            this.FBFbPcsCnt,
            this.FBLmDist,
            this.FBCaInfo1Raw,
            this.FBCaInfo2Raw,
            this.FBInterlineScac,
            this.FBInterlineQual,
            this.FBInterlineAmt,
            this.FBLmPkupActualDtm,
            this.FBLmAtaDtm,
            this.FBFbLnCnt,
            this.FBVendLabl,
            this.FBAcctNumVendBlng,
            this.FBPriceLaneLabl,
            this.FBLmLaneLabl,
            this.FBFbFrghtAmt,
            this.FBFbDscntAmt,
            this.FBFbAccAmt,
            this.FBFbTaxAmt});
            this.grdFreightBill.Location = new System.Drawing.Point(80, 13);
            this.grdFreightBill.MultiSelect = false;
            this.grdFreightBill.Name = "grdFreightBill";
            this.grdFreightBill.RowHeadersVisible = false;
            this.grdFreightBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFreightBill.Size = new System.Drawing.Size(710, 98);
            this.grdFreightBill.TabIndex = 1;
            this.grdFreightBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFreightBill_CellEndEdit);
            this.grdFreightBill.SelectionChanged += new System.EventHandler(this.grdFreightBill_SelectionChanged);
            // 
            // FBInvId
            // 
            this.FBInvId.DataPropertyName = "InvId";
            this.FBInvId.HeaderText = "InvId";
            this.FBInvId.Name = "FBInvId";
            this.FBInvId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FBInvId.Visible = false;
            // 
            // FBInvKey
            // 
            this.FBInvKey.DataPropertyName = "InvKey";
            this.FBInvKey.HeaderText = "InvKey";
            this.FBInvKey.Name = "FBInvKey";
            this.FBInvKey.Visible = false;
            // 
            // FBFbId
            // 
            this.FBFbId.DataPropertyName = "FbId";
            this.FBFbId.HeaderText = "FbId";
            this.FBFbId.MaxInputLength = 23;
            this.FBFbId.Name = "FBFbId";
            this.FBFbId.Visible = false;
            // 
            // FBFbKey
            // 
            this.FBFbKey.DataPropertyName = "FbKey";
            this.FBFbKey.HeaderText = "Freight Bill Key";
            this.FBFbKey.MaxInputLength = 50;
            this.FBFbKey.Name = "FBFbKey";
            this.FBFbKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBFbKey.Width = 300;
            // 
            // FBFbCurrencyQual
            // 
            this.FBFbCurrencyQual.DataPropertyName = "FbCurrencyQual";
            this.FBFbCurrencyQual.HeaderText = "Currency";
            this.FBFbCurrencyQual.Name = "FBFbCurrencyQual";
            this.FBFbCurrencyQual.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FBFbAmt
            // 
            this.FBFbAmt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FBFbAmt.DataPropertyName = "FbAmt";
            dataGridViewCellStyle8.Format = "C4";
            dataGridViewCellStyle8.NullValue = null;
            this.FBFbAmt.DefaultCellStyle = dataGridViewCellStyle8;
            this.FBFbAmt.HeaderText = "Freight Bill Amount";
            this.FBFbAmt.Name = "FBFbAmt";
            this.FBFbAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FBFbCreatDtm
            // 
            this.FBFbCreatDtm.DataPropertyName = "FbCreatDtm";
            this.FBFbCreatDtm.HeaderText = "FbCreatDtm";
            this.FBFbCreatDtm.Name = "FBFbCreatDtm";
            this.FBFbCreatDtm.Visible = false;
            // 
            // FBFbPaymtTermsCode
            // 
            this.FBFbPaymtTermsCode.DataPropertyName = "FbPaymtTermsCode";
            this.FBFbPaymtTermsCode.HeaderText = "FbPaymtTermsCode";
            this.FBFbPaymtTermsCode.Name = "FBFbPaymtTermsCode";
            this.FBFbPaymtTermsCode.Visible = false;
            // 
            // FBSrvcReqCode
            // 
            this.FBSrvcReqCode.DataPropertyName = "SrvcReqCode";
            this.FBSrvcReqCode.HeaderText = "SrvcReqCode";
            this.FBSrvcReqCode.Name = "FBSrvcReqCode";
            this.FBSrvcReqCode.Visible = false;
            // 
            // FBAlOrig1
            // 
            this.FBAlOrig1.DataPropertyName = "AlOrig1";
            this.FBAlOrig1.HeaderText = "AlOrig1";
            this.FBAlOrig1.Name = "FBAlOrig1";
            this.FBAlOrig1.Visible = false;
            // 
            // FBAlOrig2
            // 
            this.FBAlOrig2.DataPropertyName = "AlOrig2";
            this.FBAlOrig2.HeaderText = "AlOrig2";
            this.FBAlOrig2.Name = "FBAlOrig2";
            this.FBAlOrig2.Visible = false;
            // 
            // FBAlOrig3
            // 
            this.FBAlOrig3.DataPropertyName = "AlOrig3";
            this.FBAlOrig3.HeaderText = "AlOrig3";
            this.FBAlOrig3.Name = "FBAlOrig3";
            this.FBAlOrig3.Visible = false;
            // 
            // FBAlOrig4
            // 
            this.FBAlOrig4.DataPropertyName = "AlOrig4";
            this.FBAlOrig4.HeaderText = "AlOrig4";
            this.FBAlOrig4.Name = "FBAlOrig4";
            this.FBAlOrig4.Visible = false;
            // 
            // FBAlCityOrig
            // 
            this.FBAlCityOrig.DataPropertyName = "AlCityOrig";
            this.FBAlCityOrig.HeaderText = "AlCityOrig";
            this.FBAlCityOrig.Name = "FBAlCityOrig";
            this.FBAlCityOrig.Visible = false;
            // 
            // FBAlStateProvOrig
            // 
            this.FBAlStateProvOrig.DataPropertyName = "AlStateProvOrig";
            this.FBAlStateProvOrig.HeaderText = "AlStateProvOrig";
            this.FBAlStateProvOrig.Name = "FBAlStateProvOrig";
            this.FBAlStateProvOrig.Visible = false;
            // 
            // FBAlPostCodeOrig
            // 
            this.FBAlPostCodeOrig.DataPropertyName = "AlPostCodeOrig";
            this.FBAlPostCodeOrig.HeaderText = "AlPostCodeOrig";
            this.FBAlPostCodeOrig.Name = "FBAlPostCodeOrig";
            this.FBAlPostCodeOrig.Visible = false;
            // 
            // FBAlCntryCodeOrig
            // 
            this.FBAlCntryCodeOrig.DataPropertyName = "AlCntryCodeOrig";
            this.FBAlCntryCodeOrig.HeaderText = "AlCntryCodeOrig";
            this.FBAlCntryCodeOrig.Name = "FBAlCntryCodeOrig";
            this.FBAlCntryCodeOrig.Visible = false;
            // 
            // FBAlDest1
            // 
            this.FBAlDest1.DataPropertyName = "AlDest1";
            this.FBAlDest1.HeaderText = "AlDest1";
            this.FBAlDest1.Name = "FBAlDest1";
            this.FBAlDest1.Visible = false;
            // 
            // FBAlDest2
            // 
            this.FBAlDest2.DataPropertyName = "AlDest2";
            this.FBAlDest2.HeaderText = "AlDest2";
            this.FBAlDest2.Name = "FBAlDest2";
            this.FBAlDest2.Visible = false;
            // 
            // FBAlDest3
            // 
            this.FBAlDest3.DataPropertyName = "AlDest3";
            this.FBAlDest3.HeaderText = "AlDest3";
            this.FBAlDest3.Name = "FBAlDest3";
            this.FBAlDest3.Visible = false;
            // 
            // FBAlDest4
            // 
            this.FBAlDest4.DataPropertyName = "AlDest4";
            this.FBAlDest4.HeaderText = "AlDest4";
            this.FBAlDest4.Name = "FBAlDest4";
            this.FBAlDest4.Visible = false;
            // 
            // FBAlCityDest
            // 
            this.FBAlCityDest.DataPropertyName = "AlCityDest";
            this.FBAlCityDest.HeaderText = "AlCityDest";
            this.FBAlCityDest.Name = "FBAlCityDest";
            this.FBAlCityDest.Visible = false;
            // 
            // FBAlStateProvDest
            // 
            this.FBAlStateProvDest.DataPropertyName = "AlStateProvDest";
            this.FBAlStateProvDest.HeaderText = "AlStateProvDest";
            this.FBAlStateProvDest.Name = "FBAlStateProvDest";
            this.FBAlStateProvDest.Visible = false;
            // 
            // FBAlPostCodeDest
            // 
            this.FBAlPostCodeDest.DataPropertyName = "AlPostCodeDest";
            this.FBAlPostCodeDest.HeaderText = "AlPostCodeDest";
            this.FBAlPostCodeDest.Name = "FBAlPostCodeDest";
            this.FBAlPostCodeDest.Visible = false;
            // 
            // FBAlCntryCodeDest
            // 
            this.FBAlCntryCodeDest.DataPropertyName = "AlCntryCodeDest";
            this.FBAlCntryCodeDest.HeaderText = "AlCntryCodeDest";
            this.FBAlCntryCodeDest.Name = "FBAlCntryCodeDest";
            this.FBAlCntryCodeDest.Visible = false;
            // 
            // FBFbActualWt
            // 
            this.FBFbActualWt.DataPropertyName = "FbActualWt";
            this.FBFbActualWt.HeaderText = "FbActualWt";
            this.FBFbActualWt.Name = "FBFbActualWt";
            this.FBFbActualWt.Visible = false;
            // 
            // FBFbFnclWt
            // 
            this.FBFbFnclWt.DataPropertyName = "FbFnclWt";
            this.FBFbFnclWt.HeaderText = "FbFnclWt";
            this.FBFbFnclWt.Name = "FBFbFnclWt";
            this.FBFbFnclWt.Visible = false;
            // 
            // FBFbPkgType
            // 
            this.FBFbPkgType.DataPropertyName = "FbPkgType";
            this.FBFbPkgType.HeaderText = "FbPkgType";
            this.FBFbPkgType.Name = "FBFbPkgType";
            this.FBFbPkgType.Visible = false;
            // 
            // FBFbPcsCnt
            // 
            this.FBFbPcsCnt.DataPropertyName = "FbPcsCnt";
            this.FBFbPcsCnt.HeaderText = "FbPcsCnt";
            this.FBFbPcsCnt.Name = "FBFbPcsCnt";
            this.FBFbPcsCnt.Visible = false;
            // 
            // FBLmDist
            // 
            this.FBLmDist.DataPropertyName = "LmDist";
            this.FBLmDist.HeaderText = "LmDist";
            this.FBLmDist.Name = "FBLmDist";
            this.FBLmDist.Visible = false;
            // 
            // FBCaInfo1Raw
            // 
            this.FBCaInfo1Raw.DataPropertyName = "CaInfo1Raw";
            this.FBCaInfo1Raw.HeaderText = "CaInfo1Raw";
            this.FBCaInfo1Raw.Name = "FBCaInfo1Raw";
            this.FBCaInfo1Raw.Visible = false;
            // 
            // FBCaInfo2Raw
            // 
            this.FBCaInfo2Raw.DataPropertyName = "CaInfo2Raw";
            this.FBCaInfo2Raw.HeaderText = "CaInfo2Raw";
            this.FBCaInfo2Raw.Name = "FBCaInfo2Raw";
            this.FBCaInfo2Raw.Visible = false;
            // 
            // FBInterlineScac
            // 
            this.FBInterlineScac.DataPropertyName = "InterlineScac";
            this.FBInterlineScac.HeaderText = "InterlineScac";
            this.FBInterlineScac.Name = "FBInterlineScac";
            this.FBInterlineScac.Visible = false;
            // 
            // FBInterlineQual
            // 
            this.FBInterlineQual.DataPropertyName = "InterlineQual";
            this.FBInterlineQual.HeaderText = "InterlineQual";
            this.FBInterlineQual.Name = "FBInterlineQual";
            this.FBInterlineQual.Visible = false;
            // 
            // FBInterlineAmt
            // 
            this.FBInterlineAmt.DataPropertyName = "InterlineAmt";
            this.FBInterlineAmt.HeaderText = "InterlineAmt";
            this.FBInterlineAmt.Name = "FBInterlineAmt";
            this.FBInterlineAmt.Visible = false;
            // 
            // FBLmPkupActualDtm
            // 
            this.FBLmPkupActualDtm.DataPropertyName = "LmPkupActualDtm";
            this.FBLmPkupActualDtm.HeaderText = "LmPkupActualDtm";
            this.FBLmPkupActualDtm.Name = "FBLmPkupActualDtm";
            this.FBLmPkupActualDtm.Visible = false;
            // 
            // FBLmAtaDtm
            // 
            this.FBLmAtaDtm.DataPropertyName = "LmAtaDtm";
            this.FBLmAtaDtm.HeaderText = "LmAtaDtm";
            this.FBLmAtaDtm.Name = "FBLmAtaDtm";
            this.FBLmAtaDtm.Visible = false;
            // 
            // FBFbLnCnt
            // 
            this.FBFbLnCnt.DataPropertyName = "FbLnCnt";
            this.FBFbLnCnt.HeaderText = "FbLnCnt";
            this.FBFbLnCnt.Name = "FBFbLnCnt";
            this.FBFbLnCnt.Visible = false;
            // 
            // FBVendLabl
            // 
            this.FBVendLabl.DataPropertyName = "VendLabl";
            this.FBVendLabl.HeaderText = "VendLabl";
            this.FBVendLabl.Name = "FBVendLabl";
            this.FBVendLabl.Visible = false;
            // 
            // FBAcctNumVendBlng
            // 
            this.FBAcctNumVendBlng.DataPropertyName = "AcctNumVendBlng";
            this.FBAcctNumVendBlng.HeaderText = "Account";
            this.FBAcctNumVendBlng.Name = "FBAcctNumVendBlng";
            this.FBAcctNumVendBlng.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FBAcctNumVendBlng.Visible = false;
            // 
            // FBPriceLaneLabl
            // 
            this.FBPriceLaneLabl.DataPropertyName = "PriceLaneLabl";
            this.FBPriceLaneLabl.HeaderText = "PriceLaneLabl";
            this.FBPriceLaneLabl.Name = "FBPriceLaneLabl";
            this.FBPriceLaneLabl.Visible = false;
            // 
            // FBLmLaneLabl
            // 
            this.FBLmLaneLabl.DataPropertyName = "LmLaneLabl";
            this.FBLmLaneLabl.HeaderText = "LmLaneLabl";
            this.FBLmLaneLabl.Name = "FBLmLaneLabl";
            this.FBLmLaneLabl.Visible = false;
            // 
            // FBFbFrghtAmt
            // 
            this.FBFbFrghtAmt.HeaderText = "FbFrghtAmt";
            this.FBFbFrghtAmt.Name = "FBFbFrghtAmt";
            this.FBFbFrghtAmt.Visible = false;
            // 
            // FBFbDscntAmt
            // 
            this.FBFbDscntAmt.HeaderText = "FbDscntAmt";
            this.FBFbDscntAmt.Name = "FBFbDscntAmt";
            this.FBFbDscntAmt.Visible = false;
            // 
            // FBFbAccAmt
            // 
            this.FBFbAccAmt.HeaderText = "FbAccAmt";
            this.FBFbAccAmt.Name = "FBFbAccAmt";
            this.FBFbAccAmt.Visible = false;
            // 
            // FBFbTaxAmt
            // 
            this.FBFbTaxAmt.HeaderText = "FbTaxAmt";
            this.FBFbTaxAmt.Name = "FBFbTaxAmt";
            this.FBFbTaxAmt.Visible = false;
            // 
            // grpBoxMode
            // 
            this.grpBoxMode.Controls.Add(this.chkBoxFBLnAdd);
            this.grpBoxMode.Controls.Add(this.lblFBLnAdd);
            this.grpBoxMode.Controls.Add(this.chkBoxFBAdd);
            this.grpBoxMode.Controls.Add(this.lblFBAdd);
            this.grpBoxMode.Controls.Add(this.lblInvoiceAdd);
            this.grpBoxMode.Controls.Add(this.lblAutosave);
            this.grpBoxMode.Controls.Add(this.chkBoxInvoiceAdd);
            this.grpBoxMode.Controls.Add(this.lblMode2);
            this.grpBoxMode.Controls.Add(this.lblMode1);
            this.grpBoxMode.Controls.Add(this.radioSingleFB);
            this.grpBoxMode.Controls.Add(this.radioInvoiceFB);
            this.grpBoxMode.Location = new System.Drawing.Point(329, 28);
            this.grpBoxMode.Name = "grpBoxMode";
            this.grpBoxMode.Size = new System.Drawing.Size(115, 165);
            this.grpBoxMode.TabIndex = 3;
            this.grpBoxMode.TabStop = false;
            this.grpBoxMode.Text = "Mode";
            // 
            // chkBoxFBLnAdd
            // 
            this.chkBoxFBLnAdd.AutoSize = true;
            this.chkBoxFBLnAdd.Location = new System.Drawing.Point(92, 143);
            this.chkBoxFBLnAdd.Name = "chkBoxFBLnAdd";
            this.chkBoxFBLnAdd.Size = new System.Drawing.Size(15, 14);
            this.chkBoxFBLnAdd.TabIndex = 85;
            this.chkBoxFBLnAdd.UseVisualStyleBackColor = true;
            // 
            // lblFBLnAdd
            // 
            this.lblFBLnAdd.AutoSize = true;
            this.lblFBLnAdd.Location = new System.Drawing.Point(5, 143);
            this.lblFBLnAdd.Name = "lblFBLnAdd";
            this.lblFBLnAdd.Size = new System.Drawing.Size(89, 13);
            this.lblFBLnAdd.TabIndex = 84;
            this.lblFBLnAdd.Text = "FBLine item add :";
            // 
            // chkBoxFBAdd
            // 
            this.chkBoxFBAdd.AutoSize = true;
            this.chkBoxFBAdd.Location = new System.Drawing.Point(92, 123);
            this.chkBoxFBAdd.Name = "chkBoxFBAdd";
            this.chkBoxFBAdd.Size = new System.Drawing.Size(15, 14);
            this.chkBoxFBAdd.TabIndex = 83;
            this.chkBoxFBAdd.UseVisualStyleBackColor = true;
            // 
            // lblFBAdd
            // 
            this.lblFBAdd.AutoSize = true;
            this.lblFBAdd.Location = new System.Drawing.Point(5, 123);
            this.lblFBAdd.Name = "lblFBAdd";
            this.lblFBAdd.Size = new System.Drawing.Size(81, 13);
            this.lblFBAdd.TabIndex = 82;
            this.lblFBAdd.Text = "Freight bill add :";
            // 
            // lblInvoiceAdd
            // 
            this.lblInvoiceAdd.AutoSize = true;
            this.lblInvoiceAdd.Location = new System.Drawing.Point(6, 103);
            this.lblInvoiceAdd.Name = "lblInvoiceAdd";
            this.lblInvoiceAdd.Size = new System.Drawing.Size(69, 13);
            this.lblInvoiceAdd.TabIndex = 81;
            this.lblInvoiceAdd.Text = "Invoice add :";
            // 
            // lblAutosave
            // 
            this.lblAutosave.AutoSize = true;
            this.lblAutosave.Location = new System.Drawing.Point(6, 84);
            this.lblAutosave.Name = "lblAutosave";
            this.lblAutosave.Size = new System.Drawing.Size(73, 13);
            this.lblAutosave.TabIndex = 80;
            this.lblAutosave.Text = "Autosave per:";
            // 
            // chkBoxInvoiceAdd
            // 
            this.chkBoxInvoiceAdd.AutoSize = true;
            this.chkBoxInvoiceAdd.Location = new System.Drawing.Point(92, 103);
            this.chkBoxInvoiceAdd.Name = "chkBoxInvoiceAdd";
            this.chkBoxInvoiceAdd.Size = new System.Drawing.Size(15, 14);
            this.chkBoxInvoiceAdd.TabIndex = 79;
            this.chkBoxInvoiceAdd.UseVisualStyleBackColor = true;
            // 
            // lblMode2
            // 
            this.lblMode2.AutoSize = true;
            this.lblMode2.Location = new System.Drawing.Point(6, 52);
            this.lblMode2.Name = "lblMode2";
            this.lblMode2.Size = new System.Drawing.Size(93, 13);
            this.lblMode2.TabIndex = 78;
            this.lblMode2.Text = "Single Freight Bill :";
            // 
            // lblMode1
            // 
            this.lblMode1.AutoSize = true;
            this.lblMode1.Location = new System.Drawing.Point(6, 19);
            this.lblMode1.Name = "lblMode1";
            this.lblMode1.Size = new System.Drawing.Size(101, 13);
            this.lblMode1.TabIndex = 77;
            this.lblMode1.Text = "Invoice\\Freight Bill :";
            // 
            // radioSingleFB
            // 
            this.radioSingleFB.AutoSize = true;
            this.radioSingleFB.Location = new System.Drawing.Point(6, 68);
            this.radioSingleFB.Name = "radioSingleFB";
            this.radioSingleFB.Size = new System.Drawing.Size(14, 13);
            this.radioSingleFB.TabIndex = 1;
            this.radioSingleFB.UseVisualStyleBackColor = true;
            this.radioSingleFB.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // radioInvoiceFB
            // 
            this.radioInvoiceFB.AutoSize = true;
            this.radioInvoiceFB.Checked = true;
            this.radioInvoiceFB.Location = new System.Drawing.Point(6, 35);
            this.radioInvoiceFB.Name = "radioInvoiceFB";
            this.radioInvoiceFB.Size = new System.Drawing.Size(14, 13);
            this.radioInvoiceFB.TabIndex = 0;
            this.radioInvoiceFB.TabStop = true;
            this.radioInvoiceFB.UseVisualStyleBackColor = true;
            this.radioInvoiceFB.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
            // 
            // frmDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1192, 726);
            this.Controls.Add(this.grpBoxMode);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.grpBoxImageGroup);
            this.Controls.Add(this.grpBoxInvoice);
            this.Controls.Add(this.grpBoxFreightBill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 738);
            this.Name = "frmDataEntry";
            this.Text = "Data Entry";
            this.Load += new System.EventHandler(this.frmDataEntry_Load);
            this.Enter += new System.EventHandler(this.frmDataEntry_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDataEntry_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDataEntry_KeyDown);
            this.grpBoxInvoice.ResumeLayout(false);
            this.grpBoxInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).EndInit();
            this.grpBoxImageGroup.ResumeLayout(false);
            this.grpBoxImageGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpBoxFbLine.ResumeLayout(false);
            this.grpBoxFbLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBLine)).EndInit();
            this.grpBoxShipperAddress.ResumeLayout(false);
            this.grpBoxShipperAddress.PerformLayout();
            this.grpBoxConsigneeAddress.ResumeLayout(false);
            this.grpBoxConsigneeAddress.PerformLayout();
            this.grpBoxFreightBill.ResumeLayout(false);
            this.grpBoxFreightBill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFXI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightBill)).EndInit();
            this.grpBoxMode.ResumeLayout(false);
            this.grpBoxMode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxInvoice;
        private FormControls.TraxDEDataGridView grdInvoice;
        private System.Windows.Forms.GroupBox grpBoxImageGroup;
        private FormControls.TraxDEDataGridView grdImageGroup;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDELabel lblSearch;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendReview;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonRestart;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        //private TraxDEDataGridViewTextBoxColumn InvoiceInvKey;
        private System.Windows.Forms.GroupBox grpBoxFbLine;
        private System.Windows.Forms.Button btnDeleteFBLn;
        private System.Windows.Forms.Button btnAddFBLn;
        private FormControls.TraxDEDataGridView grdFreightBill;
        private FormControls.TraxDELabel lblDate;
        private FormControls.TraxDELabel lblTerm;
        private FormControls.TraxDELabel lblService;
        private FormControls.TraxDELabel lblActualWt;
        private FormControls.TraxDELabel lblFnclWt;
        private FormControls.TraxDELabel lblPkgType;
        private FormControls.TraxDELabel lblPieces;
        private FormControls.TraxDELabel lblDistance;
        private FormControls.TraxDELabel lblCustRef1;
        private FormControls.TraxDELabel lblCustRef2;
        private FormControls.TraxDELabel lblInterLineField;
        private FormControls.TraxDETextBox txtActualWt;
        private FormControls.TraxDETextBox txtFnclWt;
        private FormControls.TraxDETextBox txtPkgType;
        private FormControls.TraxDETextBox txtPieces;
        private FormControls.TraxDETextBox txtDistance;
        private FormControls.TraxDETextBox txtServiceCode;
        private FormControls.TraxDETextBox txtTerm;
        private FormControls.TraxDETextBox txtInterLineField1;
        private FormControls.TraxDETextBox txtCustRef2;
        private FormControls.TraxDETextBox txtCustRef1;
        private FormControls.TraxDETextBox txtInterLineField2;
        private FormControls.TraxDETextBox txtInterLineField3;
        private System.Windows.Forms.GroupBox grpBoxShipperAddress;
        private FormControls.TraxDETextBox txtShipperCountry;
        private FormControls.TraxDETextBox txtShipperZip;
        private FormControls.TraxDETextBox txtShipperSt;
        private FormControls.TraxDETextBox txtShipperCity;
        private FormControls.TraxDETextBox txtShipperAddress2;
        private FormControls.TraxDETextBox txtShipperAddress1;
        private FormControls.TraxDETextBox txtShipperName2;
        private FormControls.TraxDETextBox txtShipperName1;
        private FormControls.TraxDELabel lblShipperCountry;
        private FormControls.TraxDELabel lblShipperZip;
        private FormControls.TraxDELabel lblShipperAddress;
        private FormControls.TraxDELabel lblShipperName;
        private FormControls.TraxDELabel lblShipperSt;
        private FormControls.TraxDELabel lblShipperCity;
        private System.Windows.Forms.GroupBox grpBoxConsigneeAddress;
        private FormControls.TraxDETextBox txtConsigneeCountry;
        private FormControls.TraxDETextBox txtConsigneeZip;
        private FormControls.TraxDETextBox txtConsigneeSt;
        private FormControls.TraxDETextBox txtConsigneeCity;
        private FormControls.TraxDETextBox txtConsigneeAddress2;
        private FormControls.TraxDETextBox txtConsigneeAddress1;
        private FormControls.TraxDETextBox txtConsigneeName2;
        private FormControls.TraxDETextBox txtConsigneeName1;
        private FormControls.TraxDELabel lblConsigneeCountry;
        private FormControls.TraxDELabel lblConsigneeZip;
        private FormControls.TraxDELabel lblConsigneeAddress;
        private FormControls.TraxDELabel lblConsigneeName;
        private FormControls.TraxDELabel lblConsigneeSt;
        private FormControls.TraxDELabel lblConsigneeCity;
        private FormControls.TraxDELabel lblPickUp;
        private FormControls.TraxDELabel lblDelivered;
        private FormControls.TraxDELabel lblFBAmount;
        private System.Windows.Forms.Button btnAddFB;
        private System.Windows.Forms.Button btnDeleteFB;
        private System.Windows.Forms.GroupBox grpBoxFreightBill;
        private TraxDELabel lblTotal;
        private TraxDEMaskedTextBox mtxtDate;
        private TraxDEMaskedTextBox mtxtPickUp;
        private TraxDEMaskedTextBox mtxtDelivered;
        private TraxDETextBox txtPriceLane;
        private TraxDETextBox txtLaneLabel;
        private TraxDELabel lblLaneLabel;
        private TraxDELabel lblPriceLane;
        private TraxDELabel lblFBAmountTotal;
        private TraxDELabel lblFBTotal;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveClose;
        private TraxDELabel lblInvoiceCount;
        private TraxDELabel lblInvoiceCounter;
        private TraxDELabel lblFBCount;
        private TraxDELabel lblFBCounter;
        private TraxDEDataGridViewTextBoxColumn BatchNumber;
        private TraxDEDataGridViewTextBoxColumn BatchStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendSCAC;
        private TraxDEDataGridViewTextBoxColumn Operator;
        private TraxDEDataGridViewTextBoxColumn OwnerCode;
        private System.Windows.Forms.GroupBox grpBoxMode;
        private System.Windows.Forms.RadioButton radioSingleFB;
        private System.Windows.Forms.RadioButton radioInvoiceFB;
        private TraxDELabel lblMode2;
        private TraxDELabel lblMode1;
        private TraxDEDataGridViewTextBoxColumn FBInvId;
        private TraxDEDataGridViewTextBoxColumn FBInvKey;
        private TraxDEDataGridViewTextBoxColumn FBFbId;
        private TraxDEDataGridViewTextBoxColumn FBFbKey;
        private System.Windows.Forms.DataGridViewComboBoxColumn FBFbCurrencyQual;
        private TraxDEDataGridViewTextBoxColumn FBFbAmt;
        private TraxDEDataGridViewTextBoxColumn FBFbCreatDtm;
        private TraxDEDataGridViewTextBoxColumn FBFbPaymtTermsCode;
        private TraxDEDataGridViewTextBoxColumn FBSrvcReqCode;
        private TraxDEDataGridViewTextBoxColumn FBAlOrig1;
        private TraxDEDataGridViewTextBoxColumn FBAlOrig2;
        private TraxDEDataGridViewTextBoxColumn FBAlOrig3;
        private TraxDEDataGridViewTextBoxColumn FBAlOrig4;
        private TraxDEDataGridViewTextBoxColumn FBAlCityOrig;
        private TraxDEDataGridViewTextBoxColumn FBAlStateProvOrig;
        private TraxDEDataGridViewTextBoxColumn FBAlPostCodeOrig;
        private TraxDEDataGridViewTextBoxColumn FBAlCntryCodeOrig;
        private TraxDEDataGridViewTextBoxColumn FBAlDest1;
        private TraxDEDataGridViewTextBoxColumn FBAlDest2;
        private TraxDEDataGridViewTextBoxColumn FBAlDest3;
        private TraxDEDataGridViewTextBoxColumn FBAlDest4;
        private TraxDEDataGridViewTextBoxColumn FBAlCityDest;
        private TraxDEDataGridViewTextBoxColumn FBAlStateProvDest;
        private TraxDEDataGridViewTextBoxColumn FBAlPostCodeDest;
        private TraxDEDataGridViewTextBoxColumn FBAlCntryCodeDest;
        private TraxDEDataGridViewTextBoxColumn FBFbActualWt;
        private TraxDEDataGridViewTextBoxColumn FBFbFnclWt;
        private TraxDEDataGridViewTextBoxColumn FBFbPkgType;
        private TraxDEDataGridViewTextBoxColumn FBFbPcsCnt;
        private TraxDEDataGridViewTextBoxColumn FBLmDist;
        private TraxDEDataGridViewTextBoxColumn FBCaInfo1Raw;
        private TraxDEDataGridViewTextBoxColumn FBCaInfo2Raw;
        private TraxDEDataGridViewTextBoxColumn FBInterlineScac;
        private TraxDEDataGridViewTextBoxColumn FBInterlineQual;
        private TraxDEDataGridViewTextBoxColumn FBInterlineAmt;
        private TraxDEDataGridViewTextBoxColumn FBLmPkupActualDtm;
        private TraxDEDataGridViewTextBoxColumn FBLmAtaDtm;
        private System.Windows.Forms.DataGridViewTextBoxColumn FBFbLnCnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn FBVendLabl;
        private TraxDEDataGridViewTextBoxColumn FBAcctNumVendBlng;
        private System.Windows.Forms.DataGridViewTextBoxColumn FBPriceLaneLabl;
        private System.Windows.Forms.DataGridViewTextBoxColumn FBLmLaneLabl;
        private TraxDEDataGridViewTextBoxColumn FBFbFrghtAmt;
        private TraxDEDataGridViewTextBoxColumn FBFbDscntAmt;
        private TraxDEDataGridViewTextBoxColumn FBFbAccAmt;
        private TraxDEDataGridViewTextBoxColumn FBFbTaxAmt;
        private System.Windows.Forms.CheckBox chkBoxInvoiceAdd;
        private TraxDELabel lblAutosave;
        private TraxDELabel lblFBAdd;
        private TraxDELabel lblInvoiceAdd;
        private System.Windows.Forms.CheckBox chkBoxFBAdd;
        private System.Windows.Forms.CheckBox chkBoxFBLnAdd;
        private TraxDELabel lblFBLnAdd;
        private System.Windows.Forms.CheckBox chkBoxMultipleCurr;
        private TraxDELabel lblMultipleCurrency;
        private TraxDEDataGridView grdFBLine;
        private TraxDEDataGridViewTextBoxColumn FBLnFbId;
        private TraxDEDataGridViewTextBoxColumn FBLnLineItemNum;
        private TraxDEDataGridViewTextBoxColumn FBLnPcsCnt;
        private TraxDEDataGridViewTextBoxColumn FBLnLnChrgCode;
        private TraxDEDataGridViewTextBoxColumn FBLnChrgDesc;
        private TraxDEDataGridViewTextBoxColumn FBLnFacsimile01;
        private TraxDEDataGridViewTextBoxColumn FBLnCmdtyClass;
        private TraxDEDataGridViewTextBoxColumn FBLnQtyLabl;
        private TraxDEDataGridViewTextBoxColumn FBLnRateAmt;
        private System.Windows.Forms.DataGridViewComboBoxColumn FBLnRateType;
        private TraxDEDataGridViewTextBoxColumn FBLnRateUntLabl;
        private System.Windows.Forms.DataGridViewComboBoxColumn FBLnCat;
        private TraxDEDataGridViewTextBoxColumn FBLnLnActualWt;
        private TraxDEDataGridViewTextBoxColumn FBLnLnRateAsWt;
        private TraxDEDataGridViewTextBoxColumn FBLnPkgType;
        private TraxDEDataGridViewTextBoxColumn FBLnChrgAmt;
        private TraxDEDataGridViewTextBoxColumn FBLnCurrencyQual;
        private TraxDEDataGridViewTextBoxColumn FBLnT001;
        private TraxDEDataGridViewTextBoxColumn FBLnT002;
        private System.Windows.Forms.DataGridViewComboBoxColumn FBLnT003;
        private TraxDEDataGridViewTextBoxColumn FBLnT004;
        private TraxDEDataGridViewTextBoxColumn FBLnT005;
        private TraxDEDataGridViewTextBoxColumn FBLnFacsimile02;
        private TraxDEDataGridViewTextBoxColumn FBLnT006;
        private TraxDEDataGridView grdFXI;
        private TraxDEDataGridViewTextBoxColumn FbId;
        private TraxDEDataGridViewTextBoxColumn VendLabl;
        private TraxDEDataGridViewTextBoxColumn InvId;
        private TraxDEDataGridViewTextBoxColumn BatId;
        private TraxDEDataGridViewTextBoxColumn T001;
        private TraxDEDataGridViewTextBoxColumn T002;
        private TraxDEDataGridViewTextBoxColumn T003;
        private TraxDEDataGridViewTextBoxColumn T004;
        private TraxDEDataGridViewTextBoxColumn T005;
        private TraxDEDataGridViewTextBoxColumn T006;
        private TraxDEDataGridViewTextBoxColumn T007;
        private TraxDEDataGridViewTextBoxColumn T008;
        private TraxDEDataGridViewTextBoxColumn T009;
        private TraxDEDataGridViewTextBoxColumn T010;
        private TraxDEDataGridViewTextBoxColumn T011;
        private TraxDEDataGridViewTextBoxColumn T012;
        private TraxDEDataGridViewTextBoxColumn T013;
        private TraxDEDataGridViewTextBoxColumn T014;
        private TraxDEDataGridViewTextBoxColumn T015;
        private TraxDEDataGridViewTextBoxColumn T016;
        private TraxDEDataGridViewTextBoxColumn T017;
        private TraxDEDataGridViewTextBoxColumn T018;
        private TraxDEDataGridViewTextBoxColumn T019;
        private TraxDEDataGridViewTextBoxColumn T020;
        private TraxDEDataGridViewTextBoxColumn T021;
        private TraxDEDataGridViewTextBoxColumn T022;
        private TraxDEDataGridViewTextBoxColumn T023;
        private TraxDEDataGridViewTextBoxColumn T024;
        private TraxDEDataGridViewTextBoxColumn T025;
        private TraxDEDataGridViewTextBoxColumn T026;
        private TraxDEDataGridViewTextBoxColumn T027;
        private TraxDEDataGridViewTextBoxColumn T028;
        private TraxDEDataGridViewTextBoxColumn T029;
        private TraxDEDataGridViewTextBoxColumn T030;
        private TraxDEDataGridViewTextBoxColumn T031;
        private TraxDEDataGridViewTextBoxColumn T032;
        private TraxDEDataGridViewTextBoxColumn T033;
        private TraxDEDataGridViewTextBoxColumn T034;
        private TraxDEDataGridViewTextBoxColumn T035;
        private TraxDEDataGridViewTextBoxColumn T036;
        private TraxDEDataGridViewTextBoxColumn T037;
        private TraxDEDataGridViewTextBoxColumn T038;
        private TraxDEDataGridViewTextBoxColumn T039;
        private TraxDEDataGridViewTextBoxColumn T040;
        private TraxDEDataGridViewTextBoxColumn T041;
        private TraxDEDataGridViewTextBoxColumn T042;
        private TraxDEDataGridViewTextBoxColumn T043;
        private TraxDEDataGridViewTextBoxColumn T044;
        private TraxDEDataGridViewTextBoxColumn T045;
        private TraxDEDataGridViewTextBoxColumn T046;
        private TraxDEDataGridViewTextBoxColumn T047;
        private TraxDEDataGridViewTextBoxColumn T048;
        private TraxDEDataGridViewTextBoxColumn T049;
        private TraxDEDataGridViewTextBoxColumn T050;
        private TraxDEDataGridViewTextBoxColumn T051;
        private TraxDEDataGridViewTextBoxColumn T052;
        private TraxDEDataGridViewTextBoxColumn T053;
        private TraxDEDataGridViewTextBoxColumn T054;
        private TraxDEDataGridViewTextBoxColumn T055;
        private TraxDEDataGridViewTextBoxColumn T056;
        private TraxDEDataGridViewTextBoxColumn T057;
        private TraxDEDataGridViewTextBoxColumn T058;
        private TraxDEDataGridViewTextBoxColumn T059;
        private TraxDEDataGridViewTextBoxColumn T060;
        private TraxDEDataGridViewTextBoxColumn T061;
        private TraxDEDataGridViewTextBoxColumn T062;
        private TraxDEDataGridViewTextBoxColumn T063;
        private TraxDEDataGridViewTextBoxColumn T064;
        private TraxDEDataGridViewTextBoxColumn T065;
        private TraxDEDataGridViewTextBoxColumn T066;
        private TraxDEDataGridViewTextBoxColumn T067;
        private TraxDEDataGridViewTextBoxColumn T068;
        private TraxDEDataGridViewTextBoxColumn T069;
        private TraxDEDataGridViewTextBoxColumn T070;
        private TraxDEDataGridViewTextBoxColumn T071;
        private TraxDEDataGridViewTextBoxColumn T072;
        private TraxDEDataGridViewTextBoxColumn T073;
        private TraxDEDataGridViewTextBoxColumn T074;
        private TraxDEDataGridViewTextBoxColumn T075;
        private TraxDEDataGridViewTextBoxColumn T076;
        private TraxDEDataGridViewTextBoxColumn T077;
        private TraxDEDataGridViewTextBoxColumn T078;
        private TraxDEDataGridViewTextBoxColumn T079;
        private TraxDEDataGridViewTextBoxColumn T080;
        private TraxDEDataGridViewTextBoxColumn T081;
        private TraxDEDataGridViewTextBoxColumn T082;
        private TraxDEDataGridViewTextBoxColumn T083;
        private TraxDEDataGridViewTextBoxColumn T084;
        private TraxDEDataGridViewTextBoxColumn T085;
        private TraxDEDataGridViewTextBoxColumn T086;
        private TraxDEDataGridViewTextBoxColumn T087;
        private TraxDEDataGridViewTextBoxColumn T088;
        private TraxDEDataGridViewTextBoxColumn T089;
        private TraxDEDataGridViewTextBoxColumn T090;
        private TraxDEDataGridViewTextBoxColumn T091;
        private TraxDEDataGridViewTextBoxColumn T092;
        private TraxDEDataGridViewTextBoxColumn T093;
        private TraxDEDataGridViewTextBoxColumn T094;
        private TraxDEDataGridViewTextBoxColumn T095;
        private TraxDEDataGridViewTextBoxColumn T096;
        private TraxDEDataGridViewTextBoxColumn T097;
        private TraxDEDataGridViewTextBoxColumn T098;
        private TraxDEDataGridViewTextBoxColumn T099;
        private TraxDEDataGridViewTextBoxColumn T100;
        private TraxDEDataGridViewTextBoxColumn T101;
        private TraxDEDataGridViewTextBoxColumn T102;
        private TraxDEDataGridViewTextBoxColumn T103;
        private TraxDEDataGridViewTextBoxColumn T104;
        private TraxDEDataGridViewTextBoxColumn T105;
        private TraxDEDataGridViewTextBoxColumn T106;
        private TraxDEDataGridViewTextBoxColumn T107;
        private TraxDEDataGridViewTextBoxColumn T108;
        private TraxDEDataGridViewTextBoxColumn T109;
        private TraxDEDataGridViewTextBoxColumn T110;
        private TraxDEDataGridViewTextBoxColumn T111;
        private TraxDEDataGridViewTextBoxColumn T112;
        private TraxDEDataGridViewTextBoxColumn T113;
        private TraxDEDataGridViewTextBoxColumn T114;
        private TraxDEDataGridViewTextBoxColumn T115;
        private TraxDEDataGridViewTextBoxColumn T116;
        private TraxDEDataGridViewTextBoxColumn T117;
        private TraxDEDataGridViewTextBoxColumn T118;
        private TraxDEDataGridViewTextBoxColumn T119;
        private TraxDEDataGridViewTextBoxColumn T120;
        private System.Windows.Forms.Button btnRefresh;
        private TraxDEDataGridViewTextBoxColumn InvoiceInvId;
        private TraxDEDataGridViewTextBoxColumn InvoiceVendLabl;
        private TraxDEDataGridViewTextBoxColumn InvoiceLocIdRemit;
        private TraxDEDataGridViewTextBoxColumn InvoiceInvKey;
        private System.Windows.Forms.DataGridViewComboBoxColumn InvoiceInvCurrencyQual;
        private TraxDEDataGridViewTextBoxColumn InvoiceVendInvAmt;
        private TraxDEDataGridViewTextBoxColumn InvoiceAcctIdVendBlng;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlRemit1;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlRemit2;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlRemit3;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlRemit4;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlCityRemit;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlStateProvRemit;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlPostCodeRemit;
        private TraxDEDataGridViewTextBoxColumn InvoiceAlCntryCodeRemit;
        private TraxDEDataGridViewTextBoxColumn InvoiceInvFbCnt;
        private TraxDEDataGridViewTextBoxColumn InvoiceInvAmt;
        private TraxDEDataGridViewTextBoxColumn InvoiceInvStat;
        private TraxDEDataGridViewTextBoxColumn InvoiceInvCreatDtm;
    }
}