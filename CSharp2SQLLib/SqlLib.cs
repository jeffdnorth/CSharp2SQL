using Microsoft.Data.SqlClient;
using System;

namespace CSharp2SQLLib
{
    public class SqlLib
    {//testing that they are linked
        public static string About { get; set; } = "About CSharp2SqlLib";

        public SqlConnection sqlconn { get; set; }

        public void Connect()
        {
            var connStr = "server =localhost\\sqlexpress;" +
                          "database=PrsDb;" +
                          "trusted_connection=true;";
            //creat instance of connection
            sqlconn = new SqlConnection(connStr);
            sqlconn.Open();

            if (sqlconn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection string is not correct!");
            }
            Console.WriteLine("Open connection successful!");
        }
        public void Disconnect()
        {
            if(sqlconn == null)
            {
                return;
            }
            {
                sqlconn.Close();
                sqlconn = null;
            }
        }
    }

}