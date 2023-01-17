using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace DataBase.Helper
{
    public static class DatabaseHelper
    {
        private static OracleConnection connection = new OracleConnection();
        private static string oracleDatabase = "localhost:1521/XEPDB1";

        public static OracleConnection Connection
        {
            get => connection;
        }

        public static bool CreateConnect(string user, string pwd)
        {
            // 1. Create connection string
            string conStringUser = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + oracleDatabase + ";";

            // 2. Check object 
            if (connection == null)
                connection = new OracleConnection();

            // 3. Open connection
            connection.ConnectionString = conStringUser;
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
