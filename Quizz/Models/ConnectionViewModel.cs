using QuizzNoGood.Business;
using QuizzNoGood.Controllers;

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
