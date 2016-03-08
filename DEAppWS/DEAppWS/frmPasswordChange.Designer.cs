namespace DEAppWS
{
    partial class frmPasswordChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPasswordChange));
            this.lblID = new FormControls.TraxDELabel();
            this.lblOldPassword = new FormControls.TraxDELabel();
            this.lblNewPassword = new FormControls.TraxDELabel();
            this.lblConfirmPassword = new FormControls.TraxDELabel();
            this.txtID = new FormControls.TraxDETextBox();
            this.txtOldPassword = new FormControls.TraxDETextBox();
            this.txtNewPassword = new FormControls.TraxDETextBox();
            this.txtConfirmPassword = new FormControls.TraxDETextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEnter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(6, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID :";
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(6, 35);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(75, 13);
            this.lblOldPassword.TabIndex = 1;
            this.lblOldPassword.Text = "Old Password:";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(6, 61);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(81, 13);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "New Password:";
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(6, 87);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(119, 13);
            this.lblConfirmPassword.TabIndex = 3;
            this.lblConfirmPassword.Text = "Confirm New Password:";
            // 
            // txtID
            // 
            this.txtID.DatabaseFieldLink = null;
            this.txtID.Location = new System.Drawing.Point(131, 6);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(213, 20);
            this.txtID.TabIndex = 4;
            this.txtID.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.DatabaseFieldLink = null;
            this.txtOldPassword.Location = new System.Drawing.Point(131, 32);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(213, 20);
            this.txtOldPassword.TabIndex = 5;
            this.txtOldPassword.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.DatabaseFieldLink = null;
            this.txtNewPassword.Location = new System.Drawing.Point(131, 58);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(213, 20);
            this.txtNewPassword.TabIndex = 6;
            this.txtNewPassword.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.DatabaseFieldLink = null;
            this.txtConfirmPassword.Location = new System.Drawing.Point(131, 84);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(213, 20);
            this.txtConfirmPassword.TabIndex = 7;
            this.txtConfirmPassword.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(188, 110);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(269, 110);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 8;
            this.btnEnter.Text = "&OK";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // frmPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 142);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.lblID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(364, 176);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(364, 176);
            this.Name = "frmPasswordChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password Change";
            this.Load += new System.EventHandler(this.frmPasswordChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControls.TraxDELabel lblID;
        private FormControls.TraxDELabel lblOldPassword;
        private FormControls.TraxDELabel lblNewPassword;
        private FormControls.TraxDELabel lblConfirmPassword;
        private FormControls.TraxDETextBox txtID;
        private FormControls.TraxDETextBox txtOldPassword;
        private FormControls.TraxDETextBox txtNewPassword;
        private FormControls.TraxDETextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnEnter;
    }
}