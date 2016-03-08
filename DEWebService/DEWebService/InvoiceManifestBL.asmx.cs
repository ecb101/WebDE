using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using DAL;
using CommonLibrary;
namespace DEWebService
{
    /// <summary>
    /// Summary description for InvoiceManifestBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class InvoiceManifestBL : BaseBLogic
    {

        public InvoiceManifestBL()
        {
        }

        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO RawInvoiceManifest
                                           (InvManIDKey
                                           ,InvManID
                                           ,ImgDocID
                                           ,ProcDate
                                           ,TrackingNum
                                           ,Inv_Key
                                           ,ImgPageNo
                                           ,Client
                                           ,Carrier
                                           ,Language
                                           ,UserId
                                           ,LastUpdate
                                           ,Status
                                           ,Comments)
                                     VALUES
                                           (@InvManIDKey
                                           ,@InvManID
                                           ,@ImgDocID
                                           ,@ProcDate
                                           ,@TrackingNum
                                           ,@Inv_Key
                                           ,@ImgPageNo
                                           ,@Client
                                           ,@Carrier
                                           ,@Language
                                           ,@UserId
                                           ,GETDATE()
                                           ,@Status
                                           ,@Comments)";
            this.updateQuery = @"UPDATE RawInvoiceManifest
                                   SET InvManIDKey = @InvManIDKey
                                      ,InvManID = @InvManID
                                      ,ImgDocID = @ImgDocID
                                      ,ProcDate = @ProcDate
                                      ,TrackingNum = @TrackingNum
                                      ,Inv_Key = @Inv_Key
                                      ,ImgPageNo = @ImgPageNo
                                      ,Client = @Client
                                      ,Carrier = @Carrier
                                      ,Language = @Language
                                      ,UserId = @UserId
                                      ,LastUpdate = GETDATE()
                                      ,Status = @Status
                                      ,Comments = @Comments
                                 WHERE InvManIDKey = @InvManIDKey";
            this.deleteQuery = @"UPDATE RawInvoiceManifest
                                   SET UserId = @UserId
                                      ,Status = 'D'
                                      ,LastUpdate = GETDATE()                                      
                                WHERE InvManIDKey = @InvManIDKey";
        }

