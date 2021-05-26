using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using static CSharp2SQLLib.user;

namespace CSharp2SQLLib
{
    public class SqlLib
    {
        public static string About { get; set; } = "About CSharp2SqlLib";

        public SqlConnection sqlconn { get; set; }

        //create is method name..doing instead of insert...create a new instance of user, fill w data
        public bool Create(User user)
        {
            var sql = $"INSERT into Users" +
                " (Username, Password, Firstname, Lastname, Phone, Email, IsReviewer, IsAdmin) " +
                //need spaces on quotes for string concats
                " VALUES " +
                //string values require single quote
                $"( '{user.Username}' , '{user.Password}' , '{user.Firstname}', '{user.Lastname}' , " +
                                            //boolian op and ternary operator
                $" '{user.Phone}', '{user.Email}', {(user.IsReviewer  ? 1 : 0 )} , {(user.IsAdmin ? 1 : 0 )} )";
            var sqlcmd = new SqlCommand(sql, sqlconn);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            //boolian expression returns true or false for a return of values esp boolian
            return (rowsAffected == 1);
        }


        public User GetByPK(int id)
        {
            var sql = $"SELECT * from users Where id = {id};";
            var sqlcmd = new SqlCommand(sql, sqlconn);
            var sqldatareader = sqlcmd.ExecuteReader();
            if (!sqldatareader.HasRows)
            {
                sqldatareader.Close();
                return null;
            }
            sqldatareader.Read();
            var user = new User()
            {
                Id = Convert.ToInt32(sqldatareader["Id"]),
                Username = Convert.ToString(sqldatareader["Username"]),
                Password = Convert.ToString(sqldatareader["Password"]),
                Firstname = Convert.ToString(sqldatareader["Firstname"]),
                Lastname = Convert.ToString(sqldatareader["Lastname"]),
                Phone = Convert.ToString(sqldatareader["Phone"]),
                Email = Convert.ToString(sqldatareader["Email"]),
                IsReviewer = Convert.ToBoolean(sqldatareader["IsReviewer"]),
                IsAdmin = Convert.ToBoolean(sqldatareader["IsAdmin"]),
            };
            sqldatareader.Close();
            return user;
        }

        //

        public Vendors VendorGetByPK(int id)
        {
            var sql = $"SELECT * from vendors Where id = {id};";
            var sqlcmd = new SqlCommand(sql, sqlconn);
            var sqldatareader = sqlcmd.ExecuteReader();
            if (!sqldatareader.HasRows)
            {
                sqldatareader.Close();
                return null;
            }
            sqldatareader.Read();
            var vendor = new Vendors()
            {
                Id = Convert.ToInt32(sqldatareader["Id"]),
                Code = Convert.ToString(sqldatareader["Code"]),
                Name = Convert.ToString(sqldatareader["Name"]),
                Address = Convert.ToString(sqldatareader["Address"]),
                City = Convert.ToString(sqldatareader["City"]),
                Zip = Convert.ToString(sqldatareader["Zip"]),
                Phone = Convert.ToString(sqldatareader["Phone"]),
                Email = Convert.ToString(sqldatareader["Email"]),
            };
            sqldatareader.Close();
            return vendor;
        }

        //

        public List<Vendors> GetAllVendors()
        {
            var sql = "SELECT * From Vendors;";
            var SQLCMD = new SqlCommand(sql, sqlconn);
            var sqldatareader = SQLCMD.ExecuteReader();
            var vendors = new List<Vendors>();
            while (sqldatareader.Read())
            {
                var id = Convert.ToInt32(sqldatareader["Id"]);
                var code = Convert.ToString(sqldatareader["Code"]);
                var name = Convert.ToString(sqldatareader["Name"]);
                var address = Convert.ToString(sqldatareader["Address"]);
                var city = Convert.ToString(sqldatareader["City"]);
                var state = Convert.ToString(sqldatareader["State"]);
                var zip = Convert.ToString(sqldatareader["Zip"]);
                var phone = Convert.ToString(sqldatareader["Phone"]);
                var email = Convert.ToString(sqldatareader["Email"]);
                var vendor = new Vendors()
                {
                    Id = id,
                    Code = code,
                    Name = name,
                    Address = address,
                    City = city,
                    State = state,
                    Zip = zip,
                    Phone = phone,
                    Email = email,
                };
                vendors.Add(vendor);
            }
            sqldatareader.Close();
            return vendors;
        }

        //

        public List<User> GetAllUsers()
        {
            var sql = "SELECT * From Users;";
            var sqlcmd = new SqlCommand(sql, sqlconn);
            var sqldatareader = sqlcmd.ExecuteReader();
            var users = new List<User>();
            while (sqldatareader.Read())
            {
                var id = Convert.ToInt32(sqldatareader["Id"]);
                var username = Convert.ToString(sqldatareader["Username"]);
                var password = Convert.ToString(sqldatareader["Password"]);
                var firstname = Convert.ToString(sqldatareader["Firstname"]);
                var lastname = Convert.ToString(sqldatareader["Lastname"]);
                var phone = Convert.ToString(sqldatareader["Phone"]);
                var email = Convert.ToString(sqldatareader["Email"]);
                var isReviewer = Convert.ToBoolean(sqldatareader["IsReviewer"]);
                var isAdmin = Convert.ToBoolean(sqldatareader["IsAdmin"]);
                var user = new User()
                {
                    Id = id,
                    Username = username,
                    Password = password,
                    Firstname = firstname,
                    Lastname = lastname,
                    Phone = phone,
                    Email = email,
                    IsReviewer = isReviewer,

                };
                users.Add(user);

            }
            sqldatareader.Close();
            return users;
        }

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
            if (sqlconn == null)
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