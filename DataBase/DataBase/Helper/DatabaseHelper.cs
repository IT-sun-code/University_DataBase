using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using System.Windows.Documents;

namespace DataBase.Helper
{
    public static class DatabaseHelper
    {
        private static OracleConnection connection = new OracleConnection();

        public static OracleConnection Connection
        {
            get => connection;
        }

        public static bool CreateConnect(string user, string pwd, string dataSource)
        {
            // 1. Create connection string
            OracleConnectionStringBuilder connectBuilder = new OracleConnectionStringBuilder();
            connectBuilder.UserID = user;
            connectBuilder.Password = pwd;
            connectBuilder.DataSource = dataSource;

            connectBuilder.MaxPoolSize = 150;
            connectBuilder.ConnectionTimeout = 60;
            connectBuilder.PersistSecurityInfo = true;

            // 2. Check object 
            if (connection == null)
                connection = new OracleConnection();

            // 3. Open connection
            connection.ConnectionString = connectBuilder.ConnectionString;
            connection.Open();

            // 4. Check connection statement
            Log.Information("Create Connection to Database");
            if (connection.State == System.Data.ConnectionState.Open)
                return true;

            return false;
        }

        public static OracleCommand CreateCommand() =>
            Connection.CreateCommand();

        public static void CloseConnect()
        {
            connection.Close();
            connection.Dispose();
            connection = null;
            Log.Information("Close Database Connection");
        }
    }
}
