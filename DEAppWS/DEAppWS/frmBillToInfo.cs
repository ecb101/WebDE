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
    public partial class frmBillToInfo : Form
    {        
        private DataSet dsVendorInfo = new DataSet();
        private string SCAC = string.Empty;
        private DataView dvBillTo = new DataView();
        private VendorInfoBL.VendorInfoBL bl = new VendorInfoBL.VendorInfoBL();
        private bool billToInfoSelected = false;        
        
        private DataRow drBillTo;
        private bool isEditMode;
        private DataTable dtOriginalBillTo = new DataTable();
        private int editIndexBillTo;
        
        public DataRow BillToRow
        {
            get
            {
                return this.drBillTo;
            }
        }

        public bool BillToInfoSelected
        {
            get
            {
                return this.billToInfoSelected;
            }
        }
        
        public frmBillToInfo()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            drBillTo = getBillToStructure();
        }

        public frmBillToInfo(string SCAC)
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            this.SCAC = SCAC;
            isEditMode = false;            
            drBillTo = getBillToStructure();
        }

        public frmBillToInfo(string SCAC, int BillToID, DataTable BillToContents)
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            btnOK.Text = "&Update";
            this.SCAC = SCAC;
            isEditMode = true;            
            this.editIndexBillTo = BillToID;            
            drBillTo = getBillToStructure();
            dtOriginalBillTo = BillToContents;
        }

        #region events
        private void frmBillToInfo_Load(object sender, EventArgs e)
        {
            txtVendorSCAC.Text = SCAC;
            if (isEditMode)
            {
                DataSet dsTemp = new DataSet();
                dsTemp.Tables.Add(dtOriginalBillTo);
                if (!bl.isBillToContentsEqual(dsTemp))//if different bill to contents
                {
                    //add new record
                    int ID = (bl.selectBillToCount(SCAC) + 1);
                    string newLocIdBling = SCAC + ID.ToString().PadLeft(5, '0');
                    txtBillToIndex.Text = newLocIdBling;
                    drBillTo["VendLabl"] = dtOriginalBillTo.Rows[0]["VendLabl"];
                    drBillTo["LocIdBlng"] = newLocIdBling;
                    drBillTo["AlBlng1"] = dtOriginalBillTo.Rows[0]["AlBlng1"];
                    drBillTo["AlBlng2"] = dtOriginalBillTo.Rows[0]["AlBlng2"];
                    drBillTo["AlBlng3"] = dtOriginalBillTo.Rows[0]["AlBlng3"];
                    drBillTo["AlBlng4"] = dtOriginalBillTo.Rows[0]["AlBlng4"];
                    drBillTo["AlCityBlng"] = dtOriginalBillTo.Rows[0]["AlCityBlng"];
                    drBillTo["AlStateProvBlng"] = dtOriginalBillTo.Rows[0]["AlStateProvBlng"];
                    drBillTo["AlPostCodeBlng"] = dtOriginalBillTo.Rows[0]["AlPostCodeBlng"];
                    drBillTo["AlCntryCodeBlng"] = dtOriginalBillTo.Rows[0]["AlCntryCodeBlng"];
                    string BillTo = "-" + drBillTo["AlBlng1"].ToString().Trim() + "-" + drBillTo["AlBlng2"].ToString().Trim() + "-" + drBillTo["AlBlng3"].ToString().Trim() + "-" + drBillTo["AlBlng4"].ToString().Trim() + "-" + drBillTo["AlCityBlng"].ToString().Trim() + "-" + drBillTo["AlStateProvBlng"].ToString().Trim() + "-" + drBillTo["AlPostCodeBlng"].ToString().Trim() + "-" + drBillTo["AlCntryCodeBlng"].ToString().Trim();
                    if (!bl.isBillToExisting(SCAC, BillTo))
                    {
                        DataTable dt = drBillTo.Table;
                        DataSet dsTemp1 = new DataSet();
                        dt.Rows.Add(drBillTo);
                        dsTemp1.Tables.Add(dt);
                        if (bl.addBillTo(dsTemp1))
                        {
                            billToInfoSelected = true;
                            editIndexBillTo = ID;//update ID base on the new record
                        }
                    }
                    else
                    {
                        drBillTo["LocIdBlng"] = bl.getLocIdBlng(SCAC, BillTo);
                        billToInfoSelected = true;
                        editIndexBillTo = Convert.ToInt32(drBillTo["LocIdBlng"].ToString().Trim().Substring(drBillTo["LocIdBlng"].ToString().Trim().Length - 5, 5));
                    }
                }
            }
            dsVendorInfo = bl.selectVendorInfo(SCAC);
            if (dsVendorInfo != null)
            {
                bindListBoxBillTo();
                if (lstBoxSelectionBillTo.Items.Count > 0)
                {
                    if (!isEditMode)
                        lstBoxSelectionBillTo.SelectedIndex = 0;
                    else
                    {
                        foreach (object item in lstBoxSelectionBillTo.Items)
                        {
                            if (Convert.ToInt32(item.ToString().Split(' ')[0]) == editIndexBillTo)
                            {
                                lstBoxSelectionBillTo.SelectedItem = item;
                                break;
                            }
                        }
                    }
                    bindControl(Convert.ToInt32(lstBoxSelectionBillTo.Items[lstBoxSelectionBillTo.SelectedIndex].ToString().Split(' ')[0]));
                }
            }
        }             

        private void lstBoxSelectionBillTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindControl(Convert.ToInt32(lstBoxSelectionBillTo.Items[lstBoxSelectionBillTo.SelectedIndex].ToString().Split(' ')[0]));
        }

        private void lstBoxSelectionBillTo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index != -1)
            {
                if (((e.State & DrawItemState.Selected) > 0)) //&& this.lstBoxSelectionBillTo.Focused)
                {
                    e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
                    e.Graphics.DrawString(lstBoxSelectionBillTo.Items[e.Index].ToString(), lstBoxSelectionBillTo.Font, SystemBrushes.HighlightText, e.Bounds);
                }
                else
                {
                    using (Brush back = new SolidBrush(lstBoxSelectionBillTo.BackColor))
                        e.Graphics.FillRectangle(back, e.Bounds);

                    // Draw grayed text when listbox is disabled  
                    if ((e.State & DrawItemState.Disabled) > 0)
                    {
                        e.Graphics.DrawString(lstBoxSelectionBillTo.Items[e.Index].ToString(), lstBoxSelectionBillTo.Font, SystemBrushes.GrayText, e.Bounds);
                    }
                    else
                    {
                        using (Brush fore = new SolidBrush(lstBoxSelectionBillTo.ForeColor))
                            e.Graphics.DrawString(lstBoxSelectionBillTo.Items[e.Index].ToString(), lstBoxSelectionBillTo.Font, fore, e.Bounds);
                    }
                }
                e.DrawFocusRectangle();
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (allowedOK())
            {
                updatedBillTo();
                if (isAllEmpty())
                    billToInfoSelected = true;                
                if (!isBillToOld())
                {
                    if (MessageBox.Show("The following Bill To information does not exist, add record?", "Add Bill To Information", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string newLocIdBling = SCAC + (bl.selectBillToCount(SCAC) + 1).ToString().PadLeft(5, '0');
                        txtBillToIndex.Text = newLocIdBling;
                        drBillTo["LocIdBlng"] = txtBillToIndex.Text.Trim();
                        DataTable dt = drBillTo.Table;
                        DataSet dsTemp = new DataSet();
                        dt.Rows.Add(drBillTo);
                        dsTemp.Tables.Add(dt);
                        if (bl.addBillTo(dsTemp))
                        {
                            MessageBox.Show("Bill To information successfully added.", "Bill To Info");
                            billToInfoSelected = true;
                        }
                    }
                }
                else
                {
                    drBillTo["LocIdBlng"] = getBillToOld();
                    billToInfoSelected = true;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Could not proceed, missing Bill To information.", "Bill To Info");
            }
        }

        private void frmVendorInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && lstBoxSelectionBillTo.Focused)
                btnOK_Click(null, null);
        }      

        private void btnSearchBillTo_Click(object sender, EventArgs e)
        {
            bindListBoxBillTo();
            if (lstBoxSelectionBillTo.Items.Count > 0)
            {
                lstBoxSelectionBillTo.SelectedIndex = 0;
                bindControl(Convert.ToInt32(lstBoxSelectionBillTo.Items[lstBoxSelectionBillTo.SelectedIndex].ToString().Split(' ')[0]));
            }
        }

        private void txtSearchBillTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnSearchBillTo_Click(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearControls(grpBoxBillToID.Controls);
            clearControls(grpBoxBillToAddress.Controls);
        }
        #endregion

        #region Developer Designed method
        private void bindListBoxBillTo()
        {
            this.Cursor = Cursors.WaitCursor;
            dvBillTo.Table = dsVendorInfo.Tables["BillTo"];
            string text = string.Empty;
            lstBoxSelectionBillTo.Items.Clear();
            int i = 0;
            bool isLocIdBlngFormatCorrect = false;
            if (this.txtSearchBillTo.Text.Trim() == string.Empty)
            {
                foreach (DataRow row in dsVendorInfo.Tables["BillTo"].Rows)
                {
                    try
                    {
                        Convert.ToInt32(row["LocIdBlng"].ToString().Substring(row["LocIdBlng"].ToString().Length - 5));
                        isLocIdBlngFormatCorrect = true;
                    }
                    catch
                    {
                        isLocIdBlngFormatCorrect = false;
                    }
                    if (isLocIdBlngFormatCorrect && isEditMode)
                    {
                        i = Convert.ToInt32(row["LocIdBlng"].ToString().Substring(row["LocIdBlng"].ToString().Length - 5));
                        text = i.ToString() + " " + row["AlBlng3"].ToString() + ",\n   " + row["AlCityBlng"].ToString() + ",\n   " + row["AlStateProvBlng"].ToString() + " " + row["AlPostCodeBlng"].ToString() + " " + row["AlCntryCodeBlng"].ToString();
                        if (lstBoxSelectionBillTo.Items.Count > 0 && i < Convert.ToInt32(lstBoxSelectionBillTo.Items[lstBoxSelectionBillTo.Items.Count - 1].ToString().Split(' ')[0]))
                        {
                            int index = 0;
                            while (i > Convert.ToInt32(lstBoxSelectionBillTo.Items[index].ToString().Split(' ')[0]))
                            {
                                index++;
                            }
                            lstBoxSelectionBillTo.Items.Insert(index, text);
                        }
                        else
                            lstBoxSelectionBillTo.Items.Add(text);

                    }
                }
            }
            else
            {
                foreach (DataRow row in dsVendorInfo.Tables["BillTo"].Select(string.Format("AlBlng3 LIKE '{0}%' OR AlCityBlng LIKE '{0}%' OR AlStateProvBlng LIKE '{0}%' OR AlPostCodeBlng LIKE '{0}%' OR AlCntryCodeBlng LIKE '{0}%'", this.txtSearchBillTo.Text.Trim())))
                {
                    try
                    {
                        Convert.ToInt32(row["LocIdBlng"].ToString().Substring(row["LocIdBlng"].ToString().Length - 5));
                        isLocIdBlngFormatCorrect = true;
                    }
                    catch
                    {
                        isLocIdBlngFormatCorrect = false;
                    }
                    if (isLocIdBlngFormatCorrect)
                    {
                        i = Convert.ToInt32(row["LocIdBlng"].ToString().Substring(row["LocIdBlng"].ToString().Length - 5));
                        text = i.ToString() + " " + row["AlBlng3"].ToString() + ",\n   " + row["AlCityBlng"].ToString() + ",\n   " + row["AlStateProvBlng"].ToString() + " " + row["AlPostCodeBlng"].ToString() + " " + row["AlCntryCodeBlng"].ToString();
                        if (lstBoxSelectionBillTo.Items.Count > 0 && i < Convert.ToInt32(lstBoxSelectionBillTo.Items[lstBoxSelectionBillTo.Items.Count - 1].ToString().Split(' ')[0]))
                        {
                            int index = 0;
                            while (i > Convert.ToInt32(lstBoxSelectionBillTo.Items[index].ToString().Split(' ')[0]))
                            {
                                index++;
                            }
                            lstBoxSelectionBillTo.Items.Insert(index, text);
                        }
                        else
                            lstBoxSelectionBillTo.Items.Add(text);

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
                    dvBillTo.RowFilter = string.Format("LocIdBlng = '{0}'", txtVendorSCAC.Text.Trim() + index.ToString().PadLeft(5, '0'));
                    if (dvBillTo.Count > 0)
                    {
                        foreach (Control control in this.Controls)
                        {
                            if (control is TraxDETextBox)
                            {
                                ((TraxDETextBox)control).Text = dvBillTo[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                            }
                            else if (control is GroupBox)
                            {
                                
                                foreach (Control controls in ((GroupBox)control).Controls)
                                {
                                    if (controls is TraxDETextBox && ((TraxDETextBox)controls).DatabaseFieldLink != null)
                                    {
                                        ((TraxDETextBox)controls).Text = dvBillTo[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString();
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
        
        private void updatedBillTo()
        {
            drBillTo["VendLabl"] = txtVendorSCAC.Text.Trim();
            drBillTo["LocIdBlng"] = txtBillToIndex.Text.Trim();
            drBillTo["AlBlng1"] = txtAlBlng1.Text.Trim();
            drBillTo["AlBlng2"] = txtAlBlng2.Text.Trim();
            drBillTo["AlBlng3"] = txtAlBlng3.Text.Trim();
            drBillTo["AlBlng4"] = txtAlBlng4.Text.Trim();
            drBillTo["AlCityBlng"] = txtAlCityBlng.Text.Trim();
            drBillTo["AlStateProvBlng"] = txtAlStateProvBlng.Text.Trim();
            drBillTo["AlPostCodeBlng"] = txtAlPostCodeBlng.Text.Trim();
            drBillTo["AlCntryCodeBlng"] = txtAlCntryCodeBlng.Text.Trim();
        }
        
        private bool isBillToOld()
        {
            bool retval = false;
            string BillTo = "-" + txtAlBlng1.Text.Trim() + "-" + txtAlBlng2.Text.Trim() + "-" + txtAlBlng3.Text.Trim() + "-" + txtAlBlng4.Text.Trim() + "-" + txtAlCityBlng.Text.Trim() + "-" + txtAlStateProvBlng.Text.Trim() + "-" + txtAlPostCodeBlng.Text.Trim() + "-" + txtAlCntryCodeBlng.Text.Trim();
            retval = bl.isBillToExisting(SCAC, BillTo);
            return retval;
        }        

        private string getBillToOld()
        {
            string retval = string.Empty;
            string BillTo = "-" + txtAlBlng1.Text.Trim() + "-" + txtAlBlng2.Text.Trim() + "-" + txtAlBlng3.Text.Trim() + "-" + txtAlBlng4.Text.Trim() + "-" + txtAlCityBlng.Text.Trim() + "-" + txtAlStateProvBlng.Text.Trim() + "-" + txtAlPostCodeBlng.Text.Trim() + "-" + txtAlCntryCodeBlng.Text.Trim();
            retval = bl.getLocIdBlng(SCAC, BillTo);
            return retval;
        }

        private bool allowedOK()
        {
            bool retval = true;// false;
            //if (!isAllEmpty())//all is not empty
            //{                
            //    if (txtAlBlng1.Text.Trim() == string.Empty)
            //        return retval;
            //    if (txtAlBlng3.Text.Trim() == string.Empty)
            //        return retval;
            //    if (txtAlCityBlng.Text.Trim() == string.Empty)
            //        return retval;
            //    if (txtAlStateProvBlng.Text.Trim() == string.Empty)
            //        return retval;
            //    if (txtAlPostCodeBlng.Text.Trim() == string.Empty)
            //        return retval;
            //    //if (txtAlCntryCodeBlng.Text.Trim() == string.Empty)
            //    //    return retval;
            //}
            //retval = true;
            return retval;
        }

        private DataRow getBillToStructure()
        {
            DataRow retval;
            DataTable dtBillTo = new DataTable();
            dtBillTo.Columns.Add("VendLabl");
            dtBillTo.Columns.Add("LocIdBlng");
            dtBillTo.Columns.Add("AlBlng1");
            dtBillTo.Columns.Add("AlBlng2");
            dtBillTo.Columns.Add("AlBlng3");
            dtBillTo.Columns.Add("AlBlng4");
            dtBillTo.Columns.Add("AlCityBlng");
            dtBillTo.Columns.Add("AlStateProvBlng");
            dtBillTo.Columns.Add("AlPostCodeBlng");
            dtBillTo.Columns.Add("AlCntryCodeBlng");
            retval = dtBillTo.NewRow();
            return retval;
        }

        private bool isAllEmpty()
        {
            bool retval = false;
            if (txtAlBlng1.Text.Trim() == string.Empty && txtAlBlng2.Text.Trim() == string.Empty && txtAlBlng3.Text.Trim() == string.Empty && txtAlBlng4.Text.Trim() == string.Empty 
                && txtAlCityBlng.Text.Trim() == string.Empty && txtAlStateProvBlng.Text.Trim() == string.Empty && txtAlPostCodeBlng.Text.Trim() == string.Empty && txtAlCntryCodeBlng.Text.Trim() == string.Empty)
                retval = true;
            return retval;
        }
        #endregion        
    }
}
