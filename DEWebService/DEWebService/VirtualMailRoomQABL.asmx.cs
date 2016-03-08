using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Drawing;
using System.IO;
using DAL;
namespace DEWebService
{
    /// <summary>
    /// Summary description for VirtualMailRoomQABL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VirtualMailRoomQABL : BaseBLogic
    {
        public VirtualMailRoomQABL()
        { }

        public override void setQueries()
        {

        }

        [WebMethod]
        public DataSet selectBatches()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT Bat_Ctrl_Num AS [Batch Number],
                                    Batch_Status AS [Batch Status],
                                    Owner_Key AS [Owner Key],
                                    Vend_SCAC AS [Vendor SCAC],
                                    Oper_Init AS [Operator],
                                    Owner_Code AS [OwnerCode],
                                    Fb_Cnt  AS [Fb_Cnt]
                            FROM Batch_DE(NOLOCK)
                            WHERE Batch_Status IN ('QA BATCH','OPENVMRQA') AND Active = 1
                            ORDER BY Bat_Ctrl_Num";
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
        public DataSet selectClient()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT '' AS Client, '' AS OwnerKey
                                UNION
                                SELECT OwnerName + ' (' +OwnerKey+ ')' AS Client,
                                        OwnerKey AS OwnerKey
                                FROM Entity(NOLOCK) ORDER BY Client";
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
        public DataSet selectSCAC()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT DISTINCT            
                                '!No Scac' AS [Name],
                                'NOSCAC' AS [Scac],
                                '' AS [City/State],
                                '' AS [Mode],
                                 OwnerKey AS OwnerKey
                            FROM EntityScac(NOLOCK)
                            UNION
                            SELECT                                
                                UPPER(ScacName) AS [Name],
                                UPPER(EntityScac.DeScac) AS [Scac],
                                CASE WHEN (UPPER(RemitCity)+','+UPPER(RemitState)) IS NULL THEN '' ELSE UPPER(RemitCity)+','+UPPER(RemitState) END AS [City/State],
                                CASE WHEN (Mode) IS NULL THEN '' ELSE UPPER(Mode) END AS [Mode],
                                OwnerKey AS OwnerKey
                            FROM EntityScac(NOLOCK)
                            LEFT JOIN Carrier ON Carrier.DeScac= EntityScac.DeScac";

            try
            {
                try
                {
                    dal.OpenDB();
                    retval = dal.ExecuteDataSet(query, CommandType.Text);
                }
                catch (Exception)
                {
                    retval = null;
                }
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;

        }

        [WebMethod]
        public bool deactivateBatch(string reason, string batchNumber, string systemUserName, string systemMachineName)
        {
            bool retval = false;
            int affectedRows = 0;
            updateQuery = @"UPDATE Batch_DE 
                        SET Batch_DE.Active = 0,
                        [Batch_Status] = 'IN DE',
                        [%T001] = @Reason,
                        [%T006] = @T006,
                        [%T007] = [%T007]+':'+@T007
                        WHERE Batch_DE.Bat_Ctrl_Num = @Bat_Ctrl_Num";
            ParameterInfo[] param = new ParameterInfo[4];
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();

                param[0] = new ParameterInfo("@Reason", reason);
                param[1] = new ParameterInfo("@Bat_Ctrl_Num", batchNumber);
                param[2] = new ParameterInfo("@T006", systemUserName);
                param[3] = new ParameterInfo("@T007", systemMachineName);
                affectedRows = dal.ExecuteNonQuery(updateQuery, CommandType.Text, param);
                //this.BatchAuditTrail(row["Bat_Ctrl_Num"].ToString(), "140", dal);

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
        public bool isAllowBatchStart(string batCtrlNum)
        {
            bool retval = false;
            DataSet ds = new DataSet();
            string query = @"SELECT IN_DE_DTM
                            FROM Batch_DE(NOLOCK)
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0][0].ToString() == string.Empty)
                {
                    retval = true;
                }
            }
            catch (Exception e)
            {
                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool isAllowEdit(string batCtrlNum)
        {
            bool retval = false;

            DataSet ds = new DataSet();
            string query = @"SELECT Batch_Status AS [Batch Status]
                            FROM Batch_DE(NOLOCK)
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";

            string queryUpdate = @"UPDATE Batch_DE
                                    SET Batch_Status = 'OPENVMRQA'
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                dal.BeginTransaction();
                ds = dal.ExecuteDataSet(query, CommandType.Text, param);
                if (ds.Tables[0].Rows.Count > 0 && (ds.Tables[0].Rows[0][0].ToString() == "QA BATCH"))
                {
                    dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                    //this.BatchAuditTrail(batCtrlNum, "101", dal);//auditTrailBatch(batCtrlNum, "101");
                    dal.CommitTransaction();
                    retval = true;
                }
            }
            catch (Exception e)
            {
                dal.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool updateStatus(string batCtrlNum, string status)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE Batch_DE
                                    SET Batch_Status = @Status                            
                                    WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@Status", status);
                param[1] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dal.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public bool updateBatch(string Bat_Ctrl_Num, string OwnerKey, string VendBatKey, string FBCount, bool isProduction, string CarrierName, string ICS, string imageFilePath, string SCAC, string systemUserName, string systemMachineName)
        {
            Image imageFile = Image.FromFile(imageFilePath);
            bool retval = false;
            int affectedRows = 0;
            DataSet dsOwnerCode = new DataSet();
            string OwnerCode;
            string queryOwnerCode = string.Format(@"SELECT {0}
                                      FROM Entity(NOLOCK)
                                      WHERE OwnerKey = @OwnerKey", isProduction ? "OwnerCodeProd" : "OwnerCodeTest");

            string queryUpdateBatchDE = @"UPDATE [Batch_DE]
                                           SET [Owner_Key] = @Owner_Key
                                              ,[Owner_Code] = @Owner_Code
                                              ,[Vend_SCAC] = @Vend_SCAC
                                              ,[FB_Cnt] = @FB_Cnt
                                              ,[IN_DE_DTM] = @IN_DE_DTM
                                              ,[Batch_Status] = 'IN DE'
                                              ,[%T004] = @T004
                                              ,[%T006] = @T006
                                              ,[%T007] = [%T007]+':'+@T007
                                              ,[%T008] = @T008
                                         WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            string queryUpdateFBSCAC = @"UPDATE [FB_SCAC]
                                           SET [Vend_SCAC] = @Vend_SCAC
                                              ,[FB_Cnt] = @FB_Cnt
                                         WHERE [Bat_Ctrl_Num] = @Bat_Ctrl_Num";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();

                //Get OwnerCode
                ParameterInfo[] paramOwnerCode = new ParameterInfo[1];
                paramOwnerCode[0] = new ParameterInfo("@OwnerKey", OwnerKey);
                dsOwnerCode = dal.ExecuteDataSet(queryOwnerCode, CommandType.Text, paramOwnerCode);
                OwnerCode = dsOwnerCode.Tables[0].Rows[0][0].ToString();

                //update Batch_DE
                ParameterInfo[] paramBatchDE = new ParameterInfo[10];
                paramBatchDE[0] = new ParameterInfo("@Bat_Ctrl_Num", Bat_Ctrl_Num);
                paramBatchDE[1] = new ParameterInfo("@Owner_Key", OwnerKey);
                paramBatchDE[2] = new ParameterInfo("@Owner_Code", OwnerCode);
                paramBatchDE[3] = new ParameterInfo("@Vend_SCAC", VendBatKey);
                paramBatchDE[4] = new ParameterInfo("@FB_Cnt", FBCount);
                paramBatchDE[5] = new ParameterInfo("@IN_DE_DTM", DateTime.Now.ToString());
                if (CarrierName == string.Empty)
                    paramBatchDE[6] = new ParameterInfo("@T004", DBNull.Value);
                else
                    paramBatchDE[6] = new ParameterInfo("@T004", CarrierName);
                paramBatchDE[7] = new ParameterInfo("@T006", systemUserName);
                paramBatchDE[8] = new ParameterInfo("@T007", systemMachineName);
                if (ICS == string.Empty)
                    paramBatchDE[9] = new ParameterInfo("@T008", DBNull.Value);
                else
                    paramBatchDE[9] = new ParameterInfo("@T008", ICS);
                affectedRows = dal.ExecuteNonQuery(queryUpdateBatchDE, CommandType.Text, paramBatchDE);

                //update FB_SCAC
                ParameterInfo[] paramFBSCAC = new ParameterInfo[3];

                paramFBSCAC[0] = new ParameterInfo("@Bat_Ctrl_Num", Bat_Ctrl_Num);
                paramFBSCAC[1] = new ParameterInfo("@Vend_SCAC", VendBatKey);
                paramFBSCAC[2] = new ParameterInfo("@FB_Cnt", FBCount);
                affectedRows = dal.ExecuteNonQuery(queryUpdateFBSCAC, CommandType.Text, paramFBSCAC);

                //update image-insert header page
                updateImage(SCAC, Bat_Ctrl_Num, imageFile, ICS, dal);
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception error)
            {
                retval = false;
                dal.RollBackTransaction();
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }
        
        private DataSet selectHeaderInfo(ArrayList parameters, DALHelper dal)
        {
            DataSet retval = new DataSet();
            DataSet ds = new DataSet();
            string query = @"SELECT
	                            'MXX' + Bat_Ctrl_Num AS BatchNumber,
	                            CONVERT(VARCHAR(10), [NEW_DTM], 110) AS 'Date',
	                            '' AS Mode,
	                            Vend_SCAC AS SCAC,
	                            '' AS Client,
	                            Owner_Key AS OwnerKey,
	                            Owner_Code AS OwnerCode,
                                '' AS Carrier,
	                            '' AS 'Level',
	                            FB_Cnt AS Bills,
	                            Inv_Cnt AS Invoices,
	                            Bat_Amt AS Amount,
	                            '' AS CarrierNotes,
	                            '' AS ClientSpecific                      
                            FROM Batch_DE(NOLOCK)                            
                            WHERE  Bat_Ctrl_Num = @BatchNumber";
            ParameterInfo[] param = new ParameterInfo[1];
            param[0] = new ParameterInfo("@BatchNumber", parameters[0].ToString());
            try
            {
                retval = dal.ExecuteDataSet(query, CommandType.Text, param);
            }
            catch
            {
                retval = null;
            }


            ParameterInfo[] param2 = new ParameterInfo[2];
            try
            {

                for (int ctr = 0; ctr < 4; ctr++)
                {
                    if (ctr == 0)
                    {
                        query = @"SELECT                            
                                    OwnerName AS Client
                                FROM Entity
                                WHERE  OwnerKey = @OwnerKey";
                        param2 = new ParameterInfo[1];
                        param2[0] = new ParameterInfo("@OwnerKey", retval.Tables[0].Rows[0]["OwnerKey"].ToString().Trim());
                    }
                    if (ctr == 1)
                    {
                        query = @"SELECT
                                        Mode AS Mode,
                                        Carrier.Level AS 'Level',
                                        KeyingInstructions AS CarrierNotes
                                    FROM Carrier
                                    WHERE  DeScac = @DeScac";
                        param2 = new ParameterInfo[1];
                        param2[0] = new ParameterInfo("@DeScac", retval.Tables[0].Rows[0]["SCAC"].ToString().Trim());

                    }
                    if (ctr == 2)
                    {
                        query = @"SELECT KeyingInstructions AS ClientSpecific
                                FROM KeyingInstructions 
                                WHERE KeyingInstructions.DeScac = @DeScac
                                AND KeyingInstructions.OwnerKey = @OwnerKey";


                        param2 = new ParameterInfo[2];
                        param2[0] = new ParameterInfo("@DeScac", retval.Tables[0].Rows[0]["SCAC"].ToString().Trim());
                        param2[1] = new ParameterInfo("@OwnerKey", retval.Tables[0].Rows[0]["OwnerKey"].ToString().Trim());
                    }

                    if (ctr == 3)
                    {
                        query = @"SELECT ScacName AS Carrier
                                FROM EntityScac 
                                WHERE EntityScac.OwnerKey = @OwnerKey 
                                AND EntityScac.DeScac = @DeScac
                                AND ScacName = @ScacName";


                        param2 = new ParameterInfo[3];
                        param2[0] = new ParameterInfo("@OwnerKey", retval.Tables[0].Rows[0]["OwnerKey"].ToString().Trim());
                        param2[1] = new ParameterInfo("@DeScac", retval.Tables[0].Rows[0]["SCAC"].ToString().Trim());
                        param2[2] = new ParameterInfo("@ScacName", parameters[1].ToString());
                    }


                    ds = dal.ExecuteDataSet(query, CommandType.Text, param2);


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ctr == 0)
                        {
                            retval.Tables[0].Rows[0]["Client"] = ds.Tables[0].Rows[0]["Client"];
                        }
                        if (ctr == 1)
                        {
                            retval.Tables[0].Rows[0]["Mode"] = ds.Tables[0].Rows[0]["Mode"];
                            retval.Tables[0].Rows[0]["Level"] = ds.Tables[0].Rows[0]["Level"];
                            retval.Tables[0].Rows[0]["CarrierNotes"] = ds.Tables[0].Rows[0]["CarrierNotes"];

                        }
                        if (ctr == 2)
                        {
                            retval.Tables[0].Rows[0]["ClientSpecific"] = ds.Tables[0].Rows[0]["ClientSpecific"];
                        }
                        if (ctr == 3)
                        {
                            retval.Tables[0].Rows[0]["Carrier"] = ds.Tables[0].Rows[0]["Carrier"];
                        }
                    }
                }
            }
            catch
            {
                retval = null;
            }
            return retval;
        }

        private void updateImage(string SCAC, string batchNumber, Image imageFile, string ICS, DALHelper dal)
        {
            ArrayList parameter = new ArrayList();
            DataSet header;
            parameter.Clear();
            parameter.Add(batchNumber);
            parameter.Add(SCAC);
            string fileSaveAsPath = string.Empty;
            try
            {
                header = this.selectHeaderInfo(parameter, dal);
                fileSaveAsPath = getCompleteDestinationFolderPath(ConfigurationManager.AppSettings["ImageDestinationPathBackup"], getTodayFolder()) + "\\" + batchNumber + ".tif";
                CommonLibrary.CommonMethod.createTiffImageQA(fileSaveAsPath, ICS, header.Tables[0].Rows[0], imageFile);
                File.Copy(fileSaveAsPath, ConfigurationManager.AppSettings["ImageDestinationPath"] + batchNumber + ".tif");
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private string getCompleteDestinationFolderPath(string baseFolderPath, string folderName)
        {
            string retval = baseFolderPath + folderName;
            if (!Directory.Exists(retval))
            {
                Directory.CreateDirectory(retval);
            }
            return retval;
        }

        private string getTodayFolder()
        {
            return DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + DateTime.Now.Year.ToString("0000");
        }
    }
}
