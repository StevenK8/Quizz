using System;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ganss.XSS;

namespace QuizzNoGood.Buisness
{
    public class User
    {
        private const int SALT_NUMBER = 10;

        public int Id { get; set; }
        private string _username;
        public string Username {
            get => _username;
            private set
            {
#warning TODO
                var sanitizer = new HtmlSanitizer();
                _username = sanitizer.Sanitize(value);
            }
        }
        public string CryptedPassword { get; set; }

        /// <summary>
        /// Create a User, used only with an already crypted password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="cryptedPassword"></param>
        public User(int id, string username, string cryptedPassword)
        {
            Id = id;
            Username = username;
            CryptedPassword = cryptedPassword;
        }
        /// <summary>
        /// Create a User, used only with an already crypted password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="cryptedPassword"></param>
        public User(string username, string cryptedPassword)
        {
            Username = username;
            CryptedPassword = cryptedPassword;
        }


        /// <summary>
        /// Create a user and crypt the password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="notCryptedPassword"></param>
        /// <returns></returns>
        public static User CreateNewUser(int id, string username, string notCryptedPassword)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(SALT_NUMBER);
            return new User(id, username, BCrypt.Net.BCrypt.HashPassword(notCryptedPassword, salt));
        }

        /// <summary>
        /// Create a user and crypt the password
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="notCryptedPassword"></param>
        /// <returns></returns>
        public static User CreateNewUser(string username, string notCryptedPassword)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(SALT_NUMBER);
            return new User(username, BCrypt.Net.BCrypt.HashPassword(notCryptedPassword, salt));
        }

        public bool VerifyPassword(string psw)
        {
            return BCrypt.Net.BCrypt.Verify(psw, CryptedPassword);
        }


    }
}
