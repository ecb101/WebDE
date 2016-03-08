namespace DEAppWS
{
    partial class frmAddressInfoSC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddressInfoSC));
            this.btnOK = new System.Windows.Forms.Button();
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.lblZone = new FormControls.TraxDELabel();
            this.txtAlZoneAddr = new FormControls.TraxDETextBox();
            this.txtAddrCat = new FormControls.TraxDETextBox();
            this.txtAddrNum = new FormControls.TraxDETextBox();
            this.txtFbId = new FormControls.TraxDETextBox();
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.txtAlPortAddr = new FormControls.TraxDETextBox();
            this.lblCountryCodeBillTo = new FormControls.TraxDELabel();
            this.lblZipBillTo = new FormControls.TraxDELabel();
            this.lblStBillTo = new FormControls.TraxDELabel();
            this.lblCityBillTo = new FormControls.TraxDELabel();
            this.lblAddressBillTo = new FormControls.TraxDELabel();
            this.lblNameBillTo = new FormControls.TraxDELabel();
            this.txtAlCntryCodeAddr = new FormControls.TraxDETextBox();
            this.txtAlPostCodeAddr = new FormControls.TraxDETextBox();
            this.txtAlStateProvAddr = new FormControls.TraxDETextBox();
            this.txtAlCityAddr = new FormControls.TraxDETextBox();
            this.txtAlAddr4 = new FormControls.TraxDETextBox();
            this.txtAlAddr3 = new FormControls.TraxDETextBox();
            this.txtAlAddr2 = new FormControls.TraxDETextBox();
            this.txtAlAddr1 = new FormControls.TraxDETextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 177);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.lblZone);
            this.grpAddress.Controls.Add(this.txtAlZoneAddr);
            this.grpAddress.Controls.Add(this.txtAddrCat);
            this.grpAddress.Controls.Add(this.txtAddrNum);
            this.grpAddress.Controls.Add(this.txtFbId);
            this.grpAddress.Controls.Add(this.traxDELabel1);
            this.grpAddress.Controls.Add(this.txtAlPortAddr);
            this.grpAddress.Controls.Add(this.lblCountryCodeBillTo);
            this.grpAddress.Controls.Add(this.lblZipBillTo);
            this.grpAddress.Controls.Add(this.lblStBillTo);
            this.grpAddress.Controls.Add(this.lblCityBillTo);
            this.grpAddress.Controls.Add(this.lblAddressBillTo);
            this.grpAddress.Controls.Add(this.lblNameBillTo);
            this.grpAddress.Controls.Add(this.txtAlCntryCodeAddr);
            this.grpAddress.Controls.Add(this.txtAlPostCodeAddr);
            this.grpAddress.Controls.Add(this.txtAlStateProvAddr);
            this.grpAddress.Controls.Add(this.txtAlCityAddr);
            this.grpAddress.Controls.Add(this.txtAlAddr4);
            this.grpAddress.Controls.Add(this.txtAlAddr3);
            this.grpAddress.Controls.Add(this.txtAlAddr2);
            this.grpAddress.Controls.Add(this.txtAlAddr1);
            this.grpAddress.Location = new System.Drawing.Point(12, 12);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Size = new System.Drawing.Size(422, 160);
            this.grpAddress.TabIndex = 0;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "Address";
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.DatabaseTableLink = null;
            this.lblZone.Location = new System.Drawing.Point(155, 140);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(38, 13);
            this.lblZone.TabIndex = 20;
            this.lblZone.Text = "Zone :";
            this.lblZone.Visible = false;
            // 
            // txtAlZoneAddr
            // 
            this.txtAlZoneAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlZoneAddr.DatabaseFieldLink = "AlZoneAddr";
            this.txtAlZoneAddr.DatabaseTableLink = null;
            this.txtAlZoneAddr.FieldHint = null;
            this.txtAlZoneAddr.Location = new System.Drawing.Point(199, 137);
            this.txtAlZoneAddr.MaxLength = 30;
            this.txtAlZoneAddr.Name = "txtAlZoneAddr";
            this.txtAlZoneAddr.Size = new System.Drawing.Size(217, 20);
            this.txtAlZoneAddr.TabIndex = 19;
            this.txtAlZoneAddr.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtAlZoneAddr.Visible = false;
            // 
            // txtAddrCat
            // 
            this.txtAddrCat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddrCat.DatabaseFieldLink = "AddrCat";
            this.txtAddrCat.DatabaseTableLink = null;
            this.txtAddrCat.FieldHint = null;
            this.txtAddrCat.Location = new System.Drawing.Point(313, 137);
            this.txtAddrCat.MaxLength = 30;
            this.txtAddrCat.Name = "txtAddrCat";
            this.txtAddrCat.Size = new System.Drawing.Size(103, 20);
            this.txtAddrCat.TabIndex = 18;
            this.txtAddrCat.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtAddrCat.Visible = false;
            // 
            // txtAddrNum
            // 
            this.txtAddrNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddrNum.DatabaseFieldLink = "AddrNum";
            this.txtAddrNum.DatabaseTableLink = null;
            this.txtAddrNum.FieldHint = null;
            this.txtAddrNum.Location = new System.Drawing.Point(270, 137);
            this.txtAddrNum.MaxLength = 30;
            this.txtAddrNum.Name = "txtAddrNum";
            this.txtAddrNum.Size = new System.Drawing.Size(42, 20);
            this.txtAddrNum.TabIndex = 17;
            this.txtAddrNum.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtAddrNum.Visible = false;
            // 
            // txtFbId
            // 
            this.txtFbId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFbId.DatabaseFieldLink = "FbId";
            this.txtFbId.DatabaseTableLink = null;
            this.txtFbId.FieldHint = null;
            this.txtFbId.Location = new System.Drawing.Point(150, 137);
            this.txtFbId.MaxLength = 30;
            this.txtFbId.Name = "txtFbId";
            this.txtFbId.Size = new System.Drawing.Size(119, 20);
            this.txtFbId.TabIndex = 16;
            this.txtFbId.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtFbId.Visible = false;
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.DatabaseTableLink = null;
            this.traxDELabel1.Location = new System.Drawing.Point(25, 140);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(32, 13);
            this.traxDELabel1.TabIndex = 15;
            this.traxDELabel1.Text = "Port :";
            // 
            // txtAlPortAddr
            // 
            this.txtAlPortAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlPortAddr.DatabaseFieldLink = "AlPortAddr";
            this.txtAlPortAddr.DatabaseTableLink = null;
            this.txtAlPortAddr.FieldHint = null;
            this.txtAlPortAddr.Location = new System.Drawing.Point(58, 137);
            this.txtAlPortAddr.MaxLength = 30;
            this.txtAlPortAddr.Name = "txtAlPortAddr";
            this.txtAlPortAddr.Size = new System.Drawing.Size(91, 20);
            this.txtAlPortAddr.TabIndex = 14;
            this.txtAlPortAddr.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblCountryCodeBillTo
            // 
            this.lblCountryCodeBillTo.AutoSize = true;
            this.lblCountryCodeBillTo.DatabaseTableLink = null;
            this.lblCountryCodeBillTo.Location = new System.Drawing.Point(230, 119);
            this.lblCountryCodeBillTo.Name = "lblCountryCodeBillTo";
            this.lblCountryCodeBillTo.Size = new System.Drawing.Size(77, 13);
            this.lblCountryCodeBillTo.TabIndex = 13;
            this.lblCountryCodeBillTo.Text = "Country Code :";
            // 
            // lblZipBillTo
            // 
            this.lblZipBillTo.AutoSize = true;
            this.lblZipBillTo.DatabaseTableLink = null;
            this.lblZipBillTo.Location = new System.Drawing.Point(99, 119);
            this.lblZipBillTo.Name = "lblZipBillTo";
            this.lblZipBillTo.Size = new System.Drawing.Size(28, 13);
            this.lblZipBillTo.TabIndex = 12;
            this.lblZipBillTo.Text = "Zip :";
            // 
            // lblStBillTo
            // 
            this.lblStBillTo.AutoSize = true;
            this.lblStBillTo.DatabaseTableLink = null;
            this.lblStBillTo.Location = new System.Drawing.Point(34, 119);
            this.lblStBillTo.Name = "lblStBillTo";
            this.lblStBillTo.Size = new System.Drawing.Size(23, 13);
            this.lblStBillTo.TabIndex = 11;
            this.lblStBillTo.Text = "St :";
            // 
            // lblCityBillTo
            // 
            this.lblCityBillTo.AutoSize = true;
            this.lblCityBillTo.DatabaseTableLink = null;
            this.lblCityBillTo.Location = new System.Drawing.Point(27, 98);
            this.lblCityBillTo.Name = "lblCityBillTo";
            this.lblCityBillTo.Size = new System.Drawing.Size(30, 13);
            this.lblCityBillTo.TabIndex = 10;
            this.lblCityBillTo.Text = "City :";
            // 
            // lblAddressBillTo
            // 
            this.lblAddressBillTo.AutoSize = true;
            this.lblAddressBillTo.DatabaseTableLink = null;
            this.lblAddressBillTo.Location = new System.Drawing.Point(6, 56);
            this.lblAddressBillTo.Name = "lblAddressBillTo";
            this.lblAddressBillTo.Size = new System.Drawing.Size(51, 13);
            this.lblAddressBillTo.TabIndex = 9;
            this.lblAddressBillTo.Text = "Address :";
            // 
            // lblNameBillTo
            // 
            this.lblNameBillTo.AutoSize = true;
            this.lblNameBillTo.DatabaseTableLink = null;
            this.lblNameBillTo.Location = new System.Drawing.Point(16, 14);
            this.lblNameBillTo.Name = "lblNameBillTo";
            this.lblNameBillTo.Size = new System.Drawing.Size(41, 13);
            this.lblNameBillTo.TabIndex = 8;
            this.lblNameBillTo.Text = "Name :";
            // 
            // txtAlCntryCodeAddr
            // 
            this.txtAlCntryCodeAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlCntryCodeAddr.DatabaseFieldLink = "AlCntryCodeAddr";
            this.txtAlCntryCodeAddr.DatabaseTableLink = null;
            this.txtAlCntryCodeAddr.FieldHint = null;
            this.txtAlCntryCodeAddr.Location = new System.Drawing.Point(313, 116);
            this.txtAlCntryCodeAddr.MaxLength = 30;
            this.txtAlCntryCodeAddr.Name = "txtAlCntryCodeAddr";
            this.txtAlCntryCodeAddr.Size = new System.Drawing.Size(103, 20);
            this.txtAlCntryCodeAddr.TabIndex = 7;
            this.txtAlCntryCodeAddr.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlPostCodeAddr
            // 
            this.txtAlPostCodeAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlPostCodeAddr.DatabaseFieldLink = "AlPostCodeAddr";
            this.txtAlPostCodeAddr.DatabaseTableLink = null;
            this.txtAlPostCodeAddr.FieldHint = null;
            this.txtAlPostCodeAddr.Location = new System.Drawing.Point(133, 116);
            this.txtAlPostCodeAddr.MaxLength = 30;
            this.txtAlPostCodeAddr.Name = "txtAlPostCodeAddr";
            this.txtAlPostCodeAddr.Size = new System.Drawing.Size(91, 20);
            this.txtAlPostCodeAddr.TabIndex = 6;
            this.txtAlPostCodeAddr.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlStateProvAddr
            // 
            this.txtAlStateProvAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlStateProvAddr.DatabaseFieldLink = "AlStateProvAddr";
            this.txtAlStateProvAddr.DatabaseTableLink = null;
            this.txtAlStateProvAddr.FieldHint = null;
            this.txtAlStateProvAddr.Location = new System.Drawing.Point(58, 116);
            this.txtAlStateProvAddr.MaxLength = 70;
            this.txtAlStateProvAddr.Name = "txtAlStateProvAddr";
            this.txtAlStateProvAddr.Size = new System.Drawing.Size(35, 20);
            this.txtAlStateProvAddr.TabIndex = 5;
            this.txtAlStateProvAddr.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlCityAddr
            // 
            this.txtAlCityAddr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlCityAddr.DatabaseFieldLink = "AlCityAddr";
            this.txtAlCityAddr.DatabaseTableLink = null;
            this.txtAlCityAddr.FieldHint = null;
            this.txtAlCityAddr.Location = new System.Drawing.Point(58, 95);
            this.txtAlCityAddr.MaxLength = 70;
            this.txtAlCityAddr.Name = "txtAlCityAddr";
            this.txtAlCityAddr.Size = new System.Drawing.Size(358, 20);
            this.txtAlCityAddr.TabIndex = 4;
            this.txtAlCityAddr.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlAddr4
            // 
            this.txtAlAddr4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlAddr4.DatabaseFieldLink = "AlAddr4";
            this.txtAlAddr4.DatabaseTableLink = null;
            this.txtAlAddr4.FieldHint = null;
            this.txtAlAddr4.Location = new System.Drawing.Point(58, 74);
            this.txtAlAddr4.MaxLength = 70;
            this.txtAlAddr4.Name = "txtAlAddr4";
            this.txtAlAddr4.Size = new System.Drawing.Size(358, 20);
            this.txtAlAddr4.TabIndex = 3;
            this.txtAlAddr4.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlAddr3
            // 
            this.txtAlAddr3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlAddr3.DatabaseFieldLink = "AlAddr3";
            this.txtAlAddr3.DatabaseTableLink = null;
            this.txtAlAddr3.FieldHint = null;
            this.txtAlAddr3.Location = new System.Drawing.Point(58, 53);
            this.txtAlAddr3.MaxLength = 70;
            this.txtAlAddr3.Name = "txtAlAddr3";
            this.txtAlAddr3.Size = new System.Drawing.Size(358, 20);
            this.txtAlAddr3.TabIndex = 2;
            this.txtAlAddr3.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlAddr2
            // 
            this.txtAlAddr2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlAddr2.DatabaseFieldLink = "AlAddr2";
            this.txtAlAddr2.DatabaseTableLink = null;
            this.txtAlAddr2.FieldHint = null;
            this.txtAlAddr2.Location = new System.Drawing.Point(58, 32);
            this.txtAlAddr2.MaxLength = 70;
            this.txtAlAddr2.Name = "txtAlAddr2";
            this.txtAlAddr2.Size = new System.Drawing.Size(358, 20);
            this.txtAlAddr2.TabIndex = 1;
            this.txtAlAddr2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlAddr1
            // 
            this.txtAlAddr1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlAddr1.DatabaseFieldLink = "AlAddr1";
            this.txtAlAddr1.DatabaseTableLink = null;
            this.txtAlAddr1.FieldHint = null;
            this.txtAlAddr1.Location = new System.Drawing.Point(58, 11);
            this.txtAlAddr1.MaxLength = 70;
            this.txtAlAddr1.Name = "txtAlAddr1";
            this.txtAlAddr1.Size = new System.Drawing.Size(358, 20);
            this.txtAlAddr1.TabIndex = 0;
            this.txtAlAddr1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(174, 178);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clea&r";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddressInfoSC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 206);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpAddress);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(448, 240);
            this.Name = "frmAddressInfoSC";
            this.Text = "Address Information";
            this.Load += new System.EventHandler(this.frmAddressInfoSC_Load);
            this.Activated += new System.EventHandler(this.frmAddressInfoSC_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddressInfoSC_KeyDown);
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpAddress;
        private FormControls.TraxDELabel lblCountryCodeBillTo;
        private FormControls.TraxDELabel lblZipBillTo;
        private FormControls.TraxDELabel lblStBillTo;
        private FormControls.TraxDELabel lblCityBillTo;
        private FormControls.TraxDELabel lblAddressBillTo;
        private FormControls.TraxDELabel lblNameBillTo;
        private FormControls.TraxDETextBox txtAlCntryCodeAddr;
        private FormControls.TraxDETextBox txtAlPostCodeAddr;
        private FormControls.TraxDETextBox txtAlStateProvAddr;
        private FormControls.TraxDETextBox txtAlCityAddr;
        private FormControls.TraxDETextBox txtAlAddr4;
        private FormControls.TraxDETextBox txtAlAddr3;
        private FormControls.TraxDETextBox txtAlAddr2;
        private FormControls.TraxDETextBox txtAlAddr1;
        private System.Windows.Forms.Button btnClear;
        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDETextBox txtAlPortAddr;
        private FormControls.TraxDETextBox txtAddrCat;
        private FormControls.TraxDETextBox txtAddrNum;
        private FormControls.TraxDETextBox txtFbId;
        private System.Windows.Forms.Button btnCancel;
        private FormControls.TraxDELabel lblZone;
        private FormControls.TraxDETextBox txtAlZoneAddr;
    }
}