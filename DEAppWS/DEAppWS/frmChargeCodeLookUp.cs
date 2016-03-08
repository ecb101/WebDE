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
    public partial class frmChargeCodeLookUp : Form
    {
        private DataView dvChargeCode = new DataView();
        private DataRow drChargeCode;
        private bool chargeCodeSelected = false;

        public bool ChargeCodeSelected
        {
            get
            {
                return this.chargeCodeSelected;
            }
        }

        public DataRow ChargeCodeRow
        {
            get
            {
                return this.drChargeCode;
            }
        }

        public frmChargeCodeLookUp()
        {
            InitializeComponent();
        }

        public frmChargeCodeLookUp(DataView dv)
        {
            InitializeComponent();
            dvChargeCode = dv;
            drChargeCode = getChargeCodeStructure();
        }

        #region events
        private void frmChargeCodeLookUp_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isAllowedOK())
            {
                updatedChargeCode();
                chargeCodeSelected = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("No selected charge code.", "Charge Code Lookup");
            }
        }

        private void grdChargeCode_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnOK_Click(null, null);
        }

        private void grdChargeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                btnOK_Click(null, null);

            }
        }

        private void frmChargeCodeLookUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!chargeCodeSelected)
            //{
            //    e.Cancel = true; ;
            //}
        }

        private void frmChargeCodeLookUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdChargeCode.SelectedRows.Count > 0)
            {
                if (e.KeyValue == 13)
                {
                    btnOK_Click(null, null);
                }
            }
        }
        #endregion

        #region Developer Designed method
        private void bindGrid()
        {
            this.dvChargeCode.RowFilter = string.Format("[LnCat] LIKE '{0}%' OR [LnChrgCode] LIKE '{0}%' OR [LnChrgDesc] LIKE '{0}%' ", this.txtSearch.Text.Trim());
            this.grdChargeCode.DataSource = dvChargeCode;
            this.grdChargeCode.Refresh();
        }

        private DataRow getChargeCodeStructure()
        {
            DataRow retval;
            DataTable dtChargeCode = new DataTable();
            dtChargeCode.Columns.Add("LnCat");
            dtChargeCode.Columns.Add("LnChrgCode");
            dtChargeCode.Columns.Add("LnChrgDesc");
            retval = dtChargeCode.NewRow();
            return retval;
        }

        private void updatedChargeCode()
        {
            drChargeCode["LnCat"] = grdChargeCode.SelectedRows[0].Cells["ChargeCodeLnCat"].Value.ToString().Trim();
            drChargeCode["LnChrgCode"] = grdChargeCode.SelectedRows[0].Cells["ChargeCodeLnChrgCode"].Value.ToString().Trim();
            drChargeCode["LnChrgDesc"] = grdChargeCode.SelectedRows[0].Cells["ChargeCodeLnChrgDesc"].Value.ToString().Trim();
        }

        private bool isAllowedOK()
        {
            bool retval = false;
            if (grdChargeCode.SelectedRows.Count == 0)            
                return retval;
            retval = true;
            return retval;
        }
        #endregion
        
    }
}
