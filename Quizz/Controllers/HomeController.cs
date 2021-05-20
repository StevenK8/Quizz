using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QuizzNoGood.Business;
using QuizzNoGood.Models;
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

        public IActionResult Index(InscriptionViewModel inscription, int isInscription, ConnectionViewModel connection, int isConnection)
        {
#warning gérer les exceptions
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
                
            if (isConnection == 1)
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
            return View();
        }
        
        public IActionResult Profil()
        {
            return View();
        }
        
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

        public IActionResult GoToWaitingHub(string isJoin)
        {
            //TODO des tests ici
            bool isJoinb = Equals(isJoin, "true");

            string s = HttpContext.Session.GetString(USER);
            User u = JsonConvert.DeserializeObject<User>(s);

            if (u != null)
            {
                if (isJoinb)
                {
                    var id = Request.Form["idGame"].First();

                    WebContext.GetInstance().GameManager.RegisterUser(id, u);
                    return RedirectToAction("WaitingHub", new
                    {
                        gameId = id,
                        userId = 1,
                    });

                }
                else
                {
                    var id = WebContext.GetInstance().GameManager.CreateGame();
                    WebContext.GetInstance().GameManager.RegisterUser(id, new User(2, "test2", "blbllb"));
                    return RedirectToAction("WaitingHub", new
                    {
                        gameId = id,
                        userId = 2,
                    });
                }
            }
            else
            {
                return RedirectToAction("Connection", new { errorCode = 5 });
            }
            
        }

        public IActionResult WaitingHub(string gameId, int userId)
        {
            return View(new WaitingHubViewModel(gameId));
        }


        public IActionResult GameView(string gameId)
        {
            WebContext.GetInstance().GameManager.StartGame(gameId);
            return View();
        }
    }
}
