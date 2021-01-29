using System;
using System.Collections.Generic;

namespace Bingo.Api.Models
{
    public partial class GameDetails
    {
        public int GameId { get; set; }
        public int? BoardId { get; set; }
        public int? CurrentNumber { get; set; }
        public string Previousnumbers { get; set; }
        public decimal? TotalPrize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        public Guid? CoinCounterid { get; set; }
        public decimal? TicketPrice { get; set; }

        public virtual BingoBoard Board { get; set; }
    }
}
