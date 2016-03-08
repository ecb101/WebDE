using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Deployment.Application;
using CommonLibrary;
namespace DEAppWS
{
    public partial class frmMain : Form
    {
        //frmInvoiceManifest frmIM = null;        
        frmVirtualMailRoomBatchSolution frmBHC = null;        
        //frmDataEntry frmDE = null;
        frmDEQA frmNDE = null;
        frmDEQA frmNQA = null;
        frmDEQA frmNT = null;
        //frmQA frmQA = null;        
        //frmImageCombine frmIC = null;
        //frmBatchDeactivation frmBD = null;
        //frmBatchReserve frmBR = null;        
        //frmPasswordChange frmPC = null;
        //frmTransferOwnership frmTO = null;
        //frmForceStatusChange frmFSC = null;
        //frmUserMaster frmUM = null;
        //frmUserGroupMaster frmGM = null;
        //frmCreateMXXmdb frmMC = null;
        //frmImageResolution frmIR = null;
        //frmFBCountCorrection frmFBCC = null;
        //frmDeactivationDescriptionMaster frmDDM = null;
        //frmAlphaNumericKey frmANK = null;
        //frmKeyingInstructionsMaster frmKIM = null;
        //frmOwnerCodeSiteMaster frmOCSM = null;
        //frmQAConfigMaster frmQACM = null;
        //frmDEVersionConfig frmVCM = null;
        //frmSiteRouteConfig frmSRC = null;
        //frmTransferSite frmTS = null;
        public frmMain()
        {
            InitializeComponent();
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                this.Text = this.Text + " Test (" + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + ")";
            }
        }

