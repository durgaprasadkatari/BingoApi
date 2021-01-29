using Bingo.Api.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.DataManager
{
    public class PlayerDataManager : IPlayerRepository<Player>
    {
        readonly sarathkatari07_BingoDBContext _bingoDBContext;
        public PlayerDataManager(sarathkatari07_BingoDBContext storeContext)
        {
            _bingoDBContext = storeContext;
        }

        public IEnumerable<Player> GetAll(int boardid)
        {
            var players = _bingoDBContext.Player.Where(player => player.Boardid == boardid).ToList();

            return players;
        }

        public Player Get(Guid id)
        {
            var player = _bingoDBContext.Player
                .SingleOrDefault(b => b.Playerid == id);

            if (player == null)
            {
                return null;
            }

            return player;
        }

        public Guid Add(Player entity)
        {
            entity.Playerid = Guid.NewGuid();
            _bingoDBContext.Player.Add(entity);
            _bingoDBContext.SaveChanges();
            return entity.Playerid;
        }
    }
}
