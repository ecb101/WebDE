using System;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    public class ParameterInfoOleDB
    {
        public string Name;
        public object Value;
        public DbType DataType;
        public ParameterDirection Direction;
        public int Size;

        #region constructor

        public ParameterInfoOleDB(string paramName, object paramValue)
            : this(paramName, paramValue, DbType.String, ParameterDirection.Input, paramValue.ToString().Trim().Length)
        {
        }

        public ParameterInfoOleDB(string paramName, object paramValue, DbType paramType)
            : this(paramName, paramValue, paramType, ParameterDirection.Input, paramValue.ToString().Trim().Length)
        {
        }

        public ParameterInfoOleDB(string paramName, object paramValue, DbType paramType, int paramSize)
            : this(paramName, paramValue, paramType, ParameterDirection.Input, paramSize)
        {
        }

        public ParameterInfoOleDB(string paramName, object paramValue, DbType paramType, ParameterDirection paramDirection)
            : this(paramName, paramValue, paramType, paramDirection, 0)
        {
        }

        public ParameterInfoOleDB(string paramName, object paramValue, DbType paramType, ParameterDirection paramDirection, int paramSize)
        {
            Name = paramName;
            Value = paramValue;
            DataType = paramType;
            Direction = paramDirection;
            Size = paramSize;            
        }

        #endregion
    }
}
