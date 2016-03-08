namespace DEAppWS
{
    partial class frmInvoiceManifest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceManifest));
            this.grpBoxDetail = new System.Windows.Forms.GroupBox();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grdDetail = new FormControls.TraxDEDataGridView();
            this.InvManIDKey = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.InvManID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.ImgDocID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Language = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TrackingNum = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Inv_Key = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.ImgPageNo = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Client = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Carrier = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.UserId = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.LastUpdate = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Status = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Comments = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.ofdOpenImageFile = new System.Windows.Forms.OpenFileDialog();
            this.txtFilePathName = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.grpBoxList = new System.Windows.Forms.GroupBox();
            this.ddlProcDate = new FormControls.TraxDEComboBox();
            this.grpBoxDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxDetail.Controls.Add(this.btnComplete);
            this.grpBoxDetail.Controls.Add(this.btnDelete);
            this.grpBoxDetail.Controls.Add(this.btnAdd);
            this.grpBoxDetail.Controls.Add(this.grdDetail);
            this.grpBoxDetail.Location = new System.Drawing.Point(12, 86);
            this.grpBoxDetail.Name = "grpBoxDetail";
            this.grpBoxDetail.Size = new System.Drawing.Size(1109, 529);
            this.grpBoxDetail.TabIndex = 1;
            this.grpBoxDetail.TabStop = false;
            this.grpBoxDetail.Text = "Details";
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(140, 19);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(75, 23);
            this.btnComplete.TabIndex = 25;
            this.btnComplete.Text = "C&omplete";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(73, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdDetail
            // 
            this.grdDetail.AllowUserToAddRows = false;
            this.grdDetail.AllowUserToDeleteRows = false;
            this.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvManIDKey,
            this.InvManID,
            this.ImgDocID,
            this.Language,
            this.TrackingNum,
            this.Inv_Key,
            this.ImgPageNo,
            this.Client,
            this.Carrier,
            this.UserId,
            this.LastUpdate,
            this.Status,
            this.Comments});
            this.grdDetail.Location = new System.Drawing.Point(6, 48);
            this.grdDetail.MultiSelect = false;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.RowHeadersVisible = false;
            this.grdDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDetail.Size = new System.Drawing.Size(1095, 475);
            this.grdDetail.StandardTab = true;
            this.grdDetail.TabIndex = 8;
            this.grdDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDetail_CellValueChanged);
            // 
            // InvManIDKey
            // 
            this.InvManIDKey.DataPropertyName = "InvManIDKey";
            this.InvManIDKey.HeaderText = "InvManIDKey";
            this.InvManIDKey.Name = "InvManIDKey";
            this.InvManIDKey.Visible = false;
            // 
            // InvManID
            // 
            this.InvManID.DataPropertyName = "InvManID";
            this.InvManID.HeaderText = "InvManID";
            this.InvManID.Name = "InvManID";
            // 
            // ImgDocID
            // 
            this.ImgDocID.DataPropertyName = "ImgDocID";
            this.ImgDocID.HeaderText = "ImgDocID";
            this.ImgDocID.Name = "ImgDocID";
            // 
            // Language
            // 
            this.Language.DataPropertyName = "Language";
            this.Language.HeaderText = "Language";
            this.Language.MinimumWidth = 100;
            this.Language.Name = "Language";
            this.Language.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Language.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Language.Width = 215;
            // 
            // TrackingNum
            // 
            this.TrackingNum.DataPropertyName = "TrackingNum";
            this.TrackingNum.HeaderText = "TrackingNum";
            this.TrackingNum.MaxInputLength = 40;
            this.TrackingNum.Name = "TrackingNum";
            this.TrackingNum.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Inv_Key
            // 
            this.Inv_Key.DataPropertyName = "Inv_Key";
            this.Inv_Key.HeaderText = "Inv_Key";
            this.Inv_Key.MaxInputLength = 50;
            this.Inv_Key.Name = "Inv_Key";
            // 
            // ImgPageNo
            // 
            this.ImgPageNo.DataPropertyName = "ImgPageNo";
            this.ImgPageNo.HeaderText = "ImgPageNo";
            this.ImgPageNo.Name = "ImgPageNo";
            this.ImgPageNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ImgPageNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Client.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Carrier
            // 
            this.Carrier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Carrier.DataPropertyName = "Carrier";
            this.Carrier.HeaderText = "Carrier";
            this.Carrier.MaxInputLength = 50;
            this.Carrier.MinimumWidth = 150;
            this.Carrier.Name = "Carrier";
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.Visible = false;
            // 
            // LastUpdate
            // 
            this.LastUpdate.DataPropertyName = "LastUpdate";
            this.LastUpdate.HeaderText = "LastUpdate";
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.Visible = false;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Visible = false;
            // 
            // Comments
            // 
            this.Comments.DataPropertyName = "Comments";
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            this.Comments.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonEdit,
            this.toolStripSeparator1,
            this.toolStripButtonSave,
            this.toolStripButtonCancel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1133, 25);
            this.toolStrip.TabIndex = 2;
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(32, 22);
            this.toolStripButtonNew.Text = "&New";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEdit.Image")));
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(29, 22);
            this.toolStripButtonEdit.Text = "&Edit";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonSave.Text = "&Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(43, 22);
            this.toolStripButtonCancel.Text = "&Cancel";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // ofdOpenImageFile
            // 
            this.ofdOpenImageFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenImageFile_FileOk);
            // 
            // txtFilePathName
            // 
            this.txtFilePathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePathName.Location = new System.Drawing.Point(87, 21);
            this.txtFilePathName.Name = "txtFilePathName";
            this.txtFilePathName.ReadOnly = true;
            this.txtFilePathName.Size = new System.Drawing.Size(461, 20);
            this.txtFilePathName.TabIndex = 26;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 19);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 27;
            this.btnOpenFile.Text = "Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // grpBoxList
            // 
            this.grpBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxList.Controls.Add(this.ddlProcDate);
            this.grpBoxList.Controls.Add(this.txtFilePathName);
            this.grpBoxList.Controls.Add(this.btnOpenFile);
            this.grpBoxList.Location = new System.Drawing.Point(12, 28);
            this.grpBoxList.Name = "grpBoxList";
            this.grpBoxList.Size = new System.Drawing.Size(1109, 52);
            this.grpBoxList.TabIndex = 28;
            this.grpBoxList.TabStop = false;
            this.grpBoxList.Text = "Image";
            // 
            // ddlProcDate
            // 
            this.ddlProcDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlProcDate.DatabaseFieldLink = null;
            this.ddlProcDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlProcDate.FormattingEnabled = true;
            this.ddlProcDate.Location = new System.Drawing.Point(711, 21);
            this.ddlProcDate.Name = "ddlProcDate";
            this.ddlProcDate.Size = new System.Drawing.Size(121, 21);
            this.ddlProcDate.TabIndex = 28;
            this.ddlProcDate.SelectedIndexChanged += new System.EventHandler(this.ddlProcDate_SelectedIndexChanged);
            // 
            // frmInvoiceManifest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 627);
            this.Controls.Add(this.grpBoxList);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.grpBoxDetail);
            this.MinimumSize = new System.Drawing.Size(896, 446);
            this.Name = "frmInvoiceManifest";
            this.Text = "Invoice Manifest";
            this.Enter += new System.EventHandler(this.frmInvoiceManifest_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInvoiceManifest_FormClosing);
            this.grpBoxDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.grpBoxList.ResumeLayout(false);
            this.grpBoxList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxDetail;
        protected FormControls.TraxDEDataGridView grdDetail;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog ofdOpenImageFile;
        private System.Windows.Forms.TextBox txtFilePathName;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.GroupBox grpBoxList;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private FormControls.TraxDEComboBox ddlProcDate;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvManIDKey;
        private FormControls.TraxDEDataGridViewTextBoxColumn InvManID;
        private FormControls.TraxDEDataGridViewTextBoxColumn ImgDocID;
        private System.Windows.Forms.DataGridViewComboBoxColumn Language;
        private FormControls.TraxDEDataGridViewTextBoxColumn TrackingNum;
        private FormControls.TraxDEDataGridViewTextBoxColumn Inv_Key;
        private System.Windows.Forms.DataGridViewComboBoxColumn ImgPageNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn Client;
        private FormControls.TraxDEDataGridViewTextBoxColumn Carrier;
        private FormControls.TraxDEDataGridViewTextBoxColumn UserId;
        private FormControls.TraxDEDataGridViewTextBoxColumn LastUpdate;
        private FormControls.TraxDEDataGridViewTextBoxColumn Status;
        private FormControls.TraxDEDataGridViewTextBoxColumn Comments;
    }
}