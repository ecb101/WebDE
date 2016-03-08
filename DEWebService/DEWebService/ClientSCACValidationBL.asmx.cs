using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.IO;
using System.Configuration;
using DAL;
using CommonLibrary;
using Trax.FPS;
using Filex.MSharp.Lib.Common;
namespace DEWebService
{
    /// <summary>
    /// Summary description for ClientSCACValidationBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ClientSCACValidationBL : BaseBLogic
    {
        private BatchEntryBL batchEntryBL = new BatchEntryBL();
        private DataEntryQABL de_QA_BL = new DataEntryQABL();
        private CreateMXXmdbBL createMXXmdbBL = new CreateMXXmdbBL();

        public ClientSCACValidationBL()
        {
            
        }

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
        public DataSet selectSCAC(string OwnerKey)
        {            
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
            param[0] = new ParameterInfo("@OwnerKey", OwnerKey.Trim());
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

        public override void setQueries()
        {
            //throw new NotImplementedException();
        }

        [WebMethod]
        public bool updateDEClientSCAC(string batCtrlNum, string Owner_Key, string Vend_SCAC, string UserInitials)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdateClientSCAC = string.Empty;
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                ParameterInfo[] param;

                ParameterInfo[] paramBat = new ParameterInfo[1];
                paramBat[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);//get rootbatch                
                DataSet dsSplitBatches = dal.ExecuteDataSet("SELECT A.*,DE.Batch_Status AS DEStatus FROM Batch_DE_Split A INNER JOIN Batch_DE_Split B ON A.Bat_Ctrl_Num_Root = B.Bat_Ctrl_Num_Root INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num WHERE B.Bat_Ctrl_Num_Split =  @Bat_Ctrl_Num ORDER BY B.Bat_Ctrl_Num_Split", CommandType.Text, paramBat);

                if (dsSplitBatches.Tables.Count > 0 && dsSplitBatches.Tables[0].Rows.Count > 0)//split
                {
                    bool isFirst = true;
                    string rootbatch = string.Empty;                 
                    queryUpdateClientSCAC = @"UPDATE Batch_DE_ext
                                             SET DEValidatedBy = @DEValidatedBy,
                                                 DEOwner_Key = @DEOwner_Key, 
                                                 DEVend_SCAC = @DEVend_SCAC,
                                                 TransmissionId = 0
                                             WHERE Bat_Ctrl_Num IN (";
                    
                    rootbatch = dsSplitBatches.Tables[0].Rows[0]["Bat_Ctrl_Num_Root"].ToString();
                    foreach (DataRow row in dsSplitBatches.Tables[0].Rows)
                    {
                        if (isFirst)
                        {
                            queryUpdateClientSCAC = queryUpdateClientSCAC + "'" + row["Bat_Ctrl_Num_Split"].ToString() + "'";
                            isFirst = false;
                        }
                        else
                            queryUpdateClientSCAC = queryUpdateClientSCAC + ",'" + row["Bat_Ctrl_Num_Split"].ToString() + "'";
                    }
                    queryUpdateClientSCAC = queryUpdateClientSCAC + ",'" + rootbatch + "')";


                    param = new ParameterInfo[3];
                    param[0] = new ParameterInfo("@DEValidatedBy", UserInitials);
                    param[1] = new ParameterInfo("@DEOwner_Key", Owner_Key);
                    param[2] = new ParameterInfo("@DEVend_SCAC", Vend_SCAC);
                    affectedRows = dal.ExecuteNonQuery(queryUpdateClientSCAC, CommandType.Text, param);
                    
                }
                else
                {
                    queryUpdateClientSCAC = @"UPDATE Batch_DE_ext
                                             SET DEValidatedBy = @DEValidatedBy,
                                                 DEOwner_Key = @DEOwner_Key, 
                                                 DEVend_SCAC = @DEVend_SCAC,
                                                 TransmissionId = 0
                                             WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";

                    param = new ParameterInfo[4];
                    param[0] = new ParameterInfo("@DEValidatedBy", UserInitials);
                    param[1] = new ParameterInfo("@DEOwner_Key", Owner_Key);
                    param[2] = new ParameterInfo("@DEVend_SCAC", Vend_SCAC);
                    param[3] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                    affectedRows = dal.ExecuteNonQuery(queryUpdateClientSCAC, CommandType.Text, param);
                }
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

        private bool updateClientSCAC(object Dal, string batCtrlNum, string Owner_Key, string Vend_SCAC, bool isProduction)
        {
            DALHelper dal = (DALHelper)Dal;
            bool retval = false;
            string OwnerCode;
            DataSet dsOwnerCode = new DataSet();
            int affectedRows = 0;
            string queryOwnerCode = string.Format(@"SELECT {0}
                                      FROM Entity
                                      WHERE OwnerKey = @OwnerKey", isProduction ? "OwnerCodeProd" : "OwnerCodeTest");

            string queryUpdate = @"UPDATE Batch_DE
                                    SET Owner_Key = @Owner_Key,
                                        Owner_Code = @Owner_Code,
                                        Vend_SCAC = @Vend_SCAC
                                   WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                   UPDATE FB_SCAC
                                    SET Vend_SCAC = @Vend_SCAC
                                   WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num
                                   UPDATE Batch_DE_ext
                                    SET TransmissionId = 0
                                   WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";


            try
            {

                //Get OwnerCode
                ParameterInfo[] paramOwnerCode = new ParameterInfo[1];
                paramOwnerCode[0] = new ParameterInfo("@OwnerKey", Owner_Key);
                dsOwnerCode = dal.ExecuteDataSet(queryOwnerCode, CommandType.Text, paramOwnerCode);
                OwnerCode = dsOwnerCode.Tables[0].Rows[0][0].ToString();
                
                ParameterInfo[] param = new ParameterInfo[4];
                param[0] = new ParameterInfo("@Owner_Key", Owner_Key);
                param[1] = new ParameterInfo("@Owner_Code", OwnerCode);
                param[2] = new ParameterInfo("@Vend_SCAC", Vend_SCAC);
                param[3] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);                
                retval = true;
            }
            catch (Exception e)
            {                
                retval = false;
                throw e;
            }            
            return retval;
        }

        [WebMethod]
        public bool overwriteClientSCAC(string batCtrlNum, string Owner_Key, string Vend_SCAC)
        {
            bool retval = false;
            DataSet dsBatch = new DataSet();            
            DataSet dsBatchInfo = new DataSet();
            string ownerKey = Owner_Key.Remove(3, 1);
            bool isProduction = true;
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();                
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dsBatchInfo = dal.ExecuteDataSet(@"SELECT 
                                                    CASE WHEN ext.DEVer = 'OLD' THEN 1 ELSE 0 END AS 'isOld',
                                                    CASE WHEN ext.DESiteID <> 1 THEN 1 ELSE 0 END AS 'isObject',
                                                    CASE WHEN de.Owner_Code = e.OwnerCodeProd THEN 1 ELSE 0 END AS 'isProduction',
                                                    de.Oper_Init AS Operator,
                                                    de.DE_START_DTM AS DateStart
                                                    FROM Batch_DE_ext ext
                                                    INNER JOIN Batch_DE de on ext.BatchID = de.BatchID
                                                    INNER JOIN Entity e on de.Owner_Key = e.OwnerKey
                                                    WHERE ext.Bat_Ctrl_Num = @Bat_Ctrl_Num", CommandType.Text, param);

                if (dsBatchInfo.Tables.Count > 0 && dsBatchInfo.Tables[0].Rows.Count > 0)
                {
                    isProduction = Convert.ToBoolean(dsBatchInfo.Tables[0].Rows[0]["isProduction"]);
                    updateClientSCAC(dal, batCtrlNum, Owner_Key, Vend_SCAC, isProduction);
                    if (Convert.ToBoolean(dsBatchInfo.Tables[0].Rows[0]["isOld"]))//old
                    {
                        if (Convert.ToBoolean(dsBatchInfo.Tables[0].Rows[0]["isObject"]))//check if object file
                        {
                            if (File.Exists(ConfigurationManager.AppSettings["ObjDestinationPath"] + batCtrlNum + ".mxx"))//check if object file is existing
                            {
                                if (this.makeMDBCopy(batCtrlNum.Trim()))//copy mxx template
                                {
                                    dsBatch = createMXXmdbBL.selectBatchObj(batCtrlNum);//populate dataset using the mxx object file                                
                                    createMXXmdbBL.insertTRBat(dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString(), "MXX" + batCtrlNum, Convert.ToDateTime(dsBatchInfo.Tables[0].Rows[0]["DateStart"]), dsBatchInfo.Tables[0].Rows[0]["Operator"].ToString());//update TRBat
                                    createMXXmdbBL.saveBatch(dsBatch, batCtrlNum, dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString());//populate save dataset in the mxx                            
                                }
                            }
                            else
                                throw new Exception("Object file is missing.");
                        }
                        dsBatch = batchEntryBL.selectQABatch(batCtrlNum.Trim());

                        //clear remit info in inv_Bat level
                        if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                        {
                            dsBatch.Tables["InvBat"].Rows[0]["BatId"] = "BACH" + ownerKey + dsBatch.Tables["InvBat"].Rows[0]["BatId"].ToString().Substring(11);
                            dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = DBNull.Value;
                            dsBatch.Tables["InvBat"].Rows[0]["VendLabl"] = Vend_SCAC;
                            dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"] = Owner_Key;
                        }

                        //update scac, clear remit to and bill to info in Invoice level                    
                        foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                        {
                            row["InvId"] = "INVC" + ownerKey + row["InvId"].ToString().Substring(11);
                            //need to update ID
                            row["VendLabl"] = Vend_SCAC;
                            row["LocIdRemit"] = DBNull.Value;
                            row["AlRemit1"] = DBNull.Value;
                            row["AlRemit2"] = DBNull.Value;
                            row["AlRemit3"] = DBNull.Value;
                            row["AlRemit4"] = DBNull.Value;
                            row["AlCityRemit"] = DBNull.Value;
                            row["AlStateProvRemit"] = DBNull.Value;
                            row["AlPostCodeRemit"] = DBNull.Value;
                            row["AlCntryCodeRemit"] = DBNull.Value;

                            row["LocIdBlng"] = DBNull.Value;
                            row["AlBlng1"] = DBNull.Value;
                            row["AlBlng2"] = DBNull.Value;
                            row["AlBlng3"] = DBNull.Value;
                            row["AlBlng4"] = DBNull.Value;
                            row["AlCityBlng"] = DBNull.Value;
                            row["AlStateProvBlng"] = DBNull.Value;
                            row["AlPostCodeBlng"] = DBNull.Value;
                            row["AlCntryCodeBlng"] = DBNull.Value;
                        }
                        //clear bill to info FrghtBl Level
                        foreach (DataRow row in dsBatch.Tables["FB"].Rows)
                        {
                            row["InvId"] = "INVC" + ownerKey + row["InvId"].ToString().Substring(11);
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                            //need to update ID
                            row["LocIdBlng"] = DBNull.Value;
                            row["VendLabl"] = Vend_SCAC;
                        }

                        foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                        {
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                            //need to update ID
                        }

                        foreach (DataRow row in dsBatch.Tables["FXI"].Rows)
                        {
                            row["BatId"] = dsBatch.Tables["InvBat"].Rows[0]["BatId"];
                            row["InvId"] = "INVC" + ownerKey + row["InvId"].ToString().Substring(11);
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                            //need to update ID
                        }
                        if (!batchEntryBL.saveQABatch(dsBatch, batCtrlNum, Owner_Key))
                            throw new Exception("Failed in overwrite client/Scac.");
                        else
                            UpdateTRBat(batCtrlNum,Owner_Key);
                    }
                    else//if new
                    {
                        dsBatch = de_QA_BL.selectBatchXML(batCtrlNum.Trim(), CommonEnum.FormMode.QUALITY_ASSURANCE);

                        if (dsBatch.Tables["InvBat"].Rows.Count > 0)
                        {
                            dsBatch.Tables["InvBat"].Rows[0]["BatId"] = "BACH" + ownerKey + dsBatch.Tables["InvBat"].Rows[0]["BatId"].ToString().Substring(11);
                            dsBatch.Tables["InvBat"].Rows[0]["BatLocIdRemit"] = DBNull.Value;
                            dsBatch.Tables["InvBat"].Rows[0]["VendLabl"] = Vend_SCAC;
                            dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"] = Owner_Key;
                        }

                        //update scac, clear remit to and bill to info in Invoice level                    
                        foreach (DataRow row in dsBatch.Tables["Invoice"].Rows)
                        {
                            row["BatId"] = dsBatch.Tables["InvBat"].Rows[0]["BatId"];
                            row["InvId"] = "INVC" + ownerKey + row["InvId"].ToString().Substring(11);
                            //need to update ID
                            row["VendLabl"] = Vend_SCAC;
                            row["LocIdRemit"] = DBNull.Value;
                            row["AlRemit1"] = DBNull.Value;
                            row["AlRemit2"] = DBNull.Value;
                            row["AlRemit3"] = DBNull.Value;
                            row["AlRemit4"] = DBNull.Value;
                            row["AlCityRemit"] = DBNull.Value;
                            row["AlStateProvRemit"] = DBNull.Value;
                            row["AlPostCodeRemit"] = DBNull.Value;
                            row["AlCntryCodeRemit"] = DBNull.Value;

                            row["LocIdBlng"] = DBNull.Value;
                            row["AlBlng1"] = DBNull.Value;
                            row["AlBlng2"] = DBNull.Value;
                            row["AlBlng3"] = DBNull.Value;
                            row["AlBlng4"] = DBNull.Value;
                            row["AlCityBlng"] = DBNull.Value;
                            row["AlStateProvBlng"] = DBNull.Value;
                            row["AlPostCodeBlng"] = DBNull.Value;
                            row["AlCntryCodeBlng"] = DBNull.Value;
                        }
                        //clear bill to info FrghtBl Level
                        foreach (DataRow row in dsBatch.Tables["FrghtBl"].Rows)
                        {
                            row["InvId"] = "INVC" + ownerKey + row["InvId"].ToString().Substring(11);
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                            //need to update ID
                            row["LocIdBlng"] = DBNull.Value;
                            row["VendLabl"] = Vend_SCAC;
                        }

                        foreach (DataRow row in dsBatch.Tables["FBLn"].Rows)
                        {
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                            //need to update ID
                        }

                        foreach (DataRow row in dsBatch.Tables["KeyIdents"].Rows)
                        {
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                        }
                        foreach (DataRow row in dsBatch.Tables["Addrs"].Rows)
                        {
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                        }
                        foreach (DataRow row in dsBatch.Tables["Cntnrs"].Rows)
                        {
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                        }
                        foreach (DataRow row in dsBatch.Tables["ProdDtl"].Rows)
                        {
                            row["FbId"] = "FBLL" + ownerKey + row["FbId"].ToString().Substring(11);
                        }
                        if(!de_QA_BL.saveBatchXML(dsBatch, batCtrlNum, CommonEnum.FormMode.QUALITY_ASSURANCE))
                            throw new Exception("Failed in overwrite client/Scac.");
                    }
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
        public bool isUpdateDEClientSCACNeeded(string batCtrlNum)
        {
            bool retval = false;
            DataSet ds = new DataSet();
            string query = @"SELECT DEValidatedBy
                            FROM Batch_DE_ext
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
        public bool isSplitBatches(string batCtrlNum)
        {
            bool retval = false;
            DataSet dsSplitBatches = new DataSet();         
            try
            {
                ParameterInfo[] paramBat = new ParameterInfo[1];
                paramBat[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);//get rootbatch                
                dsSplitBatches = dal.ExecuteDataSet("SELECT A.*,DE.Batch_Status AS DEStatus FROM Batch_DE_Split A INNER JOIN Batch_DE_Split B ON A.Bat_Ctrl_Num_Root = B.Bat_Ctrl_Num_Root INNER JOIN Batch_DE DE ON A.Bat_Ctrl_Num_Split = DE.Bat_Ctrl_Num WHERE B.Bat_Ctrl_Num_Split =  @Bat_Ctrl_Num ORDER BY B.Bat_Ctrl_Num_Split", CommandType.Text, paramBat);

                if (dsSplitBatches.Tables.Count > 0 && dsSplitBatches.Tables[0].Rows.Count > 0)//split
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

        private bool makeMDBCopy(string batchNumber)
        {
            bool retval = false;
            string filePath = ConfigurationManager.AppSettings["MDBSourcePath"] + "batchxxx";
            string newfile = ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batchNumber + ".mdb";

            try
            {
                if (File.Exists(newfile))
                {
                    File.Delete(newfile);
                }
                File.Copy(filePath, newfile);
                retval = true;
            }
            catch (Exception e)
            {
                retval = false;
                throw e;
            }
            
            
            return retval;
        }

        [WebMethod]
        public DataSet selectDetail(string MXXDatabase)
        {
            DataSet retval = new DataSet();
            string query = @"SELECT DEOwner_Key,DEVend_SCAC                              
                            FROM Batch_DE_ext
                            WHERE Bat_Ctrl_Num = @Bat_Ctrl_Num";
            try
            {
                dal.OpenDB();
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", MXXDatabase);
                retval = dal.ExecuteDataSet(query, CommandType.Text, param);
            }
            catch
            {
                retval = null;
            }            
            return retval;
        }

        [WebMethod]
        public void createIfObject(string batCtrlNum, string Owner_Key, string Vend_SCAC)
        {
            DataSet dsBatchInfo = new DataSet();            
            DataSet dsBatch = new DataSet();
            try
            {
                dal.OpenDB();
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@Bat_Ctrl_Num", batCtrlNum);
                dsBatchInfo = dal.ExecuteDataSet(@"SELECT 
                                                    CASE WHEN ext.DEVer = 'OLD' THEN 1 ELSE 0 END AS 'isOld',
                                                    CASE WHEN ext.DESiteID <> 1 THEN 1 ELSE 0 END AS 'isObject',
                                                    de.Oper_Init AS Operator,
                                                    de.DE_START_DTM AS DateStart
                                                    FROM Batch_DE_ext ext
                                                    INNER JOIN Batch_DE de on ext.BatchID = de.BatchID                                                    
                                                    WHERE ext.Bat_Ctrl_Num = @Bat_Ctrl_Num", CommandType.Text, param);

                if (dsBatchInfo.Tables.Count > 0 && dsBatchInfo.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dsBatchInfo.Tables[0].Rows[0]["isOld"]))//old
                    {
                        if (Convert.ToBoolean(dsBatchInfo.Tables[0].Rows[0]["isObject"]))//check if object file
                        {
                            if (File.Exists(ConfigurationManager.AppSettings["ObjDestinationPath"] + batCtrlNum + ".mxx") && !File.Exists(ConfigurationManager.AppSettings["MDBDestinationPath"] + "MXX" + batCtrlNum + ".mdb"))//check if object file is existing
                            {
                                if (this.makeMDBCopy(batCtrlNum.Trim()))//copy mxx template
                                {
                                    dsBatch = createMXXmdbBL.selectBatchObj(batCtrlNum);//populate dataset using the mxx object file                                
                                    createMXXmdbBL.insertTRBat(dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString(), "MXX" + batCtrlNum, Convert.ToDateTime(dsBatchInfo.Tables[0].Rows[0]["DateStart"]), dsBatchInfo.Tables[0].Rows[0]["Operator"].ToString());//update TRBat
                                    createMXXmdbBL.saveBatch(dsBatch, batCtrlNum, dsBatch.Tables["InvBat"].Rows[0]["OwnerKey"].ToString());//populate save dataset in the mxx                            
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            { }
            finally
            {
                dal.CloseDB();
            }
        }
        
        private bool UpdateTRBat(string MXXDatabase, string OwnerKey)
        {
            bool retval = false;
            DataSet dsInvBat = new DataSet();
            DataSet dsInvoice = new DataSet();
            DataSet dsFrghtBL = new DataSet();
            DataSet dsFBLn = new DataSet();
            int affectedRows;
            DALHelperOleDB dalMXXDatabase = new DAL.DALHelperOleDB("MXXDBConnection", @"QA\MXX" + MXXDatabase.Trim() + ".mdb");

            try
            {
                dalMXXDatabase.OpenDB();
                dalMXXDatabase.BeginTransaction();
                ParameterInfoOleDB[] param = new ParameterInfoOleDB[2];
                param[0] = new ParameterInfoOleDB("@OWNER_KEY", OwnerKey);
                param[1] = new ParameterInfoOleDB("@BAT_ID", "BACH" + OwnerKey.Trim().Remove(3, 1) + MXXDatabase + (0).ToString().PadLeft(4, '0'));
                affectedRows = dalMXXDatabase.ExecuteNonQuery(@"UPDATE TR_BAT SET OWNER_KEY =@OWNER_KEY, BAT_ID=@BAT_ID", CommandType.Text, param);
                dalMXXDatabase.CommitTransaction();
                retval = true;
            }
            catch (Exception e)
            {
                dalMXXDatabase.RollBackTransaction();
                retval = false;
                throw e;
            }
            finally
            {
                dalMXXDatabase.CloseDB();
            }
            return retval;
        }
    }
}
