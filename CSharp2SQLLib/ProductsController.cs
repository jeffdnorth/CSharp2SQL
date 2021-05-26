using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class ProductsController
    {
        private static Connection connection { get; set; }
            
        public List<Product> GetAll()
        {
            var sql = "SELECT * from Products;";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();
            while (reader.Read())
            {
                var product = new Product()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    PartNbr = Convert.ToString(reader["PartNbr"]),
                    Name = Convert.ToString(reader["Name"]),
                    Price = Convert.ToDecimal(reader["Price"]),
                    Unit = Convert.ToString(reader["Unit"]),
                    PhotoPath = Convert.ToString(reader["PhotPath"]),
                    VendorId = Convert.ToInt32(reader["VendorId"]),
                };
                products.Add(product);
            }
                reader.Close();

                foreach(var product in products)
                {
                GetVendorForProduct(product);
                }
         
                 return products;
        }
                

        private void GetVendorForProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public ProductsController(Connection connection)
        {
            ProductsController.connection = connection;
        }

        //CREATE (instead of using Insert)
        public bool Create(Product product)
        {
            var sql = $"Insert into Products" +
                " ( PartnNbr,Name, Price, Unit, PhotPath, VendorId ) " +
                " Values " +
                $"( @PartNbr, @name, @Price, @Unit, @PhotPath, @VendorId) ";
           
            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            {
                sqlcmd.Parameters.AddWithValue("@partnbr", product.PartNbr);
                sqlcmd.Parameters.AddWithValue("@name", product.Name);
                sqlcmd.Parameters.AddWithValue("@price", product.Price);
                sqlcmd.Parameters.AddWithValue("@unit", product.Unit);
                sqlcmd.Parameters.AddWithValue("@photopath", product.PhotoPath);
                sqlcmd.Parameters.AddWithValue("@vendorid", product.VendorId);
                var rowsAffected = sqlcmd.ExecuteNonQuery();
                return (rowsAffected == 1);
            }
        }

        public bool Change(Product product)
        {
            var sql = $"Update Set " +
                " PartNbr = @partNbr, " +
                " name =  @name, " +
                " Price = @price, " +
                " Unit = @unit, " +
                " PhotPath = @photoPath, " +
                " VendorId = @vendorid, ";

            var sqlcmd = new SqlCommand(sql, connection.SqlConn);

            sqlcmd.Parameters.AddWithValue("@partnbr", product.PartNbr);
            sqlcmd.Parameters.AddWithValue("@name", product.Name);
            sqlcmd.Parameters.AddWithValue("@price", product.Price);
            sqlcmd.Parameters.AddWithValue("@unit", product.Unit);
            sqlcmd.Parameters.AddWithValue("@photopath", product.PhotoPath);
            sqlcmd.Parameters.AddWithValue("@vendorid", product.VendorId);

            var rowsAffected = sqlcmd.ExecuteNonQuery();
            //boolian expression returns true or false for a return of values esp boolian
            return (rowsAffected == 1);
        }
        
        public bool Delete(Product product)
        {
            var sql = $"DELETE from product" +
                "Where Id = @id ; ";

            var sqlcmd = new SqlCommand(sql, connection.SqlConn);
            sqlcmd.Parameters.AddWithValue("@id", product.Id);
            var rowsAffected = sqlcmd.ExecuteNonQuery();
            //boolian expression returns true or false for a return of values esp boolian
            return (rowsAffected == 1);

        }
        
    }
}


