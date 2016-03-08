namespace DEAppWS
{
    partial class frmForceStatusChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForceStatusChange));
            this.grpBoxImageGroup = new System.Windows.Forms.GroupBox();
            this.grdImageGroup = new FormControls.TraxDEDataGridView();
            this.BatchNumber = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatchStatus = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.lblSearch = new FormControls.TraxDELabel();
            this.grpRestoreStatus = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.radioReview = new System.Windows.Forms.RadioButton();
            this.radioInDE = new System.Windows.Forms.RadioButton();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpBoxImageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).BeginInit();
            this.grpRestoreStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxImageGroup
            // 
            this.grpBoxImageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxImageGroup.Controls.Add(this.btnRefresh);
            this.grpBoxImageGroup.Controls.Add(this.grdImageGroup);
            this.grpBoxImageGroup.Controls.Add(this.txtSearch);
            this.grpBoxImageGroup.Controls.Add(this.lblSearch);
            this.grpBoxImageGroup.Location = new System.Drawing.Point(12, 12);
            this.grpBoxImageGroup.Name = "grpBoxImageGroup";
            this.grpBoxImageGroup.Size = new System.Drawing.Size(220, 188);
            this.grpBoxImageGroup.TabIndex = 86;
            this.grpBoxImageGroup.TabStop = false;
            this.grpBoxImageGroup.Text = "Choose Batch";
            // 
            // grdImageGroup
            // 
            this.grdImageGroup.AllowUserToAddRows = false;
            this.grdImageGroup.AllowUserToDeleteRows = false;
            this.grdImageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdImageGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImageGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchNumber,
            this.BatchStatus});
            this.grdImageGroup.Location = new System.Drawing.Point(9, 42);
            this.grdImageGroup.MultiSelect = false;
            this.grdImageGroup.Name = "grdImageGroup";
            this.grdImageGroup.ReadOnly = true;
            this.grdImageGroup.RowHeadersVisible = false;
            this.grdImageGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdImageGroup.Size = new System.Drawing.Size(205, 140);
            this.grdImageGroup.StandardTab = true;
            this.grdImageGroup.TabIndex = 3;
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
            this.BatchStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BatchStatus.DataPropertyName = "Batch Status";
            this.BatchStatus.HeaderText = "Status";
            this.BatchStatus.Name = "BatchStatus";
            this.BatchStatus.ReadOnly = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(59, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(74, 20);
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
            // grpRestoreStatus
            // 
            this.grpRestoreStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRestoreStatus.Controls.Add(this.btnRestore);
            this.grpRestoreStatus.Controls.Add(this.radioReview);
            this.grpRestoreStatus.Controls.Add(this.radioInDE);
            this.grpRestoreStatus.Location = new System.Drawing.Point(238, 12);
            this.grpRestoreStatus.Name = "grpRestoreStatus";
            this.grpRestoreStatus.Size = new System.Drawing.Size(106, 188);
            this.grpRestoreStatus.TabIndex = 87;
            this.grpRestoreStatus.TabStop = false;
            this.grpRestoreStatus.Text = "Restore Status";
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.Location = new System.Drawing.Point(25, 159);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 13;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // radioReview
            // 
            this.radioReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioReview.AutoSize = true;
            this.radioReview.Location = new System.Drawing.Point(6, 42);
            this.radioReview.Name = "radioReview";
            this.radioReview.Size = new System.Drawing.Size(68, 17);
            this.radioReview.TabIndex = 12;
            this.radioReview.Text = "REVIEW";
            this.radioReview.UseVisualStyleBackColor = true;
            this.radioReview.CheckedChanged += new System.EventHandler(this.radio_CheckedChange);
            // 
            // radioInDE
            // 
            this.radioInDE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioInDE.AutoSize = true;
            this.radioInDE.Checked = true;
            this.radioInDE.Location = new System.Drawing.Point(6, 19);
            this.radioInDE.Name = "radioInDE";
            this.radioInDE.Size = new System.Drawing.Size(54, 17);
            this.radioInDE.TabIndex = 11;
            this.radioInDE.TabStop = true;
            this.radioInDE.Text = "IN DE";
            this.radioInDE.UseVisualStyleBackColor = true;
            this.radioInDE.CheckedChanged += new System.EventHandler(this.radio_CheckedChange);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(139, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmForceStatusChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 212);
            this.Controls.Add(this.grpRestoreStatus);
            this.Controls.Add(this.grpBoxImageGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmForceStatusChange";
            this.Text = "Force Status Change";
            this.Load += new System.EventHandler(this.frmForceStatusChange_Load);
            this.grpBoxImageGroup.ResumeLayout(false);
            this.grpBoxImageGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).EndInit();
            this.grpRestoreStatus.ResumeLayout(false);
            this.grpRestoreStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxImageGroup;
        private FormControls.TraxDEDataGridView grdImageGroup;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchNumber;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchStatus;
        private System.Windows.Forms.GroupBox grpRestoreStatus;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.RadioButton radioReview;
        private System.Windows.Forms.RadioButton radioInDE;
        private System.Windows.Forms.Button btnRefresh;
    }
}