using PE_PRN231_SP25_00259_QE170035_Repository;
using PE_PRN231_SP25_00259_QE170035_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_PRN231_SP25_00259_QE170035_Service
{
    public interface IHandbagService
    {
        Task<List<Handbag>> GetAll();
        Task<Handbag> GetById(int id);
        Task<int> Create(Handbag handbag);
        Task<int> Update(Handbag handbag);
        Task<bool> Delete(int id);
        Task<List<Handbag>> SearchAsync(string? Color, string? ModelName, string? Material);
    }

    public class HandbagService : IHandbagService
    {
        private readonly HandbagRepository _handbagRepository;
        public HandbagService()
        {
            _handbagRepository = new HandbagRepository();
        }

        public async Task<int> Create(Handbag handbag)
        {
            return await _handbagRepository.CreateAsync(handbag);
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _handbagRepository.GetByIdAsync(id);
            if (item != null)
            {
                return await _handbagRepository.RemoveAsync(item);
            }
            return false;
        }

        public async Task<List<Handbag>> GetAll()
        {
            return await _handbagRepository.GetAllAsync();
        }

        public async Task<Handbag> GetById(int id)
        {
            return await _handbagRepository.GetByIdAsync(id);
        }

        public async Task<List<Handbag>> SearchAsync(string? Color, string? ModelName, string? Material)
        {
            return await _handbagRepository.SearchAsync(Color, ModelName, Material);
        }

        public async Task<int> Update(Handbag handbag)
        {
            return await _handbagRepository.UpdateAsync(handbag);
        }
    }
}
