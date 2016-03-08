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
    /// Summary description for FBCountCorrectionBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FBCountCorrectionBL : BaseBLogic
    {
        public FBCountCorrectionBL()
        {
        }

        public override void setQueries()
        {

        }

        [WebMethod]
        public DataSet selectBatch()
        {
            DataSet retval = new DataSet();
            string query = string.Empty;

            query = @"SELECT 
	                        Batch_DE.Bat_Ctrl_Num,
	                        Batch_DE.Owner_Key,
	                        Batch_DE.Vend_SCAC,
	                        Batch_DE.NEW_DTM,	
	                        OwnerCodeSite.Assigned_Site,
	                        Batch_DE.Inv_Cnt,
	                        Batch_DE.FB_Cnt AS DataEntry_FB_Cnt,
	                        FB_SCAC.FB_Cnt AS Batching_FB_Cnt,
	                        (CASE WHEN DEUser1.UserFirstName='' OR DEUser1.UserFirstName IS NULL THEN '' ELSE DEUser1.UserFirstName + ' ' END +
	                        CASE WHEN DEUser1.UserMiddleName='' OR DEUser1.UserMiddleName IS NULL THEN '' ELSE DEUser1.UserMiddleName + ' 'END +
	                        CASE WHEN DEUser1.UserLastName='' OR DEUser1.UserLastName IS NULL THEN '' ELSE DEUser1.UserLastName END) AS Oper_Init, 
	                        (CASE WHEN DEUser2.UserFirstName='' OR DEUser2.UserFirstName IS NULL THEN '' ELSE DEUser2.UserFirstName + ' ' END +
	                        CASE WHEN DEUser2.UserMiddleName='' OR DEUser2.UserMiddleName IS NULL THEN '' ELSE DEUser2.UserMiddleName + ' 'END +
	                        CASE WHEN DEUser2.UserLastName='' OR DEUser2.UserLastName IS NULL THEN '' ELSE DEUser2.UserLastName END) AS Rev_Init, 	
	                        Batch_DE.[%T006] AS BatchOperator,
	                        0 AS Correction
                        FROM (((Batch_DE(nolock) INNER JOIN FB_SCAC ON Batch_DE.Bat_Ctrl_Num=FB_SCAC.Bat_Ctrl_Num) LEFT JOIN NonScacs ON Batch_DE.Vend_SCAC=NonScacs.VEND_SCAC) 						
                        LEFT JOIN OwnerCodeSite ON Batch_DE.Owner_Code=OwnerCodeSite.Owner_Code)
						LEFT JOIN (SELECT Batch_DE.Bat_Ctrl_Num FROM Batch_DE(nolock)
									INNER JOIN FBCountCorrection ON Batch_DE.Bat_Ctrl_Num=FBCountCorrection.Bat_Ctrl_Num
									AND Batch_DE.Owner_Key = FBCountCorrection.Owner_Key
									AND Batch_DE.Vend_SCAC = FBCountCorrection.Vend_SCAC
									AND Batch_DE.NEW_DTM = FBCountCorrection.NEW_DTM) AS TEMP ON TEMP.Bat_Ctrl_Num = Batch_DE.Bat_Ctrl_Num
                        LEFT JOIN DEUsers DEUser1 ON Batch_DE.Oper_Init=DEUser1.UserInitials
                        LEFT JOIN DEUsers DEUser2 ON Batch_DE.Rev_Init=DEUser2.UserInitials
                        WHERE (((Batch_DE.FB_Cnt)<>FB_SCAC.FB_CNT) And ((Batch_DE.Active)=1))
						AND TEMP.Bat_Ctrl_Num IS NULL";
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
        public bool UpdateFBCountCorrection(string Note, DataTable batchNumber, string correctField, string systemUserName)
        {
            bool retval = false;
            int affectedRows = 0;

            insertQuery = @"INSERT INTO [FBCountCorrection]
                                   ([Bat_Ctrl_Num]
                                   ,[Owner_Key]
                                   ,[Vend_SCAC]
                                   ,[NEW_DTM]
                                   ,[Note]
                                   ,[CorrectField]
                                   ,[CorrectCount]
                                   ,[UserName]
                                   ,[CorrectionDate])
                             VALUES
                                   (@Bat_Ctrl_Num
                                   ,@Owner_Key
                                   ,@Vend_SCAC
                                   ,@NEW_DTM
                                   ,@Note
                                   ,@CorrectField
                                   ,@CorrectCount
                                   ,@UserName
                                   ,GETDATE())";

            ParameterInfo[] param = new ParameterInfo[8];
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                foreach (DataRow row in batchNumber.Rows)
                {

                    param[0] = new ParameterInfo("@Bat_Ctrl_Num", row["Bat_Ctrl_Num"].ToString());

                    param[2] = new ParameterInfo("@Owner_Key", row["Owner_Key"].ToString());
                    param[3] = new ParameterInfo("@Vend_SCAC", row["Vend_SCAC"].ToString());
                    param[4] = new ParameterInfo("@NEW_DTM", row["NEW_DTM"].ToString());
                    param[1] = new ParameterInfo("@Note", Note);
                    param[5] = new ParameterInfo("@CorrectField", correctField);
                    param[6] = new ParameterInfo("@CorrectCount", row["CorrectCount"].ToString());
                    param[7] = new ParameterInfo("@UserName", systemUserName);

                    affectedRows = dal.ExecuteNonQuery(insertQuery, CommandType.Text, param);
                    //this.BatchAuditTrail(row["Bat_Ctrl_Num"].ToString(), "140", dal);
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
