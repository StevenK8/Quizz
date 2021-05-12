using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Models
{
    public class Game
    {
        public string Id { get; private set; }

        public Dictionary<User,int> ScoreByUser { get; set; }

        public HashSet<Question> QuestionAsked { get; set; }
        
    }
}
