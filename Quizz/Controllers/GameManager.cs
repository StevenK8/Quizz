using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizzNoGood.Models;

namespace QuizzNoGood.Controllers
{
    public class GameManager
    {
        public HashSet<GameController> Games { get; set; }

        public GameManager()
        {
            Games = new HashSet<GameController>();
        }

        public Game CreateGame()
        {
            string id = GenerateUnregisteredRandomId();
            Game game = new Game(id);
            GameController gc = new GameController(game);
            Games.Add(gc);
            return game;
        }

        public void RegisterUser(string gameId, User user)
        {
            var game = Games.FirstOrDefault(g => Equals(g.Game.Id, gameId));
            game?.RegisterUser(user);
        }

        public void StartGame(string gameId)
        {
            var game = Games.FirstOrDefault(g => Equals(g.Game.Id, gameId));
            game?.StartGame();
        }

        public void EndGame()
        {

        }

        private string GenerateUnregisteredRandomId()
        {
            string generatedId;
            do
            {
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                generatedId = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            } while (Games.Any(g => Equals(g.Game.Id, generatedId)));

            return generatedId;
        }
    }
}
