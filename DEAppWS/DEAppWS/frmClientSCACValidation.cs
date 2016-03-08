using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using BLogic;
using CommonLibrary;
using FormControls;
namespace DEAppWS
{
    public partial class frmClientSCACValidation : Form
    {
        private DataSet ds = new DataSet();
        private ClientSCACValidationBL.ClientSCACValidationBL bl = new ClientSCACValidationBL.ClientSCACValidationBL();                
        private DataSet dsClient = new DataSet();
        private DataView dv = new DataView();
        private CommonEnum.FormMode formMode = CommonEnum.FormMode.DATA_ENTRY;
        private bool isNoValidation = false;
        private bool isValidated = false;
        private bool isBatchingMatch = false;
        private bool isOverwriteValue = false;
        private bool isDEMatch = false;
        private string scac = string.Empty;
        private string client = string.Empty;
        private string MXXBatch = string.Empty;
        private string MXXOwnerKey = string.Empty;
        private string MXXSCAC = string.Empty;
        public frmClientSCACValidation()
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
        }
        
        public frmClientSCACValidation(CommonEnum.FormMode mode,string Batch, string OwnerKey, string SCAC)
        {
            InitializeComponent();
            bl.Url = ConfigurationManager.AppSettings["WebServiceURL"] + CommonMethod.getWebServiceName(bl.Url);
            formMode = mode;
            defaultValue();
            scac = string.Empty;
            client = string.Empty;
            MXXBatch = Batch;
            MXXOwnerKey = OwnerKey;
            MXXSCAC = SCAC;
            if (bl.isSplitBatches(MXXBatch) && !bl.isUpdateDEClientSCACNeeded(MXXBatch))
            {
                isNoValidation = true;
                this.isValidated = true;
            }
        }

        public bool IsValidated
        {
            get
            {
                return this.isValidated;
            }
        }

        public bool IsNoValidation
        {
            get
            {
                return this.isNoValidation;
            }
        }

        public bool IsOverwriteValue
        {
            get
            {
                return this.isOverwriteValue;
            }
        }

        public string SCAC
        {
            get
            {
                return this.scac;
            }
        }

        public string Client
        {
            get
            {
                return this.client;
            }
        }

        private void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {            
            ds = bl.selectSCAC(getOwnerKey());
            bindgrd();
        }

        private void ddlClient_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void grdSCAC_SelectionChanged(object sender, EventArgs e)
        {
            //if (grdSCAC.Rows.Count > 0 && grdSCAC.SelectedRows.Count > 0 && grdSCAC.Rows[grdSCAC.SelectedRows[0].Index].Cells[1].Value.ToString().Trim() == "NOSCAC")
            //{
            //    txtCarrierName.Clear();
            //    txtCarrierName.Enabled = true;
            //}
            //else
            //{
            //    txtCarrierName.Clear();
            //    txtCarrierName.Enabled = false;
            //}
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                this.defaultValue();
                this.validate();
                if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                {
                    if (!isBatchingMatch)
                    {
                        if (!bl.isSplitBatches(MXXBatch))//if split batch/ no overwrites
                        {
                            if (MessageBox.Show("Batching SCAC/client did not match, do you wish to overwrite?", "SCAC/Client Validation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                if (bl.overwriteClientSCAC(MXXBatch, this.client, this.scac))
                                {
                                    isOverwriteValue = true;
                                    this.isValidated = true;
                                    this.Close();
                                }
                                else
                                    isValidated = false;
                            }
                            else
                            {
                                isValidated = false;
                            }
                        }
                        else
                        {
                            if (MessageBox.Show("Batching SCAC/client did not match but no overwrites for split batches, only root batches.", "SCAC/Client Validation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                bl.createIfObject(MXXBatch, this.client, this.scac);
                                isValidated = true;
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        if (!isDEMatch)
                        {
                            if (MessageBox.Show("Data Entry SCAC/client did not match, do you wish to ignore and proceed?", "SCAC/Client Validation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                bl.createIfObject(MXXBatch, this.client, this.scac);
                                this.isValidated = true;
                                this.Close();
                            }
                            else
                            {
                                isValidated = false;
                            }
                        }
                        else
                        {
                            bl.createIfObject(MXXBatch, this.client, this.scac);
                            this.isValidated = true;
                            this.Close();
                        }
                    }
                }
                else
                {
                    this.isValidated = true;
                    this.Close();
                }
            }
            catch(Exception error)
            {
                isValidated = false;
                MessageBox.Show(error.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindgrd();
        }

        private void frmClientSCACValidation_Load(object sender, EventArgs e)
        {   
            dsClient = bl.selectClient();
            bindDDL();
            ds = bl.selectSCAC(getOwnerKey());
            bindgrd();
        }
        
        private void defaultValue()
        {
            isNoValidation = false;
            isValidated = false;
            isBatchingMatch = false;
            isOverwriteValue = false;
            isDEMatch = false;
        }
        
        private void bindgrd()
        {
            dv.Table = ds.Tables[0];
            this.dv.RowFilter = string.Format("Name LIKE '{0}%' OR Scac LIKE '{0}%' OR [City/State] LIKE '{0}%'", this.txtSearch.Text.Trim());
            this.grdSCAC.DataSource = dv;
            this.grdSCAC.Refresh();
        }

        private string getOwnerKey()
        {
            string[] retval;
            if (this.ddlClient.SelectedValue != null)
                retval = this.ddlClient.SelectedValue.ToString().Split('(');
            else
                return "";
            return retval[retval.Length - 1].Trim(')');
        }

        private void bindDDL()
        {
            this.ddlClient.DisplayMember = "Client";
            this.ddlClient.ValueMember = "Client";
            this.ddlClient.DataSource = dsClient.Tables[0];
            this.ddlClient.Refresh();
        }

        private void validate()
        { 
            //validate code
            this.client = getOwnerKey();
            this.scac = grdSCAC.SelectedRows[0].Cells[1].Value.ToString();
            if (formMode == CommonEnum.FormMode.DATA_ENTRY)
            {
                bl.updateDEClientSCAC(MXXBatch, this.client, this.scac, CommonUserLogin.getUser().UserInitials);//record info
            }
            else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
            {
                //compare results
                if (client == MXXOwnerKey && scac == MXXSCAC)
                {
                    isBatchingMatch = true;
                    string clientDE = string.Empty;//get DE client info
                    string scacDE = string.Empty;//get DE SCAC info
                    DataSet ds = new DataSet();
                    ds = bl.selectDetail(MXXBatch);
                    if(ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                    {
                        clientDE = ds.Tables[0].Rows[0]["DEOwner_Key"].ToString();
                        scacDE = ds.Tables[0].Rows[0]["DEVend_SCAC"].ToString();
                    }
                    if (client == clientDE && scac == scacDE)
                    {                        
                        isDEMatch = true;
                    }
                }
            }            
        }
    }
}
