using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Threading;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmInvoiceManifest : Form
    {        
        private DataSet dsDetail = new DataSet();
        private DataView dv = new DataView();
        private DataView dvDetail = new DataView();
        private InvoiceManifestBL.InvoiceManifestBL bl = new InvoiceManifestBL.InvoiceManifestBL();
        private CommonEnum.FormState currentFormState = CommonEnum.FormState.NORMAL_STATE;
        private string ImgDocIDList = string.Empty;
        private DateTime procDateServerDate = new DateTime();
        private string procDate = string.Empty;
        private ProcessStartInfo procInfo = new ProcessStartInfo();
        private Process proc = new Process();
        public frmInvoiceManifest()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            Client.Items.AddRange(bl.selectClient());
            Language.Items.AddRange(bl.selectLanguage());
        }

        #region events
        #region grid
        private void grdDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dsDetail != null && dsDetail.Tables.Count > 0 && dsDetail.Tables[0].Rows.Count > 0 && dsDetail.Tables[0].Rows[e.RowIndex].RowState == DataRowState.Unchanged)
                dsDetail.Tables[0].Rows[e.RowIndex].SetModified();
        }
        #endregion

        #region toolStrip
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            if (txtFilePathName.Text != string.Empty)
            {
                currentFormState = CommonEnum.FormState.NEW_STATE;
                bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "1", System.Environment.UserName);
                procDateServerDate = bl.GetServerDate();
                procDate = procDateServerDate.ToShortDateString();
                ddlProcDate.Items.Add(procDate);
                ddlProcDate.SelectedItem = procDate;
                dsDetail.Clear();
                bindgrdDetail();
                enableToolStripButtons(currentFormState);
                procInfo.FileName = txtFilePathName.Text;
                proc.StartInfo = procInfo;
                proc.Start();
            }
            else
            {
                MessageBox.Show("Pick an image bill first.", "Invoice Manifest");
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {       
            if (txtFilePathName.Text != string.Empty && ddlProcDate.SelectedItem != null && ddlProcDate.SelectedItem != string.Empty)
            {
                currentFormState = CommonEnum.FormState.EDIT_STATE;
                bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "1", System.Environment.UserName);
                procDate = ddlProcDate.SelectedItem.ToString();
                enableToolStripButtons(currentFormState);
                procInfo.FileName = txtFilePathName.Text;
                proc.StartInfo = procInfo;
                proc.Start();
            }
            else
            {
                MessageBox.Show("Pick an image bill and a process date first before you can edit.", "Invoice Manifest");
            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (isAllowedSave())
            {
                if (MessageBox.Show("Are you sure to save all changes done?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        bl.saveInvoiceManifest(dsDetail, ConfigurationManager.AppSettings["SiteID"]);
                        currentFormState = CommonEnum.FormState.NORMAL_STATE;
                        enableToolStripButtons(currentFormState);
                        clearControls();
                        txtFilePathName.Clear();
                        ImgDocIDList = string.Empty;
                        dsDetail = bl.selectInvoiceManifest(ImgDocIDList);
                        bindgrdDetail();
                        proc.Kill();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        proc.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("There are fields that are empty, please review.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("There are fields that are empty, please review.");
            }
            
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel all changes done?", "Cancel updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    enableToolStripButtons(currentFormState);
                    bl.auditTrail(CommonMethod.getFileName(txtFilePathName.Text).Substring(0, 8), "3", System.Environment.UserName);
                    dsDetail = bl.selectInvoiceManifest(ImgDocIDList);
                    bindgrdDetail();
                    proc.Kill();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                    proc.Close();                    
                }
            }
        }
        #endregion

        #region others
        private void frmInvoiceManifest_Enter(object sender, EventArgs e)
        {            
            enableToolStripButtons(currentFormState);
        }
        
        private void frmInvoiceManifest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                MessageBox.Show("Cannot close in Edit mode.", "Invoice Manifest");
                e.Cancel = true;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            ofdOpenImageFile.Filter = string.Format("TIFF files (*.tif)|{0}.tif", "*");
            ofdOpenImageFile.FileName = string.Empty;
            ofdOpenImageFile.InitialDirectory = ConfigurationManager.AppSettings["RootManifestPath"];
            ofdOpenImageFile.ShowDialog();
            if (ofdOpenImageFile.FileName != string.Empty && ofdOpenImageFile.FileName.Contains(ConfigurationManager.AppSettings["RootManifestPath"]))
            {
                ImgDocIDList = ofdOpenImageFile.SafeFileName;
                dsDetail = bl.selectInvoiceManifest(ImgDocIDList);

                //if there are existing records enable and populate process date drop down list 
                populateProcDate();
                setComboBoxPageNumber();
                bindgrdDetail();
            }
            else
            {
                ImgDocIDList = string.Empty;
                txtFilePathName.Clear();
                ddlProcDate.Items.Clear();
                MessageBox.Show("No file is selected or failed to process files that are not in the Manifest folder.");
            }
        }

        private void ofdOpenImageFile_FileOk(object sender, CancelEventArgs e)
        {
            this.txtFilePathName.Text = ofdOpenImageFile.FileName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ImgDocIDList != string.Empty)
            {
                DataRow row = ((DataView)grdDetail.DataSource).Table.NewRow();
                row["InvManID"] = (grdDetail.Rows.Count + 1).ToString();
                row["ImgDocID"] = ImgDocIDList;
                row["ProcDate"] = procDate;
                row["UserId"] = CommonUserLogin.getUser().UserID;
                row["Status"] = "A";
                if (grdDetail.Rows.Count > 0)
                {
                    row["TrackingNum"] = grdDetail.Rows[grdDetail.Rows.Count - 1].Cells["TrackingNum"].Value;
                    row["Client"] = grdDetail.Rows[grdDetail.Rows.Count - 1].Cells["Client"].Value;
                    row["Carrier"] = grdDetail.Rows[grdDetail.Rows.Count - 1].Cells["Carrier"].Value;
                    row["Language"] = grdDetail.Rows[grdDetail.Rows.Count - 1].Cells["Language"].Value;
                }
                dsDetail.Tables[0].Rows.Add(row);
                bindgrdDetail();
                grdDetail.Select();
                grdDetail.Rows[grdDetail.Rows.Count - 1].Selected = true;
                grdDetail.CurrentCell = grdDetail.Rows[grdDetail.SelectedRows[0].Index].Cells[3];
                setReadOnlyGridColumns(grdDetail);
                if (grdDetail.SelectedRows.Count > 0)
                    btnDelete.Enabled = true;
                btnComplete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            delete(string.Format("InvManID = '{0}'", grdDetail.Rows[grdDetail.SelectedRows[0].Index].Cells["InvManID"].Value.ToString().Trim()));
            bindgrdDetail();
            if (grdDetail.Rows.Count <= 0)
            {
                btnDelete.Enabled = false;
                btnComplete.Enabled = false;
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            try
            {
                setStatus();
                string client = grdDetail.Rows[0].Cells["Client"].Value.ToString();
                string file = txtFilePathName.Text;
                toolStripButtonSave_Click(null, null);
                bl.auditTrail(CommonMethod.getFileName(file).Substring(0, 8), "2", System.Environment.UserName);
                moveFiles(file);//, client);
                txtFilePathName.Clear();
                dvDetail.Table.Rows.Clear();
                grdDetail.DataSource = dvDetail;
                grdDetail.ClearSelection();
            }
            catch (Exception error)
            {
                CommonMethod.createErrorLog(error.Message);
            }
        }

        private void ddlProcDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrdDetail();
        }
        #endregion
        #endregion

        #region Developer Designed method
        private void enableToolStripButtons(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        toolStripButtonNew.Enabled = true;
                        toolStripButtonEdit.Enabled = true;
                        toolStripButtonSave.Enabled = false;
                        toolStripButtonCancel.Enabled = false;
                        break;
                    }
                case CommonEnum.FormState.NEW_STATE:
                    {
                        toolStripButtonNew.Enabled = false;
                        toolStripButtonEdit.Enabled = false;
                        toolStripButtonSave.Enabled = true;
                        toolStripButtonCancel.Enabled = true;
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        toolStripButtonNew.Enabled = false;
                        toolStripButtonEdit.Enabled = false;
                        toolStripButtonSave.Enabled = true;                        
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
                        enableControls(true, grpBoxList.Controls);
                        enableControls(false, grpBoxDetail.Controls);
                        break;
                    }
                case CommonEnum.FormState.NEW_STATE:
                    {
                        enableControls(false, grpBoxList.Controls);
                        enableControls(true, grpBoxDetail.Controls);
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        enableControls(false, grpBoxList.Controls);
                        enableControls(true,  grpBoxDetail.Controls);
                        break;
                    }
            }
        }

        private void enableControls(bool isEnable, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                    if (((Button)control).Name == "btnDelete" || ((Button)control).Name == "btnComplete")
                        ((Button)control).Enabled = grdDetail.SelectedRows.Count > 0 ? isEnable : false;
                    else
                        ((Button)control).Enabled = isEnable;
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = isEnable;
                else if (control is TraxDETextBox)
                    ((TraxDETextBox)control).ReadOnly = !isEnable;
                else if (control is TraxDEComboBox)
                    ((TraxDEComboBox)control).Enabled = isEnable;
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).ReadOnly = !isEnable;
                else if (control is TraxDEDataGridView)
                {
                    ((TraxDEDataGridView)control).Enabled = isEnable;
                    ((TraxDEDataGridView)control).StandardTab = !isEnable;
                    if (isEnable)
                        setReadOnlyGridColumns((TraxDEDataGridView)control);
                }
                else if (control is Panel)
                    enableControls(isEnable, ((Panel)control).Controls);
                else if (control is GroupBox)
                    enableControls(isEnable, ((GroupBox)control).Controls);
                else if (control is RadioButton)
                    control.Enabled = isEnable;

            }
        }

        private void bindgrdDetail()
        {
            if (dsDetail == null)
            {
                if ((DataView)grdDetail.DataSource != null)
                {
                    if (dvDetail.Table != null)
                        dvDetail.Table.Rows.Clear();
                    grdDetail.DataSource = dvDetail;
                    grdDetail.ClearSelection();
                }
            }
            else
            {                
                dvDetail.Table = dsDetail.Tables[0];
                if (ddlProcDate.SelectedItem != null)                
                    dvDetail.RowFilter = string.Format("ProcDate = '{0}'", ddlProcDate.SelectedItem);                    
                else
                    dvDetail.RowFilter = string.Format("ProcDate = '{0}'", string.Empty);
                
                this.grdDetail.DataSource = dvDetail;
                this.grdDetail.Refresh();                
            }            
        }        

        private void clearControls()
        {
            foreach (Control control in grpBoxList.Controls)
            {
                if (control is TraxDETextBox)
                    ((TraxDETextBox)control).Clear();
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).Clear();
                else if (control is TraxDEComboBox)
                    ((TraxDEComboBox)control).Items.Clear();
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                            ((TraxDETextBox)controls).Clear();
                    }
                }
            }
        }

        private void setReadOnlyGridColumns(TraxDEDataGridView grd)
        {
            foreach (DataGridViewColumn column in grd.Columns)
            {
                if (column is TraxDEDataGridViewTextBoxColumn)
                {
                    if (column.Name == "InvManID" || column.Name == "ImgDocID" || column.Name == "ProcDate")
                        column.ReadOnly = true;
                }
            }
        }

        private void setComboBoxPageNumber()
        {
            int count = Image.FromFile(txtFilePathName.Text, true).GetFrameCount(new FrameDimension(Image.FromFile(txtFilePathName.Text, true).FrameDimensionsList[0]));
            this.ImgPageNo.Items.Clear();
            for (int i = 1; i <= count; i++)
                this.ImgPageNo.Items.Add(i);            
        }

        private bool delete(string filter)
        {
            bool retval = false;
            try
            {
                this.dvDetail.RowFilter = filter;
                int count = dvDetail.Count;
                ArrayList deleteList = new ArrayList();
                for (int i = 0; i < count; i++)
                    deleteList.Add(dsDetail.Tables[0].Rows.IndexOf(dvDetail[i].Row));
                foreach (object item in deleteList)
                    dsDetail.Tables[0].Rows[(int)item].Delete();
                retval = true;
            }
            catch
            {
                retval = false;
            }
            this.dvDetail.RowFilter = string.Empty;
            return retval;
        }

        private void moveFiles(string file)// , string client)
        {
            string newFile = ConfigurationManager.AppSettings["ImageSourcePath"] + file.Substring(ConfigurationManager.AppSettings["RootManifestPath"].Length);
            //string folder = getCompleteDestinationFolderPath(ConfigurationManager.AppSettings["ImageSourcePath"], client);
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
                    counter = counter + 1;
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
                bl.insertImagesManifested(file, file);
                throw new Exception(file + " to " + newFile + ":" + errorMessage);//folder + "\\" + CommonMethod.getFileName(file) + ":" + errorMessage);
            }
            else
            { 
                //record to database
                bl.insertImagesManifested(file, newFile);
            }
        }

        private string getCompleteDestinationFolderPath(string baseFolderPath, string folderName)
        {
            string retval = baseFolderPath + folderName;
            if (!Directory.Exists(retval))
            {
                Directory.CreateDirectory(retval);
            }
            return retval;
        }

        private void populateProcDate()
        {
            ddlProcDate.Items.Clear();
            foreach (DataRow row in dsDetail.Tables[0].Rows)
            {
                if(!ddlProcDate.Items.Contains(row["ProcDate"].ToString()))
                    ddlProcDate.Items.Add(row["ProcDate"].ToString());
            }
        }

        private bool isAllowedSave()
        {
            bool retval = true;
            foreach (DataRow row in dsDetail.Tables[0].Rows)
            {
                if (row["Inv_Key"].ToString().Trim() == string.Empty
                    || row["ImgPageNo"].ToString().Trim() == string.Empty
                    || row["Client"].ToString().Trim() == string.Empty
                    || row["Carrier"].ToString().Trim() == string.Empty)
                {
                    retval = false;
                    break;
                }
            }
            return retval;
        }

        private void setStatus()
        {
            foreach (DataRow row in dsDetail.Tables[0].Rows)
            {
                if (row["ProcDate"].ToString() == procDate)
                {
                    row["Status"] = "C";
                }
            }
        }
        #endregion
    }
}
