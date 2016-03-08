using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using DAL;
namespace DEWebService
{
    /// <summary>
    /// Summary description for TransferOwnershipBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TransferOwnershipBL : BaseBLogic
    {
        public override void setQueries()
        {
            //throw new NotImplementedException();
        }

        public TransferOwnershipBL()
        {
        }

        [WebMethod]
        public DataSet selectBatches(string status)
        {
            DataSet retval = new DataSet();
            string query = string.Empty;

            if (status != "REVIEW")
                query = @"SELECT Bat_Ctrl_Num AS [Batch Number],
                                    Oper_Init AS [Operator],                                    
                                    Rev_Init AS [QA By],                                    
                                    Batch_Status AS [Batch Status]
                            FROM Batch_DE(NOLOCK)
                            WHERE Batch_Status IN ('IN DE', 'RE-KEY', 'REVIEW')
                            AND Oper_Init<> ''
                            ORDER BY Bat_Ctrl_Num";

            else
                query = @"SELECT Bat_Ctrl_Num AS [Batch Number],
                                    Oper_Init AS [Operator],                                    
                                    Rev_Init AS [QA By],                                    
                                    Batch_Status AS [Batch Status]
                            FROM Batch_DE(NOLOCK)
                            WHERE Batch_Status = 'REVIEW'
                            AND Oper_Init<> ''
                            ORDER BY Bat_Ctrl_Num";

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
        public bool updateOperator(string batCtrlNum, string Operator, string systemUserName)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE Batch_DE
                                    SET Oper_Init = @OperInit                            
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@OperInit", Operator);
                param[1] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                this.BatchAuditTrail(batCtrlNum, "160", dal, systemUserName);//auditTrailBatch(batCtrlNum, "160");
                dal.CommitTransaction();
                retval = true;
            }
            catch
            {
                dal.RollBackTransaction();
                retval = false;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool updateReviewer(string batCtrlNum, string Reviewer, string systemUserName)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE Batch_DE
                                    SET Rev_Init = @RevInit                            
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@RevInit", Reviewer);
                param[1] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                this.BatchAuditTrail(batCtrlNum, "161", dal, systemUserName);//auditTrailBatch(batCtrlNum, "161");
                dal.CommitTransaction();
                retval = true;
            }
            catch
            {
                dal.RollBackTransaction();
                retval = false;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }        
    }
}
