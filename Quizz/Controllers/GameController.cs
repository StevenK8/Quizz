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

        public HubConnection GameConnection { get; private set; }

        public GameController(Game game)
        {
            Game = game;
            Connect();
        }

        public void StartGame()
        {
            ListenControllerEvent();
            GameConnection.SendAsync("StartGame", Game);
        }

        private async void Connect()
        {
            try
            {
                string address = "";

#if DEBUG
                address = "http://localhost:53701/GameHub";
#else
                address = ""; // todo mettre l'adresse 
#endif

                GameConnection = new HubConnectionBuilder().WithUrl(address).Build();
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

        public void AskQuestion()
        {

        }

        public void AnswerQuestion(int userId, int answerId)
        {
            
        }
    }
}
