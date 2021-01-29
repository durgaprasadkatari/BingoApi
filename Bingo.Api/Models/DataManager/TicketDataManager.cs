using Bingo.Api.Models.Repository;
using Bingo.Api.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bingo.Api.Models.DataManager
{
    public class TicketDataManager : ITicketRepository<Ticket>
    {
        readonly sarathkatari07_BingoDBContext _bingoDBContext;
        public TicketDataManager(sarathkatari07_BingoDBContext storeContext)
        {
            _bingoDBContext = storeContext;
        }
        public Ticket Get(Guid id)
        {
            var ticket = _bingoDBContext.Ticket
                .SingleOrDefault(b => b.Ticketid == id);

            if (ticket == null)
            {
                return null;
            }

            return ticket;
        }

        public Ticket Add(Ticket entity)
        {
            entity.Ticketid = Guid.NewGuid();
            string strHTML = string.Empty;
            
            for (int i = 0; i < entity.NoOfTickets; i++)
            {
                Thread.Sleep(1000);
                strHTML += "&nbsp;&nbsp";
                int[,] ticket = new int[3, 9];
                ticket = TicketGenerator.GenerateTicket(ticket);
                strHTML += TicketGenerator.PrintTicket(ticket);
            }
            entity.TicketContent = strHTML;
            _bingoDBContext.Ticket.Add(entity);
            _bingoDBContext.SaveChanges();
            return entity;
        }

        public IEnumerable<Ticket> GetExistingTicket(Guid? playerid, int? gameid)
        {
            var existingticket = _bingoDBContext.Ticket.Where(b => b.Playerid == playerid && b.Gameid == gameid).ToList();
            return existingticket;
        }

    }
}
