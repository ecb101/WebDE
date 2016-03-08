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
    public partial class frmForceStatusChange : Form
    {
        private ForceStatusChangeBL.ForceStatusChangeBL bl = new ForceStatusChangeBL.ForceStatusChangeBL();
        private string status = string.Empty;
        private DataSet dsBatches = new DataSet();
        private DataView dvBatches = new DataView();
        private string MXXControlNumber = string.Empty;

        public frmForceStatusChange()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
        }

        #region events
        private void frmForceStatusChange_Load(object sender, EventArgs e)
        {
            dsBatches = bl.selectBatches();
            bindgrdBatches();
            changeStatus();
        }

        private void radio_CheckedChange(object sender, EventArgs e)
        {
            changeStatus();
            populateParameter();
        }

        private void grdImageGroup_SelectionChanged(object sender, EventArgs e)
        {
            populateParameter();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (isAllowedRestore())
            {
                if (MessageBox.Show("Are you sure you want to force update the status of this batch?", "Force Status Change", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bl.updateStatus(MXXControlNumber, status, System.Environment.UserName))
                    {
                        dsBatches = bl.selectBatches();
                        bindgrdBatches();                        
                        MessageBox.Show("Status successfully changed.", "Force Status Change");
                    }
                    else
                    {
                        MessageBox.Show("There was a problem during status restore.", "Force Status Change");
                    }

                }
            }
            else
            {
                MessageBox.Show("There was a problem during status restore.", "Force Status Change");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrdBatches();
            grdImageGroup_SelectionChanged(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dsBatches = bl.selectBatches();
            bindgrdBatches();
            changeStatus();
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

        private void changeStatus()
        {
            if (radioInDE.Checked)
            {                
                status = "IN DE";
            }
            else
            {             
                status = "REVIEW";
            }
        }

        private void bindgrdBatches()
        {
            grdImageGroup.SelectionChanged -= new EventHandler(grdImageGroup_SelectionChanged);
            dvBatches.Table = dsBatches.Tables[0];
            this.dvBatches.RowFilter = string.Format("[Batch Number] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdImageGroup.DataSource = dvBatches;
            this.grdImageGroup.Refresh();
            grdImageGroup.SelectionChanged += new EventHandler(grdImageGroup_SelectionChanged);
        }

        private bool isAllowedRestore()
        {
            bool retval = false;
            if (MXXControlNumber != string.Empty)
            {                
                retval = true;                
            }
            return retval;
        }
        #endregion       
    }
}
