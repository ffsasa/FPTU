using Psychological.Repository;
using Psychological.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological.Service
{
    public interface ISurveyUserAccountService
    {
        public Task<UserAccount?> Authenticate(string userName, string password);
        Task<UserAccount> GetById(int id);
        Task<int> Create(UserAccount userAccount);
        Task<int> Update(UserAccount userAccount);
        Task<bool> Delete(int id);
        Task<List<UserAccount>> GetAll();
    }

    public class SurveyUserAccountService : ISurveyUserAccountService
    {
        private readonly SurveyUserAccountRepository _surveyUserAccountRepository;

        public SurveyUserAccountService()
        {
            _surveyUserAccountRepository = new SurveyUserAccountRepository();
        }

        public async Task<UserAccount?> Authenticate(string userName, string password)
        {
            return await _surveyUserAccountRepository.GetUserAccount(userName, password);
        }

        public async Task<int> Create(UserAccount userAccount)
        {
            return await _surveyUserAccountRepository.CreateAsync(userAccount);
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _surveyUserAccountRepository.GetByIdAsync(id);
            if (item != null)
            {
                return await _surveyUserAccountRepository.RemoveAsync(item);
            }
            return false;
        }

        public async Task<List<UserAccount>> GetAll()
        {
            return await _surveyUserAccountRepository.GetAllAsync();
        }

        public async Task<UserAccount> GetById(int id)
        {
            return await _surveyUserAccountRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(UserAccount userAccount)
        {
            return await _surveyUserAccountRepository.UpdateAsync(userAccount);
        }
    }
}
