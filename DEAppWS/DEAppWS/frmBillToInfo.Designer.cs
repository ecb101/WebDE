namespace DEAppWS
{
    partial class frmBillToInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBillToInfo));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxBillToAddress = new System.Windows.Forms.GroupBox();
            this.lblCountryCodeBillTo = new FormControls.TraxDELabel();
            this.lblZipBillTo = new FormControls.TraxDELabel();
            this.lblStBillTo = new FormControls.TraxDELabel();
            this.lblCityBillTo = new FormControls.TraxDELabel();
            this.lblAddressBillTo = new FormControls.TraxDELabel();
            this.lblNameBillTo = new FormControls.TraxDELabel();
            this.txtAlCntryCodeBlng = new FormControls.TraxDETextBox();
            this.txtAlPostCodeBlng = new FormControls.TraxDETextBox();
            this.txtAlStateProvBlng = new FormControls.TraxDETextBox();
            this.txtAlCityBlng = new FormControls.TraxDETextBox();
            this.txtAlBlng4 = new FormControls.TraxDETextBox();
            this.txtAlBlng3 = new FormControls.TraxDETextBox();
            this.txtAlBlng2 = new FormControls.TraxDETextBox();
            this.txtAlBlng1 = new FormControls.TraxDETextBox();
            this.grpBoxBillToID = new System.Windows.Forms.GroupBox();
            this.lblVendorSCAC = new FormControls.TraxDELabel();
            this.txtVendorSCAC = new FormControls.TraxDETextBox();
            this.lblBillToIndex = new FormControls.TraxDELabel();
            this.txtBillToIndex = new FormControls.TraxDETextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearchBillTo = new System.Windows.Forms.Button();
            this.txtSearchBillTo = new FormControls.TraxDETextBox();
            this.lstBoxSelectionBillTo = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpBoxBillToAddress.SuspendLayout();
            this.grpBoxBillToID.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 301);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpBoxBillToAddress
            // 
            this.grpBoxBillToAddress.Controls.Add(this.lblCountryCodeBillTo);
            this.grpBoxBillToAddress.Controls.Add(this.lblZipBillTo);
            this.grpBoxBillToAddress.Controls.Add(this.lblStBillTo);
            this.grpBoxBillToAddress.Controls.Add(this.lblCityBillTo);
            this.grpBoxBillToAddress.Controls.Add(this.lblAddressBillTo);
            this.grpBoxBillToAddress.Controls.Add(this.lblNameBillTo);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlCntryCodeBlng);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlPostCodeBlng);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlStateProvBlng);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlCityBlng);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlBlng4);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlBlng3);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlBlng2);
            this.grpBoxBillToAddress.Controls.Add(this.txtAlBlng1);
            this.grpBoxBillToAddress.Location = new System.Drawing.Point(12, 67);
            this.grpBoxBillToAddress.Name = "grpBoxBillToAddress";
            this.grpBoxBillToAddress.Size = new System.Drawing.Size(454, 184);
            this.grpBoxBillToAddress.TabIndex = 5;
            this.grpBoxBillToAddress.TabStop = false;
            this.grpBoxBillToAddress.Text = "Bill To Address";
            // 
            // lblCountryCodeBillTo
            // 
            this.lblCountryCodeBillTo.AutoSize = true;
            this.lblCountryCodeBillTo.DatabaseTableLink = null;
            this.lblCountryCodeBillTo.Location = new System.Drawing.Point(262, 157);
            this.lblCountryCodeBillTo.Name = "lblCountryCodeBillTo";
            this.lblCountryCodeBillTo.Size = new System.Drawing.Size(77, 13);
            this.lblCountryCodeBillTo.TabIndex = 13;
            this.lblCountryCodeBillTo.Text = "Country Code :";
            // 
            // lblZipBillTo
            // 
            this.lblZipBillTo.AutoSize = true;
            this.lblZipBillTo.DatabaseTableLink = null;
            this.lblZipBillTo.Location = new System.Drawing.Point(131, 157);
            this.lblZipBillTo.Name = "lblZipBillTo";
            this.lblZipBillTo.Size = new System.Drawing.Size(28, 13);
            this.lblZipBillTo.TabIndex = 12;
            this.lblZipBillTo.Text = "Zip :";
            // 
            // lblStBillTo
            // 
            this.lblStBillTo.AutoSize = true;
            this.lblStBillTo.DatabaseTableLink = null;
            this.lblStBillTo.Location = new System.Drawing.Point(6, 157);
            this.lblStBillTo.Name = "lblStBillTo";
            this.lblStBillTo.Size = new System.Drawing.Size(23, 13);
            this.lblStBillTo.TabIndex = 11;
            this.lblStBillTo.Text = "St :";
            // 
            // lblCityBillTo
            // 
            this.lblCityBillTo.AutoSize = true;
            this.lblCityBillTo.DatabaseTableLink = null;
            this.lblCityBillTo.Location = new System.Drawing.Point(6, 131);
            this.lblCityBillTo.Name = "lblCityBillTo";
            this.lblCityBillTo.Size = new System.Drawing.Size(30, 13);
            this.lblCityBillTo.TabIndex = 10;
            this.lblCityBillTo.Text = "City :";
            // 
            // lblAddressBillTo
            // 
            this.lblAddressBillTo.AutoSize = true;
            this.lblAddressBillTo.DatabaseTableLink = null;
            this.lblAddressBillTo.Location = new System.Drawing.Point(6, 76);
            this.lblAddressBillTo.Name = "lblAddressBillTo";
            this.lblAddressBillTo.Size = new System.Drawing.Size(51, 13);
            this.lblAddressBillTo.TabIndex = 9;
            this.lblAddressBillTo.Text = "Address :";
            // 
            // lblNameBillTo
            // 
            this.lblNameBillTo.AutoSize = true;
            this.lblNameBillTo.DatabaseTableLink = null;
            this.lblNameBillTo.Location = new System.Drawing.Point(6, 22);
            this.lblNameBillTo.Name = "lblNameBillTo";
            this.lblNameBillTo.Size = new System.Drawing.Size(41, 13);
            this.lblNameBillTo.TabIndex = 8;
            this.lblNameBillTo.Text = "Name :";
            // 
            // txtAlCntryCodeBlng
            // 
            this.txtAlCntryCodeBlng.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlCntryCodeBlng.DatabaseFieldLink = "AlCntryCodeBlng";
            this.txtAlCntryCodeBlng.DatabaseTableLink = null;
            this.txtAlCntryCodeBlng.FieldHint = null;
            this.txtAlCntryCodeBlng.Location = new System.Drawing.Point(345, 154);
            this.txtAlCntryCodeBlng.MaxLength = 30;
            this.txtAlCntryCodeBlng.Name = "txtAlCntryCodeBlng";
            this.txtAlCntryCodeBlng.Size = new System.Drawing.Size(103, 20);
            this.txtAlCntryCodeBlng.TabIndex = 7;
            this.txtAlCntryCodeBlng.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlPostCodeBlng
            // 
            this.txtAlPostCodeBlng.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlPostCodeBlng.DatabaseFieldLink = "AlPostCodeBlng";
            this.txtAlPostCodeBlng.DatabaseTableLink = null;
            this.txtAlPostCodeBlng.FieldHint = null;
            this.txtAlPostCodeBlng.Location = new System.Drawing.Point(165, 154);
            this.txtAlPostCodeBlng.MaxLength = 30;
            this.txtAlPostCodeBlng.Name = "txtAlPostCodeBlng";
            this.txtAlPostCodeBlng.Size = new System.Drawing.Size(91, 20);
            this.txtAlPostCodeBlng.TabIndex = 6;
            this.txtAlPostCodeBlng.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlStateProvBlng
            // 
            this.txtAlStateProvBlng.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlStateProvBlng.DatabaseFieldLink = "AlStateProvBlng";
            this.txtAlStateProvBlng.DatabaseTableLink = null;
            this.txtAlStateProvBlng.FieldHint = null;
            this.txtAlStateProvBlng.Location = new System.Drawing.Point(90, 154);
            this.txtAlStateProvBlng.MaxLength = 70;
            this.txtAlStateProvBlng.Name = "txtAlStateProvBlng";
            this.txtAlStateProvBlng.Size = new System.Drawing.Size(35, 20);
            this.txtAlStateProvBlng.TabIndex = 5;
            this.txtAlStateProvBlng.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlCityBlng
            // 
            this.txtAlCityBlng.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlCityBlng.DatabaseFieldLink = "AlCityBlng";
            this.txtAlCityBlng.DatabaseTableLink = null;
            this.txtAlCityBlng.FieldHint = null;
            this.txtAlCityBlng.Location = new System.Drawing.Point(90, 128);
            this.txtAlCityBlng.MaxLength = 70;
            this.txtAlCityBlng.Name = "txtAlCityBlng";
            this.txtAlCityBlng.Size = new System.Drawing.Size(249, 20);
            this.txtAlCityBlng.TabIndex = 4;
            this.txtAlCityBlng.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlBlng4
            // 
            this.txtAlBlng4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlBlng4.DatabaseFieldLink = "AlBlng4";
            this.txtAlBlng4.DatabaseTableLink = null;
            this.txtAlBlng4.FieldHint = null;
            this.txtAlBlng4.Location = new System.Drawing.Point(90, 101);
            this.txtAlBlng4.MaxLength = 70;
            this.txtAlBlng4.Name = "txtAlBlng4";
            this.txtAlBlng4.Size = new System.Drawing.Size(358, 20);
            this.txtAlBlng4.TabIndex = 3;
            this.txtAlBlng4.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlBlng3
            // 
            this.txtAlBlng3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlBlng3.DatabaseFieldLink = "AlBlng3";
            this.txtAlBlng3.DatabaseTableLink = null;
            this.txtAlBlng3.FieldHint = null;
            this.txtAlBlng3.Location = new System.Drawing.Point(90, 73);
            this.txtAlBlng3.MaxLength = 70;
            this.txtAlBlng3.Name = "txtAlBlng3";
            this.txtAlBlng3.Size = new System.Drawing.Size(358, 20);
            this.txtAlBlng3.TabIndex = 2;
            this.txtAlBlng3.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlBlng2
            // 
            this.txtAlBlng2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlBlng2.DatabaseFieldLink = "AlBlng2";
            this.txtAlBlng2.DatabaseTableLink = null;
            this.txtAlBlng2.FieldHint = null;
            this.txtAlBlng2.Location = new System.Drawing.Point(90, 47);
            this.txtAlBlng2.MaxLength = 70;
            this.txtAlBlng2.Name = "txtAlBlng2";
            this.txtAlBlng2.Size = new System.Drawing.Size(358, 20);
            this.txtAlBlng2.TabIndex = 1;
            this.txtAlBlng2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlBlng1
            // 
            this.txtAlBlng1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlBlng1.DatabaseFieldLink = "AlBlng1";
            this.txtAlBlng1.DatabaseTableLink = null;
            this.txtAlBlng1.FieldHint = null;
            this.txtAlBlng1.Location = new System.Drawing.Point(90, 19);
            this.txtAlBlng1.MaxLength = 70;
            this.txtAlBlng1.Name = "txtAlBlng1";
            this.txtAlBlng1.Size = new System.Drawing.Size(358, 20);
            this.txtAlBlng1.TabIndex = 0;
            this.txtAlBlng1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // grpBoxBillToID
            // 
            this.grpBoxBillToID.Controls.Add(this.lblVendorSCAC);
            this.grpBoxBillToID.Controls.Add(this.txtVendorSCAC);
            this.grpBoxBillToID.Controls.Add(this.lblBillToIndex);
            this.grpBoxBillToID.Controls.Add(this.txtBillToIndex);
            this.grpBoxBillToID.Location = new System.Drawing.Point(12, 12);
            this.grpBoxBillToID.Name = "grpBoxBillToID";
            this.grpBoxBillToID.Size = new System.Drawing.Size(454, 49);
            this.grpBoxBillToID.TabIndex = 6;
            this.grpBoxBillToID.TabStop = false;
            this.grpBoxBillToID.Text = "Bill To ID";
            // 
            // lblVendorSCAC
            // 
            this.lblVendorSCAC.AutoSize = true;
            this.lblVendorSCAC.DatabaseTableLink = null;
            this.lblVendorSCAC.Location = new System.Drawing.Point(6, 22);
            this.lblVendorSCAC.Name = "lblVendorSCAC";
            this.lblVendorSCAC.Size = new System.Drawing.Size(78, 13);
            this.lblVendorSCAC.TabIndex = 12;
            this.lblVendorSCAC.Text = "Vendor SCAC :";
            // 
            // txtVendorSCAC
            // 
            this.txtVendorSCAC.BackColor = System.Drawing.SystemColors.Control;
            this.txtVendorSCAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVendorSCAC.DatabaseFieldLink = "VendLabl";
            this.txtVendorSCAC.DatabaseTableLink = null;
            this.txtVendorSCAC.FieldHint = null;
            this.txtVendorSCAC.ForeColor = System.Drawing.Color.Black;
            this.txtVendorSCAC.Location = new System.Drawing.Point(90, 19);
            this.txtVendorSCAC.Name = "txtVendorSCAC";
            this.txtVendorSCAC.ReadOnly = true;
            this.txtVendorSCAC.Size = new System.Drawing.Size(142, 20);
            this.txtVendorSCAC.TabIndex = 11;
            this.txtVendorSCAC.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblBillToIndex
            // 
            this.lblBillToIndex.AutoSize = true;
            this.lblBillToIndex.DatabaseTableLink = null;
            this.lblBillToIndex.Location = new System.Drawing.Point(238, 22);
            this.lblBillToIndex.Name = "lblBillToIndex";
            this.lblBillToIndex.Size = new System.Drawing.Size(53, 13);
            this.lblBillToIndex.TabIndex = 10;
            this.lblBillToIndex.Text = "BillTo ID :";
            // 
            // txtBillToIndex
            // 
            this.txtBillToIndex.BackColor = System.Drawing.SystemColors.Control;
            this.txtBillToIndex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBillToIndex.DatabaseFieldLink = "LocIdBlng";
            this.txtBillToIndex.DatabaseTableLink = null;
            this.txtBillToIndex.FieldHint = null;
            this.txtBillToIndex.ForeColor = System.Drawing.Color.Black;
            this.txtBillToIndex.Location = new System.Drawing.Point(313, 19);
            this.txtBillToIndex.Name = "txtBillToIndex";
            this.txtBillToIndex.ReadOnly = true;
            this.txtBillToIndex.Size = new System.Drawing.Size(135, 20);
            this.txtBillToIndex.TabIndex = 5;
            this.txtBillToIndex.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearchBillTo);
            this.groupBox3.Controls.Add(this.txtSearchBillTo);
            this.groupBox3.Controls.Add(this.lstBoxSelectionBillTo);
            this.groupBox3.Location = new System.Drawing.Point(474, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(287, 312);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Selection";
            // 
            // btnSearchBillTo
            // 
            this.btnSearchBillTo.Location = new System.Drawing.Point(6, 17);
            this.btnSearchBillTo.Name = "btnSearchBillTo";
            this.btnSearchBillTo.Size = new System.Drawing.Size(64, 23);
            this.btnSearchBillTo.TabIndex = 9;
            this.btnSearchBillTo.Text = "Search";
            this.btnSearchBillTo.UseVisualStyleBackColor = true;
            this.btnSearchBillTo.Click += new System.EventHandler(this.btnSearchBillTo_Click);
            // 
            // txtSearchBillTo
            // 
            this.txtSearchBillTo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchBillTo.DatabaseFieldLink = null;
            this.txtSearchBillTo.DatabaseTableLink = null;
            this.txtSearchBillTo.FieldHint = null;
            this.txtSearchBillTo.Location = new System.Drawing.Point(76, 19);
            this.txtSearchBillTo.Name = "txtSearchBillTo";
            this.txtSearchBillTo.Size = new System.Drawing.Size(205, 20);
            this.txtSearchBillTo.TabIndex = 6;
            this.txtSearchBillTo.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearchBillTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchBillTo_KeyDown);
            // 
            // lstBoxSelectionBillTo
            // 
            this.lstBoxSelectionBillTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstBoxSelectionBillTo.FormattingEnabled = true;
            this.lstBoxSelectionBillTo.ItemHeight = 50;
            this.lstBoxSelectionBillTo.Location = new System.Drawing.Point(6, 45);
            this.lstBoxSelectionBillTo.Name = "lstBoxSelectionBillTo";
            this.lstBoxSelectionBillTo.Size = new System.Drawing.Size(275, 254);
            this.lstBoxSelectionBillTo.TabIndex = 5;
            this.lstBoxSelectionBillTo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBoxSelectionBillTo_DrawItem);
            this.lstBoxSelectionBillTo.SelectedIndexChanged += new System.EventHandler(this.lstBoxSelectionBillTo_SelectedIndexChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(174, 301);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clea&r";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmBillToInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 332);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpBoxBillToID);
            this.Controls.Add(this.grpBoxBillToAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(489, 370);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(489, 370);
            this.Name = "frmBillToInfo";
            this.Text = "Bill To Information";
            this.Load += new System.EventHandler(this.frmBillToInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVendorInfo_KeyDown);
            this.grpBoxBillToAddress.ResumeLayout(false);
            this.grpBoxBillToAddress.PerformLayout();
            this.grpBoxBillToID.ResumeLayout(false);
            this.grpBoxBillToID.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpBoxBillToAddress;
        private FormControls.TraxDELabel lblCountryCodeBillTo;
        private FormControls.TraxDELabel lblZipBillTo;
        private FormControls.TraxDELabel lblStBillTo;
        private FormControls.TraxDELabel lblCityBillTo;
        private FormControls.TraxDELabel lblAddressBillTo;
        private FormControls.TraxDELabel lblNameBillTo;
        private FormControls.TraxDETextBox txtAlCntryCodeBlng;
        private FormControls.TraxDETextBox txtAlPostCodeBlng;
        private FormControls.TraxDETextBox txtAlStateProvBlng;
        private FormControls.TraxDETextBox txtAlCityBlng;
        private FormControls.TraxDETextBox txtAlBlng4;
        private FormControls.TraxDETextBox txtAlBlng3;
        private FormControls.TraxDETextBox txtAlBlng2;
        private FormControls.TraxDETextBox txtAlBlng1;
        private System.Windows.Forms.GroupBox grpBoxBillToID;
        private FormControls.TraxDELabel lblBillToIndex;
        private FormControls.TraxDETextBox txtBillToIndex;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearchBillTo;
        private FormControls.TraxDETextBox txtSearchBillTo;
        private System.Windows.Forms.ListBox lstBoxSelectionBillTo;
        private FormControls.TraxDELabel lblVendorSCAC;
        private FormControls.TraxDETextBox txtVendorSCAC;
        private System.Windows.Forms.Button btnClear;
    }
}