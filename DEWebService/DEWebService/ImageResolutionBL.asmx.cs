using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections;
using System.Configuration;
using System.Data;
using System.IO;
using System.Threading;
using CommonLibrary;
using DAL;
namespace DEWebService
{
    /// <summary>
    /// Summary description for ImageResolutionBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ImageResolutionBL : BaseBLogic
    {
        public ImageResolutionBL()
        {

        }

        public override void setQueries()
        {
            //throw new NotImplementedException();
        }

        [WebMethod]
        public DataSet selectResolutionDescription()
        {
            DataSet retval = new DataSet();
            string query = @"SELECT ([Description] + ' (' +cast(Code AS nvarchar) +')') AS ResolutionDescription,
                                    [Type],
                                    [Category]
                            FROM ResolutionDescription(NOLOCK)";
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
        public DataSet selectImages()
        {
            DataSet retval = new DataSet();
            DataSet dsReceived = new DataSet("Received");
            DataSet dsManifesting = new DataSet("Manifesting");
            DataSet dsBatching = new DataSet("Batching");
            DataSet dsCombinedManifesting = new DataSet("CombinedManifesting");
            DataSet dsCombinedBatching = new DataSet("CombinedBatching");
            string selectQueryReceived = @"SELECT ImageFiles.ID,FullFolderPath,OriginalFileName,NewFolderPath,NewFileName,ProcessedDate,ErrorDescription
                                            FROM dbo.ImageFiles 
                                            LEFT JOIN (SELECT ID FROM ImageResolution WHERE ResolutionCode = 10) AS TEMP ON TEMP.ID=ImageFiles.ID
                                            WHERE ImageStatus = 'E'
                                            AND TEMP.ID IS NULL
                                            ORDER BY ProcessedDate";
            string selectQueryManifesting = @"SELECT ImgFiles.ID,FullFolderPath,OriginalFileName,NewFolderPath,NewFileName,ProcessedDate,ErrorDescription
                                                FROM ImageFiles ImgFiles
                                                LEFT JOIN (SELECT DISTINCT ImgFiles.ID
			                                                FROM ImageFiles ImgFiles (nolock) 
			                                                INNER JOIN ImagesManifested IM ON ImgFiles.ID = IM.ID
			                                                AND IM.FromFolder<>IM.ToFolder) AS TEMP1 ON TEMP1.ID = ImgFiles.ID
                                                LEFT JOIN (SELECT DISTINCT ImgFiles.ID 
			                                                FROM ImageFiles ImgFiles (nolock) 
			                                                INNER JOIN CombinedImageFiles CIF ON ImgFiles.ID=CIF.ID) AS TEMP2 ON TEMP2.ID = ImgFiles.ID
                                                WHERE ImageStatus = 'A' 
                                                AND ImgFiles.ProcessedDate IS NOT NULL
                                                AND TEMP1.ID IS NULL 
                                                AND TEMP2.ID IS NULL
                                                ORDER BY ImgFiles.ProcessedDate";
            string selectQueryBatching = @"SELECT ImgFiles.ID,FullFolderPath,OriginalFileName,replace(NewFolderPath,'MANIFESTING','BATCHING') AS NewFolderPath,NewFileName,ProcessedDate,ErrorDescription
                                            FROM ImageFiles ImgFiles
                                            INNER JOIN (SELECT DISTINCT ImgFiles.ID
			                                            FROM ImageFiles ImgFiles (nolock) 
			                                            INNER JOIN ImagesManifested IM ON ImgFiles.ID = IM.ID
			                                            AND IM.FromFolder<>IM.ToFolder) AS TEMP1 ON TEMP1.ID=ImgFiles.ID
                                            LEFT JOIN (SELECT DISTINCT ImgFiles.ID
                                                        FROM ImageFiles ImgFiles (nolock) 
                                                        INNER JOIN ImagesBatched IB ON ImgFiles.ID = IB.ID
                                                        AND IB.CompletelyBatch = 1) AS TEMP2 ON TEMP2.ID=ImgFiles.ID
                                            LEFT JOIN (SELECT DISTINCT ImgFiles.ID 
                                                        FROM ImageFiles ImgFiles (nolock) 
                                                        INNER JOIN CombinedImageFiles CIF ON ImgFiles.ID=CIF.ID) AS TEMP3 ON TEMP3.ID=ImgFiles.ID
                                            WHERE ImageStatus = 'A' 
                                            AND ImgFiles.ProcessedDate IS NOT NULL                                            
                                            AND TEMP2.ID IS NULL
                                            AND TEMP3.ID IS NULL
                                            ORDER BY ImgFiles.ProcessedDate";

            string selectQueryCombinedManifesting = @"SELECT DISTINCT CombinedImageFiles.CombinedImageID AS [ID],'' AS [FullFolderPath],''AS [OriginalFileName],SUBSTRING ( CombinedImageFolderPath , 0 , LEN (CombinedImageFolderPath)) AS [NewFolderPath],CombinedImageFileName AS [NewFileName],(SELECT TOP 1 ProcessedDate FROM CombinedImageFiles InnerTable WHERE InnerTable.CombinedImageID = CombinedImageFiles.CombinedImageID) AS [ProcessedDate],'' AS [ErrorDescription]
                                                        FROM CombinedImageFiles
                                                        LEFT JOIN (SELECT DISTINCT CIF.CombinedImageID
                                                                    FROM CombinedImageFiles CIF (nolock) 
                                                                    INNER JOIN ImagesManifested IM ON CIF.CombinedImageID = IM.ID
                                                                    AND IM.FromFolder<>IM.ToFolder) AS TEMP ON TEMP.CombinedImageID = CombinedImageFiles.CombinedImageID
                                                        WHERE ImageStatus = 'A' 
                                                        AND TEMP.CombinedImageID IS NULL
                                                        ORDER BY ProcessedDate";
            string selectQueryCombinedBatching = @"SELECT DISTINCT CombinedImageFiles.CombinedImageID AS [ID],'' AS [FullFolderPath],''AS [OriginalFileName],replace(SUBSTRING ( CombinedImageFolderPath , 0 , LEN (CombinedImageFolderPath)),'MANIFESTING','BATCHING') AS [NewFolderPath],CombinedImageFileName AS [NewFileName],(SELECT TOP 1 ProcessedDate FROM CombinedImageFiles InnerTable WHERE InnerTable.CombinedImageID = CombinedImageFiles.CombinedImageID) AS [ProcessedDate],'' AS [ErrorDescription]
                                                    FROM CombinedImageFiles
                                                    INNER JOIN (SELECT DISTINCT CIF.CombinedImageID
                                                                FROM CombinedImageFiles CIF (nolock) 
                                                                INNER JOIN ImagesManifested IM ON CIF.CombinedImageID = IM.ID
                                                                AND IM.FromFolder<>IM.ToFolder) AS TEMP1 ON TEMP1.CombinedImageID = CombinedImageFiles.CombinedImageID
                                                    LEFT JOIN (SELECT DISTINCT CIF.CombinedImageID
                                                                FROM CombinedImageFiles CIF (nolock) 
                                                                INNER JOIN ImagesBatched IB ON CIF.CombinedImageID = IB.ID
                                                                AND IB.CompletelyBatch = 1) AS TEMP2 ON TEMP2.CombinedImageID = CombinedImageFiles.CombinedImageID
                                                    WHERE ImageStatus = 'A' 
                                                    AND TEMP2.CombinedImageID  IS NULL
                                                    ORDER BY ProcessedDate";
            try
            {
                dal.OpenDB();

                dsReceived = dal.ExecuteDataSet(selectQueryReceived, CommandType.Text);
                dsManifesting = dal.ExecuteDataSet(selectQueryManifesting, CommandType.Text);
                dsBatching = dal.ExecuteDataSet(selectQueryBatching, CommandType.Text);
                dsCombinedManifesting = dal.ExecuteDataSet(selectQueryCombinedManifesting, CommandType.Text);
                dsCombinedBatching = dal.ExecuteDataSet(selectQueryCombinedBatching, CommandType.Text);

                dsReceived.Tables[0].TableName = "Received";
                dsManifesting.Tables[0].TableName = "Manifesting";
                dsBatching.Tables[0].TableName = "Batching";

                dsCombinedManifesting.Tables[0].TableName = "CombinedManifesting";
                dsCombinedBatching.Tables[0].TableName = "CombinedBatching";

                retval.Tables.Add(dsReceived.Tables[0].Copy());
                retval.Tables[0].AcceptChanges();
                retval.Tables.Add(dsManifesting.Tables[0].Copy());
                retval.Tables[1].AcceptChanges();
                retval.Tables.Add(dsBatching.Tables[0].Copy());
                retval.Tables[2].AcceptChanges();
                retval.Tables.Add(dsCombinedManifesting.Tables[0].Copy());
                retval.Tables[3].AcceptChanges();
                retval.Tables.Add(dsCombinedBatching.Tables[0].Copy());
                retval.Tables[4].AcceptChanges();
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
        public bool implementImageResolutionReceived(DataTable dt, string systemUserName)
        {
            bool retval = false;
            ParameterInfo[] paramInsert = new ParameterInfo[9];

            int affectedRows = 0;
            string insertImageResolutionQuery = @"INSERT INTO ImageResolution
                                                       (ID
                                                       ,Category
                                                       ,ReasonCode
                                                       ,ReasonDescription
                                                       ,ResolutionCode
                                                       ,ResolutionAction
                                                       ,FromFolder
                                                       ,ToFolder
                                                       ,UserName
                                                       ,ResolutionDate)
                                                 VALUES
                                                       (@ID
                                                       ,@Category
                                                       ,@ReasonCode
                                                       ,@ReasonDescription
                                                       ,@ResolutionCode
                                                       ,@ResolutionAction
                                                       ,@FromFolder
                                                       ,@ToFolder
                                                       ,@UserName
                                                       ,GETDATE())";
            string updateImageFiles = @"UPDATE ImageFiles
                                           SET ImageStatus = 'D'
                                         WHERE ID = @ID";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();

                paramInsert[0] = new ParameterInfo("@ID", dt.Rows[0]["ID"]);
                paramInsert[1] = new ParameterInfo("@Category", dt.Rows[0]["Category"]);
                paramInsert[2] = new ParameterInfo("@ReasonCode", dt.Rows[0]["ReasonCode"]);
                paramInsert[3] = new ParameterInfo("@ReasonDescription", dt.Rows[0]["ReasonDescription"]);
                paramInsert[4] = new ParameterInfo("@ResolutionCode", dt.Rows[0]["ResolutionCode"]);
                paramInsert[5] = new ParameterInfo("@ResolutionAction", dt.Rows[0]["ResolutionAction"]);
                paramInsert[6] = new ParameterInfo("@FromFolder", dt.Rows[0]["FromFolder"]);
                paramInsert[7] = new ParameterInfo("@ToFolder", dt.Rows[0]["ToFolder"]);
                paramInsert[8] = new ParameterInfo("@UserName", systemUserName);
                affectedRows = dal.ExecuteNonQuery(insertImageResolutionQuery, CommandType.Text, paramInsert);
                if (dt.Rows[0]["ResolutionCode"].ToString() != "10")
                {
                    ParameterInfo[] paramUpdate = new ParameterInfo[1];
                    paramUpdate[0] = new ParameterInfo("@ID", dt.Rows[0]["ID"]);
                    affectedRows = dal.ExecuteNonQuery(updateImageFiles, CommandType.Text, paramUpdate);
                    ImageAuditTrail(dt.Rows[0]["ID"].ToString(), "41", dal, systemUserName);
                }
                else
                    ImageAuditTrail(dt.Rows[0]["ID"].ToString(), "40", dal, systemUserName);
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
        public bool implementImageResolutionManifestingBatching(DataTable dt, string newFileName, bool isManifest, bool isCombinedImage, string systemUserName)
        {
            bool retval = false;
            ParameterInfo[] paramInsert = new ParameterInfo[9];

            int affectedRows = 0;
            string insertImageResolutionQuery = @"INSERT INTO ImageResolution
                                                       (ID
                                                       ,Category
                                                       ,ReasonCode
                                                       ,ReasonDescription
                                                       ,ResolutionCode
                                                       ,ResolutionAction
                                                       ,FromFolder
                                                       ,ToFolder
                                                       ,UserName
                                                       ,ResolutionDate)
                                                 VALUES
                                                       (@ID
                                                       ,@Category
                                                       ,@ReasonCode
                                                       ,@ReasonDescription
                                                       ,@ResolutionCode
                                                       ,@ResolutionAction
                                                       ,@FromFolder
                                                       ,@ToFolder
                                                       ,@UserName
                                                       ,GETDATE())";
            string updateImageFiles = string.Empty;
            if (isCombinedImage)
            {
                updateImageFiles = @"UPDATE CombinedImageFiles
                                    SET ImageStatus = 'D'
                                    WHERE CombinedImageID = @ID";
            }
            else
            {
                updateImageFiles = @"UPDATE ImageFiles
                                           SET ImageStatus = 'D'
                                         WHERE ID = @ID";
            }
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                moveFiles(dt.Rows[0]["FromFolder"].ToString() + "\\" + newFileName, dt.Rows[0]["ToFolder"].ToString() + "\\" + newFileName);
                paramInsert[0] = new ParameterInfo("@ID", dt.Rows[0]["ID"]);
                paramInsert[1] = new ParameterInfo("@Category", dt.Rows[0]["Category"]);
                paramInsert[2] = new ParameterInfo("@ReasonCode", dt.Rows[0]["ReasonCode"]);
                paramInsert[3] = new ParameterInfo("@ReasonDescription", dt.Rows[0]["ReasonDescription"]);
                paramInsert[4] = new ParameterInfo("@ResolutionCode", dt.Rows[0]["ResolutionCode"]);
                paramInsert[5] = new ParameterInfo("@ResolutionAction", dt.Rows[0]["ResolutionAction"]);
                paramInsert[6] = new ParameterInfo("@FromFolder", dt.Rows[0]["FromFolder"]);
                paramInsert[7] = new ParameterInfo("@ToFolder", dt.Rows[0]["ToFolder"]);
                paramInsert[8] = new ParameterInfo("@UserName", systemUserName);
                affectedRows = dal.ExecuteNonQuery(insertImageResolutionQuery, CommandType.Text, paramInsert);

                ParameterInfo[] paramUpdate = new ParameterInfo[1];
                paramUpdate[0] = new ParameterInfo("@ID", dt.Rows[0]["ID"]);
                affectedRows = dal.ExecuteNonQuery(updateImageFiles, CommandType.Text, paramUpdate);
                if (isManifest)
                    ImageAuditTrail(dt.Rows[0]["ID"].ToString(), "42", dal, systemUserName);
                else
                    ImageAuditTrail(dt.Rows[0]["ID"].ToString(), "43", dal, systemUserName);
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
                
        private void moveFiles(string oldFile, string newFile)
        {            
            if (!Directory.Exists(newFile.Substring(0, newFile.Length - CommonMethod.getFileName(newFile).Length)))
            {
                Directory.CreateDirectory(newFile.Substring(0, newFile.Length - CommonMethod.getFileName(newFile).Length));
            }
            bool moveTry = true;
            bool moveSuccessful = false;
            string errorMessage = string.Empty;
            int counter = 0;
            while (moveTry)
            {
                try
                {
                    counter = counter + 1;
                    File.Move(oldFile, newFile);
                    moveTry = false;
                    moveSuccessful = true;
                }
                catch (Exception e)
                {
                    if (counter == 3)
                    {
                        moveTry = false;
                        errorMessage = e.Message;
                    }
                    else
                    {
                        System.GC.Collect();
                        System.GC.WaitForPendingFinalizers();
                        Thread.Sleep(1000);
                    }
                }
                finally
                {
                }
            }
            if (!moveSuccessful)
            {
                throw new Exception(oldFile + " to " + newFile + ":" + errorMessage);
            }
        }
    }
}
