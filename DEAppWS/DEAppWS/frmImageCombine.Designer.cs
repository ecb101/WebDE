namespace DEAppWS
{
    partial class frmImageCombine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageCombine));
            this.lstBoxImages = new System.Windows.Forms.ListBox();
            this.grpBoxImageCombine = new System.Windows.Forms.GroupBox();
            this.lblFileName = new FormControls.TraxDELabel();
            this.txtFilename = new FormControls.TraxDETextBox();
            this.btnCombine = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.ofdOpenImageFiles = new System.Windows.Forms.OpenFileDialog();
            this.grpBoxImageCombine.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstBoxImages
            // 
            this.lstBoxImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxImages.FormattingEnabled = true;
            this.lstBoxImages.Location = new System.Drawing.Point(6, 19);
            this.lstBoxImages.Name = "lstBoxImages";
            this.lstBoxImages.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstBoxImages.Size = new System.Drawing.Size(956, 186);
            this.lstBoxImages.TabIndex = 0;
            this.lstBoxImages.SelectedValueChanged += new System.EventHandler(this.lstBoxImages_SelectedValueChanged);
            // 
            // grpBoxImageCombine
            // 
            this.grpBoxImageCombine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxImageCombine.Controls.Add(this.lblFileName);
            this.grpBoxImageCombine.Controls.Add(this.txtFilename);
            this.grpBoxImageCombine.Controls.Add(this.btnCombine);
            this.grpBoxImageCombine.Controls.Add(this.btnRemove);
            this.grpBoxImageCombine.Controls.Add(this.btnAdd);
            this.grpBoxImageCombine.Controls.Add(this.lstBoxImages);
            this.grpBoxImageCombine.Location = new System.Drawing.Point(12, 12);
            this.grpBoxImageCombine.Name = "grpBoxImageCombine";
            this.grpBoxImageCombine.Size = new System.Drawing.Size(968, 242);
            this.grpBoxImageCombine.TabIndex = 1;
            this.grpBoxImageCombine.TabStop = false;
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(521, 218);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(60, 13);
            this.lblFileName.TabIndex = 5;
            this.lblFileName.Text = "File Name :";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.DatabaseFieldLink = null;
            this.txtFilename.Location = new System.Drawing.Point(587, 215);
            this.txtFilename.MaxLength = 20;
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(269, 20);
            this.txtFilename.TabIndex = 4;
            this.txtFilename.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // btnCombine
            // 
            this.btnCombine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCombine.Location = new System.Drawing.Point(862, 213);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(100, 23);
            this.btnCombine.TabIndex = 3;
            this.btnCombine.Text = "Combine Images";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.Location = new System.Drawing.Point(112, 213);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove Image";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(6, 213);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add Image";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ofdOpenImageFiles
            // 
            this.ofdOpenImageFiles.Filter = "TIFF files (*.tif)|*.tif|PNG files(*.png)|*.png|JPG files(*.jpg)|*.jpg|GIF files(" +
                "*.gif)|*.gif|BMP files(*.bmp)|*.bmp";
            this.ofdOpenImageFiles.Multiselect = true;
            this.ofdOpenImageFiles.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenImageFiles_FileOk);
            // 
            // frmImageCombine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 266);
            this.Controls.Add(this.grpBoxImageCombine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 300);
            this.Name = "frmImageCombine";
            this.Text = "Combine Image";
            this.Load += new System.EventHandler(this.frmImageCombine_Load);
            this.grpBoxImageCombine.ResumeLayout(false);
            this.grpBoxImageCombine.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxImages;
        private System.Windows.Forms.GroupBox grpBoxImageCombine;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.OpenFileDialog ofdOpenImageFiles;
        private FormControls.TraxDELabel lblFileName;
        private FormControls.TraxDETextBox txtFilename;
    }
}