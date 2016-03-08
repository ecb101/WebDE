namespace DEAppWS
{
    partial class frmGroupLookup
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
            this.grdList = new FormControls.TraxDEDataGridView();
            this.UserGroupID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.UserGroupDescription = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Mode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Client = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.SCAC = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.DocumentType = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Language = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.grpBoxSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).BeginInit();
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
            this.grpBoxSelection.Controls.Add(this.grdList);
            this.grpBoxSelection.Location = new System.Drawing.Point(12, 12);
            this.grpBoxSelection.Name = "grpBoxSelection";
            this.grpBoxSelection.Size = new System.Drawing.Size(791, 299);
            this.grpBoxSelection.TabIndex = 2;
            this.grpBoxSelection.TabStop = false;
            this.grpBoxSelection.Text = "Group";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(6, 270);
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
            this.txtSearch.Size = new System.Drawing.Size(723, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grdList
            // 
            this.grdList.AllowUserToAddRows = false;
            this.grdList.AllowUserToDeleteRows = false;
            this.grdList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserGroupID,
            this.UserGroupDescription,
            this.Mode,
            this.Client,
            this.SCAC,
            this.DocumentType,
            this.Language});
            this.grdList.Location = new System.Drawing.Point(6, 45);
            this.grdList.MultiSelect = false;
            this.grdList.Name = "grdList";
            this.grdList.ReadOnly = true;
            this.grdList.RowHeadersVisible = false;
            this.grdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdList.Size = new System.Drawing.Size(779, 219);
            this.grdList.StandardTab = true;
            this.grdList.TabIndex = 2;
            this.grdList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdList_CellDoubleClick);
            this.grdList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdList_KeyDown);
            // 
            // UserGroupID
            // 
            this.UserGroupID.DataPropertyName = "UserGroupID";
            this.UserGroupID.HeaderText = "GroupID";
            this.UserGroupID.Name = "UserGroupID";
            this.UserGroupID.ReadOnly = true;
            this.UserGroupID.Width = 60;
            // 
            // UserGroupDescription
            // 
            this.UserGroupDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserGroupDescription.DataPropertyName = "UserGroupDescription";
            this.UserGroupDescription.HeaderText = "GroupDescription";
            this.UserGroupDescription.Name = "UserGroupDescription";
            this.UserGroupDescription.ReadOnly = true;
            // 
            // Mode
            // 
            this.Mode.DataPropertyName = "Mode";
            this.Mode.HeaderText = "Mode";
            this.Mode.Name = "Mode";
            this.Mode.ReadOnly = true;
            // 
            // Client
            // 
            this.Client.DataPropertyName = "Client";
            this.Client.HeaderText = "Client";
            this.Client.Name = "Client";
            this.Client.ReadOnly = true;
            // 
            // SCAC
            // 
            this.SCAC.DataPropertyName = "SCAC";
            this.SCAC.HeaderText = "SCAC";
            this.SCAC.Name = "SCAC";
            this.SCAC.ReadOnly = true;
            // 
            // DocumentType
            // 
            this.DocumentType.DataPropertyName = "DocumentType";
            this.DocumentType.HeaderText = "DocumentType";
            this.DocumentType.Name = "DocumentType";
            this.DocumentType.ReadOnly = true;
            // 
            // Language
            // 
            this.Language.DataPropertyName = "Language";
            this.Language.HeaderText = "Language";
            this.Language.Name = "Language";
            this.Language.ReadOnly = true;
            // 
            // frmGroupLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 323);
            this.Controls.Add(this.grpBoxSelection);
            this.Name = "frmGroupLookup";
            this.Text = "Group Lookup";
            this.Load += new System.EventHandler(this.frmGroupLookup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGroupLookup_KeyDown);
            this.grpBoxSelection.ResumeLayout(false);
            this.grpBoxSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSelection;
        private System.Windows.Forms.Button btnOK;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDEDataGridView grdList;
        private FormControls.TraxDEDataGridViewTextBoxColumn UserGroupID;
        private FormControls.TraxDEDataGridViewTextBoxColumn UserGroupDescription;
        private FormControls.TraxDEDataGridViewTextBoxColumn Mode;
        private FormControls.TraxDEDataGridViewTextBoxColumn Client;
        private FormControls.TraxDEDataGridViewTextBoxColumn SCAC;
        private FormControls.TraxDEDataGridViewTextBoxColumn DocumentType;
        private FormControls.TraxDEDataGridViewTextBoxColumn Language;
    }
}