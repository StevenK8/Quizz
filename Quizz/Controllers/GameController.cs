using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR.Client;
using QuizzNoGood.Business;

namespace QuizzNoGood.Controllers
{
    public class GameController
    {
        private System.Timers.Timer Timer { get; set; }
        private Stopwatch Stopwatch { get; set; }

        public Game Game { get; }

        public HubConnection GameConnection { get; private set; }

        public GameController(Game game)
        {
            Game = game;
            Connect();
            Stopwatch = new Stopwatch();
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

            var questions = DB.SelectQuestions(themes.Select(t => t.Id).ToList(), Game.Difficulty);
            var result = questions.ToArray()[randomizer.Next(questions.Count)];
            Game.QuestionPool = questions.Take(10).ToHashSet();
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

            if (Game.IsTimed)
            {
                Timer = new System.Timers.Timer(30000);
                Timer.Elapsed += TimerOnElapsed;
                Timer.Enabled = true;
                Timer.AutoReset = false;

                if (Stopwatch.IsRunning)
                {
                    Stopwatch.Restart();
                }
                else
                {
                    Stopwatch.Start();
                }
            }
            else if (Game.IsDeathMatch)
            {

            }
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            GiveAnswer();
        }

        private async void GiveAnswer()
        {
            var question = Game.CurrentQuestion;
            string msg = null;
            if (Game.IsDeathMatch)
            {
                msg = $"{Game.GetWinner()} as won";
            }
            await GameConnection.SendAsync("GiveAnswer", Game, Game.CurrentQuestion.Answer, msg );
            Game.CurrentQuestion = null;
            Game.ResetUsersHasAnswered();
            AskQuestionOrEndGame(question.Answer);
        }

        public void AnswerQuestion(int userId, string answer)
        {
            TimeSpan? elapsed = null;
            if (Game.IsTimed)
            {
                elapsed = Stopwatch.Elapsed;
            }
                
            Game.SetUserHasAnswered(userId);
            bool deathMatchEnd = false;
            if (Equals(Game.CurrentQuestion.Answer, answer))
            {
                Game.AddPointToUser(userId, elapsed);
                if (Game.IsDeathMatch)
                {
                    deathMatchEnd = true;
                }
            }

            if (Game.IsTimed)
            {
                Timer.Enabled = false;
                Timer.Stop();
                Timer.Close();
            }
            if (deathMatchEnd || Game.AllUsersAnswered())
            {
                AskQuestionOrEndGame(Game.CurrentQuestion.Answer);
            }
        }

        private async void AskQuestionOrEndGame(string answer)
        {
            //En faire une fonction
            await Task.Run(async () =>
            {
                await GameConnection.SendAsync("GiveAnswer", Game, answer);

                Thread.Sleep(3000);
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

        private async void EndGame()
        {
            await Task.Run(async () =>
            {
                await GameConnection.SendAsync("EndGame", Game, Game.ComputeScore(), Game.GetWinner());

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
