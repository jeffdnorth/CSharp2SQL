using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class Connection
    {
        //property for Sql Conn
        public SqlConnection SqlConn { get; set; }

        //constructor to pass in server parameter and data base
        public void Disconnect()
        {
            if (SqlConn == null)
            {
                return;
            }
            SqlConn.Close();
            SqlConn = null;

        }
        public Connection(string server, string database)
        {
            var connStr = $"server={server};database={database};trusted_connection=true;";
            SqlConn = new SqlConnection(connStr);
            SqlConn.Open();
            if (SqlConn.State != System.Data.ConnectionState.Open)
            {
                SqlConn = null;
                throw new Exception("Connection did not open!");
            }
        }
    }
}
