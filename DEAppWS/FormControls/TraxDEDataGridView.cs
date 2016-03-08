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
    public partial class TraxDEDataGridView : DataGridView
    {
        private DataGridViewCell oldCell;

        private int visibleColumnCount;

        [Category("Custom Properties"), DescriptionAttribute("Returns the number of visible columns.")]
        public int VisibleColumnCount
        {
            get
            {
                return visibleColumnCount;
            }
        }

        private ArrayList visibleColumnsIndexes = new ArrayList();

        private ArrayList qaValidationColumns = new ArrayList();

        private bool isQAForm = false;

        [Category("Custom Properties"), DescriptionAttribute("Returns an array list containing the indexes of the visible columns.")]
        public ArrayList VisibleColumnsIndexes
        {
            get
            {
                return visibleColumnsIndexes;
            }
        }

        public ArrayList QAValidationColumns
        {
            get
            {
                return qaValidationColumns;
            }
            set
            {
                qaValidationColumns = value;
            }
        }

        [Category("Custom Properties"), DescriptionAttribute("Returns wether the grid is in a QA form.")]
        public bool IsQAForm
        {
            get
            {
                return isQAForm;
            }
            set
            {
                isQAForm = value;
            }
        }

        public TraxDEDataGridView()
        {
            InitializeComponent();
            AutoGenerateColumns = false;
        }

        public void UpdateVisibleColumnCount()
        {
            OnCreateControl();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            visibleColumnCount = 0;
            visibleColumnsIndexes.Clear();
            for (int i = 0; i < this.ColumnCount; i++)
            {
                if (Columns[i].Visible)
                {
                    visibleColumnCount++;
                    visibleColumnsIndexes.Add(i);
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (base.CurrentCell != null)// && base.CurrentCell.ColumnIndex == Convert.ToInt32(visibleColumnsIndexes[visibleColumnCount - 1]))
                {
                    keyData = Keys.Tab;
                    return base.ProcessDialogKey(keyData);//this.ProcessRightKey(keyData);
                }
                else
                {
                    return base.ProcessDialogKey(keyData);
                }

            }
            return base.ProcessDialogKey(keyData);
        }

        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                return this.ProcessRightKey(e.KeyData);
            }
            return base.ProcessDataGridViewKey(e);
        }

        public new bool ProcessRightKey(Keys keyData)
        {
            Keys key = (keyData & Keys.KeyCode);
            if (key == Keys.Enter)
            {
                if (base.CurrentCell != null && base.CurrentCell.ColumnIndex == Convert.ToInt32(visibleColumnsIndexes[visibleColumnCount - 1]))
                {
                    keyData = Keys.Tab; //SendKeys.Send("{TAB}");                 
                }
                return base.ProcessRightKey(keyData);
            }
            return base.ProcessRightKey(keyData);
        }

        protected override void OnCurrentCellChanged(EventArgs e)
        {
            base.OnCurrentCellChanged(e);

            if (this.ReadOnly == false)
            {
                if (oldCell != null && CurrentCell != null && this.Focus())
                {
                    if (isQAForm)
                    {
                        if (QAValidationColumns.Contains(this.Columns[oldCell.ColumnIndex].Name))
                        {
                            oldCell.Style.BackColor = Color.White;
                            oldCell.Style.ForeColor = Color.Black;
                            oldCell.Style.SelectionBackColor = Color.White;
                            oldCell.Style.SelectionForeColor = Color.Black;
                            InvalidateCell(oldCell);
                        }
                        else
                        {
                            try
                            {
                                oldCell.Style.BackColor = oldCell.InheritedStyle.BackColor;
                            }
                            catch
                            {
                                oldCell.Style.BackColor = DefaultCellStyle.BackColor;
                            }
                            oldCell.Style.ForeColor = DefaultCellStyle.ForeColor;
                            oldCell.Style.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
                            oldCell.Style.SelectionForeColor = DefaultCellStyle.SelectionForeColor;
                            InvalidateCell(oldCell);
                        }
                    }
                    else
                    {
                        try
                        {
                            oldCell.Style.BackColor = oldCell.InheritedStyle.BackColor;
                        }
                        catch
                        {
                            oldCell.Style.BackColor = DefaultCellStyle.BackColor;
                        }
                        oldCell.Style.ForeColor = DefaultCellStyle.ForeColor;
                        oldCell.Style.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
                        oldCell.Style.SelectionForeColor = DefaultCellStyle.SelectionForeColor;
                        InvalidateCell(oldCell);
                    }
                    CurrentCell.Style.SelectionBackColor = Color.Yellow;
                    CurrentCell.Style.SelectionForeColor = Color.Black;
                    InvalidateCell(CurrentCell);
                }
                oldCell = CurrentCell;
            }

        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            if (ReadOnly)
            {
                if (oldCell != null)
                {
                    oldCell.Style.BackColor = DefaultCellStyle.BackColor;
                    oldCell.Style.ForeColor = DefaultCellStyle.ForeColor;
                    oldCell.Style.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
                    oldCell.Style.SelectionForeColor = DefaultCellStyle.SelectionForeColor;
                    InvalidateCell(oldCell);
                    oldCell = null;
                    this.Refresh();
                }
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (this.ReadOnly == false && CurrentCell != null)
            {
                oldCell = null;
                CurrentCell.Style.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
                CurrentCell.Style.SelectionForeColor = DefaultCellStyle.SelectionForeColor;
                if (SelectedRows.Count > 0)
                    InvalidateRow(SelectedRows[0].Index);
                Refresh();
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (this.ReadOnly == false)
            {
                if (CurrentCell != null)
                {
                    CurrentCell.Style.SelectionBackColor = Color.Yellow;
                    CurrentCell.Style.SelectionForeColor = Color.Black;
                    InvalidateCell(CurrentCell);
                }
                oldCell = CurrentCell;
            }

        }

        protected override void OnDataError(bool displayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
        {   
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString() == string.Empty)
            {
                e.Cancel = false;
            }
            else
                base.OnDataError(displayErrorDialogIfNoHandler, e);          
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            if (this.RowHeadersVisible)
            {
                //store a string representation of the row number in 'strRowNumber'
                string strRowNumber = (e.RowIndex + 1).ToString();

                //prepend leading zeros to the string if necessary to improve
                //appearance. For example, if there are ten rows in the grid,
                //row seven will be numbered as "07" instead of "7". Similarly, if 
                //there are 100 rows in the grid, row seven will be numbered as "007".
                while (strRowNumber.Length < this.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

                //determine the display size of the row number string using
                //the DataGridView's current font.
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

                //adjust the width of the column that contains the row header cells 
                //if necessary
                if (this.RowHeadersWidth < (int)(size.Width + 20)) this.RowHeadersWidth = (int)(size.Width + 20);

                //this brush will be used to draw the row number string on the
                //row header cell using the system's current ControlText color
                Brush b = SystemBrushes.ControlText;

                //draw the row number string on the current row header cell using
                //the brush defined above and the DataGridView's default font
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
            //call the base object's OnRowPostPaint method

            base.OnRowPostPaint(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control == true && (e.KeyValue != 33 && e.KeyValue != 34 && e.KeyValue != 35 && e.KeyValue != 36 && e.KeyValue != 37 && e.KeyValue != 38 && e.KeyValue != 39 && e.KeyValue != 40))
                e.Handled = true;
            else
                base.OnKeyDown(e);
        }

        public void updateBackColor()
        {
            if (isQAForm)
            {
                DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
                for (int i = 0; i < this.ColumnCount; i++)
                {
                    cellStyle = this.Columns[i].DefaultCellStyle;
                    if (QAValidationColumns.Contains(this.Columns[i].Name))
                    {
                        cellStyle.BackColor = Color.White;
                        cellStyle.SelectionBackColor = Color.White;
                        this.Columns[i].CellTemplate.Style.BackColor = Color.White;
                        this.Columns[i].CellTemplate.Style.ForeColor = Color.Black;
                        this.Columns[i].CellTemplate.Style.SelectionBackColor = Color.White;
                        this.Columns[i].CellTemplate.Style.SelectionForeColor = Color.Black;
                        this.Columns[i].DefaultCellStyle = cellStyle;
                    }
                    else
                    {
                        cellStyle.BackColor = Color.LightGray;
                        cellStyle.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
                        this.Columns[i].CellTemplate.Style.BackColor = Color.LightGray;
                        this.Columns[i].CellTemplate.Style.ForeColor = DefaultCellStyle.ForeColor;
                        this.Columns[i].CellTemplate.Style.SelectionBackColor = DefaultCellStyle.SelectionBackColor;
                        this.Columns[i].CellTemplate.Style.SelectionForeColor = DefaultCellStyle.SelectionForeColor;
                        this.Columns[i].DefaultCellStyle = cellStyle;
                    }
                    this.InvalidateColumn(i);
                }
            }
        }
    }
}
