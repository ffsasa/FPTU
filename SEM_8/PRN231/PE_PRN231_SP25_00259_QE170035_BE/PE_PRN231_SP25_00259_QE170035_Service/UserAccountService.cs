using PE_PRN231_SP25_00259_QE170035_Repository;
using PE_PRN231_SP25_00259_QE170035_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_PRN231_SP25_00259_QE170035_Service
{
    public class UserAccountService
    {
        private readonly UserAccountRepository _userAccountRepository;

        public UserAccountService()
        {
            _userAccountRepository = new UserAccountRepository();
        }

        public async Task<SystemAccount> Authenticate(string email, string password)
        {
            return await _userAccountRepository.GetUserAccount(email, password);
        }
    }
}
