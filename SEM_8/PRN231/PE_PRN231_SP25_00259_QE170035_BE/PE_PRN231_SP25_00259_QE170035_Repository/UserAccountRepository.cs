using Microsoft.EntityFrameworkCore;
using PE_PRN231_SP25_00259_QE170035_Repository.Base;
using PE_PRN231_SP25_00259_QE170035_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_PRN231_SP25_00259_QE170035_Repository
{
    public class UserAccountRepository : GenericRepository<SystemAccount>
    {
        public UserAccountRepository() { }
        public async Task<SystemAccount> GetUserAccount(string email, string password)
        {
            return await _context.SystemAccounts.FirstOrDefaultAsync(
                u => u.Email == email &&
                u.Password == password &&
                u.IsActive == true
                );
        }
    }
}
