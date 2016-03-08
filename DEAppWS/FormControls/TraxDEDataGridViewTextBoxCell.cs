using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormControls
{
    public partial class TraxDEDataGridViewTextBoxCell : DataGridViewTextBoxCell
    {        
        public TraxDEDataGridViewTextBoxCell()
        {
            InitializeComponent();            
        }

        public override Type EditType 
        {
            get
            {
                return typeof(TraxDEDataGridViewTextBoxEditingControl);
            }
        }        
    }
}
