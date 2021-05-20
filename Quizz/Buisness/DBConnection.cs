using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace QuizzNoGood.Buisness
{
    public class DBConnection : IDisposable
    {
        private const string CONNECTION_STRING = "Data Source=ryzen.ddns.net,3306; database=quizz;" +
                                                "User id=quizzuser; Password=EwYpTZXSgLeWzTHp38DdM4AwoAEHkYYepVaZLgn76bmLJY3FZY;";
        private const char SEPARATOR = ' ';

        private readonly MySqlConnection _mySqlConnection = new MySqlConnection(CONNECTION_STRING);
        public bool IsConnected { get; set; } = false;

        public DBConnection()
        {
            IsConnected = Connect();
        }

        public bool Connect()
        {
            try
            {
                _mySqlConnection.Open();
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Insert User in database, if user with the same username exist return false.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(User user)
        {
            if (!IsConnected)
                if (!Connect())
                    throw new Exception("Unable to connect to Database");

            string sql = $"insert into users(username, password) values('{user.Username}', '{user.CryptedPassword}')";

            using (MySqlCommand command = new (sql, _mySqlConnection))
            {
                try
                {
                    if (command.ExecuteNonQuery() != 1)
                        return false;
                    return true;
                }
                catch
                {
                    return false;
                }
                
                
            }
        }


        public User SelectUser(string username)
        {
            string sql = $"SELECT id, username, password FROM users WHERE username = '{username}'";
            using (MySqlCommand command = new(sql, _mySqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read()) //username c'est la clé donc un seul resultat
                        return null;
                    int id = int.TryParse(reader.GetString(0), out int k) ? k : 0;
                    string uname = reader.GetString(1);
                    string psw = reader.GetString(2);
                    return new User(id, uname, psw);
                }
            }
        }

        public void Dispose()
        {
            _mySqlConnection.Close();
        }
    }
}
