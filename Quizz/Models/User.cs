using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; private set; }
        public string CryptedPassword { get; set; }
        
        public User()
        {

        }

        public bool VerifyPassword()
        {
            throw new NotImplementedException();
        }
    }
}
