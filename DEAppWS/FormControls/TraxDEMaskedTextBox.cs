using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using CommonLibrary;
namespace FormControls
{
    public partial class TraxDEMaskedTextBox : MaskedTextBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;
        private string hintMask = string.Empty;
        private string[] d;
        #region Customized properties

        private bool isValidateValue = false;
        [Category("Custom Properties"), DefaultValue(false), DescriptionAttribute("Indicates wether this field is for validation or not.")]
        public bool IsValidateValue
        {
            get
            {
                return isValidateValue;
            }

            set
            {
                isValidateValue = value;
            }
        }

        private bool isOCRValue = false;
        [Category("Custom Properties"), DefaultValue(false), DescriptionAttribute("Indicates wether this field is for OCR value or not.")]
        public bool IsOCRValue
        {
            get
            {
                return isOCRValue;
            }

            set
            {
                isOCRValue = value;
            }
        }

        private bool isQualityAssuranceForm = false;
        [Category("Custom Properties"), DefaultValue(false), DescriptionAttribute("Indicates wether this field is in Quality Assurance Form or not.")]
        public bool IsQualityAssuranceForm
        {
            get
            {
                return isQualityAssuranceForm;
            }

            set
            {
                isQualityAssuranceForm = value;
            }
        }

        private CommonEnum.MaskValueType valueType;
        [Category("Custom Properties"), DescriptionAttribute("Indicates the type of value this property is allowed whether it is alpha numeric, money or measurements.")]
        public CommonEnum.MaskValueType ValueType
        {
            get
            {
                return valueType;
            }

            set
            {
                valueType = value;
            }
        }

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

        private bool isCorrectValue = true;
        [Category("Custom Properties"), DefaultValue(true), DescriptionAttribute("Indicates wether this correct value or not.")]
        public bool IsCorrectValue
        {
            get
            {
                return isCorrectValue;
            }

            set
            {
                isCorrectValue = value;
            }
        }

        private string fieldHint;
        [Category("Custom Properties"), DefaultValue(""), DescriptionAttribute("Indicates the hint on the contents of this field.")]
        public string FieldHint
        {
            get
            {
                return fieldHint;
            }

            set
            {
                fieldHint = value;
            }
        }
        #endregion

