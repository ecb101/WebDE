using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using FormControls;
namespace DEAppWS
{
    public partial class frmFXI : Form
    {
        private DataView dvFXI = new DataView();
        private DataTable dtFXI = new DataTable();
        private string FbIdFilter = string.Empty;
        private string FBKey = string.Empty;
        private string FBId = string.Empty;
        private string CustRef1 = string.Empty;
        private string CustRef2 = string.Empty;
        private bool isEndSemiColon = false;

        public string CustReference1
        {
            get
            {
                return this.CustRef1;
            }
        }

        public string CustReference2
        {
            get
            {
                return this.CustRef2;
            }
        }
                
        public frmFXI()
        {
            InitializeComponent();            
        }

        public frmFXI(DataTable dtFXI, string FbId, string FbKey, bool isEndSemiColon)
        {
            InitializeComponent();
            this.dtFXI = dtFXI;
            this.FbIdFilter = FbId;
            this.FBKey = FbKey;
            this.FBId = FbId;
            this.isEndSemiColon = isEndSemiColon;
            dvFXI.Table = dtFXI;
            dvFXI.RowFilter = string.Format("FbId  ='{0}'", this.FbIdFilter);
        }

        #region events
        private void frmFXI_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + " - " + this.FBKey;
            bindControls();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmFXI_FormClosing(object sender, FormClosingEventArgs e)
        {
            sortFXI();
            try
            {
                updateCustRef1();
                updateCustRef2();
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dvFXI.Count > 0)
                {
                    if (sender is TraxDETextBox)
                    {
                        if (((TraxDETextBox)sender).Text.Trim() == string.Empty)
                        {
                            if (dvFXI[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Single" ||
                                dvFXI[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int32" ||
                                dvFXI[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Int16" ||
                                dvFXI[0][((TraxDETextBox)sender).DatabaseFieldLink].GetType().FullName == "System.Decimal")
                                ((TraxDETextBox)sender).Text = "0";
                            else
                                dvFXI[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();
                        }
                        else
                        {
                            try
                            {
                                updateCustRef1();
                                updateCustRef2();
                                dvFXI[0][((TraxDETextBox)sender).DatabaseFieldLink] = ((TraxDETextBox)sender).Text.Trim();
                            }
                            catch 
                            {
                                MessageBox.Show("Could not proceed due to the limitation of the Cust ref field.","Cust Ref");
                                ((TraxDETextBox)sender).Text = dvFXI[0][((TraxDETextBox)sender).DatabaseFieldLink].ToString();
                            }
                        }
                    }

                }
                else
                {
                    if (sender is TraxDETextBox)
                        ((TraxDETextBox)sender).Text = string.Empty;
                    else if (sender is TraxDEMaskedTextBox)
                        ((TraxDEMaskedTextBox)sender).Text = string.Empty;
                }

            }
            catch
            { }
        }

        private void frmFXI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyValue == 49)//Ctrl+1
            {
                txtCustRef11.Focus();
                e.Handled = true;
            }
            else if (e.Control == true && e.KeyValue == 50)//Ctrl+2
            {
                txtBOL1.Focus();
                e.Handled = true;
            }
            else if (e.Control == true && e.KeyValue == 51)//Ctrl+3                
            {
                txtCustRef21.Focus();
                e.Handled = true;
            }
            else if (e.Control == true && e.KeyValue == 52)//Ctrl+4                
            {
                txtInvPageNum.Focus();
                e.Handled = true;
            }
            else if (e.Control == true && e.KeyValue == 79)//Ctrl+O                
            {
                btnOK_Click(null, null);
                e.Handled = true;
            }
        }

        private void txtInvPageNum_Leave(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt16(txtInvPageNum.Text);
                if (value < 0)
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show(this.Name + " thus not contain a numeric value.", "txtInvPageNum");
                txtInvPageNum.Focus();
            }
        }
        #endregion

