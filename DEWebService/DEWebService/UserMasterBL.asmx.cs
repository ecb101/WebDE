using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using DAL;
using CommonLibrary;
namespace DEWebService
{
    /// <summary>
    /// Summary description for UserMasterBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserMasterBL : BaseBLogic
    {
        string insertQueryDetail;
        string deleteQueryDetail;
        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO DEUsers
                                       (UserID
                                       ,UserPassword
                                       ,UserLastName
                                       ,UserFirstName
                                       ,UserMiddleName
                                       ,UserInitials
                                       ,SiteID
                                       ,UserType
                                       ,Status
                                       ,LastLoginDateTime)
                                 VALUES
                                       (@UserID
                                       ,@UserPassword
                                       ,@UserLastName
                                       ,@UserFirstName
                                       ,@UserMiddleName
                                       ,@UserInitials
                                       ,@SiteID
                                       ,@UserType
                                       ,'A'
                                       ,@LastLoginDateTime)";
            this.updateQuery = @"UPDATE DEUsers
                                 SET 
                                       UserID = @UserID
                                      ,UserPassword = @UserPassword
                                      ,UserLastName = @UserLastName
                                      ,UserFirstName = @UserFirstName
                                      ,UserMiddleName = @UserMiddleName
                                      ,UserInitials = @UserInitials
                                      ,SiteID = @SiteID
                                      ,UserType = @UserType                                     
                                      ,LastLoginDateTime = @LastLoginDateTime                                      
                                 WHERE UserID = @UserID";
            this.deleteQuery = @"UPDATE DEUsers
                                 SET Status = 'D'
                                 WHERE UserID = @UserID";
            this.selectQuery = @"SELECT * 
                                     FROM DEUsers
                                     WHERE UserID = @UserID";
            this.selectAllQuery = "SELECT * FROM DEUsers WHERE Status = 'A'";

            insertQueryDetail = @"INSERT INTO UserGroupMasterDetail
                                       (UserGroupID
                                       ,UserID)
                                 VALUES
                                       (@UserGroupID
                                       ,@UserID)";
            deleteQueryDetail = @"DELETE FROM UserGroupMasterDetail
                                WHERE UserGroupID = @UserGroupID
                                AND UserID = @UserID";

        }

        [WebMethod]
        public int selectLastID()
        {
            int retval = -1;
            DataSet ds = new DataSet();
            string query = @"SELECT TOP 1 UserID FROM DEUsers
                                ORDER BY
	                                CASE WHEN ISNUMERIC(UserID) = 1 THEN UserID 
	                                ELSE 0 
	                                END 
                                DESC";
            try
            {
                dal.OpenDB();
                ds = dal.ExecuteDataSet(query, CommandType.Text);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    retval = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                else
                    retval = -1;
            }
            catch
            {
                ds = null;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public DataSet selectGroupDetail(string UserID)
        {
            DataSet retval = new DataSet();

            string query = @"SELECT GMH.UserGroupID AS UserGroupID
								  ,GMD.UserID AS UserID
                                  ,DEU.SiteID AS SiteID
                                  ,GMH.UserGroupDescription AS UserGroupDescription
                                  ,GMH.Mode AS Mode
                                  ,GMH.Client AS Client
                                  ,GMH.SCAC AS SCAC
                                  ,GMH.DocumentTYpe AS DocumentType
                                  ,GMH.Language AS Language                                  
                            FROM UserGroupMasterHeader GMH
                            INNER JOIN UserGroupMasterDetail GMD ON GMH.UserGroupID = GMD.UserGroupID
                            INNER JOIN DEUsers DEU ON GMD.UserID = DEU.UserID
                            WHERE GMD.UserID =@UserID";

            try
            {
                ParameterInfo[] param = new ParameterInfo[1];
                param[0] = new ParameterInfo("@UserID", UserID);
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
        public DataSet selectGroup()
        {
            DataSet retval = new DataSet();

            string query = @"SELECT UserGroupID, UserGroupDescription, Mode, Client,SCAC,DocumentType,Language
                            FROM UserGroupMasterHeader
                            ORDER BY UserGroupID";
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
        public bool saveUser(DataTable dtUser, DataSet dsDetail, bool isNew)
        {
            bool retval = false;
            ParameterInfo[] paramDetail = new ParameterInfo[3];
            ParameterInfo[] paramHeader;
            ParameterInfo[] param = new ParameterInfo[1];
            int affectedRows = 0;
            object count;
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                paramHeader = this.GetParameters(dtUser.Rows[0]);

                if (isNew)
                {
                    //check if UserInitial exist
                    string selectUserInitials = @"SELECT Count(*) FROM DEUsers WHERE UserInitials = @UserInitials";
                    param[0] = new ParameterInfo("@UserInitials", dtUser.Rows[0]["UserInitials"].ToString());
                    count = dal.ExecuteScalar(selectUserInitials, CommandType.Text, param);
                    if (Convert.ToInt32(count) == 0)
                        affectedRows = dal.ExecuteNonQuery(insertQuery, CommandType.Text, paramHeader);
                    else
                        throw new Exception("Specific user initial already exist.");                    
                }
                else
                {
                    affectedRows = dal.ExecuteNonQuery(updateQuery, CommandType.Text, paramHeader);                    
                }
                
                if (dsDetail != null)
                {
                    foreach (DataRow dr in dsDetail.Tables[0].Rows)
                    {
                        if (dr.RowState == DataRowState.Added)
                        {
                            paramDetail[0] = new ParameterInfo("@UserGroupID", dr["UserGroupID"].ToString());
                            paramDetail[1] = new ParameterInfo("@UserID", dr["UserID"].ToString());
                            paramDetail[2] = new ParameterInfo("@SiteID", dr["SiteID"].ToString());
                            affectedRows = dal.ExecuteNonQuery(insertQueryDetail, CommandType.Text, paramDetail);
                        }
                        else if (dr.RowState == DataRowState.Deleted)
                        {
                            dr.RejectChanges();
                            paramDetail[0] = new ParameterInfo("@UserGroupID", dr["UserGroupID"].ToString());
                            paramDetail[1] = new ParameterInfo("@UserID", dr["UserID"].ToString());
                            paramDetail[2] = new ParameterInfo("@SiteID", dr["SiteID"].ToString());
                            affectedRows = dal.ExecuteNonQuery(deleteQueryDetail, CommandType.Text, paramDetail);
                        }
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
        public bool deleteUser(string UserID, string SiteID)
        {
            bool retval = false;
            ParameterInfo[] param = new ParameterInfo[1];

            int affectedRows = 0;
            //string deleteDetail = @"DELETE FROM UserGroupMasterDetail WHERE UserID=@UserID";
            try
            {
                dal.OpenDB();
                dal.BeginTransaction();
                param[0] = new ParameterInfo("@UserID", UserID);
                //affectedRows = dal.ExecuteNonQuery(deleteDetail, CommandType.Text, param);
                affectedRows = dal.ExecuteNonQuery(deleteQuery, CommandType.Text, param);

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
    }
}
