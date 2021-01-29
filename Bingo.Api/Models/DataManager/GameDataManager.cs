using Bingo.Api.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.DataManager
{
    public class GameDataManager : IGameRepository<GameDetails>
    {
        readonly sarathkatari07_BingoDBContext _bingoDBContext;
        public GameDataManager(sarathkatari07_BingoDBContext storeContext)
        {
            _bingoDBContext = storeContext;
        }

        public GameDetails Get(int id)
        {
            var currentgame = _bingoDBContext.GameDetails
                .SingleOrDefault(b => b.BoardId == id && b.Status == true);

            if (currentgame == null)
            {
                return null;
            }

            return currentgame;
        }

        public GameDetails Add(GameDetails entity)
        {
            _bingoDBContext.GameDetails.Add(entity);
            _bingoDBContext.SaveChanges();
            return entity;
        }

        public void Update(GameDetails entity)
        {
            _bingoDBContext.GameDetails.Update(entity);
            _bingoDBContext.SaveChanges();
        }

    }
}
