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
            UserId = userId;
        }

        public string GameId { get; set; }
        public int UserId { get; set; }

    }
}
