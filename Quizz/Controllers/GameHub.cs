using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace QuizzNoGood.Controllers
{
    public class GameHub:Hub
    {
        public async Task TestConnexion()
        {
            await Clients.Caller.SendAsync("TestConnexion");
        }
    }
}
