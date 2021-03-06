using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using QuizzNoGood.Business;
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
            gc.ConnectUser(idUser, Context.ConnectionId);
        }

        public async Task AskQuestion(Game game, string question, List<string> choices)
        {
            foreach (var gameUser in game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("AskQuestion", question, choices.ToArray(), game.IsTimed);
            }
        }

        //Pour chaque user envoyer si la réponse est bonne et le score de toute le monde
        public async Task GiveAnswer(Game game, string answer, string msg)
        {
            foreach (var gameUser in game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("ReceiveAnswer", answer, game.ComputeScore(), gameUser.IsGoodAnswer, msg);
            }
        }
        
        public async Task EndGame(Game game, List<string> scores, string winner)
        {
            foreach (var gameUser in game.Users)
            {
                await Clients.Client(gameUser.ConnectionId).SendAsync("EndGame", scores.ToArray(), winner);
            }
        }

        public void AnswerQuestion(int userId, string gameId, string answer)
        {
            var game = WebContext.GetInstance().GameManager.GetGameById(gameId);
            game.AnswerQuestion(userId, answer);
        }
    }
}
