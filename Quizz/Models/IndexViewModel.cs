using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizzNoGood.Models
{
    public class IndexViewModel
    {
        [BindProperty(Name = "GameId", SupportsGet = true)]
        public string GameId { get; set; }
        public bool IsConnected { get; set; } = false;

    }
}
