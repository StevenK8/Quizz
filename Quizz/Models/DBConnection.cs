using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace QuizzNoGood.Models
{
    public class DBConnection : IDisposable
    {
        private const string CONNECTION_STRING = "Data Source=ryzen.ddns.net,3306; database=quizz;" +
                                                "User id=quizzuser; Password=EwYpTZXSgLeWzTHp38DdM4AwoAEHkYYepVaZLgn76bmLJY3FZY;";

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
                if (command.ExecuteNonQuery() != 1)
                    return false;
                return true;
                //using (Mysqlda reader = command.ExecuteReader())
                //{
                //    while (reader.Read())
                //    {
                //        Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                //    }
                //}
            }
        }


        public string SelectUser(User user)
        {
            string sql = $"SELECT id, username, password FROM users WHERE username = '{user.Username}'";
            return null;
        }

        public void Dispose()
        {
            _mySqlConnection.Close();
        }
    }
}
