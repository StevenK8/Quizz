using Microsoft.AspNetCore.Mvc;
using QuizzNoGood.Business;
using QuizzNoGood.Controllers;

namespace QuizzNoGood.Models
{
    public class InscriptionViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
        [BindProperty(Name = "ErrorCode", SupportsGet = true)]
        public int ErrorCode { get; set; }

        public (User u, int errorCode) CreateUserFormInscription()
        {
            var (errorCode, user) = UserController.UserInscription(Login, Password, RepeatedPassword);
            return (user, errorCode);
            
        }
    }
}
