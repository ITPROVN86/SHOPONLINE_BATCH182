using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Add(Category category)=> CategoryDAO.Add(category);
        public void Update(Category category) => CategoryDAO.Update(category);
        public void Delete(Category category) => CategoryDAO.Delete(category);
        public Category GetCategoryById(int id)=> CategoryDAO.FindById(id);
        public List<Category> GetCategories()=>CategoryDAO.GetCategories();
    }
}
