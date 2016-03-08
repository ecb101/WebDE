using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace DEWebService
{
    /// <summary>
    /// Summary description for BillToBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BillToBL : BaseBLogic
    {

        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [BillTo]
                                       ([VEND_LABL]
                                       ,[LOC_ID_BLNG]
                                       ,[AL_BLNG_1]
                                       ,[AL_BLNG_2]
                                       ,[AL_BLNG_3]
                                       ,[AL_BLNG_4]
                                       ,[AL_CITY_BLNG]
                                       ,[AL_STATE_PROV_BLNG]
                                       ,[AL_POST_CODE_BLNG]
                                       ,[AL_CNTRY_CODE_BLNG]
                                       ,[AL_PHONE_NUM_BLNG]
                                       ,[AL_PHONE_EXT_BLNG])
                                 VALUES
                                       (@VEND_LABL
                                       ,@LOC_ID_BLNG
                                       ,@AL_BLNG_1
                                       ,@AL_BLNG_2
                                       ,@AL_BLNG_3
                                       ,@AL_BLNG_4
                                       ,@AL_CITY_BLNG
                                       ,@AL_STATE_PROV_BLNG
                                       ,@AL_POST_CODE_BLNG
                                       ,@AL_CNTRY_CODE_BLNG
                                       ,@AL_PHONE_NUM_BLNG
                                       ,@AL_PHONE_EXT_BLNG)";
            this.updateQuery = @"UPDATE BillTo
                                   SET [AL_BLNG_1] = @AL_BLNG_1
                                      ,[AL_BLNG_2] = @AL_BLNG_2
                                      ,[AL_BLNG_3] = @AL_BLNG_3
                                      ,[AL_BLNG_4] = @AL_BLNG_4
                                      ,[AL_CITY_BLNG] = @AL_CITY_BLNG
                                      ,[AL_STATE_PROV_BLNG] = @AL_STATE_PROV_BLNG
                                      ,[AL_POST_CODE_BLNG] = @AL_POST_CODE_BLNG
                                      ,[AL_CNTRY_CODE_BLNG] = @AL_CNTRY_CODE_BLNG
                                      ,[AL_PHONE_NUM_BLNG] = @AL_PHONE_NUM_BLNG
                                      ,[AL_PHONE_EXT_BLNG] = @AL_PHONE_EXT_BLNG
                                 WHERE VEND_LABL = @VEND_LABL AND LOC_ID_BLNG = @LOC_ID_BLNG";
            this.deleteQuery = @"DELETE FROM BillTo
                                WHERE VEND_LABL = @VEND_LABL AND LOC_ID_BLNG = @LOC_ID_BLNG";
            this.selectQuery = @"SELECT * FROM BillTo                           
                                WHERE VEND_LABL = @VEND_LABL AND LOC_ID_BLNG = @LOC_ID_BLNG";
            this.selectAllQuery = "SELECT * FROM BillTo";
        }

        [WebMethod]
        public DataSet selectSCAC()
        {
            DataSet retval = new DataSet();
            string query = string.Empty;

            query = string.Format(@"SELECT DISTINCT DeScac
                             FROM EntityScac 
                             ORDER BY DeScac");
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
        public DataSet selectLOC(string vend)
        {
            DataSet retval;

            string query = string.Empty;

            query = string.Format(@"SELECT LOC_ID_BLNG
                             FROM BillTo 
                             WHERE VEND_LABL = '" + vend + "'");
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
