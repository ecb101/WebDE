using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmVirtualMailRoomQA : Form
    {
        private int page = 0;
        private int pageCount = 0;
        private VirtualMailRoomQABL.VirtualMailRoomQABL bl = new VirtualMailRoomQABL.VirtualMailRoomQABL();
        private CommonEnum.FormState currentFormState = CommonEnum.FormState.NORMAL_STATE;
        private DataSet ds = new DataSet();
        private DataSet dsBatches = new DataSet();
        private DataSet dsClient = new DataSet();
        private DataView dv = new DataView();
        private DataView dvBatches = new DataView();
        private ArrayList parameter = new ArrayList();
        private ArrayList stamp = new ArrayList();
        private Image imageFile;
        private int zoomFactor = 1;
        private int rotateDegree = 0;
        private Bitmap tempBitmap;
        private string MXXDatabase = string.Empty;
        private string MXXOwnerKey = string.Empty;
        private string MXXSCAC = string.Empty;
        //DataRow dr;
        FrameDimension frameDimensions;
        public frmVirtualMailRoomQA()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ofdOpenImageFile.InitialDirectory = ConfigurationManager.AppSettings["ImageDestinationPathQA"];            
        }

        #region Events
        private void frmVirtualMailRoomQA_Load(object sender, EventArgs e)
        {
            enableButton();            
            dsClient = bl.selectClient();
            populateParameter();
            ds = bl.selectSCAC();
            dsBatches = bl.selectBatches();
            bindDDL();            
            bindgrd();            
            bindgrdImageGroup();
            enableToolStripButtons(currentFormState);
        }
       
        private void txtFBCount_TextChanged(object sender, EventArgs e)
        {
            if (txtFBCount.Text.Trim() != "")
            {
                try
                {
                    if (Convert.ToInt32(txtFBCount.Text.Trim()) == 0)
                    {
                        throw new Exception();
                    }
                    enableButton();
                }
                catch
                {
                    txtFBCount.Text = txtFBCount.Text.Trim().Remove(txtFBCount.Text.Trim().Length - 1).Trim();
                    MessageBox.Show("Enter non zero integer value.", "Batching Quality Assurance");
                }
            }

        }

        private void txtFBCount_Leave(object sender, EventArgs e)
        {
            //if (txtFBCount.Text == string.Empty)
                //btnCreateGroup.Enabled = false;
        }

        private void frmVirtualMailRoomQA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnOpenFile.Enabled)
            {
                MessageBox.Show("There are some pages that are not yet batched, you cannot close this form yet.", "Batching Quality Assurance");
                e.Cancel = true;
            }
        }

        #region toolStrip
        private void toolStripButtonQA_Click(object sender, EventArgs e)
        {
            try
            {
                if (MXXDatabase != string.Empty && txtFilePathName.Text != string.Empty && CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 5) == MXXDatabase)
                {
                    if (bl.isAllowEdit(MXXDatabase))//if (bl.isAllowBatchStart(MXXDatabase) && bl.isAllowEdit(MXXDatabase))
                    {

                        //bl.auditTrailBatch(MXXDatabase, "102");
                        currentFormState = CommonEnum.FormState.EDIT_STATE;
                        enableToolStripButtons(currentFormState);

                    }
                    else
                        MessageBox.Show("This batch was started by a different user.", "Batching Quality Assurance");
                }
                else
                {
                    MessageBox.Show("Batch did not match the image. Could not proceed.", "Batching Quality Assurance");
                
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButtonValidate_Click(object sender, EventArgs e)
        {
            bool validate = false;
            if (getOwnerKey() != string.Empty && grdSCAC.SelectedRows.Count > 0 && txtFBCount.Text.Trim() != string.Empty)
            {
                validate = this.validate();
                string ownerKey = grdImageGroup.SelectedRows[0].Cells[2].Value.ToString();
                string scac = grdImageGroup.SelectedRows[0].Cells[3].Value.ToString();
                string fbCnt = grdImageGroup.SelectedRows[0].Cells[6].Value.ToString();
                if (validate == true ? MessageBox.Show("All information match. Do you wish to proceed?", "Batching Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.Yes : MessageBox.Show(string.Format("OwnerKey/SCAC/Fb_Cnt did not match.\nOriginal Batch Information:\nOwnerKey: {0}\nSCAC: {1}\nFB Count: {2}\nDo you wish to overwrite the original information?",ownerKey,scac,fbCnt), "Batching Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bl.updateBatch(grdImageGroup.SelectedRows[0].Cells[0].Value.ToString(), getOwnerKey(), grdSCAC.SelectedRows[0].Cells[1].Value.ToString(), txtFBCount.Text.Trim(), chkBoxProduction.Checked, txtCarrierName.Text.Trim(), txtICS.Text.Trim(), txtFilePathName.Text.Trim(), grdSCAC.SelectedRows[0].Cells[0].Value.ToString(), System.Environment.UserName, System.Environment.MachineName);
                    MessageBox.Show("Validation successful.", "Batching Quality Assurance");
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    enableToolStripButtons(currentFormState);
                    clearControls();
                    setDefaultValues();
                    dsBatches = bl.selectBatches();
                    bindgrdImageGroup();
                }
                else
                {
                    
                    if (validate == false && MessageBox.Show(string.Format("Do you wish to deactivate this batch?", ownerKey, scac, fbCnt), "Batching Quality Assurance", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (bl.deactivateBatch("FAILED BATCHING QA", MXXDatabase, System.Environment.UserName, System.Environment.MachineName))
                        {
                            MessageBox.Show("Deactivation successful.", "Batching Quality Assurance");
                            currentFormState = CommonEnum.FormState.NORMAL_STATE;
                            enableToolStripButtons(currentFormState);
                            clearControls();
                            setDefaultValues();
                            dsBatches = bl.selectBatches();
                            bindgrdImageGroup();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please pick Client, SCAC and input FB Count to proceed.", "Batching Quality Assurance");
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel all changes done?", "Cancel updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    bl.updateStatus(MXXDatabase, "QA BATCH");
                    //bl.auditTrailBatch(MXXDatabase, "104");
                    dsBatches = bl.selectBatches();
                    bindgrdImageGroup();
                    enableToolStripButtons(currentFormState);                    
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Image Navigation
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofdOpenImageFile.Filter = string.Format("TIFF files (*.tif)|{0}.tif", "*");
            ofdOpenImageFile.FileName = string.Empty;
            ofdOpenImageFile.ShowDialog();
        }

        private void ofdOpenImageFile_FileOk(object sender, CancelEventArgs e)
        {
            setDefaultValues();
            if (this.txtFilePathName.Text.Trim() != string.Empty)
            {                
                //bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "21");
            }
            if (ofdOpenImageFile.FileName != string.Empty && ofdOpenImageFile.FileName.Contains(ConfigurationManager.AppSettings["ImageDestinationPathQA"]) && getValidBackupFolderDate(ofdOpenImageFile.FileName))
            {             
                this.txtFilePathName.Text = ofdOpenImageFile.FileName;
                loadImage(page);
            }
            else
            {
                this.txtFilePathName.Text = string.Empty;
                if(pcbImage.Image != null)
                    clearControls();                
                MessageBox.Show("No valid image file is selected or failed to process files that are not in the for backup batched folder.", "Batching Quality Assurance");
            }            
            //bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "20");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            page++;
            loadImage(page);            
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            page--;
            loadImage(page);            
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            page = 0;
            loadImage(page);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            page = Convert.ToInt32(txtPageCount.Text) - 1;
            loadImage(page);
        }

        private void grdImageGroup_SelectionChanged(object sender, EventArgs e)
        {
            populateBatchParameter();
        }

        private void txtSearchBatch_TextChanged(object sender, EventArgs e)
        {
            bindgrdImageGroup();
        }
        #endregion        

        #region Image Control
        private void btnRotateLeft_Click(object sender, EventArgs e)
        {
            if (rotateDegree != 270)
                rotateDegree = rotateDegree + 90;
            else
                rotateDegree = 0;

            zoomRotateImage(zoomFactor);
            txtRotateDegree.Text = rotateDegree.ToString();
        }

        private void btnRotateRight_Click(object sender, EventArgs e)
        {
            if (rotateDegree != 0)
                rotateDegree = rotateDegree - 90;
            else
                rotateDegree = 270;

            zoomRotateImage(zoomFactor);
            txtRotateDegree.Text = rotateDegree.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (pcbImage.Image != null)
                {
                    zoomRotateImage(1);
                    zoomFactor = 1;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                zoomRotateImage(2);
                zoomFactor = 2;
            }
        }

        private void radioButton_2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_2.Checked)
            {
                zoomRotateImage(-2);
                zoomFactor = -2;
            }
        }

        private void radioButton_4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_4.Checked)
            {
                zoomRotateImage(-4);
                zoomFactor = -4;
            }
        }

        #endregion

        #region Grouping
        private void ddlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateParameter();
            bindgrd();
        }

        private void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateParameter();
            bindgrd();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrd();
        }

        private void grdSCAC_SelectionChanged(object sender, EventArgs e)
        {
            if (grdSCAC.Rows.Count > 0 && grdSCAC.SelectedRows.Count > 0 && grdSCAC.Rows[grdSCAC.SelectedRows[0].Index].Cells[1].Value.ToString().Trim() == "NOSCAC")
            {
                txtCarrierName.Clear();
                txtCarrierName.Enabled = true;
            }
            else
            {
                txtCarrierName.Clear();
                txtCarrierName.Enabled = false;
            }
        }

        private void ddlClient_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Back)
            //{
            //    enableButton();
            //    return;
            //}
            //if (ddlClient.Text != "")
            //{
            //    string matchText = ddlClient.Text;
            //    int match = ddlClient.FindString(matchText);
            //    if (match != -1)
            //    {
            //        ddlClient.SelectedIndex = match;
            //        ddlClient.SelectionStart = matchText.Length;
            //        ddlClient.SelectionLength = ddlClient.Text.Length - ddlClient.SelectionStart;
            //        ddlClient.SelectedValue = ((DataRowView)ddlClient.Items[ddlClient.SelectedIndex])[0].ToString();
            //    }
            //    else
            //    {
            //        ddlClient.SelectedValue = "";
            //    }
            //}
            //else
            //{
            //    ddlClient.SelectedIndex = -1;
            //    ddlClient.SelectedValue = "";
            //}
            enableButton();
        }
        #endregion        
        #endregion

        #region Developer Designed method
        private void clearControls()
        {
            pcbImage.Image.Dispose();
            pcbImage.Image = null;
            pcbImage.Refresh();            
            txtFilePathName.Clear();
            txtPageCount.Clear();
            txtPageNumber.Clear();
            txtFBCount.Clear();
            imageFile.Dispose();
            tempBitmap.Dispose();
            frameDimensions = null;
            this.Refresh();
        }

        private void setDefaultValues()
        {
            page = 0;
            pageCount = 0;
            zoomFactor = 1;
            rotateDegree = 0;            
            radioButton1.Checked = true;            
            imageFile = null;
            tempBitmap = null;            
        }

        private void loadImage(int pageNumber)
        {
            if (txtFilePathName.Text != string.Empty)
            {                
                imageFile = Image.FromFile(txtFilePathName.Text,true);
                frameDimensions = new FrameDimension(imageFile.FrameDimensionsList[0]);
                pageCount = imageFile.GetFrameCount(frameDimensions);
                imageFile.SelectActiveFrame(frameDimensions, pageNumber);
                zoomRotateImage(zoomFactor);
                this.txtPageCount.Text = pageCount.ToString();
                this.txtPageNumber.Text = (page + 1).ToString();
                enableButton();
            }            
        }

        private void enableButton()
        {
            if (page <= 0)
            {
                this.btnPrev.Enabled = false;
            }
            else
            {
                this.btnPrev.Enabled = true;
            }

            if (page + 1 == pageCount || pageCount == 0)
            {
                this.btnNext.Enabled = false;
            }
            else
            {
                this.btnNext.Enabled = true;
            }
            if (pcbImage.Image == null)
            {
                radioButton1.Checked = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;                
                radioButton_2.Enabled = false;
                radioButton_4.Enabled = false;
                btnRotateLeft.Enabled = false;
                btnRotateRight.Enabled = false;
                btnFirst.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton_2.Enabled = true;
                radioButton_4.Enabled = true;
                btnRotateLeft.Enabled = true;
                btnRotateRight.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
            }            
            //btnCreateGroup.Enabled = pcbImage.Image == null ? false : true && txtFBCount.Text.Trim() == string.Empty ? false : true && getOwnerKey() == "" ? false : true;
        }
        
        private void populateStampList()
        {
            stamp.Clear();
            for(int i=1;i<=pageCount;i++)
                stamp.Add(new ImageStamp(i,false));
        }       
        
        private void bindDDL()
        {            
            this.ddlClient.DisplayMember = "Client";
            this.ddlClient.ValueMember = "Client";
            this.ddlClient.DataSource = dsClient.Tables[0];            
            this.ddlClient.Refresh();
        }

        private void populateParameter()
        {
            parameter.Clear();
            parameter.Add(getOwnerKey());
        }

        private void bindgrd()
        {            
            dv.Table = ds.Tables[0];
            this.dv.RowFilter = string.Format("TRIM(OwnerKey) = '{0}' AND TRIM(Mode) = '{1}' AND TRIM([City/State]) LIKE '%{2}%' ", getOwnerKey(), ddlMode.SelectedItem == null ? string.Empty : ddlMode.SelectedItem, this.txtSearch.Text.Trim());
            this.grdSCAC.DataSource = dv;
            this.grdSCAC.AutoResizeColumns();
            this.grdSCAC.Refresh();
        }

        private void bindgrdImageGroup()
        {
            dvBatches.Table = dsBatches.Tables[0];
            this.dvBatches.RowFilter = string.Format("[Batch Number] LIKE '{0}%'", this.txtSearchBatch.Text.Trim());
            this.grdImageGroup.DataSource = dvBatches;
            this.grdImageGroup.Refresh();
        }

        private string getOwnerKey()
        {
            string[] retval;
            if (this.ddlClient.SelectedValue != null)
                retval = this.ddlClient.SelectedValue.ToString().Split('(');
            else
                return "";
            return retval[retval.Length - 1].Trim(')');
        }

        private void zoomRotateImage(int zoomFactor)
        {
            int width = imageFile.Width;
            int height = imageFile.Height;            
            if (zoomFactor < 1)
            {
                width = imageFile.Width / Math.Abs(zoomFactor);
                height = imageFile.Height / Math.Abs(zoomFactor);
            }
            else
            {
                width = imageFile.Width * zoomFactor;
                height = imageFile.Height * zoomFactor;
            }            
            tempBitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);            
            Graphics bmGraphics = Graphics.FromImage(tempBitmap);            
            bmGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            bmGraphics.DrawImage(imageFile, new Rectangle(0, 0, width, height), new Rectangle(0, 0, imageFile.Width, imageFile.Height), GraphicsUnit.Pixel);
            bmGraphics.Dispose();
            bmGraphics = null;

            if(rotateDegree == 90)
                tempBitmap.RotateFlip(RotateFlipType.Rotate90FlipXY);
            else if (rotateDegree == 180)
                tempBitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);                
            else if (rotateDegree == 270)            
                tempBitmap.RotateFlip(RotateFlipType.Rotate270FlipXY);                
            pcbImage.Image = tempBitmap;
        }

        public bool getValidBackupFolderDate(string filename)
        {
            string[] file = filename.Split('\\');
            DateTime folderDate;
            bool retval = true;
            string date = file[file.Length - 2];
            try
            {
                try
                {
                    folderDate = Convert.ToDateTime(date.Insert(2, "/").Insert(5, "/"));                    
                }
                catch
                {
                    throw new Exception("Invalid backup folder date.");
                }
                if (bl.GetServerDate().AddMonths(-3) > folderDate)
                    throw new Exception("The image file is located in an old backup folder, this might be a recycled image");
            }
            catch (Exception e)
            {
                retval = false;
                MessageBox.Show(e.Message, "Virtual Mailroom QA");
            }
            return retval;
        }

        private void enableToolStripButtons(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        toolStripButtonQA.Enabled = true;
                        toolStripButtonValidate.Enabled = false;                        
                        toolStripButtonCancel.Enabled = false;                        
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        toolStripButtonQA.Enabled = false;
                        toolStripButtonValidate.Enabled = true;                        
                        toolStripButtonCancel.Enabled = true;
                        break;
                    }
            }
            enableStateControls(currentFormState);
        }

        private void enableStateControls(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        grdImageGroup.Enabled = true;
                        txtSearchBatch.Enabled = true;
                        btnOpenFile.Enabled = true;
                        btnRefresh.Enabled = true;
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        grdImageGroup.Enabled = false;
                        txtSearchBatch.Enabled = false;
                        btnOpenFile.Enabled = false;
                        btnRefresh.Enabled = false;
                        break;
                    }
            }
        }

        private void populateBatchParameter()
        {
            MXXDatabase = string.Empty;
            MXXOwnerKey = string.Empty;
            MXXSCAC = string.Empty;
            if (this.grdImageGroup.Rows.Count > 0 && this.grdImageGroup.SelectedRows.Count > 0)
            {
                MXXDatabase = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["BatchNumber"].Value.ToString();
                MXXOwnerKey = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString();
                MXXSCAC = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["VendSCAC"].Value.ToString();                
            }
        }

        private bool validate()
        {
            bool retval = false;
            string ownerKey = grdImageGroup.SelectedRows[0].Cells[2].Value.ToString();
            string scac = grdImageGroup.SelectedRows[0].Cells[3].Value.ToString();
            string fbCnt = grdImageGroup.SelectedRows[0].Cells[6].Value.ToString();
            if (getOwnerKey() != ownerKey)
            {
                retval = false;
            }
            else if (grdSCAC.SelectedRows[0].Cells[1].Value.ToString() != scac)
            {
                retval = false;
            }
            else if (txtFBCount.Text.Trim() != fbCnt)
            {
                retval = false;
            }
            else
                retval = true;
            return retval;
        }
        #endregion
    }
}
