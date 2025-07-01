using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CarConnectApp.Util
{
    public class DBConnUtil
    {
        public static string GetConnectionString()
        {
            string filePath = "db.properties";
            Dictionary<string, string> props = DBPropertyUtil.GetProperties(filePath);

            return $"Server={props["server"]};Database={props["database"]};Integrated Security=True;TrustServerCertificate=True;";
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }
    }
}
