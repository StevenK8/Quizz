using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AngleSharp.Dom;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR.Client;
using QuizzNoGood.Business;
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
            LoadQuestions();
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

        private void LoadQuestions()
        {
            Random randomizer = new Random();
            DBConnection DB = new DBConnection();
            var themes = DB.SelectThemes();
            if (themes is not null)
            {
                List<Theme> themesForQuiz = new List<Theme>();
                themesForQuiz.Add(themes.ToArray()[randomizer.Next(themes.Count)]);
                themesForQuiz.Add(themes.ToArray()[randomizer.Next(themes.Count)]);
                themesForQuiz.Add(themes.ToArray()[randomizer.Next(themes.Count)]);

                var questions = DB.SelectQuestions(themesForQuiz.Select(t => t.Id).ToList(), Game.Difficulty);
                Game.QuestionPool = questions.ToHashSet();
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

            GameConnection.SendAsync("AskQuestion", Game, question.Sentence, randomisedAnswers);
            //Create timer
            //Quand fin GiveAnswer à créer
            //await GameConnection.SendAsync("GiveAnswer", Game, Game.CurrentQuestion.Answer);
            //set to null
            //appeler Game.ResetUsermachin
            //Appeler la nouvelle fonction

            //Lancer stopwatch global au Gamecontroler
            //GameUserInfo rajouter propriete Time span pour le temps mis a répondre
            //Stop à la réponse
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
                //En faire une fonction
                await Task.Run(async () =>
                {
                    await GameConnection.SendAsync("GiveAnswer", Game, Game.CurrentQuestion.Answer);

                    Thread.Sleep(5000);
                });

                if (Game.QuestionPool.Count == 0)
                {
                    EndGame();
                }
                else
                {
                    AskQuestion();
                }
            }
        }

        private async void EndGame()
        {
            await Task.Run(async () =>
            {
                await GameConnection.SendAsync("EndGame", Game);

                Thread.Sleep(5000);

                await GameConnection.SendAsync("DisplayScores", Game);
            });
        }

        public void ConnectUser(int idUser, string connectionId)
        {
            Game.ConnectUser(idUser, connectionId);
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
