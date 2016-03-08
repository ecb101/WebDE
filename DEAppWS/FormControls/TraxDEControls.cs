using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
namespace FormControls
{
    [Designer(typeof(TraxDEControlDesigner))]
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))] 
    public partial class TraxDEControls : UserControl
    {
        public TraxDEControls()
        {
            InitializeComponent();
        }
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TraxDETextBox TxtInvKey
        {
            get { return this.txtInvKey; }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TraxDEDataGridView GrdFXI
        {
            get { return this.grdFXI; }
        }
        
    }
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class TraxDEControlDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.EnableDesignMode(((TraxDEControls)component).TxtInvKey, ((TraxDEControls)component).TxtInvKey.Name);
            this.EnableDesignMode(((TraxDEControls)component).GrdFXI, ((TraxDEControls)component).GrdFXI.Name);
        }
    }
}
