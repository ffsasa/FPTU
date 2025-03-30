using Psychological.Repository;
using Psychological.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological.Service
{
    public interface ISurveyCategoryService
    {
        Task<List<ServeyCategory>> GetAll();
        Task<ServeyCategory> GetById(int id);
        Task<int> Create(ServeyCategory serveyCategory);
        Task<int> Update(ServeyCategory serveyCategory);
        Task<bool> Delete(int id);
    }

    public class SurveyCategoryService : ISurveyCategoryService
    {
        private SurveyCategoryRepository _surveyCategoryRepository;

        public SurveyCategoryService ()
        {
            _surveyCategoryRepository = new SurveyCategoryRepository();
        }

        public async Task<int> Create(ServeyCategory serveyCategory)
        {
            return await _surveyCategoryRepository.CreateAsync(serveyCategory);
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _surveyCategoryRepository.GetByIdAsync(id);
            if (item != null)
            {
                return await _surveyCategoryRepository.RemoveAsync(item);
            }
            return false;
        }

        public async Task<List<ServeyCategory>> GetAll()
        {
            return await _surveyCategoryRepository.GetAllAsync();
        }

        public async Task<ServeyCategory> GetById(int id)
        {
            return await _surveyCategoryRepository.GetByIdAsync(id);
        }

        public async Task<int> Update(ServeyCategory serveyCategory)
        {
            return await _surveyCategoryRepository.UpdateAsync(serveyCategory);
        }
    }
}
