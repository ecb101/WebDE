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
    /// Summary description for ForceStatusChangeBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ForceStatusChangeBL : BaseBLogic
    {
        public ForceStatusChangeBL()
        {
        }

        public override void setQueries()
        {
            //throw new NotImplementedException();
        }

        [WebMethod]
        public DataSet selectBatches()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT Bat_Ctrl_Num AS [Batch Number],                                    
                                    Batch_Status AS [Batch Status]
                            FROM Batch_DE(NOLOCK)
                            WHERE Batch_Status LIKE 'OPEN%' OR Batch_Status = 'DEACTIVATION'
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
        public bool updateStatus(string batCtrlNum, string status, string systemUserName)
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
                if (status == "IN DE")
                    this.BatchAuditTrail(batCtrlNum, "150", dal, systemUserName);
                else
                    this.BatchAuditTrail(batCtrlNum, "151", dal, systemUserName);
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
