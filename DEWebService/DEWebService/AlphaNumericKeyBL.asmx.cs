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
    /// Summary description for AlphaNumericKeyBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AlphaNumericKeyBL : BaseBLogic
    {

        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [AlphaNumericKey]
                                       ([Owner_Key]
                                       ,[Invoice]
                                       ,[FreightBill]
                                       ,[Account]
                                       ,[TaxNumber]
                                       ,[VatReg]
                                       ,[AccountOrig]
                                       ,[AccountDest])
                                 VALUES
                                       (@Owner_Key
                                       ,@Invoice
                                       ,@FreightBill
                                       ,@Account
                                       ,@TaxNumber
                                       ,@VatReg
                                       ,@AccountOrig
                                       ,@AccountDest)";
            this.updateQuery = @"UPDATE AlphaNumericKey
                                   SET [Invoice] = @Invoice
                                      ,[FreightBill] = @FreightBill
                                      ,[Account] = @Account
                                      ,[TaxNumber] = @TaxNumber
                                      ,[VatReg] = @VatReg
                                      ,[AccountOrig] = @AccountOrig
                                      ,[AccountDest] = @AccountDest
                                 WHERE Owner_Key =@Owner_Key";
            this.deleteQuery = @"DELETE FROM AlphaNumericKey
                                WHERE Owner_Key =@Owner_Key";
            this.selectQuery = @"SELECT * FROM AlphaNumericKey                           
                                WHERE Owner_Key =@Owner_Key";
            this.selectAllQuery = "SELECT * FROM AlphaNumericKey";
        }

        [WebMethod]
        public DataSet selectReasonDescription(bool isNew)
        {
            DataSet retval = new DataSet();

            string query = string.Empty;
            if(isNew)
                query = @"SELECT OwnerKey AS Owner_Key
                            FROM Entity LEFT JOIN AlphaNumericKey ON OwnerKey = Owner_Key
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
