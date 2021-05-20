using QuizzNoGood.Buisness;
using QuizzNoGood.Controllers;
using QuizzNoGood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Models
{
    public class ConnectionViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public User Connect()
        {
            return UserController.UserConnection(Login, Password);
        }
    }
}
