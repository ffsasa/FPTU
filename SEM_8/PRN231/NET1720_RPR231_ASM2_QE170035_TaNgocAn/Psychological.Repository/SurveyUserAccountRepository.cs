using Microsoft.EntityFrameworkCore;
using Psychological.Repository.Base;
using Psychological.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological.Repository
{
    public class SurveyUserAccountRepository : GenericRepository<UserAccount>
    {
        public SurveyUserAccountRepository() { }
        public async Task<UserAccount> GetUserAccount(string userName, string password)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(
                u => u.UserName == userName && 
                u.Password == password && 
                u.IsActive == true
                );
        }
    }
}
