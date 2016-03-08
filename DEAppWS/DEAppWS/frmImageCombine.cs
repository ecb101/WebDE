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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmImageCombine : Form
    {
        private ImageCombineBL.ImageCombineBL bl = new ImageCombineBL.ImageCombineBL();
        private Regex regStr = new Regex("[^a-zA-Z0-9]");
        public frmImageCombine()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
        }

        #region events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ofdOpenImageFiles.InitialDirectory = ConfigurationManager.AppSettings["RootManifestPath"];
            ofdOpenImageFiles.ShowDialog();
        }

        private void ofdOpenImageFiles_FileOk(object sender, CancelEventArgs e)
        {
            bool duplicateFile = false;
            string msg = string.Empty;
            foreach (string filename in ofdOpenImageFiles.FileNames)
            {
                if (lstBoxImages.Items.Contains(filename) 
                    || !bl.imageInDatabase(CommonMethod.getFileName(filename)) 
                    || (!filename.Contains(ConfigurationManager.AppSettings["ImageSourcePath"]) && !filename.Contains(ConfigurationManager.AppSettings["RootManifestPath"])))
                {
                    duplicateFile = true;
                }                
                else
                {
                    lstBoxImages.Items.Add(filename);
                }
            }
            if (duplicateFile)
            {
                MessageBox.Show("One or more files that were not added is due to the following reasons:\n1. It already exist on the list.\n2. The file is not in the proper folder structure.\n3. The file is not allowed for image combine due to it was not properly recorded in the database.", "Image Combine");
            }
            enableButton();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            object[] temp = new object[lstBoxImages.SelectedItems.Count];
            int i = 0;
            foreach (object item in lstBoxImages.SelectedItems)
            {
                temp[i] = item;
                i++;
            }

            foreach (object item in temp)
            { 
                this.lstBoxImages.Items.Remove(item);
            }                
        }

        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (this.lstBoxImages.Items.Count > 1)
            {
                string[] files = new string[this.lstBoxImages.Items.Count];
                string newFilename = string.Empty;
                int counter = 0;
                foreach (object file in this.lstBoxImages.Items)
                {
                    files[counter] = file.ToString();
                    counter++;
                }
                newFilename = bl.combineImage(files, txtFilename.Text.Trim(), ConfigurationManager.AppSettings["SiteID"], System.Environment.UserName);
                if (newFilename != string.Empty)
                {
                    //combineImage(newFilename);
                    //moveFiles(CommonMethod.getFileName(newFilename).Split('.')[0]);
                    MessageBox.Show("Image creation successful.\nNew image file : " + newFilename, "Image Combine");
                    lstBoxImages.Items.Clear();
                }
            }
        }

        private void lstBoxImages_SelectedValueChanged(object sender, EventArgs e)
        {
            enableButton();
        }

        private void frmImageCombine_Load(object sender, EventArgs e)
        {
            enableButton();
        }

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            txtFilename.Text = regStr.Replace(txtFilename.Text, string.Empty);
        }
        #endregion

        #region Developer Designed method
        private void enableButton()
        {
            btnRemove.Enabled = lstBoxImages.SelectedItems.Count == 0 ? false : true;
            btnCombine.Enabled = lstBoxImages.Items.Count > 1 ? true : false;
        }
        #endregion        
    }
}
