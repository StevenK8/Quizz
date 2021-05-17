using System.Collections.Generic;

namespace QuizzNoGood.Models
{
    public class Game
    {
        public string Id { get; private set; }

        public Dictionary<User, int> ScoreByUser { get; set; }

        public HashSet<Question> QuestionAsked { get; set; }

        public Game(string id)
        {
            
        }

        public void RegisterUser(User user)
        {
            ScoreByUser.Add(user, 0);
        }
    }
}
