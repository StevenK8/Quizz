using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizzNoGood.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using QuizzNoGood.ViewModels;

namespace QuizzNoGood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(InscriptionViewModel inscription, int isInscription)
        {
            if(isInscription == 1)
                inscription.CreateUserFormInscription();
            return View();
        }
        
        public IActionResult Profil()
        {
            return View();
        }
        
        public IActionResult Connection()
        {
            return View();
        }
        
        public IActionResult Inscription()
        {
            return View(new InscriptionViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult WaitingHub(string isJoin)
        {
            //TODO des tests ici
            bool isJoinb = Equals(isJoin, "true"); 
            if (isJoinb)
            {
                var id = Request.Form["idGame"].First();
                WebContext.GetInstance().GameManager.RegisterUser(id, new User(1,"test1","blbllb"));
                return View(new WaitingHubViewModel(id));

            }
            else
            {
                //HttpContext.Session.SetString("user","ze");
                var id = WebContext.GetInstance().GameManager.CreateGame();
                WebContext.GetInstance().GameManager.RegisterUser(id, new User(2, "test2", "blbllb"));
                return View(new WaitingHubViewModel(id));
            }
        }


        public IActionResult GameView(string gameId)
        {
            WebContext.GetInstance().GameManager.StartGame(gameId);
            return View();
        }
    }
}
