using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using QuizzNoGood.Models;

namespace QuizzNoGood.Controllers
{
    public class GameController
    {
        public Game Game { get; }

        private HubConnection GameConnection { get; set; }

        public GameController(Game game)
        {
            Game = game;
        }

        public void StartGame()
        {
            Connect();
            ListenControllerEvent();
        }

        private async void Connect()
        {
            try
            {
                GameConnection = new HubConnectionBuilder().WithUrl("http://localhost:53701/GameHub").Build();
                await GameConnection.StartAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void ListenControllerEvent()
        {

        }

        public void RegisterUser(User user)
        {
            Game.ScoreByUser.Add(user,0);
        }
    }
}
