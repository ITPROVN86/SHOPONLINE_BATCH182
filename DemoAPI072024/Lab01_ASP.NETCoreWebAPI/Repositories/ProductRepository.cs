using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class ProductRepository: IProductRepository
    {
        public void Add(Product product)=> ProductDAO.Add(product);
        public void Update(Product product)=>ProductDAO.Update(product);
        public void Delete(Product product)=>ProductDAO.Delete(product);
        public Product GetProductById(int id)=>ProductDAO.FindById(id);
        public List<Category> GetCategories()=>CategoryDAO.GetCategories();
        public IEnumerable<Product> GetProducts()=>ProductDAO.GetProducts();
    }
}
