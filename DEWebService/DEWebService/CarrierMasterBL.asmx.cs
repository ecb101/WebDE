using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text;

namespace DEWebService
{
    /// <summary>
    /// Summary description for CarrierMasterBL
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CarrierMasterBL : BaseBLogic
    {
        public override void setQueries()
        {
            this.insertQuery = @"INSERT INTO Carrier
                                       ([DeScac]
                                       ,[Mode]
                                       ,[Level]
                                       ,[KeyingInstructions]
                                       ,[UpdateTimestamp]
                                       ,[UpdateUsername]
                                       ,[UpdateMachine])
                                 VALUES
                                       (@DeScac
                                       ,@Mode
                                       ,@Level
                                       ,@KeyingInstructions
                                       ,@UpdateTimestamp
                                       ,@UpdateUsername
                                       ,@UpdateMachine)";
            this.updateQuery = @"UPDATE Carrier
                                   SET [DeScac] = @DeScac
                                      ,[Mode] = @Mode
                                      ,[Level] = @Level
                                      ,[KeyingInstructions] = @KeyingInstructions
                                      ,[UpdateTimestamp] = @UpdateTimestamp
                                      ,[UpdateUsername] = @UpdateUsername
                                      ,[UpdateMachine] = @UpdateMachine
                                 WHERE DeScac =@DeScac";
            this.deleteQuery = @"DELETE FROM Carrier
                                WHERE DeScac =@DeScac";
            this.selectQuery = @"SELECT * FROM Carrier                           
                                WHERE DeScac =@DeScac";
            this.selectAllQuery = "SELECT * FROM Carrier";
        }
    }
}
