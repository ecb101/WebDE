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
    public partial class frmErrorList : Form
    {
        private DataTable dtErrorList = new DataTable();
        private DataView dvErrorList = new DataView();
        public frmErrorList()
        {
            InitializeComponent();
        }

        public frmErrorList(DataTable ErrorList)
        {
            InitializeComponent();
            dtErrorList = ErrorList;
        }

        private void frmErrorList_Load(object sender, EventArgs e)
        {
            dvErrorList.Table = dtErrorList;
            //this.dvErrorList.RowFilter = string.Format("[Batch Number] LIKE '{0}%' OR [Vendor SCAC] LIKE '{0}%' OR [OwnerCode] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdErrorList.DataSource = dvErrorList;
            this.grdErrorList.AutoResizeColumns();
            this.grdErrorList.Refresh();
        }
    }
}
