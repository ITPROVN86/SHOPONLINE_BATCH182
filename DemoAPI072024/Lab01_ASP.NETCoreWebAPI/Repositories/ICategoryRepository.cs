using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ICategoryRepository
    {
        void Add(Category product);
        void Update(Category product);
        void Delete(Category product);
        Category GetCategoryById(int id);
        List<Category> GetCategories();
    }
}
