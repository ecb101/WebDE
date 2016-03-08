namespace DEAppWS
{
    partial class frmUserMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserMaster));
            this.txtUserID = new FormControls.TraxDETextBox();
            this.txtUserPassword = new FormControls.TraxDETextBox();
            this.txtUserLastName = new FormControls.TraxDETextBox();
            this.txtUserInitials = new FormControls.TraxDETextBox();
            this.txtSiteID = new FormControls.TraxDETextBox();
            this.ddlUserType = new FormControls.TraxDEComboBox();
            this.lblUserID = new FormControls.TraxDELabel();
            this.lblUserName = new FormControls.TraxDELabel();
            this.lblUserPassword = new FormControls.TraxDELabel();
            this.lblUserInitials = new FormControls.TraxDELabel();
            this.lblSiteID = new FormControls.TraxDELabel();
            this.lblUserType = new FormControls.TraxDELabel();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.grdDetail = new FormControls.TraxDEDataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.txtUserFirstName = new FormControls.TraxDETextBox();
            this.traxDELabel2 = new FormControls.TraxDELabel();
            this.txtUserMiddleName = new FormControls.TraxDETextBox();
            this.UserGroupID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.UserID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.SiteID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.UserGroupDescription = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Mode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Client = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.SCAC = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.DocumentType = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Language = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.traxDELabel2);
            this.grpBoxDetail.Controls.Add(this.txtUserMiddleName);
            this.grpBoxDetail.Controls.Add(this.traxDELabel1);
            this.grpBoxDetail.Controls.Add(this.txtUserFirstName);
            this.grpBoxDetail.Controls.Add(this.btnDelete);
            this.grpBoxDetail.Controls.Add(this.btnAdd);
            this.grpBoxDetail.Controls.Add(this.grdDetail);
            this.grpBoxDetail.Controls.Add(this.btnResetPassword);
            this.grpBoxDetail.Controls.Add(this.lblUserType);
            this.grpBoxDetail.Controls.Add(this.lblSiteID);
            this.grpBoxDetail.Controls.Add(this.lblUserInitials);
            this.grpBoxDetail.Controls.Add(this.lblUserPassword);
            this.grpBoxDetail.Controls.Add(this.lblUserName);
            this.grpBoxDetail.Controls.Add(this.lblUserID);
            this.grpBoxDetail.Controls.Add(this.ddlUserType);
            this.grpBoxDetail.Controls.Add(this.txtSiteID);
            this.grpBoxDetail.Controls.Add(this.txtUserInitials);
            this.grpBoxDetail.Controls.Add(this.txtUserLastName);
            this.grpBoxDetail.Controls.Add(this.txtUserPassword);
            this.grpBoxDetail.Controls.Add(this.txtUserID);
            this.grpBoxDetail.Location = new System.Drawing.Point(604, 28);
            this.grpBoxDetail.Size = new System.Drawing.Size(582, 497);
            // 
            // grpBoxList
            // 
            this.grpBoxList.Size = new System.Drawing.Size(586, 497);
            // 
            // txtSearch
            // 
            this.txtSearch.Size = new System.Drawing.Size(521, 20);
            // 
            // panelGrid
            // 
            this.panelGrid.Size = new System.Drawing.Size(574, 452);
            // 
            // txtUserID
            // 
            this.txtUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserID.DatabaseFieldLink = "UserID";
            this.txtUserID.Location = new System.Drawing.Point(111, 13);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 20);
            this.txtUserID.TabIndex = 0;
            this.txtUserID.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.DatabaseFieldLink = "UserPassword";
            this.txtUserPassword.Location = new System.Drawing.Point(111, 143);
            this.txtUserPassword.MaxLength = 20;
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(275, 20);
            this.txtUserPassword.TabIndex = 5;
            this.txtUserPassword.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtUserLastName
            // 
            this.txtUserLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserLastName.DatabaseFieldLink = "UserLastName";
            this.txtUserLastName.Location = new System.Drawing.Point(111, 39);
            this.txtUserLastName.MaxLength = 50;
            this.txtUserLastName.Name = "txtUserLastName";
            this.txtUserLastName.Size = new System.Drawing.Size(275, 20);
            this.txtUserLastName.TabIndex = 1;
            this.txtUserLastName.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtUserInitials
            // 
            this.txtUserInitials.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserInitials.DatabaseFieldLink = "UserInitials";
            this.txtUserInitials.Location = new System.Drawing.Point(111, 117);
            this.txtUserInitials.MaxLength = 3;
            this.txtUserInitials.Name = "txtUserInitials";
            this.txtUserInitials.Size = new System.Drawing.Size(50, 20);
            this.txtUserInitials.TabIndex = 4;
            this.txtUserInitials.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtSiteID
            // 
            this.txtSiteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSiteID.DatabaseFieldLink = "SiteID";
            this.txtSiteID.Location = new System.Drawing.Point(111, 169);
            this.txtSiteID.MaxLength = 1;
            this.txtSiteID.Name = "txtSiteID";
            this.txtSiteID.Size = new System.Drawing.Size(50, 20);
            this.txtSiteID.TabIndex = 6;
            this.txtSiteID.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // ddlUserType
            // 
            this.ddlUserType.DatabaseFieldLink = "UserType";
            this.ddlUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUserType.FormattingEnabled = true;
            this.ddlUserType.Items.AddRange(new object[] {
            "ADMIN",
            "USER",
            "POWER USER"});
            this.ddlUserType.Location = new System.Drawing.Point(111, 196);
            this.ddlUserType.Name = "ddlUserType";
            this.ddlUserType.Size = new System.Drawing.Size(121, 21);
            this.ddlUserType.TabIndex = 7;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Location = new System.Drawing.Point(6, 16);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(49, 13);
            this.lblUserID.TabIndex = 6;
            this.lblUserID.Text = "User ID :";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(6, 42);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(64, 13);
            this.lblUserName.TabIndex = 7;
            this.lblUserName.Text = "Last Name :";
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(6, 146);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(59, 13);
            this.lblUserPassword.TabIndex = 8;
            this.lblUserPassword.Text = "Password :";
            // 
            // lblUserInitials
            // 
            this.lblUserInitials.AutoSize = true;
            this.lblUserInitials.Location = new System.Drawing.Point(6, 120);
            this.lblUserInitials.Name = "lblUserInitials";
            this.lblUserInitials.Size = new System.Drawing.Size(42, 13);
            this.lblUserInitials.TabIndex = 9;
            this.lblUserInitials.Text = "Initials :";
            // 
            // lblSiteID
            // 
            this.lblSiteID.AutoSize = true;
            this.lblSiteID.Location = new System.Drawing.Point(6, 172);
            this.lblSiteID.Name = "lblSiteID";
            this.lblSiteID.Size = new System.Drawing.Size(45, 13);
            this.lblSiteID.TabIndex = 10;
            this.lblSiteID.Text = "Site ID :";
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.Location = new System.Drawing.Point(6, 199);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(62, 13);
            this.lblUserType.TabIndex = 11;
            this.lblUserType.Text = "User Type :";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(287, 11);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(99, 23);
            this.btnResetPassword.TabIndex = 12;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
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
            this.UserGroupID,
            this.UserID,
            this.SiteID,
            this.UserGroupDescription,
            this.Mode,
            this.Client,
            this.SCAC,
            this.DocumentType,
            this.Language});
            this.grdDetail.Location = new System.Drawing.Point(6, 252);
            this.grdDetail.MultiSelect = false;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ReadOnly = true;
            this.grdDetail.RowHeadersVisible = false;
            this.grdDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDetail.Size = new System.Drawing.Size(570, 236);
            this.grdDetail.StandardTab = true;
            this.grdDetail.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(73, 223);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 223);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.Location = new System.Drawing.Point(6, 68);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(63, 13);
            this.traxDELabel1.TabIndex = 28;
            this.traxDELabel1.Text = "First Name :";
            // 
            // txtUserFirstName
            // 
            this.txtUserFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserFirstName.DatabaseFieldLink = "UserFirstName";
            this.txtUserFirstName.Location = new System.Drawing.Point(111, 65);
            this.txtUserFirstName.MaxLength = 50;
            this.txtUserFirstName.Name = "txtUserFirstName";
            this.txtUserFirstName.Size = new System.Drawing.Size(275, 20);
            this.txtUserFirstName.TabIndex = 2;
            this.txtUserFirstName.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // traxDELabel2
            // 
            this.traxDELabel2.AutoSize = true;
            this.traxDELabel2.Location = new System.Drawing.Point(6, 94);
            this.traxDELabel2.Name = "traxDELabel2";
            this.traxDELabel2.Size = new System.Drawing.Size(75, 13);
            this.traxDELabel2.TabIndex = 30;
            this.traxDELabel2.Text = "Middle Name :";
            // 
            // txtUserMiddleName
            // 
            this.txtUserMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUserMiddleName.DatabaseFieldLink = "UserMiddleName";
            this.txtUserMiddleName.Location = new System.Drawing.Point(111, 91);
            this.txtUserMiddleName.MaxLength = 50;
            this.txtUserMiddleName.Name = "txtUserMiddleName";
            this.txtUserMiddleName.Size = new System.Drawing.Size(275, 20);
            this.txtUserMiddleName.TabIndex = 3;
            this.txtUserMiddleName.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // UserGroupID
            // 
            this.UserGroupID.DataPropertyName = "UserGroupID";
            this.UserGroupID.HeaderText = "GroupID";
            this.UserGroupID.Name = "UserGroupID";
            this.UserGroupID.ReadOnly = true;
            this.UserGroupID.Visible = false;
            // 
            // UserID
            // 
            this.UserID.HeaderText = "UserID";
            this.UserID.Name = "UserID";
            this.UserID.ReadOnly = true;
            this.UserID.Visible = false;
            // 
            // SiteID
            // 
            this.SiteID.HeaderText = "SiteID";
            this.SiteID.Name = "SiteID";
            this.SiteID.ReadOnly = true;
            this.SiteID.Visible = false;
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
            this.SCAC.MinimumWidth = 70;
            this.SCAC.Name = "SCAC";
            this.SCAC.ReadOnly = true;
            this.SCAC.Width = 70;
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
            // frmUserMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 537);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(731, 302);
            this.Name = "frmUserMaster";
            this.Text = "User Master";
            this.Load += new System.EventHandler(this.frmUserMaster_Load);
            this.grpBoxDetail.ResumeLayout(false);
            this.grpBoxDetail.PerformLayout();
            this.grpBoxList.ResumeLayout(false);
            this.grpBoxList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControls.TraxDETextBox txtSiteID;
        private FormControls.TraxDETextBox txtUserInitials;
        private FormControls.TraxDETextBox txtUserLastName;
        private FormControls.TraxDETextBox txtUserPassword;
        private FormControls.TraxDETextBox txtUserID;
        private FormControls.TraxDEComboBox ddlUserType;
        private FormControls.TraxDELabel lblUserID;
        private FormControls.TraxDELabel lblUserType;
        private FormControls.TraxDELabel lblSiteID;
        private FormControls.TraxDELabel lblUserInitials;
        private FormControls.TraxDELabel lblUserPassword;
        private FormControls.TraxDELabel lblUserName;
        private System.Windows.Forms.Button btnResetPassword;
        protected FormControls.TraxDEDataGridView grdDetail;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private FormControls.TraxDELabel traxDELabel2;
        private FormControls.TraxDETextBox txtUserMiddleName;
        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDETextBox txtUserFirstName;
        private FormControls.TraxDEDataGridViewTextBoxColumn UserGroupID;
        private FormControls.TraxDEDataGridViewTextBoxColumn UserID;
        private FormControls.TraxDEDataGridViewTextBoxColumn SiteID;
        private FormControls.TraxDEDataGridViewTextBoxColumn UserGroupDescription;
        private FormControls.TraxDEDataGridViewTextBoxColumn Mode;
        private FormControls.TraxDEDataGridViewTextBoxColumn Client;
        private FormControls.TraxDEDataGridViewTextBoxColumn SCAC;
        private FormControls.TraxDEDataGridViewTextBoxColumn DocumentType;
        private FormControls.TraxDEDataGridViewTextBoxColumn Language;

    }
}