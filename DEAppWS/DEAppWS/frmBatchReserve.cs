using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormControls;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmBatchReserve : Form
    {
        private BatchReserveBL.BatchReserveBL bl = new BatchReserveBL.BatchReserveBL();
        private DataSet dsBuffedContents = new DataSet();
        private DataRow drBuffedContents;
        private DataTable dt = new DataTable("BatchReserve");
        public frmBatchReserve()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            setTableStructure();
        }

        #region events
        private void btnReserve_Click(object sender, EventArgs e)
        {
            try
            {
                if (isAllowedReserve())
                {
                    drBuffedContents["BuffDate"] = DateTime.Now;
                    drBuffedContents["OriginalCRBatCtrlNum"] = txtCRBatCtrlNum.Text;
                    drBuffedContents["BuffedCRBatCtrlNum"] = (Convert.ToInt32(txtCRBatCtrlNum.Text.Trim()) + Convert.ToInt32(txtReserve.Text.Trim()));
                    drBuffedContents["StartBatCtrlNum"] = txtCRBatCtrlNum.Text;
                    drBuffedContents["EndBatCtrlNum"] = Convert.ToInt32(drBuffedContents["BuffedCRBatCtrlNum"]) - 1;
                    drBuffedContents["OrigReservedCount"] = Convert.ToInt32(txtReserve.Text.Trim());
                    drBuffedContents["RemainingReservedCount"] = Convert.ToInt32(txtReserve.Text.Trim());
                    drBuffedContents["UserName"] = System.Environment.UserName;
                    dt.Rows.Add(drBuffedContents);
                    if (bl.addBatchBuff(dt))
                    {
                        MessageBox.Show("Successfully Reserved.", "Batch Reservation");
                        dt.Clear();
                        this.frmBatchReserve_Load(null, null);
                    }
                    else
                    {
                        this.frmBatchReserve_Load(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Missing or invalid inputs.", "Batch Reservation");
                }
            }
            catch(Exception error)
            {
                CommonMethod.createErrorLog(error.Message);
                throw;
            }

        }

        private void frmBatchReserve_Load(object sender, EventArgs e)
        {
            dsBuffedContents = bl.selectBuffedContents(ConfigurationManager.AppSettings["SiteID"]);
            clearControls();
            bindControls();
            if (dsBuffedContents != null)
                drBuffedContents = getBuffedContentStructure();
        }
        #endregion

        #region Developer Designed method
        private void bindControls()
        {
            if (dsBuffedContents != null)
            {
                if (dsBuffedContents.Tables["CRBatchHeader"].Rows.Count > 0)
                    txtCRBatCtrlNum.Text = dsBuffedContents.Tables["CRBatchHeader"].Rows[0][0].ToString();
                if (dsBuffedContents.Tables["CebuBatchHeader"].Rows.Count > 0)
                    txtCebuBatCtrlNum.Text = dsBuffedContents.Tables["CebuBatchHeader"].Rows[0][0].ToString();
                if (dsBuffedContents.Tables["BatchBuffTotal"].Rows.Count > 0)
                    txtTotalRemaining.Text = dsBuffedContents.Tables["BatchBuffTotal"].Rows[0][0].ToString();
                if (dsBuffedContents.Tables["BatchBuff"].Rows.Count > 0)
                    foreach (Control control in grpBoxCurrentReserve.Controls)
                    {
                        if (control is TraxDETextBox)
                        {
                            ((TraxDETextBox)control).Text = dsBuffedContents.Tables["BatchBuff"].Rows[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                        }
                    }
            }
        }

        private DataRow getBuffedContentStructure()
        {
            DataRow retval;            
            retval = dt.NewRow();
            return retval;
        }

        private bool isAllowedReserve()
        {
            bool retval = false;
            if (txtCRBatCtrlNum.Text.Trim() == string.Empty)
                return retval;
            if (txtReserve.Text.Trim() == string.Empty)
                return retval;
            if ((Convert.ToInt32(txtCRBatCtrlNum.Text.Trim()) + Convert.ToInt32(txtReserve.Text.Trim())) > 99999)
                return retval;
            retval = true;
            return retval;
        }

        private void clearControls()
        {
            txtCebuBatCtrlNum.Clear();
            txtCRBatCtrlNum.Clear();
            txtReserve.Clear();
            foreach (Control control in grpBoxCurrentReserve.Controls)
            {
                if (control is TraxDETextBox)
                {
                    ((TraxDETextBox)control).Clear();
                }
            }
        }

        private void setTableStructure()
        {
            dt.Columns.Add("BuffDate");
            dt.Columns.Add("OriginalCRBatCtrlNum");
            dt.Columns.Add("BuffedCRBatCtrlNum");
            dt.Columns.Add("StartBatCtrlNum");
            dt.Columns.Add("EndBatCtrlNum");
            dt.Columns.Add("OrigReservedCount");
            dt.Columns.Add("RemainingReservedCount");
            dt.Columns.Add("UserName");
        }
        #endregion
    }
}
