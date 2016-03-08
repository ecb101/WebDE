namespace DEAppWS
{
    partial class frmKeyingInstructionsMaster
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
            this.lblOwnerKey = new FormControls.TraxDELabel();
            this.ddlOwnerKey = new FormControls.TraxDEComboBox();
            this.ddlDeScac = new FormControls.TraxDEComboBox();
            this.lblDeScac = new FormControls.TraxDELabel();
            this.lblKeyingInstructions = new FormControls.TraxDELabel();
            this.txtKeyingInstructions = new FormControls.TraxDETextBox();
            this.lblUpdateTimestamp = new FormControls.TraxDELabel();
            this.lblUpdateUsername = new FormControls.TraxDELabel();
            this.lblUpdateMachine = new FormControls.TraxDELabel();
            this.txtUpdateTimestamp = new FormControls.TraxDETextBox();
            this.txtUpdateUsername = new FormControls.TraxDETextBox();
            this.txtUpdateMachine = new FormControls.TraxDETextBox();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.txtUpdateMachine);
            this.grpBoxDetail.Controls.Add(this.txtUpdateUsername);
            this.grpBoxDetail.Controls.Add(this.txtUpdateTimestamp);
            this.grpBoxDetail.Controls.Add(this.lblUpdateMachine);
            this.grpBoxDetail.Controls.Add(this.lblUpdateUsername);
            this.grpBoxDetail.Controls.Add(this.lblUpdateTimestamp);
            this.grpBoxDetail.Controls.Add(this.txtKeyingInstructions);
            this.grpBoxDetail.Controls.Add(this.lblKeyingInstructions);
            this.grpBoxDetail.Controls.Add(this.ddlDeScac);
            this.grpBoxDetail.Controls.Add(this.lblDeScac);
            this.grpBoxDetail.Controls.Add(this.ddlOwnerKey);
            this.grpBoxDetail.Controls.Add(this.lblOwnerKey);
            // 
            // lblOwnerKey
            // 
            this.lblOwnerKey.AutoSize = true;
            this.lblOwnerKey.Location = new System.Drawing.Point(6, 16);
            this.lblOwnerKey.Name = "lblOwnerKey";
            this.lblOwnerKey.Size = new System.Drawing.Size(62, 13);
            this.lblOwnerKey.TabIndex = 0;
            this.lblOwnerKey.Text = "Owner Key:";
            // 
            // ddlOwnerKey
            // 
            this.ddlOwnerKey.DatabaseFieldLink = "OwnerKey";
            this.ddlOwnerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOwnerKey.FormattingEnabled = true;
            this.ddlOwnerKey.Location = new System.Drawing.Point(111, 13);
            this.ddlOwnerKey.Name = "ddlOwnerKey";
            this.ddlOwnerKey.Size = new System.Drawing.Size(121, 21);
            this.ddlOwnerKey.TabIndex = 1;
            this.ddlOwnerKey.SelectedIndexChanged += new System.EventHandler(this.ddlOwnerKey_SelectedIndexChanged);
            // 
            // ddlDeScac
            // 
            this.ddlDeScac.DatabaseFieldLink = "DeScac";
            this.ddlDeScac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDeScac.FormattingEnabled = true;
            this.ddlDeScac.Location = new System.Drawing.Point(111, 39);
            this.ddlDeScac.Name = "ddlDeScac";
            this.ddlDeScac.Size = new System.Drawing.Size(121, 21);
            this.ddlDeScac.TabIndex = 3;
            // 
            // lblDeScac
            // 
            this.lblDeScac.AutoSize = true;
            this.lblDeScac.Location = new System.Drawing.Point(6, 42);
            this.lblDeScac.Name = "lblDeScac";
            this.lblDeScac.Size = new System.Drawing.Size(49, 13);
            this.lblDeScac.TabIndex = 2;
            this.lblDeScac.Text = "DeScac:";
            // 
            // lblKeyingInstructions
            // 
            this.lblKeyingInstructions.AutoSize = true;
            this.lblKeyingInstructions.Location = new System.Drawing.Point(6, 69);
            this.lblKeyingInstructions.Name = "lblKeyingInstructions";
            this.lblKeyingInstructions.Size = new System.Drawing.Size(99, 13);
            this.lblKeyingInstructions.TabIndex = 4;
            this.lblKeyingInstructions.Text = "Keying Instructions:";
            // 
            // txtKeyingInstructions
            // 
            this.txtKeyingInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyingInstructions.DatabaseFieldLink = "KeyingInstructions";
            this.txtKeyingInstructions.Location = new System.Drawing.Point(111, 66);
            this.txtKeyingInstructions.Multiline = true;
            this.txtKeyingInstructions.Name = "txtKeyingInstructions";
            this.txtKeyingInstructions.Size = new System.Drawing.Size(273, 102);
            this.txtKeyingInstructions.TabIndex = 5;
            this.txtKeyingInstructions.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblUpdateTimestamp
            // 
            this.lblUpdateTimestamp.AutoSize = true;
            this.lblUpdateTimestamp.Location = new System.Drawing.Point(6, 177);
            this.lblUpdateTimestamp.Name = "lblUpdateTimestamp";
            this.lblUpdateTimestamp.Size = new System.Drawing.Size(99, 13);
            this.lblUpdateTimestamp.TabIndex = 6;
            this.lblUpdateTimestamp.Text = "Update Timestamp:";
            // 
            // lblUpdateUsername
            // 
            this.lblUpdateUsername.AutoSize = true;
            this.lblUpdateUsername.Location = new System.Drawing.Point(6, 203);
            this.lblUpdateUsername.Name = "lblUpdateUsername";
            this.lblUpdateUsername.Size = new System.Drawing.Size(96, 13);
            this.lblUpdateUsername.TabIndex = 8;
            this.lblUpdateUsername.Text = "Update Username:";
            // 
            // lblUpdateMachine
            // 
            this.lblUpdateMachine.AutoSize = true;
            this.lblUpdateMachine.Location = new System.Drawing.Point(6, 229);
            this.lblUpdateMachine.Name = "lblUpdateMachine";
            this.lblUpdateMachine.Size = new System.Drawing.Size(89, 13);
            this.lblUpdateMachine.TabIndex = 10;
            this.lblUpdateMachine.Text = "Update Machine:";
            // 
            // txtUpdateTimestamp
            // 
            this.txtUpdateTimestamp.DatabaseFieldLink = "UpdateTimestamp";
            this.txtUpdateTimestamp.Location = new System.Drawing.Point(111, 174);
            this.txtUpdateTimestamp.Name = "txtUpdateTimestamp";
            this.txtUpdateTimestamp.Size = new System.Drawing.Size(160, 20);
            this.txtUpdateTimestamp.TabIndex = 11;
            this.txtUpdateTimestamp.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtUpdateUsername
            // 
            this.txtUpdateUsername.DatabaseFieldLink = "UpdateUsername";
            this.txtUpdateUsername.Location = new System.Drawing.Point(111, 200);
            this.txtUpdateUsername.Name = "txtUpdateUsername";
            this.txtUpdateUsername.Size = new System.Drawing.Size(160, 20);
            this.txtUpdateUsername.TabIndex = 11;
            this.txtUpdateUsername.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtUpdateMachine
            // 
            this.txtUpdateMachine.DatabaseFieldLink = "UpdateMachine";
            this.txtUpdateMachine.Location = new System.Drawing.Point(111, 226);
            this.txtUpdateMachine.Name = "txtUpdateMachine";
            this.txtUpdateMachine.Size = new System.Drawing.Size(160, 20);
            this.txtUpdateMachine.TabIndex = 11;
            this.txtUpdateMachine.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // frmKeyingInstructionsMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 491);
            this.Name = "frmKeyingInstructionsMaster";
            this.Text = "KeyingInstructionsMaster";
            this.grpBoxDetail.ResumeLayout(false);
            this.grpBoxDetail.PerformLayout();
            this.grpBoxList.ResumeLayout(false);
            this.grpBoxList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControls.TraxDELabel lblKeyingInstructions;
        private FormControls.TraxDEComboBox ddlDeScac;
        private FormControls.TraxDELabel lblDeScac;
        private FormControls.TraxDEComboBox ddlOwnerKey;
        private FormControls.TraxDELabel lblOwnerKey;
        private FormControls.TraxDELabel lblUpdateMachine;
        private FormControls.TraxDELabel lblUpdateUsername;
        private FormControls.TraxDELabel lblUpdateTimestamp;
        private FormControls.TraxDETextBox txtKeyingInstructions;
        private FormControls.TraxDETextBox txtUpdateMachine;
        private FormControls.TraxDETextBox txtUpdateUsername;
        private FormControls.TraxDETextBox txtUpdateTimestamp;

    }
}