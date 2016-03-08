using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Collections;
namespace DAL
{
    public sealed class DALHelperOleDB
    {
        OleDbConnection dbConn;
        OleDbTransaction trans;

        #region constructor
        public DALHelperOleDB()
        {
            this.dbConn = getConnection();

        }

        public DALHelperOleDB(string OtherConnection)
        {
            this.dbConn = getConnection(OtherConnection);
        }

        public DALHelperOleDB(string OtherConnection, string MXXDatabaseName)
        {
            this.dbConn = getConnection(OtherConnection, MXXDatabaseName);
        }
        #endregion

        #region Connect
        private OleDbConnection getConnection()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["Batch_DEConnection"].ConnectionString;
            return new OleDbConnection(ConnectionString);

        }

        private OleDbConnection getConnection(string OtherConnection)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[OtherConnection].ConnectionString;
            return new OleDbConnection(ConnectionString);

        }

        private OleDbConnection getConnection(string OtherConnection, string MXXDatabaseName)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[OtherConnection].ConnectionString + MXXDatabaseName;
            return new OleDbConnection(ConnectionString);
        }

        public void OpenDB()
        {
            try
            {
                if (this.dbConn.State == ConnectionState.Closed)
                    this.dbConn.Open();
            }
            catch
            {

            }
        }

        public void CloseDB()
        {
            try
            {
                if (this.dbConn.State == ConnectionState.Open)
                    this.dbConn.Close();
            }
            catch
            {

            }
        }

        public void BeginTransaction()
        {
            try
            {
                if (this.trans == null)
                    this.trans = this.dbConn.BeginTransaction();
            }
            catch
            {

            }
        }

        public void CommitTransaction()
        {
            try
            {
                if (this.trans != null)
                {
                    this.trans.Commit();
                    this.trans = null;
                }
            }
            catch
            {

            }
        }

        public void RollBackTransaction()
        {
            try
            {
                if (this.trans != null)
                {
                    this.trans.Rollback();
                    this.trans = null;
                }
            }
            catch
            {

            }
        }
        #endregion

        #region execute DataSet
        public DataSet ExecuteDataSet(string sqlStatement)
        {
            return this.ExecuteDataSet(sqlStatement, CommandType.Text, null);
        }

        public DataSet ExecuteDataSet(string sqlStatement, CommandType cmdType)
        {
            return this.ExecuteDataSet(sqlStatement, cmdType, null);
        }

        public DataSet ExecuteDataSet(string sqlStatement, CommandType cmdType, ParameterInfoOleDB[] paramCol)
        {
            DataSet ds = new DataSet();

            OleDbCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = sqlStatement;
            cmd.CommandType = cmdType;

            if (this.trans != null)
                cmd.Transaction = this.trans;

            if (paramCol != null)
            {
                foreach (ParameterInfoOleDB prmInfo in paramCol)
                {
                    OleDbParameter prm = new OleDbParameter();

                    prm.ParameterName = prmInfo.Name;
                    prm.DbType = prmInfo.DataType;
                    prm.Size = prmInfo.Size;
                    prm.Value = prmInfo.Value;
                    prm.Direction = prmInfo.Direction;

                    cmd.Parameters.Add(prm);
                }
            }

            IDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds);

            return ds;
        }
        #endregion

        #region execute nonquery
        public int ExecuteNonQuery(string sqlStatement)
        {
            return this.ExecuteNonQuery(sqlStatement, CommandType.Text, null);
        }

        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType)
        {
            return this.ExecuteNonQuery(sqlStatement, cmdType, null);
        }

        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType, ParameterInfoOleDB[] paramCol)
        {
            int affectedRows = 0;
            bool isOutputParameter = false;

            OleDbCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = sqlStatement;
            cmd.CommandType = cmdType;

            if (this.trans != null)
                cmd.Transaction = this.trans;

            if (paramCol != null)
            {
                foreach (ParameterInfoOleDB prmInfo in paramCol)
                {
                    OleDbParameter prm = new OleDbParameter();

                    prm.ParameterName = prmInfo.Name;
                    prm.DbType = prmInfo.DataType;
                    prm.Size = prmInfo.Size;
                    prm.Value = prmInfo.Value;
                    prm.Direction = prmInfo.Direction;

                    cmd.Parameters.Add(prm);
                }
            }

            affectedRows = cmd.ExecuteNonQuery();

            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                isOutputParameter = (((OleDbParameter)cmd.Parameters[i]).Direction == ParameterDirection.Output) || (((OleDbParameter)cmd.Parameters[i]).Direction == ParameterDirection.InputOutput) || (((OleDbParameter)cmd.Parameters[i]).Direction == ParameterDirection.ReturnValue);

                if (isOutputParameter)
                    paramCol[i].Value = ((OleDbParameter)cmd.Parameters[i]).Value;
            }

            return affectedRows;
        }
        #endregion

        #region execute scalar
        public object ExecuteScalar(string sqlStatement)
        {
            return this.ExecuteScalar(sqlStatement, CommandType.Text, null);
        }

        public object ExecuteScalar(string sqlStatement, CommandType cmdType)
        {
            return this.ExecuteScalar(sqlStatement, cmdType, null);
        }

        public object ExecuteScalar(string sqlStatement, CommandType cmdType, ParameterInfoOleDB[] paramCol)
        {
            OleDbCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = sqlStatement;
            cmd.CommandType = cmdType;

            if (this.trans != null)
                cmd.Transaction = this.trans;

            if (paramCol != null)
            {
                foreach (ParameterInfoOleDB prmInfo in paramCol)
                {
                    OleDbParameter prm = new OleDbParameter();

                    prm.ParameterName = prmInfo.Name;
                    prm.DbType = prmInfo.DataType;
                    prm.Size = prmInfo.Size;
                    prm.Value = prmInfo.Value;
                    prm.Direction = prmInfo.Direction;

                    cmd.Parameters.Add(prm);
                }
            }

            return cmd.ExecuteScalar();
        }
        #endregion

        #region Batch Updating
        public void BatchUpdate(DataTable dt, string tableName, bool continueOnError)
        {
            OleDbCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = string.Format("SELECT * FROM {0}", tableName);            
            cmd.CommandType = CommandType.Text;
            
            if (this.trans != null)
                cmd.Transaction = this.trans;

            dt.TableName = tableName;

            OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM {0}", tableName), (OleDbConnection)this.dbConn);            
            adapter.SelectCommand = (OleDbCommand)cmd;
            adapter.ContinueUpdateOnError = continueOnError;            
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

            builder.QuotePrefix = "[";
            builder.QuoteSuffix = "]";
            
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.Update(dt);
        }

        #endregion

        #region other Methods
        public DataTable GetTableStructure(string tableName)
        {
            DataTable dt = new DataTable();
            OleDbCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandText = string.Format("SELECT * from {0}", tableName);
            cmd.CommandType = CommandType.Text;

            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.FillSchema(dt, SchemaType.Source);
            return dt;
        }

        public ArrayList GetPrimaryKeys(string TableName)
        {
            ArrayList retval = new ArrayList();

            DataTable dt = this.ExecuteDataSet(string.Format("sp_pkeys {0}", TableName.Replace("dbo.", " "))).Tables[0];

            foreach (DataRow dr in dt.Rows)
                retval.Add(dr["COLUMN_NAME"].ToString());

            return retval;
        }

        /*
        public void RepairDatabase(string MXXDatabaseName)
        {
            try
            {
                object[] oParams;
                string connectionString = ConfigurationManager.ConnectionStrings["MXXDBConnection"].ConnectionString + MXXDatabaseName;
                string newConnectionString = ConfigurationManager.ConnectionStrings["MXXDBConnection"].ConnectionString + "Temp" + MXXDatabaseName;
                oParams = new object[] { connectionString, newConnectionString + ";Jet OLEDB:Engine Type=4" };
                object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));
                objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                objJRO = null;
                System.IO.File.Delete(ConfigurationManager.AppSettings["MDBSourcePath"] + MXXDatabaseName);
                System.IO.File.Move(ConfigurationManager.AppSettings["MDBSourcePath"] + "Temp" + MXXDatabaseName, ConfigurationManager.AppSettings["MDBSourcePath"] + MXXDatabaseName);
            }
            catch (Exception error)
            {
                throw error;
            }

        }*/

        public void RepairDatabase(string MXXDatabaseName)
        {
            object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("Access.Application"));
            try
            {
                objJRO.GetType().InvokeMember("RepairDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, new Object[] { "Provider=Microsoft.Jet.OLEDB.3.5;Data Source=" + MXXDatabaseName + ";Jet OLEDB:Engine Type=4" });
                //System.IO.File.Delete(ConfigurationManager.AppSettings["MDBSourcePath"] + MXXDatabaseName);
                //System.IO.File.Move(ConfigurationManager.AppSettings["MDBSourcePath"] + "Temp" + MXXDatabaseName, ConfigurationManager.AppSettings["MDBSourcePath"] + MXXDatabaseName);
            }
            catch (Exception error)
            {
                throw error;
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
                objJRO = null;
            }

        }

        //public void RepairDatabase(string DatabaseName)
        //{
        //    try
        //    {
        //        DAO.DBEngine db = new DAO.DBEngine();
        //        db.RepairDatabase(DatabaseName);
        //    }
        //    catch (Exception error)
        //    {
        //        throw error;
        //    }

        //}
        #endregion
    }

}
