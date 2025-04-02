using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<List<Survey>> SearchAsync(string? categoryName, int number, int veryGood)
        {
            return await _context.Surveys
                .Include(s => s.Category)
                .Where(s => (string.IsNullOrEmpty(categoryName) || s.Category.Name.Contains(categoryName)) &&
                            (number == 0 || s.Number == number) && // Giả sử Survey có thuộc tính Number
                            (veryGood == 0 || s.Verygood == veryGood)) // Giả sử Survey có thuộc tính VeryGood
                .GroupBy(s => new { s.Category.Name, s.Number, s.Verygood })
                .Select(g => new Survey // Giả sử bạn muốn trả về Survey, không phải CosmeticInformation
                {
                    CategoryId = g.FirstOrDefault().CategoryId,
                    Description = g.FirstOrDefault().Description,
                    PointAverage = g.FirstOrDefault().PointAverage,
                    Good = g.FirstOrDefault().Good,
                    Category = g.FirstOrDefault().Category,
                    Medium = g.FirstOrDefault().Medium,
                    Bad = g.FirstOrDefault().Bad,
                    VeryBad = g.FirstOrDefault().VeryBad,
                    CreateBy = g.FirstOrDefault().CreateBy,
                    CreateAt = g.FirstOrDefault().CreateAt,
                    UpdateAt = g.FirstOrDefault().UpdateAt,
                    Number = g.Key.Number,
                    Verygood = g.Key.Verygood
                })
                .ToListAsync();
        }
    }
}

