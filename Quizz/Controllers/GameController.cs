using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Client;
using QuizzNoGood.Buisness;
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

        private void ListenControllerEvent()
        {

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


        public void AskQuestion()
        {
            if (Game.CurrentQuestion != null)
            {
                Game.QuestionAsked.Add(Game.CurrentQuestion);
            }

            Game.ResetUsersHasAnswered();

            Random randomizer = new Random();
            Question question = Game.QuestionPool.ToArray()[randomizer.Next(Game.QuestionPool.Count)];

            Game.QuestionPool.Remove(question);
            Game.CurrentQuestion = question;

            List<string> randomisedAnswers = ShuffleAnswers(question);
            GameConnection.SendAsync("AskQuestion", question.Sentence, randomisedAnswers);
        }

        public async void AnswerQuestion(int userId, string answer)
        {
            Game.SetUserHasAnswered(userId);
            if (Equals(Game.CurrentQuestion.Answer, answer))
            {
                Game.AddPointToUser(userId);
            }

            if (Game.AllUsersAnswered())
            {
                await Task.Run(async () =>
                {
                    await GameConnection.SendAsync("GiveAnswer", Game, Game.CurrentQuestion.Answer);

                    Thread.Sleep(5000);
                });

                if (Game.QuestionPool.Count == 0)
                {
                    //EndGame();
                }
                else
                {
                    AskQuestion();
                }
            }
        }

        public void ConnectUser(int idUser)
        {
            Game.ConnectUser(idUser);
            if (Game.AllUserConnected())
            {
                AskQuestion();
            }
        }

        public void SetUserConnectionId(int idUser, string contextConnectionId)
        {
            Game.SetUserConnectionId(idUser, contextConnectionId);
        }

        private List<string> ShuffleAnswers(Question question)
        {
            List<string> questions = new List<string>
            {
                question.Answer, question.False1, question.False2, question.False3
            };


            Random rng = new Random();

            int n = questions.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = questions[k];
                questions[k] = questions[n];
                questions[n] = value;
            }

            return questions;
        }
    }
}
