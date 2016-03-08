using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmImageResolution : Form
    {
        private ImageResolutionBL.ImageResolutionBL bl = new ImageResolutionBL.ImageResolutionBL();
        private DataSet dsRD = new DataSet();
        private DataSet dsImages = new DataSet();
        private DataView dvRDReason = new DataView();
        private DataView dvRDResolution = new DataView();
        private DataView dvImages = new DataView();
        private string Category = "R";
        private DataTable dtImageResolution = new DataTable("ImageResolution");
        public frmImageResolution()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            dsRD = bl.selectResolutionDescription();            
            setDropDownList();
        }

        #region events
        private void frmImageResolution_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsImages = bl.selectImages();
            bindgrdImages();
            this.Cursor = Cursors.Default;
        }

        private void ddlReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtReasonCode.Text = getCode(true);
        }

        private void ddlResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtResolutionCode.Text = getCode(false);
        }
                
        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {            
            bindgrdImages();
            setDropDownList();            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isAllowedImplementation())
            {
                if (MessageBox.Show("Are you sure to implement image resolution?", "Image Resolution", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dtImageResolution.Clear();
                    DataRow dr = getImageResolutionStructure();                                   
                    dr = setImageResolutionValues(dr);
                    dtImageResolution.Rows.Add(dr);
                    if (radioBtnReceived.Checked)
                    {
                        bl.implementImageResolutionReceived(dtImageResolution, System.Environment.UserName);
                    }
                    if (radioBtnManifesting.Checked)
                    {
                        dr["ToFolder"] = ConfigurationManager.AppSettings["ImageIssueManifesting"] + dr["FromFolder"].ToString().Substring(ConfigurationManager.AppSettings["RootManifestPath"].Length, (dr["FromFolder"].ToString().Length - ConfigurationManager.AppSettings["RootManifestPath"].Length));
                        bl.implementImageResolutionManifestingBatching(dtImageResolution, grdImages.SelectedRows[0].Cells["NewFileName"].Value.ToString().Trim(), true, chkBoxCombinedImage.Checked, System.Environment.UserName);
                    }
                    if (radioBtnBatching.Checked)
                    {
                        if (txtReasonCode.Text == "44")//not for batching
                            dr["ToFolder"] = ConfigurationManager.AppSettings["ImageNotForBatching"] + dr["FromFolder"].ToString().Substring(ConfigurationManager.AppSettings["ImageSourcePath"].Length, (dr["FromFolder"].ToString().Length - ConfigurationManager.AppSettings["ImageSourcePath"].Length));
                        else//error images
                            dr["ToFolder"] = ConfigurationManager.AppSettings["ImageIssueBatching"] + dr["FromFolder"].ToString().Substring(ConfigurationManager.AppSettings["ImageSourcePath"].Length, (dr["FromFolder"].ToString().Length - ConfigurationManager.AppSettings["ImageSourcePath"].Length));
                        bl.implementImageResolutionManifestingBatching(dtImageResolution, grdImages.SelectedRows[0].Cells["NewFileName"].Value.ToString().Trim(), false, chkBoxCombinedImage.Checked, System.Environment.UserName);
                    }
                    this.Cursor = Cursors.WaitCursor;
                    dsImages = bl.selectImages();
                    bindgrdImages();
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Make sure all required fields are not empty.", "Image Resolution");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrdImages();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dsImages = bl.selectImages();
            bindgrdImages();
            this.Cursor = Cursors.Default;
        }

        private void chkBoxCombinedImage_CheckedChanged(object sender, EventArgs e)
        {            
            bindgrdImages();
            setDropDownList();            
        }
        #endregion

        #region Developer Designed method
        private void bindgrdImages()
        {
            if (radioBtnReceived.Checked)
            {
                chkBoxCombinedImage.Checked = false;
                chkBoxCombinedImage.Enabled = false;
                dvImages.Table = dsImages.Tables["Received"];
                Category = "R";
            }
            else
                chkBoxCombinedImage.Enabled = true;
            if (radioBtnManifesting.Checked)
            {
                if (chkBoxCombinedImage.Checked)
                {
                    dvImages.Table = dsImages.Tables["CombinedManifesting"];
                }
                else
                {
                    dvImages.Table = dsImages.Tables["Manifesting"];
                }
                Category = "M";
            }
            if (radioBtnBatching.Checked)
            {
                if (chkBoxCombinedImage.Checked)
                {
                    dvImages.Table = dsImages.Tables["CombinedBatching"];
                }
                else
                {
                    dvImages.Table = dsImages.Tables["Batching"];
                }
                Category = "B";
            }
            this.dvImages.RowFilter = string.Format("[ID] LIKE '{0}%' OR [FullFolderPath] LIKE '{0}%' OR [OriginalFileName] LIKE '{0}%' OR [NewFolderPath] LIKE '{0}%' OR [NewFileName] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdImages.DataSource = dvImages;
            this.grdImages.AutoResizeColumns();
            this.grdImages.Refresh();            
        }

        private string getCode(bool isReason)
        {
            string[] retval;
            if (isReason)
            {
                if (this.ddlReason.SelectedValue != null)
                    retval = this.ddlReason.SelectedValue.ToString().Split('(');
                else
                    return "";
            }
            else
            {
                if (this.ddlResolution.SelectedValue != null)
                    retval = this.ddlResolution.SelectedValue.ToString().Split('(');
                else
                    return "";
            }
            return retval[retval.Length - 1].Trim(')');
        }

        private void setDropDownList()
        {            
            this.dvRDReason.Table = dsRD.Tables[0];
            this.dvRDReason.RowFilter = string.Format("[Type] = 'Reason' AND [Category] = '{0}'", Category);
            this.ddlReason.DisplayMember = "ResolutionDescription";
            this.ddlReason.ValueMember = "ResolutionDescription";
            this.ddlReason.DataSource = dvRDReason;
            this.ddlReason.Refresh();
            ddlReason_SelectedIndexChanged(null, null);
            this.dvRDResolution.Table = dsRD.Tables[0];
            this.dvRDResolution.RowFilter = string.Format("[Type] = 'Resolution' AND [Category] = '{0}'", Category);            
            this.ddlResolution.DisplayMember = "ResolutionDescription";
            this.ddlResolution.ValueMember = "ResolutionDescription";
            this.ddlResolution.DataSource = dvRDResolution;
            this.ddlResolution.Refresh();
            ddlResolution_SelectedIndexChanged(null, null);
        }

        private bool isAllowedImplementation()
        {
            if (txtAction.Text.Equals(string.Empty))
                return false;
            else if (ddlReason.SelectedValue == null)
                return false;
            else if (txtReasonDescription.Text.Equals(string.Empty))
                return false;
            else if (ddlResolution.SelectedValue == null)
                return false;
            else
                return true;            
        }

        private DataRow getImageResolutionStructure()
        {
            DataRow retval;            
            dtImageResolution.Columns.Add("ID");
            dtImageResolution.Columns.Add("Category");
            dtImageResolution.Columns.Add("ReasonCode");
            dtImageResolution.Columns.Add("ReasonDescription");
            dtImageResolution.Columns.Add("ResolutionCode");
            dtImageResolution.Columns.Add("ResolutionAction");
            dtImageResolution.Columns.Add("FromFolder");
            dtImageResolution.Columns.Add("ToFolder");
            retval = dtImageResolution.NewRow();
            return retval;
        }

        private DataRow setImageResolutionValues(DataRow row)
        {
            row["ID"] = grdImages.SelectedRows[0].Cells["ID"].Value.ToString().Trim();
            row["Category"] = Category;
            row["ReasonCode"] = txtReasonCode.Text;
            row["ReasonDescription"] = txtReasonDescription.Text;
            row["ResolutionCode"] = txtResolutionCode.Text;
            row["ResolutionAction"] = txtAction.Text;
            row["FromFolder"] = grdImages.SelectedRows[0].Cells["NewFolderPath"].Value.ToString().Trim();
            row["ToFolder"] = "";
            return row;
        }
        #endregion
    }
}
