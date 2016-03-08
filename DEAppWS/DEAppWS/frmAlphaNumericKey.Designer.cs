namespace DEAppWS
{
    partial class frmAlphaNumericKey
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
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.chkInvoice = new FormControls.TraxDECheckBox();
            this.chkFreightBill = new FormControls.TraxDECheckBox();
            this.ddlOwnerKey = new FormControls.TraxDEComboBox();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.ddlOwnerKey);
            this.grpBoxDetail.Controls.Add(this.chkFreightBill);
            this.grpBoxDetail.Controls.Add(this.chkInvoice);
            this.grpBoxDetail.Controls.Add(this.traxDELabel1);
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.Location = new System.Drawing.Point(16, 22);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(65, 13);
            this.traxDELabel1.TabIndex = 0;
            this.traxDELabel1.Text = "Owner Key :";
            // 
            // chkInvoice
            // 
            this.chkInvoice.AutoSize = true;
            this.chkInvoice.DatabaseFieldLink = "Invoice";
            this.chkInvoice.Location = new System.Drawing.Point(19, 58);
            this.chkInvoice.Name = "chkInvoice";
            this.chkInvoice.Size = new System.Drawing.Size(61, 17);
            this.chkInvoice.TabIndex = 3;
            this.chkInvoice.Text = "Invoice";
            this.chkInvoice.UseVisualStyleBackColor = true;
            // 
            // chkFreightBill
            // 
            this.chkFreightBill.AutoSize = true;
            this.chkFreightBill.DatabaseFieldLink = "FreightBill";
            this.chkFreightBill.Location = new System.Drawing.Point(19, 81);
            this.chkFreightBill.Name = "chkFreightBill";
            this.chkFreightBill.Size = new System.Drawing.Size(74, 17);
            this.chkFreightBill.TabIndex = 6;
            this.chkFreightBill.Text = "Freight Bill";
            this.chkFreightBill.UseVisualStyleBackColor = true;
            // 
            // ddlOwnerKey
            // 
            this.ddlOwnerKey.DatabaseFieldLink = "Owner_Key";
            this.ddlOwnerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOwnerKey.FormattingEnabled = true;
            this.ddlOwnerKey.Location = new System.Drawing.Point(87, 19);
            this.ddlOwnerKey.Name = "ddlOwnerKey";
            this.ddlOwnerKey.Size = new System.Drawing.Size(121, 21);
            this.ddlOwnerKey.TabIndex = 7;
            // 
            // frmAlphaNumericKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 491);
            this.Name = "frmAlphaNumericKey";
            this.Text = "Alpha Numeric Invoice\\FB Key";
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

        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDECheckBox chkInvoice;
        private FormControls.TraxDECheckBox chkFreightBill;
        private FormControls.TraxDEComboBox ddlOwnerKey;
    }
}