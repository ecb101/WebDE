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
    /// Summary description for OwnerCodeSiteMasterBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class OwnerCodeSiteMasterBL : BaseBLogic
    {

        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [OwnerCodeSite]
                                       ([Owner_Code]
                                       ,[Assigned_Site])
                                 VALUES
                                       (@Owner_Code
                                       ,@Assigned_Site)";
            this.updateQuery = @"UPDATE OwnerCodeSite
                                   SET [Assigned_Site] = @Assigned_Site
                                 WHERE Owner_Code =@Owner_Code";
            this.deleteQuery = @"DELETE FROM OwnerCodeSite
                                WHERE Owner_Code =@Owner_Code";
            this.selectQuery = @"SELECT * FROM OwnerCodeSite                           
                                WHERE Owner_Code =@Owner_Code";
            this.selectAllQuery = "SELECT * FROM OwnerCodeSite";
        }

        [WebMethod]
        public DataSet selectAssignedSite()
        {
            DataSet retval = new DataSet();

            string query = @"SELECT DISTINCT Assigned_Site FROM OwnerCodeSite";

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
