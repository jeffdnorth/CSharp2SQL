using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class Connection
    {
        public SqlConnection SqlConn { get; set; }

        //constructor to pass in server parameter and data base
        public void Disconnect()
        {
            if (SqlConn == null)
            {
                return;
            }
            SqlConn.Close();

        }


        public Connection(string server, string database)
        {
            var ConnStr = $"server={server};database={database};trusted_connection=true;";
            SqlConn = new SqlConnection(ConnStr);
            SqlConn.Open();
            if (SqlConn.State != System.Data.ConnectionState.Open)
            {
                throw new Exception("Connection did not open!");
            }
        }
    }
}
