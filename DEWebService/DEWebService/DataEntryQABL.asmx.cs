using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Xml;
using System.Configuration;
using DAL;
using CommonLibrary;
using Trax.FPS;
using Filex.MSharp.Lib.Common;
using System.Deployment.Application;
using System.Runtime.Serialization;
using Filex.Xml.XmlToEdi;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace DEWebService
{
    /// <summary>
    /// Summary description for DataEntryQABL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataEntryQABL : BaseBLogic
    {
        protected DALHelperOleDB dalMXXDatabase;

        public DataEntryQABL()
        { }

        public override void setQueries()
        {   /*
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


            insertQueryGlobalINV_BAT = @"INSERT INTO [batmdb_INV_BAT]
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

            insertQueryGlobalINVOICE = @"INSERT INTO [batmdb_Invoice]
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
                                LOC_ID_BLNG AS LocIdBlng
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
                                        ,TX_LM_DIST)
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
                                        ,0)";

            insertQueryGlobalFRGHT_BL = @"INSERT INTO [batmdb_FRGHT_BL]
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

            insertQueryGlobalFB_LN = @"INSERT INTO [batmdb_FB_LN]
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

            insertQueryGlobalFXI = @"INSERT INTO batmdb_FXI
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
            #region TR_BAT
            insertQueryGlobalTR_BAT = @"INSERT INTO [TR_BAT]
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

            #endregion*/
        }

        #region DataEntry
        [WebMethod]
        public DataSet selectBatches(object FormMode)
        {
            CommonEnum.FormMode formMode = (CommonEnum.FormMode)FormMode;
            DataSet retval = new DataSet();
            string query = string.Empty;
            switch (formMode)
            {
                case CommonEnum.FormMode.DATA_ENTRY:
                    {
                        query = string.Format(@"SELECT BDE.Bat_Ctrl_Num AS [Batch Number],
                                    BDE.Batch_Status AS [Batch Status],
                                    BDE.Owner_Key AS [Owner Key],
                                    BDE.Vend_SCAC AS [Vendor SCAC],
                                    BDE.Oper_Init AS [Operator],
                                    BDE.Rev_Init AS [QA By],
                                    BDE.Owner_Code AS [OwnerCode],
                                    ceiling(round((DateDiff(mi,DateAdd(hh,14,BDE.NEW_DTM),GETDATE()))/1440.00,4)) AS BatchAge
                                FROM Batch_DE(NOLOCK) BDE                            
                                JOIN Batch_DE_Ext(NOLOCK) BDX ON BDE.BatchID = BDX.BatchID AND BDX.DEVer = 'NEW'
                                WHERE BDE.Batch_Status NOT IN ('MOVE TO CR','DE COMPLETE', 'OPENQA', 'SPLIT','SPLIT COMPLETE','COMBINED') AND BDE.Active = 1
                                AND BDX.DESiteID = {0}
                                --AND BDX.DESupplierID = {1}
                            ORDER BY BDE.Bat_Ctrl_Num", ConfigurationManager.AppSettings["SiteID"], CommonUserLogin.getUser().SupplierID);
                        break;
                    }

                case CommonEnum.FormMode.QUALITY_ASSURANCE:
                    {
                        query = string.Format(@"SELECT BDE.Bat_Ctrl_Num AS [Batch Number],
                                    BDE.Batch_Status AS [Batch Status],
                                    BDE.Owner_Key AS [Owner Key],
                                    BDE.Vend_SCAC AS [Vendor SCAC],
                                    BDE.Oper_Init AS [Operator],
                                    BDE.Rev_Init AS [QA By],
                                    BDE.Owner_Code AS [OwnerCode],
                                    ceiling(round((DateDiff(mi,DateAdd(hh,14,BDE.NEW_DTM),GETDATE()))/1440.00,4)) AS BatchAge
                            FROM Batch_DE(NOLOCK) BDE
                            JOIN Batch_DE_Ext(NOLOCK) BDX ON BDE.BatchID = BDX.BatchID AND BDX.DEVer = 'NEW'
                            WHERE BDE.Batch_Status IN ('REVIEW','OPENQA')AND BDE.Active = 1 
                            AND BDX.QASiteID = {0}
                            AND BDX.QASupplierID = {1}                          
                            ORDER BY BatchAge DESC", ConfigurationManager.AppSettings["SiteID"], CommonUserLogin.getUser().SupplierID);
                        break;
                    }
                case CommonEnum.FormMode.DATA_ENTRY_TRAINER:
                    {
                        query = @"SELECT Bat_Ctrl_Num AS [Batch Number],
                                    'IN DE' AS [Batch Status],
                                    Owner_Key AS [Owner Key],
                                    Vend_SCAC AS [Vendor SCAC],
                                    '' AS [Operator],
                                    '' AS [QA By],
                                    Owner_Code AS [OwnerCode],
                                    0 AS BatchAge
                            FROM Batch_DETrainer(NOLOCK)
                            ORDER BY Bat_Ctrl_Num";
                        break;
                    }
            }
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
        public DataSet selectKeyIdentifier()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT * FROM KeyIdentifier(NOLOCK)";
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

        private DataSet selectShipperConsignee()
        {
            DataSet retval = new DataSet();
            DataSet dsShipper = new DataSet();
            DataSet dsConsignee = new DataSet();
            string queryShipper = @"SELECT TOP(10)
                                        AL_ORIG_1 AS Name1,
                                        AL_ORIG_2 AS Name2,
                                        AL_ORIG_3 AS Address1,
                                        AL_ORIG_4 AS Address2,
                                        AL_CITY_ORIG AS City,
                                        AL_STATE_PROV_ORIG AS St,
                                        AL_POST_CODE_ORIG AS Zip,
                                        AL_CNTRY_CODE_ORIG AS Country
                                    FROM SHIPPER(NOLOCK)";
            string queryConsignee = @"SELECT TOP(10)
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
        public string selectDEForm(string batCtrlNum, string OwnerKey, string SCAC)
        {
            string retval = string.Empty;
            DataSet ds = new DataSet();
            DataSet dsForm = new DataSet();
            string query = @"SELECT NEW_DTM 
                            FROM Batch_DE(nolock)
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";

            string formQuery = @"SELECT DEFormName FROM DEAppFormConfig
                                    WHERE DeAppFormConfigId = dbo.fn_getDEForm(@Owner_Key,@Vend_SCAC,@NEW_DTM)";

            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                ParameterInfo[] paramFrom = new ParameterInfo[3];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                paramFrom[0] = new ParameterInfo("@Owner_Key", OwnerKey);
                paramFrom[1] = new ParameterInfo("@Vend_SCAC", SCAC);
                
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                paramFrom[2] = new ParameterInfo("@NEW_DTM", ds.Tables[0].Rows[0]["NEW_DTM"].ToString());
                dsForm = dal.ExecuteDataSet(formQuery, CommandType.Text, paramFrom);

                retval = dsForm.Tables[0].Rows[0]["DEFormName"].ToString();
            }
            catch (Exception e)
            {
                return string.Empty;
            }
            finally
            {
                dal.CloseDB();
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
                param[0] = new ParameterInfo("@Oper_Init", UserInitials);
                param[1] = new ParameterInfo("@UTCDate", this.GetServerDate(dal));
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
                dsRoot = dal.ExecuteDataSet(rootQuery, CommandType.Text, param);
                isRootBatch = Convert.ToInt32(dsRoot.Tables[0].Rows[0][0]) > 0;
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0] != null)
                {
                    if (ds.Tables[0].Rows[0][0].ToString().Trim() == UserInitials)
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
                if (File.Exists(ConfigurationManager.AppSettings["ObjQADestinationPath"] + batCtrlNum + ".xml"))
                    File.Delete(ConfigurationManager.AppSettings["ObjQADestinationPath"] + batCtrlNum + ".xml");
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
        public bool updateStatus(string batCtrlNum, string status)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE Batch_DE
                                    SET Batch_Status = @Status                            
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
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
        public bool saveBatchXML(DataSet dsBatch, string MXXDatabase, object FormMode)
        {
            CommonEnum.FormMode formMode = (CommonEnum.FormMode)FormMode;
            bool retval = false;
            try
            {                
                 
                string filename = string.Empty;
                if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                    filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".xml";
                else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                    filename = ConfigurationManager.AppSettings["ObjQADestinationPath"] + MXXDatabase + ".xml";

                else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
                {
                    if (!Directory.Exists(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID))
                        Directory.CreateDirectory(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID);

                    filename = ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID + "\\" + MXXDatabase + ".xml";
                }
                dsBatch.Relations.Clear();
                DataRelation drInvBatInvoice = new DataRelation("InvBatInvoice", dsBatch.Tables["InvBat"].Columns["BatId"], dsBatch.Tables["Invoice"].Columns["BatId"]);
                DataRelation drInvoiceFrghtBl = new DataRelation("InvoiceFrghtBl", dsBatch.Tables["Invoice"].Columns["InvId"], dsBatch.Tables["FrghtBl"].Columns["InvId"]);
                DataRelation drFrghtBlAddrs = new DataRelation("FrghtBlAddrs", dsBatch.Tables["FrghtBl"].Columns["FbId"], dsBatch.Tables["Addrs"].Columns["FbId"]);
                DataRelation drFrghtBlKeyIdents = new DataRelation("FrghtBlKeyIdents", dsBatch.Tables["FrghtBl"].Columns["FbId"], dsBatch.Tables["KeyIdents"].Columns["FbId"]);
                DataRelation drFrghtBlCntnrs = new DataRelation("FrghtBlCntnrs", dsBatch.Tables["FrghtBl"].Columns["FbId"], dsBatch.Tables["Cntnrs"].Columns["FbId"]);
                DataRelation drFrghtBlProdDtl = new DataRelation("FrghtBlProdDtl", dsBatch.Tables["FrghtBl"].Columns["FbId"], dsBatch.Tables["ProdDtl"].Columns["FbId"]);
                DataRelation drFrghtBlFbLn = new DataRelation("FrghtBlFbLn", dsBatch.Tables["FrghtBl"].Columns["FbId"], dsBatch.Tables["FbLn"].Columns["FbId"]);
                drInvBatInvoice.Nested = true;
                drInvoiceFrghtBl.Nested = true;
                drFrghtBlAddrs.Nested = true;
                drFrghtBlKeyIdents.Nested = true;
                drFrghtBlCntnrs.Nested = true;
                drFrghtBlProdDtl.Nested = true;
                drFrghtBlFbLn.Nested = true;
                dsBatch.Relations.Add(drInvBatInvoice);
                dsBatch.Relations.Add(drInvoiceFrghtBl);
                dsBatch.Relations.Add(drFrghtBlAddrs);
                dsBatch.Relations.Add(drFrghtBlKeyIdents);
                dsBatch.Relations.Add(drFrghtBlCntnrs);
                dsBatch.Relations.Add(drFrghtBlProdDtl);
                dsBatch.Relations.Add(drFrghtBlFbLn);
                dsBatch.WriteXml(filename);                
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
        public DataSet selectBatchXML(string MXXDatabase, object FormMode)
        {
            CommonEnum.FormMode formMode = (CommonEnum.FormMode)FormMode;
            string xmlVerionName = string.Empty;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                xmlVerionName = "ver." + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + "-" + MXXDatabase;
            }
            else
            { 
                xmlVerionName = "ver.Development-" + MXXDatabase;
            }
            DataSet retval = new DataSet(xmlVerionName);
            DataTable tableInvBat = GetInvBatRowStructureXML();
            DataTable tableInvoice = GetInvoiceRowStructureXML();
            DataTable tableFrghtBl = GetFrghtBlRowStructureXML();
            DataTable tableAddrs = GetAddrsRowStructureXML();
            DataTable tableKeyIdents = GetKeyIdentsRowStructureXML();
            DataTable tableCntnrs = GetCntnrsRowStructureXML();
            DataTable tableProdDtl = GetProdDtlRowStructureXML();
            DataTable tableFbLnRow = GetFbLnRowStructureXML();
            retval.Tables.Add(tableInvBat.Copy());
            retval.Tables[0].AcceptChanges();
            retval.Tables.Add(tableInvoice.Copy());
            retval.Tables[1].AcceptChanges();
            retval.Tables.Add(tableFrghtBl.Copy());
            retval.Tables[2].AcceptChanges();
            retval.Tables.Add(tableAddrs.Copy());
            retval.Tables[3].AcceptChanges();
            retval.Tables.Add(tableKeyIdents.Copy());
            retval.Tables[4].AcceptChanges();
            retval.Tables.Add(tableCntnrs.Copy());
            retval.Tables[5].AcceptChanges();
            retval.Tables.Add(tableProdDtl.Copy());
            retval.Tables[6].AcceptChanges();
            retval.Tables.Add(tableFbLnRow.Copy());
            retval.Tables[7].AcceptChanges();
            string filename = string.Empty;
            if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".xml";
            else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
            {
                filename = ConfigurationManager.AppSettings["ObjQADestinationPath"] + MXXDatabase + ".xml";
                try
                {
                    if (!File.Exists(filename))
                        File.Copy(ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".xml", filename);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
            {
                if (!Directory.Exists(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID))
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID);

                filename = ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID + "\\" + MXXDatabase + ".xml";                
            }
            if (File.Exists(filename))
            {
                foreach (DataTable dataTable in retval.Tables)
                    dataTable.BeginLoadData();
                retval.ReadXml(filename);
                foreach (DataTable dataTable in retval.Tables)
                    dataTable.EndLoadData();
            }
            //else
            //    retval = selectBatchObj(MXXDatabase, formMode, retval);            
            retval.EnforceConstraints = true;
            return retval;
        }

        [WebMethod]
        public DataSet selectBatchEphesoftXML(string MXXDatabase)
        {
            string xmlVerionName = string.Empty;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                xmlVerionName = "ver." + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + "-" + MXXDatabase;
            }
            else
            {
                xmlVerionName = "ver.Development-" + MXXDatabase;
            }
            DataSet retval = new DataSet(xmlVerionName);
            DataTable tableInvBat = GetInvBatRowStructureXML();
            DataTable tableInvoice = GetInvoiceRowStructureXML();
            DataTable tableFrghtBl = GetFrghtBlRowStructureXML();
            DataTable tableAddrs = GetAddrsRowStructureXML();
            DataTable tableKeyIdents = GetKeyIdentsRowStructureXML();
            DataTable tableCntnrs = GetCntnrsRowStructureXML();
            DataTable tableProdDtl = GetProdDtlRowStructureXML();
            DataTable tableFbLnRow = GetFbLnRowStructureXML();
            retval.Tables.Add(tableInvBat.Copy());
            retval.Tables[0].AcceptChanges();
            retval.Tables.Add(tableInvoice.Copy());
            retval.Tables[1].AcceptChanges();
            retval.Tables.Add(tableFrghtBl.Copy());
            retval.Tables[2].AcceptChanges();
            retval.Tables.Add(tableAddrs.Copy());
            retval.Tables[3].AcceptChanges();
            retval.Tables.Add(tableKeyIdents.Copy());
            retval.Tables[4].AcceptChanges();
            retval.Tables.Add(tableCntnrs.Copy());
            retval.Tables[5].AcceptChanges();
            retval.Tables.Add(tableProdDtl.Copy());
            retval.Tables[6].AcceptChanges();
            retval.Tables.Add(tableFbLnRow.Copy());
            retval.Tables[7].AcceptChanges();
            string filename = string.Empty;
            filename = ConfigurationManager.AppSettings["ObjDestinationPathEphesoft"] + MXXDatabase + ".xml";            
            if (File.Exists(filename))
            {
                foreach (DataTable dataTable in retval.Tables)
                    dataTable.BeginLoadData();
                retval.ReadXml(filename);
                foreach (DataTable dataTable in retval.Tables)
                    dataTable.EndLoadData();
            }
            //else
            //    retval = selectBatchObj(MXXDatabase, formMode, retval);
            retval.EnforceConstraints = true;
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
        #endregion

        #region QualityAssurance
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
        public bool isAllowUserQA(string batCtrlNum, string UserInitials)
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
                    if (ds.Tables[0].Rows[0][0].ToString().Trim() == UserInitials)
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

        [WebMethod]
        public bool startReview(string batCtrlNum, string UserInitials)
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
                param[0] = new ParameterInfo("@Rev_Init", UserInitials);
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

        [WebMethod]
        public bool completeReview(string batCtrlNum, string OwnerKey, string OwnerCode, int invoiceCount, int fbCount, int fbLineCount, bool isMultiCurrency, bool isFullQA, string UserInitials)
        {
            bool retval = false;
            bool isSplitBatch = false;            
            int affectedRows = 0;            
            DataSet ds = new DataSet();
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
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                ParameterInfo[] param = new ParameterInfo[7];
                param[0] = new ParameterInfo("@Rev_Init", UserInitials);
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
                    //dtFBLn = FBLnUpdate(batCtrlNum, false, isMultiCurrency, dtFBLn);//to be updated                    
                    //update Batch_de.mdb table Batch_DE
                    affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                    //insert into Global_DE na table
                    //insertGlobalDB(dal, this.selectBatchQA(batCtrlNum));//to be updated, Create backup copy of the XML file instead of inserting records to global DE                
                    //createMDB(selectBatchXML(batCtrlNum, CommonEnum.FormMode.QUALITY_ASSURANCE), batCtrlNum, OwnerCode);
                    ds = populatePageCount(selectBatchXML(batCtrlNum, CommonEnum.FormMode.QUALITY_ASSURANCE), batCtrlNum, dal);
                    //saveGuideMatrix(ds,dal);
                    saveBatchXMLFPS(ds, batCtrlNum, CommonEnum.FormMode.QUALITY_ASSURANCE);
                    createMDB(ds, batCtrlNum, OwnerKey);
                    //move mxx file to correct folder
                    moveToProd("MXX" + batCtrlNum + ".mdb", OwnerCode);
                    //archive DE and QA xml files
                    archiveXMLFile(batCtrlNum, false, dal);//File.Delete(ConfigurationManager.AppSettings["ObjQADestinationPath"] + batCtrlNum + ".xml");
                    //if SplitBatch
                    dsSplitBatches = dal.ExecuteDataSet("SELECT Bat_Ctrl_Num_Split FROM Batch_DE_Split WHERE Bat_Ctrl_Num_Root =  @Bat_Ctrl_Num", CommandType.Text, paramBat);
                    foreach (DataRow row in dsSplitBatches.Tables[0].Rows)
                    {
                        archiveXMLFile(row["Bat_Ctrl_Num_Split"].ToString().Trim(), true, dal);
                    }                    
                    //commit all if there are no problem                
                }
                else
                {
                    string splitbatches = string.Empty;
                    //update split batch status to "COMBINED"
                    ParameterInfo[] paramBat2 = new ParameterInfo[2];
                    paramBat2[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                    paramBat2[1] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                    affectedRows = dal.ExecuteNonQuery(string.Format(@"UPDATE Batch_DE SET Batch_Status = 'COMBINED',DE_Complete_DTM = @UTCDate, FB_Cnt = {0} WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num 
                                                                       UPDATE Batch_DE_ext SET f_DE_Complete_DTM = @UTCDate WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num ", fbCount.ToString()), CommandType.Text, paramBat2);
                    dsSplitBatches = dal.ExecuteDataSet("SELECT A.*,DE.Batch_Status AS DEStatus FROM Batch_DE_Split A INNER JOIN Batch_DE_Split B ON A.Bat_Ctrl_Num_Root = B.Bat_Ctrl_Num_Root INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num WHERE B.Bat_Ctrl_Num_Split =  @Bat_Ctrl_Num ORDER BY B.Bat_Ctrl_Num_Split", CommandType.Text, paramBat);
                    if (checkAllCombined(dsSplitBatches.Tables[0], out splitbatches))//check if all the other related split batches are "COMBINED" status
                    {
                       
                        //update all status to Combining
                        affectedRows = dal.ExecuteNonQuery("UPDATE Batch_DE SET Batch_Status = 'COMBINING' " + splitbatches, CommandType.Text);                        
                        createCombinedXML(dsSplitBatches.Tables[0],dal);//create a combined xml file for the root batch
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
        
        private DataSet selectBatchXML(string MXXDatabase, string filename)
        {
            string xmlVerionName = string.Empty;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                xmlVerionName = "ver." + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + "-" + MXXDatabase;
            }
            else
            {
                xmlVerionName = "ver.Development-" + MXXDatabase;
            }
            DataSet retval = new DataSet(xmlVerionName);
            try
            {   
                DataTable tableInvBat = GetInvBatRowStructureXML();
                DataTable tableInvoice = GetInvoiceRowStructureXML();
                DataTable tableFrghtBl = GetFrghtBlRowStructureXML();
                DataTable tableAddrs = GetAddrsRowStructureXML();
                DataTable tableKeyIdents = GetKeyIdentsRowStructureXML();
                DataTable tableCntnrs = GetCntnrsRowStructureXML();
                DataTable tableProdDtl = GetProdDtlRowStructureXML();
                DataTable tableFbLnRow = GetFbLnRowStructureXML();
                retval.Tables.Add(tableInvBat.Copy());
                retval.Tables[0].AcceptChanges();
                retval.Tables.Add(tableInvoice.Copy());
                retval.Tables[1].AcceptChanges();
                retval.Tables.Add(tableFrghtBl.Copy());
                retval.Tables[2].AcceptChanges();
                retval.Tables.Add(tableAddrs.Copy());
                retval.Tables[3].AcceptChanges();
                retval.Tables.Add(tableKeyIdents.Copy());
                retval.Tables[4].AcceptChanges();
                retval.Tables.Add(tableCntnrs.Copy());
                retval.Tables[5].AcceptChanges();
                retval.Tables.Add(tableProdDtl.Copy());
                retval.Tables[6].AcceptChanges();
                retval.Tables.Add(tableFbLnRow.Copy());
                retval.Tables[7].AcceptChanges();
                if (File.Exists(filename))
                {
                    foreach (DataTable dataTable in retval.Tables)
                        dataTable.BeginLoadData();
                    retval.ReadXml(filename);
                    foreach (DataTable dataTable in retval.Tables)
                        dataTable.EndLoadData();
                }
                else
                    throw new Exception("XML file is not existing.");
            }
            catch (Exception e)
            {
                throw e;
            }
            retval.EnforceConstraints = true;
            return retval;
        }

        [WebMethod]
        public DataTable graphDiffQAXML(string MXXDatabase, string MXXOwnerKey, string MXXSCAC, string siteID)
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
                retval = graphDiffXML(MXXDatabase, CommonEnum.FormMode.QUALITY_ASSURANCE);
                foreach(DataRow row in retval.Rows)
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

        private DataTable graphDiffXML(string MXXDatabase, CommonEnum.FormMode formMode)
        {
            DataTable retval = this.getTableStructureErrorData();            
            DataView dvInvBat = new DataView();
            DataView dvInvoice = new DataView();
            DataView dvFrghtBl = new DataView();
            DataView dvKeyIdents = new DataView();
            DataView dvDuplicate = new DataView();
            DataView dvError = new DataView();
            DataView dvAddrs = new DataView();
            DataView dvCntnrs = new DataView();
            DataView dvProdDtl = new DataView();
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
                if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                {
                    filenameDETest = ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".xml";
                    filenameCorrect = ConfigurationManager.AppSettings["ObjQADestinationPath"] + MXXDatabase + ".xml";
                }
                else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
                {
                    filenameDETest = ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID + "\\" + MXXDatabase + ".xml";
                    filenameCorrect = ConfigurationManager.AppSettings["ObjTestCasesPath"] + MXXDatabase + ".xml";
                }
                dsConfig = dal.ExecuteDataSet("SELECT * FROM TrainerConfig", CommandType.Text);
                dsDETest = selectBatchXML(MXXDatabase, filenameDETest);
                dsCorrect = selectBatchXML(MXXDatabase, filenameCorrect);
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
                dvFrghtBl.Table = dsDETest.Tables["FrghtBl"];
                isCorrect = true;
                foreach (DataRow dr in dsCorrect.Tables["FrghtBl"].Rows)
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
                
                dvFrghtBl.Table = dsCorrect.Tables["FrghtBl"];
                foreach (DataRow dr in dsDETest.Tables["FrghtBl"].Rows)
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

                #region KeyIdents
                dvKeyIdents.Table = dsCorrect.Tables["KeyIdents"];
                dvDuplicate.Table = dsDETest.Tables["KeyIdents"];
                dvError.Table = retval;
                //DataRow drDup;
                foreach (DataRow dr in dsDETest.Tables["KeyIdents"].Select("", "FbId,KeyNum DESC"))
                {
                    dvKeyIdents.RowFilter = string.Format("FbId = '{0}' AND KeyQual = '{1}' AND KeyVal = '{2}'", dr["FbId"].ToString().Trim(), dr["KeyQual"].ToString().Trim().Replace("'", "''"), dr["KeyVal"].ToString().Trim().Replace("'", "''"));
                    if (dvKeyIdents.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["KeyNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "KEY_IDENTS";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = dr["KeyQual"].ToString().Trim() + ":" + dr["KeyVal"].ToString().Trim();
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                    dvDuplicate.RowFilter = string.Format("FbId = '{0}' AND KeyQual = '{1}' AND KeyVal = '{2}'", dr["FbId"].ToString().Trim(), dr["KeyQual"].ToString().Trim().Replace("'", "''"), dr["KeyVal"].ToString().Trim().Replace("'", "''"));
                    if (dvKeyIdents.Count != dvDuplicate.Count && dvKeyIdents.Count < dvDuplicate.Count)
                    {
                        dvError.RowFilter = string.Format("ID = '{0}' AND KeyedValue = '{1}'", dr["FbId"].ToString().Trim(), dr["KeyQual"].ToString().Trim().Replace("'", "''") + ":" + dr["KeyVal"].ToString().Trim().Replace("'", "''"));
                        if (dvError.Count < dvDuplicate.Count - dvKeyIdents.Count)
                        {
                            row = retval.NewRow();
                            row["ID"] = dr["FbId"].ToString().Trim();
                            row["LineItemNum"] = dr["KeyNum"].ToString().Trim();
                            row["ItemCategory"] = DBNull.Value;
                            row["NodeName"] = "KEY_IDENTS";
                            row["OriginalName"] = DBNull.Value;
                            row["FieldName"] = DBNull.Value;
                            row["CorrectValue"] = "Missing duplicate record";
                            row["KeyedValue"] = dr["KeyQual"].ToString().Trim() + ":" + dr["KeyVal"].ToString().Trim();
                            row["Accuracy"] = 0;
                            retval.Rows.Add(row);
                        }
                    }
                }
                dvKeyIdents.Table = dsDETest.Tables["KeyIdents"];
                dvDuplicate.Table = dsCorrect.Tables["KeyIdents"];
                foreach (DataRow dr in dsCorrect.Tables["KeyIdents"].Select("", "FbId,KeyNum DESC"))
                {
                    dvKeyIdents.RowFilter = string.Format("FbId = '{0}' AND KeyQual = '{1}' AND KeyVal = '{2}'", dr["FbId"].ToString().Trim(), dr["KeyQual"].ToString().Trim().Replace("'", "''"), dr["KeyVal"].ToString().Trim().Replace("'", "''"));
                    if (dvKeyIdents.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["KeyNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "KEY_IDENTS";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = dr["KeyQual"].ToString().Trim() + ":" + dr["KeyVal"].ToString().Trim();
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                    dvDuplicate.RowFilter = string.Format("FbId = '{0}' AND KeyQual = '{1}' AND KeyVal = '{2}'", dr["FbId"].ToString().Trim(), dr["KeyQual"].ToString().Trim().Replace("'", "''"), dr["KeyVal"].ToString().Trim().Replace("'", "''"));
                    if (dvKeyIdents.Count != dvDuplicate.Count && dvKeyIdents.Count < dvDuplicate.Count)
                    {
                        dvError.RowFilter = string.Format("ID = '{0}' AND CorrectValue = '{1}'", dr["FbId"].ToString().Trim(), dr["KeyQual"].ToString().Trim().Replace("'", "''") + ":" + dr["KeyVal"].ToString().Trim().Replace("'", "''"));
                        if (dvError.Count < dvDuplicate.Count - dvKeyIdents.Count)
                        {
                            row = retval.NewRow();
                            row["ID"] = dr["FbId"].ToString().Trim();
                            row["LineItemNum"] = dr["KeyNum"].ToString().Trim();
                            row["ItemCategory"] = DBNull.Value;
                            row["NodeName"] = "KEY_IDENTS";
                            row["OriginalName"] = DBNull.Value;
                            row["FieldName"] = DBNull.Value;
                            row["CorrectValue"] = dr["KeyQual"].ToString().Trim() + ":" + dr["KeyVal"].ToString().Trim();
                            row["KeyedValue"] = "Missing record";
                            row["Accuracy"] = 0;
                            retval.Rows.Add(row);
                        }
                    }
                }
                #endregion

                #region Addrs
                dvAddrs.Table = dsDETest.Tables["Addrs"];
                foreach (DataRow dr in dsCorrect.Tables["Addrs"].Rows)
                {
                    dvAddrs.RowFilter = string.Format("FbId = '{0}' AND AddrNum = '{1}' AND AddrCat = '{2}'", dr["FbId"].ToString().Trim(), dr["AddrNum"].ToString().Trim(), dr["AddrCat"].ToString().Trim());
                    if (dvAddrs.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dvAddrs[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "ADDRS", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["FbId"].ToString().Trim();
                                    row["LineItemNum"] = dr["AddrNum"].ToString().Trim();
                                    row["ItemCategory"] = dr["AddrCat"].ToString().Trim();
                                    row["NodeName"] = "ADDRS";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvAddrs[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvAddrs[0][dc.ColumnName].ToString().Trim());
                                    retval.Rows.Add(row);
                                }
                            }
                        }
                    }
                    else
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["AddrNum"].ToString().Trim();
                        row["ItemCategory"] = dr["AddrCat"].ToString().Trim();
                        row["NodeName"] = "ADDRS";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }                
                dvAddrs.Table = dsCorrect.Tables["Addrs"];
                foreach (DataRow dr in dsDETest.Tables["Addrs"].Rows)
                {
                    dvAddrs.RowFilter = string.Format("FbId = '{0}' AND AddrNum = '{1}' AND AddrCat = '{2}'", dr["FbId"].ToString().Trim(), dr["AddrNum"].ToString().Trim(), dr["AddrCat"].ToString().Trim());
                    if (dvAddrs.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["AddrNum"].ToString().Trim();
                        row["ItemCategory"] = dr["AddrCat"].ToString().Trim();
                        row["NodeName"] = "ADDRS";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                #endregion

                #region Cntnrs
                dvCntnrs.Table = dsDETest.Tables["Cntnrs"];
                foreach (DataRow dr in dsCorrect.Tables["Cntnrs"].Rows)
                {
                    dvCntnrs.RowFilter = string.Format("FbId = '{0}' AND CntnrNum = '{1}'", dr["FbId"].ToString().Trim(), dr["CntnrNum"].ToString().Trim());
                    if (dvCntnrs.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dvCntnrs[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "CNTNRS", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["FbId"].ToString().Trim();
                                    row["LineItemNum"] = dr["CntnrNum"].ToString().Trim();
                                    row["ItemCategory"] = DBNull.Value;
                                    row["NodeName"] = "CNTNRS";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvCntnrs[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvCntnrs[0][dc.ColumnName].ToString().Trim());
                                    retval.Rows.Add(row);
                                }
                            }
                        }
                    }
                    else
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["CntnrNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "CNTNRS";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }                
                dvCntnrs.Table = dsCorrect.Tables["Cntnrs"];
                foreach (DataRow dr in dsDETest.Tables["Cntnrs"].Rows)
                {
                    dvCntnrs.RowFilter = string.Format("FbId = '{0}' AND CntnrNum = '{1}'", dr["FbId"].ToString().Trim(), dr["CntnrNum"].ToString().Trim());
                    if (dvCntnrs.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["CntnrNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "CNTNRS";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                #endregion

                #region ProdDtl
                dvProdDtl.Table = dsDETest.Tables["ProdDtl"];
                isCorrect = true;
                foreach (DataRow dr in dsCorrect.Tables["ProdDtl"].Rows)
                {
                    dvProdDtl.RowFilter = string.Format("FbId = '{0}' AND ProdInstNum = '{1}'", dr["FbId"].ToString().Trim(), dr["ProdInstNum"].ToString().Trim());
                    if (dvProdDtl.Count > 0)
                    {
                        foreach (DataColumn dc in dr.Table.Columns)
                        {
                            if (dc.DataType == System.Type.GetType("System.Decimal"))
                            {
                                if (dvProdDtl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && Convert.ToDecimal(dvProdDtl[0][dc.ColumnName]) != Convert.ToDecimal(dr[dc.ColumnName]))
                                    isCorrect = false;
                                else if ((dvProdDtl[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvProdDtl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }
                            else
                            {
                                if (dvProdDtl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && dvProdDtl[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                                    isCorrect = false;
                                else if ((dvProdDtl[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvProdDtl[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
                                    isCorrect = false;
                            }

                            if (!isCorrect)
                            {
                                dvConfig.RowFilter = string.Format("[NodeName] = '{0}' AND [FieldName] = '{1}'", "PRODDTL", dc.ColumnName);
                                if (dvConfig.Count == 0)
                                {
                                    row = retval.NewRow();
                                    row["ID"] = dr["FbId"].ToString().Trim();
                                    row["LineItemNum"] = dr["ProdInstNum"].ToString().Trim();
                                    row["ItemCategory"] = DBNull.Value;
                                    row["NodeName"] = "PRODDTL";
                                    row["OriginalName"] = DBNull.Value;
                                    row["FieldName"] = dc.ColumnName;
                                    row["CorrectValue"] = dr[dc.ColumnName].ToString().Trim();
                                    row["KeyedValue"] = dvProdDtl[0][dc.ColumnName].ToString().Trim();
                                    row["Accuracy"] = computeDifference(dr[dc.ColumnName].ToString().Trim(), dvProdDtl[0][dc.ColumnName].ToString().Trim());
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
                        row["LineItemNum"] = dr["ProdInstNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "PRODDTL";
                        row["OriginalName"] = DBNull.Value;
                        row["FieldName"] = DBNull.Value;
                        row["CorrectValue"] = "Missing record";
                        row["KeyedValue"] = "Missing record";
                        row["Accuracy"] = 0;
                        retval.Rows.Add(row);
                    }
                }
                dvProdDtl.Table = dsCorrect.Tables["ProdDtl"];
                foreach (DataRow dr in dsDETest.Tables["ProdDtl"].Rows)
                {
                    dvProdDtl.RowFilter = string.Format("FbId = '{0}' AND ProdInstNum = '{1}'", dr["FbId"].ToString().Trim(), dr["ProdInstNum"].ToString().Trim());
                    if (dvProdDtl.Count == 0)
                    {
                        row = retval.NewRow();
                        row["ID"] = dr["FbId"].ToString().Trim();
                        row["LineItemNum"] = dr["ProdInstNum"].ToString().Trim();
                        row["ItemCategory"] = DBNull.Value;
                        row["NodeName"] = "PRODDTL";
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
                                if (dvFBLn[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] != DBNull.Value && dvFBLn[0][dc.ColumnName].ToString().Trim() != dr[dc.ColumnName].ToString().Trim())
                                    isCorrect = false;
                                else if ((dvFBLn[0][dc.ColumnName] == DBNull.Value && dr[dc.ColumnName] != DBNull.Value) || (dvFBLn[0][dc.ColumnName] != DBNull.Value && dr[dc.ColumnName] == DBNull.Value))
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

        private void archiveXMLFile(string batCtrlNum, bool isSplit, DALHelper dal)
        {
            string folderDate = string.Empty;
            string archiveDEFolderPath = string.Empty;
            string archiveQAFolderPath = string.Empty;
            try
            { 
                //getserverdate
                folderDate = this.GetServerDate(dal).ToString("yyyyMMdd");
                archiveDEFolderPath = ConfigurationManager.AppSettings["ObjArchivePath"] + folderDate + @"\DE\";
                archiveQAFolderPath = ConfigurationManager.AppSettings["ObjArchivePath"] + folderDate + @"\QA\";
                if (!Directory.Exists(archiveDEFolderPath))
                    Directory.CreateDirectory(archiveDEFolderPath);
                if (!Directory.Exists(archiveQAFolderPath))
                    Directory.CreateDirectory(archiveQAFolderPath);

                moveFile(ConfigurationManager.AppSettings["ObjDestinationPath"] + batCtrlNum + ".xml", archiveDEFolderPath + batCtrlNum + ".xml");
                moveFile(ConfigurationManager.AppSettings["ObjQADestinationPath"] + batCtrlNum + ".xml", archiveQAFolderPath + batCtrlNum + ".xml");
                if(!isSplit)
                    moveFile(ConfigurationManager.AppSettings["ObjQADestinationPath"] + "FPS" + batCtrlNum + ".xml", archiveQAFolderPath + "FPS" + batCtrlNum + ".xml");
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private bool createMDB(DataSet dsBatch, string MXXDatabase, string OwnerKey)
        {

            #region INV_BAT
            string insertQueryINV_BAT = @"INSERT INTO batmdb_INV_BAT
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



            #endregion
            #region INVOICE
            string insertQueryINVOICE = @"INSERT INTO batmdb_INVOICE
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
                                        ,@InvType
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
            #endregion
            #region FRGHT_BL
            string insertQueryFRGHT_BL = @"INSERT INTO batmdb_FRGHT_BL
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
                                        ,ACCT_NUM_VEND_BLNG                                        
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
                                        ,TX_LM_DIST)
                                    VALUES
                                        (@FBId
                                        ,@OwnerKey
                                        ,@FbKey
                                        ,'Manual Bill'
                                        ,@FbType
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
                                        ,@AcctNumVendBlng                                        
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
                                        ,0)";

            #endregion
            #region FB_LN
            string insertQueryFB_LN = @"INSERT INTO batmdb_FB_LN
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
            #endregion
            #region A_Line
            string insertQueryA_Line = @"INSERT INTO batmdb_A_LINE
                                    (UNT_ID
                                    ,CNTXT
                                    ,OWNER_KEY)
                                VALUES
                                    (@UntId
                                    ,@Cntxt
                                    ,@OwnerKey)";
            #endregion

            bool retval = false;
            DataSet dsInvBat = new DataSet();
            DataSet dsInvoice = new DataSet();
            DataSet dsFrghtBL = new DataSet();
            DataSet dsFBLn = new DataSet();
            int affectedRows;
            string filePath = ConfigurationManager.AppSettings["MDBSourcePath"] + "Newbatchxxx";
            string newfile = ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + MXXDatabase + ".mdb";
            string xslPath = ConfigurationManager.AppSettings["XSLTRoot"] + "DeXmlToEdi110.xslt";
            string xmlPath = ConfigurationManager.AppSettings["ObjQADestinationPath"] + "FPS" + MXXDatabase + ".xml";
            dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", "MXX" + MXXDatabase.Trim() + ".mdb");

            try
            {

                if (File.Exists(newfile))
                    File.Delete(newfile);
                File.Copy(filePath, newfile);
                string ownerKey = OwnerKey.Trim().Remove(3, 1);
                string batchNumber = "MXX" + MXXDatabase.Trim();
                string batchCount = (0).ToString().PadLeft(4, '0');
                dalMXXDatabase.OpenDB();
                dalMXXDatabase.BeginTransaction();
                #region INV_BAT
                foreach (DataRow dr in dsBatch.Tables["InvBat"].Rows)
                {
                    ParameterInfoOleDB[] paramINV_BAT;

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
                #endregion
                #region INVOICE
                foreach (DataRow dr in dsBatch.Tables["Invoice"].Rows)
                {
                    ParameterInfoOleDB[] paramINVOICE;
                    paramINVOICE = new ParameterInfoOleDB[32];
                    paramINVOICE[0] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                    paramINVOICE[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                    paramINVOICE[2] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? "INV_TEMP." + dr["InvId"].ToString().Substring(19, 4) : dr["InvKey"]);
                    paramINVOICE[3] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                    paramINVOICE[4] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                    paramINVOICE[5] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["VendLabl"]);
                    paramINVOICE[6] = new ParameterInfoOleDB("@LocIdRemit", dr["LocIdRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdRemit"]);
                    paramINVOICE[7] = new ParameterInfoOleDB("@InvType", dr["InvType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvType"]);
                    paramINVOICE[8] = new ParameterInfoOleDB("@InvStat", dr["InvStat"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvStat"]);
                    paramINVOICE[9] = new ParameterInfoOleDB("@InvFbCnt", dr["InvFbCnt"].ToString().Trim() == string.Empty ? 0 : dr["InvFbCnt"]);
                    paramINVOICE[10] = new ParameterInfoOleDB("@InvCurrencyQual", dr["InvCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCurrencyQual"]);
                    paramINVOICE[11] = new ParameterInfoOleDB("@InvAmt", dr["InvAmt"].ToString().Trim() == string.Empty ? 0 : dr["InvAmt"]);
                    paramINVOICE[12] = new ParameterInfoOleDB("@VendInvAmt", dr["VendInvAmt"].ToString().Trim() == string.Empty ? 0 : dr["VendInvAmt"]);
                    paramINVOICE[13] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                    paramINVOICE[14] = new ParameterInfoOleDB("@AlRemit1", dr["AlRemit1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit1"]);
                    paramINVOICE[15] = new ParameterInfoOleDB("@AlRemit2", dr["AlRemit2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit2"]);
                    paramINVOICE[16] = new ParameterInfoOleDB("@AlRemit3", dr["AlRemit3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit3"]);
                    paramINVOICE[17] = new ParameterInfoOleDB("@AlRemit4", dr["AlRemit4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit4"]);
                    paramINVOICE[18] = new ParameterInfoOleDB("@AlCityRemit", dr["AlCityRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityRemit"]);
                    paramINVOICE[19] = new ParameterInfoOleDB("@AlStateProvRemit", dr["AlStateProvRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvRemit"]);
                    paramINVOICE[20] = new ParameterInfoOleDB("@AlPostCodeRemit", dr["AlPostCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeRemit"]);
                    paramINVOICE[21] = new ParameterInfoOleDB("@AlCntryCodeRemit", dr["AlCntryCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeRemit"]);
                    paramINVOICE[22] = new ParameterInfoOleDB("@InvCreatDtm", (dr["InvCreatDtm"].ToString().Trim() == string.Empty || dr["InvCreatDtm"] == null) ? DBNull.Value : dr["InvCreatDtm"]);
                    paramINVOICE[23] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);
                    paramINVOICE[24] = new ParameterInfoOleDB("@AlBlng1", dr["AlBlng1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng1"]);
                    paramINVOICE[25] = new ParameterInfoOleDB("@AlBlng2", dr["AlBlng2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng2"]);
                    paramINVOICE[26] = new ParameterInfoOleDB("@AlBlng3", dr["AlBlng3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng3"]);
                    paramINVOICE[27] = new ParameterInfoOleDB("@AlBlng4", dr["AlBlng4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng4"]);
                    paramINVOICE[28] = new ParameterInfoOleDB("@AlCityBlng", dr["AlCityBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityBlng"]);
                    paramINVOICE[29] = new ParameterInfoOleDB("@AlStateProvBlng", dr["AlStateProvBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvBlng"]);
                    paramINVOICE[30] = new ParameterInfoOleDB("@AlPostCodeBlng", dr["AlPostCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeBlng"]);
                    paramINVOICE[31] = new ParameterInfoOleDB("@AlCntryCodeBlng", dr["AlCntryCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeBlng"]);

                    affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryINVOICE, CommandType.Text, paramINVOICE);

                }
                #endregion
                #region FRGHT_BL

                foreach (DataRow dr in dsBatch.Tables["FrghtBl"].Rows)
                {
                    ParameterInfoOleDB[] paramFRGHT_BL;

                    paramFRGHT_BL = new ParameterInfoOleDB[32];

                    paramFRGHT_BL[0] = new ParameterInfoOleDB("@FBId", dr["FbId"]);
                    paramFRGHT_BL[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                    paramFRGHT_BL[2] = new ParameterInfoOleDB("@FbKey", dr["FbKey"].ToString().Trim() == string.Empty ? "FB_TEMP." + dr["FbId"].ToString().Substring(19, 4) : dr["FbKey"]);
                    paramFRGHT_BL[3] = new ParameterInfoOleDB("@FbType", dr["FbType"].ToString().Trim() == string.Empty ? DBNull.Value : (dr["FbType"].ToString().Length > 20 ? dr["FbType"] = dr["FbType"].ToString().Substring(0, 20) : dr["FbType"]));
                    paramFRGHT_BL[4] = new ParameterInfoOleDB("@InvId", dr["InvId"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvId"]);
                    paramFRGHT_BL[5] = new ParameterInfoOleDB("@InvKey", dr["InvKey"].ToString().Trim() == string.Empty ? "INV_TEMP." + dr["InvId"].ToString().Substring(19, 4) : dr["InvKey"]);
                    paramFRGHT_BL[6] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                    paramFRGHT_BL[7] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                    paramFRGHT_BL[8] = new ParameterInfoOleDB("@FbLnCnt", dr["FbLnCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbLnCnt"]);
                    paramFRGHT_BL[9] = new ParameterInfoOleDB("@FbAmt", dr["FbAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAmt"]);
                    paramFRGHT_BL[10] = new ParameterInfoOleDB("@FbFrghtAmt", dr["FbFrghtAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbFrghtAmt"]);
                    paramFRGHT_BL[11] = new ParameterInfoOleDB("@FbDscntAmt", dr["FbDscntAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbDscntAmt"]);
                    paramFRGHT_BL[12] = new ParameterInfoOleDB("@FbAccAmt", dr["FbAccAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbAccAmt"]);
                    paramFRGHT_BL[13] = new ParameterInfoOleDB("@FbTaxAmt", dr["FbTaxAmt"].ToString().Trim() == string.Empty ? 0 : dr["FbTaxAmt"]);
                    paramFRGHT_BL[14] = new ParameterInfoOleDB("@FbCurrencyQual", dr["FbCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCurrencyQual"]);
                    paramFRGHT_BL[15] = new ParameterInfoOleDB("@FbPaymtTermsCode", dr["FbPaymtTermsCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPaymtTermsCode"]);
                    paramFRGHT_BL[16] = new ParameterInfoOleDB("@FbCreatDtm", dr["FbCreatDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbCreatDtm"]);
                    paramFRGHT_BL[17] = new ParameterInfoOleDB("@FbPkgType", dr["FbPkgType"].ToString().Trim() == string.Empty ? DBNull.Value : dr["FbPkgType"]);
                    paramFRGHT_BL[18] = new ParameterInfoOleDB("@FbPcsCnt", dr["FbPcsCnt"].ToString().Trim() == string.Empty ? 0 : dr["FbPcsCnt"]);
                    paramFRGHT_BL[19] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["VendLabl"]);
                    paramFRGHT_BL[20] = new ParameterInfoOleDB("@SrvcReqCode", dr["SrvcReqCode"].ToString().Trim() == string.Empty ? DBNull.Value : dr["SrvcReqCode"]);
                    //paramFRGHT_BL[20] = new ParameterInfoOleDB("@CaInfo1Raw", dr["CaInfo1Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo1Raw"]);
                    //paramFRGHT_BL[21] = new ParameterInfoOleDB("@CaInfo2Raw", dr["CaInfo2Raw"].ToString().Trim() == string.Empty ? DBNull.Value : dr["CaInfo2Raw"]);
                    paramFRGHT_BL[21] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                    //paramFRGHT_BL[23] = new ParameterInfoOleDB("@AlOrig1", dr["AlOrig1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig1"]);
                    //paramFRGHT_BL[24] = new ParameterInfoOleDB("@AlOrig2", dr["AlOrig2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig2"]);
                    //paramFRGHT_BL[25] = new ParameterInfoOleDB("@AlOrig3", dr["AlOrig3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig3"]);
                    //paramFRGHT_BL[26] = new ParameterInfoOleDB("@AlOrig4", dr["AlOrig4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlOrig4"]);
                    //paramFRGHT_BL[27] = new ParameterInfoOleDB("@AlCityOrig", dr["AlCityOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityOrig"]);
                    //paramFRGHT_BL[28] = new ParameterInfoOleDB("@AlStateProvOrig", dr["AlStateProvOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvOrig"]);
                    //paramFRGHT_BL[29] = new ParameterInfoOleDB("@AlPostCodeOrig", dr["AlPostCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeOrig"]);
                    //paramFRGHT_BL[30] = new ParameterInfoOleDB("@AlCntryCodeOrig", dr["AlCntryCodeOrig"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeOrig"]);
                    //paramFRGHT_BL[31] = new ParameterInfoOleDB("@AlDest1", dr["AlDest1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest1"]);
                    //paramFRGHT_BL[32] = new ParameterInfoOleDB("@AlDest2", dr["AlDest2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest2"]);
                    //paramFRGHT_BL[33] = new ParameterInfoOleDB("@AlDest3", dr["AlDest3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest3"]);
                    //paramFRGHT_BL[34] = new ParameterInfoOleDB("@AlDest4", dr["AlDest4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlDest4"]);
                    //paramFRGHT_BL[35] = new ParameterInfoOleDB("@AlCityDest", dr["AlCityDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityDest"]);
                    //paramFRGHT_BL[36] = new ParameterInfoOleDB("@AlStateProvDest", dr["AlStateProvDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvDest"]);
                    //paramFRGHT_BL[37] = new ParameterInfoOleDB("@AlPostCodeDest", dr["AlPostCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeDest"]);
                    //paramFRGHT_BL[38] = new ParameterInfoOleDB("@AlCntryCodeDest", dr["AlCntryCodeDest"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeDest"]);
                    paramFRGHT_BL[22] = new ParameterInfoOleDB("@FbActualWt", dr["FbActualWt"].ToString().Trim() == string.Empty ? 0 : dr["FbActualWt"]);
                    paramFRGHT_BL[23] = new ParameterInfoOleDB("@FbFnclWt", dr["FbFnclWt"].ToString().Trim() == string.Empty ? 0 : dr["FbFnclWt"]);
                    paramFRGHT_BL[24] = new ParameterInfoOleDB("@InterlineScac", dr["InterlineScac"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineScac"]);
                    paramFRGHT_BL[25] = new ParameterInfoOleDB("@InterlineQual", dr["InterlineQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineQual"]);
                    paramFRGHT_BL[26] = new ParameterInfoOleDB("@InterlineAmt", dr["InterlineAmt"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InterlineAmt"]);
                    paramFRGHT_BL[27] = new ParameterInfoOleDB("@LmDist", dr["LmDist"].ToString().Trim() == string.Empty ? 0 : dr["LmDist"]);
                    paramFRGHT_BL[28] = new ParameterInfoOleDB("@LmPkupActualDtm", dr["LmPkupActualDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmPkupActualDtm"]);
                    paramFRGHT_BL[29] = new ParameterInfoOleDB("@LmAtaDtm", dr["LmAtaDtm"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmAtaDtm"]);
                    paramFRGHT_BL[30] = new ParameterInfoOleDB("@PriceLaneLabl", dr["PriceLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["PriceLaneLabl"]);
                    paramFRGHT_BL[31] = new ParameterInfoOleDB("@LmLaneLabl", dr["LmLaneLabl"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LmLaneLabl"]);
                    affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFRGHT_BL, CommandType.Text, paramFRGHT_BL);

                }
                #endregion
                #region FB_LN
                /*
                foreach (DataRow dr in dsBatch.Tables["FBLn"].Rows)
                {
                    ParameterInfoOleDB[] paramFB_LN;

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

                }*/
                #endregion
                #region A_LINE
                XmlEdiTransform ediTrans = new XmlEdiTransform(xslPath, true, true);
                XPathDocument xmlDoc = new XPathDocument(xmlPath); //file path or Stream
                XPathNavigator xmlNav = xmlDoc.CreateNavigator();
                XmlNamespaceManager ns = new XmlNamespaceManager(xmlNav.NameTable);
                ns.AddNamespace("tx", "http://www.traxtech.com/NS/Trax.FPS.v1.Types");
                List<NodeEdi> nodes = ediTrans.TransformListToEdi(xmlNav, ns, "//tx:FrghtBl", "./tx:FbId", 1);
                foreach (object n in nodes)
                {
                    ParameterInfoOleDB[] paramA_LINE;
                    paramA_LINE = new ParameterInfoOleDB[3];
                    paramA_LINE[0] = new ParameterInfoOleDB("@UntId", ((NodeEdi)n).NodeKey);
                    paramA_LINE[1] = new ParameterInfoOleDB("@Cntxt", ((NodeEdi)n).EdiText);
                    paramA_LINE[2] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                    affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryA_Line, CommandType.Text, paramA_LINE);

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
                
            if(!Directory.Exists(folder))
                throw new Exception("Application configuration is lacking path settings for " + OwnerCode.Trim() + ".");
            while (moveTry)
            {
                try
                {
                    counter = counter + 1;
                    File.Move(ConfigurationManager.AppSettings["MDBDestinationPath"] + file, folder + file);
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

        private void createCombinedXML(DataTable dt, DALHelper dalDE)
        {
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

            DataRow rowKeyIdent;
            DataRow rowAddrs;
            DataRow rowCntnrs;
            DataRow rowProdDtl;
            DataRow rowFBLn;
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["ObjDestinationPath"] + rootBatch + ".xml"))
                    File.Delete(ConfigurationManager.AppSettings["ObjDestinationPath"] + rootBatch + ".xml");
                dsBatch = selectBatchXML(rootBatch, CommonEnum.FormMode.DATA_ENTRY);
                foreach (DataRow rowSplit in dt.Rows)
                {
                    splitBatch = selectBatchXML(rowSplit["Bat_Ctrl_Num_Split"].ToString(), CommonEnum.FormMode.QUALITY_ASSURANCE);
                    if (isFirst)//check the 
                    {
                        ownerKey = splitBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString().Trim();
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
                            if (dsBatch.Tables["Invoice"].Rows[0][dc.ColumnName] != null && dsBatch.Tables["Invoice"].Rows[0][dc.ColumnName].ToString().Trim() == string.Empty)
                                dsBatch.Tables["Invoice"].Rows[0][dc.ColumnName] = splitBatch.Tables["Invoice"].Rows[0][dc.ColumnName];
                    }
                    //insert FrghtBl
                    foreach (DataRow fbRow in splitBatch.Tables["FrghtBl"].Rows)
                    {
                        FBCount = dsBatch.Tables["FrghtBl"].DefaultView.Count == 0 ? (1).ToString().PadLeft(4, '0') : (Convert.ToInt16(dsBatch.Tables["FrghtBl"].DefaultView.Table.Select("", "FbId DESC")[0]["FbId"].ToString().Substring(19, 4)) + 1).ToString().PadLeft(4, '0');
                        fbID = "FBLL" + ownerKey.Remove(3, 1) + "MXX" + rootBatch + FBCount;
                        rowFrghtBl = dsBatch.Tables["FrghtBl"].NewRow();
                        foreach (DataColumn dc in dsBatch.Tables["FrghtBl"].Columns)
                        {
                            if (dc.ColumnName == "FbId")
                                rowFrghtBl[dc.ColumnName] = fbID;
                            else if (dc.ColumnName == "InvId")
                                rowFrghtBl[dc.ColumnName] = invID;
                            else if (dc.ColumnName == "FbPageNum")
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
                        dsBatch.Tables["FrghtBl"].Rows.Add(rowFrghtBl);

                        #region KeyIdent Update
                        foreach (DataRow keyIdentRow in splitBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}'", fbRow["FbId"].ToString().Trim())))
                        {
                            rowKeyIdent = dsBatch.Tables["KeyIdents"].NewRow();
                            foreach (DataColumn dc in dsBatch.Tables["KeyIdents"].Columns)
                            {
                                if (dc.ColumnName == "FbId")
                                    rowKeyIdent[dc.ColumnName] = fbID;
                                else
                                    rowKeyIdent[dc.ColumnName] = keyIdentRow[dc.ColumnName];
                            }
                            dsBatch.Tables["KeyIdents"].Rows.Add(rowKeyIdent);
                        }
                        #endregion
                        #region Addrs Update
                        foreach (DataRow addrsRow in splitBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}'", fbRow["FbId"].ToString().Trim())))
                        {
                            rowAddrs = dsBatch.Tables["Addrs"].NewRow();
                            foreach (DataColumn dc in dsBatch.Tables["Addrs"].Columns)
                            {
                                if (dc.ColumnName == "FbId")
                                    rowAddrs[dc.ColumnName] = fbID;
                                else
                                    rowAddrs[dc.ColumnName] = addrsRow[dc.ColumnName];
                            }
                            dsBatch.Tables["Addrs"].Rows.Add(rowAddrs);
                        }
                        #endregion
                        #region Cntnrs Update
                        foreach (DataRow cntnrsRow in splitBatch.Tables["Cntnrs"].Select(string.Format("FbId = '{0}'", fbRow["FbId"].ToString().Trim())))
                        {
                            rowCntnrs = dsBatch.Tables["Cntnrs"].NewRow();
                            foreach (DataColumn dc in dsBatch.Tables["Cntnrs"].Columns)
                            {
                                if (dc.ColumnName == "FbId")
                                    rowCntnrs[dc.ColumnName] = fbID;
                                else
                                    rowCntnrs[dc.ColumnName] = cntnrsRow[dc.ColumnName];
                            }
                            dsBatch.Tables["Cntnrs"].Rows.Add(rowCntnrs);
                        }
                        #endregion
                        #region ProdDtl Update
                        foreach (DataRow prodDtlRow in splitBatch.Tables["ProdDtl"].Select(string.Format("FbId = '{0}'", fbRow["FbId"].ToString().Trim())))
                        {
                            rowProdDtl = dsBatch.Tables["ProdDtl"].NewRow();
                            foreach (DataColumn dc in dsBatch.Tables["ProdDtl"].Columns)
                            {
                                if (dc.ColumnName == "FbId")
                                    rowProdDtl[dc.ColumnName] = fbID;
                                else
                                    rowProdDtl[dc.ColumnName] = prodDtlRow[dc.ColumnName];
                            }
                            dsBatch.Tables["ProdDtl"].Rows.Add(rowProdDtl);
                        }
                        #endregion
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
                    }
                    pageCount = pageCount + Convert.ToInt32(dal.ExecuteDataSet(string.Format("SELECT TOP 1 BatchImageCount-1 FROM BatchPageCounter WHERE Bat_Ctrl_Num = '{0}' ORDER BY BatchPageCounterID DESC", rowSplit["Bat_Ctrl_Num_Split"].ToString()), CommandType.Text).Tables[0].Rows[0][0]);
                    File.Delete(ConfigurationManager.AppSettings["ObjQADestinationPath"] + rowSplit[1].ToString() + ".xml");
                }
                foreach (DataRow row in dsBatch.Tables["FrghtBl"].Rows)
                {
                    row.BeginEdit();
                    row["LocIdBlng"] =       dsBatch.Tables["Invoice"].Rows[0]["LocIdBlng"].ToString();
                    row["AcctNumVendBlng"] = dsBatch.Tables["Invoice"].Rows[0]["AcctNumVendBlng"].ToString().Trim();
                    row.EndEdit();
                }
                dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = dsBatch.Tables["Invoice"].Rows[0]["LocIdRemit"];
                saveBatchXML(dsBatch, rootBatch, CommonEnum.FormMode.DATA_ENTRY);
            }
            catch
            {
                throw new Exception("Error during XML Creation.");
            }
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

        private DataSet populatePageCount(DataSet dsBatch, string batCtrlNum, DALHelper dal)
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

                dsTotalPageCount = dal.ExecuteDataSet(string.Format(@"SELECT bpc.BatchImageCount FROM BatchPageCounter(NOLOCK) bpc
                                                                      INNER JOIN Batch_DE de on bpc.BatchID = de.BatchID
                                                                      WHERE de.Bat_Ctrl_Num =  '{0}' ", batCtrlNum), CommandType.Text);
                if (dsTotalPageCount.Tables[0].Rows.Count > 0 && dsTotalPageCount.Tables[0].Rows[0]["BatchImageCount"].ToString() != string.Empty)
                {
                    lastPage = Convert.ToInt16(dsTotalPageCount.Tables[0].Rows[0]["BatchImageCount"]) + 1;
                    lastInvPage = lastPage;
                    foreach (DataRow row in dsBatch.Tables["FrghtBl"].Select("", "FbPageNum DESC,InvId DESC"))
                    {
                        fbPageNum = Convert.ToInt16(row["FbPageNum"]);
                        fbPageCount = lastPage - fbPageNum;
                        fbPageCount = fbPageCount > 0 ? fbPageCount : 1;
                        row["ImgPageCnt"] = fbPageCount;
                        //populate invoice page 
                        if (InvIDCurrent != row["InvId"].ToString())
                        {
                            InvIDCurrent = row["InvId"].ToString();
                            if (InvIDPrevious != string.Empty)
                            {
                                invPageCount = lastInvPage - lastPage;
                                dsBatch.Tables["Invoice"].Select(string.Format("InvId = '{0}'", InvIDPrevious))[0]["ImgPageCnt"] = invPageCount > 0 ? invPageCount : 1;
                                invPageCount = 0;
                                lastInvPage = lastPage;
                            }
                            InvIDPrevious = InvIDCurrent;
                        }
                        lastPage = fbPageNum;
                    }
                    invPageCount = lastInvPage - fbPageNum;
                    dsBatch.Tables["Invoice"].Select(string.Format("InvId = '{0}'", InvIDCurrent))[0]["ImgPageCnt"] = invPageCount > 0 ? invPageCount : 1;
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
        }

        private void saveGuideMatrix(DataSet dsBatch, DALHelper dal)
        {
            try
            {
                string query = @"INSERT INTO [DEGuidelineMatrix]
                                       ([CarrierName]
                                       ,[Owner_Key]
                                       ,[SCAC]
                                       ,[By]
                                       ,[Date]
                                       ,[Filename]
                                       ,[Version]
                                       ,[Format])
                                 VALUES
                                       (@CarrierName
                                       ,@Owner_Key
                                       ,@SCAC
                                       ,@By
                                       ,getUTCdate()
                                       ,@Filename
                                       ,@Version
                                       ,@Format)";

                ParameterInfo[] param = new ParameterInfo[7];
                param[1] = new ParameterInfo("@Owner_Key", dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString().Trim());
                param[2] = new ParameterInfo("@SCAC", dsBatch.Tables["InvBat"].Rows[0]["VendLabl"].ToString().Trim());
                param[3] = new ParameterInfo("@By", System.Environment.UserName);

                string[] temp;
                foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                {
                    temp = row["VendName"].ToString().Split('|');
                    param[0] = new ParameterInfo("@CarrierName", temp[1]);
                    param[4] = new ParameterInfo("@Filename", temp[0]);
                    param[5] = new ParameterInfo("@Version", temp[3]);
                    param[6] = new ParameterInfo("@Format", temp[2]);
                    dal.ExecuteNonQuery(query, CommandType.Text, param);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region Trainer
        [WebMethod]
        public DataTable graphDiffTrainerXML(string MXXDatabase, DateTime StartDate, string siteID)
        {
            DataTable retval = this.getTableStructureErrorData();
            DataSet dsAttempts = new DataSet();
            DataSet dsIDCounter = new DataSet();
            
            int attempts = 0;
            int affectedRows = 0;
            long trainerIDKey;

            string queryIDCounter = string.Format(@"SELECT IDCounter,PrefixSite,PrefixType FROM SiteIDController(NOLOCK) WHERE SiteID = {0} AND IDType = 'TrainerID'", ConfigurationManager.AppSettings["SiteID"]);
            string queryIDCounterUpdate = string.Format(@"UPDATE SiteIDController SET IDCounter = IDCounter+1 WHERE SiteID = {0} AND IDType = 'TrainerID'", ConfigurationManager.AppSettings["SiteID"]);
            string queryInsertTrainingRecord = @"INSERT INTO [TrainingRecord]
                                                       ([TrainerID]
                                                       ,[UserID]
                                                       ,[Bat_Ctrl_Num]
                                                       ,[Attempt]
                                                       ,[TimeStart]
                                                       ,[TimeEnd]
                                                       ,[TrainingStatus])
                                                 VALUES
                                                       (@TrainerID
                                                       ,@UserID
                                                       ,@Bat_Ctrl_Num
                                                       ,@Attempt
                                                       ,@TimeStart
                                                       ,GETUTCDATE()
                                                       ,@TrainingStatus)";
            string queryInserTrainingRecordDetail = @"INSERT INTO [TrainingRecordErrorDetails]
                                                           ([TrainerID]
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
                                                           (@TrainerID
                                                           ,@ID
                                                           ,@LineItemNum
                                                           ,@ItemCategory
                                                           ,@NodeName
                                                           ,@OriginalName
                                                           ,@FieldName
                                                           ,@CorrectValue
                                                           ,@KeyedValue
                                                           ,@Accuracy)";
            string querySelectAttempts = @"SELECT COUNT(*) AS Attempts FROM TrainingRecord
                                        WHERE UserID = @UserID AND Bat_Ctrl_Num = @Bat_Ctrl_Num";

            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(queryIDCounterUpdate, CommandType.Text);
                //get attempts count
                ParameterInfo[] paramAttempts = new ParameterInfo[2];
                paramAttempts[0] = new ParameterInfo("@UserID", CommonUserLogin.getUser().UserID);
                paramAttempts[1] = new ParameterInfo("@Bat_Ctrl_Num", MXXDatabase);

                dsAttempts = dal.ExecuteDataSet(querySelectAttempts, CommandType.Text, paramAttempts);
                attempts = Convert.ToInt32(dsAttempts.Tables[0].Rows[0][0]) + 1;

                //get and update TrainerID TrainingRecord
                dsIDCounter = dal.ExecuteDataSet(queryIDCounter, CommandType.Text);
                trainerIDKey = CommonMethod.createIDKey(Convert.ToInt64(dsIDCounter.Tables[0].Rows[0][0].ToString()) - 1, siteID);

                ParameterInfo[] paramTrainingRecordDetail = new ParameterInfo[10];
                paramTrainingRecordDetail[0] = new ParameterInfo("@TrainerID", trainerIDKey);
                retval = graphDiffXML(MXXDatabase, CommonEnum.FormMode.DATA_ENTRY_TRAINER);
                foreach(DataRow row in retval.Rows)
                {
                    paramTrainingRecordDetail[1] = new ParameterInfo("@NodeName", row["NodeName"]);
                    paramTrainingRecordDetail[2] = new ParameterInfo("@ID", row["ID"]);
                    paramTrainingRecordDetail[3] = new ParameterInfo("@LineItemNum", row["LineItemNum"]);
                    paramTrainingRecordDetail[4] = new ParameterInfo("@ItemCategory", row["ItemCategory"]);
                    paramTrainingRecordDetail[5] = new ParameterInfo("@OriginalName", DBNull.Value);
                    paramTrainingRecordDetail[6] = new ParameterInfo("@FieldName", row["FieldName"]);
                    paramTrainingRecordDetail[7] = new ParameterInfo("@CorrectValue", row["CorrectValue"]);
                    paramTrainingRecordDetail[8] = new ParameterInfo("@KeyedValue", row["KeyedValue"]);
                    paramTrainingRecordDetail[9] = new ParameterInfo("@Accuracy", row["Accuracy"]);
                    affectedRows = dal.ExecuteNonQuery(queryInserTrainingRecordDetail, CommandType.Text, paramTrainingRecordDetail);
                }

                ParameterInfo[] paramTrainingRecord = new ParameterInfo[6];
                paramTrainingRecord[0] = new ParameterInfo("@TrainerID", trainerIDKey);
                paramTrainingRecord[1] = new ParameterInfo("@UserID", CommonUserLogin.getUser().UserID);
                paramTrainingRecord[2] = new ParameterInfo("@Bat_Ctrl_Num", MXXDatabase);
                paramTrainingRecord[3] = new ParameterInfo("@Attempt", attempts);
                paramTrainingRecord[4] = new ParameterInfo("@TimeStart", StartDate);
                paramTrainingRecord[5] = new ParameterInfo("@TrainingStatus", retval.Rows.Count > 0 ? "FAILED" : "PASSED");
                
                //insert TrainingRecord                                       
                affectedRows = dal.ExecuteNonQuery(queryInsertTrainingRecord, CommandType.Text, paramTrainingRecord);
                dal.CommitTransaction();
            }
            catch (Exception error)
            {
                //MessageBox.Show(error.Message, CommonEnum.FormMode.DATA_ENTRY_TRAINER.ToString());
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

        [WebMethod]
        public bool deleteObject(string MXXDatabase)
        {
            bool retval = false;
            try
            {
                if (File.Exists(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID + "\\" + MXXDatabase + ".xml"))
                    File.Delete(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID + "\\" + MXXDatabase + ".xml");
                retval = true;
            }
            catch (Exception error)
            {
                throw error;
            }
            return retval;
        }
        #endregion

        private bool saveBatchXMLFPS(DataSet dsBatch, string MXXDatabase, CommonEnum.FormMode formMode)
        {
            bool retval = false;
            Trax.FPS.v1.Types.Batch invBat = new Trax.FPS.v1.Types.Batch();
            Trax.FPS.v1.Types.Invoice invoice;
            Trax.FPS.v1.Types.FrghtBl frghtBl;
            Trax.FPS.v1.Types.KeyRaw keyIdent;
            Trax.FPS.v1.Types.AddrRaw addrRaw;
            Trax.FPS.v1.Types.ShpmtEqpmtRaw shpmtEqpmtRaw;
            Trax.FPS.v1.Types.ProdDtl prodDtl;
            Trax.FPS.v1.Types.FbLn fbLn;
            Trax.FPS.v1.Types.Auth auth;
            
            try
            {

                string filename = string.Empty;
                if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                    filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + "FPS" + MXXDatabase + ".xml";
                else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                    filename = ConfigurationManager.AppSettings["ObjQADestinationPath"] + "FPS" + MXXDatabase + ".xml";

                else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
                {
                    if (!Directory.Exists(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID))
                        Directory.CreateDirectory(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID);

                    filename = ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID + "\\" + "FPS" + MXXDatabase + ".xml";
                }

                //update batch
                #region InvBat Update
                if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                {
                    dsBatch.Tables["InvBat"].Rows[0]["BatInvCnt"] = dsBatch.Tables["Invoice"].Rows.Count;
                    dsBatch.Tables["InvBat"].Rows[0]["BatFbCnt"] = dsBatch.Tables["FrghtBl"].Rows.Count;
                    dsBatch.Tables["InvBat"].Rows[0]["BatStat"] = "Open";
                    dsBatch.Tables["InvBat"].Rows[0]["BatType"] = "Manual";
                    invBat = this.SetInvBatPropertiesXMLFPS(invBat, dsBatch.Tables["InvBat"].Rows[0]);
                    invBat.Invoices = new List<Trax.FPS.v1.Types.Invoice>();

                    #region Invoice update
                    int invoiceCount = 0;
                    foreach (DataRow newRowInvoice in dsBatch.Tables["Invoice"].Select(string.Format("LocIdRemit = '{0}'", invBat.BatLocIdRemit)))
                    {
                        invoice = new Trax.FPS.v1.Types.Invoice();
                        invoice = this.SetInvoicePropertiesXMLFPS(invoice, newRowInvoice);
                        invBat.Invoices.Add(invoice);
                        invBat.Invoices[invoiceCount].FrghtBls = new List<Trax.FPS.v1.Types.FrghtBl>();
                        #region FrghtBl update
                        int frghtBLCount = 0;
                        foreach (DataRow newRowFrghtBL in dsBatch.Tables["FrghtBl"].Select(string.Format("InvId = '{0}'", invBat.Invoices[invoiceCount].InvId)))
                        {
                            frghtBl = new Trax.FPS.v1.Types.FrghtBl();
                            frghtBl = this.SetFrghtBlPropertiesXMLFPS(frghtBl, newRowFrghtBL);
                            invBat.Invoices[invoiceCount].FrghtBls.Add(frghtBl);
                            #region KeyIdent Update
                            if (dsBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)).Count() > 0)
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].KeyRaws = new List<Trax.FPS.v1.Types.KeyRaw>();
                            foreach (DataRow newRowKeyIdent in dsBatch.Tables["KeyIdents"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)))
                            {
                                keyIdent = new Trax.FPS.v1.Types.KeyRaw();
                                keyIdent = this.SetKeyIdentsPropertiesXMLFPS(keyIdent, newRowKeyIdent);
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].KeyRaws.Add(keyIdent);
                            }
                            #endregion
                            #region Addrs Update
                            if (dsBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)).Count() > 0)
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws = new List<Trax.FPS.v1.Types.AddrRaw>();
                            foreach (DataRow newRowAddrs in dsBatch.Tables["Addrs"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)))
                            {
                                addrRaw = new Trax.FPS.v1.Types.AddrRaw();
                                addrRaw = this.SetAddrsPropertiesXMLFPS(addrRaw, newRowAddrs);
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws.Add(addrRaw);
                                if (newRowAddrs["AddrCat"].ToString() == CommonEnum.AddressType.SHIPPER_INVOICE.ToString() && newRowAddrs["AlZoneAddr"].ToString().Trim() != string.Empty)
                                    invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].VendSrvcZoneOrig = newRowAddrs["AlZoneAddr"].ToString();
                                if (newRowAddrs["AddrCat"].ToString() == CommonEnum.AddressType.CONSIGNEE_INVOICE.ToString() && newRowAddrs["AlZoneAddr"].ToString().Trim() != string.Empty)
                                    invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].VendSrvcZoneDest = newRowAddrs["AlZoneAddr"].ToString();

                            }
                            #endregion
                            #region Cntnrs Update
                            if (dsBatch.Tables["Cntnrs"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)).Count() > 0)
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].ShpmtEqpmts = new List<Trax.FPS.v1.Types.ShpmtEqpmtRaw>();
                            foreach (DataRow newRowCntnrs in dsBatch.Tables["Cntnrs"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)))
                            {
                                shpmtEqpmtRaw = new Trax.FPS.v1.Types.ShpmtEqpmtRaw();
                                shpmtEqpmtRaw = this.SetCntnrsPropertiesXMLFPS(shpmtEqpmtRaw, newRowCntnrs);
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].ShpmtEqpmts.Add(shpmtEqpmtRaw);
                            }
                            #endregion
                            #region ProdDtl Update
                            if (dsBatch.Tables["ProdDtl"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)).Count() > 0)
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].ProdDtls = new List<Trax.FPS.v1.Types.ProdDtl>();
                            foreach (DataRow newRowProdDtl in dsBatch.Tables["ProdDtl"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)))
                            {
                                prodDtl = new Trax.FPS.v1.Types.ProdDtl();
                                prodDtl = this.SetProdDtlPropertiesXMLFPS(prodDtl, newRowProdDtl);
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].ProdDtls.Add(prodDtl);
                            }
                            #endregion
                            #region FBLn Update
                            if (dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)).Count() > 0)
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbLns = new List<Trax.FPS.v1.Types.FbLn>();
                            int FBLnCount = 0;
                            foreach (DataRow newRowFBLn in dsBatch.Tables["FBLn"].Select(string.Format("FbId = '{0}'", invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbId)))
                            {
                                fbLn = new Trax.FPS.v1.Types.FbLn();
                                fbLn = this.SetFbLnPropertiesXMLFPS(fbLn, newRowFBLn);
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].FbLns.Add(fbLn);
                                FBLnCount++;
                            }
                            #endregion
                            #region OtherFields
                            if (newRowFrghtBL["VesselName"] != null && newRowFrghtBL["VesselName"].ToString() != string.Empty)
                            {
                                if (invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].ShpmtEqpmts == null)
                                    invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].ShpmtEqpmts = new List<Trax.FPS.v1.Types.ShpmtEqpmtRaw>();
                                shpmtEqpmtRaw = new Trax.FPS.v1.Types.ShpmtEqpmtRaw();
                                shpmtEqpmtRaw.LocalUntNId = Convert.ToInt64(newRowFrghtBL["FbId"].ToString().Substring(19, 4));
                                shpmtEqpmtRaw.VesselName = newRowFrghtBL["VesselName"].ToString();
                                shpmtEqpmtRaw.EqpmtType = "VESSEL";
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].ShpmtEqpmts.Add(shpmtEqpmtRaw);
                            }
                            if (newRowFrghtBL["FbExtRoute"] != null && newRowFrghtBL["FbExtRoute"].ToString() != string.Empty)
                            {
                                if (invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws == null)
                                    invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws = new List<Trax.FPS.v1.Types.AddrRaw>();
                                addrRaw = new Trax.FPS.v1.Types.AddrRaw();
                                addrRaw.LocalUntNId = Convert.ToInt64(newRowFrghtBL["FbId"].ToString().Substring(19, 4));
                                addrRaw.PlaceName = newRowFrghtBL["FbExtRoute"].ToString();
                                addrRaw.AddrType = "ROUTE";
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws.Add(addrRaw);
                            }
                            if (newRowFrghtBL["FbRcvdBy"] != null && newRowFrghtBL["FbRcvdBy"].ToString() != string.Empty)
                            {
                                if (invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws == null)
                                    invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws = new List<Trax.FPS.v1.Types.AddrRaw>();
                                addrRaw = new Trax.FPS.v1.Types.AddrRaw();
                                addrRaw.LocalUntNId = Convert.ToInt64(newRowFrghtBL["FbId"].ToString().Substring(19, 4));
                                addrRaw.AddrLine1 = newRowFrghtBL["FbRcvdBy"].ToString();
                                addrRaw.AddrType = "RECEIVED";
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].AddrRaws.Add(addrRaw);
                            }

                            if ((newRowFrghtBL["FbPreAuthType"] != null && newRowFrghtBL["FbPreAuthType"].ToString() != string.Empty) ||
                                (newRowFrghtBL["FbPreAuthAmt"] != null && newRowFrghtBL["FbPreAuthAmt"].ToString() != string.Empty) ||
                                (newRowFrghtBL["FbPreAuthBy"] != null && newRowFrghtBL["FbPreAuthBy"].ToString() != string.Empty))
                            {
                                if (invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].Authorizations == null)
                                    invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].Authorizations = new List<Trax.FPS.v1.Types.Auth>();
                                auth = new Trax.FPS.v1.Types.Auth();
                                auth.AppliedToUntNId = Convert.ToInt64(newRowFrghtBL["FbId"].ToString().Substring(19, 4));
                                auth.AuthKey = newRowFrghtBL["FbKey"].ToString();
                                if (newRowFrghtBL["FbPreAuthType"] != DBNull.Value)
                                    auth.AuthType = newRowFrghtBL["FbPreAuthType"].ToString();
                                if (newRowFrghtBL["FbPreAuthAmt"] != DBNull.Value && newRowFrghtBL["FbPreAuthAmt"].ToString().Trim() != string.Empty)
                                    auth.OverrideAuthAmt = Convert.ToDecimal(newRowFrghtBL["FbPreAuthAmt"]);
                                if (newRowFrghtBL["FbPreAuthBy"] != DBNull.Value)
                                    auth.CustAuthBy = newRowFrghtBL["FbPreAuthBy"].ToString();
                                invBat.Invoices[invoiceCount].FrghtBls[frghtBLCount].Authorizations.Add(auth);
                            }


                            //if (newRowFrghtBL["CustTaxKey"] != null && newRowFrghtBL["CustTaxKey"].ToString() != string.Empty)
                            //{
                            //    invBat.Invoices[invoiceCount].TaxRegKeyBlng = newRowFrghtBL["CustTaxKey"].ToString();
                            //}
                            if (newRowFrghtBL["FbTaxPcnt"] != null && newRowFrghtBL["FbTaxPcnt"].ToString() != string.Empty)
                            {
                                invBat.Invoices[invoiceCount].TaxPcnt = Convert.ToSingle(newRowFrghtBL["FbTaxPcnt"]);
                            }

                            #endregion
                            frghtBl.FbLnCnt = Convert.ToInt16(FBLnCount);
                            frghtBLCount++;
                        }
                        invoiceCount++;
                        #endregion
                    }
                    #endregion
                }
                #endregion

                // Serialize the data to a file.
                System.Runtime.Serialization.DataContractSerializer dcs = new DataContractSerializer(invBat.GetType());

                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    dcs.WriteObject(fs, invBat);
                }

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
        /*
        private DataSet selectBatchXMLFPS(string MXXDatabase, CommonEnum.FormMode formMode)
        {
            string xmlVerionName = string.Empty;
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                xmlVerionName = "ver." + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + "-" + MXXDatabase;
            }
            else
            {
                xmlVerionName = "ver.Development-" + MXXDatabase;
            }
            DataSet retval = new DataSet(xmlVerionName);
            DataTable tableInvBat = GetInvBatRowStructureXML();
            DataTable tableInvoice = GetInvoiceRowStructureXML();
            DataTable tableFrghtBl = GetFrghtBlRowStructureXML();
            DataTable tableAddrs = GetAddrsRowStructureXML();
            DataTable tableKeyIdents = GetKeyIdentsRowStructureXML();
            DataTable tableCntnrs = GetCntnrsRowStructureXML();
            DataTable tableProdDtl = GetProdDtlRowStructureXML();
            DataTable tableFbLnRow = GetFbLnRowStructureXML();
            DataRow rowInvBat;
            DataRow rowInvoice;
            DataRow rowFrghtBl;
            DataRow rowAddrs;
            DataRow rowKeyIdents;
            DataRow rowCntnrs;
            DataRow rowProdDtl;
            DataRow rowFbLnRow;



            string filename = string.Empty;
            try
            {
                if (formMode == CommonEnum.FormMode.DATA_ENTRY)
                    filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + "FPS" + MXXDatabase + ".xml";
                else if (formMode == CommonEnum.FormMode.QUALITY_ASSURANCE)
                {
                    filename = ConfigurationManager.AppSettings["ObjQADestinationPath"] + "FPS" + MXXDatabase + ".xml";
                    try
                    {
                        if (!File.Exists(filename))
                            File.Copy(ConfigurationManager.AppSettings["ObjDestinationPath"] + "FPS" + MXXDatabase + ".xml", filename);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
                else if (formMode == CommonEnum.FormMode.DATA_ENTRY_TRAINER)
                {
                    if (!Directory.Exists(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID))
                        Directory.CreateDirectory(ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID);

                    filename = ConfigurationManager.AppSettings["ObjTrainingDestinationPath"] + CommonUserLogin.getUser().UserID + "\\" + MXXDatabase + ".xml";
                }
                if (File.Exists(filename))
                {
                    Trax.FPS.v1.Types.Batch invBat = null;
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                        DataContractSerializer ser = new DataContractSerializer(typeof(Trax.FPS.v1.Types.Batch));
                        // Deserialize the data and read it from the instance.
                        invBat = (Trax.FPS.v1.Types.Batch)ser.ReadObject(reader, true);
                    }
                    //System.Diagnostics.Debug.WriteLine(batch.BatId, "BatId");

                    rowInvBat = tableInvBat.NewRow();
                    rowInvBat = SetInvBatRowXMLFPS(invBat, rowInvBat);
                    tableInvBat.Rows.Add(rowInvBat);
                    if (invBat.Invoices != null)
                        foreach (Trax.FPS.v1.Types.Invoice invoice in invBat.Invoices)
                        {
                            rowInvoice = tableInvoice.NewRow();
                            rowInvoice = SetInvoiceRowXMLFPS(invoice, rowInvoice);
                            tableInvoice.Rows.Add(rowInvoice);
                            if (invoice.FrghtBls != null)
                                foreach (Trax.FPS.v1.Types.FrghtBl frghtBl in invoice.FrghtBls)
                                {
                                    rowFrghtBl = tableFrghtBl.NewRow();
                                    rowFrghtBl = SetFrghtBlRowXMLFPS(frghtBl, rowFrghtBl);
                                    tableFrghtBl.Rows.Add(rowFrghtBl);

                                    #region KeyIdent Update
                                    if (frghtBl.KeyIdents != null)
                                        foreach (Trax.FPS.v1.Types.KeyRaw keyIdent in frghtBl.KeyIdents)
                                        {
                                            rowKeyIdents = tableKeyIdents.NewRow();
                                            rowKeyIdents = SetKeyIdentsRowXMLFPS(keyIdent, rowKeyIdents);
                                            tableKeyIdents.Rows.Add(rowKeyIdents);
                                        }
                                    #endregion
                                    #region Addrs Update
                                    if (frghtBl.Addresses != null)
                                        foreach (Trax.FPS.v1.Types.AddrRaw addrs in frghtBl.Addresses)
                                        {
                                            rowAddrs = tableAddrs.NewRow();
                                            rowAddrs = SetAddrsRowXMLFPS(addrs, rowAddrs);
                                            tableAddrs.Rows.Add(rowAddrs);
                                        }
                                    #endregion
                                    #region Cntnrs Update
                                    if (frghtBl.ShpmtEqpmts != null)
                                        foreach (Trax.FPS.v1.Types.ShpmtEqpmtRaw cntnrs in frghtBl.ShpmtEqpmts)
                                        {
                                            rowCntnrs = tableCntnrs.NewRow();
                                            rowCntnrs = SetCntnrsRowXMLFPS(cntnrs, rowCntnrs);
                                            tableCntnrs.Rows.Add(rowCntnrs);
                                        }
                                    #endregion
                                    #region ProdDtl Update
                                    if (frghtBl.ProdDtls != null)
                                        foreach (Trax.FPS.v1.Types.ProdDtl prodDtl in frghtBl.ProdDtls)
                                        {
                                            rowProdDtl = tableProdDtl.NewRow();
                                            rowProdDtl = SetProdDtlRowXMLFPS(prodDtl, rowProdDtl);
                                            tableProdDtl.Rows.Add(rowProdDtl);
                                        }
                                    #endregion
                                    #region FBLn Update
                                    if (frghtBl.FbLns != null)
                                        foreach (Trax.FPS.v1.Types.FbLn fbLn in frghtBl.FbLns)
                                        {
                                            rowFbLnRow = tableFbLnRow.NewRow();
                                            rowFbLnRow = SetFbLnRowXMLFPS(fbLn, rowFbLnRow);
                                            tableFbLnRow.Rows.Add(rowFbLnRow);
                                        }
                                    #endregion
                                }
                        }
                }
                retval.Tables.Add(tableInvBat.Copy());
                retval.Tables[0].AcceptChanges();
                retval.Tables.Add(tableInvoice.Copy());
                retval.Tables[1].AcceptChanges();
                retval.Tables.Add(tableFrghtBl.Copy());
                retval.Tables[2].AcceptChanges();
                retval.Tables.Add(tableAddrs.Copy());
                retval.Tables[3].AcceptChanges();
                retval.Tables.Add(tableKeyIdents.Copy());
                retval.Tables[4].AcceptChanges();
                retval.Tables.Add(tableCntnrs.Copy());
                retval.Tables[5].AcceptChanges();
                retval.Tables.Add(tableProdDtl.Copy());
                retval.Tables[6].AcceptChanges();
                retval.Tables.Add(tableFbLnRow.Copy());
                retval.Tables[7].AcceptChanges();
            }
            catch
            {
                retval = null;
            }
            finally
            {
            }            
            return retval;
        }        
        */
    }
}
