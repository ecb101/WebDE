using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace DEWebService
{
    /// <summary>
    /// Summary description for VendRemitBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VendRemitBL : BaseBLogic
    {
        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [VEND_REMIT]
                                       ([VEND_LABL]
                                       ,[LOC_ID_REMIT]
                                       ,[AL_REMIT_1]
                                       ,[AL_REMIT_2]
                                       ,[AL_REMIT_3]
                                       ,[AL_REMIT_4]
                                       ,[AL_CITY_REMIT]
                                       ,[AL_STATE_PROV_REMIT]
                                       ,[AL_POST_CODE_REMIT]
                                       ,[AL_CNTRY_CODE_REMIT]
                                       ,[AL_PHONE_NUM_REMIT]
                                       ,[AL_PHONE_EXT_REMIT]
                                       ,[AL_FAX_NUM_REMIT]
                                       ,[CURRENCY_QUAL])
                                 VALUES
                                       (@VEND_LABL
                                       ,@LOC_ID_REMIT
                                       ,@AL_REMIT_1
                                       ,@AL_REMIT_2
                                       ,@AL_REMIT_3
                                       ,@AL_REMIT_4
                                       ,@AL_CITY_REMIT
                                       ,@AL_STATE_PROV_REMIT
                                       ,@AL_POST_CODE_REMIT
                                       ,@AL_CNTRY_CODE_REMIT
                                       ,@AL_PHONE_NUM_REMIT
                                       ,@AL_PHONE_EXT_REMIT
                                       ,@AL_FAX_NUM_REMIT
                                       ,@CURRENCY_QUAL)";
            this.updateQuery = @"UPDATE VEND_REMIT
                                   SET [AL_REMIT_1] = @AL_REMIT_1
                                      ,[AL_REMIT_2] = @AL_REMIT_2
                                      ,[AL_REMIT_3] = @AL_REMIT_3
                                      ,[AL_REMIT_4] = @AL_REMIT_4
                                      ,[AL_CITY_REMIT] = @AL_CITY_REMIT
                                      ,[AL_STATE_PROV_REMIT] = @AL_STATE_PROV_REMIT
                                      ,[AL_POST_CODE_REMIT] = @AL_POST_CODE_REMIT
                                      ,[AL_CNTRY_CODE_REMIT] = @AL_CNTRY_CODE_REMIT
                                      ,[AL_PHONE_NUM_REMIT] = @AL_PHONE_NUM_REMIT
                                      ,[AL_PHONE_EXT_REMIT] = @AL_PHONE_EXT_REMIT
                                      ,[AL_FAX_NUM_REMIT] = @AL_FAX_NUM_REMIT
                                      ,[CURRENCY_QUAL] = @CURRENCY_QUAL
                                 WHERE VEND_LABL = @VEND_LABL AND LOC_ID_REMIT = @LOC_ID_REMIT";
            this.deleteQuery = @"DELETE FROM VEND_REMIT
                                WHERE VEND_LABL = @VEND_LABL AND LOC_ID_REMIT = @LOC_ID_REMIT";
            this.selectQuery = @"SELECT * FROM VEND_REMIT                           
                                WHERE VEND_LABL = @VEND_LABL AND LOC_ID_REMIT = @LOC_ID_REMIT";
            this.selectAllQuery = "SELECT * FROM VEND_REMIT";
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

            query = string.Format(@"SELECT LOC_ID_REMIT
                             FROM VEND_REMIT 
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
