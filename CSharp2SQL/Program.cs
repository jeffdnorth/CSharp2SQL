using CSharp2SQLLib;
using System;
using static CSharp2SQLLib.user;

namespace CSharp2SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqllib = new SqlLib();
            sqllib.Connect();

            //adding or inserting the "wrong way"  string concat below is never the best way to do it
            var newUser = new User()
            {
                Id =0, Username = "XYZ1" , Password = "XYZ", Firstname = "XYZ", Lastname = "XYZ",
                Phone = "XYZ", Email = "XYZ", IsReviewer = true, IsAdmin = true
            };
            var success = sqllib.Create(newUser);


            var users = sqllib.GetAllUsers();
            var user = sqllib.GetByPK(1);
            var nulluser = sqllib.GetByPK(0);
            //
            var vendors = sqllib.GetAllVendors();
            var vendor = sqllib.VendorGetByPK(1);
            var nullvendor = sqllib.VendorGetByPK(0);


            sqllib.Disconnect();
        }
        
    }
}
