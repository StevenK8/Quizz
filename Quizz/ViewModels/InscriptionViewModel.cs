using QuizzNoGood.Controllers;
using QuizzNoGood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.ViewModels
{
    public class InscriptionViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }

        public User CreateUserFormInscription()
        {
            var (success, message, user) = UserController.UserInscription(Login, Password, RepeatedPassword);
            if (success)
                return user;
            return null;
        }
    }
}
