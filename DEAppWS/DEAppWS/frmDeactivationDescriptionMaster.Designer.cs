namespace DEAppWS
{
    partial class frmDeactivationDescriptionMaster
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
            this.txtDescription = new FormControls.TraxDETextBox();
            this.txtNote = new FormControls.TraxDETextBox();
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.traxDELabel2 = new FormControls.TraxDELabel();
            this.traxDELabel3 = new FormControls.TraxDELabel();
            this.txtDeatcivationReasonID = new FormControls.TraxDETextBox();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.txtDeatcivationReasonID);
            this.grpBoxDetail.Controls.Add(this.traxDELabel3);
            this.grpBoxDetail.Controls.Add(this.traxDELabel2);
            this.grpBoxDetail.Controls.Add(this.traxDELabel1);
            this.grpBoxDetail.Controls.Add(this.txtNote);
            this.grpBoxDetail.Controls.Add(this.txtDescription);
            this.grpBoxDetail.Location = new System.Drawing.Point(413, 28);
            this.grpBoxDetail.Size = new System.Drawing.Size(298, 451);
            // 
            // grpBoxList
            // 
            this.grpBoxList.Size = new System.Drawing.Size(395, 451);
            // 
            // txtSearch
            // 
            this.txtSearch.Size = new System.Drawing.Size(330, 20);
            // 
            // panelGrid
            // 
            this.panelGrid.Size = new System.Drawing.Size(383, 406);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.DatabaseFieldLink = "Description";
            this.txtDescription.Location = new System.Drawing.Point(106, 45);
            this.txtDescription.MaxLength = 255;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(186, 20);
            this.txtDescription.TabIndex = 0;
            this.txtDescription.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.DatabaseFieldLink = "Note";
            this.txtNote.Location = new System.Drawing.Point(106, 71);
            this.txtNote.MaxLength = 255;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(186, 20);
            this.txtNote.TabIndex = 1;
            this.txtNote.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.Location = new System.Drawing.Point(6, 48);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(66, 13);
            this.traxDELabel1.TabIndex = 2;
            this.traxDELabel1.Text = "Description :";
            // 
            // traxDELabel2
            // 
            this.traxDELabel2.AutoSize = true;
            this.traxDELabel2.Location = new System.Drawing.Point(6, 74);
            this.traxDELabel2.Name = "traxDELabel2";
            this.traxDELabel2.Size = new System.Drawing.Size(36, 13);
            this.traxDELabel2.TabIndex = 3;
            this.traxDELabel2.Text = "Note :";
            // 
            // traxDELabel3
            // 
            this.traxDELabel3.AutoSize = true;
            this.traxDELabel3.Location = new System.Drawing.Point(6, 22);
            this.traxDELabel3.Name = "traxDELabel3";
            this.traxDELabel3.Size = new System.Drawing.Size(61, 13);
            this.traxDELabel3.TabIndex = 4;
            this.traxDELabel3.Text = "ReasonID :";
            // 
            // txtDeatcivationReasonID
            // 
            this.txtDeatcivationReasonID.DatabaseFieldLink = "DeactivationReasonID";
            this.txtDeatcivationReasonID.Enabled = false;
            this.txtDeatcivationReasonID.Location = new System.Drawing.Point(106, 19);
            this.txtDeatcivationReasonID.Name = "txtDeatcivationReasonID";
            this.txtDeatcivationReasonID.Size = new System.Drawing.Size(29, 20);
            this.txtDeatcivationReasonID.TabIndex = 5;
            this.txtDeatcivationReasonID.ValueType = CommonLibrary.CommonEnum.ValueType.ALPHA_NUMERIC;
            // 
            // frmDeactivationDescriptionMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 491);
            this.Name = "frmDeactivationDescriptionMaster";
            this.Text = "Deactivation Description Master";
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

        private FormControls.TraxDETextBox txtDescription;
        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDETextBox txtNote;
        private FormControls.TraxDELabel traxDELabel2;
        private FormControls.TraxDELabel traxDELabel3;
        private FormControls.TraxDETextBox txtDeatcivationReasonID;

    }
}