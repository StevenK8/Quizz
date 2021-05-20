﻿using QuizzNoGood.Business;
using QuizzNoGood.Controllers;

namespace QuizzNoGood.Models
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