using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace FormControls
{
    public partial class TraxDEDataGridViewTextBoxEditingControl : DataGridViewTextBoxEditingControl
    {
        private string currentValue = string.Empty;
        public TraxDEDataGridViewTextBoxEditingControl()
        {
            InitializeComponent();
            this.CharacterCasing = CharacterCasing.Upper;
            
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.EditingControlDataGridView.CurrentCell.ValueType == typeof(decimal))
            {
                currentValue = this.EditingControlDataGridView.CurrentCell.Value.ToString();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.EditingControlDataGridView.CurrentCell != null)
            {
                if (this.EditingControlDataGridView.CurrentCell.ValueType == typeof(decimal))
                {
                    if (this.EditingControlDataGridView.CurrentCell.Value != null && currentValue == this.EditingControlDataGridView.CurrentCell.Value.ToString())
                    {
                        try
                        {
                            this.EditingControlDataGridView.CurrentCell.Value = Convert.ToDecimal(this.EditingControlDataGridView.CurrentCell.Value.ToString()).ToString();
                        }
                        catch{}
                    }
                    if (this.EditingControlDataGridView.CurrentCell.EditedFormattedValue.ToString().Trim() == string.Empty)
                    {
                        this.EditingControlDataGridView.CurrentCell.Value = DBNull.Value;
                    }
                }
                else if (this.EditingControlDataGridView.CurrentCell.ValueType == typeof(DateTime))
                {
                    if (this.EditingControlDataGridView.CurrentCell.EditedFormattedValue.ToString().Trim() == string.Empty)
                    {
                        this.EditingControlDataGridView.CurrentCell.Value = DBNull.Value;
                    }
                }
                else
                {
                    if (this.EditingControlDataGridView.CurrentCell.EditedFormattedValue.ToString().Trim() == string.Empty)
                    {
                        this.EditingControlDataGridView.CurrentCell.Value = DBNull.Value;
                    }
                    else
                    {
                        this.EditingControlDataGridView.CurrentCell.Value = Regex.Replace(this.EditingControlDataGridView.CurrentCell.Value.ToString(), " {2,}", " ").Trim();
                    }
                }
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
            base.OnKeyDown(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            if (this.EditingControlDataGridView.CurrentCell.ValueType != typeof(decimal) && this.EditingControlDataGridView.CurrentCell.ValueType != typeof(DateTime))
            {
                if (this.EditingControlDataGridView.CurrentCell.EditedFormattedValue.ToString().Trim() == string.Empty)
                {
                    this.EditingControlDataGridView.CurrentCell.Value = DBNull.Value;
                }
                else
                {
                    this.EditingControlDataGridView.CurrentCell.Value = Regex.Replace(Regex.Replace(this.EditingControlDataGridView.CurrentCell.Value.ToString(), "\\*", "").Trim(), " {2,}", " ");
                }
            }
        }
    }
}
