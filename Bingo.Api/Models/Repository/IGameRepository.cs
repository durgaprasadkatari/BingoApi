using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.Repository
{
    public interface IGameRepository<TEntity>
    {
        TEntity Get(int id);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
    }
}
