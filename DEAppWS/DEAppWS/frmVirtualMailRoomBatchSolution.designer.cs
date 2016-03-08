namespace DEAppWS
{
    partial class frmVirtualMailRoomBatchSolution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVirtualMailRoomBatchSolution));
            this.ofdOpenImageFile = new System.Windows.Forms.OpenFileDialog();
            this.grpBoxImage = new System.Windows.Forms.GroupBox();
            this.pcbImage = new FormControls.TraxDEPictureBox();
            this.grpBoxData = new System.Windows.Forms.GroupBox();
            this.chkBoxEphesoftDrop = new FormControls.TraxDECheckBox();
            this.radioNewBatch = new System.Windows.Forms.RadioButton();
            this.radioReBatch = new System.Windows.Forms.RadioButton();
            this.chkBoxSplitBatch = new System.Windows.Forms.CheckBox();
            this.chkBoxProduction = new System.Windows.Forms.CheckBox();
            this.grpBoxImageControl = new System.Windows.Forms.GroupBox();
            this.txtRotateDegree = new System.Windows.Forms.TextBox();
            this.radioButton_4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton_2 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFBCount = new System.Windows.Forms.TextBox();
            this.grpBoxGrouping = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtICS = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCarrierName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ddlClient = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.grdSCAC = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBoxImageNavigation = new System.Windows.Forms.GroupBox();
            this.txtFilePathName = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSplitFBCount = new FormControls.TraxDETextBox();
            this.ddlPages = new FormControls.TraxDEComboBox();
            this.chkBoxSplitPoint = new System.Windows.Forms.CheckBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.radioJPM = new System.Windows.Forms.RadioButton();
            this.radioLA = new System.Windows.Forms.RadioButton();
            this.radioAPAC = new System.Windows.Forms.RadioButton();
            this.chkBoxStamp = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnInlude = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPageCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.grpBoxPageList = new System.Windows.Forms.GroupBox();
            this.btnMoveLeftAll = new System.Windows.Forms.Button();
            this.btnMoveRightAll = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.lstBoxForGrouping = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstBoxPages = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.txtImageIssue = new System.Windows.Forms.TextBox();
            this.grpBoxImage.SuspendLayout();
            this.grpBoxData.SuspendLayout();
            this.grpBoxImageControl.SuspendLayout();
            this.grpBoxGrouping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCAC)).BeginInit();
            this.grpBoxImageNavigation.SuspendLayout();
            this.grpBoxPageList.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdOpenImageFile
            // 
            this.ofdOpenImageFile.Filter = "TIFF files (*.tif)|*.tif";
            this.ofdOpenImageFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdOpenImageFile_FileOk);
            // 
            // grpBoxImage
            // 
            this.grpBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxImage.Controls.Add(this.pcbImage);
            this.grpBoxImage.Location = new System.Drawing.Point(12, -1);
            this.grpBoxImage.Name = "grpBoxImage";
            this.grpBoxImage.Size = new System.Drawing.Size(717, 720);
            this.grpBoxImage.TabIndex = 0;
            this.grpBoxImage.TabStop = false;
            this.grpBoxImage.Text = "Image";
            // 
            // pcbImage
            // 
            this.pcbImage.AutoScroll = true;
            this.pcbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbImage.Image = null;
            this.pcbImage.Location = new System.Drawing.Point(3, 16);
            this.pcbImage.Name = "pcbImage";
            this.pcbImage.Size = new System.Drawing.Size(711, 701);
            this.pcbImage.TabIndex = 0;
            // 
            // grpBoxData
            // 
            this.grpBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxData.Controls.Add(this.chkBoxEphesoftDrop);
            this.grpBoxData.Controls.Add(this.radioNewBatch);
            this.grpBoxData.Controls.Add(this.radioReBatch);
            this.grpBoxData.Controls.Add(this.chkBoxSplitBatch);
            this.grpBoxData.Controls.Add(this.chkBoxProduction);
            this.grpBoxData.Controls.Add(this.grpBoxImageControl);
            this.grpBoxData.Controls.Add(this.label10);
            this.grpBoxData.Controls.Add(this.txtFBCount);
            this.grpBoxData.Controls.Add(this.grpBoxGrouping);
            this.grpBoxData.Controls.Add(this.grpBoxImageNavigation);
            this.grpBoxData.Controls.Add(this.grpBoxPageList);
            this.grpBoxData.Controls.Add(this.btnCreateGroup);
            this.grpBoxData.Location = new System.Drawing.Point(735, -1);
            this.grpBoxData.Name = "grpBoxData";
            this.grpBoxData.Size = new System.Drawing.Size(445, 720);
            this.grpBoxData.TabIndex = 1;
            this.grpBoxData.TabStop = false;
            // 
            // chkBoxEphesoftDrop
            // 
            this.chkBoxEphesoftDrop.AutoSize = true;
            this.chkBoxEphesoftDrop.DatabaseFieldLink = null;
            this.chkBoxEphesoftDrop.Location = new System.Drawing.Point(6, 12);
            this.chkBoxEphesoftDrop.Name = "chkBoxEphesoftDrop";
            this.chkBoxEphesoftDrop.Size = new System.Drawing.Size(94, 17);
            this.chkBoxEphesoftDrop.TabIndex = 27;
            this.chkBoxEphesoftDrop.Text = "Ephesoft Drop";
            this.chkBoxEphesoftDrop.UseVisualStyleBackColor = true;
            // 
            // radioNewBatch
            // 
            this.radioNewBatch.AutoSize = true;
            this.radioNewBatch.Checked = true;
            this.radioNewBatch.ForeColor = System.Drawing.Color.Maroon;
            this.radioNewBatch.Location = new System.Drawing.Point(356, 12);
            this.radioNewBatch.Name = "radioNewBatch";
            this.radioNewBatch.Size = new System.Drawing.Size(78, 17);
            this.radioNewBatch.TabIndex = 26;
            this.radioNewBatch.TabStop = true;
            this.radioNewBatch.Text = "New Batch";
            this.radioNewBatch.UseVisualStyleBackColor = true;
            // 
            // radioReBatch
            // 
            this.radioReBatch.AutoSize = true;
            this.radioReBatch.ForeColor = System.Drawing.Color.Maroon;
            this.radioReBatch.Location = new System.Drawing.Point(275, 12);
            this.radioReBatch.Name = "radioReBatch";
            this.radioReBatch.Size = new System.Drawing.Size(70, 17);
            this.radioReBatch.TabIndex = 25;
            this.radioReBatch.TabStop = true;
            this.radioReBatch.Text = "Re-Batch";
            this.radioReBatch.UseVisualStyleBackColor = true;
            this.radioReBatch.Visible = false;
            // 
            // chkBoxSplitBatch
            // 
            this.chkBoxSplitBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxSplitBatch.AutoSize = true;
            this.chkBoxSplitBatch.Location = new System.Drawing.Point(153, 692);
            this.chkBoxSplitBatch.Name = "chkBoxSplitBatch";
            this.chkBoxSplitBatch.Size = new System.Drawing.Size(77, 17);
            this.chkBoxSplitBatch.TabIndex = 24;
            this.chkBoxSplitBatch.Text = "Split Batch";
            this.chkBoxSplitBatch.UseVisualStyleBackColor = true;
            this.chkBoxSplitBatch.CheckedChanged += new System.EventHandler(this.chkBoxSplitBatch_CheckedChanged);
            // 
            // chkBoxProduction
            // 
            this.chkBoxProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxProduction.AutoSize = true;
            this.chkBoxProduction.Checked = true;
            this.chkBoxProduction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxProduction.Location = new System.Drawing.Point(236, 692);
            this.chkBoxProduction.Name = "chkBoxProduction";
            this.chkBoxProduction.Size = new System.Drawing.Size(77, 17);
            this.chkBoxProduction.TabIndex = 23;
            this.chkBoxProduction.Text = "Production";
            this.chkBoxProduction.UseVisualStyleBackColor = true;
            // 
            // grpBoxImageControl
            // 
            this.grpBoxImageControl.Controls.Add(this.txtRotateDegree);
            this.grpBoxImageControl.Controls.Add(this.radioButton_4);
            this.grpBoxImageControl.Controls.Add(this.radioButton2);
            this.grpBoxImageControl.Controls.Add(this.btnRotateLeft);
            this.grpBoxImageControl.Controls.Add(this.btnRotateRight);
            this.grpBoxImageControl.Controls.Add(this.label9);
            this.grpBoxImageControl.Controls.Add(this.radioButton_2);
            this.grpBoxImageControl.Controls.Add(this.label7);
            this.grpBoxImageControl.Controls.Add(this.radioButton1);
            this.grpBoxImageControl.Location = new System.Drawing.Point(319, 157);
            this.grpBoxImageControl.Name = "grpBoxImageControl";
            this.grpBoxImageControl.Size = new System.Drawing.Size(114, 187);
            this.grpBoxImageControl.TabIndex = 6;
            this.grpBoxImageControl.TabStop = false;
            this.grpBoxImageControl.Text = "Image Control";
            // 
            // txtRotateDegree
            // 
            this.txtRotateDegree.Location = new System.Drawing.Point(57, 14);
            this.txtRotateDegree.Name = "txtRotateDegree";
            this.txtRotateDegree.ReadOnly = true;
            this.txtRotateDegree.Size = new System.Drawing.Size(38, 20);
            this.txtRotateDegree.TabIndex = 8;
            this.txtRotateDegree.Text = "0";
            this.txtRotateDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioButton_4
            // 
            this.radioButton_4.AutoSize = true;
            this.radioButton_4.Location = new System.Drawing.Point(6, 94);
            this.radioButton_4.Name = "radioButton_4";
            this.radioButton_4.Size = new System.Drawing.Size(39, 17);
            this.radioButton_4.TabIndex = 4;
            this.radioButton_4.Text = "-4x";
            this.radioButton_4.UseVisualStyleBackColor = true;
            this.radioButton_4.CheckedChanged += new System.EventHandler(this.radioButton_4_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 163);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(36, 17);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.Text = "2x";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // btnRotateLeft
            // 
            this.btnRotateLeft.Location = new System.Drawing.Point(9, 35);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(40, 23);
            this.btnRotateLeft.TabIndex = 0;
            this.btnRotateLeft.Text = "Left";
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Location = new System.Drawing.Point(55, 35);
            this.btnRotateRight.Name = "btnRotateRight";
            this.btnRotateRight.Size = new System.Drawing.Size(40, 23);
            this.btnRotateRight.TabIndex = 1;
            this.btnRotateRight.Text = "Right";
            this.btnRotateRight.UseVisualStyleBackColor = true;
            this.btnRotateRight.Click += new System.EventHandler(this.btnRotateRight_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Rotate :";
            // 
            // radioButton_2
            // 
            this.radioButton_2.AutoSize = true;
            this.radioButton_2.Location = new System.Drawing.Point(6, 117);
            this.radioButton_2.Name = "radioButton_2";
            this.radioButton_2.Size = new System.Drawing.Size(39, 17);
            this.radioButton_2.TabIndex = 3;
            this.radioButton_2.Text = "-2x";
            this.radioButton_2.UseVisualStyleBackColor = true;
            this.radioButton_2.CheckedChanged += new System.EventHandler(this.radioButton_2_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Zoom :";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 140);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(36, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "1x";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 693);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "FB Count :";
            // 
            // txtFBCount
            // 
            this.txtFBCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFBCount.Location = new System.Drawing.Point(69, 690);
            this.txtFBCount.Name = "txtFBCount";
            this.txtFBCount.Size = new System.Drawing.Size(78, 20);
            this.txtFBCount.TabIndex = 3;
            this.txtFBCount.TextChanged += new System.EventHandler(this.txtFBCount_TextChanged);
            this.txtFBCount.Leave += new System.EventHandler(this.txtFBCount_Leave);
            // 
            // grpBoxGrouping
            // 
            this.grpBoxGrouping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxGrouping.Controls.Add(this.label14);
            this.grpBoxGrouping.Controls.Add(this.txtImageIssue);
            this.grpBoxGrouping.Controls.Add(this.label12);
            this.grpBoxGrouping.Controls.Add(this.txtICS);
            this.grpBoxGrouping.Controls.Add(this.label11);
            this.grpBoxGrouping.Controls.Add(this.txtCarrierName);
            this.grpBoxGrouping.Controls.Add(this.label8);
            this.grpBoxGrouping.Controls.Add(this.txtSearch);
            this.grpBoxGrouping.Controls.Add(this.ddlClient);
            this.grpBoxGrouping.Controls.Add(this.label6);
            this.grpBoxGrouping.Controls.Add(this.grdSCAC);
            this.grpBoxGrouping.Controls.Add(this.label5);
            this.grpBoxGrouping.Location = new System.Drawing.Point(6, 350);
            this.grpBoxGrouping.Name = "grpBoxGrouping";
            this.grpBoxGrouping.Size = new System.Drawing.Size(433, 329);
            this.grpBoxGrouping.TabIndex = 2;
            this.grpBoxGrouping.TabStop = false;
            this.grpBoxGrouping.Text = "Grouping";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "ICS :";
            // 
            // txtICS
            // 
            this.txtICS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtICS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtICS.Location = new System.Drawing.Point(86, 284);
            this.txtICS.MaxLength = 255;
            this.txtICS.Name = "txtICS";
            this.txtICS.Size = new System.Drawing.Size(341, 20);
            this.txtICS.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Carrier Name :";
            // 
            // txtCarrierName
            // 
            this.txtCarrierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCarrierName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCarrierName.Location = new System.Drawing.Point(86, 263);
            this.txtCarrierName.MaxLength = 250;
            this.txtCarrierName.Name = "txtCarrierName";
            this.txtCarrierName.Size = new System.Drawing.Size(341, 20);
            this.txtCarrierName.TabIndex = 22;
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
            this.txtSearch.Size = new System.Drawing.Size(314, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ddlClient
            // 
            this.ddlClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlClient.FormattingEnabled = true;
            this.ddlClient.Location = new System.Drawing.Point(51, 19);
            this.ddlClient.Name = "ddlClient";
            this.ddlClient.Size = new System.Drawing.Size(376, 21);
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
            this.grdSCAC.Size = new System.Drawing.Size(421, 189);
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
            // grpBoxImageNavigation
            // 
            this.grpBoxImageNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxImageNavigation.Controls.Add(this.txtFilePathName);
            this.grpBoxImageNavigation.Controls.Add(this.btnOpenFile);
            this.grpBoxImageNavigation.Controls.Add(this.label13);
            this.grpBoxImageNavigation.Controls.Add(this.txtSplitFBCount);
            this.grpBoxImageNavigation.Controls.Add(this.ddlPages);
            this.grpBoxImageNavigation.Controls.Add(this.chkBoxSplitPoint);
            this.grpBoxImageNavigation.Controls.Add(this.btnLast);
            this.grpBoxImageNavigation.Controls.Add(this.btnFirst);
            this.grpBoxImageNavigation.Controls.Add(this.radioJPM);
            this.grpBoxImageNavigation.Controls.Add(this.radioLA);
            this.grpBoxImageNavigation.Controls.Add(this.radioAPAC);
            this.grpBoxImageNavigation.Controls.Add(this.chkBoxStamp);
            this.grpBoxImageNavigation.Controls.Add(this.btnRemove);
            this.grpBoxImageNavigation.Controls.Add(this.btnInlude);
            this.grpBoxImageNavigation.Controls.Add(this.btnPrev);
            this.grpBoxImageNavigation.Controls.Add(this.btnNext);
            this.grpBoxImageNavigation.Controls.Add(this.label2);
            this.grpBoxImageNavigation.Controls.Add(this.txtPageCount);
            this.grpBoxImageNavigation.Controls.Add(this.label1);
            this.grpBoxImageNavigation.Controls.Add(this.txtPageNumber);
            this.grpBoxImageNavigation.Location = new System.Drawing.Point(6, 29);
            this.grpBoxImageNavigation.Name = "grpBoxImageNavigation";
            this.grpBoxImageNavigation.Size = new System.Drawing.Size(427, 127);
            this.grpBoxImageNavigation.TabIndex = 0;
            this.grpBoxImageNavigation.TabStop = false;
            this.grpBoxImageNavigation.Text = "Image Navigation";
            // 
            // txtFilePathName
            // 
            this.txtFilePathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePathName.Location = new System.Drawing.Point(87, 20);
            this.txtFilePathName.Name = "txtFilePathName";
            this.txtFilePathName.ReadOnly = true;
            this.txtFilePathName.Size = new System.Drawing.Size(334, 20);
            this.txtFilePathName.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 19);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "&Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(315, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Split FB :";
            // 
            // txtSplitFBCount
            // 
            this.txtSplitFBCount.DatabaseFieldLink = null;
            this.txtSplitFBCount.DatabaseTableLink = null;
            this.txtSplitFBCount.FieldHint = null;
            this.txtSplitFBCount.Location = new System.Drawing.Point(370, 44);
            this.txtSplitFBCount.Name = "txtSplitFBCount";
            this.txtSplitFBCount.Size = new System.Drawing.Size(51, 20);
            this.txtSplitFBCount.TabIndex = 27;
            this.txtSplitFBCount.ValueType = CommonLibrary.CommonEnum.ValueType.NUMERIC;
            this.txtSplitFBCount.Validated += new System.EventHandler(this.txtSplitFBCount_Validated);
            // 
            // ddlPages
            // 
            this.ddlPages.DatabaseFieldLink = null;
            this.ddlPages.DatabaseTableLink = null;
            this.ddlPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPages.FormattingEnabled = true;
            this.ddlPages.Location = new System.Drawing.Point(87, 67);
            this.ddlPages.Name = "ddlPages";
            this.ddlPages.Size = new System.Drawing.Size(55, 21);
            this.ddlPages.TabIndex = 26;
            this.ddlPages.SelectedIndexChanged += new System.EventHandler(this.ddlPages_SelectedIndexChanged);
            // 
            // chkBoxSplitPoint
            // 
            this.chkBoxSplitPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxSplitPoint.AutoSize = true;
            this.chkBoxSplitPoint.Location = new System.Drawing.Point(204, 47);
            this.chkBoxSplitPoint.Name = "chkBoxSplitPoint";
            this.chkBoxSplitPoint.Size = new System.Drawing.Size(101, 17);
            this.chkBoxSplitPoint.TabIndex = 25;
            this.chkBoxSplitPoint.Text = "Page Split Point";
            this.chkBoxSplitPoint.UseVisualStyleBackColor = true;
            this.chkBoxSplitPoint.CheckedChanged += new System.EventHandler(this.chkBoxSplitPoint_CheckedChanged);
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.Location = new System.Drawing.Point(175, 98);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(39, 23);
            this.btnLast.TabIndex = 13;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirst.Location = new System.Drawing.Point(6, 98);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(39, 23);
            this.btnFirst.TabIndex = 12;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // radioJPM
            // 
            this.radioJPM.AutoSize = true;
            this.radioJPM.Location = new System.Drawing.Point(271, 66);
            this.radioJPM.Name = "radioJPM";
            this.radioJPM.Size = new System.Drawing.Size(46, 17);
            this.radioJPM.TabIndex = 9;
            this.radioJPM.Text = "JPM";
            this.radioJPM.UseVisualStyleBackColor = true;
            // 
            // radioLA
            // 
            this.radioLA.AutoSize = true;
            this.radioLA.Location = new System.Drawing.Point(227, 66);
            this.radioLA.Name = "radioLA";
            this.radioLA.Size = new System.Drawing.Size(38, 17);
            this.radioLA.TabIndex = 8;
            this.radioLA.Text = "LA";
            this.radioLA.UseVisualStyleBackColor = true;
            // 
            // radioAPAC
            // 
            this.radioAPAC.AutoSize = true;
            this.radioAPAC.Checked = true;
            this.radioAPAC.Location = new System.Drawing.Point(168, 66);
            this.radioAPAC.Name = "radioAPAC";
            this.radioAPAC.Size = new System.Drawing.Size(53, 17);
            this.radioAPAC.TabIndex = 7;
            this.radioAPAC.TabStop = true;
            this.radioAPAC.Text = "APAC";
            this.radioAPAC.UseVisualStyleBackColor = true;
            // 
            // chkBoxStamp
            // 
            this.chkBoxStamp.AutoSize = true;
            this.chkBoxStamp.Location = new System.Drawing.Point(142, 47);
            this.chkBoxStamp.Name = "chkBoxStamp";
            this.chkBoxStamp.Size = new System.Drawing.Size(56, 17);
            this.chkBoxStamp.TabIndex = 6;
            this.chkBoxStamp.Text = "&Stamp";
            this.chkBoxStamp.UseVisualStyleBackColor = true;
            this.chkBoxStamp.CheckedChanged += new System.EventHandler(this.chkBoxStamp_CheckedChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(313, 98);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "&Remove from Grp";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnInlude
            // 
            this.btnInlude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInlude.Enabled = false;
            this.btnInlude.Location = new System.Drawing.Point(220, 98);
            this.btnInlude.Name = "btnInlude";
            this.btnInlude.Size = new System.Drawing.Size(92, 23);
            this.btnInlude.TabIndex = 4;
            this.btnInlude.Text = "&Include in Grp";
            this.btnInlude.UseVisualStyleBackColor = true;
            this.btnInlude.Click += new System.EventHandler(this.btnInlude_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(51, 98);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(56, 23);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "&Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(113, 98);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(56, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "&Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Page Count :";
            // 
            // txtPageCount
            // 
            this.txtPageCount.Location = new System.Drawing.Point(87, 44);
            this.txtPageCount.Name = "txtPageCount";
            this.txtPageCount.ReadOnly = true;
            this.txtPageCount.Size = new System.Drawing.Size(49, 20);
            this.txtPageCount.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Page :";
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(87, 67);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.ReadOnly = true;
            this.txtPageNumber.Size = new System.Drawing.Size(49, 20);
            this.txtPageNumber.TabIndex = 11;
            // 
            // grpBoxPageList
            // 
            this.grpBoxPageList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxPageList.Controls.Add(this.btnMoveLeftAll);
            this.grpBoxPageList.Controls.Add(this.btnMoveRightAll);
            this.grpBoxPageList.Controls.Add(this.btnMoveLeft);
            this.grpBoxPageList.Controls.Add(this.lstBoxForGrouping);
            this.grpBoxPageList.Controls.Add(this.label4);
            this.grpBoxPageList.Controls.Add(this.lstBoxPages);
            this.grpBoxPageList.Controls.Add(this.label3);
            this.grpBoxPageList.Controls.Add(this.btnMoveRight);
            this.grpBoxPageList.Location = new System.Drawing.Point(6, 158);
            this.grpBoxPageList.Name = "grpBoxPageList";
            this.grpBoxPageList.Size = new System.Drawing.Size(307, 186);
            this.grpBoxPageList.TabIndex = 1;
            this.grpBoxPageList.TabStop = false;
            this.grpBoxPageList.Text = "Image Group";
            // 
            // btnMoveLeftAll
            // 
            this.btnMoveLeftAll.Location = new System.Drawing.Point(133, 148);
            this.btnMoveLeftAll.Name = "btnMoveLeftAll";
            this.btnMoveLeftAll.Size = new System.Drawing.Size(36, 23);
            this.btnMoveLeftAll.TabIndex = 5;
            this.btnMoveLeftAll.Text = "<<";
            this.btnMoveLeftAll.UseVisualStyleBackColor = true;
            this.btnMoveLeftAll.Click += new System.EventHandler(this.btnMoveLeftAll_Click);
            // 
            // btnMoveRightAll
            // 
            this.btnMoveRightAll.Location = new System.Drawing.Point(133, 61);
            this.btnMoveRightAll.Name = "btnMoveRightAll";
            this.btnMoveRightAll.Size = new System.Drawing.Size(36, 23);
            this.btnMoveRightAll.TabIndex = 1;
            this.btnMoveRightAll.Text = ">>";
            this.btnMoveRightAll.UseVisualStyleBackColor = true;
            this.btnMoveRightAll.Click += new System.EventHandler(this.btnMoveRightAll_Click);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Location = new System.Drawing.Point(133, 119);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(36, 23);
            this.btnMoveLeft.TabIndex = 4;
            this.btnMoveLeft.Text = "<";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.btnMoveLeft_Click);
            // 
            // lstBoxForGrouping
            // 
            this.lstBoxForGrouping.FormattingEnabled = true;
            this.lstBoxForGrouping.Location = new System.Drawing.Point(175, 32);
            this.lstBoxForGrouping.Name = "lstBoxForGrouping";
            this.lstBoxForGrouping.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxForGrouping.Size = new System.Drawing.Size(120, 147);
            this.lstBoxForGrouping.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Group Pages :";
            // 
            // lstBoxPages
            // 
            this.lstBoxPages.FormattingEnabled = true;
            this.lstBoxPages.Location = new System.Drawing.Point(6, 32);
            this.lstBoxPages.Name = "lstBoxPages";
            this.lstBoxPages.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxPages.Size = new System.Drawing.Size(120, 147);
            this.lstBoxPages.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Image Pages :";
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Location = new System.Drawing.Point(133, 90);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(36, 23);
            this.btnMoveRight.TabIndex = 2;
            this.btnMoveRight.Text = ">";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.btnMoveRight_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateGroup.Location = new System.Drawing.Point(319, 681);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(120, 36);
            this.btnCreateGroup.TabIndex = 4;
            this.btnCreateGroup.Text = "&Create Batch for these pages";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Scac";
            this.dataGridViewTextBoxColumn2.HeaderText = "Scac";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "City/State";
            this.dataGridViewTextBoxColumn3.HeaderText = "City/State";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 308);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Image Issue :";
            // 
            // txtImageIssue
            // 
            this.txtImageIssue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImageIssue.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtImageIssue.Location = new System.Drawing.Point(86, 305);
            this.txtImageIssue.MaxLength = 250;
            this.txtImageIssue.Name = "txtImageIssue";
            this.txtImageIssue.Size = new System.Drawing.Size(341, 20);
            this.txtImageIssue.TabIndex = 26;
            // 
            // frmVirtualMailRoomBatchSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 726);
            this.Controls.Add(this.grpBoxData);
            this.Controls.Add(this.grpBoxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 736);
            this.Name = "frmVirtualMailRoomBatchSolution";
            this.Text = "Virtual Mail Room Batch Creation";
            this.Load += new System.EventHandler(this.frmVirtualMailRoom_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVirtualMailRoomBatchSolution_FormClosing);
            this.grpBoxImage.ResumeLayout(false);
            this.grpBoxData.ResumeLayout(false);
            this.grpBoxData.PerformLayout();
            this.grpBoxImageControl.ResumeLayout(false);
            this.grpBoxImageControl.PerformLayout();
            this.grpBoxGrouping.ResumeLayout(false);
            this.grpBoxGrouping.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCAC)).EndInit();
            this.grpBoxImageNavigation.ResumeLayout(false);
            this.grpBoxImageNavigation.PerformLayout();
            this.grpBoxPageList.ResumeLayout(false);
            this.grpBoxPageList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdOpenImageFile;
        private System.Windows.Forms.GroupBox grpBoxImage;
        private FormControls.TraxDEPictureBox pcbImage;
        private System.Windows.Forms.GroupBox grpBoxData;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.ListBox lstBoxForGrouping;
        private System.Windows.Forms.ListBox lstBoxPages;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpBoxPageList;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveRightAll;
        private System.Windows.Forms.Button btnMoveLeftAll;
        private System.Windows.Forms.GroupBox grpBoxGrouping;
        private System.Windows.Forms.ComboBox ddlClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView grdSCAC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpBoxImageNavigation;
        private System.Windows.Forms.TextBox txtFilePathName;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPageCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.Button btnInlude;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton_2;
        private System.Windows.Forms.RadioButton radioButton_4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRotateLeft;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.TextBox txtRotateDegree;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFBCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox grpBoxImageControl;
        private System.Windows.Forms.CheckBox chkBoxStamp;
        private System.Windows.Forms.RadioButton radioLA;
        private System.Windows.Forms.RadioButton radioAPAC;
        private System.Windows.Forms.RadioButton radioJPM;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCarrierName;
        private System.Windows.Forms.CheckBox chkBoxProduction;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtICS;
        private System.Windows.Forms.CheckBox chkBoxSplitBatch;
        private System.Windows.Forms.CheckBox chkBoxSplitPoint;
        private FormControls.TraxDEComboBox ddlPages;
        private FormControls.TraxDETextBox txtSplitFBCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radioNewBatch;
        private System.Windows.Forms.RadioButton radioReBatch;
        private FormControls.TraxDECheckBox chkBoxEphesoftDrop;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtImageIssue;
    }
}

