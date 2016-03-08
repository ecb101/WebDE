namespace DEAppWS
{
    partial class frmFBCountCorrection
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
            this.grpBoxBatch = new System.Windows.Forms.GroupBox();
            this.grpBoxCorrectField = new System.Windows.Forms.GroupBox();
            this.radioBtnDE = new System.Windows.Forms.RadioButton();
            this.radioBtnNone = new System.Windows.Forms.RadioButton();
            this.radioBtnBatching = new System.Windows.Forms.RadioButton();
            this.txtNote = new FormControls.TraxDETextBox();
            this.txtCount = new FormControls.TraxDETextBox();
            this.lblNote = new FormControls.TraxDELabel();
            this.lblCount = new FormControls.TraxDELabel();
            this.btnOK = new System.Windows.Forms.Button();
            this.grdBatches = new FormControls.TraxDEDataGridView();
            this.chkBoxAll = new System.Windows.Forms.CheckBox();
            this.lblSearch = new FormControls.TraxDELabel();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.Bat_Ctrl_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner_Key = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Vend_SCAC = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.NEW_DTM = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Assigned_Site = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Inv_Cnt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.DataEntry_FB_Cnt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Batching_FB_Cnt = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Oper_Init = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Rev_Init = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatchOperator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Correction = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpBoxBatch.SuspendLayout();
            this.grpBoxCorrectField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxBatch
            // 
            this.grpBoxBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxBatch.Controls.Add(this.chkBoxAll);
            this.grpBoxBatch.Controls.Add(this.lblSearch);
            this.grpBoxBatch.Controls.Add(this.txtSearch);
            this.grpBoxBatch.Controls.Add(this.grdBatches);
            this.grpBoxBatch.Location = new System.Drawing.Point(12, 12);
            this.grpBoxBatch.Name = "grpBoxBatch";
            this.grpBoxBatch.Size = new System.Drawing.Size(948, 336);
            this.grpBoxBatch.TabIndex = 1;
            this.grpBoxBatch.TabStop = false;
            this.grpBoxBatch.Text = "Batches";
            // 
            // grpBoxCorrectField
            // 
            this.grpBoxCorrectField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCorrectField.Controls.Add(this.btnOK);
            this.grpBoxCorrectField.Controls.Add(this.lblNote);
            this.grpBoxCorrectField.Controls.Add(this.txtNote);
            this.grpBoxCorrectField.Controls.Add(this.radioBtnDE);
            this.grpBoxCorrectField.Controls.Add(this.radioBtnNone);
            this.grpBoxCorrectField.Controls.Add(this.radioBtnBatching);
            this.grpBoxCorrectField.Controls.Add(this.lblCount);
            this.grpBoxCorrectField.Controls.Add(this.txtCount);
            this.grpBoxCorrectField.Location = new System.Drawing.Point(12, 354);
            this.grpBoxCorrectField.Name = "grpBoxCorrectField";
            this.grpBoxCorrectField.Size = new System.Drawing.Size(948, 72);
            this.grpBoxCorrectField.TabIndex = 5;
            this.grpBoxCorrectField.TabStop = false;
            // 
            // radioBtnDE
            // 
            this.radioBtnDE.AutoSize = true;
            this.radioBtnDE.Checked = true;
            this.radioBtnDE.Location = new System.Drawing.Point(6, 19);
            this.radioBtnDE.Name = "radioBtnDE";
            this.radioBtnDE.Size = new System.Drawing.Size(75, 17);
            this.radioBtnDE.TabIndex = 2;
            this.radioBtnDE.TabStop = true;
            this.radioBtnDE.Text = "Data Entry";
            this.radioBtnDE.UseVisualStyleBackColor = true;
            // 
            // radioBtnNone
            // 
            this.radioBtnNone.AutoSize = true;
            this.radioBtnNone.Location = new System.Drawing.Point(160, 19);
            this.radioBtnNone.Name = "radioBtnNone";
            this.radioBtnNone.Size = new System.Drawing.Size(51, 17);
            this.radioBtnNone.TabIndex = 3;
            this.radioBtnNone.Text = "None";
            this.radioBtnNone.UseVisualStyleBackColor = true;
            this.radioBtnNone.Visible = false;
            // 
            // radioBtnBatching
            // 
            this.radioBtnBatching.AutoSize = true;
            this.radioBtnBatching.Location = new System.Drawing.Point(87, 19);
            this.radioBtnBatching.Name = "radioBtnBatching";
            this.radioBtnBatching.Size = new System.Drawing.Size(67, 17);
            this.radioBtnBatching.TabIndex = 1;
            this.radioBtnBatching.Text = "Batching";
            this.radioBtnBatching.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNote.DatabaseFieldLink = null;
            this.txtNote.Location = new System.Drawing.Point(105, 45);
            this.txtNote.MaxLength = 50;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(756, 20);
            this.txtNote.TabIndex = 4;
            this.txtNote.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtCount
            // 
            this.txtCount.DatabaseFieldLink = null;
            this.txtCount.Location = new System.Drawing.Point(105, 45);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(75, 20);
            this.txtCount.TabIndex = 5;
            this.txtCount.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtCount.Visible = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(6, 48);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(36, 13);
            this.lblNote.TabIndex = 6;
            this.lblNote.Text = "Note :";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(7, 48);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(57, 13);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "FB Count :";
            this.lblCount.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(867, 43);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grdBatches
            // 
            this.grdBatches.AllowUserToAddRows = false;
            this.grdBatches.AllowUserToDeleteRows = false;
            this.grdBatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bat_Ctrl_Num,
            this.Owner_Key,
            this.Vend_SCAC,
            this.NEW_DTM,
            this.Assigned_Site,
            this.Inv_Cnt,
            this.DataEntry_FB_Cnt,
            this.Batching_FB_Cnt,
            this.Oper_Init,
            this.Rev_Init,
            this.BatchOperator,
            this.Correction});
            this.grdBatches.Location = new System.Drawing.Point(10, 54);
            this.grdBatches.Name = "grdBatches";
            this.grdBatches.RowHeadersVisible = false;
            this.grdBatches.Size = new System.Drawing.Size(932, 276);
            this.grdBatches.TabIndex = 3;
            // 
            // chkBoxAll
            // 
            this.chkBoxAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxAll.AutoSize = true;
            this.chkBoxAll.Location = new System.Drawing.Point(905, 21);
            this.chkBoxAll.Name = "chkBoxAll";
            this.chkBoxAll.Size = new System.Drawing.Size(37, 17);
            this.chkBoxAll.TabIndex = 5;
            this.chkBoxAll.Text = "All";
            this.chkBoxAll.UseVisualStyleBackColor = true;
            this.chkBoxAll.CheckedChanged += new System.EventHandler(this.chkBoxAll_CheckedChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 22);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 6;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(59, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(840, 20);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Bat_Ctrl_Num
            // 
            this.Bat_Ctrl_Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Bat_Ctrl_Num.DataPropertyName = "Bat_Ctrl_Num";
            this.Bat_Ctrl_Num.HeaderText = "Bat_Ctrl_Num";
            this.Bat_Ctrl_Num.MinimumWidth = 80;
            this.Bat_Ctrl_Num.Name = "Bat_Ctrl_Num";
            this.Bat_Ctrl_Num.ReadOnly = true;
            // 
            // Owner_Key
            // 
            this.Owner_Key.DataPropertyName = "Owner_Key";
            this.Owner_Key.HeaderText = "Owner_Key";
            this.Owner_Key.Name = "Owner_Key";
            this.Owner_Key.ReadOnly = true;
            // 
            // Vend_SCAC
            // 
            this.Vend_SCAC.DataPropertyName = "Vend_SCAC";
            this.Vend_SCAC.HeaderText = "Vend_SCAC";
            this.Vend_SCAC.Name = "Vend_SCAC";
            this.Vend_SCAC.ReadOnly = true;
            // 
            // NEW_DTM
            // 
            this.NEW_DTM.DataPropertyName = "NEW_DTM";
            this.NEW_DTM.HeaderText = "NEW_DTM";
            this.NEW_DTM.Name = "NEW_DTM";
            this.NEW_DTM.ReadOnly = true;
            // 
            // Assigned_Site
            // 
            this.Assigned_Site.DataPropertyName = "Assigned_Site";
            this.Assigned_Site.HeaderText = "Assigned_Site";
            this.Assigned_Site.Name = "Assigned_Site";
            this.Assigned_Site.ReadOnly = true;
            // 
            // Inv_Cnt
            // 
            this.Inv_Cnt.DataPropertyName = "Inv_Cnt";
            this.Inv_Cnt.HeaderText = "Inv_Cnt";
            this.Inv_Cnt.Name = "Inv_Cnt";
            this.Inv_Cnt.ReadOnly = true;
            // 
            // DataEntry_FB_Cnt
            // 
            this.DataEntry_FB_Cnt.DataPropertyName = "DataEntry_FB_Cnt";
            this.DataEntry_FB_Cnt.HeaderText = "DataEntry_FB_Cnt";
            this.DataEntry_FB_Cnt.Name = "DataEntry_FB_Cnt";
            this.DataEntry_FB_Cnt.ReadOnly = true;
            // 
            // Batching_FB_Cnt
            // 
            this.Batching_FB_Cnt.DataPropertyName = "Batching_FB_Cnt";
            this.Batching_FB_Cnt.HeaderText = "Batching_FB_Cnt";
            this.Batching_FB_Cnt.Name = "Batching_FB_Cnt";
            this.Batching_FB_Cnt.ReadOnly = true;
            // 
            // Oper_Init
            // 
            this.Oper_Init.DataPropertyName = "Oper_Init";
            this.Oper_Init.HeaderText = "Oper_Init";
            this.Oper_Init.Name = "Oper_Init";
            this.Oper_Init.ReadOnly = true;
            // 
            // Rev_Init
            // 
            this.Rev_Init.DataPropertyName = "Rev_Init";
            this.Rev_Init.HeaderText = "Rev_Init";
            this.Rev_Init.Name = "Rev_Init";
            this.Rev_Init.ReadOnly = true;
            // 
            // BatchOperator
            // 
            this.BatchOperator.DataPropertyName = "BatchOperator";
            this.BatchOperator.HeaderText = "BatchOperator";
            this.BatchOperator.Name = "BatchOperator";
            this.BatchOperator.ReadOnly = true;
            // 
            // Correction
            // 
            this.Correction.DataPropertyName = "Correction";
            this.Correction.HeaderText = "Correction";
            this.Correction.Name = "Correction";
            // 
            // frmFBCountCorrection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 462);
            this.Controls.Add(this.grpBoxCorrectField);
            this.Controls.Add(this.grpBoxBatch);
            this.Name = "frmFBCountCorrection";
            this.Text = "FB Count Correction";
            this.Load += new System.EventHandler(this.frmFBCountCorrection_Load);
            this.grpBoxBatch.ResumeLayout(false);
            this.grpBoxBatch.PerformLayout();
            this.grpBoxCorrectField.ResumeLayout(false);
            this.grpBoxCorrectField.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxBatch;
        private System.Windows.Forms.GroupBox grpBoxCorrectField;
        private FormControls.TraxDETextBox txtCount;
        private FormControls.TraxDETextBox txtNote;
        private System.Windows.Forms.RadioButton radioBtnDE;
        private System.Windows.Forms.RadioButton radioBtnNone;
        private System.Windows.Forms.RadioButton radioBtnBatching;
        private FormControls.TraxDELabel lblCount;
        private FormControls.TraxDELabel lblNote;
        private System.Windows.Forms.Button btnOK;
        private FormControls.TraxDEDataGridView grdBatches;
        private System.Windows.Forms.CheckBox chkBoxAll;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDETextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bat_Ctrl_Num;
        private FormControls.TraxDEDataGridViewTextBoxColumn Owner_Key;
        private FormControls.TraxDEDataGridViewTextBoxColumn Vend_SCAC;
        private FormControls.TraxDEDataGridViewTextBoxColumn NEW_DTM;
        private FormControls.TraxDEDataGridViewTextBoxColumn Assigned_Site;
        private FormControls.TraxDEDataGridViewTextBoxColumn Inv_Cnt;
        private FormControls.TraxDEDataGridViewTextBoxColumn DataEntry_FB_Cnt;
        private FormControls.TraxDEDataGridViewTextBoxColumn Batching_FB_Cnt;
        private FormControls.TraxDEDataGridViewTextBoxColumn Oper_Init;
        private FormControls.TraxDEDataGridViewTextBoxColumn Rev_Init;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchOperator;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Correction;
    }
}