using Psychological.Repository;
using Psychological.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological.Service
{
    public class SurveyUserAccountService
    {
        private readonly SurveyUserAccountRepository _surveyUserAccountRepository;

        public SurveyUserAccountService()
        {
            _surveyUserAccountRepository = new SurveyUserAccountRepository();
        }

        public async Task<UserAccount> Authenticate(string userName, string password)
        {
            return await _surveyUserAccountRepository.GetUserAccount(userName, password);
        }
    }
}
