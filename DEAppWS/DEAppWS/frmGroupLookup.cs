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
    public partial class frmGroupLookup : Form
    {
        private DataSet ds = new DataSet();
        private DataView dv = new DataView();
        private DataRow dr;
        private bool selected = false;

        public bool Selected
        {
            get
            {
                return this.selected;
            }
        }

        public DataRow Row
        {
            get
            {
                return this.dr;
            }
        }

        public frmGroupLookup()
        {
            InitializeComponent();
        }

        public frmGroupLookup(DataSet dsGroup)
        {
            InitializeComponent();
            ds = dsGroup;
            dv.Table = ds.Tables[0];
            dr = getDataRowStructure();
        }

        #region events
        private void frmGroupLookup_Load(object sender, EventArgs e)
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
                updateRow();
                selected = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("No selected item.", this.Text);
            }
        }

        private void grdList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnOK_Click(null, null);
        }

        private void grdList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                e.Handled = true;
                btnOK_Click(null, null);

            }
        }

        private void frmGroupLookup_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdList.SelectedRows.Count > 0)
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
            this.dv.RowFilter = string.Format("[UserGroupDescription] LIKE '{0}%' OR [Mode] LIKE '{0}%' OR [Client] LIKE '{0}%' OR [SCAC] LIKE '{0}%' OR [DocumentType] LIKE '{0}%' OR [Language] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdList.DataSource = dv;
            this.grdList.Refresh();
        }

        private DataRow getDataRowStructure()
        {
            DataRow retval;
            retval = ds.Tables[0].NewRow();
            return retval;
        }

        private void updateRow()
        {
            dr["UserGroupID"] = grdList.SelectedRows[0].Cells["UserGroupID"].Value.ToString().Trim();
            dr["UserGroupDescription"] = grdList.SelectedRows[0].Cells["UserGroupDescription"].Value.ToString().Trim();
            dr["Mode"] = grdList.SelectedRows[0].Cells["Mode"].Value.ToString().Trim();
            dr["Client"] = grdList.SelectedRows[0].Cells["Client"].Value.ToString().Trim();
            dr["SCAC"] = grdList.SelectedRows[0].Cells["SCAC"].Value.ToString().Trim();
            dr["DocumentType"] = grdList.SelectedRows[0].Cells["DocumentType"].Value.ToString().Trim();
            dr["Language"] = grdList.SelectedRows[0].Cells["Language"].Value.ToString().Trim();
        }

        private bool isAllowedOK()
        {
            bool retval = false;
            if (grdList.SelectedRows.Count == 0)
                return retval;
            retval = true;
            return retval;
        }
        #endregion
    }
}
