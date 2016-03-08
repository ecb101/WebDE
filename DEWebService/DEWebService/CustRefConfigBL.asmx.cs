using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace DEWebService
{
    /// <summary>
    /// Summary description for CustRefConfigBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustRefConfigBL : BaseBLogic
    {

        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [CustRefConfig]
                                       ([Owner_Key]
                                       ,[EndSemiColon])
                                 VALUES
                                       (@Owner_Key
                                       ,@EndSemiColon)";
            this.updateQuery = @"UPDATE CustRefConfig
                                   SET [EndSemiColon] = @EndSemiColon
                                 WHERE Owner_Key =@Owner_Key";
            this.deleteQuery = @"DELETE FROM CustRefConfig
                                WHERE Owner_Key =@Owner_Key";
            this.selectQuery = @"SELECT * FROM CustRefConfig                           
                                WHERE Owner_Key =@Owner_Key";
            this.selectAllQuery = "SELECT * FROM CustRefConfig";
        }

        [WebMethod]
        public DataSet selectOwnerKey(bool isNew)
        {
            DataSet retval = new DataSet();

            string query = string.Empty;
            if (isNew)
                query = @"SELECT OwnerKey AS Owner_Key
                            FROM Entity LEFT JOIN CustRefConfig ON OwnerKey = Owner_Key
                            WHERE Owner_Key IS NULL";
            else
                query = @"SELECT OwnerKey AS Owner_Key
                            FROM Entity";
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
