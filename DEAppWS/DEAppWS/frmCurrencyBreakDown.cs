using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmCurrencyBreakDown : Form
    {
        private bool computedBreakdown = false;
        private string initialCurrency = string.Empty;
        private string secondaryCurrency = string.Empty;
        private string outputCurrency = string.Empty;
        private decimal exchangeRateAmount1;
        private decimal exchangeRateAmount2;
        private string originalLineItemInfo = string.Empty;
        private ArrayList lineItemRange = new ArrayList();

        public bool ComputedBreakdown
        {
            get
            {
                return this.computedBreakdown;
            }
        }

        public string InitialCurrency
        {
            get
            {
                return this.initialCurrency;
            }
        }

        public string SecondaryCurrency
        {
            get
            {
                return this.secondaryCurrency;
            }
        }

        public string OutputCurrency
        {
            get
            {
                return this.outputCurrency;
            }
        }

        public decimal ExchangeRateAmount1
        {
            get
            {
                return this.exchangeRateAmount1;
            }
        }

        public decimal ExchangeRateAmount2
        {
            get
            {
                return this.exchangeRateAmount2;
            }
        }

        public string OriginalLineItem
        {
            get
            {
                return this.originalLineItemInfo;
            }
        }

        public ArrayList LineItemRange
        {
            get
            {
                return this.lineItemRange;
            }
        }
        
        public frmCurrencyBreakDown(ArrayList initialContent)
        {
            InitializeComponent();
            this.ddlCurrency.Items.AddRange(CommonMethod.getCurrencyList());
            this.ddlCurrency1.Items.Add("");
            this.ddlCurrency1.Items.AddRange(CommonMethod.getCurrencyList());
            this.ddlCurrency2.Items.Add("");
            this.ddlCurrency2.Items.AddRange(CommonMethod.getCurrencyList());

            initialCurrency = initialContent[0].ToString();//Currency1
            secondaryCurrency = initialContent[1].ToString();//Currency2
            outputCurrency = initialContent[2].ToString();//OutputCurrency
            setOriginalLineItem(initialContent[3].ToString());//OriginalItem

            exchangeRateAmount1 = Convert.ToDecimal(initialContent[4]);//Exchange Rate 1
            exchangeRateAmount2 = Convert.ToDecimal(initialContent[5]);//Exchange Rate 2            

            setLineItemCount(Convert.ToInt16(initialContent[6]), ddlLineItemFrom);//RowCount
            setLineItemCount(Convert.ToInt16(initialContent[6]), ddlLineItemTo);//RowCount
            this.ddlLineItemFrom.SelectedItem = Convert.ToInt16(initialContent[7]) + 1;//Selected LineItem
            this.ddlLineItemTo.SelectedItem = Convert.ToInt16(initialContent[7]) + 1;//Selected LineItem
        }

        #region events
        private void frmCurrencyBreakDown_Load(object sender, EventArgs e)
        {            
            this.ddlCurrency1.SelectedItem = initialCurrency;
            this.ddlCurrency2.SelectedItem = secondaryCurrency;
            this.ddlCurrency.SelectedItem = outputCurrency;
            txtExchangeRate1.Text = exchangeRateAmount1.ToString();
            txtExchangeRate2.Text = exchangeRateAmount2.ToString();

        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (allowedOK())
            {
                try
                {
                    initialCurrency = this.ddlCurrency1.SelectedItem.ToString();
                    secondaryCurrency = this.ddlCurrency2.SelectedItem.ToString();
                    if (txtExchangeRate2.Text == string.Empty)
                        txtExchangeRate2.Text = "1";
                    exchangeRateAmount1 = decimal.Round(Convert.ToDecimal(txtExchangeRate1.Text), 7);
                    exchangeRateAmount2 = decimal.Round(Convert.ToDecimal(txtExchangeRate2.Text), 7);
                    setLineItemRange();
                    originalLineItemInfo = txtOriginal.Text + ":" + outputCurrency + ":" + txtOriginalAmount.Text; ;
                    computedBreakdown = true;
                }
                catch
                {

                }
                finally
                {
                    this.Close();
                }
            }
            else
                MessageBox.Show("There are unacceptable field values, please review.","Currency Break Down");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ddlCurrency1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExchangeRate1.Text = "1.000000";//Convert.ToDecimal(0).ToString("###,###,###,###.#00000"); ;
        }

        private void ddlCurrency2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExchangeRate2.Text = "1.000000";
        }
        
        #endregion

        #region Developer Designed method
        private bool allowedOK()
        {
            bool retval = false;
            if (txtExchangeRate1.Text == string.Empty)
                return retval;
            if (txtExchangeRate1.Text != string.Empty && ddlCurrency1.SelectedItem.ToString() == "")
                return retval;
            if (txtExchangeRate2.Text != string.Empty && ddlCurrency2.SelectedItem.ToString() == "")
                return retval;
            if (ddlCurrency1.SelectedItem.ToString() == string.Empty)
                return retval;
            if (ddlCurrency2.SelectedItem.ToString() == string.Empty)
                return retval;
            if (ddlCurrency2.SelectedItem.ToString() == outputCurrency && Convert.ToDecimal(txtExchangeRate2.Text) != 1)
                return retval;
            if (txtOriginal.Text == string.Empty)
                return retval;
            if (txtOriginalAmount.Text == string.Empty)
                return retval;
            
            retval = true;
            return retval;
        }

        private void setLineItemCount(int count, ComboBox LineItemComboBox)
        {
            for (int i = 1;i<=count ; i++)
            {
                LineItemComboBox.Items.Add(i);
            }

        }

        private void setLineItemRange()
        {
            int from = 0;
            int to = 0;
            if (Convert.ToInt16(ddlLineItemFrom.SelectedItem.ToString()) >= Convert.ToInt16(ddlLineItemTo.SelectedItem.ToString()))
            {
                from = Convert.ToInt16(ddlLineItemTo.SelectedItem.ToString());
                to = Convert.ToInt16(ddlLineItemFrom.SelectedItem.ToString());
            }
            else
            {
                from = Convert.ToInt16(ddlLineItemFrom.SelectedItem.ToString());
                to = Convert.ToInt16(ddlLineItemTo.SelectedItem.ToString());
            }
            for (int i = from; i <= to; i++)
            {
                lineItemRange.Add(i);
            }
        }

        private void setOriginalLineItem(string OriginalItem)
        {

            try
            {
                if (OriginalItem == string.Empty)
                {
                    txtOriginal.Text = string.Empty;
                    txtOriginalAmount.Text = string.Empty;
                }
                else
                {
                    string[] item;
                    item = OriginalItem.Split(':');
                    txtOriginal.Text = item[0];
                    txtOriginalAmount.Text = item[2];
                }


            }
            catch
            { 
                txtOriginal.Text = string.Empty;
                txtOriginalAmount.Text = string.Empty;
            }

        }
        #endregion


    }
}
