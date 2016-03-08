namespace DEAppWS
{
    partial class frmChargeCodeLookUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeCodeLookUp));
            this.grpBoxSelection = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblSearch = new FormControls.TraxDELabel();
            this.txtSearch = new FormControls.TraxDETextBox();
            this.grdChargeCode = new FormControls.TraxDEDataGridView();
            this.ChargeCodeLnCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargeCodeLnChrgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChargeCodeLnChrgDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoxSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChargeCode)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxSelection
            // 
            this.grpBoxSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxSelection.Controls.Add(this.btnOK);
            this.grpBoxSelection.Controls.Add(this.lblSearch);
            this.grpBoxSelection.Controls.Add(this.txtSearch);
            this.grpBoxSelection.Controls.Add(this.grdChargeCode);
            this.grpBoxSelection.Location = new System.Drawing.Point(12, 12);
            this.grpBoxSelection.Name = "grpBoxSelection";
            this.grpBoxSelection.Size = new System.Drawing.Size(693, 299);
            this.grpBoxSelection.TabIndex = 0;
            this.grpBoxSelection.TabStop = false;
            this.grpBoxSelection.Text = "Charge Codes";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Location = new System.Drawing.Point(6, 270);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(6, 22);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Search : ";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.DatabaseFieldLink = null;
            this.txtSearch.Location = new System.Drawing.Point(62, 19);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(625, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // grdChargeCode
            // 
            this.grdChargeCode.AllowUserToAddRows = false;
            this.grdChargeCode.AllowUserToDeleteRows = false;
            this.grdChargeCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdChargeCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdChargeCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChargeCodeLnCat,
            this.ChargeCodeLnChrgCode,
            this.ChargeCodeLnChrgDesc});
            this.grdChargeCode.Location = new System.Drawing.Point(6, 45);
            this.grdChargeCode.MultiSelect = false;
            this.grdChargeCode.Name = "grdChargeCode";
            this.grdChargeCode.ReadOnly = true;
            this.grdChargeCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdChargeCode.Size = new System.Drawing.Size(681, 219);
            this.grdChargeCode.StandardTab = true;
            this.grdChargeCode.TabIndex = 2;
            this.grdChargeCode.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdChargeCode_CellDoubleClick);
            this.grdChargeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdChargeCode_KeyDown);
            // 
            // ChargeCodeLnCat
            // 
            this.ChargeCodeLnCat.DataPropertyName = "LnCat";
            this.ChargeCodeLnCat.HeaderText = "CAT";
            this.ChargeCodeLnCat.Name = "ChargeCodeLnCat";
            this.ChargeCodeLnCat.ReadOnly = true;
            // 
            // ChargeCodeLnChrgCode
            // 
            this.ChargeCodeLnChrgCode.DataPropertyName = "LnChrgCode";
            this.ChargeCodeLnChrgCode.HeaderText = "Charge Code";
            this.ChargeCodeLnChrgCode.Name = "ChargeCodeLnChrgCode";
            this.ChargeCodeLnChrgCode.ReadOnly = true;
            // 
            // ChargeCodeLnChrgDesc
            // 
            this.ChargeCodeLnChrgDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChargeCodeLnChrgDesc.DataPropertyName = "LnChrgDesc";
            this.ChargeCodeLnChrgDesc.HeaderText = "Charge Code Description";
            this.ChargeCodeLnChrgDesc.Name = "ChargeCodeLnChrgDesc";
            this.ChargeCodeLnChrgDesc.ReadOnly = true;
            // 
            // frmChargeCodeLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 323);
            this.Controls.Add(this.grpBoxSelection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(725, 357);
            this.Name = "frmChargeCodeLookUp";
            this.Text = "Charge Code Look Up";
            this.Load += new System.EventHandler(this.frmChargeCodeLookUp_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChargeCodeLookUp_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChargeCodeLookUp_KeyDown);
            this.grpBoxSelection.ResumeLayout(false);
            this.grpBoxSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdChargeCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxSelection;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDETextBox txtSearch;
        private FormControls.TraxDEDataGridView grdChargeCode;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeCodeLnCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeCodeLnChrgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChargeCodeLnChrgDesc;
    }
}