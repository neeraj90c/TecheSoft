using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public abstract class DABase
    {
        protected string ConnectionString { get; set; }
        public DABase() { }
        public DABase(string DBConn)
        {
            if (!string.IsNullOrEmpty(DBConn))
            {
                ConnectionString = DBConn;
            }
        }

        protected static T SafeRead<T>(IDataReader reader, string name, T defaultValue)
        {
            object o = reader[name];
            if (o != System.DBNull.Value && o != null)
                return (T)Convert.ChangeType(o, defaultValue.GetType());

            return defaultValue;
        }

        protected static T? SafeReadNullable<T>(IDataReader reader, string name) where T : struct
        {
            object o = reader[name];
            if (o != System.DBNull.Value && o != null)
                return (T)Convert.ChangeType(o, typeof(T));

            return null;
        }

        protected void AddParameter(SqlCommand command, string paramName, SqlDbType type, ParameterDirection direction, object value = null)
        {
            SqlParameter parameter = new SqlParameter(paramName, type);
            if (direction == ParameterDirection.Input || direction == ParameterDirection.InputOutput)
            {
                parameter.Value = (value != null ? Convert.ChangeType(value, value.GetType()) : null);
            }
            command.Parameters.Add(parameter);
        }

        protected SqlCommand GetCommandObject(string procName, SqlConnection connection)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            return command;
        }
    }
}
