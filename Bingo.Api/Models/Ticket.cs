using System;
using System.Collections.Generic;

namespace Bingo.Api.Models
{
    public partial class Ticket
    {
        public Guid Ticketid { get; set; }
        public decimal? TicketPrice { get; set; }
        public Guid? Playerid { get; set; }
        public string TicketPath { get; set; }
        public int? NoOfTickets { get; set; }
        public int? Gameid { get; set; }
        public string TicketContent { get; set; }
    }
}
