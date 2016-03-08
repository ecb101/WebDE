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
    public partial class frmCertify : frmDEQABase
    {
        public frmCertify(CommonEnum.FormMode formMode, string MXXDatabase, string MXXOwnerKey, string MXXSCAC, string MXXOwnerCode, Form parent)
            : base(formMode, MXXDatabase, MXXOwnerKey, MXXSCAC, MXXOwnerCode, parent)
        {
            InitializeComponent();
            this.Text = formMode.ToString() + " - " + MXXDatabase;
        }
    }
}
