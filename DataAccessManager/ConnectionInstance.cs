using System;
using System.Data.SqlClient;

namespace DataAccessManager
{

    
    public sealed class ConnectionInstance
    {
        SqlConnection sqlConnection = null;
        SqlCommand sqlcommand = null;
        SqlDataAdapter sqlDataAdapter = null;


        public ConnectionInstance(string connectionString)
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlConnection;
            sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = sqlcommand;
            sqlDataAdapter.SelectCommand.Connection = sqlConnection;

        }

        public Tuple<SqlConnection, SqlCommand, SqlDataAdapter> GetSqlConnectionInstances()
        {
            return new Tuple<SqlConnection, SqlCommand, SqlDataAdapter>(sqlConnection, sqlcommand, sqlDataAdapter);
        }

        public void DisposeSqlConnection()
        {
            sqlConnection.Dispose();
            sqlConnection = null;
        }
    }
}
