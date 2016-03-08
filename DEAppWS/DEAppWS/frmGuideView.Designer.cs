namespace DEAppWS
{
    partial class frmGuideView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuideView));
            this.grdList = new FormControls.TraxDEDataGridView();
            this.btnNoGuide = new System.Windows.Forms.Button();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.CarrierName = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Format = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Filename = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FileC = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.LatestVersion = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.ViewGuide = new System.Windows.Forms.DataGridViewButtonColumn();
            this.UseGuide = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdList
            // 
            this.grdList.AllowUserToAddRows = false;
            this.grdList.AllowUserToDeleteRows = false;
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarrierName,
            this.Format,
            this.Filename,
            this.FileC,
            this.LatestVersion,
            this.ViewGuide,
            this.UseGuide});
            this.grdList.IsQAForm = false;
            this.grdList.Location = new System.Drawing.Point(12, 39);
            this.grdList.MultiSelect = false;
            this.grdList.Name = "grdList";
            this.grdList.QAValidationColumns = ((System.Collections.ArrayList)(resources.GetObject("grdList.QAValidationColumns")));
            this.grdList.RowHeadersVisible = false;
            this.grdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdList.Size = new System.Drawing.Size(760, 308);
            this.grdList.StandardTab = true;
            this.grdList.TabIndex = 36;
            this.grdList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdList_CellContentClick);
            // 
            // btnNoGuide
            // 
            this.btnNoGuide.Location = new System.Drawing.Point(652, 8);
            this.btnNoGuide.Name = "btnNoGuide";
            this.btnNoGuide.Size = new System.Drawing.Size(120, 29);
            this.btnNoGuide.TabIndex = 37;
            this.btnNoGuide.Text = "No Guide Available";
            this.btnNoGuide.UseVisualStyleBackColor = true;
            this.btnNoGuide.Click += new System.EventHandler(this.btnNoGuide_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.DatabaseTableLink = null;
            this.txtSearch.FieldHint = null;
            this.txtSearch.Location = new System.Drawing.Point(62, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(572, 20);
            this.txtSearch.TabIndex = 38;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALPHA_NUMERIC;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.DatabaseTableLink = null;
            this.traxDELabel1.Location = new System.Drawing.Point(12, 16);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(44, 13);
            this.traxDELabel1.TabIndex = 39;
            this.traxDELabel1.Text = "Search:";
            // 
            // CarrierName
            // 
            this.CarrierName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarrierName.DataPropertyName = "CarrierName";
            this.CarrierName.HeaderText = "CarrierName";
            this.CarrierName.Name = "CarrierName";
            // 
            // Format
            // 
            this.Format.DataPropertyName = "Format";
            this.Format.HeaderText = "Format";
            this.Format.Name = "Format";
            // 
            // Filename
            // 
            this.Filename.DataPropertyName = "Filename";
            this.Filename.HeaderText = "Filename";
            this.Filename.Name = "Filename";
            // 
            // FileC
            // 
            this.FileC.DataPropertyName = "FileC";
            this.FileC.HeaderText = "File";
            this.FileC.Name = "FileC";
            this.FileC.Visible = false;
            // 
            // LatestVersion
            // 
            this.LatestVersion.DataPropertyName = "LatestVersion";
            this.LatestVersion.HeaderText = "LatestVersion";
            this.LatestVersion.Name = "LatestVersion";
            // 
            // ViewGuide
            // 
            this.ViewGuide.DataPropertyName = "ViewGuide";
            this.ViewGuide.HeaderText = "ViewGuide";
            this.ViewGuide.Name = "ViewGuide";
            this.ViewGuide.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // UseGuide
            // 
            this.UseGuide.DataPropertyName = "UseGuide";
            this.UseGuide.HeaderText = "UseGuide";
            this.UseGuide.Name = "UseGuide";
            this.UseGuide.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // frmGuideView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 359);
            this.Controls.Add(this.traxDELabel1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnNoGuide);
            this.Controls.Add(this.grdList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGuideView";
            this.Text = "Guide View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGuideView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected FormControls.TraxDEDataGridView grdList;
        private System.Windows.Forms.Button btnNoGuide;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDEDataGridViewTextBoxColumn CarrierName;
        private FormControls.TraxDEDataGridViewTextBoxColumn Format;
        private FormControls.TraxDEDataGridViewTextBoxColumn Filename;
        private FormControls.TraxDEDataGridViewTextBoxColumn FileC;
        private FormControls.TraxDEDataGridViewTextBoxColumn LatestVersion;
        private System.Windows.Forms.DataGridViewButtonColumn ViewGuide;
        private System.Windows.Forms.DataGridViewButtonColumn UseGuide;

    }
}