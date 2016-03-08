namespace DEAppWS
{
    partial class frmImageResolution
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBoxList = new System.Windows.Forms.GroupBox();
            this.lblResolutonCode = new FormControls.TraxDELabel();
            this.lblReasonCode = new FormControls.TraxDELabel();
            this.lblAction = new FormControls.TraxDELabel();
            this.lblResolution = new FormControls.TraxDELabel();
            this.lblReasonDescription = new FormControls.TraxDELabel();
            this.lblReason = new FormControls.TraxDELabel();
            this.txtResolutionCode = new FormControls.TraxDETextBox();
            this.txtAction = new FormControls.TraxDETextBox();
            this.ddlResolution = new FormControls.TraxDEComboBox();
            this.txtReasonCode = new FormControls.TraxDETextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtReasonDescription = new FormControls.TraxDETextBox();
            this.ddlReason = new FormControls.TraxDEComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpBoxCategory = new System.Windows.Forms.GroupBox();
            this.radioBtnBatching = new System.Windows.Forms.RadioButton();
            this.radioBtnManifesting = new System.Windows.Forms.RadioButton();
            this.radioBtnReceived = new System.Windows.Forms.RadioButton();
            this.grdImages = new FormControls.TraxDEDataGridView();
            this.ID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FullFolderPath = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.OriginalFileName = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.NewFolderPath = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.NewFileName = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.ProcessedDate = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.ErrorDescription = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.lblSearch = new FormControls.TraxDELabel();
            this.chkBoxCombinedImage = new System.Windows.Forms.CheckBox();
            this.grpBoxList.SuspendLayout();
            this.grpBoxCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImages)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxList
            // 
            this.grpBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxList.Controls.Add(this.lblResolutonCode);
            this.grpBoxList.Controls.Add(this.lblReasonCode);
            this.grpBoxList.Controls.Add(this.lblAction);
            this.grpBoxList.Controls.Add(this.lblResolution);
            this.grpBoxList.Controls.Add(this.lblReasonDescription);
            this.grpBoxList.Controls.Add(this.lblReason);
            this.grpBoxList.Controls.Add(this.txtResolutionCode);
            this.grpBoxList.Controls.Add(this.txtAction);
            this.grpBoxList.Controls.Add(this.ddlResolution);
            this.grpBoxList.Controls.Add(this.txtReasonCode);
            this.grpBoxList.Controls.Add(this.btnOK);
            this.grpBoxList.Controls.Add(this.txtReasonDescription);
            this.grpBoxList.Controls.Add(this.ddlReason);
            this.grpBoxList.Controls.Add(this.btnRefresh);
            this.grpBoxList.Controls.Add(this.grpBoxCategory);
            this.grpBoxList.Controls.Add(this.grdImages);
            this.grpBoxList.Controls.Add(this.txtSearch);
            this.grpBoxList.Controls.Add(this.lblSearch);
            this.grpBoxList.Location = new System.Drawing.Point(12, 12);
            this.grpBoxList.Name = "grpBoxList";
            this.grpBoxList.Size = new System.Drawing.Size(899, 514);
            this.grpBoxList.TabIndex = 3;
            this.grpBoxList.TabStop = false;
            this.grpBoxList.Text = "Image List";
            // 
            // lblResolutonCode
            // 
            this.lblResolutonCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResolutonCode.AutoSize = true;
            this.lblResolutonCode.Location = new System.Drawing.Point(719, 435);
            this.lblResolutonCode.Name = "lblResolutonCode";
            this.lblResolutonCode.Size = new System.Drawing.Size(91, 13);
            this.lblResolutonCode.TabIndex = 24;
            this.lblResolutonCode.Text = "Resolution Code :";
            // 
            // lblReasonCode
            // 
            this.lblReasonCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReasonCode.AutoSize = true;
            this.lblReasonCode.Location = new System.Drawing.Point(719, 383);
            this.lblReasonCode.Name = "lblReasonCode";
            this.lblReasonCode.Size = new System.Drawing.Size(78, 13);
            this.lblReasonCode.TabIndex = 23;
            this.lblReasonCode.Text = "Reason Code :";
            // 
            // lblAction
            // 
            this.lblAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAction.AutoSize = true;
            this.lblAction.Location = new System.Drawing.Point(6, 462);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(43, 13);
            this.lblAction.TabIndex = 22;
            this.lblAction.Text = "Action :";
            // 
            // lblResolution
            // 
            this.lblResolution.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(6, 436);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(63, 13);
            this.lblResolution.TabIndex = 21;
            this.lblResolution.Text = "Resolution :";
            // 
            // lblReasonDescription
            // 
            this.lblReasonDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReasonDescription.AutoSize = true;
            this.lblReasonDescription.Location = new System.Drawing.Point(6, 410);
            this.lblReasonDescription.Name = "lblReasonDescription";
            this.lblReasonDescription.Size = new System.Drawing.Size(106, 13);
            this.lblReasonDescription.TabIndex = 20;
            this.lblReasonDescription.Text = "Reason Description :";
            // 
            // lblReason
            // 
            this.lblReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(6, 384);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 13);
            this.lblReason.TabIndex = 19;
            this.lblReason.Text = "Reason :";
            // 
            // txtResolutionCode
            // 
            this.txtResolutionCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResolutionCode.DatabaseFieldLink = null;
            this.txtResolutionCode.Location = new System.Drawing.Point(816, 433);
            this.txtResolutionCode.Name = "txtResolutionCode";
            this.txtResolutionCode.ReadOnly = true;
            this.txtResolutionCode.Size = new System.Drawing.Size(76, 20);
            this.txtResolutionCode.TabIndex = 18;
            this.txtResolutionCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtResolutionCode.ValueType = CommonLibrary.CommonEnum.ValueType.ALPHA_NUMERIC;
            // 
            // txtAction
            // 
            this.txtAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAction.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAction.DatabaseFieldLink = null;
            this.txtAction.Location = new System.Drawing.Point(118, 459);
            this.txtAction.MaxLength = 100;
            this.txtAction.Name = "txtAction";
            this.txtAction.Size = new System.Drawing.Size(774, 20);
            this.txtAction.TabIndex = 17;
            this.txtAction.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // ddlResolution
            // 
            this.ddlResolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlResolution.DatabaseFieldLink = null;
            this.ddlResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlResolution.FormattingEnabled = true;
            this.ddlResolution.Location = new System.Drawing.Point(118, 432);
            this.ddlResolution.Name = "ddlResolution";
            this.ddlResolution.Size = new System.Drawing.Size(595, 21);
            this.ddlResolution.TabIndex = 16;
            this.ddlResolution.SelectedIndexChanged += new System.EventHandler(this.ddlResolution_SelectedIndexChanged);
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReasonCode.DatabaseFieldLink = null;
            this.txtReasonCode.Location = new System.Drawing.Point(816, 380);
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.ReadOnly = true;
            this.txtReasonCode.Size = new System.Drawing.Size(76, 20);
            this.txtReasonCode.TabIndex = 15;
            this.txtReasonCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReasonCode.ValueType = CommonLibrary.CommonEnum.ValueType.ALPHA_NUMERIC;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(716, 485);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(176, 23);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "Implement Image Resolution";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtReasonDescription
            // 
            this.txtReasonDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReasonDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReasonDescription.DatabaseFieldLink = null;
            this.txtReasonDescription.Location = new System.Drawing.Point(118, 407);
            this.txtReasonDescription.MaxLength = 100;
            this.txtReasonDescription.Name = "txtReasonDescription";
            this.txtReasonDescription.Size = new System.Drawing.Size(774, 20);
            this.txtReasonDescription.TabIndex = 13;
            this.txtReasonDescription.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // ddlReason
            // 
            this.ddlReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlReason.DatabaseFieldLink = null;
            this.ddlReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlReason.FormattingEnabled = true;
            this.ddlReason.Location = new System.Drawing.Point(118, 380);
            this.ddlReason.Name = "ddlReason";
            this.ddlReason.Size = new System.Drawing.Size(595, 21);
            this.ddlReason.TabIndex = 12;
            this.ddlReason.SelectedIndexChanged += new System.EventHandler(this.ddlReason_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(6, 72);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpBoxCategory
            // 
            this.grpBoxCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCategory.Controls.Add(this.chkBoxCombinedImage);
            this.grpBoxCategory.Controls.Add(this.radioBtnBatching);
            this.grpBoxCategory.Controls.Add(this.radioBtnManifesting);
            this.grpBoxCategory.Controls.Add(this.radioBtnReceived);
            this.grpBoxCategory.Location = new System.Drawing.Point(6, 19);
            this.grpBoxCategory.Name = "grpBoxCategory";
            this.grpBoxCategory.Size = new System.Drawing.Size(887, 47);
            this.grpBoxCategory.TabIndex = 10;
            this.grpBoxCategory.TabStop = false;
            this.grpBoxCategory.Text = "Category";
            // 
            // radioBtnBatching
            // 
            this.radioBtnBatching.AutoSize = true;
            this.radioBtnBatching.Location = new System.Drawing.Point(292, 19);
            this.radioBtnBatching.Name = "radioBtnBatching";
            this.radioBtnBatching.Size = new System.Drawing.Size(129, 17);
            this.radioBtnBatching.TabIndex = 2;
            this.radioBtnBatching.Text = "Error Batching Images";
            this.radioBtnBatching.UseVisualStyleBackColor = true;
            this.radioBtnBatching.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // radioBtnManifesting
            // 
            this.radioBtnManifesting.AutoSize = true;
            this.radioBtnManifesting.Location = new System.Drawing.Point(145, 19);
            this.radioBtnManifesting.Name = "radioBtnManifesting";
            this.radioBtnManifesting.Size = new System.Drawing.Size(141, 17);
            this.radioBtnManifesting.TabIndex = 1;
            this.radioBtnManifesting.Text = "Error Manifesting Images";
            this.radioBtnManifesting.UseVisualStyleBackColor = true;
            this.radioBtnManifesting.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // radioBtnReceived
            // 
            this.radioBtnReceived.AutoSize = true;
            this.radioBtnReceived.Checked = true;
            this.radioBtnReceived.Location = new System.Drawing.Point(6, 19);
            this.radioBtnReceived.Name = "radioBtnReceived";
            this.radioBtnReceived.Size = new System.Drawing.Size(133, 17);
            this.radioBtnReceived.TabIndex = 0;
            this.radioBtnReceived.TabStop = true;
            this.radioBtnReceived.Text = "Received Error Images";
            this.radioBtnReceived.UseVisualStyleBackColor = true;
            this.radioBtnReceived.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // grdImages
            // 
            this.grdImages.AllowUserToAddRows = false;
            this.grdImages.AllowUserToDeleteRows = false;
            this.grdImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FullFolderPath,
            this.OriginalFileName,
            this.NewFolderPath,
            this.NewFileName,
            this.ProcessedDate,
            this.ErrorDescription});
            this.grdImages.Location = new System.Drawing.Point(6, 101);
            this.grdImages.MultiSelect = false;
            this.grdImages.Name = "grdImages";
            this.grdImages.ReadOnly = true;
            this.grdImages.RowHeadersVisible = false;
            this.grdImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdImages.Size = new System.Drawing.Size(887, 273);
            this.grdImages.StandardTab = true;
            this.grdImages.TabIndex = 7;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 80;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // FullFolderPath
            // 
            this.FullFolderPath.DataPropertyName = "FullFolderPath";
            this.FullFolderPath.HeaderText = "FullFolderPath";
            this.FullFolderPath.MinimumWidth = 300;
            this.FullFolderPath.Name = "FullFolderPath";
            this.FullFolderPath.ReadOnly = true;
            this.FullFolderPath.Width = 301;
            // 
            // OriginalFileName
            // 
            this.OriginalFileName.DataPropertyName = "OriginalFileName";
            this.OriginalFileName.HeaderText = "OriginalFileName";
            this.OriginalFileName.MinimumWidth = 80;
            this.OriginalFileName.Name = "OriginalFileName";
            this.OriginalFileName.ReadOnly = true;
            // 
            // NewFolderPath
            // 
            this.NewFolderPath.DataPropertyName = "NewFolderPath";
            this.NewFolderPath.HeaderText = "NewFolderPath";
            this.NewFolderPath.MinimumWidth = 300;
            this.NewFolderPath.Name = "NewFolderPath";
            this.NewFolderPath.ReadOnly = true;
            this.NewFolderPath.Width = 300;
            // 
            // NewFileName
            // 
            this.NewFileName.DataPropertyName = "NewFileName";
            this.NewFileName.HeaderText = "NewFileName";
            this.NewFileName.MinimumWidth = 100;
            this.NewFileName.Name = "NewFileName";
            this.NewFileName.ReadOnly = true;
            // 
            // ProcessedDate
            // 
            this.ProcessedDate.DataPropertyName = "ProcessedDate";
            dataGridViewCellStyle3.Format = "G";
            dataGridViewCellStyle3.NullValue = null;
            this.ProcessedDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.ProcessedDate.HeaderText = "ProcessedDate";
            this.ProcessedDate.MinimumWidth = 80;
            this.ProcessedDate.Name = "ProcessedDate";
            this.ProcessedDate.ReadOnly = true;
            // 
            // ErrorDescription
            // 
            this.ErrorDescription.DataPropertyName = "ErrorDescription";
            this.ErrorDescription.HeaderText = "ErrorDescription";
            this.ErrorDescription.MinimumWidth = 100;
            this.ErrorDescription.Name = "ErrorDescription";
            this.ErrorDescription.ReadOnly = true;
            this.ErrorDescription.Width = 150;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(140, 74);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(753, 20);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(87, 77);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Search :";
            // 
            // chkBoxCombinedImage
            // 
            this.chkBoxCombinedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxCombinedImage.AutoSize = true;
            this.chkBoxCombinedImage.Location = new System.Drawing.Point(776, 20);
            this.chkBoxCombinedImage.Name = "chkBoxCombinedImage";
            this.chkBoxCombinedImage.Size = new System.Drawing.Size(105, 17);
            this.chkBoxCombinedImage.TabIndex = 3;
            this.chkBoxCombinedImage.Text = "Combined Image";
            this.chkBoxCombinedImage.UseVisualStyleBackColor = true;
            this.chkBoxCombinedImage.CheckedChanged += new System.EventHandler(this.chkBoxCombinedImage_CheckedChanged);
            // 
            // frmImageResolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 538);
            this.Controls.Add(this.grpBoxList);
            this.Name = "frmImageResolution";
            this.Text = "Image Resolution";
            this.Load += new System.EventHandler(this.frmImageResolution_Load);
            this.grpBoxList.ResumeLayout(false);
            this.grpBoxList.PerformLayout();
            this.grpBoxCategory.ResumeLayout(false);
            this.grpBoxCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxList;
        protected FormControls.TraxDEDataGridView grdImages;
        protected FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDELabel lblSearch;
        private System.Windows.Forms.GroupBox grpBoxCategory;
        private System.Windows.Forms.RadioButton radioBtnManifesting;
        private System.Windows.Forms.RadioButton radioBtnReceived;
        private System.Windows.Forms.RadioButton radioBtnBatching;
        private System.Windows.Forms.Button btnRefresh;
        private FormControls.TraxDETextBox txtReasonDescription;
        private FormControls.TraxDEComboBox ddlReason;
        private System.Windows.Forms.Button btnOK;
        private FormControls.TraxDETextBox txtReasonCode;
        private FormControls.TraxDETextBox txtResolutionCode;
        private FormControls.TraxDETextBox txtAction;
        private FormControls.TraxDEComboBox ddlResolution;
        private FormControls.TraxDELabel lblAction;
        private FormControls.TraxDELabel lblResolution;
        private FormControls.TraxDELabel lblReasonDescription;
        private FormControls.TraxDELabel lblReason;
        private FormControls.TraxDEDataGridViewTextBoxColumn ID;
        private FormControls.TraxDEDataGridViewTextBoxColumn FullFolderPath;
        private FormControls.TraxDEDataGridViewTextBoxColumn OriginalFileName;
        private FormControls.TraxDEDataGridViewTextBoxColumn NewFolderPath;
        private FormControls.TraxDEDataGridViewTextBoxColumn NewFileName;
        private FormControls.TraxDEDataGridViewTextBoxColumn ProcessedDate;
        private FormControls.TraxDEDataGridViewTextBoxColumn ErrorDescription;
        private FormControls.TraxDELabel lblResolutonCode;
        private FormControls.TraxDELabel lblReasonCode;
        private System.Windows.Forms.CheckBox chkBoxCombinedImage;
    }
}