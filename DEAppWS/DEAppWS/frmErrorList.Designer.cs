namespace DEAppWS
{
    partial class frmErrorList
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
            this.grdErrorList = new FormControls.TraxDEDataGridView();
            this.TrainerID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.ID = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.LineItemNum = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.ItemCategory = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.NodeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.CorrectValue = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.KeyedValue = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Accuracy = new FormControls.TraxDEDataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdErrorList)).BeginInit();
            this.SuspendLayout();
            // 
            // grdErrorList
            // 
            this.grdErrorList.AllowUserToAddRows = false;
            this.grdErrorList.AllowUserToDeleteRows = false;
            this.grdErrorList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdErrorList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdErrorList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TrainerID,
            this.ID,
            this.LineItemNum,
            this.ItemCategory,
            this.NodeName,
            this.OriginalName,
            this.FieldName,
            this.CorrectValue,
            this.KeyedValue,
            this.Accuracy});
            this.grdErrorList.Location = new System.Drawing.Point(12, 12);
            this.grdErrorList.MultiSelect = false;
            this.grdErrorList.Name = "grdErrorList";
            this.grdErrorList.ReadOnly = true;
            this.grdErrorList.RowHeadersVisible = false;
            this.grdErrorList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdErrorList.Size = new System.Drawing.Size(986, 549);
            this.grdErrorList.StandardTab = true;
            this.grdErrorList.TabIndex = 3;
            // 
            // TrainerID
            // 
            this.TrainerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TrainerID.DataPropertyName = "TrainerID";
            this.TrainerID.HeaderText = "TrainerID";
            this.TrainerID.MinimumWidth = 50;
            this.TrainerID.Name = "TrainerID";
            this.TrainerID.ReadOnly = true;
            this.TrainerID.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 50;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // LineItemNum
            // 
            this.LineItemNum.DataPropertyName = "LineItemNum";
            this.LineItemNum.HeaderText = "ItemNum";
            this.LineItemNum.Name = "LineItemNum";
            this.LineItemNum.ReadOnly = true;
            // 
            // ItemCategory
            // 
            this.ItemCategory.DataPropertyName = "ItemCategory";
            this.ItemCategory.HeaderText = "ItemCategory";
            this.ItemCategory.Name = "ItemCategory";
            this.ItemCategory.ReadOnly = true;
            // 
            // NodeName
            // 
            this.NodeName.DataPropertyName = "NodeName";
            this.NodeName.HeaderText = "NodeName";
            this.NodeName.MinimumWidth = 75;
            this.NodeName.Name = "NodeName";
            this.NodeName.ReadOnly = true;
            this.NodeName.Width = 150;
            // 
            // OriginalName
            // 
            this.OriginalName.DataPropertyName = "OriginalName";
            this.OriginalName.HeaderText = "OriginalName";
            this.OriginalName.MinimumWidth = 75;
            this.OriginalName.Name = "OriginalName";
            this.OriginalName.ReadOnly = true;
            this.OriginalName.Visible = false;
            this.OriginalName.Width = 150;
            // 
            // FieldName
            // 
            this.FieldName.DataPropertyName = "FieldName";
            this.FieldName.HeaderText = "FieldName";
            this.FieldName.MinimumWidth = 50;
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            // 
            // CorrectValue
            // 
            this.CorrectValue.DataPropertyName = "CorrectValue";
            this.CorrectValue.HeaderText = "CorrectValue";
            this.CorrectValue.MinimumWidth = 120;
            this.CorrectValue.Name = "CorrectValue";
            this.CorrectValue.ReadOnly = true;
            this.CorrectValue.Width = 123;
            // 
            // KeyedValue
            // 
            this.KeyedValue.DataPropertyName = "KeyedValue";
            this.KeyedValue.HeaderText = "KeyedValue";
            this.KeyedValue.MinimumWidth = 125;
            this.KeyedValue.Name = "KeyedValue";
            this.KeyedValue.ReadOnly = true;
            this.KeyedValue.Width = 250;
            // 
            // Accuracy
            // 
            this.Accuracy.DataPropertyName = "Accuracy";
            this.Accuracy.HeaderText = "Accuracy";
            this.Accuracy.MinimumWidth = 30;
            this.Accuracy.Name = "Accuracy";
            this.Accuracy.ReadOnly = true;
            this.Accuracy.Width = 60;
            // 
            // frmErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 573);
            this.Controls.Add(this.grdErrorList);
            this.Name = "frmErrorList";
            this.Text = "Error List";
            this.Load += new System.EventHandler(this.frmErrorList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdErrorList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormControls.TraxDEDataGridView grdErrorList;
        private FormControls.TraxDEDataGridViewTextBoxColumn TrainerID;
        private FormControls.TraxDEDataGridViewTextBoxColumn ID;
        private FormControls.TraxDEDataGridViewTextBoxColumn LineItemNum;
        private FormControls.TraxDEDataGridViewTextBoxColumn ItemCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn NodeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalName;
        private FormControls.TraxDEDataGridViewTextBoxColumn FieldName;
        private FormControls.TraxDEDataGridViewTextBoxColumn CorrectValue;
        private FormControls.TraxDEDataGridViewTextBoxColumn KeyedValue;
        private FormControls.TraxDEDataGridViewTextBoxColumn Accuracy;
    }
}