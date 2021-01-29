using Bingo.Api.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.DataManager
{
    public class BingoBoardDataManager : IDataRepository<BingoBoard>
    {
        readonly sarathkatari07_BingoDBContext _bingoDBContext;
        public BingoBoardDataManager(sarathkatari07_BingoDBContext storeContext)
        {
            _bingoDBContext = storeContext;
        }

        public IEnumerable<BingoBoard> GetAll()
        {
            return _bingoDBContext.BingoBoard
                .Include(board => board.Player)
                .ToList();
        }

        public BingoBoard Get(long id)
        {
            var board = _bingoDBContext.BingoBoard
                .SingleOrDefault(b => b.BoardId == id);

            if (board == null)
            {
                return null;
            }

            _bingoDBContext.Entry(board)
                .Collection(b => b.Player)
                .Load();
            _bingoDBContext.Entry(board)
                .Collection(b => b.GameDetails).Query().Where(g => g.Status == true)
                .Load();

            return board;
        }

        public int Add(BingoBoard entity)
        {
            _bingoDBContext.BingoBoard.Add(entity);
            _bingoDBContext.SaveChanges();
            return entity.BoardId;
        }

        public void Update(BingoBoard entityToUpdate, BingoBoard entity)
        {
            entityToUpdate.PrimaryPlayerid = entity.PrimaryPlayerid;
            _bingoDBContext.BingoBoard.Update(entityToUpdate);
            _bingoDBContext.SaveChanges();
        }

        public void Delete(BingoBoard entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
