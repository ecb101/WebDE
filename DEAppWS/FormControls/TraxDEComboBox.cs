using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormControls
{
    public partial class TraxDEComboBox : ComboBox
    {
        #region Customized properties
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

        private string databaseFieldLink;
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

        private string databaseTableLink;
        [Category("Custom Properties"), DefaultValue(""), DescriptionAttribute("Indicates the database table this control is link to.")]
        public string DatabaseTableLink
        {
            get
            {
                return databaseTableLink;
            }

            set
            {
                databaseTableLink = value;
            }
        }
        #endregion

        public TraxDEComboBox()
        {
            InitializeComponent();
        }
    }
}
