using Psychological.Repository;
using Psychological.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological.Service
{
    public class SurveyCategoryService
    {
        private SurveyCategoryRepository _surveyCategoryRepository;

        public SurveyCategoryService ()
        {
            _surveyCategoryRepository = new SurveyCategoryRepository();
        }

        public async Task<List<ServeyCategory>> GetAll()
        {
            return await _surveyCategoryRepository.GetAllAsync();
        }
    }
}
