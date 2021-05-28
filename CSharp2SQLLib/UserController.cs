using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp2SQLLib
{
    class UserController
    {
        private static Connection connection { get; set; }

        public bool Create(User user)
            var sql = "INSERT into Users "
                + " (Username, Password, Firstname, Lastname, Phone, Email, IsReviewer, IsAdmin) "
                + VALUES(@username, @password, @firstname, @lastname, @phone, @email, @isreviewer, @isadmin); ";
            var cmd = new Sqlcommand(SqlLib, connection, SqlConn);
        cmd.Parameters.AddWithValue("@username", username.Username);
            cmd.Parameters.AddWithValue("@password", password.Password);
            cmd.Parameters.AddWithValue("@username", firstname.Firstname);
            cmd.Parameters.AddWithValue("@username", lastname.Lastname);
            cmd.Parameters.AddWithValue("@username", phone.Phone);
            cmd.Parameters.AddWithValue("@username", email.Email);
            cmd.Parameters.AddWithValue("@username", isreviewer.IsReviewer);
            cmd.Parameters.AddWithValue("@isadmin", isadmin.IsAdmin);
            var(rowsAffected == 1);



        public bool Create(User user, string UserCode)
        {
            var userCtrl = new UsersController(connection);
            var user = userCtrl.GetByCode(UserCode);
            user.User.Id = user.Id;
            return Create(user);
        }
        private User FillUserFromSqlRow(SqlDataReader reader)
        {
            var user = new User();
            {
                Id = Convert.ToInt32(reader["Id"]),
            Username = Convert.ToString(reader["Username"]),
            Password = Convert.ToString(reader["Password"]),
            Firstname = Convert.ToString(reader["Firstname"]),
            Lastname = Convert.ToString(reader["Lastname"]),
            Phone = Convert.ToString(reader["Phone"]),
            Email = Convert.ToString(reader["Email"]),
            IsReviewer = Convert.Bool(reader["IsReviewer"]),
            IsAdmin = Convert.Bool(reader["IsAdmin"])
             };
            return Users;
        }


        


            private bool Create(object user)
        {
            throw new NotImplementedException();
        }



    }
}