        public TraxDEMaskedTextBox()
        {
            InitializeComponent();            
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.Mask = hintMask;
            switch (valueType)
            {
                case CommonEnum.MaskValueType.DATELONG:
                    {
                        if (this.Text.Trim() == "/  /       :")
                        {
                            SendKeys.Send("{BACKSPACE}");
                        }
                        break;
                    }
                case CommonEnum.MaskValueType.DATESHORT:
                    {
                        if (this.Text.Trim() == "/  /")
                        {
                            SendKeys.Send("{BACKSPACE}");
                        }
                        break;
                    }
                case CommonEnum.MaskValueType.DIMENSION:
                    {
                        if (this.Text.Trim() == "x    x")
                        {
                            SendKeys.Send("{BACKSPACE}");
                        }
                        break;
                    }
            }                
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == 13)
            {
                if (valueType == CommonEnum.MaskValueType.DIMENSION)
                {
                    if (this.SelectionStart <= hintMask.Split('x')[0].Trim().Length)
                        this.SelectionStart = hintMask.Split('x')[0].Trim().Length+1;
                    else if (this.SelectionStart > hintMask.Split('x')[0].Trim().Length && this.SelectionStart <= hintMask.Split('x')[0].Trim().Length + hintMask.Split('x')[1].Trim().Length+1)
                        this.SelectionStart = hintMask.Split('x')[0].Trim().Length + hintMask.Split('x')[1].Trim().Length + 2;
                    else
                        SendKeys.Send("{TAB}");
                }
                else
                    SendKeys.Send("{TAB}");
            }
            //else
            //{
            //    if (valueType == CommonEnum.MaskValueType.DIMENSION)
            //    {
            //        d = this.Text.Split('x');
            //        int selection;
            //        if (this.SelectionStart <= hintMask.Split('x')[0].Trim().Length && d[0].Trim().Length == hintMask.Split('x')[0].Trim().Length)
            //            hintMask = "C" + hintMask;
            //        else if (this.SelectionStart > hintMask.Split('x')[0].Trim().Length && this.SelectionStart <= hintMask.Split('x')[0].Trim().Length + hintMask.Split('x')[1].Trim().Length + 1 && d[1].Trim().Length == hintMask.Split('x')[1].Trim().Length)
            //            hintMask = hintMask.Insert(hintMask.Split('x')[0].Trim().Length + 1, "C");
            //        else if (this.SelectionStart > hintMask.Split('x')[0].Trim().Length + hintMask.Split('x')[0].Trim().Length + hintMask.Split('x')[1].Trim().Length + 1 && d[2].Trim().Length == hintMask.Split('x')[2].Trim().Length)
            //            hintMask = hintMask + "C";
            //        selection = this.SelectionStart;
            //        this.Mask = hintMask;
            //        this.SelectionStart = selection;
            //    }
            //}
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyValue == 40 || e.KeyValue == 38)
                e.Handled = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            switch (valueType)
            {
                case CommonEnum.MaskValueType.DATELONG:
                    {
                        if (this.Text.Trim() == "/  /       :")
                        {
                            this.Mask = string.Empty;
                            showHint();
                        }
                        break;
                    }
                case CommonEnum.MaskValueType.DATESHORT:
                    {
                        if (this.Text.Trim() == "/  /")
                        {
                            this.Mask = string.Empty;
                            showHint();
                        }
                        break;
                    }
                case CommonEnum.MaskValueType.DIMENSION:
                    {
                        if (this.Text.Trim() == "x    x")
                        {
                            this.Mask = string.Empty;
                            showHint();
                        }
                        break;
                    }
            }
            
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!IsCorrectValue)
            {
                this.ForeColor = Color.White;
                this.BackColor = Color.Red;
            }
            else
            {
                this.BackColor = Color.Yellow;
                this.ForeColor = Color.Black;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            updateBackColor();
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);
            if (!this.ReadOnly && this.Mask != string.Empty)
            {
                switch (valueType)
                {
                    case CommonEnum.MaskValueType.DATELONG:
                        {
                            if (this.Text.Trim() != "/  /       :")
                            {
                                try
                                {
                                    //if(Convert.ToDateTime(this.Text) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(this.Text) > (bl.GetServerDate().AddDays(30)))
                                    string date = string.Empty;
                                    if (this.Text.Trim().Substring(this.Text.Length - 1, 1) == ":")
                                        date = this.Text.Trim().Remove(this.Text.Length - 1, 1).Trim();
                                    else
                                        date = this.Text;

                                    if (Convert.ToDateTime(date) < (DateTime.Now.AddYears(-10)) || Convert.ToDateTime(date) > (DateTime.Now.AddDays(30)))
                                        MessageBox.Show("Date out of range");
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message + ", format is MM/dd/yyyy hh:mm .", this.Name);
                                    e.Cancel = true;
                                }
                            }
                            break;
                        }
                    case CommonEnum.MaskValueType.DATESHORT:
                        {
                            if (this.Text.Trim() != "/  /")
                            {
                                try
                                {
                                    //if (Convert.ToDateTime(this.Text) < (bl.GetServerDate().AddYears(-10)) || Convert.ToDateTime(this.Text) > (bl.GetServerDate().AddDays(30)))
                                    if (Convert.ToDateTime(this.Text) < (DateTime.Now.AddYears(-10)) || Convert.ToDateTime(this.Text) > (DateTime.Now.AddDays(30)))
                                        MessageBox.Show("Date out of range");
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message + ", format is MM/dd/yyyy .", this.Name);
                                    e.Cancel = true;
                                }
                            }
                            break;
                        }
                    case CommonEnum.MaskValueType.DIMENSION:
                        {
                            if (this.Text.Trim() != "x      x")
                            {   
                                try
                                {
                                    Convert.ToDecimal(this.Text.Substring(0, 6).Replace("'","").Replace("\"",""));
                                    Convert.ToDecimal(this.Text.Substring(7, 6).Replace("'", "").Replace("\"", ""));
                                    Convert.ToDecimal(this.Text.Substring(14).Replace("'", "").Replace("\"", ""));
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message, this.Name);
                                    e.Cancel = true;
                                }
                            }
                            break;
                        }
                }
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if (!this.ReadOnly && this.Mask != string.Empty)
            {
                switch (valueType)
                {
                    case CommonEnum.MaskValueType.DATELONG:
                        {
                            if (this.Text.Trim() != "/  /       :")
                            {
                                try
                                {

                                    string date = string.Empty;
                                    if (this.Text.Trim().Substring(this.Text.Length - 1, 1) == ":")
                                        date = this.Text.Trim().Remove(this.Text.Length - 1, 1).Trim();
                                    else
                                        date = this.Text;

                                    this.Text = String.Format("{0:MM/dd/yyyy HH:mm}", Convert.ToDateTime(date)).Replace('/', ' ').Replace(':', ' ').Replace(" ", string.Empty);
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message + ", format is MM/dd/yyyy hh:mm .", this.Name);
                                }
                            }
                            break;
                        }
                    case CommonEnum.MaskValueType.DATESHORT:
                        {
                            if (this.Text.Trim() != "/  /")
                            {
                                try
                                {
                                    this.Text = String.Format("{0:MM/dd/yyyy}", Convert.ToDateTime(this.Text)).Replace('/', ' ').Replace(" ", string.Empty);
                                }
                                catch (Exception error)
                                {
                                    MessageBox.Show(error.Message + ", format is MM/dd/yyyy .", this.Name);                                    
                                }
                            }
                            break;
                        }
                    case CommonEnum.MaskValueType.DIMENSION:
                        {
                            if (this.Text.Trim() != "x    x")
                            {                                
                            }
                            break;
                        }
                }
            }
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            updateBackColor();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            switch (valueType)
            {
                case CommonEnum.MaskValueType.DATESHORT:
                    {
                        hintMask = "##/##/####";
                        break;
                    }
                case CommonEnum.MaskValueType.DATELONG:
                    {
                        hintMask = "##/##/#### ##:##";
                        break;
                    }
                case CommonEnum.MaskValueType.DIMENSION:
                    {
                        hintMask = "CCCCCCxCCCCCCxCCCCCC";
                        break;
                    }
            }
            
            this.Mask = string.Empty;
            showHint();
        }

        public void updateBackColor()
        {
            if (!IsCorrectValue)
            {
                this.ForeColor = Color.White;
                this.BackColor = Color.Red;
            }
            else
            {
                if (this.ReadOnly)
                {
                    if (this.isQualityAssuranceForm && !this.isValidateValue)
                        this.BackColor = Color.LightGray;
                    else
                        this.BackColor = Color.FromKnownColor(KnownColor.Control);
                }
                else
                {
                    if (this.isQualityAssuranceForm && !this.isValidateValue)
                        this.BackColor = Color.LightGray;
                    else if (this.IsOCRValue)
                        this.BackColor = Color.Aqua;
                    else
                        this.BackColor = Color.White;
                }
                this.ForeColor = Color.Black;
            }
        }

        public void showHint()
        {
            SendMessage(this.Handle, EM_SETCUEBANNER, 0, fieldHint);
        }
    }
}
