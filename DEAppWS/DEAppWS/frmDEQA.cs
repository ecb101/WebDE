using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
//using BLogic;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmDEQA : Form
    {        
        private CommonEnum.FormMode formMode = CommonEnum.FormMode.DATA_ENTRY;
        private DataEntryQABL.DataEntryQABL bl = new DataEntryQABL.DataEntryQABL();
        private CommonEnum.FormState currentFormState = CommonEnum.FormState.NORMAL_STATE;        
        private DataSet dsBatches = new DataSet();        
        private DataView dvBatches = new DataView();        
        private string MXXDatabase = string.Empty;
        private string MXXOwnerKey = string.Empty;
        private string MXXSCAC = string.Empty;
        private string MXXOwnerCode = string.Empty;
        private frmDEQABase frmDEQAForm = null;
        public frmDEQA()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            enableToolStripButtons(currentFormState);
        }

        public frmDEQA(CommonEnum.FormMode mode)
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            enableToolStripButtons(currentFormState);            
            this.formMode = mode;
            
            if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
            {
                toolStripButtonSaveClose.Text = "On &Hold";
                toolStripButtonRestart.Text = "QA &Pass";
                toolStripButtonSendReview.Text = "Ch&eck";
                Operator.Visible = false;
                QABy.Visible = true;
            }
            else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
            {
                toolStripButtonEdit.Visible = false;
                toolStripButtonSaveClose.Visible = false;
                toolStripButtonRestart.Visible = false;
                toolStripButtonCancel.Text = "E&nd";
                Operator.Visible = false;
            }
            this.Text = formMode.ToString();
        }

        #region events
        #region others
        private void frmDEQA_Enter(object sender, EventArgs e)
        {
            dsBatches = bl.selectBatches(formMode);
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
            if (dsBatches.Tables[0].Rows.Count == 0)
                enableToolStripButtons(currentFormState);
        }

        private void frmDEQA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                MessageBox.Show("Cannot close in Edit or Open mode.", "Data Entry");
                e.Cancel = true;
            }
        }
                
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            
            dsBatches = bl.selectBatches(formMode);
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
            if (dsBatches.Tables[0].Rows.Count == 0)
                enableToolStripButtons(currentFormState);
            this.Cursor = Cursors.Default;
        }        
        #endregion

        #region grid events
        private void grdImageGroup_SelectionChanged(object sender, EventArgs e)
        {
            populateParameter();            
            enableToolStripButtons(currentFormState);            
        }       
        #endregion

        #region toolStrip
        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            if (this.grdImageGroup.SelectedRows.Count > 0)
            {
                populateParameter();
                if (MXXDatabase.Trim() != string.Empty)
                {
                    try
                    {
                        if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                        {
                            if (bl.isAllowBatchStart(MXXDatabase) && bl.isAllowEdit(MXXDatabase, System.Environment.UserName))
                            {
                                frmClientSCACValidation frmClientSCACValidation = new frmClientSCACValidation(formMode,MXXDatabase,MXXOwnerKey,MXXSCAC);
                                if (!frmClientSCACValidation.IsNoValidation)
                                    frmClientSCACValidation.ShowDialog();
                                if (frmClientSCACValidation.IsValidated)
                                {
                                    if (bl.startBatch(MXXDatabase.Trim(), CommonUserLogin.getUser().UserInitials))//update ang Batch_DE Oper_Init, DE_START_DTM, DE_File_Name
                                    {

                                        bl.auditTrailBatch(MXXDatabase, "102", System.Environment.UserName);
                                        loadForm();

                                        this.Visible = false;
                                        frmDEQAForm.Show();
                                    }
                                    else
                                        MessageBox.Show("There was a problem when starting this batch.", "Data Entry");
                                }
                                else
                                    bl.updateStatus(MXXDatabase, "IN DE");
                            }
                            else
                                MessageBox.Show("This batch was started by a different user.", "Data Entry");
                        }
                        else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                        {
                            if (bl.isAllowQA(MXXDatabase) && bl.isAllowQAEdit(MXXDatabase, System.Environment.UserName))
                            {
                                frmClientSCACValidation frmClientSCACValidation = new frmClientSCACValidation(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC);
                                frmClientSCACValidation.ShowDialog();
                                if (frmClientSCACValidation.IsValidated)
                                {
                                    if (frmClientSCACValidation.IsOverwriteValue)
                                    {
                                        //reload mxx
                                        string bat_Ctrl_Num = MXXDatabase;
                                        btnRefresh_Click(null, null);
                                        BindingSource bsImageGroup = new BindingSource();
                                        bsImageGroup.DataSource = dvBatches;
                                        grdImageGroup.Rows[bsImageGroup.Find("Batch Number", bat_Ctrl_Num)].Selected = true;//bsInvoice.Find("InvId", rowTemp["ID"])]                                        
                                    }
                                    if (bl.startReview(MXXDatabase, CommonUserLogin.getUser().UserInitials))//update Batch_DE Rev_Init, REV_START_DTM
                                    {
                                        bl.auditTrailBatch(MXXDatabase, "121", System.Environment.UserName);
                                        loadForm();
                                        this.Visible = false;
                                        frmDEQAForm.Show();
                                    }
                                    else
                                        MessageBox.Show("There was a problem when starting to review this batch.", "Quality Assurance");
                                }
                                else
                                    bl.updateStatus(MXXDatabase, "REVIEW");
                            }
                            else
                                MessageBox.Show("This batch is currently QA by a different user.", "Quality Assurance");
                        }
                        else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
                        {
                            loadForm();
                            this.Visible = false;
                            frmDEQAForm.Show();
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, formMode == CommonEnum.FormMode.DATA_ENTRY ? "Data Entry" : "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                {
                    if (bl.isAllowUserEntry(MXXDatabase, CommonUserLogin.getUser().UserInitials.Trim()))
                    {
                        if (bl.isAllowEdit(MXXDatabase, System.Environment.UserName))
                        {
                            loadForm();
                            this.Visible = false;
                            frmDEQAForm.Show();
                        }
                        else
                            MessageBox.Show("There was a problem when setting this batch to edit mode.", "Data Entry");
                    }
                    else
                        MessageBox.Show("This batch was started by a different user or was not started properly.", "Data Entry");
                }
                else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                {
                    if (bl.isAllowUserQA(MXXDatabase, CommonUserLogin.getUser().UserInitials.Trim()))
                    {
                        if (bl.isAllowQAEdit(MXXDatabase, System.Environment.UserName))
                        {
                            frmClientSCACValidation frmClientSCACValidation = new frmClientSCACValidation(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC);
                            frmClientSCACValidation.ShowDialog();
                            if (frmClientSCACValidation.IsValidated)
                            {
                                if (frmClientSCACValidation.IsOverwriteValue)
                                {
                                    //reload mxx
                                    string bat_Ctrl_Num = MXXDatabase;
                                    btnRefresh_Click(null, null);
                                    BindingSource bsImageGroup = new BindingSource();
                                    bsImageGroup.DataSource = dvBatches;
                                    grdImageGroup.Rows[bsImageGroup.Find("Batch Number", bat_Ctrl_Num)].Selected = true;//bsInvoice.Find("InvId", rowTemp["ID"])]                                        
                                }
                                loadForm();
                                this.Visible = false;
                                frmDEQAForm.Show();
                            }
                        }
                        else
                            MessageBox.Show("There was a problem when setting this batch to edit mode.", "Quality Assurance");
                    }
                    else
                        MessageBox.Show("This batch is currently QA by a different user.", "Quality Assurance");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Data Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion

        #region Developer Designed method
        private void bindgrdBatches()
        {
            grdImageGroup.SelectionChanged -= new EventHandler(grdImageGroup_SelectionChanged);
            dvBatches.Table = dsBatches.Tables[0];
            this.dvBatches.RowFilter = string.Format("[Batch Number] LIKE '{0}%' OR [Vendor SCAC] LIKE '{0}%' OR [OwnerCode] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdImageGroup.DataSource = dvBatches;
            this.grdImageGroup.Refresh();
            grdImageGroup.SelectionChanged += new EventHandler(grdImageGroup_SelectionChanged);
        }

        private void enableStateControls(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {                        
                        enableControls(true, grpBoxImageGroup.Controls);
                        break;
                    }               
            }
        }

        private void enableToolStripButtons(CommonEnum.FormState state)
        {
            if ((formMode == CommonEnum.FormMode.DATA_ENTRY))
            {
                switch (state)
                {

                    case CommonEnum.FormState.NORMAL_STATE:
                        {
                            toolStripButtonStart.Enabled = !isBatchStarted();
                            toolStripButtonEdit.Enabled = isEditAllowed() == true ? isBatchStarted() : false;
                            toolStripButtonSave.Enabled = false;
                            toolStripButtonSaveClose.Enabled = false;
                            toolStripButtonRestart.Enabled = false;
                            toolStripButtonSendReview.Enabled = false;
                            toolStripButtonCancel.Enabled = false;
                            toolStripButtonMode.Enabled = false;
                            toolStripButtonOption.Enabled = false;
                            break;
                        }                    
                }
            }
            else
            {
                switch (state)
                {
                    case CommonEnum.FormState.NORMAL_STATE:
                        {
                            toolStripButtonStart.Enabled = !isReviewStarted();
                            toolStripButtonEdit.Enabled = isReviewContAllowed() == true ? isReviewStarted() : false;
                            toolStripButtonSave.Enabled = false;
                            toolStripButtonSaveClose.Enabled = false;
                            toolStripButtonSendReview.Enabled = false;
                            toolStripButtonRestart.Enabled = false;
                            toolStripButtonCancel.Enabled = false;
                            toolStripButtonMode.Enabled = false;
                            toolStripButtonOption.Enabled = false;
                            break;
                        }                    
                }
            }

            enableStateControls(currentFormState);
        }

        private void enableControls(bool isEnable, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)                
                    ((Button)control).Enabled = isEnable;                
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = isEnable;
                else if (control is TraxDETextBox)
                    ((TraxDETextBox)control).ReadOnly = !isEnable;                
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).ReadOnly = !isEnable;
                else if (control is TraxDEComboBox)
                    ((TraxDEComboBox)control).Enabled = isEnable;
                //else if (control is TraxDEDataGridView)                
                //    ((TraxDEDataGridView)control).ReadOnly = !isEnable;
                else if (control is GroupBox)
                    enableControls(isEnable, ((GroupBox)control).Controls);
                else if (control is RadioButton)
                    control.Enabled = isEnable;
            }
        }

        private bool isBatchStarted()
        {
            bool retval = false;
            if (this.grdImageGroup.SelectedRows.Count > 0)
                retval = (grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value == null || grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["Operator"].Value.ToString().Trim() == "") ? false : true;
            return retval;
        }
                
        private bool isEditAllowed()
        {
            bool retval = false;
            if (this.grdImageGroup.Rows.Count > 0)
                retval = true;
            return retval;
        }
                
        private bool isReviewContAllowed()
        {
            bool retval = false;
            if (this.grdImageGroup.Rows.Count > 0)
                retval = true;
            return retval;
        }

        private bool isReviewStarted()
        {
            bool retval = false;
            if (this.grdImageGroup.SelectedRows.Count > 0)
                retval = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["QABy"].Value == null || grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["QABy"].Value.ToString().Trim() == "" ? false : true;
            return retval;
        }

        private void loadForm()
        {
            string DEForm = string.Empty;
            DEForm = bl.selectDEForm(MXXDatabase, MXXOwnerKey, MXXSCAC);
            if (DEForm.ToUpper().Trim() == "CERTIFY")
                frmDEQAForm = new frmCertify(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, this);
            else if (DEForm.ToUpper().Trim() == "DEFAULT")
                frmDEQAForm = new frmDefaultDE(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, this);
            else if (DEForm.ToUpper().Trim() == "MATCH")
                frmDEQAForm = new frmMatch(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, this);
            else if (DEForm.ToUpper().Trim() == "MATCH_WITH_REF")
                frmDEQAForm = new frmMatchWithRef(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, this);
            else if (DEForm.ToUpper().Trim() == "FIS")
                frmDEQAForm = new frmFIS(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, this);
            else
                frmDEQAForm = new frmDefaultDE(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, this);
            
            frmDEQAForm.MdiParent = this.MdiParent;
        }

        private void populateParameter()
        {
            MXXDatabase = string.Empty;
            MXXOwnerKey = string.Empty;
            MXXSCAC = string.Empty;
            MXXOwnerCode = string.Empty;
            if (this.grdImageGroup.Rows.Count > 0 && this.grdImageGroup.SelectedRows.Count > 0)
            {
                MXXDatabase = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["BatchNumber"].Value.ToString();
                MXXOwnerKey = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerKey"].Value.ToString();
                MXXSCAC = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["VendSCAC"].Value.ToString();
                MXXOwnerCode = grdImageGroup.Rows[grdImageGroup.SelectedRows[0].Index].Cells["OwnerCode"].Value.ToString();
            }
        }
        #endregion
    }
}
