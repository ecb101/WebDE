namespace DEAppWS
{
    partial class frmCurrencyBreakDown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrencyBreakDown));
            this.grpBoxExchangeRate = new System.Windows.Forms.GroupBox();
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.lblCurrency = new FormControls.TraxDELabel();
            this.lblRate = new FormControls.TraxDELabel();
            this.lblTo2 = new FormControls.TraxDELabel();
            this.txtExchangeRate2 = new FormControls.TraxDETextBox();
            this.ddlCurrency2 = new System.Windows.Forms.ComboBox();
            this.txtExchangeRate1 = new FormControls.TraxDETextBox();
            this.ddlCurrency1 = new System.Windows.Forms.ComboBox();
            this.ddlCurrency = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxLineItem = new System.Windows.Forms.GroupBox();
            this.lblOriginalAmount = new FormControls.TraxDELabel();
            this.txtOriginalAmount = new FormControls.TraxDETextBox();
            this.lblOriginal = new FormControls.TraxDELabel();
            this.lblLineItems = new FormControls.TraxDELabel();
            this.traxDELabel2 = new FormControls.TraxDELabel();
            this.ddlLineItemFrom = new System.Windows.Forms.ComboBox();
            this.ddlLineItemTo = new System.Windows.Forms.ComboBox();
            this.txtOriginal = new FormControls.TraxDETextBox();
            this.grpBoxExchangeRate.SuspendLayout();
            this.grpBoxLineItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxExchangeRate
            // 
            this.grpBoxExchangeRate.Controls.Add(this.traxDELabel1);
            this.grpBoxExchangeRate.Controls.Add(this.lblCurrency);
            this.grpBoxExchangeRate.Controls.Add(this.lblRate);
            this.grpBoxExchangeRate.Controls.Add(this.lblTo2);
            this.grpBoxExchangeRate.Controls.Add(this.txtExchangeRate2);
            this.grpBoxExchangeRate.Controls.Add(this.ddlCurrency2);
            this.grpBoxExchangeRate.Controls.Add(this.txtExchangeRate1);
            this.grpBoxExchangeRate.Controls.Add(this.ddlCurrency1);
            this.grpBoxExchangeRate.Controls.Add(this.ddlCurrency);
            this.grpBoxExchangeRate.Location = new System.Drawing.Point(12, 12);
            this.grpBoxExchangeRate.Name = "grpBoxExchangeRate";
            this.grpBoxExchangeRate.Size = new System.Drawing.Size(538, 72);
            this.grpBoxExchangeRate.TabIndex = 0;
            this.grpBoxExchangeRate.TabStop = false;
            this.grpBoxExchangeRate.Text = "Exchange Rate Computation";
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.DatabaseTableLink = null;
            this.traxDELabel1.Location = new System.Drawing.Point(379, 16);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(20, 13);
            this.traxDELabel1.TabIndex = 21;
            this.traxDELabel1.Text = "To";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.DatabaseTableLink = null;
            this.lblCurrency.Location = new System.Drawing.Point(6, 16);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(55, 13);
            this.lblCurrency.TabIndex = 20;
            this.lblCurrency.Text = "Currency :";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.DatabaseTableLink = null;
            this.lblRate.Location = new System.Drawing.Point(6, 45);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(87, 13);
            this.lblRate.TabIndex = 18;
            this.lblRate.Text = "Exchange Rate :";
            // 
            // lblTo2
            // 
            this.lblTo2.AutoSize = true;
            this.lblTo2.DatabaseTableLink = null;
            this.lblTo2.Location = new System.Drawing.Point(226, 16);
            this.lblTo2.Name = "lblTo2";
            this.lblTo2.Size = new System.Drawing.Size(20, 13);
            this.lblTo2.TabIndex = 17;
            this.lblTo2.Text = "To";
            // 
            // txtExchangeRate2
            // 
            this.txtExchangeRate2.DatabaseFieldLink = null;
            this.txtExchangeRate2.DatabaseTableLink = null;
            this.txtExchangeRate2.FieldHint = null;
            this.txtExchangeRate2.Location = new System.Drawing.Point(339, 42);
            this.txtExchangeRate2.Name = "txtExchangeRate2";
            this.txtExchangeRate2.Size = new System.Drawing.Size(121, 20);
            this.txtExchangeRate2.TabIndex = 3;
            this.txtExchangeRate2.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // ddlCurrency2
            // 
            this.ddlCurrency2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCurrency2.FormattingEnabled = true;
            this.ddlCurrency2.Location = new System.Drawing.Point(252, 13);
            this.ddlCurrency2.Name = "ddlCurrency2";
            this.ddlCurrency2.Size = new System.Drawing.Size(121, 21);
            this.ddlCurrency2.TabIndex = 2;
            this.ddlCurrency2.SelectedIndexChanged += new System.EventHandler(this.ddlCurrency2_SelectedIndexChanged);
            // 
            // txtExchangeRate1
            // 
            this.txtExchangeRate1.DatabaseFieldLink = null;
            this.txtExchangeRate1.DatabaseTableLink = null;
            this.txtExchangeRate1.FieldHint = null;
            this.txtExchangeRate1.Location = new System.Drawing.Point(174, 42);
            this.txtExchangeRate1.Name = "txtExchangeRate1";
            this.txtExchangeRate1.Size = new System.Drawing.Size(121, 20);
            this.txtExchangeRate1.TabIndex = 1;
            this.txtExchangeRate1.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // ddlCurrency1
            // 
            this.ddlCurrency1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCurrency1.FormattingEnabled = true;
            this.ddlCurrency1.Location = new System.Drawing.Point(99, 13);
            this.ddlCurrency1.Name = "ddlCurrency1";
            this.ddlCurrency1.Size = new System.Drawing.Size(121, 21);
            this.ddlCurrency1.TabIndex = 0;
            this.ddlCurrency1.SelectedIndexChanged += new System.EventHandler(this.ddlCurrency1_SelectedIndexChanged);
            // 
            // ddlCurrency
            // 
            this.ddlCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCurrency.Enabled = false;
            this.ddlCurrency.FormattingEnabled = true;
            this.ddlCurrency.Location = new System.Drawing.Point(405, 13);
            this.ddlCurrency.Name = "ddlCurrency";
            this.ddlCurrency.Size = new System.Drawing.Size(121, 21);
            this.ddlCurrency.TabIndex = 12;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(496, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(54, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(436, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(54, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpBoxLineItem
            // 
            this.grpBoxLineItem.Controls.Add(this.lblOriginalAmount);
            this.grpBoxLineItem.Controls.Add(this.txtOriginalAmount);
            this.grpBoxLineItem.Controls.Add(this.lblOriginal);
            this.grpBoxLineItem.Controls.Add(this.lblLineItems);
            this.grpBoxLineItem.Controls.Add(this.traxDELabel2);
            this.grpBoxLineItem.Controls.Add(this.ddlLineItemFrom);
            this.grpBoxLineItem.Controls.Add(this.ddlLineItemTo);
            this.grpBoxLineItem.Controls.Add(this.txtOriginal);
            this.grpBoxLineItem.Location = new System.Drawing.Point(12, 90);
            this.grpBoxLineItem.Name = "grpBoxLineItem";
            this.grpBoxLineItem.Size = new System.Drawing.Size(538, 110);
            this.grpBoxLineItem.TabIndex = 1;
            this.grpBoxLineItem.TabStop = false;
            this.grpBoxLineItem.Text = "Implement Exchange Rate to Line Item";
            // 
            // lblOriginalAmount
            // 
            this.lblOriginalAmount.AutoSize = true;
            this.lblOriginalAmount.DatabaseTableLink = null;
            this.lblOriginalAmount.Location = new System.Drawing.Point(6, 82);
            this.lblOriginalAmount.Name = "lblOriginalAmount";
            this.lblOriginalAmount.Size = new System.Drawing.Size(87, 13);
            this.lblOriginalAmount.TabIndex = 28;
            this.lblOriginalAmount.Text = "Original Amount :";
            // 
            // txtOriginalAmount
            // 
            this.txtOriginalAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOriginalAmount.DatabaseFieldLink = null;
            this.txtOriginalAmount.DatabaseTableLink = null;
            this.txtOriginalAmount.FieldHint = null;
            this.txtOriginalAmount.Location = new System.Drawing.Point(116, 79);
            this.txtOriginalAmount.MaxLength = 255;
            this.txtOriginalAmount.Name = "txtOriginalAmount";
            this.txtOriginalAmount.Size = new System.Drawing.Size(89, 20);
            this.txtOriginalAmount.TabIndex = 27;
            this.txtOriginalAmount.ValueType = CommonLibrary.CommonEnum.ValueType.MONEY;
            // 
            // lblOriginal
            // 
            this.lblOriginal.AutoSize = true;
            this.lblOriginal.DatabaseTableLink = null;
            this.lblOriginal.Location = new System.Drawing.Point(6, 56);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(104, 13);
            this.lblOriginal.TabIndex = 26;
            this.lblOriginal.Text = "Original Description :";
            // 
            // lblLineItems
            // 
            this.lblLineItems.AutoSize = true;
            this.lblLineItems.DatabaseTableLink = null;
            this.lblLineItems.Location = new System.Drawing.Point(6, 22);
            this.lblLineItems.Name = "lblLineItems";
            this.lblLineItems.Size = new System.Drawing.Size(84, 13);
            this.lblLineItems.TabIndex = 25;
            this.lblLineItems.Text = "Line Items from :";
            // 
            // traxDELabel2
            // 
            this.traxDELabel2.AutoSize = true;
            this.traxDELabel2.DatabaseTableLink = null;
            this.traxDELabel2.Location = new System.Drawing.Point(154, 22);
            this.traxDELabel2.Name = "traxDELabel2";
            this.traxDELabel2.Size = new System.Drawing.Size(20, 13);
            this.traxDELabel2.TabIndex = 24;
            this.traxDELabel2.Text = "To";
            // 
            // ddlLineItemFrom
            // 
            this.ddlLineItemFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLineItemFrom.FormattingEnabled = true;
            this.ddlLineItemFrom.Location = new System.Drawing.Point(96, 19);
            this.ddlLineItemFrom.Name = "ddlLineItemFrom";
            this.ddlLineItemFrom.Size = new System.Drawing.Size(52, 21);
            this.ddlLineItemFrom.TabIndex = 0;
            // 
            // ddlLineItemTo
            // 
            this.ddlLineItemTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLineItemTo.FormattingEnabled = true;
            this.ddlLineItemTo.Location = new System.Drawing.Point(180, 19);
            this.ddlLineItemTo.Name = "ddlLineItemTo";
            this.ddlLineItemTo.Size = new System.Drawing.Size(52, 21);
            this.ddlLineItemTo.TabIndex = 1;
            // 
            // txtOriginal
            // 
            this.txtOriginal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOriginal.DatabaseFieldLink = null;
            this.txtOriginal.DatabaseTableLink = null;
            this.txtOriginal.FieldHint = null;
            this.txtOriginal.Location = new System.Drawing.Point(116, 53);
            this.txtOriginal.MaxLength = 255;
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Size = new System.Drawing.Size(410, 20);
            this.txtOriginal.TabIndex = 2;
            this.txtOriginal.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // frmCurrencyBreakDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 239);
            this.Controls.Add(this.grpBoxLineItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpBoxExchangeRate);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(570, 273);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(570, 273);
            this.Name = "frmCurrencyBreakDown";
            this.Text = "Exchange Rate Break Down";
            this.Load += new System.EventHandler(this.frmCurrencyBreakDown_Load);
            this.grpBoxExchangeRate.ResumeLayout(false);
            this.grpBoxExchangeRate.PerformLayout();
            this.grpBoxLineItem.ResumeLayout(false);
            this.grpBoxLineItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxExchangeRate;
        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDELabel lblCurrency;
        private System.Windows.Forms.Button btnOK;
        private FormControls.TraxDELabel lblRate;
        private FormControls.TraxDELabel lblTo2;
        private FormControls.TraxDETextBox txtExchangeRate2;
        private System.Windows.Forms.ComboBox ddlCurrency2;
        private FormControls.TraxDETextBox txtExchangeRate1;
        private System.Windows.Forms.ComboBox ddlCurrency1;
        private System.Windows.Forms.ComboBox ddlCurrency;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpBoxLineItem;
        private FormControls.TraxDETextBox txtOriginal;
        private FormControls.TraxDELabel traxDELabel2;
        private System.Windows.Forms.ComboBox ddlLineItemFrom;
        private System.Windows.Forms.ComboBox ddlLineItemTo;
        private FormControls.TraxDELabel lblLineItems;
        private FormControls.TraxDELabel lblOriginal;
        private FormControls.TraxDELabel lblOriginalAmount;
        private FormControls.TraxDETextBox txtOriginalAmount;

    }
}