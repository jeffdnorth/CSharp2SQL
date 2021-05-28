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

        public Vendor GetByCode(string Code)
        {
            var sql = "SELECT * From Vendors Where Code = @code;";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@code", Code);
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }

            reader.Read();
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
            reader.Close();
            return vendor;

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
                vendors.Add(vendor);
            }
            reader.Close();
            return vendors;
        }

        public Vendor GetByPk(int id)
        {
            var sql = "SELECT * From Vendors Where Id = @id;";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return null;
            }
            reader.Read();
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
            reader.Close();
            return vendor;
        }

        private void LoadSqlParametersFromVendor(SqlCommand cmd, Vendor vendor)
        {
            cmd.Parameters.AddWithValue("@code", vendor.Code);
            cmd.Parameters.AddWithValue("@name", vendor.Name);
            cmd.Parameters.AddWithValue("@address", vendor.Address);
            cmd.Parameters.AddWithValue("@city", vendor.City);
            cmd.Parameters.AddWithValue("@state", vendor.State);
            cmd.Parameters.AddWithValue("@zip", vendor.Zip);
            cmd.Parameters.AddWithValue("@phone", vendor.Phone);
            cmd.Parameters.AddWithValue("@email", vendor.Email);
        }


        public bool Create(Vendor vendor)
        {
            var sql = "INSERT into Vendors "
                    + " (Code, Name, Address,City, State, Zip, Phone, Email) "
                    + " VALUES (@code, @name, @address, @city, @state, @zip, @phone, @email);";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            //cmd.Parameters.AddWithValue("@id, id);
            LoadSqlParametersFromVendor(cmd, vendor);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }

        public bool Change(Vendor vendor)
        {
            var sql = "Update Vendors "
                + " Code = @code, Name = @name, Address = @address, City = @city, "
                + " State = @state, Zip = @zip, Phone = @phone, Email = @email "
                + " Where Id = @id; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@id", vendor.Id);
            LoadSqlParametersFromVendor(cmd, vendor);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }

        public bool Remove(int id)
        {
            var sql = "DELETE Vendors "
                + " Where Id = @id; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            return (rowsAffected == 1);
        }
    }
}


        






            

              

/*

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


        public bool Remove(int, id)
        {
            var sql = $"DELETE from Vendor " +
                 " Where Id = @id ; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@id", id);
            var rowsAffected = cmd.ExecuteNonQuery();
            //boolian expression returns true or false for a return of values esp boolian
            return (rowsAffected == 1);
        }

    }
}

*/