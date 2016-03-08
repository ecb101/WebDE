using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmPasswordChange : Form
    {
        private UserLoginBL.UserLoginBL bl = new UserLoginBL.UserLoginBL();        
        public frmPasswordChange()
        {
            InitializeComponent();

        }

        public frmPasswordChange(string DEUser)
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            txtID.Text = DEUser;
        }
        #region events
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (isChangesAcceptable())
            {
                if (bl.UpdatePassword(this.txtID.Text.Trim(), this.txtNewPassword.Text.Trim()))
                {
                    MessageBox.Show("Password successfully changed.", "Change password");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("There was a problem during password update.", "Change password");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPasswordChange_Load(object sender, EventArgs e)
        {
            this.txtOldPassword.Select();
            this.txtOldPassword.Focus();
            if (this.txtID.Text.Trim() == string.Empty)
            {
                this.btnEnter.Enabled = false;
                this.txtConfirmPassword.ReadOnly = true;
                this.txtNewPassword.ReadOnly = true;
                this.txtOldPassword.ReadOnly = true;
            }
        }
        #endregion

        #region Developer Designed method
        private bool isChangesAcceptable()
        {
            bool retval = false;
            if (txtOldPassword.Text.Trim() != bl.selectPassword(txtID.Text.Trim(), ConfigurationManager.AppSettings["SiteID"]))
            {
                retval = false;
                MessageBox.Show("Incorrect password.", "Change password");
            }
            else if (txtNewPassword.Text.Trim() == string.Empty)
            {
                retval = false;
                MessageBox.Show("New password is empty. Please input the new password.","Change password");

            }
            else if (txtNewPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                retval = false;
                MessageBox.Show("Password not confirmed. The new password and did not match.", "Change password");
            }
            else if (txtNewPassword.Text.Trim() == txtOldPassword.Text.Trim())
            {
                retval = false;
                MessageBox.Show("The new password is the same as the old password. Please change the new password.", "Change password");
            }
            else
                retval = true;
            return retval;
        }
        #endregion
    }
}
