using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Trax.FPS;
using Filex.MSharp.Lib.Common;
using DAL;
using Trax.FPS;
using Filex.MSharp.Lib.Common;
namespace DEWebService
{
    /// <summary>
    /// Summary description for wsBase
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public abstract class BaseBLogic : System.Web.Services.WebService
    {
        protected DALHelper dal;

        protected DALHelperTrax dalTrax;
        protected string insertQuery;
        protected string updateQuery;
        protected string deleteQuery;
        protected string selectAllQuery;
        protected string selectQuery;                

        public BaseBLogic()
        {
            dal = new DALHelper("LocalDEConnection");

            //try
            //{
            //    dal.TestOpenDB();
            //}
            //catch
            //{
            //    dal = new DALHelper("DEConnection");
            //}
            //finally
            //{
            //    dal.CloseDB();
            //}
            dalTrax = new DALHelperTrax();
            setQueries();
        }

        public abstract void setQueries();

        [WebMethod]
        public virtual bool Insert(System.Data.DataTable dt)
        {
            bool retval = false;
            int affectedRows = 0;
            ParameterInfo[] param = this.GetParameters(dt.Rows[0]);
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(insertQuery, CommandType.Text, param);
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dal.RollBackTransaction();
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public virtual bool Update(System.Data.DataTable dt)
        {
            bool retval = false;
            int affectedRows = 0;
            ParameterInfo[] param = this.GetParameters(dt.Rows[0]);
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(updateQuery, CommandType.Text, param);
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dal.RollBackTransaction();
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public virtual bool Delete(string[] primaryKeys, string[] parametersValues)
        {
            bool retval = false;
            int affectedRows = 0;
            ParameterInfo[] param = new ParameterInfo[primaryKeys.Count()];

            for (int i = 0; i < primaryKeys.Count(); i++)
            {
                param[i] = new ParameterInfo("@" + primaryKeys[i].ToString(), parametersValues[i].ToString());
            }
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(deleteQuery, CommandType.Text, param);
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dal.RollBackTransaction();
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public virtual DataSet SelectAll()
        {
            DataSet retval = new DataSet();
            try
            {
                dal.OpenDB();
                retval = dal.ExecuteDataSet(selectAllQuery, CommandType.Text);
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

        public virtual DataSet Select(ArrayList parameters)
        {
            DataSet retval = new DataSet();
            ParameterInfo[] param = new ParameterInfo[1];
            param[0] = new ParameterInfo("@PrimaryKey", parameters[0].ToString());
            try
            {
                dal.OpenDB();
                retval = dal.ExecuteDataSet(selectQuery, CommandType.Text, param);
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

        public DateTime GetServerDate(DALHelper dal)
        {
            DateTime retval;
            string query = @"SELECT CONVERT(VARCHAR(25), GETUTCDATE(), 121)";
            try
            {
                retval = Convert.ToDateTime(dal.ExecuteScalar(query, CommandType.Text));
            }
            catch (Exception e)
            {
                throw e;
            }
            return retval;
        }

        [WebMethod]
        public DateTime GetServerDate()
        {
            DateTime retval;
            string query = @"SELECT CONVERT(VARCHAR(25), GETUTCDATE(), 121)";
            try
            {
                dal.OpenDB();
                retval = Convert.ToDateTime(dal.ExecuteScalar(query, CommandType.Text));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }            
            return retval;
        }

        public DataTable GetTableStructure(string tableName)
        {
            DataTable retval = new DataTable();
            retval = dal.GetTableStructure(tableName);
            return retval;
        }

        protected ParameterInfo[] GetParameters(DataRow row)
        {
            ParameterInfo[] retval = new ParameterInfo[row.Table.Columns.Count];
            int Columns = 0;
            foreach (DataColumn column in row.Table.Columns)
            {
                retval[Columns] = new ParameterInfo("@" + column.ColumnName, row[column.ColumnName]);
                Columns++;
            }
            return retval;
        }

        protected ParameterInfo[] GetParametersNoSpecialChar(DataRow row)
        {
            ParameterInfo[] retval = new ParameterInfo[row.Table.Columns.Count];
            int Columns = 0;
            
            foreach (DataColumn column in row.Table.Columns)
            {
                retval[Columns] = new ParameterInfo("@" + column.ColumnName.Replace("/", string.Empty).Replace("%", string.Empty), row[column.ColumnName]);
                Columns++;
            }
            return retval;
        }

        protected ParameterInfoOleDB[] GetParametersOleDB(DataRow row)
        {
            ParameterInfoOleDB[] retval = new ParameterInfoOleDB[row.Table.Columns.Count];
            int Columns = 0;
            foreach (DataColumn column in row.Table.Columns)
            {
                retval[Columns] = new ParameterInfoOleDB("@" + column.ColumnName, row[column.ColumnName]);
                Columns++;
            }
            return retval;
        }
               
        protected InvBat SetInvBatProperties(InvBat invoiceBat, DataRow row)
        {   
            invoiceBat.BatAmt = row["BatAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["BatAmt"].ToString());//BAT_AMT AS BatAmt,
            if (row["BatCreatDtm"].ToString() == "")//BAT_CREAT_DTM AS BatCreatDtm,
                invoiceBat.BatCreatDtm = Nullable_Of_DateTime.Null;
            else
                invoiceBat.BatCreatDtm = new DateTime(Convert.ToDateTime(row["BatCreatDtm"]).Year, Convert.ToDateTime(row["BatCreatDtm"]).Month, Convert.ToDateTime(row["BatCreatDtm"]).Day, Convert.ToDateTime(row["BatCreatDtm"]).Hour, Convert.ToDateTime(row["BatCreatDtm"]).Minute, Convert.ToDateTime(row["BatCreatDtm"]).Second, DateTimeKind.Utc);
            invoiceBat.BatCurrencyQual = row["BatCurrencyQual"].ToString();//BAT_CURRENCY_QUAL AS BatCurrencyQual,
            if (row["BatFbCnt"].ToString() == "")//BAT_FB_CNT AS BatFbCnt,
                invoiceBat.BatFbCnt = Nullable_Of_Int32.Null;
            else
                invoiceBat.BatFbCnt = Convert.ToInt32(row["BatFbCnt"].ToString());
            invoiceBat.BatId = row["BatId"].ToString();//BAT_ID AS BatId,
            if (row["BatInvCnt"].ToString() == "")//BAT_INV_CNT AS BatInvCnt,
                invoiceBat.BatInvCnt = Nullable_Of_Int32.Null;
            else
                invoiceBat.BatInvCnt = Convert.ToInt32(row["BatInvCnt"].ToString());
            invoiceBat.BatKey = row["BatKey"].ToString();//BAT_KEY AS BatKey,
            invoiceBat.BatLocIdRemit = row["BatLocIdRemit"].ToString();//BAT_LOC_ID_REMIT AS BatLocIdRemit,
            invoiceBat.BatStat = row["BatStat"].ToString();//BAT_STAT AS BatStat,
            invoiceBat.BatType = row["BatType"].ToString();//BAT_TYPE AS BatType
            invoiceBat.OwnerKey = row["OwnerKey"].ToString();//OWNER_KEY AS OwnerKey,
            if (row["VendBatDtm"].ToString() == "")//VEND_BAT_DTM AS VendBatDtm,
                invoiceBat.VendBatDtm = Nullable_Of_DateTime.Null;
            else
                invoiceBat.VendBatDtm = new DateTime(Convert.ToDateTime(row["VendBatDtm"]).Year, Convert.ToDateTime(row["VendBatDtm"]).Month, Convert.ToDateTime(row["VendBatDtm"]).Day, Convert.ToDateTime(row["VendBatDtm"]).Hour, Convert.ToDateTime(row["VendBatDtm"]).Minute, Convert.ToDateTime(row["VendBatDtm"]).Second, DateTimeKind.Utc);
            invoiceBat.VendBatKey = row["VendBatKey"].ToString();//VEND_BAT_KEY AS VendBatKey,
            invoiceBat.VendFeed = row["VendFeed"].ToString();//VEND_FEED AS VendFeed,
            invoiceBat.VendLabl = row["VendLabl"].ToString();//VEND_LABL AS VendLabl,

            //invoiceBat.BatAdjmAmt = row["BatAdjmAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["BatAdjmAmt"].ToString());
            //if (row["BatAdjmAmt"].ToString() == "")
            //    invoiceBat.BatAdjmCnt = 0;
            //else
            //    invoiceBat.BatAdjmCnt = Convert.ToInt16(row["BatAdjmCnt"].ToString());
            //invoiceBat.BatAppAmt = row["BatAppAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["BatAppAmt"].ToString());
            //invoiceBat.BatCreditAmt = row["BatCreditAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["BatCreditAmt"].ToString());
            //invoiceBat.BatDisputeAmt = row["BatDisputeAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["BatDisputeAmt"].ToString());
            //if(row["BatDueDtm"].ToString() == "")
            //    invoiceBat.BatDueDtm = Nullable_Of_DateTime.Null;
            //else
            //    invoiceBat.BatDueDtm = Convert.ToDateTime(row["BatDueDtm"].ToString());
            //if(row["BatMsgCtrlDtm"].ToString() == "")
            //    invoiceBat.BatMsgCtrlDtm = Nullable_Of_DateTime.Null;
            //else
            //    invoiceBat.BatMsgCtrlDtm = Convert.ToDateTime(row["BatMsgCtrlDtm"].ToString());
            //if(row["BatMsgCtrlPodDtm"].ToString() == "")
            //    invoiceBat.BatMsgCtrlPodDtm = Nullable_Of_DateTime.Null;
            //else
            //    invoiceBat.BatMsgCtrlPodDtm =  Convert.ToDateTime(row["BatMsgCtrlPodDtm"].ToString());
            //invoiceBat.BatMsgCtrlRouteLabl = row["BatMsgCtrlRouteLabl"].ToString();
            //if(row["BatMsgCtrlSnapCnt"].ToString() == "")
            //    invoiceBat.BatMsgCtrlSnapCnt =  0;
            //else
            //    invoiceBat.BatMsgCtrlSnapCnt = Convert.ToInt16(row["BatMsgCtrlSnapCnt"].ToString());
            //invoiceBat.BatMsgCtrlStat = row["BatMsgCtrlStat"].ToString();
            //invoiceBat.BatMsgCtrlType = row["BatMsgCtrlType"].ToString();
            //invoiceBat.BatOpenAmt = row["BatOpenAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["BatOpenAmt"].ToString());
            //if(row["BatPaymtCnt"].ToString() == "")
            //    invoiceBat.BatPaymtCnt = 0;
            //else
            //    invoiceBat.BatPaymtCnt = Convert.ToInt16(row["BatPaymtCnt"].ToString());
            //invoiceBat.BatPdAmt = row["BatPdAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["BatPdAmt"].ToString());
            //if(row["BatSnapCnt"].ToString() == "")
            //    invoiceBat.BatSnapCnt = 0;
            //else
            //    invoiceBat.BatSnapCnt = Convert.ToInt16(row["BatSnapCnt"].ToString());
            //invoiceBat.BatVoidFlag = row["BatVoidFlag"].ToString() == "" ? false : Convert.ToBoolean(row["BatVoidFlag"].ToString());
            //if (row["ImgDpFileDtm"].ToString() == "")
            //    invoiceBat.ImgDpFileDtm = Nullable_Of_DateTime.Null;
            //else
            //    invoiceBat.ImgDpFileDtm = Convert.ToDateTime(row["ImgDpFileDtm"].ToString());
            //invoiceBat.ImgDpFileGrp = row["ImgDpFileGrp"].ToString();
            //invoiceBat.ImgDpFileName = row["ImgDpFileName"].ToString();
            //invoiceBat.MsgGrpNum = row["MsgGrpNum"].ToString();
            //invoiceBat.MsgGrpNumHist = row["MsgGrpNumHist"].ToString();
            //invoiceBat.MsgGrpOrigHist = row["MsgGrpOrigHist"].ToString();
            //invoiceBat.VendBatAmt = row["VendBatAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["VendBatAmt"].ToString());
            return invoiceBat;
        }

        protected Invoice SetInvoiceProperties(Invoice invoice, DataRow row)
        {
            invoice.AcctNumVendBlng = row["AcctNumVendBlng"].ToString();//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            invoice.AlCityRemit = row["AlCityRemit"].ToString();//AL_CITY_REMIT AS AlCityRemit,
            invoice.AlCntryCodeRemit = row["AlCntryCodeRemit"].ToString();//AL_CNTRY_CODE_REMIT AS AlCntryCodeRemit,
            invoice.AlPostCodeRemit = row["AlPostCodeRemit"].ToString();//AL_POST_CODE_REMIT AS AlPostCodeRemit,
            invoice.AlRemit1 = row["AlRemit1"].ToString();//AL_REMIT_1 AS AlRemit1,
            invoice.AlRemit2 = row["AlRemit2"].ToString();//AL_REMIT_2 AS AlRemit2,
            invoice.AlRemit3 = row["AlRemit3"].ToString();//AL_REMIT_3 AS AlRemit3,
            invoice.AlRemit4 = row["AlRemit4"].ToString();//AL_REMIT_4 AS AlRemit4,
            invoice.AlStateProvRemit = row["AlStateProvRemit"].ToString();//AL_STATE_PROV_REMIT AS AlStateProvRemit,
            invoice.BatId = invoice.Batch.BatId;//row["BatId"].ToString();
            invoice.BatKey = invoice.Batch.BatKey;//row["BatKey"].ToString();            
            if (row["InvAmt"].ToString() == "")//INV_AMT AS InvAmt
                invoice.InvAmt = Nullable_Of_Decimal.Null;
            else
                invoice.InvAmt = Convert.ToDecimal(row["InvAmt"]);
            if (row["InvCreatDtm"].ToString() == "")//INV_CREAT_DTM AS InvCreatDtm
                invoice.InvCreatDtm = Nullable_Of_DateTime.Null;
            else                            
                invoice.InvCreatDtm = new DateTime(Convert.ToDateTime(row["InvCreatDtm"]).Year, Convert.ToDateTime(row["InvCreatDtm"]).Month, Convert.ToDateTime(row["InvCreatDtm"]).Day, Convert.ToDateTime(row["InvCreatDtm"]).Hour, Convert.ToDateTime(row["InvCreatDtm"]).Minute, Convert.ToDateTime(row["InvCreatDtm"]).Second, DateTimeKind.Utc);            
            invoice.InvCurrencyQual = row["InvCurrencyQual"].ToString();//INV_CURRENCY_QUAL AS InvCurrencyQual,
            if (row["InvFbCnt"].ToString() == "")//INV_FB_CNT AS InvFbCnt,
                invoice.InvFbCnt = Nullable_Of_Int32.Null;
            else
                invoice.InvFbCnt = Convert.ToInt32(row["InvFbCnt"]);
            invoice.InvId = row["InvId"].ToString();//INV_ID AS InvId,
            invoice.InvKey = row["InvKey"].ToString();//INV_KEY AS InvKey,
            invoice.LocIdRemit = row["LocIdRemit"].ToString();//LOC_ID_REMIT AS LocIdRemit,
            invoice.OwnerKey = invoice.Batch.OwnerKey; //row["OwnerKey"].ToString();
            invoice.VendBatKey = invoice.Batch.VendBatKey;//row["VendBatKey"].ToString();
            if (row["VendInvAmt"].ToString() == "")//VEND_INV_AMT AS VendInvAmt,
                invoice.VendInvAmt = Nullable_Of_Decimal.Null;
            else
                invoice.VendInvAmt = Convert.ToDecimal(row["VendInvAmt"]);
            invoice.VendLabl = row["VendLabl"].ToString();//VEND_LABL AS VendLabl,
            //invoice.AcctIdVendBlng = row["AcctIdVendBlng"].ToString();            
            invoice.AlBlng1 = row["AlBlng1"].ToString();
            invoice.AlBlng2 = row["AlBlng2"].ToString();
            invoice.AlBlng3 = row["AlBlng3"].ToString();
            invoice.AlBlng4 = row["AlBlng4"].ToString();
            //invoice.AlBlngQual = row["AlBlngQual"].ToString();
            invoice.AlCityBlng = row["AlCityBlng"].ToString();
            invoice.AlCntryCodeBlng = row["AlCntryCodeBlng"].ToString();
            //invoice.AlPhoneExtBlng = row["AlPhoneExtBlng"].ToString();
            //invoice.AlPhoneExtRemit = row["AlPhoneExtRemit"].ToString();
            //invoice.AlPhoneNumBlng = row["AlPhoneNumBlng"].ToString();
            //invoice.AlPhoneNumRemit = row["AlPhoneNumRemit"].ToString();
            invoice.AlPostCodeBlng = row["AlPostCodeBlng"].ToString();
            //invoice.AlRemitQual = row["AlRemitQual"].ToString();
            invoice.AlStateProvBlng = row["AlStateProvBlng"].ToString();
            //invoice.InvAdjmAmt = row["InvAdjmAmt"].ToString() =="" ? 0 : Convert.ToDecimal(row["InvAdjmAmt"]);
            //if (row["InvAdjmCnt"].ToString() == "")
            //    invoice.InvAdjmCnt = Nullable_Of_Int16.Null;
            //else
            //    invoice.InvAdjmCnt = Convert.ToInt16(row["InvAdjmCnt"]);
            //invoice.InvAppAmt = row["InvAppAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["InvAppAmt"]);            
            //invoice.InvCreditAmt = row["InvCreditAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["InvCreditAmt"]);
            //invoice.InvDisputeAmt = row["InvDisputeAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["InvDisputeAmt"]);
            if (row["InvDueDtm"].ToString() == "")
                invoice.InvDueDtm = Nullable_Of_DateTime.Null;
            else
                invoice.InvDueDtm = new DateTime(Convert.ToDateTime(row["InvDueDtm"]).Year, Convert.ToDateTime(row["InvDueDtm"]).Month, Convert.ToDateTime(row["InvDueDtm"]).Day, Convert.ToDateTime(row["InvDueDtm"]).Hour, Convert.ToDateTime(row["InvDueDtm"]).Minute, Convert.ToDateTime(row["InvDueDtm"]).Second, DateTimeKind.Utc);
            //invoice.InvOpenAmt = row["InvOpenAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["InvOpenAmt"]);
            //invoice.InvOrigId = row["InvOrigId"].ToString();
            //if (row["InvPaymtCnt"].ToString() == "")
            //    invoice.InvPaymtCnt = Nullable_Of_Int16.Null;
            //else
            //    invoice.InvPaymtCnt = Convert.ToInt16(row["InvPaymtCnt"]);
            //invoice.InvPdAmt = row["InvPdAmt"].ToString() == "" ? 0 : Convert.ToDecimal(row["InvPdAmt"]);
            //if (row["InvPdDtm"].ToString() == "")
            //    invoice.InvPdDtm = Nullable_Of_DateTime.Null;
            //else
            //    invoice.InvPdDtm = Convert.ToDateTime(row["InvPdDtm"]);
            invoice.InvStat = row["InvStat"].ToString();//INV_STAT AS InvStat,
            //invoice.InvType = row["InvType"].ToString();
            //invoice.InvVoidFlag = row["InvVoidFlag"].ToString() == "" ? false : Convert.ToBoolean(row["InvVoidFlag"]);
            invoice.LocIdBlng = row["LocIdBlng"].ToString();
            //invoice.LocKeyBlng = row["LocKeyBlng"].ToString();
            //invoice.LocKeyRemit = row["LocKeyRemit"].ToString();
            //invoice.MsgGrpNum = row["MsgGrpNum"].ToString();
            return invoice;
        }

        protected FrghtBl SetFrghtBlProperties(FrghtBl freightBill, DataRow row)
        {
            freightBill.AcctNumVendBlng = row["AcctNumVendBlng"].ToString();//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            freightBill.AlCityDest = row["AlCityDest"].ToString();//AL_CITY_DEST AS AlCityDest,
            freightBill.AlCityOrig = row["AlCityOrig"].ToString();//AL_CITY_ORIG AS AlCityOrig,
            freightBill.AlCntryCodeDest = row["AlCntryCodeDest"].ToString();//AL_CNTRY_CODE_DEST AS AlCntryCodeDest,
            freightBill.AlCntryCodeOrig = row["AlCntryCodeOrig"].ToString();//AL_CNTRY_CODE_ORIG AS AlCntryCodeOrig,
            freightBill.AlDest1 = row["AlDest1"].ToString();//AL_DEST_1 AS AlDest1,
            freightBill.AlDest2 = row["AlDest2"].ToString();//AL_DEST_2 AS AlDest2,
            freightBill.AlDest3 = row["AlDest3"].ToString();//AL_DEST_3 AS AlDest3,
            freightBill.AlDest4 = row["AlDest4"].ToString();//AL_DEST_4 AS AlDest4,
            freightBill.AlOrig1 = row["AlOrig1"].ToString();//AL_ORIG_1 AS AlOrig1,
            freightBill.AlOrig2 = row["AlOrig2"].ToString();//AL_ORIG_2 AS AlOrig2,
            freightBill.AlOrig3 = row["AlOrig3"].ToString();//AL_ORIG_3 AS AlOrig3,
            freightBill.AlOrig4 = row["AlOrig4"].ToString();//AL_ORIG_4 AS AlOrig4,
            freightBill.AlPostCodeDest = row["AlPostCodeDest"].ToString();//AL_POST_CODE_DEST AS AlPostCodeDest,
            freightBill.AlPostCodeOrig = row["AlPostCodeOrig"].ToString();//AL_POST_CODE_ORIG AS AlPostCodeOrig,
            freightBill.AlStateProvDest = row["AlStateProvDest"].ToString();//AL_STATE_PROV_DEST AS AlStateProvDest,
            freightBill.AlStateProvOrig = row["AlStateProvOrig"].ToString();//AL_STATE_PROV_ORIG AS AlStateProvOrig,
            freightBill.BatId = freightBill.Invoice.BatId; //row["BatId"].ToString();            
            freightBill.BatKey = freightBill.Invoice.BatKey;//row["BatKey"].ToString();
            freightBill.CaInfo1Raw = row["CaInfo1Raw"].ToString();//CA_INFO_1_RAW AS CaInfo1Raw,
            freightBill.CaInfo2Raw = row["CaInfo2Raw"].ToString();//CA_INFO_2_RAW AS CaInfo2Raw,            
            if (row["FbActualWt"].ToString() == "")//FB_ACTUAL_WT AS FbActualWt,
                freightBill.FbActualWt = Nullable_Of_Single.Null;
            else
                freightBill.FbActualWt = Convert.ToSingle(row["FbActualWt"]);            
            if (row["FbAmt"].ToString() == "")//FB_AMT AS FbAmt,
                freightBill.FbAmt = Nullable_Of_Decimal.Null;
            else
                freightBill.FbAmt = Convert.ToDecimal(row["FbAmt"]);
            if (row["FbAccAmt"].ToString() == "")//FB_ACC_AMT AS FbAccAmt
                freightBill.FbAccAmt = Nullable_Of_Decimal.Null;
            else
                freightBill.FbAccAmt = Convert.ToDecimal(row["FbAccAmt"]);            
            freightBill.FbClass = "Waybill";//row["FbClass"].ToString();            
            if (row["FbCreatDtm"].ToString() == "")//FB_CREAT_DTM AS FbCreatDtm,
                freightBill.FbCreatDtm = Nullable_Of_DateTime.Null;
            else
                freightBill.FbCreatDtm = new DateTime(Convert.ToDateTime(row["FbCreatDtm"]).Year, Convert.ToDateTime(row["FbCreatDtm"]).Month, Convert.ToDateTime(row["FbCreatDtm"]).Day, Convert.ToDateTime(row["FbCreatDtm"]).Hour, Convert.ToDateTime(row["FbCreatDtm"]).Minute, Convert.ToDateTime(row["FbCreatDtm"]).Second, DateTimeKind.Utc);
            freightBill.FbCurrencyQual = row["FbCurrencyQual"].ToString();//FB_CURRENCY_QUAL AS FbCurrencyQual,
            if (row["FbDscntAmt"].ToString() == "")//FB_DSCNT_AMT AS FbDscntAmt
                freightBill.FbDscntAmt = Nullable_Of_Decimal.Null;
            else
                freightBill.FbDscntAmt = Convert.ToDecimal(row["FbDscntAmt"]);
            if (row["FbFnclWt"].ToString() == "")//FB_FNCL_WT AS FbFnclWt,
                freightBill.FbFnclWt = Nullable_Of_Single.Null;
            else
                freightBill.FbFnclWt = Convert.ToSingle(row["FbFnclWt"]);
            if (row["FbFrghtAmt"].ToString() == "")
                freightBill.FbFrghtAmt = Nullable_Of_Decimal.Null;
            else
                freightBill.FbFrghtAmt = Convert.ToDecimal(row["FbAmt"]);//Convert.ToDecimal(row["FbFrghtAmt"]);
            freightBill.FbId = row["FbId"].ToString();//FB_ID AS FbId,
            freightBill.FbKey = row["FbKey"].ToString();//FB_KEY AS FbKey,
            freightBill.FbPaymtTermsCode = row["FbPaymtTermsCode"].ToString();//FB_PAYMT_TERMS_CODE AS FbPaymtTermsCode,
            if (row["FbPcsCnt"].ToString() == "")//FB_PCS_CNT AS FbPcsCnt,
                freightBill.FbPcsCnt = Nullable_Of_Int32.Null;
            else
                freightBill.FbPcsCnt = Convert.ToInt32(row["FbPcsCnt"]);
            freightBill.FbPkgType = row["FbPkgType"].ToString();//FB_PKG_TYPE AS FbPkgType,
            if (row["FbTaxAmt"].ToString() == "")//FB_TAX_AMT AS FbTaxAmt
                freightBill.FbTaxAmt = Nullable_Of_Decimal.Null;
            else
                freightBill.FbTaxAmt = Convert.ToDecimal(row["FbTaxAmt"]);
            freightBill.FbType = "Manual Bill";//row["FbType"].ToString();
            if (row["InterlineAmt"].ToString() == "")//INTERLINE_AMT AS InterlineAmt,
                freightBill.InterlineAmt = Nullable_Of_Decimal.Null;
            else
                freightBill.InterlineAmt = Convert.ToDecimal(row["InterlineAmt"]);
            freightBill.InterlineQual = row["InterlineQual"].ToString();//INTERLINE_QUAL AS InterlineQual,
            freightBill.InterlineScac = row["InterlineScac"].ToString();//INTERLINE_SCAC AS InterlineScac,
            freightBill.InvId = row["InvId"].ToString();//INV_ID AS InvId,
            freightBill.InvKey = row["InvKey"].ToString();//INV_KEY AS InvKey,
            if (row["LmAtaDtm"].ToString() == "")//LM_ATA_DTM AS LmAtaDtm,
                freightBill.LmAtaDtm = Nullable_Of_DateTime.Null;
            else
                freightBill.LmAtaDtm = new DateTime(Convert.ToDateTime(row["LmAtaDtm"]).Year, Convert.ToDateTime(row["LmAtaDtm"]).Month, Convert.ToDateTime(row["LmAtaDtm"]).Day, Convert.ToDateTime(row["LmAtaDtm"]).Hour, Convert.ToDateTime(row["LmAtaDtm"]).Minute, Convert.ToDateTime(row["LmAtaDtm"]).Second, DateTimeKind.Utc);
            if (row["LmDist"].ToString() == "")//LM_DIST AS LmDist,
                freightBill.LmDist = Nullable_Of_Int16.Null;
            else
                freightBill.LmDist = Convert.ToInt16(row["LmDist"]);
            freightBill.LmLaneLabl = row["LmLaneLabl"].ToString();//LM_LANE_LABL AS LmLaneLabl
            if (row["LmPkupActualDtm"].ToString() == "")//LM_PKUP_ACTUAL_DTM AS LmPkupActualDtm,
                freightBill.LmPkupActualDtm = Nullable_Of_DateTime.Null;
            else
                freightBill.LmPkupActualDtm =  new DateTime(Convert.ToDateTime(row["LmPkupActualDtm"]).Year, Convert.ToDateTime(row["LmPkupActualDtm"]).Month, Convert.ToDateTime(row["LmPkupActualDtm"]).Day, Convert.ToDateTime(row["LmPkupActualDtm"]).Hour, Convert.ToDateTime(row["LmPkupActualDtm"]).Minute, Convert.ToDateTime(row["LmPkupActualDtm"]).Second, DateTimeKind.Utc);
            freightBill.OwnerKey = freightBill.Invoice.OwnerKey;// row["OwnerKey"].ToString();
            freightBill.PriceLaneLabl = row["PriceLaneLabl"].ToString();//PRICE_LANE_LABL AS PriceLaneLabl,
            freightBill.SrvcReqCode = row["SrvcReqCode"].ToString();//SRVC_REQ_CODE AS SrvcReqCode,
            freightBill.VendFbType = "Manual Bill";//row["VendFbType"].ToString();
            freightBill.VendLabl = row["VendLabl"].ToString();//VEND_LABL AS VendLabl,
            freightBill.T001 = row["T001"].ToString();
            freightBill.T002 = row["T002"].ToString();
            freightBill.T003 = row["T003"].ToString();
            freightBill.T004 = row["T004"].ToString();
            //freightBill.T005 = row["T005"].ToString();
            //freightBill.T006 = row["T006"].ToString();
            //freightBill.T007 = row["T007"].ToString();
            //freightBill.T008 = row["T008"].ToString();
            //freightBill.T009 = row["T009"].ToString();
            //freightBill.T010 = row["T010"].ToString();
            //freightBill.T011 = row["T011"].ToString();
            //freightBill.T012 = row["T012"].ToString();
            //freightBill.T013 = row["T013"].ToString();
            //freightBill.T014 = row["T014"].ToString();
            //freightBill.T015 = row["T015"].ToString();
            //freightBill.T016 = row["T016"].ToString();
            //freightBill.T017 = row["T017"].ToString();
            //freightBill.T018 = row["T018"].ToString();
            //freightBill.T019 = row["T019"].ToString();
            //freightBill.T020 = row["T020"].ToString();
            //freightBill.AcctNumVendDest = row["AcctNumVendDest"].ToString();
            //freightBill.AcctNumVendOrig = row["AcctNumVendOrig"].ToString();
            //freightBill.AlDestQual = row["AlDestQual"].ToString();
            //freightBill.AlOrigQual = row["AlOrigQual"].ToString();
            //freightBill.AlPhoneExtDest = row["AlPhoneExtDest"].ToString();
            //freightBill.AlPhoneExtOrig = row["AlPhoneExtOrig"].ToString();
            //freightBill.AlPhoneNumDest = row["AlPhoneNumDest"].ToString();
            //freightBill.AlPhoneNumOrig = row["AlPhoneNumOrig"].ToString();
            //freightBill.Bol1Raw = row["Bol1Raw"].ToString();
            //freightBill.BolNumKey = row["BolNumKey"].ToString();
            //freightBill.BundleNum = row["BundleNum"].ToString();
            //freightBill.EntTypeBlng = row["EntTypeBlng"].ToString();
            //freightBill.EntTypeCons = row["EntTypeCons"].ToString();
            //freightBill.EntTypeShpr = row["EntTypeShpr"].ToString();
            
            //freightBill.FbAdjmAmt = Convert.ToDecimal(row["FbAdjmAmt"]);
            //freightBill.FbAdjmCnt = Convert.ToInt16(row["FbAdjmCnt"]);
            //freightBill.FbAdjmDesc = row["FbAdjmDesc"].ToString();
            //freightBill.FbAdjmReason = row["FbAdjmReason"].ToString();
            //freightBill.FbAppAccAmt = Convert.ToDecimal(row["FbAppAccAmt"]);
            //freightBill.FbAppAmt = Convert.ToDecimal(row["FbAppAmt"]);
            //freightBill.FbAppCurrencyQual = row["FbAppCurrencyQual"].ToString();
            //freightBill.FbAppDscntAmt = Convert.ToDecimal(row["FbAppDscntAmt"]);
            //freightBill.FbAppFrghtAmt = Convert.ToDecimal(row["FbAppFrghtAmt"]);
            //freightBill.FbAppRptFactor = Convert.ToSingle(row["FbAppRptFactor"]);
            //freightBill.FbAppTaxAmt = Convert.ToDecimal(row["FbAppTaxAmt"]);
            //freightBill.FbAppTaxPcnt = Convert.ToSingle(row["FbAppTaxPcnt"]);
            //freightBill.FbBrkPtWt = Convert.ToSingle(row["FbBrkPtWt"]);
            //freightBill.FbCreditAmt = Convert.ToDecimal(row["FbCreditAmt"]);
            //freightBill.FbDeclAmt = Convert.ToDecimal(row["FbDeclAmt"]);
            //freightBill.FbDimWt = Convert.ToSingle(row["FbDimWt"]);
            //freightBill.FbDisputeAmt = Convert.ToDecimal(row["FbDisputeAmt"]);

            //freightBill.FbDuFlag = Convert.ToBoolean(row["FbDuFlag"]);
            //freightBill.FbDueDtm = Convert.ToDateTime(row["FbDueDtm"]);
            //freightBill.FbLnCnt = Convert.ToInt16(row["FbLnCnt"]);//ilisanan pa ug value;//FB_LN_CNT AS FbLnCnt,
            //freightBill.FbOpenAmt = Convert.ToDecimal(row["FbOpenAmt"]);
            //freightBill.FbParentId = row["FbParentId"].ToString();
            //freightBill.FbPaymtCnt = Convert.ToInt16(row["FbPaymtCnt"]);
            //freightBill.FbPdAmt = Convert.ToDecimal(row["FbPdAmt"]);
            //freightBill.FbPendingReason = row["FbPendingReason"].ToString();
            //freightBill.FbPendingReasonDesc = row["FbPendingReasonDesc"].ToString();
            //freightBill.FbRptFactor = Convert.ToSingle(row["FbRptFactor"]);
            //freightBill.FbStat = row["FbStat"].ToString();
            
            //freightBill.FbTerms = row["FbTerms"].ToString();
            //freightBill.FbVoidFlag = Convert.ToBoolean(row["FbVoidFlag"]);
            //freightBill.FbWtQual = row["FbWtQual"].ToString();
            //freightBill.ForceFaExFlag = Convert.ToBoolean(row["ForceFaExFlag"]);
            //freightBill.LmAtaEtaVarncLabl = row["LmAtaEtaVarncLabl"].ToString();
            //freightBill.LmAtaEtaVarncReason = row["LmAtaEtaVarncReason"].ToString();
            //freightBill.LmDistQual = row["LmDistQual"].ToString();
            //freightBill.LmDlvryReqDtm = Convert.ToDateTime(row["LmDlvryReqDtm"]);
            //freightBill.LmEtaDtm = Convert.ToDateTime(row["LmEtaDtm"]);
            //freightBill.LmFirstDlvryDtm = Convert.ToDateTime(row["LmFirstDlvryDtm"]);
            //freightBill.LmPkupByDtm = Convert.ToDateTime(row["LmPkupByDtm"]);
            //freightBill.LmPkupVarncLabl = row["LmPkupVarncLabl"].ToString();
            //freightBill.LmPkupVarncReason = row["LmPkupVarncReason"].ToString();
            //freightBill.LmRdyDtm = Convert.ToDateTime(row["LmRdyDtm"]);
            //freightBill.LmReqKey = row["LmReqKey"].ToString();
            //freightBill.LmTransitStat = row["LmTransitStat"].ToString();
            freightBill.LocIdBlng = row["LocIdBlng"].ToString();
            //freightBill.LocIdCons = row["LocIdCons"].ToString();
            //freightBill.LocIdDest = row["LocIdDest"].ToString();
            //freightBill.LocIdOrig = row["LocIdOrig"].ToString();
            //freightBill.LocIdShpr = row["LocIdShpr"].ToString();
            //freightBill.LocKeyBlng = row["LocKeyBlng"].ToString();
            //freightBill.LocKeyCons = row["LocKeyCons"].ToString();
            //freightBill.LocKeyDest = row["LocKeyDest"].ToString();
            //freightBill.LocKeyOrig = row["LocKeyOrig"].ToString();
            //freightBill.LocKeyShpr = row["LocKeyShpr"].ToString();
            //freightBill.PodSignBy = row["PodSignBy"].ToString();
            //freightBill.RuleBlWinner = row["RuleBlWinner"].ToString();
            //freightBill.RuleBolWinner = row["RuleBolWinner"].ToString();
            //freightBill.RuleCaWinner = row["RuleCaWinner"].ToString();
            //freightBill.RuleDestWinner = row["RuleDestWinner"].ToString();
            //freightBill.RuleDuWinner = row["RuleDuWinner"].ToString();
            //freightBill.RuleFaWinner = row["RuleFaWinner"].ToString();
            //freightBill.RuleLmWinner = row["RuleLmWinner"].ToString();
            //freightBill.RuleMpWinner = row["RuleMpWinner"].ToString();
            //freightBill.RuleOrigWinner = row["RuleOrigWinner"].ToString();
            //freightBill.RuleRtWinner = row["RuleRtWinner"].ToString();
            //freightBill.TxFbAccAmt = Convert.ToDecimal(row["TxFbAccAmt"]);
            //freightBill.TxFbAmt = Convert.ToDecimal(row["TxFbAmt"]);
            //freightBill.TxFbBaseRate = Convert.ToDecimal(row["TxFbBaseRate"]);
            //freightBill.TxFbBrkPtWt = Convert.ToSingle(row["TxFbBrkPtWt"]);
            //freightBill.TxFbCurrencyQual = row["TxFbCurrencyQual"].ToString();
            //freightBill.TxFbDimWt = Convert.ToSingle(row["TxFbDimWt"]);
            //freightBill.TxFbDscntAmt = Convert.ToDecimal(row["TxFbDscntAmt"]);
            //freightBill.TxFbFnclWt = Convert.ToSingle(row["TxFbFnclWt"]);
            //freightBill.TxFbFrghtAmt = Convert.ToDecimal(row["TxFbFrghtAmt"]);
            //freightBill.TxFbRptFactor = Convert.ToSingle(row["TxFbRptFactor"]);
            //freightBill.TxFbTaxAmt = Convert.ToDecimal(row["TxFbTaxAmt"]);
            //freightBill.TxFbTaxPcnt = Convert.ToSingle(row["TxFbTaxPcnt"]);
            //freightBill.TxFbWtQual = row["TxFbWtQual"].ToString();
            //freightBill.TxLmDir = row["TxLmDir"].ToString();
            //freightBill.TxLmDist = Convert.ToInt16(row["TxLmDist"]);
            //freightBill.TxLmDistQual = row["TxLmDistQual"].ToString();
            //freightBill.TxLmType = row["TxLmType"].ToString();
            //freightBill.TxShpmtId = row["TxShpmtId"].ToString();
            //freightBill.VendCommitCode = row["VendCommitCode"].ToString();
            //freightBill.VendRateScale = row["VendRateScale"].ToString();
            //freightBill.VendSrvcGuarCode = row["VendSrvcGuarCode"].ToString();
            //freightBill.VendSrvcName = row["VendSrvcName"].ToString();
            //freightBill.VendTariff = row["VendTariff"].ToString();
            return freightBill;
        }

        protected FXI SetFXIProperties(FXI fxi, DataRow row)
        {            
            fxi.FbId = row["FbId"].ToString();
            fxi.InvPageNum = Convert.ToInt16(row["InvPageNum"].ToString() == string.Empty ? "1" : row["InvPageNum"].ToString());
            fxi.VendLabl = row["VendLabl"].ToString();
            fxi.InvId = row["InvId"].ToString();
            fxi.BatId = row["BatId"].ToString();
            fxi.T001 = row["T001"].ToString();
            fxi.T002 = row["T002"].ToString();
            fxi.T003 = row["T003"].ToString();
            fxi.T004 = row["T004"].ToString();
            fxi.T005 = row["T005"].ToString();
            fxi.T006 = row["T006"].ToString();
            fxi.T007 = row["T007"].ToString();
            fxi.T008 = row["T008"].ToString();
            fxi.T009 = row["T009"].ToString();
            fxi.T010 = row["T010"].ToString();
            fxi.T011 = row["T011"].ToString();
            fxi.T012 = row["T012"].ToString();
            fxi.T013 = row["T013"].ToString();
            fxi.T014 = row["T014"].ToString();
            fxi.T015 = row["T015"].ToString();
            fxi.T016 = row["T016"].ToString();
            fxi.T017 = row["T017"].ToString();
            fxi.T018 = row["T018"].ToString();
            fxi.T019 = row["T019"].ToString();
            fxi.T020 = row["T020"].ToString();
            fxi.T021 = row["T021"].ToString();
            fxi.T022 = row["T022"].ToString();
            fxi.T023 = row["T023"].ToString();
            fxi.T024 = row["T024"].ToString();
            fxi.T025 = row["T025"].ToString();
            fxi.T026 = row["T026"].ToString();
            fxi.T027 = row["T027"].ToString();
            fxi.T028 = row["T028"].ToString();
            fxi.T029 = row["T029"].ToString();
            fxi.T030 = row["T030"].ToString();
            fxi.T031 = row["T031"].ToString();
            fxi.T032 = row["T032"].ToString();
            fxi.T033 = row["T033"].ToString();
            fxi.T034 = row["T034"].ToString();
            fxi.T035 = row["T035"].ToString();
            fxi.T036 = row["T036"].ToString();
            fxi.T037 = row["T037"].ToString();
            fxi.T038 = row["T038"].ToString();
            fxi.T039 = row["T039"].ToString();
            fxi.T040 = row["T040"].ToString();
            fxi.T041 = row["T041"].ToString();
            fxi.T042 = row["T042"].ToString();
            fxi.T043 = row["T043"].ToString();
            fxi.T044 = row["T044"].ToString();
            fxi.T045 = row["T045"].ToString();
            fxi.T046 = row["T046"].ToString();
            fxi.T047 = row["T047"].ToString();
            fxi.T048 = row["T048"].ToString();
            fxi.T049 = row["T049"].ToString();
            fxi.T050 = row["T050"].ToString();
            fxi.T051 = row["T051"].ToString();
            fxi.T052 = row["T052"].ToString();
            fxi.T053 = row["T053"].ToString();
            fxi.T054 = row["T054"].ToString();
            fxi.T055 = row["T055"].ToString();
            fxi.T056 = row["T056"].ToString();
            fxi.T057 = row["T057"].ToString();
            fxi.T058 = row["T058"].ToString();
            fxi.T059 = row["T059"].ToString();
            fxi.T060 = row["T060"].ToString();
            fxi.T061 = row["T061"].ToString();
            fxi.T062 = row["T062"].ToString();
            fxi.T063 = row["T063"].ToString();
            fxi.T064 = row["T064"].ToString();
            fxi.T065 = row["T065"].ToString();
            fxi.T066 = row["T066"].ToString();
            fxi.T067 = row["T067"].ToString();
            fxi.T068 = row["T068"].ToString();
            fxi.T069 = row["T069"].ToString();
            fxi.T070 = row["T070"].ToString();
            fxi.T071 = row["T071"].ToString();
            fxi.T072 = row["T072"].ToString();
            fxi.T073 = row["T073"].ToString();
            fxi.T074 = row["T074"].ToString();
            fxi.T075 = row["T075"].ToString();
            fxi.T076 = row["T076"].ToString();
            fxi.T077 = row["T077"].ToString();
            fxi.T078 = row["T078"].ToString();
            fxi.T079 = row["T079"].ToString();
            fxi.T080 = row["T080"].ToString();
            fxi.T081 = row["T081"].ToString();
            fxi.T082 = row["T082"].ToString();
            fxi.T083 = row["T083"].ToString();
            fxi.T084 = row["T084"].ToString();
            fxi.T085 = row["T085"].ToString();
            fxi.T086 = row["T086"].ToString();
            fxi.T087 = row["T087"].ToString();
            fxi.T088 = row["T088"].ToString();
            fxi.T089 = row["T089"].ToString();
            fxi.T090 = row["T090"].ToString();
            fxi.T091 = row["T091"].ToString();
            fxi.T092 = row["T092"].ToString();
            fxi.T093 = row["T093"].ToString();
            fxi.T094 = row["T094"].ToString();
            fxi.T095 = row["T095"].ToString();
            fxi.T096 = row["T096"].ToString();
            fxi.T097 = row["T097"].ToString();
            fxi.T098 = row["T098"].ToString();
            fxi.T099 = row["T099"].ToString();
            fxi.T100 = row["T100"].ToString();
            fxi.T101 = row["T101"].ToString();
            fxi.T102 = row["T102"].ToString();
            fxi.T103 = row["T103"].ToString();
            fxi.T104 = row["T104"].ToString();
            fxi.T105 = row["T105"].ToString();
            fxi.T106 = row["T106"].ToString();
            fxi.T107 = row["T107"].ToString();
            fxi.T108 = row["T108"].ToString();
            fxi.T109 = row["T109"].ToString();
            fxi.T110 = row["T110"].ToString();
            fxi.T111 = row["T111"].ToString();
            fxi.T112 = row["T112"].ToString();
            fxi.T113 = row["T113"].ToString();
            fxi.T114 = row["T114"].ToString();
            fxi.T115 = row["T115"].ToString();
            fxi.T116 = row["T116"].ToString();
            fxi.T117 = row["T117"].ToString();
            fxi.T118 = row["T118"].ToString();
            fxi.T119 = row["T119"].ToString();
            fxi.T120 = row["T120"].ToString();
            

            return fxi;
        }

        protected FbLn SetFbLnProperties(FbLn fbLine, DataRow row)
        {            
            fbLine.BatKey = fbLine.FrghtBl.BatKey;//row["BatKey"].ToString();
            fbLine.Cat = row["Cat"].ToString();//CAT AS Cat,
            if (row["ChrgAmt"].ToString() == "")//CHRG_AMT AS ChrgAmt,
                fbLine.ChrgAmt = Nullable_Of_Decimal.Null;
            else
                fbLine.ChrgAmt = Convert.ToDecimal(row["ChrgAmt"]);
            fbLine.ChrgDesc = row["ChrgDesc"].ToString();//CHRG_DESC AS ChrgDesc,
            fbLine.CmdtyClass = row["CmdtyClass"].ToString();//CMDTY_CLASS AS CmdtyClass,
            fbLine.CurrencyQual = row["CurrencyQual"].ToString();//CURRENCY_QUAL AS CurrencyQual
            fbLine.FbId = row["FbId"].ToString();//FB_ID AS FbId,
            fbLine.FbLineItemFlag = true;//Convert.ToBoolean(row["FbLineItemFlag"]);
            if (row["LineItemNum"].ToString() == "")//LINE_ITEM_NUM AS LineItemNum,
                fbLine.LineItemNum = Nullable_Of_Int16.Null;
            else
                fbLine.LineItemNum = Convert.ToInt16(row["LineItemNum"]);
            if (row["LnActualWt"].ToString() == "")//LN_ACTUAL_WT AS	LnActualWt,
                fbLine.LnActualWt = Nullable_Of_Single.Null;
            else
                fbLine.LnActualWt = Convert.ToSingle(row["LnActualWt"]);
            fbLine.LnChrgCode = row["LnChrgCode"].ToString();//LN_CHRG_CODE AS LnChrgCode,
            if (row["LnRateAsWt"].ToString() == "")//LN_RATE_AS_WT AS LnRateAsWt,
                fbLine.LnRateAsWt = Nullable_Of_Single.Null;
            else
                fbLine.LnRateAsWt = Convert.ToSingle(row["LnRateAsWt"]);
            if (row["PcsCnt"].ToString() == "")//PCS_CNT	AS PcsCnt,
                fbLine.PcsCnt = Nullable_Of_Int32.Null;
            else
                fbLine.PcsCnt = Convert.ToInt32(row["PcsCnt"]);
            fbLine.PkgType = row["PkgType"].ToString();//PKG_TYPE AS PkgType,
            fbLine.QtyLabl = row["QtyLabl"].ToString();//QTY_LABL AS QtyLabl,
            if (row["RateAmt"].ToString() == "")//RATE_AMT AS RateAmt,
                fbLine.RateAmt = Nullable_Of_Decimal.Null;
            else
                fbLine.RateAmt = Convert.ToDecimal(row["RateAmt"]);
            fbLine.RateType = row["RateType"].ToString();//RATE_TYPE AS RateType,
            fbLine.RateUntLabl = row["RateUntLabl"].ToString();//RATE_UNT_LABL AS RateUntLabl,
            //fbLine.VendDesc = row["Facsimile01"].ToString();
            fbLine.Facsimile01 = row["Facsimile01"].ToString();//[%FACSIMILE_01] AS Facsimile01,
            fbLine.Facsimile02 = row["Facsimile02"].ToString();
            fbLine.T001 = row["T001"].ToString();
            fbLine.T002 = row["T002"].ToString();
            fbLine.T003 = row["T003"].ToString();
            fbLine.T004 = row["T004"].ToString();
            fbLine.T005 = row["T005"].ToString();
            fbLine.T006 = row["T006"].ToString();
            //fbLine.CatSeqNum = Convert.ToInt16(row["CatSeqNum"]);
            //fbLine.DimData = row["DimData"].ToString();
            //fbLine.LnBasis = Convert.ToSingle(row["LnBasis"]);
            //fbLine.LnBasisQual = row["LnBasisQual"].ToString();
            //fbLine.LnDeclAmt = Convert.ToDecimal(row["LnDeclAmt"]);
            //fbLine.LnRateAsQual = row["LnRateAsQual"].ToString();
            //fbLine.LnVendRateScale = row["LnVendRateScale"].ToString();
            //fbLine.MsgGrpNum = row["MsgGrpNum"].ToString();
            //fbLine.RateCpntId = row["RateCpntId"].ToString();
            //fbLine.RatePerUntCnt = Convert.ToInt32(row["RatePerUntCnt"]);
            //fbLine.TxActualWt = Convert.ToSingle(row["TxActualWt"]);
            //fbLine.TxDimVol = Convert.ToDouble(row["TxDimVol"]);
            //fbLine.TxDimWt = Convert.ToSingle(row["TxDimWt"]);
            //fbLine.TxFnclWt = Convert.ToSingle(row["TxFnclWt"]);
            //fbLine.TxLineItemFlag = Convert.ToBoolean(row["TxLineItemFlag"]);
            //fbLine.TxRateAmt = Convert.ToDecimal(row["TxRateAmt"]);
            

            return fbLine;
        }

        protected DataRow SetInvBatRow(InvBat invoiceBat, DataRow row)
        {         
            //row["BatAdjmAmt"] = invoiceBat.BatAdjmAmt;
            //row["BatAdjmCnt"] = invoiceBat.BatAdjmCnt;
            if (!invoiceBat.BatAmt.IsNull)
                row["BatAmt"] = invoiceBat.BatAmt;//BAT_AMT AS BatAmt,
            //row["BatAppAmt"] = invoiceBat.BatAppAmt;
            if(!invoiceBat.BatCreatDtm.IsNull)
                row["BatCreatDtm"] = invoiceBat.BatCreatDtm.Value.ToUniversalTime(); ;//BAT_CREAT_DTM AS BatCreatDtm,
            //row["BatCreditAmt"] = invoiceBat.BatCreditAmt;
            row["BatCurrencyQual"] = invoiceBat.BatCurrencyQual;//BAT_CURRENCY_QUAL AS BatCurrencyQual,
            //row["BatDisputeAmt"] = invoiceBat.BatDisputeAmt;
            //row["BatDueDtm"] = invoiceBat.BatDueDtm;
            if(!invoiceBat.BatFbCnt.IsNull)
                row["BatFbCnt"] = invoiceBat.BatFbCnt;//BAT_FB_CNT AS BatFbCnt,
            row["BatId"] = invoiceBat.BatId;//BAT_ID AS BatId,
            if(!invoiceBat.BatInvCnt.IsNull)
                row["BatInvCnt"] = invoiceBat.BatInvCnt;//BAT_INV_CNT AS BatInvCnt,
            row["BatKey"] = invoiceBat.BatKey;//BAT_KEY AS BatKey,
            row["BatLocIdRemit"] = invoiceBat.BatLocIdRemit;//BAT_LOC_ID_REMIT AS BatLocIdRemit,
            //row["BatMsgCtrlDtm"] = invoiceBat.BatMsgCtrlDtm;
            //row["BatMsgCtrlPodDtm"] = invoiceBat.BatMsgCtrlPodDtm;
            //row["BatMsgCtrlRouteLabl"] = invoiceBat.BatMsgCtrlRouteLabl;
            //row["BatMsgCtrlSnapCnt"] = invoiceBat.BatMsgCtrlSnapCnt;
            //row["BatMsgCtrlStat"] = invoiceBat.BatMsgCtrlStat;
            //row["BatMsgCtrlType"] = invoiceBat.BatMsgCtrlType;
            //row["BatOpenAmt"] = invoiceBat.BatOpenAmt;
            //row["BatPaymtCnt"] = invoiceBat.BatPaymtCnt;
            //row["BatPdAmt"] = invoiceBat.BatPdAmt;
            //row["BatSnapCnt"] = invoiceBat.BatSnapCnt;
            row["BatStat"] = invoiceBat.BatStat;//BAT_STAT AS BatStat,
            row["BatType"] = invoiceBat.BatType;//BAT_TYPE AS BatType
            //row["BatVoidFlag"] = invoiceBat.BatVoidFlag;
            //row["ImgDpFileDtm"] = invoiceBat.ImgDpFileDtm;
            //row["ImgDpFileGrp"] = invoiceBat.ImgDpFileGrp;
            //row["ImgDpFileName"] = invoiceBat.ImgDpFileName;
            //row["MsgGrpNum"] = invoiceBat.MsgGrpNum;
            //row["MsgGrpNumHist"] = invoiceBat.MsgGrpNumHist;
            //row["MsgGrpOrigHist"] = invoiceBat.MsgGrpOrigHist;
            row["OwnerKey"] = invoiceBat.OwnerKey;//OWNER_KEY AS OwnerKey,
            //row["VendBatAmt"] = invoiceBat.VendBatAmt;
            if(!invoiceBat.VendBatDtm.IsNull)
                row["VendBatDtm"] = invoiceBat.VendBatDtm.Value.ToUniversalTime(); ;//VEND_BAT_DTM AS VendBatDtm,
            row["VendBatKey"] = invoiceBat.VendBatKey;//VEND_BAT_KEY AS VendBatKey,
            row["VendFeed"] = invoiceBat.VendFeed;//VEND_FEED AS VendFeed,
            row["VendLabl"] = invoiceBat.VendLabl;//VEND_LABL AS VendLabl,
            return row;
        }

        protected DataRow SetInvoiceRow(Invoice invoice, DataRow row)
        {
            //row["AcctIdVendBlng"] = invoice.AcctIdVendBlng;
            row["AcctNumVendBlng"] = invoice.AcctNumVendBlng;//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            row["AlBlng1"] = invoice.AlBlng1;
            row["AlBlng2"] = invoice.AlBlng2;
            row["AlBlng3"] = invoice.AlBlng3;
            row["AlBlng4"] = invoice.AlBlng4;
            //row["AlBlngQual"] = invoice.AlBlngQual;
            row["AlCityBlng"] = invoice.AlCityBlng;
            row["AlCityRemit"] = invoice.AlCityRemit;//AL_CITY_REMIT AS AlCityRemit,
            row["AlCntryCodeBlng"] = invoice.AlCntryCodeBlng;
            row["AlCntryCodeRemit"] = invoice.AlCntryCodeRemit;//AL_CNTRY_CODE_REMIT AS AlCntryCodeRemit,
            //row["AlPhoneExtBlng"] = invoice.AlPhoneExtBlng;
            //row["AlPhoneExtRemit"] = invoice.AlPhoneExtRemit;
            //row["AlPhoneNumBlng"] = invoice.AlPhoneNumBlng;
            //row["AlPhoneNumRemit"] = invoice.AlPhoneNumRemit;
            row["AlPostCodeBlng"] = invoice.AlPostCodeBlng;
            row["AlPostCodeRemit"] = invoice.AlPostCodeRemit;//AL_POST_CODE_REMIT AS AlPostCodeRemit,
            row["AlRemit1"] = invoice.AlRemit1;//AL_REMIT_1 AS AlRemit1,
            row["AlRemit2"] = invoice.AlRemit2;//AL_REMIT_2 AS AlRemit2,
            row["AlRemit3"] = invoice.AlRemit3;//AL_REMIT_3 AS AlRemit3,
            row["AlRemit4"] = invoice.AlRemit4;//AL_REMIT_4 AS AlRemit4,
            //row["AlRemitQual"] = invoice.AlRemitQual;
            row["AlStateProvBlng"] = invoice.AlStateProvBlng;
            row["AlStateProvRemit"] = invoice.AlStateProvRemit;//AL_STATE_PROV_REMIT AS AlStateProvRemit,
            //row["BatId"] = invoice.BatId;
            //row["BatKey"] = invoice.BatKey;
            //row["InvAdjmAmt"] = invoice.InvAdjmAmt;
            //row["InvAdjmCnt"] = invoice.InvAdjmCnt;
            if(!invoice.InvAmt.IsNull)
                row["InvAmt"] = invoice.InvAmt;//INV_AMT AS InvAmt
            //row["InvAppAmt"] = invoice.InvAppAmt;
            if (!invoice.InvCreatDtm.IsNull)
                row["InvCreatDtm"] = invoice.InvCreatDtm.Value.ToUniversalTime();
            //row["InvCreditAmt"] = invoice.InvCreditAmt;
            row["InvCurrencyQual"] = invoice.InvCurrencyQual;//INV_CURRENCY_QUAL AS InvCurrencyQual,
            //row["InvDisputeAmt"] = invoice.InvDisputeAmt;
            if (!invoice.InvDueDtm.IsNull)
                row["InvDueDtm"] = invoice.InvDueDtm.Value.ToUniversalTime();
            if(!invoice.InvFbCnt.IsNull)
                row["InvFbCnt"] = invoice.InvFbCnt;//INV_FB_CNT AS InvFbCnt,
            row["InvId"] = invoice.InvId;//INV_ID AS InvId,
            row["InvKey"] = invoice.InvKey;//INV_KEY AS InvKey,
            //row["InvOpenAmt"] = invoice.InvOpenAmt;
            //row["InvOrigId"] = invoice.InvOrigId;
            //row["InvPaymtCnt"] = invoice.InvPaymtCnt;
            //row["InvPdAmt"] = invoice.InvPdAmt;
            //row["InvPdDtm"] = invoice.InvPdDtm;
            row["InvStat"] = invoice.InvStat;//INV_STAT AS InvStat,
            //row["InvType"] = invoice.InvType;
            //row["InvVoidFlag"] = invoice.InvVoidFlag;
            row["LocIdBlng"] = invoice.LocIdBlng;
            row["LocIdRemit"] = invoice.LocIdRemit;//LOC_ID_REMIT AS LocIdRemit,
            //row["LocKeyBlng"] = invoice.LocKeyBlng;
            //row["LocKeyRemit"] = invoice.LocKeyRemit;
            //row["MsgGrpNum"] = invoice.MsgGrpNum;
            //row["OwnerKey"] = invoice.OwnerKey;
            //row["VendBatKey"] = invoice.VendBatKey;
            if(!invoice.VendInvAmt.IsNull)
                row["VendInvAmt"] = invoice.VendInvAmt;//VEND_INV_AMT AS VendInvAmt,
            row["VendLabl"] = invoice.VendLabl;//VEND_LABL AS VendLabl,
            return row;
        }
        
        protected DataRow SetFrghtBlRow(FrghtBl freightBill, DataRow row)
        {
            row["T001"] = freightBill.T001;
            row["T002"] = freightBill.T002;
            row["T003"] = freightBill.T003;
            row["T004"] = freightBill.T004;
            //row["T005"] = freightBill.T005;
            //row["T006"] = freightBill.T006;
            //row["T007"] = freightBill.T007;
            //row["T008"] = freightBill.T008;
            //row["T009"] = freightBill.T009;
            //row["T010"] = freightBill.T010;
            //row["T011"] = freightBill.T011;
            //row["T012"] = freightBill.T012;
            //row["T013"] = freightBill.T013;
            //row["T014"] = freightBill.T014;
            //row["T015"] = freightBill.T015;
            //row["T016"] = freightBill.T016;
            //row["T017"] = freightBill.T017;
            //row["T018"] = freightBill.T018;
            //row["T019"] = freightBill.T019;
            //row["T020"] = freightBill.T020;
            row["AcctNumVendBlng"] = freightBill.AcctNumVendBlng;//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            //row["AcctNumVendDest"] = freightBill.AcctNumVendDest;
            //row["AcctNumVendOrig"] = freightBill.AcctNumVendOrig;
            row["AlCityDest"] = freightBill.AlCityDest;//AL_CITY_DEST AS AlCityDest,
            row["AlCityOrig"] = freightBill.AlCityOrig;//AL_CITY_ORIG AS AlCityOrig,
            row["AlCntryCodeDest"] = freightBill.AlCntryCodeDest;//AL_CNTRY_CODE_DEST AS AlCntryCodeDest,
            row["AlCntryCodeOrig"] = freightBill.AlCntryCodeOrig;//AL_CNTRY_CODE_ORIG AS AlCntryCodeOrig,
            row["AlDest1"] = freightBill.AlDest1;//AL_DEST_1 AS AlDest1,
            row["AlDest2"] = freightBill.AlDest2;//AL_DEST_2 AS AlDest2,
            row["AlDest3"] = freightBill.AlDest3;//AL_DEST_3 AS AlDest3,
            row["AlDest4"] = freightBill.AlDest4;//AL_DEST_4 AS AlDest4,
            //row["AlDestQual"] = freightBill.AlDestQual;
            row["AlOrig1"] = freightBill.AlOrig1;//AL_ORIG_1 AS AlOrig1,
            row["AlOrig2"] = freightBill.AlOrig2;//AL_ORIG_2 AS AlOrig2,
            row["AlOrig3"] = freightBill.AlOrig3;//AL_ORIG_3 AS AlOrig3,
            row["AlOrig4"] = freightBill.AlOrig4;//AL_ORIG_4 AS AlOrig4,
            //row["AlOrigQual"] = freightBill.AlOrigQual;
            //row["AlPhoneExtDest"] = freightBill.AlPhoneExtDest;
            //row["AlPhoneExtOrig"] = freightBill.AlPhoneExtOrig;
            //row["AlPhoneNumDest"] = freightBill.AlPhoneNumDest;
            //row["AlPhoneNumOrig"] = freightBill.AlPhoneNumOrig;
            row["AlPostCodeDest"] = freightBill.AlPostCodeDest;//AL_POST_CODE_DEST AS AlPostCodeDest,
            row["AlPostCodeOrig"] = freightBill.AlPostCodeOrig;//AL_POST_CODE_ORIG AS AlPostCodeOrig,
            row["AlStateProvDest"] = freightBill.AlStateProvDest;//AL_STATE_PROV_DEST AS AlStateProvDest,
            row["AlStateProvOrig"] = freightBill.AlStateProvOrig;//AL_STATE_PROV_ORIG AS AlStateProvOrig,
            //row["BatId"] = freightBill.BatId;
            //row["BatKey"] = freightBill.BatKey;
            //row["Bol1Raw"] = freightBill.Bol1Raw;
            //row["BolNumKey"] = freightBill.BolNumKey;
            //row["BundleNum"] = freightBill.BundleNum;
            row["CaInfo1Raw"] = freightBill.CaInfo1Raw;//CA_INFO_1_RAW AS CaInfo1Raw,
            row["CaInfo2Raw"] = freightBill.CaInfo2Raw;//CA_INFO_2_RAW AS CaInfo2Raw,
            //row["EntTypeBlng"] = freightBill.EntTypeBlng;
            //row["EntTypeCons"] = freightBill.EntTypeCons;
            //row["EntTypeShpr"] = freightBill.EntTypeShpr;
            if (!freightBill.FbAccAmt.IsNull)
                row["FbAccAmt"] = freightBill.FbAccAmt;//FB_ACC_AMT AS FbAccAmt,
            if(!freightBill.FbActualWt.IsNull)
                row["FbActualWt"] = freightBill.FbActualWt;//FB_ACTUAL_WT AS FbActualWt,
            //row["FbAdjmAmt"] = freightBill.FbAdjmAmt;
            //row["FbAdjmCnt"] = freightBill.FbAdjmCnt;
            //row["FbAdjmDesc"] = freightBill.FbAdjmDesc;
            //row["FbAdjmReason"] = freightBill.FbAdjmReason;
            if(!freightBill.FbAmt.IsNull)
                row["FbAmt"] = freightBill.FbAmt;//FB_AMT AS FbAmt,
            //row["FbAppAccAmt"] = freightBill.FbAppAccAmt;
            //row["FbAppAmt"] = freightBill.FbAppAmt;
            //row["FbAppCurrencyQual"] = freightBill.FbAppCurrencyQual;
            //row["FbAppDscntAmt"] = freightBill.FbAppDscntAmt;
            //row["FbAppFrghtAmt"] = freightBill.FbAppFrghtAmt;
            //row["FbAppRptFactor"] = freightBill.FbAppRptFactor;
            //row["FbAppTaxAmt"] = freightBill.FbAppTaxAmt;
            //row["FbAppTaxPcnt"] = freightBill.FbAppTaxPcnt;
            //row["FbBrkPtWt"] = freightBill.FbBrkPtWt;
            //row["FbClass"] = freightBill.FbClass;
            if(!freightBill.FbCreatDtm.IsNull)
                row["FbCreatDtm"] = Convert.ToDateTime(freightBill.FbCreatDtm).ToUniversalTime(); ;//FB_CREAT_DTM AS FbCreatDtm,
            //row["FbCreditAmt"] = freightBill.FbCreditAmt;
            row["FbCurrencyQual"] = freightBill.FbCurrencyQual;//FB_CURRENCY_QUAL AS FbCurrencyQual,
            //row["FbDeclAmt"] = freightBill.FbDeclAmt;
            //row["FbDimWt"] = freightBill.FbDimWt;
            //row["FbDisputeAmt"] = freightBill.FbDisputeAmt;
            if(!freightBill.FbDscntAmt.IsNull)
                row["FbDscntAmt"] = freightBill.FbDscntAmt;//FB_DSCNT_AMT AS FbDscntAmt,
            //row["FbDuFlag"] = freightBill.FbDuFlag;
            //row["FbDueDtm"] = freightBill.FbDueDtm;
            if (!freightBill.FbFnclWt.IsNull)
                row["FbFnclWt"] = freightBill.FbFnclWt;//FB_FNCL_WT AS FbFnclWt,
            if (!freightBill.FbFrghtAmt.IsNull)
                row["FbFrghtAmt"] = freightBill.FbFrghtAmt;//FB_FRGHT_AMT AS FbFrghtAmt,
            row["FbId"] = freightBill.FbId;//FB_ID AS FbId, 
            row["FbKey"] = freightBill.FbKey;//FB_KEY AS FbKey,
            row["FbLnCnt"] = freightBill.FbLnCnt;//FB_LN_CNT AS FbLnCnt,
            //row["FbOpenAmt"] = freightBill.FbOpenAmt;
            //row["FbParentId"] = freightBill.FbParentId;
            //row["FbPaymtCnt"] = freightBill.FbPaymtCnt;
            row["FbPaymtTermsCode"] = freightBill.FbPaymtTermsCode;//FB_PAYMT_TERMS_CODE AS FbPaymtTermsCode,
            if(!freightBill.FbPcsCnt.IsNull)
                row["FbPcsCnt"] = freightBill.FbPcsCnt;//FB_PCS_CNT AS FbPcsCnt,
            //row["FbPdAmt"] = freightBill.FbPdAmt;
            //row["FbPendingReason"] = freightBill.FbPendingReason;
            //row["FbPendingReasonDesc"] = freightBill.FbPendingReasonDesc;
            row["FbPkgType"] = freightBill.FbPkgType;//FB_PKG_TYPE AS FbPkgType,
            //row["FbRptFactor"] = freightBill.FbRptFactor;
            //row["FbStat"] = freightBill.FbStat;
            if(!freightBill.FbTaxAmt.IsNull)
                row["FbTaxAmt"] = freightBill.FbTaxAmt;//FB_TAX_AMT AS FbTaxAmt
            //row["FbTerms"] = freightBill.FbTerms;
            //row["FbType"] = freightBill.FbType;
            //row["FbVoidFlag"] = freightBill.FbVoidFlag;
            //row["FbWtQual"] = freightBill.FbWtQual;
            //row["ForceFaExFlag"] = freightBill.ForceFaExFlag;
            if(!freightBill.InterlineAmt.IsNull)
                row["InterlineAmt"] = freightBill.InterlineAmt;//INTERLINE_AMT AS InterlineAmt,
            row["InterlineQual"] = freightBill.InterlineQual;//INTERLINE_QUAL AS InterlineQual,
            row["InterlineScac"] = freightBill.InterlineScac;//INTERLINE_SCAC AS InterlineScac,
            row["InvId"] = freightBill.InvId;//INV_ID AS InvId,
            row["InvKey"] = freightBill.InvKey;//INV_KEY AS InvKey,
            //row["LmAtaEtaVarncLabl"] = freightBill.LmAtaEtaVarncLabl;
            //row["LmAtaEtaVarncReason"] = freightBill.LmAtaEtaVarncReason;
            if(!freightBill.LmAtaDtm.IsNull)
                row["LmAtaDtm"] = Convert.ToDateTime(freightBill.LmAtaDtm).ToUniversalTime(); ;//LM_ATA_DTM AS LmAtaDtm,
            if(!freightBill.LmDist.IsNull)
                row["LmDist"] = freightBill.LmDist;//LM_DIST AS LmDist,
            //row["LmDistQual"] = freightBill.LmDistQual;
            //row["LmDlvryReqDtm"] = freightBill.LmDlvryReqDtm;
            //row["LmEtaDtm"] = freightBill.LmEtaDtm;
            //row["LmFirstDlvryDtm"] = freightBill.LmFirstDlvryDtm;
            row["LmLaneLabl"] = freightBill.LmLaneLabl;//LM_LANE_LABL AS LmLaneLabl
            if(!freightBill.LmPkupActualDtm.IsNull)
                row["LmPkupActualDtm"] = Convert.ToDateTime(freightBill.LmPkupActualDtm).ToUniversalTime(); ;//LM_PKUP_ACTUAL_DTM AS LmPkupActualDtm,            
            //row["LmPkupByDtm"] = freightBill.LmPkupByDtm;
            //row["LmPkupVarncLabl"] = freightBill.LmPkupVarncLabl;
            //row["LmPkupVarncReason"] = freightBill.LmPkupVarncReason;
            //row["LmRdyDtm"] = freightBill.LmRdyDtm;
            //row["LmReqKey"] = freightBill.LmReqKey;
            //row["LmTransitStat"] = freightBill.LmTransitStat;
            row["LocIdBlng"] = freightBill.LocIdBlng;
            //row["LocIdCons"] = freightBill.LocIdCons;
            //row["LocIdDest"] = freightBill.LocIdDest;
            //row["LocIdOrig"] = freightBill.LocIdOrig;
            //row["LocIdShpr"] = freightBill.LocIdShpr;
            //row["LocKeyBlng"] = freightBill.LocKeyBlng;
            //row["LocKeyCons"] = freightBill.LocKeyCons;
            //row["LocKeyDest"] = freightBill.LocKeyDest;
            //row["LocKeyOrig"] = freightBill.LocKeyOrig;
            //row["LocKeyShpr"] = freightBill.LocKeyShpr;
            //row["OwnerKey"] = freightBill.OwnerKey;
            //row["PodSignBy"] = freightBill.PodSignBy;
            row["PriceLaneLabl"] = freightBill.PriceLaneLabl;//PRICE_LANE_LABL AS PriceLaneLabl,
            //row["RuleBlWinner"] = freightBill.RuleBlWinner;
            //row["RuleBolWinner"] = freightBill.RuleBolWinner;
            //row["RuleCaWinner"] = freightBill.RuleCaWinner;
            //row["RuleDestWinner"] = freightBill.RuleDestWinner;
            //row["RuleDuWinner"] = freightBill.RuleDuWinner;
            //row["RuleFaWinner"] = freightBill.RuleFaWinner;
            //row["RuleLmWinner"] = freightBill.RuleLmWinner;
            //row["RuleMpWinner"] = freightBill.RuleMpWinner;
            //row["RuleOrigWinner"] = freightBill.RuleOrigWinner;
            //row["RuleRtWinner"] = freightBill.RuleRtWinner;
            row["SrvcReqCode"] = freightBill.SrvcReqCode;//SRVC_REQ_CODE AS SrvcReqCode,
            //row["TxFbAccAmt"] = freightBill.TxFbAccAmt;
            //row["TxFbAmt"] = freightBill.TxFbAmt;
            //row["TxFbBaseRate"] = freightBill.TxFbBaseRate;
            //row["TxFbBrkPtWt"] = freightBill.TxFbBrkPtWt;
            //row["TxFbCurrencyQual"] = freightBill.TxFbCurrencyQual;
            //row["TxFbDimWt"] = freightBill.TxFbDimWt;
            //row["TxFbDscntAmt"] = freightBill.TxFbDscntAmt;
            //row["TxFbFnclWt"] = freightBill.TxFbFnclWt;
            //row["TxFbFrghtAmt"] = freightBill.TxFbFrghtAmt;
            //row["TxFbRptFactor"] = freightBill.TxFbRptFactor;
            //row["TxFbTaxAmt"] = freightBill.TxFbTaxAmt;
            //row["TxFbTaxPcnt"] = freightBill.TxFbTaxPcnt;
            //row["TxFbWtQual"] = freightBill.TxFbWtQual;
            //row["TxLmDir"] = freightBill.TxLmDir;
            //row["TxLmDist"] = freightBill.TxLmDist;
            //row["TxLmDistQual"] = freightBill.TxLmDistQual;
            //row["TxLmType"] = freightBill.TxLmType;
            //row["TxShpmtId"] = freightBill.TxShpmtId;
            //row["VendCommitCode"] = freightBill.VendCommitCode;
            //row["VendFbType"] = freightBill.VendFbType;
            row["VendLabl"] = freightBill.VendLabl;//VEND_LABL AS VendLabl,
            //row["VendRateScale"] = freightBill.VendRateScale;
            //row["VendSrvcGuarCode"] = freightBill.VendSrvcGuarCode;
            //row["VendSrvcName"] = freightBill.VendSrvcName;
            //row["VendTariff"] = freightBill.VendTariff;
            return row;
        }

        protected DataRow SetFXIRow(FXI fxi, DataRow row)
        {
            row["FbId"] = fxi.FbId;
            row["InvPageNum"] = fxi.InvPageNum;
            row["VendLabl"] = fxi.VendLabl;
            row["InvId"] = fxi.InvId;
            row["BatId"] = fxi.BatId;
            row["T001"] = fxi.T001;
            row["T002"] = fxi.T002;
            row["T003"] = fxi.T003;
            row["T004"] = fxi.T004;
            row["T005"] = fxi.T005;
            row["T006"] = fxi.T006;
            row["T007"] = fxi.T007;
            row["T008"] = fxi.T008;
            row["T009"] = fxi.T009;
            row["T010"] = fxi.T010;
            row["T011"] = fxi.T011;
            row["T012"] = fxi.T012;
            row["T013"] = fxi.T013;
            row["T014"] = fxi.T014;
            row["T015"] = fxi.T015;
            row["T016"] = fxi.T016;
            row["T017"] = fxi.T017;
            row["T018"] = fxi.T018;
            row["T019"] = fxi.T019;
            row["T020"] = fxi.T020;
            row["T021"] = fxi.T021;
            row["T022"] = fxi.T022;
            row["T023"] = fxi.T023;
            row["T024"] = fxi.T024;
            row["T025"] = fxi.T025;
            row["T026"] = fxi.T026;
            row["T027"] = fxi.T027;
            row["T028"] = fxi.T028;
            row["T029"] = fxi.T029;
            row["T030"] = fxi.T030;
            row["T031"] = fxi.T031;
            row["T032"] = fxi.T032;
            row["T033"] = fxi.T033;
            row["T034"] = fxi.T034;
            row["T035"] = fxi.T035;
            row["T036"] = fxi.T036;
            row["T037"] = fxi.T037;
            row["T038"] = fxi.T038;
            row["T039"] = fxi.T039;
            row["T040"] = fxi.T040;
            row["T041"] = fxi.T041;
            row["T042"] = fxi.T042;
            row["T043"] = fxi.T043;
            row["T044"] = fxi.T044;
            row["T045"] = fxi.T045;
            row["T046"] = fxi.T046;
            row["T047"] = fxi.T047;
            row["T048"] = fxi.T048;
            row["T049"] = fxi.T049;
            row["T050"] = fxi.T050;
            row["T051"] = fxi.T051;
            row["T052"] = fxi.T052;
            row["T053"] = fxi.T053;
            row["T054"] = fxi.T054;
            row["T055"] = fxi.T055;
            row["T056"] = fxi.T056;
            row["T057"] = fxi.T057;
            row["T058"] = fxi.T058;
            row["T059"] = fxi.T059;
            row["T060"] = fxi.T060;
            row["T061"] = fxi.T061;
            row["T062"] = fxi.T062;
            row["T063"] = fxi.T063;
            row["T064"] = fxi.T064;
            row["T065"] = fxi.T065;
            row["T066"] = fxi.T066;
            row["T067"] = fxi.T067;
            row["T068"] = fxi.T068;
            row["T069"] = fxi.T069;
            row["T070"] = fxi.T070;
            row["T071"] = fxi.T071;
            row["T072"] = fxi.T072;
            row["T073"] = fxi.T073;
            row["T074"] = fxi.T074;
            row["T075"] = fxi.T075;
            row["T076"] = fxi.T076;
            row["T077"] = fxi.T077;
            row["T078"] = fxi.T078;
            row["T079"] = fxi.T079;
            row["T080"] = fxi.T080;
            row["T081"] = fxi.T081;
            row["T082"] = fxi.T082;
            row["T083"] = fxi.T083;
            row["T084"] = fxi.T084;
            row["T085"] = fxi.T085;
            row["T086"] = fxi.T086;
            row["T087"] = fxi.T087;
            row["T088"] = fxi.T088;
            row["T089"] = fxi.T089;
            row["T090"] = fxi.T090;
            row["T091"] = fxi.T091;
            row["T092"] = fxi.T092;
            row["T093"] = fxi.T093;
            row["T094"] = fxi.T094;
            row["T095"] = fxi.T095;
            row["T096"] = fxi.T096;
            row["T097"] = fxi.T097;
            row["T098"] = fxi.T098;
            row["T099"] = fxi.T099;
            row["T100"] = fxi.T100;
            row["T101"] = fxi.T101;
            row["T102"] = fxi.T102;
            row["T103"] = fxi.T103;
            row["T104"] = fxi.T104;
            row["T105"] = fxi.T105;
            row["T106"] = fxi.T106;
            row["T107"] = fxi.T107;
            row["T108"] = fxi.T108;
            row["T109"] = fxi.T109;
            row["T110"] = fxi.T110;
            row["T111"] = fxi.T111;
            row["T112"] = fxi.T112;
            row["T113"] = fxi.T113;
            row["T114"] = fxi.T114;
            row["T115"] = fxi.T115;
            row["T116"] = fxi.T116;
            row["T117"] = fxi.T117;
            row["T118"] = fxi.T118;
            row["T119"] = fxi.T119;
            row["T120"] = fxi.T120;
            return row;
        }
       
        protected DataRow SetFbLnRow(FbLn fbLine, DataRow row)
        {
            row["Facsimile01"] = fbLine.Facsimile01;// .VendDesc;//[%FACSIMILE_01] AS Facsimile01,
            row["Facsimile02"] = fbLine.Facsimile02;
            row["T001"] = fbLine.T001;
            row["T002"] = fbLine.T002;
            row["T003"] = fbLine.T003;
            row["T004"] = fbLine.T004;
            row["T005"] = fbLine.T005;
            row["T006"] = fbLine.T006;
            //row["BatKey"] = fbLine.BatKey;
            row["Cat"] = fbLine.Cat;//CAT AS Cat,
            //row["CatSeqNum"] = fbLine.CatSeqNum;
            if(!fbLine.ChrgAmt.IsNull)
                row["ChrgAmt"] = fbLine.ChrgAmt;//CHRG_AMT AS ChrgAmt,
            row["ChrgDesc"] = fbLine.ChrgDesc;//CHRG_DESC AS ChrgDesc,
            row["CmdtyClass"] = fbLine.CmdtyClass;//CMDTY_CLASS AS CmdtyClass,
            row["CurrencyQual"] = fbLine.CurrencyQual;//CURRENCY_QUAL AS CurrencyQual
            //row["DimData"] = fbLine.DimData;
            row["FbId"] = fbLine.FbId;//FB_ID AS FbId,
            //row["FbLineItemFlag"] = fbLine.FbLineItemFlag;            
            row["LineItemNum"] = fbLine.LineItemNum;//LINE_ITEM_NUM AS LineItemNum,
            if(!fbLine.LnActualWt.IsNull)
                row["LnActualWt"] = fbLine.LnActualWt;//LN_ACTUAL_WT AS	LnActualWt,
            //row["LnBasis"] = fbLine.LnBasis;
            //row["LnBasisQual"] = fbLine.LnBasisQual;
            row["LnChrgCode"] = fbLine.LnChrgCode; //LN_CHRG_CODE AS LnChrgCode,
            //row["LnDeclAmt"] = fbLine.LnDeclAmt;
            //row["LnRateAsQual"] = fbLine.LnRateAsQual;
            if(!fbLine.LnRateAsWt.IsNull)
                row["LnRateAsWt"] = fbLine.LnRateAsWt;//LN_RATE_AS_WT AS LnRateAsWt,
            //row["LnVendRateScale"] = fbLine.LnVendRateScale;
            //row["MsgGrpNum"] = fbLine.MsgGrpNum;
            if(!fbLine.PcsCnt.IsNull)
                row["PcsCnt"] = fbLine.PcsCnt;//PCS_CNT	AS PcsCnt,
            row["PkgType"] = fbLine.PkgType;//PKG_TYPE AS PkgType,
            row["QtyLabl"] = fbLine.QtyLabl;//QTY_LABL AS QtyLabl,
            if(!fbLine.RateAmt.IsNull)
                row["RateAmt"] = fbLine.RateAmt;//RATE_AMT AS RateAmt,
            //row["RateCpntId"] = fbLine.RateCpntId;
            //row["RatePerUntCnt"] = fbLine.RatePerUntCnt;
            row["RateType"] = fbLine.RateType;//RATE_TYPE AS RateType,
            row["RateUntLabl"] = fbLine.RateUntLabl;//RATE_UNT_LABL AS RateUntLabl,
            //row["TxActualWt"] = fbLine.TxActualWt;
            //row["TxDimVol"] = fbLine.TxDimVol;
            //row["TxDimWt"] = fbLine.TxDimWt;
            //row["TxFnclWt"] = fbLine.TxFnclWt;
            //row["TxLineItemFlag"] = fbLine.TxLineItemFlag;
            //row["TxRateAmt"] = fbLine.TxRateAmt;
            //row["VendDesc"] = fbLine.VendDesc;
            return row;
         }

        protected DataTable GetInvBatRowStructure()
        {                           
            DataTable retval = new DataTable("InvBat");
            //retval.Columns.Add("BatAdjmAmt");
            //retval.Columns.Add("BatAdjmCnt");
            retval.Columns.Add("BatAmt");//BAT_AMT AS BatAmt,
            //retval.Columns.Add("BatAppAmt");
            retval.Columns.Add("BatCreatDtm");//BAT_CREAT_DTM AS BatCreatDtm,
            //retval.Columns.Add("BatCreditAmt");
            retval.Columns.Add("BatCurrencyQual");//BAT_CURRENCY_QUAL AS BatCurrencyQual,
            //retval.Columns.Add("BatDisputeAmt");
            //retval.Columns.Add("BatDueDtm");
            retval.Columns.Add("BatFbCnt");//BAT_FB_CNT AS BatFbCnt,
            retval.Columns.Add("BatId");//BAT_ID AS BatId,
            retval.Columns.Add("BatInvCnt");//BAT_INV_CNT AS BatInvCnt,
            retval.Columns.Add("BatKey");//BAT_KEY AS BatKey,
            retval.Columns.Add("BatLocIdRemit");//BAT_LOC_ID_REMIT AS BatLocIdRemit,
            //retval.Columns.Add("BatMsgCtrlDtm");
            //retval.Columns.Add("BatMsgCtrlPodDtm");
            //retval.Columns.Add("BatMsgCtrlRouteLabl");
            //retval.Columns.Add("BatMsgCtrlSnapCnt");
            //retval.Columns.Add("BatMsgCtrlStat");
            //retval.Columns.Add("BatMsgCtrlType");
            //retval.Columns.Add("BatOpenAmt");
            //retval.Columns.Add("BatPaymtCnt");
            //retval.Columns.Add("BatPdAmt");
            //retval.Columns.Add("BatSnapCnt");
            retval.Columns.Add("BatStat");//BAT_STAT AS BatStat,
            retval.Columns.Add("BatType");//BAT_TYPE AS BatType
            //retval.Columns.Add("BatVoidFlag");
            //retval.Columns.Add("ImgDpFileDtm");
            //retval.Columns.Add("ImgDpFileGrp");
            //retval.Columns.Add("ImgDpFileName");
            //retval.Columns.Add("MsgGrpNum");
            //retval.Columns.Add("MsgGrpNumHist");
            //retval.Columns.Add("MsgGrpOrigHist");
            retval.Columns.Add("OwnerKey");//OWNER_KEY AS OwnerKey,
            //retval.Columns.Add("VendBatAmt");
            retval.Columns.Add("VendBatDtm");//VEND_BAT_DTM AS VendBatDtm,
            retval.Columns.Add("VendBatKey");//VEND_BAT_KEY AS VendBatKey,
            retval.Columns.Add("VendFeed");//VEND_FEED AS VendFeed,
            retval.Columns.Add("VendLabl");//VEND_LABL AS VendLabl,
            return retval;
        }

        protected DataTable GetInvoiceRowStructure()
        {
            DataTable retval = new DataTable("Invoice");
            //retval.Columns.Add("AcctIdVendBlng");
            retval.Columns.Add("AcctNumVendBlng");//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            retval.Columns.Add("AlBlng1");
            retval.Columns.Add("AlBlng2");
            retval.Columns.Add("AlBlng3");
            retval.Columns.Add("AlBlng4");
            //retval.Columns.Add("AlBlngQual");
            retval.Columns.Add("AlCityBlng");
            retval.Columns.Add("AlCityRemit");//AL_CITY_REMIT AS AlCityRemit,
            retval.Columns.Add("AlCntryCodeBlng");
            retval.Columns.Add("AlCntryCodeRemit");//AL_CNTRY_CODE_REMIT AS AlCntryCodeRemit,
            //retval.Columns.Add("AlPhoneExtBlng");
            //retval.Columns.Add("AlPhoneExtRemit");
            //retval.Columns.Add("AlPhoneNumBlng");
            //retval.Columns.Add("AlPhoneNumRemit");
            retval.Columns.Add("AlPostCodeBlng");
            retval.Columns.Add("AlPostCodeRemit");//AL_POST_CODE_REMIT AS AlPostCodeRemit,
            retval.Columns.Add("AlRemit1");//AL_REMIT_1 AS AlRemit1,
            retval.Columns.Add("AlRemit2");//AL_REMIT_2 AS AlRemit2,
            retval.Columns.Add("AlRemit3");//AL_REMIT_3 AS AlRemit3,
            retval.Columns.Add("AlRemit4");//AL_REMIT_4 AS AlRemit4,
            //retval.Columns.Add("AlRemitQual");
            retval.Columns.Add("AlStateProvBlng");
            retval.Columns.Add("AlStateProvRemit");//AL_STATE_PROV_REMIT AS AlStateProvRemit,
            //retval.Columns.Add("BatId");
            //retval.Columns.Add("BatKey");
            //retval.Columns.Add("InvAdjmAmt");
            //retval.Columns.Add("InvAdjmCnt");
            retval.Columns.Add("InvAmt");//INV_AMT AS InvAmt
            //retval.Columns.Add("InvAppAmt");
            retval.Columns.Add("InvCreatDtm");//INV_CREAT_DTM AS InvCreatDtm
            //retval.Columns.Add("InvCreditAmt");
            retval.Columns.Add("InvCurrencyQual");//INV_CURRENCY_QUAL AS InvCurrencyQual,
            //retval.Columns.Add("InvDisputeAmt");
            retval.Columns.Add("InvDueDtm");
            retval.Columns.Add("InvFbCnt");//INV_FB_CNT AS InvFbCnt,
            retval.Columns.Add("InvId");//INV_ID AS InvId,
            retval.Columns.Add("InvKey");//INV_KEY AS InvKey,
            //retval.Columns.Add("InvOpenAmt");
            //retval.Columns.Add("InvOrigId");
            //retval.Columns.Add("InvPaymtCnt");
            //retval.Columns.Add("InvPdAmt");
            //retval.Columns.Add("InvPdDtm");
            retval.Columns.Add("InvStat");//INV_STAT AS InvStat,
            //retval.Columns.Add("InvType");
            //retval.Columns.Add("InvVoidFlag");
            retval.Columns.Add("LocIdBlng");
            retval.Columns.Add("LocIdRemit");//LOC_ID_REMIT AS LocIdRemit,
            //retval.Columns.Add("LocKeyBlng");
            //retval.Columns.Add("LocKeyRemit");
            //retval.Columns.Add("MsgGrpNum");
            //retval.Columns.Add("OwnerKey");
            //retval.Columns.Add("VendBatKey");
            retval.Columns.Add("VendInvAmt");//VEND_INV_AMT AS VendInvAmt,
            retval.Columns.Add("VendLabl");//VEND_LABL AS VendLabl,
            return retval;
        }

        protected DataTable GetFrghtBlRowStructure()
        {            
            DataTable retval = new DataTable("FB");
            retval.Columns.Add("T001");
            retval.Columns.Add("T002");
            retval.Columns.Add("T003");
            retval.Columns.Add("T004");
            //retval.Columns.Add("T005");
            //retval.Columns.Add("T006");
            //retval.Columns.Add("T007");
            //retval.Columns.Add("T008");
            //retval.Columns.Add("T009");
            //retval.Columns.Add("T010");
            //retval.Columns.Add("T011");
            //retval.Columns.Add("T012");
            //retval.Columns.Add("T013");
            //retval.Columns.Add("T014");
            //retval.Columns.Add("T015");
            //retval.Columns.Add("T016");
            //retval.Columns.Add("T017");
            //retval.Columns.Add("T018");
            //retval.Columns.Add("T019");
            //retval.Columns.Add("T020");
            retval.Columns.Add("AcctNumVendBlng");//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            //retval.Columns.Add("AcctNumVendDest");
            //retval.Columns.Add("AcctNumVendOrig");
            retval.Columns.Add("AlCityDest");//AL_CITY_DEST AS AlCityDest,
            retval.Columns.Add("AlCityOrig");//AL_CITY_ORIG AS AlCityOrig,
            retval.Columns.Add("AlCntryCodeDest");//AL_CNTRY_CODE_DEST AS AlCntryCodeDest,
            retval.Columns.Add("AlCntryCodeOrig");//AL_CNTRY_CODE_ORIG AS AlCntryCodeOrig,
            retval.Columns.Add("AlDest1");//AL_DEST_1 AS AlDest1,
            retval.Columns.Add("AlDest2");//AL_DEST_2 AS AlDest2,
            retval.Columns.Add("AlDest3");//AL_DEST_3 AS AlDest3,
            retval.Columns.Add("AlDest4");//AL_DEST_4 AS AlDest4,
            //retval.Columns.Add("AlDestQual");
            retval.Columns.Add("AlOrig1");//AL_ORIG_1 AS AlOrig1,
            retval.Columns.Add("AlOrig2");//AL_ORIG_2 AS AlOrig2,
            retval.Columns.Add("AlOrig3");//AL_ORIG_3 AS AlOrig3,
            retval.Columns.Add("AlOrig4");//AL_ORIG_4 AS AlOrig4,
            //retval.Columns.Add("AlOrigQual");
            //retval.Columns.Add("AlPhoneExtDest");
            //retval.Columns.Add("AlPhoneExtOrig");
            //retval.Columns.Add("AlPhoneNumDest");
            //retval.Columns.Add("AlPhoneNumOrig");
            retval.Columns.Add("AlPostCodeDest");//AL_POST_CODE_DEST AS AlPostCodeDest,
            retval.Columns.Add("AlPostCodeOrig");//AL_POST_CODE_ORIG AS AlPostCodeOrig,
            retval.Columns.Add("AlStateProvDest");//AL_STATE_PROV_DEST AS AlStateProvDest,
            retval.Columns.Add("AlStateProvOrig");//AL_STATE_PROV_ORIG AS AlStateProvOrig,
            //retval.Columns.Add("BatId");
            //retval.Columns.Add("BatKey");
            //retval.Columns.Add("Bol1Raw");
            //retval.Columns.Add("BolNumKey");
            //retval.Columns.Add("BundleNum");
            retval.Columns.Add("CaInfo1Raw");//CA_INFO_1_RAW AS CaInfo1Raw,
            retval.Columns.Add("CaInfo2Raw");//CA_INFO_2_RAW AS CaInfo2Raw,
            //retval.Columns.Add("EntTypeBlng");
            //retval.Columns.Add("EntTypeCons");
            //retval.Columns.Add("EntTypeShpr");
            retval.Columns.Add("FbAccAmt");//FB_ACC_AMT AS FbAccAmt,
            retval.Columns.Add("FbActualWt");//FB_ACTUAL_WT AS FbActualWt,
            //retval.Columns.Add("FbAdjmAmt");
            //retval.Columns.Add("FbAdjmCnt");
            //retval.Columns.Add("FbAdjmDesc");
            //retval.Columns.Add("FbAdjmReason");
            retval.Columns.Add("FbAmt");//FB_AMT AS FbAmt,
            //retval.Columns.Add("FbAppAccAmt");
            //retval.Columns.Add("FbAppAmt");
            //retval.Columns.Add("FbAppCurrencyQual");
            //retval.Columns.Add("FbAppDscntAmt");
            //retval.Columns.Add("FbAppFrghtAmt");
            //retval.Columns.Add("FbAppRptFactor");
            //retval.Columns.Add("FbAppTaxAmt");
            //retval.Columns.Add("FbAppTaxPcnt");
            //retval.Columns.Add("FbBrkPtWt");
            //retval.Columns.Add("FbClass");
            retval.Columns.Add("FbCreatDtm");//FB_CREAT_DTM AS FbCreatDtm,
            //retval.Columns.Add("FbCreditAmt");
            retval.Columns.Add("FbCurrencyQual");//FB_CURRENCY_QUAL AS FbCurrencyQual,
            //retval.Columns.Add("FbDeclAmt");
            //retval.Columns.Add("FbDimWt");
            //retval.Columns.Add("FbDisputeAmt");
            retval.Columns.Add("FbDscntAmt");//FB_DSCNT_AMT AS FbDscntAmt,
            //retval.Columns.Add("FbDuFlag");
            //retval.Columns.Add("FbDueDtm");
            retval.Columns.Add("FbFnclWt");//FB_FNCL_WT AS FbFnclWt,
            retval.Columns.Add("FbFrghtAmt");//FB_FRGHT_AMT AS FbFrghtAmt,
            retval.Columns.Add("FbId");//FB_ID AS FbId, 
            retval.Columns.Add("FbKey");//FB_KEY AS FbKey,
            retval.Columns.Add("FbLnCnt");//FB_LN_CNT AS FbLnCnt,
            //retval.Columns.Add("FbOpenAmt");
            //retval.Columns.Add("FbParentId");
            //retval.Columns.Add("FbPaymtCnt");
            retval.Columns.Add("FbPaymtTermsCode");//FB_PAYMT_TERMS_CODE AS FbPaymtTermsCode,
            retval.Columns.Add("FbPcsCnt");//FB_PCS_CNT AS FbPcsCnt,
            //retval.Columns.Add("FbPdAmt");
            //retval.Columns.Add("FbPendingReason");
            //retval.Columns.Add("FbPendingReasonDesc");
            retval.Columns.Add("FbPkgType");//FB_PKG_TYPE AS FbPkgType,
            //retval.Columns.Add("FbRptFactor");
            //retval.Columns.Add("FbStat");
            retval.Columns.Add("FbTaxAmt");//FB_TAX_AMT AS FbTaxAmt
            //retval.Columns.Add("FbTerms");
            //retval.Columns.Add("FbType");
            //retval.Columns.Add("FbVoidFlag");
            //retval.Columns.Add("FbWtQual");
            //retval.Columns.Add("ForceFaExFlag");
            retval.Columns.Add("InterlineAmt");//INTERLINE_AMT AS InterlineAmt,
            retval.Columns.Add("InterlineQual");//INTERLINE_QUAL AS InterlineQual,
            retval.Columns.Add("InterlineScac");//INTERLINE_SCAC AS InterlineScac,
            retval.Columns.Add("InvId");//INV_ID AS InvId,
            retval.Columns.Add("InvKey");//INV_KEY AS InvKey,
            //retval.Columns.Add("LmAtaEtaVarncLabl");
            //retval.Columns.Add("LmAtaEtaVarncReason");
            retval.Columns.Add("LmAtaDtm");//LM_ATA_DTM AS LmAtaDtm,
            retval.Columns.Add("LmDist");//LM_DIST AS LmDist,
            //retval.Columns.Add("LmDistQual");
            //retval.Columns.Add("LmDlvryReqDtm");
            //retval.Columns.Add("LmEtaDtm");
            //retval.Columns.Add("LmFirstDlvryDtm");
            retval.Columns.Add("LmLaneLabl");//LM_LANE_LABL AS LmLaneLabl
            retval.Columns.Add("LmPkupActualDtm");//LM_PKUP_ACTUAL_DTM AS LmPkupActualDtm,
            //retval.Columns.Add("LmPkupByDtm");
            //retval.Columns.Add("LmPkupVarncLabl");
            //retval.Columns.Add("LmPkupVarncReason");
            //retval.Columns.Add("LmRdyDtm");
            //retval.Columns.Add("LmReqKey");
            //retval.Columns.Add("LmTransitStat");
            retval.Columns.Add("LocIdBlng");
            //retval.Columns.Add("LocIdCons");
            //retval.Columns.Add("LocIdDest");
            //retval.Columns.Add("LocIdOrig");
            //retval.Columns.Add("LocIdShpr");
            //retval.Columns.Add("LocKeyBlng");
            //retval.Columns.Add("LocKeyCons");
            //retval.Columns.Add("LocKeyDest");
            //retval.Columns.Add("LocKeyOrig");
            //retval.Columns.Add("LocKeyShpr");
            //retval.Columns.Add("OwnerKey");
            //retval.Columns.Add("PodSignBy");
            retval.Columns.Add("PriceLaneLabl");//PRICE_LANE_LABL AS PriceLaneLabl,
            //retval.Columns.Add("RuleBlWinner");
            //retval.Columns.Add("RuleBolWinner");
            //retval.Columns.Add("RuleCaWinner");
            //retval.Columns.Add("RuleDestWinner");
            //retval.Columns.Add("RuleDuWinner");
            //retval.Columns.Add("RuleFaWinner");
            //retval.Columns.Add("RuleLmWinner");
            //retval.Columns.Add("RuleMpWinner");
            //retval.Columns.Add("RuleOrigWinner");
            //retval.Columns.Add("RuleRtWinner");
            retval.Columns.Add("SrvcReqCode");//SRVC_REQ_CODE AS SrvcReqCode,
            //retval.Columns.Add("TxFbAccAmt");
            //retval.Columns.Add("TxFbAmt");
            //retval.Columns.Add("TxFbBaseRate");
            //retval.Columns.Add("TxFbBrkPtWt");
            //retval.Columns.Add("TxFbCurrencyQual");
            //retval.Columns.Add("TxFbDimWt");
            //retval.Columns.Add("TxFbDscntAmt");
            //retval.Columns.Add("TxFbFnclWt");
            //retval.Columns.Add("TxFbFrghtAmt");
            //retval.Columns.Add("TxFbRptFactor");
            //retval.Columns.Add("TxFbTaxAmt");
            //retval.Columns.Add("TxFbTaxPcnt");
            //retval.Columns.Add("TxFbWtQual");
            //retval.Columns.Add("TxLmDir");
            //retval.Columns.Add("TxLmDist");
            //retval.Columns.Add("TxLmDistQual");
            //retval.Columns.Add("TxLmType");
            //retval.Columns.Add("TxShpmtId");
            //retval.Columns.Add("VendCommitCode");
            //retval.Columns.Add("VendFbType");
            retval.Columns.Add("VendLabl");//VEND_LABL AS VendLabl,
            //retval.Columns.Add("VendRateScale");
            //retval.Columns.Add("VendSrvcGuarCode");
            //retval.Columns.Add("VendSrvcName");
            //retval.Columns.Add("VendTariff");
            return retval;
        }

        protected DataTable GetFXIRowStructure()
        {
            DataTable retval = new DataTable("FXI");
            DataColumn[] keys = new DataColumn[1];
            retval.Columns.Add("FbId");
            retval.Columns.Add("InvPageNum");
            retval.Columns.Add("VendLabl");
            retval.Columns.Add("InvId");
            retval.Columns.Add("BatId");
            retval.Columns.Add("T001");
            retval.Columns.Add("T002");
            retval.Columns.Add("T003");
            retval.Columns.Add("T004");
            retval.Columns.Add("T005");
            retval.Columns.Add("T006");
            retval.Columns.Add("T007");
            retval.Columns.Add("T008");
            retval.Columns.Add("T009");
            retval.Columns.Add("T010");
            retval.Columns.Add("T011");
            retval.Columns.Add("T012");
            retval.Columns.Add("T013");
            retval.Columns.Add("T014");
            retval.Columns.Add("T015");
            retval.Columns.Add("T016");
            retval.Columns.Add("T017");
            retval.Columns.Add("T018");
            retval.Columns.Add("T019");
            retval.Columns.Add("T020");
            retval.Columns.Add("T021");
            retval.Columns.Add("T022");
            retval.Columns.Add("T023");
            retval.Columns.Add("T024");
            retval.Columns.Add("T025");
            retval.Columns.Add("T026");
            retval.Columns.Add("T027");
            retval.Columns.Add("T028");
            retval.Columns.Add("T029");
            retval.Columns.Add("T030");
            retval.Columns.Add("T031");
            retval.Columns.Add("T032");
            retval.Columns.Add("T033");
            retval.Columns.Add("T034");
            retval.Columns.Add("T035");
            retval.Columns.Add("T036");
            retval.Columns.Add("T037");
            retval.Columns.Add("T038");
            retval.Columns.Add("T039");
            retval.Columns.Add("T040");
            retval.Columns.Add("T041");
            retval.Columns.Add("T042");
            retval.Columns.Add("T043");
            retval.Columns.Add("T044");
            retval.Columns.Add("T045");
            retval.Columns.Add("T046");
            retval.Columns.Add("T047");
            retval.Columns.Add("T048");
            retval.Columns.Add("T049");
            retval.Columns.Add("T050");
            retval.Columns.Add("T051");
            retval.Columns.Add("T052");
            retval.Columns.Add("T053");
            retval.Columns.Add("T054");
            retval.Columns.Add("T055");
            retval.Columns.Add("T056");
            retval.Columns.Add("T057");
            retval.Columns.Add("T058");
            retval.Columns.Add("T059");
            retval.Columns.Add("T060");
            retval.Columns.Add("T061");
            retval.Columns.Add("T062");
            retval.Columns.Add("T063");
            retval.Columns.Add("T064");
            retval.Columns.Add("T065");
            retval.Columns.Add("T066");
            retval.Columns.Add("T067");
            retval.Columns.Add("T068");
            retval.Columns.Add("T069");
            retval.Columns.Add("T070");
            retval.Columns.Add("T071");
            retval.Columns.Add("T072");
            retval.Columns.Add("T073");
            retval.Columns.Add("T074");
            retval.Columns.Add("T075");
            retval.Columns.Add("T076");
            retval.Columns.Add("T077");
            retval.Columns.Add("T078");
            retval.Columns.Add("T079");
            retval.Columns.Add("T080");
            retval.Columns.Add("T081");
            retval.Columns.Add("T082");
            retval.Columns.Add("T083");
            retval.Columns.Add("T084");
            retval.Columns.Add("T085");
            retval.Columns.Add("T086");
            retval.Columns.Add("T087");
            retval.Columns.Add("T088");
            retval.Columns.Add("T089");
            retval.Columns.Add("T090");
            retval.Columns.Add("T091");
            retval.Columns.Add("T092");
            retval.Columns.Add("T093");
            retval.Columns.Add("T094");
            retval.Columns.Add("T095");
            retval.Columns.Add("T096");
            retval.Columns.Add("T097");
            retval.Columns.Add("T098");
            retval.Columns.Add("T099");
            retval.Columns.Add("T100");
            retval.Columns.Add("T101");
            retval.Columns.Add("T102");
            retval.Columns.Add("T103");
            retval.Columns.Add("T104");
            retval.Columns.Add("T105");
            retval.Columns.Add("T106");
            retval.Columns.Add("T107");
            retval.Columns.Add("T108");
            retval.Columns.Add("T109");
            retval.Columns.Add("T110");
            retval.Columns.Add("T111");
            retval.Columns.Add("T112");
            retval.Columns.Add("T113");
            retval.Columns.Add("T114");
            retval.Columns.Add("T115");
            retval.Columns.Add("T116");
            retval.Columns.Add("T117");
            retval.Columns.Add("T118");
            retval.Columns.Add("T119");
            retval.Columns.Add("T120");
            keys[0] = retval.Columns["FbId"];
            retval.PrimaryKey = keys;
            return retval;
        }

        protected DataTable GetFbLnRowStructure()
        {   
            DataTable retval = new DataTable("FBLn");
            retval.Columns.Add("Facsimile01");//[%FACSIMILE_01] AS Facsimile01,
            retval.Columns.Add("Facsimile02");
            retval.Columns.Add("T001");
            retval.Columns.Add("T002");
            retval.Columns.Add("T003");
            retval.Columns.Add("T004");
            retval.Columns.Add("T005");
            retval.Columns.Add("T006");
            //retval.Columns.Add("BatKey");
            retval.Columns.Add("Cat");//CAT AS Cat,
            //retval.Columns.Add("CatSeqNum");
            retval.Columns.Add("ChrgAmt");//CHRG_AMT AS ChrgAmt,
            retval.Columns.Add("ChrgDesc");//CHRG_DESC AS ChrgDesc,
            retval.Columns.Add("CmdtyClass");//CMDTY_CLASS AS CmdtyClass,
            retval.Columns.Add("CurrencyQual");//CURRENCY_QUAL AS CurrencyQual
            //retval.Columns.Add("DimData");
            retval.Columns.Add("FbId");//FB_ID AS FbId,
            //retval.Columns.Add("FbLineItemFlag");
            retval.Columns.Add("LineItemNum");//LINE_ITEM_NUM AS LineItemNum,
            retval.Columns.Add("LnActualWt");//LN_ACTUAL_WT AS LnActualWt,
            //retval.Columns.Add("LnBasis");
            //retval.Columns.Add("LnBasisQual");
            retval.Columns.Add("LnChrgCode");//LN_CHRG_CODE AS LnChrgCode,
            //retval.Columns.Add("LnDeclAmt");
            //retval.Columns.Add("LnRateAsQual");
            retval.Columns.Add("LnRateAsWt");//LN_RATE_AS_WT AS LnRateAsWt,
            //retval.Columns.Add("LnVendRateScale");
            //retval.Columns.Add("MsgGrpNum");
            retval.Columns.Add("PcsCnt");//PCS_CNT AS PcsCnt,
            retval.Columns.Add("PkgType");//PKG_TYPE AS PkgType,
            retval.Columns.Add("QtyLabl");//QTY_LABL AS QtyLabl,
            retval.Columns.Add("RateAmt");//RATE_AMT AS RateAmt,
            //retval.Columns.Add("RateCpntId");
            //retval.Columns.Add("RatePerUntCnt");
            retval.Columns.Add("RateType");//RATE_TYPE AS RateType,
            retval.Columns.Add("RateUntLabl");//RATE_UNT_LABL AS RateUntLabl,
            //retval.Columns.Add("TxActualWt");
            //retval.Columns.Add("TxDimVol");
            //retval.Columns.Add("TxDimWt");
            //retval.Columns.Add("TxFnclWt");
            //retval.Columns.Add("TxLineItemFlag");
            //retval.Columns.Add("TxRateAmt");
            //retval.Columns.Add("VendDesc");            
            return retval;
        }

        protected void RawGroupInfoAuditTrail(string ImgGrpIDKey, string DescriptionID, DALHelper dal, string UserID)
        {
            try
            {
                int affectedRows = 0;

                string queryRGIAuditTrailInsert = @"INSERT INTO RawGroupInfoAuditTrail
													(ImgGrpIDKey
													,DescriptionID
													,Date
													,UserID)
												VALUES
													(@ImgGrpIDKey
													,@DescriptionID
													,GETUTCDATE()
													,@UserID)";

                ParameterInfo[] paramAuditTrail = new ParameterInfo[3];
                paramAuditTrail[0] = new ParameterInfo("@ImgGrpIDKey", ImgGrpIDKey);
                paramAuditTrail[1] = new ParameterInfo("@DescriptionID", DescriptionID);
                paramAuditTrail[2] = new ParameterInfo("@UserID", UserID);
                affectedRows = dal.ExecuteNonQuery(queryRGIAuditTrailInsert, CommandType.Text, paramAuditTrail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RawGroupInfoAuditTrail(string GroupIDKey, string DescriptionID, string UserID)
        {
            try
            {
                int affectedRows = 0;
                string queryRGIAuditTrailInsert = @"INSERT INTO RawGroupInfoAuditTrail
													(ImgGrpIDKey
													,DescriptionID
													,Date
													,UserID)
												VALUES
													(@ImgGrpIDKey
													,@DescriptionID
													,GETUTCDATE()
													,@UserID)";
                ParameterInfo[] paramAuditTrail = new ParameterInfo[3];
                paramAuditTrail[0] = new ParameterInfo("@ImgGrpIDKey", GroupIDKey);
                paramAuditTrail[1] = new ParameterInfo("@DescriptionID", DescriptionID);
                paramAuditTrail[2] = new ParameterInfo("@UserID", UserID);
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(queryRGIAuditTrailInsert, CommandType.Text, paramAuditTrail);
                dal.CommitTransaction();
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

        protected void RawImageInfoAuditTrail(string ImgDocIDKey, string DescriptionID, DALHelper dal, string UserID)
        {
            try
            {
                int affectedRows = 0;
                //insert audit trail
                string queryRIIAuditTrailInsert = @"INSERT INTO RawImageInfoAuditTrail
													(ImgDocIDKey
													,DescriptionID
													,Date
													,UserID)
												VALUES
													(@ImgDocIDKey
													,@DescriptionID
													,GETUTCDATE()
													,@UserID)";
                ParameterInfo[] paramAuditTrail = new ParameterInfo[3];
                paramAuditTrail[0] = new ParameterInfo("@ImgDocIDKey", ImgDocIDKey);
                paramAuditTrail[1] = new ParameterInfo("@DescriptionID", DescriptionID);
                paramAuditTrail[2] = new ParameterInfo("@UserID", UserID);

                affectedRows = dal.ExecuteNonQuery(queryRIIAuditTrailInsert, CommandType.Text, paramAuditTrail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void RawGroupInfoDeleteDetail(string ImgDocIDKey, string ImgGrpIDKey, string Reason, DALHelper dal, string UserID)
        {
            try
            {
                DataSet ds = new DataSet();
                int affectedRows = 0;
                string querySelect = @"SELECT ImgPageNo FROM RawPageInfo WHERE ImgGrpIDKey = @ImgGrpIDKey";
                string queryInsert = @"INSERT INTO RawGroupInfoDeleteDetail
													(ImgDocIDKey
                                                    ,ImgPageNo
                                                    ,ImgGrpIDKey
													,Reason
													,Date
													,UserID)
												VALUES
													(@ImgDocIDKey
                                                    ,@ImgPageNo
                                                    ,@ImgGrpIDKey
													,@Reason
													,GETUTCDATE()
													,@UserID)";
                ParameterInfo[] paramPages = new ParameterInfo[1];
                paramPages[0] = new ParameterInfo("@ImgGrpIDKey", ImgGrpIDKey);
                ds = dal.ExecuteDataSet(querySelect, CommandType.Text, paramPages);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ParameterInfo[] param = new ParameterInfo[5];
                        param[0] = new ParameterInfo("@ImgDocIDKey", ImgDocIDKey);
                        param[1] = new ParameterInfo("@ImgPageNo", row["ImgPageNo"].ToString());
                        param[2] = new ParameterInfo("@ImgGrpIDKey", ImgGrpIDKey);
                        param[3] = new ParameterInfo("@Reason", Reason);
                        param[4] = new ParameterInfo("@UserID", UserID);
                        affectedRows = dal.ExecuteNonQuery(queryInsert, CommandType.Text, param);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void RawImageInfoDeleteDetail(string ImgDocIDKey, string Reason, DALHelper dal, string UserID)
        {
            try
            {
                int affectedRows = 0;
                string queryInsert = @"INSERT INTO RawImageInfoDeleteDetail
													(ImgDocIDKey
													,Reason
													,Date
													,UserID)
												VALUES
													(@ImgDocIDKey
													,@Reason
													,GETUTCDATE()
													,@UserID)";
                ParameterInfo[] param = new ParameterInfo[3];
                param[0] = new ParameterInfo("@ImgDocIDKey", ImgDocIDKey);
                param[1] = new ParameterInfo("@Reason", Reason);
                param[2] = new ParameterInfo("@UserID", UserID);

                affectedRows = dal.ExecuteNonQuery(queryInsert, CommandType.Text, param);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void ImageAuditTrailInsert(string ImgID, string DescriptionID, DALHelper dal, string systemUserName)
        {
            try
            {
                int affectedRows = 0;
                //insert audit trail
                string queryImageAuditTrailInsert = @"INSERT INTO ImageAuditTrail
                                                           (ID
                                                           ,DescriptionID
                                                           ,Date
                                                           ,UserName
                                                           ,f_Date)
                                                     VALUES
                                                           (@ID
                                                           ,@DescriptionID
                                                           ,@UTCDate
                                                           ,@UserName
                                                           ,@UTCDate)";
                ParameterInfo[] paramAuditTrail = new ParameterInfo[4];
                paramAuditTrail[0] = new ParameterInfo("@ID", ImgID);
                paramAuditTrail[1] = new ParameterInfo("@DescriptionID", DescriptionID);
                paramAuditTrail[2] = new ParameterInfo("@UserName", systemUserName);
                paramAuditTrail[3] = new ParameterInfo("@UTCDate", GetServerDate(dal));

                affectedRows = dal.ExecuteNonQuery(queryImageAuditTrailInsert, CommandType.Text, paramAuditTrail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected void BatchAuditTrailInsert(string BatCtrlNum, string DescriptionID, DALHelper dal, string systemUserName)
        {
            try
            {
                int affectedRows = 0;
                //insert audit trail
                string queryImageAuditTrailInsert = @"INSERT INTO BatchAuditTrail
                                                           (Bat_Ctrl_Num
                                                           ,DescriptionID
                                                           ,Date
                                                           ,UserName
                                                           ,f_Date)
                                                     VALUES
                                                           (@Bat_Ctrl_Num
                                                           ,@DescriptionID
                                                           ,@UTCDate
                                                           ,@UserName
                                                           ,@UTCDate)";
                ParameterInfo[] paramAuditTrail = new ParameterInfo[4];
                paramAuditTrail[0] = new ParameterInfo("@Bat_Ctrl_Num", BatCtrlNum);
                paramAuditTrail[1] = new ParameterInfo("@DescriptionID", DescriptionID);
                paramAuditTrail[2] = new ParameterInfo("@UserName", systemUserName);
                paramAuditTrail[3] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                affectedRows = dal.ExecuteNonQuery(queryImageAuditTrailInsert, CommandType.Text, paramAuditTrail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
                
        protected DataTable GetInvBatRowStructureXML()
        {
            DataTable retval = new DataTable("InvBat");
            //retval.Columns.Add("BatAdjmAmt");
            //retval.Columns.Add("BatAdjmCnt");
            retval.Columns.Add("BatAmt");//BAT_AMT AS BatAmt,
            //retval.Columns.Add("BatAppAmt");
            retval.Columns.Add("BatCreatDtm");//BAT_CREAT_DTM AS BatCreatDtm,
            //retval.Columns.Add("BatCreditAmt");
            retval.Columns.Add("BatCurrencyQual");//BAT_CURRENCY_QUAL AS BatCurrencyQual,
            //retval.Columns.Add("BatDisputeAmt");
            //retval.Columns.Add("BatDueDtm");
            retval.Columns.Add("BatFbCnt", System.Type.GetType("System.Int32"));//BAT_FB_CNT AS BatFbCnt,
            retval.Columns.Add("BatId");//BAT_ID AS BatId,
            retval.Columns.Add("BatInvCnt", System.Type.GetType("System.Int32"));//BAT_INV_CNT AS BatInvCnt,
            retval.Columns.Add("BatKey");//BAT_KEY AS BatKey,
            retval.Columns.Add("BatLocIdRemit");//BAT_LOC_ID_REMIT AS BatLocIdRemit,
            //retval.Columns.Add("BatMsgCtrlDtm");
            //retval.Columns.Add("BatMsgCtrlPodDtm");
            //retval.Columns.Add("BatMsgCtrlRouteLabl");
            //retval.Columns.Add("BatMsgCtrlSnapCnt");
            //retval.Columns.Add("BatMsgCtrlStat");
            //retval.Columns.Add("BatMsgCtrlType");
            //retval.Columns.Add("BatOpenAmt");
            //retval.Columns.Add("BatPaymtCnt");
            //retval.Columns.Add("BatPdAmt");
            //retval.Columns.Add("BatSnapCnt");
            retval.Columns.Add("BatStat");//BAT_STAT AS BatStat,
            retval.Columns.Add("BatType");//BAT_TYPE AS BatType
            //retval.Columns.Add("BatVoidFlag");
            //retval.Columns.Add("ImgDpFileDtm");
            //retval.Columns.Add("ImgDpFileGrp");
            //retval.Columns.Add("ImgDpFileName");
            //retval.Columns.Add("MsgGrpNum");
            //retval.Columns.Add("MsgGrpNumHist");
            //retval.Columns.Add("MsgGrpOrigHist");
            retval.Columns.Add("OwnerKey");//OWNER_KEY AS OwnerKey,
            //retval.Columns.Add("VendBatAmt");
            retval.Columns.Add("VendBatDtm");//VEND_BAT_DTM AS VendBatDtm,
            retval.Columns.Add("VendBatKey");//VEND_BAT_KEY AS VendBatKey,
            retval.Columns.Add("VendFeed");//VEND_FEED AS VendFeed,
            retval.Columns.Add("VendLabl");//VEND_LABL AS VendLabl,
            return retval;
        }

        protected DataTable GetInvoiceRowStructureXML()
        {
            DataTable retval = new DataTable("Invoice");
            //retval.Columns.Add("AcctIdVendBlng");
            retval.Columns.Add("AcctNumVendBlng");//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            retval.Columns.Add("AlBlng1");
            retval.Columns.Add("AlBlng2");
            retval.Columns.Add("AlBlng3");
            retval.Columns.Add("AlBlng4");
            //retval.Columns.Add("AlBlngQual");
            retval.Columns.Add("AlCityBlng");
            retval.Columns.Add("AlCityRemit");//AL_CITY_REMIT AS AlCityRemit,
            retval.Columns.Add("AlCntryCodeBlng");
            retval.Columns.Add("AlCntryCodeRemit");//AL_CNTRY_CODE_REMIT AS AlCntryCodeRemit,
            //retval.Columns.Add("AlPhoneExtBlng");
            //retval.Columns.Add("AlPhoneExtRemit");
            //retval.Columns.Add("AlPhoneNumBlng");
            //retval.Columns.Add("AlPhoneNumRemit");
            retval.Columns.Add("AlPostCodeBlng");
            retval.Columns.Add("AlPostCodeRemit");//AL_POST_CODE_REMIT AS AlPostCodeRemit,
            retval.Columns.Add("AlRemit1");//AL_REMIT_1 AS AlRemit1,
            retval.Columns.Add("AlRemit2");//AL_REMIT_2 AS AlRemit2,
            retval.Columns.Add("AlRemit3");//AL_REMIT_3 AS AlRemit3,
            retval.Columns.Add("AlRemit4");//AL_REMIT_4 AS AlRemit4,
            //retval.Columns.Add("AlRemitQual");
            retval.Columns.Add("AlStateProvBlng");
            retval.Columns.Add("AlStateProvRemit");//AL_STATE_PROV_REMIT AS AlStateProvRemit,
            retval.Columns.Add("BatId");
            //retval.Columns.Add("BatKey");
            //retval.Columns.Add("InvAdjmAmt");
            //retval.Columns.Add("InvAdjmCnt");
            retval.Columns.Add("InvAmt", System.Type.GetType("System.Decimal"));//INV_AMT AS InvAmt
            //retval.Columns.Add("InvAppAmt");
            retval.Columns.Add("InvCreatDtm");//INV_CREAT_DTM AS InvCreatDtm
            //retval.Columns.Add("InvCreditAmt");
            retval.Columns.Add("InvCurrencyQual");//INV_CURRENCY_QUAL AS InvCurrencyQual,
            //retval.Columns.Add("InvDisputeAmt");
            retval.Columns.Add("InvDueDtm");
            retval.Columns.Add("InvFbCnt", System.Type.GetType("System.Int32"));//INV_FB_CNT AS InvFbCnt,
            retval.Columns.Add("InvId");//INV_ID AS InvId,
            retval.Columns.Add("InvKey");//INV_KEY AS InvKey,
            //retval.Columns.Add("InvOpenAmt");
            //retval.Columns.Add("InvOrigId");
            //retval.Columns.Add("InvPaymtCnt");
            //retval.Columns.Add("InvPdAmt");
            //retval.Columns.Add("InvPdDtm");
            retval.Columns.Add("InvStat");//INV_STAT AS InvStat,
            //retval.Columns.Add("InvType");
            //retval.Columns.Add("InvVoidFlag");
            retval.Columns.Add("LocIdBlng");
            retval.Columns.Add("LocIdRemit");//LOC_ID_REMIT AS LocIdRemit,
            //retval.Columns.Add("LocKeyBlng");
            //retval.Columns.Add("LocKeyRemit");
            //retval.Columns.Add("MsgGrpNum");
            //retval.Columns.Add("OwnerKey");
            //retval.Columns.Add("VendBatKey");
            retval.Columns.Add("VendInvAmt", System.Type.GetType("System.Decimal"));//VEND_INV_AMT AS VendInvAmt,
            retval.Columns.Add("VendLabl");//VEND_LABL AS VendLabl,
            
            //newFields
            retval.Columns.Add("InvBeforeTaxAmt", System.Type.GetType("System.Decimal"));
            retval.Columns.Add("VendTaxKey");
            retval.Columns.Add("InvTaxAmt", System.Type.GetType("System.Decimal"));
            retval.Columns.Add("InvType");
            retval.Columns.Add("InvPageNum", System.Type.GetType("System.Int32"));
            retval.Columns.Add("CustTaxKey");
            retval.Columns.Add("ImgPageCnt");
            retval.Columns.Add("VendName");
            return retval;
        }

        protected DataTable GetFrghtBlRowStructureXML()
        {
            DataTable retval = new DataTable("FrghtBl");
            //retval.Columns.Add("T001");
            //retval.Columns.Add("T002");
            //retval.Columns.Add("T003");
            //retval.Columns.Add("T004");
            //retval.Columns.Add("T005");
            //retval.Columns.Add("T006");
            //retval.Columns.Add("T007");
            //retval.Columns.Add("T008");
            //retval.Columns.Add("T009");
            //retval.Columns.Add("T010");
            //retval.Columns.Add("T011");
            //retval.Columns.Add("T012");
            //retval.Columns.Add("T013");
            //retval.Columns.Add("T014");
            //retval.Columns.Add("T015");
            //retval.Columns.Add("T016");
            //retval.Columns.Add("T017");
            //retval.Columns.Add("T018");
            //retval.Columns.Add("T019");
            //retval.Columns.Add("T020");
            retval.Columns.Add("AcctNumVendBlng");//ACCT_NUM_VEND_BLNG AS AcctNumVendBlng,
            //retval.Columns.Add("AcctNumVendDest");
            //retval.Columns.Add("AcctNumVendOrig");
            retval.Columns.Add("AlCityDest");//AL_CITY_DEST AS AlCityDest,
            retval.Columns.Add("AlCityOrig");//AL_CITY_ORIG AS AlCityOrig,
            retval.Columns.Add("AlCntryCodeDest");//AL_CNTRY_CODE_DEST AS AlCntryCodeDest,
            retval.Columns.Add("AlCntryCodeOrig");//AL_CNTRY_CODE_ORIG AS AlCntryCodeOrig,
            retval.Columns.Add("AlDest1");//AL_DEST_1 AS AlDest1,
            retval.Columns.Add("AlDest2");//AL_DEST_2 AS AlDest2,
            retval.Columns.Add("AlDest3");//AL_DEST_3 AS AlDest3,
            retval.Columns.Add("AlDest4");//AL_DEST_4 AS AlDest4,
            //retval.Columns.Add("AlDestQual");
            retval.Columns.Add("AlOrig1");//AL_ORIG_1 AS AlOrig1,
            retval.Columns.Add("AlOrig2");//AL_ORIG_2 AS AlOrig2,
            retval.Columns.Add("AlOrig3");//AL_ORIG_3 AS AlOrig3,
            retval.Columns.Add("AlOrig4");//AL_ORIG_4 AS AlOrig4,
            //retval.Columns.Add("AlOrigQual");
            //retval.Columns.Add("AlPhoneExtDest");
            //retval.Columns.Add("AlPhoneExtOrig");
            //retval.Columns.Add("AlPhoneNumDest");
            //retval.Columns.Add("AlPhoneNumOrig");
            retval.Columns.Add("AlPostCodeDest");//AL_POST_CODE_DEST AS AlPostCodeDest,
            retval.Columns.Add("AlPostCodeOrig");//AL_POST_CODE_ORIG AS AlPostCodeOrig,
            retval.Columns.Add("AlStateProvDest");//AL_STATE_PROV_DEST AS AlStateProvDest,
            retval.Columns.Add("AlStateProvOrig");//AL_STATE_PROV_ORIG AS AlStateProvOrig,
            //retval.Columns.Add("BatId");
            //retval.Columns.Add("BatKey");
            //retval.Columns.Add("Bol1Raw");
            //retval.Columns.Add("BolNumKey");
            //retval.Columns.Add("BundleNum");
            //retval.Columns.Add("CaInfo1Raw");//CA_INFO_1_RAW AS CaInfo1Raw,
            //retval.Columns.Add("CaInfo2Raw");//CA_INFO_2_RAW AS CaInfo2Raw,
            //retval.Columns.Add("EntTypeBlng");
            //retval.Columns.Add("EntTypeCons");
            //retval.Columns.Add("EntTypeShpr");
            retval.Columns.Add("FbAccAmt");//, System.Type.GetType("System.Decimal"));//FB_ACC_AMT AS FbAccAmt,
            retval.Columns.Add("FbActualWt", System.Type.GetType("System.Single"));//FB_ACTUAL_WT AS FbActualWt,
            //retval.Columns.Add("FbAdjmAmt");
            //retval.Columns.Add("FbAdjmCnt");
            //retval.Columns.Add("FbAdjmDesc");
            //retval.Columns.Add("FbAdjmReason");
            retval.Columns.Add("FbAmt", System.Type.GetType("System.Decimal"));//FB_AMT AS FbAmt,
            //retval.Columns.Add("FbAppAccAmt");
            //retval.Columns.Add("FbAppAmt");
            //retval.Columns.Add("FbAppCurrencyQual");
            //retval.Columns.Add("FbAppDscntAmt");
            //retval.Columns.Add("FbAppFrghtAmt");
            //retval.Columns.Add("FbAppRptFactor");
            //retval.Columns.Add("FbAppTaxAmt");
            //retval.Columns.Add("FbAppTaxPcnt");
            //retval.Columns.Add("FbBrkPtWt");
            //retval.Columns.Add("FbClass");
            retval.Columns.Add("FbCreatDtm");//FB_CREAT_DTM AS FbCreatDtm,
            //retval.Columns.Add("FbCreditAmt");
            retval.Columns.Add("FbCurrencyQual");//FB_CURRENCY_QUAL AS FbCurrencyQual,
            //retval.Columns.Add("FbDeclAmt");
            //retval.Columns.Add("FbDimWt");
            //retval.Columns.Add("FbDisputeAmt");
            retval.Columns.Add("FbDscntAmt");//, System.Type.GetType("System.Decimal"));//FB_DSCNT_AMT AS FbDscntAmt,
            //retval.Columns.Add("FbDuFlag");
            //retval.Columns.Add("FbDueDtm");
            retval.Columns.Add("FbFnclWt", System.Type.GetType("System.Single"));//FB_FNCL_WT AS FbFnclWt,
            retval.Columns.Add("FbFrghtAmt");//, System.Type.GetType("System.Decimal"));//FB_FRGHT_AMT AS FbFrghtAmt,
            retval.Columns.Add("FbId");//FB_ID AS FbId, 
            retval.Columns.Add("FbKey");//FB_KEY AS FbKey,
            retval.Columns.Add("FbLnCnt");//FB_LN_CNT AS FbLnCnt,
            //retval.Columns.Add("FbOpenAmt");
            //retval.Columns.Add("FbParentId");
            //retval.Columns.Add("FbPaymtCnt");
            retval.Columns.Add("FbPaymtTermsCode");//FB_PAYMT_TERMS_CODE AS FbPaymtTermsCode,
            retval.Columns.Add("FbPcsCnt", System.Type.GetType("System.Int32"));//FB_PCS_CNT AS FbPcsCnt,
            //retval.Columns.Add("FbPdAmt");
            //retval.Columns.Add("FbPendingReason");
            //retval.Columns.Add("FbPendingReasonDesc");
            retval.Columns.Add("FbPkgType");//FB_PKG_TYPE AS FbPkgType,
            //retval.Columns.Add("FbRptFactor");
            //retval.Columns.Add("FbStat");
            retval.Columns.Add("FbTaxAmt");//, System.Type.GetType("System.Decimal"));//FB_TAX_AMT AS FbTaxAmt
            //retval.Columns.Add("FbTerms");
            //retval.Columns.Add("FbType");
            //retval.Columns.Add("FbVoidFlag");
            //retval.Columns.Add("FbWtQual");
            //retval.Columns.Add("ForceFaExFlag");
            retval.Columns.Add("InterlineAmt", System.Type.GetType("System.Decimal"));//INTERLINE_AMT AS InterlineAmt,
            retval.Columns.Add("InterlineQual");//INTERLINE_QUAL AS InterlineQual,
            retval.Columns.Add("InterlineScac");//INTERLINE_SCAC AS InterlineScac,
            retval.Columns.Add("InvId");//INV_ID AS InvId,
            retval.Columns.Add("InvKey");//INV_KEY AS InvKey,
            //retval.Columns.Add("LmAtaEtaVarncLabl");
            //retval.Columns.Add("LmAtaEtaVarncReason");
            retval.Columns.Add("LmAtaDtm");//LM_ATA_DTM AS LmAtaDtm,
            retval.Columns.Add("LmDist", System.Type.GetType("System.Int16"));//LM_DIST AS LmDist,
            //retval.Columns.Add("LmDistQual");
            //retval.Columns.Add("LmDlvryReqDtm");
            //retval.Columns.Add("LmEtaDtm");
            //retval.Columns.Add("LmFirstDlvryDtm");
            retval.Columns.Add("LmLaneLabl");//LM_LANE_LABL AS LmLaneLabl
            retval.Columns.Add("LmPkupActualDtm");//LM_PKUP_ACTUAL_DTM AS LmPkupActualDtm,
            //retval.Columns.Add("LmPkupByDtm");
            //retval.Columns.Add("LmPkupVarncLabl");
            //retval.Columns.Add("LmPkupVarncReason");
            //retval.Columns.Add("LmRdyDtm");
            //retval.Columns.Add("LmReqKey");
            //retval.Columns.Add("LmTransitStat");
            retval.Columns.Add("LocIdBlng");
            //retval.Columns.Add("LocIdCons");
            //retval.Columns.Add("LocIdDest");
            //retval.Columns.Add("LocIdOrig");
            //retval.Columns.Add("LocIdShpr");
            //retval.Columns.Add("LocKeyBlng");
            //retval.Columns.Add("LocKeyCons");
            //retval.Columns.Add("LocKeyDest");
            //retval.Columns.Add("LocKeyOrig");
            //retval.Columns.Add("LocKeyShpr");
            //retval.Columns.Add("OwnerKey");
            //retval.Columns.Add("PodSignBy");
            retval.Columns.Add("PriceLaneLabl");//PRICE_LANE_LABL AS PriceLaneLabl,
            //retval.Columns.Add("RuleBlWinner");
            //retval.Columns.Add("RuleBolWinner");
            //retval.Columns.Add("RuleCaWinner");
            //retval.Columns.Add("RuleDestWinner");
            //retval.Columns.Add("RuleDuWinner");
            //retval.Columns.Add("RuleFaWinner");
            //retval.Columns.Add("RuleLmWinner");
            //retval.Columns.Add("RuleMpWinner");
            //retval.Columns.Add("RuleOrigWinner");
            //retval.Columns.Add("RuleRtWinner");
            retval.Columns.Add("SrvcReqCode");//SRVC_REQ_CODE AS SrvcReqCode,
            //retval.Columns.Add("TxFbAccAmt");
            //retval.Columns.Add("TxFbAmt");
            //retval.Columns.Add("TxFbBaseRate");
            //retval.Columns.Add("TxFbBrkPtWt");
            //retval.Columns.Add("TxFbCurrencyQual");
            //retval.Columns.Add("TxFbDimWt");
            //retval.Columns.Add("TxFbDscntAmt");
            //retval.Columns.Add("TxFbFnclWt");
            //retval.Columns.Add("TxFbFrghtAmt");
            //retval.Columns.Add("TxFbRptFactor");
            //retval.Columns.Add("TxFbTaxAmt");
            //retval.Columns.Add("TxFbTaxPcnt");
            //retval.Columns.Add("TxFbWtQual");
            //retval.Columns.Add("TxLmDir");
            //retval.Columns.Add("TxLmDist");
            //retval.Columns.Add("TxLmDistQual");
            //retval.Columns.Add("TxLmType");
            //retval.Columns.Add("TxShpmtId");
            //retval.Columns.Add("VendCommitCode");
            //retval.Columns.Add("VendFbType");
            retval.Columns.Add("VendLabl");//VEND_LABL AS VendLabl,
            //retval.Columns.Add("VendRateScale");
            //retval.Columns.Add("VendSrvcGuarCode");
            //retval.Columns.Add("VendSrvcName");
            //retval.Columns.Add("VendTariff");

            //newFields
            
            retval.Columns.Add("FbSpotQuoteKey");
            retval.Columns.Add("FbSpotQuoteAmt", System.Type.GetType("System.Decimal"));
            retval.Columns.Add("IncoTerms");
            retval.Columns.Add("FbPreAuthType");
            retval.Columns.Add("FbPreAuthAmt", System.Type.GetType("System.Decimal"));		
            retval.Columns.Add("FbType");
            //retval.Columns.Add("CustTaxKey");
            retval.Columns.Add("FbTaxPcnt", System.Type.GetType("System.Decimal"));		
            retval.Columns.Add("FbPreAuthBy");
			retval.Columns.Add("VendTariff");
            retval.Columns.Add("VendSrvcName");		
            retval.Columns.Add("VendSrvcType");			            
            retval.Columns.Add("VendSrvcZone");		
            retval.Columns.Add("VendSrvcScope");			
            retval.Columns.Add("FbExtRoute");	
            retval.Columns.Add("FbWtQual");
            retval.Columns.Add("FbVol", System.Type.GetType("System.Decimal"));	
            retval.Columns.Add("FbVolQual");
            retval.Columns.Add("FbLoadMeters", System.Type.GetType("System.Decimal"));	
            retval.Columns.Add("VesselName");
		    retval.Columns.Add("FbFnclWtQual");            	
            retval.Columns.Add("LmDistQual");
            retval.Columns.Add("FbDim");
            retval.Columns.Add("FbDimFactor", System.Type.GetType("System.Decimal"));	
            retval.Columns.Add("FbDimQual");

            retval.Columns.Add("FbRcvdBy");
            retval.Columns.Add("PortOrig");
            retval.Columns.Add("PortDest");
            retval.Columns.Add("FbExchDtm");
            retval.Columns.Add("FbExchRate", System.Type.GetType("System.Decimal"));
            retval.Columns.Add("FbPageNum", System.Type.GetType("System.Int32"));
            retval.Columns.Add("ImgPageCnt");

            retval.Columns.Add("FbSpotQuoteCurrencyQual");
            return retval;
        }

        protected DataTable GetKeyIdentsRowStructureXML()
        {
            DataTable retval = new DataTable("KeyIdents");
            retval.Columns.Add("FbId");
            retval.Columns.Add("KeyNum", System.Type.GetType("System.Int32"));
            //retval.Columns.Add("KeyType");
            retval.Columns.Add("KeyQual");
            retval.Columns.Add("KeyVal");            
            return retval;
        }

        protected DataTable GetAddrsRowStructureXML()
        {
            DataTable retval = new DataTable("Addrs");
            DataColumn[] keys = new DataColumn[3];
            retval.Columns.Add("FbId");
            retval.Columns.Add("AddrNum", System.Type.GetType("System.Int32"));
            retval.Columns.Add("AddrCat");
            retval.Columns.Add("AlAddr1");
            retval.Columns.Add("AlAddr2");
            retval.Columns.Add("AlAddr3");
            retval.Columns.Add("AlAddr4");
            retval.Columns.Add("AlCityAddr");
            retval.Columns.Add("AlStateProvAddr");
            retval.Columns.Add("AlPostCodeAddr");
            retval.Columns.Add("AlCntryCodeAddr");
            retval.Columns.Add("AlPortAddr");
            retval.Columns.Add("AlZoneAddr");

            keys[0] = retval.Columns["FbId"];
            keys[1] = retval.Columns["AddrNum"];
            keys[2] = retval.Columns["AddrCat"];
            retval.PrimaryKey = keys;
            return retval;
        }        

        protected DataTable GetCntnrsRowStructureXML()
        {
            DataTable retval = new DataTable("Cntnrs");
            retval.Columns.Add("FbId");
            retval.Columns.Add("CntnrNum", System.Type.GetType("System.Int32"));
            retval.Columns.Add("CntnrKey");
            retval.Columns.Add("CntnrType");
            retval.Columns.Add("CntnrSize");
            retval.Columns.Add("CntnrQty", System.Type.GetType("System.Int32"));
            return retval;
        }

        protected DataTable GetProdDtlRowStructureXML()
        {
            DataTable retval = new DataTable("ProdDtl");
            retval.Columns.Add("FbId");
            retval.Columns.Add("ProdInstNum", System.Type.GetType("System.Int32"));
            retval.Columns.Add("ProdKey");//nvarchar(50),     --SKU, Material #, Part #, specific product identifier
            retval.Columns.Add("ProdLine");//nvarchar(50),     --e.g. Dove Soap
            retval.Columns.Add("ProdType");//nvarchar(50),     --e.g. Soap
            retval.Columns.Add("ProdDesc");//nvarchar(255),    --long form product description or friendly name
            retval.Columns.Add("ProdUnitAmt", System.Type.GetType("System.Decimal"));//money,
            retval.Columns.Add("ProdUnitCurr");//nvarchar(20),
            retval.Columns.Add("ProdTotalAmt", System.Type.GetType("System.Decimal"));//money,
            retval.Columns.Add("ProdTotalCurr");//nvarchar(20)
            retval.Columns.Add("ProdPcsCnt", System.Type.GetType("System.Int32"));//int,
            retval.Columns.Add("ProdGrossWt", System.Type.GetType("System.Decimal"));//decimal(19,4),
            retval.Columns.Add("ProdNetWt", System.Type.GetType("System.Decimal"));//decimal(19,4),
            retval.Columns.Add("ProdWtUom");//nvarchar(20),
            retval.Columns.Add("ProdDim");//varchar(50),
            retval.Columns.Add("ProdDimUom");//nvarchar(20),
            retval.Columns.Add("ProdVol", System.Type.GetType("System.Decimal"));//decimal(19,4),
            retval.Columns.Add("ProdVolUom");//nvarchar(20),
            retval.Columns.Add("HazmatFlag");//bit,              --how to handle nullable?
            retval.Columns.Add("HazmatType");//nvarchar(50),
            retval.Columns.Add("OverDimFlag");//bit               --how to handle nullable?  Will             
            return retval;
        }

        protected DataTable GetFbLnRowStructureXML()
        {
            DataTable retval = new DataTable("FBLn");
            //retval.Columns.Add("Facsimile01");//[%FACSIMILE_01] AS Facsimile01,
            //retval.Columns.Add("Facsimile02");
            retval.Columns.Add("ExchRate");//retval.Columns.Add("T001");
            retval.Columns.Add("LocalAmt");//retval.Columns.Add("T002");
            retval.Columns.Add("LocalCurrencyQual");//retval.Columns.Add("T003");
            //retval.Columns.Add("T004");
            //retval.Columns.Add("T005");
            retval.Columns.Add("T006");
            //retval.Columns.Add("BatKey");
            retval.Columns.Add("Cat");//CAT AS Cat,
            //retval.Columns.Add("CatSeqNum");
            retval.Columns.Add("ChrgAmt", System.Type.GetType("System.Decimal"));//CHRG_AMT AS ChrgAmt,
            retval.Columns.Add("ChrgDesc");//CHRG_DESC AS ChrgDesc,
            retval.Columns.Add("CmdtyClass");//CMDTY_CLASS AS CmdtyClass,
            retval.Columns.Add("CurrencyQual");//CURRENCY_QUAL AS CurrencyQual
            //retval.Columns.Add("DimData");
            retval.Columns.Add("FbId");//FB_ID AS FbId,
            //retval.Columns.Add("FbLineItemFlag");
            retval.Columns.Add("LineItemNum", System.Type.GetType("System.Int16"));//LINE_ITEM_NUM AS LineItemNum,
            retval.Columns.Add("LnActualWt", System.Type.GetType("System.Single"));//LN_ACTUAL_WT AS LnActualWt,
            //retval.Columns.Add("LnBasis");
            //retval.Columns.Add("LnBasisQual");
            retval.Columns.Add("LnChrgCode");//LN_CHRG_CODE AS LnChrgCode,
            //retval.Columns.Add("LnDeclAmt");
            //retval.Columns.Add("LnRateAsQual");
            retval.Columns.Add("LnRateAsWt", System.Type.GetType("System.Single"));//LN_RATE_AS_WT AS LnRateAsWt,
            //retval.Columns.Add("LnVendRateScale");
            //retval.Columns.Add("MsgGrpNum");
            retval.Columns.Add("PcsCnt", System.Type.GetType("System.Int32"));//PCS_CNT AS PcsCnt,
            retval.Columns.Add("PkgType");//PKG_TYPE AS PkgType,
            retval.Columns.Add("QtyLabl");//QTY_LABL AS QtyLabl,
            retval.Columns.Add("RateAmt", System.Type.GetType("System.Decimal"));//RATE_AMT AS RateAmt,
            //retval.Columns.Add("RateCpntId");
            //retval.Columns.Add("RatePerUntCnt");
            retval.Columns.Add("RateType");//RATE_TYPE AS RateType,
            retval.Columns.Add("RateUntLabl");//RATE_UNT_LABL AS RateUntLabl,
            //retval.Columns.Add("TxActualWt");
            //retval.Columns.Add("TxDimVol");
            //retval.Columns.Add("TxDimWt");
            //retval.Columns.Add("TxFnclWt");
            //retval.Columns.Add("TxLineItemFlag");
            //retval.Columns.Add("TxRateAmt");
            retval.Columns.Add("VendDesc");

            retval.Columns.Add("LnDim");
            retval.Columns.Add("LnDimQual");
            retval.Columns.Add("LnVol", System.Type.GetType("System.Decimal"));
            retval.Columns.Add("LnVolQual");
            retval.Columns.Add("Taxable");

            return retval;
        }


        /*
        protected DataRow SetInvBatRowXMLFPS(Trax.FPS.v1.Types.Batch invoiceBat, DataRow row)
        {            
            //row["BatAdjmAmt"]=invoiceBat.
            //row["BatAdjmCnt"]=invoiceBat.
            if (invoiceBat.BatAmt.HasValue)
                row["BatAmt"]=invoiceBat.BatAmt;
            //row["BatAppAmt"]=invoiceBat.
            if (invoiceBat.BatCreatDtm.HasValue)
                row["BatCreatDtm"]=invoiceBat.BatCreatDtm;
            //row["BatCreditAmt"]=invoiceBat.            
            row["BatCurrencyQual"]=invoiceBat.BatCurrencyQual;
            //row["BatDisputeAmt"]=invoiceBat.BatDisputeAmt
            //row["BatDueDtm"]=invoiceBat.BatDueDtm
            if (invoiceBat.BatFbCnt.HasValue)
                row["BatFbCnt"]=invoiceBat.BatFbCnt;
            row["BatId"]=invoiceBat.BatId;
            if (invoiceBat.BatInvCnt.HasValue)
                row["BatInvCnt"]=invoiceBat.BatInvCnt;          
            row["BatKey"]=invoiceBat.BatKey;           
            row["BatLocIdRemit"]=invoiceBat.BatLocIdRemit;
            //row["BatMsgCtrlDtm"]=invoiceBat.
            //row["BatMsgCtrlPodDtm"]=invoiceBat.
            //row["BatMsgCtrlRouteLabl"]=invoiceBat.
            //row["BatMsgCtrlSnapCnt"]=invoiceBat.
            //row["BatMsgCtrlStat"]=invoiceBat.
            //row["BatMsgCtrlType"]=invoiceBat.
            //row["BatOpenAmt"]=invoiceBat.
            //row["BatPaymtCnt"]=invoiceBat.
            //row["BatPdAmt"]=invoiceBat.
            //row["BatSnapCnt"]=invoiceBat.
            row["BatStat"]=invoiceBat.BatStat;
            //row["BatSuspendAmt"]=invoiceBat.
            //row["BatSuspendCnt"]=invoiceBat.
            row["BatType"]=invoiceBat.BatType;
            //row["BatVoidFlag"]=invoiceBat.        
            //row["ImgDpFileDtm"]=invoiceBat.
            //row["ImgDpFileGrp"]=invoiceBat.
            //row["ImgDpFileName"]=invoiceBat.        
            //row["MsgGrpNum"]=invoiceBat.
            //row["MsgGrpNumHist"]=invoiceBat.
            //row["MsgGrpOrigHist"]=invoiceBat.            
            row["OwnerKey"]=invoiceBat.OwnerKey;
            //row["RuleProcessAfterDtm"]=invoiceBat.
            //row["RuleProcessCycCnt"]=invoiceBat.
            //row["VendBatAmt"]=invoiceBat.
            if (invoiceBat.VendBatDtm.HasValue)
                row["VendBatDtm"]=invoiceBat.VendBatDtm;            
            row["VendBatKey"]=invoiceBat.VendBatKey;            
            row["VendFeed"]=invoiceBat.VendFeed;
            row["VendLabl"] = invoiceBat.VendLabl;

            return row;
        }

        protected DataRow SetInvoiceRowXMLFPS(Trax.FPS.v1.Types.Invoice invoice, DataRow row)
        {
            //row["AcctIdVendBlng"] = invoice.AcctIdVendBlng;
            //row["AcctNumBlng"]= invoice.
            row["AcctNumVendBlng"]= invoice.AcctNumVendBlng;
            row["AlBlng1"]= invoice.AlBlng1;
            row["AlBlng2"]= invoice.AlBlng2;
            row["AlBlng3"]= invoice.AlBlng3;
            row["AlBlng4"]= invoice.AlBlng4;
            //row["AlBlngQual"]= invoice.
            row["AlCityBlng"]= invoice.AlCityBlng;
            row["AlCityRemit"]= invoice.AlCityRemit;
            row["AlCntryCodeBlng"]= invoice.AlCntryCodeBlng;
            row["AlCntryCodeRemit"]= invoice.AlCntryCodeRemit;
            //row["AlPhoneExtBlng"]= invoice.
            //row["AlPhoneExtRemit"]= invoice.
            //row["AlPhoneNumBlng"]= invoice.
            //row["AlPhoneNumRemit"]= invoice.
            row["AlPostCodeBlng"]= invoice.AlPostCodeBlng;
            row["AlPostCodeRemit"]= invoice.AlPostCodeRemit;
            row["AlRemit1"]= invoice.AlRemit1;
            row["AlRemit2"]= invoice.AlRemit2;
            row["AlRemit3"]= invoice.AlRemit3;
            row["AlRemit4"]= invoice.AlRemit4;
            //row["AlRemitQual"]= invoice.
            row["AlStateProvBlng"]= invoice.AlStateProvBlng;
            row["AlStateProvRemit"]= invoice.AlStateProvRemit;
            //row["AuthKey"]= invoice.        
            row["BatId"]= invoice.BatId;
            //row["BatKey"]= invoice.
            //row["EntityBlng"]= invoice.
            //row["ErpVendCode"]= invoice.
            //row["ImgPageCnt", System.Type.GetType("System.Int32")]= invoice.
            row["InvPageNum"]= invoice.ImgPageNum;//row["ImgPageNum", System.Type.GetType("System.Int32")]= invoice.
            //row["InvAdjmAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvAdjmCnt", System.Type.GetType("System.Int32")]= invoice.
            row["InvAmt"]= invoice.InvAmt;
            //row["InvAppAmt", System.Type.GetType("System.Decimal")]= invoice.
            row["InvCreatDtm"]= invoice.InvCreatDtm;
            //row["InvCreditAmt", System.Type.GetType("System.Decimal")]= invoice.
            row["InvCurrencyQual"]= invoice.InvCurrencyQual;
            //row["InvDisputeAmt", System.Type.GetType("System.Decimal")]= invoice.
            row["InvDueDtm"]= invoice.InvDueDtm;
            //row["InvDupAdjmDesc"]= invoice.
            //row["InvDupAdjmReason"]= invoice.
            //row["InvDupCapAppAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvDupManualRslt"]= invoice.
            //row["InvDupPattern"]= invoice.
            //row["InvDupRslt"]= invoice.
            //row["InvDupType"]= invoice.
            row["InvFbCnt"]= invoice.InvFbCnt;
            row["InvId"]= invoice.InvId;
            row["InvKey"]= invoice.InvKey;
            //row["InvKeyBase"]= invoice.
            //row["InvKeyPfx"]= invoice.
            //row["InvKeySfx"]= invoice.
            //row[" long InvNId"]= invoice.
            row["InvBeforeTaxAmt"]= invoice.InvNonTaxAmt;//row["InvNonTaxAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvOpenAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvOrigId"]= invoice.
            //row["InvPaymtCnt", System.Type.GetType("System.Int32")]= invoice.
            //row["InvPdAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvPdDtm"]= invoice.
            row["InvStat"]= invoice.InvStat;
            row["InvType"]= invoice.InvType;
            //row["InvVoidFlag"]= invoice.
            row["LocIdBlng"]= invoice.LocIdBlng;
            row["LocIdRemit"]= invoice.LocIdRemit;
            //row["LocKeyBlng"]= invoice.
            //row["LocKeyRemit"]= invoice.
            //row["MsgGrpNum"]= invoice.
            //row["NormalizedScac"]= invoice.
            //row["OwnerKey"]= invoice.
            //row["PaymtDscntReasonCode"]= invoice.
            //row["PaymtDscntReasonDesc"]= invoice.
            //row["SpotQuoteAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["SpotQuoteKey"]= invoice.
            row["InvTaxAmt"]= invoice.TaxAmt;//row["TaxAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["TaxRegCntryBlng"]= invoice.
            //row["TaxRegCntryVend"]= invoice.
            //row["TaxRegKeyBlng"]= invoice.
            row["VendTaxKey"]= invoice.TaxRegKeyVend;//row["TaxRegKeyVend"]= invoice.
            //row["VendBatKey"]= invoice.
            row["VendInvAmt"]= invoice.VendInvAmt;
            //row["VendInvDueDtm"]= invoice.
            row["VendLabl"]= invoice.VendLabl;
            //row["VendName"]= invoice.

            return row;
        }

        protected DataRow SetFrghtBlRowXMLFPS(Trax.FPS.v1.Types.FrghtBl freightBill, DataRow row)
        {   
            row["AcctNumVendBlng"] = freightBill.AcctNumVendBlng;
            //row["AcctNumVendDest"] = freightBill.
            //row["AcctNumVendOrig"] = freightBill.        
            row["AlCityDest"] = freightBill.AlCityDest;
            row["AlCityOrig"] = freightBill.AlCityOrig;
            row["AlCntryCodeDest"] = freightBill.AlCntryCodeDest;
            row["AlCntryCodeOrig"] = freightBill.AlCntryCodeOrig;
            row["AlDest1"] = freightBill.AlDest1;
            row["AlDest2"] = freightBill.AlDest2;
            row["AlDest3"] = freightBill.AlDest3;
            row["AlDest4"] = freightBill.AlDest4;
            //row["AlDestQual"] = freightBill.
            //row["ALineContext"] = freightBill.
            row["AlOrig1"] = freightBill.AlOrig1;
            row["AlOrig2"] = freightBill.AlOrig2;
            row["AlOrig3"] = freightBill.AlOrig3;
            row["AlOrig4"] = freightBill.AlOrig4;
            //row["AlOrigQual"] = freightBill.
            //row["AlPhoneExtDest"] = freightBill.
            //row["AlPhoneExtOrig"] = freightBill.
            //row["AlPhoneNumDest"] = freightBill.
            //row["AlPhoneNumOrig"] = freightBill.
            row["AlPostCodeDest"] = freightBill.AlPostCodeDest;
            row["AlPostCodeOrig"] = freightBill.AlPostCodeOrig;
            row["AlStateProvDest"] = freightBill.AlStateProvDest;
            row["AlStateProvOrig"] = freightBill.AlStateProvOrig;
            //row["AsnRatedAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["AsnRatedCurrencyQual"] = freightBill.
            //row["AsnWt"] = freightBill.//public float? 
            //row["AsnWtQual"] = freightBill.        
            //row["AuthKey"] = freightBill.        
            //row["BatId"] = freightBill.
            //row["BatKey"] = freightBill.
            //row["BmDiv"] = freightBill.
            //row["BmEntity"] = freightBill.
            //row["BmSubDiv"] = freightBill.
            //row["BmSubEntity"] = freightBill.
            //row["Bol1Raw"] = freightBill.
            //row["BolNumKey"] = freightBill.
            //row["BundleNum"] = freightBill.
            //row["BusinessFlow"] = freightBill.
            //row["BusinessProgram"] = freightBill.
            //row["BusinessUnit"] = freightBill.
            //row["BusinessUnitRule"] = freightBill.        
            //row["CaInfo1Raw"] = freightBill.
            //row["CaInfo2Raw"] = freightBill.
            //row["CaModel"] = freightBill.
            //row["CaRule"] = freightBill.
            //row["ContractNum"] = freightBill.
            //row["CurrEntity"] = freightBill.
            //row["CurrState"] = freightBill.
            //row["CustMode"] = freightBill.
            //row["CustSrvcCode"] = freightBill.
            //row["CustSrvcName"] = freightBill.
            //row["DenialEnv"] = freightBill.
            //row["DenialPhase"] = freightBill.//public byte? 
            //row["DeniedFlag"] = freightBill.
            row["FbDim"] = freightBill.DimData;//row["DimData"] = freightBill.
            if(freightBill.DimFactor.HasValue)
                row["FbDimFactor"] = freightBill.DimFactor;//row["DimFactor", System.Type.GetType("System.Decimal")] = freightBill.
            row["FbDimQual"] = freightBill.DimUom;//row["DimUom"] = freightBill.
            //row["DirectIndirectCode"] = freightBill.
            //row["EntTypeBlng"] = freightBill.
            //row["EntTypeCons"] = freightBill.
            //row["EntTypeShpr"] = freightBill.
            //row["ExchDate"] = freightBill.
            //row["ExchRate", System.Type.GetType("System.Decimal")] = freightBill.
            //row["ExDesc"] = freightBill.
            //row["ExDtlInfo"] = freightBill.        
            if(freightBill.FbAccAmt.HasValue)
                row["FbAccAmt"] = freightBill.FbAccAmt;
            if (freightBill.FbActualWt.HasValue)
                row["FbActualWt"] = freightBill.FbActualWt;
            //row["FbAdjmAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAdjmCnt"] = freightBill.//public short? 
            //row["FbAdjmDesc"] = freightBill.
            //row["FbAdjmReason"] = freightBill.
            if (freightBill.FbAmt.HasValue)
                row["FbAmt"] = freightBill.FbAmt;
            //row["FbAppAccAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppCurrencyQual"] = freightBill.
            //row["FbAppDscntAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppFrghtAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppRptFactor", System.Type.GetType("System.Single")] = freightBill.
            //row["FbAppTaxAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppTaxPcnt", System.Type.GetType("System.Single")] = freightBill.
            //row["FbBrkPtWt", System.Type.GetType("System.Single")] = freightBill.
            //row["FbClass"] = freightBill.
            if (freightBill.FbCreatDtm.HasValue)
                row["FbCreatDtm"] = freightBill.FbCreatDtm;
            //row["FbCreditAmt", System.Type.GetType("System.Decimal")] = freightBill.
            row["FbCurrencyQual"] = freightBill.FbCurrencyQual;
            //row["FbDeclAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbDimWt", System.Type.GetType("System.Single")] = freightBill.
            //row["FbDisputeAmt", System.Type.GetType("System.Decimal")] = freightBill.
            if (freightBill.FbDscntAmt.HasValue)
                row["FbDscntAmt"] = freightBill.FbDscntAmt;
            //row["FbDueDtm"] = freightBill.
            //row["FbDuFlag"] = freightBill.
            //row["FbDupAdjmDesc"] = freightBill.
            //row["FbDupAdjmReason"] = freightBill.
            //row["FbDupCapAppAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbDupManualRslt"] = freightBill.
            //row["FbDupPattern"] = freightBill.
            //row["FbDupRslt"] = freightBill.
            //row["FbDupType"] = freightBill.
            if (freightBill.FbFnclWt.HasValue)
                row["FbFnclWt"] = freightBill.FbFnclWt;
            if (freightBill.FbFrghtAmt.HasValue)
                row["FbFrghtAmt"] = freightBill.FbFrghtAmt;
            row["FbId"] = freightBill.FbId;
            row["FbKey"] = freightBill.FbKey;
            //row["FbKeyBase"] = freightBill.
            //row["FbKeyPfx"] = freightBill.
            //row["FbKeySfx"] = freightBill.
            if (freightBill.FbLnCnt.HasValue)
                row["FbLnCnt"] = freightBill.FbLnCnt;//public short?         
            //row["FbNId"] = freightBill.//public long 
            //row["FbOpenAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbParentId"] = freightBill.
            //row["FbPaymtCnt"] = freightBill.//public short? 
            row["FbPaymtTermsCode"] = freightBill.FbPaymtTermsCode;
            if (freightBill.FbPcsCnt.HasValue)
                row["FbPcsCnt"] = freightBill.FbPcsCnt;
            //row["FbPdAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbPendingReason"] = freightBill.
            //row["FbPendingReasonDesc"] = freightBill.
            row["FbPkgType"] = freightBill.FbPkgType;
            //row["FbRecycleFromId"] = freightBill.
            //row["FbRecycleReasonInfo"] = freightBill.
            //row["FbRptFactor", System.Type.GetType("System.Single")] = freightBill.
            //row["FbStat"] = freightBill.
            if (freightBill.FbTaxAmt.HasValue)
                row["FbTaxAmt"] = freightBill.FbTaxAmt;
            //row["FbTerms"] = freightBill.
            row["FbType"] = freightBill.FbType;
            //row["FbVoidFlag"] = freightBill.
            row["FbWtQual"] = freightBill.FbWtQual;
            //row["ForceFaExFlag"] = freightBill.
            //row["GlModel"] = freightBill.
            //row["GlRule"] = freightBill.
            //row["ImageURI"] = freightBill.
            //row["ImgPageCnt", System.Type.GetType("System.Int32")] = freightBill.
            if (freightBill.ImgPageNum.HasValue)
                row["FbPageNum"] = freightBill.ImgPageNum;//row["ImgPageNum", System.Type.GetType("System.Int32")] = freightBill.
            row["IncoTerms"] = freightBill.IncoTerms;
            if (freightBill.InterlineAmt.HasValue)
                row["InterlineAmt"] = freightBill.InterlineAmt;
            row["InterlineQual"] = freightBill.InterlineQual;
            row["InterlineScac"] = freightBill.InterlineScac;
            //row["InternationalFlag"] = freightBill.
            //row["InterStateProvFlag"] = freightBill.
            //row["IntraStateProvFlag"] = freightBill.
            row["InvId"] = freightBill.InvId;
            row["InvKey"] = freightBill.InvKey;
            if (freightBill.LmAtaDtm.HasValue)
                row["LmAtaDtm"] = freightBill.LmAtaDtm;
            //row["LmAtaEtaVarncLabl"] = freightBill.
            //row["LmAtaEtaVarncReason"] = freightBill.
            if (freightBill.LmDist.HasValue)
                row["LmDist"] = freightBill.LmDist;//public short? 
            row["LmDistQual"] = freightBill.LmDistQual;
            //row["LmDlvryReqDtm"] = freightBill.
            //row["LmEtaDtm"] = freightBill.
            //row["LmFirstDlvryDtm"] = freightBill.
            row["LmLaneLabl"] = freightBill.LmLaneLabl;
            if (freightBill.LmPkupActualDtm.HasValue)
                row["LmPkupActualDtm"] = freightBill.LmPkupActualDtm;
            //row["LmPkupByDtm"] = freightBill.
            //row["LmPkupVarncLabl"] = freightBill.
            //row["LmPkupVarncReason"] = freightBill.
            //row["LmRdyDtm"] = freightBill.
            //row["LmReqKey"] = freightBill.
            //row["LmTransitStat"] = freightBill.
            //row["LoadMeter", System.Type.GetType("System.Decimal")] = freightBill.
            row["LocIdBlng"] = freightBill.LocIdBlng;
            //row["LocIdCons"] = freightBill.
            //row["LocIdDest"] = freightBill.
            //row["LocIdOrig"] = freightBill.
            //row["LocIdShpr"] = freightBill.
            //row["LocKeyBlng"] = freightBill.
            //row["LocKeyCons"] = freightBill.
            //row["LocKeyDest"] = freightBill.
            //row["LocKeyOrig"] = freightBill.
            //row["LocKeyShpr"] = freightBill.
            //row["Mode"] = freightBill.
            //row["ModeType"] = freightBill.
            //row["MsgGrpNum"] = freightBill.
            //row["OmArea"] = freightBill.
            //row["OmDept"] = freightBill.
            //row["OmGrp"] = freightBill.
            //row["OmOrg"] = freightBill.
            //row["OmTeam"] = freightBill.
            //row["OwnerKey"] = freightBill.
            //row["PaymtDscntReasonCode"] = freightBill.
            //row["PaymtDscntReasonDesc"] = freightBill.
            //row["PodSignBy"] = freightBill.
            row["PortDest"] = freightBill.PortDest;
            row["PortOrig"] = freightBill.PortOrig;
            row["PriceLaneLabl"] = freightBill.PriceLaneLabl;
            //row["RoleDest"] = freightBill.
            //row["RoleDestRule"] = freightBill.
            //row["RoleOrig"] = freightBill.
            //row["RoleOrigRule"] = freightBill.
            //row["RouteCityDest"] = freightBill.
            //row["RouteCityOrig"] = freightBill.
            //row["RouteCntryCodeDest"] = freightBill.
            //row["RouteCntryCodeOrig"] = freightBill.
            //row["RouteStateProvDest"] = freightBill.
            //row["RouteStateProvOrig"] = freightBill.
            //row["RuleBlWinner"] = freightBill.
            //row["RuleBolWinner"] = freightBill.
            //row["RuleCaWinner"] = freightBill.
            //row["RuleDestWinner"] = freightBill.
            //row["RuleDuWinner"] = freightBill.
            //row["RuleFaWinner"] = freightBill.
            //row["RuleLmWinner"] = freightBill.
            //row["RuleMpWinner"] = freightBill.
            //row["RuleOrigWinner"] = freightBill.
            //row["RuleRtWinner"] = freightBill.
            //row["ShpmtPurp"] = freightBill.
            //row["ShpmtPurpType"] = freightBill.
            if(freightBill.SpotQuoteAmt.HasValue)
            row["FbSpotQuoteAmt"] = freightBill.SpotQuoteAmt; //row["SpotQuoteAmt", System.Type.GetType("System.Decimal")] = freightBill.
            row["FbSpotQuoteKey"] = freightBill.SpotQuoteKey; //row["SpotQuoteKey"] = freightBill.
            //row["SrvcLvl"] = freightBill.
            row["SrvcReqCode"] = freightBill.SrvcReqCode;
            //row["SrvcScope"] = freightBill.
            //row["SupplyChainArc"] = freightBill.
            //row["T001"] = freightBill.
            //row["T002"] = freightBill.
            //row["T003"] = freightBill.
            //row["T004"] = freightBill.
            //row["T005"] = freightBill.
            //row["T006"] = freightBill.
            //row["T007"] = freightBill.
            //row["T008"] = freightBill.
            //row["T009"] = freightBill.
            //row["T010"] = freightBill.
            //row["T011"] = freightBill.
            //row["T012"] = freightBill.
            //row["T013"] = freightBill.
            //row["T014"] = freightBill.
            //row["T015"] = freightBill.
            //row["T016"] = freightBill.
            //row["T017"] = freightBill.
            //row["T018"] = freightBill.
            //row["T019"] = freightBill.
            //row["T020"] = freightBill.
            //row["TransType"] = freightBill.
            //row["TxFbAccAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbBaseRate", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbBrkPtWt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbCurrencyQual"] = freightBill.
            //row["TxFbDimWt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbDscntAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbFnclWt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbFrghtAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbRptFactor", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbTaxAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbTaxPcnt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbWtQual"] = freightBill.
            //row["TxLmDir"] = freightBill.
            //row["TxLmDist"] = freightBill.//public short? 
            //row["TxLmDistQual"] = freightBill.
            //row["TxLmType"] = freightBill.
            //row["TxPaymtTermsCode"] = freightBill.
            //row["TxShpmtId"] = freightBill.
            //row["VendCommitCode"] = freightBill.
            //row["VendFbType"] = freightBill.
            row["VendLabl"] = freightBill.VendLabl;
            //row["VendName"] = freightBill.
            //row["VendRateScale"] = freightBill.
            //row["VendSrvcCode"] = freightBill.
            //row["VendSrvcGuarCode"] = freightBill.
            row["VendSrvcName"] = freightBill.VendSrvcName;
            row["VendSrvcScope"] = freightBill.VendSrvcScope;
            row["VendSrvcType"] = freightBill.VendSrvcType;
            row["VendSrvcZone"] = freightBill.VendSrvcZone;
            //row["VendSupplyChainSrvc"] = freightBill.
            row["VendTariff"] = freightBill.VendTariff;
            if (freightBill.Vol.HasValue)
                row["FbVol"] = freightBill.Vol;//row["Vol", System.Type.GetType("System.Decimal")] = freightBill.
            row["FbVolQual"] = freightBill.VolUom;//row["VolUom"] = freightBill.

            return row;
        }

        protected DataRow SetKeyIdentsRowXMLFPS(Trax.FPS.v1.Types.KeyRaw keyIdent, DataRow row)
        {            
            //row["KeyNum"] = keyIdent.InstNum ;
            //if(row["KeyBase"] != DBNull.Value)
            //    keyIdent.KeyBase=row["KeyBase"].ToString();
            row["KeyQual"] = keyIdent.KeyQual;
            //if(row["KeySource"] != DBNull.Value)
            //    keyIdent.KeySource=row["KeySource"].ToString();
            //if(row["KeyType"] != DBNull.Value)
            //    keyIdent.KeyType=row["KeyType"].ToString();
            row["KeyVal"] =  keyIdent.KeyVal ;
            row["FbId"] = keyIdent.LocalUntNId.Value.ToString();
            //if(row["UntType"] != DBNull.Value)
            //    keyIdent.UntType=row["UntType"].ToString();
            //if(row["ValidKeyPattern"] != DBNull.Value)
            //    keyIdent.ValidKeyPattern=row["ValidKeyPattern"].ToString();
            //if(row["ValidKeyType"] != DBNull.Value)
            //    keyIdent.ValidKeyType=row["ValidKeyType"].ToString();
            return row;
        }

        protected DataRow SetAddrsRowXMLFPS(Trax.FPS.v1.Types.AddrRaw addrRaw, DataRow row)
        {            
            row["AlAddr1"] = addrRaw.AddrLine1;
            row["AlAddr2"] = addrRaw.AddrLine2 ;
            row["AlAddr3"] =  addrRaw.AddrLine3 ;
            row["AlAddr4"] = addrRaw.AddrLine4 ;
            row["AddrCat"] = addrRaw.AddrType ;
            row["AlCntryCodeAddr"] =  addrRaw.Country;
            //if(row["GeoLatitude"] != DBNull.Value)addrRaw.GeoLatitude=row["GeoLatitude"].ToString();
            //if(row["GeoLocation"] != DBNull.Value)addrRaw.GeoLocation=row["GeoLocation"].ToString();
            //if(row["GeoLongitude"] != DBNull.Value)addrRaw.GeoLongitude=row["GeoLongitude"].ToString();
            //if(row["GeoRegion"] != DBNull.Value)addrRaw.GeoRegion=row["GeoRegion"].ToString();
            //if(row["GeoTerritory"] != DBNull.Value)addrRaw.GeoTerritory=row["GeoTerritory"].ToString();
            row["AddrNum"] =  addrRaw.InstNum;
            //if(row["LocalAddrLocation"] != DBNull.Value)addrRaw.LocalAddrLocation=row["LocalAddrLocation"].ToString();
            row["FbId"] = addrRaw.LocalUntNId.Value.ToString();
            //if(row["LocType"] != DBNull.Value)addrRaw.LocType=row["LocType"].ToString();
            //if(row["PartnerEntity"] != DBNull.Value)addrRaw.PartnerEntity=row["PartnerEntity"].ToString();
            row["AlCityAddr"] = addrRaw.PlaceName ;
            row["AlPostCodeAddr"] = addrRaw.PostalCode ;
            row["AlStateProvAddr"] = addrRaw.StateProv;
            //if(row["UntType"] != DBNull.Value)addrRaw.UntType=row["UntType"].ToString();
            row["AlPortAddr"] = addrRaw.PortStation;
            //row["AlZoneAddr"] = addrRaw.;
            return row;
        }

        protected DataRow SetCntnrsRowXMLFPS(Trax.FPS.v1.Types.ShpmtEqpmtRaw shpmtEqpmtRaw, DataRow row)
        {            
            row["CntnrKey"] =shpmtEqpmtRaw.CntnrKey;
            //if (row["EqpmtOwnerName"] != DBNull.Value) shpmtEqpmtRaw.EqpmtOwnerName = row["EqpmtOwnerName"].ToString();
            if (shpmtEqpmtRaw.EqpmtQty.HasValue)
                row["CntnrQty"] = shpmtEqpmtRaw.EqpmtQty;
            row["CntnrSize"] = shpmtEqpmtRaw.EqpmtSize;
            row["CntnrType"] = shpmtEqpmtRaw.EqpmtType;
            row["CntnrNum"] = shpmtEqpmtRaw.InstNum;
            //if (row["LocalEqpmtId"] != DBNull.Value) shpmtEqpmtRaw.LocalEqpmtId = row["LocalEqpmtId"].ToString();
            row["FbId"] = shpmtEqpmtRaw.LocalUntNId.Value.ToString(); 
            //if (row["NormEqpmtSize"] != DBNull.Value) shpmtEqpmtRaw.NormEqpmtSize = row["NormEqpmtSize"].ToString();
            //if (row["NormEqpmtType"] != DBNull.Value) shpmtEqpmtRaw.NormEqpmtType = row["NormEqpmtType"].ToString();
            //if (row["UntType"] != DBNull.Value) shpmtEqpmtRaw.UntType = row["UntType"].ToString();
            //if (row["VehicleKey"] != DBNull.Value) shpmtEqpmtRaw.VehicleKey = row["VehicleKey"].ToString();
            //if (row["VesselName"] != DBNull.Value) shpmtEqpmtRaw.VesselName = row["VesselName"].ToString();
            return row;
        }

        protected DataRow SetProdDtlRowXMLFPS(Trax.FPS.v1.Types.ProdDtl prodDtl, DataRow row)
        {
            if (prodDtl.HazmatFlag.HasValue)
                row["HazmatFlag"] = prodDtl.HazmatFlag;
            row["HazmatType"] = prodDtl.HazmatType;
            row["ProdInstNum"] = prodDtl.InstNum ;
            row["FbId"]=prodDtl.LocalUntNId.Value.ToString();
            if (prodDtl.OverDimFlag.HasValue)
                row["OverDimFlag"] = prodDtl.OverDimFlag;
            row["ProdDesc"]= prodDtl.ProdDesc ;
            row["ProdDim"]=prodDtl.ProdDim;
            row["ProdDimUom"]=prodDtl.ProdDimUom ;
            if (prodDtl.ProdGrossWt.HasValue)
                row["ProdGrossWt"] = prodDtl.ProdGrossWt;
            row["ProdKey"]=prodDtl.ProdKey ;
            row["ProdLine"]=prodDtl.ProdLine ;
            //row["ProdMarket"]=prodDtl.ProdMarket ;
            if (prodDtl.ProdNetWt.HasValue)
                row["ProdNetWt"] = prodDtl.ProdNetWt;
            if (prodDtl.ProdPcsCnt.HasValue)
                row["ProdPcsCnt"] = prodDtl.ProdPcsCnt;
            if (prodDtl.ProdTotalAmt.HasValue)
                row["ProdTotalAmt"] = prodDtl.ProdTotalAmt;
            row["ProdTotalCurr"]=prodDtl.ProdTotalCurr ;
            row["ProdType"]=prodDtl.ProdType ;
            if (prodDtl.ProdUnitAmt.HasValue)
                row["ProdUnitAmt"] = prodDtl.ProdUnitAmt;
            row["ProdUnitCurr"]=prodDtl.ProdUnitCurr ;
            if (prodDtl.ProdVol.HasValue)
                row["ProdVol"] = prodDtl.ProdVol;
            row["ProdVolUom"]=prodDtl.ProdVolUom ;
            row["ProdWtUom"]=prodDtl.ProdWtUom ;
            row["UntType"]=prodDtl.UntType ;
            return row;
        }

        protected DataRow SetFbLnRowXMLFPS(Trax.FPS.v1.Types.FbLn fbLine, DataRow row)
        {
            //if(row["AdjmReasonCode"] != DBNull.Value)
            //    fbLine.AdjmReasonCode=row["AdjmReasonCode"].ToString();
            //if(row["AdjmReasonDesc"] != DBNull.Value)
            //    fbLine.AdjmReasonDesc=row["AdjmReasonDesc"].ToString();
            //if(row["AppAmt"] != DBNull.Value)
            //    fbLine.AppAmt=Convert.ToDecimal(row["AppAmt"]);
            //if(row["BatKey"] != DBNull.Value)
            //    fbLine.BatKey=row["BatKey"].ToString();
            row["Cat"]=fbLine.Cat;
            //if(row["CatSeqNum"] != DBNull.Value)
            //    fbLine.CatSeqNum=Convert.ToInt16(row["CatSeqNum"]);
            if (fbLine.ChrgAmt.HasValue)
                row["ChrgAmt"] = fbLine.ChrgAmt;
            row["ChrgDesc"] = fbLine.ChrgDesc;
            row["CmdtyClass"]=fbLine.CmdtyClass;
            row["CurrencyQual"]=fbLine.CurrencyQual ;
            //if(row["CustLnChrgCode"] != DBNull.Value)
            //    fbLine.CustLnChrgCode=row["CustLnChrgCode"].ToString();
            row["LnDim"]=fbLine.DimData ;
            row["LnDimQual"]=fbLine.DimUom ;
            if (fbLine.ExchRate.HasValue)
                row["ExchRate"] = fbLine.ExchRate;
            row["Facsimile01"]=fbLine.Facsimile01 ;
            row["Facsimile02"]=fbLine.Facsimile02 ;
            row["FbId"]=fbLine.FbId ;
            //if(row["FbLineItemFlag"] != DBNull.Value)
            //    fbLine.FbLineItemFlag=Convert.ToBoolean(row["FbLineItemFlag"]);
            row["LineItemNum"]=fbLine.LineItemNum ;
            if (fbLine.LnActualWt.HasValue)
                row["LnActualWt"] = fbLine.LnActualWt;
            //if(row["LnBasis"] != DBNull.Value)
            //    fbLine.LnBasis=Convert.ToSingle(row["LnBasis"]);
            //if(row["LnBasisQual"] != DBNull.Value)
            //    fbLine.LnBasisQual=row["LnBasisQual"].ToString();
            row["LnChrgCode"]=fbLine.LnChrgCode ;
            //if(row["LnDeclAmt"] != DBNull.Value)
            //    fbLine.LnDeclAmt=Convert.ToDecimal(row["LnDeclAmt"]);
            //if(row["LnRateAsQual"] != DBNull.Value)
            //    fbLine.LnRateAsQual=row["LnRateAsQual"].ToString();
            if (fbLine.LnRateAsWt.HasValue)
                row["LnRateAsWt"] = fbLine.LnRateAsWt;
            //if(row["LnVendRateScale"] != DBNull.Value)
            //    fbLine.LnVendRateScale=row["LnVendRateScale"].ToString();
            if (fbLine.LocalAmt.HasValue)
                row["LocalAmt"] = fbLine.LocalAmt;
            row["LocalCurrencyQual"] = fbLine.LocalCurrencyQual;
            //if(row["MsgGrpNum"] != DBNull.Value)
            //    fbLine.MsgGrpNum=row["MsgGrpNum"].ToString();
            if (fbLine.PcsCnt.HasValue)
                row["PcsCnt"] = fbLine.PcsCnt;
            row["PkgType"]=fbLine.PkgType ;
            row["QtyLabl"]=fbLine.QtyLabl ;
            if (fbLine.RateAmt.HasValue)
                row["RateAmt"] = fbLine.RateAmt;
            //if(row["RateCpntId"] != DBNull.Value)
            //    fbLine.RateCpntId=row["RateCpntId"].ToString();
            //if(row["RatePerUntCnt"] != DBNull.Value)
            //    fbLine.RatePerUntCnt=Convert.ToInt32(row["RatePerUntCnt"]);
            row["RateType"]=fbLine.RateType ;
            row["RateUntLabl"]=fbLine.RateUntLabl ;
            row["T001"]=fbLine.T001 ;
            row["T002"]=fbLine.T002 ;
            row["T003"]=fbLine.T003 ;
            row["T004"]=fbLine.T004 ;
            row["T005"]=fbLine.T005 ;
            row["T006"]=fbLine.T006 ;
            if (fbLine.TaxableFlag.HasValue)
                row["Taxable"] = fbLine.TaxableFlag;
            //if(row["TxActualWt"] != DBNull.Value)
            //    fbLine.TxActualWt=Convert.ToSingle(row["TxActualWt"]);
            //if(row["TxDimVol"] != DBNull.Value)
            //    fbLine.TxDimVol=Convert.ToDouble(row["TxDimVol"]);
            //if(row["TxDimWt"] != DBNull.Value)
            //    fbLine.TxDimWt=Convert.ToSingle(row["TxDimWt"]);
            //if(row["TxFnclWt"] != DBNull.Value)
            //    fbLine.TxFnclWt=Convert.ToSingle(row["TxFnclWt"]);
            //if(row["TxLineItemFlag"] != DBNull.Value)
            //    fbLine.TxLineItemFlag=Convert.ToBoolean(row["TxLineItemFlag"]);
            //if(row["TxRateAmt"] != DBNull.Value)
            //    fbLine.TxRateAmt=Convert.ToDecimal(row["TxRateAmt"]);
            row["VendDesc"]=fbLine.VendDesc ;
            if (fbLine.Vol.HasValue)
                row["LnVol"] = fbLine.Vol;
            row["LnVolQual"]=fbLine.VolUom ;
            return row;
        }
        */


        protected Trax.FPS.v1.Types.Batch SetInvBatPropertiesXMLFPS(Trax.FPS.v1.Types.Batch invoiceBat, DataRow row)
        {
            
            //row["BatAdjmAmt"]=invoiceBat.
            //row["BatAdjmCnt"]=invoiceBat.
            if(row["BatAmt"] != DBNull.Value)
                invoiceBat.BatAmt = Convert.ToDecimal(row["BatAmt"]);
            //row["BatAppAmt"]=invoiceBat.
            if (row["BatCreatDtm"] != DBNull.Value)
                invoiceBat.BatCreatDtm = Convert.ToDateTime(row["BatCreatDtm"]);
            //row["BatCreditAmt"]=invoiceBat.            
            if (row["BatCurrencyQual"] != DBNull.Value)
                invoiceBat.BatCurrencyQual = row["BatCurrencyQual"].ToString();
            //row["BatDisputeAmt"]=invoiceBat.BatDisputeAmt
            //row["BatDueDtm"]=invoiceBat.BatDueDtm
            if (row["BatFbCnt"] != DBNull.Value)
                invoiceBat.BatFbCnt = Convert.ToInt16(row["BatFbCnt"]);
            if (row["BatId"] != DBNull.Value)
                invoiceBat.BatId = row["BatId"].ToString();
            if (row["BatInvCnt"] != DBNull.Value)
                invoiceBat.BatInvCnt = Convert.ToInt16(row["BatInvCnt"]);
            if (row["BatKey"] != DBNull.Value)
                invoiceBat.BatKey = row["BatKey"].ToString();
            if (row["BatLocIdRemit"] != DBNull.Value)
                invoiceBat.BatLocIdRemit = row["BatLocIdRemit"].ToString();
            //row["BatMsgCtrlDtm"]=invoiceBat.
            //row["BatMsgCtrlPodDtm"]=invoiceBat.
            //row["BatMsgCtrlRouteLabl"]=invoiceBat.
            //row["BatMsgCtrlSnapCnt"]=invoiceBat.
            //row["BatMsgCtrlStat"]=invoiceBat.
            //row["BatMsgCtrlType"]=invoiceBat.
            //row["BatOpenAmt"]=invoiceBat.
            //row["BatPaymtCnt"]=invoiceBat.
            //row["BatPdAmt"]=invoiceBat.
            //row["BatSnapCnt"]=invoiceBat.
            if (row["BatStat"] != DBNull.Value)
                invoiceBat.BatStat = row["BatStat"].ToString();
            //row["BatSuspendAmt"]=invoiceBat.
            //row["BatSuspendCnt"]=invoiceBat.
            if (row["BatType"] != DBNull.Value)
                invoiceBat.BatType = row["BatType"].ToString();
            //row["BatVoidFlag"]=invoiceBat.        
            //row["ImgDpFileDtm"]=invoiceBat.
            //row["ImgDpFileGrp"]=invoiceBat.
            //row["ImgDpFileName"]=invoiceBat.        
            //row["MsgGrpNum"]=invoiceBat.
            //row["MsgGrpNumHist"]=invoiceBat.
            //row["MsgGrpOrigHist"]=invoiceBat.            
            if (row["OwnerKey"] != DBNull.Value)
                invoiceBat.OwnerKey = row["OwnerKey"].ToString();
            //row["RuleProcessAfterDtm"]=invoiceBat.
            //row["RuleProcessCycCnt"]=invoiceBat.
            //row["VendBatAmt"]=invoiceBat.
            if (row["VendBatDtm"] != DBNull.Value)
                invoiceBat.VendBatDtm = Convert.ToDateTime(row["VendBatDtm"]);
            if (row["VendBatKey"] != DBNull.Value)
                invoiceBat.VendBatKey = row["VendBatKey"].ToString();
            if (row["VendFeed"] != DBNull.Value)
                invoiceBat.VendFeed = row["VendFeed"].ToString();
            if (row["VendLabl"] != DBNull.Value)
                invoiceBat.VendLabl = row["VendLabl"].ToString();
            return invoiceBat;
        }

        protected Trax.FPS.v1.Types.Invoice SetInvoicePropertiesXMLFPS(Trax.FPS.v1.Types.Invoice invoice, DataRow row)
        {
            //if(row["AcctIdVendBlng"] != DBNull.Value) 
            //    invoice.AcctIdVendBlng=row["AcctIdVendBlng"] .ToString();
            //row["AcctNumBlng"]= invoice.
            if(row["AcctNumVendBlng"]!= DBNull.Value)
                invoice.AcctNumVendBlng=row["AcctNumVendBlng"].ToString();
            if(row["AlBlng1"]!= DBNull.Value)
                invoice.AlBlng1=row["AlBlng1"].ToString();
            if(row["AlBlng2"]!= DBNull.Value)
                invoice.AlBlng2=row["AlBlng2"].ToString();
            if(row["AlBlng3"]!= DBNull.Value)
                invoice.AlBlng3=row["AlBlng3"].ToString();
            if(row["AlBlng4"]!= DBNull.Value)
                invoice.AlBlng4=row["AlBlng4"].ToString();
            //row["AlBlngQual"]= invoice.
            if(row["AlCityBlng"]!= DBNull.Value)
                invoice.AlCityBlng=row["AlCityBlng"].ToString();
            if(row["AlCityRemit"]!= DBNull.Value)
                invoice.AlCityRemit=row["AlCityRemit"].ToString();
            if(row["AlCntryCodeBlng"]!= DBNull.Value)
                invoice.AlCntryCodeBlng=row["AlCntryCodeBlng"].ToString();
            if(row["AlCntryCodeRemit"]!= DBNull.Value)
                invoice.AlCntryCodeRemit=row["AlCntryCodeRemit"].ToString();
            //row["AlPhoneExtBlng"]= invoice.
            //row["AlPhoneExtRemit"]= invoice.
            //row["AlPhoneNumBlng"]= invoice.
            //row["AlPhoneNumRemit"]= invoice.
            if(row["AlPostCodeBlng"]!= DBNull.Value)
                invoice.AlPostCodeBlng=row["AlPostCodeBlng"].ToString();
            if(row["AlPostCodeRemit"]!= DBNull.Value)
                invoice.AlPostCodeRemit=row["AlPostCodeRemit"].ToString();
            if(row["AlRemit1"]!= DBNull.Value)
                invoice.AlRemit1=row["AlRemit1"].ToString();
            if(row["AlRemit2"]!= DBNull.Value)
                invoice.AlRemit2=row["AlRemit2"].ToString();
            if(row["AlRemit3"]!= DBNull.Value)
                invoice.AlRemit3=row["AlRemit3"].ToString();
            if(row["AlRemit4"]!= DBNull.Value)
                invoice.AlRemit4=row["AlRemit4"].ToString();
            //row["AlRemitQual"]= invoice.
            if(row["AlStateProvBlng"]!= DBNull.Value)
                invoice.AlStateProvBlng=row["AlStateProvBlng"].ToString();
            if(row["AlStateProvRemit"]!= DBNull.Value)
                invoice.AlStateProvRemit=row["AlStateProvRemit"].ToString();
            //row["AuthKey"]= invoice.        
            if(row["BatId"]!= DBNull.Value)
                invoice.BatId=row["BatId"].ToString();
            //row["BatKey"]= invoice.
            //row["EntityBlng"]= invoice.
            //row["ErpVendCode"]= invoice.
            if (row["ImgPageCnt"] != DBNull.Value && row["ImgPageCnt"].ToString().Trim() != string.Empty)//row["ImgPageCnt", System.Type.GetType("System.Int32")]= invoice.
                invoice.ImgPageCnt = Convert.ToInt16(row["ImgPageCnt"]);
            if(row["InvPageNum"]!= DBNull.Value && row["InvPageNum"].ToString().Trim() != string.Empty)
                invoice.ImgPageNum=Convert.ToInt16(row["InvPageNum"]);
            //row["InvAdjmAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvAdjmCnt", System.Type.GetType("System.Int32")]= invoice.
            if (row["InvAmt"] != DBNull.Value && row["InvAmt"].ToString().Trim() != string.Empty)
                invoice.InvAmt=Convert.ToDecimal(row["InvAmt"]);
            //row["InvAppAmt", System.Type.GetType("System.Decimal")]= invoice.
            if (row["InvCreatDtm"] != DBNull.Value && row["InvCreatDtm"].ToString().Trim() != string.Empty)
                invoice.InvCreatDtm=Convert.ToDateTime(row["InvCreatDtm"]);
            //row["InvCreditAmt", System.Type.GetType("System.Decimal")]= invoice.
            if(row["InvCurrencyQual"]!= DBNull.Value)
                invoice.InvCurrencyQual=row["InvCurrencyQual"].ToString();
            //row["InvDisputeAmt", System.Type.GetType("System.Decimal")]= invoice.
            if (row["InvDueDtm"] != DBNull.Value && row["InvDueDtm"].ToString().Trim() != string.Empty)
                invoice.InvDueDtm=Convert.ToDateTime(row["InvDueDtm"]);
            //row["InvDupAdjmDesc"]= invoice.
            //row["InvDupAdjmReason"]= invoice.
            //row["InvDupCapAppAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvDupManualRslt"]= invoice.
            //row["InvDupPattern"]= invoice.
            //row["InvDupRslt"]= invoice.
            //row["InvDupType"]= invoice.
            if (row["InvFbCnt"] != DBNull.Value && row["InvFbCnt"].ToString().Trim() != string.Empty)
                invoice.InvFbCnt=Convert.ToInt16(row["InvFbCnt"]);
            if (row["InvId"] != DBNull.Value)
                invoice.InvId = row["InvId"].ToString();
            if (row["InvKey"] != DBNull.Value)
                invoice.InvKey = row["InvKey"].ToString();
            //row["InvKeyBase"]= invoice.
            //row["InvKeyPfx"]= invoice.
            //row["InvKeySfx"]= invoice.
            //row[" long InvNId"]= invoice.
            if (row["InvBeforeTaxAmt"] != DBNull.Value && row["InvBeforeTaxAmt"].ToString().Trim() != string.Empty)//row["InvBeforeTaxAmt"]= invoice.InvNonTaxAmt//row["InvNonTaxAmt", System.Type.GetType("System.Decimal")]= invoice.
                invoice.InvNonTaxAmt=Convert.ToDecimal(row["InvBeforeTaxAmt"]);
            //row["InvOpenAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvOrigId"]= invoice.
            //row["InvPaymtCnt", System.Type.GetType("System.Int32")]= invoice.
            //row["InvPdAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["InvPdDtm"]= invoice.
            if(row["InvStat"]!= DBNull.Value)
                invoice.InvStat=row["InvStat"].ToString();
            if(row["InvType"]!= DBNull.Value)
                invoice.InvType=row["InvType"].ToString();
            //row["InvVoidFlag"]= invoice.
            if(row["LocIdBlng"]!= DBNull.Value)
                invoice.LocIdBlng=row["LocIdBlng"].ToString();
            if(row["LocIdRemit"]!= DBNull.Value)
                invoice.LocIdRemit=row["LocIdRemit"].ToString();
            //row["LocKeyBlng"]= invoice.
            //row["LocKeyRemit"]= invoice.
            //row["MsgGrpNum"]= invoice.
            //row["NormalizedScac"]= invoice.
            //row["OwnerKey"]= invoice.
            //row["PaymtDscntReasonCode"]= invoice.
            //row["PaymtDscntReasonDesc"]= invoice.
            //row["SpotQuoteAmt", System.Type.GetType("System.Decimal")]= invoice.
            //row["SpotQuoteKey"]= invoice.
            if (row["InvTaxAmt"] != DBNull.Value && row["InvTaxAmt"].ToString().Trim() != string.Empty)//row["InvTaxAmt"]= invoice.TaxAmt//row["TaxAmt", System.Type.GetType("System.Decimal")]= invoice.
                invoice.TaxAmt=Convert.ToDecimal(row["InvTaxAmt"]);
            //row["TaxRegCntryBlng"]= invoice.
            //row["TaxRegCntryVend"]= invoice.
            if (row["VendTaxKey"] != DBNull.Value)
                invoice.TaxRegKeyBlng = row["VendTaxKey"].ToString();//row["TaxRegKeyBlng"].ToString();
            if (row["CustTaxKey"] != DBNull.Value)//row["VendTaxKey"]= invoice.TaxRegKeyVend//row["TaxRegKeyVend"]= invoice.
                invoice.TaxRegKeyVend = row["CustTaxKey"].ToString();//row["VendTaxKey"].ToString();
            //row["VendBatKey"]= invoice.
            if (row["VendInvAmt"] != DBNull.Value && row["VendInvAmt"].ToString().Trim() != string.Empty)
                invoice.VendInvAmt=Convert.ToDecimal(row["VendInvAmt"]);
            //row["VendInvDueDtm"]= invoice.
            if(row["VendLabl"]!= DBNull.Value)
                invoice.VendLabl=row["VendLabl"].ToString();
            if(row["VendName"] != DBNull.Value)
                invoice.VendName = row["VendName"].ToString();

            return invoice;
        }

        protected Trax.FPS.v1.Types.FrghtBl SetFrghtBlPropertiesXMLFPS(Trax.FPS.v1.Types.FrghtBl freightBill, DataRow row)
        {            
            if(row["AcctNumVendBlng"] != DBNull.Value) 
                freightBill.AcctNumVendBlng=row["AcctNumVendBlng"] .ToString();
            //row["AcctNumVendDest"] = freightBill.
            //row["AcctNumVendOrig"] = freightBill.        
            if(row["AlCityDest"] != DBNull.Value) 
                freightBill.AlCityDest=row["AlCityDest"] .ToString();
            if(row["AlCityOrig"] != DBNull.Value) 
                freightBill.AlCityOrig=row["AlCityOrig"] .ToString();
            if(row["AlCntryCodeDest"] != DBNull.Value) 
                freightBill.AlCntryCodeDest=row["AlCntryCodeDest"] .ToString();
            if(row["AlCntryCodeOrig"] != DBNull.Value) 
                freightBill.AlCntryCodeOrig=row["AlCntryCodeOrig"] .ToString();
            if(row["AlDest1"] != DBNull.Value) 
                freightBill.AlDest1=row["AlDest1"] .ToString();
            if(row["AlDest2"] != DBNull.Value) 
                freightBill.AlDest2=row["AlDest2"] .ToString();
            if(row["AlDest3"] != DBNull.Value) 
                freightBill.AlDest3=row["AlDest3"] .ToString();
            if(row["AlDest4"] != DBNull.Value) 
                freightBill.AlDest4=row["AlDest4"] .ToString();
            //row["AlDestQual"] = freightBill.
            //row["ALineContext"] = freightBill.
            if(row["AlOrig1"] != DBNull.Value) 
                freightBill.AlOrig1=row["AlOrig1"] .ToString();
            if(row["AlOrig2"] != DBNull.Value) 
                freightBill.AlOrig2=row["AlOrig2"] .ToString();
            if(row["AlOrig3"] != DBNull.Value) 
                freightBill.AlOrig3=row["AlOrig3"] .ToString();
            if(row["AlOrig4"] != DBNull.Value) 
                freightBill.AlOrig4=row["AlOrig4"] .ToString();
            //row["AlOrigQual"] = freightBill.
            //row["AlPhoneExtDest"] = freightBill.
            //row["AlPhoneExtOrig"] = freightBill.
            //row["AlPhoneNumDest"] = freightBill.
            //row["AlPhoneNumOrig"] = freightBill.
            if(row["AlPostCodeDest"] != DBNull.Value) 
                freightBill.AlPostCodeDest=row["AlPostCodeDest"] .ToString();
            if(row["AlPostCodeOrig"] != DBNull.Value) 
                freightBill.AlPostCodeOrig=row["AlPostCodeOrig"] .ToString();
            if(row["AlStateProvDest"] != DBNull.Value) 
                freightBill.AlStateProvDest=row["AlStateProvDest"] .ToString();
            if(row["AlStateProvOrig"] != DBNull.Value) 
                freightBill.AlStateProvOrig=row["AlStateProvOrig"] .ToString();
            //row["AsnRatedAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["AsnRatedCurrencyQual"] = freightBill.
            //row["AsnWt"] = freightBill.//public float? 
            //row["AsnWtQual"] = freightBill.        
            //row["AuthKey"] = freightBill.        
            //row["BatId"] = freightBill.
            //row["BatKey"] = freightBill.
            //row["BmDiv"] = freightBill.
            //row["BmEntity"] = freightBill.
            //row["BmSubDiv"] = freightBill.
            //row["BmSubEntity"] = freightBill.
            //row["Bol1Raw"] = freightBill.
            //row["BolNumKey"] = freightBill.
            //row["BundleNum"] = freightBill.
            //row["BusinessFlow"] = freightBill.
            //row["BusinessProgram"] = freightBill.
            //row["BusinessUnit"] = freightBill.
            //row["BusinessUnitRule"] = freightBill.        
            //row["CaInfo1Raw"] = freightBill.
            //row["CaInfo2Raw"] = freightBill.
            //row["CaModel"] = freightBill.
            //row["CaRule"] = freightBill.
            //row["ContractNum"] = freightBill.
            //row["CurrEntity"] = freightBill.
            //row["CurrState"] = freightBill.
            //row["CustMode"] = freightBill.
            //row["CustSrvcCode"] = freightBill.
            //row["CustSrvcName"] = freightBill.
            //row["DenialEnv"] = freightBill.
            //row["DenialPhase"] = freightBill.//public byte? 
            //row["DeniedFlag"] = freightBill.
            if(row["FbDim"] != DBNull.Value) 
                freightBill.DimData=row["FbDim"].ToString();//row["DimData"] = freightBill.
            if (row["FbDimFactor"] != DBNull.Value && row["FbDimFactor"].ToString().Trim() != string.Empty) 
                freightBill.DimFactor=Convert.ToDecimal(row["FbDimFactor"]);//row["DimFactor", System.Type.GetType("System.Decimal")] = freightBill.
            if(row["FbDimQual"] != DBNull.Value) 
                freightBill.DimUom = row["FbDimQual"].ToString();//row["DimUom"] = freightBill.=
            //row["DirectIndirectCode"] = freightBill.
            //row["EntTypeBlng"] = freightBill.
            //row["EntTypeCons"] = freightBill.
            //row["EntTypeShpr"] = freightBill.
            if (row["FbExchDtm"] != DBNull.Value && row["FbExchDtm"].ToString().Trim() != string.Empty) 
                freightBill.ExchDate = Convert.ToDateTime(row["FbExchDtm"]);
            if (row["FbExchRate"] != DBNull.Value && row["FbExchRate"].ToString().Trim() != string.Empty) 
                freightBill.ExchRate = Convert.ToDecimal(row["FbExchRate"]);
            //row["ExDesc"] = freightBill.
            //row["ExDtlInfo"] = freightBill.        
            if (row["FbAccAmt"] != DBNull.Value && row["FbAccAmt"].ToString().Trim() != string.Empty) 
                freightBill.FbAccAmt=Convert.ToDecimal(row["FbAccAmt"]);
            if (row["FbActualWt"] != DBNull.Value && row["FbActualWt"].ToString().Trim() != string.Empty) 
                freightBill.FbActualWt=Convert.ToSingle(row["FbActualWt"]);
            //row["FbAdjmAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAdjmCnt"] = freightBill.//public short? 
            //row["FbAdjmDesc"] = freightBill.
            //row["FbAdjmReason"] = freightBill.
            if (row["FbAmt"] != DBNull.Value && row["FbAmt"].ToString().Trim() != string.Empty) 
                freightBill.FbAmt=Convert.ToDecimal(row["FbAmt"]);
            //row["FbAppAccAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppCurrencyQual"] = freightBill.
            //row["FbAppDscntAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppFrghtAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppRptFactor", System.Type.GetType("System.Single")] = freightBill.
            //row["FbAppTaxAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbAppTaxPcnt", System.Type.GetType("System.Single")] = freightBill.
            //row["FbBrkPtWt", System.Type.GetType("System.Single")] = freightBill.
            //row["FbClass"] = freightBill.
            if (row["FbCreatDtm"] != DBNull.Value && row["FbCreatDtm"].ToString().Trim() != string.Empty) 
                freightBill.FbCreatDtm=Convert.ToDateTime(row["FbCreatDtm"]);
            //row["FbCreditAmt", System.Type.GetType("System.Decimal")] = freightBill.
            if(row["FbCurrencyQual"] != DBNull.Value) 
                freightBill.FbCurrencyQual=row["FbCurrencyQual"] .ToString();
            //row["FbDeclAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbDimWt", System.Type.GetType("System.Single")] = freightBill.
            //row["FbDisputeAmt", System.Type.GetType("System.Decimal")] = freightBill.
            if (row["FbDscntAmt"] != DBNull.Value && row["FbDscntAmt"].ToString().Trim() != string.Empty) 
                freightBill.FbDscntAmt=Convert.ToDecimal(row["FbDscntAmt"]);
            //row["FbDueDtm"] = freightBill.
            //row["FbDuFlag"] = freightBill.
            //row["FbDupAdjmDesc"] = freightBill.
            //row["FbDupAdjmReason"] = freightBill.
            //row["FbDupCapAppAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbDupManualRslt"] = freightBill.
            //row["FbDupPattern"] = freightBill.
            //row["FbDupRslt"] = freightBill.
            //row["FbDupType"] = freightBill.
            if (row["FbFnclWt"] != DBNull.Value && row["FbFnclWt"].ToString().Trim() != string.Empty) 
                freightBill.FbFnclWt=Convert.ToSingle(row["FbFnclWt"]);
            if (row["FbFrghtAmt"] != DBNull.Value && row["FbFrghtAmt"].ToString().Trim() != string.Empty) 
                freightBill.FbFrghtAmt=Convert.ToDecimal(row["FbFrghtAmt"]);
            if(row["FbId"] != DBNull.Value) 
                freightBill.FbId=row["FbId"] .ToString();
            if(row["FbKey"] != DBNull.Value)
                freightBill.FbKey = row["FbKey"].ToString();
            //row["FbKeyBase"] = freightBill.
            //row["FbKeyPfx"] = freightBill.
            //row["FbKeySfx"] = freightBill.
            if (row["FbLnCnt"] != DBNull.Value && row["FbLnCnt"].ToString().Trim() != string.Empty) 
                freightBill.FbLnCnt=Convert.ToInt16(row["FbLnCnt"]);//public short?
            //row["FbNId"] = freightBill.//public long 
            //row["FbOpenAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbParentId"] = freightBill.
            //row["FbPaymtCnt"] = freightBill.//public short? 
            if(row["FbPaymtTermsCode"] != DBNull.Value) 
                freightBill.FbPaymtTermsCode=row["FbPaymtTermsCode"] .ToString();
            if (row["FbPcsCnt"] != DBNull.Value && row["FbPcsCnt"].ToString().Trim() != string.Empty) 
                freightBill.FbPcsCnt=Convert.ToInt32(row["FbPcsCnt"]);
            //row["FbPdAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["FbPendingReason"] = freightBill.
            //row["FbPendingReasonDesc"] = freightBill.
            if(row["FbPkgType"] != DBNull.Value) 
                freightBill.FbPkgType=row["FbPkgType"].ToString();
            //row["FbRecycleFromId"] = freightBill.
            //row["FbRecycleReasonInfo"] = freightBill.
            //row["FbRptFactor", System.Type.GetType("System.Single")] = freightBill.
            //row["FbStat"] = freightBill.
            if (row["FbTaxAmt"] != DBNull.Value && row["FbTaxAmt"].ToString().Trim() != string.Empty) 
                freightBill.FbTaxAmt=Convert.ToDecimal(row["FbTaxAmt"]);
            //row["FbTerms"] = freightBill.
            if(row["FbType"] != DBNull.Value) 
                freightBill.FbType=row["FbType"] .ToString();
            //row["FbVoidFlag"] = freightBill.
            if(row["FbWtQual"] != DBNull.Value) 
                freightBill.FbWtQual=row["FbWtQual"] .ToString();
            //row["ForceFaExFlag"] = freightBill.
            //row["GlModel"] = freightBill.
            //row["GlRule"] = freightBill.
            //row["ImageURI"] = freightBill.
            if (row["ImgPageCnt"] != DBNull.Value && row["ImgPageCnt"].ToString().Trim() != string.Empty) //row["ImgPageCnt", System.Type.GetType("System.Int32")] = freightBill.
                freightBill.ImgPageCnt = Convert.ToInt32(row["ImgPageCnt"]);
            if (row["FbPageNum"] != DBNull.Value && row["FbPageNum"].ToString().Trim() != string.Empty) 
                freightBill.ImgPageNum=Convert.ToInt32(row["FbPageNum"]);//row["ImgPageNum", System.Type.GetType("System.Int32")] = freightBill.
            if(row["IncoTerms"] != DBNull.Value) 
                freightBill.IncoTerms=row["IncoTerms"] .ToString();
            if (row["InterlineAmt"] != DBNull.Value && row["InterlineAmt"].ToString().Trim() != string.Empty) 
                freightBill.InterlineAmt=Convert.ToDecimal(row["InterlineAmt"]);
            if(row["InterlineQual"] != DBNull.Value) 
                freightBill.InterlineQual=row["InterlineQual"] .ToString();
            if(row["InterlineScac"] != DBNull.Value) 
                freightBill.InterlineScac=row["InterlineScac"] .ToString();
            //row["InternationalFlag"] = freightBill.
            //row["InterStateProvFlag"] = freightBill.
            //row["IntraStateProvFlag"] = freightBill.
            if(row["InvId"] != DBNull.Value) 
                freightBill.InvId=row["InvId"] .ToString();
            if (row["InvKey"] != DBNull.Value)
                freightBill.InvKey = row["InvKey"].ToString();
            if (row["LmAtaDtm"] != DBNull.Value && row["LmAtaDtm"].ToString().Trim() != string.Empty) 
                freightBill.LmAtaDtm=Convert.ToDateTime(row["LmAtaDtm"]);
            //row["LmAtaEtaVarncLabl"] = freightBill.
            //row["LmAtaEtaVarncReason"] = freightBill.
            if (row["LmDist"] != DBNull.Value && row["LmDist"].ToString().Trim() != string.Empty) 
                freightBill.LmDist=Convert.ToInt16(row["LmDist"]);//public short? 
            if(row["LmDistQual"] != DBNull.Value) 
                freightBill.LmDistQual=row["LmDistQual"] .ToString();
            //row["LmDlvryReqDtm"] = freightBill.
            //row["LmEtaDtm"] = freightBill.
            //row["LmFirstDlvryDtm"] = freightBill.
            if(row["LmLaneLabl"] != DBNull.Value) 
                freightBill.LmLaneLabl=row["LmLaneLabl"] .ToString();
            if (row["LmPkupActualDtm"] != DBNull.Value && row["LmPkupActualDtm"].ToString().Trim() != string.Empty) 
                freightBill.LmPkupActualDtm=Convert.ToDateTime(row["LmPkupActualDtm"]);
            //row["LmPkupByDtm"] = freightBill.
            //row["LmPkupVarncLabl"] = freightBill.
            //row["LmPkupVarncReason"] = freightBill.
            //row["LmRdyDtm"] = freightBill.
            //row["LmReqKey"] = freightBill.
            //row["LmTransitStat"] = freightBill.
            if (row["FbLoadMeters"] != DBNull.Value && row["FbLoadMeters"].ToString().Trim() != string.Empty) 
                freightBill.LoadMeter = Convert.ToDecimal(row["FbLoadMeters"]);
            if(row["LocIdBlng"] != DBNull.Value) 
                freightBill.LocIdBlng=row["LocIdBlng"] .ToString();
            //row["LocIdCons"] = freightBill.
            //row["LocIdDest"] = freightBill.
            //row["LocIdOrig"] = freightBill.
            //row["LocIdShpr"] = freightBill.
            //row["LocKeyBlng"] = freightBill.
            //row["LocKeyCons"] = freightBill.
            //row["LocKeyDest"] = freightBill.
            //row["LocKeyOrig"] = freightBill.
            //row["LocKeyShpr"] = freightBill.
            //row["Mode"] = freightBill.
            //row["ModeType"] = freightBill.
            //row["MsgGrpNum"] = freightBill.
            //row["OmArea"] = freightBill.
            //row["OmDept"] = freightBill.
            //row["OmGrp"] = freightBill.
            //row["OmOrg"] = freightBill.
            //row["OmTeam"] = freightBill.
            //row["OwnerKey"] = freightBill.
            //row["PaymtDscntReasonCode"] = freightBill.
            //row["PaymtDscntReasonDesc"] = freightBill.
            //row["PodSignBy"] = freightBill.
            //if(row["PortDest"] != DBNull.Value) 
            //    freightBill.PortDest=row["PortDest"] .ToString();
            //if(row["PortOrig"] != DBNull.Value) 
            //    freightBill.PortOrig=row["PortOrig"] .ToString();
            if(row["PriceLaneLabl"] != DBNull.Value) 
                freightBill.PriceLaneLabl=row["PriceLaneLabl"] .ToString();
            //row["RoleDest"] = freightBill.
            //row["RoleDestRule"] = freightBill.
            //row["RoleOrig"] = freightBill.
            //row["RoleOrigRule"] = freightBill.
            //row["RouteCityDest"] = freightBill.
            //row["RouteCityOrig"] = freightBill.
            //row["RouteCntryCodeDest"] = freightBill.
            //row["RouteCntryCodeOrig"] = freightBill.
            //row["RouteStateProvDest"] = freightBill.
            //row["RouteStateProvOrig"] = freightBill.
            //row["RuleBlWinner"] = freightBill.
            //row["RuleBolWinner"] = freightBill.
            //row["RuleCaWinner"] = freightBill.
            //row["RuleDestWinner"] = freightBill.
            //row["RuleDuWinner"] = freightBill.
            //row["RuleFaWinner"] = freightBill.
            //row["RuleLmWinner"] = freightBill.
            //row["RuleMpWinner"] = freightBill.
            //row["RuleOrigWinner"] = freightBill.
            //row["RuleRtWinner"] = freightBill.
            //row["ShpmtPurp"] = freightBill.
            //row["ShpmtPurpType"] = freightBill.
            if (row["FbSpotQuoteAmt"] != DBNull.Value && row["FbSpotQuoteAmt"].ToString().Trim() != string.Empty) 
                freightBill.SpotQuoteAmt=Convert.ToDecimal(row["FbSpotQuoteAmt"]); //row["SpotQuoteAmt", System.Type.GetType("System.Decimal")] = freightBill.
            if(row["FbSpotQuoteKey"] != DBNull.Value) 
                freightBill.SpotQuoteKey =row["FbSpotQuoteKey"].ToString();//row["SpotQuoteKey"] = freightBill.
            if (row["FbSpotQuoteCurrencyQual"] != DBNull.Value)//to be added once field is available.
                freightBill.SpotQuoteCurrencyQual = row["FbSpotQuoteCurrencyQual"].ToString();
            //row["SrvcLvl"] = freightBill.
            if(row["SrvcReqCode"] != DBNull.Value) 
                freightBill.SrvcReqCode=row["SrvcReqCode"] .ToString();
            //row["SrvcScope"] = freightBill.
            //row["SupplyChainArc"] = freightBill.
            //row["T001"] = freightBill.
            //row["T002"] = freightBill.
            //row["T003"] = freightBill.
            //row["T004"] = freightBill.
            //row["T005"] = freightBill.
            //row["T006"] = freightBill.
            //row["T007"] = freightBill.
            //row["T008"] = freightBill.
            //row["T009"] = freightBill.
            //row["T010"] = freightBill.
            //row["T011"] = freightBill.
            //row["T012"] = freightBill.
            //row["T013"] = freightBill.
            //row["T014"] = freightBill.
            //row["T015"] = freightBill.
            //row["T016"] = freightBill.
            //row["T017"] = freightBill.
            //row["T018"] = freightBill.
            //row["T019"] = freightBill.
            //row["T020"] = freightBill.
            //row["TransType"] = freightBill.
            //row["TxFbAccAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbBaseRate", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbBrkPtWt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbCurrencyQual"] = freightBill.
            //row["TxFbDimWt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbDscntAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbFnclWt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbFrghtAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbRptFactor", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbTaxAmt", System.Type.GetType("System.Decimal")] = freightBill.
            //row["TxFbTaxPcnt", System.Type.GetType("System.Single")] = freightBill.
            //row["TxFbWtQual"] = freightBill.
            //row["TxLmDir"] = freightBill.
            //row["TxLmDist"] = freightBill.//public short? 
            //row["TxLmDistQual"] = freightBill.
            //row["TxLmType"] = freightBill.
            //row["TxPaymtTermsCode"] = freightBill.
            //row["TxShpmtId"] = freightBill.
            //row["VendCommitCode"] = freightBill.
            //row["VendFbType"] = freightBill.
            if(row["VendLabl"] != DBNull.Value) 
                freightBill.VendLabl=row["VendLabl"] .ToString();
            //row["VendName"] = freightBill.
            //row["VendRateScale"] = freightBill.
            //row["VendSrvcCode"] = freightBill.
            //row["VendSrvcGuarCode"] = freightBill.
            if(row["VendSrvcName"] != DBNull.Value) 
                freightBill.VendSrvcName=row["VendSrvcName"] .ToString();
            if(row["VendSrvcScope"] != DBNull.Value) 
                freightBill.VendSrvcScope=row["VendSrvcScope"] .ToString();
            if (row["VendSrvcType"] != DBNull.Value)
                freightBill.VendSrvcType = row["VendSrvcType"].ToString();
            if(row["VendSrvcZone"] != DBNull.Value) 
                freightBill.VendSrvcZone=row["VendSrvcZone"] .ToString();
            //row["VendSupplyChainSrvc"] = freightBill.
            if(row["VendTariff"] != DBNull.Value) 
                freightBill.VendTariff=row["VendTariff"] .ToString();
            if (row["FbVol"] != DBNull.Value && row["FbVol"].ToString().Trim() != string.Empty) 
                freightBill.Vol=Convert.ToDecimal(row["FbVol"]);//row["Vol", System.Type.GetType("System.Decimal")] = freightBill.
            if(row["FbVolQual"] != DBNull.Value)
                freightBill.VolUom = row["FbVolQual"].ToString();//row["VolUom"] = freightBill.


            return freightBill;
        }

        protected Trax.FPS.v1.Types.KeyRaw SetKeyIdentsPropertiesXMLFPS(Trax.FPS.v1.Types.KeyRaw keyIdent, DataRow row)
        {
            //if (row["KeyNum"] != DBNull.Value && row["KeyNum"].ToString().Trim() != string.Empty)
            //    keyIdent.InstNum = Convert.ToInt32(row["KeyNum"]);
            //if(row["KeyBase"] != DBNull.Value)
            //    keyIdent.KeyBase=row["KeyBase"].ToString();
            if(row["KeyQual"] != DBNull.Value)
                keyIdent.KeyQual=row["KeyQual"].ToString();
            //if(row["KeySource"] != DBNull.Value)
            //    keyIdent.KeySource=row["KeySource"].ToString();
            //if(row["KeyType"] != DBNull.Value)
            //    keyIdent.KeyType=row["KeyType"].ToString();
            if(row["KeyVal"] != DBNull.Value)
                keyIdent.KeyVal=row["KeyVal"].ToString();
            if (row["FbId"] != DBNull.Value)
                keyIdent.LocalUntNId = Convert.ToInt64(row["FbId"].ToString().Substring(19, 4));
            //if(row["UntType"] != DBNull.Value)
            //    keyIdent.UntType=row["UntType"].ToString();
            //if(row["ValidKeyPattern"] != DBNull.Value)
            //    keyIdent.ValidKeyPattern=row["ValidKeyPattern"].ToString();
            //if(row["ValidKeyType"] != DBNull.Value)
            //    keyIdent.ValidKeyType=row["ValidKeyType"].ToString();
            return keyIdent;
        }

        protected Trax.FPS.v1.Types.AddrRaw SetAddrsPropertiesXMLFPS(Trax.FPS.v1.Types.AddrRaw addrRaw, DataRow row)
        {
            if (row["AlAddr1"] != DBNull.Value)
                addrRaw.AddrLine1 = row["AlAddr1"].ToString();
            if (row["AlAddr2"] != DBNull.Value)
                addrRaw.AddrLine2 = row["AlAddr2"].ToString();
            if (row["AlAddr3"] != DBNull.Value)
                addrRaw.AddrLine3 = row["AlAddr3"].ToString();
            if (row["AlAddr4"] != DBNull.Value)
                addrRaw.AddrLine4 = row["AlAddr4"].ToString();
            if (row["AddrCat"] != DBNull.Value)
                addrRaw.AddrType = row["AddrCat"].ToString();
            if (row["AlCntryCodeAddr"] != DBNull.Value)
                addrRaw.Country = row["AlCntryCodeAddr"].ToString();
            //if(row["GeoLatitude"] != DBNull.Value)addrRaw.GeoLatitude=row["GeoLatitude"].ToString();
            //if(row["GeoLocation"] != DBNull.Value)addrRaw.GeoLocation=row["GeoLocation"].ToString();
            //if(row["GeoLongitude"] != DBNull.Value)addrRaw.GeoLongitude=row["GeoLongitude"].ToString();
            //if(row["GeoRegion"] != DBNull.Value)addrRaw.GeoRegion=row["GeoRegion"].ToString();
            //if(row["GeoTerritory"] != DBNull.Value)addrRaw.GeoTerritory=row["GeoTerritory"].ToString();
            if (row["AddrNum"] != DBNull.Value && row["AddrNum"].ToString().Trim() != string.Empty)
                addrRaw.InstNum = Convert.ToInt32(row["AddrNum"]);
            //if(row["LocalAddrLocation"] != DBNull.Value)addrRaw.LocalAddrLocation=row["LocalAddrLocation"].ToString();
            if (row["FbId"] != DBNull.Value)
                addrRaw.LocalUntNId = Convert.ToInt64(row["FbId"].ToString().Substring(19, 4));
            //if(row["LocType"] != DBNull.Value)addrRaw.LocType=row["LocType"].ToString();
            //if(row["PartnerEntity"] != DBNull.Value)addrRaw.PartnerEntity=row["PartnerEntity"].ToString();
            if (row["AlCityAddr"] != DBNull.Value)
                addrRaw.PlaceName = row["AlCityAddr"].ToString();
            if (row["AlPostCodeAddr"] != DBNull.Value)
                addrRaw.PostalCode = row["AlPostCodeAddr"].ToString();
            if (row["AlStateProvAddr"] != DBNull.Value)
                addrRaw.StateProv = row["AlStateProvAddr"].ToString();
            //if(row["UntType"] != DBNull.Value)addrRaw.UntType=row["UntType"].ToString();
            if (row["AlPortAddr"] != DBNull.Value)
                addrRaw.PortStation = row["AlPortAddr"].ToString();
            //if (row["AlZoneAddr"] != DBNull.Value)
            return addrRaw;
        }

        protected Trax.FPS.v1.Types.ShpmtEqpmtRaw SetCntnrsPropertiesXMLFPS(Trax.FPS.v1.Types.ShpmtEqpmtRaw shpmtEqpmtRaw, DataRow row)
        {
            if (row["CntnrKey"] != DBNull.Value) shpmtEqpmtRaw.CntnrKey = row["CntnrKey"].ToString();
            //if (row["EqpmtOwnerName"] != DBNull.Value) shpmtEqpmtRaw.EqpmtOwnerName = row["EqpmtOwnerName"].ToString();
            if (row["CntnrQty"] != DBNull.Value && row["CntnrQty"].ToString().Trim() != string.Empty)
                shpmtEqpmtRaw.EqpmtQty = Convert.ToInt32(row["CntnrQty"]);
            if (row["CntnrSize"] != DBNull.Value)
                shpmtEqpmtRaw.EqpmtSize = row["CntnrSize"].ToString();
            if (row["CntnrType"] != DBNull.Value)
                shpmtEqpmtRaw.EqpmtType = row["CntnrType"].ToString();
            if (row["CntnrNum"] != DBNull.Value && row["CntnrNum"].ToString().Trim() != string.Empty)
                shpmtEqpmtRaw.InstNum = Convert.ToInt32(row["CntnrNum"]);
            //if (row["LocalEqpmtId"] != DBNull.Value) shpmtEqpmtRaw.LocalEqpmtId = row["LocalEqpmtId"].ToString();
            if (row["FbId"] != DBNull.Value)
                shpmtEqpmtRaw.LocalUntNId = Convert.ToInt64(row["FbId"].ToString().Substring(19, 4));
            //if (row["NormEqpmtSize"] != DBNull.Value) shpmtEqpmtRaw.NormEqpmtSize = row["NormEqpmtSize"].ToString();
            //if (row["NormEqpmtType"] != DBNull.Value) shpmtEqpmtRaw.NormEqpmtType = row["NormEqpmtType"].ToString();
            //if (row["UntType"] != DBNull.Value) shpmtEqpmtRaw.UntType = row["UntType"].ToString();
            //if (row["VehicleKey"] != DBNull.Value) shpmtEqpmtRaw.VehicleKey = row["VehicleKey"].ToString();
            //if (row["VesselName"] != DBNull.Value) shpmtEqpmtRaw.VesselName = row["VesselName"].ToString();
            
            return shpmtEqpmtRaw;
        }

        protected Trax.FPS.v1.Types.ProdDtl SetProdDtlPropertiesXMLFPS(Trax.FPS.v1.Types.ProdDtl prodDtl, DataRow row)
        {
            if (row["HazmatFlag"] != DBNull.Value && row["HazmatFlag"].ToString().Trim() != string.Empty) 
                prodDtl.HazmatFlag = row["HazmatFlag"].ToString() == "1" ? true : false;
            if (row["HazmatType"] != DBNull.Value) 
                prodDtl.HazmatType = row["HazmatType"].ToString();
            if (row["ProdInstNum"] != DBNull.Value && row["ProdInstNum"].ToString().Trim() != string.Empty) 
                prodDtl.InstNum = Convert.ToInt32(row["ProdInstNum"]);
            if (row["FbId"] != DBNull.Value)
                prodDtl.LocalUntNId = Convert.ToInt64(row["FbId"].ToString().Substring(19, 4));
            if (row["OverDimFlag"] != DBNull.Value && row["OverDimFlag"].ToString().Trim() != string.Empty)
                prodDtl.OverDimFlag = row["OverDimFlag"].ToString() == "1" ? true : false; ;
            if (row["ProdDesc"] != DBNull.Value) 
                prodDtl.ProdDesc = row["ProdDesc"].ToString();
            if (row["ProdDim"] != DBNull.Value) 
                prodDtl.ProdDim = row["ProdDim"].ToString();
            if (row["ProdDimUom"] != DBNull.Value) 
                prodDtl.ProdDimUom = row["ProdDimUom"].ToString();
            if (row["ProdGrossWt"] != DBNull.Value && row["ProdGrossWt"].ToString().Trim() != string.Empty) 
                prodDtl.ProdGrossWt = Convert.ToDecimal(row["ProdGrossWt"]);
            if (row["ProdKey"] != DBNull.Value) 
                prodDtl.ProdKey = row["ProdKey"].ToString();
            if (row["ProdLine"] != DBNull.Value) 
                prodDtl.ProdLine = row["ProdLine"].ToString();
            //if (row["ProdMarket"] != DBNull.Value) 
            //    prodDtl.ProdMarket = row["ProdMarket"].ToString();
            if (row["ProdNetWt"] != DBNull.Value && row["ProdNetWt"].ToString().Trim() != string.Empty) 
                prodDtl.ProdNetWt = Convert.ToDecimal(row["ProdNetWt"]);
            if (row["ProdPcsCnt"] != DBNull.Value && row["ProdPcsCnt"].ToString().Trim() != string.Empty) 
                prodDtl.ProdPcsCnt = Convert.ToInt32(row["ProdPcsCnt"]);
            if (row["ProdTotalAmt"] != DBNull.Value && row["ProdTotalAmt"].ToString().Trim() != string.Empty) 
                prodDtl.ProdTotalAmt = Convert.ToDecimal(row["ProdTotalAmt"]);
            if (row["ProdTotalCurr"] != DBNull.Value) 
                prodDtl.ProdTotalCurr = row["ProdTotalCurr"].ToString();
            if (row["ProdType"] != DBNull.Value) 
                prodDtl.ProdType = row["ProdType"].ToString();
            if (row["ProdUnitAmt"] != DBNull.Value && row["ProdUnitAmt"].ToString().Trim() != string.Empty) 
                prodDtl.ProdUnitAmt = Convert.ToDecimal(row["ProdUnitAmt"]);
            if (row["ProdUnitCurr"] != DBNull.Value) 
                prodDtl.ProdUnitCurr = row["ProdUnitCurr"].ToString();
            if (row["ProdVol"] != DBNull.Value && row["ProdVol"].ToString().Trim() != string.Empty) 
                prodDtl.ProdVol = Convert.ToDecimal(row["ProdVol"]);
            if (row["ProdVolUom"] != DBNull.Value) 
                prodDtl.ProdVolUom = row["ProdVolUom"].ToString();
            if (row["ProdWtUom"] != DBNull.Value) 
                prodDtl.ProdWtUom = row["ProdWtUom"].ToString();
            //if (row["UntType"] != DBNull.Value) 
            //    prodDtl.UntType = row["UntType"].ToString();

            return prodDtl;
        }

        protected Trax.FPS.v1.Types.FbLn SetFbLnPropertiesXMLFPS(Trax.FPS.v1.Types.FbLn fbLine, DataRow row)
        {           
            //if(row["AdjmReasonCode"] != DBNull.Value)
            //    fbLine.AdjmReasonCode=row["AdjmReasonCode"].ToString();
            //if(row["AdjmReasonDesc"] != DBNull.Value)
            //    fbLine.AdjmReasonDesc=row["AdjmReasonDesc"].ToString();
            //if(row["AppAmt"] != DBNull.Value)
            //    fbLine.AppAmt=Convert.ToDecimal(row["AppAmt"]);
            //if(row["BatKey"] != DBNull.Value)
            //    fbLine.BatKey=row["BatKey"].ToString();
            if (row["Cat"] != DBNull.Value)
                fbLine.Cat = row["Cat"].ToString();
            //if(row["CatSeqNum"] != DBNull.Value)
            //    fbLine.CatSeqNum=Convert.ToInt16(row["CatSeqNum"]);
            if (row["ChrgAmt"] != DBNull.Value && row["ChrgAmt"].ToString().Trim() != string.Empty)
                fbLine.ChrgAmt = Convert.ToDecimal(row["ChrgAmt"]);
            if (row["ChrgDesc"] != DBNull.Value)
                fbLine.ChrgDesc = row["ChrgDesc"].ToString();
            if (row["CmdtyClass"] != DBNull.Value)
                fbLine.CmdtyClass = row["CmdtyClass"].ToString();
            if (row["CurrencyQual"] != DBNull.Value)
                fbLine.CurrencyQual = row["CurrencyQual"].ToString();
            //if(row["CustLnChrgCode"] != DBNull.Value)
            //    fbLine.CustLnChrgCode=row["CustLnChrgCode"].ToString();
            if (row["LnDim"] != DBNull.Value)
                fbLine.DimData = row["LnDim"].ToString();
            if (row["LnDimQual"] != DBNull.Value)
                fbLine.DimUom = row["LnDimQual"].ToString();
            if (row["ExchRate"] != DBNull.Value && row["ExchRate"].ToString().Trim() != string.Empty)
                fbLine.ExchRate = Convert.ToDecimal(row["ExchRate"]);
            //if (row["Facsimile01"] != DBNull.Value)
            //    fbLine.Facsimile01 = row["Facsimile01"].ToString();
            //if (row["Facsimile02"] != DBNull.Value)
                //fbLine.Facsimile02 = row["Facsimile02"].ToString();
            if (row["FbId"] != DBNull.Value)
                fbLine.FbId = row["FbId"].ToString();
            //if(row["FbLineItemFlag"] != DBNull.Value)
            //    fbLine.FbLineItemFlag=Convert.ToBoolean(row["FbLineItemFlag"]);
            if (row["LineItemNum"] != DBNull.Value && row["LineItemNum"].ToString().Trim() != string.Empty)
                fbLine.LineItemNum = Convert.ToInt16(row["LineItemNum"]);
            if (row["LnActualWt"] != DBNull.Value && row["LnActualWt"].ToString().Trim() != string.Empty)
                fbLine.LnActualWt = Convert.ToSingle(row["LnActualWt"]);
            //if(row["LnBasis"] != DBNull.Value)
            //    fbLine.LnBasis=Convert.ToSingle(row["LnBasis"]);
            //if(row["LnBasisQual"] != DBNull.Value)
            //    fbLine.LnBasisQual=row["LnBasisQual"].ToString();
            if (row["LnChrgCode"] != DBNull.Value)
                fbLine.LnChrgCode = row["LnChrgCode"].ToString();
            //if(row["LnDeclAmt"] != DBNull.Value)
            //    fbLine.LnDeclAmt=Convert.ToDecimal(row["LnDeclAmt"]);
            //if(row["LnRateAsQual"] != DBNull.Value)
            //    fbLine.LnRateAsQual=row["LnRateAsQual"].ToString();
            if (row["LnRateAsWt"] != DBNull.Value && row["LnRateAsWt"].ToString().Trim() != string.Empty)
                fbLine.LnRateAsWt = Convert.ToSingle(row["LnRateAsWt"]);
            //if(row["LnVendRateScale"] != DBNull.Value)
            //    fbLine.LnVendRateScale=row["LnVendRateScale"].ToString();
            if (row["LocalAmt"] != DBNull.Value && row["LocalAmt"].ToString().Trim() != string.Empty)
                fbLine.LocalAmt = Convert.ToDecimal(row["LocalAmt"]);
            if (row["LocalCurrencyQual"] != DBNull.Value)
                fbLine.LocalCurrencyQual = row["LocalCurrencyQual"].ToString();                
            //if(row["MsgGrpNum"] != DBNull.Value)
            //    fbLine.MsgGrpNum=row["MsgGrpNum"].ToString();
            if (row["PcsCnt"] != DBNull.Value && row["PcsCnt"].ToString().Trim() != string.Empty)
                fbLine.PcsCnt = Convert.ToInt32(row["PcsCnt"]);
            if (row["PkgType"] != DBNull.Value)
                fbLine.PkgType = row["PkgType"].ToString();
            if (row["QtyLabl"] != DBNull.Value)
                fbLine.QtyLabl = row["QtyLabl"].ToString();
            if (row["RateAmt"] != DBNull.Value && row["RateAmt"].ToString().Trim() != string.Empty)
                fbLine.RateAmt = Convert.ToDecimal(row["RateAmt"]);
            //if(row["RateCpntId"] != DBNull.Value)
            //    fbLine.RateCpntId=row["RateCpntId"].ToString();
            //if(row["RatePerUntCnt"] != DBNull.Value)
            //    fbLine.RatePerUntCnt=Convert.ToInt32(row["RatePerUntCnt"]);
            if (row["RateType"] != DBNull.Value)
                fbLine.RateType = row["RateType"].ToString();
            if (row["RateUntLabl"] != DBNull.Value)
                fbLine.RateUntLabl = row["RateUntLabl"].ToString();
            //if (row["T001"] != DBNull.Value)
            //    fbLine.T001 = row["T001"].ToString();
            //if (row["T002"] != DBNull.Value)
            //    fbLine.T002 = row["T002"].ToString();
            //if (row["T003"] != DBNull.Value)
            //    fbLine.T003 = row["T003"].ToString();
            //if (row["T004"] != DBNull.Value)
            //    fbLine.T004 = row["T004"].ToString();
            //if (row["T005"] != DBNull.Value)
            //    fbLine.T005 = row["T005"].ToString();
            //if (row["T006"] != DBNull.Value)
            //    fbLine.T006 = row["T006"].ToString();
            if (row["Taxable"] != DBNull.Value && row["Taxable"].ToString().Trim() != string.Empty)
                fbLine.TaxableFlag = row["Taxable"].ToString() == "1" ? true : false;
            //if(row["TxActualWt"] != DBNull.Value)
            //    fbLine.TxActualWt=Convert.ToSingle(row["TxActualWt"]);
            //if(row["TxDimVol"] != DBNull.Value)
            //    fbLine.TxDimVol=Convert.ToDouble(row["TxDimVol"]);
            //if(row["TxDimWt"] != DBNull.Value)
            //    fbLine.TxDimWt=Convert.ToSingle(row["TxDimWt"]);
            //if(row["TxFnclWt"] != DBNull.Value)
            //    fbLine.TxFnclWt=Convert.ToSingle(row["TxFnclWt"]);
            //if(row["TxLineItemFlag"] != DBNull.Value)
            //    fbLine.TxLineItemFlag=Convert.ToBoolean(row["TxLineItemFlag"]);
            //if(row["TxRateAmt"] != DBNull.Value)
            //    fbLine.TxRateAmt=Convert.ToDecimal(row["TxRateAmt"]);
            if (row["VendDesc"] != DBNull.Value)
                fbLine.VendDesc = row["VendDesc"].ToString();
            if (row["LnVol"] != DBNull.Value && row["LnVol"].ToString().Trim() != string.Empty)
                fbLine.Vol = Convert.ToDecimal(row["LnVol"]);
            if (row["LnVolQual"] != DBNull.Value)
                fbLine.VolUom = row["LnVolQual"].ToString();
            return fbLine;
        }
    }
}
