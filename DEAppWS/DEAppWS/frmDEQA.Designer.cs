namespace DEAppWS
{
    partial class frmDEQA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDEQA));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSaveClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSendReview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRestart = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuSingleFB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonOption = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuListView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuTreeView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuFB = new System.Windows.Forms.ToolStripMenuItem();
            this.grdImageGroup = new FormControls.TraxDEDataGridView();
            this.lblSearch = new FormControls.TraxDELabel();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpBoxImageGroup = new System.Windows.Forms.GroupBox();
            this.BatchNumber = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatchStatus = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.OwnerKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendSCAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.QABy = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.OwnerCode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatchAge = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).BeginInit();
            this.grpBoxImageGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonEdit,
            this.toolStripSeparator1,
            this.toolStripButtonSaveClose,
            this.toolStripButtonSave,
            this.toolStripButtonSendReview,
            this.toolStripSeparator2,
            this.toolStripButtonCancel,
            this.toolStripButtonRestart,
            this.toolStripSeparator3,
            this.toolStripButtonMode,
            this.toolStripButtonOption});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1192, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonStart.Text = "S&tart";
            this.toolStripButtonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonStart.ToolTipText = "Start Data Entry for a Batch";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(37, 22);
            this.toolStripButtonEdit.Text = "C&ont";
            this.toolStripButtonEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonEdit.ToolTipText = "Edit Batch";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSaveClose
            // 
            this.toolStripButtonSaveClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSaveClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveClose.Image")));
            this.toolStripButtonSaveClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveClose.Name = "toolStripButtonSaveClose";
            this.toolStripButtonSaveClose.Size = new System.Drawing.Size(69, 22);
            this.toolStripButtonSaveClose.Text = "Save/Cl&ose";
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonSave.Text = "&Save";
            // 
            // toolStripButtonSendReview
            // 
            this.toolStripButtonSendReview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSendReview.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSendReview.Image")));
            this.toolStripButtonSendReview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSendReview.Name = "toolStripButtonSendReview";
            this.toolStripButtonSendReview.Size = new System.Drawing.Size(37, 22);
            this.toolStripButtonSendReview.Text = "Se&nd";
            this.toolStripButtonSendReview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSendReview.ToolTipText = "Send for Review";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(47, 22);
            this.toolStripButtonCancel.Text = "&Cancel";
            this.toolStripButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCancel.ToolTipText = "Cancel Updates";
            // 
            // toolStripButtonRestart
            // 
            this.toolStripButtonRestart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonRestart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRestart.Image")));
            this.toolStripButtonRestart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRestart.Name = "toolStripButtonRestart";
            this.toolStripButtonRestart.Size = new System.Drawing.Size(47, 22);
            this.toolStripButtonRestart.Text = "&Restart";
            this.toolStripButtonRestart.ToolTipText = "Restart Batch";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMode
            // 
            this.toolStripButtonMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuSingleFB});
            this.toolStripButtonMode.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMode.Image")));
            this.toolStripButtonMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMode.Name = "toolStripButtonMode";
            this.toolStripButtonMode.Size = new System.Drawing.Size(51, 22);
            this.toolStripButtonMode.Text = "Mo&de";
            // 
            // toolStripMenuSingleFB
            // 
            this.toolStripMenuSingleFB.CheckOnClick = true;
            this.toolStripMenuSingleFB.Name = "toolStripMenuSingleFB";
            this.toolStripMenuSingleFB.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuSingleFB.Text = "Single Freight Bill";
            // 
            // toolStripButtonOption
            // 
            this.toolStripButtonOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuListView,
            this.toolStripMenuTreeView,
            this.toolStripSeparator4,
            this.toolStripMenuInvoice,
            this.toolStripMenuFB});
            this.toolStripButtonOption.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOption.Image")));
            this.toolStripButtonOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOption.Name = "toolStripButtonOption";
            this.toolStripButtonOption.Size = new System.Drawing.Size(57, 22);
            this.toolStripButtonOption.Text = "O&ption";
            // 
            // toolStripMenuListView
            // 
            this.toolStripMenuListView.Checked = true;
            this.toolStripMenuListView.CheckOnClick = true;
            this.toolStripMenuListView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuListView.Name = "toolStripMenuListView";
            this.toolStripMenuListView.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuListView.Text = "ListView";
            // 
            // toolStripMenuTreeView
            // 
            this.toolStripMenuTreeView.CheckOnClick = true;
            this.toolStripMenuTreeView.Name = "toolStripMenuTreeView";
            this.toolStripMenuTreeView.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuTreeView.Text = "TreeView";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(206, 6);
            // 
            // toolStripMenuInvoice
            // 
            this.toolStripMenuInvoice.CheckOnClick = true;
            this.toolStripMenuInvoice.Name = "toolStripMenuInvoice";
            this.toolStripMenuInvoice.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuInvoice.Text = "Autosave per Invoice Add";
            // 
            // toolStripMenuFB
            // 
            this.toolStripMenuFB.CheckOnClick = true;
            this.toolStripMenuFB.Name = "toolStripMenuFB";
            this.toolStripMenuFB.Size = new System.Drawing.Size(209, 22);
            this.toolStripMenuFB.Text = "Autosave per FB Add";
            // 
            // grdImageGroup
            // 
            this.grdImageGroup.AllowUserToAddRows = false;
            this.grdImageGroup.AllowUserToDeleteRows = false;
            this.grdImageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdImageGroup.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.grdImageGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImageGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchNumber,
            this.BatchStatus,
            this.OwnerKey,
            this.VendSCAC,
            this.Operator,
            this.QABy,
            this.OwnerCode,
            this.BatchAge});
            this.grdImageGroup.IsQAForm = false;
            this.grdImageGroup.Location = new System.Drawing.Point(6, 42);
            this.grdImageGroup.MultiSelect = false;
            this.grdImageGroup.Name = "grdImageGroup";
            this.grdImageGroup.QAValidationColumns = ((System.Collections.ArrayList)(resources.GetObject("grdImageGroup.QAValidationColumns")));
            this.grdImageGroup.ReadOnly = true;
            this.grdImageGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdImageGroup.Size = new System.Drawing.Size(476, 639);
            this.grdImageGroup.StandardTab = true;
            this.grdImageGroup.TabIndex = 2;
            this.grdImageGroup.SelectionChanged += new System.EventHandler(this.grdImageGroup_SelectionChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.DatabaseTableLink = null;
            this.lblSearch.Location = new System.Drawing.Point(6, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.DatabaseTableLink = null;
            this.txtSearch.FieldHint = null;
            this.txtSearch.Location = new System.Drawing.Point(59, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(342, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(407, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpBoxImageGroup
            // 
            this.grpBoxImageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxImageGroup.Controls.Add(this.btnRefresh);
            this.grpBoxImageGroup.Controls.Add(this.txtSearch);
            this.grpBoxImageGroup.Controls.Add(this.lblSearch);
            this.grpBoxImageGroup.Controls.Add(this.grdImageGroup);
            this.grpBoxImageGroup.Location = new System.Drawing.Point(12, 34);
            this.grpBoxImageGroup.Name = "grpBoxImageGroup";
            this.grpBoxImageGroup.Size = new System.Drawing.Size(1168, 687);
            this.grpBoxImageGroup.TabIndex = 0;
            this.grpBoxImageGroup.TabStop = false;
            this.grpBoxImageGroup.Text = "Choose Batch";
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
            // OwnerKey
            // 
            this.OwnerKey.DataPropertyName = "Owner Key";
            this.OwnerKey.HeaderText = "OwnerKey";
            this.OwnerKey.Name = "OwnerKey";
            this.OwnerKey.ReadOnly = true;
            this.OwnerKey.Visible = false;
            // 
            // VendSCAC
            // 
            this.VendSCAC.DataPropertyName = "Vendor SCAC";
            this.VendSCAC.HeaderText = "SCAC";
            this.VendSCAC.Name = "VendSCAC";
            this.VendSCAC.ReadOnly = true;
            this.VendSCAC.Visible = false;
            this.VendSCAC.Width = 70;
            // 
            // Operator
            // 
            this.Operator.DataPropertyName = "Operator";
            this.Operator.HeaderText = "Operator";
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            // 
            // QABy
            // 
            this.QABy.DataPropertyName = "QA By";
            this.QABy.HeaderText = "QA";
            this.QABy.Name = "QABy";
            this.QABy.ReadOnly = true;
            this.QABy.Visible = false;
            // 
            // OwnerCode
            // 
            this.OwnerCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OwnerCode.DataPropertyName = "OwnerCode";
            this.OwnerCode.HeaderText = "Client";
            this.OwnerCode.Name = "OwnerCode";
            this.OwnerCode.ReadOnly = true;
            this.OwnerCode.Visible = false;
            // 
            // BatchAge
            // 
            this.BatchAge.DataPropertyName = "BatchAge";
            this.BatchAge.HeaderText = "BatchAge";
            this.BatchAge.MinimumWidth = 60;
            this.BatchAge.Name = "BatchAge";
            this.BatchAge.ReadOnly = true;
            this.BatchAge.Width = 60;
            // 
            // frmDEQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 726);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.grpBoxImageGroup);
            this.KeyPreview = true;
            this.Name = "frmDEQA";
            this.Text = "frmDataEntryBase";
            this.Enter += new System.EventHandler(this.frmDEQA_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDEQA_FormClosing);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).EndInit();
            this.grpBoxImageGroup.ResumeLayout(false);
            this.grpBoxImageGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveClose;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonSendReview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.ToolStripButton toolStripButtonRestart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonOption;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuListView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuTreeView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuInvoice;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFB;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonMode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSingleFB;
        private FormControls.TraxDEDataGridView grdImageGroup;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDETextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpBoxImageGroup;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchNumber;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendSCAC;
        private FormControls.TraxDEDataGridViewTextBoxColumn Operator;
        private FormControls.TraxDEDataGridViewTextBoxColumn QABy;
        private FormControls.TraxDEDataGridViewTextBoxColumn OwnerCode;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchAge;
    }
}