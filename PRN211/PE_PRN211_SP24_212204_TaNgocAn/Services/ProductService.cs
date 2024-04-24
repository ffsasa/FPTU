using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService
    {
        private ProductRepository repository = new ProductRepository();

        public List<Product> GetProducts()
        {
            return repository.GetProducts();
        }

        public void AddProduct(Product product)
        {
            repository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            repository.UpdateProduct(product);
        }

        public void DeleteProduct(Product product)
        {
            repository.DeleteProduct(product);
        }
    }
}
