using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Threading;
using DAL;
using CommonLibrary;
using Trax.FPS;
using Filex.MSharp.Lib.Common;
namespace DEWebService
{
    /// <summary>
    /// Summary description for QABL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QABL : BaseBLogic
    {
        protected DALHelperOleDB dalMXXDatabase;
        private string insertQueryINV_BAT;
        private string insertQueryINVOICE;
        private string insertQueryFRGHT_BL;
        private string insertQueryFB_LN;
        private string insertQueryFXI;
        private string insertQueryTR_BAT;

        public QABL()
        {
        }

        public override void setQueries()
        {
            #region INV_BAT
            insertQueryINV_BAT = @"INSERT INTO [batmdb_INV_BAT]
                                       ([BAT_ID]
                                       ,[OWNER_KEY]
                                       ,[VEND_BAT_KEY]
                                       ,[VEND_BAT_DTM]
                                       ,[VEND_LABL]
                                       ,[BAT_LOC_ID_REMIT]
                                       ,[VEND_FEED]
                                       ,[BAT_KEY]
                                       ,[BAT_STAT]
                                       ,[BAT_TYPE]
                                       ,[BAT_CREAT_DTM]
                                       ,[BAT_DUE_DTM]
                                       ,[BAT_INV_CNT]
                                       ,[BAT_FB_CNT]
                                       ,[BAT_AMT]
                                       ,[VEND_BAT_AMT]
                                       ,[BAT_CURRENCY_QUAL]
                                       ,[BAT_APP_AMT]
                                       ,[BAT_ADJM_AMT]
                                       ,[BAT_PD_AMT]
                                       ,[BAT_ADJM_CNT]
                                       ,[BAT_PAYMT_CNT]
                                       ,[BAT_CREDIT_AMT]
                                       ,[BAT_DISPUTE_AMT]
                                       ,[BAT_OPEN_AMT]
                                       ,[IMG_DP_FILE_GRP]
                                       ,[IMG_DP_FILE_NAME]
                                       ,[IMG_DP_FILE_DTM]
                                       ,[BAT_SNAP_CNT]
                                       ,[BAT_MSG_CTRL_STAT]
                                       ,[BAT_MSG_CTRL_TYPE]
                                       ,[BAT_MSG_CTRL_ROUTE_LABL]
                                       ,[BAT_MSG_CTRL_POD_DTM]
                                       ,[BAT_MSG_CTRL_DTM]
                                       ,[BAT_MSG_CTRL_SNAP_CNT]
                                       ,[MSG_GRP_ORIG_HIST]
                                       ,[MSG_GRP_NUM_HIST]
                                       ,[MSG_GRP_NUM])
                                 VALUES
                                       (@BAT_ID
                                       ,@OWNER_KEY
                                       ,@VEND_BAT_KEY
                                       ,@VEND_BAT_DTM
                                       ,@VEND_LABL
                                       ,@BAT_LOC_ID_REMIT
                                       ,@VEND_FEED
                                       ,@BAT_KEY
                                       ,'Open'
                                       ,'Manual'
                                       ,@BAT_CREAT_DTM
                                       ,@BAT_DUE_DTM
                                       ,@BAT_INV_CNT
                                       ,@BAT_FB_CNT
                                       ,@BAT_AMT
                                       ,@VEND_BAT_AMT
                                       ,@BAT_CURRENCY_QUAL
                                       ,0
                                       ,0
                                       ,0
                                       ,0
                                       ,0
                                       ,0
                                       ,0
                                       ,0
                                       ,@IMG_DP_FILE_GRP
                                       ,@IMG_DP_FILE_NAME
                                       ,@IMG_DP_FILE_DTM
                                       ,@BAT_SNAP_CNT
                                       ,@BAT_MSG_CTRL_STAT
                                       ,@BAT_MSG_CTRL_TYPE
                                       ,@BAT_MSG_CTRL_ROUTE_LABL
                                       ,@BAT_MSG_CTRL_POD_DTM
                                       ,@BAT_MSG_CTRL_DTM
                                       ,@BAT_MSG_CTRL_SNAP_CNT
                                       ,@MSG_GRP_ORIG_HIST
                                       ,@MSG_GRP_NUM_HIST
                                       ,@MSG_GRP_NUM)";

            #endregion
            #region INVOICE
            insertQueryINVOICE = @"INSERT INTO [batmdb_Invoice]
                                       ([INV_ID]
                                       ,[OWNER_KEY]
                                       ,[INV_KEY]
                                       ,[BAT_ID]
                                       ,[BAT_KEY]
                                       ,[VEND_BAT_KEY]
                                       ,[VEND_LABL]
                                       ,[INV_STAT]
                                       ,[INV_TYPE]
                                       ,[INV_ORIG_ID]
                                       ,[INV_CREAT_DTM]
                                       ,[INV_DUE_DTM]
                                       ,[INV_FB_CNT]
                                       ,[INV_AMT]
                                       ,[VEND_INV_AMT]
                                       ,[INV_CURRENCY_QUAL]
                                       ,[INV_APP_AMT]
                                       ,[INV_ADJM_AMT]
                                       ,[INV_PD_AMT]
                                       ,[INV_PD_DTM]
                                       ,[INV_ADJM_CNT]
                                       ,[INV_PAYMT_CNT]
                                       ,[INV_CREDIT_AMT]
                                       ,[INV_DISPUTE_AMT]
                                       ,[INV_OPEN_AMT]
                                       ,[ACCT_NUM_VEND_BLNG]
                                       ,[ACCT_ID_VEND_BLNG]
                                       ,[LOC_ID_BLNG]
                                       ,[LOC_KEY_BLNG]
                                       ,[AL_BLNG_QUAL]
                                       ,[AL_BLNG_1]
                                       ,[AL_BLNG_2]
                                       ,[AL_BLNG_3]
                                       ,[AL_BLNG_4]
                                       ,[AL_CITY_BLNG]
                                       ,[AL_STATE_PROV_BLNG]
                                       ,[AL_POST_CODE_BLNG]
                                       ,[AL_CNTRY_CODE_BLNG]
                                       ,[AL_PHONE_NUM_BLNG]
                                       ,[AL_PHONE_EXT_BLNG]
                                       ,[LOC_ID_REMIT]
                                       ,[LOC_KEY_REMIT]
                                       ,[AL_REMIT_QUAL]
                                       ,[AL_REMIT_1]
                                       ,[AL_REMIT_2]
                                       ,[AL_REMIT_3]
                                       ,[AL_REMIT_4]
                                       ,[AL_CITY_REMIT]
                                       ,[AL_STATE_PROV_REMIT]
                                       ,[AL_POST_CODE_REMIT]
                                       ,[AL_CNTRY_CODE_REMIT]
                                       ,[AL_PHONE_NUM_REMIT]
                                       ,[AL_PHONE_EXT_REMIT]
                                       ,[MSG_GRP_NUM])
                                 VALUES
                                       (@INV_ID
                                       ,@OWNER_KEY
                                       ,@INV_KEY
                                       ,@BAT_ID
                                       ,@BAT_KEY
                                       ,@VEND_BAT_KEY
                                       ,@VEND_LABL
                                       ,@INV_STAT
                                       ,@INV_TYPE
                                       ,@INV_ORIG_ID
                                       ,@INV_CREAT_DTM
                                       ,@INV_DUE_DTM
                                       ,@INV_FB_CNT
                                       ,@INV_AMT
                                       ,@VEND_INV_AMT
                                       ,@INV_CURRENCY_QUAL
                                       ,0
                                       ,0
                                       ,0
                                       ,@INV_PD_DTM
                                       ,0
                                       ,0
                                       ,0
                                       ,0
                                       ,0
                                       ,@ACCT_NUM_VEND_BLNG
                                       ,@ACCT_ID_VEND_BLNG
                                       ,@LOC_ID_BLNG
                                       ,@LOC_KEY_BLNG
                                       ,@AL_BLNG_QUAL
                                       ,@AL_BLNG_1
                                       ,@AL_BLNG_2
                                       ,@AL_BLNG_3
                                       ,@AL_BLNG_4
                                       ,@AL_CITY_BLNG
                                       ,@AL_STATE_PROV_BLNG
                                       ,@AL_POST_CODE_BLNG
                                       ,@AL_CNTRY_CODE_BLNG
                                       ,@AL_PHONE_NUM_BLNG
                                       ,@AL_PHONE_EXT_BLNG
                                       ,@LOC_ID_REMIT
                                       ,@LOC_KEY_REMIT
                                       ,@AL_REMIT_QUAL
                                       ,@AL_REMIT_1
                                       ,@AL_REMIT_2
                                       ,@AL_REMIT_3
                                       ,@AL_REMIT_4
                                       ,@AL_CITY_REMIT
                                       ,@AL_STATE_PROV_REMIT
                                       ,@AL_POST_CODE_REMIT
                                       ,@AL_CNTRY_CODE_REMIT
                                       ,@AL_PHONE_NUM_REMIT
                                       ,@AL_PHONE_EXT_REMIT
                                       ,@MSG_GRP_NUM)";
            #endregion
            #region FRGHT_BL
            insertQueryFRGHT_BL = @"INSERT INTO [batmdb_FRGHT_BL]
           ([FB_ID]
           ,[OWNER_KEY]
           ,[FB_KEY]
           ,[VEND_FB_TYPE]
           ,[FB_TYPE]
           ,[FB_PARENT_ID]
           ,[INV_ID]
           ,[INV_KEY]
           ,[BAT_ID]
           ,[BAT_KEY]
           ,[FB_CLASS]
           ,[FB_STAT]
           ,[FB_LN_CNT]
           ,[FB_AMT]
           ,[FB_FRGHT_AMT]
           ,[FB_DSCNT_AMT]
           ,[FB_ACC_AMT]
           ,[FB_TAX_AMT]
           ,[FB_CURRENCY_QUAL]
           ,[FB_RPT_FACTOR]
           ,[TX_FB_AMT]
           ,[TX_FB_FRGHT_AMT]
           ,[TX_FB_DSCNT_AMT]
           ,[TX_FB_ACC_AMT]
           ,[TX_FB_TAX_AMT]
           ,[TX_FB_TAX_PCNT]
           ,[TX_FB_CURRENCY_QUAL]
           ,[TX_FB_RPT_FACTOR]
           ,[FB_APP_AMT]
           ,[FB_APP_FRGHT_AMT]
           ,[FB_APP_DSCNT_AMT]
           ,[FB_APP_ACC_AMT]
           ,[FB_APP_TAX_AMT]
           ,[FB_APP_TAX_PCNT]
           ,[FB_APP_CURRENCY_QUAL]
           ,[FB_APP_RPT_FACTOR]
           ,[FB_ADJM_AMT]
           ,[FB_ADJM_REASON]
           ,[FB_ADJM_DESC]
           ,[FB_PD_AMT]
           ,[FB_CREDIT_AMT]
           ,[FB_DISPUTE_AMT]
           ,[FB_OPEN_AMT]
           ,[FB_TERMS]
           ,[FB_PAYMT_TERMS_CODE]
           ,[FB_CREAT_DTM]
           ,[FB_DUE_DTM]
           ,[FB_ADJM_CNT]
           ,[FB_PAYMT_CNT]
           ,[FB_PKG_TYPE]
           ,[FB_PCS_CNT]
           ,[BUNDLE_NUM]
           ,[TX_SHPMT_ID]
           ,[VEND_LABL]
           ,[SRVC_REQ_CODE]
           ,[VEND_SRVC_NAME]
           ,[VEND_COMMIT_CODE]
           ,[VEND_SRVC_GUAR_CODE]
           ,[VEND_TARIFF]
           ,[VEND_RATE_SCALE]
           ,[CA_INFO_1_RAW]
           ,[CA_INFO_2_RAW]
           ,[BOL_1_RAW]
           ,[BOL_NUM_KEY]
           ,[ACCT_NUM_VEND_BLNG]
           ,[ACCT_NUM_VEND_ORIG]
           ,[ACCT_NUM_VEND_DEST]
           ,[LOC_ID_ORIG]
           ,[LOC_KEY_ORIG]
           ,[AL_ORIG_QUAL]
           ,[AL_ORIG_1]
           ,[AL_ORIG_2]
           ,[AL_ORIG_3]
           ,[AL_ORIG_4]
           ,[AL_CITY_ORIG]
           ,[AL_STATE_PROV_ORIG]
           ,[AL_POST_CODE_ORIG]
           ,[AL_CNTRY_CODE_ORIG]
           ,[AL_PHONE_NUM_ORIG]
           ,[AL_PHONE_EXT_ORIG]
           ,[LOC_ID_DEST]
           ,[LOC_KEY_DEST]
           ,[AL_DEST_QUAL]
           ,[AL_DEST_1]
           ,[AL_DEST_2]
           ,[AL_DEST_3]
           ,[AL_DEST_4]
           ,[AL_CITY_DEST]
           ,[AL_STATE_PROV_DEST]
           ,[AL_POST_CODE_DEST]
           ,[AL_CNTRY_CODE_DEST]
           ,[AL_PHONE_NUM_DEST]
           ,[AL_PHONE_EXT_DEST]
           ,[ENT_TYPE_BLNG]
           ,[LOC_ID_BLNG]
           ,[LOC_KEY_BLNG]
           ,[ENT_TYPE_SHPR]
           ,[LOC_ID_SHPR]
           ,[LOC_KEY_SHPR]
           ,[ENT_TYPE_CONS]
           ,[LOC_ID_CONS]
           ,[LOC_KEY_CONS]
           ,[FB_ACTUAL_WT]
           ,[FB_DIM_WT]
           ,[FB_BRK_PT_WT]
           ,[FB_FNCL_WT]
           ,[FB_WT_QUAL]
           ,[FB_DECL_AMT]
           ,[TX_FB_DIM_WT]
           ,[TX_FB_BRK_PT_WT]
           ,[TX_FB_FNCL_WT]
           ,[TX_FB_WT_QUAL]
           ,[TX_FB_BASE_RATE]
           ,[FB_PENDING_REASON]
           ,[FB_PENDING_REASON_DESC]
           ,[INTERLINE_SCAC]
           ,[INTERLINE_QUAL]
           ,[INTERLINE_AMT]
           ,[PRICE_LANE_LABL]
           ,[LM_LANE_LABL]
           ,[LM_REQ_KEY]
           ,[LM_DIST]
           ,[LM_DIST_QUAL]
           ,[TX_LM_DIST]
           ,[TX_LM_DIST_QUAL]
           ,[TX_LM_TYPE]
           ,[TX_LM_DIR]
           ,[LM_TRANSIT_STAT]
           ,[LM_RDY_DTM]
           ,[LM_PKUP_BY_DTM]
           ,[LM_DLVRY_REQ_DTM]
           ,[LM_PKUP_ACTUAL_DTM]
           ,[LM_PKUP_VARNC_LABL]
           ,[LM_PKUP_VARNC_REASON]
           ,[LM_ETA_DTM]
           ,[LM_ATA_DTM]
           ,[LM_FIRST_DLVRY_DTM]
           ,[LM_ATA/ETA_VARNC_LABL]
           ,[LM_ATA/ETA_VARNC_REASON]
           ,[POD_SIGN_BY]
           ,[FB_DU_FLAG]
           ,[FORCE_FA_EX_FLAG]
           ,[RULE_MP_WINNER]
           ,[RULE_DU_WINNER]
           ,[RULE_LM_WINNER]
           ,[RULE_ORIG_WINNER]
           ,[RULE_DEST_WINNER]
           ,[RULE_BOL_WINNER]
           ,[RULE_RT_WINNER]
           ,[RULE_FA_WINNER]
           ,[RULE_CA_WINNER]
           ,[RULE_BL_WINNER]
           ,[%T001]
           ,[%T002]
           ,[%T003]
           ,[%T004]
           ,[%T005]
           ,[%T006]
           ,[%T007]
           ,[%T008]
           ,[%T009]
           ,[%T010]
           ,[%T011]
           ,[%T012]
           ,[%T013]
           ,[%T014]
           ,[%T015]
           ,[%T016]
           ,[%T017]
           ,[%T018]
           ,[%T019]
           ,[%T020]
           ,[MSG_GRP_NUM])
     VALUES
           (@FB_ID
           ,@OWNER_KEY
           ,@FB_KEY
           ,@VEND_FB_TYPE
           ,@FB_TYPE
           ,@FB_PARENT_ID
           ,@INV_ID
           ,@INV_KEY
           ,@BAT_ID
           ,@BAT_KEY
           ,@FB_CLASS
           ,@FB_STAT
           ,@FB_LN_CNT
           ,@FB_AMT
           ,@FB_FRGHT_AMT
           ,@FB_DSCNT_AMT
           ,@FB_ACC_AMT
           ,@FB_TAX_AMT
           ,@FB_CURRENCY_QUAL
           ,1
           ,@TX_FB_AMT
           ,@TX_FB_FRGHT_AMT
           ,@TX_FB_DSCNT_AMT
           ,@TX_FB_ACC_AMT
           ,@TX_FB_TAX_AMT
           ,@TX_FB_TAX_PCNT
           ,@TX_FB_CURRENCY_QUAL
           ,1
           ,0
           ,@FB_APP_FRGHT_AMT
           ,@FB_APP_DSCNT_AMT
           ,@FB_APP_ACC_AMT
           ,@FB_APP_TAX_AMT
           ,@FB_APP_TAX_PCNT
           ,@FB_APP_CURRENCY_QUAL
           ,1
           ,0
           ,@FB_ADJM_REASON
           ,@FB_ADJM_DESC
           ,0
           ,0
           ,0
           ,0
           ,@FB_TERMS
           ,@FB_PAYMT_TERMS_CODE
           ,@FB_CREAT_DTM
           ,@FB_DUE_DTM
           ,0
           ,0
           ,@FB_PKG_TYPE
           ,@FB_PCS_CNT
           ,@BUNDLE_NUM
           ,@TX_SHPMT_ID
           ,@VEND_LABL
           ,@SRVC_REQ_CODE
           ,@VEND_SRVC_NAME
           ,@VEND_COMMIT_CODE
           ,@VEND_SRVC_GUAR_CODE
           ,@VEND_TARIFF
           ,@VEND_RATE_SCALE
           ,@CA_INFO_1_RAW
           ,@CA_INFO_2_RAW
           ,@BOL_1_RAW
           ,@BOL_NUM_KEY
           ,@ACCT_NUM_VEND_BLNG
           ,@ACCT_NUM_VEND_ORIG
           ,@ACCT_NUM_VEND_DEST
           ,@LOC_ID_ORIG
           ,@LOC_KEY_ORIG
           ,@AL_ORIG_QUAL
           ,@AL_ORIG_1
           ,@AL_ORIG_2
           ,@AL_ORIG_3
           ,@AL_ORIG_4
           ,@AL_CITY_ORIG
           ,@AL_STATE_PROV_ORIG
           ,@AL_POST_CODE_ORIG
           ,@AL_CNTRY_CODE_ORIG
           ,@AL_PHONE_NUM_ORIG
           ,@AL_PHONE_EXT_ORIG
           ,@LOC_ID_DEST
           ,@LOC_KEY_DEST
           ,@AL_DEST_QUAL
           ,@AL_DEST_1
           ,@AL_DEST_2
           ,@AL_DEST_3
           ,@AL_DEST_4
           ,@AL_CITY_DEST
           ,@AL_STATE_PROV_DEST
           ,@AL_POST_CODE_DEST
           ,@AL_CNTRY_CODE_DEST
           ,@AL_PHONE_NUM_DEST
           ,@AL_PHONE_EXT_DEST
           ,@ENT_TYPE_BLNG
           ,@LOC_ID_BLNG
           ,@LOC_KEY_BLNG
           ,@ENT_TYPE_SHPR
           ,@LOC_ID_SHPR
           ,@LOC_KEY_SHPR
           ,@ENT_TYPE_CONS
           ,@LOC_ID_CONS
           ,@LOC_KEY_CONS
           ,@FB_ACTUAL_WT
           ,0
           ,0
           ,@FB_FNCL_WT
           ,@FB_WT_QUAL
           ,@FB_DECL_AMT
           ,0
           ,0
           ,0
           ,@TX_FB_WT_QUAL
           ,@TX_FB_BASE_RATE
           ,@FB_PENDING_REASON
           ,@FB_PENDING_REASON_DESC
           ,@INTERLINE_SCAC
           ,@INTERLINE_QUAL
           ,@INTERLINE_AMT
           ,@PRICE_LANE_LABL
           ,@LM_LANE_LABL
           ,@LM_REQ_KEY
           ,@LM_DIST
           ,@LM_DIST_QUAL
           ,0
           ,@TX_LM_DIST_QUAL
           ,@TX_LM_TYPE
           ,@TX_LM_DIR
           ,@LM_TRANSIT_STAT
           ,@LM_RDY_DTM
           ,@LM_PKUP_BY_DTM
           ,@LM_DLVRY_REQ_DTM
           ,@LM_PKUP_ACTUAL_DTM
           ,@LM_PKUP_VARNC_LABL
           ,@LM_PKUP_VARNC_REASON
           ,@LM_ETA_DTM
           ,@LM_ATA_DTM
           ,@LM_FIRST_DLVRY_DTM
           ,@LM_ATAETA_VARNC_LABL
           ,@LM_ATAETA_VARNC_REASON
           ,@POD_SIGN_BY
           ,@FB_DU_FLAG
           ,@FORCE_FA_EX_FLAG
           ,@RULE_MP_WINNER
           ,@RULE_DU_WINNER
           ,@RULE_LM_WINNER
           ,@RULE_ORIG_WINNER
           ,@RULE_DEST_WINNER
           ,@RULE_BOL_WINNER
           ,@RULE_RT_WINNER
           ,@RULE_FA_WINNER
           ,@RULE_CA_WINNER
           ,@RULE_BL_WINNER
           ,@T001
           ,@T002
           ,@T003
           ,@T004
           ,@T005
           ,@T006
           ,@T007
           ,@T008
           ,@T009
           ,@T010
           ,@T011
           ,@T012
           ,@T013
           ,@T014
           ,@T015
           ,@T016
           ,@T017
           ,@T018
           ,@T019
           ,@T020
           ,@MSG_GRP_NUM)";

            #endregion
            #region FB_LN
            insertQueryFB_LN = @"INSERT INTO [batmdb_FB_LN]
                                       ([FB_ID]
                                       ,[LINE_ITEM_NUM]
                                       ,[FB_LINE_ITEM_FLAG]
                                       ,[TX_LINE_ITEM_FLAG]
                                       ,[BAT_KEY]
                                       ,[QTY_LABL]
                                       ,[CHRG_DESC]
                                       ,[RATE_AMT]
                                       ,[RATE_TYPE]
                                       ,[RATE_PER_UNT_CNT]
                                       ,[RATE_UNT_LABL]
                                       ,[RATE_CPNT_ID]
                                       ,[CHRG_AMT]
                                       ,[CURRENCY_QUAL]
                                       ,[CAT]
                                       ,[CAT_SEQ_NUM]
                                       ,[PKG_TYPE]
                                       ,[PCS_CNT]
                                       ,[DIM_DATA]
                                       ,[TX_DIM_VOL]
                                       ,[LN_CHRG_CODE]
                                       ,[LN_VEND_RATE_SCALE]
                                       ,[LN_BASIS]
                                       ,[LN_BASIS_QUAL]
                                       ,[LN_DECL_AMT]
                                       ,[LN_ACTUAL_WT]
                                       ,[LN_RATE_AS_WT]
                                       ,[LN_RATE_AS_QUAL]
                                       ,[TX_ACTUAL_WT]
                                       ,[TX_DIM_WT]
                                       ,[TX_FNCL_WT]
                                       ,[TX_RATE_AMT]
                                       ,[CMDTY_CLASS]
                                       ,[VEND_DESC]
                                       ,[%FACSIMILE_01]
                                       ,[%FACSIMILE_02]
                                       ,[%T001]
                                       ,[%T002]
                                       ,[%T003]
                                       ,[%T004]
                                       ,[%T005]
                                       ,[%T006]
                                       ,[MSG_GRP_NUM])
                                 VALUES
                                       (@FB_ID
                                       ,@LINE_ITEM_NUM
                                       ,1
                                       ,@TX_LINE_ITEM_FLAG
                                       ,@BAT_KEY
                                       ,@QTY_LABL
                                       ,@CHRG_DESC
                                       ,@RATE_AMT
                                       ,@RATE_TYPE
                                       ,0
                                       ,@RATE_UNT_LABL
                                       ,@RATE_CPNT_ID
                                       ,@CHRG_AMT
                                       ,@CURRENCY_QUAL
                                       ,@CAT
                                       ,0
                                       ,@PKG_TYPE
                                       ,@PCS_CNT
                                       ,@DIM_DATA
                                       ,@TX_DIM_VOL
                                       ,@LN_CHRG_CODE
                                       ,@LN_VEND_RATE_SCALE
                                       ,@LN_BASIS
                                       ,@LN_BASIS_QUAL
                                       ,@LN_DECL_AMT
                                       ,@LN_ACTUAL_WT
                                       ,@LN_RATE_AS_WT
                                       ,@LN_RATE_AS_QUAL
                                       ,@TX_ACTUAL_WT
                                       ,@TX_DIM_WT
                                       ,@TX_FNCL_WT
                                       ,@TX_RATE_AMT
                                       ,@CMDTY_CLASS
                                       ,@VEND_DESC
                                       ,@FACSIMILE_01
                                       ,@FACSIMILE_02
                                       ,@T001
                                       ,@T002
                                       ,@T003
                                       ,@T004
                                       ,@T005
                                       ,@T006
                                       ,@MSG_GRP_NUM)";
            #endregion
            #region FXI
            insertQueryFXI = @"INSERT INTO batmdb_FXI
                                    (FB_ID,[INV_PAGE_NUM],VEND_LABL,INV_ID,BAT_ID,[INV_PAGE_CNT],[%D1],[%D2],[%N1],[%N2],
                                    [%T001],[%T002],[%T003],[%T004],[%T005],[%T006],[%T007],[%T008],[%T009],[%T010],
                                    [%T011],[%T012],[%T013],[%T014],[%T015],[%T016],[%T017],[%T018],[%T019],[%T020],
                                    [%T021],[%T022],[%T023],[%T024],[%T025],[%T026],[%T027],[%T028],[%T029],[%T030],
                                    [%T031],[%T032],[%T033],[%T034],[%T035],[%T036],[%T037],[%T038],[%T039],[%T040],
                                    [%T041],[%T042],[%T043],[%T044],[%T045],[%T046],[%T047],[%T048],[%T049],[%T050],
                                    [%T051],[%T052],[%T053],[%T054],[%T055],[%T056],[%T057],[%T058],[%T059],[%T060],
                                    [%T061],[%T062],[%T063],[%T064],[%T065],[%T066],[%T067],[%T068],[%T069],[%T070],
                                    [%T071],[%T072],[%T073],[%T074],[%T075],[%T076],[%T077],[%T078],[%T079],[%T080],
                                    [%T081],[%T082],[%T083],[%T084],[%T085],[%T086],[%T087],[%T088],[%T089],[%T090],
                                    [%T091],[%T092],[%T093],[%T094],[%T095],[%T096],[%T097],[%T098],[%T099],[%T100],
                                    [%T101],[%T102],[%T103],[%T104],[%T105],[%T106],[%T107],[%T108],[%T109],[%T110],
                                    [%T111],[%T112],[%T113],[%T114],[%T115],[%T116],[%T117],[%T118],[%T119],[%T120],
                                    [%M001],[%M002],[MSG_GRP_NUM])
                                VALUES
                                    (@FB_ID,@INV_PAGE_NUM,@VEND_LABL,@INV_ID,@BAT_ID,0,@D1,@D2,0,0,
                                    @T001,@T002,@T003,@T004,@T005,@T006,@T007,@T008,@T009,@T010,
                                    @T011,@T012,@T013,@T014,@T015,@T016,@T017,@T018,@T019,@T020,
                                    @T021,@T022,@T023,@T024,@T025,@T026,@T027,@T028,@T029,@T030,
                                    @T031,@T032,@T033,@T034,@T035,@T036,@T037,@T038,@T039,@T040,
                                    @T041,@T042,@T043,@T044,@T045,@T046,@T047,@T048,@T049,@T050,
                                    @T051,@T052,@T053,@T054,@T055,@T056,@T057,@T058,@T059,@T060,
                                    @T061,@T062,@T063,@T064,@T065,@T066,@T067,@T068,@T069,@T070,
                                    @T071,@T072,@T073,@T074,@T075,@T076,@T077,@T078,@T079,@T080,
                                    @T081,@T082,@T083,@T084,@T085,@T086,@T087,@T088,@T089,@T090,
                                    @T091,@T092,@T093,@T094,@T095,@T096,@T097,@T098,@T099,@T100,
                                    @T101,@T102,@T103,@T104,@T105,@T106,@T107,@T108,@T109,@T110,
                                    @T111,@T112,@T113,@T114,@T115,@T116,@T117,@T118,@T119,@T120,
                                    @M001,@M002,@MSG_GRP_NUM)";

            #endregion
            #region TR_BAT
            insertQueryTR_BAT = @"INSERT INTO [TR_BAT]
                                       ([OWNER_KEY]
                                       ,[EX_BAT_KEY]
                                       ,[EX_BAT_KEY_TYPE]
                                       ,[VEND_LABL]
                                       ,[CURR_BAT_KEY]
                                       ,[VEND_BAT_KEY]
                                       ,[BAT_ID]
                                       ,[BAT_KEY]
                                       ,[EX_BAT_CYC_NUM]
                                       ,[EX_BAT_CREAT_DTM]
                                       ,[EX_BAT_CREAT_DTM_ORIG]
                                       ,[BAT_DUE_DTM]
                                       ,[EX_BAT_TRANS_CNT]
                                       ,[EX_BAT_AMT]
                                       ,[EX_BAT_OWN_USER]
                                       ,[EX_BAT_WKS_CODE]
                                       ,[EX_BAT_STAT]
                                       ,[EX_BAT_SUBMIT_DTM]
                                       ,[MDB_WKS_CODE]
                                       ,[MDB_OWN_USER]
                                       ,[MDB_UPDATE_DTM]
                                       ,[EX_BAT_KEY_TYPE_LAST]
                                       ,[RULE_RANGE_REQ]
                                       ,[RULE_CNTXT_REQ]
                                       ,[RULE_CNTXT_LAST]
                                       ,[RULE_CNTXT_VALID]
                                       ,[MSG_GRP_NUM])
                                 VALUES
                                       (@OWNER_KEY
                                       ,@EX_BAT_KEY
                                       ,@EX_BAT_KEY_TYPE
                                       ,@VEND_LABL
                                       ,@CURR_BAT_KEY
                                       ,@VEND_BAT_KEY
                                       ,@BAT_ID
                                       ,@BAT_KEY
                                       ,@EX_BAT_CYC_NUM
                                       ,@EX_BAT_CREAT_DTM
                                       ,@EX_BAT_CREAT_DTM_ORIG
                                       ,@BAT_DUE_DTM
                                       ,@EX_BAT_TRANS_CNT
                                       ,@EX_BAT_AMT
                                       ,@EX_BAT_OWN_USER
                                       ,@EX_BAT_WKS_CODE
                                       ,@EX_BAT_STAT
                                       ,@EX_BAT_SUBMIT_DTM
                                       ,@MDB_WKS_CODE
                                       ,@MDB_OWN_USER
                                       ,@MDB_UPDATE_DTM
                                       ,@EX_BAT_KEY_TYPE_LAST
                                       ,@RULE_RANGE_REQ
                                       ,@RULE_CNTXT_REQ
                                       ,@RULE_CNTXT_LAST
                                       ,@RULE_CNTXT_VALID
                                       ,@MSG_GRP_NUM)";

            #endregion
        }

        [WebMethod]
        public DataSet selectBatches()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT BDE.Bat_Ctrl_Num AS [Batch Number],
                                    BDE.Oper_Init AS [Operator],
                                    BDE.Rev_Init AS [QA By],
                                    BDE.Batch_Status AS [Batch Status],
                                    BDE.Owner_Key AS [Owner Key],
                                    BDE.Vend_SCAC AS [Vendor SCAC],
                                    BDE.Owner_Code AS [OwnerCode]
                            FROM Batch_DE(NOLOCK) BDE
                            JOIN Batch_DE_Ext(NOLOCK) BDX ON BDE.BatchID = BDX.BatchID                          
                            WHERE BDE.Batch_Status IN ('REVIEW','OPENQA')AND Active = 1
                            AND BDX.DEVer = 'OLD'
                            ORDER BY BDE.Bat_Ctrl_Num";
            try
            {
                dal.OpenDB();
                retval = dal.ExecuteDataSet(query, CommandType.Text);
            }
            catch
            {
                retval = null;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool isAllowQA(string batCtrlNum)
        {
            bool retval = false;
            DataSet ds = new DataSet();
            string query = @"SELECT Rev_Init AS [QA By]
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                            AND Batch_Status = 'REVIEW'";
            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == string.Empty)
                {
                    retval = true;
                }
            }
            catch (Exception e)
            {
                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool isAllowUserQA(string batCtrlNum, string userInitials)
        {
            bool retval = false;

            DataSet ds = new DataSet();
            string query = @"SELECT Rev_Init AS [QA By]
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != null)
                    if (ds.Tables[0].Rows[0][0].ToString().Trim() == userInitials)
                        retval = true;

            }
            catch (Exception e)
            {
                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool startReview(string batCtrlNum, string userInitials)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE Batch_DE
                                    SET Rev_Init = @Rev_Init,
                                        REV_START_DTM = @UTCDate
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                   UPDATE Batch_DE_ext
                                    SET f_REV_START_DTM = @UTCDate
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                ParameterInfo[] param = new ParameterInfo[3];
                param[0] = new ParameterInfo("@Rev_Init", userInitials);
                param[1] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                param[2] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dal.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool completeReview(string batCtrlNum, string OwnerCode, int invoiceCount, int fbCount, int fbLineCount, bool isMultiCurrency, bool isFullQA, string userInitials)
        {
            bool retval = false;
            int affectedRows = 0;
            bool isSplitBatch = false;
            DataSet dsFBLn = new DataSet();
            DataSet dsSplitBatches = new DataSet();
            string queryUpdate = @"UPDATE Batch_DE
                                    SET Rev_Init = @Rev_Init,
                                    DE_Complete_DTM = @UTCDate,
                                    Inv_Cnt = @Inv_Cnt,
                                    FB_Cnt = @FB_Cnt,
                                    LI_Cnt = @LI_Cnt,
                                    Batch_Status = 'DE COMPLETE',
                                    [%T002] = @T002
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                   UPDATE Batch_DE_ext
                                    SET f_DE_Complete_DTM = @UTCDate, 
                                        TransmissionId = 0
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            #region Deleted code
            /*
            #region Insert InvBat Query
            string queryInsertInvBat = @"INSERT INTO batmdb_INV_BAT 
                                        SELECT 
                                            BAT_ID,
                                            OWNER_KEY,
                                            VEND_BAT_KEY,
                                            VEND_BAT_DTM,
                                            VEND_LABL,
                                            BAT_LOC_ID_REMIT,
                                            VEND_FEED,
                                            BAT_KEY,
                                            BAT_STAT,
                                            BAT_TYPE,
                                            BAT_CREAT_DTM,
                                            BAT_DUE_DTM,
                                            BAT_INV_CNT,
                                            BAT_FB_CNT,
                                            BAT_AMT,
                                            VEND_BAT_AMT,
                                            BAT_CURRENCY_QUAL,
                                            BAT_APP_AMT,
                                            BAT_ADJM_AMT,
                                            BAT_PD_AMT,
                                            BAT_ADJM_CNT,
                                            BAT_PAYMT_CNT,
                                            BAT_CREDIT_AMT,
                                            BAT_DISPUTE_AMT,
                                            BAT_OPEN_AMT,
                                            IMG_DP_FILE_GRP,
                                            IMG_DP_FILE_NAME,
                                            IMG_DP_FILE_DTM,
                                            BAT_SNAP_CNT,
                                            BAT_MSG_CTRL_STAT,
                                            BAT_MSG_CTRL_TYPE,
                                            BAT_MSG_CTRL_ROUTE_LABL,
                                            BAT_MSG_CTRL_POD_DTM,
                                            BAT_MSG_CTRL_DTM
                                        FROM [" + ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batCtrlNum + ".mdb" + "].batmdb_INV_BAT";
            #endregion

            #region Insert Invoice Query
            string queryInsertInvoice = @"INSERT INTO batmdb_Invoice 
                                        SELECT 
                                            INV_ID,
                                            OWNER_KEY,
                                            INV_KEY,
                                            BAT_ID,
                                            BAT_KEY,
                                            VEND_BAT_KEY,
                                            VEND_LABL,
                                            INV_STAT,
                                            INV_TYPE,
                                            INV_ORIG_ID,
                                            INV_CREAT_DTM,
                                            INV_DUE_DTM,
                                            INV_FB_CNT,
                                            INV_AMT,
                                            VEND_INV_AMT,
                                            INV_CURRENCY_QUAL,
                                            INV_APP_AMT,
                                            INV_ADJM_AMT,
                                            INV_PD_AMT,
                                            INV_PD_DTM,
                                            INV_ADJM_CNT,
                                            INV_PAYMT_CNT,
                                            INV_CREDIT_AMT,
                                            INV_DISPUTE_AMT,
                                            INV_OPEN_AMT,
                                            ACCT_NUM_VEND_BLNG,
                                            ACCT_ID_VEND_BLNG,
                                            LOC_ID_BLNG,
                                            LOC_KEY_BLNG,
                                            AL_BLNG_QUAL,
                                            AL_BLNG_1,
                                            AL_BLNG_2,
                                            AL_BLNG_3,
                                            AL_BLNG_4,
                                            AL_CITY_BLNG,
                                            AL_STATE_PROV_BLNG,
                                            AL_POST_CODE_BLNG,
                                            AL_CNTRY_CODE_BLNG,
                                            AL_PHONE_NUM_BLNG,
                                            AL_PHONE_EXT_BLNG,
                                            LOC_ID_REMIT,
                                            LOC_KEY_REMIT,
                                            AL_REMIT_QUAL,
                                            AL_REMIT_1,
                                            AL_REMIT_2,
                                            AL_REMIT_3,
                                            AL_REMIT_4,
                                            AL_CITY_REMIT,
                                            AL_STATE_PROV_REMIT,
                                            AL_POST_CODE_REMIT,
                                            AL_CNTRY_CODE_REMIT,
                                            AL_PHONE_NUM_REMIT,
                                            AL_PHONE_EXT_REMIT,
                                            MSG_GRP_NUM
                                        FROM [" + ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batCtrlNum + ".mdb" + "].batmdb_INVOICE";
            #endregion

            #region Insert FrghtBL Query
            string queryInsertFrghtBL = @"INSERT INTO batmdb_FRGHT_BL
                                        SELECT 
                                            FB_ID,
                                            OWNER_KEY,
                                            FB_KEY,
                                            VEND_FB_TYPE,
                                            FB_TYPE,
                                            FB_PARENT_ID,
                                            INV_ID,
                                            INV_KEY,
                                            BAT_ID,
                                            BAT_KEY,
                                            FB_CLASS,
                                            FB_STAT,
                                            FB_LN_CNT,
                                            FB_AMT,
                                            FB_FRGHT_AMT,
                                            FB_DSCNT_AMT,
                                            FB_ACC_AMT,
                                            FB_TAX_AMT,
                                            FB_CURRENCY_QUAL,
                                            FB_RPT_FACTOR,
                                            TX_FB_AMT,
                                            TX_FB_FRGHT_AMT,
                                            TX_FB_DSCNT_AMT,
                                            TX_FB_ACC_AMT,
                                            TX_FB_TAX_AMT,
                                            TX_FB_TAX_PCNT,
                                            TX_FB_CURRENCY_QUAL,
                                            TX_FB_RPT_FACTOR,
                                            FB_APP_AMT,
                                            FB_APP_FRGHT_AMT,
                                            FB_APP_DSCNT_AMT,
                                            FB_APP_ACC_AMT,
                                            FB_APP_TAX_AMT,
                                            FB_APP_TAX_PCNT,
                                            FB_APP_CURRENCY_QUAL,
                                            FB_APP_RPT_FACTOR,
                                            FB_ADJM_AMT,
                                            FB_ADJM_REASON,
                                            FB_ADJM_DESC,
                                            FB_PD_AMT,
                                            FB_CREDIT_AMT,
                                            FB_DISPUTE_AMT,
                                            FB_OPEN_AMT,
                                            FB_TERMS,
                                            FB_PAYMT_TERMS_CODE,
                                            FB_CREAT_DTM,
                                            FB_DUE_DTM,
                                            FB_ADJM_CNT,
                                            FB_PAYMT_CNT,
                                            FB_PKG_TYPE,
                                            FB_PCS_CNT,
                                            BUNDLE_NUM,
                                            TX_SHPMT_ID,
                                            VEND_LABL,
                                            SRVC_REQ_CODE,
                                            VEND_SRVC_NAME,
                                            VEND_COMMIT_CODE,
                                            VEND_SRVC_GUAR_CODE,
                                            VEND_TARIFF,
                                            VEND_RATE_SCALE,
                                            CA_INFO_1_RAW,
                                            CA_INFO_2_RAW,
                                            BOL_1_RAW,
                                            BOL_NUM_KEY,
                                            ACCT_NUM_VEND_BLNG,
                                            ACCT_NUM_VEND_ORIG,
                                            ACCT_NUM_VEND_DEST,
                                            LOC_ID_ORIG,
                                            LOC_KEY_ORIG,
                                            AL_ORIG_QUAL,
                                            AL_ORIG_1,
                                            AL_ORIG_2,
                                            AL_ORIG_3,
                                            AL_ORIG_4,
                                            AL_CITY_ORIG,
                                            AL_STATE_PROV_ORIG,
                                            AL_POST_CODE_ORIG,
                                            AL_CNTRY_CODE_ORIG,
                                            AL_PHONE_NUM_ORIG,
                                            AL_PHONE_EXT_ORIG,
                                            LOC_ID_DEST,
                                            LOC_KEY_DEST,
                                            AL_DEST_QUAL,
                                            AL_DEST_1,
                                            AL_DEST_2,
                                            AL_DEST_3,
                                            AL_DEST_4,
                                            AL_CITY_DEST,
                                            AL_STATE_PROV_DEST,
                                            AL_POST_CODE_DEST,
                                            AL_CNTRY_CODE_DEST,
                                            AL_PHONE_NUM_DEST,
                                            AL_PHONE_EXT_DEST,
                                            ENT_TYPE_BLNG,
                                            LOC_ID_BLNG,
                                            LOC_KEY_BLNG,
                                            ENT_TYPE_SHPR,
                                            LOC_ID_SHPR,
                                            LOC_KEY_SHPR,
                                            ENT_TYPE_CONS,
                                            LOC_ID_CONS,
                                            LOC_KEY_CONS,
                                            FB_ACTUAL_WT,
                                            FB_DIM_WT,
                                            FB_BRK_PT_WT,
                                            FB_FNCL_WT,
                                            FB_WT_QUAL,
                                            FB_DECL_AMT,
                                            TX_FB_DIM_WT,
                                            TX_FB_BRK_PT_WT,
                                            TX_FB_FNCL_WT,
                                            TX_FB_WT_QUAL,
                                            TX_FB_BASE_RATE,
                                            FB_PENDING_REASON,
                                            FB_PENDING_REASON_DESC,
                                            INTERLINE_SCAC,
                                            INTERLINE_QUAL,
                                            INTERLINE_AMT,
                                            PRICE_LANE_LABL,
                                            LM_LANE_LABL,
                                            LM_REQ_KEY,
                                            LM_DIST,
                                            LM_DIST_QUAL,
                                            TX_LM_DIST,
                                            TX_LM_DIST_QUAL,
                                            TX_LM_TYPE,
                                            TX_LM_DIR,
                                            LM_TRANSIT_STAT,
                                            LM_RDY_DTM,
                                            LM_PKUP_BY_DTM,
                                            LM_DLVRY_REQ_DTM,
                                            LM_PKUP_ACTUAL_DTM,
                                            LM_PKUP_VARNC_LABL,
                                            LM_PKUP_VARNC_REASON,
                                            LM_ETA_DTM,
                                            LM_ATA_DTM,
                                            LM_FIRST_DLVRY_DTM,
                                            [LM_ATA/ETA_VARNC_LABL],
                                            [LM_ATA/ETA_VARNC_REASON],
                                            POD_SIGN_BY,
                                            FB_DU_FLAG,
                                            FORCE_FA_EX_FLAG,
                                            RULE_MP_WINNER,
                                            RULE_DU_WINNER,
                                            RULE_LM_WINNER,
                                            RULE_ORIG_WINNER,
                                            RULE_DEST_WINNER,
                                            RULE_BOL_WINNER,
                                            RULE_RT_WINNER,
                                            RULE_FA_WINNER,
                                            RULE_CA_WINNER,
                                            RULE_BL_WINNER,
                                            [%T001],
                                            [%T002],
                                            [%T003],
                                            [%T004],
                                            [%T005],
                                            [%T006],
                                            [%T007],
                                            [%T008],
                                            [%T009],
                                            [%T010],
                                            [%T011],
                                            [%T012],
                                            [%T013],
                                            [%T014],
                                            [%T015],
                                            [%T016],
                                            [%T017],
                                            [%T018],
                                            [%T019],
                                            [%T020],
                                            MSG_GRP_NUM
                                        FROM [" + ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batCtrlNum + ".mdb" + "].batmdb_FRGHT_BL";
            #endregion

            #region Insert FBLn Query
            string queryInsertFBLn = @"INSERT INTO batmdb_FB_LN
                                        SELECT
                                            FB_ID,
                                            LINE_ITEM_NUM,
                                            FB_LINE_ITEM_FLAG,
                                            TX_LINE_ITEM_FLAG,
                                            BAT_KEY,
                                            QTY_LABL,
                                            CHRG_DESC,
                                            RATE_AMT,
                                            RATE_TYPE,
                                            RATE_PER_UNT_CNT,
                                            RATE_UNT_LABL,
                                            RATE_CPNT_ID,
                                            CHRG_AMT,
                                            CURRENCY_QUAL,
                                            CAT,
                                            CAT_SEQ_NUM,
                                            PKG_TYPE,
                                            PCS_CNT,
                                            DIM_DATA,
                                            TX_DIM_VOL,
                                            LN_CHRG_CODE,
                                            LN_VEND_RATE_SCALE,
                                            LN_BASIS,
                                            LN_BASIS_QUAL,
                                            LN_DECL_AMT,
                                            LN_ACTUAL_WT,
                                            LN_RATE_AS_WT,
                                            LN_RATE_AS_QUAL,
                                            TX_ACTUAL_WT,
                                            TX_DIM_WT,
                                            TX_FNCL_WT,
                                            TX_RATE_AMT,
                                            CMDTY_CLASS,
                                            VEND_DESC,
                                            [%FACSIMILE_01],
                                            [%FACSIMILE_02],
                                            [%T001],
                                            [%T002],
                                            [%T003],
                                            [%T004],
                                            [%T005],
                                            [%T006],
                                            MSG_GRP_NUM
                                        FROM [" + ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batCtrlNum + ".mdb" + "].batmdb_FB_LN";
            #endregion

            #region Insert FXI Query
            string queryInsertFXI = @"INSERT INTO batmdb_FXI
                                        SELECT 
                                            FB_ID ,VEND_LABL ,INV_ID,BAT_ID, 
                                            [%T001],[%T002],[%T003],[%T004],[%T005],
                                            [%T006],[%T007],[%T008],[%T009],[%T010],
                                            [%T011],[%T012],[%T013],[%T014],[%T015],
                                            [%T016],[%T017],[%T018],[%T019],[%T020],
                                            [%T021],[%T022],[%T023],[%T024],[%T025],
                                            [%T026],[%T027],[%T028],[%T029],[%T030],
                                            [%T031],[%T032],[%T033],[%T034],[%T035],
                                            [%T036],[%T037],[%T038],[%T039],[%T040],
                                            [%T041],[%T042],[%T043],[%T044],[%T045],
                                            [%T046],[%T047],[%T048],[%T049],[%T050],
                                            [%T051],[%T052],[%T053],[%T054],[%T055],
                                            [%T056],[%T057],[%T058],[%T059],[%T060],
                                            [%T061],[%T062],[%T063],[%T064],[%T065],
                                            [%T066],[%T067],[%T068],[%T069],[%T070],
                                            [%T071],[%T072],[%T073],[%T074],[%T075],
                                            [%T076],[%T077],[%T078],[%T079],[%T080],
                                            [%T081],[%T082],[%T083],[%T084],[%T085],
                                            [%T086],[%T087],[%T088],[%T089],[%T090],
                                            [%T091],[%T092],[%T093],[%T094],[%T095],
                                            [%T096],[%T097],[%T098],[%T099],[%T100],
                                            [%T101],[%T102],[%T103],[%T104],[%T105],
                                            [%T106],[%T107],[%T108],[%T109],[%T110],
                                            [%T111],[%T112],[%T113],[%T114],[%T115],
                                            [%T116],[%T117],[%T118],[%T119],[%T120]                                        
                                        FROM OPENROWSET('Microsoft.Jet.OLEDB.4.0','" + ConfigurationManager.AppSettings["MDBDestinationPath"] + batCtrlNum + ".mdb';'Admin';'',batmdb_FXI)";
            #endregion

            #region Insert TRBat Query
            string queryInsertTRBat = @"INSERT INTO TR_BAT
                                        SELECT 
                                            OWNER_KEY,
                                            EX_BAT_KEY,
                                            EX_BAT_KEY_TYPE,
                                            VEND_LABL,
                                            CURR_BAT_KEY,
                                            VEND_BAT_KEY,
                                            BAT_ID,
                                            BAT_KEY,
                                            EX_BAT_CYC_NUM,
                                            EX_BAT_CREAT_DTM,
                                            EX_BAT_CREAT_DTM_ORIG,
                                            BAT_DUE_DTM,
                                            EX_BAT_TRANS_CNT,
                                            EX_BAT_AMT,
                                            EX_BAT_OWN_USER,
                                            EX_BAT_WKS_CODE,
                                            EX_BAT_STAT,
                                            EX_BAT_SUBMIT_DTM,
                                            MDB_WKS_CODE,
                                            MDB_OWN_USER,
                                            MDB_UPDATE_DTM,
                                            EX_BAT_KEY_TYPE_LAST,
                                            RULE_RANGE_REQ,
                                            RULE_CNTXT_REQ,
                                            RULE_CNTXT_LAST,
                                            RULE_CNTXT_VALID,
                                            MSG_GRP_NUM                                            
                                        FROM [" + ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batCtrlNum + ".mdb" + "].TR_BAT";
            #endregion*/
            #endregion
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                ParameterInfo[] param = new ParameterInfo[7];
                param[0] = new ParameterInfo("@Rev_Init", userInitials);
                param[1] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                param[2] = new ParameterInfo("@Inv_Cnt", invoiceCount);
                param[3] = new ParameterInfo("@FB_Cnt", fbCount);
                param[4] = new ParameterInfo("@LI_Cnt", fbLineCount);
                param[5] = new ParameterInfo("@T002", isFullQA == true ? "Full QA base on configuration" : "Default QA or QA base on configuration without Freight bill level validation");
                param[6] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                //Get if it is a split batch
                ParameterInfo[] paramBat = new ParameterInfo[1];
                paramBat[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);//get rootbatch                
                isSplitBatch = Convert.ToInt32(dal.ExecuteScalar("SELECT COUNT(*) FROM Batch_DE_Split(NOLOCK) WHERE Bat_Ctrl_Num_Split =  @Bat_Ctrl_Num", CommandType.Text, paramBat)) > 0;
                if (!isSplitBatch)//if not split batch
                {
                    //update batmdb_FB_LN VEND_DESC ug %FACSIMILE_01
                    dsFBLn = FBLnUpdate(batCtrlNum, false, isMultiCurrency, dsFBLn);
                    //update Batch_de.mdb table Batch_DE
                    affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                    //insert into Global_DE na table
                    insertGlobalDB(dal, this.selectBatch(batCtrlNum));
                    moveToProd("MXX" + batCtrlNum + ".mdb", OwnerCode);
                    archiveMDBFile(batCtrlNum, dal);
                    dsSplitBatches = dal.ExecuteDataSet("SELECT Bat_Ctrl_Num_Split FROM Batch_DE_Split WHERE Bat_Ctrl_Num_Root =  @Bat_Ctrl_Num", CommandType.Text, paramBat);
                    foreach (DataRow row in dsSplitBatches.Tables[0].Rows)
                    {
                        archiveMDBFile(row["Bat_Ctrl_Num_Split"].ToString().Trim(), dal);
                    }
                    //move mxx file to correct folder                                        
                }
                else
                {
                    string splitbatches = string.Empty;
                    //update split batch status to "COMBINED"
                    ParameterInfo[] paramBat2 = new ParameterInfo[2];
                    paramBat2[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                    paramBat2[1] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                    affectedRows = dal.ExecuteNonQuery(string.Format(@"UPDATE Batch_DE SET Batch_Status = 'COMBINED',DE_Complete_DTM = @UTCDate, FB_Cnt = {0} WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num 
                                                                       UPDATE Batch_DE_ext SET f_DE_Complete_DTM = @UTCDate WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num", fbCount.ToString()), CommandType.Text, paramBat2);
                    dsSplitBatches = dal.ExecuteDataSet("SELECT A.*,DE.Batch_Status AS DEStatus FROM Batch_DE_Split A INNER JOIN Batch_DE_Split B ON A.Bat_Ctrl_Num_Root = B.Bat_Ctrl_Num_Root INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num WHERE B.Bat_Ctrl_Num_Split =  @Bat_Ctrl_Num ORDER BY B.Bat_Ctrl_Num_Split", CommandType.Text, paramBat);
                    if (checkAllCombined(dsSplitBatches.Tables[0], out splitbatches))//check if all the other related split batches are "COMBINED" status
                    {

                        //update all status to Combining
                        affectedRows = dal.ExecuteNonQuery("UPDATE Batch_DE SET Batch_Status = 'COMBINING' " + splitbatches, CommandType.Text);
                        createCombinedMDB(dsSplitBatches.Tables[0], userInitials);//create a combined mdb file for the root batch
                        //update root batch status to "REVIEW"                        
                        paramBat[0] = new ParameterInfo("@Bat_Ctrl_Num", dsSplitBatches.Tables[0].Rows[0]["Bat_Ctrl_Num_Root"].ToString().Trim());//get rootbatch
                        affectedRows = dal.ExecuteNonQuery(@"UPDATE Batch_DE SET Batch_Status = 'REVIEW', 
                                                            DE_START_DTM = (SELECT TOP 1 DE.DE_START_DTM AS DEStart FROM Batch_DE_Split A INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num WHERE A.Bat_Ctrl_Num_Root  = @Bat_Ctrl_Num ORDER BY DE.DE_START_DTM),
                                                            DE_FIN_DTM = (SELECT TOP 1 DE.DE_FIN_DTM AS DEFinish FROM Batch_DE_Split A INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num WHERE A.Bat_Ctrl_Num_Root  = @Bat_Ctrl_Num ORDER BY DE.DE_FIN_DTM DESC)
                                                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                                            UPDATE Batch_DE_ext SET  
                                                            f_DE_START_DTM = (SELECT TOP 1 ext.f_DE_START_DTM AS DEStart FROM Batch_DE_Split A INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num INNER JOIN Batch_DE_ext ext ON ext.Bat_Ctrl_Num = DE.Bat_Ctrl_Num WHERE A.Bat_Ctrl_Num_Root  = @Bat_Ctrl_Num ORDER BY DE.DE_START_DTM),
                                                            f_DE_FIN_DTM = (SELECT TOP 1 ext.f_DE_FIN_DTM AS DEFinish FROM Batch_DE_Split A INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num INNER JOIN Batch_DE_ext ext ON ext.Bat_Ctrl_Num = DE.Bat_Ctrl_Num WHERE A.Bat_Ctrl_Num_Root  = @Bat_Ctrl_Num ORDER BY DE.DE_FIN_DTM DESC)
                                                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num", CommandType.Text, paramBat);
                        //update all related split batch statuses in Batch_DE to "SPLIT COMPLETE"
                        affectedRows = dal.ExecuteNonQuery("UPDATE Batch_DE SET Batch_Status = 'SPLIT COMPLETE' " + splitbatches, CommandType.Text);
                        //update all related split batch statuses in Batch_DE_Split to "SPLIT COMPLETE"
                        affectedRows = dal.ExecuteNonQuery("UPDATE Batch_DE_Split SET Batch_Status = 'SPLIT COMPLETE' WHERE Bat_Ctrl_Num_Root = @Bat_Ctrl_Num", CommandType.Text, paramBat);
                    }
                }
                //commit all if there are no problem
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                FBLnUpdate(batCtrlNum, true, isMultiCurrency, dsFBLn);
                dal.RollBackTransaction();

                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        private DataSet FBLnUpdate(string batCtrlNum, bool isRollback, bool isMultipleCurrency, DataSet dsFBLn)
        {
            DataSet retval = new DataSet();
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", @"QA\MXX" + batCtrlNum.Trim() + ".mdb");
            string queryUpdateVendDesk = string.Empty;
            string queryUpdateFacsimile = string.Empty;
            string querySelectFBLn = @"SELECT 
                                            FB_ID AS FbId,
                                            LINE_ITEM_NUM AS LineItemNum,
                                            [%FACSIMILE_01] AS Facsimile01,
                                            [%FACSIMILE_02] AS Facsimile02,
                                            [%T001] AS T001,
                                            [%T002] AS T002,
                                            [%T003] AS T003,
                                            [%T004] AS T004,
                                            [%T005] AS T005
                                        FROM batmdb_FB_LN";
            ParameterInfoOleDB[] param = new ParameterInfoOleDB[9];

            if (isRollback)
            {
                if (isMultipleCurrency)
                {
                    queryUpdateVendDesk = @"UPDATE batmdb_FB_LN SET [%FACSIMILE_01] = @Facsimile01,
                                                                    [%FACSIMILE_02] = @Facsimile02,
                                                                    [%T001] = @T001,
                                                                    [%T002] = @T002,
                                                                    [%T003] = @T003,
                                                                    [%T004] = @T004,
                                                                    [%T005] = @T005,
                                                                    [%T006] = 'MultipleCurrency'
                                            WHERE FB_ID = @FbId AND LINE_ITEM_NUM = @LineItemNum";
                }
                else
                    queryUpdateVendDesk = @"UPDATE batmdb_FB_LN SET [%FACSIMILE_01] = VEND_DESC";
                queryUpdateFacsimile = @"UPDATE batmdb_FB_LN SET VEND_DESC = NULL";
            }
            else
            {
                if (isMultipleCurrency)
                    queryUpdateVendDesk = @"UPDATE batmdb_FB_LN SET VEND_DESC = IIF(ISNULL([%FACSIMILE_01]),'',[%FACSIMILE_01]) + IIF([%T003] = CURRENCY_QUAL,'',' ;RATE1: '  + [%T001] + ' ;AMOUNT: ' + [%T002] + ' ;CUR1: ' + [%T003] + IIF([%T005] = CURRENCY_QUAL ,'', ' ;RATE2: '  + [%T004]  + ' ;CUR2: ' + [%T005]) + ' ;ORIGINAL ITEM: ' + IIF(ISNULL([%FACSIMILE_02]),'',[%FACSIMILE_02]))";
                else
                    queryUpdateVendDesk = @"UPDATE batmdb_FB_LN SET VEND_DESC = [%FACSIMILE_01]";
                queryUpdateFacsimile = @"UPDATE batmdb_FB_LN SET [%FACSIMILE_01] = NULL,
                                                                 [%FACSIMILE_02] = NULL,
                                                                 [%T001] = NULL,
                                                                 [%T002] = NULL,
                                                                 [%T003] = NULL,
                                                                 [%T004] = NULL,
                                                                 [%T005] = NULL,
                                                                 [%T006] = NULL";
            }
            int affectedRows = 0;
            try
            {
                dalMXXDatabase.OpenDB();
                dalMXXDatabase.BeginTransaction();
                if (isMultipleCurrency)
                {
                    if (!isRollback)
                    {
                        try
                        {
                            retval = dalMXXDatabase.ExecuteDataSet(querySelectFBLn, CommandType.Text);
                        }
                        catch (Exception error)
                        {
                            retval = null;
                            throw error;
                        }
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(queryUpdateVendDesk, CommandType.Text);
                    }
                    else
                    {
                        if (dsFBLn != null)
                        {
                            foreach (DataRow row in dsFBLn.Tables[0].Rows)
                            {
                                param[0] = new ParameterInfoOleDB("@Facsimile01", row["Facsimile01"]);
                                param[1] = new ParameterInfoOleDB("@Facsimile02", row["Facsimile02"]);
                                param[2] = new ParameterInfoOleDB("@T001", row["T001"]);
                                param[3] = new ParameterInfoOleDB("@T002", row["T002"]);
                                param[4] = new ParameterInfoOleDB("@T003", row["T003"]);
                                param[5] = new ParameterInfoOleDB("@T004", row["T004"]);
                                param[6] = new ParameterInfoOleDB("@T005", row["T005"]);
                                param[7] = new ParameterInfoOleDB("@FbId", row["FbId"]);
                                param[8] = new ParameterInfoOleDB("@LineItemNum", Convert.ToInt16(row["LineItemNum"]));
                                affectedRows = dalMXXDatabase.ExecuteNonQuery(queryUpdateVendDesk, CommandType.Text, param);
                            }
                        }
                    }


                }
                else
                {
                    retval = null;
                    affectedRows = dalMXXDatabase.ExecuteNonQuery(queryUpdateVendDesk, CommandType.Text);
                }
                affectedRows = dalMXXDatabase.ExecuteNonQuery(queryUpdateFacsimile, CommandType.Text);
                dalMXXDatabase.CommitTransaction();
            }
            catch (Exception e)
            {
                dalMXXDatabase.RollBackTransaction();
                throw e;
            }
            finally
            {
                dalMXXDatabase.CloseDB();
            }
            return retval;
        }

        private void moveToProd(string file, string OwnerCode)
        {
            string folder = string.Empty;
            bool moveTry = true;
            bool moveSuccessful = false;
            string errorMessage = string.Empty;
            int counter = 0;
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = ConfigurationManager.AppSettings["PathConfigFile"];
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            try
            {
                folder = config.AppSettings.Settings[OwnerCode].Value;
            }
            catch
            {
                throw new Exception("Application configuration is lacking path settings for " + OwnerCode.Trim() + ".");
            }
            while (moveTry)
            {
                try
                {
                    counter = counter + 1;
                    File.Copy(ConfigurationManager.AppSettings["MDBDestinationPath"] + @"QA\" + file, folder + file);
                    moveTry = false;
                    moveSuccessful = true;
                }
                catch (Exception e)
                {
                    if (counter == 3)
                    {
                        moveTry = false;
                        errorMessage = e.Message;
                    }
                    else
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        Thread.Sleep(1000);
                    }
                }
                finally
                {
                }
            }
            if (!moveSuccessful)
            {
                throw new Exception(errorMessage);
            }
        }

        private string getCompleteDestinationFolderPath(string folderName)
        {
            string retval = ConfigurationManager.AppSettings["ProcessedImagePath"] + folderName;
            if (!Directory.Exists(retval))
            {
                Directory.CreateDirectory(retval);
            }
            return retval;
        }

        [WebMethod]
        public bool isAllowQAEdit(string batCtrlNum, string systemUserName)
        {
            bool retval = false;

            DataSet ds = new DataSet();
            string query = @"SELECT Batch_Status AS [Batch Status]
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";

            string queryUpdate = @"UPDATE Batch_DE
                                    SET Batch_Status = 'OPENQA'
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                dal.BeginTransaction();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                if (ds.Tables[0].Rows.Count > 0 && (ds.Tables[0].Rows[0][0].ToString() == "REVIEW"))
                {
                    dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                    dal.CommitTransaction();
                    this.BatchAuditTrailInsert(batCtrlNum, "120", dal, systemUserName);//auditTrailBatch(batCtrlNum, "120");
                    retval = true;
                }
            }
            catch (Exception e)
            {
                dal.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        private bool completeReviewObject(string batCtrlNum, string OwnerCode, int invoiceCount, int fbCount, int fbLineCount, bool isMultiCurrency)
        {
            bool retval = false;
            //update RawBatFile QA,DECompleteDate
            //update RawGroupInfo status,UserId(Last updatedby)
            //update batmdb_FB_LN VEND_DESC ug %FACSIMILE_01
            //insert all data in the business object to a global database(InvBat, invoice, FB, FBLn)
            //move business object file to be parsed.
            return retval;
        }

        private DataTable FBLnUpdateBusinessObject(string batCtrlNum, bool isRollback, bool isMultipleCurrency, DataTable dtFBLn)
        {
            DataTable retval = new DataTable("FBLn");
            retval.Columns.Add("FbId");
            retval.Columns.Add("LineItemNum");
            retval.Columns.Add("Facsimile01");
            retval.Columns.Add("T001");
            retval.Columns.Add("T002");
            retval.Columns.Add("T003");
            retval.Columns.Add("T004");


            InvBat invBat = new InvBat();
            string filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + batCtrlNum + ".mxx";

            //check if file exist
            if (File.Exists(filename))
            {
                //depersist file to an InvBat object
                try
                {
                    invBat = (InvBat)dalTrax.DepersistFile(filename);//batCtrlNum + ".mxx");
                    if (isRollback)
                    {
                        if (!isMultipleCurrency)
                        {
                            foreach (Invoice invoice in invBat.Invoices)
                            {
                                foreach (FrghtBl frghtBl in invoice.FrghtBls)
                                {
                                    foreach (FbLn fbLn in frghtBl.LineItems)
                                    {
                                        fbLn.Facsimile01 = fbLn.VendDesc;
                                        fbLn.VendDesc = string.Empty;
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Invoice invoice in invBat.Invoices)
                            {
                                foreach (FrghtBl frghtBl in invoice.FrghtBls)
                                {
                                    foreach (FbLn fbLn in frghtBl.LineItems)
                                    {
                                        fbLn.Facsimile01 = dtFBLn.Select(string.Format("FbId = '{0}' AND LineItemNum = '{1}'", fbLn.FbId, fbLn.LineItemNum.ToString()))[0]["Facsimile01"].ToString();
                                        fbLn.T001 = dtFBLn.Select(string.Format("FbId = '{0}' AND LineItemNum = '{1}'", fbLn.FbId, fbLn.LineItemNum.ToString()))[0]["T001"].ToString();
                                        fbLn.T002 = dtFBLn.Select(string.Format("FbId = '{0}' AND LineItemNum = '{1}'", fbLn.FbId, fbLn.LineItemNum.ToString()))[0]["T002"].ToString();
                                        fbLn.T003 = dtFBLn.Select(string.Format("FbId = '{0}' AND LineItemNum = '{1}'", fbLn.FbId, fbLn.LineItemNum.ToString()))[0]["T003"].ToString();
                                        fbLn.T004 = dtFBLn.Select(string.Format("FbId = '{0}' AND LineItemNum = '{1}'", fbLn.FbId, fbLn.LineItemNum.ToString()))[0]["T004"].ToString();
                                        fbLn.T005 = "MultipleCurrency";
                                        fbLn.VendDesc = string.Empty;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (!isMultipleCurrency)
                        {
                            foreach (Invoice invoice in invBat.Invoices)
                            {
                                foreach (FrghtBl frghtBl in invoice.FrghtBls)
                                {
                                    foreach (FbLn fbLn in frghtBl.LineItems)
                                    {
                                        fbLn.VendDesc = fbLn.Facsimile01;
                                        fbLn.Facsimile01 = string.Empty;
                                    }
                                }
                            }
                        }
                        else
                        {
                            foreach (Invoice invoice in invBat.Invoices)
                            {
                                foreach (FrghtBl frghtBl in invoice.FrghtBls)
                                {
                                    foreach (FbLn fbLn in frghtBl.LineItems)
                                    {
                                        DataRow rowFbLnRow = retval.NewRow();
                                        rowFbLnRow["FbId"] = fbLn.FbId;
                                        rowFbLnRow["LineItemNum"] = fbLn.LineItemNum;
                                        rowFbLnRow["Facsimile01"] = fbLn.Facsimile01;
                                        rowFbLnRow["T001"] = fbLn.T001;
                                        rowFbLnRow["T002"] = fbLn.T002;
                                        rowFbLnRow["T003"] = fbLn.T003;
                                        rowFbLnRow["T004"] = fbLn.T004;
                                        retval.Rows.Add(rowFbLnRow);
                                        if (fbLn.CurrencyQual == fbLn.T003)
                                            fbLn.VendDesc = fbLn.Facsimile01;
                                        else
                                            fbLn.VendDesc = fbLn.Facsimile01 + " ;RATE: " + fbLn.T001 + " ;AMOUNT: " + fbLn.T002 + " ;CUR: " + fbLn.T003 + " ;ORIGINAL ITEM: " + fbLn.T004;
                                        fbLn.Facsimile01 = string.Empty;
                                        fbLn.T001 = string.Empty;
                                        fbLn.T002 = string.Empty;
                                        fbLn.T003 = string.Empty;
                                        fbLn.T004 = string.Empty;
                                        fbLn.T005 = string.Empty;
                                    }
                                }
                            }
                        }
                    }
                    dalTrax.PersistToFile(filename, invBat);

                }
                catch
                { }
                finally
                { }
            }
            return retval;
        }

        [WebMethod]
        public void auditTrailBatch(string BatCtrlNum, string descriptionID, string systemUserName)
        {
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                BatchAuditTrailInsert(BatCtrlNum, descriptionID, dal, systemUserName);
                dal.CommitTransaction();
            }
            catch (Exception error)
            {
                dal.RollBackTransaction();
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }
        }

        /*
        private void QAValidationInsert(string batCtrlNum, string ownerKey, string vendSCAC, decimal invoiceAccuracy, decimal fbAccuracy, bool fbValidated ,string mistakeDescription, string qa, string deOperator)
        {
            string queryInsert = @"INSERT INTO QAValidation
                                       (Bat_Ctrl_Num
                                       ,Owner_Key
                                       ,Vend_SCAC
                                       ,InvoiceAccuracy
                                       ,FreightBillAccuracy
                                       ,FreightBillValidated
                                       ,MistakeDescription
                                       ,ProcessedDate
                                       ,QA
                                       ,Operator
                                       ,f_ProcessedDate)
                                 VALUES
                                       (@Bat_Ctrl_Num
                                       ,@Owner_Key
                                       ,@Vend_SCAC
                                       ,@InvoiceAccuracy
                                       ,@FreightBillAccuracy
                                       ,@FreightBillValidated
                                       ,@MistakeDescription
                                       ,GETUTCDATE()
                                       ,@QA
                                       ,@Operator
                                       ,1)";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();

                ParameterInfo[] param = new ParameterInfo[9];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                param[1] = new ParameterInfo("@Owner_Key", ownerKey);
                param[2] = new ParameterInfo("@Vend_SCAC", vendSCAC);
                param[3] = new ParameterInfo("@InvoiceAccuracy", invoiceAccuracy);
                param[4] = new ParameterInfo("@FreightBillAccuracy", fbAccuracy);
                param[5] = new ParameterInfo("@FreightBillValidated", fbValidated);
                param[6] = new ParameterInfo("@MistakeDescription", mistakeDescription);
                param[7] = new ParameterInfo("@QA", qa);
                param[8] = new ParameterInfo("@Operator", deOperator);
                dal.ExecuteNonQuery(queryInsert, CommandType.Text, param);
                dal.CommitTransaction();
            }
            catch (Exception error)
            {
                dal.RollBackTransaction();
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }
        }
        */
        private void insertGlobalDB(DALHelper dal, DataSet dsBatch)
        {
            int affectedRows = 0;
            try
            {
                #region TR_BAT
                ParameterInfo[] paramTR_BAT;
                foreach (DataRow dr in dsBatch.Tables["TRBat"].Rows)
                {
                    paramTR_BAT = new ParameterInfo[dsBatch.Tables["TRBat"].Columns.Count];
                    paramTR_BAT = this.GetParameters(dr);
                    affectedRows = dal.ExecuteNonQuery(insertQueryTR_BAT, CommandType.Text, paramTR_BAT);
                }
                #endregion
                #region INV_BAT
                ParameterInfo[] paramINV_BAT;
                foreach (DataRow dr in dsBatch.Tables["InvBat"].Rows)
                {
                    paramINV_BAT = new ParameterInfo[dsBatch.Tables["InvBat"].Columns.Count];
                    paramINV_BAT = this.GetParameters(dr);
                    affectedRows = dal.ExecuteNonQuery(insertQueryINV_BAT, CommandType.Text, paramINV_BAT);
                }
                #endregion
                #region INVOICE
                ParameterInfo[] paramINVOICE;
                foreach (DataRow dr in dsBatch.Tables["Invoice"].Rows)
                {
                    paramINVOICE = new ParameterInfo[dsBatch.Tables["Invoice"].Columns.Count];
                    paramINVOICE = this.GetParameters(dr);
                    affectedRows = dal.ExecuteNonQuery(insertQueryINVOICE, CommandType.Text, paramINVOICE);
                }
                #endregion
                #region FRGHT_BL
                ParameterInfo[] paramFRGHT_BL;
                foreach (DataRow dr in dsBatch.Tables["FB"].Rows)
                {
                    paramFRGHT_BL = new ParameterInfo[dsBatch.Tables["FB"].Columns.Count];
                    paramFRGHT_BL = this.GetParametersNoSpecialChar(dr);
                    affectedRows = dal.ExecuteNonQuery(insertQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);
                }
                #endregion
                #region FB_LN
                ParameterInfo[] paramFB_LN;
                foreach (DataRow dr in dsBatch.Tables["FBLn"].Rows)
                {
                    paramFB_LN = new ParameterInfo[dsBatch.Tables["FBLn"].Columns.Count];
                    paramFB_LN = this.GetParametersNoSpecialChar(dr);
                    affectedRows = dal.ExecuteNonQuery(insertQueryFB_LN, CommandType.Text, paramFB_LN);
                }
                #endregion
                #region FB_FXI
                ParameterInfo[] paramFB_FXI;
                foreach (DataRow dr in dsBatch.Tables["FXI"].Rows)
                {
                    paramFB_FXI = new ParameterInfo[dsBatch.Tables["FXI"].Columns.Count];
                    paramFB_FXI = this.GetParametersNoSpecialChar(dr);
                    affectedRows = dal.ExecuteNonQuery(insertQueryFXI, CommandType.Text, paramFB_FXI);
                }
                #endregion
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private DataSet selectBatch(string MXXDatabase)
        {
            DataSet retval = new DataSet();
            DataSet dsInvBat = new DataSet("InvBat");
            DataSet dsInvoice = new DataSet("Invoice");
            DataSet dsFB = new DataSet("FB");
            DataSet dsFBLn = new DataSet("FBLn");
            DataSet dsFXI = new DataSet("FXI");
            DataSet dsTRBat = new DataSet("TRBat");
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", @"QA\MXX" + MXXDatabase.Trim() + ".mdb");

            try
            {
                dalMXXDatabase.OpenDB();
                dsInvBat = dalMXXDatabase.ExecuteDataSet("SELECT * FROM batmdb_INV_BAT", CommandType.Text);
                dsInvoice = dalMXXDatabase.ExecuteDataSet("SELECT * FROM batmdb_INVOICE ORDER BY INV_ID", CommandType.Text);
                dsFB = dalMXXDatabase.ExecuteDataSet("SELECT * FROM batmdb_FRGHT_BL ORDER BY FB_ID", CommandType.Text);
                dsFBLn = dalMXXDatabase.ExecuteDataSet("SELECT * FROM batmdb_FB_LN ORDER BY FB_ID,LINE_ITEM_NUM", CommandType.Text);
                dsFXI = dalMXXDatabase.ExecuteDataSet("SELECT * FROM batmdb_FXI", CommandType.Text);
                dsTRBat = dalMXXDatabase.ExecuteDataSet("SELECT * FROM TR_BAT", CommandType.Text);

                dsInvBat.Tables[0].TableName = "InvBat";
                dsInvoice.Tables[0].TableName = "Invoice";
                dsFB.Tables[0].TableName = "FB";
                dsFBLn.Tables[0].TableName = "FBLn";
                dsFXI.Tables[0].TableName = "FXI";
                dsTRBat.Tables[0].TableName = "TRBat";

                retval.Tables.Add(dsInvBat.Tables[0].Copy());
                retval.Tables[0].AcceptChanges();
                retval.Tables.Add(dsInvoice.Tables[0].Copy());
                retval.Tables[1].AcceptChanges();
                retval.Tables.Add(dsFB.Tables[0].Copy());
                retval.Tables[2].AcceptChanges();
                retval.Tables.Add(dsFBLn.Tables[0].Copy());
                retval.Tables[3].AcceptChanges();
                retval.Tables.Add(dsFXI.Tables[0].Copy());
                retval.Tables[4].AcceptChanges();
                retval.Tables.Add(dsTRBat.Tables[0].Copy());
                retval.Tables[5].AcceptChanges();
            }
            catch
            {
                retval = null;
            }
            finally
            {
                dalMXXDatabase.CloseDB();
            }

            return retval;
        }

        private bool checkAllCombined(DataTable dt, out string splitBatches)
        {
            bool retval = true;
            bool isFirst = true;
            splitBatches = "WHERE Bat_Ctrl_Num IN (";
            foreach (DataRow row in dt.Rows)
            {
                if (row["DEStatus"].ToString().Trim() != "COMBINED")
                {
                    retval = false;
                }
                if (isFirst)
                {
                    splitBatches = splitBatches + "'" + row["Bat_Ctrl_Num_Split"].ToString() + "'";
                    isFirst = false;
                }
                else
                    splitBatches = splitBatches + ",'" + row["Bat_Ctrl_Num_Split"].ToString() + "'";
            }
            splitBatches = splitBatches + ")";
            return retval;
        }

        private void makeMDBCopy(string batchNumber)
        {
            string filePath = ConfigurationManager.AppSettings["MDBSourcePath"] + "batchxxx";
            string newfile = ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batchNumber + ".mdb";
            try
            {
                if (File.Exists(newfile))
                    File.Delete(newfile);
                File.Copy(filePath, newfile);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void createCombinedMDB(DataTable dt, string userInitials)
        {
            BatchEntryBL bl = new BatchEntryBL();
            DataSet dsBatch = new DataSet();
            DataSet splitBatch = new DataSet();
            string rootBatch = dt.Rows[0]["Bat_Ctrl_Num_Root"].ToString();
            string ownerKey = string.Empty;
            string FBCount = string.Empty;
            string invbatID = string.Empty;
            string invID = string.Empty;
            string fbID = string.Empty;
            bool isFirst = true;
            int pageCount = 0;
            DataRow rowInvBat;
            DataRow rowInvoice;
            DataRow rowFrghtBl;
            DataRow rowFBLn;
            DataRow rowFXI;
            decimal FBTotal = 0;
            try
            {
                makeMDBCopy(rootBatch);
                dsBatch = bl.selectBatch(rootBatch);
                foreach (DataRow rowSplit in dt.Rows)
                {
                    splitBatch = bl.selectQABatch(rowSplit["Bat_Ctrl_Num_Split"].ToString());
                    if (isFirst)//check the 
                    {
                        ownerKey = splitBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString().Trim();
                        bl.insertTRBat(ownerKey, "MXX" + rootBatch.Trim(), userInitials);//insert TRBat                        
                        invbatID = "BACH" + ownerKey.Remove(3, 1) + "MXX" + rootBatch + (0).ToString().PadLeft(4, '0');
                        invID = "INVC" + ownerKey.Remove(3, 1) + "MXX" + rootBatch + (1).ToString().PadLeft(4, '0');
                        //insert InvBat
                        rowInvBat = dsBatch.Tables["InvBat"].NewRow();
                        rowInvBat["BatId"] = invbatID;
                        rowInvBat["OwnerKey"] = ownerKey;
                        rowInvBat["VendBatKey"] = "MXX" + rootBatch;
                        rowInvBat["VendBatDtm"] = DateTime.Now;
                        rowInvBat["VendLabl"] = splitBatch.Tables["InvBat"].Rows[0]["VendLabl"];
                        rowInvBat["VendFeed"] = "MXX" + rootBatch;
                        rowInvBat["BatKey"] = "MXX" + rootBatch;
                        rowInvBat["BatCreatDtm"] = DateTime.Now;
                        rowInvBat["BatLocIdRemit"] = splitBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"];
                        rowInvBat["BatCurrencyQual"] = splitBatch.Tables["InvBat"].Rows[0]["BatCurrencyQual"];
                        dsBatch.Tables["InvBat"].Rows.InsertAt(rowInvBat, 0);// Add(rowInvBat);

                        //insert Invoice
                        rowInvoice = dsBatch.Tables["Invoice"].NewRow();
                        foreach (DataColumn dc in dsBatch.Tables["Invoice"].Columns)
                        {
                            if (dc.ColumnName == "BatId")
                                rowInvoice[dc.ColumnName] = invbatID;
                            else if (dc.ColumnName == "InvId")
                                rowInvoice[dc.ColumnName] = invID;
                            else
                                rowInvoice[dc.ColumnName] = splitBatch.Tables["Invoice"].Rows[0][dc.ColumnName];
                        }
                        dsBatch.Tables["Invoice"].Rows.Add(rowInvoice);
                        isFirst = false;
                    }
                    //Update Invoice                    
                    foreach (DataColumn dc in dsBatch.Tables["Invoice"].Columns)
                    {
                        if (dc.ColumnName != "BatId" && dc.ColumnName != "InvId")
                            if (dsBatch.Tables["Invoice"].Rows[0][dc.ColumnName] != null && dsBatch.Tables["Invoice"].Rows[0][dc.ColumnName].ToString().Trim() != string.Empty)
                            {
                                dsBatch.Tables["Invoice"].Rows[0][dc.ColumnName] = splitBatch.Tables["Invoice"].Rows[0][dc.ColumnName];
                            }
                    }
                    //insert FrghtBl
                    foreach (DataRow fbRow in splitBatch.Tables["FB"].Rows)
                    {
                        FBCount = dsBatch.Tables["FB"].DefaultView.Count == 0 ? (1).ToString().PadLeft(4, '0') : (Convert.ToInt16(dsBatch.Tables["FB"].DefaultView.Table.Select("", "FbId DESC")[0]["FbId"].ToString().Substring(19, 4)) + 1).ToString().PadLeft(4, '0');
                        fbID = "FBLL" + ownerKey.Remove(3, 1) + "MXX" + rootBatch + FBCount;
                        rowFrghtBl = dsBatch.Tables["FB"].NewRow();
                        foreach (DataColumn dc in dsBatch.Tables["FB"].Columns)
                        {
                            if (dc.ColumnName == "FbId")
                                rowFrghtBl[dc.ColumnName] = fbID;
                            else if (dc.ColumnName == "InvId")
                                rowFrghtBl[dc.ColumnName] = invID;
                            else if (dc.ColumnName == "FbAmt")
                            {
                                rowFrghtBl[dc.ColumnName] = fbRow[dc.ColumnName];
                                FBTotal = FBTotal + Convert.ToDecimal(fbRow[dc.ColumnName]);
                            }
                            else if (dc.ColumnName == "T002")
                            {
                                try
                                {
                                    rowFrghtBl[dc.ColumnName] = Convert.ToInt32(fbRow[dc.ColumnName]) + pageCount;
                                }
                                catch
                                {
                                    rowFrghtBl[dc.ColumnName] = DBNull.Value;
                                }
                            }
                            else
                                rowFrghtBl[dc.ColumnName] = fbRow[dc.ColumnName];
                        }
                        dsBatch.Tables["FB"].Rows.Add(rowFrghtBl);
                        #region FBLn Update
                        foreach (DataRow fbLnRow in splitBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", fbRow["FbId"].ToString().Trim())))
                        {
                            rowFBLn = dsBatch.Tables["FBLn"].NewRow();
                            foreach (DataColumn dc in dsBatch.Tables["FBLn"].Columns)
                            {
                                if (dc.ColumnName == "FbId")
                                    rowFBLn[dc.ColumnName] = fbID;
                                else
                                    rowFBLn[dc.ColumnName] = fbLnRow[dc.ColumnName];
                            }
                            dsBatch.Tables["FBLn"].Rows.Add(rowFBLn);
                        }
                        #endregion
                        #region FXI Update
                        foreach (DataRow fxiRow in splitBatch.Tables["FXI"].Select(string.Format("FbId = '{0}'", fbRow["FbId"].ToString().Trim())))
                        {
                            rowFXI = dsBatch.Tables["FXI"].NewRow();
                            foreach (DataColumn dc in dsBatch.Tables["FXI"].Columns)
                            {
                                if (dc.ColumnName == "FbId")
                                    rowFXI[dc.ColumnName] = fbID;
                                else if (dc.ColumnName == "BatId")
                                    rowFXI[dc.ColumnName] = invbatID;
                                else if (dc.ColumnName == "InvId")
                                    rowFXI[dc.ColumnName] = invID;
                                else
                                    rowFXI[dc.ColumnName] = fxiRow[dc.ColumnName];
                            }
                            dsBatch.Tables["FXI"].Rows.Add(rowFXI);
                        }
                        #endregion
                    }
                    pageCount = pageCount + Convert.ToInt32(dal.ExecuteDataSet(string.Format("SELECT TOP 1 BatchImageCount-1 FROM BatchPageCounter WHERE Bat_Ctrl_Num = '{0}' ORDER BY BatchPageCounterID DESC", rowSplit["Bat_Ctrl_Num_Split"].ToString()), CommandType.Text).Tables[0].Rows[0][0]);
                }
                foreach (DataRow row in dsBatch.Tables["FB"].Rows)
                {
                    row.BeginEdit();
                    row["LocIdBlng"] = dsBatch.Tables["Invoice"].Rows[0]["LocIdBlng"].ToString();
                    row["AcctNumVendBlng"] = dsBatch.Tables["Invoice"].Rows[0]["AcctNumVendBlng"].ToString();
                    row.EndEdit();
                }
                dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = dsBatch.Tables["Invoice"].Rows[0]["LocIdRemit"];
                dsBatch.Tables["Invoice"].Rows[0]["InvAmt"] = FBTotal;
                bl.saveBatch(dsBatch, rootBatch, ownerKey);
            }
            catch
            {
                throw new Exception("Error during MDB Creation.");
            }
        }

        [WebMethod]
        public DataSet selectQAConfig(string Owner_Key, string Vend_SCAC, string batCtrlNum)
        {
            DataSet retval = new DataSet();
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            string query1 = @"SELECT NodeName,FieldName FROM QAConfigHeader H
                            INNER JOIN QAConfigDetail D ON H.QAConfigID = D.QAConfigID
                            WHERE Owner_Key = @Owner_Key
                            AND Vend_SCAC = '*'";
            string query2 = @"SELECT NodeName,FieldName FROM QAConfigHeader H
                            INNER JOIN QAConfigDetail D ON H.QAConfigID = D.QAConfigID
                            WHERE Owner_Key = @Owner_Key
                            AND Vend_SCAC = @Vend_SCAC";
            try
            {
                dal.OpenDB();
                ParameterInfo[] param;
                param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Owner_Key", Owner_Key);
                ds1 = dal.ExecuteDataSet(query1, CommandType.Text, param);
                ds1.Tables[0].TableName = "ds1";
                param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@Owner_Key", Owner_Key);
                param[1] = new ParameterInfo("@Vend_SCAC", Vend_SCAC);
                ds2 = dal.ExecuteDataSet(query2, CommandType.Text, param);
                ds2.Tables[0].TableName = "ds2";
                retval.Tables.Add(ds1.Tables[0].Copy());
                retval.Tables[0].AcceptChanges();
                retval.Tables.Add(ds2.Tables[0].Copy());
                retval.Tables[1].AcceptChanges();

                ParameterInfo[] paramBat = new ParameterInfo[1];
                paramBat[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);//get rootbatch
                //is split batch
                if (Convert.ToInt32(dal.ExecuteScalar("SELECT COUNT(*) FROM Batch_DE_Split A INNER JOIN Batch_DE_Split B ON A.Bat_Ctrl_Num_Root = B.Bat_Ctrl_Num_Root WHERE B.Bat_Ctrl_Num_Split =  @Bat_Ctrl_Num", CommandType.Text, paramBat)) > 0)
                {
                    if (retval.Tables[1].Rows.Count > 0)
                    {
                        //delete INVOICE configuration
                        foreach (DataRow row in retval.Tables[1].Select("NodeName = 'INVOICE'"))
                        {
                            row.Delete();
                        }
                        retval.Tables[1].AcceptChanges();
                        //insert FbAmt,FbKey
                        if (retval.Tables[1].Select("NodeName = 'FRGHT_BL' AND FieldName ='FbAmt'").Count() == 0)
                        {
                            DataRow FbAmtRow = retval.Tables[1].NewRow();
                            FbAmtRow["NodeName"] = "FRGHT_BL";
                            FbAmtRow["FieldName"] = "FbAmt";
                            retval.Tables[1].Rows.Add(FbAmtRow);
                        }
                        if (retval.Tables[1].Select("NodeName = 'FRGHT_BL' AND FieldName ='FbKey'").Count() == 0)
                        {
                            DataRow FbKeyRow = retval.Tables[1].NewRow();
                            FbKeyRow["NodeName"] = "FRGHT_BL";
                            FbKeyRow["FieldName"] = "FbKey";
                            retval.Tables[1].Rows.Add(FbKeyRow);
                        }
                        retval.Tables[1].AcceptChanges();
                    }
                    else
                    {
                        if (retval.Tables[0].Rows.Count > 0)
                        {
                            //delete INVOICE configuration
                            foreach (DataRow row in retval.Tables[0].Select("NodeName = 'INVOICE'"))
                            {
                                row.Delete();
                            }
                            retval.Tables[0].AcceptChanges();
                        }
                        //insert FbAmt,FbKey
                        if (retval.Tables[0].Select("NodeName = 'FRGHT_BL' AND FieldName ='FbAmt'").Count() == 0)
                        {
                            DataRow FbAmtRow = retval.Tables[0].NewRow();
                            FbAmtRow["NodeName"] = "FRGHT_BL";
                            FbAmtRow["FieldName"] = "FbAmt";
                            retval.Tables[0].Rows.Add(FbAmtRow);
                        }
                        if (retval.Tables[0].Select("NodeName = 'FRGHT_BL' AND FieldName ='FbKey'").Count() == 0)
                        {
                            DataRow FbKeyRow = retval.Tables[0].NewRow();
                            FbKeyRow["NodeName"] = "FRGHT_BL";
                            FbKeyRow["FieldName"] = "FbKey";
                            retval.Tables[0].Rows.Add(FbKeyRow);
                        }
                        retval.Tables[0].AcceptChanges();
                    }
                }
                //is Rootbatch
                else if (Convert.ToInt32(dal.ExecuteScalar("SELECT COUNT(*) FROM Batch_DE_Split WHERE Bat_Ctrl_Num_Root =  @Bat_Ctrl_Num", CommandType.Text, paramBat)) > 0)
                {
                    if (retval.Tables[1].Rows.Count > 0)
                    {
                        //delete FRGHT_BL configuration
                        foreach (DataRow row in retval.Tables[1].Select("NodeName = 'FRGHT_BL'"))
                        {
                            row.Delete();
                        }
                        retval.Tables[1].AcceptChanges();
                        //insert InvAmt,InvKey,InvCreatDtm
                        if (retval.Tables[1].Select("NodeName = 'INVOICE' AND FieldName ='InvAmt'").Count() == 0)
                        {
                            DataRow InvAmtRow = retval.Tables[1].NewRow();
                            InvAmtRow["NodeName"] = "INVOICE";
                            InvAmtRow["FieldName"] = "InvAmt";
                            retval.Tables[1].Rows.Add(InvAmtRow);
                        }
                        if (retval.Tables[1].Select("NodeName = 'INVOICE' AND FieldName ='InvKey'").Count() == 0)
                        {
                            DataRow InvKeyRow = retval.Tables[1].NewRow();
                            InvKeyRow["NodeName"] = "INVOICE";
                            InvKeyRow["FieldName"] = "InvKey";
                            retval.Tables[1].Rows.Add(InvKeyRow);
                        }
                        if (retval.Tables[1].Select("NodeName = 'INVOICE' AND FieldName ='InvCreatDtm'").Count() == 0)
                        {
                            DataRow InvCreatDtmRow = retval.Tables[1].NewRow();
                            InvCreatDtmRow["NodeName"] = "INVOICE";
                            InvCreatDtmRow["FieldName"] = "InvCreatDtm";
                            retval.Tables[1].Rows.Add(InvCreatDtmRow);
                        }
                        if (retval.Tables[0].Select("NodeName = 'INVOICE' AND FieldName ='InvCurrencyQual'").Count() == 0)
                        {
                            DataRow InvCreatDtmRow = retval.Tables[0].NewRow();
                            InvCreatDtmRow["NodeName"] = "INVOICE";
                            InvCreatDtmRow["FieldName"] = "InvCurrencyQual";
                            retval.Tables[0].Rows.Add(InvCreatDtmRow);
                        }
                        retval.Tables[1].AcceptChanges();
                    }
                    else
                    {
                        if (retval.Tables[0].Rows.Count > 0)
                        {
                            //delete FRGHT_BL configuration
                            foreach (DataRow row in retval.Tables[0].Select("NodeName = 'FRGHT_BL'"))
                            {
                                row.Delete();
                            }
                            retval.Tables[0].AcceptChanges();
                        }
                        //insert InvAmt,InvKey,InvCreatDtm
                        if (retval.Tables[0].Select("NodeName = 'INVOICE' AND FieldName ='InvAmt'").Count() == 0)
                        {
                            DataRow InvAmtRow = retval.Tables[0].NewRow();
                            InvAmtRow["NodeName"] = "INVOICE";
                            InvAmtRow["FieldName"] = "InvAmt";
                            retval.Tables[0].Rows.Add(InvAmtRow);
                        }
                        if (retval.Tables[0].Select("NodeName = 'INVOICE' AND FieldName ='InvKey'").Count() == 0)
                        {
                            DataRow InvKeyRow = retval.Tables[0].NewRow();
                            InvKeyRow["NodeName"] = "INVOICE";
                            InvKeyRow["FieldName"] = "InvKey";
                            retval.Tables[0].Rows.Add(InvKeyRow);
                        }
                        if (retval.Tables[0].Select("NodeName = 'INVOICE' AND FieldName ='InvCreatDtm'").Count() == 0)
                        {
                            DataRow InvCreatDtmRow = retval.Tables[0].NewRow();
                            InvCreatDtmRow["NodeName"] = "INVOICE";
                            InvCreatDtmRow["FieldName"] = "InvCreatDtm";
                            retval.Tables[0].Rows.Add(InvCreatDtmRow);
                        }
                        if (retval.Tables[0].Select("NodeName = 'INVOICE' AND FieldName ='InvCurrencyQual'").Count() == 0)
                        {
                            DataRow InvCreatDtmRow = retval.Tables[0].NewRow();
                            InvCreatDtmRow["NodeName"] = "INVOICE";
                            InvCreatDtmRow["FieldName"] = "InvCurrencyQual";
                            retval.Tables[0].Rows.Add(InvCreatDtmRow);
                        }
                        retval.Tables[1].AcceptChanges();
                    }
                }
            }
            catch
            {
                retval = null;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public DataTable graphDiffQA(string MXXDatabase, string MXXOwnerKey, string MXXSCAC, string siteID)
        {
            DataTable retval = this.getTableStructureErrorData();
            DataSet dsAttempts = new DataSet();
            DataSet dsIDCounter = new DataSet();
            int affectedRows = 0;
            long IDKey;

            string queryIDCounter = string.Format(@"SELECT IDCounter,PrefixSite,PrefixType FROM SiteIDController(NOLOCK) WHERE SiteID = {0} AND IDType = 'QAVID'", ConfigurationManager.AppSettings["SiteID"]);
            string queryIDCounterUpdate = string.Format(@"UPDATE SiteIDController SET IDCounter = IDCounter+1 WHERE SiteID = {0} AND IDType = 'QAVID'", ConfigurationManager.AppSettings["SiteID"]);
            string queryInsertQAValidationNew = @"INSERT INTO QAValidationNew
                                                           (QAValidationID
                                                           ,Bat_Ctrl_Num
                                                           ,Owner_Key
                                                           ,Vend_SCAC
                                                           ,ProcessedDate
                                                           ,QA
                                                           ,f_ProcessedDate)
                                                     VALUES
                                                           (@QAValidationID
                                                           ,@Bat_Ctrl_Num
                                                           ,@Owner_Key
                                                           ,@Vend_SCAC
                                                           ,@UTCDate
                                                           ,@QA
                                                           ,@UTCDate)";
            string queryInserQAValidationDetail = @"INSERT INTO [QAValidationErrorDetails]
                                                           ([QAValidationID]
                                                           ,[ID]
                                                           ,[LineItemNum]
                                                           ,[ItemCategory]
                                                           ,[NodeName]
                                                           ,[OriginalName]
                                                           ,[FieldName]
                                                           ,[CorrectValue]
                                                           ,[KeyedValue]
                                                           ,[Accuracy])
                                                     VALUES
                                                           (@QAValidationID
                                                           ,@ID
                                                           ,@LineItemNum
                                                           ,@ItemCategory
                                                           ,@NodeName
                                                           ,@OriginalName
                                                           ,@FieldName
                                                           ,@CorrectValue
                                                           ,@KeyedValue
                                                           ,@Accuracy)";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();

                //get and update TrainerID TrainingRecord
                affectedRows = dal.ExecuteNonQuery(queryIDCounterUpdate, CommandType.Text);
                dsIDCounter = dal.ExecuteDataSet(queryIDCounter, CommandType.Text);
                IDKey = CommonMethod.createIDKey(Convert.ToInt64(dsIDCounter.Tables[0].Rows[0][0].ToString()) - 1, siteID);

                ParameterInfo[] paramQAValidationDetail = new ParameterInfo[10];
                paramQAValidationDetail[0] = new ParameterInfo("@QAValidationID", IDKey);
                retval = graphDiff(MXXDatabase);
                foreach (DataRow row in retval.Rows)
                {
                    paramQAValidationDetail[1] = new ParameterInfo("@NodeName", row["NodeName"]);
                    paramQAValidationDetail[2] = new ParameterInfo("@ID", row["ID"]);
                    paramQAValidationDetail[3] = new ParameterInfo("@LineItemNum", row["LineItemNum"]);
                    paramQAValidationDetail[4] = new ParameterInfo("@ItemCategory", row["ItemCategory"]);
                    paramQAValidationDetail[5] = new ParameterInfo("@OriginalName", DBNull.Value);
                    paramQAValidationDetail[6] = new ParameterInfo("@FieldName", row["FieldName"]);
                    paramQAValidationDetail[7] = new ParameterInfo("@CorrectValue", row["CorrectValue"]);
                    paramQAValidationDetail[8] = new ParameterInfo("@KeyedValue", row["KeyedValue"]);
                    paramQAValidationDetail[9] = new ParameterInfo("@Accuracy", row["Accuracy"]);
                    affectedRows = dal.ExecuteNonQuery(queryInserQAValidationDetail, CommandType.Text, paramQAValidationDetail);
                }

                ParameterInfo[] paramQAValidation = new ParameterInfo[6];

                paramQAValidation[0] = new ParameterInfo("@QAValidationID", IDKey);
                paramQAValidation[1] = new ParameterInfo("@Bat_Ctrl_Num", MXXDatabase);
                paramQAValidation[2] = new ParameterInfo("@Owner_Key", MXXOwnerKey);
                paramQAValidation[3] = new ParameterInfo("@Vend_SCAC", MXXSCAC);
                paramQAValidation[4] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                paramQAValidation[5] = new ParameterInfo("@QA", CommonUserLogin.getUser().UserID);

                //insert TrainingRecord                                       
                affectedRows = dal.ExecuteNonQuery(queryInsertQAValidationNew, CommandType.Text, paramQAValidation);
                dal.CommitTransaction();
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.Message, CommonEnum.FormMode.QUALITY_ASSURANCE.ToString());
                dal.RollBackTransaction();
                return null;
                throw error;
            }

            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        private DataTable graphDiff(string MXXDatabase)
        {
            BatchEntryBL bl = new BatchEntryBL();
            DataTable retval = this.getTableStructureErrorData();
            DataView dvInvBat = new DataView();
            DataView dvInvoice = new DataView();
            DataView dvFrghtBl = new DataView();
            DataView dvFXI = new DataView();
            DataView dvFBLn = new DataView();
            DataSet dsDETest = new DataSet();
            DataSet dsCorrect = new DataSet();
            DataView dvConfig = new DataView();
            DataSet dsConfig = new DataSet();
            DataRow row;
            bool isCorrect = true;
            string filenameDETest = string.Empty;
            string filenameCorrect = string.Empty;
            try
            {

                filenameDETest = ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".xml";
                filenameCorrect = ConfigurationManager.AppSettings["ObjQADestinationPath"] + MXXDatabase + ".xml";


                dsConfig = dal.ExecuteDataSet("SELECT * FROM TrainerConfig", CommandType.Text);
                dsDETest = bl.selectBatch(MXXDatabase);// selectBatchXML(MXXDatabase, filenameDETest);
                dsCorrect = bl.selectQABatch(MXXDatabase);// selectBatchXML(MXXDatabase, filenameCorrect);
                dvConfig.Table = dsConfig.Tables[0];
                #region InvBat
                dvInvBat.Table = dsDETest.Tables["InvBat"];
                foreach (DataRow dr in dsCorrect.Tables["InvBat"].Rows)
                {
                    dvInvBat.RowFilter = string.Format("BatId = '{0}'", dr["BatId"].ToString().Trim());
                    if (dvInvBat.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dvInvBat[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "INV_BAT", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["BatId"].ToString().Trim();
                                    row["LineItemNum"] = DBNull.Value;
                                    row["ItemCategory"] = DBNull.Value;
                                    row["NodeName"] = "INV_BAT";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvInvBat[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvInvBat[0][dc.ColumnName].ToString().Trim());
                                    retval.Rows.Add(row);
                                }
                            }
                        }
                    }
                    else
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["BatId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "INV_BAT";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                dvInvBat.Table = dsCorrect.Tables["InvBat"];
                foreach (DataRow dr in dsDETest.Tables["InvBat"].Rows)
                {
                    dvInvBat.RowFilter = string.Format("BatId = '{0}'", dr["BatId"].ToString().Trim());
                    if (dvInvBat.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["BatId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "INV_BAT";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                #endregion

                #region Invoice
                dvInvoice.Table = dsDETest.Tables["Invoice"];
                isCorrect = true;
                foreach (DataRow dr in dsCorrect.Tables["Invoice"].Rows)
                {
                    dvInvoice.RowFilter = string.Format("InvId = '{0}'", dr["InvId"].ToString().Trim());
                    if (dvInvoice.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dc.DataType == System.Type.GetType("System.Decimal"))
                            {
                                if (dvInvoice[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && Convert.ToDecimal(dvInvoice[0][dc.ColumnName]) != Convert.ToDecimal(dr[dc.ColumnName]))
                                    isCorrect = false;
                                else if ((dvInvoice[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvInvoice[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }
                            else
                            {
                                if (dvInvoice[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && dvInvoice[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                                    isCorrect = false;
                                else if ((dvInvoice[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvInvoice[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }

                            if (!isCorrect)
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "INVOICE", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["InvId"].ToString().Trim();
                                    row["LineItemNum"] = DBNull.Value;
                                    row["ItemCategory"] = DBNull.Value;
                                    row["NodeName"] = "INVOICE";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvInvoice[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvInvoice[0][dc.ColumnName].ToString().Trim());
                                    retval.Rows.Add(row);
                                }
                                isCorrect = true;
                            }
                        }
                    }
                    else
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["InvId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "INVOICE";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }

                dvInvoice.Table = dsCorrect.Tables["Invoice"];
                foreach (DataRow dr in dsDETest.Tables["Invoice"].Rows)
                {
                    dvInvoice.RowFilter = string.Format("InvId = '{0}'", dr["InvId"].ToString().Trim());
                    if (dvInvoice.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["InvId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "INVOICE";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                #endregion

                #region FrghtBl
                dvFrghtBl.Table = dsDETest.Tables["FB"];
                isCorrect = true;
                foreach (DataRow dr in dsCorrect.Tables["FB"].Rows)
                {
                    dvFrghtBl.RowFilter = string.Format("FbId = '{0}'", dr["FbId"].ToString().Trim());
                    if (dvFrghtBl.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dc.DataType == System.Type.GetType("System.Decimal"))
                            {
                                if (dvFrghtBl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && Convert.ToDecimal(dvFrghtBl[0][dc.ColumnName]) != Convert.ToDecimal(dr[dc.ColumnName]))
                                    isCorrect = false;
                                else if ((dvFrghtBl[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvFrghtBl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }
                            else
                            {
                                if (dvFrghtBl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && dvFrghtBl[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                                    isCorrect = false;
                                else if ((dvFrghtBl[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvFrghtBl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }
                            if (!isCorrect)
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "FRGHT_BL", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["FbId"].ToString().Trim();
                                    row["LineItemNum"] = DBNull.Value;
                                    row["ItemCategory"] = DBNull.Value;
                                    row["NodeName"] = "FRGHT_BL";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvFrghtBl[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvFrghtBl[0][dc.ColumnName].ToString().Trim());
                                    retval.Rows.Add(row);
                                }
                                isCorrect = true;
                            }
                        }
                    }
                    else
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "FRGHT_BL";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }

                dvFrghtBl.Table = dsCorrect.Tables["FB"];
                foreach (DataRow dr in dsDETest.Tables["FB"].Rows)
                {
                    dvFrghtBl.RowFilter = string.Format("FbId = '{0}'", dr["FbId"].ToString().Trim());
                    if (dvFrghtBl.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "FRGHT_BL";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                #endregion

                #region FXI
                dvFXI.Table = dsDETest.Tables["FXI"];
                isCorrect = true;
                foreach (DataRow dr in dsCorrect.Tables["FXI"].Rows)
                {
                    dvFXI.RowFilter = string.Format("FbId = '{0}' ", dr["FbId"].ToString().Trim());
                    if (dvFXI.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dc.DataType == System.Type.GetType("System.Decimal"))
                            {
                                if (dvFXI[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && Convert.ToDecimal(dvFXI[0][dc.ColumnName]) != Convert.ToDecimal(dr[dc.ColumnName]))
                                    isCorrect = false;
                                else if ((dvFXI[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvFXI[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }
                            else
                            {
                                if (dvFXI[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                                    isCorrect = false;
                            }

                            if (!isCorrect)
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "FXI", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["FbId"].ToString().Trim();
                                    row["LineItemNum"] = DBNull.Value;
                                    row["ItemCategory"] = DBNull.Value;
                                    row["NodeName"] = "FXI";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvFXI[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvFXI[0][dc.ColumnName].ToString().Trim());
                                    retval.Rows.Add(row);
                                }
                                isCorrect = true;
                            }
                        }
                    }
                    else
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "FXI";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                dvFXI.Table = dsCorrect.Tables["FXI"];
                foreach (DataRow dr in dsDETest.Tables["FXI"].Rows)
                {
                    dvFXI.RowFilter = string.Format("FbId = '{0}'", dr["FbId"].ToString().Trim());
                    if (dvFXI.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = DBNull.Value;
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "FXI";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                #endregion

                #region FBLn
                dvFBLn.Table = dsDETest.Tables["FBLn"];
                isCorrect = true;
                foreach (DataRow dr in dsCorrect.Tables["FBLn"].Rows)
                {
                    dvFBLn.RowFilter = string.Format("FbId = '{0}' AND LineItemNum = '{1}'", dr["FbId"].ToString().Trim(), dr["LineItemNum"].ToString().Trim());
                    if (dvFBLn.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dc.DataType == System.Type.GetType("System.Decimal"))
                            {
                                if (dvFBLn[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && Convert.ToDecimal(dvFBLn[0][dc.ColumnName]) != Convert.ToDecimal(dr[dc.ColumnName]))
                                    isCorrect = false;
                                else if ((dvFBLn[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvFBLn[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }
                            else
                            {
                                if (dvFBLn[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                                    isCorrect = false;
                            }

                            if (!isCorrect)
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "FB_LN", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["FbId"].ToString().Trim();
                                    row["LineItemNum"] = dr["LineItemNum"].ToString().Trim();
                                    row["ItemCategory"] = DBNull.Value;
                                    row["NodeName"] = "FB_LN";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvFBLn[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvFBLn[0][dc.ColumnName].ToString().Trim());
                                    retval.Rows.Add(row);
                                }
                                isCorrect = true;
                            }
                        }
                    }
                    else
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["LineItemNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "FB_LN";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                dvFBLn.Table = dsCorrect.Tables["FBLn"];
                foreach (DataRow dr in dsDETest.Tables["FBLn"].Rows)
                {
                    dvFBLn.RowFilter = string.Format("FbId = '{0}' AND LineItemNum = '{1}'", dr["FbId"].ToString().Trim(), dr["LineItemNum"].ToString().Trim());
                    if (dvFBLn.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["LineItemNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "FB_LN";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                #endregion
            }
            catch (Exception e)
            {
                throw e;
            }
            return retval;
        }

        private DataTable getTableStructureErrorData()
        {
            DataTable retval = new DataTable("ErrorDetail");
            retval.Columns.Add("ID");
            retval.Columns.Add("LineItemNum");
            retval.Columns.Add("ItemCategory");
            retval.Columns.Add("NodeName");
            retval.Columns.Add("OriginalName");
            retval.Columns.Add("FieldName");
            retval.Columns.Add("CorrectValue");
            retval.Columns.Add("KeyedValue");
            retval.Columns.Add("Accuracy");
            return retval;
        }

        private decimal computeDifference(string correctString, string keyedString)
        {
            decimal retval = 0;
            int CorrectCount = correctString.Length;
            int WrongCount = 0;
            int ctr = 0;

            for (ctr = 0; ctr < correctString.Length; ctr++)
            {
                try
                {
                    if (correctString[ctr] != keyedString[ctr])//if different
                    {
                        WrongCount = WrongCount + 1;
                    }
                }
                catch
                {
                    WrongCount = WrongCount + 1;
                }
            }
            if (correctString.Length < keyedString.Length)
            {
                WrongCount = WrongCount + (keyedString.Length - correctString.Length);
            }
            if (CorrectCount == 0)
                retval = 0;
            else
                retval = (Convert.ToDecimal(CorrectCount - WrongCount) / Convert.ToDecimal(CorrectCount)) * 100;
            return retval;

        }

        private void archiveMDBFile(string batCtrlNum, DALHelper dal)
        {
            string folderDate = string.Empty;
            string archiveDEFolderPath = string.Empty;
            string archiveQAFolderPath = string.Empty;
            try
            {
                //getserverdate
                folderDate = this.GetServerDate(dal).ToString("yyyyMMdd");
                archiveDEFolderPath = ConfigurationManager.AppSettings["MDBArchivePath"] + folderDate + @"\DE\";
                archiveQAFolderPath = ConfigurationManager.AppSettings["MDBArchivePath"] + folderDate + @"\QA\";
                if (!Directory.Exists(archiveDEFolderPath))
                    Directory.CreateDirectory(archiveDEFolderPath);
                if (!Directory.Exists(archiveQAFolderPath))
                    Directory.CreateDirectory(archiveQAFolderPath);

                moveFile(ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batCtrlNum + ".mdb", archiveDEFolderPath + "MXX" + batCtrlNum + ".mdb");
                moveFile(ConfigurationManager.AppSettings["MDBDestinationPath"] + @"QA\MXX" + batCtrlNum + ".mdb", archiveQAFolderPath + "MXX" + batCtrlNum + ".mdb");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void moveFile(string fileFrom, string fileTo)
        {
            string folder = string.Empty;
            bool moveTry = true;
            bool moveSuccessful = false;
            string errorMessage = string.Empty;
            int counter = 0;

            while (moveTry)
            {
                try
                {
                    counter = counter + 1;
                    File.Move(fileFrom, fileTo);
                    moveTry = false;
                    moveSuccessful = true;
                }
                catch (Exception e)
                {
                    if (counter == 3)
                    {
                        moveTry = false;
                        errorMessage = e.Message;
                    }
                    else
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        Thread.Sleep(1000);
                    }
                }
                finally
                {
                }
            }
            if (!moveSuccessful)
            {
                throw new Exception(errorMessage);
            }
        }

        [WebMethod]
        public DataSet populatePageCount(DataSet dsBatch, string batCtrlNum)
        {
            try
            {
                int fbPageCount = 0;
                int lastPage = 0;
                int lastInvPage = 0;
                int fbPageNum = 0;
                int invPageCount = 0;
                string InvIDCurrent = string.Empty;
                string InvIDPrevious = string.Empty;
                DataSet dsTotalPageCount = new DataSet();
                DataTable temp = dsBatch.Tables["FB"].Clone();
                temp.Columns["T002"].DataType = Type.GetType("System.Int32");
                foreach (DataRow dr in dsBatch.Tables["FB"].Rows)
                {
                    temp.ImportRow(dr);
                }
                temp.AcceptChanges();
                dal.OpenDB();
                dsTotalPageCount = dal.ExecuteDataSet(string.Format(@"SELECT bpc.BatchImageCount FROM BatchPageCounter(NOLOCK) bpc
                                                                      INNER JOIN Batch_DE de on bpc.BatchID = de.BatchID
                                                                      WHERE de.Bat_Ctrl_Num =  '{0}' ", batCtrlNum), CommandType.Text);
                if (dsTotalPageCount.Tables[0].Rows.Count > 0 && dsTotalPageCount.Tables[0].Rows[0]["BatchImageCount"].ToString() != string.Empty)
                {
                    lastPage = Convert.ToInt16(dsTotalPageCount.Tables[0].Rows[0]["BatchImageCount"]) + 1;
                    lastInvPage = lastPage;
                    foreach (DataRow row in temp.Select("", "T002 DESC, InvId DESC"))
                    {
                        fbPageNum = Convert.ToInt16(row["T002"]);
                        fbPageCount = lastPage - fbPageNum;
                        fbPageCount = fbPageCount > 0 ? fbPageCount : 1;
                        dsBatch.Tables["FB"].Select(string.Format("FbId = '{0}'", row["FbId"].ToString()))[0]["T004"] = fbPageCount;//row["T004"] = fbPageCount;
                        //populate invoice page 
                        if (InvIDCurrent != row["InvId"].ToString())
                        {
                            InvIDCurrent = row["InvId"].ToString();
                            if (InvIDPrevious != string.Empty)
                            {
                                invPageCount = lastInvPage - lastPage;
                                foreach (DataRow dr in dsBatch.Tables["FB"].Select(string.Format("InvId = '{0}'", InvIDPrevious)))
                                {
                                    dr["T003"] = invPageCount > 0 ? invPageCount : 1;
                                }

                                invPageCount = 0;
                                lastInvPage = lastPage;
                            }
                            InvIDPrevious = InvIDCurrent;
                        }
                        lastPage = fbPageNum;
                    }
                    invPageCount = lastInvPage - fbPageNum;
                    foreach (DataRow dr in dsBatch.Tables["FB"].Select(string.Format("InvId = '{0}'", InvIDCurrent)))
                    {
                        dr["T003"] = invPageCount > 0 ? invPageCount : 1;
                    }
                }
                else
                {
                    throw new Exception("No total batch page count");
                }
                return dsBatch;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
        }
    }
}
