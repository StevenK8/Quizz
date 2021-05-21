using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using QuizzNoGood.Business;
using QuizzNoGood.Controllers;

namespace QuizzNoGood.Models
{
    public class WaitingHubViewModel
    {
        public WaitingHubViewModel(string gameId, int userId)
        {
            GameId = gameId;
            UserId = UserId;
        }

        public string GameId { get; }
        public int UserId { get; }

    }
}
