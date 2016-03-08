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
    /// Summary description for DeactivateBatchesBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DeactivateBatchesBL : BaseBLogic
    {
        public DeactivateBatchesBL()
        {
        }

        public override void setQueries()
        {

        }

        [WebMethod]
        public DataSet selectReasonDescription()
        {
            DataSet retval = new DataSet();

            string query = @"SELECT Description
                            FROM DeactivationDescription(NOLOCK)";
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
        public DataSet selectBatch(bool isReactivate)
        {
            DataSet retval = new DataSet();
            string query = string.Empty;
            if (!isReactivate)
            {
                query = @"SELECT Bat_Ctrl_Num AS Bat_Ctrl_Num, Active AS Active
                            FROM Batch_DE(NOLOCK)
                            WHERE Active = 1 AND Batch_Status NOT IN ('OPENDE', 'OPENQA')
                            ORDER BY Bat_Ctrl_Num";
            }
            else
            {
                query = @"SELECT Bat_Ctrl_Num AS Bat_Ctrl_Num, Active AS Active
                            FROM Batch_DE(NOLOCK)
                            WHERE Active = 0
                            ORDER BY Bat_Ctrl_Num";
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
        public bool UpdateBatchReactivate(DataTable batchNumber, string systemUserName)
        {
            bool retval = false;
            int affectedRows = 0;
            updateQuery = @"UPDATE Batch_DE 
                                SET Batch_DE.Active = 1, 
                                Batch_DE.[%T001] = NULL,
                                Batch_DE.[%T004] = NULL
                            WHERE Batch_DE.Bat_Ctrl_Num = @Bat_Ctrl_Num";

            ParameterInfo[] param = new ParameterInfo[1];
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                foreach (DataRow row in batchNumber.Rows)
                {
                    param[0] = new ParameterInfo("@Bat_Ctrl_Num", row["Bat_Ctrl_Num"].ToString());
                    affectedRows = dal.ExecuteNonQuery(updateQuery, CommandType.Text, param);
                    this.BatchAuditTrail(row["Bat_Ctrl_Num"].ToString(), "141", dal, systemUserName);//auditTrailBatch(row["Bat_Ctrl_Num"].ToString(), "140");
                }
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
        public bool UpdateBatch(string reason, DataTable batchNumber, bool isStandardReason, string systemUserName)
        {
            bool retval = false;
            int affectedRows = 0;
            if (isStandardReason)
            {
                updateQuery = @"UPDATE Batch_DE 
                            SET Batch_DE.Active = 0,
                            Batch_DE.[%T004] = @Reason
                            WHERE Batch_DE.Bat_Ctrl_Num = @Bat_Ctrl_Num";
            }
            else
            {
                updateQuery = @"UPDATE Batch_DE 
                            SET Batch_DE.Active = 0, 
                            Batch_DE.[%T001] = @Reason,
                            Batch_DE.[%T004] = 'Other Reason'
                            WHERE Batch_DE.Bat_Ctrl_Num = @Bat_Ctrl_Num";
            }
            ParameterInfo[] param = new ParameterInfo[2];
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                foreach (DataRow row in batchNumber.Rows)
                {
                    param[0] = new ParameterInfo("@Reason", reason);
                    param[1] = new ParameterInfo("@Bat_Ctrl_Num", row["Bat_Ctrl_Num"].ToString());
                    affectedRows = dal.ExecuteNonQuery(updateQuery, CommandType.Text, param);
                    this.BatchAuditTrail(row["Bat_Ctrl_Num"].ToString(), "140", dal, systemUserName);//auditTrailBatch(row["Bat_Ctrl_Num"].ToString(), "140");
                }
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
    }
}
