using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserAccountService
    {
        private UserAccountRepository UserAccountRepository = new UserAccountRepository();
        public UserAccount? GetUserAccounts (string email, string password)
        {
            return UserAccountRepository.GetUserAccounts(email, password);
        }
    }
}
