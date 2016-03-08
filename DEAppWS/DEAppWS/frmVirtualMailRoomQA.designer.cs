namespace DEAppWS
{
    partial class frmVirtualMailRoomQA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVirtualMailRoomQA));
            this.ofdOpenImageFile = new System.Windows.Forms.OpenFileDialog();
            this.grpBoxImage = new System.Windows.Forms.GroupBox();
            this.pcbImage = new FormControls.TraxDEPictureBox();
            this.grpBoxData = new System.Windows.Forms.GroupBox();
            this.chkBoxProduction = new System.Windows.Forms.CheckBox();
            this.grpBoxImageControl = new System.Windows.Forms.GroupBox();
            this.txtRotateDegree = new System.Windows.Forms.TextBox();
            this.radioButton_4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnRotateLeft = new System.Windows.Forms.Button();
            this.btnRotateRight = new System.Windows.Forms.Button();
            this.label9 = new FormControls.TraxDELabel();
            this.radioButton_2 = new System.Windows.Forms.RadioButton();
            this.label7 = new FormControls.TraxDELabel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label10 = new FormControls.TraxDELabel();
            this.txtFBCount = new System.Windows.Forms.TextBox();
            this.grpBoxGrouping = new System.Windows.Forms.GroupBox();
            this.lblMode = new FormControls.TraxDELabel();
            this.ddlMode = new FormControls.TraxDEComboBox();
            this.label12 = new FormControls.TraxDELabel();
            this.txtICS = new System.Windows.Forms.TextBox();
            this.label11 = new FormControls.TraxDELabel();
            this.txtCarrierName = new System.Windows.Forms.TextBox();
            this.label8 = new FormControls.TraxDELabel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ddlClient = new System.Windows.Forms.ComboBox();
            this.label6 = new FormControls.TraxDELabel();
            this.grdSCAC = new System.Windows.Forms.DataGridView();
            this.OwnerKeyGrid = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.label5 = new FormControls.TraxDELabel();
            this.grpBoxImageNavigation = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearchBatch = new FormControls.TraxDETextBox();
            this.lblSearch = new FormControls.TraxDELabel();
            this.grdImageGroup = new FormControls.TraxDEDataGridView();
            this.BatchNumber = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.BatchStatus = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.OwnerKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendSCAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.OwnerCode = new FormControls.TraxDEDataGridViewTextBoxColumn();
            this.Fb_Cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.txtFilePathName = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label2 = new FormControls.TraxDELabel();
            this.txtPageCount = new System.Windows.Forms.TextBox();
            this.label1 = new FormControls.TraxDELabel();
            this.txtPageNumber = new System.Windows.Forms.TextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonQA = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonValidate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCancel = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoxImage.SuspendLayout();
            this.grpBoxData.SuspendLayout();
            this.grpBoxImageControl.SuspendLayout();
            this.grpBoxGrouping.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSCAC)).BeginInit();
            this.grpBoxImageNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).BeginInit();
            this.toolStrip.SuspendLayout();
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
            this.grpBoxImage.Location = new System.Drawing.Point(12, 28);
            this.grpBoxImage.Name = "grpBoxImage";
            this.grpBoxImage.Size = new System.Drawing.Size(717, 719);
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
            this.pcbImage.Size = new System.Drawing.Size(711, 700);
            this.pcbImage.TabIndex = 0;
            // 
            // grpBoxData
            // 
            this.grpBoxData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxData.Controls.Add(this.chkBoxProduction);
            this.grpBoxData.Controls.Add(this.grpBoxImageControl);
            this.grpBoxData.Controls.Add(this.label10);
            this.grpBoxData.Controls.Add(this.txtFBCount);
            this.grpBoxData.Controls.Add(this.grpBoxGrouping);
            this.grpBoxData.Controls.Add(this.grpBoxImageNavigation);
            this.grpBoxData.Location = new System.Drawing.Point(735, 28);
            this.grpBoxData.Name = "grpBoxData";
            this.grpBoxData.Size = new System.Drawing.Size(445, 719);
            this.grpBoxData.TabIndex = 1;
            this.grpBoxData.TabStop = false;
            // 
            // chkBoxProduction
            // 
            this.chkBoxProduction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBoxProduction.AutoSize = true;
            this.chkBoxProduction.Checked = true;
            this.chkBoxProduction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxProduction.Location = new System.Drawing.Point(362, 696);
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
            this.grpBoxImageControl.Location = new System.Drawing.Point(334, 13);
            this.grpBoxImageControl.Name = "grpBoxImageControl";
            this.grpBoxImageControl.Size = new System.Drawing.Size(99, 203);
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
            this.btnRotateLeft.Location = new System.Drawing.Point(9, 40);
            this.btnRotateLeft.Name = "btnRotateLeft";
            this.btnRotateLeft.Size = new System.Drawing.Size(40, 23);
            this.btnRotateLeft.TabIndex = 0;
            this.btnRotateLeft.Text = "Left";
            this.btnRotateLeft.UseVisualStyleBackColor = true;
            this.btnRotateLeft.Click += new System.EventHandler(this.btnRotateLeft_Click);
            // 
            // btnRotateRight
            // 
            this.btnRotateRight.Location = new System.Drawing.Point(55, 40);
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
            this.label10.Location = new System.Drawing.Point(6, 696);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "FB Count :";
            // 
            // txtFBCount
            // 
            this.txtFBCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFBCount.Location = new System.Drawing.Point(69, 693);
            this.txtFBCount.Name = "txtFBCount";
            this.txtFBCount.Size = new System.Drawing.Size(99, 20);
            this.txtFBCount.TabIndex = 3;
            this.txtFBCount.TextChanged += new System.EventHandler(this.txtFBCount_TextChanged);
            this.txtFBCount.Leave += new System.EventHandler(this.txtFBCount_Leave);
            // 
            // grpBoxGrouping
            // 
            this.grpBoxGrouping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxGrouping.Controls.Add(this.lblMode);
            this.grpBoxGrouping.Controls.Add(this.ddlMode);
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
            this.grpBoxGrouping.Location = new System.Drawing.Point(6, 222);
            this.grpBoxGrouping.Name = "grpBoxGrouping";
            this.grpBoxGrouping.Size = new System.Drawing.Size(433, 465);
            this.grpBoxGrouping.TabIndex = 2;
            this.grpBoxGrouping.TabStop = false;
            this.grpBoxGrouping.Text = "Grouping";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(6, 49);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(40, 13);
            this.lblMode.TabIndex = 27;
            this.lblMode.Text = "Mode :";
            // 
            // ddlMode
            // 
            this.ddlMode.DatabaseFieldLink = null;
            this.ddlMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlMode.FormattingEnabled = true;
            this.ddlMode.Items.AddRange(new object[] {
            "",
            "3PL",
            "AIR FREIGHT",
            "BULK",
            "COURIER",
            "INTERNATIONAL",
            "LOGISTICS",
            "LTL",
            "MILKRUN",
            "NOT BaFB",
            "NOT FB",
            "OCEAN",
            "PARCEL",
            "RAIL",
            "REFUND",
            "TRUCKLOAD"});
            this.ddlMode.Location = new System.Drawing.Point(51, 46);
            this.ddlMode.Name = "ddlMode";
            this.ddlMode.Size = new System.Drawing.Size(376, 21);
            this.ddlMode.TabIndex = 1;
            this.ddlMode.SelectedIndexChanged += new System.EventHandler(this.ddlMode_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 444);
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
            this.txtICS.Location = new System.Drawing.Point(86, 441);
            this.txtICS.MaxLength = 255;
            this.txtICS.Name = "txtICS";
            this.txtICS.Size = new System.Drawing.Size(341, 20);
            this.txtICS.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 418);
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
            this.txtCarrierName.Location = new System.Drawing.Point(86, 415);
            this.txtCarrierName.Name = "txtCarrierName";
            this.txtCarrierName.Size = new System.Drawing.Size(341, 20);
            this.txtCarrierName.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Remit City/State :";
            // 
            // txtSearch
            // 
            this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearch.Location = new System.Drawing.Point(102, 73);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(325, 20);
            this.txtSearch.TabIndex = 2;
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
            this.label6.Location = new System.Drawing.Point(6, 103);
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
            this.grdSCAC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OwnerKeyGrid,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Mode});
            this.grdSCAC.Location = new System.Drawing.Point(6, 119);
            this.grdSCAC.MultiSelect = false;
            this.grdSCAC.Name = "grdSCAC";
            this.grdSCAC.ReadOnly = true;
            this.grdSCAC.RowHeadersVisible = false;
            this.grdSCAC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSCAC.Size = new System.Drawing.Size(421, 290);
            this.grdSCAC.StandardTab = true;
            this.grdSCAC.TabIndex = 3;
            this.grdSCAC.SelectionChanged += new System.EventHandler(this.grdSCAC_SelectionChanged);
            // 
            // OwnerKeyGrid
            // 
            this.OwnerKeyGrid.DataPropertyName = "OwnerKey";
            this.OwnerKeyGrid.HeaderText = "OwnerKey";
            this.OwnerKeyGrid.Name = "OwnerKeyGrid";
            this.OwnerKeyGrid.ReadOnly = true;
            this.OwnerKeyGrid.Visible = false;
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
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "Scac";
            this.Column2.HeaderText = "Scac";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "City/State";
            this.Column3.HeaderText = "City/State";
            this.Column3.MinimumWidth = 80;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 80;
            // 
            // Mode
            // 
            this.Mode.DataPropertyName = "Mode";
            this.Mode.HeaderText = "Mode";
            this.Mode.Name = "Mode";
            this.Mode.ReadOnly = true;
            this.Mode.Visible = false;
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
            this.grpBoxImageNavigation.Controls.Add(this.btnRefresh);
            this.grpBoxImageNavigation.Controls.Add(this.txtSearchBatch);
            this.grpBoxImageNavigation.Controls.Add(this.lblSearch);
            this.grpBoxImageNavigation.Controls.Add(this.grdImageGroup);
            this.grpBoxImageNavigation.Controls.Add(this.btnLast);
            this.grpBoxImageNavigation.Controls.Add(this.btnFirst);
            this.grpBoxImageNavigation.Controls.Add(this.txtFilePathName);
            this.grpBoxImageNavigation.Controls.Add(this.btnOpenFile);
            this.grpBoxImageNavigation.Controls.Add(this.btnPrev);
            this.grpBoxImageNavigation.Controls.Add(this.btnNext);
            this.grpBoxImageNavigation.Controls.Add(this.label2);
            this.grpBoxImageNavigation.Controls.Add(this.txtPageCount);
            this.grpBoxImageNavigation.Controls.Add(this.label1);
            this.grpBoxImageNavigation.Controls.Add(this.txtPageNumber);
            this.grpBoxImageNavigation.Location = new System.Drawing.Point(6, 13);
            this.grpBoxImageNavigation.Name = "grpBoxImageNavigation";
            this.grpBoxImageNavigation.Size = new System.Drawing.Size(322, 203);
            this.grpBoxImageNavigation.TabIndex = 0;
            this.grpBoxImageNavigation.TabStop = false;
            this.grpBoxImageNavigation.Text = "Image Navigation";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(241, 40);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // txtSearchBatch
            // 
            this.txtSearchBatch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchBatch.DatabaseFieldLink = null;
            this.txtSearchBatch.Location = new System.Drawing.Point(201, 14);
            this.txtSearchBatch.Name = "txtSearchBatch";
            this.txtSearchBatch.Size = new System.Drawing.Size(115, 20);
            this.txtSearchBatch.TabIndex = 15;
            this.txtSearchBatch.ValueType = CommonLibrary.CommonEnum.ValueType.ALL;
            this.txtSearchBatch.TextChanged += new System.EventHandler(this.txtSearchBatch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(148, 17);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 13);
            this.lblSearch.TabIndex = 14;
            this.lblSearch.Text = "Search :";
            // 
            // grdImageGroup
            // 
            this.grdImageGroup.AllowUserToAddRows = false;
            this.grdImageGroup.AllowUserToDeleteRows = false;
            this.grdImageGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdImageGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdImageGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BatchNumber,
            this.BatchStatus,
            this.OwnerKey,
            this.VendSCAC,
            this.Operator,
            this.OwnerCode,
            this.Fb_Cnt});
            this.grdImageGroup.Location = new System.Drawing.Point(6, 14);
            this.grdImageGroup.MultiSelect = false;
            this.grdImageGroup.Name = "grdImageGroup";
            this.grdImageGroup.ReadOnly = true;
            this.grdImageGroup.RowHeadersVisible = false;
            this.grdImageGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdImageGroup.Size = new System.Drawing.Size(132, 154);
            this.grdImageGroup.StandardTab = true;
            this.grdImageGroup.TabIndex = 16;
            this.grdImageGroup.SelectionChanged += new System.EventHandler(this.grdImageGroup_SelectionChanged);
            // 
            // BatchNumber
            // 
            this.BatchNumber.DataPropertyName = "Batch Number";
            this.BatchNumber.HeaderText = "Batch";
            this.BatchNumber.Name = "BatchNumber";
            this.BatchNumber.ReadOnly = true;
            this.BatchNumber.Width = 50;
            // 
            // BatchStatus
            // 
            this.BatchStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BatchStatus.DataPropertyName = "Batch Status";
            this.BatchStatus.HeaderText = "Status";
            this.BatchStatus.MinimumWidth = 60;
            this.BatchStatus.Name = "BatchStatus";
            this.BatchStatus.ReadOnly = true;
            // 
            // OwnerKey
            // 
            this.OwnerKey.DataPropertyName = "Owner Key";
            this.OwnerKey.HeaderText = "OwnerKey";
            this.OwnerKey.Name = "OwnerKey";
            this.OwnerKey.ReadOnly = true;
            this.OwnerKey.Visible = false;
            // 
            // VendSCAC
            // 
            this.VendSCAC.DataPropertyName = "Vendor SCAC";
            this.VendSCAC.HeaderText = "SCAC";
            this.VendSCAC.Name = "VendSCAC";
            this.VendSCAC.ReadOnly = true;
            this.VendSCAC.Visible = false;
            this.VendSCAC.Width = 70;
            // 
            // Operator
            // 
            this.Operator.DataPropertyName = "Operator";
            this.Operator.HeaderText = "Operator";
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            this.Operator.Visible = false;
            // 
            // OwnerCode
            // 
            this.OwnerCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OwnerCode.DataPropertyName = "OwnerCode";
            this.OwnerCode.HeaderText = "Client";
            this.OwnerCode.Name = "OwnerCode";
            this.OwnerCode.ReadOnly = true;
            this.OwnerCode.Visible = false;
            // 
            // Fb_Cnt
            // 
            this.Fb_Cnt.DataPropertyName = "Fb_Cnt";
            this.Fb_Cnt.HeaderText = "Fb_Cnt";
            this.Fb_Cnt.Name = "Fb_Cnt";
            this.Fb_Cnt.ReadOnly = true;
            this.Fb_Cnt.Visible = false;
            // 
            // btnLast
            // 
            this.btnLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLast.Location = new System.Drawing.Point(175, 174);
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
            this.btnFirst.Location = new System.Drawing.Point(6, 174);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(39, 23);
            this.btnFirst.TabIndex = 12;
            this.btnFirst.Text = "First";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // txtFilePathName
            // 
            this.txtFilePathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePathName.Location = new System.Drawing.Point(144, 69);
            this.txtFilePathName.Name = "txtFilePathName";
            this.txtFilePathName.ReadOnly = true;
            this.txtFilePathName.Size = new System.Drawing.Size(172, 20);
            this.txtFilePathName.TabIndex = 1;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(144, 40);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "&Open File";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(51, 174);
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
            this.btnNext.Location = new System.Drawing.Point(113, 174);
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
            this.label2.Location = new System.Drawing.Point(144, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Page Count :";
            // 
            // txtPageCount
            // 
            this.txtPageCount.Location = new System.Drawing.Point(226, 95);
            this.txtPageCount.Name = "txtPageCount";
            this.txtPageCount.ReadOnly = true;
            this.txtPageCount.Size = new System.Drawing.Size(49, 20);
            this.txtPageCount.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Current Page :";
            // 
            // txtPageNumber
            // 
            this.txtPageNumber.Location = new System.Drawing.Point(226, 121);
            this.txtPageNumber.Name = "txtPageNumber";
            this.txtPageNumber.ReadOnly = true;
            this.txtPageNumber.Size = new System.Drawing.Size(49, 20);
            this.txtPageNumber.TabIndex = 11;
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonQA,
            this.toolStripSeparator1,
            this.toolStripButtonValidate,
            this.toolStripSeparator2,
            this.toolStripButtonCancel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1192, 25);
            this.toolStrip.TabIndex = 3;
            // 
            // toolStripButtonQA
            // 
            this.toolStripButtonQA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonQA.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonQA.Image")));
            this.toolStripButtonQA.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonQA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQA.Name = "toolStripButtonQA";
            this.toolStripButtonQA.Size = new System.Drawing.Size(56, 22);
            this.toolStripButtonQA.Text = "&QA Batch";
            this.toolStripButtonQA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonQA.ToolTipText = "Start Data Entry for a Batch";
            this.toolStripButtonQA.Click += new System.EventHandler(this.toolStripButtonQA_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonValidate
            // 
            this.toolStripButtonValidate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonValidate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonValidate.Image")));
            this.toolStripButtonValidate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonValidate.Name = "toolStripButtonValidate";
            this.toolStripButtonValidate.Size = new System.Drawing.Size(49, 22);
            this.toolStripButtonValidate.Text = "&Validate";
            this.toolStripButtonValidate.Click += new System.EventHandler(this.toolStripButtonValidate_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCancel
            // 
            this.toolStripButtonCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCancel.Image")));
            this.toolStripButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCancel.Name = "toolStripButtonCancel";
            this.toolStripButtonCancel.Size = new System.Drawing.Size(43, 22);
            this.toolStripButtonCancel.Text = "&Cancel";
            this.toolStripButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonCancel.ToolTipText = "Cancel Updates";
            this.toolStripButtonCancel.Click += new System.EventHandler(this.toolStripButtonCancel_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Scac";
            this.dataGridViewTextBoxColumn2.HeaderText = "Scac";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "City/State";
            this.dataGridViewTextBoxColumn3.HeaderText = "City/State";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // frmVirtualMailRoomQA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 754);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.grpBoxData);
            this.Controls.Add(this.grpBoxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1200, 760);
            this.Name = "frmVirtualMailRoomQA";
            this.Text = "Virtual Mail Room Batch QA";
            this.Load += new System.EventHandler(this.frmVirtualMailRoomQA_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVirtualMailRoomQA_FormClosing);
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
            ((System.ComponentModel.ISupportInitialize)(this.grdImageGroup)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdOpenImageFile;
        private System.Windows.Forms.GroupBox grpBoxImage;
        private FormControls.TraxDEPictureBox pcbImage;
        private System.Windows.Forms.GroupBox grpBoxData;
        private System.Windows.Forms.GroupBox grpBoxGrouping;
        private System.Windows.Forms.ComboBox ddlClient;
        private FormControls.TraxDELabel label6;
        private System.Windows.Forms.DataGridView grdSCAC;
        private FormControls.TraxDELabel label5;
        private System.Windows.Forms.GroupBox grpBoxImageNavigation;
        private System.Windows.Forms.TextBox txtFilePathName;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private FormControls.TraxDELabel label2;
        private System.Windows.Forms.TextBox txtPageCount;
        private FormControls.TraxDELabel label1;
        private System.Windows.Forms.TextBox txtPageNumber;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton_2;
        private System.Windows.Forms.RadioButton radioButton_4;
        private FormControls.TraxDELabel label7;
        private FormControls.TraxDELabel label8;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRotateLeft;
        private FormControls.TraxDELabel label9;
        private System.Windows.Forms.Button btnRotateRight;
        private System.Windows.Forms.TextBox txtRotateDegree;
        private FormControls.TraxDELabel label10;
        private System.Windows.Forms.TextBox txtFBCount;
        private System.Windows.Forms.GroupBox grpBoxImageControl;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private FormControls.TraxDELabel label11;
        private System.Windows.Forms.TextBox txtCarrierName;
        private System.Windows.Forms.CheckBox chkBoxProduction;
        private FormControls.TraxDELabel label12;
        private System.Windows.Forms.TextBox txtICS;
        private System.Windows.Forms.Button btnRefresh;
        private FormControls.TraxDETextBox txtSearchBatch;
        private FormControls.TraxDELabel lblSearch;
        private FormControls.TraxDEDataGridView grdImageGroup;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonQA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonValidate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCancel;
        private FormControls.TraxDELabel lblMode;
        private FormControls.TraxDEComboBox ddlMode;
        private FormControls.TraxDEDataGridViewTextBoxColumn OwnerKeyGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private FormControls.TraxDEDataGridViewTextBoxColumn Mode;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchNumber;
        private FormControls.TraxDEDataGridViewTextBoxColumn BatchStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendSCAC;
        private FormControls.TraxDEDataGridViewTextBoxColumn Operator;
        private FormControls.TraxDEDataGridViewTextBoxColumn OwnerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fb_Cnt;
    }
}

