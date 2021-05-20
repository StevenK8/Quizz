using Microsoft.AspNetCore.Mvc;
using QuizzNoGood.Business;
using QuizzNoGood.Controllers;

namespace QuizzNoGood.Models
{
    public class ConnectionViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        [BindProperty(Name = "ErrorCode", SupportsGet = true)]
        public int ErrorCode { get; set; }

        public User Connect()
        {
            return UserController.UserConnection(Login, Password);
        }
    }
}
