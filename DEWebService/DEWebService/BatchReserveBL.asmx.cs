using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using DAL;
namespace DEWebService
{
    /// <summary>
    /// Summary description for BatchReserveBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BatchReserveBL : BaseBLogic
    {        
        protected DALHelperOleDB dalBatchHeaderCR;

        public BatchReserveBL()
        {            
            dalBatchHeaderCR = new DALHelperOleDB("BatchHeaderCRDEConnection");        
        }

        public override void setQueries()
        {
            
        }

        [WebMethod]
        public DataSet selectBuffedContents(string siteID)
        {
            DataSet retval = new DataSet();
            DataSet dsBatchBuff = new DataSet("BatchBuff");
            DataSet dsBatchBuffTotal = new DataSet("BatchBuffTotal");
            DataSet dsCRBatchHeader = new DataSet("CRBatchHeader");
            DataSet dsCebuBatchHeader = new DataSet("CebuBatchHeader");
            string query = @"SELECT TOP(1) *
                            FROM BatchBuff
                            WHERE RemainingReservedCount>0";

            string queryTotal = @"SELECT SUM(RemainingReservedCount)
                            FROM BatchBuff";

            string queryBatchHeader = @"SELECT Bat_Ctrl_Num FROM BatchNumberCounter";
            string queryBatchHeader2 = string.Format(@"SELECT IDCounter FROM SiteIDController WHERE SiteID = {0} AND IDType = 'BatFileID'", ConfigurationManager.AppSettings["SiteID"]);

            try
            {
                dal.OpenDB();
                dsBatchBuff = dal.ExecuteDataSet(query, CommandType.Text);
                dsBatchBuffTotal = dal.ExecuteDataSet(queryTotal, CommandType.Text);

                dalBatchHeaderCR.OpenDB();
                dsCRBatchHeader = dalBatchHeaderCR.ExecuteDataSet(queryBatchHeader, CommandType.Text);
                
                dsCebuBatchHeader = dal.ExecuteDataSet(queryBatchHeader2, CommandType.Text);

                dsBatchBuff.Tables[0].TableName = "BatchBuff";
                dsBatchBuffTotal.Tables[0].TableName = "BatchBuffTotal";
                dsCRBatchHeader.Tables[0].TableName = "CRBatchHeader";
                dsCebuBatchHeader.Tables[0].TableName = "CebuBatchHeader";

                retval.Tables.Add(dsBatchBuff.Tables[0].Copy());
                retval.Tables[0].AcceptChanges();
                retval.Tables.Add(dsBatchBuffTotal.Tables[0].Copy());
                retval.Tables[1].AcceptChanges();
                retval.Tables.Add(dsCRBatchHeader.Tables[0].Copy());
                retval.Tables[2].AcceptChanges();
                retval.Tables.Add(dsCebuBatchHeader.Tables[0].Copy());
                retval.Tables[3].AcceptChanges();

            }
            catch
            {
                retval = null;
            }
            finally
            {
                dal.CloseDB();
                dalBatchHeaderCR.CloseDB();                
            }
            return retval;
        }

        [WebMethod]
        public bool addBatchBuff(DataTable dt)
        {
            bool retval = false;
            int affectedRows = 0;
            string selectBatchHeader = "SELECT TOP 1 Bat_Ctrl_Num FROM BatchNumberCounter";
            DataSet ds = new DataSet();
            insertQuery = @"INSERT INTO BatchBuff
                                   (BuffDate
                                   ,OriginalCRBatCtrlNum
                                   ,BuffedCRBatCtrlNum
                                   ,StartBatCtrlNum
                                   ,EndBatCtrlNum
                                   ,OrigReservedCount
                                   ,RemainingReservedCount
                                   ,UserName)
                             VALUES
                                   (@BuffDate
                                   ,@OriginalCRBatCtrlNum
                                   ,@BuffedCRBatCtrlNum
                                   ,@StartBatCtrlNum
                                   ,@EndBatCtrlNum
                                   ,@OrigReservedCount
                                   ,@RemainingReservedCount
                                   ,@UserName)";

            string updateQueryBatchHeader = @"UPDATE BatchNumberCounter
                                    SET Bat_Ctrl_Num = Bat_Ctrl_Num + @Reserved";
            try
            {
                dal.OpenDB();
                dalBatchHeaderCR.OpenDB();
                dal.BeginTransaction();
                dalBatchHeaderCR.BeginTransaction();

                //update Costa Rica Batch Counter
                ParameterInfoOleDB[] param2 = new ParameterInfoOleDB[1];
                param2[0] = new ParameterInfoOleDB("@Reserved", Convert.ToInt32(dt.Rows[0]["OrigReservedCount"]));
                dalBatchHeaderCR.ExecuteNonQuery(updateQueryBatchHeader, CommandType.Text, param2);
                //add BatchBuff Record
                ParameterInfo[] param = new ParameterInfo[8];
                ds = dalBatchHeaderCR.ExecuteDataSet(selectBatchHeader, CommandType.Text);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    param[0] = new ParameterInfo("@BuffDate", this.GetServerDate(dal));
                    param[1] = new ParameterInfo("@OriginalCRBatCtrlNum", Convert.ToInt32(ds.Tables[0].Rows[0][0]) - Convert.ToInt32(dt.Rows[0]["OrigReservedCount"]));
                    param[2] = new ParameterInfo("@BuffedCRBatCtrlNum", Convert.ToInt32(ds.Tables[0].Rows[0][0]));
                    param[3] = new ParameterInfo("@StartBatCtrlNum", Convert.ToInt32(ds.Tables[0].Rows[0][0]) - Convert.ToInt32(dt.Rows[0]["OrigReservedCount"]));
                    param[4] = new ParameterInfo("@EndBatCtrlNum", Convert.ToInt32(ds.Tables[0].Rows[0][0]) - 1);
                    param[5] = new ParameterInfo("@OrigReservedCount", dt.Rows[0]["OrigReservedCount"]);
                    param[6] = new ParameterInfo("@RemainingReservedCount", dt.Rows[0]["OrigReservedCount"]);
                    param[7] = new ParameterInfo("@UserName", dt.Rows[0]["UserName"]);
                }
                else
                {
                    throw new Exception("There was a problem during reservation.");
                }
                affectedRows = dal.ExecuteNonQuery(insertQuery, CommandType.Text, param);

                dalBatchHeaderCR.CommitTransaction();
                dal.CommitTransaction();
                retval = true;
                //}
                //else
                //{
                //    retval = false;
                //}
            }
            catch (Exception error)
            {
                dalBatchHeaderCR.RollBackTransaction();
                dal.RollBackTransaction();
                throw error;
            }
            finally
            {
                dalBatchHeaderCR.CloseDB();
                dal.CloseDB();
            }
            return retval;
        }
    }
}