        #region Developer Designed method
        private void sortFXI()
        {
            //CustRef1
            int ctrCustRef1 = 10;            
            string[] custRef1 = new string[ctrCustRef1];
            for (int i = 0; i < ctrCustRef1; i++)
            {
                custRef1[i] = dvFXI[0][i+5].ToString().Trim();
                dvFXI[0][i + 5] = DBNull.Value;
            }
            Array.Sort(custRef1);
            int j = 0;
            for (int i = 0; i < ctrCustRef1; i++)
            {
                if (custRef1[i].Trim().Length > 0)
                {
                    dvFXI[0][j + 5] = custRef1[i];
                    j++;
                }
            }

            //BOL
            int ctrBOL = 10;            
            string[] BOL = new string[ctrBOL];
            for (int i = 0; i < ctrBOL; i++)
            {
                BOL[i] = dvFXI[0][i + 15].ToString().Trim();
                dvFXI[0][i + 15] = DBNull.Value;
            }
            Array.Sort(BOL);
            j = 0;
            for (int i = 0; i < ctrBOL; i++)
            {
                if (BOL[i].Trim().Length > 0)
                {
                    dvFXI[0][j + 15] = BOL[i];
                    j++;
                }
            }

            //CustRef2
            int ctrCustRef2 = 20;
            string[] custRef2 = new string[ctrCustRef2];
            for (int i = 0; i < ctrCustRef2; i++)
            {
                custRef2[i] = dvFXI[0][i + 25].ToString().Trim();
                dvFXI[0][i + 25] = DBNull.Value;
            }
            Array.Sort(custRef2);
            j = 0;
            for (int i = 0; i < ctrCustRef2; i++)
            {
                if (custRef2[i].Trim().Length > 0)
                {
                    dvFXI[0][j + 25] = custRef2[i];
                    j++;
                }
            }
        }

