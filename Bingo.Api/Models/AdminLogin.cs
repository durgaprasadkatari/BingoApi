using System;
using System.Collections.Generic;

namespace Bingo.Api.Models
{
    public partial class AdminLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid? Playerid { get; set; }
    }
}
