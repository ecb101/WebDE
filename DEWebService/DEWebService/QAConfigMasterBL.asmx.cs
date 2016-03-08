using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;
using System.Data;
using DAL;

namespace DEWebService
{
    /// <summary>
    /// Summary description for QAConfigMasterBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QAConfigMasterBL : BaseBLogic 
    {

        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [QAConfig]
                                       ([Owner_Key]
                                       ,[Vend_SCAC]
                                       ,[InvAmt]
                                       ,[AcctNumVendBlng]
                                       ,[InvCreatDtm]
                                       ,[FbAmt]
                                       ,[FbCreatDtm]
                                       ,[FbPaymtTermsCode]
                                       ,[FbFullQAPercent])
                                 VALUES
                                       (@Owner_Key
                                       ,@Vend_SCAC
                                       ,@InvAmt
                                       ,@AcctNumVendBlng
                                       ,@InvCreatDtm
                                       ,@FbAmt
                                       ,@FbCreatDtm
                                       ,@FbPaymtTermsCode
                                       ,@FBFullQAPercent)";
            this.updateQuery = @"UPDATE QAConfig
                                   SET [InvAmt] = @InvAmt
                                      ,[AcctNumVendBlng] = @AcctNumVendBlng
                                      ,[InvCreatDtm] = @InvCreatDtm
                                      ,[FbAmt] = @FbAmt
                                      ,[FbCreatDtm] = @FbCreatDtm
                                      ,[FbPaymtTermsCode] = @FbPaymtTermsCode
                                      ,[FBFullQAPercent] = @FBFullQAPercent
                                 WHERE Owner_Key =@Owner_Key AND Vend_SCAC = @Vend_SCAC";
            this.deleteQuery = @"DELETE FROM QAConfig
                                WHERE Owner_Key =@Owner_Key AND Vend_SCAC = @Vend_SCAC";
            this.selectQuery = @"SELECT * FROM QAConfig                           
                                WHERE Owner_Key =@Owner_Key AND Vend_SCAC = @Vend_SCAC";
            this.selectAllQuery = "SELECT * FROM QAConfig";
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
