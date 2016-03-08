using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
namespace FormControls
{
    public partial class TraxDECheckBox : CheckBox
    {
        #region Customized properties

        private string databaseFieldLink;

        private bool isNeeded;        

        [Category("Custom Properties"), DefaultValue(false), DescriptionAttribute("Indicates wether this requires a value or not.")]
        public bool IsNeeded
        {
            get
            {
                return isNeeded;
            }

            set
            {
                isNeeded = value;
            }
        }

        [Category("Custom Properties"), DefaultValue(""), DescriptionAttribute("Indicates the database field this control is link to.")]
        public string DatabaseFieldLink
        {
            get
            {
                return databaseFieldLink;
            }

            set
            {
                databaseFieldLink = value;
            }
        }

        #endregion

        public TraxDECheckBox()
        {
            InitializeComponent();
        }
    }
}
