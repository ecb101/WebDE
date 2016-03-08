namespace DEAppWS
{
    partial class frmOwnerCodeSiteMaster
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
            this.lblOwnerCode = new FormControls.TraxDELabel();
            this.txtOwnerCode = new FormControls.TraxDETextBox();
            this.lblAssignedSite = new FormControls.TraxDELabel();
            this.ddlAssignedSite = new FormControls.TraxDEComboBox();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.ddlAssignedSite);
            this.grpBoxDetail.Controls.Add(this.lblAssignedSite);
            this.grpBoxDetail.Controls.Add(this.txtOwnerCode);
            this.grpBoxDetail.Controls.Add(this.lblOwnerCode);
            // 
            // lblOwnerCode
            // 
            this.lblOwnerCode.AutoSize = true;
            this.lblOwnerCode.Location = new System.Drawing.Point(6, 16);
            this.lblOwnerCode.Name = "lblOwnerCode";
            this.lblOwnerCode.Size = new System.Drawing.Size(69, 13);
            this.lblOwnerCode.TabIndex = 0;
            this.lblOwnerCode.Text = "Owner Code:";
            // 
            // txtOwnerCode
            // 
            this.txtOwnerCode.DatabaseFieldLink = "Owner_Code";
            this.txtOwnerCode.Location = new System.Drawing.Point(86, 13);
            this.txtOwnerCode.MaxLength = 16;
            this.txtOwnerCode.Name = "txtOwnerCode";
            this.txtOwnerCode.Size = new System.Drawing.Size(100, 20);
            this.txtOwnerCode.TabIndex = 1;
            this.txtOwnerCode.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblAssignedSite
            // 
            this.lblAssignedSite.AutoSize = true;
            this.lblAssignedSite.Location = new System.Drawing.Point(6, 42);
            this.lblAssignedSite.Name = "lblAssignedSite";
            this.lblAssignedSite.Size = new System.Drawing.Size(74, 13);
            this.lblAssignedSite.TabIndex = 2;
            this.lblAssignedSite.Text = "Assigned Site:";
            // 
            // ddlAssignedSite
            // 
            this.ddlAssignedSite.DatabaseFieldLink = "Assigned_Site";
            this.ddlAssignedSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlAssignedSite.FormattingEnabled = true;
            this.ddlAssignedSite.Location = new System.Drawing.Point(86, 39);
            this.ddlAssignedSite.Name = "ddlAssignedSite";
            this.ddlAssignedSite.Size = new System.Drawing.Size(121, 21);
            this.ddlAssignedSite.TabIndex = 3;
            // 
            // frmOwnerCodeSiteMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 491);
            this.Name = "frmOwnerCodeSiteMaster";
            this.Text = "frmOwnerCodeSiteMaster";
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

        private FormControls.TraxDELabel lblOwnerCode;
        private FormControls.TraxDETextBox txtOwnerCode;
        private FormControls.TraxDEComboBox ddlAssignedSite;
        private FormControls.TraxDELabel lblAssignedSite;
    }
}