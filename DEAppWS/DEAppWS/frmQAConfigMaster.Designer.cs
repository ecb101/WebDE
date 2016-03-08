namespace DEAppWS
{
    partial class frmQAConfigMaster
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
            this.ddlVendSCAC = new FormControls.TraxDEComboBox();
            this.lblVendSCAC = new FormControls.TraxDELabel();
            this.chkInvAmt = new FormControls.TraxDECheckBox();
            this.chkAcctNumVendBlng = new FormControls.TraxDECheckBox();
            this.chkInvCreatDtm = new FormControls.TraxDECheckBox();
            this.chkFbAmt = new FormControls.TraxDECheckBox();
            this.chkFbCreatDtm = new FormControls.TraxDECheckBox();
            this.lblFBFullQAPercent = new FormControls.TraxDELabel();
            this.txtFBFullQAPercent = new FormControls.TraxDETextBox();
            this.chkFbPaymtTermsCode = new FormControls.TraxDECheckBox();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.chkFbPaymtTermsCode);
            this.grpBoxDetail.Controls.Add(this.txtFBFullQAPercent);
            this.grpBoxDetail.Controls.Add(this.lblFBFullQAPercent);
            this.grpBoxDetail.Controls.Add(this.chkFbCreatDtm);
            this.grpBoxDetail.Controls.Add(this.chkFbAmt);
            this.grpBoxDetail.Controls.Add(this.chkInvCreatDtm);
            this.grpBoxDetail.Controls.Add(this.chkAcctNumVendBlng);
            this.grpBoxDetail.Controls.Add(this.chkInvAmt);
            this.grpBoxDetail.Controls.Add(this.ddlVendSCAC);
            this.grpBoxDetail.Controls.Add(this.lblVendSCAC);
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
            this.ddlOwnerKey.DatabaseFieldLink = "Owner_Key";
            this.ddlOwnerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOwnerKey.Enabled = false;
            this.ddlOwnerKey.FormattingEnabled = true;
            this.ddlOwnerKey.Location = new System.Drawing.Point(112, 12);
            this.ddlOwnerKey.Name = "ddlOwnerKey";
            this.ddlOwnerKey.Size = new System.Drawing.Size(121, 21);
            this.ddlOwnerKey.TabIndex = 1;
            this.ddlOwnerKey.SelectedIndexChanged += new System.EventHandler(this.ddlOwnerKey_SelectedIndexChanged);
            // 
            // ddlVendSCAC
            // 
            this.ddlVendSCAC.DatabaseFieldLink = "Vend_SCAC";
            this.ddlVendSCAC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlVendSCAC.Enabled = false;
            this.ddlVendSCAC.FormattingEnabled = true;
            this.ddlVendSCAC.Location = new System.Drawing.Point(112, 40);
            this.ddlVendSCAC.Name = "ddlVendSCAC";
            this.ddlVendSCAC.Size = new System.Drawing.Size(121, 21);
            this.ddlVendSCAC.TabIndex = 3;
            // 
            // lblVendSCAC
            // 
            this.lblVendSCAC.AutoSize = true;
            this.lblVendSCAC.Location = new System.Drawing.Point(6, 43);
            this.lblVendSCAC.Name = "lblVendSCAC";
            this.lblVendSCAC.Size = new System.Drawing.Size(66, 13);
            this.lblVendSCAC.TabIndex = 2;
            this.lblVendSCAC.Text = "Vend SCAC:";
            // 
            // chkInvAmt
            // 
            this.chkInvAmt.AutoSize = true;
            this.chkInvAmt.DatabaseFieldLink = "InvAmt";
            this.chkInvAmt.Location = new System.Drawing.Point(4, 67);
            this.chkInvAmt.Name = "chkInvAmt";
            this.chkInvAmt.Size = new System.Drawing.Size(59, 17);
            this.chkInvAmt.TabIndex = 4;
            this.chkInvAmt.Text = "InvAmt";
            this.chkInvAmt.UseVisualStyleBackColor = true;
            // 
            // chkAcctNumVendBlng
            // 
            this.chkAcctNumVendBlng.AutoSize = true;
            this.chkAcctNumVendBlng.DatabaseFieldLink = "AcctNumVendBlng";
            this.chkAcctNumVendBlng.Location = new System.Drawing.Point(4, 90);
            this.chkAcctNumVendBlng.Name = "chkAcctNumVendBlng";
            this.chkAcctNumVendBlng.Size = new System.Drawing.Size(116, 17);
            this.chkAcctNumVendBlng.TabIndex = 5;
            this.chkAcctNumVendBlng.Text = "AcctNumVendBlng";
            this.chkAcctNumVendBlng.UseVisualStyleBackColor = true;
            // 
            // chkInvCreatDtm
            // 
            this.chkInvCreatDtm.AutoSize = true;
            this.chkInvCreatDtm.DatabaseFieldLink = "InvCreatDtm";
            this.chkInvCreatDtm.Location = new System.Drawing.Point(4, 113);
            this.chkInvCreatDtm.Name = "chkInvCreatDtm";
            this.chkInvCreatDtm.Size = new System.Drawing.Size(85, 17);
            this.chkInvCreatDtm.TabIndex = 6;
            this.chkInvCreatDtm.Text = "InvCreatDtm";
            this.chkInvCreatDtm.UseVisualStyleBackColor = true;
            // 
            // chkFbAmt
            // 
            this.chkFbAmt.AutoSize = true;
            this.chkFbAmt.DatabaseFieldLink = "FbAmt";
            this.chkFbAmt.Location = new System.Drawing.Point(158, 67);
            this.chkFbAmt.Name = "chkFbAmt";
            this.chkFbAmt.Size = new System.Drawing.Size(56, 17);
            this.chkFbAmt.TabIndex = 7;
            this.chkFbAmt.Text = "FbAmt";
            this.chkFbAmt.UseVisualStyleBackColor = true;
            // 
            // chkFbCreatDtm
            // 
            this.chkFbCreatDtm.AutoSize = true;
            this.chkFbCreatDtm.DatabaseFieldLink = "FbCreatDtm";
            this.chkFbCreatDtm.Location = new System.Drawing.Point(158, 91);
            this.chkFbCreatDtm.Name = "chkFbCreatDtm";
            this.chkFbCreatDtm.Size = new System.Drawing.Size(82, 17);
            this.chkFbCreatDtm.TabIndex = 8;
            this.chkFbCreatDtm.Text = "FbCreatDtm";
            this.chkFbCreatDtm.UseVisualStyleBackColor = true;
            // 
            // lblFBFullQAPercent
            // 
            this.lblFBFullQAPercent.AutoSize = true;
            this.lblFBFullQAPercent.Location = new System.Drawing.Point(6, 141);
            this.lblFBFullQAPercent.Name = "lblFBFullQAPercent";
            this.lblFBFullQAPercent.Size = new System.Drawing.Size(100, 13);
            this.lblFBFullQAPercent.TabIndex = 10;
            this.lblFBFullQAPercent.Text = "FB Full QA Percent:";
            // 
            // txtFBFullQAPercent
            // 
            this.txtFBFullQAPercent.DatabaseFieldLink = "FBFullQAPercent";
            this.txtFBFullQAPercent.Location = new System.Drawing.Point(112, 138);
            this.txtFBFullQAPercent.MaxLength = 3;
            this.txtFBFullQAPercent.Name = "txtFBFullQAPercent";
            this.txtFBFullQAPercent.Size = new System.Drawing.Size(51, 20);
            this.txtFBFullQAPercent.TabIndex = 11;
            this.txtFBFullQAPercent.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // chkFbPaymtTermsCode
            // 
            this.chkFbPaymtTermsCode.AutoSize = true;
            this.chkFbPaymtTermsCode.DatabaseFieldLink = "FbPaymtTermsCode";
            this.chkFbPaymtTermsCode.Enabled = false;
            this.chkFbPaymtTermsCode.Location = new System.Drawing.Point(158, 115);
            this.chkFbPaymtTermsCode.Name = "chkFbPaymtTermsCode";
            this.chkFbPaymtTermsCode.Size = new System.Drawing.Size(121, 17);
            this.chkFbPaymtTermsCode.TabIndex = 12;
            this.chkFbPaymtTermsCode.Text = "FbPaymtTermsCode";
            this.chkFbPaymtTermsCode.UseVisualStyleBackColor = true;
            // 
            // frmQAConfigMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 491);
            this.Name = "frmQAConfigMaster";
            this.Text = "QAConfigMaster";
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

        private FormControls.TraxDELabel lblOwnerKey;
        private FormControls.TraxDEComboBox ddlOwnerKey;
        private FormControls.TraxDECheckBox chkInvAmt;
        private FormControls.TraxDEComboBox ddlVendSCAC;
        private FormControls.TraxDELabel lblVendSCAC;
        private FormControls.TraxDECheckBox chkAcctNumVendBlng;
        private FormControls.TraxDECheckBox chkInvCreatDtm;
        private FormControls.TraxDETextBox txtFBFullQAPercent;
        private FormControls.TraxDELabel lblFBFullQAPercent;
        private FormControls.TraxDECheckBox chkFbCreatDtm;
        private FormControls.TraxDECheckBox chkFbAmt;
        private FormControls.TraxDECheckBox chkFbPaymtTermsCode;
    }
}