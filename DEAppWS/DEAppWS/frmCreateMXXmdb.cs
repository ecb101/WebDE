using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmCreateMXXmdb : Form
    {
        private CreateMXXmdbBL.CreateMXXmdbBL bl = new CreateMXXmdbBL.CreateMXXmdbBL();
        private string MXXDatabase = string.Empty;
        private DataSet dsBatch = new DataSet();
        private DataSet ds = new DataSet();
        public frmCreateMXXmdb()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
        }

        #region events
        private void btnCreate_Click(object sender, EventArgs e)
        {
            ofdOpenObjectFile.InitialDirectory = ConfigurationManager.AppSettings["ObjDestinationPath"];
            ofdOpenObjectFile.Filter = string.Format("MXX Object files (*.mxx)|{0}.mxx", "*");
            ofdOpenObjectFile.FileName = string.Empty;
            ofdOpenObjectFile.ShowDialog();
            if (ofdOpenObjectFile.FileName != string.Empty)
            {
                try
                {
                    MXXDatabase = getMXXName(CommonMethod.getFileName(ofdOpenObjectFile.FileName));
                    if (this.makeMDBCopy(MXXDatabase.Trim()))//copy mxx template                    
                    {                        
                        dsBatch = bl.selectBatchObj(MXXDatabase);//populate dataset using the mxx object file
                        ds = bl.selectDetail(MXXDatabase);//get info for TR Bat
                        bl.insertTRBat(dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString(), "MXX"+MXXDatabase, Convert.ToDateTime(ds.Tables[0].Rows[0]["DateStart"]), ds.Tables[0].Rows[0]["Operator"].ToString());//update TRBat
                        bl.saveBatch(dsBatch, MXXDatabase, dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString());//populate save dataset in the mxx
                        MessageBox.Show("Creation successful.", "Create MXX Database");
                    }
                    else
                    {
                        MessageBox.Show("Could not create because the MXX Database already exists.", "Create MXX Database");
                    }
                }
                catch (Exception error)
                {
                    if (File.Exists(ConfigurationManager.AppSettings["MDBSourcePath"] + "MXX" + MXXDatabase + ".mdb"))
                        File.Delete(ConfigurationManager.AppSettings["MDBSourcePath"] + "MXX" + MXXDatabase + ".mdb");
                    throw error;
                }
            }
        }
        #endregion

        #region Developer Designed method
        private bool makeMDBCopy(string batchNumber)
        {
            bool retval = false;
            string filePath = ConfigurationManager.AppSettings["MDBSourcePath"] + "batchxxx";
            string newfile = ConfigurationManager.AppSettings["MDBSourcePath"] + "MXX" + batchNumber + ".mdb";
            if (!File.Exists(newfile))
            {
                try
                {
                    File.Copy(filePath, newfile);
                    retval = true;
                }
                catch (Exception e)
                {
                    retval = false;
                    throw e;                    
                }
            }
            else
                retval = false;
            return retval;
        }

        private string getMXXName(string filename)
        {
            string[] file = filename.Split('.');
            return file[0];
        }
        #endregion
    }
}
