using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmMasterBase : Form
    {
        protected DataSet ds = new DataSet();
        protected DataRow dr;
        protected DataView dv = new DataView();
        protected DataTable dt = new DataTable("Table");
        protected CommonEnum.FormState currentFormState = CommonEnum.FormState.NORMAL_STATE;
        protected string searchFilter = string.Empty;
        protected ArrayList grdInvisibleColumns = new ArrayList();//invisible columns of the grid
        protected ArrayList readOnlyControlNew = new ArrayList();//readonly controls during New record mode
        protected ArrayList readOnlyControlEdit = new ArrayList();//readonly controls during Edit record mode
        protected ArrayList primaryKeys = new ArrayList();//primary keys of the table
        //protected ArrayList primaryKeyValues = new ArrayList();//values of the primary key
        protected string [] primaryKeysString;//primary keys of the table
        protected string [] primaryKeyValuesString;//values of the primary key
        public frmMasterBase()
        {
            InitializeComponent();
            InitGridColumns(grdList.Columns);
            SetReadOnlyControlsNew();
            SetReadOnlyControlsEdit();
            SetPrimaryKeys();
        }

        #region events
        #region toolStrip
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {            
            setNewRecord();
            currentFormState = CommonEnum.FormState.NEW_STATE;
            enableToolStripButtons(currentFormState);
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            currentFormState = CommonEnum.FormState.EDIT_STATE;
            enableToolStripButtons(currentFormState);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                if (MessageBox.Show("Are you sure to save all changes done?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        this.Save();
                        currentFormState = CommonEnum.FormState.NORMAL_STATE;
                        enableToolStripButtons(currentFormState);
                        bindgrdList();
                        bindListDetail();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Validation failed.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this record?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    this.Delete();
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    enableToolStripButtons(currentFormState);
                    bindgrdList();
                    bindListDetail();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButtonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel all changes done?", "Cancel updates", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    currentFormState = CommonEnum.FormState.NORMAL_STATE;
                    enableToolStripButtons(currentFormState);
                    bindgrdList();
                    bindListDetail();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Quality Assurance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region others
        private void frmMasterBase_Load(object sender, EventArgs e)
        {
            bindgrdList();
            enableToolStripButtons(currentFormState);
        }

        private void frmMasterBase_Enter(object sender, EventArgs e)
        {
            bindgrdList();
            enableToolStripButtons(currentFormState);
        }

        private void grdList_SelectionChanged(object sender, EventArgs e)
        {
            bindListDetail();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrdList();
        }

        private void frmMasterBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentFormState == CommonEnum.FormState.EDIT_STATE || currentFormState == CommonEnum.FormState.NEW_STATE)
            {
                MessageBox.Show("Cannot close in Edit or Open mode.", this.Text);
                e.Cancel = true;
            }
        }
        #endregion

        #endregion

        #region Developer Designed method
        protected virtual void enableToolStripButtons(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        toolStripButtonNew.Enabled = true;
                        toolStripButtonEdit.Enabled = grdList.Rows.Count > 0 ? true : false;
                        toolStripButtonSave.Enabled = false;
                        toolStripButtonDelete.Enabled = false;
                        toolStripButtonCancel.Enabled = false;
                        break;
                    }
                case CommonEnum.FormState.NEW_STATE:
                    {
                        toolStripButtonNew.Enabled = false;
                        toolStripButtonEdit.Enabled = false;
                        toolStripButtonSave.Enabled = true;
                        toolStripButtonDelete.Enabled = false;
                        toolStripButtonCancel.Enabled = true;
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        toolStripButtonNew.Enabled = false;
                        toolStripButtonEdit.Enabled = false;
                        toolStripButtonSave.Enabled = true;
                        toolStripButtonDelete.Enabled = true;
                        toolStripButtonCancel.Enabled = true;
                        break;
                    }
            }
            enableStateControls(currentFormState);
        }

        protected virtual void enableStateControls(CommonEnum.FormState state)
        {
            switch (state)
            {
                case CommonEnum.FormState.NORMAL_STATE:
                    {
                        enableControls(true, new ArrayList(), grpBoxList.Controls);
                        enableControls(false, new ArrayList(), grpBoxDetail.Controls);
                        break;
                    }
                case CommonEnum.FormState.NEW_STATE:
                    {
                        enableControls(false, readOnlyControlNew, grpBoxList.Controls);
                        enableControls(true, readOnlyControlNew, grpBoxDetail.Controls);
                        break;
                    }
                case CommonEnum.FormState.EDIT_STATE:
                    {
                        enableControls(false, readOnlyControlEdit, grpBoxList.Controls);
                        enableControls(true, readOnlyControlEdit, grpBoxDetail.Controls);
                        break;
                    }
            }
        }

        protected virtual void enableControls(bool isEnable, ArrayList readOnlyControls, Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is Button)
                    ((Button)control).Enabled = !readOnlyControls.Contains(control.Name) ? isEnable : false;
                else if (control is CheckBox)
                    ((CheckBox)control).Enabled = !readOnlyControls.Contains(control.Name) ? isEnable : false;
                else if (control is TraxDECheckBox)
                    ((TraxDECheckBox)control).Enabled = !readOnlyControls.Contains(control.Name) ? isEnable : false;
                else if (control is TraxDETextBox)
                    ((TraxDETextBox)control).ReadOnly = !readOnlyControls.Contains(control.Name) ? !isEnable : true;
                else if (control is TraxDEComboBox)
                    ((TraxDEComboBox)control).Enabled = !readOnlyControls.Contains(control.Name) ? isEnable : false;
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).ReadOnly = !readOnlyControls.Contains(control.Name) ? !isEnable : true;               
                else if (control is TraxDEDataGridView)
                {
                    ((TraxDEDataGridView)control).Enabled = !readOnlyControls.Contains(control.Name) ? isEnable : false;
                    ((TraxDEDataGridView)control).StandardTab = !readOnlyControls.Contains(control.Name) ? !isEnable : true;
                }
                else if (control is Panel)
                    enableControls(isEnable, readOnlyControls, ((Panel)control).Controls);
                else if (control is GroupBox)
                    enableControls(isEnable, readOnlyControls, ((GroupBox)control).Controls);
                else if (control is RadioButton)
                    control.Enabled = isEnable;
            }
        }

        protected virtual void bindgrdList()
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                dv.Table = ds.Tables[0];
                this.dv.RowFilter = string.Format(searchFilter, this.txtSearch.Text.Trim());
                this.grdList.DataSource = dv;
                this.grdList.AutoResizeColumns();
                this.grdList.Refresh();
            }
        }

        protected virtual void bindListDetail()
        {
            if (ds == null)
            {
                if ((DataView)grdList.DataSource != null)
                    clearControls();
            }
            else
            {
                if (this.grdList.SelectedRows.Count > 0)
                {
                    foreach (Control control in grpBoxDetail.Controls)
                    {
                        if (control is TraxDETextBox)
                        {
                            ((TraxDETextBox)control).Text = this.grdList.SelectedRows[0].Cells[((TraxDETextBox)control).DatabaseFieldLink].Value.ToString();
                        }
                        else if (control is TraxDEComboBox)
                        {
                            ((TraxDEComboBox)control).SelectedValue = this.grdList.SelectedRows[0].Cells[((TraxDEComboBox)control).DatabaseFieldLink].Value.ToString();
                            ((TraxDEComboBox)control).SelectedItem = this.grdList.SelectedRows[0].Cells[((TraxDEComboBox)control).DatabaseFieldLink].Value.ToString();
                        }
                        else if (control is TraxDECheckBox)
                        {
                            ((TraxDECheckBox)control).Checked = this.grdList.SelectedRows[0].Cells[((TraxDECheckBox)control).DatabaseFieldLink].Value == null ? false : Convert.ToBoolean(this.grdList.SelectedRows[0].Cells[((TraxDECheckBox)control).DatabaseFieldLink].Value);
                        }
                        else if (control is TraxDEMaskedTextBox)
                        {
                            if (dr[((TraxDEMaskedTextBox)control).DatabaseFieldLink].ToString().Trim() != string.Empty)
                            {
                                if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.ValueType.DATELONG)
                                    ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy HH:mm}", this.grdList.SelectedRows[0].Cells[((TraxDEMaskedTextBox)control).DatabaseFieldLink].Value);
                                else if (((TraxDEMaskedTextBox)control).ValueType == CommonEnum.ValueType.DATESHORT)
                                    ((TraxDEMaskedTextBox)control).Text = string.Format("{0:MM/dd/yyyy}", this.grdList.SelectedRows[0].Cells[((TraxDEMaskedTextBox)control).DatabaseFieldLink].Value);
                                else
                                    ((TraxDEMaskedTextBox)control).Text = this.grdList.SelectedRows[0].Cells[((TraxDEMaskedTextBox)control).DatabaseFieldLink].Value.ToString();
                            }
                            else
                                ((TraxDEMaskedTextBox)control).Text = string.Empty;
                        }
                        else if (control is GroupBox)
                        {
                            foreach (Control controls in ((GroupBox)control).Controls)
                            {
                                if (controls is TraxDETextBox)
                                {
                                    ((TraxDETextBox)controls).Text = this.grdList.SelectedRows[0].Cells[((TraxDETextBox)controls).DatabaseFieldLink].Value.ToString();
                                }
                                else if (controls is TraxDEMaskedTextBox)
                                {
                                    ((TraxDEMaskedTextBox)controls).Text = this.grdList.SelectedRows[0].Cells[((TraxDEMaskedTextBox)controls).DatabaseFieldLink].Value.ToString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    clearControls();
                }
            }
        }

        protected virtual void clearControls()
        {
            foreach (Control control in grpBoxDetail.Controls)
            {
                if (control is TraxDETextBox)
                    ((TraxDETextBox)control).Clear();
                else if (control is TraxDECheckBox)
                    ((TraxDECheckBox)control).Checked = false;
                else if (control is TraxDEMaskedTextBox)
                    ((TraxDEMaskedTextBox)control).Clear();
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                            ((TraxDETextBox)controls).Clear();
                    }
                }
            }
        }

        private void populateDataRow()
        {
            dt.Clear();            
            dr = dt.NewRow();
            foreach (Control control in grpBoxDetail.Controls)
            {
                if (control is TraxDETextBox)
                {
                    dr[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                }
                else if (control is TraxDECheckBox)
                {
                    dr[((TraxDECheckBox)control).DatabaseFieldLink] = ((TraxDECheckBox)control).Checked;
                }
                else if (control is TraxDEComboBox)
                {
                    dr[((TraxDEComboBox)control).DatabaseFieldLink] = ((TraxDEComboBox)control).SelectedValue == null ? ((TraxDEComboBox)control).SelectedItem : ((TraxDEComboBox)control).SelectedValue;
                }
                else if (control is TraxDEMaskedTextBox)
                {
                    dr[((TraxDEMaskedTextBox)control).DatabaseFieldLink] = ((TraxDEMaskedTextBox)control).Text;
                }
                else if (control is GroupBox)
                {
                    foreach (Control controls in ((GroupBox)control).Controls)
                    {
                        if (controls is TraxDETextBox)
                        {
                            dr[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                        }
                        else if (controls is TraxDEMaskedTextBox)
                        {
                            dr[((TraxDETextBox)control).DatabaseFieldLink] = ((TraxDETextBox)control).Text;
                        }
                    }
                }
            }
            dt.Rows.Add(dr);
        }

        private void populatePrimaryKeyValues()
        {
            //primaryKeyValues.Clear();            
            primaryKeysString = new string[primaryKeys.Count];
            primaryKeyValuesString = new string[primaryKeys.Count];
            int counter = 0;
            foreach (object keys in primaryKeys)
            {
                //primaryKeyValues.Add(grdList.SelectedRows[0].Cells[keys.ToString()].Value);
                primaryKeysString[counter] = keys.ToString();
                primaryKeyValuesString[counter] = grdList.SelectedRows[0].Cells[keys.ToString()].Value.ToString().Trim();
                counter++;
            }
        }

        protected virtual void InitGridColumns(DataGridViewColumnCollection columns)
        {            
            columns.Clear();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Columns.Count > 0)
            {
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    grdList.Columns.Add(dc.ColumnName, dc.ColumnName);
                    dt.Columns.Add(dc.ColumnName);
                }
                foreach (DataGridViewColumn dgvc in grdList.Columns)
                {
                    dgvc.DataPropertyName = dgvc.Name;
                }
                foreach (object invisibleColumn in grdInvisibleColumns)
                {
                    grdList.Columns[invisibleColumn.ToString()].Visible = false;
                }
                grdList.Columns[0].MinimumWidth = grdList.Columns[0].Width;
                grdList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                
            }
        }

        protected virtual void SetReadOnlyControlsNew()
        {
            readOnlyControlNew.Clear();
        }

        protected virtual void SetReadOnlyControlsEdit()
        {
            readOnlyControlEdit.Clear();
        }

        protected virtual void SetPrimaryKeys()
        {
            primaryKeys.Clear();
        }

        protected virtual void setNewRecord()
        {
            clearControls();
        }

        protected virtual void Save()
        {
            populateDataRow();
        }

        protected virtual void Delete()
        {
            populatePrimaryKeyValues();
        }

        protected virtual bool ValidateSave()
        {            
            return true;
        }
        #endregion
    }
}
