using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Logging;

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
        public bool IsTimed { get; set; }

        public Game(string id, bool isTimed)
        {
            Id = id;
            Users = new HashSet<GameUserInfos>();
            QuestionAsked = new HashSet<Question>();
            QuestionPool = new HashSet<Question>();
            Difficulty = new List<int>(){1,2,3};
            IsTimed = isTimed;
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

        public void AddPointToUser(int userId, TimeSpan? elapsed)
        {
            var user = Users.FirstOrDefault(u => u.User.Id == userId);

            if (user != null)
            {
                if (IsTimed)
                {
                    double percentage = 1-elapsed.Value.Milliseconds / 3000.00;
                    int value = (int) (percentage * 100);
                    user.Score += value;
                }
                else
                {
                    user.Score += 100;
                }
                user.IsGoodAnswer = true;
            }
        }

        public bool AllUsersAnswered()
        {
            return Users.All(u => u.HasAnswered);
        }

        public string[] ComputeScore()
        {
            List<string> result = new List<string>();

            foreach (var user in Users.OrderByDescending(u => u.Score))
            {
                result.Add($"{user.User.Username} : {user.Score}");
            }

            return result.ToArray();
        }

        public string GetWinner()
        {
            return Users.OrderByDescending(u => u.Score).First().User.Username;
        }
    }
}
