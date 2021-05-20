using System.Collections.Generic;
using System.Linq;

namespace QuizzNoGood.Business
{
    public class Game
    {
        public string Id { get; private set; }
        
        public HashSet<GameUserInfos> Users { get; set; }

        public HashSet<Question> QuestionAsked { get; set; }
        public HashSet<Question> QuestionPool { get; set; }
        public Question CurrentQuestion { get; set; }
        public List<int> Difficulty { get; set; }

        public Game(string id)
        {
            Id = id;
            Users = new HashSet<GameUserInfos>();
            QuestionAsked = new HashSet<Question>();
            QuestionPool = new HashSet<Question>();
            Difficulty = new List<int>(){1,2,3};
        }

        public void RegisterUser(User user)
        {
            Users.Add(new GameUserInfos(user));
        }

        public void ConnectUser(int userId, string connectionId)
        {
            var user = Users.FirstOrDefault(u => u.User.Id == userId);

            if (user != null)
            {
                user.ConnectionId = connectionId;
                user.IsConnected = true;
            }
        }

        public void SetUserConnectionId(int idUser, string contextConnectionId)
        {
            var user = Users.FirstOrDefault(u => u.User.Id == idUser);

            if (user != null)
            {
                user.ConnectionId = contextConnectionId;
            }
        }

        public bool AllUserConnected()
        {
            return Users.All(u => u.IsConnected);
        }

        public void SetUserHasAnswered(int userId)
        {
            var user = Users.FirstOrDefault(u => u.User.Id == userId);

            if (user != null)
            {
                user.HasAnswered = true;
            }
        }

        public void ResetUsersHasAnswered()
        {
            foreach (var user in Users)
            {
                user.HasAnswered = false;
            }
        }

        public void AddPointToUser(int userId)
        {
            var user = Users.FirstOrDefault(u => u.User.Id == userId);

            if (user != null)
            {
                user.Score += 1;
            }
        }

        public bool AllUsersAnswered()
        {
            return Users.All(u => u.HasAnswered);
        }
    }
}
