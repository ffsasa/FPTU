using PE_PRN231_SP25_00259_QE170035_Repository;
using PE_PRN231_SP25_00259_QE170035_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_PRN231_SP25_00259_QE170035_Service
{
    public interface IBrandService
    {
        Task<List<Brand>> GetAll();
        Task<Brand> GetById(int id);
    }

    public class BrandService : IBrandService
    {
        private BrandRepository _brandRepository;

        public BrandService()
        {
            _brandRepository = new BrandRepository();
        }

        public async Task<List<Brand>> GetAll()
        {
            return await _brandRepository.GetAllAsync();
        }

        public async Task<Brand> GetById(int id)
        {
            return await _brandRepository.GetByIdAsync(id);
        }
    }
}
