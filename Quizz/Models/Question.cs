using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Models
{
    public class Question
    {
        public string Sentence { get; private set; } 
        public string Answer { get; private set; }
        public string False1 { get; private set; }
        /// <summary>
        /// Possibly null
        /// </summary>
        public string False2 { get; private set; }
        /// <summary>
        /// Possibly null
        /// </summary>
        public string False3 { get; private set; }
    
        public bool VerifyAnswer(string answer)
        {
            throw new NotImplementedException();
        }
    }
}
