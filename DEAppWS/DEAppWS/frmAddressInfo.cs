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
    public partial class frmAddressInfo : Form
    {        
        private DataTable dtAddress = new DataTable();
        private DataView dvAddress = new DataView();
        private string fbid = string.Empty;
        private CommonEnum.AddressType addressType;
        private bool deleteTriggered;
        private string shortCutKey = string.Empty;
        public bool DeleteTriggered
        {
            get
            {
                return this.deleteTriggered;
            }
        }

        public frmAddressInfo()
        {
            InitializeComponent();
        }

        public frmAddressInfo(DataTable Address, string fbId, CommonEnum.AddressType AddressType, bool DeleteTriggered)
        {
            InitializeComponent();
            dtAddress = Address;
            dtAddress.TableNewRow += new DataTableNewRowEventHandler(grdAddressNewRow);
            fbid = fbId;
            addressType = AddressType;
            deleteTriggered = DeleteTriggered;
            switch (addressType)
            {
                case CommonEnum.AddressType.PICKUP:
                    {
                        grpBoxAddress.Text = "Pickup Address";
                        radioBtnPickUpAdd.Checked = true;
                        break;
                    }
                case CommonEnum.AddressType.DELIVERY:
                    {
                        grpBoxAddress.Text = "Delivery Address";
                        radioBtnDeliveryAdd.Checked = true;
                        break;
                    }
                case CommonEnum.AddressType.STOP_OFF:
                    {
                        grpBoxAddress.Text = "Stop Off Address";
                        radioBtnStopOffLoc.Checked = true;
                        break;
                    }
            }
        }

        public frmAddressInfo(DataTable Address, string fbId, CommonEnum.AddressType AddressType, bool DeleteTriggered, string ShortCutKey)
        {
            InitializeComponent();
            dtAddress = Address;
            dtAddress.TableNewRow += new DataTableNewRowEventHandler(grdAddressNewRow);
            fbid = fbId;
            addressType = AddressType;
            deleteTriggered = DeleteTriggered;
            switch (addressType)
            {
                case CommonEnum.AddressType.PICKUP:
                    {
                        grpBoxAddress.Text = "Pickup Address";
                        radioBtnPickUpAdd.Checked = true;
                        break;
                    }
                case CommonEnum.AddressType.DELIVERY:
                    {
                        grpBoxAddress.Text = "Delivery Address";
                        radioBtnDeliveryAdd.Checked = true;
                        break;
                    }
                case CommonEnum.AddressType.STOP_OFF:
                    {
                        grpBoxAddress.Text = "Stop Off Address";
                        radioBtnStopOffLoc.Checked = true;
                        break;
                    }
            }
            shortCutKey = ShortCutKey;
        }        

        #region events
        private void radioBtn_CheckedChanged(object sender, EventArgs e)
        {
            bindGrid();       
        }

        private void frmAddressInfo_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdAddressNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["FbId"] = fbid;
            e.Row["AddrNum"] = grdAddress.Rows.Count;
            e.Row["AddrCat"] = addressType.ToString();
        }

        private void grdAddress_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            deleteTriggered = true;
        }

        private void grdAddress_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this address?", "Delete address", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void grdAddress_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.grdAddress.AutoResizeColumns();
            this.grdAddress.Refresh();
        }

        private void frmAddressInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
            {
                grdAddress.Select();
                if (grdAddress.SelectedCells.Count > 0)
                {
                    if (e.KeyCode == Keys.NumPad1)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlAddr1"];
                    else if (e.KeyCode == Keys.NumPad2)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlAddr2"];
                    else if (e.KeyCode == Keys.NumPad3)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlAddr3"];
                    else if (e.KeyCode == Keys.NumPad4)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlAddr4"];
                    else if (e.KeyCode == Keys.NumPad5)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlCityAddr"];
                    else if (e.KeyCode == Keys.NumPad6)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlStateProvAddr"];
                    else if (e.KeyCode == Keys.NumPad7)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlPostCodeAddr"];
                    else if (e.KeyCode == Keys.NumPad8)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlCntryCodeAddr"];
                    else if (e.KeyCode == Keys.NumPad9)
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlPortAddr"];
                    //else if (e.KeyCode == Keys.NumPad0)
                    //    grdAddress.CurrentCell = grdAddress.Rows[grdAddress.SelectedCells[0].RowIndex].Cells["AlZoneAddr"];
                }
            }
        }

        private void frmAddressInfo_Activated(object sender, EventArgs e)
        {
            grdAddress.Select();

            switch (shortCutKey)
            {
                case "1":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlAddr1"];
                        break;
                    }
                case "2":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlAddr2"];
                        break;
                    }
                case "3":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlAddr3"];
                        break;
                    }
                case "4":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlAddr4"];
                        break;
                    }
                case "5":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlCityAddr"];
                        break;
                    }
                case "6":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlStateProvAddr"];
                        break;
                    }
                case "7":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlPostCodeAddr"];
                        break;
                    }
                case "8":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlCntryCodeAddr"];
                        break;
                    }
                case "9":
                    {
                        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlPortAddr"];
                        break;
                    }
                //case "0":
                //    {
                //        grdAddress.CurrentCell = grdAddress.Rows[grdAddress.Rows.Count - 1].Cells["AlZoneAddr"];
                //        break;
                //    }
            }

            shortCutKey = string.Empty;
        }
        #endregion

        #region Developer Designed method
        private void bindGrid()
        {
            dvAddress.Table = dtAddress;
            dvAddress.RowFilter = string.Empty;
            // Add rows by looping columns        
            if (radioBtnPickUpAdd.Checked)
            {
                addressType = CommonEnum.AddressType.PICKUP;
            }
            else if (radioBtnDeliveryAdd.Checked)
            {
                addressType = CommonEnum.AddressType.DELIVERY;
            }
            else
            {
                addressType = CommonEnum.AddressType.STOP_OFF;
            }
            dvAddress.RowFilter = string.Format("FbId = '{0}' AND AddrCat = '{1}'", fbid, addressType.ToString());
            this.grdAddress.DataSource = dvAddress;
            this.grdAddress.Refresh();
        }
        #endregion
    }        
}
