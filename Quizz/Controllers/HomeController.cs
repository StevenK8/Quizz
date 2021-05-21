using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QuizzNoGood.Business;
using QuizzNoGood.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace QuizzNoGood.Controllers
{
    public class HomeController : Controller
    {
        public const string USER = "user";
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(InscriptionViewModel inscription, int isInscription, ConnectionViewModel connection, int isConnection, int isDeconnexion)
        {
            if (isInscription == 1)
            {
                (User u, int eCode) = inscription.CreateUserFormInscription();
                if (u is not null)
                {
                    string s = JsonConvert.SerializeObject(u);
                    HttpContext.Session.SetString(USER, s);

                }
                else
                {
                    return RedirectToAction("Inscription", new { errorCode = eCode });
                }
            }
                
            else if (isConnection == 1)
            {
                User u = connection.Connect();
                if (u is not null)
                {
                    string s = JsonConvert.SerializeObject(u);
                    HttpContext.Session.SetString(USER, s);
                }
                else
                {
                    return RedirectToAction("Connection", new { errorCode = 4 });
                }

            }

            else if (isDeconnexion == 1)
            {
                HttpContext.Session.Remove(USER);
            }

            var stringUser = HttpContext.Session.GetString(USER);
            Business.User user = null;
            if(stringUser is not null)
            {
                try
                {
                    user = JsonConvert.DeserializeObject<User>(stringUser);
                }
                catch (Exception e)
                {
                    //renvoyer une erreur
                }

                HttpContext.Session.SetString(USER, stringUser);
            }

            return View(new IndexViewModel() { IsConnected = user is not null});
        }
        
        //public IActionResult Profil()
        //{
        //    return View();
        //}
        
        public IActionResult Connection(int errorCode)
        {
            return View(new ConnectionViewModel() { ErrorCode = errorCode});
        }
        
        public IActionResult Inscription(int errorCode)
        {
            return View(new InscriptionViewModel() { ErrorCode = errorCode });
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

        public IActionResult GoToWaitingHub(IndexViewModel index, int isJoin, int isTimed, int isDeathMatch)
        {
            bool isJoinb = isJoin == 1;

            string s = HttpContext.Session.GetString(USER);
            if (s != null)
            {
                User u = JsonConvert.DeserializeObject<User>(s);
                if (u != null)
                {
                    if (isJoinb)
                    {
                        var id = index.GameId;
                        var game = WebContext.GetInstance().GameManager.GetGameById(id);

                        if (game == null || game.Game.IsRunning)
                        {
                            return RedirectToAction("Index");
                        }

                        WebContext.GetInstance().GameManager.RegisterUser(id, u);

                        HttpContext.Session.SetString(USER, s);
                        return RedirectToAction("WaitingHub", new
                        {
                            gameId = id,
                            userId = u.Id,
                        });

                    }
                    else
                    {   
                        var id = WebContext.GetInstance().GameManager.CreateGame(isTimed == 1, isDeathMatch == 1);
                        WebContext.GetInstance().GameManager.RegisterUser(id, u);

                        HttpContext.Session.SetString(USER, s);
                        return RedirectToAction("WaitingHub", new
                        {
                            gameId = id,
                            userId = u.Id,
                        });
                    }
                }
            }

            return RedirectToAction("Connection", new { errorCode = 5 });
        }

        public IActionResult WaitingHub(string gameId, int userId)
        {
            return View(new WaitingHubViewModel(gameId, userId));
        }


        public IActionResult GoToGameView(string gameId, int userId)
        {

            WebContext.GetInstance().GameManager.StartGame(gameId);

            return RedirectToAction("GameView", new
            {
                gameId = gameId,
                userId = userId
            });
        }

        public IActionResult GameView(string gameId, int userId)
        {
            return View();
        }
    }
}
