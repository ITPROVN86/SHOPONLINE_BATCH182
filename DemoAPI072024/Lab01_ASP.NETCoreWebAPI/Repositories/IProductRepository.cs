using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetProductById(int id);
        List<Category> GetCategories();
        IEnumerable<Product> GetProducts();
    }
}
