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
//using BLogic;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmVirtualMailRoomBatchSolution : Form
    {
        private int page = 0;
        private int pageCount = 0;
        private VirtualMailRoomBatchSolutionBL.VirtualMailRoomBatchSolutionBL bl = new VirtualMailRoomBatchSolutionBL.VirtualMailRoomBatchSolutionBL();
        private DataSet ds = new DataSet();
        private DataSet dsClient = new DataSet();
        private DataView dv = new DataView();
        private ArrayList parameter = new ArrayList();
        private ArrayList stamp = new ArrayList();
        private ArrayList splitPoint = new ArrayList();
        private Image imageFile;
        private int zoomFactor = 1;
        private int rotateDegree = 0;
        private Bitmap tempBitmap;
        //DataRow dr;
        FrameDimension frameDimensions;
        public frmVirtualMailRoomBatchSolution()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            ofdOpenImageFile.InitialDirectory = ConfigurationManager.AppSettings["ImageSourcePath"];
            //dr = getRowStructureHeaderPage();
        }

        #region Events
        private void frmVirtualMailRoom_Load(object sender, EventArgs e)
        {
            enableButton();
            dsClient = bl.selectClient();
            bindDDL();
            populateParameter();
            ds = bl.selectSCAC(parameter);
            bindgrd();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ArrayList pages = new ArrayList();
            try
            {           
                if (bl.isAllowedBatching())
                {
                    if (txtICS.Text.Trim() != string.Empty)
                    {
                        string text = string.Empty;
                        if (radioAPAC.Checked)
                            text = "TRAX TECH APAC";
                        else if (radioLA.Checked)
                            text = "TRAX TECH LA";
                        else if (radioJPM.Checked)
                            text = "J P M";

                        foreach (object page in lstBoxForGrouping.Items)
                        {
                            pages.Add(Convert.ToInt32(page.ToString()));
                        }
                        string batchID = string.Empty;
                        lstBoxForGrouping.Items.Clear();
                        bool createBatch = lstBoxForGrouping.Items.Count + lstBoxPages.Items.Count == 0;

                        //if (grdSCAC.SelectedRows[0].Cells[1].Value.ToString() != "NOSCAC")
//                        batchID = bl.createBatches(getOwnerKey(), grdSCAC.SelectedRows[0].Cells[1].Value.ToString(), txtFBCount.Text.Trim(), chkBoxProduction.Checked, txtCarrierName.Text, txtICS.Text.Trim(), txtFilePathName.Text.Trim(), this.imageFile, stamp, pages, text, grdSCAC.SelectedRows[0].Cells[0].Value.ToString(), chkBoxSplitBatch.Checked, splitPoint, chkBoxEphesoftDrop.Checked, txtImageIssue.Text.Trim(), System.Environment.UserName);
                        //else
                        //    batchID = bl.createBatchNOSCAC(getOwnerKey(), grdSCAC.SelectedRows[0].Cells[1].Value.ToString(), txtFBCount.Text.Trim(), chkBoxProduction.Checked, txtCarrierName.Text, txtICS.Text.Trim(), this.imageFile, stamp, pages, text, grdSCAC.SelectedRows[0].Cells[0].Value.ToString());
                        if (batchID.Trim() == string.Empty)
                        {
                            throw new Exception("There was an error during creation of the batch.");
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Image Creation Successful for batch {0}", batchID), "Virtual Mail Room");
                            bool isSplitBatch = chkBoxSplitBatch.Checked;
                            if (createBatch)
                            {
                                string file = txtFilePathName.Text;                                
                                clearControls();
                                setDefaultValues();
                                stamp.Clear();
                                bl.auditTrail(CommonMethod.getFileName(file).Substring(0, 8), "23", System.Environment.UserName);
                                if (!isSplitBatch)
                                    moveFiles(file, batchID);
                                else
                                {   
                                        foreach (object o in batchID.Split('\n'))
                                        {
                                            try
                                            {
                                                if(o.ToString().Trim().Length>0)
                                                    moveFiles(file, o.ToString());
                                            }
                                            catch { }
                                        }
                                }
                                MessageBox.Show("You have successfully group all pages of this image.", "Virtual Mail Room");
                            }
                            else
                            {
                                bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "22", System.Environment.UserName);
                                if (!isSplitBatch)
                                    bl.insertImagesBatched(txtFilePathName.Text, txtFilePathName.Text, batchID, false);
                                else
                                {
                                    foreach (object o in batchID.Split('\n'))
                                    {
                                        bl.insertImagesBatched(txtFilePathName.Text, txtFilePathName.Text, o.ToString(), false);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ICS field is empty.", "Virtual Mail Room");
                    }
                }
                else
                {
                    MessageBox.Show("No more reserved Batch Control Number available.\nMake some reservation.", "Virtual Mail Room");
                }
            }
            catch (Exception error)
            {
                foreach (object page in pages)
                {
                    lstBoxForGrouping.Items.Add(Convert.ToInt32(page));
                }
                CommonMethod.createErrorLog(error.Message);
                MessageBox.Show(error.Message, "Virtual Mail Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                enableButton();
            }
            this.Cursor = Cursors.Default;
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
                    MessageBox.Show("Enter non zero integer value.", "Virtual Mail Room");
                }
            }

        }

        private void txtFBCount_Leave(object sender, EventArgs e)
        {
            if (txtFBCount.Text == string.Empty)
                btnCreateGroup.Enabled = false;
        }

        private void frmVirtualMailRoomBatchSolution_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnOpenFile.Enabled)
            {
                MessageBox.Show("There are some pages that are not yet batched, you cannot close this form yet.", "Virtual Mail Room");
                e.Cancel = true;
            }
        }

        private void txtSplitFBCount_Validated(object sender, EventArgs e)
        {
            if (txtSplitFBCount.Text.Trim() != string.Empty)
                ((ImageStamp)splitPoint[Convert.ToInt32(page)]).SplitFBCount = Convert.ToInt32(txtSplitFBCount.Text);
        }

        #region Image Navigation
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (radioNewBatch.Checked)
            {
                ofdOpenImageFile.Filter = string.Format("TIFF files (*.tif)|{0}.tif", "*");
                ofdOpenImageFile.FileName = string.Empty;
                ofdOpenImageFile.ShowDialog();
                if (ofdOpenImageFile.FileName != string.Empty && ofdOpenImageFile.FileName.Contains(ConfigurationManager.AppSettings["ImageSourcePath"]))
                {
                    setDefaultValues();
                    loadImage(page);
                    populatePageList();
                    populateStampList();
                    populateSplitPointList();
                }
                else
                    MessageBox.Show("No file is selected or failed to process files that are not in the for batching folder.", "Virtual Mail Room");
            }
            else
            {
                frmReBatchList newReBatch = new frmReBatchList();
                DialogResult result = newReBatch.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.txtFilePathName.Text = newReBatch.getFilePath.ToString();
                    setDefaultValues();
                    loadImage(page);
                    populatePageList();
                    populateStampList();
                    populateSplitPointList();
                }
                else
                    MessageBox.Show("No file is selected or failed to process files that are not in the for batching folder.", "Virtual Mail Room");
            }
        }

        private void ofdOpenImageFile_FileOk(object sender, CancelEventArgs e)
        {
            if (this.txtFilePathName.Text.Trim() != string.Empty)
                bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "21", System.Environment.UserName);
            this.txtFilePathName.Text = ofdOpenImageFile.FileName;
            bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "20", System.Environment.UserName);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ddlPages.SelectedIndex = ddlPages.SelectedIndex + 1;
            //page++;            
            //loadImage(page);
            //this.chkBoxStamp.Checked = getStamped(page);
            //this.chkBoxSplitPoint.Checked = getSplitPoint(page);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            ddlPages.SelectedIndex = ddlPages.SelectedIndex - 1;
            //page--;
            //loadImage(page);
            //this.chkBoxStamp.Checked = getStamped(page);
            //this.chkBoxSplitPoint.Checked = getSplitPoint(page);
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ddlPages.SelectedIndex = 0;
            //page = 0;
            //loadImage(page);
            //this.chkBoxStamp.Checked = getStamped(page);
            //this.chkBoxSplitPoint.Checked = getSplitPoint(page);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            ddlPages.SelectedIndex = Convert.ToInt32(txtPageCount.Text) - 1;
            //page = Convert.ToInt32(txtPageCount.Text) - 1;
            //loadImage(page);
            //this.chkBoxStamp.Checked = getStamped(page);
            //this.chkBoxSplitPoint.Checked = getSplitPoint(page);
        }

        private void btnInlude_Click(object sender, EventArgs e)
        {
            if (lstBoxForGrouping.Items.Count > 0 && Convert.ToInt32(this.txtPageNumber.Text) < Convert.ToInt32(lstBoxForGrouping.Items[lstBoxForGrouping.Items.Count - 1]))
            {
                int index = 0;
                while (Convert.ToInt32(this.txtPageNumber.Text) > Convert.ToInt32(lstBoxForGrouping.Items[index]))
                {
                    index++;
                }
                lstBoxForGrouping.Items.Insert(index, Convert.ToInt32(this.txtPageNumber.Text));
            }
            else
                lstBoxForGrouping.Items.Add(Convert.ToInt32(this.txtPageNumber.Text));
            updateIsForSplit(Convert.ToInt32(this.txtPageNumber.Text)-1, true);
            lstBoxPages.Items.Remove(Convert.ToInt32(this.txtPageNumber.Text));
            enableButton();            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstBoxPages.Items.Count > 0 && Convert.ToInt32(this.txtPageNumber.Text) < Convert.ToInt32(lstBoxPages.Items[lstBoxPages.Items.Count - 1]))
            {
                int index = 0;
                while (Convert.ToInt32(this.txtPageNumber.Text) > Convert.ToInt32(lstBoxPages.Items[index]))
                {
                    index++;
                }
                lstBoxPages.Items.Insert(index, Convert.ToInt32(this.txtPageNumber.Text));
            }
            else
                lstBoxPages.Items.Add(Convert.ToInt32(this.txtPageNumber.Text));
            updateIsForSplit(Convert.ToInt32(this.txtPageNumber.Text)-1, false);
            lstBoxForGrouping.Items.Remove(Convert.ToInt32(this.txtPageNumber.Text));
            enableButton();         
        }

        private void chkBoxStamp_CheckedChanged(object sender, EventArgs e)
        {
            updateStamped(Convert.ToInt32(page));
        }

        private void chkBoxSplitPoint_CheckedChanged(object sender, EventArgs e)
        {
            updateSplit(Convert.ToInt32(page));
        }

        private void chkBoxSplitBatch_CheckedChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void ddlPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            page = Convert.ToInt32(ddlPages.SelectedItem) - 1;
            loadImage(page);
            this.chkBoxStamp.Checked = getStamped(page);
            this.chkBoxSplitPoint.Checked = getSplitPoint(page);
            txtSplitFBCount.Text = getSplitFBCount(page).ToString();
        }
        #endregion

        #region Image Group
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            object[] temp = new object[lstBoxPages.SelectedItems.Count];
            int i = 0;
            foreach (object item in lstBoxPages.SelectedItems)
            {
                temp[i] = item;
                i++;
            }
            lstBoxPages.SelectedItems.Clear();
            foreach (object item in temp)
            {
                if (lstBoxForGrouping.Items.Count > 0 && Convert.ToInt32(item) < Convert.ToInt32(lstBoxForGrouping.Items[lstBoxForGrouping.Items.Count - 1]))
                {
                    int index = 0;
                    while (Convert.ToInt32(item) > Convert.ToInt32(lstBoxForGrouping.Items[index]))
                    {
                        index++;
                    }
                    lstBoxForGrouping.Items.Insert(index, item);
                }
                else                
                    lstBoxForGrouping.Items.Add(item);
                updateIsForSplit(Convert.ToInt32(item) - 1, true);
                lstBoxPages.Items.Remove(item);
            }
            updateSplitFBCount();
            enableButton();            
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            object[] temp = new object[lstBoxForGrouping.SelectedItems.Count];
            int i = 0;
            foreach (object item in lstBoxForGrouping.SelectedItems)
            {
                temp[i] = item;
                i++;
            }

            foreach (object item in temp)
            {

                if (lstBoxPages.Items.Count > 0 && Convert.ToInt32(item) < Convert.ToInt32(lstBoxPages.Items[lstBoxPages.Items.Count - 1]))
                {
                    int index = 0;
                    while (Convert.ToInt32(item) > Convert.ToInt32(lstBoxPages.Items[index]))
                    {
                        index++;
                    }
                    lstBoxPages.Items.Insert(index, item);
                }
                else
                    lstBoxPages.Items.Add(item);
                updateIsForSplit(Convert.ToInt32(item) - 1, false);
                lstBoxForGrouping.Items.Remove(item);
            }
            updateSplitFBCount();
            enableButton();            
        }

        private void btnMoveRightAll_Click(object sender, EventArgs e)
        {
            foreach (object item in lstBoxPages.Items)
            {
                if (lstBoxForGrouping.Items.Count > 0 && Convert.ToInt32(item) < Convert.ToInt32(lstBoxForGrouping.Items[lstBoxForGrouping.Items.Count - 1]))
                {
                    int index = 0;
                    while (Convert.ToInt32(item) > Convert.ToInt32(lstBoxForGrouping.Items[index]))
                    {
                        index++;
                    }
                    lstBoxForGrouping.Items.Insert(index, item);
                }
                else
                    lstBoxForGrouping.Items.Add(item);
                updateIsForSplit(Convert.ToInt32(item) - 1, true);
            }
            lstBoxPages.Items.Clear();
            updateSplitFBCount();
            enableButton();            
        }

        private void btnMoveLeftAll_Click(object sender, EventArgs e)
        {
            foreach (object item in lstBoxForGrouping.Items)
            {
                if (lstBoxPages.Items.Count > 0 && Convert.ToInt32(item) < Convert.ToInt32(lstBoxPages.Items[lstBoxPages.Items.Count - 1]))
                {
                    int index = 0;
                    while (Convert.ToInt32(item) > Convert.ToInt32(lstBoxPages.Items[index]))
                    {
                        index++;
                    }
                    lstBoxPages.Items.Insert(index, item);
                }
                else
                    lstBoxPages.Items.Add(item);
                updateIsForSplit(Convert.ToInt32(item) - 1, false);
            }
            lstBoxForGrouping.Items.Clear();
            updateSplitFBCount();
            enableButton();            
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
        private void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateParameter();
            ds = bl.selectSCAC(parameter);
            bindgrd();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrd();
        }

        private void grdSCAC_SelectionChanged(object sender, EventArgs e)
        {
            if (grdSCAC.Rows.Count > 0 && grdSCAC.SelectedRows.Count > 0 
                && (grdSCAC.Rows[grdSCAC.SelectedRows[0].Index].Cells[1].Value.ToString().Trim() == "NOSCAC" 
                    || grdSCAC.Rows[grdSCAC.SelectedRows[0].Index].Cells[1].Value.ToString().Trim() == "FBNOKEY"
                    || grdSCAC.Rows[grdSCAC.SelectedRows[0].Index].Cells[1].Value.ToString().Trim() == "REFUNDS"))
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
            txtCarrierName.Clear();
            txtICS.Clear();
            txtImageIssue.Clear();
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
            chkBoxStamp.Checked = false;
            chkBoxSplitBatch.Checked = false;
            chkBoxSplitPoint.Checked = false;
            imageFile = null;
            tempBitmap = null;
            txtSplitFBCount.Text = "0";            
        }

        private void loadImage(int pageNumber)
        {
            if (txtFilePathName.Text != string.Empty)
            {
                if (imageFile == null)
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
            if (page == 0)
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

            btnInlude.Enabled = inGroupList(this.txtPageNumber.Text.Trim());
            btnRemove.Enabled = inPageList(this.txtPageNumber.Text.Trim());

            if (pcbImage.Image == null)
            {
                radioButton1.Checked = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;                
                radioButton_2.Enabled = false;
                radioButton_4.Enabled = false;
                btnRotateLeft.Enabled = false;
                btnRotateRight.Enabled = false;
                chkBoxStamp.Enabled = false;
                chkBoxSplitPoint.Enabled = false;
                radioAPAC.Enabled = false;
                radioJPM.Enabled = false;
                radioLA.Enabled = false;
                btnFirst.Enabled = false;
                btnLast.Enabled = false;
                ddlPages.Enabled = false;
                txtSplitFBCount.Enabled = false;
            }
            else
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton_2.Enabled = true;
                radioButton_4.Enabled = true;
                btnRotateLeft.Enabled = true;
                btnRotateRight.Enabled = true;
                chkBoxStamp.Enabled = true;
                chkBoxSplitPoint.Enabled = chkBoxSplitBatch.Checked ? getIsForSplit(page) : false;
                radioAPAC.Enabled = true;
                radioJPM.Enabled = true;
                radioLA.Enabled = true;
                btnFirst.Enabled = true;
                btnLast.Enabled = true;
                ddlPages.Enabled = true;
                if (lstBoxForGrouping.Items.Count > 0 && chkBoxSplitBatch.Checked)
                    txtSplitFBCount.Enabled = page == Convert.ToInt32(lstBoxForGrouping.Items[0]) - 1 ? true : chkBoxSplitPoint.Checked;
                else
                    txtSplitFBCount.Enabled = chkBoxSplitPoint.Checked;
            }
            if (txtPageCount.Text != "")
            {
                if (Convert.ToInt32(txtPageCount.Text) != lstBoxForGrouping.Items.Count + lstBoxPages.Items.Count)
                {
                    if(lstBoxForGrouping.Items.Count + lstBoxPages.Items.Count == 0)
                        btnOpenFile.Enabled = true;
                    else
                        btnOpenFile.Enabled = false;
                }
                else
                    btnOpenFile.Enabled = true;
            }
            else
                btnOpenFile.Enabled = true;
            btnCreateGroup.Enabled = pcbImage.Image == null ? false : true && lstBoxForGrouping.Items.Count == 0 ? false : true && txtFBCount.Text.Trim() == string.Empty ? false : true && getOwnerKey() == "" ? false : true;
        }

        private void populatePageList()
        {
            this.lstBoxPages.Items.Clear();
            this.lstBoxForGrouping.Items.Clear();
            this.ddlPages.Items.Clear();
            for (int i = 1; i <= pageCount; i++)
            {
                this.lstBoxPages.Items.Add(i);
                ddlPages.Items.Add(i);
            }
            this.ddlPages.SelectedIndexChanged -= new System.EventHandler(this.ddlPages_SelectedIndexChanged);
            ddlPages.SelectedIndex = 0;
            this.ddlPages.SelectedIndexChanged += new System.EventHandler(this.ddlPages_SelectedIndexChanged);
            enableButton();
        }

        private void populateStampList()
        {
            stamp.Clear();
            for(int i=1;i<=pageCount;i++)
                stamp.Add(new ImageStamp(i,false));
        }

        private void populateSplitPointList()
        {
            splitPoint.Clear();
            for (int i = 1; i <= pageCount; i++)
                splitPoint.Add(new ImageStamp(i, false));
        }

        private void updateStamped(int pageNumber)
        {
            ((ImageStamp)stamp[pageNumber]).IsStamped = chkBoxStamp.Checked;
        }

        private void updateSplit(int pageNumber)
        {
            ((ImageStamp)splitPoint[pageNumber]).IsStamped = chkBoxSplitPoint.Checked;
            if (lstBoxForGrouping.Items.Count > 0 && chkBoxSplitBatch.Checked)
                txtSplitFBCount.Enabled = page == Convert.ToInt32(lstBoxForGrouping.Items[0]) - 1 ? true : chkBoxSplitPoint.Checked;
            else
                txtSplitFBCount.Enabled = chkBoxSplitPoint.Checked;
        }

        private void updateIsForSplit(int pageNumber,bool isForSplit)
        {
            ((ImageStamp)splitPoint[pageNumber]).IsForSplit = isForSplit;
            if (!isForSplit)
            {
                ((ImageStamp)splitPoint[pageNumber]).IsStamped = false;
                this.chkBoxSplitPoint.Checked = getSplitPoint(pageNumber);
            }
        }

        private bool getStamped(int pageNumber)
        {
            return ((ImageStamp)stamp[pageNumber]).IsStamped;
        }

        private bool getSplitPoint(int pageNumber)
        {
            return ((ImageStamp)splitPoint[pageNumber]).IsStamped;
        }

        private int getSplitFBCount(int pageNumber)
        {            
            return ((ImageStamp)splitPoint[pageNumber]).SplitFBCount;
        }

        private bool getIsForSplit(int pageNumber)
        {
            if (splitPoint.Count > 0)
                return ((ImageStamp)splitPoint[pageNumber]).IsForSplit;
            else
                return false;
        }

        private bool inGroupList(string pageNumber)
        {
            bool retval = false;
            if (pageNumber != string.Empty)
            {     
                if(this.lstBoxPages.Items.Contains(Convert.ToInt32(pageNumber)))
                    retval = !(this.lstBoxForGrouping.Items.Contains(Convert.ToInt32(pageNumber)));
            }
            return retval;
        }

        private bool inPageList(string pageNumber)
        {
            bool retval = false;
            if (pageNumber != string.Empty)
            {                
                retval = (this.lstBoxForGrouping.Items.Contains(Convert.ToInt32(pageNumber)));
            }
            return retval;
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
            this.dv.RowFilter = string.Format("Name LIKE '{0}%' OR Scac LIKE '{0}%' OR [City/State] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdSCAC.DataSource = dv;
            this.grdSCAC.Refresh();
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
               
        private void moveFiles(string file, string batCtrlNum)
        {
            //string folder = getCompleteDestinationFolderPath(ConfigurationManager.AppSettings["ProcessedImagePath"], getTodayFolder());
            string newFile = ConfigurationManager.AppSettings["ProcessedImagePath"] + file.Substring(ConfigurationManager.AppSettings["ImageSourcePath"].Length);            
            if (!Directory.Exists(newFile.Substring(0, newFile.Length - CommonMethod.getFileName(newFile).Length)))
            {
                Directory.CreateDirectory(newFile.Substring(0, newFile.Length - CommonMethod.getFileName(newFile).Length));
            }
            bool moveTry = true;
            bool moveSuccessful = false;
            string errorMessage = string.Empty;
            int counter = 0;
            while (moveTry)
            {               
                try
                {
                    counter = counter+1;
                    File.Move(file, newFile);//folder + "\\" + CommonMethod.getFileName(file));                    
                    moveTry = false;
                    moveSuccessful = true;
                }
                catch (Exception e)
                {
                    if (counter == 3)
                    {
                        moveTry = false;
                        errorMessage = e.Message;
                    }
                    else
                    {  
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        Thread.Sleep(1000);
                    }                    
                }
                finally
                {
                }
            }
            if (!moveSuccessful)
            {
                //record to database FromFolder equal to ToFolder
                bl.insertImagesBatched(file, file, batCtrlNum, true);
                throw new Exception(file + " to " + newFile + ":" + errorMessage);//+ folder + "\\" + CommonMethod.getFileName(file) + ":" + errorMessage);
            }
            else
            {
                //record to database
                bl.insertImagesBatched(file, newFile, batCtrlNum, true);                
            }
        }

        private void updateSplitFBCount()
        {
            foreach (object item in lstBoxForGrouping.Items)
            {
                if (!(lstBoxForGrouping.Items.IndexOf(item) == 0))
                {
                    if (!((ImageStamp)splitPoint[Convert.ToInt32(Convert.ToInt32(item) - 1)]).IsStamped && ((ImageStamp)splitPoint[Convert.ToInt32(Convert.ToInt32(item) - 1)]).SplitFBCount != 0)
                    {
                        ((ImageStamp)splitPoint[Convert.ToInt32(Convert.ToInt32(item) - 1)]).SplitFBCount = 0;
                        break;
                    }
                }
            }
            txtSplitFBCount.Text = getSplitFBCount(page).ToString();
        }
        #endregion        

        
    }
}
