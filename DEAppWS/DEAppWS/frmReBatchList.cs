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
    public partial class frmReBatchList : Form
    {
        public string gBatchNumber = string.Empty;
        public string gFilePath = string.Empty;
        private DataView dvBatches = new DataView();
        private DataSet dsBatches = new DataSet();
        private VirtualMailRoomBatchSolutionBL.VirtualMailRoomBatchSolutionBL bl = new VirtualMailRoomBatchSolutionBL.VirtualMailRoomBatchSolutionBL();
        public string getBatchNumber { get { return gBatchNumber; } }
        public string getFilePath { get { return gFilePath; } }
        
        public frmReBatchList()
        {
            InitializeComponent();
        }

        private void bindgrdBatches()
        {            
            dvBatches.Table = dsBatches.Tables[0];
            this.dvBatches.RowFilter = string.Format("[BatchNumber] LIKE '{0}%' OR [FilePath] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdBatchList.DataSource = dvBatches;
            this.grdBatchList.Refresh();         
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.grdBatchList.Rows.Count > 0 && this.grdBatchList.SelectedRows.Count > 0)
            {
                this.gBatchNumber = this.grdBatchList.Rows[grdBatchList.SelectedRows[0].Index].Cells["BatchNumber"].Value.ToString();
                this.gFilePath = this.grdBatchList.Rows[grdBatchList.SelectedRows[0].Index].Cells["FilePath"].Value.ToString();
            }
            else
            {
                this.gBatchNumber = "12345";
                this.gFilePath = @"\\FXCEBWS3095\DETest\Images\MAILROOM\BATCHING\71760.tif";
            }
           this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsBatches = bl.selectReBatches();
            bindgrdBatches();
            this.Cursor = Cursors.Default;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsBatches = bl.selectReBatches();
            bindgrdBatches();
            this.Cursor = Cursors.Default;
        }

        private void frmReBatchList_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsBatches = bl.selectReBatches();
            bindgrdBatches();
            this.Cursor = Cursors.Default;
        }
        
    }
}
