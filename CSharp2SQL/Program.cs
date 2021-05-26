using CSharp2SQLLib;
using System;

namespace CSharp2SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqllib = new SqlLib();
            sqllib.Connect();

            var users = sqllib.GetAllUsers();
            var user = sqllib.GetByPK(1);
            var nulluser = sqllib.GetByPK(0);
            //
            var vendors = sqllib.GetAllVendors();
            var vendor = sqllib.GetByPK();
            var nullvendor = sqllib.GetByPK();


            sqllib.Disconnect();
        }
        
    }
}
