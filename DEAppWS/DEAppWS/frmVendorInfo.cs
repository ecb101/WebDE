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
//using BLogic;
using FormControls;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmVendorInfo : Form
    {
        private string SCAC = string.Empty;
        private DataSet dsVendorInfo = new DataSet();
        private DataView dvVendorInfo = new DataView();
        private VendorInfoBL.VendorInfoBL bl = new VendorInfoBL.VendorInfoBL();
        private bool vendorInfoSelected = false;
        private DataRow drVendorInfo;
        private bool isEditMode;
        private int editIndex;
        private DataTable dtOriginalVendorInfo = new DataTable();
        public DataRow VendorInfoRow
        {
            get
            {
                return this.drVendorInfo;
            }
        }

        public bool VendorInfoSelected
        {
            get
            {
                return this.vendorInfoSelected;
            }
        }

        public frmVendorInfo()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            dtOriginalVendorInfo.Clear();
            drVendorInfo = getVendorInfoStructure();
        }

        public frmVendorInfo(string SCAC)
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            this.SCAC = SCAC;
            isEditMode = false;
            drVendorInfo = getVendorInfoStructure();
        }

        public frmVendorInfo(string SCAC, int RemitId, DataTable VendorInfoContents)
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            btnOK.Text = "&Update";
            this.SCAC = SCAC;
            isEditMode = true;
            this.editIndex = RemitId;
            drVendorInfo = getVendorInfoStructure();
            dtOriginalVendorInfo = VendorInfoContents;
        }

        #region events
        private void frmVendorInfo_Load(object sender, EventArgs e)
        {
            txtVendorSCAC.Text = SCAC;
            if (isEditMode)
            {
                if (!bl.isVendorInfoContentsEqual(dtOriginalVendorInfo))//if different bill to contents
                {                    
                    
                    //add new record
                    int ID = (bl.selectVendorInfoCount(SCAC) + 1);
                    string newBatLocIdRemit = SCAC + ID.ToString().PadLeft(5, '0');
                    txtRemitIndex.Text = newBatLocIdRemit;
                    drVendorInfo["VendLabl"] = dtOriginalVendorInfo.Rows[0]["VendLabl"];
                    drVendorInfo["LocIdRemit"] = newBatLocIdRemit;
                    drVendorInfo["AlRemit1"] = dtOriginalVendorInfo.Rows[0]["AlRemit1"];
                    drVendorInfo["AlRemit2"] = dtOriginalVendorInfo.Rows[0]["AlRemit2"];
                    drVendorInfo["AlRemit3"] = dtOriginalVendorInfo.Rows[0]["AlRemit3"];
                    drVendorInfo["AlRemit4"] = dtOriginalVendorInfo.Rows[0]["AlRemit4"];
                    drVendorInfo["AlCityRemit"] = dtOriginalVendorInfo.Rows[0]["AlCityRemit"];
                    drVendorInfo["AlStateProvRemit"] = dtOriginalVendorInfo.Rows[0]["AlStateProvRemit"];
                    drVendorInfo["AlPostCodeRemit"] = dtOriginalVendorInfo.Rows[0]["AlPostCodeRemit"];
                    drVendorInfo["AlCntryCodeRemit"] = dtOriginalVendorInfo.Rows[0]["AlCntryCodeRemit"];

                    string vendorInfo = "-" + drVendorInfo["AlRemit1"].ToString().Trim() + "-" + drVendorInfo["AlRemit2"].ToString().Trim() + "-" + drVendorInfo["AlRemit3"].ToString().Trim() + "-" + drVendorInfo["AlRemit4"].ToString().Trim() + "-" + drVendorInfo["AlCityRemit"].ToString().Trim() + "-" + drVendorInfo["AlStateProvRemit"].ToString().Trim() + "-" + drVendorInfo["AlPostCodeRemit"].ToString().Trim() + "-" + drVendorInfo["AlCntryCodeRemit"].ToString().Trim();
                    
                    if (!bl.isVendorInfoExisting(SCAC, vendorInfo))
                    {
                        if (bl.addVendorInfo(dtOriginalVendorInfo))
                        {                            
                            vendorInfoSelected = true;
                            editIndex = ID;//update ID base on the new record
                        }                        
                    }
                    else
                    {
                        drVendorInfo["LocIdRemit"] = bl.getBatLocIdRemit(SCAC, vendorInfo);
                        vendorInfoSelected = true;
                        editIndex = Convert.ToInt32(drVendorInfo["LocIdRemit"].ToString().Trim().Substring(drVendorInfo["LocIdRemit"].ToString().Trim().Length - 5, 5));
                    }
                }
            }
            dsVendorInfo = bl.selectVendorInfo(SCAC);            
            if (dsVendorInfo != null)
            {
                bindDDL();
                bindListBox();
                if (lstBoxSelection.Items.Count > 0)
                {
                    if (!isEditMode)
                        lstBoxSelection.SelectedIndex = 0;
                    else
                    {
                        //lstBoxSelection.SelectedIndex = editIndex;
                        foreach (object item in lstBoxSelection.Items)
                        {
                            if (Convert.ToInt32(item.ToString().Split(' ')[0]) == editIndex)
                            {
                                lstBoxSelection.SelectedItem = item;
                                break;
                            }
                        }
                    }
                    bindControl(Convert.ToInt32(lstBoxSelection.Items[lstBoxSelection.SelectedIndex].ToString().Split(' ')[0]));
                }
            }
        }

        private void lstBoxSelection_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                if (((e.State & DrawItemState.Selected) > 0))// && this.lstBoxSelection.Focused)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                    e.Graphics.DrawString(lstBoxSelection.Items[e.Index].ToString(), lstBoxSelection.Font, SystemBrushes.HighlightText, e.Bounds);
                }
                else
                {
                    using (Brush back = new SolidBrush(lstBoxSelection.BackColor))
                        e.Graphics.FillRectangle(back, e.Bounds);

                    // Draw grayed text when listbox is disabled  
                    if ((e.State & DrawItemState.Disabled) > 0)
                    {
                        e.Graphics.DrawString(lstBoxSelection.Items[e.Index].ToString(), lstBoxSelection.Font, SystemBrushes.GrayText, e.Bounds);
                    }
                    else
                    {
                        using (Brush fore = new SolidBrush(lstBoxSelection.ForeColor))
                            e.Graphics.DrawString(lstBoxSelection.Items[e.Index].ToString(), lstBoxSelection.Font, fore, e.Bounds);
                    }
                }
                e.DrawFocusRectangle();
            }
        }

        private void lstBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindControl(Convert.ToInt32(lstBoxSelection.Items[lstBoxSelection.SelectedIndex].ToString().Split(' ')[0]));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (allowedOK())
            {
                updatedVendorInfo();
                if (!isVendorInfoOld())
                {
                    if (MessageBox.Show("The following Vendor information does not exist, add record?", "Add Vendor Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string newBatLocIdRemit = SCAC + (bl.selectVendorInfoCount(SCAC) + 1).ToString().PadLeft(5, '0');
                        txtRemitIndex.Text = newBatLocIdRemit;
                        drVendorInfo["LocIdRemit"] = txtRemitIndex.Text.Trim();
                        dtOriginalVendorInfo.Rows.Add(drVendorInfo);
                        if (bl.addVendorInfo(dtOriginalVendorInfo))
                        {
                            MessageBox.Show("Vendor information successfully added.", "Vendor Info");
                            vendorInfoSelected = true;
                        }
                    }
                }
                else
                {
                    drVendorInfo["LocIdRemit"] = getVendorInfoOld();
                    vendorInfoSelected = true;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not proceed, missing vendor information.", "Vendor Info");
            }
        }

        private void frmVendorInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && lstBoxSelection.Focused)
                btnOK_Click(null, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bindListBox();
            if (lstBoxSelection.Items.Count > 0)
            {
                lstBoxSelection.SelectedIndex = 0;
                bindControl(Convert.ToInt32(lstBoxSelection.Items[lstBoxSelection.SelectedIndex].ToString().Split(' ')[0]));
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnSearch_Click(null, null);
        }
        #endregion

        #region Developer Designed method
        private void bindDDL()
        {
            this.ddlDESCAC.DisplayMember = "vend_norm";
            this.ddlDESCAC.ValueMember = "vend_norm";
            this.ddlDESCAC.DataSource = dsVendorInfo.Tables["DESCACS"];
            this.ddlDESCAC.Refresh();
        }

        private void bindListBox()
        {
            this.Cursor = Cursors.WaitCursor;
            dvVendorInfo.Table = dsVendorInfo.Tables["VendRemit"];            
            string text = string.Empty;
            lstBoxSelection.Items.Clear();
            int i = 0;
            bool isBatLocIdRemitFormatCorrect = false;
            if(this.txtSearch.Text.Trim() == string.Empty)
            foreach (DataRow row in dsVendorInfo.Tables["VendRemit"].Rows )
            {
                try
                {
                    Convert.ToInt32(row["BatLocIdRemit"].ToString().Substring(row["BatLocIdRemit"].ToString().Length - 5));
                    isBatLocIdRemitFormatCorrect = true;
                }
                catch
                {
                    isBatLocIdRemitFormatCorrect = false;
                }
                if (isBatLocIdRemitFormatCorrect && isEditMode)
                {
                    i = Convert.ToInt32(row["BatLocIdRemit"].ToString().Substring(row["BatLocIdRemit"].ToString().Length - 5));
                    text = i.ToString() + " " + row["AlRemit3"].ToString() + ",\n   " + row["AlCityRemit"].ToString() + ",\n   " + row["AlStateProvRemit"].ToString() + " " + row["AlPostCodeRemit"].ToString() + " " + row["AlCntryCodeRemit"].ToString();
                    if (lstBoxSelection.Items.Count > 0 && i < Convert.ToInt32(lstBoxSelection.Items[lstBoxSelection.Items.Count - 1].ToString().Split(' ')[0]))
                    {
                        int index = 0;
                        while (i > Convert.ToInt32(lstBoxSelection.Items[index].ToString().Split(' ')[0]))
                        {
                            index++;
                        }
                        lstBoxSelection.Items.Insert(index, text);
                    }
                    else
                        lstBoxSelection.Items.Add(text);

                }
            }
            else
            {
                foreach (DataRow row in dsVendorInfo.Tables["VendRemit"].Select(string.Format("AlRemit3 LIKE '{0}%' OR AlCityRemit LIKE '{0}%' OR AlStateProvRemit LIKE '{0}%' OR AlPostCodeRemit LIKE '{0}%' OR AlCntryCodeRemit LIKE '{0}%'", this.txtSearch.Text.Trim())))
                {
                    try
                    {
                        Convert.ToInt32(row["BatLocIdRemit"].ToString().Substring(row["BatLocIdRemit"].ToString().Length - 5));
                        isBatLocIdRemitFormatCorrect = true;
                    }
                    catch
                    {
                        isBatLocIdRemitFormatCorrect = false;
                    }
                    if (isBatLocIdRemitFormatCorrect)
                    {
                        i = Convert.ToInt32(row["BatLocIdRemit"].ToString().Substring(row["BatLocIdRemit"].ToString().Length - 5));
                        text = i.ToString() + " " + row["AlRemit3"].ToString() + ",\n   " + row["AlCityRemit"].ToString() + ",\n   " + row["AlStateProvRemit"].ToString() + " " + row["AlPostCodeRemit"].ToString() + " " + row["AlCntryCodeRemit"].ToString();
                        if (lstBoxSelection.Items.Count > 0 && i < Convert.ToInt32(lstBoxSelection.Items[lstBoxSelection.Items.Count - 1].ToString().Split(' ')[0]))
                        {
                            int index = 0;
                            while (i > Convert.ToInt32(lstBoxSelection.Items[index].ToString().Split(' ')[0]))
                            {
                                index++;
                            }
                            lstBoxSelection.Items.Insert(index, text);
                        }
                        else
                            lstBoxSelection.Items.Add(text);

                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void bindControl(int index)
        {            
            if (index >= 0)            
            {
                if (dsVendorInfo == null)
                {
                    clearControls(this.Controls);
                }
                else
                {
                    dvVendorInfo.RowFilter = string.Format("BatLocIdRemit = '{0}'", txtVendorSCAC.Text.Trim() + index.ToString().PadLeft(5, '0'));
                    if (dvVendorInfo.Count > 0)
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is TraxDETextBox)
                            {
                                ((TraxDETextBox)control).Text = dvVendorInfo[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                            }
                            else if (control is GroupBox)
                            {
                                foreach (Control controls in ((GroupBox)control).Controls)
                                {
                                    if (controls is TraxDETextBox && ((TraxDETextBox)controls).DatabaseFieldLink != null)
                                    {
                                        ((TraxDETextBox)controls).Text = dvVendorInfo[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString();
                                    }
                                }
                            }
                        }
                    }
                    
                    
                }
            }
        }

        private void clearControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TraxDETextBox)
                {
                    ((TraxDETextBox)control).Clear();
                }
                else if (control is GroupBox)
                {
                    clearControls(((GroupBox)control).Controls);                    
                }
            }
        }

        private void updatedVendorInfo()
        {
            drVendorInfo["VendLabl"] = txtVendorSCAC.Text.Trim();
            drVendorInfo["LocIdRemit"] = txtRemitIndex.Text.Trim();
            drVendorInfo["AlRemit1"] = txtAlRemit1.Text.Trim();
            drVendorInfo["AlRemit2"] = txtAlRemit2.Text.Trim();
            drVendorInfo["AlRemit3"] = txtAlRemit3.Text.Trim();
            drVendorInfo["AlRemit4"] = txtAlRemit4.Text.Trim();
            drVendorInfo["AlCityRemit"] = txtAlCityRemit.Text.Trim();
            drVendorInfo["AlStateProvRemit"] = txtAlStateProvRemit.Text.Trim();
            drVendorInfo["AlPostCodeRemit"] = txtAlPostCodeRemit.Text.Trim();
            drVendorInfo["AlCntryCodeRemit"] = txtAlCntryCodeRemit.Text.Trim();            
        }

        private bool isVendorInfoOld()
        {
            bool retval = false;
            string vendorInfo = "-" + txtAlRemit1.Text.Trim() + "-" + txtAlRemit2.Text.Trim() + "-" + txtAlRemit3.Text.Trim() + "-" + txtAlRemit4.Text.Trim() + "-" + txtAlCityRemit.Text.Trim() + "-" + txtAlStateProvRemit.Text.Trim() + "-" + txtAlPostCodeRemit.Text.Trim() + "-" + txtAlCntryCodeRemit.Text.Trim();
            retval = bl.isVendorInfoExisting(SCAC, vendorInfo);
            return retval;
        }

        private string getVendorInfoOld()
        {
            string retval = string.Empty;
            string vendorInfo = "-" + txtAlRemit1.Text.Trim() + "-" + txtAlRemit2.Text.Trim() + "-" + txtAlRemit3.Text.Trim() + "-" + txtAlRemit4.Text.Trim() + "-" + txtAlCityRemit.Text.Trim() + "-" + txtAlStateProvRemit.Text.Trim() + "-" + txtAlPostCodeRemit.Text.Trim() + "-" + txtAlCntryCodeRemit.Text.Trim();
            retval = bl.getBatLocIdRemit(SCAC, vendorInfo);
            return retval;
        }

        private bool allowedOK()
        {
            bool retval = true;//false;
            //if (txtAlRemit1.Text.Trim() == string.Empty)
            //    return retval;
            //if (txtAlRemit3.Text.Trim() == string.Empty)
            //    return retval;
            //if (txtAlCityRemit.Text.Trim() == string.Empty)
            //    return retval;
            //if (txtAlStateProvRemit.Text.Trim() == string.Empty)
            //    return retval;
            //if (txtAlPostCodeRemit.Text.Trim() == string.Empty)
            //    return retval;
            //if (txtAlCntryCodeRemit.Text.Trim() == string.Empty)
            //    return retval;

            //retval = true;
            return retval;
        }
        
        private DataRow getVendorInfoStructure()
        {
            DataRow retval;
            DataTable dtVendorInfo = new DataTable();
            dtVendorInfo.Columns.Add("VendLabl");
            dtVendorInfo.Columns.Add("LocIdRemit");
            dtVendorInfo.Columns.Add("AlRemit1");
            dtVendorInfo.Columns.Add("AlRemit2");
            dtVendorInfo.Columns.Add("AlRemit3");
            dtVendorInfo.Columns.Add("AlRemit4");
            dtVendorInfo.Columns.Add("AlCityRemit");
            dtVendorInfo.Columns.Add("AlStateProvRemit");
            dtVendorInfo.Columns.Add("AlPostCodeRemit");
            dtVendorInfo.Columns.Add("AlCntryCodeRemit");
            retval = dtVendorInfo.NewRow();
            return retval;
        }
        #endregion
    }
}
