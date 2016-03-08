using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FormControls
{
    public partial class TraxDEPictureBox : Panel
    {
        
        PictureBox imageHolder = new PictureBox();

        private Image image;        
        [Category("Custom Properties"), DescriptionAttribute("Image")]

        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                if (image is Image)
                {
                    imageHolder.Image = image;
                    if (sizeMode == PictureBoxSizeMode.StretchImage)
                        imageHolder.Size = this.Size;
                    else
                        imageHolder.Size = image.Size;
                }
                if (image == null)
                {
                    imageHolder.Image = null;
                }
            }
        }
        
        private bool mAutoScroll = true;
        [Browsable(false)]
        public override bool AutoScroll
        {
            get
            {
                return mAutoScroll;
            }
            set
            {
                mAutoScroll = value;
            }

        }

        private PictureBoxSizeMode sizeMode;
        [Category("Custom Properties"), DefaultValue(PictureBoxSizeMode.Normal), DescriptionAttribute("Indicates wether this is scrollable or not.")]
        public PictureBoxSizeMode SizeMode
        {
            get
            {
                return sizeMode;
            }

            set
            {
                sizeMode = value;
                if (sizeMode == PictureBoxSizeMode.StretchImage)
                    imageHolder.Size = this.Size;
                else
                    imageHolder.Size = image.Size;
                imageHolder.SizeMode = sizeMode;
                
                imageHolder.Refresh();
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            imageHolder.Refresh();
        }
        
        public TraxDEPictureBox()
        {
            InitializeComponent();
            
            imageHolder.Top = 0;
            imageHolder.Left = 0;
            Controls.Add(imageHolder);

        }

    }
}
