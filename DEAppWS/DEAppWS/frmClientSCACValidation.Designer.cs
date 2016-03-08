namespace DEAppWS
{
    partial class frmClientSCACValidation
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpBoxGrouping = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ddlClient = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdSCAC = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.grpBoxGrouping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCAC)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxGrouping
            // 
            this.grpBoxGrouping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxGrouping.Controls.Add(this.label8);
            this.grpBoxGrouping.Controls.Add(this.txtSearch);
            this.grpBoxGrouping.Controls.Add(this.ddlClient);
            this.grpBoxGrouping.Controls.Add(this.label6);
            this.grpBoxGrouping.Controls.Add(this.grdSCAC);
            this.grpBoxGrouping.Controls.Add(this.label5);
            this.grpBoxGrouping.Location = new System.Drawing.Point(12, 12);
            this.grpBoxGrouping.Name = "grpBoxGrouping";
            this.grpBoxGrouping.Size = new System.Drawing.Size(695, 374);
            this.grpBoxGrouping.TabIndex = 3;
            this.grpBoxGrouping.TabStop = false;
            this.grpBoxGrouping.Text = "Grouping";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Search :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(113, 46);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(576, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ddlClient
            // 
            this.ddlClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClient.FormattingEnabled = true;
            this.ddlClient.Location = new System.Drawing.Point(51, 19);
            this.ddlClient.Name = "ddlClient";
            this.ddlClient.Size = new System.Drawing.Size(638, 21);
            this.ddlClient.TabIndex = 0;
            this.ddlClient.SelectedIndexChanged += new System.EventHandler(this.ddlClient_SelectedIndexChanged);
            this.ddlClient.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ddlClient_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "SCAC";
            // 
            // grdSCAC
            // 
            this.grdSCAC.AllowUserToAddRows = false;
            this.grdSCAC.AllowUserToDeleteRows = false;
            this.grdSCAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSCAC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSCAC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSCAC.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSCAC.Location = new System.Drawing.Point(6, 72);
            this.grdSCAC.MultiSelect = false;
            this.grdSCAC.Name = "grdSCAC";
            this.grdSCAC.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSCAC.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSCAC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSCAC.Size = new System.Drawing.Size(683, 296);
            this.grdSCAC.StandardTab = true;
            this.grdSCAC.TabIndex = 2;
            this.grdSCAC.SelectionChanged += new System.EventHandler(this.grdSCAC_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Name";
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Scac";
            this.Column2.HeaderText = "Scac";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "City/State";
            this.Column3.HeaderText = "City/State";
            this.Column3.MinimumWidth = 50;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Client :";
            // 
            // btnValidate
            // 
            this.btnValidate.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnValidate.Location = new System.Drawing.Point(607, 392);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(100, 23);
            this.btnValidate.TabIndex = 4;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // frmClientSCACValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 420);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.grpBoxGrouping);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmClientSCACValidation";
            this.Text = "frmClientSCACValidation";
            this.Load += new System.EventHandler(this.frmClientSCACValidation_Load);
            this.grpBoxGrouping.ResumeLayout(false);
            this.grpBoxGrouping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCAC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxGrouping;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox ddlClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdSCAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnValidate;
    }
}