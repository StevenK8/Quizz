using System.Collections.Generic;
using System.Linq;

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
            Users = new HashSet<GameUserInfos>();
        }

        public void RegisterUser(User user)
        {
            Users.Add(new GameUserInfos(user));
        }

        public void ConnectUser(int userId)
        {
            var user = Users.FirstOrDefault(u => u.User.Id == userId);

            if (user != null)
            {
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
    }
}
