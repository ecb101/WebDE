using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using Trax.FPS;
using Filex.MSharp.Lib.Common;
using DAL;
namespace DEWebService
{
    /// <summary>
    /// Summary description for CreateMXXmdbBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CreateMXXmdbBL : BaseBLogic
    {
        
        private string insertQueryINV_BAT;        
        private string insertQueryINVOICE;
        private string insertQueryFRGHT_BL;
        private string insertQueryFB_LN;
        private string insertQueryFXI;
        protected DALHelperOleDB dalMXXDatabase;
        public override void setQueries()
        {
            #region INV_BAT
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


            
            #endregion
            #region INVOICE
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
//            insertQueryINVOICE = @"INSERT INTO batmdb_INVOICE
//                                        (INV_ID
//                                        ,OWNER_KEY
//                                        ,INV_KEY
//                                        ,BAT_ID
//                                        ,BAT_KEY
//                                        ,VEND_BAT_KEY
//                                        ,VEND_LABL
//                                        ,LOC_ID_REMIT
//                                        ,INV_TYPE
//                                        ,INV_STAT
//                                        ,INV_FB_CNT
//                                        ,INV_CURRENCY_QUAL
//                                        ,INV_AMT
//                                        ,VEND_INV_AMT
//                                        ,ACCT_NUM_VEND_BLNG
//                                        ,AL_REMIT_1
//                                        ,AL_REMIT_2
//                                        ,AL_REMIT_3
//                                        ,AL_REMIT_4
//                                        ,AL_CITY_REMIT
//                                        ,AL_STATE_PROV_REMIT
//                                        ,AL_POST_CODE_REMIT
//                                        ,AL_CNTRY_CODE_REMIT
//                                        ,INV_CREAT_DTM
//                                        ,INV_APP_AMT
//                                        ,INV_ADJM_AMT
//                                        ,INV_PD_AMT
//                                        ,INV_ADJM_CNT
//                                        ,INV_PAYMT_CNT
//                                        ,INV_CREDIT_AMT
//                                        ,INV_DISPUTE_AMT
//                                        ,INV_OPEN_AMT)
//                                    VALUES
//                                        (@InvId
//                                        ,OwnerKey
//                                        ,@InvKey
//                                        ,@BatId
//                                        ,@batchNumber
//                                        ,@batchNumber
//                                        ,@VendLabl
//                                        ,@LocIdRemit
//                                        ,'Manual Bill'
//                                        ,@InvStat
//                                        ,@InvFbCnt
//                                        ,@InvCurrencyQual
//                                        ,@InvAmt
//                                        ,@VendInvAmt
//                                        ,@AcctNumVendBlng
//                                        ,@AlRemit1
//                                        ,@AlRemit2
//                                        ,@AlRemit3
//                                        ,@AlRemit4
//                                        ,@AlCityRemit
//                                        ,@AlStateProvRemit
//                                        ,@AlPostCodeRemit
//                                        ,@AlCntryCodeRemit
//                                        ,@InvCreatDtm
//                                        ,0
//                                        ,0
//                                        ,0
//                                        ,0
//                                        ,0
//                                        ,0
//                                        ,0
//                                        ,0)";            
            #endregion
            #region FRGHT_BL
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
            
            #endregion
            #region FB_LN
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
                        #endregion
            #region FXI
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
            #endregion
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

            //DataSet retval = new DataSet();
            //InvBat invBat = new InvBat();

            //DataTable tableInvBat = GetInvBatRowStructure();
            //DataTable tableInvoice = GetInvoiceRowStructure();
            //DataTable tableFrghtBl = GetFrghtBlRowStructure();
            //DataTable tableFbLnRow = GetFbLnRowStructure();

            //string filename = ConfigurationManager.AppSettings["ObjDestinationPath"] + MXXDatabase + ".mxx";

            ////check if file exist
            //if (File.Exists(filename))
            //{
            //    //depersist file to an InvBat object
            //    try
            //    {
            //        invBat = (InvBat)dalTrax.DepersistFile(MXXDatabase + ".mxx");
            //        DataRow rowInvBat = tableInvBat.NewRow();
            //        rowInvBat = SetInvBatRow(invBat, rowInvBat);
            //        tableInvBat.Rows.Add(rowInvBat);
            //        foreach (Invoice invoice in invBat.Invoices)
            //        {
            //            DataRow rowInvoice = tableInvoice.NewRow();
            //            rowInvoice = SetInvoiceRow(invoice, rowInvoice);
            //            tableInvoice.Rows.Add(rowInvoice);
            //            foreach (FrghtBl frghtBl in invoice.FrghtBls)
            //            {
            //                DataRow rowFrghtBl = tableFrghtBl.NewRow();
            //                rowFrghtBl = SetFrghtBlRow(frghtBl, rowFrghtBl);
            //                tableFrghtBl.Rows.Add(rowFrghtBl);
            //                foreach (FbLn fbLn in frghtBl.LineItems)
            //                {
            //                    DataRow rowFbLnRow = tableFbLnRow.NewRow();
            //                    rowFbLnRow = SetFbLnRow(fbLn, rowFbLnRow);
            //                    tableFbLnRow.Rows.Add(rowFbLnRow);
            //                }
            //            }
            //        }                    
            //    }
            //    catch
            //    {
            //        retval = null;
            //    }
            //    finally
            //    {
            //    }
            //}
            //retval.Tables.Add(tableInvBat.Copy());
            //retval.Tables[0].AcceptChanges();
            //retval.Tables.Add(tableInvoice.Copy());
            //retval.Tables[1].AcceptChanges();
            //retval.Tables.Add(tableFrghtBl.Copy());
            //retval.Tables[2].AcceptChanges();
            //retval.Tables.Add(tableFbLnRow.Copy());
            //retval.Tables[3].AcceptChanges();
            //return retval;
        }

        [WebMethod]
        public DataSet selectDetail(string MXXDatabase)
        {
            DataSet retval = new DataSet();            
            string query = @"SELECT
                                Oper_Init AS Operator,
                                DE_START_DTM AS DateStart                                
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                dal.OpenDB();
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", MXXDatabase);
                retval = dal.ExecuteDataSet(query, CommandType.Text,param);
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
                    
                    paramINVOICE = new ParameterInfoOleDB[31];


                    paramINVOICE[0] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                    paramINVOICE[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                    paramINVOICE[2] = new ParameterInfoOleDB("@InvKey", dr["InvKey"]);
                    paramINVOICE[3] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                    paramINVOICE[4] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                    paramINVOICE[5] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                    paramINVOICE[6] = new ParameterInfoOleDB("@LocIdRemit", dr["LocIdRemit"]);
                    paramINVOICE[7] = new ParameterInfoOleDB("@InvStat", dr["InvStat"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvStat"]);
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
                    paramINVOICE[21] = new ParameterInfoOleDB("@InvCreatDtm", (dr["InvCreatDtm"].ToString().Trim() == string.Empty || dr["InvCreatDtm"] == null) ? DBNull.Value : dr["InvCreatDtm"]);
                    paramINVOICE[22] = new ParameterInfoOleDB("@LocIdBlng", dr["LocIdBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["LocIdBlng"]);
                    paramINVOICE[23] = new ParameterInfoOleDB("@AlBlng1", dr["AlBlng1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng1"]);
                    paramINVOICE[24] = new ParameterInfoOleDB("@AlBlng2", dr["AlBlng2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng2"]);
                    paramINVOICE[25] = new ParameterInfoOleDB("@AlBlng3", dr["AlBlng3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng3"]);
                    paramINVOICE[26] = new ParameterInfoOleDB("@AlBlng4", dr["AlBlng4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlBlng4"]);
                    paramINVOICE[27] = new ParameterInfoOleDB("@AlCityBlng", dr["AlCityBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityBlng"]);
                    paramINVOICE[28] = new ParameterInfoOleDB("@AlStateProvBlng", dr["AlStateProvBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvBlng"]);
                    paramINVOICE[29] = new ParameterInfoOleDB("@AlPostCodeBlng", dr["AlPostCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeBlng"]);
                    paramINVOICE[30] = new ParameterInfoOleDB("@AlCntryCodeBlng", dr["AlCntryCodeBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeBlng"]);

                    //paramINVOICE[0] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                    //paramINVOICE[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                    //paramINVOICE[2] = new ParameterInfoOleDB("@InvKey", dr["InvKey"]);
                    //paramINVOICE[3] = new ParameterInfoOleDB("@BatId", "BACH" + ownerKey + batchNumber + batchCount);
                    //paramINVOICE[4] = new ParameterInfoOleDB("@batchNumber", batchNumber);
                    //paramINVOICE[5] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                    //paramINVOICE[6] = new ParameterInfoOleDB("@LocIdRemit", dr["LocIdRemit"]);
                    //paramINVOICE[7] = new ParameterInfoOleDB("@InvStat", dr["InvStat"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvStat"]);
                    //paramINVOICE[8] = new ParameterInfoOleDB("@InvFbCnt", dr["InvFbCnt"].ToString().Trim() == string.Empty ? 0 : dr["InvFbCnt"]);
                    //paramINVOICE[9] = new ParameterInfoOleDB("@InvCurrencyQual", dr["InvCurrencyQual"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvCurrencyQual"]);
                    //paramINVOICE[10] = new ParameterInfoOleDB("@InvAmt", dr["InvAmt"].ToString().Trim() == string.Empty ? 0 : dr["InvAmt"]);
                    //paramINVOICE[11] = new ParameterInfoOleDB("@VendInvAmt", dr["VendInvAmt"].ToString().Trim() == string.Empty ? 0 : dr["VendInvAmt"]);
                    //paramINVOICE[12] = new ParameterInfoOleDB("@AcctNumVendBlng", dr["AcctNumVendBlng"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AcctNumVendBlng"]);
                    //paramINVOICE[13] = new ParameterInfoOleDB("@AlRemit1", dr["AlRemit1"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit1"]);
                    //paramINVOICE[14] = new ParameterInfoOleDB("@AlRemit2", dr["AlRemit2"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit2"]);
                    //paramINVOICE[15] = new ParameterInfoOleDB("@AlRemit3", dr["AlRemit3"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit3"]);
                    //paramINVOICE[16] = new ParameterInfoOleDB("@AlRemit4", dr["AlRemit4"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlRemit4"]);
                    //paramINVOICE[17] = new ParameterInfoOleDB("@AlCityRemit", dr["AlCityRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCityRemit"]);
                    //paramINVOICE[18] = new ParameterInfoOleDB("@AlStateProvRemit", dr["AlStateProvRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlStateProvRemit"]);
                    //paramINVOICE[19] = new ParameterInfoOleDB("@AlPostCodeRemit", dr["AlPostCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlPostCodeRemit"]);
                    //paramINVOICE[20] = new ParameterInfoOleDB("@AlCntryCodeRemit", dr["AlCntryCodeRemit"].ToString().Trim() == string.Empty ? DBNull.Value : dr["AlCntryCodeRemit"]);
                    //paramINVOICE[21] = new ParameterInfoOleDB("@InvCreatDtm", (dr["InvCreatDtm"].ToString().Trim() == string.Empty || dr["InvCreatDtm"] == null) ? DBNull.Value : dr["InvCreatDtm"]);
                    affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryINVOICE, CommandType.Text, paramINVOICE);
                                        
                }
                #endregion
                #region FRGHT_BL
                foreach (DataRow dr in dsBatch.Tables["FB"].Rows)
                {
                    ParameterInfoOleDB[] paramFRGHT_BL;
                    
                        paramFRGHT_BL = new ParameterInfoOleDB[54];

                        paramFRGHT_BL[0] = new ParameterInfoOleDB("@FBId", dr["FbId"]);
                        paramFRGHT_BL[1] = new ParameterInfoOleDB("@OwnerKey", OwnerKey);
                        paramFRGHT_BL[2] = new ParameterInfoOleDB("@FbKey", dr["FbKey"]);
                        paramFRGHT_BL[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                        paramFRGHT_BL[4] = new ParameterInfoOleDB("@InvKey", dr["InvKey"]);
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
                #endregion
                #region FB_LN
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
                                        
                }
                #endregion
                #region FXI
                foreach (DataRow dr in dsBatch.Tables["FXI"].Rows)
                {
                    ParameterInfoOleDB[] paramFXI;

                    paramFXI = new ParameterInfoOleDB[125];
                    paramFXI[0] = new ParameterInfoOleDB("@FbId", dr["FBId"]);
                    paramFXI[1] = new ParameterInfoOleDB("@InvPageNum", dr["InvPageNum"].ToString().Trim() == string.Empty ? DBNull.Value : dr["InvPageNum"]);
                    paramFXI[2] = new ParameterInfoOleDB("@VendLabl", dr["VendLabl"]);
                    paramFXI[3] = new ParameterInfoOleDB("@InvId", dr["InvId"]);
                    paramFXI[4] = new ParameterInfoOleDB("@BatId", dr["BatId"]);
                    paramFXI[5] = new ParameterInfoOleDB("@T001", dr["T001"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T001"]);
                    paramFXI[6] = new ParameterInfoOleDB("@T002", dr["T002"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T002"]);
                    paramFXI[7] = new ParameterInfoOleDB("@T003", dr["T003"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T003"]);
                    paramFXI[8] = new ParameterInfoOleDB("@T004", dr["T004"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T004"]);
                    paramFXI[9] = new ParameterInfoOleDB("@T005", dr["T005"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T005"]);
                    paramFXI[10] = new ParameterInfoOleDB("@T006", dr["T006"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T006"]);
                    paramFXI[11] = new ParameterInfoOleDB("@T007", dr["T007"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T007"]);
                    paramFXI[12] = new ParameterInfoOleDB("@T008", dr["T008"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T008"]);
                    paramFXI[13] = new ParameterInfoOleDB("@T009", dr["T009"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T009"]);
                    paramFXI[14] = new ParameterInfoOleDB("@T010", dr["T010"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T010"]);
                    paramFXI[15] = new ParameterInfoOleDB("@T011", dr["T011"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T011"]);
                    paramFXI[16] = new ParameterInfoOleDB("@T012", dr["T012"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T012"]);
                    paramFXI[17] = new ParameterInfoOleDB("@T013", dr["T013"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T013"]);
                    paramFXI[18] = new ParameterInfoOleDB("@T014", dr["T014"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T014"]);
                    paramFXI[19] = new ParameterInfoOleDB("@T015", dr["T015"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T015"]);
                    paramFXI[20] = new ParameterInfoOleDB("@T016", dr["T016"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T016"]);
                    paramFXI[21] = new ParameterInfoOleDB("@T017", dr["T017"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T017"]);
                    paramFXI[22] = new ParameterInfoOleDB("@T018", dr["T018"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T018"]);
                    paramFXI[23] = new ParameterInfoOleDB("@T019", dr["T019"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T019"]);
                    paramFXI[24] = new ParameterInfoOleDB("@T020", dr["T020"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T020"]);
                    paramFXI[25] = new ParameterInfoOleDB("@T021", dr["T021"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T021"]);
                    paramFXI[26] = new ParameterInfoOleDB("@T022", dr["T022"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T022"]);
                    paramFXI[27] = new ParameterInfoOleDB("@T023", dr["T023"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T023"]);
                    paramFXI[28] = new ParameterInfoOleDB("@T024", dr["T024"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T024"]);
                    paramFXI[29] = new ParameterInfoOleDB("@T025", dr["T025"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T025"]);
                    paramFXI[30] = new ParameterInfoOleDB("@T026", dr["T026"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T026"]);
                    paramFXI[31] = new ParameterInfoOleDB("@T027", dr["T027"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T027"]);
                    paramFXI[32] = new ParameterInfoOleDB("@T028", dr["T028"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T028"]);
                    paramFXI[33] = new ParameterInfoOleDB("@T029", dr["T029"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T029"]);
                    paramFXI[34] = new ParameterInfoOleDB("@T030", dr["T030"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T030"]);
                    paramFXI[35] = new ParameterInfoOleDB("@T031", dr["T031"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T031"]);
                    paramFXI[36] = new ParameterInfoOleDB("@T032", dr["T032"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T032"]);
                    paramFXI[37] = new ParameterInfoOleDB("@T033", dr["T033"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T033"]);
                    paramFXI[38] = new ParameterInfoOleDB("@T034", dr["T034"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T034"]);
                    paramFXI[39] = new ParameterInfoOleDB("@T035", dr["T035"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T035"]);
                    paramFXI[40] = new ParameterInfoOleDB("@T036", dr["T036"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T036"]);
                    paramFXI[41] = new ParameterInfoOleDB("@T037", dr["T037"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T037"]);
                    paramFXI[42] = new ParameterInfoOleDB("@T038", dr["T038"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T038"]);
                    paramFXI[43] = new ParameterInfoOleDB("@T039", dr["T039"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T039"]);
                    paramFXI[44] = new ParameterInfoOleDB("@T040", dr["T040"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T040"]);
                    paramFXI[45] = new ParameterInfoOleDB("@T041", dr["T041"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T041"]);
                    paramFXI[46] = new ParameterInfoOleDB("@T042", dr["T042"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T042"]);
                    paramFXI[47] = new ParameterInfoOleDB("@T043", dr["T043"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T043"]);
                    paramFXI[48] = new ParameterInfoOleDB("@T044", dr["T044"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T044"]);
                    paramFXI[49] = new ParameterInfoOleDB("@T045", dr["T045"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T045"]);
                    paramFXI[50] = new ParameterInfoOleDB("@T046", dr["T046"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T046"]);
                    paramFXI[51] = new ParameterInfoOleDB("@T047", dr["T047"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T047"]);
                    paramFXI[52] = new ParameterInfoOleDB("@T048", dr["T048"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T048"]);
                    paramFXI[53] = new ParameterInfoOleDB("@T049", dr["T049"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T049"]);
                    paramFXI[54] = new ParameterInfoOleDB("@T050", dr["T050"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T050"]);
                    paramFXI[55] = new ParameterInfoOleDB("@T051", dr["T051"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T051"]);
                    paramFXI[56] = new ParameterInfoOleDB("@T052", dr["T052"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T052"]);
                    paramFXI[57] = new ParameterInfoOleDB("@T053", dr["T053"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T053"]);
                    paramFXI[58] = new ParameterInfoOleDB("@T054", dr["T054"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T054"]);
                    paramFXI[59] = new ParameterInfoOleDB("@T055", dr["T055"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T055"]);
                    paramFXI[60] = new ParameterInfoOleDB("@T056", dr["T056"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T056"]);
                    paramFXI[61] = new ParameterInfoOleDB("@T057", dr["T057"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T057"]);
                    paramFXI[62] = new ParameterInfoOleDB("@T058", dr["T058"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T058"]);
                    paramFXI[63] = new ParameterInfoOleDB("@T059", dr["T059"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T059"]);
                    paramFXI[64] = new ParameterInfoOleDB("@T060", dr["T060"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T060"]);
                    paramFXI[65] = new ParameterInfoOleDB("@T061", dr["T061"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T061"]);
                    paramFXI[66] = new ParameterInfoOleDB("@T062", dr["T062"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T062"]);
                    paramFXI[67] = new ParameterInfoOleDB("@T063", dr["T063"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T063"]);
                    paramFXI[68] = new ParameterInfoOleDB("@T064", dr["T064"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T064"]);
                    paramFXI[69] = new ParameterInfoOleDB("@T065", dr["T065"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T065"]);
                    paramFXI[70] = new ParameterInfoOleDB("@T066", dr["T066"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T066"]);
                    paramFXI[71] = new ParameterInfoOleDB("@T067", dr["T067"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T067"]);
                    paramFXI[72] = new ParameterInfoOleDB("@T068", dr["T068"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T068"]);
                    paramFXI[73] = new ParameterInfoOleDB("@T069", dr["T069"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T069"]);
                    paramFXI[74] = new ParameterInfoOleDB("@T070", dr["T070"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T070"]);
                    paramFXI[75] = new ParameterInfoOleDB("@T071", dr["T071"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T071"]);
                    paramFXI[76] = new ParameterInfoOleDB("@T072", dr["T072"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T072"]);
                    paramFXI[77] = new ParameterInfoOleDB("@T073", dr["T073"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T073"]);
                    paramFXI[78] = new ParameterInfoOleDB("@T074", dr["T074"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T074"]);
                    paramFXI[79] = new ParameterInfoOleDB("@T075", dr["T075"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T075"]);
                    paramFXI[80] = new ParameterInfoOleDB("@T076", dr["T076"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T076"]);
                    paramFXI[81] = new ParameterInfoOleDB("@T077", dr["T077"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T077"]);
                    paramFXI[82] = new ParameterInfoOleDB("@T078", dr["T078"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T078"]);
                    paramFXI[83] = new ParameterInfoOleDB("@T079", dr["T079"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T079"]);
                    paramFXI[84] = new ParameterInfoOleDB("@T080", dr["T080"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T080"]);
                    paramFXI[85] = new ParameterInfoOleDB("@T081", dr["T081"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T081"]);
                    paramFXI[86] = new ParameterInfoOleDB("@T082", dr["T082"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T082"]);
                    paramFXI[87] = new ParameterInfoOleDB("@T083", dr["T083"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T083"]);
                    paramFXI[88] = new ParameterInfoOleDB("@T084", dr["T084"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T084"]);
                    paramFXI[89] = new ParameterInfoOleDB("@T085", dr["T085"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T085"]);
                    paramFXI[90] = new ParameterInfoOleDB("@T086", dr["T086"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T086"]);
                    paramFXI[91] = new ParameterInfoOleDB("@T087", dr["T087"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T087"]);
                    paramFXI[92] = new ParameterInfoOleDB("@T088", dr["T088"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T088"]);
                    paramFXI[93] = new ParameterInfoOleDB("@T089", dr["T089"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T089"]);
                    paramFXI[94] = new ParameterInfoOleDB("@T090", dr["T090"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T090"]);
                    paramFXI[95] = new ParameterInfoOleDB("@T091", dr["T091"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T091"]);
                    paramFXI[96] = new ParameterInfoOleDB("@T092", dr["T092"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T092"]);
                    paramFXI[97] = new ParameterInfoOleDB("@T093", dr["T093"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T093"]);
                    paramFXI[98] = new ParameterInfoOleDB("@T094", dr["T094"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T094"]);
                    paramFXI[99] = new ParameterInfoOleDB("@T095", dr["T095"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T095"]);
                    paramFXI[100] = new ParameterInfoOleDB("@T096", dr["T096"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T096"]);
                    paramFXI[101] = new ParameterInfoOleDB("@T097", dr["T097"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T097"]);
                    paramFXI[102] = new ParameterInfoOleDB("@T098", dr["T098"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T098"]);
                    paramFXI[103] = new ParameterInfoOleDB("@T099", dr["T099"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T099"]);
                    paramFXI[104] = new ParameterInfoOleDB("@T100", dr["T100"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T100"]);
                    paramFXI[105] = new ParameterInfoOleDB("@T101", dr["T101"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T101"]);
                    paramFXI[106] = new ParameterInfoOleDB("@T102", dr["T102"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T102"]);
                    paramFXI[107] = new ParameterInfoOleDB("@T103", dr["T103"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T103"]);
                    paramFXI[108] = new ParameterInfoOleDB("@T104", dr["T104"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T104"]);
                    paramFXI[109] = new ParameterInfoOleDB("@T105", dr["T105"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T105"]);
                    paramFXI[110] = new ParameterInfoOleDB("@T106", dr["T106"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T106"]);
                    paramFXI[111] = new ParameterInfoOleDB("@T107", dr["T107"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T107"]);
                    paramFXI[112] = new ParameterInfoOleDB("@T108", dr["T108"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T108"]);
                    paramFXI[113] = new ParameterInfoOleDB("@T109", dr["T109"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T109"]);
                    paramFXI[114] = new ParameterInfoOleDB("@T110", dr["T110"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T110"]);
                    paramFXI[115] = new ParameterInfoOleDB("@T111", dr["T111"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T111"]);
                    paramFXI[116] = new ParameterInfoOleDB("@T112", dr["T112"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T112"]);
                    paramFXI[117] = new ParameterInfoOleDB("@T113", dr["T113"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T113"]);
                    paramFXI[118] = new ParameterInfoOleDB("@T114", dr["T114"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T114"]);
                    paramFXI[119] = new ParameterInfoOleDB("@T115", dr["T115"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T115"]);
                    paramFXI[120] = new ParameterInfoOleDB("@T116", dr["T116"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T116"]);
                    paramFXI[121] = new ParameterInfoOleDB("@T117", dr["T117"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T117"]);
                    paramFXI[122] = new ParameterInfoOleDB("@T118", dr["T118"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T118"]);
                    paramFXI[123] = new ParameterInfoOleDB("@T119", dr["T119"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T119"]);
                    paramFXI[124] = new ParameterInfoOleDB("@T120", dr["T120"].ToString().Trim() == string.Empty ? DBNull.Value : dr["T120"]);

                    affectedRows = dalMXXDatabase.ExecuteNonQuery(insertQueryFXI, CommandType.Text, paramFXI);

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
        public bool insertTRBat(string ownerKey, string MXXBatch, DateTime dateStart, string userInitial)
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
                param[7] = new ParameterInfoOleDB("@EX_BAT_CREAT_DTM", dateStart);
                param[8] = new ParameterInfoOleDB("@EX_BAT_CREAT_DTM_ORIG", dateStart);
                param[9] = new ParameterInfoOleDB("@EX_BAT_TRANS_CNT", 0);
                param[10] = new ParameterInfoOleDB("@EX_BAT_OWN_USER", userInitial);

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
    }
}
