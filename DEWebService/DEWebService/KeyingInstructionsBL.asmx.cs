using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Data;


namespace DEWebService
{
    /// <summary>
    /// Summary description for KeyingInstructionsBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KeyingInstructionsBL : BaseBLogic
    {
        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [KeyingInstructions]
                                       ([OwnerKey]
                                       ,[DeScac]
                                       ,[KeyingInstructions]
                                       ,[UpdateTimestamp]
                                       ,[UpdateUsername]
                                       ,[UpdateMachine])
                                 VALUES
                                       (@OwnerKey
                                       ,@DeScac
                                       ,@KeyingInstructions
                                       ,GETDATE()
                                       ,@UpdateUsername
                                       ,@UpdateMachine)";
            this.updateQuery = @"UPDATE KeyingInstructions
                                   SET [KeyingInstructions] = @KeyingInstructions
                                      ,[UpdateTimestamp] = GETDATE()
                                      ,[UpdateUsername] = @UpdateUsername 
                                      ,[UpdateMachine] = @UpdateMachine
                                      WHERE OwnerKey =@OwnerKey AND DeScac = @DeScac";
            this.deleteQuery = @"DELETE FROM KeyingInstructions
                                WHERE OwnerKey =@OwnerKey AND DeScac = @DeScac";
            this.selectQuery = @"SELECT * FROM KeyingInstructions                           
                                WHERE OwnerKey =@OwnerKey AND DeScac = @DeScac";
            this.selectAllQuery = "SELECT * FROM KeyingInstructions";
        }

        [WebMethod]
        public DataSet selectOwnerKey()
        {
            DataSet retval = new DataSet();

            string query = @"SELECT OwnerKey
                            FROM Entity"; //LEFT JOIN QAConfig ON OwnerKey = Owner_Key
            //WHERE Owner_Key IS NULL";
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
        public DataSet selectSCAC(string ownerKey, bool isNew)
        {
            DataSet retval = new DataSet();
            string query = string.Empty;

            query = string.Format(@"SELECT DISTINCT DeScac
                             FROM EntityScac 
                             {0}
                             ORDER BY DeScac", isNew ? string.Format("WHERE OwnerKey = '{0}'", ownerKey) : "");
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
        
    }
}
