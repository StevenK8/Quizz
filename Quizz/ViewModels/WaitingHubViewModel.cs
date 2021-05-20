using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using QuizzNoGood.Controllers;

namespace QuizzNoGood.ViewModels
{
    public class WaitingHubViewModel
    {
        public WaitingHubViewModel(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
