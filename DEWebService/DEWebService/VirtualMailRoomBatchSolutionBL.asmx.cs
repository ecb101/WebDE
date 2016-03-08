using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using DAL;
using CommonLibrary;
namespace DEWebService
{
    /// <summary>
    /// Summary description for VirtualMailRoomBatchSolutionBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VirtualMailRoomBatchSolutionBL : BaseBLogic
    {   
        private ArrayList parameter = new ArrayList();
        public VirtualMailRoomBatchSolutionBL()
        {
        }
        public override void setQueries()
        {
            
        }

        [WebMethod]
        public DataSet selectBatch()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT Bat_Ctrl_Num
                            FROM Batch_DE
                            WHERE Batch_Status = 'IN DE'
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
        public DataSet selectReBatches()
        {
            DataSet retval = new DataSet();
            string query = string.Empty;
            query = @"SELECT BDE.Bat_Ctrl_Num AS [BatchNumber],
				CASE WHEN IMB.CompletelyBatch = 1 
					THEN IMB.ToFolder + '' + IMB.[FileName] 
					ELSE IMB.FromFolder + '' + IMB.[FileName] END AS [FilePath]
                FROM Batch_DE(NOLOCK) BDE  
                JOIN ImagesBatched(NOLOCK) IMB ON BDE.Bat_Ctrl_Num = IMB.Bat_Ctrl_Num
                JOIN Batch_DE_Ext(NOLOCK) BDX ON BDE.BatchID = BDX.BatchID AND BDX.DEVer = 'NEW'
                WHERE BDE.DE_START_DTM BETWEEN DATEADD(MONTH,-3,GETDATE()) AND GETDATE()";
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
                            FROM Batch_DE                            
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

        /*
        public DataSet selectScacName(ArrayList parameters)
        {
            DataSet retval = new DataSet();
            DataSet ds = new DataSet();
            string query = @"Select Owner_Key,Vend_SCAC
                            FROM Batch_DE
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            ParameterInfoOleDB[] param = new ParameterInfoOleDB[1];
            param[0] = new ParameterInfoOleDB("@Bat_Ctrl_Num", parameters[0].ToString());
            try
            {
                dalBatch_DE.OpenDB();
                ds = dalBatch_DE.ExecuteDataSet(query, CommandType.Text, param);
            }
            catch
            {
                retval = null;
            }
            finally
            {
                dalBatch_DE.CloseDB();
            }


            query = @"SELECT ScacName 
                    FROM EntityScac
                    WHERE OwnerKey = @OwnerKey
                        AND DeScac = @DeScac";

            ParameterInfoOleDB[] param2 = new ParameterInfoOleDB[2];
            param2[0] = new ParameterInfoOleDB("@OwnerKey", ds.Tables[0].Rows[0]["Owner_Key"].ToString().Trim());
            param2[1] = new ParameterInfoOleDB("@DeScac", ds.Tables[0].Rows[0]["Vend_SCAC"].ToString().Trim());

            try
            {
                dalBatchHeader.OpenDB();
                retval = dalBatchHeader.ExecuteDataSet(query, CommandType.Text, param2);
            }
            catch
            {
                retval = null;
            }
            finally
            {
                dalBatchHeader.CloseDB();
            }
            return retval;
        }
        */

        [WebMethod]
        public DataSet selectClient()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT OwnerName + ' (' +OwnerKey+ ')' AS Client,
                                    OwnerKey AS OwnerKey
                            FROM Entity
                            ORDER BY OwnerName";
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
        public DataSet selectSCAC(object Parameters)
        {
            ArrayList parameters = (ArrayList)Parameters;
            DataSet retval = new DataSet();
            string query = @"SELECT                                 
                                '!No Scac' AS [Name],
                                'NOSCAC' AS [Scac],
                                '' AS [City/State]
                            FROM EntityScac
                            UNION
                            SELECT
                                ScacName AS [Name],
                                DeScac AS [Scac],
                                RemitCity+','+RemitState AS [City/State]
                            FROM EntityScac
                            WHERE OwnerKey = '*' OR OwnerKey = @OwnerKey";
            ParameterInfo[] param = new ParameterInfo[1];
            param[0] = new ParameterInfo("@OwnerKey", parameters[0].ToString());
            try
            {
                try
                {
                    dal.OpenDB();
                    retval = dal.ExecuteDataSet(query, CommandType.Text, param);
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
        public string createBatches(string OwnerKey, string VendBatKey, string FBCount, bool isProduction, string CarrierName, string ICS, string imageFileName, Image imageFile, ArrayList stampPages, ArrayList pages, string stampLabel, string SCAC, bool isSplitBatch, ArrayList splitPoint, bool isEphesoftDrop, string imageIssue, string systemUserName)
        {
            string retval = string.Empty;            
            ArrayList batchCreated = new ArrayList();
            ArrayList splitPages = new ArrayList();
            bool isStart = true;
            bool isSplitPoint = false;
            string rootBatch = string.Empty;
            int splitCount = 0;
            try
            {                       
                foreach (object o in splitPoint)
                {
                    if (((ImageStamp)o).IsForSplit && ((ImageStamp)o).IsStamped)
                        splitCount++;
                }
                splitCount = isSplitBatch ? splitCount + 1 : 0;//include the 1st split                
                dal.OpenDB();
                dal.BeginTransaction();
                batchCreated.Add(createBatch(dal, OwnerKey, VendBatKey, FBCount, isProduction, CarrierName, ICS, imageFileName, imageFile, stampPages, pages, stampLabel, SCAC, isSplitBatch, true, "", "", splitCount, isEphesoftDrop, imageIssue, systemUserName));
                if (isSplitBatch)//is create split batches
                {
                    rootBatch = dal.ExecuteDataSet(string.Format("SELECT Bat_Ctrl_Num FROM Batch_DE WHERE BatchID = {0}", batchCreated[0].ToString())).Tables[0].Rows[0][0].ToString();
                    splitPages.Clear();
                    foreach (object o in splitPoint)
                    {
                        if (((ImageStamp)o).IsForSplit )
                        {
                            
                            if (((ImageStamp)o).IsStamped && !isStart)
                            {
                                if (!isSplitPoint) 
                                    isSplitPoint = true;
                                batchCreated.Add(createBatch(dal, OwnerKey, VendBatKey, FBCount, isProduction, CarrierName, ICS, imageFileName, imageFile, stampPages, splitPages, stampLabel, SCAC, isSplitBatch, false, batchCreated[0].ToString(), rootBatch, 0, isEphesoftDrop, imageIssue, systemUserName));
                                splitPages.Clear();                                
                                splitPages.Add(((ImageStamp)o).Page);
                                FBCount = ((ImageStamp)o).SplitFBCount.ToString();
                            }
                            else
                            {
                                if (pages.Contains(((ImageStamp)o).Page))
                                {
                                    splitPages.Add(((ImageStamp)o).Page);
                                    if (isStart)
                                    {
                                        FBCount = ((ImageStamp)o).SplitFBCount.ToString();
                                        isStart = false;
                                    }
                                }
                            }
                        }
                    }
                    if (isSplitPoint)
                        batchCreated.Add(createBatch(dal, OwnerKey, VendBatKey, FBCount, isProduction, CarrierName, ICS, imageFileName, imageFile, stampPages, splitPages, stampLabel, SCAC, isSplitBatch, false, batchCreated[0].ToString(), rootBatch, 0, isEphesoftDrop, imageIssue, systemUserName));
                }
                //commit all
                string tempQuery = string.Empty;
                bool isFirst = true;
                foreach (object o in batchCreated)
                {
                    if (isFirst)
                    {
                        isFirst = false;
                        tempQuery = tempQuery + o.ToString();
                    }
                    else
                        tempQuery = tempQuery + ","+o.ToString();
                    //retval = retval + o.ToString() + "\n";
                }
                DataSet dsTemp = new DataSet();
                dsTemp = dal.ExecuteDataSet(string.Format("SELECT Bat_Ctrl_Num FROM Batch_DE WHERE BatchID IN ({0})", tempQuery));
                foreach (DataRow row in dsTemp.Tables[0].Rows)
                {
                    retval = retval + row["Bat_Ctrl_Num"].ToString() + "\n";
                }
                
                dal.CommitTransaction();                
            }
            catch (Exception error)
            {
                dal.RollBackTransaction();
                foreach (object batch in batchCreated)
                {
                    if (File.Exists(ConfigurationManager.AppSettings["ImageDestinationPath"] + batch.ToString() + ".tif"))
                    {
                        File.Delete(ConfigurationManager.AppSettings["ImageDestinationPath"] + batch.ToString() + ".tif");
                    }
                    if (File.Exists(getCompleteDestinationFolderPath(ConfigurationManager.AppSettings["ImageDestinationPathBackup"], getTodayFolder()) + "\\" + batch.ToString() + ".tif"))
                    {
                        File.Delete(getCompleteDestinationFolderPath(ConfigurationManager.AppSettings["ImageDestinationPathBackup"], getTodayFolder()) + "\\" + batch.ToString() + ".tif");
                    }
                }
                retval = string.Empty;
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }

            return retval;
        }

        private string createBatch(DALHelper dalDataEntryDB, string OwnerKey, string VendBatKey, string FBCount, bool isProduction, string CarrierName, string ICS, string imageFileName, Image imageFile, ArrayList stampPages, ArrayList pages, string stampLabel, string SCAC, bool isSplitBatch, bool isRootBatch, string rootBatchID, string rootBatch, int splitCount, bool isEphesoftDrop, string imageIssue, string systemUserName)
        {
            string retval = string.Empty;
            DataSet dsbatch = new DataSet();
            DataSet dsOwnerCode = new DataSet();
            DataSet dsReservedRange = new DataSet();
            DataSet dsSite = new DataSet();
            DataSet dsDEVer = new DataSet();
            string batchNumber = string.Empty;
            string siteID = string.Empty;
            string imageDropPath = string.Empty;
            long batchID;
            string OwnerCode;
            int start = 0;
            int end = 0;
            int affectedRows = 0;
            string queryOwnerCode = string.Format(@"SELECT {0}
                                      FROM Entity
                                      WHERE OwnerKey = @OwnerKey", isProduction ? "OwnerCodeProd" : "OwnerCodeTest");
            string query = string.Format(@"SELECT IDCounter FROM SiteIDController WHERE SiteID = {0} AND IDType IN('BatFileID','BatchID') ORDER BY IDType", ConfigurationManager.AppSettings["SiteID"]);//string query = @"SELECT TOP 1 Bat_Ctrl_Num FROM BatchNumberCounter";

            string queryUpdate = string.Format(@"UPDATE SiteIDController SET IDCounter = IDCounter+1 WHERE SiteID = {0} AND IDType IN ('BatFileID','BatchID')", ConfigurationManager.AppSettings["SiteID"]);//string queryUpdate = @"UPDATE BatchNumberCounter SET Bat_Ctrl_Num = Bat_Ctrl_Num+1";

            string queryInsertBatchDE1 = @"INSERT INTO Batch_DE
                                           (BatchID
                                           ,Bat_Ctrl_Num
                                           ,Active
                                           ,Owner_Key
                                           ,Owner_Code
                                           ,Vend_SCAC
                                           ,Vend_Bat_Key
                                           ,FB_Cnt
                                           ,NEW_DTM
                                           ,IN_DE_DTM
                                           ,Batch_Status
                                           ,[%T005]
                                           ,[%T006]
                                           ,[%T007]";

            string queryInsertBatchDE2 = @")
                                            VALUES
                                           (@BatchID
                                           ,@Bat_Ctrl_Num
                                           ,1
                                           ,@Owner_Key
                                           ,@Owner_Code
                                           ,@Vend_SCAC
                                           ,@Vend_Bat_Key
                                           ,@FB_Cnt
                                           ,@NEW_DTM
                                           ,@IN_DE_DTM
                                           ,@Batch_Status
                                           ,@T005
                                           ,@T006
                                           ,@T007";

            string queryInsertBatchDE = string.Empty;
            string queryInsertFBSCAC = @"INSERT INTO FB_SCAC
                                           (BatchID
                                           ,Bat_Ctrl_Num
                                           ,SEQ
                                           ,[TimeStamp]
                                           ,Vend_SCAC
                                           ,Inv_Cnt
                                           ,FB_Cnt
                                           ,LI_Cnt
                                           ,Bat_Amt
                                           ,f_TimeStamp)
                                     VALUES
                                           (@BatchID
                                           ,@Bat_Ctrl_Num
                                           ,@SEQ
                                           ,@TimeStamp
                                           ,@Vend_SCAC
                                           ,@Inv_Cnt
                                           ,@FB_Cnt
                                           ,@LI_Cnt
                                           ,@Bat_Amt
                                           ,@TimeStamp)";
            string queryInsertBatchDESplit = @"INSERT INTO Batch_DE_Split
                                                       (BatchID_Root
                                                       ,Bat_Ctrl_Num_Root
                                                       ,BatchID_Split
                                                       ,Bat_Ctrl_Num_Split
                                                       ,Batch_Status)
                                                 VALUES
                                                       (@BatchID_Root
                                                       ,@Bat_Ctrl_Num_Root
                                                       ,@BatchID_Split
                                                       ,@Bat_Ctrl_Num_Split           
                                                       ,'SPLIT')";
            string queryInsertBatchExt = @"INSERT INTO [Batch_DE_ext]
                                               ([BatchID]
                                               ,[Bat_Ctrl_Num]
                                               ,[DESiteID]
                                               ,[QASiteID]
                                               ,[AssignDate]
                                               ,[AssignBy]
                                               ,[TransmissionId]
                                               ,[ImageID]
                                               ,[CombinedImageID]
                                               ,[BatchImagePath]
                                               ,[SplitBatchCount]
                                               ,[DEVer]
                                               ,[f_NEW_DTM]
                                               ,[f_IN_DE_DTM]
                                               ,[f_AssignDate]
                                               ,[BatOwner_Key]
                                               ,[BatVend_SCAC])
                                         VALUES
                                               (@BatchID
                                               ,@Bat_Ctrl_Num
                                               ,@DESiteID
                                               ,1
                                               ,@UTCDate
                                               ,'VMR'
                                               ,0
                                               ,@ImageID
                                               ,@CombinedImageID
                                               ,@BatchImagePath
                                               ,@SplitBatchCount
                                               ,@DEVer
                                               ,@UTCDate
                                               ,@UTCDate
                                               ,@UTCDate
                                               ,@BatOwner_Key
                                               ,@BatVend_SCAC)";
            string querySelectSite = @"SELECT SiteRoute,ImageDropPath FROM DeSiteRouteConfig src
                                    INNER JOIN SiteMaster sm ON src.SiteRoute = sm.SiteID
                                    WHERE src.DeSiteRouteConfigId = dbo.Fn_getDESiteRoute(@Owner_Key,@Vend_SCAC,@NEW_DTM)";
            string querySelectDEVer = @"SELECT DEVer FROM DEAppVerConfig
                                    WHERE DeAppVerConfigId = dbo.fn_getDEAppVersion(@Owner_Key,@Vend_SCAC,@NEW_DTM)";
            try
            {
                updateLocalBatchControlNumber(dalDataEntryDB);

                //update batch control number by 1
                affectedRows = dalDataEntryDB.ExecuteNonQuery(queryUpdate, CommandType.Text);

                //get reserved range
                dsReservedRange = updateRemainingReserveBatchBuff(dalDataEntryDB);//dal.ExecuteDataSet(selectReservedRangeQuery, CommandType.Text);
                start = Convert.ToInt32(dsReservedRange.Tables[0].Rows[0]["StartBatCtrlNum"]);
                end = Convert.ToInt32(dsReservedRange.Tables[0].Rows[0]["EndBatCtrlNum"]);

                //Get OwnerCode
                ParameterInfo[] paramOwnerCode = new ParameterInfo[1];
                paramOwnerCode[0] = new ParameterInfo("@OwnerKey", OwnerKey);
                dsOwnerCode = dalDataEntryDB.ExecuteDataSet(queryOwnerCode, CommandType.Text, paramOwnerCode);
                OwnerCode = dsOwnerCode.Tables[0].Rows[0][0].ToString();

                //get latest Batch control number in batchheader database
                dsbatch = dalDataEntryDB.ExecuteDataSet(query, CommandType.Text);
                batchID = Convert.ToInt64(dsbatch.Tables[0].Rows[0][0]) - 1;
                batchNumber = (Convert.ToInt32(dsbatch.Tables[0].Rows[1][0]) - 1).ToString();                
                //check if within range
                if (Convert.ToInt32(batchNumber) < start || Convert.ToInt32(batchNumber) > end)
                    throw new Exception("Created batch number is not within range of the current reserved batches.");

                //batchNumber = CommonMethod.base36Encode(Convert.ToInt64(batchNumber));//batchNumber.PadLeft(5, '0');
                //if (batchNumber.Length > 5)
                //    throw new Exception("Batch number limit is reached please recycle batch number and set it back to 0.");
                //else
                batchNumber = batchNumber.PadLeft(5, '0');

                //add record in Batch_DE                
                ParameterInfo[] paramBatchDE;
                if (CarrierName == string.Empty && ICS == string.Empty)
                    paramBatchDE = new ParameterInfo[13];
                else if (CarrierName != string.Empty && ICS == string.Empty)
                {
                    queryInsertBatchDE1 = queryInsertBatchDE1 + ",[%T004]";
                    queryInsertBatchDE2 = queryInsertBatchDE2 + ",@T004";
                    paramBatchDE = new ParameterInfo[14];
                    paramBatchDE[13] = new ParameterInfo("@T004", CarrierName);
                }
                else if (CarrierName == string.Empty && ICS != string.Empty)
                {
                    queryInsertBatchDE1 = queryInsertBatchDE1 + ",[%T008]";
                    queryInsertBatchDE2 = queryInsertBatchDE2 + ",@T008";
                    paramBatchDE = new ParameterInfo[14];
                    paramBatchDE[13] = new ParameterInfo("@T008", ICS);
                }
                else
                {
                    queryInsertBatchDE1 = queryInsertBatchDE1 + ",[%T004]";
                    queryInsertBatchDE2 = queryInsertBatchDE2 + ",@T004";
                    queryInsertBatchDE1 = queryInsertBatchDE1 + ",[%T008]";
                    queryInsertBatchDE2 = queryInsertBatchDE2 + ",@T008";
                    paramBatchDE = new ParameterInfo[15];
                    paramBatchDE[13] = new ParameterInfo("@T004", CarrierName);
                    paramBatchDE[14] = new ParameterInfo("@T008", ICS);
                }
                DateTime dt = this.GetServerDate(dal);
                queryInsertBatchDE = queryInsertBatchDE1 + queryInsertBatchDE2 + ")";
                paramBatchDE[0] = new ParameterInfo("@BatchID", batchID);
                paramBatchDE[1] = new ParameterInfo("@Bat_Ctrl_Num", batchNumber);
                paramBatchDE[2] = new ParameterInfo("@Owner_Key", OwnerKey);
                paramBatchDE[3] = new ParameterInfo("@Owner_Code", OwnerCode);
                paramBatchDE[4] = new ParameterInfo("@Vend_SCAC", VendBatKey);
                paramBatchDE[5] = new ParameterInfo("@Vend_Bat_Key", "MXX" + batchNumber);
                paramBatchDE[6] = new ParameterInfo("@FB_Cnt", FBCount);
                paramBatchDE[7] = new ParameterInfo("@NEW_DTM", dt.ToString());
                paramBatchDE[8] = new ParameterInfo("@IN_DE_DTM", dt.ToString());                
                paramBatchDE[9] = new ParameterInfo("@Batch_Status", !isSplitBatch ? "IN DE" : (!isRootBatch ? "IN DE" : "SPLIT"));
                paramBatchDE[10] = new ParameterInfo("@T005", dt.ToString());
                paramBatchDE[11] = new ParameterInfo("@T006", System.Environment.UserName);
                paramBatchDE[12] = new ParameterInfo("@T007", System.Environment.MachineName);

                affectedRows = dalDataEntryDB.ExecuteNonQuery(queryInsertBatchDE, CommandType.Text, paramBatchDE);

                //add record in Batch_DE_Ext
                ParameterInfo[] paramSite = new ParameterInfo[3];                
                paramSite[0] = new ParameterInfo("@Owner_Key", OwnerKey);
                paramSite[1] = new ParameterInfo("@Vend_SCAC", VendBatKey);
                paramSite[2] = new ParameterInfo("@NEW_DTM", dt.ToShortDateString());
                dsSite = dalDataEntryDB.ExecuteDataSet(querySelectSite, CommandType.Text, paramSite);
                dsDEVer = dalDataEntryDB.ExecuteDataSet(querySelectDEVer, CommandType.Text, paramSite);
                string backupFolderPath = getCompleteDestinationFolderPath(ConfigurationManager.AppSettings["ImageDestinationPathBackup"], getTodayFolder()) + "\\" + batchNumber + ".tif";
                ParameterInfo[] paramBatchExt = new ParameterInfo[11];
                paramBatchExt[0] = new ParameterInfo("@BatchID", batchID);
                paramBatchExt[1] = new ParameterInfo("@Bat_Ctrl_Num", batchNumber);
                /* 11.05.12 Remove
                if (ICS.Contains("ICS") || ICS.Contains("RFS") || ICS.Contains("Credit Note"))
                {
                    paramBatchExt[2] = new ParameterInfo("@DESiteID", "1"); 
                } else {
                   paramBatchExt[2] = new ParameterInfo("@DESiteID", dsSite.Tables.Count > 0 && dsSite.Tables[0].Rows.Count > 0 ? dsSite.Tables[0].Rows[0][0].ToString() : "1");                
                }*/
                // 11.05.12 Added the next line
                if (dsSite.Tables.Count > 0 && dsSite.Tables[0].Rows.Count > 0)
                {
                    siteID = dsSite.Tables[0].Rows[0]["SiteRoute"].ToString().Trim();
                    if(dsSite.Tables[0].Rows[0]["ImageDropPath"].ToString().Trim() != string.Empty)
                    {
                        imageDropPath = dsSite.Tables[0].Rows[0]["ImageDropPath"].ToString().Trim() + "\\" + dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00");
                        try
                        {
                            if (!Directory.Exists(imageDropPath))
                            {
                                Directory.CreateDirectory(imageDropPath);
                            }
                            imageDropPath = imageDropPath + "\\" + batchNumber + ".tif";
                        }
                        catch
                        {
                            imageDropPath = string.Empty;
                        }
                    }                    
                    else
                        imageDropPath = string.Empty;
                }
                else
                {
                    siteID = "1";
                    imageDropPath = string.Empty;
                }

                paramBatchExt[2] = new ParameterInfo("@DESiteID", siteID);//dsSite.Tables.Count > 0 && dsSite.Tables[0].Rows.Count > 0 ? dsSite.Tables[0].Rows[0][0].ToString() : "1");
                string imageID = CommonMethod.getFileName(imageFileName).Substring(0, 8);
                if (imageID.Substring(0, 2) == "15" && imageFileName.Contains(ConfigurationManager.AppSettings["ImageSourcePath"] + "COMBINED IMAGES"))//check if images is combined
                {
                    paramBatchExt[3] = new ParameterInfo("@ImageID", DBNull.Value);
                    paramBatchExt[4] = new ParameterInfo("@CombinedImageID", imageID);
                }
                else
                {
                    paramBatchExt[3] = new ParameterInfo("@ImageID", imageID);
                    paramBatchExt[4] = new ParameterInfo("@CombinedImageID", DBNull.Value);
                }
                paramBatchExt[5] = new ParameterInfo("@BatchImagePath", backupFolderPath);
                paramBatchExt[6] = new ParameterInfo("@SplitBatchCount", splitCount);
                paramBatchExt[7] = new ParameterInfo("@DEVer", dsDEVer.Tables.Count > 0 && dsDEVer.Tables[0].Rows.Count > 0 ? dsDEVer.Tables[0].Rows[0][0].ToString() : "OLD");
                paramBatchExt[8] = new ParameterInfo("@UTCDate", dt.ToString());
                paramBatchExt[9] = new ParameterInfo("@BatOwner_Key", OwnerKey);
                paramBatchExt[10] = new ParameterInfo("@BatVend_SCAC", VendBatKey);
                affectedRows = dalDataEntryDB.ExecuteNonQuery(queryInsertBatchExt, CommandType.Text, paramBatchExt);

                //add record in FB_SCAC
                ParameterInfo[] paramFBSCAC = new ParameterInfo[9];
                paramFBSCAC[0] = new ParameterInfo("@BatchID", batchID);
                paramFBSCAC[1] = new ParameterInfo("@Bat_Ctrl_Num", batchNumber);
                paramFBSCAC[2] = new ParameterInfo("@SEQ", "1");
                paramFBSCAC[3] = new ParameterInfo("@TimeStamp", dt.ToString());
                paramFBSCAC[4] = new ParameterInfo("@Vend_SCAC", VendBatKey);
                paramFBSCAC[5] = new ParameterInfo("@Inv_Cnt", "0");
                paramFBSCAC[6] = new ParameterInfo("@FB_Cnt", FBCount);
                paramFBSCAC[7] = new ParameterInfo("@LI_Cnt", "0");
                paramFBSCAC[8] = new ParameterInfo("@Bat_Amt", "$0.00");
                affectedRows = dalDataEntryDB.ExecuteNonQuery(queryInsertFBSCAC, CommandType.Text, paramFBSCAC);

                //add record in Batch_DE_Split
                if (!isRootBatch)
                {
                    ParameterInfo[] paramBatchDESplit = new ParameterInfo[4];
                    paramBatchDESplit[0] = new ParameterInfo("@BatchID_Root", rootBatchID);
                    paramBatchDESplit[1] = new ParameterInfo("@Bat_Ctrl_Num_Root", rootBatch);
                    paramBatchDESplit[2] = new ParameterInfo("@BatchID_Split", batchID);
                    paramBatchDESplit[3] = new ParameterInfo("@Bat_Ctrl_Num_Split", batchNumber);
                    affectedRows = dalDataEntryDB.ExecuteNonQuery(queryInsertBatchDESplit, CommandType.Text, paramBatchDESplit);
                }

                insertBatchPageCounter(batchNumber, "MXX" + batchNumber, "MXX" + batchNumber + ".tif", pages.Count, dalDataEntryDB, batchID, dt);
                this.createImage(SCAC, batchNumber, imageFile, stampPages, pages, stampLabel, ICS, dalDataEntryDB, rootBatch, backupFolderPath, isEphesoftDrop, isRootBatch, imageIssue, CarrierName, imageDropPath);
                BatchAuditTrailInsert(batchNumber, "100", dalDataEntryDB, systemUserName);
                retval = batchID.ToString();
            }
            catch
            {
                if (File.Exists(imageDropPath))
                {
                    File.Delete(imageDropPath);
                }
                retval = string.Empty;
                throw;
            }
            return retval;
        }
        
        private DataSet updateRemainingReserveBatchBuff(DALHelper dalBatchBuff)
        {            
            DataSet ds = new DataSet();
            int affectedRows = 0;
            selectQuery = @"SELECT TOP(1)BatchBuffID, StartBatCtrlNum, EndBatCtrlNum
                            FROM BatchBuff
                            WHERE RemainingReservedCount>0";

            updateQuery = @"UPDATE BatchBuff 
                            SET RemainingReservedCount = RemainingReservedCount-1
                            WHERE BatchBuffID = @BatchBuffID";
            try
            {
                ds = dalBatchBuff.ExecuteDataSet(selectQuery, CommandType.Text);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    ParameterInfo[] param = new ParameterInfo[1];
                    param[0] = new ParameterInfo("@BatchBuffID", ds.Tables[0].Rows[0][0].ToString());
                    affectedRows = dalBatchBuff.ExecuteNonQuery(updateQuery, CommandType.Text, param);
                }
            }
            catch (Exception e)
            {                
                throw e;
            }
            return ds;
        }

        private bool insertBatchPageCounter(string BatchControlNumber, string VendBatKey ,string batchImageFilename, int pageCount, DALHelper dal, long BatchID, DateTime UTCDate)
        {
            bool retval = false;
            int affectedRows = 0;
            insertQuery = @"INSERT INTO BatchPageCounter
                                   (Bat_Ctrl_Num
                                   ,Vend_Bat_Key
                                   ,BatchImageFile
                                   ,BatchImageCount
                                   ,BatchDate
                                   ,BatchID)
                             VALUES
                                   (@Bat_Ctrl_Num
                                   ,@Vend_Bat_Key
                                   ,@BatchImageFile
                                   ,@BatchImageCount
                                   ,@BatchDate
                                   ,@BatchID)";
            try
            {
                ParameterInfo[] param = new ParameterInfo[6];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", BatchControlNumber);
                param[1] = new ParameterInfo("@Vend_Bat_Key", VendBatKey);
                param[2] = new ParameterInfo("@BatchImageFile", batchImageFilename);
                param[3] = new ParameterInfo("@BatchImageCount", pageCount+1);
                param[4] = new ParameterInfo("@BatchDate", UTCDate);
                param[5] = new ParameterInfo("@BatchID", BatchID);
                affectedRows = dal.ExecuteNonQuery(insertQuery, CommandType.Text, param);
                retval = true;
            }
            catch (Exception e)
            {                
                throw e;
            }
            return retval;
        }

        private bool updateLocalBatchControlNumber(DALHelper dalBatchBuff)
        {
            bool retval = false;
            DataSet ds = new DataSet();                        
            selectQuery = @"SELECT TOP(1)BatchBuffID, RemainingReservedCount,StartBatCtrlNum,OrigReservedCount
                            FROM BatchBuff
                            WHERE RemainingReservedCount>0";

            string updateQueryBatchHeader = string.Format(@"UPDATE SiteIDController SET IDCounter = @BatCtrlNum WHERE SiteID = {0} AND IDType = 'BatFileID'", ConfigurationManager.AppSettings["SiteID"]);//string updateQueryBatchHeader = @"UPDATE BatchNumberCounter SET Bat_Ctrl_Num = @BatCtrlNum";
            try
            {
                ds = dalBatchBuff.ExecuteDataSet(selectQuery, CommandType.Text);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    if (ds.Tables[0].Rows[0][1].ToString().Trim() == ds.Tables[0].Rows[0][3].ToString().Trim())//meaning new record na wala pa kuhai, so dapat i-update to StartBatCtrlNum ang Bat_Ctrl_Num
                    {                        
                        ParameterInfo[] param2 = new ParameterInfo[1];
                        param2[0] = new ParameterInfo("@BatCtrlNum", ds.Tables[0].Rows[0][2].ToString());
                        dalBatchBuff.ExecuteNonQuery(updateQueryBatchHeader, CommandType.Text, param2);
                    }
                    retval = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
            return retval;
        }

        [WebMethod]
        public bool isAllowedBatching()
        {
            bool retval = false;
            DataSet ds = new DataSet();
            selectQuery = @"SELECT TOP(1)*
                            FROM BatchBuff
                            WHERE RemainingReservedCount>0";
            try
            {
                dal.OpenDB();
                ds = dal.ExecuteDataSet(selectQuery, CommandType.Text);

                if (ds.Tables[0].Rows.Count == 1)
                {                    
                    retval = true;
                }
                else
                {
                    retval = false;
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
        public bool insertImagesBatched(string from, string to, string batCtrlNum, bool isCompletelyBatched)
        {
            bool retval = false;
            try
            {
                string file = from.Split('\\')[from.ToString().Split('\\').Length - 1];
                ParameterInfo[] param = new ParameterInfo[7];
                string queryImagesBatchedInsert = @"INSERT INTO ImagesBatched
                                                           (ID
                                                           ,FileName
                                                           ,FromFolder
                                                           ,ToFolder
                                                           ,Bat_Ctrl_Num
                                                           ,CompletelyBatch
                                                           ,ProcessedDate
                                                           ,f_ProcessedDate)
                                                     VALUES
                                                           (@ID
                                                           ,@FileName
                                                           ,@FromFolder
                                                           ,@ToFolder
                                                           ,@Bat_Ctrl_Num
                                                           ,@CompletelyBatch
                                                           ,@UTCDate
                                                           ,@UTCDate)";
                dal.OpenDB();
                dal.BeginTransaction();
                param[0] = new ParameterInfo("@ID", file.Split('.')[0]);
                param[1] = new ParameterInfo("@FileName", file);
                param[2] = new ParameterInfo("@FromFolder", from.Substring(0, from.Length - file.Length));
                param[3] = new ParameterInfo("@ToFolder", to.Substring(0, to.Length - file.Length));
                param[4] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                param[5] = new ParameterInfo("@CompletelyBatch", isCompletelyBatched);
                param[6] = new ParameterInfo("@UTCDate", GetServerDate(dal));
                dal.ExecuteNonQuery(queryImagesBatchedInsert, CommandType.Text, param);
                dal.CommitTransaction();
                retval = true;
            }
            catch (Exception error)
            {
                dal.RollBackTransaction();
                retval = false;
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public void auditTrail(string ImageID, string descriptionID, string systemUserName)
        {
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                ImageAuditTrailInsert(ImageID, descriptionID, dal, systemUserName);
                dal.CommitTransaction();
            }
            catch (Exception error)
            {
                dal.RollBackTransaction();
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }
        }

        private void createImage(string SCAC, string batchNumber, Image imageFile, ArrayList stampPages, ArrayList pages, string stampLabel, string ICS, DALHelper dal, string rootBatch, string backupFolderPath, bool isEphesoftDrop, bool isRootBatch, string imageIssue, string carrierName, string imageDropPath)
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
                if (isRootBatch)
                {
                    fileSaveAsPath = ConfigurationManager.AppSettings["ImageDestinationPath"] + batchNumber + ".tif";//+ dr["BatchNumber"].ToString().Trim() + ".tif";updated
                    CommonLibrary.CommonMethod.createTiffImage(fileSaveAsPath, ICS, header.Tables[0].Rows[0], imageFile, stampPages, pages, stampLabel, rootBatch, imageIssue, carrierName);
                    File.Copy(fileSaveAsPath, backupFolderPath);//copy tiff file to a backup folder, sub folder is per daymonthyear                    
                }
                else
                {
                    fileSaveAsPath = backupFolderPath;
                    CommonLibrary.CommonMethod.createTiffImage(fileSaveAsPath, ICS, header.Tables[0].Rows[0], imageFile, stampPages, pages, stampLabel, rootBatch, imageIssue, carrierName);
                }
                if (imageDropPath.Trim() != string.Empty)
                    File.Copy(fileSaveAsPath, imageDropPath);
                try
                {                    
                    if (isEphesoftDrop)
                    {
                        //create and copy tif file to a temp batch folder
                        string sourceFolder = getCompleteDestinationFolderPath(ConfigurationManager.AppSettings["ObjDestinationPathEphesoft"], batchNumber);
                        string DestinationFolder = ConfigurationManager.AppSettings["ImageEphesoftDropOffPath"] + batchNumber;
                        File.Copy(fileSaveAsPath, sourceFolder + @"\" + batchNumber + ".tif");
                        CommonMethod.moveDirectory(sourceFolder, DestinationFolder);//File.Move the entire folder to the Ephesoft drop off folder                         
                    }
                }
                catch
                { }
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
