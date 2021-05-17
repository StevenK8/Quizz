using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizzNoGood.Controllers;

namespace QuizzNoGood.Models
{
    public class WebContext
    {
        private static WebContext _instance;

        public GameManager GameManager { get; }

        private WebContext()
        {
            GameManager = new GameManager();
        }

        public static WebContext GetInstance()
        {
            if(_instance == null)
            {
                _instance = new WebContext();
            }

            return _instance;
        }
    }
}
