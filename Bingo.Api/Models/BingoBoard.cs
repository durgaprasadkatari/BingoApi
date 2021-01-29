using System;
using System.Collections.Generic;

namespace Bingo.Api.Models
{
    public partial class BingoBoard
    {
        public BingoBoard()
        {
            GameDetails = new HashSet<GameDetails>();
            Player = new HashSet<Player>();
        }

        public int BoardId { get; set; }
        public byte? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Guid? PrimaryPlayerid { get; set; }

        public virtual ICollection<GameDetails> GameDetails { get; set; }
        public virtual ICollection<Player> Player { get; set; }
    }
}
