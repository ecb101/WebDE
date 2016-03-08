namespace DEAppWS
{
    partial class frmVendorInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVendorInfo));
            this.grpBoxSelection = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.lstBoxSelection = new System.Windows.Forms.ListBox();
            this.grpBoxRemitAddress = new System.Windows.Forms.GroupBox();
            this.lblCountryCode = new FormControls.TraxDELabel();
            this.lblZip = new FormControls.TraxDELabel();
            this.lblSt = new FormControls.TraxDELabel();
            this.lblCity = new FormControls.TraxDELabel();
            this.lblAddress = new FormControls.TraxDELabel();
            this.lblName = new FormControls.TraxDELabel();
            this.txtAlCntryCodeRemit = new FormControls.TraxDETextBox();
            this.txtAlPostCodeRemit = new FormControls.TraxDETextBox();
            this.txtAlStateProvRemit = new FormControls.TraxDETextBox();
            this.txtAlCityRemit = new FormControls.TraxDETextBox();
            this.txtAlRemit4 = new FormControls.TraxDETextBox();
            this.txtAlRemit3 = new FormControls.TraxDETextBox();
            this.txtAlRemit2 = new FormControls.TraxDETextBox();
            this.txtAlRemit1 = new FormControls.TraxDETextBox();
            this.grpBoxVendorSCAC = new System.Windows.Forms.GroupBox();
            this.lblRemitIndex = new FormControls.TraxDELabel();
            this.lblVendorSCAC = new FormControls.TraxDELabel();
            this.txtRemitIndex = new FormControls.TraxDETextBox();
            this.txtVendorSCAC = new FormControls.TraxDETextBox();
            this.ddlDESCAC = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBoxSelection.SuspendLayout();
            this.grpBoxRemitAddress.SuspendLayout();
            this.grpBoxVendorSCAC.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxSelection
            // 
            this.grpBoxSelection.Controls.Add(this.btnSearch);
            this.grpBoxSelection.Controls.Add(this.txtSearch);
            this.grpBoxSelection.Controls.Add(this.lstBoxSelection);
            this.grpBoxSelection.Location = new System.Drawing.Point(474, 12);
            this.grpBoxSelection.Name = "grpBoxSelection";
            this.grpBoxSelection.Size = new System.Drawing.Size(287, 310);
            this.grpBoxSelection.TabIndex = 0;
            this.grpBoxSelection.TabStop = false;
            this.grpBoxSelection.Text = "Selection";
            this.grpBoxSelection.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(6, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.DatabaseTableLink = null;
            this.txtSearch.FieldHint = null;
            this.txtSearch.Location = new System.Drawing.Point(76, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 20);
            this.txtSearch.TabIndex = 6;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lstBoxSelection
            // 
            this.lstBoxSelection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstBoxSelection.FormattingEnabled = true;
            this.lstBoxSelection.ItemHeight = 50;
            this.lstBoxSelection.Location = new System.Drawing.Point(6, 45);
            this.lstBoxSelection.Name = "lstBoxSelection";
            this.lstBoxSelection.Size = new System.Drawing.Size(275, 254);
            this.lstBoxSelection.TabIndex = 5;
            this.lstBoxSelection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lstBoxSelection_DrawItem);
            this.lstBoxSelection.SelectedIndexChanged += new System.EventHandler(this.lstBoxSelection_SelectedIndexChanged);
            // 
            // grpBoxRemitAddress
            // 
            this.grpBoxRemitAddress.Controls.Add(this.lblCountryCode);
            this.grpBoxRemitAddress.Controls.Add(this.lblZip);
            this.grpBoxRemitAddress.Controls.Add(this.lblSt);
            this.grpBoxRemitAddress.Controls.Add(this.lblCity);
            this.grpBoxRemitAddress.Controls.Add(this.lblAddress);
            this.grpBoxRemitAddress.Controls.Add(this.lblName);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlCntryCodeRemit);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlPostCodeRemit);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlStateProvRemit);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlCityRemit);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlRemit4);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlRemit3);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlRemit2);
            this.grpBoxRemitAddress.Controls.Add(this.txtAlRemit1);
            this.grpBoxRemitAddress.Location = new System.Drawing.Point(12, 100);
            this.grpBoxRemitAddress.Name = "grpBoxRemitAddress";
            this.grpBoxRemitAddress.Size = new System.Drawing.Size(454, 184);
            this.grpBoxRemitAddress.TabIndex = 1;
            this.grpBoxRemitAddress.TabStop = false;
            this.grpBoxRemitAddress.Text = "Remit Address";
            // 
            // lblCountryCode
            // 
            this.lblCountryCode.AutoSize = true;
            this.lblCountryCode.DatabaseTableLink = null;
            this.lblCountryCode.Location = new System.Drawing.Point(262, 157);
            this.lblCountryCode.Name = "lblCountryCode";
            this.lblCountryCode.Size = new System.Drawing.Size(77, 13);
            this.lblCountryCode.TabIndex = 13;
            this.lblCountryCode.Text = "Country Code :";
            // 
            // lblZip
            // 
            this.lblZip.AutoSize = true;
            this.lblZip.DatabaseTableLink = null;
            this.lblZip.Location = new System.Drawing.Point(131, 157);
            this.lblZip.Name = "lblZip";
            this.lblZip.Size = new System.Drawing.Size(28, 13);
            this.lblZip.TabIndex = 12;
            this.lblZip.Text = "Zip :";
            // 
            // lblSt
            // 
            this.lblSt.AutoSize = true;
            this.lblSt.DatabaseTableLink = null;
            this.lblSt.Location = new System.Drawing.Point(6, 157);
            this.lblSt.Name = "lblSt";
            this.lblSt.Size = new System.Drawing.Size(23, 13);
            this.lblSt.TabIndex = 11;
            this.lblSt.Text = "St :";
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.DatabaseTableLink = null;
            this.lblCity.Location = new System.Drawing.Point(6, 131);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(30, 13);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City :";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.DatabaseTableLink = null;
            this.lblAddress.Location = new System.Drawing.Point(6, 76);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(51, 13);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.DatabaseTableLink = null;
            this.lblName.Location = new System.Drawing.Point(6, 22);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "Name :";
            // 
            // txtAlCntryCodeRemit
            // 
            this.txtAlCntryCodeRemit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlCntryCodeRemit.DatabaseFieldLink = "AlCntryCodeRemit";
            this.txtAlCntryCodeRemit.DatabaseTableLink = null;
            this.txtAlCntryCodeRemit.FieldHint = null;
            this.txtAlCntryCodeRemit.Location = new System.Drawing.Point(345, 154);
            this.txtAlCntryCodeRemit.MaxLength = 30;
            this.txtAlCntryCodeRemit.Name = "txtAlCntryCodeRemit";
            this.txtAlCntryCodeRemit.Size = new System.Drawing.Size(103, 20);
            this.txtAlCntryCodeRemit.TabIndex = 7;
            this.txtAlCntryCodeRemit.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlPostCodeRemit
            // 
            this.txtAlPostCodeRemit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlPostCodeRemit.DatabaseFieldLink = "AlPostCodeRemit";
            this.txtAlPostCodeRemit.DatabaseTableLink = null;
            this.txtAlPostCodeRemit.FieldHint = null;
            this.txtAlPostCodeRemit.Location = new System.Drawing.Point(165, 154);
            this.txtAlPostCodeRemit.MaxLength = 30;
            this.txtAlPostCodeRemit.Name = "txtAlPostCodeRemit";
            this.txtAlPostCodeRemit.Size = new System.Drawing.Size(91, 20);
            this.txtAlPostCodeRemit.TabIndex = 6;
            this.txtAlPostCodeRemit.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlStateProvRemit
            // 
            this.txtAlStateProvRemit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlStateProvRemit.DatabaseFieldLink = "AlStateProvRemit";
            this.txtAlStateProvRemit.DatabaseTableLink = null;
            this.txtAlStateProvRemit.FieldHint = null;
            this.txtAlStateProvRemit.Location = new System.Drawing.Point(90, 154);
            this.txtAlStateProvRemit.MaxLength = 70;
            this.txtAlStateProvRemit.Name = "txtAlStateProvRemit";
            this.txtAlStateProvRemit.Size = new System.Drawing.Size(35, 20);
            this.txtAlStateProvRemit.TabIndex = 5;
            this.txtAlStateProvRemit.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlCityRemit
            // 
            this.txtAlCityRemit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlCityRemit.DatabaseFieldLink = "AlCityRemit";
            this.txtAlCityRemit.DatabaseTableLink = null;
            this.txtAlCityRemit.FieldHint = null;
            this.txtAlCityRemit.Location = new System.Drawing.Point(90, 128);
            this.txtAlCityRemit.MaxLength = 70;
            this.txtAlCityRemit.Name = "txtAlCityRemit";
            this.txtAlCityRemit.Size = new System.Drawing.Size(249, 20);
            this.txtAlCityRemit.TabIndex = 4;
            this.txtAlCityRemit.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlRemit4
            // 
            this.txtAlRemit4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlRemit4.DatabaseFieldLink = "AlRemit4";
            this.txtAlRemit4.DatabaseTableLink = null;
            this.txtAlRemit4.FieldHint = null;
            this.txtAlRemit4.Location = new System.Drawing.Point(90, 101);
            this.txtAlRemit4.MaxLength = 70;
            this.txtAlRemit4.Name = "txtAlRemit4";
            this.txtAlRemit4.Size = new System.Drawing.Size(358, 20);
            this.txtAlRemit4.TabIndex = 3;
            this.txtAlRemit4.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlRemit3
            // 
            this.txtAlRemit3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlRemit3.DatabaseFieldLink = "AlRemit3";
            this.txtAlRemit3.DatabaseTableLink = null;
            this.txtAlRemit3.FieldHint = null;
            this.txtAlRemit3.Location = new System.Drawing.Point(90, 73);
            this.txtAlRemit3.MaxLength = 70;
            this.txtAlRemit3.Name = "txtAlRemit3";
            this.txtAlRemit3.Size = new System.Drawing.Size(358, 20);
            this.txtAlRemit3.TabIndex = 2;
            this.txtAlRemit3.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlRemit2
            // 
            this.txtAlRemit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlRemit2.DatabaseFieldLink = "AlRemit2";
            this.txtAlRemit2.DatabaseTableLink = null;
            this.txtAlRemit2.FieldHint = null;
            this.txtAlRemit2.Location = new System.Drawing.Point(90, 47);
            this.txtAlRemit2.MaxLength = 70;
            this.txtAlRemit2.Name = "txtAlRemit2";
            this.txtAlRemit2.Size = new System.Drawing.Size(358, 20);
            this.txtAlRemit2.TabIndex = 1;
            this.txtAlRemit2.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtAlRemit1
            // 
            this.txtAlRemit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlRemit1.DatabaseFieldLink = "AlRemit1";
            this.txtAlRemit1.DatabaseTableLink = null;
            this.txtAlRemit1.FieldHint = null;
            this.txtAlRemit1.Location = new System.Drawing.Point(90, 19);
            this.txtAlRemit1.MaxLength = 70;
            this.txtAlRemit1.Name = "txtAlRemit1";
            this.txtAlRemit1.Size = new System.Drawing.Size(358, 20);
            this.txtAlRemit1.TabIndex = 0;
            this.txtAlRemit1.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // grpBoxVendorSCAC
            // 
            this.grpBoxVendorSCAC.Controls.Add(this.lblRemitIndex);
            this.grpBoxVendorSCAC.Controls.Add(this.lblVendorSCAC);
            this.grpBoxVendorSCAC.Controls.Add(this.txtRemitIndex);
            this.grpBoxVendorSCAC.Controls.Add(this.txtVendorSCAC);
            this.grpBoxVendorSCAC.Controls.Add(this.ddlDESCAC);
            this.grpBoxVendorSCAC.Location = new System.Drawing.Point(12, 12);
            this.grpBoxVendorSCAC.Name = "grpBoxVendorSCAC";
            this.grpBoxVendorSCAC.Size = new System.Drawing.Size(454, 82);
            this.grpBoxVendorSCAC.TabIndex = 2;
            this.grpBoxVendorSCAC.TabStop = false;
            this.grpBoxVendorSCAC.Text = "Vendor SCAC";
            // 
            // lblRemitIndex
            // 
            this.lblRemitIndex.AutoSize = true;
            this.lblRemitIndex.DatabaseTableLink = null;
            this.lblRemitIndex.Location = new System.Drawing.Point(238, 49);
            this.lblRemitIndex.Name = "lblRemitIndex";
            this.lblRemitIndex.Size = new System.Drawing.Size(54, 13);
            this.lblRemitIndex.TabIndex = 10;
            this.lblRemitIndex.Text = "Remit ID :";
            // 
            // lblVendorSCAC
            // 
            this.lblVendorSCAC.AutoSize = true;
            this.lblVendorSCAC.DatabaseTableLink = null;
            this.lblVendorSCAC.Location = new System.Drawing.Point(6, 49);
            this.lblVendorSCAC.Name = "lblVendorSCAC";
            this.lblVendorSCAC.Size = new System.Drawing.Size(78, 13);
            this.lblVendorSCAC.TabIndex = 9;
            this.lblVendorSCAC.Text = "Vendor SCAC :";
            // 
            // txtRemitIndex
            // 
            this.txtRemitIndex.BackColor = System.Drawing.SystemColors.Control;
            this.txtRemitIndex.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemitIndex.DatabaseFieldLink = "BatLocIdRemit";
            this.txtRemitIndex.DatabaseTableLink = null;
            this.txtRemitIndex.FieldHint = null;
            this.txtRemitIndex.ForeColor = System.Drawing.Color.Black;
            this.txtRemitIndex.Location = new System.Drawing.Point(313, 46);
            this.txtRemitIndex.Name = "txtRemitIndex";
            this.txtRemitIndex.ReadOnly = true;
            this.txtRemitIndex.Size = new System.Drawing.Size(135, 20);
            this.txtRemitIndex.TabIndex = 5;
            this.txtRemitIndex.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtVendorSCAC
            // 
            this.txtVendorSCAC.BackColor = System.Drawing.SystemColors.Control;
            this.txtVendorSCAC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVendorSCAC.DatabaseFieldLink = "VendLabl";
            this.txtVendorSCAC.DatabaseTableLink = null;
            this.txtVendorSCAC.FieldHint = null;
            this.txtVendorSCAC.ForeColor = System.Drawing.Color.Black;
            this.txtVendorSCAC.Location = new System.Drawing.Point(90, 46);
            this.txtVendorSCAC.Name = "txtVendorSCAC";
            this.txtVendorSCAC.ReadOnly = true;
            this.txtVendorSCAC.Size = new System.Drawing.Size(142, 20);
            this.txtVendorSCAC.TabIndex = 4;
            this.txtVendorSCAC.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // ddlDESCAC
            // 
            this.ddlDESCAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDESCAC.FormattingEnabled = true;
            this.ddlDESCAC.Location = new System.Drawing.Point(6, 19);
            this.ddlDESCAC.Name = "ddlDESCAC";
            this.ddlDESCAC.Size = new System.Drawing.Size(442, 21);
            this.ddlDESCAC.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 299);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(93, 299);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmVendorInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 332);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpBoxVendorSCAC);
            this.Controls.Add(this.grpBoxRemitAddress);
            this.Controls.Add(this.grpBoxSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(489, 370);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(489, 370);
            this.Name = "frmVendorInfo";
            this.Text = "Vendor Information";
            this.Load += new System.EventHandler(this.frmVendorInfo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVendorInfo_KeyDown);
            this.grpBoxSelection.ResumeLayout(false);
            this.grpBoxSelection.PerformLayout();
            this.grpBoxRemitAddress.ResumeLayout(false);
            this.grpBoxRemitAddress.PerformLayout();
            this.grpBoxVendorSCAC.ResumeLayout(false);
            this.grpBoxVendorSCAC.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSelection;
        private System.Windows.Forms.GroupBox grpBoxRemitAddress;
        private System.Windows.Forms.GroupBox grpBoxVendorSCAC;
        private System.Windows.Forms.ComboBox ddlDESCAC;
        private FormControls.TraxDETextBox txtRemitIndex;
        private FormControls.TraxDETextBox txtVendorSCAC;
        private FormControls.TraxDELabel lblVendorSCAC;
        private FormControls.TraxDELabel lblRemitIndex;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private FormControls.TraxDETextBox txtAlCntryCodeRemit;
        private FormControls.TraxDETextBox txtAlPostCodeRemit;
        private FormControls.TraxDETextBox txtAlStateProvRemit;
        private FormControls.TraxDETextBox txtAlCityRemit;
        private FormControls.TraxDETextBox txtAlRemit4;
        private FormControls.TraxDETextBox txtAlRemit3;
        private FormControls.TraxDETextBox txtAlRemit2;
        private FormControls.TraxDETextBox txtAlRemit1;
        private FormControls.TraxDELabel lblCountryCode;
        private FormControls.TraxDELabel lblZip;
        private FormControls.TraxDELabel lblSt;
        private FormControls.TraxDELabel lblCity;
        private FormControls.TraxDELabel lblAddress;
        private FormControls.TraxDELabel lblName;
        private System.Windows.Forms.ListBox lstBoxSelection;
        private FormControls.TraxDETextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}