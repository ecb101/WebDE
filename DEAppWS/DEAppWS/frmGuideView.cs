using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//using BLogic;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmGuideView : Form
    {
        //GuidelineBL bl = new GuidelineBL();
        protected string OwnerKey;
        protected string SCAC;
        protected DataSet ds = new DataSet();
        protected DataView dv = new DataView();
        private string guide;
        private bool pickGuide = false;
        private bool isNeededPick;
        public string Guide
        {
            get
            {
                return this.guide;
            }
        }

        public bool PickGuide
        {
            get
            {
                return this.pickGuide;
            }
        }

        public frmGuideView()
        {
            InitializeComponent();
        }

        public frmGuideView(string OwnerKey, string SCAC, bool isNeededPick)
        {
            InitializeComponent();
            this.OwnerKey = OwnerKey;
            this.SCAC = SCAC;
            //ds = bl.selectGuide(this.OwnerKey, this.SCAC);
            bindGrid();
            this.isNeededPick = isNeededPick;
        }

        #region Developer Designed method
        private void bindGrid()
        {
            if (ds == null)
            {
                if ((DataView)grdList.DataSource != null)
                {
                    if (dv.Table != null)
                        dv.Table.Rows.Clear();
                    grdList.DataSource = dv;
                    grdList.ClearSelection();
                }
            }
            else
            {
                dv.RowFilter = string.Format("[CarrierName] LIKE '{0}%'", this.txtSearch.Text.Trim());
                dv.Table = ds.Tables[0];
                this.grdList.DataSource = dv;
                this.grdList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.grdList.Refresh();
            }
        }

        private string getFile(string filename, Byte[] file)
        {
            string folder = string.Format("{0}{1}", Environment.SystemDirectory.Split('\\')[0], "\\TempGuideline");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string completeFilename = string.Format("{0}\\{1}", folder, filename);

            using (BinaryWriter binWriter = new BinaryWriter(File.Open(completeFilename, FileMode.Create, FileAccess.ReadWrite)))
                binWriter.Write(file);

            return completeFilename;
        }

        private static void showFile(string completeFilename)
        {
            ProcessStartInfo procInfo = new ProcessStartInfo();
            procInfo.FileName = completeFilename;

            Process proc = new Process();
            proc.StartInfo = procInfo;
            proc.Start();
        }

        public string viewFile(string filename, Byte[] file)
        {
            string completePath = getFile(filename, file);
            showFile(completePath);

            return completePath;
        }
        #endregion

        private void grdList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == grdList.Columns["ViewGuide"].Index && e.RowIndex >= 0)
            {
                try
                {
                    viewFile(this.grdList.Rows[e.RowIndex].Cells["Filename"].Value.ToString(), (Byte[])this.grdList.Rows[e.RowIndex].Cells["FileC"].Value);
                }
                catch
                { }
            }
            else if (e.ColumnIndex == grdList.Columns["UseGuide"].Index && e.RowIndex >= 0)
            {
                try
                {
                    deleteTempFiles();
                    this.guide = this.grdList.Rows[e.RowIndex].Cells["CarrierName"].Value.ToString() + "|FORMAT " + this.grdList.Rows[e.RowIndex].Cells["Format"].Value.ToString() + "|" + this.grdList.Rows[e.RowIndex].Cells["LatestVersion"].Value.ToString() + "|" + this.grdList.Rows[e.RowIndex].Cells["Filename"].Value.ToString();
                    viewFile(this.grdList.Rows[e.RowIndex].Cells["Filename"].Value.ToString(), (Byte[])this.grdList.Rows[e.RowIndex].Cells["FileC"].Value);
                    this.pickGuide = true;
                    this.Close();
                }
                catch (Exception error)
                {
                    throw error;
                }
            }
        }

        private void btnNoGuide_Click(object sender, EventArgs e)
        {
            this.guide = "No Guide|||";
            this.pickGuide = true;
            this.Close();
        }

        private void deleteTempFiles()
        {
            //delete temp files
            string folder = string.Format("{0}{1}", Environment.SystemDirectory.Split('\\')[0], "\\TempGuideline");

            if (Directory.Exists(folder))
                try
                {
                    Directory.Delete(folder, true);
                }
                catch
                {
                    throw new Exception("Please close all open guidelines before proceeding.");
                }
        }

        private void frmGuideView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isNeededPick && !pickGuide)
            {
                MessageBox.Show("You must pick at least one guide or press the [No Guide Available] button", "Guide View");
                e.Cancel = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindGrid();
        }
    }
}
