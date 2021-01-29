using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.Repository
{
    public interface ITicketRepository<TEntity>
    {
        TEntity Get(Guid id);
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> GetExistingTicket(Guid? playerid, int? gameid);
    }
}
