﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class VendorsController
    {
        private static Connection connection { get; set; }

        public VendorsController(Connection connection)
        {
            VendorsController.connection = connection;
        }

        private Vendor FillVendorFromReader(SqlDataReader reader)
        {
            var vendor = new Vendor()
            {
                Id = Convert.ToInt32(reader["Id"]),

                Code = Convert.ToString(reader["Code"]),
                Name = Convert.ToString(reader["Name"]),
                Address = Convert.ToString(reader["Address"]),
                City = Convert.ToString(reader["City"]),
                State = Convert.ToString(reader["State"]),
                Zip = Convert.ToString(reader["Zip"]),
                Phone = Convert.ToString(reader["Phone"]),
                Email = Convert.ToString(reader["Email"])
            };
            return vendor;
        }
        public List<Vendor> GetAll()
        {
            var sql = "SELECT * from Vendors;";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            var reader = cmd.ExecuteReader();
            var vendors = new List<Vendor>();
            while (reader.Read())
            {
                var vendor = FillVendorFromReader(reader);
                {
                    Id = Convert.ToInt32(reader["Id"]),

                    Code = Convert.ToString(reader["Code"]),
                    Name = Convert.ToString(reader["Name"]),
                    Address = Convert.ToString(reader["Address"]),
                    City = Convert.ToString(reader["City"]),
                    State = Convert.ToString(reader["State"]),
                    Zip = Convert.ToString(reader["Zip"]),
                    Phone = Convert.ToString(reader["Phone"]),
                    Email = Convert.ToString(reader["Email"])

                };
                vendors.Add(vendor);
            }
            reader.Close();
            return vendors;
        }

        //create is method name..doing instead of insert...create a new instance of user

        public bool Create(Vendor vendor)
        {
            var sql = $"INSERT into Vendors" +
                    " (Code, Name, Address, City, State, Zip, Phone, Email) " +
                    " VALUES " +
                    $"( @Code , @Name, @Address, @City, @State @Zip, @Phone, @Email) ";

            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            {
                sqlcmd.Parameters.AddWithValue("@code", vendor.Code);
                sqlcmd.Parameters.AddWithValue("@name", vendor.Name);
                sqlcmd.Parameters.AddWithValue("@address", vendor.Address);
                sqlcmd.Parameters.AddWithValue("@city", vendor.City);
                sqlcmd.Parameters.AddWithValue("@state", vendor.State);
                sqlcmd.Parameters.AddWithValue("@zip", vendor.Zip);
                sqlcmd.Parameters.AddWithValue("@phone", vendor.Phone);
                sqlcmd.Parameters.AddWithValue("@email", vendor.Email);
                var rowsAffected = sqlcmd.ExecuteNonQuery();

                //boolian expression returns true or false for a return of values esp boolian
                return (rowsAffected == 1);
            }
        }



        public bool Change(Vendor vendor)
        {
            var sql = $"Update Set " +
                " Code = @code, " +
                " Name = @name, " +
                " Address = @address, " +
                " City = @city, " +
                " State = @state, " +
                " Zip = @zip, " +
                " Phone = @phone, " +
                " Email = @email, ";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);

            sqlcmd.Parameters.AddWithValue("@code", vendor.Code);
            sqlcmd.Parameters.AddWithValue("@name", vendor.Name);
            sqlcmd.Parameters.AddWithValue("@address", vendor.Address);
            sqlcmd.Parameters.AddWithValue("@city", vendor.City);
            sqlcmd.Parameters.AddWithValue("@state", vendor.State);
            sqlcmd.Parameters.AddWithValue("@zip", vendor.Zip);
            sqlcmd.Parameters.AddWithValue("@phone", vendor.Phone);
            sqlcmd.Parameters.AddWithValue("@email", vendor.Email);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            //boolian expression returns true or false for a return of values esp boolian
            return (rowsAffected == 1);
        }


        public bool Delete(Vendor vendor)
        {
            var sql = $"DELETE from Vendor " +
                 " Where Id = @id ; ";
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", vendor.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            //boolian expression returns true or false for a return of values esp boolian
            return (rowsAffected == 1);
        }

    }
}

