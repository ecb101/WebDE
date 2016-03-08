using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;

namespace DEAppWS
{
    public partial class frmFBCountCorrection : Form
    {
        private DataSet ds = new DataSet();
        private DataView dv = new DataView();
        private ArrayList parameter = new ArrayList();
        private FBCountCorrectionBL.FBCountCorrectionBL bl = new FBCountCorrectionBL.FBCountCorrectionBL();
        public frmFBCountCorrection()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
        }

        private void frmFBCountCorrection_Load(object sender, EventArgs e)
        {
            ds = bl.selectBatch();
            bindGrid();
        }
        
        #region Developer Designed method
        private void bindGrid()
        {
            dv.Table = ds.Tables[0];
            this.dv.RowFilter = string.Format("Bat_Ctrl_Num LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdBatches.DataSource = dv;
            this.grdBatches.AutoResizeColumns();
            this.grdBatches.Refresh();
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void chkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdBatches.Rows)
            {
                row.Cells["Correction"].Value = chkBoxAll.Checked;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to implement FB count correction on these batches?", "FB Count Correction", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataTable batch = new DataTable("BatchTable");
                batch.Columns.Add("Bat_Ctrl_Num");
                batch.Columns.Add("Owner_Key");
                batch.Columns.Add("Vend_SCAC");
                batch.Columns.Add("NEW_DTM");
                batch.Columns.Add("CorrectCount");
                DataRow temp;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (Convert.ToBoolean(row["Correction"]))
                    {
                        temp = batch.NewRow();
                        temp["Bat_Ctrl_Num"] = row["Bat_Ctrl_Num"];
                        temp["Owner_Key"] = row["Owner_Key"];
                        temp["Vend_SCAC"] = row["Vend_SCAC"];
                        temp["NEW_DTM"] = row["NEW_DTM"];
                        if (radioBtnDE.Checked)                        
                            temp["CorrectCount"] = row["DataEntry_FB_Cnt"];
                        
                        else                        
                            temp["CorrectCount"] = row["Batching_FB_Cnt"];

                        batch.Rows.Add(temp);                       
                    }
                }
                if (batch.Rows.Count > 0)
                {
                    if (bl.UpdateFBCountCorrection(txtNote.Text, batch, radioBtnDE.Checked == true ? "Data Entry" : "Batching", System.Environment.UserName))
                    {
                        ds = bl.selectBatch();
                        bindGrid();
                        MessageBox.Show("Batches are successfully implemented FB count correction.", "FB Count Correction");
                    }
                }
                else
                    MessageBox.Show("There are no batches corrected.", "FB Count Correction");
            }
        }
    }
}
