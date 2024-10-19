using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository
    {
        ConvenienceStoreDbContext dbContext;
        public List<Product> GetProducts()
        {
            dbContext = new ConvenienceStoreDbContext();
            return dbContext.Products.ToList();
        }

        public void AddProduct(Product product)
        {
            dbContext = new ConvenienceStoreDbContext();
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            dbContext = new ConvenienceStoreDbContext();
            dbContext.Products.Update(product);
            dbContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            dbContext = new ConvenienceStoreDbContext();
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
        }
    }
}
