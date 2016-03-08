namespace DEAppWS
{
    partial class frmBatchDeactivation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchDeactivation));
            this.grpBoxGrid = new System.Windows.Forms.GroupBox();
            this.grpBoxReason = new System.Windows.Forms.GroupBox();
            this.radioBtnReason1 = new System.Windows.Forms.RadioButton();
            this.txtReason = new FormControls.TraxDETextBox();
            this.ddlReason = new FormControls.TraxDEComboBox();
            this.radioBtnReason2 = new System.Windows.Forms.RadioButton();
            this.radioBtnReactivate = new System.Windows.Forms.RadioButton();
            this.radioBtnDeactivate = new System.Windows.Forms.RadioButton();
            this.chkBoxAll = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSearch = new FormControls.TraxDELabel();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.grdBatches = new FormControls.TraxDEDataGridView();
            this.Bat_Ctrl_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblReason = new FormControls.TraxDELabel();
            this.grpBoxGrid.SuspendLayout();
            this.grpBoxReason.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxGrid
            // 
            this.grpBoxGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxGrid.Controls.Add(this.grpBoxReason);
            this.grpBoxGrid.Controls.Add(this.radioBtnReactivate);
            this.grpBoxGrid.Controls.Add(this.radioBtnDeactivate);
            this.grpBoxGrid.Controls.Add(this.chkBoxAll);
            this.grpBoxGrid.Controls.Add(this.btnOK);
            this.grpBoxGrid.Controls.Add(this.lblSearch);
            this.grpBoxGrid.Controls.Add(this.txtSearch);
            this.grpBoxGrid.Controls.Add(this.grdBatches);
            this.grpBoxGrid.Location = new System.Drawing.Point(12, 12);
            this.grpBoxGrid.Name = "grpBoxGrid";
            this.grpBoxGrid.Size = new System.Drawing.Size(556, 465);
            this.grpBoxGrid.TabIndex = 0;
            this.grpBoxGrid.TabStop = false;
            // 
            // grpBoxReason
            // 
            this.grpBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxReason.Controls.Add(this.lblReason);
            this.grpBoxReason.Controls.Add(this.radioBtnReason1);
            this.grpBoxReason.Controls.Add(this.txtReason);
            this.grpBoxReason.Controls.Add(this.ddlReason);
            this.grpBoxReason.Controls.Add(this.radioBtnReason2);
            this.grpBoxReason.Location = new System.Drawing.Point(6, 360);
            this.grpBoxReason.Name = "grpBoxReason";
            this.grpBoxReason.Size = new System.Drawing.Size(544, 70);
            this.grpBoxReason.TabIndex = 10;
            this.grpBoxReason.TabStop = false;
            // 
            // radioBtnReason1
            // 
            this.radioBtnReason1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnReason1.AutoSize = true;
            this.radioBtnReason1.Checked = true;
            this.radioBtnReason1.Location = new System.Drawing.Point(6, 18);
            this.radioBtnReason1.Name = "radioBtnReason1";
            this.radioBtnReason1.Size = new System.Drawing.Size(114, 17);
            this.radioBtnReason1.TabIndex = 3;
            this.radioBtnReason1.TabStop = true;
            this.radioBtnReason1.Text = "Standard Reason :";
            this.radioBtnReason1.UseVisualStyleBackColor = true;
            this.radioBtnReason1.Visible = false;
            this.radioBtnReason1.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.DatabaseFieldLink = null;
            this.txtReason.Location = new System.Drawing.Point(126, 44);
            this.txtReason.MaxLength = 255;
            this.txtReason.Name = "txtReason";
            this.txtReason.ReadOnly = true;
            this.txtReason.Size = new System.Drawing.Size(412, 20);
            this.txtReason.TabIndex = 6;
            this.txtReason.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtReason.Visible = false;
            this.txtReason.TextChanged += new System.EventHandler(this.txtReason_TextChanged);
            // 
            // ddlReason
            // 
            this.ddlReason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlReason.DatabaseFieldLink = null;
            this.ddlReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlReason.FormattingEnabled = true;
            this.ddlReason.Items.AddRange(new object[] {
            "Amounts Out Of Balance ",
            "DE Application Error ",
            "Duplicate Batch ",
            "Image Issue ",
            "Keyed at Another Site ",
            "Missing Required Information ",
            "Multiple Client ",
            "Multiple Remit Address ",
            "Multiple SCAC ",
            "Negative Amount ",
            "Non-Invoice Document ",
            "Not To Be Batched Per Instruction",
            "Test Batch ",
            "Wrong Client ",
            "Wrong SCAC ",
            "Zero Amount",
            "Parsing Error"});
            this.ddlReason.Location = new System.Drawing.Point(126, 17);
            this.ddlReason.Name = "ddlReason";
            this.ddlReason.Size = new System.Drawing.Size(412, 21);
            this.ddlReason.TabIndex = 4;
            this.ddlReason.SelectedIndexChanged += new System.EventHandler(this.ddlReason_SelectedIndexChanged);
            // 
            // radioBtnReason2
            // 
            this.radioBtnReason2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.radioBtnReason2.AutoSize = true;
            this.radioBtnReason2.Location = new System.Drawing.Point(6, 47);
            this.radioBtnReason2.Name = "radioBtnReason2";
            this.radioBtnReason2.Size = new System.Drawing.Size(97, 17);
            this.radioBtnReason2.TabIndex = 5;
            this.radioBtnReason2.Text = "Other Reason :";
            this.radioBtnReason2.UseVisualStyleBackColor = true;
            this.radioBtnReason2.Visible = false;
            this.radioBtnReason2.CheckedChanged += new System.EventHandler(this.radioBtn_CheckedChanged);
            // 
            // radioBtnReactivate
            // 
            this.radioBtnReactivate.AutoSize = true;
            this.radioBtnReactivate.Location = new System.Drawing.Point(97, 19);
            this.radioBtnReactivate.Name = "radioBtnReactivate";
            this.radioBtnReactivate.Size = new System.Drawing.Size(77, 17);
            this.radioBtnReactivate.TabIndex = 9;
            this.radioBtnReactivate.Text = "Reactivate";
            this.radioBtnReactivate.UseVisualStyleBackColor = true;
            this.radioBtnReactivate.CheckedChanged += new System.EventHandler(this.radioBtnType_CheckedChanged);
            // 
            // radioBtnDeactivate
            // 
            this.radioBtnDeactivate.AutoSize = true;
            this.radioBtnDeactivate.Checked = true;
            this.radioBtnDeactivate.Location = new System.Drawing.Point(6, 19);
            this.radioBtnDeactivate.Name = "radioBtnDeactivate";
            this.radioBtnDeactivate.Size = new System.Drawing.Size(77, 17);
            this.radioBtnDeactivate.TabIndex = 8;
            this.radioBtnDeactivate.TabStop = true;
            this.radioBtnDeactivate.Text = "Deactivate";
            this.radioBtnDeactivate.UseVisualStyleBackColor = true;
            this.radioBtnDeactivate.CheckedChanged += new System.EventHandler(this.radioBtnType_CheckedChanged);
            // 
            // chkBoxAll
            // 
            this.chkBoxAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxAll.AutoSize = true;
            this.chkBoxAll.Checked = true;
            this.chkBoxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxAll.Location = new System.Drawing.Point(504, 44);
            this.chkBoxAll.Name = "chkBoxAll";
            this.chkBoxAll.Size = new System.Drawing.Size(37, 17);
            this.chkBoxAll.TabIndex = 1;
            this.chkBoxAll.Text = "All";
            this.chkBoxAll.UseVisualStyleBackColor = true;
            this.chkBoxAll.CheckedChanged += new System.EventHandler(this.chkBoxAll_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(475, 436);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Deactivate";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 45);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(59, 42);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(439, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grdBatches
            // 
            this.grdBatches.AllowUserToAddRows = false;
            this.grdBatches.AllowUserToDeleteRows = false;
            this.grdBatches.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBatches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdBatches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bat_Ctrl_Num,
            this.Active});
            this.grdBatches.Location = new System.Drawing.Point(6, 68);
            this.grdBatches.Name = "grdBatches";
            this.grdBatches.RowHeadersVisible = false;
            this.grdBatches.Size = new System.Drawing.Size(544, 286);
            this.grdBatches.TabIndex = 2;
            // 
            // Bat_Ctrl_Num
            // 
            this.Bat_Ctrl_Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Bat_Ctrl_Num.DataPropertyName = "Bat_Ctrl_Num";
            this.Bat_Ctrl_Num.HeaderText = "Batch Number";
            this.Bat_Ctrl_Num.Name = "Bat_Ctrl_Num";
            this.Bat_Ctrl_Num.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Location = new System.Drawing.Point(6, 20);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(96, 13);
            this.lblReason.TabIndex = 7;
            this.lblReason.Text = "Standard Reason :";
            // 
            // frmBatchDeactivation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 489);
            this.Controls.Add(this.grpBoxGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(459, 300);
            this.Name = "frmBatchDeactivation";
            this.Text = "Batch Maintenance";
            this.Load += new System.EventHandler(this.frmBatchDeactivation_Load);
            this.grpBoxGrid.ResumeLayout(false);
            this.grpBoxGrid.PerformLayout();
            this.grpBoxReason.ResumeLayout(false);
            this.grpBoxReason.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBatches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxGrid;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDEDataGridView grdBatches;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkBoxAll;
        private FormControls.TraxDETextBox txtReason;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bat_Ctrl_Num;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
        private System.Windows.Forms.RadioButton radioBtnReason2;
        private System.Windows.Forms.RadioButton radioBtnReason1;
        private FormControls.TraxDEComboBox ddlReason;
        private System.Windows.Forms.RadioButton radioBtnReactivate;
        private System.Windows.Forms.RadioButton radioBtnDeactivate;
        private System.Windows.Forms.GroupBox grpBoxReason;
        private FormControls.TraxDELabel lblReason;
    }
}