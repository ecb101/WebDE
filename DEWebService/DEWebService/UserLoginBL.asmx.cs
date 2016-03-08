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
    /// Summary description for UserLoginBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserLoginBL : BaseBLogic
    {
        public override void setQueries()
        {
        }

        [WebMethod]
        public DataSet validateLogin(string userID, string password, string siteID)
        {            
            DataSet retval = new DataSet();
            string query = @"SELECT 
                                UserPassword,
                                UserInitials,
                                UserType
                            FROM DEUsers
                            WHERE 
                                UserID = @UserID
                            AND SiteID = @SiteID
                            AND Status = 'A'";
            //get info from database on the UserID provided
            try
            {
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@UserID", userID);
                param[1] = new ParameterInfo("@SiteID", siteID);
                dal.OpenDB();
                retval = dal.ExecuteDataSet(query, CommandType.Text, param);
            }
            catch (Exception error)
            {
                retval = null;
                throw error;
            }
            finally
            {
                dal.CloseDB();
            }
            
            return retval;
        }

        [WebMethod]
        public bool UpdatePassword(string userID, string password)
        {
            bool retval = false;
            int affectedRows = 0;
            string queryUpdate = @"UPDATE DEUsers
                                    SET  UserPassword= @UserPassword
                                    WHERE UserID = @UserID";
            try
            {
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@UserPassword", CommonEncrytion.Encrypt(password));
                param[1] = new ParameterInfo("@UserID", userID);
                dal.OpenDB();
                dal.BeginTransaction();
                affectedRows = dal.ExecuteNonQuery(queryUpdate, CommandType.Text, param);
                dal.CommitTransaction();
                retval = true;
            }
            catch
            {
                dal.RollBackTransaction();
                retval = false;
            }
            finally
            {
                dal.CloseDB();
            }
            return retval;
        }

        [WebMethod]
        public string selectPassword(string userID)
        {
            string retval = string.Empty;

            DataSet dsUser = new DataSet();
            string query = @"SELECT 
                                UserPassword
                            FROM DEUsers
                            WHERE 
                                UserID = @UserID
                            AND SiteID = @SiteID";
            try
            {
                ParameterInfo[] param = new ParameterInfo[2];
                param[0] = new ParameterInfo("@UserID", userID);
                param[1] = new ParameterInfo("@SiteID", ConfigurationManager.AppSettings["SiteID"]);
                dal.OpenDB();
                dsUser = dal.ExecuteDataSet(query, CommandType.Text, param);
                if (dsUser != null && dsUser.Tables[0].Rows.Count > 0)
                {
                    retval = dsUser.Tables[0].Rows[0]["UserPassword"].ToString().Trim();
                }
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
