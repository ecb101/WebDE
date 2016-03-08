namespace DEAppWS
{
    partial class frmReBatchList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReBatchList));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.lblSearch = new FormControls.TraxDELabel();
            this.grdBatchList = new FormControls.TraxDEDataGridView();
            this.BatchNumber = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxList = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatchList)).BeginInit();
            this.groupBoxList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(477, 23);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.DatabaseTableLink = null;
            this.txtSearch.FieldHint = null;
            this.txtSearch.Location = new System.Drawing.Point(73, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(403, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.WordWrap = false;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.DatabaseTableLink = null;
            this.lblSearch.Location = new System.Drawing.Point(20, 32);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 4;
            this.lblSearch.Text = "Search :";
            // 
            // grdBatchList
            // 
            this.grdBatchList.AllowUserToAddRows = false;
            this.grdBatchList.AllowUserToDeleteRows = false;
            this.grdBatchList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBatchList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBatchList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchNumber,
            this.FilePath});
            this.grdBatchList.IsQAForm = false;
            this.grdBatchList.Location = new System.Drawing.Point(20, 55);
            this.grdBatchList.MultiSelect = false;
            this.grdBatchList.Name = "grdBatchList";
            this.grdBatchList.QAValidationColumns = ((System.Collections.ArrayList)(resources.GetObject("grdBatchList.QAValidationColumns")));
            this.grdBatchList.ReadOnly = true;
            this.grdBatchList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdBatchList.Size = new System.Drawing.Size(539, 303);
            this.grdBatchList.StandardTab = true;
            this.grdBatchList.TabIndex = 3;
            // 
            // BatchNumber
            // 
            this.BatchNumber.DataPropertyName = "BatchNumber";
            this.BatchNumber.HeaderText = "Batch";
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.ReadOnly = true;
            this.BatchNumber.Width = 50;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Width = 1000;
            // 
            // groupBoxList
            // 
            this.groupBoxList.Controls.Add(this.btnRefresh);
            this.groupBoxList.Location = new System.Drawing.Point(7, 4);
            this.groupBoxList.Name = "groupBoxList";
            this.groupBoxList.Size = new System.Drawing.Size(565, 367);
            this.groupBoxList.TabIndex = 8;
            this.groupBoxList.TabStop = false;
            this.groupBoxList.Text = "Select a Batch";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(401, 380);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(484, 380);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // frmReBatchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 412);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.grdBatchList);
            this.Controls.Add(this.groupBoxList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReBatchList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Re-Batch List";
            this.Load += new System.EventHandler(this.frmReBatchList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBatchList)).EndInit();
            this.groupBoxList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDEDataGridView grdBatchList;
        private System.Windows.Forms.GroupBox groupBoxList;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;


    }
}