namespace DEAppWS
{
    partial class frmBatchReserve
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchReserve));
            this.btnReserve = new System.Windows.Forms.Button();
            this.grpBoxCurrentBatch = new System.Windows.Forms.GroupBox();
            this.txtCebuBatCtrlNum = new FormControls.TraxDETextBox();
            this.txtCRBatCtrlNum = new FormControls.TraxDETextBox();
            this.lblCRCurrent = new FormControls.TraxDELabel();
            this.lblCebuCurrent = new FormControls.TraxDELabel();
            this.grpBoxCurrentReserve = new System.Windows.Forms.GroupBox();
            this.traxDELabel1 = new FormControls.TraxDELabel();
            this.lblTo = new FormControls.TraxDELabel();
            this.lblRemaining = new FormControls.TraxDELabel();
            this.lblReservedBatches = new FormControls.TraxDELabel();
            this.lblDate = new FormControls.TraxDELabel();
            this.lblBuffedID = new FormControls.TraxDELabel();
            this.txtRemaining = new FormControls.TraxDETextBox();
            this.txtStartBatchNum = new FormControls.TraxDETextBox();
            this.txtOriginalCount = new FormControls.TraxDETextBox();
            this.txtEndBatchNum = new FormControls.TraxDETextBox();
            this.txtBuffedID = new FormControls.TraxDETextBox();
            this.txtBuffedDate = new FormControls.TraxDETextBox();
            this.lblReserve = new FormControls.TraxDELabel();
            this.txtReserve = new FormControls.TraxDETextBox();
            this.lblTotalRemaining = new FormControls.TraxDELabel();
            this.txtTotalRemaining = new FormControls.TraxDETextBox();
            this.grpBoxCurrentBatch.SuspendLayout();
            this.grpBoxCurrentReserve.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReserve
            // 
            this.btnReserve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReserve.Location = new System.Drawing.Point(307, 171);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(75, 23);
            this.btnReserve.TabIndex = 2;
            this.btnReserve.Text = "Reserve";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // grpBoxCurrentBatch
            // 
            this.grpBoxCurrentBatch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCurrentBatch.Controls.Add(this.txtCebuBatCtrlNum);
            this.grpBoxCurrentBatch.Controls.Add(this.txtCRBatCtrlNum);
            this.grpBoxCurrentBatch.Controls.Add(this.lblCRCurrent);
            this.grpBoxCurrentBatch.Controls.Add(this.lblCebuCurrent);
            this.grpBoxCurrentBatch.Location = new System.Drawing.Point(12, 12);
            this.grpBoxCurrentBatch.MinimumSize = new System.Drawing.Size(367, 49);
            this.grpBoxCurrentBatch.Name = "grpBoxCurrentBatch";
            this.grpBoxCurrentBatch.Size = new System.Drawing.Size(367, 49);
            this.grpBoxCurrentBatch.TabIndex = 8;
            this.grpBoxCurrentBatch.TabStop = false;
            this.grpBoxCurrentBatch.Text = "Current Batch Number";
            // 
            // txtCebuBatCtrlNum
            // 
            this.txtCebuBatCtrlNum.DatabaseFieldLink = null;
            this.txtCebuBatCtrlNum.Location = new System.Drawing.Point(293, 19);
            this.txtCebuBatCtrlNum.Name = "txtCebuBatCtrlNum";
            this.txtCebuBatCtrlNum.ReadOnly = true;
            this.txtCebuBatCtrlNum.Size = new System.Drawing.Size(62, 20);
            this.txtCebuBatCtrlNum.TabIndex = 6;
            this.txtCebuBatCtrlNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCebuBatCtrlNum.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtCRBatCtrlNum
            // 
            this.txtCRBatCtrlNum.DatabaseFieldLink = null;
            this.txtCRBatCtrlNum.Location = new System.Drawing.Point(117, 19);
            this.txtCRBatCtrlNum.Name = "txtCRBatCtrlNum";
            this.txtCRBatCtrlNum.ReadOnly = true;
            this.txtCRBatCtrlNum.Size = new System.Drawing.Size(62, 20);
            this.txtCRBatCtrlNum.TabIndex = 0;
            this.txtCRBatCtrlNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCRBatCtrlNum.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblCRCurrent
            // 
            this.lblCRCurrent.AutoSize = true;
            this.lblCRCurrent.Location = new System.Drawing.Point(10, 22);
            this.lblCRCurrent.Name = "lblCRCurrent";
            this.lblCRCurrent.Size = new System.Drawing.Size(96, 13);
            this.lblCRCurrent.TabIndex = 1;
            this.lblCRCurrent.Text = "Costa Rica Batch :";
            // 
            // lblCebuCurrent
            // 
            this.lblCebuCurrent.AutoSize = true;
            this.lblCebuCurrent.Location = new System.Drawing.Point(218, 22);
            this.lblCebuCurrent.Name = "lblCebuCurrent";
            this.lblCebuCurrent.Size = new System.Drawing.Size(69, 13);
            this.lblCebuCurrent.TabIndex = 5;
            this.lblCebuCurrent.Text = "Cebu Batch :";
            // 
            // grpBoxCurrentReserve
            // 
            this.grpBoxCurrentReserve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCurrentReserve.Controls.Add(this.traxDELabel1);
            this.grpBoxCurrentReserve.Controls.Add(this.lblTo);
            this.grpBoxCurrentReserve.Controls.Add(this.lblRemaining);
            this.grpBoxCurrentReserve.Controls.Add(this.lblReservedBatches);
            this.grpBoxCurrentReserve.Controls.Add(this.lblDate);
            this.grpBoxCurrentReserve.Controls.Add(this.lblBuffedID);
            this.grpBoxCurrentReserve.Controls.Add(this.txtRemaining);
            this.grpBoxCurrentReserve.Controls.Add(this.txtStartBatchNum);
            this.grpBoxCurrentReserve.Controls.Add(this.txtOriginalCount);
            this.grpBoxCurrentReserve.Controls.Add(this.txtEndBatchNum);
            this.grpBoxCurrentReserve.Controls.Add(this.txtBuffedID);
            this.grpBoxCurrentReserve.Controls.Add(this.txtBuffedDate);
            this.grpBoxCurrentReserve.Location = new System.Drawing.Point(12, 67);
            this.grpBoxCurrentReserve.Name = "grpBoxCurrentReserve";
            this.grpBoxCurrentReserve.Size = new System.Drawing.Size(367, 100);
            this.grpBoxCurrentReserve.TabIndex = 9;
            this.grpBoxCurrentReserve.TabStop = false;
            this.grpBoxCurrentReserve.Text = "Current Cebu Reserved";
            // 
            // traxDELabel1
            // 
            this.traxDELabel1.AutoSize = true;
            this.traxDELabel1.Location = new System.Drawing.Point(6, 77);
            this.traxDELabel1.Name = "traxDELabel1";
            this.traxDELabel1.Size = new System.Drawing.Size(75, 13);
            this.traxDELabel1.TabIndex = 18;
            this.traxDELabel1.Text = "Batches from :";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(223, 77);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(26, 13);
            this.lblTo.TabIndex = 17;
            this.lblTo.Text = "To :";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Location = new System.Drawing.Point(169, 48);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(105, 13);
            this.lblRemaining.TabIndex = 16;
            this.lblRemaining.Text = "Remaining Batches :";
            // 
            // lblReservedBatches
            // 
            this.lblReservedBatches.AutoSize = true;
            this.lblReservedBatches.Location = new System.Drawing.Point(10, 48);
            this.lblReservedBatches.Name = "lblReservedBatches";
            this.lblReservedBatches.Size = new System.Drawing.Size(101, 13);
            this.lblReservedBatches.TabIndex = 15;
            this.lblReservedBatches.Text = "Reserved Batches :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(169, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 13);
            this.lblDate.TabIndex = 14;
            this.lblDate.Text = "Buffed Date :";
            // 
            // lblBuffedID
            // 
            this.lblBuffedID.AutoSize = true;
            this.lblBuffedID.Location = new System.Drawing.Point(10, 22);
            this.lblBuffedID.Name = "lblBuffedID";
            this.lblBuffedID.Size = new System.Drawing.Size(58, 13);
            this.lblBuffedID.TabIndex = 13;
            this.lblBuffedID.Text = "Buffed ID :";
            // 
            // txtRemaining
            // 
            this.txtRemaining.DatabaseFieldLink = "RemainingReservedCount";
            this.txtRemaining.Location = new System.Drawing.Point(309, 45);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.ReadOnly = true;
            this.txtRemaining.Size = new System.Drawing.Size(46, 20);
            this.txtRemaining.TabIndex = 12;
            this.txtRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRemaining.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // txtStartBatchNum
            // 
            this.txtStartBatchNum.DatabaseFieldLink = "StartBatCtrlNum";
            this.txtStartBatchNum.Location = new System.Drawing.Point(117, 74);
            this.txtStartBatchNum.Name = "txtStartBatchNum";
            this.txtStartBatchNum.ReadOnly = true;
            this.txtStartBatchNum.Size = new System.Drawing.Size(100, 20);
            this.txtStartBatchNum.TabIndex = 11;
            this.txtStartBatchNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtStartBatchNum.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtOriginalCount
            // 
            this.txtOriginalCount.DatabaseFieldLink = "OrigReservedCount";
            this.txtOriginalCount.Location = new System.Drawing.Point(117, 45);
            this.txtOriginalCount.Name = "txtOriginalCount";
            this.txtOriginalCount.ReadOnly = true;
            this.txtOriginalCount.Size = new System.Drawing.Size(46, 20);
            this.txtOriginalCount.TabIndex = 10;
            this.txtOriginalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOriginalCount.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // txtEndBatchNum
            // 
            this.txtEndBatchNum.DatabaseFieldLink = "EndBatCtrlNum";
            this.txtEndBatchNum.Location = new System.Drawing.Point(255, 74);
            this.txtEndBatchNum.Name = "txtEndBatchNum";
            this.txtEndBatchNum.ReadOnly = true;
            this.txtEndBatchNum.Size = new System.Drawing.Size(100, 20);
            this.txtEndBatchNum.TabIndex = 9;
            this.txtEndBatchNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEndBatchNum.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // txtBuffedID
            // 
            this.txtBuffedID.DatabaseFieldLink = "BatchBuffID";
            this.txtBuffedID.Location = new System.Drawing.Point(117, 19);
            this.txtBuffedID.Name = "txtBuffedID";
            this.txtBuffedID.ReadOnly = true;
            this.txtBuffedID.Size = new System.Drawing.Size(46, 20);
            this.txtBuffedID.TabIndex = 8;
            this.txtBuffedID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBuffedID.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // txtBuffedDate
            // 
            this.txtBuffedDate.DatabaseFieldLink = "BuffDate";
            this.txtBuffedDate.Location = new System.Drawing.Point(255, 19);
            this.txtBuffedDate.Name = "txtBuffedDate";
            this.txtBuffedDate.ReadOnly = true;
            this.txtBuffedDate.Size = new System.Drawing.Size(100, 20);
            this.txtBuffedDate.TabIndex = 7;
            this.txtBuffedDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBuffedDate.ValueType = CommonLibrary.CommonEnum.ValueType.DATESHORT;
            // 
            // lblReserve
            // 
            this.lblReserve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReserve.AutoSize = true;
            this.lblReserve.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblReserve.Location = new System.Drawing.Point(157, 176);
            this.lblReserve.Name = "lblReserve";
            this.lblReserve.Size = new System.Drawing.Size(95, 13);
            this.lblReserve.TabIndex = 4;
            this.lblReserve.Text = "New Reservation :";
            // 
            // txtReserve
            // 
            this.txtReserve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReserve.DatabaseFieldLink = null;
            this.txtReserve.Location = new System.Drawing.Point(258, 173);
            this.txtReserve.Name = "txtReserve";
            this.txtReserve.Size = new System.Drawing.Size(43, 20);
            this.txtReserve.TabIndex = 3;
            this.txtReserve.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReserve.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // lblTotalRemaining
            // 
            this.lblTotalRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRemaining.AutoSize = true;
            this.lblTotalRemaining.Location = new System.Drawing.Point(9, 176);
            this.lblTotalRemaining.Name = "lblTotalRemaining";
            this.lblTotalRemaining.Size = new System.Drawing.Size(90, 13);
            this.lblTotalRemaining.TabIndex = 18;
            this.lblTotalRemaining.Text = "Total Remaining :";
            // 
            // txtTotalRemaining
            // 
            this.txtTotalRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalRemaining.DatabaseFieldLink = "RemainingReservedCount";
            this.txtTotalRemaining.Location = new System.Drawing.Point(105, 173);
            this.txtTotalRemaining.Name = "txtTotalRemaining";
            this.txtTotalRemaining.ReadOnly = true;
            this.txtTotalRemaining.Size = new System.Drawing.Size(46, 20);
            this.txtTotalRemaining.TabIndex = 17;
            this.txtTotalRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalRemaining.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // frmBatchReserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 204);
            this.Controls.Add(this.lblTotalRemaining);
            this.Controls.Add(this.txtTotalRemaining);
            this.Controls.Add(this.grpBoxCurrentReserve);
            this.Controls.Add(this.grpBoxCurrentBatch);
            this.Controls.Add(this.lblReserve);
            this.Controls.Add(this.txtReserve);
            this.Controls.Add(this.btnReserve);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(397, 238);
            this.Name = "frmBatchReserve";
            this.Text = "Batch Number Reservation";
            this.Load += new System.EventHandler(this.frmBatchReserve_Load);
            this.grpBoxCurrentBatch.ResumeLayout(false);
            this.grpBoxCurrentBatch.PerformLayout();
            this.grpBoxCurrentReserve.ResumeLayout(false);
            this.grpBoxCurrentReserve.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControls.TraxDETextBox txtCRBatCtrlNum;
        private FormControls.TraxDELabel lblCRCurrent;
        private System.Windows.Forms.Button btnReserve;
        private FormControls.TraxDETextBox txtReserve;
        private FormControls.TraxDELabel lblReserve;
        private FormControls.TraxDELabel lblCebuCurrent;
        private FormControls.TraxDETextBox txtCebuBatCtrlNum;
        private FormControls.TraxDETextBox txtBuffedDate;
        private System.Windows.Forms.GroupBox grpBoxCurrentBatch;
        private System.Windows.Forms.GroupBox grpBoxCurrentReserve;
        private FormControls.TraxDETextBox txtBuffedID;
        private FormControls.TraxDETextBox txtEndBatchNum;
        private FormControls.TraxDETextBox txtOriginalCount;
        private FormControls.TraxDETextBox txtStartBatchNum;
        private FormControls.TraxDELabel lblDate;
        private FormControls.TraxDELabel lblBuffedID;
        private FormControls.TraxDETextBox txtRemaining;
        private FormControls.TraxDELabel traxDELabel1;
        private FormControls.TraxDELabel lblTo;
        private FormControls.TraxDELabel lblRemaining;
        private FormControls.TraxDELabel lblReservedBatches;
        private FormControls.TraxDELabel lblTotalRemaining;
        private FormControls.TraxDETextBox txtTotalRemaining;
    }
}