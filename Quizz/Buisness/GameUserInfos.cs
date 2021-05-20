using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Buisness
{
    public class GameUserInfos
    {
        public GameUserInfos(User user)
        {
            User = user;
            HasAnswered = false;
            Score = 0;
        }

        public User User { get; }

        public bool IsConnected { get; set; }

        public int Score { get; set; }

        public string ConnectionId { get; set; }

        public bool HasAnswered { get; set; }
    }
}
