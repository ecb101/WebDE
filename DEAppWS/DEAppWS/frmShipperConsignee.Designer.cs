namespace DEAppWS
{
    partial class frmShipperConsignee
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
            this.grpBoxSelection = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSearch = new FormControls.TraxDELabel();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.grdInfo = new FormControls.TraxDEDataGridView();
            this.Name1 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Name2 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Address1 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Address2 = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.City = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.St = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Zip = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Country = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.grpBoxSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxSelection
            // 
            this.grpBoxSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxSelection.Controls.Add(this.btnOK);
            this.grpBoxSelection.Controls.Add(this.lblSearch);
            this.grpBoxSelection.Controls.Add(this.txtSearch);
            this.grpBoxSelection.Controls.Add(this.grdInfo);
            this.grpBoxSelection.Location = new System.Drawing.Point(12, 12);
            this.grpBoxSelection.Name = "grpBoxSelection";
            this.grpBoxSelection.Size = new System.Drawing.Size(1309, 423);
            this.grpBoxSelection.TabIndex = 1;
            this.grpBoxSelection.TabStop = false;
            this.grpBoxSelection.Text = "Info";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(6, 394);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 22);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search : ";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(62, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(1241, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grdInfo
            // 
            this.grdInfo.AllowUserToAddRows = false;
            this.grdInfo.AllowUserToDeleteRows = false;
            this.grdInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name1,
            this.Name2,
            this.Address1,
            this.Address2,
            this.City,
            this.St,
            this.Zip,
            this.Country});
            this.grdInfo.Location = new System.Drawing.Point(6, 45);
            this.grdInfo.MultiSelect = false;
            this.grdInfo.Name = "grdInfo";
            this.grdInfo.ReadOnly = true;
            this.grdInfo.RowHeadersVisible = false;
            this.grdInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInfo.Size = new System.Drawing.Size(1297, 343);
            this.grdInfo.StandardTab = true;
            this.grdInfo.TabIndex = 2;
            this.grdInfo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInfo_CellDoubleClick);
            this.grdInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdInfo_KeyDown);
            // 
            // Name1
            // 
            this.Name1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name1.DataPropertyName = "Name1";
            this.Name1.HeaderText = "Name1";
            this.Name1.MinimumWidth = 300;
            this.Name1.Name = "Name1";
            this.Name1.ReadOnly = true;
            // 
            // Name2
            // 
            this.Name2.DataPropertyName = "Name2";
            this.Name2.HeaderText = "Name2";
            this.Name2.Name = "Name2";
            this.Name2.ReadOnly = true;
            // 
            // Address1
            // 
            this.Address1.DataPropertyName = "Address1";
            this.Address1.HeaderText = "Address1";
            this.Address1.Name = "Address1";
            this.Address1.ReadOnly = true;
            // 
            // Address2
            // 
            this.Address2.DataPropertyName = "Address2";
            this.Address2.HeaderText = "Address2";
            this.Address2.Name = "Address2";
            this.Address2.ReadOnly = true;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            // 
            // St
            // 
            this.St.DataPropertyName = "St";
            this.St.HeaderText = "St";
            this.St.Name = "St";
            this.St.ReadOnly = true;
            // 
            // Zip
            // 
            this.Zip.DataPropertyName = "Zip";
            this.Zip.HeaderText = "Zip";
            this.Zip.Name = "Zip";
            this.Zip.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // frmShipperConsignee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 447);
            this.Controls.Add(this.grpBoxSelection);
            this.Name = "frmShipperConsignee";
            this.Load += new System.EventHandler(this.frmShipperConsignee_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmShipperConsignee_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShipperConsignee_KeyDown);
            this.grpBoxSelection.ResumeLayout(false);
            this.grpBoxSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSelection;
        private System.Windows.Forms.Button btnOK;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDEDataGridView grdInfo;
        private FormControls.TraxDEDataGridViewTextBoxColumn Name1;
        private FormControls.TraxDEDataGridViewTextBoxColumn Name2;
        private FormControls.TraxDEDataGridViewTextBoxColumn Address1;
        private FormControls.TraxDEDataGridViewTextBoxColumn Address2;
        private FormControls.TraxDEDataGridViewTextBoxColumn City;
        private FormControls.TraxDEDataGridViewTextBoxColumn St;
        private FormControls.TraxDEDataGridViewTextBoxColumn Zip;
        private FormControls.TraxDEDataGridViewTextBoxColumn Country;
    }
}