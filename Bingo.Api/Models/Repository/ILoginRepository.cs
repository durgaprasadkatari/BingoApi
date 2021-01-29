using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.Repository
{
    public interface ILoginRepository<TEntity>
    {
        TEntity Get(string username, string password);
        void Add(TEntity entity);
    }
}
