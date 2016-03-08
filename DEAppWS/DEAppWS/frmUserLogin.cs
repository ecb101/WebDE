using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
//using BLogic;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmUserLogin : Form
    {
        private UserLoginBL.UserLoginBL bl = new UserLoginBL.UserLoginBL(); 
        public frmUserLogin()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtID.Text.Equals(string.Empty))
            {
                this.txtID.Focus();
                MessageBox.Show("ID is empty. Please input the ID.", "User login");
            }
            else if (this.txtPassword.Text.Equals(string.Empty))
            {
                this.txtPassword.Focus();
                MessageBox.Show("Password is empty. Please input the password.", "User login");
            }
            else
            {
                CommonUserLogin userLogin = new CommonUserLogin();//bl.validateLogin(this.txtID.Text, this.txtPassword.Text);
                if (userLogin != null)
                {
                    Thread.SetData(Thread.GetNamedDataSlot("Login"), userLogin);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect user ID or password.", "User login");
                    txtID.Focus();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                btnOK_Click(null, null);
        }
    }
}
