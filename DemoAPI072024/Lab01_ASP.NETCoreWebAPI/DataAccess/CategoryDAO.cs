using BusinessObjects;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var list = new List<Category>();
            using (var context = new MyDbContext())
            {
                list = context.Categories.ToList();
            }
            return list;
        }

        public static Category FindById(int id)
        {
            Category p = new Category();
            using (var context = new MyDbContext())
            {
                p = context.Categories.SingleOrDefault(p => p.CategoryId == id);
            }
            return p;
        }

        public static void Add(Category category)
        {
            using (var context = new MyDbContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        public static void Update(Category category)
        {
            using (var context = new MyDbContext())
            {
                context.Entry<Category>(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(Category category)
        {
            using (var context = new MyDbContext())
            {
                var id = context.Categories.SingleOrDefault(p => p.CategoryId == category.CategoryId);
                if (id != null)
                {
                    context.Categories.Remove(id);
                    context.SaveChanges();
                }

            }
        }
    }
}