        [WebMethod]
        public DataSet selectInvoiceManifest(string ImgDocID)
        {
            DataSet retval = new DataSet();
            string query = @"SELECT InvManIDKey
                                  ,InvManID
                                  ,ImgDocID
                                  ,CONVERT(VARCHAR(10), ProcDate, 101) AS ProcDate
                                  ,TrackingNum
                                  ,Inv_Key
                                  ,ImgPageNo
                                  ,Client
                                  ,Carrier
                                  ,Language
                                  ,UserId
                                  ,LastUpdate
                                  ,Status
                                  ,Comments
                              FROM RawInvoiceManifest(NOLOCK)
                            WHERE ImgDocID =@ImgDocID
                            AND Status = 'A'";
            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@ImgDocID", ImgDocID);
                dal.OpenDB();
                retval = dal.ExecuteDataSet(query, CommandType.Text, param);
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
        public bool saveInvoiceManifest(DataSet ds, string siteID)
        {
            bool retval = false;
            DataSet dsSitePrefix = new DataSet();
            DataSet dsIDCounter = new DataSet();
            ParameterInfo[] param;
            ParameterInfo[] paramDelete = new ParameterInfo[2];
            int affectedRows = 0;
            bool isIDWrongFormat;
            string invoiceManifestID = string.Empty;
            long invoiceManifestIDKey;
            string selectPrefix = string.Format(@"SELECT PrefixSite FROM SiteMaster(NOLOCK) WHERE SiteID= '{0}'", siteID);
            string queryIDCounter = string.Format(@"SELECT IDCounter,PrefixSite,PrefixType FROM SiteIDController(NOLOCK) WHERE SiteID = {0} AND IDType = 'InvManID'", siteID);
            string queryIDCounterUpdate = string.Format(@"UPDATE SiteIDController SET IDCounter = IDCounter+1 WHERE SiteID = {0} AND IDType = 'InvManID'", siteID);
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();

                dsSitePrefix = dal.ExecuteDataSet(selectPrefix, CommandType.Text);
                if (dsSitePrefix == null || dsSitePrefix.Tables.Count <= 0 || dsSitePrefix.Tables[0].Rows.Count <= 0)
                    throw new Exception("No SiteIDController configuration for this Site.");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                    {
                        isIDWrongFormat = false;
                        try
                        {
                            Convert.ToInt32(dr["InvManID"]);
                            isIDWrongFormat = true;
                        }
                        catch
                        {
                            isIDWrongFormat = false;
                        }
                        if (isIDWrongFormat)//check if ID is in correct format
                        {
                            dsIDCounter = dal.ExecuteDataSet(queryIDCounter, CommandType.Text);
                            invoiceManifestID = dsIDCounter.Tables[0].Rows[0][0].ToString();
                            //format invoiceManifestIDKey, invoiceManifestID
                            invoiceManifestIDKey = CommonMethod.createIDKey(Convert.ToInt64(invoiceManifestID), siteID);
                            invoiceManifestID = CommonMethod.createID(dsSitePrefix.Tables[0].Rows[0]["PrefixSite"].ToString(), Convert.ToInt64(invoiceManifestID));
                            dr["InvManID"] = invoiceManifestID;
                            dr["InvManIDKey"] = invoiceManifestIDKey;
                            affectedRows = dal.ExecuteNonQuery(queryIDCounterUpdate, CommandType.Text);
                        }
                        param = this.GetParameters(dr);
                        affectedRows = dal.ExecuteNonQuery(insertQuery, CommandType.Text, param);
                    }
                    else if (dr.RowState == DataRowState.Deleted)
                    {
                        dr.RejectChanges();
                        paramDelete[0] = new ParameterInfo("@UserId", CommonUserLogin.getUser().UserID);
                        paramDelete[1] = new ParameterInfo("@InvManID", dr["InvManID"]);
                        affectedRows = dal.ExecuteNonQuery(deleteQuery, CommandType.Text, paramDelete);
                    }
                    else if (dr.RowState == DataRowState.Modified)
                    {
                        dr["UserId"] = CommonUserLogin.getUser().UserID;
                        param = this.GetParameters(dr);
                        affectedRows = dal.ExecuteNonQuery(updateQuery, CommandType.Text, param);
                    }
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

        [WebMethod]
        public object[] selectClient()
        {
            object[] retval;
            DataSet ds = new DataSet();
            string query = @"SELECT OwnerName
                            FROM Entity(NOLOCK)
                            ORDER BY OwnerName";
            try
            {
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0)
                {
                    retval = new object[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        retval[i] = ds.Tables[0].Rows[i]["OwnerName"].ToString();
                    }
                }
                else
                    retval = new object[0];
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
        public object[] selectLanguage()
        {
            object[] retval;
            DataSet ds = new DataSet();
            string query = @"SELECT Description
                            FROM LanguageMaster(NOLOCK)
                            ORDER BY Description";
            try
            {
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0)
                {
                    retval = new object[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        retval[i] = ds.Tables[0].Rows[i]["Description"].ToString();
                    }
                }
                else
                    retval = new object[0];
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
        public bool insertImagesManifested(string from, string to)
        {
            bool retval = false;
            try
            {
                string file = from.Split('\\')[from.ToString().Split('\\').Length - 1];
                ParameterInfo[] param = new ParameterInfo[4];
                string queryImagesManifestedInsert = @"INSERT INTO ImagesManifested
                                                           (ID
                                                           ,FileName
                                                           ,FromFolder
                                                           ,ToFolder
                                                           ,ProcessedDate)
                                                     VALUES
                                                           (@ID
                                                           ,@FileName
                                                           ,@FromFolder
                                                           ,@ToFolder
                                                           ,GETDATE())";
                dal.OpenDB();
                dal.BeginTransaction();
                param[0] = new ParameterInfo("@ID", file.Split('.')[0]);
                param[1] = new ParameterInfo("@FileName", file);
                param[2] = new ParameterInfo("@FromFolder", from.Substring(0, from.Length - file.Length));
                param[3] = new ParameterInfo("@ToFolder", to.Substring(0, to.Length - file.Length));

                dal.ExecuteNonQuery(queryImagesManifestedInsert, CommandType.Text, param);
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
                ImageAuditTrail(ImageID, descriptionID, dal, systemUserName);
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
    }
}
