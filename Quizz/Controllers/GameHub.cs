using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizzNoGood.Models;

namespace QuizzNoGood.Controllers
{
    public class GameHub:Hub
    {
        public async Task AskForConnection(int idUser, string idGame)
        {
            var gc = WebContext.GetInstance().GameManager.GetGameById(idGame);
            var user = gc.Game.Users.FirstOrDefault(u => u.Id == idUser);

            //TODO que test
            user = gc.Game.Users.FirstOrDefault(u => u.ConnectionId == null);


            user.ConnectionId = Context.ConnectionId;

            string[] names = gc.Game.Users.Select(u => u.Username).ToArray();
            foreach (var gameUser in gc.Game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("UserConnected", names);
            }
        }

        public async Task StartGame(Game game)
        {
            string[] names = game.Users.Select(u => u.Username).ToArray();
            foreach (var gameUser in game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("GameStarted");
            }

        }

    }
}
