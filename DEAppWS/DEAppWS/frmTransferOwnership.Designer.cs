namespace DEAppWS
{
    partial class frmTransferOwnership
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferOwnership));
            this.grpBoxImageGroup = new System.Windows.Forms.GroupBox();
            this.grdImageGroup = new FormControls.TraxDEDataGridView();
            this.BatchNumber = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Operator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.QABy = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatchStatus = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.lblSearch = new FormControls.TraxDELabel();
            this.grpUpdate = new System.Windows.Forms.GroupBox();
            this.radioReviewer = new System.Windows.Forms.RadioButton();
            this.radioOperator = new System.Windows.Forms.RadioButton();
            this.grpReviewer = new System.Windows.Forms.GroupBox();
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.traxDELabel2 = new FormControls.TraxDELabel();
            this.txtNewReviewerOwner = new FormControls.TraxDETextBox();
            this.txtOldReviewerOwner = new FormControls.TraxDETextBox();
            this.grpOperator = new System.Windows.Forms.GroupBox();
            this.lblNewOwner = new FormControls.TraxDELabel();
            this.lblOldOwner = new FormControls.TraxDELabel();
            this.txtNewOperatorOwner = new FormControls.TraxDETextBox();
            this.txtOldOperatorOwner = new FormControls.TraxDETextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpBoxImageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).BeginInit();
            this.grpUpdate.SuspendLayout();
            this.grpReviewer.SuspendLayout();
            this.grpOperator.SuspendLayout();
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
            this.grpBoxImageGroup.Size = new System.Drawing.Size(218, 256);
            this.grpBoxImageGroup.TabIndex = 85;
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
            this.Operator,
            this.QABy,
            this.BatchStatus});
            this.grdImageGroup.Location = new System.Drawing.Point(9, 42);
            this.grdImageGroup.MultiSelect = false;
            this.grdImageGroup.Name = "grdImageGroup";
            this.grdImageGroup.ReadOnly = true;
            this.grdImageGroup.RowHeadersVisible = false;
            this.grdImageGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdImageGroup.Size = new System.Drawing.Size(203, 208);
            this.grdImageGroup.StandardTab = true;
            this.grdImageGroup.TabIndex = 3;
            // 
            // BatchNumber
            // 
            this.BatchNumber.DataPropertyName = "Batch Number";
            this.BatchNumber.HeaderText = "Batch";
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.ReadOnly = true;
            this.BatchNumber.Width = 50;
            // 
            // Operator
            // 
            this.Operator.DataPropertyName = "Operator";
            this.Operator.HeaderText = "Operator";
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            this.Operator.Width = 60;
            // 
            // QABy
            // 
            this.QABy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QABy.DataPropertyName = "QA By";
            this.QABy.HeaderText = "QA By";
            this.QABy.Name = "QABy";
            this.QABy.ReadOnly = true;
            this.QABy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BatchStatus
            // 
            this.BatchStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BatchStatus.DataPropertyName = "Batch Status";
            this.BatchStatus.HeaderText = "Status";
            this.BatchStatus.Name = "BatchStatus";
            this.BatchStatus.ReadOnly = true;
            this.BatchStatus.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(59, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(72, 20);
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
            // grpUpdate
            // 
            this.grpUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUpdate.Controls.Add(this.radioReviewer);
            this.grpUpdate.Controls.Add(this.radioOperator);
            this.grpUpdate.Controls.Add(this.grpReviewer);
            this.grpUpdate.Controls.Add(this.grpOperator);
            this.grpUpdate.Controls.Add(this.btnUpdate);
            this.grpUpdate.Location = new System.Drawing.Point(236, 12);
            this.grpUpdate.Name = "grpUpdate";
            this.grpUpdate.Size = new System.Drawing.Size(163, 256);
            this.grpUpdate.TabIndex = 86;
            this.grpUpdate.TabStop = false;
            this.grpUpdate.Text = "Update Ownership";
            // 
            // radioReviewer
            // 
            this.radioReviewer.AutoSize = true;
            this.radioReviewer.Location = new System.Drawing.Point(6, 42);
            this.radioReviewer.Name = "radioReviewer";
            this.radioReviewer.Size = new System.Drawing.Size(70, 17);
            this.radioReviewer.TabIndex = 10;
            this.radioReviewer.Text = "Reviewer";
            this.radioReviewer.UseVisualStyleBackColor = true;
            this.radioReviewer.CheckedChanged += new System.EventHandler(this.radio_CheckedChange);
            // 
            // radioOperator
            // 
            this.radioOperator.AutoSize = true;
            this.radioOperator.Checked = true;
            this.radioOperator.Location = new System.Drawing.Point(6, 19);
            this.radioOperator.Name = "radioOperator";
            this.radioOperator.Size = new System.Drawing.Size(66, 17);
            this.radioOperator.TabIndex = 9;
            this.radioOperator.TabStop = true;
            this.radioOperator.Text = "Operator";
            this.radioOperator.UseVisualStyleBackColor = true;
            this.radioOperator.CheckedChanged += new System.EventHandler(this.radio_CheckedChange);
            // 
            // grpReviewer
            // 
            this.grpReviewer.Controls.Add(this.traxDELabel1);
            this.grpReviewer.Controls.Add(this.traxDELabel2);
            this.grpReviewer.Controls.Add(this.txtNewReviewerOwner);
            this.grpReviewer.Controls.Add(this.txtOldReviewerOwner);
            this.grpReviewer.Location = new System.Drawing.Point(6, 143);
            this.grpReviewer.Name = "grpReviewer";
            this.grpReviewer.Size = new System.Drawing.Size(151, 72);
            this.grpReviewer.TabIndex = 8;
            this.grpReviewer.TabStop = false;
            this.grpReviewer.Text = "Reviewer";
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.Location = new System.Drawing.Point(6, 48);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(69, 13);
            this.traxDELabel1.TabIndex = 14;
            this.traxDELabel1.Text = "New Owner :";
            // 
            // traxDELabel2
            // 
            this.traxDELabel2.AutoSize = true;
            this.traxDELabel2.Location = new System.Drawing.Point(6, 22);
            this.traxDELabel2.Name = "traxDELabel2";
            this.traxDELabel2.Size = new System.Drawing.Size(63, 13);
            this.traxDELabel2.TabIndex = 13;
            this.traxDELabel2.Text = "Old Owner :";
            // 
            // txtNewReviewerOwner
            // 
            this.txtNewReviewerOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewReviewerOwner.DatabaseFieldLink = null;
            this.txtNewReviewerOwner.Location = new System.Drawing.Point(75, 45);
            this.txtNewReviewerOwner.MaxLength = 3;
            this.txtNewReviewerOwner.Name = "txtNewReviewerOwner";
            this.txtNewReviewerOwner.Size = new System.Drawing.Size(70, 20);
            this.txtNewReviewerOwner.TabIndex = 12;
            this.txtNewReviewerOwner.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtOldReviewerOwner
            // 
            this.txtOldReviewerOwner.DatabaseFieldLink = null;
            this.txtOldReviewerOwner.Location = new System.Drawing.Point(75, 19);
            this.txtOldReviewerOwner.Name = "txtOldReviewerOwner";
            this.txtOldReviewerOwner.ReadOnly = true;
            this.txtOldReviewerOwner.Size = new System.Drawing.Size(70, 20);
            this.txtOldReviewerOwner.TabIndex = 11;
            this.txtOldReviewerOwner.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // grpOperator
            // 
            this.grpOperator.Controls.Add(this.lblNewOwner);
            this.grpOperator.Controls.Add(this.lblOldOwner);
            this.grpOperator.Controls.Add(this.txtNewOperatorOwner);
            this.grpOperator.Controls.Add(this.txtOldOperatorOwner);
            this.grpOperator.Location = new System.Drawing.Point(6, 65);
            this.grpOperator.Name = "grpOperator";
            this.grpOperator.Size = new System.Drawing.Size(151, 72);
            this.grpOperator.TabIndex = 5;
            this.grpOperator.TabStop = false;
            this.grpOperator.Text = "Operator";
            // 
            // lblNewOwner
            // 
            this.lblNewOwner.AutoSize = true;
            this.lblNewOwner.Location = new System.Drawing.Point(6, 48);
            this.lblNewOwner.Name = "lblNewOwner";
            this.lblNewOwner.Size = new System.Drawing.Size(69, 13);
            this.lblNewOwner.TabIndex = 10;
            this.lblNewOwner.Text = "New Owner :";
            // 
            // lblOldOwner
            // 
            this.lblOldOwner.AutoSize = true;
            this.lblOldOwner.Location = new System.Drawing.Point(6, 22);
            this.lblOldOwner.Name = "lblOldOwner";
            this.lblOldOwner.Size = new System.Drawing.Size(63, 13);
            this.lblOldOwner.TabIndex = 9;
            this.lblOldOwner.Text = "Old Owner :";
            // 
            // txtNewOperatorOwner
            // 
            this.txtNewOperatorOwner.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNewOperatorOwner.DatabaseFieldLink = null;
            this.txtNewOperatorOwner.Location = new System.Drawing.Point(75, 45);
            this.txtNewOperatorOwner.MaxLength = 3;
            this.txtNewOperatorOwner.Name = "txtNewOperatorOwner";
            this.txtNewOperatorOwner.Size = new System.Drawing.Size(70, 20);
            this.txtNewOperatorOwner.TabIndex = 8;
            this.txtNewOperatorOwner.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtOldOperatorOwner
            // 
            this.txtOldOperatorOwner.DatabaseFieldLink = null;
            this.txtOldOperatorOwner.Location = new System.Drawing.Point(75, 19);
            this.txtOldOperatorOwner.Name = "txtOldOperatorOwner";
            this.txtOldOperatorOwner.ReadOnly = true;
            this.txtOldOperatorOwner.Size = new System.Drawing.Size(70, 20);
            this.txtOldOperatorOwner.TabIndex = 7;
            this.txtOldOperatorOwner.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(82, 221);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(137, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmTransferOwnership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 280);
            this.Controls.Add(this.grpUpdate);
            this.Controls.Add(this.grpBoxImageGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTransferOwnership";
            this.Text = "Transfer Ownership";
            this.Load += new System.EventHandler(this.frmTransferOwnership_Load);
            this.grpBoxImageGroup.ResumeLayout(false);
            this.grpBoxImageGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).EndInit();
            this.grpUpdate.ResumeLayout(false);
            this.grpUpdate.PerformLayout();
            this.grpReviewer.ResumeLayout(false);
            this.grpReviewer.PerformLayout();
            this.grpOperator.ResumeLayout(false);
            this.grpOperator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxImageGroup;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDELabel lblSearch;
        private System.Windows.Forms.GroupBox grpUpdate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox grpOperator;
        private System.Windows.Forms.GroupBox grpReviewer;
        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDELabel traxDELabel2;
        private FormControls.TraxDETextBox txtNewReviewerOwner;
        private FormControls.TraxDETextBox txtOldReviewerOwner;
        private FormControls.TraxDELabel lblNewOwner;
        private FormControls.TraxDELabel lblOldOwner;
        private FormControls.TraxDETextBox txtNewOperatorOwner;
        private FormControls.TraxDETextBox txtOldOperatorOwner;
        private System.Windows.Forms.RadioButton radioReviewer;
        private System.Windows.Forms.RadioButton radioOperator;
        private FormControls.TraxDEDataGridView grdImageGroup;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchNumber;
        private FormControls.TraxDEDataGridViewTextBoxColumn Operator;
        private FormControls.TraxDEDataGridViewTextBoxColumn QABy;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchStatus;
        private System.Windows.Forms.Button btnRefresh;        
    }
}