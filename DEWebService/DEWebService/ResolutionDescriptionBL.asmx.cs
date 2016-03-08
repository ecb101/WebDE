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
    /// Summary description for ResolutionDescriptionBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ResolutionDescriptionBL : BaseBLogic
    {

        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [ResolutionDescription]
                                       ([Code]
                                       ,[Description]
                                       ,[Type]
                                       ,[Category])
                                 VALUES
                                       (@Code
                                       ,@Description
                                       ,@Type
                                       ,@Category)";
            this.updateQuery = @"UPDATE ResolutionDescription
                                   SET [Code] = @Code
                                      ,[Description] = @Description
                                      ,[Type] = @Type
                                      ,[Category] = @Category
                                 WHERE ID =@ID";
            this.deleteQuery = @"DELETE FROM ResolutionDescription
                                WHERE ID =@ID";
            this.selectQuery = @"SELECT * FROM ResolutionDescription                           
                                WHERE ID =@ID";
            this.selectAllQuery = "SELECT * FROM ResolutionDescription";
        }

        [WebMethod]
        public DataSet selectCategory()
        {
            DataSet retval = new DataSet();

            string query = @"SELECT DISTINCT Category FROM ResolutionDescription";
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
        public DataSet selectType()
        {
            DataSet retval = new DataSet();

            string query = @"SELECT DISTINCT Type FROM ResolutionDescription";
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
        public DataSet selectCode(String type, String cat)
        {
            DataSet retval = new DataSet();


            string query = @"SELECT Code FROM ResolutionDescription WHERE Type = '" + type + "' AND Category = '" + cat +
                "' ORDER BY Code";

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
