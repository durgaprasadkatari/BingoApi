using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.Repository
{
    public interface IPlayerRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll(int boardid);
        TEntity Get(Guid id);
        Guid Add(TEntity entity);
    }
}
