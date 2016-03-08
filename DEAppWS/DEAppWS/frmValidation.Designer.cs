namespace DEAppWS
{
    partial class frmValidation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBoxInvoice = new System.Windows.Forms.GroupBox();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.grdInvoice = new FormControls.TraxDEDataGridView();
            this.InvoiceInvKey = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAcctNumVendBlng = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvCreatDtm = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.isCorrectInvoice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpBoxFB = new System.Windows.Forms.GroupBox();
            this.btnDeleteFB = new System.Windows.Forms.Button();
            this.btnAddFB = new System.Windows.Forms.Button();
            this.grdFreightBill = new FormControls.TraxDEDataGridView();
            this.FBFbKey = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbAmt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbCreatDtm = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbPaymtTermsCode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isCorrectFB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtCurrency = new FormControls.TraxDETextBox();
            this.lblCurrency = new FormControls.TraxDELabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSCAC = new FormControls.TraxDELabel();
            this.txtSCAC = new FormControls.TraxDETextBox();
            this.grpBoxInvoiceOperator = new System.Windows.Forms.GroupBox();
            this.grdInvoiceOperator = new FormControls.TraxDEDataGridView();
            this.InvoiceInvKeyOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvAmtOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceAcctNumVendBlngOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvoiceInvCreatDtmOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.isCorrectInvoiceOperator = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpBoxFBOperator = new System.Windows.Forms.GroupBox();
            this.grdFreightBillOperator = new FormControls.TraxDEDataGridView();
            this.FBFbKeyOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbAmtOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbCreatDtmOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FBFbPaymtTermsCodeOperator = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isCorrectFBOperator = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).BeginInit();
            this.grpBoxFB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightBill)).BeginInit();
            this.grpBoxInvoiceOperator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceOperator)).BeginInit();
            this.grpBoxFBOperator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightBillOperator)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxInvoice
            // 
            this.grpBoxInvoice.Controls.Add(this.btnDeleteInvoice);
            this.grpBoxInvoice.Controls.Add(this.btnAddInvoice);
            this.grpBoxInvoice.Controls.Add(this.grdInvoice);
            this.grpBoxInvoice.Location = new System.Drawing.Point(12, 12);
            this.grpBoxInvoice.Name = "grpBoxInvoice";
            this.grpBoxInvoice.Size = new System.Drawing.Size(587, 312);
            this.grpBoxInvoice.TabIndex = 0;
            this.grpBoxInvoice.TabStop = false;
            this.grpBoxInvoice.Text = "Invoice";
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(84, 19);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(72, 23);
            this.btnDeleteInvoice.TabIndex = 1;
            this.btnDeleteInvoice.TabStop = false;
            this.btnDeleteInvoice.Text = "Delete";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(6, 19);
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
            this.grdInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceInvKey,
            this.InvoiceInvAmt,
            this.InvoiceAcctNumVendBlng,
            this.InvoiceInvCreatDtm,
            this.isCorrectInvoice});
            this.grdInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdInvoice.Location = new System.Drawing.Point(6, 48);
            this.grdInvoice.MultiSelect = false;
            this.grdInvoice.Name = "grdInvoice";
            this.grdInvoice.RowHeadersVisible = false;
            this.grdInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoice.Size = new System.Drawing.Size(575, 258);
            this.grdInvoice.TabIndex = 2;
            this.grdInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoice_CellEndEdit);
            // 
            // InvoiceInvKey
            // 
            this.InvoiceInvKey.DataPropertyName = "InvKey";
            this.InvoiceInvKey.HeaderText = "Invoice Key";
            this.InvoiceInvKey.MaxInputLength = 50;
            this.InvoiceInvKey.MinimumWidth = 150;
            this.InvoiceInvKey.Name = "InvoiceInvKey";
            this.InvoiceInvKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceInvKey.Width = 150;
            // 
            // InvoiceInvAmt
            // 
            this.InvoiceInvAmt.DataPropertyName = "InvAmt";
            dataGridViewCellStyle1.Format = "C4";
            dataGridViewCellStyle1.NullValue = "0.0000";
            this.InvoiceInvAmt.DefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceInvAmt.HeaderText = "Inv Amt";
            this.InvoiceInvAmt.MinimumWidth = 100;
            this.InvoiceInvAmt.Name = "InvoiceInvAmt";
            this.InvoiceInvAmt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceInvAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvoiceAcctNumVendBlng
            // 
            this.InvoiceAcctNumVendBlng.DataPropertyName = "AcctNumVendBlng";
            this.InvoiceAcctNumVendBlng.HeaderText = "Account";
            this.InvoiceAcctNumVendBlng.MinimumWidth = 150;
            this.InvoiceAcctNumVendBlng.Name = "InvoiceAcctNumVendBlng";
            this.InvoiceAcctNumVendBlng.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceAcctNumVendBlng.Width = 150;
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
            // isCorrectInvoice
            // 
            this.isCorrectInvoice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isCorrectInvoice.DataPropertyName = "isCorrect";
            this.isCorrectInvoice.HeaderText = "Correct";
            this.isCorrectInvoice.MinimumWidth = 47;
            this.isCorrectInvoice.Name = "isCorrectInvoice";
            this.isCorrectInvoice.ReadOnly = true;
            // 
            // grpBoxFB
            // 
            this.grpBoxFB.Controls.Add(this.btnDeleteFB);
            this.grpBoxFB.Controls.Add(this.btnAddFB);
            this.grpBoxFB.Controls.Add(this.grdFreightBill);
            this.grpBoxFB.Location = new System.Drawing.Point(605, 12);
            this.grpBoxFB.Name = "grpBoxFB";
            this.grpBoxFB.Size = new System.Drawing.Size(585, 312);
            this.grpBoxFB.TabIndex = 1;
            this.grpBoxFB.TabStop = false;
            this.grpBoxFB.Text = "Freight Bill";
            this.grpBoxFB.Visible = false;
            // 
            // btnDeleteFB
            // 
            this.btnDeleteFB.Location = new System.Drawing.Point(80, 19);
            this.btnDeleteFB.Name = "btnDeleteFB";
            this.btnDeleteFB.Size = new System.Drawing.Size(68, 23);
            this.btnDeleteFB.TabIndex = 5;
            this.btnDeleteFB.TabStop = false;
            this.btnDeleteFB.Text = "Delete";
            this.btnDeleteFB.UseVisualStyleBackColor = true;
            this.btnDeleteFB.Click += new System.EventHandler(this.btnDeleteFB_Click);
            // 
            // btnAddFB
            // 
            this.btnAddFB.Location = new System.Drawing.Point(6, 19);
            this.btnAddFB.Name = "btnAddFB";
            this.btnAddFB.Size = new System.Drawing.Size(68, 23);
            this.btnAddFB.TabIndex = 4;
            this.btnAddFB.Text = "Add";
            this.btnAddFB.UseVisualStyleBackColor = true;
            this.btnAddFB.Click += new System.EventHandler(this.btnAddFB_Click);
            // 
            // grdFreightBill
            // 
            this.grdFreightBill.AllowUserToAddRows = false;
            this.grdFreightBill.AllowUserToDeleteRows = false;
            this.grdFreightBill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFreightBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFreightBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FBFbKey,
            this.FBFbAmt,
            this.FBFbCreatDtm,
            this.FBFbPaymtTermsCode,
            this.isCorrectFB});
            this.grdFreightBill.Location = new System.Drawing.Point(6, 48);
            this.grdFreightBill.MultiSelect = false;
            this.grdFreightBill.Name = "grdFreightBill";
            this.grdFreightBill.RowHeadersVisible = false;
            this.grdFreightBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFreightBill.Size = new System.Drawing.Size(573, 258);
            this.grdFreightBill.TabIndex = 3;
            this.grdFreightBill.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFreightBill_CellEndEdit);
            // 
            // FBFbKey
            // 
            this.FBFbKey.DataPropertyName = "FbKey";
            this.FBFbKey.HeaderText = "Freight Bill Key";
            this.FBFbKey.MaxInputLength = 50;
            this.FBFbKey.MinimumWidth = 150;
            this.FBFbKey.Name = "FBFbKey";
            this.FBFbKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBFbKey.Width = 150;
            // 
            // FBFbAmt
            // 
            this.FBFbAmt.DataPropertyName = "FbAmt";
            dataGridViewCellStyle3.Format = "C4";
            dataGridViewCellStyle3.NullValue = "0.0000";
            this.FBFbAmt.DefaultCellStyle = dataGridViewCellStyle3;
            this.FBFbAmt.HeaderText = "FB Amount";
            this.FBFbAmt.MinimumWidth = 100;
            this.FBFbAmt.Name = "FBFbAmt";
            this.FBFbAmt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FBFbCreatDtm
            // 
            this.FBFbCreatDtm.DataPropertyName = "FbCreatDtm";
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.FBFbCreatDtm.DefaultCellStyle = dataGridViewCellStyle4;
            this.FBFbCreatDtm.HeaderText = "Date(mm/dd/yyyy)";
            this.FBFbCreatDtm.MinimumWidth = 100;
            this.FBFbCreatDtm.Name = "FBFbCreatDtm";
            this.FBFbCreatDtm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FBFbPaymtTermsCode
            // 
            this.FBFbPaymtTermsCode.DataPropertyName = "FbPaymtTermsCode";
            this.FBFbPaymtTermsCode.HeaderText = "Term";
            this.FBFbPaymtTermsCode.Items.AddRange(new object[] {
            "TP",
            "PP",
            "CC"});
            this.FBFbPaymtTermsCode.MinimumWidth = 100;
            this.FBFbPaymtTermsCode.Name = "FBFbPaymtTermsCode";
            this.FBFbPaymtTermsCode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // isCorrectFB
            // 
            this.isCorrectFB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isCorrectFB.DataPropertyName = "isCorrect";
            this.isCorrectFB.HeaderText = "Correct";
            this.isCorrectFB.MinimumWidth = 47;
            this.isCorrectFB.Name = "isCorrectFB";
            this.isCorrectFB.ReadOnly = true;
            // 
            // txtCurrency
            // 
            this.txtCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCurrency.DatabaseFieldLink = null;
            this.txtCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrency.Location = new System.Drawing.Point(991, 614);
            this.txtCurrency.MaxLength = 3;
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(87, 20);
            this.txtCurrency.TabIndex = 3;
            this.txtCurrency.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblCurrency
            // 
            this.lblCurrency.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.ForeColor = System.Drawing.Color.Red;
            this.lblCurrency.Location = new System.Drawing.Point(920, 617);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(65, 13);
            this.lblCurrency.TabIndex = 1;
            this.lblCurrency.Text = "Currency :";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(1140, 612);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(50, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSCAC
            // 
            this.lblSCAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSCAC.AutoSize = true;
            this.lblSCAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSCAC.ForeColor = System.Drawing.Color.Red;
            this.lblSCAC.Location = new System.Drawing.Point(774, 617);
            this.lblSCAC.Name = "lblSCAC";
            this.lblSCAC.Size = new System.Drawing.Size(47, 13);
            this.lblSCAC.TabIndex = 7;
            this.lblSCAC.Text = "SCAC :";
            // 
            // txtSCAC
            // 
            this.txtSCAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSCAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSCAC.DatabaseFieldLink = null;
            this.txtSCAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSCAC.Location = new System.Drawing.Point(827, 614);
            this.txtSCAC.MaxLength = 10;
            this.txtSCAC.Name = "txtSCAC";
            this.txtSCAC.Size = new System.Drawing.Size(87, 20);
            this.txtSCAC.TabIndex = 2;
            this.txtSCAC.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // grpBoxInvoiceOperator
            // 
            this.grpBoxInvoiceOperator.Controls.Add(this.grdInvoiceOperator);
            this.grpBoxInvoiceOperator.Location = new System.Drawing.Point(12, 330);
            this.grpBoxInvoiceOperator.Name = "grpBoxInvoiceOperator";
            this.grpBoxInvoiceOperator.Size = new System.Drawing.Size(587, 272);
            this.grpBoxInvoiceOperator.TabIndex = 8;
            this.grpBoxInvoiceOperator.TabStop = false;
            this.grpBoxInvoiceOperator.Text = "Operator Invoices";
            this.grpBoxInvoiceOperator.Visible = false;
            // 
            // grdInvoiceOperator
            // 
            this.grdInvoiceOperator.AllowUserToAddRows = false;
            this.grdInvoiceOperator.AllowUserToDeleteRows = false;
            this.grdInvoiceOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInvoiceOperator.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grdInvoiceOperator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoiceOperator.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceInvKeyOperator,
            this.InvoiceInvAmtOperator,
            this.InvoiceAcctNumVendBlngOperator,
            this.InvoiceInvCreatDtmOperator,
            this.isCorrectInvoiceOperator});
            this.grdInvoiceOperator.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdInvoiceOperator.Location = new System.Drawing.Point(6, 19);
            this.grdInvoiceOperator.MultiSelect = false;
            this.grdInvoiceOperator.Name = "grdInvoiceOperator";
            this.grdInvoiceOperator.RowHeadersVisible = false;
            this.grdInvoiceOperator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoiceOperator.Size = new System.Drawing.Size(575, 247);
            this.grdInvoiceOperator.TabIndex = 3;
            this.grdInvoiceOperator.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoiceOperator_CellEndEdit);
            // 
            // InvoiceInvKeyOperator
            // 
            this.InvoiceInvKeyOperator.DataPropertyName = "InvKey";
            this.InvoiceInvKeyOperator.HeaderText = "Invoice Key";
            this.InvoiceInvKeyOperator.MaxInputLength = 50;
            this.InvoiceInvKeyOperator.MinimumWidth = 150;
            this.InvoiceInvKeyOperator.Name = "InvoiceInvKeyOperator";
            this.InvoiceInvKeyOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceInvKeyOperator.Width = 150;
            // 
            // InvoiceInvAmtOperator
            // 
            this.InvoiceInvAmtOperator.DataPropertyName = "InvAmt";
            dataGridViewCellStyle5.Format = "C4";
            dataGridViewCellStyle5.NullValue = "0.0000";
            this.InvoiceInvAmtOperator.DefaultCellStyle = dataGridViewCellStyle5;
            this.InvoiceInvAmtOperator.HeaderText = "Inv Amt";
            this.InvoiceInvAmtOperator.MinimumWidth = 100;
            this.InvoiceInvAmtOperator.Name = "InvoiceInvAmtOperator";
            this.InvoiceInvAmtOperator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceInvAmtOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InvoiceAcctNumVendBlngOperator
            // 
            this.InvoiceAcctNumVendBlngOperator.DataPropertyName = "AcctNumVendBlng";
            this.InvoiceAcctNumVendBlngOperator.HeaderText = "Account";
            this.InvoiceAcctNumVendBlngOperator.MinimumWidth = 150;
            this.InvoiceAcctNumVendBlngOperator.Name = "InvoiceAcctNumVendBlngOperator";
            this.InvoiceAcctNumVendBlngOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InvoiceAcctNumVendBlngOperator.Width = 150;
            // 
            // InvoiceInvCreatDtmOperator
            // 
            this.InvoiceInvCreatDtmOperator.DataPropertyName = "InvCreatDtm";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.InvoiceInvCreatDtmOperator.DefaultCellStyle = dataGridViewCellStyle6;
            this.InvoiceInvCreatDtmOperator.HeaderText = "Date(mm/dd/yyyy)";
            this.InvoiceInvCreatDtmOperator.MinimumWidth = 100;
            this.InvoiceInvCreatDtmOperator.Name = "InvoiceInvCreatDtmOperator";
            this.InvoiceInvCreatDtmOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // isCorrectInvoiceOperator
            // 
            this.isCorrectInvoiceOperator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isCorrectInvoiceOperator.DataPropertyName = "isCorrect";
            this.isCorrectInvoiceOperator.HeaderText = "Correct";
            this.isCorrectInvoiceOperator.MinimumWidth = 47;
            this.isCorrectInvoiceOperator.Name = "isCorrectInvoiceOperator";
            this.isCorrectInvoiceOperator.ReadOnly = true;
            // 
            // grpBoxFBOperator
            // 
            this.grpBoxFBOperator.Controls.Add(this.grdFreightBillOperator);
            this.grpBoxFBOperator.Location = new System.Drawing.Point(605, 330);
            this.grpBoxFBOperator.Name = "grpBoxFBOperator";
            this.grpBoxFBOperator.Size = new System.Drawing.Size(585, 272);
            this.grpBoxFBOperator.TabIndex = 9;
            this.grpBoxFBOperator.TabStop = false;
            this.grpBoxFBOperator.Text = "Operator Freigth Bills";
            this.grpBoxFBOperator.Visible = false;
            // 
            // grdFreightBillOperator
            // 
            this.grdFreightBillOperator.AllowUserToAddRows = false;
            this.grdFreightBillOperator.AllowUserToDeleteRows = false;
            this.grdFreightBillOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFreightBillOperator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFreightBillOperator.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FBFbKeyOperator,
            this.FBFbAmtOperator,
            this.FBFbCreatDtmOperator,
            this.FBFbPaymtTermsCodeOperator,
            this.isCorrectFBOperator});
            this.grdFreightBillOperator.Location = new System.Drawing.Point(6, 19);
            this.grdFreightBillOperator.MultiSelect = false;
            this.grdFreightBillOperator.Name = "grdFreightBillOperator";
            this.grdFreightBillOperator.RowHeadersVisible = false;
            this.grdFreightBillOperator.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdFreightBillOperator.Size = new System.Drawing.Size(573, 247);
            this.grdFreightBillOperator.TabIndex = 4;
            this.grdFreightBillOperator.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFreightBillOperator_CellEndEdit);
            // 
            // FBFbKeyOperator
            // 
            this.FBFbKeyOperator.DataPropertyName = "FbKey";
            this.FBFbKeyOperator.HeaderText = "Freight Bill Key";
            this.FBFbKeyOperator.MaxInputLength = 50;
            this.FBFbKeyOperator.MinimumWidth = 150;
            this.FBFbKeyOperator.Name = "FBFbKeyOperator";
            this.FBFbKeyOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FBFbKeyOperator.Width = 150;
            // 
            // FBFbAmtOperator
            // 
            this.FBFbAmtOperator.DataPropertyName = "FbAmt";
            dataGridViewCellStyle7.Format = "C4";
            dataGridViewCellStyle7.NullValue = "0.0000";
            this.FBFbAmtOperator.DefaultCellStyle = dataGridViewCellStyle7;
            this.FBFbAmtOperator.HeaderText = "FB Amount";
            this.FBFbAmtOperator.MinimumWidth = 100;
            this.FBFbAmtOperator.Name = "FBFbAmtOperator";
            this.FBFbAmtOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FBFbCreatDtmOperator
            // 
            this.FBFbCreatDtmOperator.DataPropertyName = "FbCreatDtm";
            dataGridViewCellStyle8.Format = "d";
            dataGridViewCellStyle8.NullValue = null;
            this.FBFbCreatDtmOperator.DefaultCellStyle = dataGridViewCellStyle8;
            this.FBFbCreatDtmOperator.HeaderText = "Date(mm/dd/yyyy)";
            this.FBFbCreatDtmOperator.MinimumWidth = 100;
            this.FBFbCreatDtmOperator.Name = "FBFbCreatDtmOperator";
            this.FBFbCreatDtmOperator.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FBFbPaymtTermsCodeOperator
            // 
            this.FBFbPaymtTermsCodeOperator.DataPropertyName = "FbPaymtTermsCode";
            this.FBFbPaymtTermsCodeOperator.HeaderText = "Term";
            this.FBFbPaymtTermsCodeOperator.Items.AddRange(new object[] {
            "TP",
            "PP",
            "CC"});
            this.FBFbPaymtTermsCodeOperator.MinimumWidth = 100;
            this.FBFbPaymtTermsCodeOperator.Name = "FBFbPaymtTermsCodeOperator";
            this.FBFbPaymtTermsCodeOperator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // isCorrectFBOperator
            // 
            this.isCorrectFBOperator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.isCorrectFBOperator.DataPropertyName = "isCorrect";
            this.isCorrectFBOperator.HeaderText = "Correct";
            this.isCorrectFBOperator.MinimumWidth = 47;
            this.isCorrectFBOperator.Name = "isCorrectFBOperator";
            this.isCorrectFBOperator.ReadOnly = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1084, 612);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 641);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpBoxFBOperator);
            this.Controls.Add(this.grpBoxInvoiceOperator);
            this.Controls.Add(this.lblSCAC);
            this.Controls.Add(this.txtSCAC);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpBoxFB);
            this.Controls.Add(this.lblCurrency);
            this.Controls.Add(this.grpBoxInvoice);
            this.Controls.Add(this.txtCurrency);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1210, 675);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1210, 675);
            this.Name = "frmValidation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Validation";
            this.Load += new System.EventHandler(this.frmValidation_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmValidation_FormClosing);
            this.grpBoxInvoice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).EndInit();
            this.grpBoxFB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightBill)).EndInit();
            this.grpBoxInvoiceOperator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceOperator)).EndInit();
            this.grpBoxFBOperator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFreightBillOperator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxInvoice;
        private System.Windows.Forms.GroupBox grpBoxFB;
        private FormControls.TraxDEDataGridView grdInvoice;
        private FormControls.TraxDEDataGridView grdFreightBill;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnDeleteFB;
        private System.Windows.Forms.Button btnAddFB;
        private System.Windows.Forms.Button btnOK;
        private FormControls.TraxDELabel lblCurrency;
        private FormControls.TraxDETextBox txtCurrency;
        private FormControls.TraxDELabel lblSCAC;
        private FormControls.TraxDETextBox txtSCAC;
        private System.Windows.Forms.GroupBox grpBoxInvoiceOperator;
        private FormControls.TraxDEDataGridView grdInvoiceOperator;
        private System.Windows.Forms.GroupBox grpBoxFBOperator;
        private FormControls.TraxDEDataGridView grdFreightBillOperator;
        private System.Windows.Forms.Button btnCancel;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceInvKey;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceInvAmt;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceAcctNumVendBlng;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceInvCreatDtm;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCorrectInvoice;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceInvKeyOperator;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceInvAmtOperator;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceAcctNumVendBlngOperator;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvoiceInvCreatDtmOperator;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCorrectInvoiceOperator;
        private FormControls.TraxDEDataGridViewTextBoxColumn FBFbKey;
        private FormControls.TraxDEDataGridViewTextBoxColumn FBFbAmt;
        private FormControls.TraxDEDataGridViewTextBoxColumn FBFbCreatDtm;
        private System.Windows.Forms.DataGridViewComboBoxColumn FBFbPaymtTermsCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCorrectFB;
        private FormControls.TraxDEDataGridViewTextBoxColumn FBFbKeyOperator;
        private FormControls.TraxDEDataGridViewTextBoxColumn FBFbAmtOperator;
        private FormControls.TraxDEDataGridViewTextBoxColumn FBFbCreatDtmOperator;
        private System.Windows.Forms.DataGridViewComboBoxColumn FBFbPaymtTermsCodeOperator;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCorrectFBOperator;
    }
}