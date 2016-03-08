using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
namespace CommonLibrary
{
    public class CommonFont
    {
        private PrivateFontCollection privateFont = new PrivateFontCollection();

        public CommonFont()
        {
            initFont();
        }        
        public PrivateFontCollection PrivateFont
        {
            get
            {
                return privateFont;
            }
        }

        private void initFont()
        {
            IntPtr fontBuffer;
            byte[] font = Properties.Resources.FREE3OF9;
            fontBuffer = Marshal.AllocCoTaskMem(font.Length);
            Marshal.Copy(font, 0, fontBuffer, font.Length);
            privateFont.AddMemoryFont(fontBuffer, font.Length);
        }
    }
}