        private void bindControls()
        {
            if (dvFXI.Count > 0)
            {
                foreach (Control control in grpFXIGrid.Controls)
                {
                    if (control is TraxDETextBox)
                    {
                        ((TraxDETextBox)control).Text = dvFXI[0][((TraxDETextBox)control).DatabaseFieldLink].ToString();
                    }
                    else if (control is GroupBox)
                    {
                        foreach (Control controls in ((GroupBox)control).Controls)
                        {
                            if (controls is TraxDETextBox)
                            {
                                ((TraxDETextBox)controls).Text = dvFXI[0][((TraxDETextBox)controls).DatabaseFieldLink].ToString();
                            }
                            else if (controls is TraxDEMaskedTextBox)
                            {
                                ((TraxDEMaskedTextBox)controls).Text = dvFXI[0][((TraxDEMaskedTextBox)controls).DatabaseFieldLink].ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                clearControls();
            }
        }

        private void clearControls()
        {
            foreach (Control control in grpFXIGrid.Controls)
            {
                if (control is TraxDETextBox)
                    ((TraxDETextBox)control).Clear();
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).Clear();
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                            ((TraxDETextBox)controls).Clear();
                    }
                }
            }
        }
        
        private void updateCustRef1()
        {
            string CustRef = string.Empty;            
            if (txtCustRef11.Text != string.Empty)
                CustRef = CustRef + txtCustRef11.Text + ";";
            if (txtCustRef12.Text != string.Empty)
                CustRef = CustRef + txtCustRef12.Text + ";";
            if (txtCustRef13.Text != string.Empty)
                CustRef = CustRef + txtCustRef13.Text + ";";
            if (txtCustRef14.Text != string.Empty)
                CustRef = CustRef + txtCustRef14.Text + ";";
            if (txtCustRef15.Text != string.Empty)
                CustRef = CustRef + txtCustRef15.Text + ";";
            if (txtCustRef16.Text != string.Empty)
                CustRef = CustRef + txtCustRef16.Text + ";";
            if (txtCustRef17.Text != string.Empty)
                CustRef = CustRef + txtCustRef17.Text + ";";
            if (txtCustRef18.Text != string.Empty)
                CustRef = CustRef + txtCustRef18.Text + ";";
            if (txtCustRef19.Text != string.Empty)
                CustRef = CustRef + txtCustRef19.Text + ";";
            if (txtCustRef110.Text != string.Empty)
                CustRef = CustRef + txtCustRef110.Text + ";";
            
            if (txtBOL1.Text != string.Empty)
                CustRef = CustRef + txtBOL1.Text + ";";
            if (txtBOL2.Text != string.Empty)
                CustRef = CustRef + txtBOL2.Text + ";";
            if (txtBOL3.Text != string.Empty)
                CustRef = CustRef + txtBOL3.Text + ";";
            if (txtBOL4.Text != string.Empty)
                CustRef = CustRef + txtBOL4.Text + ";";
            if (txtBOL5.Text != string.Empty)
                CustRef = CustRef + txtBOL5.Text + ";";
            if (txtBOL6.Text != string.Empty)
                CustRef = CustRef + txtBOL6.Text + ";";
            if (txtBOL7.Text != string.Empty)
                CustRef = CustRef + txtBOL7.Text + ";";
            if (txtBOL8.Text != string.Empty)
                CustRef = CustRef + txtBOL8.Text + ";";
            if (txtBOL9.Text != string.Empty)
                CustRef = CustRef + txtBOL9.Text + ";";
            if (txtBOL10.Text != string.Empty)
                CustRef = CustRef + txtBOL10.Text + ";";

            if (!isEndSemiColon && CustRef.Length > 0)
                CustRef = CustRef.Substring(0, CustRef.Length - 1);

            if (CustRef.Length <= 100)
            {
                this.CustRef1 = CustRef;
            }
            else
                throw new Exception("Could not proceed.");
        }

        private void updateCustRef2()
        {
            string CustRef = string.Empty;
            if (txtCustRef21.Text != string.Empty)
                CustRef = CustRef + txtCustRef21.Text + ";";
            if (txtCustRef22.Text != string.Empty)
                CustRef = CustRef + txtCustRef22.Text + ";";
            if (txtCustRef23.Text != string.Empty)
                CustRef = CustRef + txtCustRef23.Text + ";";
            if (txtCustRef24.Text != string.Empty)
                CustRef = CustRef + txtCustRef24.Text + ";";
            if (txtCustRef25.Text != string.Empty)
                CustRef = CustRef + txtCustRef25.Text + ";";
            if (txtCustRef26.Text != string.Empty)
                CustRef = CustRef + txtCustRef26.Text + ";";
            if (txtCustRef27.Text != string.Empty)
                CustRef = CustRef + txtCustRef27.Text + ";";
            if (txtCustRef28.Text != string.Empty)
                CustRef = CustRef + txtCustRef28.Text + ";";
            if (txtCustRef29.Text != string.Empty)
                CustRef = CustRef + txtCustRef29.Text + ";";
            if (txtCustRef210.Text != string.Empty)
                CustRef = CustRef + txtCustRef210.Text + ";";
            if (txtCustRef211.Text != string.Empty)
                CustRef = CustRef + txtCustRef211.Text + ";";
            if (txtCustRef212.Text != string.Empty)
                CustRef = CustRef + txtCustRef212.Text + ";";
            if (txtCustRef213.Text != string.Empty)
                CustRef = CustRef + txtCustRef213.Text + ";";
            if (txtCustRef214.Text != string.Empty)
                CustRef = CustRef + txtCustRef214.Text + ";";
            if (txtCustRef215.Text != string.Empty)
                CustRef = CustRef + txtCustRef215.Text + ";";
            if (txtCustRef216.Text != string.Empty)
                CustRef = CustRef + txtCustRef216.Text + ";";
            if (txtCustRef217.Text != string.Empty)
                CustRef = CustRef + txtCustRef217.Text + ";";
            if (txtCustRef218.Text != string.Empty)
                CustRef = CustRef + txtCustRef218.Text + ";";
            if (txtCustRef219.Text != string.Empty)
                CustRef = CustRef + txtCustRef219.Text + ";";
            if (txtCustRef220.Text != string.Empty)
                CustRef = CustRef + txtCustRef220.Text + ";";
            
            if (!isEndSemiColon && CustRef.Length > 0)
                CustRef = CustRef.Substring(0, CustRef.Length - 1);

            if (CustRef.Length <= 100)
            {                
                this.CustRef2 = CustRef;
            }
            else
                throw new Exception("Could not proceed.");
        }
        #endregion
    }
}
