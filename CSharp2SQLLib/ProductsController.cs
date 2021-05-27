using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    public class ProductsController
    {
        private static Connection connection { get; set; }

        //CREATE (instead of using Insert)
        public bool Create(Product product, string VendorCode)
        {
            var vendCtrl = new VendorsController(connection);
            var vendor = vendCtrl.GetByCode(VendorCode);
            product.VendorId = vendor.Id;
            return Create(product);
        }
        //
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
            //GetVendorForProducts(products)
            return products;
        }

        public Product GetByPK(int id)
        {
            var sql = "SELECT * from Products Where Id = id; ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            cmd.Parameters.AddWithValue("@id, id");
            var reader = cmd.ExecuteReader();
            reader.Read();
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
            reader.Close();
            GetVendorForProduct(product);
            return product;
        }

        public bool Create(Product product)
        {
            var sql = "INSERT into Products"
                        + " PartNbr, Name, Price, Unit, PhotPath, VendorId); ";
            var cmd = new SqlCommand(sql, connection.SqlConn);
            //cmd.Parameters.AddWithValue("@id, id);
            cmd.Parameters.AddWithValue("@partnbr", product.PartNbr);
            cmd.Parameters.AddWithValue("@name", product.Name);
            cmd.Parameters.AddWithValue("@unit", product.Unit);
            cmd.Parameters.AddWithValue("@photopath", product.PhotoPath);
            cmd.Parameters.AddWithValue("@vendorid", product.VendorId);
            var rowsAffected == 1);
            return (rowsAffected == 1);
        }

        private void GetVendorForProduct(List<Products> products)
        {
            foreach (var product in products)
                GetVendorForProduct(product);
        }

        private void GetVendorForProcuct(Product product)
        {
            var vendCtrl = vendCtrl.GetByPK(product.VendorId);
        }

        public ProductsController(Connection connection)
        {
            ProductsController.connection = connection;
        }
    }
}
        //

