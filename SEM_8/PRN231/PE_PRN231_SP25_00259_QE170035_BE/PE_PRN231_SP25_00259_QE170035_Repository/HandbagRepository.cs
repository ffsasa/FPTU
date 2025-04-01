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
    public class HandbagRepository : GenericRepository<Handbag>
    {
        public HandbagRepository() { }
        public async Task<List<Handbag>> SearchAsync(string? Color, string? ModelName, string? Material)
        {
            return await _context.Handbags.
               Include(c => c.Brand)
               .Where(c => (string.IsNullOrEmpty(Color) || c.Color.Contains(Color)) &&
                   (string.IsNullOrEmpty(ModelName) || c.ModelName.Contains(ModelName)) &&
                   (string.IsNullOrEmpty(Material) || c.Material.Contains(Material))).
               GroupBy(g => new { g.Color, g.ModelName, g.Material })
               .Select(g => new Handbag
               {
                   HandbagId = g.FirstOrDefault().HandbagId,
                   BrandId = g.FirstOrDefault().BrandId,
                   Price = g.FirstOrDefault().Price,
                   Stock = g.FirstOrDefault().Stock,
                   ReleaseDate = g.FirstOrDefault().ReleaseDate,
                   ModelName = g.Key.ModelName,
                   Material = g.Key.Material,
                   Color = g.Key.Color,

               }).ToListAsync();
        }
    }
}
