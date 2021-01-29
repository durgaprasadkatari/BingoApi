using Bingo.Api.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bingo.Api.Models.DataManager
{
    public class LoginDataManager : ILoginRepository<AdminLogin>
    {
        readonly sarathkatari07_BingoDBContext _bingoDBContext;
        public LoginDataManager(sarathkatari07_BingoDBContext storeContext)
        {
            _bingoDBContext = storeContext;
        }

        public IEnumerable<AdminLogin> GetAll()
        {
            return _bingoDBContext.AdminLogin
                .Include(board => board.Username)
                .ToList();
        }

        public AdminLogin Get(string username,string password)
        {
            var login = _bingoDBContext.AdminLogin
                .SingleOrDefault(b => b.Username == username && b.Password== password);

            if (login == null)
            {
                return null;
            }

            return login;
        }

        public void Add(AdminLogin entity)
        {
            _bingoDBContext.AdminLogin.Add(entity);
            _bingoDBContext.SaveChanges();
        }

        public void Update(AdminLogin entityToUpdate, AdminLogin entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(AdminLogin entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
