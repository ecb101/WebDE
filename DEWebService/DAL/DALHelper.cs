using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using CommonLibrary;
namespace DAL
{
    public sealed class DALHelper
    {
        SqlConnection dbConn;
        SqlTransaction trans;

        #region constructor
        public DALHelper()
        {
            this.dbConn = getConnection();
        }

        public DALHelper(string OtherConnection)
        {
            this.dbConn = getConnection(OtherConnection);
        }
        #endregion

        #region Connect
        private SqlConnection getConnection()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["LocalDEConnection"].ConnectionString;
            return new SqlConnection(ConnectionString);

        }

        private SqlConnection getConnection(string OtherConnection)
        {            
            string ConnectionString = string.Empty;
            if (OtherConnection == "LocalDEConnection" || OtherConnection == "DEConnection")
                ConnectionString = ConfigurationManager.ConnectionStrings[OtherConnection].ConnectionString + CommonEncrytion.Decrypt(ConfigurationManager.AppSettings["LocalDEConnectionPassword"]);
            else
                ConnectionString = ConfigurationManager.ConnectionStrings[OtherConnection].ConnectionString;
            return new SqlConnection(ConnectionString);
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

        public void TestOpenDB()
        {
            try
            {
                if (this.dbConn.State == ConnectionState.Closed)
                    this.dbConn.Open();
            }
            catch (Exception e)
            {
                throw e;
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

        public DataSet ExecuteDataSet(string sqlStatement, CommandType cmdType, ParameterInfo[] paramCol)
        {
            DataSet ds = new DataSet();

            SqlCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = sqlStatement;
            cmd.CommandType = cmdType;

            if (this.trans != null)
                cmd.Transaction = this.trans;

            if (paramCol != null)
            {
                foreach (ParameterInfo prmInfo in paramCol)
                {
                    SqlParameter prm = new SqlParameter();

                    prm.ParameterName = prmInfo.Name;
                    prm.SqlDbType = prmInfo.DataType;
                    prm.Size = prmInfo.Size;
                    prm.Value = prmInfo.Value;
                    prm.Direction = prmInfo.Direction;

                    cmd.Parameters.Add(prm);
                }
            }

            IDbDataAdapter adapter = new SqlDataAdapter();
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
        
        public int ExecuteNonQuery(string sqlStatement, CommandType cmdType, ParameterInfo[] paramCol)
        {
            int affectedRows = 0;
            bool isOutputParameter = false;

            SqlCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = sqlStatement;
            cmd.CommandType = cmdType;

            if (this.trans != null)
                cmd.Transaction = this.trans;

            if (paramCol != null)
            {
                foreach (ParameterInfo prmInfo in paramCol)
                {
                    SqlParameter prm = new SqlParameter();

                    prm.ParameterName = prmInfo.Name;
                    prm.SqlDbType = prmInfo.DataType;
                    prm.Size = prmInfo.Size;
                    prm.Value = prmInfo.Value;
                    prm.Direction = prmInfo.Direction;

                    cmd.Parameters.Add(prm);
                }
            }

            affectedRows = cmd.ExecuteNonQuery();

            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                isOutputParameter = (((SqlParameter)cmd.Parameters[i]).Direction == ParameterDirection.Output) || (((SqlParameter)cmd.Parameters[i]).Direction == ParameterDirection.InputOutput) || (((SqlParameter)cmd.Parameters[i]).Direction == ParameterDirection.ReturnValue);

                if (isOutputParameter)
                    paramCol[i].Value = ((SqlParameter)cmd.Parameters[i]).Value;
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
        
        public object ExecuteScalar(string sqlStatement, CommandType cmdType, ParameterInfo[] paramCol)
        {
            SqlCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = sqlStatement;
            cmd.CommandType = cmdType;

            if (this.trans != null)
                cmd.Transaction = this.trans;

            if (paramCol != null)
            {
                foreach (ParameterInfo prmInfo in paramCol)
                {
                    SqlParameter prm = new SqlParameter();

                    prm.ParameterName = prmInfo.Name;
                    prm.SqlDbType = prmInfo.DataType;
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
            SqlCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandTimeout = 0;
            cmd.CommandText = string.Format("SELECT * FROM {0}", tableName);
            cmd.CommandType = CommandType.Text;

            if (this.trans != null)
                cmd.Transaction = this.trans;

            dt.TableName = tableName;

            SqlDataAdapter adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0}", tableName), (SqlConnection)this.dbConn);
            adapter.SelectCommand = (SqlCommand)cmd;
            adapter.ContinueUpdateOnError = continueOnError;

            adapter.Update(dt);
        }
        #endregion

        #region other Methods
        public DataTable GetTableStructure(string tableName)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = this.dbConn.CreateCommand();
            cmd.CommandText = string.Format("SELECT * from {0}", tableName);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.FillSchema(dt, SchemaType.Source);
            return dt;
            
        }

        public ArrayList GetPrimaryKeys(string TableName)
        {
            ArrayList value = new ArrayList();

            DataTable dt = this.ExecuteDataSet(string.Format("sp_pkeys {0}", TableName.Replace("dbo.", " "))).Tables[0];

            foreach (DataRow dr in dt.Rows)
                value.Add(dr["COLUMN_NAME"].ToString());

            return value;
        }
        #endregion
    }
}
