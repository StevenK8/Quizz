using System;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Models
{
    public class User
    {
        private const int SALT_NUMBER = 10;

        public int Id { get; set; }
        public string Username { get; private set; }
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
        public bool VerifyPassword(string psw)
        {
            return BCrypt.Net.BCrypt.Verify(psw, CryptedPassword);
        }
    }
}
