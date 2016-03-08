namespace DEAppWS
{
    partial class frmAddressInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddressInfo));
            this.btnOK = new System.Windows.Forms.Button();
            this.grpBoxAddress = new System.Windows.Forms.GroupBox();
            this.grdAddress = new FormControls.TraxDEDataGridView();
            this.radioBtnPickUpAdd = new System.Windows.Forms.RadioButton();
            this.radioBtnDeliveryAdd = new System.Windows.Forms.RadioButton();
            this.radioBtnStopOffLoc = new System.Windows.Forms.RadioButton();
            this.AddrFbId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AddrNum = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AddrCat = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlAddr1 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlAddr2 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlAddr3 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlAddr4 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlCityAddr = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlStateProvAddr = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlPostCodeAddr = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlCntryCodeAddr = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlPortAddr = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.AlZoneAddr = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.grpBoxAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(1132, 225);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpBoxAddress
            // 
            this.grpBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxAddress.Controls.Add(this.grdAddress);
            this.grpBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold);
            this.grpBoxAddress.ForeColor = System.Drawing.SystemColors.Highlight;
            this.grpBoxAddress.Location = new System.Drawing.Point(12, 12);
            this.grpBoxAddress.Name = "grpBoxAddress";
            this.grpBoxAddress.Size = new System.Drawing.Size(1084, 210);
            this.grpBoxAddress.TabIndex = 0;
            this.grpBoxAddress.TabStop = false;
            this.grpBoxAddress.Text = "Pickup Address";
            // 
            // grdAddress
            // 
            this.grdAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAddress.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAddress.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddrFbId,
            this.AddrNum,
            this.AddrCat,
            this.AlAddr1,
            this.AlAddr2,
            this.AlAddr3,
            this.AlAddr4,
            this.AlCityAddr,
            this.AlStateProvAddr,
            this.AlPostCodeAddr,
            this.AlCntryCodeAddr,
            this.AlPortAddr,
            this.AlZoneAddr});
            this.grdAddress.Location = new System.Drawing.Point(6, 17);
            this.grdAddress.Name = "grdAddress";
            this.grdAddress.Size = new System.Drawing.Size(1072, 187);
            this.grdAddress.TabIndex = 0;
            this.grdAddress.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdAddress_UserDeletingRow);
            this.grdAddress.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.grdAddress_UserDeletedRow);
            this.grdAddress.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAddress_CellEndEdit);
            // 
            // radioBtnPickUpAdd
            // 
            this.radioBtnPickUpAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioBtnPickUpAdd.AutoSize = true;
            this.radioBtnPickUpAdd.Checked = true;
            this.radioBtnPickUpAdd.Location = new System.Drawing.Point(16, 228);
            this.radioBtnPickUpAdd.Name = "radioBtnPickUpAdd";
            this.radioBtnPickUpAdd.Size = new System.Drawing.Size(99, 17);
            this.radioBtnPickUpAdd.TabIndex = 1;
            this.radioBtnPickUpAdd.TabStop = true;
            this.radioBtnPickUpAdd.Text = "&Pickup Address";
            this.radioBtnPickUpAdd.UseVisualStyleBackColor = true;
            this.radioBtnPickUpAdd.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // radioBtnDeliveryAdd
            // 
            this.radioBtnDeliveryAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioBtnDeliveryAdd.AutoSize = true;
            this.radioBtnDeliveryAdd.Location = new System.Drawing.Point(121, 228);
            this.radioBtnDeliveryAdd.Name = "radioBtnDeliveryAdd";
            this.radioBtnDeliveryAdd.Size = new System.Drawing.Size(104, 17);
            this.radioBtnDeliveryAdd.TabIndex = 2;
            this.radioBtnDeliveryAdd.Text = "&Delivery Address";
            this.radioBtnDeliveryAdd.UseVisualStyleBackColor = true;
            this.radioBtnDeliveryAdd.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // radioBtnStopOffLoc
            // 
            this.radioBtnStopOffLoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioBtnStopOffLoc.AutoSize = true;
            this.radioBtnStopOffLoc.Location = new System.Drawing.Point(231, 228);
            this.radioBtnStopOffLoc.Name = "radioBtnStopOffLoc";
            this.radioBtnStopOffLoc.Size = new System.Drawing.Size(108, 17);
            this.radioBtnStopOffLoc.TabIndex = 3;
            this.radioBtnStopOffLoc.Text = "&Stop Off Location";
            this.radioBtnStopOffLoc.UseVisualStyleBackColor = true;
            this.radioBtnStopOffLoc.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // AddrFbId
            // 
            this.AddrFbId.DataPropertyName = "FbId";
            this.AddrFbId.HeaderText = "FbId";
            this.AddrFbId.Name = "AddrFbId";
            this.AddrFbId.Visible = false;
            // 
            // AddrNum
            // 
            this.AddrNum.DataPropertyName = "AddrNum";
            this.AddrNum.HeaderText = "AddrNum";
            this.AddrNum.Name = "AddrNum";
            this.AddrNum.Visible = false;
            // 
            // AddrCat
            // 
            this.AddrCat.DataPropertyName = "AddrCat";
            this.AddrCat.HeaderText = "AddrCat";
            this.AddrCat.Name = "AddrCat";
            this.AddrCat.Visible = false;
            // 
            // AlAddr1
            // 
            this.AlAddr1.DataPropertyName = "AlAddr1";
            this.AlAddr1.HeaderText = "Name1";
            this.AlAddr1.MaxInputLength = 70;
            this.AlAddr1.MinimumWidth = 150;
            this.AlAddr1.Name = "AlAddr1";
            this.AlAddr1.Width = 150;
            // 
            // AlAddr2
            // 
            this.AlAddr2.DataPropertyName = "AlAddr2";
            this.AlAddr2.HeaderText = "Name2";
            this.AlAddr2.MaxInputLength = 70;
            this.AlAddr2.Name = "AlAddr2";
            // 
            // AlAddr3
            // 
            this.AlAddr3.DataPropertyName = "AlAddr3";
            this.AlAddr3.HeaderText = "Address1";
            this.AlAddr3.MaxInputLength = 70;
            this.AlAddr3.MinimumWidth = 150;
            this.AlAddr3.Name = "AlAddr3";
            this.AlAddr3.Width = 159;
            // 
            // AlAddr4
            // 
            this.AlAddr4.DataPropertyName = "AlAddr4";
            this.AlAddr4.HeaderText = "Address2";
            this.AlAddr4.MaxInputLength = 70;
            this.AlAddr4.Name = "AlAddr4";
            // 
            // AlCityAddr
            // 
            this.AlCityAddr.DataPropertyName = "AlCityAddr";
            this.AlCityAddr.HeaderText = "City";
            this.AlCityAddr.MaxInputLength = 70;
            this.AlCityAddr.MinimumWidth = 150;
            this.AlCityAddr.Name = "AlCityAddr";
            this.AlCityAddr.Width = 150;
            // 
            // AlStateProvAddr
            // 
            this.AlStateProvAddr.DataPropertyName = "AlStateProvAddr";
            this.AlStateProvAddr.HeaderText = "St";
            this.AlStateProvAddr.MaxInputLength = 70;
            this.AlStateProvAddr.MinimumWidth = 40;
            this.AlStateProvAddr.Name = "AlStateProvAddr";
            this.AlStateProvAddr.Width = 40;
            // 
            // AlPostCodeAddr
            // 
            this.AlPostCodeAddr.DataPropertyName = "AlPostCodeAddr";
            this.AlPostCodeAddr.HeaderText = "Zip";
            this.AlPostCodeAddr.MaxInputLength = 30;
            this.AlPostCodeAddr.MinimumWidth = 100;
            this.AlPostCodeAddr.Name = "AlPostCodeAddr";
            // 
            // AlCntryCodeAddr
            // 
            this.AlCntryCodeAddr.DataPropertyName = "AlCntryCodeAddr";
            this.AlCntryCodeAddr.HeaderText = "Country";
            this.AlCntryCodeAddr.MaxInputLength = 30;
            this.AlCntryCodeAddr.MinimumWidth = 80;
            this.AlCntryCodeAddr.Name = "AlCntryCodeAddr";
            this.AlCntryCodeAddr.Width = 80;
            // 
            // AlPortAddr
            // 
            this.AlPortAddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlPortAddr.DataPropertyName = "AlPortAddr";
            this.AlPortAddr.HeaderText = "Port";
            this.AlPortAddr.MinimumWidth = 80;
            this.AlPortAddr.Name = "AlPortAddr";
            // 
            // AlZoneAddr
            // 
            this.AlZoneAddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlZoneAddr.DataPropertyName = "AlZoneAddr";
            this.AlZoneAddr.HeaderText = "Zone";
            this.AlZoneAddr.MinimumWidth = 180;
            this.AlZoneAddr.Name = "AlZoneAddr";
            this.AlZoneAddr.Visible = false;
            // 
            // frmAddressInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 250);
            this.Controls.Add(this.radioBtnStopOffLoc);
            this.Controls.Add(this.radioBtnDeliveryAdd);
            this.Controls.Add(this.radioBtnPickUpAdd);
            this.Controls.Add(this.grpBoxAddress);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1110, 284);
            this.Name = "frmAddressInfo";
            this.Text = "Address Information";
            this.Load += new System.EventHandler(this.frmAddressInfo_Load);
            this.Activated += new System.EventHandler(this.frmAddressInfo_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAddressInfo_KeyDown);
            this.grpBoxAddress.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpBoxAddress;
        private FormControls.TraxDEDataGridView grdAddress;
        private System.Windows.Forms.RadioButton radioBtnPickUpAdd;
        private System.Windows.Forms.RadioButton radioBtnDeliveryAdd;
        private System.Windows.Forms.RadioButton radioBtnStopOffLoc;
        private FormControls.TraxDEDataGridViewTextBoxColumn AddrFbId;
        private FormControls.TraxDEDataGridViewTextBoxColumn AddrNum;
        private FormControls.TraxDEDataGridViewTextBoxColumn AddrCat;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlAddr1;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlAddr2;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlAddr3;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlAddr4;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlCityAddr;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlStateProvAddr;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlPostCodeAddr;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlCntryCodeAddr;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlPortAddr;
        private FormControls.TraxDEDataGridViewTextBoxColumn AlZoneAddr;
    }
}