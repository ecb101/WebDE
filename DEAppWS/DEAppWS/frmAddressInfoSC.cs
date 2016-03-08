using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmAddressInfoSC : Form
    {
        private DataTable dtAddress = new DataTable();
        private DataView dvAddress = new DataView();
        private string fbid = string.Empty;
        private CommonEnum.AddressType addressType;
        private string shortCutKey = string.Empty;
        public frmAddressInfoSC()
        {
            InitializeComponent();
        }

        public frmAddressInfoSC(DataTable Address, string fbId, CommonEnum.AddressType AddressType)
        {
            InitializeComponent();
            dtAddress = Address;
            fbid = fbId;
            addressType = AddressType;
            this.Text = addressType.ToString() + " " + this.Text;
            if (addressType == CommonEnum.AddressType.CONSIGNEE_INVOICE || addressType == CommonEnum.AddressType.SHIPPER_INVOICE)
            {
                lblZone.Visible = true;
                txtAlZoneAddr.Visible = true;
            }
        }

        public frmAddressInfoSC(DataTable Address, string fbId, CommonEnum.AddressType AddressType, string ShortCutKey)
        {
            InitializeComponent();
            dtAddress = Address;
            fbid = fbId;
            addressType = AddressType;
            this.Text = addressType.ToString() + " " + this.Text;
            shortCutKey = ShortCutKey;
            if (addressType == CommonEnum.AddressType.CONSIGNEE_INVOICE || addressType == CommonEnum.AddressType.SHIPPER_INVOICE)
            {
                lblZone.Visible = true;
                txtAlZoneAddr.Visible = true;
            }
        }
        #region events
        private void frmAddressInfoSC_Load(object sender, EventArgs e)
        {
            this.bindControl();


            
        }

        private void btnOK_Click(object sender, EventArgs e)
                {
            //add row if there are fields that are not empty string
                if (!isAllEmpty())
                {
                    if (rowAddUpdate())
                        this.Close();
                }
                else
                {
                    if (dvAddress.Count > 0)//delete if row is existing.
                    {
                        foreach (DataRow row in dtAddress.Select(string.Format("FbId = '{0}' AND AddrCat = '{1}'", fbid, addressType.ToString())))
                        {
                            row.Delete();
                        }
                    }
                    this.Close();
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.clearControls();
        }

        private void frmAddressInfoSC_Activated(object sender, EventArgs e)
        {
            switch (shortCutKey)
            {
                case "1":
                    {
                        txtAlAddr1.Focus();
                        break;
                    }
                case "2":
                    {
                        txtAlAddr2.Focus();
                        break;
                    }
                case "3":
                    {
                        txtAlAddr3.Focus();
                        break;
                    }
                case "4":
                    {
                        txtAlAddr4.Focus();
                        break;
                    }
                case "5":
                    {
                        txtAlCityAddr.Focus();
                        break;
                    }
                case "6":
                    {
                        txtAlStateProvAddr.Focus();
                        break;
                    }
                case "7":
                    {
                        txtAlPostCodeAddr.Focus();
                        break;
                    }
                case "8":
                    {
                        txtAlCntryCodeAddr.Focus();
                        break;
                    }
                case "9":
                    {
                        txtAlPortAddr.Focus();
                        break;
                    }
                case "0":
                    {
                        txtAlZoneAddr.Focus();
                        break;
                    }
            }
            shortCutKey = string.Empty;
        }

        private void frmAddressInfoSC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                if (e.KeyCode == Keys.NumPad1)
                    txtAlAddr1.Focus();
                else if (e.KeyCode == Keys.NumPad2)
                    txtAlAddr2.Focus();
                else if (e.KeyCode == Keys.NumPad3)
                    txtAlAddr3.Focus();
                else if (e.KeyCode == Keys.NumPad4)
                    txtAlAddr4.Focus();
                else if (e.KeyCode == Keys.NumPad5)
                    txtAlCityAddr.Focus();
                else if (e.KeyCode == Keys.NumPad6)
                    txtAlStateProvAddr.Focus();
                else if (e.KeyCode == Keys.NumPad7)
                    txtAlPostCodeAddr.Focus();
                else if (e.KeyCode == Keys.NumPad8)
                    txtAlCntryCodeAddr.Focus();
                else if (e.KeyCode == Keys.NumPad9)
                    txtAlPortAddr.Focus();
                else if (e.KeyCode == Keys.NumPad0)
                    txtAlZoneAddr.Focus();
            }
        }
        #endregion

        #region Developer Designed method
        private void bindControl()
        {
            clearControls();
            dvAddress.Table = dtAddress;                        
            dvAddress.RowFilter = string.Format("FbId = '{0}' AND AddrCat = '{1}'", fbid, addressType.ToString());
            if (dvAddress.Count > 0)
            {
                foreach (Control control in this.grpAddress.Controls)
                {
                    if (control is TraxDETextBox)
                    {
                        ((TraxDETextBox)control).Text = dvAddress[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                    }
                }
            }
                
        }

        private void clearControls()
        {
            foreach (Control control in grpAddress.Controls)
            {
                if (control is TraxDETextBox)
                {
                    ((TraxDETextBox)control).Clear();
                }                
            }
        }

        private bool isAllEmpty()
        {
            bool retval = false;
            if (txtAlAddr1.Text.Trim() == string.Empty && txtAlAddr2.Text.Trim() == string.Empty && txtAlAddr3.Text.Trim() == string.Empty && txtAlAddr4.Text.Trim() == string.Empty
                && txtAlCityAddr.Text.Trim() == string.Empty && txtAlStateProvAddr.Text.Trim() == string.Empty && txtAlPostCodeAddr.Text.Trim() == string.Empty && txtAlCntryCodeAddr.Text.Trim() == string.Empty && txtAlPortAddr.Text.Trim() == string.Empty && txtAlZoneAddr.Text.Trim() == string.Empty)
                retval = true;
            return retval;
        }

        private bool rowAddUpdate()
        {
            bool retval = false;
            DataRow dr = dtAddress.NewRow();
            try
            {
                if (dvAddress.Count > 0)//update if existing
                {
                    dvAddress[0]["AlAddr1"] = txtAlAddr1.Text;
                    dvAddress[0]["AlAddr2"] = txtAlAddr2.Text;
                    dvAddress[0]["AlAddr3"] = txtAlAddr3.Text;
                    dvAddress[0]["AlAddr4"] = txtAlAddr4.Text;
                    dvAddress[0]["AlCityAddr"] = txtAlCityAddr.Text;
                    dvAddress[0]["AlStateProvAddr"] = txtAlStateProvAddr.Text;
                    dvAddress[0]["AlPostCodeAddr"] = txtAlPostCodeAddr.Text;
                    dvAddress[0]["AlCntryCodeAddr"] = txtAlCntryCodeAddr.Text;
                    dvAddress[0]["AlPortAddr"] = txtAlPortAddr.Text;
                    dvAddress[0]["AlZoneAddr"] = txtAlZoneAddr.Text;
                }
                else//add
                {
                    dr["FbId"] = fbid;
                    dr["AddrNum"] = 1;
                    dr["AddrCat"] = addressType.ToString();
                    dr["AlAddr1"] = txtAlAddr1.Text;
                    dr["AlAddr2"] = txtAlAddr2.Text;
                    dr["AlAddr3"] = txtAlAddr3.Text;
                    dr["AlAddr4"] = txtAlAddr4.Text;
                    dr["AlCityAddr"] = txtAlCityAddr.Text;
                    dr["AlStateProvAddr"] = txtAlStateProvAddr.Text;
                    dr["AlPostCodeAddr"] = txtAlPostCodeAddr.Text;
                    dr["AlCntryCodeAddr"] = txtAlCntryCodeAddr.Text;
                    dr["AlPortAddr"] = txtAlPortAddr.Text;
                    dr["AlZoneAddr"] = txtAlZoneAddr.Text;
                    dtAddress.Rows.Add(dr);
                }
                retval = true;
            }
            catch
            { }
            return retval;
        }
        #endregion

        
    }
}
