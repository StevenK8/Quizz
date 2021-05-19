using System.Collections.Generic;

namespace QuizzNoGood.Models
{
    public class Game
    {
        public string Id { get; private set; }
        
        public HashSet<GameUserInfos> Users { get; set; }

        public HashSet<Question> QuestionAsked { get; set; }

        public Game(string id)
        {
            Id = id;
            //ScoreByUser = new Dictionary<User, int>();
            Users = new HashSet<GameUserInfos>();
        }

        public void RegisterUser(User user)
        {
            Users.Add(new GameUserInfos(user));
        }
    }
}
