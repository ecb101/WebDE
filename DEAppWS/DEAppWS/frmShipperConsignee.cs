using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DEAppWS
{
    public partial class frmShipperConsignee : Form
    {
        private DataTable dtInfo = new DataTable();
        private DataView dvInfo = new DataView();
        private DataRow drInfo;
        private bool infoSelected = false;

        public bool InfoSelected
        {
            get
            {
                return this.infoSelected;
            }
        }

        public DataRow InfoRow
        {
            get
            {
                return this.drInfo;
            }
        }

        public frmShipperConsignee()
        {
            InitializeComponent();
        }

        public frmShipperConsignee(DataTable info, string infoType)
        {
            InitializeComponent();
            this.dtInfo = info;
            this.Text = infoType;
            drInfo = getInfoStructure();
        }

        #region events
        private void grdInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                btnOK_Click(null, null);

            }
        }

        private void grdInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnOK_Click(null, null);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void frmShipperConsignee_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmShipperConsignee_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void frmShipperConsignee_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdInfo.SelectedRows.Count > 0)
            {
                if (e.KeyValue == 13)
                {
                    btnOK_Click(null, null);
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isAllowedOK())
            {
                updatedChargeCode();
                infoSelected = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("No selected information.", "Information Lookup");
            }
        }
        #endregion

        #region Developer Designed method
        private void bindGrid()
        {
            this.dvInfo.Table = dtInfo;
            this.dvInfo.RowFilter = string.Format("Name1 LIKE '{0}%' OR Name2 LIKE '{0}%' OR Address1 LIKE '{0}%' OR Address2 LIKE '{0}%' OR City LIKE '{0}%' OR St LIKE '{0}%' OR Zip LIKE '{0}%' OR Country LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdInfo.DataSource = dvInfo;
            this.grdInfo.AutoResizeColumns();
            this.grdInfo.Refresh();
        }

        private DataRow getInfoStructure()
        {
            DataRow retval;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name1");
            dt.Columns.Add("Name2");
            dt.Columns.Add("Address1");
            dt.Columns.Add("Address2");
            dt.Columns.Add("City");
            dt.Columns.Add("St");
            dt.Columns.Add("Zip");
            dt.Columns.Add("Country");
            retval = dt.NewRow();
            return retval;
        }

        private void updatedChargeCode()
        {
            drInfo["Name1"] = grdInfo.SelectedRows[0].Cells["Name1"].Value.ToString().Trim();
            drInfo["Name2"] = grdInfo.SelectedRows[0].Cells["Name2"].Value.ToString().Trim();
            drInfo["Address1"] = grdInfo.SelectedRows[0].Cells["Address1"].Value.ToString().Trim();
            drInfo["Address2"] = grdInfo.SelectedRows[0].Cells["Address2"].Value.ToString().Trim();
            drInfo["City"] = grdInfo.SelectedRows[0].Cells["City"].Value.ToString().Trim();
            drInfo["St"] = grdInfo.SelectedRows[0].Cells["St"].Value.ToString().Trim();
            drInfo["Zip"] = grdInfo.SelectedRows[0].Cells["Zip"].Value.ToString().Trim();
            drInfo["Country"] = grdInfo.SelectedRows[0].Cells["Country"].Value.ToString().Trim();
            
        }

        private bool isAllowedOK()
        {
            bool retval = false;
            if (grdInfo.SelectedRows.Count == 0)
                return retval;
            retval = true;
            return retval;
        }
        #endregion
    }
}
