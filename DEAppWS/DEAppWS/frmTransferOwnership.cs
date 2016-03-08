using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmTransferOwnership : Form
    {
        private TransferOwnershipBL.TransferOwnershipBL bl = new TransferOwnershipBL.TransferOwnershipBL();
        private string ownerType = string.Empty;
        private string status = string.Empty;
        private DataSet dsBatches = new DataSet();
        private DataView dvBatches = new DataView();
        private string MXXControlNumber = string.Empty;
        public frmTransferOwnership()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
        }
        
        #region events
        private void frmTransferOwnership_Load(object sender, EventArgs e)
        {
            changeOwnerType();
            dsBatches = bl.selectBatches(status);
            bindgrdBatches();
        }        

        private void radio_CheckedChange(object sender, EventArgs e)
        {
            changeOwnerType();
            dsBatches = bl.selectBatches(status);
            bindgrdBatches();
            populateParameter();
            bindControls();
        }

        private void grdImageGroup_SelectionChanged(object sender, EventArgs e)
        {
            populateParameter();
            bindControls();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isAllowedUpdate())
            {
                if (MessageBox.Show("Are you sure you want to update the ownership of this batch?", "Transfer Ownership", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (radioOperator.Checked)
                    {
                        if (bl.updateOperator(MXXControlNumber, txtNewOperatorOwner.Text.Trim(), System.Environment.UserName))
                        {
                            changeOwnerType();
                            dsBatches = bl.selectBatches(status);
                            bindgrdBatches();
                            bindControls();
                            MessageBox.Show("Ownership successfully changed.", "Transfer Ownership");
                        }
                        else
                        {
                            MessageBox.Show("There was a problem during ownership change.", "Transfer Ownership");
                        }
                    }
                    else
                    {
                        if (bl.updateReviewer(MXXControlNumber, txtNewReviewerOwner.Text.Trim(), System.Environment.UserName))
                        {
                            changeOwnerType();
                            dsBatches = bl.selectBatches(status);
                            bindgrdBatches();
                            bindControls();
                            MessageBox.Show("Ownership successfully changed.", "Transfer Ownership");
                        }
                        else
                        {
                            MessageBox.Show("There was a problem during ownership change.", "Transfer Ownership");
                        }
                    }                
                }
            }
            else
            {
                MessageBox.Show("There was a problem during ownership change.", "Transfer Ownership");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            changeOwnerType();
            dsBatches = bl.selectBatches(status);
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
        }
        #endregion

        #region Developer Designed method
        private void populateParameter()
        {
            MXXControlNumber = string.Empty;
            if (this.grdImageGroup.Rows.Count > 0 && this.grdImageGroup.SelectedRows.Count > 0)
            {
                MXXControlNumber = this.grdImageGroup.SelectedRows[0].Cells["BatchNumber"].Value.ToString();
            }
        }

        private void changeOwnerType()
        {
            if (radioOperator.Checked)
            {
                ownerType = "Operator";
                status = "IN DE";                
            }
            else
            {
                ownerType = "Reviewer";
                status = "REVIEW";
            }
            grpOperator.Enabled = radioOperator.Checked;
            grpReviewer.Enabled = radioReviewer.Checked;
            clearControls();
        }

        private void clearControls()
        {
            foreach (Control control in grpUpdate.Controls)
            {
                if (control is TraxDETextBox)
                {
                    ((TraxDETextBox)control).Clear();
                }
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                        {
                            ((TraxDETextBox)controls).Clear();
                        }
                    }
                }
            }
        }

        private void bindgrdBatches()
        {
            grdImageGroup.SelectionChanged -= new EventHandler(grdImageGroup_SelectionChanged);
            dvBatches.Table = dsBatches.Tables[0];
            this.dvBatches.RowFilter = string.Format("[Batch Number] LIKE '{0}%' OR [Operator] LIKE '{0}%' OR [QA By] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdImageGroup.DataSource = dvBatches;
            this.grdImageGroup.Refresh();
            grdImageGroup.SelectionChanged += new EventHandler(grdImageGroup_SelectionChanged);
        }

        private void bindControls()
        {
            if (grdImageGroup.SelectedRows.Count > 0)
            {
                txtOldOperatorOwner.Text = grdImageGroup.SelectedRows[0].Cells["Operator"].Value.ToString().Trim();
                txtOldReviewerOwner.Text = grdImageGroup.SelectedRows[0].Cells["QABy"].Value.ToString().Trim();
            }
        } 

        private bool isAllowedUpdate()
        { 
            bool retval = false;
            if (MXXControlNumber != string.Empty)
            {
                if (radioOperator.Checked)
                {
                    if (txtNewOperatorOwner.Text != string.Empty)
                    {
                        retval = true;
                    }
                }
                else
                {
                    if (this.txtNewReviewerOwner.Text != string.Empty)
                    {
                        retval = true;
                    }
                }
            }
            return retval;
        }
        #endregion        
    }
}