        #region File
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmPC == null || frmPC.IsDisposed)
            //{
            //    frmPC = new frmPasswordChange(CommonUserLogin.getUser().UserID);
            //}
            //frmPC.MdiParent = this;
            //frmPC.Show();
        }
        #endregion

        #region Windows
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion

        #region transaction
        private void IMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmIM == null || frmIM.IsDisposed)
            //{
            //    frmIM = new frmInvoiceManifest();
            //}
            //frmIM.MdiParent = this;
            //frmIM.Show();
        }

        private void DEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!this.MdiChildren.Contains(frmQA))
            //{
            //    if (frmDE == null || frmDE.IsDisposed)
            //    {
            //        frmDE = new frmDataEntry();
            //    }
            //    frmDE.MdiParent = this;
            //    frmDE.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Does not allow to open both Data Entry module and QA module.", this.Text);
            //}
        }

        private void QAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!this.MdiChildren.Contains(frmDE))
            //{
            //    if (frmQA == null || frmQA.IsDisposed)
            //    {
            //        frmQA = new frmQA();
            //    }
            //    frmQA.MdiParent = this;
            //    frmQA.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Does not allow to open both Data Entry module and QA module.", this.Text);
            //}
        }

        private void BHCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBHC == null || frmBHC.IsDisposed)
            {
                frmBHC = new frmVirtualMailRoomBatchSolution();
            }
            frmBHC.MdiParent = this;
            frmBHC.Show();
        }
        #endregion      

        #region tools
        private void ICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmIC == null || frmIC.IsDisposed)
            //{
            //    frmIC = new frmImageCombine();
            //}
            //frmIC.MdiParent = this;
            //frmIC.Show();
        }

        private void BDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmBD == null || frmBD.IsDisposed)
            //{
            //    frmBD = new frmBatchDeactivation();
            //}
            //frmBD.MdiParent = this;
            //frmBD.Show();
        }

        private void BRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmBR == null || frmBR.IsDisposed)
            //{
            //    frmBR = new frmBatchReserve();
            //}
            //frmBR.MdiParent = this;
            //frmBR.Show();
        }

        private void TOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmTO == null || frmTO.IsDisposed)
            //{
            //    frmTO = new frmTransferOwnership();
            //}
            //frmTO.MdiParent = this;
            //frmTO.Show();
        }

        private void FSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmFSC == null || frmFSC.IsDisposed)
            //{
            //    frmFSC = new frmForceStatusChange();
            //}
            //frmFSC.MdiParent = this;
            //frmFSC.Show();
        }

        private void MCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmMC == null || frmMC.IsDisposed)
            //{
            //    frmMC = new frmCreateMXXmdb();
            //}
            //frmMC.MdiParent = this;
            //frmMC.Show();
        }

        private void IRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmIR == null || frmIR.IsDisposed)
            //{
            //    frmIR = new frmImageResolution();
            //}
            //frmIR.MdiParent = this;
            //frmIR.Show();
        }

        private void FBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmFBCC == null || frmFBCC.IsDisposed)
            //{
            //    frmFBCC = new frmFBCountCorrection();
            //}
            //frmFBCC.MdiParent = this;
            //frmFBCC.Show();
        }

        private void TSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmTS == null || frmTS.IsDisposed)
            //{
            //    frmTS = new frmTransferSite();
            //}
            //frmTS.MdiParent = this;
            //frmTS.Show();
        }
        #endregion

        #region master
        private void UMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmUM == null || frmUM.IsDisposed)
            //{
            //    frmUM = new frmUserMaster();
            //}
            //frmUM.MdiParent = this;
            //frmUM.Show();
        }

        private void GMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmGM == null || frmGM.IsDisposed)
            //{
            //    frmGM = new frmUserGroupMaster();
            //}
            //frmGM.MdiParent = this;
            //frmGM.Show();
        }

        private void DDMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmDDM == null || frmDDM.IsDisposed)
            //{
            //    frmDDM = new frmDeactivationDescriptionMaster();
            //}
            //frmDDM.MdiParent = this;
            //frmDDM.Show();
        }

        private void ANKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmANK == null || frmANK.IsDisposed)
            //{
            //    frmANK = new frmAlphaNumericKey();
            //}
            //frmANK.MdiParent = this;
            //frmANK.Show();
        }

        private void KIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmKIM == null || frmKIM.IsDisposed)
            //{
            //    frmKIM = new frmKeyingInstructionsMaster();
            //}
            //frmKIM.MdiParent = this;
            //frmKIM.Show();
        }

        private void OCSMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmOCSM == null || frmOCSM.IsDisposed)
            //{
            //    frmOCSM = new frmOwnerCodeSiteMaster();
            //}
            //frmOCSM.MdiParent = this;
            //frmOCSM.Show();
        }

        private void QACToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmQACM == null || frmQACM.IsDisposed)
            //{
            //    frmQACM = new frmQAConfigMaster();
            //}
            //frmQACM.MdiParent = this;
            //frmQACM.Show();
        }

        private void VCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmVCM == null || frmVCM.IsDisposed)
            //{
            //    frmVCM = new frmDEVersionConfig();
            //}
            //frmVCM.MdiParent = this;
            //frmVCM.Show();
        }

        private void SRCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (frmSRC == null || frmSRC.IsDisposed)
            //{
            //    frmSRC = new frmSiteRouteConfig();
            //}
            //frmSRC.MdiParent = this;
            //frmSRC.Show();
        }
        #endregion

        #region new transaction
        private void VMNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmBHC == null || frmBHC.IsDisposed)
            {
                frmBHC = new frmVirtualMailRoomBatchSolution();
            }
            frmBHC.MdiParent = this;
            frmBHC.Show();
        }

        private void DENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(frmNDE) && !this.MdiChildren.Contains(frmNQA))
            {
                if (frmNDE == null || frmNDE.IsDisposed)
                {
                    frmNDE = new frmDEQA(CommonEnum.FormMode.DATA_ENTRY);
                }
                frmNDE.MdiParent = this;
                frmNDE.Show();
            }
            else
            {
                MessageBox.Show("Does not allow to open both Data Entry module and QA module.", this.Text);
            }
        }

        private void QANToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.MdiChildren.Contains(frmNDE) && !this.MdiChildren.Contains(frmNQA))
            {
                if (frmNQA == null || frmNQA.IsDisposed)
                {
                    frmNQA = new frmDEQA(CommonEnum.FormMode.QUALITY_ASSURANCE);
                }
                frmNQA.MdiParent = this;
                frmNQA.Show();
            }
            else
            {
                MessageBox.Show("Does not allow to open both Data Entry module and QA module.", this.Text);
            }
        }

        private void DETToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmNT == null || frmNT.IsDisposed)
            {
                frmNT = new frmDEQA(CommonEnum.FormMode.DATA_ENTRY_TRAINER);
            }
            frmNT.MdiParent = this;
            frmNT.Show();
        }
        #endregion

        #region events
        private void frmMain_Shown(object sender, EventArgs e)
        {
            frmUserLogin login = new frmUserLogin();
            login.ShowDialog();
            if (CommonUserLogin.getUser() != null)
            {
                updateMenu(CommonUserLogin.getUser().MenuList);
            }
        }
        #endregion

        #region Developer Designed method
        private void updateMenu(ArrayList MenuItems)
        {
            int itemCounter = 0;            
            foreach (ToolStripMenuItem menuItem in this.menuStrip.Items)
            {
                if (menuItem.Name == "transactionMenu" || menuItem.Name == "toolsMenu" || menuItem.Name == "masterMenu")
                {
                    itemCounter = 0;
                    foreach (ToolStripItem item in menuItem.DropDownItems)
                    {
                        if (MenuItems.Contains(item.Name))
                        {
                            item.Visible = false;
                            itemCounter++;
                        }
                    }
                    if (itemCounter == menuItem.DropDownItems.Count)
                    {
                        menuItem.Visible = false;
                    }
                }
            }            
        }
        #endregion                           

        
                
    }
}
