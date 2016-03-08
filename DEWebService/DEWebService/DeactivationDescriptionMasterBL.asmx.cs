using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DEWebService
{
    /// <summary>
    /// Summary description for DeactivationDescriptionMasterBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DeactivationDescriptionMasterBL : BaseBLogic
    {
        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO [DeactivationDescription]
                                       ([Description]
                                       ,[Note])
                                 VALUES
                                       (@Description
                                       ,@Note)";
            this.updateQuery = @"UPDATE DeactivationDescription
                                   SET [Description] = @Description
                                      ,[Note] = @Note
                                 WHERE DeactivationReasonID =@DeactivationReasonID";
            this.deleteQuery = @"DELETE FROM DeactivationDescription
                                WHERE DeactivationReasonID =@DeactivationReasonID";
            this.selectQuery = @"SELECT * FROM DeactivationDescription                           
                                WHERE DeactivationReasonID =@DeactivationReasonID";
            this.selectAllQuery = "SELECT * FROM DeactivationDescription";
        }        
    }
}
