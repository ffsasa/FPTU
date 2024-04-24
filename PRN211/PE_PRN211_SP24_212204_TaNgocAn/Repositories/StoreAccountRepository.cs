using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StoreAccountRepository
    {
        ConvenienceStoreDbContext dbContext;

        public StoreAccount? GetStoreAccount(string email, string password)
        {
            dbContext = new ConvenienceStoreDbContext();
            return dbContext.StoreAccounts.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
