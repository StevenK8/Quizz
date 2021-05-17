using QuizzNoGood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Controllers
{
    public class UserController
    {
        public static User UserConnection (string username, string password){
            DBConnection DB = new DBConnection();
            User u = DB.SelectUser(username);
            if (u is not null)
                if (u.VerifyPassword(password))
                    return u;
            return null;
        }

        public static (bool success, string message, User user) UserInscription(string username, string password, string repeatedPassword)
        {
            DBConnection DB = new DBConnection();
            if (password != repeatedPassword)
                return (false, "Passwords does not match", null);
            var u = User.CreateNewUser(username, password);
            if(!DB.InsertUser(u))
                return (false, "A user with this username already exist", null);

            return (true, "User successfully created", DB.SelectUser(username));
        }
       
    }
}
