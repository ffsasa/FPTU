using Psychological.Repository;
using Psychological.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological.Service
{
    public interface ISurveyService
    {
        Task<List<Survey>> GetAll();
        Task<Survey> GetById(int id);
        Task<int> Create(Survey survey);
        Task<int> Update(Survey survey);
        Task<bool> Delete(int id);
        Task<List<Survey>> SearchAsync(string Name, int Number, int Verygood);
    }

    public class SurveyService : ISurveyService
    {
        private readonly SurveyRepository _surveyRepository;
        public SurveyService()
        {
            _surveyRepository = new SurveyRepository();
        }

        public async Task<int> Create(Survey survey)
        {
            return await _surveyRepository.CreateAsync(survey);
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _surveyRepository.GetByIdAsync(id);
            if (item != null)
            {
                return await _surveyRepository.RemoveAsync(item);
            }
            return false;
        }

        public async Task<List<Survey>> GetAll()
        {
            return await _surveyRepository.GetAllAsync();
        }

        public async Task<Survey> GetById(int id)
        {
            return await _surveyRepository.GetByIdAsync(id);
        }

        public async Task<List<Survey>> SearchAsync(string Name, int Number, int Verygood)
        {
            return await _surveyRepository.SearchAsync(Name, Number, Verygood);
        }

        public async Task<int> Update(Survey survey)
        {
            return await _surveyRepository.UpdateAsync(survey);
        }
    }
}
