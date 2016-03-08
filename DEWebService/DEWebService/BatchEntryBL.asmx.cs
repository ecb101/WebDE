using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.IO;
using System.Configuration;
using DAL;
using Trax.FPS;
using Filex.MSharp.Lib.Common;
using CommonLibrary;
namespace DEWebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BatchEntryBL : BaseBLogic
    {

        protected DALHelperOleDB dalMXXDatabase;

        private string selectQueryINV_BAT;
        private string insertQueryINV_BAT;
        private string updateQueryINV_BAT;
        private string deleteQueryINV_BAT;

        private string selectQueryINVOICE;
        private string insertQueryINVOICE;
        private string updateQueryINVOICE;
        private string deleteQueryINVOICE;

        private string selectQueryFRGHT_BL;
        private string insertQueryFRGHT_BL;
        private string updateQueryFRGHT_BL;
        private string deleteQueryFRGHT_BL;

        private string selectQueryFB_LN;
        private string insertQueryFB_LN;
        private string updateQueryFB_LN;
        private string deleteQueryFB_LN;

        private string selectQueryFXI;
        private string insertQueryFXI;
        private string updateQueryFXI;
        private string deleteQueryFXI;

        public BatchEntryBL()
        {
            
        }
        public override void setQueries()
        {
            #region INV_BAT
            selectQueryINV_BAT = @"SELECT
                                    BAT_ID AS BatId,
                                    OWNER_KEY AS OwnerKey,
                                    VEND_BAT_KEY AS VendBatKey,
                                    VEND_BAT_DTM AS VendBatDtm,
                                    VEND_LABL AS VendLabl,
                                    VEND_FEED AS VendFeed,
                                    BAT_KEY AS BatKey,
                                    BAT_CREAT_DTM AS BatCreatDtm,
                                    BAT_INV_CNT AS BatInvCnt,
                                    BAT_FB_CNT AS BatFbCnt,
                                    BAT_AMT AS BatAmt,
                                    BAT_CURRENCY_QUAL AS BatCurrencyQual,
                                    BAT_LOC_ID_REMIT AS BatLocIdRemit,
                                    BAT_STAT AS BatStat,
                                    BAT_TYPE AS BatType
                                FROM batmdb_INV_BAT";

            insertQueryINV_BAT = @"INSERT INTO batmdb_INV_BAT
                                                            (BAT_ID
                                                            ,OWNER_KEY
                                                            ,VEND_BAT_KEY
                                                            ,VEND_BAT_DTM
                                                            ,VEND_LABL
                                                            ,VEND_FEED
                                                            ,BAT_KEY
                                                            ,BAT_CREAT_DTM
                                                            ,BAT_INV_CNT
                                                            ,BAT_FB_CNT
                                                            ,BAT_AMT
                                                            ,BAT_CURRENCY_QUAL
                                                            ,BAT_LOC_ID_REMIT
                                                            ,BAT_STAT
                                                            ,BAT_TYPE
                                                            ,BAT_APP_AMT
                                                            ,BAT_ADJM_AMT
                                                            ,BAT_PD_AMT
                                                            ,BAT_ADJM_CNT
                                                            ,BAT_PAYMT_CNT
                                                            ,BAT_CREDIT_AMT
                                                            ,BAT_DISPUTE_AMT
                                                            ,BAT_OPEN_AMT)
                                                    VALUES
                                                            (@BatId
                                                            ,@OwnerKey
                                                            ,@VendBatKey
                                                            ,@VendBatDtm
                                                            ,@VendLabl
                                                            ,@VendFeed
                                                            ,@BatKey
                                                            ,@BatCreatDtm
                                                            ,@BatInvCnt
                                                            ,@BatFbCnt
                                                            ,@BatAmt
                                                            ,@BatCurrencyQual
                                                            ,@BatLocIdRemit
                                                            ,'Open'
                                                            ,'Manual'
                                                            ,0
                                                            ,0
                                                            ,0
                                                            ,0
                                                            ,0
                                                            ,0
                                                            ,0
                                                            ,0)";


            updateQueryINV_BAT = @"UPDATE batmdb_INV_BAT
                                   SET
                                    BAT_ID = @BatIdNew
                                    ,OWNER_KEY = @OwnerKey
                                    ,VEND_BAT_KEY = @VendBatKey
                                    ,VEND_BAT_DTM = @VendBatDtm
                                    ,VEND_LABL = @VendLabl
                                    ,VEND_FEED = @VendFeed
                                    ,BAT_KEY = @BatKey
                                    ,BAT_CREAT_DTM = @BatCreatDtm
                                    ,BAT_INV_CNT = @BatInvCnt
                                    ,BAT_FB_CNT = @BatFbCnt
                                    ,BAT_AMT = @BatAmt
                                    ,BAT_CURRENCY_QUAL = @BatCurrencyQual
                                    ,BAT_LOC_ID_REMIT = @BatLocIdRemit
                                    ,BAT_STAT = @BatStat
                                    ,BAT_TYPE = @BatType
                                 WHERE BAT_ID = @BatId";
            deleteQueryINV_BAT = @"DELETE FROM batmdb_INV_BAT WHERE BAT_ID = @BatId";
            #endregion
            #region INVOICE
            selectQueryINVOICE = @"SELECT 
                                INV_ID AS InvId,
                                VEND_LABL AS VendLabl,
                                LOC_ID_REMIT AS LocIdRemit,
                                INV_KEY AS InvKey,
                                INV_CURRENCY_QUAL AS InvCurrencyQual,
                                VEND_INV_AMT AS VendInvAmt,
                                ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
                                AL_REMIT_1 AS AlRemit1,
                                AL_REMIT_2 AS AlRemit2,
                                AL_REMIT_3 AS AlRemit3,
                                AL_REMIT_4 AS AlRemit4,
                                AL_CITY_REMIT AS AlCityRemit,
                                AL_STATE_PROV_REMIT AS AlStateProvRemit,
                                AL_POST_CODE_REMIT AS AlPostCodeRemit,
                                AL_CNTRY_CODE_REMIT AS AlCntryCodeRemit,
                                INV_FB_CNT AS InvFbCnt,
                                INV_AMT AS InvAmt,
                                INV_STAT AS InvStat,
                                INV_CREAT_DTM AS InvCreatDtm,
                                LOC_ID_BLNG AS LocIdBlng,
                                AL_BLNG_1 AS AlBlng1,
                                AL_BLNG_2 AS AlBlng2,
                                AL_BLNG_3 AS AlBlng3,
                                AL_BLNG_4 AS AlBlng4,
                                AL_CITY_BLNG AS AlCityBlng,
                                AL_STATE_PROV_BLNG AS AlStateProvBlng,
                                AL_POST_CODE_BLNG AS AlPostCodeBlng,
                                AL_CNTRY_CODE_BLNG AS AlCntryCodeBlng
                            FROM batmdb_INVOICE
                            ORDER BY INV_ID";

            insertQueryINVOICE = @"INSERT INTO batmdb_INVOICE
                                        (INV_ID
                                        ,OWNER_KEY
                                        ,INV_KEY
                                        ,BAT_ID
                                        ,BAT_KEY
                                        ,VEND_BAT_KEY
                                        ,VEND_LABL
                                        ,LOC_ID_REMIT
                                        ,INV_TYPE
                                        ,INV_STAT
                                        ,INV_FB_CNT
                                        ,INV_CURRENCY_QUAL
                                        ,INV_AMT
                                        ,VEND_INV_AMT
                                        ,ACCT_NUM_VEND_BLNG
                                        ,AL_REMIT_1
                                        ,AL_REMIT_2
                                        ,AL_REMIT_3
                                        ,AL_REMIT_4
                                        ,AL_CITY_REMIT
                                        ,AL_STATE_PROV_REMIT
                                        ,AL_POST_CODE_REMIT
                                        ,AL_CNTRY_CODE_REMIT
                                        ,INV_CREAT_DTM
                                        ,LOC_ID_BLNG
                                        ,AL_BLNG_1
                                        ,AL_BLNG_2
                                        ,AL_BLNG_3
                                        ,AL_BLNG_4
                                        ,AL_CITY_BLNG
                                        ,AL_STATE_PROV_BLNG
                                        ,AL_POST_CODE_BLNG
                                        ,AL_CNTRY_CODE_BLNG
                                        ,INV_APP_AMT
                                        ,INV_ADJM_AMT
                                        ,INV_PD_AMT
                                        ,INV_ADJM_CNT
                                        ,INV_PAYMT_CNT
                                        ,INV_CREDIT_AMT
                                        ,INV_DISPUTE_AMT
                                        ,INV_OPEN_AMT)
                                    VALUES
                                        (@InvId
                                        ,@OwnerKey
                                        ,@InvKey
                                        ,@BatId
                                        ,@batchNumber
                                        ,@batchNumber
                                        ,@VendLabl
                                        ,@LocIdRemit
                                        ,'Manual Bill'
                                        ,@InvStat
                                        ,@InvFbCnt
                                        ,@InvCurrencyQual
                                        ,@InvAmt
                                        ,@VendInvAmt
                                        ,@AcctNumVendBlng
                                        ,@AlRemit1
                                        ,@AlRemit2
                                        ,@AlRemit3
                                        ,@AlRemit4
                                        ,@AlCityRemit
                                        ,@AlStateProvRemit
                                        ,@AlPostCodeRemit
                                        ,@AlCntryCodeRemit
                                        ,@InvCreatDtm
                                        ,@LocIdBlng
                                        ,@AlBlng1
                                        ,@AlBlng2
                                        ,@AlBlng3
                                        ,@AlBlng4
                                        ,@AlCityBlng
                                        ,@AlStateProvBlng
                                        ,@AlPostCodeBlng
                                        ,@AlCntryCodeBlng
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0)";
            updateQueryINVOICE = @"UPDATE batmdb_INVOICE
                                    SET
                                        INV_ID = @InvIdNew
                                        ,OWNER_KEY = @OwnerKey
                                        ,INV_KEY = @InvKey
                                        ,BAT_ID = @BatId
                                        ,BAT_KEY = @batchNumber
                                        ,VEND_BAT_KEY = @batchNumber
                                        ,VEND_LABL = @VendLabl
                                        ,LOC_ID_REMIT = @LocIdRemit
                                        ,INV_STAT = @InvStat
                                        ,INV_FB_CNT = @InvFbCnt
                                        ,INV_CURRENCY_QUAL = @InvCurrencyQual
                                        ,INV_AMT = @InvAmt
                                        ,VEND_INV_AMT = @VendInvAmt
                                        ,ACCT_NUM_VEND_BLNG = @AcctNumVendBlng
                                        ,AL_REMIT_1 = @AlRemit1
                                        ,AL_REMIT_2 = @AlRemit2
                                        ,AL_REMIT_3 = @AlRemit3
                                        ,AL_REMIT_4 = @AlRemit4
                                        ,AL_CITY_REMIT = @AlCityRemit
                                        ,AL_STATE_PROV_REMIT = @AlStateProvRemit
                                        ,AL_POST_CODE_REMIT = @AlPostCodeRemit
                                        ,AL_CNTRY_CODE_REMIT = @AlCntryCodeRemit
                                        ,INV_CREAT_DTM = @InvCreatDtm
                                        ,LOC_ID_BLNG = @LocIdBlng
                                        ,AL_BLNG_1 = @AlBlng1
                                        ,AL_BLNG_2 = @AlBlng2
                                        ,AL_BLNG_3 = @AlBlng3
                                        ,AL_BLNG_4 = @AlBlng4
                                        ,AL_CITY_BLNG = @AlCityBlng
                                        ,AL_STATE_PROV_BLNG = @AlStateProvBlng
                                        ,AL_POST_CODE_BLNG = @AlPostCodeBlng
                                        ,AL_CNTRY_CODE_BLNG = @AlCntryCodeBlng
                                    WHERE INV_ID = @InvId";
            deleteQueryINVOICE = @"DELETE FROM batmdb_INVOICE WHERE INV_ID = @InvId";
            #endregion
            #region FRGHT_BL
            selectQueryFRGHT_BL = @"SELECT
                                INV_ID AS InvId,
                                INV_KEY AS InvKey,
                                FB_ID AS FbId, 
                                FB_KEY AS FbKey,
                                FB_CURRENCY_QUAL AS FbCurrencyQual,
                                FB_AMT AS FbAmt,
                                FB_CREAT_DTM AS FbCreatDtm,
                                FB_PAYMT_TERMS_CODE AS FbPaymtTermsCode,
                                SRVC_REQ_CODE AS SrvcReqCode,
                                AL_ORIG_1 AS AlOrig1,
                                AL_ORIG_2 AS AlOrig2,
                                AL_ORIG_3 AS AlOrig3,
                                AL_ORIG_4 AS AlOrig4,
                                AL_CITY_ORIG AS AlCityOrig,
                                AL_STATE_PROV_ORIG AS AlStateProvOrig,
                                AL_POST_CODE_ORIG AS AlPostCodeOrig,
                                AL_CNTRY_CODE_ORIG AS AlCntryCodeOrig,
                                AL_DEST_1 AS AlDest1,
                                AL_DEST_2 AS AlDest2,
                                AL_DEST_3 AS AlDest3,
                                AL_DEST_4 AS AlDest4,
                                AL_CITY_DEST AS AlCityDest,
                                AL_STATE_PROV_DEST AS AlStateProvDest,
                                AL_POST_CODE_DEST AS AlPostCodeDest,
                                AL_CNTRY_CODE_DEST AS AlCntryCodeDest,
                                FB_ACTUAL_WT AS FbActualWt,
                                FB_FNCL_WT AS FbFnclWt,
                                FB_PKG_TYPE AS FbPkgType,
                                FB_PCS_CNT AS FbPcsCnt,
                                LM_DIST AS LmDist,
                                CA_INFO_1_RAW AS CaInfo1Raw,
                                CA_INFO_2_RAW AS CaInfo2Raw,
                                INTERLINE_SCAC AS InterlineScac,
                                INTERLINE_QUAL AS InterlineQual,
                                INTERLINE_AMT AS InterlineAmt,
                                LM_PKUP_ACTUAL_DTM AS LmPkupActualDtm,
                                LM_ATA_DTM AS LmAtaDtm,
                                FB_LN_CNT AS FbLnCnt,
                                VEND_LABL AS VendLabl,
                                ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
                                PRICE_LANE_LABL AS PriceLaneLabl,
                                LM_LANE_LABL AS LmLaneLabl,
                                FB_FRGHT_AMT AS FbFrghtAmt,
                                FB_DSCNT_AMT AS FbDscntAmt,
                                FB_ACC_AMT AS FbAccAmt,
                                FB_TAX_AMT AS FbTaxAmt,
                                LOC_ID_BLNG AS LocIdBlng,
                                [%T001] AS T001,
                                [%T002] AS T002,
                                [%T003] AS T003,
                                [%T004] AS T004
                            FROM batmdb_FRGHT_BL
                            ORDER BY FB_ID";

            insertQueryFRGHT_BL = @"INSERT INTO batmdb_FRGHT_BL
                                        (FB_ID
                                        ,OWNER_KEY
                                        ,FB_KEY
                                        ,VEND_FB_TYPE
                                        ,FB_TYPE
                                        ,INV_ID
                                        ,INV_KEY
                                        ,BAT_ID
                                        ,BAT_KEY
                                        ,FB_CLASS
                                        ,FB_LN_CNT
                                        ,FB_AMT
                                        ,FB_FRGHT_AMT
                                        ,FB_DSCNT_AMT
                                        ,FB_ACC_AMT
                                        ,FB_TAX_AMT
                                        ,FB_CURRENCY_QUAL
                                        ,FB_PAYMT_TERMS_CODE
                                        ,FB_CREAT_DTM
                                        ,FB_PKG_TYPE
                                        ,FB_PCS_CNT
                                        ,VEND_LABL
                                        ,SRVC_REQ_CODE
                                        ,CA_INFO_1_RAW
                                        ,CA_INFO_2_RAW
                                        ,ACCT_NUM_VEND_BLNG
                                        ,AL_ORIG_1
                                        ,AL_ORIG_2
                                        ,AL_ORIG_3
                                        ,AL_ORIG_4
                                        ,AL_CITY_ORIG
                                        ,AL_STATE_PROV_ORIG
                                        ,AL_POST_CODE_ORIG
                                        ,AL_CNTRY_CODE_ORIG
                                        ,AL_DEST_1
                                        ,AL_DEST_2
                                        ,AL_DEST_3
                                        ,AL_DEST_4
                                        ,AL_CITY_DEST
                                        ,AL_STATE_PROV_DEST
                                        ,AL_POST_CODE_DEST
                                        ,AL_CNTRY_CODE_DEST
                                        ,FB_ACTUAL_WT
                                        ,FB_FNCL_WT
                                        ,INTERLINE_SCAC
                                        ,INTERLINE_QUAL
                                        ,INTERLINE_AMT
                                        ,LM_DIST
                                        ,LM_PKUP_ACTUAL_DTM
                                        ,LM_ATA_DTM
                                        ,PRICE_LANE_LABL
                                        ,LM_LANE_LABL
                                        ,LOC_ID_BLNG
                                        ,FB_RPT_FACTOR
                                        ,TX_FB_RPT_FACTOR
                                        ,FB_APP_AMT
                                        ,FB_APP_RPT_FACTOR
                                        ,FB_ADJM_AMT
                                        ,FB_PD_AMT
                                        ,FB_CREDIT_AMT
                                        ,FB_DISPUTE_AMT
                                        ,FB_OPEN_AMT
                                        ,FB_ADJM_CNT
                                        ,FB_PAYMT_CNT
                                        ,FB_DIM_WT
                                        ,FB_BRK_PT_WT
                                        ,TX_FB_DIM_WT
                                        ,TX_FB_BRK_PT_WT
                                        ,TX_FB_FNCL_WT
                                        ,TX_LM_DIST
                                        ,[%T001]
                                        ,[%T002]
                                        ,[%T003]
                                        ,[%T004])
                                    VALUES
                                        (@FBId
                                        ,@OwnerKey
                                        ,@FbKey
                                        ,'Manual Bill'
                                        ,'Manual Bill'
                                        ,@InvId
                                        ,@InvKey
                                        ,@BatId
                                        ,@batchNumber
                                        ,'Waybill'
                                        ,@FbLnCnt
                                        ,@FbAmt
                                        ,@FbFrghtAmt
                                        ,@FbDscntAmt
                                        ,@FbAccAmt
                                        ,@FbTaxAmt
                                        ,@FbCurrencyQual
                                        ,@FbPaymtTermsCode
                                        ,@FbCreatDtm
                                        ,@FbPkgType
                                        ,@FbPcsCnt
                                        ,@VendLabl
                                        ,@SrvcReqCode
                                        ,@CaInfo1Raw
                                        ,@CaInfo2Raw
                                        ,@AcctNumVendBlng
                                        ,@AlOrig1
                                        ,@AlOrig2
                                        ,@AlOrig3
                                        ,@AlOrig4
                                        ,@AlCityOrig
                                        ,@AlStateProvOrig
                                        ,@AlPostCodeOrig
                                        ,@AlCntryCodeOrig
                                        ,@AlDest1
                                        ,@AlDest2
                                        ,@AlDest3
                                        ,@AlDest4
                                        ,@AlCityDest
                                        ,@AlStateProvDest
                                        ,@AlPostCodeDest
                                        ,@AlCntryCodeDest
                                        ,@FbActualWt
                                        ,@FbFnclWt
                                        ,@InterlineScac
                                        ,@InterlineQual
                                        ,@InterlineAmt
                                        ,@LmDist
                                        ,@LmPkupActualDtm
                                        ,@LmAtaDtm
                                        ,@PriceLaneLabl
                                        ,@LmLaneLabl
                                        ,@LocIdBlng
                                        ,1
                                        ,1
                                        ,0
                                        ,1
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,0
                                        ,@T001
                                        ,@T002
                                        ,@T003
                                        ,@T004)";
            updateQueryFRGHT_BL = @"UPDATE batmdb_FRGHT_BL
                                    SET
                                        FB_ID = @FBIdNew
                                        ,OWNER_KEY = @OwnerKey
                                        ,FB_KEY = @FbKey
                                        ,INV_ID = @InvId
                                        ,INV_KEY = @InvKey
                                        ,BAT_ID = @BatId
                                        ,BAT_KEY = @batchNumber
                                        ,FB_LN_CNT = @FbLnCnt
                                        ,FB_AMT = @FbAmt
                                        ,FB_FRGHT_AMT = @FbFrghtAmt
                                        ,FB_DSCNT_AMT = @FbDscntAmt
                                        ,FB_ACC_AMT = @FbAccAmt
                                        ,FB_TAX_AMT = @FbTaxAmt
                                        ,FB_CURRENCY_QUAL = @FbCurrencyQual
                                        ,FB_PAYMT_TERMS_CODE = @FbPaymtTermsCode
                                        ,FB_CREAT_DTM = @FbCreatDtm
                                        ,FB_PKG_TYPE = @FbPkgType
                                        ,FB_PCS_CNT = @FbPcsCnt
                                        ,VEND_LABL = @VendLabl
                                        ,SRVC_REQ_CODE = @SrvcReqCode
                                        ,CA_INFO_1_RAW = @CaInfo1Raw
                                        ,CA_INFO_2_RAW = @CaInfo2Raw
                                        ,ACCT_NUM_VEND_BLNG = @AcctNumVendBlng
                                        ,AL_ORIG_1 = @AlOrig1
                                        ,AL_ORIG_2 = @AlOrig2
                                        ,AL_ORIG_3 = @AlOrig3
                                        ,AL_ORIG_4 = @AlOrig4
                                        ,AL_CITY_ORIG = @AlCityOrig
                                        ,AL_STATE_PROV_ORIG = @AlStateProvOrig
                                        ,AL_POST_CODE_ORIG = @AlPostCodeOrig
                                        ,AL_CNTRY_CODE_ORIG = @AlCntryCodeOrig
                                        ,AL_DEST_1 = @AlDest1
                                        ,AL_DEST_2 = @AlDest2
                                        ,AL_DEST_3 = @AlDest3
                                        ,AL_DEST_4 = @AlDest4
                                        ,AL_CITY_DEST = @AlCityDest
                                        ,AL_STATE_PROV_DEST = @AlStateProvDest
                                        ,AL_POST_CODE_DEST = @AlPostCodeDest
                                        ,AL_CNTRY_CODE_DEST = @AlCntryCodeDest
                                        ,FB_ACTUAL_WT = @FbActualWt
                                        ,FB_FNCL_WT = @FbFnclWt
                                        ,INTERLINE_SCAC = @InterlineScac
                                        ,INTERLINE_QUAL = @InterlineQual
                                        ,INTERLINE_AMT = @InterlineAmt
                                        ,LM_DIST = @LmDist
                                        ,LM_PKUP_ACTUAL_DTM = @LmPkupActualDtm
                                        ,LM_ATA_DTM = @LmAtaDtm
                                        ,PRICE_LANE_LABL = @PriceLaneLabl
                                        ,LM_LANE_LABL = @LmLaneLabl
                                        ,LOC_ID_BLNG = @LocIdBlng
                                        ,[%T001] = @T001
                                        ,[%T002] = @T002
                                        ,[%T003] = @T003
                                        ,[%T004] = @T004
                                    WHERE FB_ID = @FBId";
            deleteQueryFRGHT_BL = @"DELETE FROM batmdb_FRGHT_BL WHERE FB_ID = @FBId";
            #endregion
            #region FB_LN
            selectQueryFB_LN = @"SELECT 
                                FB_ID AS FbId,
                                LINE_ITEM_NUM AS LineItemNum,
                                PCS_CNT	AS PcsCnt,
                                LN_CHRG_CODE AS LnChrgCode,
                                CHRG_DESC AS ChrgDesc,
                                [%FACSIMILE_01] AS Facsimile01,
                                CMDTY_CLASS AS CmdtyClass,
                                QTY_LABL AS QtyLabl,
                                RATE_AMT AS RateAmt,
                                RATE_TYPE AS RateType,
                                RATE_UNT_LABL AS RateUntLabl,
                                CAT AS Cat,
                                LN_ACTUAL_WT AS	LnActualWt,
                                LN_RATE_AS_WT AS LnRateAsWt,
                                PKG_TYPE AS PkgType,
                                CHRG_AMT AS ChrgAmt,
                                CURRENCY_QUAL AS CurrencyQual,
                                [%T001] AS T001,
                                [%T002] AS T002,
                                [%T003] AS T003,
                                [%T004] AS T004,
                                [%T005] AS T005,
                                [%T006] AS T006,
                                [%FACSIMILE_02] AS Facsimile02
                            FROM batmdb_FB_LN
                            ORDER BY FB_ID,LINE_ITEM_NUM";

            insertQueryFB_LN = @"INSERT INTO batmdb_FB_LN
                                    (FB_ID
                                    ,LINE_ITEM_NUM
                                    ,BAT_KEY
                                    ,QTY_LABL
                                    ,CHRG_DESC
                                    ,RATE_AMT
                                    ,RATE_TYPE
                                    ,RATE_UNT_LABL
                                    ,CHRG_AMT
                                    ,CURRENCY_QUAL
                                    ,CAT
                                    ,PKG_TYPE
                                    ,PCS_CNT
                                    ,LN_CHRG_CODE
                                    ,LN_ACTUAL_WT
                                    ,LN_RATE_AS_WT
                                    ,CMDTY_CLASS
                                    ,[%FACSIMILE_01]
                                    ,[%FACSIMILE_02]
                                    ,[%T001]
                                    ,[%T002]
                                    ,[%T003]
                                    ,[%T004]
                                    ,[%T005]
                                    ,[%T006]
                                    ,RATE_PER_UNT_CNT
                                    ,CAT_SEQ_NUM
                                    ,FB_LINE_ITEM_FLAG)
                                VALUES
                                    (@FbId
                                    ,@LineItemNum
                                    ,@batchNumber
                                    ,@QtyLabl
                                    ,@ChrgDesc
                                    ,@RateAmt
                                    ,@RateType
                                    ,@RateUntLabl
                                    ,@ChrgAmt
                                    ,@CurrencyQual
                                    ,@Cat
                                    ,@PkgType
                                    ,@PcsCnt
                                    ,@LnChrgCode
                                    ,@LnActualWt
                                    ,@LnRateAsWt
                                    ,@CmdtyClass
                                    ,@Facsimile01
                                    ,@Facsimile02
                                    ,@T001
                                    ,@T002
                                    ,@T003
                                    ,@T004
                                    ,@T005
                                    ,@T006
                                    ,0
                                    ,0
                                    ,1)";
            updateQueryFB_LN = @"UPDATE batmdb_FB_LN
                                SET
                                    FB_ID = @FbIdNew 
                                    ,LINE_ITEM_NUM = @LineItemNumNew
                                    ,BAT_KEY = @batchNumber
                                    ,QTY_LABL = @QtyLabl
                                    ,CHRG_DESC = @ChrgDesc
                                    ,RATE_AMT = @RateAmt
                                    ,RATE_TYPE = @RateType
                                    ,RATE_UNT_LABL = @RateUntLabl
                                    ,CHRG_AMT = @ChrgAmt
                                    ,CURRENCY_QUAL = @CurrencyQual
                                    ,CAT = @Cat
                                    ,PKG_TYPE = @PkgType
                                    ,PCS_CNT = @PcsCnt
                                    ,LN_CHRG_CODE = @LnChrgCode
                                    ,LN_ACTUAL_WT = @LnActualWt
                                    ,LN_RATE_AS_WT = @LnRateAsWt
                                    ,CMDTY_CLASS = @CmdtyClass
                                    ,[%FACSIMILE_01] = @Facsimile01
                                    ,[%FACSIMILE_02] = @Facsimile02
                                    ,[%T001] = @T001
                                    ,[%T002] = @T002
                                    ,[%T003] = @T003
                                    ,[%T004] = @T004
                                    ,[%T005] = @T005
                                    ,[%T006] = @T006
                                WHERE FB_ID = @FbId AND LINE_ITEM_NUM = @LineItemNum";
            deleteQueryFB_LN = @"DELETE FROM batmdb_FB_LN WHERE FB_ID = @FbId AND LINE_ITEM_NUM = @LineItemNum";
            #endregion
            #region FXI
            selectQueryFXI = @"SELECT 
                                    FB_ID AS FbId,INV_PAGE_NUM AS InvPageNum,VEND_LABL AS VendLabl,INV_ID AS InvId,BAT_ID AS BatId, 
                                    [%T001] AS T001,[%T002] AS T002,[%T003] AS T003,[%T004] AS T004,[%T005] AS T005,
                                    [%T006] AS T006,[%T007] AS T007,[%T008] AS T008,[%T009] AS T009,[%T010] AS T010,
                                    [%T011] AS T011,[%T012] AS T012,[%T013] AS T013,[%T014] AS T014,[%T015] AS T015,
                                    [%T016] AS T016,[%T017] AS T017,[%T018] AS T018,[%T019] AS T019,[%T020] AS T020,
                                    [%T021] AS T021,[%T022] AS T022,[%T023] AS T023,[%T024] AS T024,[%T025] AS T025,
                                    [%T026] AS T026,[%T027] AS T027,[%T028] AS T028,[%T029] AS T029,[%T030] AS T030,
                                    [%T031] AS T031,[%T032] AS T032,[%T033] AS T033,[%T034] AS T034,[%T035] AS T035,
                                    [%T036] AS T036,[%T037] AS T037,[%T038] AS T038,[%T039] AS T039,[%T040] AS T040,
                                    [%T041] AS T041,[%T042] AS T042,[%T043] AS T043,[%T044] AS T044,[%T045] AS T045,
                                    [%T046] AS T046,[%T047] AS T047,[%T048] AS T048,[%T049] AS T049,[%T050] AS T050,
                                    [%T051] AS T051,[%T052] AS T052,[%T053] AS T053,[%T054] AS T054,[%T055] AS T055,
                                    [%T056] AS T056,[%T057] AS T057,[%T058] AS T058,[%T059] AS T059,[%T060] AS T060,
                                    [%T061] AS T061,[%T062] AS T062,[%T063] AS T063,[%T064] AS T064,[%T065] AS T065,
                                    [%T066] AS T066,[%T067] AS T067,[%T068] AS T068,[%T069] AS T069,[%T070] AS T070,
                                    [%T071] AS T071,[%T072] AS T072,[%T073] AS T073,[%T074] AS T074,[%T075] AS T075,
                                    [%T076] AS T076,[%T077] AS T077,[%T078] AS T078,[%T079] AS T079,[%T080] AS T080,
                                    [%T081] AS T081,[%T082] AS T082,[%T083] AS T083,[%T084] AS T084,[%T085] AS T085,
                                    [%T086] AS T086,[%T087] AS T087,[%T088] AS T088,[%T089] AS T089,[%T090] AS T090,
                                    [%T091] AS T091,[%T092] AS T092,[%T093] AS T093,[%T094] AS T094,[%T095] AS T095,
                                    [%T096] AS T096,[%T097] AS T097,[%T098] AS T098,[%T099] AS T099,[%T100] AS T100,
                                    [%T101] AS T101,[%T102] AS T102,[%T103] AS T103,[%T104] AS T104,[%T105] AS T105,
                                    [%T106] AS T106,[%T107] AS T107,[%T108] AS T108,[%T109] AS T109,[%T110] AS T110,
                                    [%T111] AS T111,[%T112] AS T112,[%T113] AS T113,[%T114] AS T114,[%T115] AS T115,
                                    [%T116] AS T116,[%T117] AS T117,[%T118] AS T118,[%T119] AS T119,[%T120] AS T120
                                FROM batmdb_FXI";
            insertQueryFXI = @"INSERT INTO batmdb_FXI
                                    (FB_ID,INV_PAGE_NUM,VEND_LABL,INV_ID,BAT_ID,
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
                                    [%T111],[%T112],[%T113],[%T114],[%T115],[%T116],[%T117],[%T118],[%T119],[%T120])
                                VALUES
                                    (@FbId,@InvPageNum,@VendLabl,@InvId,@BatId,
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
                                    @T111,@T112,@T113,@T114,@T115,@T116,@T117,@T118,@T119,@T120)";

            updateQueryFXI = @"UPDATE batmdb_FXI
                                SET
                                    FB_ID = @FbIdNew,INV_PAGE_NUM = @InvPageNum,VEND_LABL = @VendLabl,INV_ID = @InvId,BAT_ID = @BatId, 
                                    [%T001] = @T001,[%T002] = @T002,[%T003] = @T003,[%T004] = @T004,[%T005] = @T005,
                                    [%T006] = @T006,[%T007] = @T007,[%T008] = @T008,[%T009] = @T009,[%T010] = @T010,
                                    [%T011] = @T011,[%T012] = @T012,[%T013] = @T013,[%T014] = @T014,[%T015] = @T015,
                                    [%T016] = @T016,[%T017] = @T017,[%T018] = @T018,[%T019] = @T019,[%T020] = @T020,
                                    [%T021] = @T021,[%T022] = @T022,[%T023] = @T023,[%T024] = @T024,[%T025] = @T025,
                                    [%T026] = @T026,[%T027] = @T027,[%T028] = @T028,[%T029] = @T029,[%T030] = @T030,
                                    [%T031] = @T031,[%T032] = @T032,[%T033] = @T033,[%T034] = @T034,[%T035] = @T035,
                                    [%T036] = @T036,[%T037] = @T037,[%T038] = @T038,[%T039] = @T039,[%T040] = @T040,
                                    [%T041] = @T041,[%T042] = @T042,[%T043] = @T043,[%T044] = @T044,[%T045] = @T045,
                                    [%T046] = @T046,[%T047] = @T047,[%T048] = @T048,[%T049] = @T049,[%T050] = @T050,
                                    [%T051] = @T051,[%T052] = @T052,[%T053] = @T053,[%T054] = @T054,[%T055] = @T055,
                                    [%T056] = @T056,[%T057] = @T057,[%T058] = @T058,[%T059] = @T059,[%T060] = @T060,
                                    [%T061] = @T061,[%T062] = @T062,[%T063] = @T063,[%T064] = @T064,[%T065] = @T065,
                                    [%T066] = @T066,[%T067] = @T067,[%T068] = @T068,[%T069] = @T069,[%T070] = @T070,
                                    [%T071] = @T071,[%T072] = @T072,[%T073] = @T073,[%T074] = @T074,[%T075] = @T075,
                                    [%T076] = @T076,[%T077] = @T077,[%T078] = @T078,[%T079] = @T079,[%T080] = @T080,
                                    [%T081] = @T081,[%T082] = @T082,[%T083] = @T083,[%T084] = @T084,[%T085] = @T085,
                                    [%T086] = @T086,[%T087] = @T087,[%T088] = @T088,[%T089] = @T089,[%T090] = @T090,
                                    [%T091] = @T091,[%T092] = @T092,[%T093] = @T093,[%T094] = @T094,[%T095] = @T095,
                                    [%T096] = @T096,[%T097] = @T097,[%T098] = @T098,[%T099] = @T099,[%T100] = @T100,
                                    [%T101] = @T101,[%T102] = @T102,[%T103] = @T103,[%T104] = @T104,[%T105] = @T105,
                                    [%T106] = @T106,[%T107] = @T107,[%T108] = @T108,[%T109] = @T109,[%T110] = @T110,
                                    [%T111] = @T111,[%T112] = @T112,[%T113] = @T113,[%T114] = @T114,[%T115] = @T115,
                                    [%T116] = @T116,[%T117] = @T117,[%T118] = @T118,[%T119] = @T119,[%T120] = @T120
                                WHERE FB_ID = @FBId";
            deleteQueryFXI = @"DELETE FROM batmdb_FXI WHERE FB_ID = @FBId";
            #endregion
        }

        [WebMethod]
        public DataSet selectBatches()
        {
            DataSet retval = new DataSet();
            string query = string.Format(@"SELECT BDE.Bat_Ctrl_Num AS [Batch Number],
                                    BDE.Batch_Status AS [Batch Status],
                                    BDE.Owner_Key AS [Owner Key],
                                    BDE.Vend_SCAC AS [Vendor SCAC],
                                    BDE.Oper_Init AS [Operator],
                                    BDE.Owner_Code AS [OwnerCode]
                            FROM Batch_DE(NOLOCK) BDE
                            JOIN Batch_DE_Ext(NOLOCK) BDX ON BDE.BatchID = BDX.BatchID
                            WHERE BDE.Batch_Status NOT IN ('MOVE TO CR','DE COMPLETE', 'OPENQA', 'SPLIT','SPLIT COMPLETE','COMBINED') AND BDE.Active = 1
                            AND BDX.DEVer = 'OLD' AND BDX.DESiteID = {0}
                            ORDER BY BDE.Bat_Ctrl_Num", ConfigurationManager.AppSettings["SiteID"]);
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
        public DataSet selectBatch(string MXXDatabase)
        {
            DataSet retval = new DataSet();
            DataSet dsInvBat = new DataSet("InvBat");
            DataSet dsInvoice = new DataSet("Invoice");
            DataSet dsFB = new DataSet("FB");            
            DataSet dsFBLn = new DataSet("FBLn");
            DataSet dsFXI = new DataSet("FXI");
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", "MXX" + MXXDatabase.Trim() + ".mdb");
            
            try
            {
                dalMXXDatabase.OpenDB();
                dsInvBat = dalMXXDatabase.ExecuteDataSet(selectQueryINV_BAT, CommandType.Text);
                dsInvoice = dalMXXDatabase.ExecuteDataSet(selectQueryINVOICE, CommandType.Text);
                dsFB = dalMXXDatabase.ExecuteDataSet(selectQueryFRGHT_BL, CommandType.Text);
                dsFBLn = dalMXXDatabase.ExecuteDataSet(selectQueryFB_LN, CommandType.Text);
                dsFXI = dalMXXDatabase.ExecuteDataSet(selectQueryFXI, CommandType.Text);

                dsInvBat.Tables[0].TableName = "InvBat";
                dsInvoice.Tables[0].TableName = "Invoice";
                dsFB.Tables[0].TableName = "FB";
                dsFBLn.Tables[0].TableName = "FBLn";
                dsFXI.Tables[0].TableName = "FXI";

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

        [WebMethod]
        public DataSet selectChargeCode()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT
                                CAT AS LnCat,
                                LN_CHRG_CODE AS LnChrgCode,
                                CHRG_DESC AS LnChrgDesc
                            FROM CHRG_CODE(NOLOCK)";
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
        public DataSet selectShipperConsignee()
        {
            DataSet retval = new DataSet();
            DataSet dsShipper = new DataSet();
            DataSet dsConsignee = new DataSet();
            string queryShipper = @"SELECT 
                                        AL_ORIG_1 AS Name1,
                                        AL_ORIG_2 AS Name2,
                                        AL_ORIG_3 AS Address1,
                                        AL_ORIG_4 AS Address2,
                                        AL_CITY_ORIG AS City,
                                        AL_STATE_PROV_ORIG AS St,
                                        AL_POST_CODE_ORIG AS Zip,
                                        AL_CNTRY_CODE_ORIG AS Country
                                    FROM SHIPPER(NOLOCK)";
            string queryConsignee = @"SELECT 
                                        AL_DEST_1 AS Name1,
                                        AL_DEST_2 AS Name2,
                                        AL_DEST_3 AS Address1,
                                        AL_DEST_4 AS Address2,
                                        AL_CITY_DEST AS City,
                                        AL_STATE_PROV_DEST AS St,
                                        AL_POST_CODE_DEST AS Zip,
                                       AL_CNTRY_CODE_DEST AS Country
                                    FROM CONSIGNEE(NOLOCK)";
            try
            {
                dal.OpenDB();
                dsShipper = dal.ExecuteDataSet(queryShipper, CommandType.Text);
                dsConsignee = dal.ExecuteDataSet(queryConsignee, CommandType.Text);

                dsShipper.Tables[0].TableName = "Shipper";
                dsConsignee.Tables[0].TableName = "Consignee";

                retval.Tables.Add(dsShipper.Tables[0].Copy());
                retval.Tables[0].AcceptChanges();
                retval.Tables.Add(dsConsignee.Tables[0].Copy());
                retval.Tables[1].AcceptChanges();
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
        public bool insertTRBat(string ownerKey, string MXXBatch, string UserInitials)
        {
            bool retval = false;
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", MXXBatch.Trim() + ".mdb");
            int affectedRows = 0;
            string queryInsert = @"INSERT INTO TR_BAT
                                       (OWNER_KEY
                                           ,EX_BAT_KEY
                                           ,EX_BAT_KEY_TYPE
                                           ,VEND_LABL
                                           ,VEND_BAT_KEY
                                           ,BAT_ID
                                           ,BAT_KEY
                                           ,EX_BAT_CREAT_DTM
                                           ,EX_BAT_CREAT_DTM_ORIG
                                           ,EX_BAT_TRANS_CNT
                                           ,EX_BAT_OWN_USER)
                                     VALUES
                                        (@OWNER_KEY
                                           ,@EX_BAT_KEY
                                           ,@EX_BAT_KEY_TYPE
                                           ,@VEND_LABL
                                           ,@VEND_BAT_KEY
                                           ,@BAT_ID
                                           ,@BAT_KEY
                                           ,@EX_BAT_CREAT_DTM
                                           ,@EX_BAT_CREAT_DTM_ORIG
                                           ,@EX_BAT_TRANS_CNT
                                           ,@EX_BAT_OWN_USER)";
            try
            {
                ParameterInfoOleDB[] param = new ParameterInfoOleDB[11];
                param[0] = new ParameterInfoOleDB("@OWNER_KEY", ownerKey);
                param[1] = new ParameterInfoOleDB("@EX_BAT_KEY", MXXBatch);
                param[2] = new ParameterInfoOleDB("@EX_BAT_KEY_TYPE", "Manual Bill");
                param[3] = new ParameterInfoOleDB("@VEND_LABL", "Mixed");
                param[4] = new ParameterInfoOleDB("@VEND_BAT_KEY", MXXBatch);
                param[5] = new ParameterInfoOleDB("@BAT_ID", "BACH" + ownerKey.Trim().Remove(3, 1) + MXXBatch + (0).ToString().PadLeft(4, '0'));
                param[6] = new ParameterInfoOleDB("@BAT_KEY", MXXBatch);
                param[7] = new ParameterInfoOleDB("@EX_BAT_CREAT_DTM", DateTime.Now);
                param[8] = new ParameterInfoOleDB("@EX_BAT_CREAT_DTM_ORIG", DateTime.Now);
                param[9] = new ParameterInfoOleDB("@EX_BAT_TRANS_CNT", 0);
                param[10] = new ParameterInfoOleDB("@EX_BAT_OWN_USER", UserInitials);//CommonUserLogin.getUser().UserInitials);

                dalMXXDatabase.OpenDB();
                dalMXXDatabase.BeginTransaction();
                affectedRows = dalMXXDatabase.ExecuteNonQuery(queryInsert, CommandType.Text, param);
                dalMXXDatabase.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dalMXXDatabase.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dalMXXDatabase.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool saveBatch(DataSet dsBatch, string MXXDatabase, string OwnerKey)
        {
            bool retval = false;
            DataSet dsInvBat = new DataSet();
            DataSet dsInvoice = new DataSet();
            DataSet dsFrghtBL = new DataSet();
            DataSet dsFBLn = new DataSet();
            int affectedRows;
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", "MXX" + MXXDatabase.Trim() + ".mdb");
                 
            try
            {
                string ownerKey = OwnerKey.Trim().Remove(3, 1);
                string batchNumber = "MXX" + MXXDatabase.Trim();
                string batchCount = (0).ToString().PadLeft(4, '0');                
                dalMXXDatabase.OpenDB();
                dalMXXDatabase.BeginTransaction();
                #region INV_BAT
                foreach (DataRow dr in dsBatch.Tables["InvBat"].Rows)
                {
                    ParameterInfoOleDB[] paramINV_BAT;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramINV_BAT = new ParameterInfoOleDB[13];
                        paramINV_BAT[0] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        paramINV_BAT[1] = new ParameterInfoOleDB("@OwnerKey", dr["OwnerKey"]);
                        paramINV_BAT[2] = new ParameterInfoOleDB("@VendBatKey", dr["VendBatKey"]);
                        paramINV_BAT[3] = new ParameterInfoOleDB("@VendBatDtm", dr["VendBatDtm"]);
                        paramINV_BAT[4] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINV_BAT[5] = new ParameterInfoOleDB("@VendFeed", dr["VendFeed"]);
                        paramINV_BAT[6] = new ParameterInfoOleDB("@BatKey", dr["BatKey"]);
                        paramINV_BAT[7] = new ParameterInfoOleDB("@BatCreatDtm", dr["BatCreatDtm"]);
                        paramINV_BAT[8] = new ParameterInfoOleDB("@BatInvCnt", dr["BatInvCnt"]);
                        paramINV_BAT[9] = new ParameterInfoOleDB("@BatFbCnt", dr["BatFbCnt"]);
                        paramINV_BAT[10] = new ParameterInfoOleDB("@BatAmt", dr["BatAmt"].ToString().Trim() == string.Empty ? 0 : dr["BatAmt"]);
                        paramINV_BAT[11] = new ParameterInfoOleDB("@BatCurrencyQual", dr["BatCurrencyQual"]);
                        paramINV_BAT[12] = new ParameterInfoOleDB("@BatLocIdRemit", dr["BatLocIdRemit"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryINV_BAT, CommandType.Text, paramINV_BAT);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramINV_BAT = new ParameterInfoOleDB[16];
                        paramINV_BAT[0] = new ParameterInfoOleDB("@BatIdNew", dr["BatId"]);
                        paramINV_BAT[1] = new ParameterInfoOleDB("@OwnerKey", dr["OwnerKey"]);
                        paramINV_BAT[2] = new ParameterInfoOleDB("@VendBatKey", dr["VendBatKey"]);
                        paramINV_BAT[3] = new ParameterInfoOleDB("@VendBatDtm", dr["VendBatDtm"]);
                        paramINV_BAT[4] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINV_BAT[5] = new ParameterInfoOleDB("@VendFeed", dr["VendFeed"]);
                        paramINV_BAT[6] = new ParameterInfoOleDB("@BatKey", dr["BatKey"]);
                        paramINV_BAT[7] = new ParameterInfoOleDB("@BatCreatDtm", dr["BatCreatDtm"]);
                        paramINV_BAT[8] = new ParameterInfoOleDB("@BatInvCnt", dr["BatInvCnt"]);
                        paramINV_BAT[9] = new ParameterInfoOleDB("@BatFbCnt", dr["BatFbCnt"]);
                        paramINV_BAT[10] = new ParameterInfoOleDB("@BatAmt", dr["BatAmt"].ToString().Trim() == string.Empty ? 0 : dr["BatAmt"]);
                        paramINV_BAT[11] = new ParameterInfoOleDB("@BatCurrencyQual", dr["BatCurrencyQual"]);
                        paramINV_BAT[12] = new ParameterInfoOleDB("@BatLocIdRemit", dr["BatLocIdRemit"]);
                        paramINV_BAT[13] = new ParameterInfoOleDB("@BatStat", dr["BatStat"]);
                        paramINV_BAT[14] = new ParameterInfoOleDB("@BatType", dr["BatType"]);
                        dr.RejectChanges();
                        paramINV_BAT[15] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryINV_BAT, CommandType.Text, paramINV_BAT);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramINV_BAT = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramINV_BAT[0] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryINV_BAT, CommandType.Text, paramINV_BAT);
                    }
                }
                #endregion
                #region INVOICE
                foreach (DataRow dr in dsBatch.Tables["Invoice"].Rows)
                {

                    ParameterInfoOleDB[] paramINVOICE;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramINVOICE = new ParameterInfoOleDB[31];

                        paramINVOICE[0] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramINVOICE[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramINVOICE[2] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramINVOICE[3] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                        paramINVOICE[4] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramINVOICE[5] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINVOICE[6] = new ParameterInfoOleDB("@LocIdRemit", dr["LocIdRemit"]);
                        paramINVOICE[7] = new ParameterInfoOleDB("@InvStat", dr["InvStat"]);
                        paramINVOICE[8] = new ParameterInfoOleDB("@InvFbCnt", dr["InvFbCnt"].ToString().Trim() == string.Empty ? 0 : dr["InvFbCnt"]);
                        paramINVOICE[9] = new ParameterInfoOleDB("@InvCurrencyQual", dr["InvCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCurrencyQual"]);
                        paramINVOICE[10] = new ParameterInfoOleDB("@InvAmt", dr["InvAmt"].ToString().Trim() == string.Empty ? 0 : dr["InvAmt"]);
                        paramINVOICE[11] = new ParameterInfoOleDB("@VendInvAmt", dr["VendInvAmt"].ToString().Trim() == string.Empty ? 0 : dr["VendInvAmt"]);
                        paramINVOICE[12] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramINVOICE[13] = new ParameterInfoOleDB("@AlRemit1", dr["AlRemit1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit1"]);
                        paramINVOICE[14] = new ParameterInfoOleDB("@AlRemit2", dr["AlRemit2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit2"]);
                        paramINVOICE[15] = new ParameterInfoOleDB("@AlRemit3", dr["AlRemit3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit3"]);
                        paramINVOICE[16] = new ParameterInfoOleDB("@AlRemit4", dr["AlRemit4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit4"]);
                        paramINVOICE[17] = new ParameterInfoOleDB("@AlCityRemit", dr["AlCityRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityRemit"]);
                        paramINVOICE[18] = new ParameterInfoOleDB("@AlStateProvRemit", dr["AlStateProvRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvRemit"]);
                        paramINVOICE[19] = new ParameterInfoOleDB("@AlPostCodeRemit", dr["AlPostCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeRemit"]);
                        paramINVOICE[20] = new ParameterInfoOleDB("@AlCntryCodeRemit", dr["AlCntryCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeRemit"]);
                        paramINVOICE[21] = new ParameterInfoOleDB("@InvCreatDtm", dr["InvCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCreatDtm"]);

                        paramINVOICE[22] = new ParameterInfoOleDB("@LocIdBlng",dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);
                        paramINVOICE[23] = new ParameterInfoOleDB("@AlBlng1",dr["AlBlng1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng1"]);
                        paramINVOICE[24] = new ParameterInfoOleDB("@AlBlng2", dr["AlBlng2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng2"]);
                        paramINVOICE[25] = new ParameterInfoOleDB("@AlBlng3", dr["AlBlng3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng3"]);
                        paramINVOICE[26] = new ParameterInfoOleDB("@AlBlng4", dr["AlBlng4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng4"]);
                        paramINVOICE[27] = new ParameterInfoOleDB("@AlCityBlng", dr["AlCityBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityBlng"]);
                        paramINVOICE[28] = new ParameterInfoOleDB("@AlStateProvBlng", dr["AlStateProvBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvBlng"]);
                        paramINVOICE[29] = new ParameterInfoOleDB("@AlPostCodeBlng", dr["AlPostCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeBlng"]);
                        paramINVOICE[30] = new ParameterInfoOleDB("@AlCntryCodeBlng", dr["AlCntryCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeBlng"]);


                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryINVOICE, CommandType.Text, paramINVOICE);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramINVOICE = new ParameterInfoOleDB[32];

                        paramINVOICE[0] = new ParameterInfoOleDB("@InvIdNew", dr["InvId"]);
                        paramINVOICE[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramINVOICE[2] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramINVOICE[3] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                        paramINVOICE[4] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramINVOICE[5] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINVOICE[6] = new ParameterInfoOleDB("@LocIdRemit", dr["LocIdRemit"]);
                        paramINVOICE[7] = new ParameterInfoOleDB("@InvStat", dr["InvStat"]);
                        paramINVOICE[8] = new ParameterInfoOleDB("@InvFbCnt", dr["InvFbCnt"].ToString().Trim() == string.Empty ? 0 : dr["InvFbCnt"]);
                        paramINVOICE[9] = new ParameterInfoOleDB("@InvCurrencyQual", dr["InvCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCurrencyQual"]);
                        paramINVOICE[10] = new ParameterInfoOleDB("@InvAmt", dr["InvAmt"].ToString().Trim() == string.Empty ? 0 : dr["InvAmt"]);
                        paramINVOICE[11] = new ParameterInfoOleDB("@VendInvAmt", dr["VendInvAmt"].ToString().Trim() == string.Empty ? 0 : dr["VendInvAmt"]);
                        paramINVOICE[12] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramINVOICE[13] = new ParameterInfoOleDB("@AlRemit1", dr["AlRemit1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit1"]);
                        paramINVOICE[14] = new ParameterInfoOleDB("@AlRemit2", dr["AlRemit2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit2"]);
                        paramINVOICE[15] = new ParameterInfoOleDB("@AlRemit3", dr["AlRemit3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit3"]);
                        paramINVOICE[16] = new ParameterInfoOleDB("@AlRemit4", dr["AlRemit4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit4"]);
                        paramINVOICE[17] = new ParameterInfoOleDB("@AlCityRemit", dr["AlCityRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityRemit"]);
                        paramINVOICE[18] = new ParameterInfoOleDB("@AlStateProvRemit", dr["AlStateProvRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvRemit"]);
                        paramINVOICE[19] = new ParameterInfoOleDB("@AlPostCodeRemit", dr["AlPostCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeRemit"]);
                        paramINVOICE[20] = new ParameterInfoOleDB("@AlCntryCodeRemit", dr["AlCntryCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeRemit"]);
                        paramINVOICE[21] = new ParameterInfoOleDB("@InvCreatDtm", dr["InvCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCreatDtm"]);

                        paramINVOICE[22] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);
                        paramINVOICE[23] = new ParameterInfoOleDB("@AlBlng1", dr["AlBlng1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng1"]);
                        paramINVOICE[24] = new ParameterInfoOleDB("@AlBlng2", dr["AlBlng2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng2"]);
                        paramINVOICE[25] = new ParameterInfoOleDB("@AlBlng3", dr["AlBlng3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng3"]);
                        paramINVOICE[26] = new ParameterInfoOleDB("@AlBlng4", dr["AlBlng4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng4"]);
                        paramINVOICE[27] = new ParameterInfoOleDB("@AlCityBlng", dr["AlCityBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityBlng"]);
                        paramINVOICE[28] = new ParameterInfoOleDB("@AlStateProvBlng", dr["AlStateProvBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvBlng"]);
                        paramINVOICE[29] = new ParameterInfoOleDB("@AlPostCodeBlng", dr["AlPostCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeBlng"]);
                        paramINVOICE[30] = new ParameterInfoOleDB("@AlCntryCodeBlng", dr["AlCntryCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeBlng"]);

                        dr.RejectChanges();
                        paramINVOICE[31] = new ParameterInfoOleDB("@InvId", dr["InvId"]);

                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryINVOICE, CommandType.Text, paramINVOICE);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramINVOICE = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramINVOICE[0] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryINVOICE, CommandType.Text, paramINVOICE);
                    }
                }
                #endregion
                #region FRGHT_BL
                foreach (DataRow dr in dsBatch.Tables["FB"].Rows)
                {
                    ParameterInfoOleDB[] paramFRGHT_BL;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramFRGHT_BL = new ParameterInfoOleDB[54];

                        paramFRGHT_BL[0] = new ParameterInfoOleDB("@FBId", dr["FbId"]);
                        paramFRGHT_BL[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramFRGHT_BL[2] = new ParameterInfoOleDB("@FbKey", dr["FbKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbKey"]);
                        paramFRGHT_BL[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFRGHT_BL[4] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramFRGHT_BL[5] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                        paramFRGHT_BL[6] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFRGHT_BL[7] = new ParameterInfoOleDB("@FbLnCnt", dr["FbLnCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbLnCnt"]);
                        paramFRGHT_BL[8] = new ParameterInfoOleDB("@FbAmt", dr["FbAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAmt"]);
                        paramFRGHT_BL[9] = new ParameterInfoOleDB("@FbFrghtAmt", dr["FbFrghtAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbFrghtAmt"]);
                        paramFRGHT_BL[10] = new ParameterInfoOleDB("@FbDscntAmt", dr["FbDscntAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbDscntAmt"]);
                        paramFRGHT_BL[11] = new ParameterInfoOleDB("@FbAccAmt", dr["FbAccAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAccAmt"]);
                        paramFRGHT_BL[12] = new ParameterInfoOleDB("@FbTaxAmt", dr["FbTaxAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbTaxAmt"]);
                        paramFRGHT_BL[13] = new ParameterInfoOleDB("@FbCurrencyQual", dr["FbCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCurrencyQual"]);
                        paramFRGHT_BL[14] = new ParameterInfoOleDB("@FbPaymtTermsCode", dr["FbPaymtTermsCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPaymtTermsCode"]);
                        paramFRGHT_BL[15] = new ParameterInfoOleDB("@FbCreatDtm", dr["FbCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCreatDtm"]);
                        paramFRGHT_BL[16] = new ParameterInfoOleDB("@FbPkgType", dr["FbPkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPkgType"]);
                        paramFRGHT_BL[17] = new ParameterInfoOleDB("@FbPcsCnt", dr["FbPcsCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbPcsCnt"]);
                        paramFRGHT_BL[18] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["VendLabl"]);
                        paramFRGHT_BL[19] = new ParameterInfoOleDB("@SrvcReqCode", dr["SrvcReqCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["SrvcReqCode"]);
                        paramFRGHT_BL[20] = new ParameterInfoOleDB("@CaInfo1Raw", dr["CaInfo1Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo1Raw"]);
                        paramFRGHT_BL[21] = new ParameterInfoOleDB("@CaInfo2Raw", dr["CaInfo2Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo2Raw"]);
                        paramFRGHT_BL[22] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramFRGHT_BL[23] = new ParameterInfoOleDB("@AlOrig1", dr["AlOrig1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig1"]);
                        paramFRGHT_BL[24] = new ParameterInfoOleDB("@AlOrig2", dr["AlOrig2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig2"]);
                        paramFRGHT_BL[25] = new ParameterInfoOleDB("@AlOrig3", dr["AlOrig3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig3"]);
                        paramFRGHT_BL[26] = new ParameterInfoOleDB("@AlOrig4", dr["AlOrig4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig4"]);
                        paramFRGHT_BL[27] = new ParameterInfoOleDB("@AlCityOrig", dr["AlCityOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityOrig"]);
                        paramFRGHT_BL[28] = new ParameterInfoOleDB("@AlStateProvOrig", dr["AlStateProvOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvOrig"]);
                        paramFRGHT_BL[29] = new ParameterInfoOleDB("@AlPostCodeOrig", dr["AlPostCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeOrig"]);
                        paramFRGHT_BL[30] = new ParameterInfoOleDB("@AlCntryCodeOrig", dr["AlCntryCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeOrig"]);
                        paramFRGHT_BL[31] = new ParameterInfoOleDB("@AlDest1", dr["AlDest1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest1"]);
                        paramFRGHT_BL[32] = new ParameterInfoOleDB("@AlDest2", dr["AlDest2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest2"]);
                        paramFRGHT_BL[33] = new ParameterInfoOleDB("@AlDest3", dr["AlDest3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest3"]);
                        paramFRGHT_BL[34] = new ParameterInfoOleDB("@AlDest4", dr["AlDest4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest4"]);
                        paramFRGHT_BL[35] = new ParameterInfoOleDB("@AlCityDest", dr["AlCityDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityDest"]);
                        paramFRGHT_BL[36] = new ParameterInfoOleDB("@AlStateProvDest", dr["AlStateProvDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvDest"]);
                        paramFRGHT_BL[37] = new ParameterInfoOleDB("@AlPostCodeDest", dr["AlPostCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeDest"]);
                        paramFRGHT_BL[38] = new ParameterInfoOleDB("@AlCntryCodeDest", dr["AlCntryCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeDest"]);
                        paramFRGHT_BL[39] = new ParameterInfoOleDB("@FbActualWt", dr["FbActualWt"].ToString().Trim() == string.Empty ? 0 : dr["FbActualWt"]);
                        paramFRGHT_BL[40] = new ParameterInfoOleDB("@FbFnclWt", dr["FbFnclWt"].ToString().Trim() == string.Empty ? 0 : dr["FbFnclWt"]);
                        paramFRGHT_BL[41] = new ParameterInfoOleDB("@InterlineScac", dr["InterlineScac"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineScac"]);
                        paramFRGHT_BL[42] = new ParameterInfoOleDB("@InterlineQual", dr["InterlineQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineQual"]);
                        paramFRGHT_BL[43] = new ParameterInfoOleDB("@InterlineAmt", dr["InterlineAmt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineAmt"]);
                        paramFRGHT_BL[44] = new ParameterInfoOleDB("@LmDist", dr["LmDist"].ToString().Trim() == string.Empty ? 0 : dr["LmDist"]);
                        paramFRGHT_BL[45] = new ParameterInfoOleDB("@LmPkupActualDtm", dr["LmPkupActualDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmPkupActualDtm"]);
                        paramFRGHT_BL[46] = new ParameterInfoOleDB("@LmAtaDtm", dr["LmAtaDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmAtaDtm"]);
                        paramFRGHT_BL[47] = new ParameterInfoOleDB("@PriceLaneLabl", dr["PriceLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PriceLaneLabl"]);
                        paramFRGHT_BL[48] = new ParameterInfoOleDB("@LmLaneLabl", dr["LmLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmLaneLabl"]);
                        paramFRGHT_BL[49] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);

                        paramFRGHT_BL[50] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFRGHT_BL[51] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFRGHT_BL[52] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFRGHT_BL[53] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramFRGHT_BL = new ParameterInfoOleDB[55];
                        paramFRGHT_BL[0] = new ParameterInfoOleDB("@FBIdNew", dr["FbId"]);
                        paramFRGHT_BL[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramFRGHT_BL[2] = new ParameterInfoOleDB("@FbKey", dr["FbKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbKey"]);
                        paramFRGHT_BL[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFRGHT_BL[4] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramFRGHT_BL[5] = new ParameterInfoOleDB("@BAT_ID", "BACH" + ownerKey + batchNumber + batchCount);
                        paramFRGHT_BL[6] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFRGHT_BL[7] = new ParameterInfoOleDB("@FbLnCnt", dr["FbLnCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbLnCnt"]);
                        paramFRGHT_BL[8] = new ParameterInfoOleDB("@FbAmt", dr["FbAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAmt"]);
                        paramFRGHT_BL[9] = new ParameterInfoOleDB("@FbFrghtAmt", dr["FbFrghtAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbFrghtAmt"]);
                        paramFRGHT_BL[10] = new ParameterInfoOleDB("@FbDscntAmt", dr["FbDscntAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbDscntAmt"]);
                        paramFRGHT_BL[11] = new ParameterInfoOleDB("@FbAccAmt", dr["FbAccAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAccAmt"]);
                        paramFRGHT_BL[12] = new ParameterInfoOleDB("@FbTaxAmt", dr["FbTaxAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbTaxAmt"]);
                        paramFRGHT_BL[13] = new ParameterInfoOleDB("@FbCurrencyQual", dr["FbCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCurrencyQual"]);
                        paramFRGHT_BL[14] = new ParameterInfoOleDB("@FbPaymtTermsCode", dr["FbPaymtTermsCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPaymtTermsCode"]);
                        paramFRGHT_BL[15] = new ParameterInfoOleDB("@FbCreatDtm", dr["FbCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCreatDtm"]);
                        paramFRGHT_BL[16] = new ParameterInfoOleDB("@FbPkgType", dr["FbPkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPkgType"]);
                        paramFRGHT_BL[17] = new ParameterInfoOleDB("@FbPcsCnt", dr["FbPcsCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbPcsCnt"]);
                        paramFRGHT_BL[18] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["VendLabl"]);
                        paramFRGHT_BL[19] = new ParameterInfoOleDB("@SrvcReqCode", dr["SrvcReqCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["SrvcReqCode"]);
                        paramFRGHT_BL[20] = new ParameterInfoOleDB("@CaInfo1Raw", dr["CaInfo1Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo1Raw"]);
                        paramFRGHT_BL[21] = new ParameterInfoOleDB("@CaInfo2Raw", dr["CaInfo2Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo2Raw"]);
                        paramFRGHT_BL[22] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramFRGHT_BL[23] = new ParameterInfoOleDB("@AlOrig1", dr["AlOrig1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig1"]);
                        paramFRGHT_BL[24] = new ParameterInfoOleDB("@AlOrig2", dr["AlOrig2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig2"]);
                        paramFRGHT_BL[25] = new ParameterInfoOleDB("@AlOrig3", dr["AlOrig3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig3"]);
                        paramFRGHT_BL[26] = new ParameterInfoOleDB("@AlOrig4", dr["AlOrig4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig4"]);
                        paramFRGHT_BL[27] = new ParameterInfoOleDB("@AlCityOrig", dr["AlCityOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityOrig"]);
                        paramFRGHT_BL[28] = new ParameterInfoOleDB("@AlStateProvOrig", dr["AlStateProvOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvOrig"]);
                        paramFRGHT_BL[29] = new ParameterInfoOleDB("@AlPostCodeOrig", dr["AlPostCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeOrig"]);
                        paramFRGHT_BL[30] = new ParameterInfoOleDB("@AlCntryCodeOrig", dr["AlCntryCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeOrig"]);
                        paramFRGHT_BL[31] = new ParameterInfoOleDB("@AlDest1", dr["AlDest1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest1"]);
                        paramFRGHT_BL[32] = new ParameterInfoOleDB("@AlDest2", dr["AlDest2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest2"]);
                        paramFRGHT_BL[33] = new ParameterInfoOleDB("@AlDest3", dr["AlDest3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest3"]);
                        paramFRGHT_BL[34] = new ParameterInfoOleDB("@AlDest4", dr["AlDest4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest4"]);
                        paramFRGHT_BL[35] = new ParameterInfoOleDB("@AlCityDest", dr["AlCityDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityDest"]);
                        paramFRGHT_BL[36] = new ParameterInfoOleDB("@AlStateProvDest", dr["AlStateProvDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvDest"]);
                        paramFRGHT_BL[37] = new ParameterInfoOleDB("@AlPostCodeDest", dr["AlPostCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeDest"]);
                        paramFRGHT_BL[38] = new ParameterInfoOleDB("@AlCntryCodeDest", dr["AlCntryCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeDest"]);
                        paramFRGHT_BL[39] = new ParameterInfoOleDB("@FbFnclWt", dr["FbActualWt"].ToString().Trim() == string.Empty ? 0 : dr["FbActualWt"]);
                        paramFRGHT_BL[40] = new ParameterInfoOleDB("@FbFnclWt", dr["FbFnclWt"].ToString().Trim() == string.Empty ? 0 : dr["FbFnclWt"]);
                        paramFRGHT_BL[41] = new ParameterInfoOleDB("@InterlineScac", dr["InterlineScac"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineScac"]);
                        paramFRGHT_BL[42] = new ParameterInfoOleDB("@InterlineQual", dr["InterlineQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineQual"]);
                        paramFRGHT_BL[43] = new ParameterInfoOleDB("@InterlineAmt", dr["InterlineAmt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineAmt"]);
                        paramFRGHT_BL[44] = new ParameterInfoOleDB("@LmDist", dr["LmDist"].ToString().Trim() == string.Empty ? 0 : dr["LmDist"]);
                        paramFRGHT_BL[45] = new ParameterInfoOleDB("@LmPkupActualDtm", dr["LmPkupActualDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmPkupActualDtm"]);
                        paramFRGHT_BL[46] = new ParameterInfoOleDB("@LmAtaDtm", dr["LmAtaDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmAtaDtm"]);
                        paramFRGHT_BL[47] = new ParameterInfoOleDB("@PriceLaneLabl", dr["PriceLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PriceLaneLabl"]);
                        paramFRGHT_BL[48] = new ParameterInfoOleDB("@LmLaneLabl", dr["LmLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmLaneLabl"]);
                        paramFRGHT_BL[49] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);

                        paramFRGHT_BL[50] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFRGHT_BL[51] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFRGHT_BL[52] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFRGHT_BL[53] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        dr.RejectChanges();
                        paramFRGHT_BL[54] = new ParameterInfoOleDB("@FBId", dr["FbId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramFRGHT_BL = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramFRGHT_BL[0] = new ParameterInfoOleDB("@FbId", dr["FbId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);
                    }
                }
                #endregion
                #region FB_LN
                foreach (DataRow dr in dsBatch.Tables["FBLn"].Rows)
                {
                    ParameterInfoOleDB[] paramFB_LN;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramFB_LN = new ParameterInfoOleDB[25];
                        paramFB_LN[0] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        paramFB_LN[1] = new ParameterInfoOleDB("@LineItemNum", dr["LineItemNum"]);
                        paramFB_LN[2] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFB_LN[3] = new ParameterInfoOleDB("@QtyLabl", dr["QtyLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["QtyLabl"]);
                        paramFB_LN[4] = new ParameterInfoOleDB("@ChrgDesc", dr["ChrgDesc"].ToString().Trim() == string.Empty ? DBNull.Value : dr["ChrgDesc"]);
                        paramFB_LN[5] = new ParameterInfoOleDB("@RateAmt", dr["RateAmt"].ToString().Trim() == string.Empty ? 0 : dr["RateAmt"]);
                        paramFB_LN[6] = new ParameterInfoOleDB("@RateType", dr["RateType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateType"]);
                        paramFB_LN[7] = new ParameterInfoOleDB("@RateUntLabl", dr["RateUntLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateUntLabl"]);
                        paramFB_LN[8] = new ParameterInfoOleDB("@ChrgAmt", dr["ChrgAmt"].ToString().Trim() == string.Empty ? 0 : dr["ChrgAmt"]);
                        paramFB_LN[9] = new ParameterInfoOleDB("@CurrencyQual", dr["CurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CurrencyQual"]);
                        paramFB_LN[10] = new ParameterInfoOleDB("@Cat", dr["Cat"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Cat"]);
                        paramFB_LN[11] = new ParameterInfoOleDB("@PkgType", dr["PkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PkgType"]);
                        paramFB_LN[12] = new ParameterInfoOleDB("@PcsCnt", dr["PcsCnt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PcsCnt"]);
                        paramFB_LN[13] = new ParameterInfoOleDB("@LnChrgCode", dr["LnChrgCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnChrgCode"]);
                        paramFB_LN[14] = new ParameterInfoOleDB("@LnActualWt", dr["LnActualWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnActualWt"]);
                        paramFB_LN[15] = new ParameterInfoOleDB("@LnRateAsWt", dr["LnRateAsWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnRateAsWt"]);
                        paramFB_LN[16] = new ParameterInfoOleDB("@CmdtyClass", dr["CmdtyClass"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CmdtyClass"]);
                        paramFB_LN[17] = new ParameterInfoOleDB("@Facsimile01", dr["Facsimile01"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile01"]);
                        paramFB_LN[18] = new ParameterInfoOleDB("@Facsimile02", dr["Facsimile02"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile02"]);
                        paramFB_LN[19] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_LN[20] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_LN[21] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_LN[22] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_LN[23] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_LN[24] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);

                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFB_LN, CommandType.Text, paramFB_LN);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramFB_LN = new ParameterInfoOleDB[27];
                        paramFB_LN[0] = new ParameterInfoOleDB("@FbIdNew", dr["FBId"]);
                        paramFB_LN[1] = new ParameterInfoOleDB("@LineItemNumNew", dr["LineItemNum"]);
                        paramFB_LN[2] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFB_LN[3] = new ParameterInfoOleDB("@QtyLabl", dr["QtyLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["QtyLabl"]);
                        paramFB_LN[4] = new ParameterInfoOleDB("@ChrgDesc", dr["ChrgDesc"].ToString().Trim() == string.Empty ? DBNull.Value : dr["ChrgDesc"]);
                        paramFB_LN[5] = new ParameterInfoOleDB("@RateAmt", dr["RateAmt"].ToString().Trim() == string.Empty ? 0 : dr["RateAmt"]);
                        paramFB_LN[6] = new ParameterInfoOleDB("@RateType", dr["RateType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateType"]);
                        paramFB_LN[7] = new ParameterInfoOleDB("@RateUntLabl", dr["RateUntLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateUntLabl"]);
                        paramFB_LN[8] = new ParameterInfoOleDB("@ChrgAmt", dr["ChrgAmt"].ToString().Trim() == string.Empty ? 0 : dr["ChrgAmt"]);
                        paramFB_LN[9] = new ParameterInfoOleDB("@CurrencyQual", dr["CurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CurrencyQual"]);
                        paramFB_LN[10] = new ParameterInfoOleDB("@Cat", dr["Cat"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Cat"]);
                        paramFB_LN[11] = new ParameterInfoOleDB("@PkgType", dr["PkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PkgType"]);
                        paramFB_LN[12] = new ParameterInfoOleDB("@PcsCnt", dr["PcsCnt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PcsCnt"]);
                        paramFB_LN[13] = new ParameterInfoOleDB("@LnChrgCode", dr["LnChrgCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnChrgCode"]);
                        paramFB_LN[14] = new ParameterInfoOleDB("@LnActualWt", dr["LnActualWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnActualWt"]);
                        paramFB_LN[15] = new ParameterInfoOleDB("@LnRateAsWt", dr["LnRateAsWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnRateAsWt"]);
                        paramFB_LN[16] = new ParameterInfoOleDB("@CmdtyClass", dr["CmdtyClass"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CmdtyClass"]);
                        paramFB_LN[17] = new ParameterInfoOleDB("@Facsimile01", dr["Facsimile01"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile01"]);
                        paramFB_LN[18] = new ParameterInfoOleDB("@Facsimile02", dr["Facsimile02"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile02"]);
                        paramFB_LN[19] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_LN[20] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_LN[21] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_LN[22] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_LN[23] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_LN[24] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);
                        dr.RejectChanges();
                        paramFB_LN[25] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        paramFB_LN[26] = new ParameterInfoOleDB("@LineItemNum", dr["LineItemNum"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryFB_LN, CommandType.Text, paramFB_LN);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramFB_LN = new ParameterInfoOleDB[2];
                        dr.RejectChanges();
                        paramFB_LN[0] = new ParameterInfoOleDB("@FbId", dr["FbId"]);
                        paramFB_LN[1] = new ParameterInfoOleDB("@LineItemNum", dr["LineItemNum"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryFB_LN, CommandType.Text, paramFB_LN);
                    }
                }
                #endregion
                #region FXI
                foreach (DataRow dr in dsBatch.Tables["FXI"].Rows)
                {
                    ParameterInfoOleDB[] paramFB_FXI;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramFB_FXI = new ParameterInfoOleDB[125];
                        paramFB_FXI[0] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        paramFB_FXI[1] = new ParameterInfoOleDB("@InvPageNum", dr["InvPageNum"].ToString().Trim() == string.Empty ? 1 : dr["InvPageNum"]);
                        paramFB_FXI[2] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramFB_FXI[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFB_FXI[4] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        paramFB_FXI[5] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_FXI[6] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_FXI[7] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_FXI[8] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_FXI[9] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_FXI[10] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);
                        paramFB_FXI[11] = new ParameterInfoOleDB("@T007", dr["T007"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T007"]);
                        paramFB_FXI[12] = new ParameterInfoOleDB("@T008", dr["T008"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T008"]);
                        paramFB_FXI[13] = new ParameterInfoOleDB("@T009", dr["T009"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T009"]);
                        paramFB_FXI[14] = new ParameterInfoOleDB("@T010", dr["T010"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T010"]);
                        paramFB_FXI[15] = new ParameterInfoOleDB("@T011", dr["T011"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T011"]);
                        paramFB_FXI[16] = new ParameterInfoOleDB("@T012", dr["T012"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T012"]);
                        paramFB_FXI[17] = new ParameterInfoOleDB("@T013", dr["T013"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T013"]);
                        paramFB_FXI[18] = new ParameterInfoOleDB("@T014", dr["T014"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T014"]);
                        paramFB_FXI[19] = new ParameterInfoOleDB("@T015", dr["T015"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T015"]);
                        paramFB_FXI[20] = new ParameterInfoOleDB("@T016", dr["T016"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T016"]);
                        paramFB_FXI[21] = new ParameterInfoOleDB("@T017", dr["T017"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T017"]);
                        paramFB_FXI[22] = new ParameterInfoOleDB("@T018", dr["T018"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T018"]);
                        paramFB_FXI[23] = new ParameterInfoOleDB("@T019", dr["T019"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T019"]);
                        paramFB_FXI[24] = new ParameterInfoOleDB("@T020", dr["T020"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T020"]);
                        paramFB_FXI[25] = new ParameterInfoOleDB("@T021", dr["T021"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T021"]);
                        paramFB_FXI[26] = new ParameterInfoOleDB("@T022", dr["T022"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T022"]);
                        paramFB_FXI[27] = new ParameterInfoOleDB("@T023", dr["T023"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T023"]);
                        paramFB_FXI[28] = new ParameterInfoOleDB("@T024", dr["T024"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T024"]);
                        paramFB_FXI[29] = new ParameterInfoOleDB("@T025", dr["T025"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T025"]);
                        paramFB_FXI[30] = new ParameterInfoOleDB("@T026", dr["T026"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T026"]);
                        paramFB_FXI[31] = new ParameterInfoOleDB("@T027", dr["T027"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T027"]);
                        paramFB_FXI[32] = new ParameterInfoOleDB("@T028", dr["T028"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T028"]);
                        paramFB_FXI[33] = new ParameterInfoOleDB("@T029", dr["T029"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T029"]);
                        paramFB_FXI[34] = new ParameterInfoOleDB("@T030", dr["T030"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T030"]);
                        paramFB_FXI[35] = new ParameterInfoOleDB("@T031", dr["T031"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T031"]);
                        paramFB_FXI[36] = new ParameterInfoOleDB("@T032", dr["T032"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T032"]);
                        paramFB_FXI[37] = new ParameterInfoOleDB("@T033", dr["T033"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T033"]);
                        paramFB_FXI[38] = new ParameterInfoOleDB("@T034", dr["T034"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T034"]);
                        paramFB_FXI[39] = new ParameterInfoOleDB("@T035", dr["T035"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T035"]);
                        paramFB_FXI[40] = new ParameterInfoOleDB("@T036", dr["T036"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T036"]);
                        paramFB_FXI[41] = new ParameterInfoOleDB("@T037", dr["T037"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T037"]);
                        paramFB_FXI[42] = new ParameterInfoOleDB("@T038", dr["T038"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T038"]);
                        paramFB_FXI[43] = new ParameterInfoOleDB("@T039", dr["T039"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T039"]);
                        paramFB_FXI[44] = new ParameterInfoOleDB("@T040", dr["T040"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T040"]);
                        paramFB_FXI[45] = new ParameterInfoOleDB("@T041", dr["T041"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T041"]);
                        paramFB_FXI[46] = new ParameterInfoOleDB("@T042", dr["T042"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T042"]);
                        paramFB_FXI[47] = new ParameterInfoOleDB("@T043", dr["T043"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T043"]);
                        paramFB_FXI[48] = new ParameterInfoOleDB("@T044", dr["T044"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T044"]);
                        paramFB_FXI[49] = new ParameterInfoOleDB("@T045", dr["T045"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T045"]);
                        paramFB_FXI[50] = new ParameterInfoOleDB("@T046", dr["T046"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T046"]);
                        paramFB_FXI[51] = new ParameterInfoOleDB("@T047", dr["T047"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T047"]);
                        paramFB_FXI[52] = new ParameterInfoOleDB("@T048", dr["T048"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T048"]);
                        paramFB_FXI[53] = new ParameterInfoOleDB("@T049", dr["T049"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T049"]);
                        paramFB_FXI[54] = new ParameterInfoOleDB("@T050", dr["T050"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T050"]);
                        paramFB_FXI[55] = new ParameterInfoOleDB("@T051", dr["T051"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T051"]);
                        paramFB_FXI[56] = new ParameterInfoOleDB("@T052", dr["T052"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T052"]);
                        paramFB_FXI[57] = new ParameterInfoOleDB("@T053", dr["T053"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T053"]);
                        paramFB_FXI[58] = new ParameterInfoOleDB("@T054", dr["T054"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T054"]);
                        paramFB_FXI[59] = new ParameterInfoOleDB("@T055", dr["T055"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T055"]);
                        paramFB_FXI[60] = new ParameterInfoOleDB("@T056", dr["T056"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T056"]);
                        paramFB_FXI[61] = new ParameterInfoOleDB("@T057", dr["T057"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T057"]);
                        paramFB_FXI[62] = new ParameterInfoOleDB("@T058", dr["T058"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T058"]);
                        paramFB_FXI[63] = new ParameterInfoOleDB("@T059", dr["T059"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T059"]);
                        paramFB_FXI[64] = new ParameterInfoOleDB("@T060", dr["T060"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T060"]);
                        paramFB_FXI[65] = new ParameterInfoOleDB("@T061", dr["T061"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T061"]);
                        paramFB_FXI[66] = new ParameterInfoOleDB("@T062", dr["T062"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T062"]);
                        paramFB_FXI[67] = new ParameterInfoOleDB("@T063", dr["T063"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T063"]);
                        paramFB_FXI[68] = new ParameterInfoOleDB("@T064", dr["T064"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T064"]);
                        paramFB_FXI[69] = new ParameterInfoOleDB("@T065", dr["T065"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T065"]);
                        paramFB_FXI[70] = new ParameterInfoOleDB("@T066", dr["T066"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T066"]);
                        paramFB_FXI[71] = new ParameterInfoOleDB("@T067", dr["T067"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T067"]);
                        paramFB_FXI[72] = new ParameterInfoOleDB("@T068", dr["T068"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T068"]);
                        paramFB_FXI[73] = new ParameterInfoOleDB("@T069", dr["T069"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T069"]);
                        paramFB_FXI[74] = new ParameterInfoOleDB("@T070", dr["T070"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T070"]);
                        paramFB_FXI[75] = new ParameterInfoOleDB("@T071", dr["T071"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T071"]);
                        paramFB_FXI[76] = new ParameterInfoOleDB("@T072", dr["T072"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T072"]);
                        paramFB_FXI[77] = new ParameterInfoOleDB("@T073", dr["T073"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T073"]);
                        paramFB_FXI[78] = new ParameterInfoOleDB("@T074", dr["T074"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T074"]);
                        paramFB_FXI[79] = new ParameterInfoOleDB("@T075", dr["T075"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T075"]);
                        paramFB_FXI[80] = new ParameterInfoOleDB("@T076", dr["T076"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T076"]);
                        paramFB_FXI[81] = new ParameterInfoOleDB("@T077", dr["T077"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T077"]);
                        paramFB_FXI[82] = new ParameterInfoOleDB("@T078", dr["T078"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T078"]);
                        paramFB_FXI[83] = new ParameterInfoOleDB("@T079", dr["T079"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T079"]);
                        paramFB_FXI[84] = new ParameterInfoOleDB("@T080", dr["T080"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T080"]);
                        paramFB_FXI[85] = new ParameterInfoOleDB("@T081", dr["T081"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T081"]);
                        paramFB_FXI[86] = new ParameterInfoOleDB("@T082", dr["T082"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T082"]);
                        paramFB_FXI[87] = new ParameterInfoOleDB("@T083", dr["T083"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T083"]);
                        paramFB_FXI[88] = new ParameterInfoOleDB("@T084", dr["T084"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T084"]);
                        paramFB_FXI[89] = new ParameterInfoOleDB("@T085", dr["T085"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T085"]);
                        paramFB_FXI[90] = new ParameterInfoOleDB("@T086", dr["T086"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T086"]);
                        paramFB_FXI[91] = new ParameterInfoOleDB("@T087", dr["T087"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T087"]);
                        paramFB_FXI[92] = new ParameterInfoOleDB("@T088", dr["T088"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T088"]);
                        paramFB_FXI[93] = new ParameterInfoOleDB("@T089", dr["T089"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T089"]);
                        paramFB_FXI[94] = new ParameterInfoOleDB("@T090", dr["T090"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T090"]);
                        paramFB_FXI[95] = new ParameterInfoOleDB("@T091", dr["T091"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T091"]);
                        paramFB_FXI[96] = new ParameterInfoOleDB("@T092", dr["T092"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T092"]);
                        paramFB_FXI[97] = new ParameterInfoOleDB("@T093", dr["T093"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T093"]);
                        paramFB_FXI[98] = new ParameterInfoOleDB("@T094", dr["T094"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T094"]);
                        paramFB_FXI[99] = new ParameterInfoOleDB("@T095", dr["T095"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T095"]);
                        paramFB_FXI[100] = new ParameterInfoOleDB("@T096", dr["T096"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T096"]);
                        paramFB_FXI[101] = new ParameterInfoOleDB("@T097", dr["T097"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T097"]);
                        paramFB_FXI[102] = new ParameterInfoOleDB("@T098", dr["T098"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T098"]);
                        paramFB_FXI[103] = new ParameterInfoOleDB("@T099", dr["T099"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T099"]);
                        paramFB_FXI[104] = new ParameterInfoOleDB("@T100", dr["T100"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T100"]);
                        paramFB_FXI[105] = new ParameterInfoOleDB("@T101", dr["T101"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T101"]);
                        paramFB_FXI[106] = new ParameterInfoOleDB("@T102", dr["T102"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T102"]);
                        paramFB_FXI[107] = new ParameterInfoOleDB("@T103", dr["T103"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T103"]);
                        paramFB_FXI[108] = new ParameterInfoOleDB("@T104", dr["T104"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T104"]);
                        paramFB_FXI[109] = new ParameterInfoOleDB("@T105", dr["T105"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T105"]);
                        paramFB_FXI[110] = new ParameterInfoOleDB("@T106", dr["T106"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T106"]);
                        paramFB_FXI[111] = new ParameterInfoOleDB("@T107", dr["T107"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T107"]);
                        paramFB_FXI[112] = new ParameterInfoOleDB("@T108", dr["T108"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T108"]);
                        paramFB_FXI[113] = new ParameterInfoOleDB("@T109", dr["T109"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T109"]);
                        paramFB_FXI[114] = new ParameterInfoOleDB("@T110", dr["T110"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T110"]);
                        paramFB_FXI[115] = new ParameterInfoOleDB("@T111", dr["T111"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T111"]);
                        paramFB_FXI[116] = new ParameterInfoOleDB("@T112", dr["T112"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T112"]);
                        paramFB_FXI[117] = new ParameterInfoOleDB("@T113", dr["T113"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T113"]);
                        paramFB_FXI[118] = new ParameterInfoOleDB("@T114", dr["T114"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T114"]);
                        paramFB_FXI[119] = new ParameterInfoOleDB("@T115", dr["T115"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T115"]);
                        paramFB_FXI[120] = new ParameterInfoOleDB("@T116", dr["T116"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T116"]);
                        paramFB_FXI[121] = new ParameterInfoOleDB("@T117", dr["T117"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T117"]);
                        paramFB_FXI[122] = new ParameterInfoOleDB("@T118", dr["T118"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T118"]);
                        paramFB_FXI[123] = new ParameterInfoOleDB("@T119", dr["T119"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T119"]);
                        paramFB_FXI[124] = new ParameterInfoOleDB("@T120", dr["T120"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T120"]);

                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFXI, CommandType.Text, paramFB_FXI);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramFB_FXI = new ParameterInfoOleDB[126];
                        paramFB_FXI[0] = new ParameterInfoOleDB("@FbIdNew", dr["FBId"]);
                        paramFB_FXI[1] = new ParameterInfoOleDB("@InvPageNum", dr["InvPageNum"].ToString().Trim() == string.Empty ? 1 : dr["InvPageNum"]);
                        paramFB_FXI[2] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramFB_FXI[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFB_FXI[4] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        paramFB_FXI[5] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_FXI[6] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_FXI[7] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_FXI[8] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_FXI[9] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_FXI[10] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);
                        paramFB_FXI[11] = new ParameterInfoOleDB("@T007", dr["T007"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T007"]);
                        paramFB_FXI[12] = new ParameterInfoOleDB("@T008", dr["T008"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T008"]);
                        paramFB_FXI[13] = new ParameterInfoOleDB("@T009", dr["T009"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T009"]);
                        paramFB_FXI[14] = new ParameterInfoOleDB("@T010", dr["T010"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T010"]);
                        paramFB_FXI[15] = new ParameterInfoOleDB("@T011", dr["T011"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T011"]);
                        paramFB_FXI[16] = new ParameterInfoOleDB("@T012", dr["T012"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T012"]);
                        paramFB_FXI[17] = new ParameterInfoOleDB("@T013", dr["T013"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T013"]);
                        paramFB_FXI[18] = new ParameterInfoOleDB("@T014", dr["T014"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T014"]);
                        paramFB_FXI[19] = new ParameterInfoOleDB("@T015", dr["T015"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T015"]);
                        paramFB_FXI[20] = new ParameterInfoOleDB("@T016", dr["T016"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T016"]);
                        paramFB_FXI[21] = new ParameterInfoOleDB("@T017", dr["T017"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T017"]);
                        paramFB_FXI[22] = new ParameterInfoOleDB("@T018", dr["T018"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T018"]);
                        paramFB_FXI[23] = new ParameterInfoOleDB("@T019", dr["T019"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T019"]);
                        paramFB_FXI[24] = new ParameterInfoOleDB("@T020", dr["T020"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T020"]);
                        paramFB_FXI[25] = new ParameterInfoOleDB("@T021", dr["T021"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T021"]);
                        paramFB_FXI[26] = new ParameterInfoOleDB("@T022", dr["T022"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T022"]);
                        paramFB_FXI[27] = new ParameterInfoOleDB("@T023", dr["T023"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T023"]);
                        paramFB_FXI[28] = new ParameterInfoOleDB("@T024", dr["T024"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T024"]);
                        paramFB_FXI[29] = new ParameterInfoOleDB("@T025", dr["T025"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T025"]);
                        paramFB_FXI[30] = new ParameterInfoOleDB("@T026", dr["T026"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T026"]);
                        paramFB_FXI[31] = new ParameterInfoOleDB("@T027", dr["T027"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T027"]);
                        paramFB_FXI[32] = new ParameterInfoOleDB("@T028", dr["T028"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T028"]);
                        paramFB_FXI[33] = new ParameterInfoOleDB("@T029", dr["T029"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T029"]);
                        paramFB_FXI[34] = new ParameterInfoOleDB("@T030", dr["T030"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T030"]);
                        paramFB_FXI[35] = new ParameterInfoOleDB("@T031", dr["T031"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T031"]);
                        paramFB_FXI[36] = new ParameterInfoOleDB("@T032", dr["T032"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T032"]);
                        paramFB_FXI[37] = new ParameterInfoOleDB("@T033", dr["T033"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T033"]);
                        paramFB_FXI[38] = new ParameterInfoOleDB("@T034", dr["T034"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T034"]);
                        paramFB_FXI[39] = new ParameterInfoOleDB("@T035", dr["T035"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T035"]);
                        paramFB_FXI[40] = new ParameterInfoOleDB("@T036", dr["T036"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T036"]);
                        paramFB_FXI[41] = new ParameterInfoOleDB("@T037", dr["T037"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T037"]);
                        paramFB_FXI[42] = new ParameterInfoOleDB("@T038", dr["T038"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T038"]);
                        paramFB_FXI[43] = new ParameterInfoOleDB("@T039", dr["T039"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T039"]);
                        paramFB_FXI[44] = new ParameterInfoOleDB("@T040", dr["T040"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T040"]);
                        paramFB_FXI[45] = new ParameterInfoOleDB("@T041", dr["T041"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T041"]);
                        paramFB_FXI[46] = new ParameterInfoOleDB("@T042", dr["T042"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T042"]);
                        paramFB_FXI[47] = new ParameterInfoOleDB("@T043", dr["T043"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T043"]);
                        paramFB_FXI[48] = new ParameterInfoOleDB("@T044", dr["T044"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T044"]);
                        paramFB_FXI[49] = new ParameterInfoOleDB("@T045", dr["T045"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T045"]);
                        paramFB_FXI[50] = new ParameterInfoOleDB("@T046", dr["T046"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T046"]);
                        paramFB_FXI[51] = new ParameterInfoOleDB("@T047", dr["T047"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T047"]);
                        paramFB_FXI[52] = new ParameterInfoOleDB("@T048", dr["T048"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T048"]);
                        paramFB_FXI[53] = new ParameterInfoOleDB("@T049", dr["T049"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T049"]);
                        paramFB_FXI[54] = new ParameterInfoOleDB("@T050", dr["T050"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T050"]);
                        paramFB_FXI[55] = new ParameterInfoOleDB("@T051", dr["T051"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T051"]);
                        paramFB_FXI[56] = new ParameterInfoOleDB("@T052", dr["T052"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T052"]);
                        paramFB_FXI[57] = new ParameterInfoOleDB("@T053", dr["T053"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T053"]);
                        paramFB_FXI[58] = new ParameterInfoOleDB("@T054", dr["T054"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T054"]);
                        paramFB_FXI[59] = new ParameterInfoOleDB("@T055", dr["T055"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T055"]);
                        paramFB_FXI[60] = new ParameterInfoOleDB("@T056", dr["T056"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T056"]);
                        paramFB_FXI[61] = new ParameterInfoOleDB("@T057", dr["T057"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T057"]);
                        paramFB_FXI[62] = new ParameterInfoOleDB("@T058", dr["T058"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T058"]);
                        paramFB_FXI[63] = new ParameterInfoOleDB("@T059", dr["T059"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T059"]);
                        paramFB_FXI[64] = new ParameterInfoOleDB("@T060", dr["T060"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T060"]);
                        paramFB_FXI[65] = new ParameterInfoOleDB("@T061", dr["T061"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T061"]);
                        paramFB_FXI[66] = new ParameterInfoOleDB("@T062", dr["T062"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T062"]);
                        paramFB_FXI[67] = new ParameterInfoOleDB("@T063", dr["T063"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T063"]);
                        paramFB_FXI[68] = new ParameterInfoOleDB("@T064", dr["T064"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T064"]);
                        paramFB_FXI[69] = new ParameterInfoOleDB("@T065", dr["T065"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T065"]);
                        paramFB_FXI[70] = new ParameterInfoOleDB("@T066", dr["T066"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T066"]);
                        paramFB_FXI[71] = new ParameterInfoOleDB("@T067", dr["T067"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T067"]);
                        paramFB_FXI[72] = new ParameterInfoOleDB("@T068", dr["T068"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T068"]);
                        paramFB_FXI[73] = new ParameterInfoOleDB("@T069", dr["T069"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T069"]);
                        paramFB_FXI[74] = new ParameterInfoOleDB("@T070", dr["T070"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T070"]);
                        paramFB_FXI[75] = new ParameterInfoOleDB("@T071", dr["T071"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T071"]);
                        paramFB_FXI[76] = new ParameterInfoOleDB("@T072", dr["T072"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T072"]);
                        paramFB_FXI[77] = new ParameterInfoOleDB("@T073", dr["T073"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T073"]);
                        paramFB_FXI[78] = new ParameterInfoOleDB("@T074", dr["T074"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T074"]);
                        paramFB_FXI[79] = new ParameterInfoOleDB("@T075", dr["T075"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T075"]);
                        paramFB_FXI[80] = new ParameterInfoOleDB("@T076", dr["T076"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T076"]);
                        paramFB_FXI[81] = new ParameterInfoOleDB("@T077", dr["T077"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T077"]);
                        paramFB_FXI[82] = new ParameterInfoOleDB("@T078", dr["T078"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T078"]);
                        paramFB_FXI[83] = new ParameterInfoOleDB("@T079", dr["T079"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T079"]);
                        paramFB_FXI[84] = new ParameterInfoOleDB("@T080", dr["T080"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T080"]);
                        paramFB_FXI[85] = new ParameterInfoOleDB("@T081", dr["T081"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T081"]);
                        paramFB_FXI[86] = new ParameterInfoOleDB("@T082", dr["T082"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T082"]);
                        paramFB_FXI[87] = new ParameterInfoOleDB("@T083", dr["T083"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T083"]);
                        paramFB_FXI[88] = new ParameterInfoOleDB("@T084", dr["T084"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T084"]);
                        paramFB_FXI[89] = new ParameterInfoOleDB("@T085", dr["T085"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T085"]);
                        paramFB_FXI[90] = new ParameterInfoOleDB("@T086", dr["T086"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T086"]);
                        paramFB_FXI[91] = new ParameterInfoOleDB("@T087", dr["T087"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T087"]);
                        paramFB_FXI[92] = new ParameterInfoOleDB("@T088", dr["T088"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T088"]);
                        paramFB_FXI[93] = new ParameterInfoOleDB("@T089", dr["T089"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T089"]);
                        paramFB_FXI[94] = new ParameterInfoOleDB("@T090", dr["T090"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T090"]);
                        paramFB_FXI[95] = new ParameterInfoOleDB("@T091", dr["T091"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T091"]);
                        paramFB_FXI[96] = new ParameterInfoOleDB("@T092", dr["T092"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T092"]);
                        paramFB_FXI[97] = new ParameterInfoOleDB("@T093", dr["T093"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T093"]);
                        paramFB_FXI[98] = new ParameterInfoOleDB("@T094", dr["T094"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T094"]);
                        paramFB_FXI[99] = new ParameterInfoOleDB("@T095", dr["T095"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T095"]);
                        paramFB_FXI[100] = new ParameterInfoOleDB("@T096", dr["T096"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T096"]);
                        paramFB_FXI[101] = new ParameterInfoOleDB("@T097", dr["T097"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T097"]);
                        paramFB_FXI[102] = new ParameterInfoOleDB("@T098", dr["T098"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T098"]);
                        paramFB_FXI[103] = new ParameterInfoOleDB("@T099", dr["T099"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T099"]);
                        paramFB_FXI[104] = new ParameterInfoOleDB("@T100", dr["T100"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T100"]);
                        paramFB_FXI[105] = new ParameterInfoOleDB("@T101", dr["T101"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T101"]);
                        paramFB_FXI[106] = new ParameterInfoOleDB("@T102", dr["T102"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T102"]);
                        paramFB_FXI[107] = new ParameterInfoOleDB("@T103", dr["T103"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T103"]);
                        paramFB_FXI[108] = new ParameterInfoOleDB("@T104", dr["T104"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T104"]);
                        paramFB_FXI[109] = new ParameterInfoOleDB("@T105", dr["T105"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T105"]);
                        paramFB_FXI[110] = new ParameterInfoOleDB("@T106", dr["T106"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T106"]);
                        paramFB_FXI[111] = new ParameterInfoOleDB("@T107", dr["T107"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T107"]);
                        paramFB_FXI[112] = new ParameterInfoOleDB("@T108", dr["T108"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T108"]);
                        paramFB_FXI[113] = new ParameterInfoOleDB("@T109", dr["T109"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T109"]);
                        paramFB_FXI[114] = new ParameterInfoOleDB("@T110", dr["T110"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T110"]);
                        paramFB_FXI[115] = new ParameterInfoOleDB("@T111", dr["T111"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T111"]);
                        paramFB_FXI[116] = new ParameterInfoOleDB("@T112", dr["T112"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T112"]);
                        paramFB_FXI[117] = new ParameterInfoOleDB("@T113", dr["T113"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T113"]);
                        paramFB_FXI[118] = new ParameterInfoOleDB("@T114", dr["T114"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T114"]);
                        paramFB_FXI[119] = new ParameterInfoOleDB("@T115", dr["T115"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T115"]);
                        paramFB_FXI[120] = new ParameterInfoOleDB("@T116", dr["T116"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T116"]);
                        paramFB_FXI[121] = new ParameterInfoOleDB("@T117", dr["T117"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T117"]);
                        paramFB_FXI[122] = new ParameterInfoOleDB("@T118", dr["T118"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T118"]);
                        paramFB_FXI[123] = new ParameterInfoOleDB("@T119", dr["T119"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T119"]);
                        paramFB_FXI[124] = new ParameterInfoOleDB("@T120", dr["T120"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T120"]);
                        dr.RejectChanges();
                        paramFB_FXI[125] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryFXI, CommandType.Text, paramFB_FXI);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramFB_FXI = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramFB_FXI[0] = new ParameterInfoOleDB("@FbId", dr["FbId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryFXI, CommandType.Text, paramFB_FXI);
                    }
                }
                #endregion
                dalMXXDatabase.CommitTransaction();                
                retval = true;
            }
            catch (Exception e)
            {
                dalMXXDatabase.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dalMXXDatabase.CloseDB();                
            }
            return retval;
        }

        [WebMethod]
        public bool restartBatch(string MXXDatabase)
        {
            bool retval = false;
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", "MXX" + MXXDatabase.Trim() + ".mdb");

            try
            {
                dalMXXDatabase.OpenDB();
                dalMXXDatabase.BeginTransaction();
                dalMXXDatabase.ExecuteNonQuery("DELETE FROM batmdb_INV_BAT", CommandType.Text);
                dalMXXDatabase.ExecuteNonQuery("DELETE FROM batmdb_INVOICE", CommandType.Text);
                dalMXXDatabase.ExecuteNonQuery("DELETE FROM batmdb_FRGHT_BL", CommandType.Text);
                dalMXXDatabase.ExecuteNonQuery("DELETE FROM batmdb_FB_LN", CommandType.Text);
                dalMXXDatabase.ExecuteNonQuery("DELETE FROM batmdb_FXI", CommandType.Text);
                dalMXXDatabase.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dalMXXDatabase.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dalMXXDatabase.CloseDB();
            }
            return retval;                
        }

        [WebMethod]
        public bool isAllowBatchStart(string batCtrlNum)
        {
            bool retval = false;
            DataSet ds = new DataSet();
            string query = @"SELECT Oper_Init AS [Operator]
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
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
        public bool isAllowEdit(string batCtrlNum, string systemUserName)
        {
            bool retval = false;

            DataSet ds = new DataSet();
            string query = @"SELECT Batch_Status AS [Batch Status]
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";

            string queryUpdate = @"UPDATE Batch_DE
                                    SET Batch_Status = 'OPENDE'
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                dal.BeginTransaction();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                if (ds.Tables[0].Rows.Count > 0 && (ds.Tables[0].Rows[0][0].ToString() == "IN DE" || ds.Tables[0].Rows[0][0].ToString() == "RE-KEY" || ds.Tables[0].Rows[0][0].ToString() == "REVIEW"))
                {                    
                    dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                    this.BatchAuditTrailInsert(batCtrlNum, "101", dal, systemUserName);//auditTrailBatch(batCtrlNum, "101");
                    dal.CommitTransaction();
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

        [WebMethod]
        public bool startBatch(string batCtrlNum, string UserInitials)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE Batch_DE
                                    SET Oper_Init = @Oper_Init,
                                        DE_START_DTM = @UTCDate,
                                        DE_File_Name = @DE_File_Name
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                   UPDATE Batch_DE_ext
                                    SET f_DE_START_DTM = @UTCDate
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();                
                ParameterInfo[] param = new ParameterInfo[4];
                param[0] = new ParameterInfo("@Oper_Init", UserInitials);//CommonUserLogin.getUser().UserInitials);
                param[1] = new ParameterInfo("@UTCDate", GetServerDate(dal));//this.GetServerDate());
                param[2] = new ParameterInfo("@DE_File_Name", "MXX" + batCtrlNum + ".mdb");
                param[3] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);                
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
        public bool isAllowUserEntry(string batCtrlNum, string UserInitials)
        {
            bool retval = false;
            bool isRootBatch = false;

            DataSet ds = new DataSet();
            DataSet dsRoot = new DataSet();
            string query = @"SELECT Oper_Init AS [Operator]
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";

            string rootQuery = @"SELECT COUNT(*) FROM Batch_DE_Split A 
                                INNER JOIN Batch_DE_Split B ON A.Bat_Ctrl_Num_Root = B.Bat_Ctrl_Num_Root 
                                WHERE B.Bat_Ctrl_Num_root = @Bat_Ctrl_Num";

            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                ParameterInfo[] paramRoot = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                paramRoot[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                dsRoot = dal.ExecuteDataSet(rootQuery, CommandType.Text, paramRoot);
                isRootBatch = Convert.ToInt32(dsRoot.Tables[0].Rows[0][0]) > 0;
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != null)
                {
					if (ds.Tables[0].Rows[0][0].ToString().Trim() == UserInitials)//CommonUserLogin.getUser().UserInitials.Trim())
						retval = true;
                }
                retval = isRootBatch ? true : retval; 
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
        public bool sendForReview(string batCtrlNum)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE Batch_DE
                                    SET DE_FIN_DTM = @UTCDate,
                                    Batch_Status = 'REVIEW'
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                   UPDATE Batch_DE_ext
                                    SET f_DE_FIN_DTM = @UTCDate, 
                                        TransmissionId = 0
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                param[1] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);                
                affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);                
                dal.CommitTransaction();
                retval = true;
            }
            catch(Exception e)
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
        public bool updateStatus(string batCtrlNum, string status)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate;
            try
            {
                if (status == "RE-KEY")
                    queryUpdate = @"UPDATE Batch_DE
                                    SET Batch_Status = @Status
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                   UPDATE Batch_DE_ext
                                    SET TransmissionId = 0
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
                else
                    queryUpdate = @"UPDATE Batch_DE
                                    SET Batch_Status = @Status
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@Status", status);
                param[1] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);                
                dal.OpenDB();
                dal.BeginTransaction();
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
        public bool saveBatchObj(DataSet dsBatch, string MXXDatabase, string OwnerKey)
        {
            bool retval = false;
            FXI fxi;
            InvBat invBat = new InvBat();
            Invoice invoice;
            FrghtBl frghtBl;
            FbLn fbLn;
            try
            {
                #region InvBat Update
                if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                {
                    dsBatch.Tables["InvBat"].Rows[0]["BatInvCnt"] = dsBatch.Tables["Invoice"].Rows.Count;
                    dsBatch.Tables["InvBat"].Rows[0]["BatFbCnt"] = dsBatch.Tables["FB"].Rows.Count;
                    dsBatch.Tables["InvBat"].Rows[0]["BatStat"] = "Open";
                    dsBatch.Tables["InvBat"].Rows[0]["BatType"] = "Manual";
                    invBat = this.SetInvBatProperties(invBat, dsBatch.Tables["InvBat"].Rows[0]);
                    #region Invoice update
                    int invoiceCount = 0;
                    foreach (DataRow newRowInvoice in dsBatch.Tables["Invoice"].Select(string.Format("LocIdRemit = '{0}'", invBat.BatLocIdRemit)))
                    {
                        invoice = new Invoice(invBat);
                        invoice = this.SetInvoiceProperties(invoice, newRowInvoice);
                        invBat.Invoices.Add(invoice);
                        #region FrghtBl update
                        int frghtBLCount = 0;
                        foreach (DataRow newRowFrghtBL in dsBatch.Tables["FB"].Select(string.Format("InvId = '{0}'", invBat.Invoices[invoiceCount].InvId)))
                        {
                            frghtBl = new FrghtBl(invBat, invBat.Invoices[invoiceCount]);
                            frghtBl = this.SetFrghtBlProperties(frghtBl, newRowFrghtBL);
                            invBat.Invoices[invoiceCount].FrghtBls.Add(frghtBl);
                            #region FXI Update
                            foreach (DataRow newRowFXI in dsBatch.Tables["FXI"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)))
                            {
                                fxi = new FXI(frghtBl);
                                fxi = this.SetFXIProperties(fxi, newRowFXI);
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FXIs.Add(fxi);
                            }
                            #endregion
                            #region FBLn Update
                            int FBLnCount = 0;
                            foreach (DataRow newRowFBLn in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)))
                            {
                                fbLn = new FbLn(invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount]);
                                fbLn = this.SetFbLnProperties(fbLn, newRowFBLn);
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].LineItems.Add(fbLn);
                                FBLnCount++;
                            }
                            #endregion
                            frghtBl.FbLnCnt = Convert.ToInt16(FBLnCount);
                            frghtBLCount++;
                        }
                        invoiceCount++;
                        #endregion
                    }
                    #endregion
                    string filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".mxx";
                    dalTrax.PersistToFile(filename, invBat);
                }
                #endregion                
                retval = true;
            }
            catch (Exception e)
            {
                retval = false;
                throw e;
            }
            finally 
            { 
            }
            return retval;
        }

        [WebMethod]
        public DataSet selectBatchObj(string MXXDatabase)
        {
            DataSet retval = new DataSet();
            InvBat invBat = new InvBat();

            DataTable tableInvBat = GetInvBatRowStructure();
            DataTable tableInvoice = GetInvoiceRowStructure();
            DataTable tableFrghtBl = GetFrghtBlRowStructure();
            DataTable tableFXI = GetFXIRowStructure();
            DataTable tableFbLnRow = GetFbLnRowStructure();
            DataRow rowInvBat;
            DataRow rowInvoice;
            DataRow rowFrghtBl;
            DataRow rowFXIRow;
            DataRow rowFbLnRow;
            string filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".mxx";
            
            //check if file exist
            if (File.Exists(filename))
            {
                //depersist file to an InvBat object
                try
                {
                    invBat = (InvBat)dalTrax.DepersistFile(filename);//MXXDatabase + ".mxx");
                    rowInvBat = tableInvBat.NewRow();
                    rowInvBat = SetInvBatRow(invBat, rowInvBat);
                    tableInvBat.Rows.Add(rowInvBat);
                    foreach (Invoice invoice in invBat.Invoices)
                    {
                        rowInvoice = tableInvoice.NewRow();
                        rowInvoice = SetInvoiceRow(invoice, rowInvoice);
                        tableInvoice.Rows.Add(rowInvoice);                        
                        foreach (FrghtBl frghtBl in invoice.FrghtBls)
                        {
                            rowFrghtBl = tableFrghtBl.NewRow();
                            rowFrghtBl = SetFrghtBlRow(frghtBl, rowFrghtBl);
                            tableFrghtBl.Rows.Add(rowFrghtBl);
                            foreach (FXI fxi in frghtBl.FXIs)
                            {
                                rowFXIRow = tableFXI.NewRow();
                                rowFXIRow = SetFXIRow(fxi, rowFXIRow);
                                tableFXI.Rows.Add(rowFXIRow);
                            }
                            foreach (FbLn fbLn in frghtBl.LineItems)
                            {
                                rowFbLnRow = tableFbLnRow.NewRow();
                                rowFbLnRow = SetFbLnRow(fbLn, rowFbLnRow);
                                tableFbLnRow.Rows.Add(rowFbLnRow);
                            }
                        }
                    }                    
                }
                catch 
                {
                    retval = null;                    
                }
                finally
                { 
                }
            }
            retval.Tables.Add(tableInvBat.Copy());
            retval.Tables[0].AcceptChanges();
            retval.Tables.Add(tableInvoice.Copy());
            retval.Tables[1].AcceptChanges();
            retval.Tables.Add(tableFrghtBl.Copy());
            retval.Tables[2].AcceptChanges();
            retval.Tables.Add(tableFbLnRow.Copy());
            retval.Tables[3].AcceptChanges();
            retval.Tables.Add(tableFXI.Copy());
            retval.Tables[4].AcceptChanges();
            return retval;
        }

        [WebMethod]
        public void saveShipperConsigneeInfo(DataTable fb)
        {
            DataTable dtShipper = new DataTable();
            DataTable dtConsignee = new DataTable();
            DataRow drShipper;
            DataRow drConsignee;
            DataSet dsShipper = new DataSet();
            DataSet dsConsignee = new DataSet();
            object shipper = new object();
            object consignee = new object();
            int parameterCount = 1;
            int affectedRows = 0;
            try
            {
                dtShipper.Columns.Add("Name1");
                dtShipper.Columns.Add("Name2");
                dtShipper.Columns.Add("Address1");
                dtShipper.Columns.Add("Address2");
                dtShipper.Columns.Add("City");
                dtShipper.Columns.Add("St");
                dtShipper.Columns.Add("Zip");
                dtShipper.Columns.Add("Country");
                dtShipper.Columns.Add("Combined");
                dtConsignee.Columns.Add("Name1");
                dtConsignee.Columns.Add("Name2");
                dtConsignee.Columns.Add("Address1");
                dtConsignee.Columns.Add("Address2");
                dtConsignee.Columns.Add("City");
                dtConsignee.Columns.Add("St");
                dtConsignee.Columns.Add("Zip");
                dtConsignee.Columns.Add("Country");
                dtConsignee.Columns.Add("Combined");

                foreach (DataRow row in fb.Rows)
                {
                    if (dtShipper.Rows.Count == 0)
                    {
                        drShipper = dtShipper.NewRow();
                        drShipper["Name1"] = row["AlOrig1"];
                        drShipper["Name2"] = row["AlOrig2"];
                        drShipper["Address1"] = row["AlOrig3"];
                        drShipper["Address2"] = row["AlOrig4"];
                        drShipper["City"] = row["AlCityOrig"];
                        drShipper["St"] = row["AlStateProvOrig"];
                        drShipper["Zip"] = row["AlPostCodeOrig"];
                        drShipper["Country"] = row["AlCntryCodeOrig"];
                        drShipper["Combined"] = row["AlOrig1"].ToString().Trim() + row["AlOrig2"].ToString().Trim() + row["AlOrig3"].ToString().Trim() + row["AlOrig4"].ToString().Trim() + row["AlCityOrig"].ToString().Trim() + row["AlStateProvOrig"].ToString().Trim() + row["AlPostCodeOrig"].ToString().Trim() + row["AlCntryCodeOrig"].ToString().Trim();
                        dtShipper.Rows.Add(drShipper);
                    }
                    else if (dtShipper.Select(string.Format("Combined = '{0}'", row["AlOrig1"].ToString().Trim() + row["AlOrig2"].ToString().Trim() + row["AlOrig3"].ToString().Trim() + row["AlOrig4"].ToString().Trim() + row["AlCityOrig"].ToString().Trim() + row["AlStateProvOrig"].ToString().Trim() + row["AlPostCodeOrig"].ToString().Trim() + row["AlCntryCodeOrig"].ToString().Trim())).Count() == 0)
                    {
                        drShipper = dtShipper.NewRow();
                        drShipper["Name1"] = row["AlOrig1"];
                        drShipper["Name2"] = row["AlOrig2"];
                        drShipper["Address1"] = row["AlOrig3"];
                        drShipper["Address2"] = row["AlOrig4"];
                        drShipper["City"] = row["AlCityOrig"];
                        drShipper["St"] = row["AlStateProvOrig"];
                        drShipper["Zip"] = row["AlPostCodeOrig"];
                        drShipper["Country"] = row["AlCntryCodeOrig"];
                        drShipper["Combined"] = row["AlOrig1"].ToString().Trim() + row["AlOrig2"].ToString().Trim() + row["AlOrig3"].ToString().Trim() + row["AlOrig4"].ToString().Trim() + row["AlCityOrig"].ToString().Trim() + row["AlStateProvOrig"].ToString().Trim() + row["AlPostCodeOrig"].ToString().Trim() + row["AlCntryCodeOrig"].ToString().Trim();
                        dtShipper.Rows.Add(drShipper);
                    }
                    if (dtConsignee.Rows.Count == 0)
                    {
                        drConsignee = dtConsignee.NewRow();
                        drConsignee["Name1"] = row["AlDest1"];
                        drConsignee["Name2"] = row["AlDest2"];
                        drConsignee["Address1"] = row["AlDest3"];
                        drConsignee["Address2"] = row["AlDest4"];
                        drConsignee["City"] = row["AlCityDest"];
                        drConsignee["St"] = row["AlStateProvDest"];
                        drConsignee["Zip"] = row["AlPostCodeDest"];
                        drConsignee["Country"] = row["AlCntryCodeDest"];
                        drConsignee["Combined"] = row["AlDest1"].ToString().Trim() + row["AlDest2"].ToString().Trim() + row["AlDest3"].ToString().Trim() + row["AlDest4"].ToString().Trim() + row["AlCityDest"].ToString().Trim() + row["AlStateProvDest"].ToString().Trim() + row["AlPostCodeDest"].ToString().Trim() + row["AlCntryCodeDest"].ToString().Trim();
                        dtConsignee.Rows.Add(drConsignee);
                    }
                    else if (dtConsignee.Select(string.Format("Combined = '{0}'", row["AlDest1"].ToString().Trim() + row["AlDest2"].ToString().Trim() + row["AlDest3"].ToString().Trim() + row["AlDest4"].ToString().Trim() + row["AlCityDest"].ToString().Trim() + row["AlStateProvDest"].ToString().Trim() + row["AlPostCodeDest"].ToString().Trim() + row["AlCntryCodeDest"].ToString().Trim())).Count() == 0)
                    {
                        drConsignee = dtConsignee.NewRow();
                        drConsignee["Name1"] = row["AlDest1"];
                        drConsignee["Name2"] = row["AlDest2"];
                        drConsignee["Address1"] = row["AlDest3"];
                        drConsignee["Address2"] = row["AlDest4"];
                        drConsignee["City"] = row["AlCityDest"];
                        drConsignee["St"] = row["AlStateProvDest"];
                        drConsignee["Zip"] = row["AlPostCodeDest"];
                        drConsignee["Country"] = row["AlCntryCodeDest"];
                        drConsignee["Combined"] = row["AlDest1"].ToString().Trim() + row["AlDest2"].ToString().Trim() + row["AlDest3"].ToString().Trim() + row["AlDest4"].ToString().Trim() + row["AlCityDest"].ToString().Trim() + row["AlStateProvDest"].ToString().Trim() + row["AlPostCodeDest"].ToString().Trim() + row["AlCntryCodeDest"].ToString().Trim();
                        dtConsignee.Rows.Add(drConsignee);
                    }
                }
                string SelectShipperQuery = @"SELECT count(*) AS isExisting
                                      FROM SHIPPER
                                      WHERE (CASE WHEN ([AL_ORIG_1]) IS NULL THEN '' ELSE RTRIM([AL_ORIG_1]) END + 
                                            CASE WHEN ([AL_ORIG_2]) IS NULL THEN '' ELSE RTRIM([AL_ORIG_2]) END + 
                                            CASE WHEN ([AL_ORIG_3]) IS NULL THEN '' ELSE RTRIM([AL_ORIG_3]) END +
                                            CASE WHEN ([AL_ORIG_4]) IS NULL THEN '' ELSE RTRIM([AL_ORIG_4]) END +
                                            CASE WHEN ([AL_CITY_ORIG]) IS NULL THEN '' ELSE RTRIM([AL_CITY_ORIG]) END +
                                            CASE WHEN ([AL_STATE_PROV_ORIG]) IS NULL THEN '' ELSE RTRIM([AL_STATE_PROV_ORIG]) END +
                                            CASE WHEN ([AL_POST_CODE_ORIG]) IS NULL THEN '' ELSE RTRIM([AL_POST_CODE_ORIG]) END +
                                            CASE WHEN ([AL_CNTRY_CODE_ORIG]) IS NULL THEN '' ELSE RTRIM([AL_CNTRY_CODE_ORIG]) END)  = @shipperInfo";
                string SelectConsigneeQuery = @"SELECT count(*) AS isExisting
                                      FROM CONSIGNEE
                                      WHERE (CASE WHEN ([AL_DEST_1]) IS NULL THEN '' ELSE RTRIM([AL_DEST_1]) END + 
                                            CASE WHEN ([AL_DEST_2]) IS NULL THEN '' ELSE RTRIM([AL_DEST_2]) END + 
                                            CASE WHEN ([AL_DEST_3]) IS NULL THEN '' ELSE RTRIM([AL_DEST_3]) END +
                                            CASE WHEN ([AL_DEST_4]) IS NULL THEN '' ELSE RTRIM([AL_DEST_4]) END +
                                            CASE WHEN ([AL_CITY_DEST]) IS NULL THEN '' ELSE RTRIM([AL_CITY_DEST]) END +
                                            CASE WHEN ([AL_STATE_PROV_DEST]) IS NULL THEN '' ELSE RTRIM([AL_STATE_PROV_DEST]) END +
                                            CASE WHEN ([AL_POST_CODE_DEST]) IS NULL THEN '' ELSE RTRIM([AL_POST_CODE_DEST]) END +
                                            CASE WHEN ([AL_CNTRY_CODE_DEST]) IS NULL THEN '' ELSE RTRIM([AL_CNTRY_CODE_DEST]) END)  = @consigneeInfo";
                string InsertShipperQuery = string.Empty;
                string InsertConsigneeQuery = string.Empty;

                dal.OpenDB();
                dal.BeginTransaction();

                ParameterInfo[] param = new ParameterInfo[1];
                ParameterInfo[] paramShipper;
                ParameterInfo[] paramConsignee;
                string query1Part = string.Empty;
                string query2Part = string.Empty;
                int Columns;
                #region shipper insert
                foreach (DataRow rowShipper in dtShipper.Rows)
                {
                    param[0] = new ParameterInfo("@shipperInfo", rowShipper["Combined"].ToString().Trim(), SqlDbType.NVarChar, 480);
                    shipper = dal.ExecuteScalar(SelectShipperQuery, CommandType.Text, param);
                    if (Convert.ToInt16(shipper.ToString()) == 0)
                    {
                        //insert
                        parameterCount = 1;
                        query1Part = "INSERT INTO SHIPPER\n(LOC_ID_ORIG";
                        query2Part = "\nVALUES\n(@LocIDOrig";

                        if (rowShipper["Name1"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_ORIG_1";
                            query2Part = query2Part + "\n,@Name1";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowShipper["Name2"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_ORIG_2";
                            query2Part = query2Part + "\n,@Name2";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowShipper["Address1"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_ORIG_3";
                            query2Part = query2Part + "\n,@Address1";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowShipper["Address2"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_ORIG_4";
                            query2Part = query2Part + "\n,@Address2";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowShipper["City"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_CITY_ORIG";
                            query2Part = query2Part + "\n,@City";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowShipper["St"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_STATE_PROV_ORIG";
                            query2Part = query2Part + "\n,@St";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowShipper["Zip"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_POST_CODE_ORIG";
                            query2Part = query2Part + "\n,@Zip";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowShipper["Country"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_CNTRY_CODE_ORIG";
                            query2Part = query2Part + "\n,@Country";
                            parameterCount = parameterCount + 1;
                        }
                        query1Part = query1Part + ")";
                        query2Part = query2Part + ")";
                        InsertShipperQuery = query1Part + query2Part;
                        paramShipper = new ParameterInfo[parameterCount];
                        Columns = 1;
                        foreach (DataColumn column in rowShipper.Table.Columns)
                        {
                            if (rowShipper[column.ColumnName].ToString().Trim() != string.Empty && column.ColumnName != "Combined")
                            {
                                paramShipper[Columns] = new ParameterInfo("@" + column.ColumnName, rowShipper[column.ColumnName]);
                                Columns++;
                            }
                        }
                        dsShipper = dal.ExecuteDataSet(@"SELECT CASE WHEN (COUNT (*)) = 0 THEN '0' ELSE (SELECT TOP 1 LOC_ID_ORIG + 1 FROM SHIPPER ORDER BY LOC_ID_ORIG DESC) END FROM SHIPPER", CommandType.Text);
                        if (dsShipper.Tables.Count > 0 && dsShipper.Tables[0].Rows.Count > 0)
                        {
                            paramShipper[0] = new ParameterInfo("@LocIDOrig", dsShipper.Tables[0].Rows[0][0].ToString().PadLeft(23, '0'));
                        }
                        affectedRows = dal.ExecuteNonQuery(InsertShipperQuery, CommandType.Text, paramShipper);
                    }
                }
                #endregion
                #region Consignee insert
                foreach (DataRow rowConsignee in dtConsignee.Rows)
                {

                    param[0] = new ParameterInfo("@consigneeInfo", rowConsignee["Combined"].ToString().Trim(), SqlDbType.NVarChar, 480);
                    consignee = dal.ExecuteScalar(SelectConsigneeQuery, CommandType.Text, param);
                    if (Convert.ToInt16(consignee.ToString()) == 0)
                    {
                        //insert
                        parameterCount = 1;
                        query1Part = "INSERT INTO CONSIGNEE\n(LOC_ID_DEST";
                        query2Part = "\nVALUES\n(@LocIDDest";

                        if (rowConsignee["Name1"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_DEST_1";
                            query2Part = query2Part + "\n,@Name1";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowConsignee["Name2"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_DEST_2";
                            query2Part = query2Part + "\n,@Name2";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowConsignee["Address1"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_DEST_3";
                            query2Part = query2Part + "\n,@Address1";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowConsignee["Address2"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_DEST_4";
                            query2Part = query2Part + "\n,@Address2";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowConsignee["City"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_CITY_DEST";
                            query2Part = query2Part + "\n,@City";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowConsignee["St"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_STATE_PROV_DEST";
                            query2Part = query2Part + "\n,@St";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowConsignee["Zip"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_POST_CODE_DEST";
                            query2Part = query2Part + "\n,@Zip";
                            parameterCount = parameterCount + 1;
                        }
                        if (rowConsignee["Country"].ToString().Trim() != string.Empty)
                        {
                            query1Part = query1Part + "\n,AL_CNTRY_CODE_DEST";
                            query2Part = query2Part + "\n,@Country";
                            parameterCount = parameterCount + 1;
                        }
                        query1Part = query1Part + ")";
                        query2Part = query2Part + ")";
                        InsertConsigneeQuery = query1Part + query2Part;
                        paramConsignee = new ParameterInfo[parameterCount];
                        Columns = 1;
                        foreach (DataColumn column in rowConsignee.Table.Columns)
                        {
                            if (rowConsignee[column.ColumnName].ToString().Trim() != string.Empty && column.ColumnName != "Combined")
                            {
                                paramConsignee[Columns] = new ParameterInfo("@" + column.ColumnName, rowConsignee[column.ColumnName]);
                                Columns++;
                            }
                        }
                        dsConsignee = dal.ExecuteDataSet(@"SELECT CASE WHEN (COUNT (*)) = 0 THEN '0' ELSE (SELECT TOP 1 LOC_ID_DEST + 1 FROM CONSIGNEE ORDER BY LOC_ID_DEST DESC) END FROM CONSIGNEE", CommandType.Text);
                        if (dsConsignee.Tables.Count > 0 && dsConsignee.Tables[0].Rows.Count > 0)
                        {
                            paramConsignee[0] = new ParameterInfo("@LocIDDest", dsConsignee.Tables[0].Rows[0][0].ToString().PadLeft(23, '0'));
                        }
                        affectedRows = dal.ExecuteNonQuery(InsertConsigneeQuery, CommandType.Text, paramConsignee);
                    }
                }
                #endregion
                dal.CommitTransaction();
            }
            catch
            {
                dal.RollBackTransaction();
            }
            finally
            {
                dal.CloseDB();
            }
        }

        //public bool repairDatabase(string MXXDatabase)
        //{
        //    bool retval = false;
        //    try
        //    {
        //        dalMXXDatabase.RepairDatabase(ConfigurationManager.AppSettings["MDBSourcePath"] + "MXX" + MXXDatabase.Trim() + ".mdb");
        //        retval = true;
        //    }
        //    catch (Exception error)
        //    {
        //        retval = false;
        //        throw error;
        //    }
        //    return retval;
        //}

        [WebMethod]
        public DataSet selectAlphaNumericKey()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT
                                Owner_Key,
                                Invoice,
                                FreightBill,
                                Account,
                                TaxNumber,
                                VatReg
                            FROM AlphaNumericKey(NOLOCK)";
            try
            {
                dal.OpenDB();
                retval = dal.ExecuteDataSet(query, CommandType.Text);
            }
            catch
            {
                
                retval = null;
                throw new Exception("Could not connect to database.");
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }
        
        [WebMethod]
        public DataSet selectCustRef()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT * FROM CustRefConfig(NOLOCK)";
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

        [WebMethod]
        public bool isSplitBatch(string batCtrlNum)
        {
            bool retval = false;
            ParameterInfo[] paramBat = new ParameterInfo[1];
            paramBat[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);//get rootbatch 
            try
            {
                dal.OpenDB();
                retval = Convert.ToInt32(dal.ExecuteScalar("SELECT COUNT(*) FROM Batch_DE_Split A INNER JOIN Batch_DE_Split B ON A.Bat_Ctrl_Num_Root = B.Bat_Ctrl_Num_Root WHERE B.Bat_Ctrl_Num_Split =  @Bat_Ctrl_Num", CommandType.Text, paramBat)) > 0;
            }
            catch
            { }
            finally
            {
                dal.CloseDB();
            }

            return retval;
        }

        [WebMethod]
        public DataSet selectQABatch(string MXXDatabase)
        {
            DataSet retval = new DataSet();
            DataSet dsInvBat = new DataSet("InvBat");
            DataSet dsInvoice = new DataSet("Invoice");
            DataSet dsFB = new DataSet("FB");
            DataSet dsFBLn = new DataSet("FBLn");
            DataSet dsFXI = new DataSet("FXI");
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", @"QA\MXX" + MXXDatabase.Trim() + ".mdb");

            try
            {
                string filename = ConfigurationManager.AppSettings["MDBDestinationPath"] + @"QA\MXX" + MXXDatabase + ".mdb";

                if (!File.Exists(filename))
                    File.Copy(ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + MXXDatabase + ".mdb", filename);

                dalMXXDatabase.OpenDB();
                dsInvBat = dalMXXDatabase.ExecuteDataSet(selectQueryINV_BAT, CommandType.Text);
                dsInvoice = dalMXXDatabase.ExecuteDataSet(selectQueryINVOICE, CommandType.Text);
                dsFB = dalMXXDatabase.ExecuteDataSet(selectQueryFRGHT_BL, CommandType.Text);
                dsFBLn = dalMXXDatabase.ExecuteDataSet(selectQueryFB_LN, CommandType.Text);
                dsFXI = dalMXXDatabase.ExecuteDataSet(selectQueryFXI, CommandType.Text);

                dsInvBat.Tables[0].TableName = "InvBat";
                dsInvoice.Tables[0].TableName = "Invoice";
                dsFB.Tables[0].TableName = "FB";
                dsFBLn.Tables[0].TableName = "FBLn";
                dsFXI.Tables[0].TableName = "FXI";

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

        [WebMethod]
        public bool saveQABatch(DataSet dsBatch, string MXXDatabase, string OwnerKey)
        {
            bool retval = false;
            DataSet dsInvBat = new DataSet();
            DataSet dsInvoice = new DataSet();
            DataSet dsFrghtBL = new DataSet();
            DataSet dsFBLn = new DataSet();
            int affectedRows;
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", @"QA\MXX" + MXXDatabase.Trim() + ".mdb");

            try
            {
                string ownerKey = OwnerKey.Trim().Remove(3, 1);
                string batchNumber = "MXX" + MXXDatabase.Trim();
                string batchCount = (0).ToString().PadLeft(4, '0');
                dalMXXDatabase.OpenDB();
                dalMXXDatabase.BeginTransaction();
                #region INV_BAT
                foreach (DataRow dr in dsBatch.Tables["InvBat"].Rows)
                {
                    ParameterInfoOleDB[] paramINV_BAT;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramINV_BAT = new ParameterInfoOleDB[13];
                        paramINV_BAT[0] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        paramINV_BAT[1] = new ParameterInfoOleDB("@OwnerKey", dr["OwnerKey"]);
                        paramINV_BAT[2] = new ParameterInfoOleDB("@VendBatKey", dr["VendBatKey"]);
                        paramINV_BAT[3] = new ParameterInfoOleDB("@VendBatDtm", dr["VendBatDtm"]);
                        paramINV_BAT[4] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINV_BAT[5] = new ParameterInfoOleDB("@VendFeed", dr["VendFeed"]);
                        paramINV_BAT[6] = new ParameterInfoOleDB("@BatKey", dr["BatKey"]);
                        paramINV_BAT[7] = new ParameterInfoOleDB("@BatCreatDtm", dr["BatCreatDtm"]);
                        paramINV_BAT[8] = new ParameterInfoOleDB("@BatInvCnt", dr["BatInvCnt"]);
                        paramINV_BAT[9] = new ParameterInfoOleDB("@BatFbCnt", dr["BatFbCnt"]);
                        paramINV_BAT[10] = new ParameterInfoOleDB("@BatAmt", dr["BatAmt"].ToString().Trim() == string.Empty ? 0 : dr["BatAmt"]);
                        paramINV_BAT[11] = new ParameterInfoOleDB("@BatCurrencyQual", dr["BatCurrencyQual"]);
                        paramINV_BAT[12] = new ParameterInfoOleDB("@BatLocIdRemit", dr["BatLocIdRemit"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryINV_BAT, CommandType.Text, paramINV_BAT);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramINV_BAT = new ParameterInfoOleDB[16];
                        paramINV_BAT[0] = new ParameterInfoOleDB("@BatIdNew", dr["BatId"]);
                        paramINV_BAT[1] = new ParameterInfoOleDB("@OwnerKey", dr["OwnerKey"]);
                        paramINV_BAT[2] = new ParameterInfoOleDB("@VendBatKey", dr["VendBatKey"]);
                        paramINV_BAT[3] = new ParameterInfoOleDB("@VendBatDtm", dr["VendBatDtm"]);
                        paramINV_BAT[4] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINV_BAT[5] = new ParameterInfoOleDB("@VendFeed", dr["VendFeed"]);
                        paramINV_BAT[6] = new ParameterInfoOleDB("@BatKey", dr["BatKey"]);
                        paramINV_BAT[7] = new ParameterInfoOleDB("@BatCreatDtm", dr["BatCreatDtm"]);
                        paramINV_BAT[8] = new ParameterInfoOleDB("@BatInvCnt", dr["BatInvCnt"]);
                        paramINV_BAT[9] = new ParameterInfoOleDB("@BatFbCnt", dr["BatFbCnt"]);
                        paramINV_BAT[10] = new ParameterInfoOleDB("@BatAmt", dr["BatAmt"].ToString().Trim() == string.Empty ? 0 : dr["BatAmt"]);
                        paramINV_BAT[11] = new ParameterInfoOleDB("@BatCurrencyQual", dr["BatCurrencyQual"]);
                        paramINV_BAT[12] = new ParameterInfoOleDB("@BatLocIdRemit", dr["BatLocIdRemit"]);
                        paramINV_BAT[13] = new ParameterInfoOleDB("@BatStat", dr["BatStat"]);
                        paramINV_BAT[14] = new ParameterInfoOleDB("@BatType", dr["BatType"]);
                        dr.RejectChanges();
                        paramINV_BAT[15] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryINV_BAT, CommandType.Text, paramINV_BAT);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramINV_BAT = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramINV_BAT[0] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryINV_BAT, CommandType.Text, paramINV_BAT);
                    }
                }
                #endregion
                #region INVOICE
                foreach (DataRow dr in dsBatch.Tables["Invoice"].Rows)
                {

                    ParameterInfoOleDB[] paramINVOICE;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramINVOICE = new ParameterInfoOleDB[31];

                        paramINVOICE[0] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramINVOICE[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramINVOICE[2] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramINVOICE[3] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                        paramINVOICE[4] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramINVOICE[5] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINVOICE[6] = new ParameterInfoOleDB("@LocIdRemit", dr["LocIdRemit"]);
                        paramINVOICE[7] = new ParameterInfoOleDB("@InvStat", dr["InvStat"]);
                        paramINVOICE[8] = new ParameterInfoOleDB("@InvFbCnt", dr["InvFbCnt"].ToString().Trim() == string.Empty ? 0 : dr["InvFbCnt"]);
                        paramINVOICE[9] = new ParameterInfoOleDB("@InvCurrencyQual", dr["InvCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCurrencyQual"]);
                        paramINVOICE[10] = new ParameterInfoOleDB("@InvAmt", dr["InvAmt"].ToString().Trim() == string.Empty ? 0 : dr["InvAmt"]);
                        paramINVOICE[11] = new ParameterInfoOleDB("@VendInvAmt", dr["VendInvAmt"].ToString().Trim() == string.Empty ? 0 : dr["VendInvAmt"]);
                        paramINVOICE[12] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramINVOICE[13] = new ParameterInfoOleDB("@AlRemit1", dr["AlRemit1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit1"]);
                        paramINVOICE[14] = new ParameterInfoOleDB("@AlRemit2", dr["AlRemit2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit2"]);
                        paramINVOICE[15] = new ParameterInfoOleDB("@AlRemit3", dr["AlRemit3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit3"]);
                        paramINVOICE[16] = new ParameterInfoOleDB("@AlRemit4", dr["AlRemit4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit4"]);
                        paramINVOICE[17] = new ParameterInfoOleDB("@AlCityRemit", dr["AlCityRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityRemit"]);
                        paramINVOICE[18] = new ParameterInfoOleDB("@AlStateProvRemit", dr["AlStateProvRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvRemit"]);
                        paramINVOICE[19] = new ParameterInfoOleDB("@AlPostCodeRemit", dr["AlPostCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeRemit"]);
                        paramINVOICE[20] = new ParameterInfoOleDB("@AlCntryCodeRemit", dr["AlCntryCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeRemit"]);
                        paramINVOICE[21] = new ParameterInfoOleDB("@InvCreatDtm", dr["InvCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCreatDtm"]);

                        paramINVOICE[22] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);
                        paramINVOICE[23] = new ParameterInfoOleDB("@AlBlng1", dr["AlBlng1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng1"]);
                        paramINVOICE[24] = new ParameterInfoOleDB("@AlBlng2", dr["AlBlng2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng2"]);
                        paramINVOICE[25] = new ParameterInfoOleDB("@AlBlng3", dr["AlBlng3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng3"]);
                        paramINVOICE[26] = new ParameterInfoOleDB("@AlBlng4", dr["AlBlng4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng4"]);
                        paramINVOICE[27] = new ParameterInfoOleDB("@AlCityBlng", dr["AlCityBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityBlng"]);
                        paramINVOICE[28] = new ParameterInfoOleDB("@AlStateProvBlng", dr["AlStateProvBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvBlng"]);
                        paramINVOICE[29] = new ParameterInfoOleDB("@AlPostCodeBlng", dr["AlPostCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeBlng"]);
                        paramINVOICE[30] = new ParameterInfoOleDB("@AlCntryCodeBlng", dr["AlCntryCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeBlng"]);


                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryINVOICE, CommandType.Text, paramINVOICE);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramINVOICE = new ParameterInfoOleDB[32];

                        paramINVOICE[0] = new ParameterInfoOleDB("@InvIdNew", dr["InvId"]);
                        paramINVOICE[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramINVOICE[2] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramINVOICE[3] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                        paramINVOICE[4] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramINVOICE[5] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramINVOICE[6] = new ParameterInfoOleDB("@LocIdRemit", dr["LocIdRemit"]);
                        paramINVOICE[7] = new ParameterInfoOleDB("@InvStat", dr["InvStat"]);
                        paramINVOICE[8] = new ParameterInfoOleDB("@InvFbCnt", dr["InvFbCnt"].ToString().Trim() == string.Empty ? 0 : dr["InvFbCnt"]);
                        paramINVOICE[9] = new ParameterInfoOleDB("@InvCurrencyQual", dr["InvCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCurrencyQual"]);
                        paramINVOICE[10] = new ParameterInfoOleDB("@InvAmt", dr["InvAmt"].ToString().Trim() == string.Empty ? 0 : dr["InvAmt"]);
                        paramINVOICE[11] = new ParameterInfoOleDB("@VendInvAmt", dr["VendInvAmt"].ToString().Trim() == string.Empty ? 0 : dr["VendInvAmt"]);
                        paramINVOICE[12] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramINVOICE[13] = new ParameterInfoOleDB("@AlRemit1", dr["AlRemit1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit1"]);
                        paramINVOICE[14] = new ParameterInfoOleDB("@AlRemit2", dr["AlRemit2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit2"]);
                        paramINVOICE[15] = new ParameterInfoOleDB("@AlRemit3", dr["AlRemit3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit3"]);
                        paramINVOICE[16] = new ParameterInfoOleDB("@AlRemit4", dr["AlRemit4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit4"]);
                        paramINVOICE[17] = new ParameterInfoOleDB("@AlCityRemit", dr["AlCityRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityRemit"]);
                        paramINVOICE[18] = new ParameterInfoOleDB("@AlStateProvRemit", dr["AlStateProvRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvRemit"]);
                        paramINVOICE[19] = new ParameterInfoOleDB("@AlPostCodeRemit", dr["AlPostCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeRemit"]);
                        paramINVOICE[20] = new ParameterInfoOleDB("@AlCntryCodeRemit", dr["AlCntryCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeRemit"]);
                        paramINVOICE[21] = new ParameterInfoOleDB("@InvCreatDtm", dr["InvCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCreatDtm"]);

                        paramINVOICE[22] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);
                        paramINVOICE[23] = new ParameterInfoOleDB("@AlBlng1", dr["AlBlng1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng1"]);
                        paramINVOICE[24] = new ParameterInfoOleDB("@AlBlng2", dr["AlBlng2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng2"]);
                        paramINVOICE[25] = new ParameterInfoOleDB("@AlBlng3", dr["AlBlng3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng3"]);
                        paramINVOICE[26] = new ParameterInfoOleDB("@AlBlng4", dr["AlBlng4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng4"]);
                        paramINVOICE[27] = new ParameterInfoOleDB("@AlCityBlng", dr["AlCityBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityBlng"]);
                        paramINVOICE[28] = new ParameterInfoOleDB("@AlStateProvBlng", dr["AlStateProvBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvBlng"]);
                        paramINVOICE[29] = new ParameterInfoOleDB("@AlPostCodeBlng", dr["AlPostCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeBlng"]);
                        paramINVOICE[30] = new ParameterInfoOleDB("@AlCntryCodeBlng", dr["AlCntryCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeBlng"]);

                        dr.RejectChanges();
                        paramINVOICE[31] = new ParameterInfoOleDB("@InvId", dr["InvId"]);

                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryINVOICE, CommandType.Text, paramINVOICE);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramINVOICE = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramINVOICE[0] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryINVOICE, CommandType.Text, paramINVOICE);
                    }
                }
                #endregion
                #region FRGHT_BL
                foreach (DataRow dr in dsBatch.Tables["FB"].Rows)
                {
                    ParameterInfoOleDB[] paramFRGHT_BL;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramFRGHT_BL = new ParameterInfoOleDB[54];

                        paramFRGHT_BL[0] = new ParameterInfoOleDB("@FBId", dr["FbId"]);
                        paramFRGHT_BL[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramFRGHT_BL[2] = new ParameterInfoOleDB("@FbKey", dr["FbKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbKey"]);
                        paramFRGHT_BL[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFRGHT_BL[4] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramFRGHT_BL[5] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                        paramFRGHT_BL[6] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFRGHT_BL[7] = new ParameterInfoOleDB("@FbLnCnt", dr["FbLnCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbLnCnt"]);
                        paramFRGHT_BL[8] = new ParameterInfoOleDB("@FbAmt", dr["FbAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAmt"]);
                        paramFRGHT_BL[9] = new ParameterInfoOleDB("@FbFrghtAmt", dr["FbFrghtAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbFrghtAmt"]);
                        paramFRGHT_BL[10] = new ParameterInfoOleDB("@FbDscntAmt", dr["FbDscntAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbDscntAmt"]);
                        paramFRGHT_BL[11] = new ParameterInfoOleDB("@FbAccAmt", dr["FbAccAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAccAmt"]);
                        paramFRGHT_BL[12] = new ParameterInfoOleDB("@FbTaxAmt", dr["FbTaxAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbTaxAmt"]);
                        paramFRGHT_BL[13] = new ParameterInfoOleDB("@FbCurrencyQual", dr["FbCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCurrencyQual"]);
                        paramFRGHT_BL[14] = new ParameterInfoOleDB("@FbPaymtTermsCode", dr["FbPaymtTermsCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPaymtTermsCode"]);
                        paramFRGHT_BL[15] = new ParameterInfoOleDB("@FbCreatDtm", dr["FbCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCreatDtm"]);
                        paramFRGHT_BL[16] = new ParameterInfoOleDB("@FbPkgType", dr["FbPkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPkgType"]);
                        paramFRGHT_BL[17] = new ParameterInfoOleDB("@FbPcsCnt", dr["FbPcsCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbPcsCnt"]);
                        paramFRGHT_BL[18] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["VendLabl"]);
                        paramFRGHT_BL[19] = new ParameterInfoOleDB("@SrvcReqCode", dr["SrvcReqCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["SrvcReqCode"]);
                        paramFRGHT_BL[20] = new ParameterInfoOleDB("@CaInfo1Raw", dr["CaInfo1Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo1Raw"]);
                        paramFRGHT_BL[21] = new ParameterInfoOleDB("@CaInfo2Raw", dr["CaInfo2Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo2Raw"]);
                        paramFRGHT_BL[22] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramFRGHT_BL[23] = new ParameterInfoOleDB("@AlOrig1", dr["AlOrig1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig1"]);
                        paramFRGHT_BL[24] = new ParameterInfoOleDB("@AlOrig2", dr["AlOrig2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig2"]);
                        paramFRGHT_BL[25] = new ParameterInfoOleDB("@AlOrig3", dr["AlOrig3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig3"]);
                        paramFRGHT_BL[26] = new ParameterInfoOleDB("@AlOrig4", dr["AlOrig4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig4"]);
                        paramFRGHT_BL[27] = new ParameterInfoOleDB("@AlCityOrig", dr["AlCityOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityOrig"]);
                        paramFRGHT_BL[28] = new ParameterInfoOleDB("@AlStateProvOrig", dr["AlStateProvOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvOrig"]);
                        paramFRGHT_BL[29] = new ParameterInfoOleDB("@AlPostCodeOrig", dr["AlPostCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeOrig"]);
                        paramFRGHT_BL[30] = new ParameterInfoOleDB("@AlCntryCodeOrig", dr["AlCntryCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeOrig"]);
                        paramFRGHT_BL[31] = new ParameterInfoOleDB("@AlDest1", dr["AlDest1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest1"]);
                        paramFRGHT_BL[32] = new ParameterInfoOleDB("@AlDest2", dr["AlDest2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest2"]);
                        paramFRGHT_BL[33] = new ParameterInfoOleDB("@AlDest3", dr["AlDest3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest3"]);
                        paramFRGHT_BL[34] = new ParameterInfoOleDB("@AlDest4", dr["AlDest4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest4"]);
                        paramFRGHT_BL[35] = new ParameterInfoOleDB("@AlCityDest", dr["AlCityDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityDest"]);
                        paramFRGHT_BL[36] = new ParameterInfoOleDB("@AlStateProvDest", dr["AlStateProvDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvDest"]);
                        paramFRGHT_BL[37] = new ParameterInfoOleDB("@AlPostCodeDest", dr["AlPostCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeDest"]);
                        paramFRGHT_BL[38] = new ParameterInfoOleDB("@AlCntryCodeDest", dr["AlCntryCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeDest"]);
                        paramFRGHT_BL[39] = new ParameterInfoOleDB("@FbActualWt", dr["FbActualWt"].ToString().Trim() == string.Empty ? 0 : dr["FbActualWt"]);
                        paramFRGHT_BL[40] = new ParameterInfoOleDB("@FbFnclWt", dr["FbFnclWt"].ToString().Trim() == string.Empty ? 0 : dr["FbFnclWt"]);
                        paramFRGHT_BL[41] = new ParameterInfoOleDB("@InterlineScac", dr["InterlineScac"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineScac"]);
                        paramFRGHT_BL[42] = new ParameterInfoOleDB("@InterlineQual", dr["InterlineQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineQual"]);
                        paramFRGHT_BL[43] = new ParameterInfoOleDB("@InterlineAmt", dr["InterlineAmt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineAmt"]);
                        paramFRGHT_BL[44] = new ParameterInfoOleDB("@LmDist", dr["LmDist"].ToString().Trim() == string.Empty ? 0 : dr["LmDist"]);
                        paramFRGHT_BL[45] = new ParameterInfoOleDB("@LmPkupActualDtm", dr["LmPkupActualDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmPkupActualDtm"]);
                        paramFRGHT_BL[46] = new ParameterInfoOleDB("@LmAtaDtm", dr["LmAtaDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmAtaDtm"]);
                        paramFRGHT_BL[47] = new ParameterInfoOleDB("@PriceLaneLabl", dr["PriceLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PriceLaneLabl"]);
                        paramFRGHT_BL[48] = new ParameterInfoOleDB("@LmLaneLabl", dr["LmLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmLaneLabl"]);
                        paramFRGHT_BL[49] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);

                        paramFRGHT_BL[50] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFRGHT_BL[51] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFRGHT_BL[52] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFRGHT_BL[53] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramFRGHT_BL = new ParameterInfoOleDB[55];
                        paramFRGHT_BL[0] = new ParameterInfoOleDB("@FBIdNew", dr["FbId"]);
                        paramFRGHT_BL[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramFRGHT_BL[2] = new ParameterInfoOleDB("@FbKey", dr["FbKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbKey"]);
                        paramFRGHT_BL[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFRGHT_BL[4] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvKey"]);
                        paramFRGHT_BL[5] = new ParameterInfoOleDB("@BAT_ID", "BACH" + ownerKey + batchNumber + batchCount);
                        paramFRGHT_BL[6] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFRGHT_BL[7] = new ParameterInfoOleDB("@FbLnCnt", dr["FbLnCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbLnCnt"]);
                        paramFRGHT_BL[8] = new ParameterInfoOleDB("@FbAmt", dr["FbAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAmt"]);
                        paramFRGHT_BL[9] = new ParameterInfoOleDB("@FbFrghtAmt", dr["FbFrghtAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbFrghtAmt"]);
                        paramFRGHT_BL[10] = new ParameterInfoOleDB("@FbDscntAmt", dr["FbDscntAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbDscntAmt"]);
                        paramFRGHT_BL[11] = new ParameterInfoOleDB("@FbAccAmt", dr["FbAccAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAccAmt"]);
                        paramFRGHT_BL[12] = new ParameterInfoOleDB("@FbTaxAmt", dr["FbTaxAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbTaxAmt"]);
                        paramFRGHT_BL[13] = new ParameterInfoOleDB("@FbCurrencyQual", dr["FbCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCurrencyQual"]);
                        paramFRGHT_BL[14] = new ParameterInfoOleDB("@FbPaymtTermsCode", dr["FbPaymtTermsCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPaymtTermsCode"]);
                        paramFRGHT_BL[15] = new ParameterInfoOleDB("@FbCreatDtm", dr["FbCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCreatDtm"]);
                        paramFRGHT_BL[16] = new ParameterInfoOleDB("@FbPkgType", dr["FbPkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPkgType"]);
                        paramFRGHT_BL[17] = new ParameterInfoOleDB("@FbPcsCnt", dr["FbPcsCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbPcsCnt"]);
                        paramFRGHT_BL[18] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["VendLabl"]);
                        paramFRGHT_BL[19] = new ParameterInfoOleDB("@SrvcReqCode", dr["SrvcReqCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["SrvcReqCode"]);
                        paramFRGHT_BL[20] = new ParameterInfoOleDB("@CaInfo1Raw", dr["CaInfo1Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo1Raw"]);
                        paramFRGHT_BL[21] = new ParameterInfoOleDB("@CaInfo2Raw", dr["CaInfo2Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo2Raw"]);
                        paramFRGHT_BL[22] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                        paramFRGHT_BL[23] = new ParameterInfoOleDB("@AlOrig1", dr["AlOrig1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig1"]);
                        paramFRGHT_BL[24] = new ParameterInfoOleDB("@AlOrig2", dr["AlOrig2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig2"]);
                        paramFRGHT_BL[25] = new ParameterInfoOleDB("@AlOrig3", dr["AlOrig3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig3"]);
                        paramFRGHT_BL[26] = new ParameterInfoOleDB("@AlOrig4", dr["AlOrig4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig4"]);
                        paramFRGHT_BL[27] = new ParameterInfoOleDB("@AlCityOrig", dr["AlCityOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityOrig"]);
                        paramFRGHT_BL[28] = new ParameterInfoOleDB("@AlStateProvOrig", dr["AlStateProvOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvOrig"]);
                        paramFRGHT_BL[29] = new ParameterInfoOleDB("@AlPostCodeOrig", dr["AlPostCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeOrig"]);
                        paramFRGHT_BL[30] = new ParameterInfoOleDB("@AlCntryCodeOrig", dr["AlCntryCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeOrig"]);
                        paramFRGHT_BL[31] = new ParameterInfoOleDB("@AlDest1", dr["AlDest1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest1"]);
                        paramFRGHT_BL[32] = new ParameterInfoOleDB("@AlDest2", dr["AlDest2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest2"]);
                        paramFRGHT_BL[33] = new ParameterInfoOleDB("@AlDest3", dr["AlDest3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest3"]);
                        paramFRGHT_BL[34] = new ParameterInfoOleDB("@AlDest4", dr["AlDest4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest4"]);
                        paramFRGHT_BL[35] = new ParameterInfoOleDB("@AlCityDest", dr["AlCityDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityDest"]);
                        paramFRGHT_BL[36] = new ParameterInfoOleDB("@AlStateProvDest", dr["AlStateProvDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvDest"]);
                        paramFRGHT_BL[37] = new ParameterInfoOleDB("@AlPostCodeDest", dr["AlPostCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeDest"]);
                        paramFRGHT_BL[38] = new ParameterInfoOleDB("@AlCntryCodeDest", dr["AlCntryCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeDest"]);
                        paramFRGHT_BL[39] = new ParameterInfoOleDB("@FbFnclWt", dr["FbActualWt"].ToString().Trim() == string.Empty ? 0 : dr["FbActualWt"]);
                        paramFRGHT_BL[40] = new ParameterInfoOleDB("@FbFnclWt", dr["FbFnclWt"].ToString().Trim() == string.Empty ? 0 : dr["FbFnclWt"]);
                        paramFRGHT_BL[41] = new ParameterInfoOleDB("@InterlineScac", dr["InterlineScac"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineScac"]);
                        paramFRGHT_BL[42] = new ParameterInfoOleDB("@InterlineQual", dr["InterlineQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineQual"]);
                        paramFRGHT_BL[43] = new ParameterInfoOleDB("@InterlineAmt", dr["InterlineAmt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineAmt"]);
                        paramFRGHT_BL[44] = new ParameterInfoOleDB("@LmDist", dr["LmDist"].ToString().Trim() == string.Empty ? 0 : dr["LmDist"]);
                        paramFRGHT_BL[45] = new ParameterInfoOleDB("@LmPkupActualDtm", dr["LmPkupActualDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmPkupActualDtm"]);
                        paramFRGHT_BL[46] = new ParameterInfoOleDB("@LmAtaDtm", dr["LmAtaDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmAtaDtm"]);
                        paramFRGHT_BL[47] = new ParameterInfoOleDB("@PriceLaneLabl", dr["PriceLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PriceLaneLabl"]);
                        paramFRGHT_BL[48] = new ParameterInfoOleDB("@LmLaneLabl", dr["LmLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmLaneLabl"]);
                        paramFRGHT_BL[49] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);

                        paramFRGHT_BL[50] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFRGHT_BL[51] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFRGHT_BL[52] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFRGHT_BL[53] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        dr.RejectChanges();
                        paramFRGHT_BL[54] = new ParameterInfoOleDB("@FBId", dr["FbId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramFRGHT_BL = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramFRGHT_BL[0] = new ParameterInfoOleDB("@FbId", dr["FbId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);
                    }
                }
                #endregion
                #region FB_LN
                foreach (DataRow dr in dsBatch.Tables["FBLn"].Rows)
                {
                    ParameterInfoOleDB[] paramFB_LN;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramFB_LN = new ParameterInfoOleDB[25];
                        paramFB_LN[0] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        paramFB_LN[1] = new ParameterInfoOleDB("@LineItemNum", dr["LineItemNum"]);
                        paramFB_LN[2] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFB_LN[3] = new ParameterInfoOleDB("@QtyLabl", dr["QtyLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["QtyLabl"]);
                        paramFB_LN[4] = new ParameterInfoOleDB("@ChrgDesc", dr["ChrgDesc"].ToString().Trim() == string.Empty ? DBNull.Value : dr["ChrgDesc"]);
                        paramFB_LN[5] = new ParameterInfoOleDB("@RateAmt", dr["RateAmt"].ToString().Trim() == string.Empty ? 0 : dr["RateAmt"]);
                        paramFB_LN[6] = new ParameterInfoOleDB("@RateType", dr["RateType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateType"]);
                        paramFB_LN[7] = new ParameterInfoOleDB("@RateUntLabl", dr["RateUntLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateUntLabl"]);
                        paramFB_LN[8] = new ParameterInfoOleDB("@ChrgAmt", dr["ChrgAmt"].ToString().Trim() == string.Empty ? 0 : dr["ChrgAmt"]);
                        paramFB_LN[9] = new ParameterInfoOleDB("@CurrencyQual", dr["CurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CurrencyQual"]);
                        paramFB_LN[10] = new ParameterInfoOleDB("@Cat", dr["Cat"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Cat"]);
                        paramFB_LN[11] = new ParameterInfoOleDB("@PkgType", dr["PkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PkgType"]);
                        paramFB_LN[12] = new ParameterInfoOleDB("@PcsCnt", dr["PcsCnt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PcsCnt"]);
                        paramFB_LN[13] = new ParameterInfoOleDB("@LnChrgCode", dr["LnChrgCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnChrgCode"]);
                        paramFB_LN[14] = new ParameterInfoOleDB("@LnActualWt", dr["LnActualWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnActualWt"]);
                        paramFB_LN[15] = new ParameterInfoOleDB("@LnRateAsWt", dr["LnRateAsWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnRateAsWt"]);
                        paramFB_LN[16] = new ParameterInfoOleDB("@CmdtyClass", dr["CmdtyClass"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CmdtyClass"]);
                        paramFB_LN[17] = new ParameterInfoOleDB("@Facsimile01", dr["Facsimile01"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile01"]);
                        paramFB_LN[18] = new ParameterInfoOleDB("@Facsimile02", dr["Facsimile02"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile02"]);
                        paramFB_LN[19] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_LN[20] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_LN[21] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_LN[22] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_LN[23] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_LN[24] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);

                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFB_LN, CommandType.Text, paramFB_LN);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramFB_LN = new ParameterInfoOleDB[27];
                        paramFB_LN[0] = new ParameterInfoOleDB("@FbIdNew", dr["FBId"]);
                        paramFB_LN[1] = new ParameterInfoOleDB("@LineItemNumNew", dr["LineItemNum"]);
                        paramFB_LN[2] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                        paramFB_LN[3] = new ParameterInfoOleDB("@QtyLabl", dr["QtyLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["QtyLabl"]);
                        paramFB_LN[4] = new ParameterInfoOleDB("@ChrgDesc", dr["ChrgDesc"].ToString().Trim() == string.Empty ? DBNull.Value : dr["ChrgDesc"]);
                        paramFB_LN[5] = new ParameterInfoOleDB("@RateAmt", dr["RateAmt"].ToString().Trim() == string.Empty ? 0 : dr["RateAmt"]);
                        paramFB_LN[6] = new ParameterInfoOleDB("@RateType", dr["RateType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateType"]);
                        paramFB_LN[7] = new ParameterInfoOleDB("@RateUntLabl", dr["RateUntLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["RateUntLabl"]);
                        paramFB_LN[8] = new ParameterInfoOleDB("@ChrgAmt", dr["ChrgAmt"].ToString().Trim() == string.Empty ? 0 : dr["ChrgAmt"]);
                        paramFB_LN[9] = new ParameterInfoOleDB("@CurrencyQual", dr["CurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CurrencyQual"]);
                        paramFB_LN[10] = new ParameterInfoOleDB("@Cat", dr["Cat"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Cat"]);
                        paramFB_LN[11] = new ParameterInfoOleDB("@PkgType", dr["PkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PkgType"]);
                        paramFB_LN[12] = new ParameterInfoOleDB("@PcsCnt", dr["PcsCnt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PcsCnt"]);
                        paramFB_LN[13] = new ParameterInfoOleDB("@LnChrgCode", dr["LnChrgCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnChrgCode"]);
                        paramFB_LN[14] = new ParameterInfoOleDB("@LnActualWt", dr["LnActualWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnActualWt"]);
                        paramFB_LN[15] = new ParameterInfoOleDB("@LnRateAsWt", dr["LnRateAsWt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LnRateAsWt"]);
                        paramFB_LN[16] = new ParameterInfoOleDB("@CmdtyClass", dr["CmdtyClass"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CmdtyClass"]);
                        paramFB_LN[17] = new ParameterInfoOleDB("@Facsimile01", dr["Facsimile01"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile01"]);
                        paramFB_LN[18] = new ParameterInfoOleDB("@Facsimile02", dr["Facsimile02"].ToString().Trim() == string.Empty ? DBNull.Value : dr["Facsimile02"]);
                        paramFB_LN[19] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_LN[20] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_LN[21] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_LN[22] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_LN[23] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_LN[24] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);
                        dr.RejectChanges();
                        paramFB_LN[25] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        paramFB_LN[26] = new ParameterInfoOleDB("@LineItemNum", dr["LineItemNum"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryFB_LN, CommandType.Text, paramFB_LN);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramFB_LN = new ParameterInfoOleDB[2];
                        dr.RejectChanges();
                        paramFB_LN[0] = new ParameterInfoOleDB("@FbId", dr["FbId"]);
                        paramFB_LN[1] = new ParameterInfoOleDB("@LineItemNum", dr["LineItemNum"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryFB_LN, CommandType.Text, paramFB_LN);
                    }
                }
                #endregion
                #region FXI
                foreach (DataRow dr in dsBatch.Tables["FXI"].Rows)
                {
                    ParameterInfoOleDB[] paramFB_FXI;
                    if (dr.RowState == DataRowState.Added)
                    {
                        paramFB_FXI = new ParameterInfoOleDB[125];
                        paramFB_FXI[0] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        paramFB_FXI[1] = new ParameterInfoOleDB("@InvPageNum", dr["InvPageNum"].ToString().Trim() == string.Empty ? 1 : dr["InvPageNum"]);
                        paramFB_FXI[2] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramFB_FXI[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFB_FXI[4] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        paramFB_FXI[5] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_FXI[6] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_FXI[7] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_FXI[8] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_FXI[9] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_FXI[10] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);
                        paramFB_FXI[11] = new ParameterInfoOleDB("@T007", dr["T007"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T007"]);
                        paramFB_FXI[12] = new ParameterInfoOleDB("@T008", dr["T008"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T008"]);
                        paramFB_FXI[13] = new ParameterInfoOleDB("@T009", dr["T009"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T009"]);
                        paramFB_FXI[14] = new ParameterInfoOleDB("@T010", dr["T010"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T010"]);
                        paramFB_FXI[15] = new ParameterInfoOleDB("@T011", dr["T011"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T011"]);
                        paramFB_FXI[16] = new ParameterInfoOleDB("@T012", dr["T012"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T012"]);
                        paramFB_FXI[17] = new ParameterInfoOleDB("@T013", dr["T013"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T013"]);
                        paramFB_FXI[18] = new ParameterInfoOleDB("@T014", dr["T014"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T014"]);
                        paramFB_FXI[19] = new ParameterInfoOleDB("@T015", dr["T015"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T015"]);
                        paramFB_FXI[20] = new ParameterInfoOleDB("@T016", dr["T016"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T016"]);
                        paramFB_FXI[21] = new ParameterInfoOleDB("@T017", dr["T017"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T017"]);
                        paramFB_FXI[22] = new ParameterInfoOleDB("@T018", dr["T018"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T018"]);
                        paramFB_FXI[23] = new ParameterInfoOleDB("@T019", dr["T019"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T019"]);
                        paramFB_FXI[24] = new ParameterInfoOleDB("@T020", dr["T020"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T020"]);
                        paramFB_FXI[25] = new ParameterInfoOleDB("@T021", dr["T021"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T021"]);
                        paramFB_FXI[26] = new ParameterInfoOleDB("@T022", dr["T022"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T022"]);
                        paramFB_FXI[27] = new ParameterInfoOleDB("@T023", dr["T023"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T023"]);
                        paramFB_FXI[28] = new ParameterInfoOleDB("@T024", dr["T024"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T024"]);
                        paramFB_FXI[29] = new ParameterInfoOleDB("@T025", dr["T025"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T025"]);
                        paramFB_FXI[30] = new ParameterInfoOleDB("@T026", dr["T026"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T026"]);
                        paramFB_FXI[31] = new ParameterInfoOleDB("@T027", dr["T027"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T027"]);
                        paramFB_FXI[32] = new ParameterInfoOleDB("@T028", dr["T028"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T028"]);
                        paramFB_FXI[33] = new ParameterInfoOleDB("@T029", dr["T029"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T029"]);
                        paramFB_FXI[34] = new ParameterInfoOleDB("@T030", dr["T030"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T030"]);
                        paramFB_FXI[35] = new ParameterInfoOleDB("@T031", dr["T031"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T031"]);
                        paramFB_FXI[36] = new ParameterInfoOleDB("@T032", dr["T032"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T032"]);
                        paramFB_FXI[37] = new ParameterInfoOleDB("@T033", dr["T033"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T033"]);
                        paramFB_FXI[38] = new ParameterInfoOleDB("@T034", dr["T034"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T034"]);
                        paramFB_FXI[39] = new ParameterInfoOleDB("@T035", dr["T035"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T035"]);
                        paramFB_FXI[40] = new ParameterInfoOleDB("@T036", dr["T036"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T036"]);
                        paramFB_FXI[41] = new ParameterInfoOleDB("@T037", dr["T037"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T037"]);
                        paramFB_FXI[42] = new ParameterInfoOleDB("@T038", dr["T038"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T038"]);
                        paramFB_FXI[43] = new ParameterInfoOleDB("@T039", dr["T039"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T039"]);
                        paramFB_FXI[44] = new ParameterInfoOleDB("@T040", dr["T040"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T040"]);
                        paramFB_FXI[45] = new ParameterInfoOleDB("@T041", dr["T041"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T041"]);
                        paramFB_FXI[46] = new ParameterInfoOleDB("@T042", dr["T042"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T042"]);
                        paramFB_FXI[47] = new ParameterInfoOleDB("@T043", dr["T043"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T043"]);
                        paramFB_FXI[48] = new ParameterInfoOleDB("@T044", dr["T044"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T044"]);
                        paramFB_FXI[49] = new ParameterInfoOleDB("@T045", dr["T045"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T045"]);
                        paramFB_FXI[50] = new ParameterInfoOleDB("@T046", dr["T046"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T046"]);
                        paramFB_FXI[51] = new ParameterInfoOleDB("@T047", dr["T047"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T047"]);
                        paramFB_FXI[52] = new ParameterInfoOleDB("@T048", dr["T048"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T048"]);
                        paramFB_FXI[53] = new ParameterInfoOleDB("@T049", dr["T049"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T049"]);
                        paramFB_FXI[54] = new ParameterInfoOleDB("@T050", dr["T050"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T050"]);
                        paramFB_FXI[55] = new ParameterInfoOleDB("@T051", dr["T051"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T051"]);
                        paramFB_FXI[56] = new ParameterInfoOleDB("@T052", dr["T052"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T052"]);
                        paramFB_FXI[57] = new ParameterInfoOleDB("@T053", dr["T053"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T053"]);
                        paramFB_FXI[58] = new ParameterInfoOleDB("@T054", dr["T054"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T054"]);
                        paramFB_FXI[59] = new ParameterInfoOleDB("@T055", dr["T055"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T055"]);
                        paramFB_FXI[60] = new ParameterInfoOleDB("@T056", dr["T056"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T056"]);
                        paramFB_FXI[61] = new ParameterInfoOleDB("@T057", dr["T057"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T057"]);
                        paramFB_FXI[62] = new ParameterInfoOleDB("@T058", dr["T058"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T058"]);
                        paramFB_FXI[63] = new ParameterInfoOleDB("@T059", dr["T059"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T059"]);
                        paramFB_FXI[64] = new ParameterInfoOleDB("@T060", dr["T060"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T060"]);
                        paramFB_FXI[65] = new ParameterInfoOleDB("@T061", dr["T061"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T061"]);
                        paramFB_FXI[66] = new ParameterInfoOleDB("@T062", dr["T062"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T062"]);
                        paramFB_FXI[67] = new ParameterInfoOleDB("@T063", dr["T063"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T063"]);
                        paramFB_FXI[68] = new ParameterInfoOleDB("@T064", dr["T064"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T064"]);
                        paramFB_FXI[69] = new ParameterInfoOleDB("@T065", dr["T065"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T065"]);
                        paramFB_FXI[70] = new ParameterInfoOleDB("@T066", dr["T066"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T066"]);
                        paramFB_FXI[71] = new ParameterInfoOleDB("@T067", dr["T067"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T067"]);
                        paramFB_FXI[72] = new ParameterInfoOleDB("@T068", dr["T068"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T068"]);
                        paramFB_FXI[73] = new ParameterInfoOleDB("@T069", dr["T069"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T069"]);
                        paramFB_FXI[74] = new ParameterInfoOleDB("@T070", dr["T070"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T070"]);
                        paramFB_FXI[75] = new ParameterInfoOleDB("@T071", dr["T071"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T071"]);
                        paramFB_FXI[76] = new ParameterInfoOleDB("@T072", dr["T072"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T072"]);
                        paramFB_FXI[77] = new ParameterInfoOleDB("@T073", dr["T073"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T073"]);
                        paramFB_FXI[78] = new ParameterInfoOleDB("@T074", dr["T074"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T074"]);
                        paramFB_FXI[79] = new ParameterInfoOleDB("@T075", dr["T075"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T075"]);
                        paramFB_FXI[80] = new ParameterInfoOleDB("@T076", dr["T076"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T076"]);
                        paramFB_FXI[81] = new ParameterInfoOleDB("@T077", dr["T077"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T077"]);
                        paramFB_FXI[82] = new ParameterInfoOleDB("@T078", dr["T078"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T078"]);
                        paramFB_FXI[83] = new ParameterInfoOleDB("@T079", dr["T079"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T079"]);
                        paramFB_FXI[84] = new ParameterInfoOleDB("@T080", dr["T080"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T080"]);
                        paramFB_FXI[85] = new ParameterInfoOleDB("@T081", dr["T081"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T081"]);
                        paramFB_FXI[86] = new ParameterInfoOleDB("@T082", dr["T082"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T082"]);
                        paramFB_FXI[87] = new ParameterInfoOleDB("@T083", dr["T083"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T083"]);
                        paramFB_FXI[88] = new ParameterInfoOleDB("@T084", dr["T084"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T084"]);
                        paramFB_FXI[89] = new ParameterInfoOleDB("@T085", dr["T085"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T085"]);
                        paramFB_FXI[90] = new ParameterInfoOleDB("@T086", dr["T086"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T086"]);
                        paramFB_FXI[91] = new ParameterInfoOleDB("@T087", dr["T087"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T087"]);
                        paramFB_FXI[92] = new ParameterInfoOleDB("@T088", dr["T088"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T088"]);
                        paramFB_FXI[93] = new ParameterInfoOleDB("@T089", dr["T089"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T089"]);
                        paramFB_FXI[94] = new ParameterInfoOleDB("@T090", dr["T090"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T090"]);
                        paramFB_FXI[95] = new ParameterInfoOleDB("@T091", dr["T091"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T091"]);
                        paramFB_FXI[96] = new ParameterInfoOleDB("@T092", dr["T092"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T092"]);
                        paramFB_FXI[97] = new ParameterInfoOleDB("@T093", dr["T093"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T093"]);
                        paramFB_FXI[98] = new ParameterInfoOleDB("@T094", dr["T094"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T094"]);
                        paramFB_FXI[99] = new ParameterInfoOleDB("@T095", dr["T095"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T095"]);
                        paramFB_FXI[100] = new ParameterInfoOleDB("@T096", dr["T096"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T096"]);
                        paramFB_FXI[101] = new ParameterInfoOleDB("@T097", dr["T097"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T097"]);
                        paramFB_FXI[102] = new ParameterInfoOleDB("@T098", dr["T098"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T098"]);
                        paramFB_FXI[103] = new ParameterInfoOleDB("@T099", dr["T099"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T099"]);
                        paramFB_FXI[104] = new ParameterInfoOleDB("@T100", dr["T100"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T100"]);
                        paramFB_FXI[105] = new ParameterInfoOleDB("@T101", dr["T101"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T101"]);
                        paramFB_FXI[106] = new ParameterInfoOleDB("@T102", dr["T102"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T102"]);
                        paramFB_FXI[107] = new ParameterInfoOleDB("@T103", dr["T103"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T103"]);
                        paramFB_FXI[108] = new ParameterInfoOleDB("@T104", dr["T104"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T104"]);
                        paramFB_FXI[109] = new ParameterInfoOleDB("@T105", dr["T105"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T105"]);
                        paramFB_FXI[110] = new ParameterInfoOleDB("@T106", dr["T106"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T106"]);
                        paramFB_FXI[111] = new ParameterInfoOleDB("@T107", dr["T107"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T107"]);
                        paramFB_FXI[112] = new ParameterInfoOleDB("@T108", dr["T108"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T108"]);
                        paramFB_FXI[113] = new ParameterInfoOleDB("@T109", dr["T109"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T109"]);
                        paramFB_FXI[114] = new ParameterInfoOleDB("@T110", dr["T110"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T110"]);
                        paramFB_FXI[115] = new ParameterInfoOleDB("@T111", dr["T111"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T111"]);
                        paramFB_FXI[116] = new ParameterInfoOleDB("@T112", dr["T112"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T112"]);
                        paramFB_FXI[117] = new ParameterInfoOleDB("@T113", dr["T113"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T113"]);
                        paramFB_FXI[118] = new ParameterInfoOleDB("@T114", dr["T114"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T114"]);
                        paramFB_FXI[119] = new ParameterInfoOleDB("@T115", dr["T115"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T115"]);
                        paramFB_FXI[120] = new ParameterInfoOleDB("@T116", dr["T116"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T116"]);
                        paramFB_FXI[121] = new ParameterInfoOleDB("@T117", dr["T117"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T117"]);
                        paramFB_FXI[122] = new ParameterInfoOleDB("@T118", dr["T118"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T118"]);
                        paramFB_FXI[123] = new ParameterInfoOleDB("@T119", dr["T119"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T119"]);
                        paramFB_FXI[124] = new ParameterInfoOleDB("@T120", dr["T120"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T120"]);

                        affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFXI, CommandType.Text, paramFB_FXI);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        paramFB_FXI = new ParameterInfoOleDB[126];
                        paramFB_FXI[0] = new ParameterInfoOleDB("@FbIdNew", dr["FBId"]);
                        paramFB_FXI[1] = new ParameterInfoOleDB("@InvPageNum", dr["InvPageNum"].ToString().Trim() == string.Empty ? 1 : dr["InvPageNum"]);
                        paramFB_FXI[2] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                        paramFB_FXI[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFB_FXI[4] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                        paramFB_FXI[5] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                        paramFB_FXI[6] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                        paramFB_FXI[7] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                        paramFB_FXI[8] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                        paramFB_FXI[9] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                        paramFB_FXI[10] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);
                        paramFB_FXI[11] = new ParameterInfoOleDB("@T007", dr["T007"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T007"]);
                        paramFB_FXI[12] = new ParameterInfoOleDB("@T008", dr["T008"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T008"]);
                        paramFB_FXI[13] = new ParameterInfoOleDB("@T009", dr["T009"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T009"]);
                        paramFB_FXI[14] = new ParameterInfoOleDB("@T010", dr["T010"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T010"]);
                        paramFB_FXI[15] = new ParameterInfoOleDB("@T011", dr["T011"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T011"]);
                        paramFB_FXI[16] = new ParameterInfoOleDB("@T012", dr["T012"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T012"]);
                        paramFB_FXI[17] = new ParameterInfoOleDB("@T013", dr["T013"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T013"]);
                        paramFB_FXI[18] = new ParameterInfoOleDB("@T014", dr["T014"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T014"]);
                        paramFB_FXI[19] = new ParameterInfoOleDB("@T015", dr["T015"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T015"]);
                        paramFB_FXI[20] = new ParameterInfoOleDB("@T016", dr["T016"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T016"]);
                        paramFB_FXI[21] = new ParameterInfoOleDB("@T017", dr["T017"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T017"]);
                        paramFB_FXI[22] = new ParameterInfoOleDB("@T018", dr["T018"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T018"]);
                        paramFB_FXI[23] = new ParameterInfoOleDB("@T019", dr["T019"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T019"]);
                        paramFB_FXI[24] = new ParameterInfoOleDB("@T020", dr["T020"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T020"]);
                        paramFB_FXI[25] = new ParameterInfoOleDB("@T021", dr["T021"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T021"]);
                        paramFB_FXI[26] = new ParameterInfoOleDB("@T022", dr["T022"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T022"]);
                        paramFB_FXI[27] = new ParameterInfoOleDB("@T023", dr["T023"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T023"]);
                        paramFB_FXI[28] = new ParameterInfoOleDB("@T024", dr["T024"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T024"]);
                        paramFB_FXI[29] = new ParameterInfoOleDB("@T025", dr["T025"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T025"]);
                        paramFB_FXI[30] = new ParameterInfoOleDB("@T026", dr["T026"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T026"]);
                        paramFB_FXI[31] = new ParameterInfoOleDB("@T027", dr["T027"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T027"]);
                        paramFB_FXI[32] = new ParameterInfoOleDB("@T028", dr["T028"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T028"]);
                        paramFB_FXI[33] = new ParameterInfoOleDB("@T029", dr["T029"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T029"]);
                        paramFB_FXI[34] = new ParameterInfoOleDB("@T030", dr["T030"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T030"]);
                        paramFB_FXI[35] = new ParameterInfoOleDB("@T031", dr["T031"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T031"]);
                        paramFB_FXI[36] = new ParameterInfoOleDB("@T032", dr["T032"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T032"]);
                        paramFB_FXI[37] = new ParameterInfoOleDB("@T033", dr["T033"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T033"]);
                        paramFB_FXI[38] = new ParameterInfoOleDB("@T034", dr["T034"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T034"]);
                        paramFB_FXI[39] = new ParameterInfoOleDB("@T035", dr["T035"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T035"]);
                        paramFB_FXI[40] = new ParameterInfoOleDB("@T036", dr["T036"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T036"]);
                        paramFB_FXI[41] = new ParameterInfoOleDB("@T037", dr["T037"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T037"]);
                        paramFB_FXI[42] = new ParameterInfoOleDB("@T038", dr["T038"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T038"]);
                        paramFB_FXI[43] = new ParameterInfoOleDB("@T039", dr["T039"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T039"]);
                        paramFB_FXI[44] = new ParameterInfoOleDB("@T040", dr["T040"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T040"]);
                        paramFB_FXI[45] = new ParameterInfoOleDB("@T041", dr["T041"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T041"]);
                        paramFB_FXI[46] = new ParameterInfoOleDB("@T042", dr["T042"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T042"]);
                        paramFB_FXI[47] = new ParameterInfoOleDB("@T043", dr["T043"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T043"]);
                        paramFB_FXI[48] = new ParameterInfoOleDB("@T044", dr["T044"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T044"]);
                        paramFB_FXI[49] = new ParameterInfoOleDB("@T045", dr["T045"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T045"]);
                        paramFB_FXI[50] = new ParameterInfoOleDB("@T046", dr["T046"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T046"]);
                        paramFB_FXI[51] = new ParameterInfoOleDB("@T047", dr["T047"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T047"]);
                        paramFB_FXI[52] = new ParameterInfoOleDB("@T048", dr["T048"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T048"]);
                        paramFB_FXI[53] = new ParameterInfoOleDB("@T049", dr["T049"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T049"]);
                        paramFB_FXI[54] = new ParameterInfoOleDB("@T050", dr["T050"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T050"]);
                        paramFB_FXI[55] = new ParameterInfoOleDB("@T051", dr["T051"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T051"]);
                        paramFB_FXI[56] = new ParameterInfoOleDB("@T052", dr["T052"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T052"]);
                        paramFB_FXI[57] = new ParameterInfoOleDB("@T053", dr["T053"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T053"]);
                        paramFB_FXI[58] = new ParameterInfoOleDB("@T054", dr["T054"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T054"]);
                        paramFB_FXI[59] = new ParameterInfoOleDB("@T055", dr["T055"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T055"]);
                        paramFB_FXI[60] = new ParameterInfoOleDB("@T056", dr["T056"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T056"]);
                        paramFB_FXI[61] = new ParameterInfoOleDB("@T057", dr["T057"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T057"]);
                        paramFB_FXI[62] = new ParameterInfoOleDB("@T058", dr["T058"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T058"]);
                        paramFB_FXI[63] = new ParameterInfoOleDB("@T059", dr["T059"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T059"]);
                        paramFB_FXI[64] = new ParameterInfoOleDB("@T060", dr["T060"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T060"]);
                        paramFB_FXI[65] = new ParameterInfoOleDB("@T061", dr["T061"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T061"]);
                        paramFB_FXI[66] = new ParameterInfoOleDB("@T062", dr["T062"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T062"]);
                        paramFB_FXI[67] = new ParameterInfoOleDB("@T063", dr["T063"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T063"]);
                        paramFB_FXI[68] = new ParameterInfoOleDB("@T064", dr["T064"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T064"]);
                        paramFB_FXI[69] = new ParameterInfoOleDB("@T065", dr["T065"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T065"]);
                        paramFB_FXI[70] = new ParameterInfoOleDB("@T066", dr["T066"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T066"]);
                        paramFB_FXI[71] = new ParameterInfoOleDB("@T067", dr["T067"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T067"]);
                        paramFB_FXI[72] = new ParameterInfoOleDB("@T068", dr["T068"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T068"]);
                        paramFB_FXI[73] = new ParameterInfoOleDB("@T069", dr["T069"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T069"]);
                        paramFB_FXI[74] = new ParameterInfoOleDB("@T070", dr["T070"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T070"]);
                        paramFB_FXI[75] = new ParameterInfoOleDB("@T071", dr["T071"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T071"]);
                        paramFB_FXI[76] = new ParameterInfoOleDB("@T072", dr["T072"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T072"]);
                        paramFB_FXI[77] = new ParameterInfoOleDB("@T073", dr["T073"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T073"]);
                        paramFB_FXI[78] = new ParameterInfoOleDB("@T074", dr["T074"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T074"]);
                        paramFB_FXI[79] = new ParameterInfoOleDB("@T075", dr["T075"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T075"]);
                        paramFB_FXI[80] = new ParameterInfoOleDB("@T076", dr["T076"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T076"]);
                        paramFB_FXI[81] = new ParameterInfoOleDB("@T077", dr["T077"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T077"]);
                        paramFB_FXI[82] = new ParameterInfoOleDB("@T078", dr["T078"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T078"]);
                        paramFB_FXI[83] = new ParameterInfoOleDB("@T079", dr["T079"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T079"]);
                        paramFB_FXI[84] = new ParameterInfoOleDB("@T080", dr["T080"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T080"]);
                        paramFB_FXI[85] = new ParameterInfoOleDB("@T081", dr["T081"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T081"]);
                        paramFB_FXI[86] = new ParameterInfoOleDB("@T082", dr["T082"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T082"]);
                        paramFB_FXI[87] = new ParameterInfoOleDB("@T083", dr["T083"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T083"]);
                        paramFB_FXI[88] = new ParameterInfoOleDB("@T084", dr["T084"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T084"]);
                        paramFB_FXI[89] = new ParameterInfoOleDB("@T085", dr["T085"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T085"]);
                        paramFB_FXI[90] = new ParameterInfoOleDB("@T086", dr["T086"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T086"]);
                        paramFB_FXI[91] = new ParameterInfoOleDB("@T087", dr["T087"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T087"]);
                        paramFB_FXI[92] = new ParameterInfoOleDB("@T088", dr["T088"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T088"]);
                        paramFB_FXI[93] = new ParameterInfoOleDB("@T089", dr["T089"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T089"]);
                        paramFB_FXI[94] = new ParameterInfoOleDB("@T090", dr["T090"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T090"]);
                        paramFB_FXI[95] = new ParameterInfoOleDB("@T091", dr["T091"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T091"]);
                        paramFB_FXI[96] = new ParameterInfoOleDB("@T092", dr["T092"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T092"]);
                        paramFB_FXI[97] = new ParameterInfoOleDB("@T093", dr["T093"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T093"]);
                        paramFB_FXI[98] = new ParameterInfoOleDB("@T094", dr["T094"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T094"]);
                        paramFB_FXI[99] = new ParameterInfoOleDB("@T095", dr["T095"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T095"]);
                        paramFB_FXI[100] = new ParameterInfoOleDB("@T096", dr["T096"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T096"]);
                        paramFB_FXI[101] = new ParameterInfoOleDB("@T097", dr["T097"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T097"]);
                        paramFB_FXI[102] = new ParameterInfoOleDB("@T098", dr["T098"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T098"]);
                        paramFB_FXI[103] = new ParameterInfoOleDB("@T099", dr["T099"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T099"]);
                        paramFB_FXI[104] = new ParameterInfoOleDB("@T100", dr["T100"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T100"]);
                        paramFB_FXI[105] = new ParameterInfoOleDB("@T101", dr["T101"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T101"]);
                        paramFB_FXI[106] = new ParameterInfoOleDB("@T102", dr["T102"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T102"]);
                        paramFB_FXI[107] = new ParameterInfoOleDB("@T103", dr["T103"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T103"]);
                        paramFB_FXI[108] = new ParameterInfoOleDB("@T104", dr["T104"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T104"]);
                        paramFB_FXI[109] = new ParameterInfoOleDB("@T105", dr["T105"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T105"]);
                        paramFB_FXI[110] = new ParameterInfoOleDB("@T106", dr["T106"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T106"]);
                        paramFB_FXI[111] = new ParameterInfoOleDB("@T107", dr["T107"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T107"]);
                        paramFB_FXI[112] = new ParameterInfoOleDB("@T108", dr["T108"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T108"]);
                        paramFB_FXI[113] = new ParameterInfoOleDB("@T109", dr["T109"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T109"]);
                        paramFB_FXI[114] = new ParameterInfoOleDB("@T110", dr["T110"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T110"]);
                        paramFB_FXI[115] = new ParameterInfoOleDB("@T111", dr["T111"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T111"]);
                        paramFB_FXI[116] = new ParameterInfoOleDB("@T112", dr["T112"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T112"]);
                        paramFB_FXI[117] = new ParameterInfoOleDB("@T113", dr["T113"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T113"]);
                        paramFB_FXI[118] = new ParameterInfoOleDB("@T114", dr["T114"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T114"]);
                        paramFB_FXI[119] = new ParameterInfoOleDB("@T115", dr["T115"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T115"]);
                        paramFB_FXI[120] = new ParameterInfoOleDB("@T116", dr["T116"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T116"]);
                        paramFB_FXI[121] = new ParameterInfoOleDB("@T117", dr["T117"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T117"]);
                        paramFB_FXI[122] = new ParameterInfoOleDB("@T118", dr["T118"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T118"]);
                        paramFB_FXI[123] = new ParameterInfoOleDB("@T119", dr["T119"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T119"]);
                        paramFB_FXI[124] = new ParameterInfoOleDB("@T120", dr["T120"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T120"]);
                        dr.RejectChanges();
                        paramFB_FXI[125] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(updateQueryFXI, CommandType.Text, paramFB_FXI);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        paramFB_FXI = new ParameterInfoOleDB[1];
                        dr.RejectChanges();
                        paramFB_FXI[0] = new ParameterInfoOleDB("@FbId", dr["FbId"]);
                        affectedRows = dalMXXDatabase.ExecuteNonQuery(deleteQueryFXI, CommandType.Text, paramFB_FXI);
                    }
                }
                #endregion
                dalMXXDatabase.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dalMXXDatabase.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dalMXXDatabase.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public void makeMDBCopy(string batchNumber)
        {
            string filePath = ConfigurationManager.AppSettings["MDBSourcePath"] + "batchxxx";
            string newfile = ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batchNumber + ".mdb";
            if (!File.Exists(newfile))
            {
                try
                {
                    File.Copy(filePath, newfile);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
