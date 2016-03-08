using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmBatchDeactivation : Form
    {
        private DataSet ds = new DataSet();
        private DataSet dsReason = new DataSet();
        private DataView dv = new DataView();
        private DataView dvReason = new DataView();
        private ArrayList parameter = new ArrayList();
        private DeactivateBatchesBL.DeactivateBatchesBL bl = new DeactivateBatchesBL.DeactivateBatchesBL();
        public frmBatchDeactivation()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            dsReason= bl.selectReasonDescription();
            setDropDownList();
        }

        #region events
        private void frmBatchDeactivation_Load(object sender, EventArgs e)
        {
            ds = bl.selectBatch(false);
            bindGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void chkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdBatches.Rows)
            {
                row.Cells["Active"].Value = chkBoxAll.Checked;
            }
        }

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnDeactivate.Checked)
            {
                if (radioBtnReason1.Checked)
                {
                    ddlReason.SelectedItem = null;
                    ddlReason.Enabled = true;
                    txtReason.Clear();
                    txtReason.ReadOnly = true;
                }
                else
                {
                    ddlReason.SelectedItem = null;
                    ddlReason.Enabled = false;
                    txtReason.Clear();
                    txtReason.ReadOnly = false;
                }
                enableButton();
            }
        }

        private void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void radioBtnType_CheckedChanged(object sender, EventArgs e)
        {
            ds = bl.selectBatch(radioBtnReactivate.Checked);
            bindGrid();
            if (radioBtnDeactivate.Checked)
            {
                btnOK.Text = "Deactivate";
                radioBtn_CheckedChanged(null, null);
                grpBoxReason.Enabled = true;
            }
            else
            {
                btnOK.Text = "Reactivate";
                txtReason.ReadOnly = true;
                ddlReason.Enabled = false;
                grpBoxReason.Enabled = false;
            }
            ddlReason.SelectedItem = null;
            txtReason.Clear();
            enableButton();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (radioBtnDeactivate.Checked)
            {
                if (MessageBox.Show("Are you sure to disable these batches?", "Batch Deactivation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataTable batch = new DataTable("BatchTable");
                    batch.Columns.Add("Bat_Ctrl_Num");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (!Convert.ToBoolean(row["Active"]))
                        {
                            batch.Rows.Add(row["Bat_Ctrl_Num"].ToString());
                        }
                    }
                    if (bl.UpdateBatch(radioBtnReason1.Checked == true ? ddlReason.SelectedValue.ToString().Trim() : txtReason.Text.Trim(), batch, radioBtnReason1.Checked, System.Environment.UserName))
                    {
                        ds = bl.selectBatch(false);
                        bindGrid();
                        MessageBox.Show("Batches are successfully deactivated.", "Batch Deactivation");
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure to enable these batches?", "Batch Deactivation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    DataTable batch = new DataTable("BatchTable");
                    batch.Columns.Add("Bat_Ctrl_Num");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        if (Convert.ToBoolean(row["Active"]))
                        {
                            batch.Rows.Add(row["Bat_Ctrl_Num"].ToString());
                        }
                    }
                    if (bl.UpdateBatchReactivate(batch,System.Environment.UserName))
                    {
                        ds = bl.selectBatch(true);
                        bindGrid();
                        MessageBox.Show("Batches are successfully reactivated.", "Batch Deactivation");
                    }
                }
            }
        }
        #endregion

        #region Developer Designed method
        private void bindGrid()
        {
            dv.Table = ds.Tables[0];
            this.dv.RowFilter = string.Format("Bat_Ctrl_Num LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdBatches.DataSource = dv;
            this.grdBatches.Refresh();
        }

        private void enableButton()
        {
            if (radioBtnDeactivate.Checked)
            {
                if (radioBtnReason1.Checked)
                {
                    btnOK.Enabled = ddlReason.SelectedItem == null ? false : true;
                }
                else
                {
                    btnOK.Enabled = txtReason.Text.Trim() == string.Empty ? false : true;
                }
            }
            else
                btnOK.Enabled = true;
        }
        #endregion

        private void setDropDownList()
        {
            this.dvReason.Table = dsReason.Tables[0];
            this.ddlReason.DisplayMember = "Description";
            this.ddlReason.ValueMember = "Description";
            this.ddlReason.DataSource = dvReason;
            this.ddlReason.Refresh();
            ddlReason_SelectedIndexChanged(null, null);
        }
       
    }
}
