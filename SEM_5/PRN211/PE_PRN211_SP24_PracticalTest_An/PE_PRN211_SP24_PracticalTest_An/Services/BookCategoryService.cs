using Repositories.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookCategoryService
    {
        private BookCategoryRepository repository = new BookCategoryRepository();
        public List<BookCategory> GetBookCategories()
        {
            return repository.GetBookCategories();
        }
    }
}
