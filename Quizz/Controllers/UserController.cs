using QuizzNoGood.Business;

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

        public static (int errorCode, User user) UserInscription(string username, string password, string repeatedPassword)
        {
            DBConnection DB = new DBConnection();
            if (password != repeatedPassword)
                return (1, null);
            var u = User.CreateNewUser(username, password);
            if(!DB.InsertUser(u))
                return (2, null);

            return (3, DB.SelectUser(username));
        }
       
    }
}
