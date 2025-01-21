using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StoreAccountService
    {
        private StoreAccountRepository repository = new StoreAccountRepository();

        public StoreAccount? GetStoreAccount(string email, string password)
        {
            return repository.GetStoreAccount(email, password);
        }
    }
}
