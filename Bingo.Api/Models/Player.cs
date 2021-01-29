using System;
using System.Collections.Generic;

namespace Bingo.Api.Models
{
    public partial class Player
    {
        public Guid Playerid { get; set; }
        public string PlayerName { get; set; }
        public int? Boardid { get; set; }

        public virtual BingoBoard Board { get; set; }
    }
}
