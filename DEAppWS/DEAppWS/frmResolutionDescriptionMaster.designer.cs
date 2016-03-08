namespace DEAppWS
{
    partial class frmResolutionDescriptionMaster
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
            this.lblID = new FormControls.TraxDELabel();
            this.txtID = new FormControls.TraxDETextBox();
            this.lblDescription = new FormControls.TraxDELabel();
            this.txtDescription = new FormControls.TraxDETextBox();
            this.lblCode = new FormControls.TraxDELabel();
            this.lblType = new FormControls.TraxDELabel();
            this.ddlType = new FormControls.TraxDEComboBox();
            this.lblCategory = new FormControls.TraxDELabel();
            this.ddlCategory = new FormControls.TraxDEComboBox();
            this.txtCode = new FormControls.TraxDETextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).BeginInit();
            this.grpBoxDetail.SuspendLayout();
            this.grpBoxList.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxDetail
            // 
            this.grpBoxDetail.Controls.Add(this.txtCode);
            this.grpBoxDetail.Controls.Add(this.ddlCategory);
            this.grpBoxDetail.Controls.Add(this.ddlType);
            this.grpBoxDetail.Controls.Add(this.txtDescription);
            this.grpBoxDetail.Controls.Add(this.lblCategory);
            this.grpBoxDetail.Controls.Add(this.lblType);
            this.grpBoxDetail.Controls.Add(this.lblCode);
            this.grpBoxDetail.Controls.Add(this.lblDescription);
            this.grpBoxDetail.Controls.Add(this.txtID);
            this.grpBoxDetail.Controls.Add(this.lblID);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(6, 16);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.DatabaseFieldLink = "ID";
            this.txtID.Location = new System.Drawing.Point(84, 13);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(47, 20);
            this.txtID.TabIndex = 1;
            this.txtID.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(6, 93);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.DatabaseFieldLink = "Description";
            this.txtDescription.Location = new System.Drawing.Point(84, 90);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(283, 20);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(6, 56);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 13);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 134);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type:";
            // 
            // ddlType
            // 
            this.ddlType.DatabaseFieldLink = "Type";
            this.ddlType.DisplayMember = "Type";
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Location = new System.Drawing.Point(84, 131);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(102, 21);
            this.ddlType.TabIndex = 2;
            this.ddlType.ValueMember = "Type";
            this.ddlType.SelectedIndexChanged += new System.EventHandler(this.ddlType_SelectedIndexChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(6, 177);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 0;
            this.lblCategory.Text = "Category:";
            // 
            // ddlCategory
            // 
            this.ddlCategory.DatabaseFieldLink = "Category";
            this.ddlCategory.DisplayMember = "Category";
            this.ddlCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCategory.FormattingEnabled = true;
            this.ddlCategory.Location = new System.Drawing.Point(84, 174);
            this.ddlCategory.Name = "ddlCategory";
            this.ddlCategory.Size = new System.Drawing.Size(47, 21);
            this.ddlCategory.TabIndex = 2;
            this.ddlCategory.ValueMember = "Category";
            this.ddlCategory.SelectedIndexChanged += new System.EventHandler(this.ddlCategory_SelectedIndexChanged);
            // 
            // txtCode
            // 
            this.txtCode.DatabaseFieldLink = "Code";
            this.txtCode.Location = new System.Drawing.Point(84, 53);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(47, 20);
            this.txtCode.TabIndex = 3;
            this.txtCode.ValueType = CommonLibrary.CommonEnum.ValueType.ALPHA_NUMERIC;
            // 
            // frmResolutionDescriptionMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 491);
            this.Name = "frmResolutionDescriptionMaster";
            this.Text = "frmResolutionDescriptionMaster";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dv)).EndInit();
            this.grpBoxDetail.ResumeLayout(false);
            this.grpBoxDetail.PerformLayout();
            this.grpBoxList.ResumeLayout(false);
            this.grpBoxList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FormControls.TraxDELabel lblID;
        private FormControls.TraxDETextBox txtDescription;
        private FormControls.TraxDELabel lblDescription;
        private FormControls.TraxDETextBox txtID;
        private FormControls.TraxDEComboBox ddlCategory;
        private FormControls.TraxDEComboBox ddlType;
        private FormControls.TraxDELabel lblCategory;
        private FormControls.TraxDELabel lblType;
        private FormControls.TraxDELabel lblCode;
        private FormControls.TraxDETextBox txtCode;
    }
}