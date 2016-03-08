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
    public partial class TraxDETextBox : TextBox
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
        private const int EM_SETCUEBANNER = 0x1501;

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

        private CommonEnum.ValueType valueType;
        [Category("Custom Properties"), DescriptionAttribute("Indicates the type of value this property is allowed whether it is alpha numeric, money or measurements.")]
        public CommonEnum.ValueType ValueType
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

        public TraxDETextBox()
        {            
            InitializeComponent();            
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            /*
            Regex regStr;
            
            if (this.Text.Trim() != string.Empty)
            {
                switch (valueType)
                {
                    case CommonEnum.ValueType.ALPHA_NUMERIC:
                        {
                            regStr = new Regex("^[A-Za-z0-9]*$");
                            if (!regStr.IsMatch(this.Text))
                                e.Handled = true;
                            break;
                        }
                    case CommonEnum.ValueType.DATELONG:
                        {
                            regStr = new Regex("^[A-Za-z0-9]*$");
                            if (!regStr.IsMatch(this.Text))
                                e.Handled = true;
                            break;
                        }
                    case CommonEnum.ValueType.DATESHORT:
                        {
                            regStr = new Regex("^([0-9]|/|-)*$");
                            if (!regStr.IsMatch(this.Text))
                                e.Handled = true;
                            break;
                        }
                    case CommonEnum.ValueType.MEASUREMENT:
                        {
                            regStr = new Regex("^([0-9]*(, *)?)*[.]?[0-9]*$");
                            if (!regStr.IsMatch(this.Text))
                                e.Handled = true;
                            break;
                        }
                    case CommonEnum.ValueType.MONEY:
                        {
                            regStr = new Regex(@"^\$?[0-9]+(,[0-9]{3})*(\.[0-9]{2})?$");
                            if (!regStr.IsMatch(this.Text))
                                e.Handled = true;
                            break;
                        }
                    case CommonEnum.ValueType.NUMERIC:
                        {

                            regStr = new Regex("^([0-9]*(, *)?)*[.]?[0-9]*$");
                            if (this.Text.Trim().Equals(string.Empty) || this.Text.StartsWith("-") || this.Text.StartsWith(".") || this.Text.StartsWith(","))
                            {
                                e.Handled = true;
                                break;
                            }
                            if (!regStr.IsMatch(this.Text))
                            {
                                e.Handled = true;
                                break;
                            }
                            break;
                        }
                }
            }
            */
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
                
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);            
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
            if (!this.ReadOnly)
            {
                Regex regStr;
                if (this.Text.Trim() != string.Empty)
                {
                    this.Text = Regex.Replace(Regex.Replace(this.Text, "\\*", " ").Trim(), " {2,}", " ");
                    switch (valueType)
                    {
                        case CommonEnum.ValueType.ALPHA_NUMERIC:
                            {
                                regStr = new Regex("[^a-zA-Z0-9]");
                                if (!regStr.IsMatch(this.Text))
                                {
                                    MessageBox.Show(this.Name + " thus not contain an alpha numeric value.", this.Name);
                                    this.Focus();

                                }
                                break;
                            }                        
                        case CommonEnum.ValueType.MEASUREMENT:
                            {
                                regStr = new Regex("^([0-9]*(, *)?)*[.]?[0-9]*$");
                                if (!regStr.IsMatch(this.Text))
                                {
                                    MessageBox.Show(this.Name + " thus not contain a measurement value.", this.Name);
                                    this.Focus();
                                }
                                break;
                            }
                        case CommonEnum.ValueType.MONEY:
                            {
                                try
                                {
                                    Convert.ToDecimal(this.Text);
                                    //if (this.Text != string.Empty && !this.Text.Contains('.'))
                                    //{
                                    //    if (Convert.ToDecimal(this.Text) >= 0)
                                    //        this.Text = this.Text.Length == 1 ? this.Text.PadLeft(2, '0').Insert(0, ".") : this.Text.Insert(this.Text.Length - 2, ".");
                                    //    else
                                    //        this.Text = this.Text.Length == 2 ? this.Text.Insert(1, ".0") : this.Text.Insert(this.Text.Length - 2, ".");
                                    //}
                                    //this.Text = Convert.ToDecimal(this.Text).ToString("###,###,###,###.#0");
                                }
                                catch
                                {
                                    MessageBox.Show(this.Name + " thus not contain a money value.", this.Name);
                                    this.Focus();
                                }
                                //regStr = new Regex(@"^\$?[0-9]+(,[0-9]{3})*(\.[0-9]{2})?$");
                                //if (!regStr.IsMatch(this.Text))
                                //{
                                //    MessageBox.Show(this.Name + " thus not contain a money value.", this.Name);
                                //    this.Focus();
                                //}
                                break;

                            }
                        case CommonEnum.ValueType.NUMERIC:
                            {
                                regStr = new Regex("^([0-9]*(, *)?)*[.]?[0-9]*$");
                                if (!regStr.IsMatch(this.Text))
                                {
                                    MessageBox.Show(this.Name + " thus not contain a numeric value.", this.Name);
                                    this.Focus();
                                }
                                break;
                            }
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
