using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizzNoGood.Buisness;
using QuizzNoGood.Models;

namespace QuizzNoGood.Controllers
{
    public class GameHub:Hub
    {
        public async Task AskForConnection(int idUser, string idGame)
        {
            var gc = WebContext.GetInstance().GameManager.GetGameById(idGame);
            gc.SetUserConnectionId(idUser, Context.ConnectionId);

            string[] names = gc.Game.Users.Select(u => u.User.Username).ToArray();
            foreach (var gameUser in gc.Game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("UserConnected", names);
            }
        }

        public async Task StartGame(Game game)
        {
            string[] names = game.Users.Select(u => u.User.Username).ToArray();
            foreach (var gameUser in game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("GameStarted");
            }
        }

        public async Task UserConnectedToGame(int idUser, string idGame)
        {
            var gc = WebContext.GetInstance().GameManager.GetGameById(idGame);
            gc.ConnectUser(idUser);
        }

        public async Task AskQuestion(Game game, Question question)
        {
            foreach (var gameUser in game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("AskQuestion", question);
            }
        }

        public async Task AnswerQuestion(int userId, string gameId, string answer)
        {
            var game = WebContext.GetInstance().GameManager.GetGameById(gameId);
            game.AnswerQuestion(userId, answer);
        }
    }
}
