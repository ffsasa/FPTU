using Microsoft.EntityFrameworkCore;
using Psychological.Repository.Base;
using Psychological.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychological.Repository
{
    public class SurveyRepository : GenericRepository<Survey>
    {
        public SurveyRepository() { }


        public async Task<List<Survey>> SearchAsync(string Name, int Number, int Verygood)
        {
            return await _context.Surveys
                .Include(u => u.Category)
                .Where(u => u.Category.Name == Name &&
                            u.Number >= Number && 
                            u.Verygood >= Verygood)
                .ToListAsync();
        }
    }
}
