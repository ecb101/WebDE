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
    public partial class frmMatchWithRef : frmDEQABase
    {
        public frmMatchWithRef(CommonEnum.FormMode formMode, string MXXDatabase, string MXXOwnerKey, string MXXSCAC, string MXXOwnerCode, Form parent)
            : base(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, parent)
        {
            InitializeComponent();
            this.Text = formMode.ToString() + " - " + MXXDatabase;
            this.btnFBAdd.Visible = false;
            this.btnFBDelete.Visible = false;
            this.lblFBAmount.Visible = false;
            this.lblTotal.Visible = false;
        }
        protected override void txtInvKey_Validated(object sender, EventArgs e)
        {
            base.txtInvKey_Validated(sender, e);
            if (CurrentFormState == CommonEnum.FormState.EDIT_STATE)
                txtFbKey.Text = txtInvKey.Text;
        }
        protected override void txtVendInvAmt_Validated(object sender, EventArgs e)
        {
            base.txtVendInvAmt_Validated(sender, e);
            if (CurrentFormState == CommonEnum.FormState.EDIT_STATE)
            {

                txtFbAmt.Text = txtVendInvAmt.Text;
                if (txtVendInvAmt.Text == string.Empty)
                    this.grdFBLine.Rows[0].Cells["FBLnChrgAmt"].Value = 0;
                else
                    this.grdFBLine.Rows[0].Cells["FBLnChrgAmt"].Value = txtVendInvAmt.Text;
            }
        }
        protected override void txt_InvTextChanged(object sender, EventArgs e)
        {
            base.txt_InvTextChanged(sender, e);
            if (CurrentFormState == CommonEnum.FormState.EDIT_STATE)
            {
                if (sender is TraxDETextBox)
                {
                    if (((TraxDETextBox)sender).DatabaseFieldLink == "VendInvAmt")
                    {
                        txtFbAmt.Text = txtVendInvAmt.Text;
                        if (txtVendInvAmt.Text == string.Empty)
                            this.grdFBLine.Rows[0].Cells["FBLnChrgAmt"].Value = 0;
                        else
                            this.grdFBLine.Rows[0].Cells["FBLnChrgAmt"].Value = txtVendInvAmt.Text;
                    }
                    if (((TraxDETextBox)sender).DatabaseFieldLink == "InvKey")
                        txtFbKey.Text = txtInvKey.Text;
                }

            }

        }
        protected override void btnInvoiceAdd_Click(object sender, EventArgs e)
        {
            base.btnInvoiceAdd_Click(sender, e);
            DSBatch.Tables["FBLn"].Rows.Add(DSBatch.Tables["FBLn"].NewRow());
            
            this.grdFBLine.Rows[0].Cells["FBLnLnChrgCode"].Value = "400";            
        }        
    }
}
