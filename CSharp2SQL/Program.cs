using CSharp2SQLLib;
using System;
using static CSharp2SQLLib.user;

namespace CSharp2SQL
{

    class Program

    {
        static void Main(string[] args)
        {
            var sqlconn = new Connection("localhost\\sqlexpress", "PrsDb");

            var newProduct new Product()
            {
                Id = 0,
                PartNbr = "SKYLINE",
                Name = "Skyline Chili",
                Price = 5,
                Unit = "Each', PhotoPath = null, VendorId = 0"
            };

            var productsController = new ProductsController(sqlconn);
            var success = productsController.Create(newProduct, "KROG");

            var vendorsController = new VendorsController(sqlconn);
            var vendors = vendorsController.GetAll();

            var products = productsController.GetAll();
            var product = productsController.GetByPK(1);
            Console.WriteLine(product);

            sqlconn.Disconnect();
        }


    }
}


        /*
        {
            //for the add to user
            var sqllib = new SqlLib();
            sqllib.Connect();

            var user = sqllib.GetByPK(1002);
            user.Phone = "5135551212";
            var success = sqllib.Change(user);

            //create class for sql connection


            //for the remove for sql delete
            var successD = sqllib.Delete(user);
           
            //adding or inserting the "wrong way"  string concat below is never the best way to do it
            var newUser = new User()
            {
                Id =0, Username = "XYZ2" , Password = "XYZ", Firstname = "XYZ", Lastname = "XYZ",
                Phone = "XYZ", Email = "XYZ", IsReviewer = true, IsAdmin = true
            };
            //comment out so var is not duplicated in the create and add
            //var success = sqllib.Create(newUser);


            var users = sqllib.GetAllUsers();
            var nulluser = sqllib.GetByPK(0);
            var vendors = sqllib.GetAllVendors();
            var vendor = sqllib.VendorGetByPK(1);
            var nullvendor = sqllib.VendorGetByPK(0);

            sqllib.Disconnect();
        }
        
    }
}

            */