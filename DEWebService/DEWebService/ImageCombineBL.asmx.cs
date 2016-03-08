using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.IO;
using System.Threading;
using DAL;
using CommonLibrary;
namespace DEWebService
{
    /// <summary>
    /// Summary description for ImageCombineBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ImageCombineBL : BaseBLogic
    {
        public ImageCombineBL()
        {

        }

        public override void setQueries()
        {
            //throw new NotImplementedException();
        }

        [WebMethod]
        public bool imageInDatabase(string filename)
        {
            bool retval = false;
            DataSet ds = new DataSet();
            string selectQuery = @"SELECT COUNT(*) FROM ImageFiles(NOLOCK) WHERE ID = @ID";
            ParameterInfo[] param = new ParameterInfo[1];
            try
            {
                dal.OpenDB();
                param[0] = new ParameterInfo("@ID", filename.Split('.')[0]);
                ds = dal.ExecuteDataSet(selectQuery, CommandType.Text, param);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 && Convert.ToInt16(ds.Tables[0].Rows[0][0]) > 0)
                {
                    retval = true;
                }
            }
            catch (Exception error)
            {
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
        public string combineImage(string [] imageFilesArray, string filename, string siteID, string systemUserName)
        {
            DataSet ds = new DataSet();
            ParameterInfo[] param = new ParameterInfo[4];
            ArrayList imageFiles = new ArrayList();
            string retval = string.Empty;
            string ID = string.Empty;
            string CombinedImageID = string.Empty;
            string CombinedFilename = string.Empty;
            string folderDate = getTodayFolder();
            string queryFileCounterUpdate = string.Format(@"UPDATE SiteIDController SET IDCounter = IDCounter+1 WHERE SiteID = {0} AND IDType = 'ImgCmbID'", siteID);
            string queryCombinedFileCounterSelect = string.Format(@"SELECT IDCounter FROM SiteIDController(NOLOCK) WHERE SiteID = {0} AND IDType = 'ImgCmbID'", siteID);
            string queryCombinedImageFilesInsert = @"INSERT INTO CombinedImageFiles
                                                               (CombinedImageID
                                                               ,ID
                                                               ,CombinedImageFileName
                                                               ,CombinedImageFolderPath
                                                               ,ImageStatus
                                                               ,ProcessedDate)
                                                         VALUES
                                                               (@CombinedImageID
                                                               ,@ID
                                                               ,@CombinedImageFileName
                                                               ,@CombinedImageFolderPath
                                                               ,'A'
                                                               ,GETDATE())";
            try
            {

                foreach (object image in imageFilesArray)
                {
                    imageFiles.Add(image.ToString());
                }

                dal.OpenDB();
                dal.BeginTransaction();
                dal.ExecuteNonQuery(queryFileCounterUpdate, CommandType.Text);
                ds = dal.ExecuteDataSet(queryCombinedFileCounterSelect, CommandType.Text);
                CombinedImageID = (Convert.ToInt32(ds.Tables[0].Rows[0][0]) - 1).ToString();//get the latest CombinedImageID
                CombinedImageID = CommonMethod.base36Encode(Convert.ToInt64(CombinedImageID)).PadLeft(6, '0');
                if (CombinedImageID.Length > 6)
                    throw new Exception("Combine Image ID counter exeeded the limit length.");
                else
                    CombinedImageID = siteID + "5" + CombinedImageID;
                CombinedFilename = CombinedImageID + (filename == string.Empty ? ".tif" : ("." + filename + ".tif"));
                param[0] = new ParameterInfo("@CombinedImageID", CombinedImageID);
                param[2] = new ParameterInfo("@CombinedImageFileName", CombinedFilename);
                param[3] = new ParameterInfo("@CombinedImageFolderPath", ConfigurationManager.AppSettings["CombineImagePath"] + this.getTodayFolder() + "\\");

                foreach (object file in imageFiles)
                {
                    ID = file.ToString().Split('\\')[file.ToString().Split('\\').Length - 1].Split('.')[0];
                    param[1] = new ParameterInfo("@ID", ID);
                    dal.ExecuteNonQuery(queryCombinedImageFilesInsert, CommandType.Text, param);
                    ImageAuditTrail(ID, "60", dal, systemUserName);
                }
                ImageAuditTrail(CombinedImageID, "61", dal, systemUserName);
                CommonMethod.combineImage(ConfigurationManager.AppSettings["CombineImagePath"] + this.getTodayFolder() + "\\" + CombinedFilename, imageFiles);
                moveFiles(CombinedImageID, folderDate, imageFiles);
                dal.CommitTransaction();
                retval = ConfigurationManager.AppSettings["CombineImagePath"] + this.getTodayFolder() + "\\" + CombinedFilename;
            }
            catch (Exception error)
            {
                dal.RollBackTransaction();
                if (File.Exists(ConfigurationManager.AppSettings["CombineImagePath"] + this.getTodayFolder() + "\\" + CombinedFilename))
                {
                    File.Delete(ConfigurationManager.AppSettings["CombineImagePath"] + this.getTodayFolder() + "\\" + CombinedFilename);
                }
                moveFilesRollback(CombinedImageID, folderDate, imageFiles);//roll back file movement
                retval = string.Empty;
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }
                
        private string getTodayFolder()
        {
            DateTime date = new DateTime();
            string dateString = string.Empty;
            date = DateTime.Now;
            dateString = date.ToString("yyyyMMdd");// date.Year.ToString("0000") + date.Month.ToString("00") + date.Day.ToString("00");			
            return dateString;
        }
                
        private void moveFiles(string subFolder, string folderDate, ArrayList imageFiles)
        {
            bool moveTry;
            bool moveSuccessful;
            string errorMessage = string.Empty;
            int counter;
            string newFile = string.Empty;
            foreach (object file in imageFiles)
            {
                counter = 0;
                moveTry = true;
                moveSuccessful = false;
                newFile = ConfigurationManager.AppSettings["CombineImageBackupPath"] + folderDate + "\\" + subFolder + "\\" + CommonMethod.getFileName(file.ToString());
                if (!Directory.Exists(newFile.Substring(0, newFile.Length - CommonMethod.getFileName(newFile).Length)))
                {
                    Directory.CreateDirectory(newFile.Substring(0, newFile.Length - CommonMethod.getFileName(newFile).Length));
                }
                while (moveTry)
                {
                    try
                    {
                        counter = counter + 1;
                        File.Move(file.ToString(), newFile);
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
                }
                if (!moveSuccessful)
                {
                    throw new Exception(file + " to " + newFile + ":" + errorMessage);
                }
            }
        }
                
        private void moveFilesRollback(string subFolder, string folderDate, ArrayList imageFiles)
        {
            bool moveTry;
            string errorMessage = string.Empty;
            int counter;
            string newFile = string.Empty;
            foreach (object file in imageFiles)
            {
                counter = 0;
                moveTry = true;
                newFile = ConfigurationManager.AppSettings["CombineImageBackupPath"] + folderDate + "\\" + subFolder + "\\" + CommonMethod.getFileName(file.ToString());
                if (File.Exists(newFile))
                {
                    while (moveTry)
                    {
                        try
                        {
                            counter = counter + 1;
                            File.Move(newFile, file.ToString());
                            moveTry = false;
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
                    }
                }
            }
        }
    }
}
