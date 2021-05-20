using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace QuizzNoGood.Business
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
                    
            
            string sql = $"insert into users(username, password) values(@Name, '{user.CryptedPassword}')";
            
            using (MySqlCommand command = new (sql, _mySqlConnection))
            {
                command.Parameters.AddWithValue("@Name", user.Username);
                // command.Parameters.AddWithValue("@Password", user.CryptedPassword);
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

        public List<Theme> SelectThemes()
        {
            string sql = $"SELECT id, theme FROM themes";
            using (MySqlCommand command = new(sql, _mySqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    List<Theme> themeList = new List<Theme>();

                    if(reader.HasRows){
                        while(reader.Read()){
                            int id = int.TryParse(reader.GetString(0), out int k) ? k : 0;
                            string theme = reader.GetString(1);
                            themeList.Add(new Theme(id, theme));
                        }
                    }else{
                        return null;
                    }

                    return themeList;

                }
            }
        }



        public List<Question> SelectQuestions(List<int> theme, List<int> difficulty)
        {
            string themes = "";
            for (int i=0; i<theme.Count; i++){
                if (i!=theme.Count-1){
                    themes += theme[i]+",";
                }else{
                    themes += theme[i];
                }  
            }

            string difficulties = "";
            for (int i=0; i<difficulty.Count; i++){
                if (i!=difficulty.Count-1){
                    difficulties += difficulty[i]+",";
                }else{
                    difficulties += difficulty[i];
                }  
            }
            
            string sql = $"SELECT idt, question, answer, false1, false2, false3, difficulty FROM questions WHERE idt in ({themes}) and difficulty in ({difficulties}) ORDER BY RAND() LIMIT 20";
            

            using (MySqlCommand command = new(sql, _mySqlConnection))
            {
                using (var reader = command.ExecuteReader())
                {
                    List<Question> questionList = new List<Question>();
                   
                    if(reader.HasRows){
                        while(reader.Read()){
                            int id = int.TryParse(reader.GetString(0), out int k) ? k : 0;
                            string question = reader.GetString(1);
                            string answer = reader.GetString(2);
                            string false1 = reader.GetString(3);
                            string false2 = reader.GetString(4);
                            string false3 = reader.GetString(5);
                            string diff = reader.GetString(6);
                            questionList.Add(new Question(question,answer,false1,false2,diff));
                        }
                    }else{
                        return null;
                    }

                    return questionList;
                }
            }
        }

        public void Dispose()
        {
            _mySqlConnection.Close();
        }
    }
}
