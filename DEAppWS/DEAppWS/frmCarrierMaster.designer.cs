namespace DEAppWS
{
    partial class frmCarrierMaster
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
            this.txtDeScac = new FormControls.TraxDETextBox();
            this.txtMode = new FormControls.TraxDETextBox();
            this.txtLevel = new FormControls.TraxDETextBox();
            this.txtKeyingInstructions = new FormControls.TraxDETextBox();
            this.lblDESCAC = new FormControls.TraxDELabel();
            this.lblMode = new FormControls.TraxDELabel();
            this.lblLevel = new FormControls.TraxDELabel();
            this.lblKeyingInstruction = new FormControls.TraxDELabel();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.lblKeyingInstruction);
            this.grpBoxDetail.Controls.Add(this.lblLevel);
            this.grpBoxDetail.Controls.Add(this.lblMode);
            this.grpBoxDetail.Controls.Add(this.lblDESCAC);
            this.grpBoxDetail.Controls.Add(this.txtKeyingInstructions);
            this.grpBoxDetail.Controls.Add(this.txtLevel);
            this.grpBoxDetail.Controls.Add(this.txtMode);
            this.grpBoxDetail.Controls.Add(this.txtDeScac);
            this.grpBoxDetail.Size = new System.Drawing.Size(430, 451);
            // 
            // txtDeScac
            // 
            this.txtDeScac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDeScac.DatabaseFieldLink = "DeScac";
            this.txtDeScac.Location = new System.Drawing.Point(109, 13);
            this.txtDeScac.MaxLength = 8;
            this.txtDeScac.Name = "txtDeScac";
            this.txtDeScac.Size = new System.Drawing.Size(58, 20);
            this.txtDeScac.TabIndex = 0;
            this.txtDeScac.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtMode
            // 
            this.txtMode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMode.DatabaseFieldLink = "Mode";
            this.txtMode.Location = new System.Drawing.Point(109, 39);
            this.txtMode.MaxLength = 50;
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(315, 20);
            this.txtMode.TabIndex = 1;
            this.txtMode.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtLevel
            // 
            this.txtLevel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLevel.DatabaseFieldLink = "Level";
            this.txtLevel.Location = new System.Drawing.Point(109, 65);
            this.txtLevel.MaxLength = 50;
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(315, 20);
            this.txtLevel.TabIndex = 2;
            this.txtLevel.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtKeyingInstructions
            // 
            this.txtKeyingInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeyingInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtKeyingInstructions.DatabaseFieldLink = "KeyingInstructions";
            this.txtKeyingInstructions.Location = new System.Drawing.Point(109, 91);
            this.txtKeyingInstructions.Multiline = true;
            this.txtKeyingInstructions.Name = "txtKeyingInstructions";
            this.txtKeyingInstructions.Size = new System.Drawing.Size(315, 95);
            this.txtKeyingInstructions.TabIndex = 3;
            this.txtKeyingInstructions.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblDESCAC
            // 
            this.lblDESCAC.AutoSize = true;
            this.lblDESCAC.Location = new System.Drawing.Point(6, 16);
            this.lblDESCAC.Name = "lblDESCAC";
            this.lblDESCAC.Size = new System.Drawing.Size(59, 13);
            this.lblDESCAC.TabIndex = 4;
            this.lblDESCAC.Text = "DE SCAC :";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(6, 42);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(40, 13);
            this.lblMode.TabIndex = 5;
            this.lblMode.Text = "Mode :";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(6, 68);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(39, 13);
            this.lblLevel.TabIndex = 6;
            this.lblLevel.Text = "Level :";
            // 
            // lblKeyingInstruction
            // 
            this.lblKeyingInstruction.AutoSize = true;
            this.lblKeyingInstruction.Location = new System.Drawing.Point(6, 94);
            this.lblKeyingInstruction.Name = "lblKeyingInstruction";
            this.lblKeyingInstruction.Size = new System.Drawing.Size(97, 13);
            this.lblKeyingInstruction.TabIndex = 7;
            this.lblKeyingInstruction.Text = "Keying Instruction :";
            // 
            // frmCarrierMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 491);
            this.MinimumSize = new System.Drawing.Size(731, 525);
            this.Name = "frmCarrierMaster";
            this.Text = "Carrier Master";
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

        private FormControls.TraxDETextBox txtDeScac;
        private FormControls.TraxDETextBox txtMode;
        private FormControls.TraxDETextBox txtKeyingInstructions;
        private FormControls.TraxDETextBox txtLevel;
        private FormControls.TraxDELabel lblKeyingInstruction;
        private FormControls.TraxDELabel lblLevel;
        private FormControls.TraxDELabel lblMode;
        private FormControls.TraxDELabel lblDESCAC;
    }
}