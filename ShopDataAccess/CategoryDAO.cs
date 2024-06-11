using Microsoft.EntityFrameworkCore;
using ShopBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDataAccess
{
    public class CategoryDAO : SingletonBase<CategoryDAO>
    {
        public CategoryDAO() { _context = new ShopBacth182Context(); }
        /// <summary>
        /// GET ALL
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetCategoryAll()
        {
            return await _context.Categories.ToListAsync();
        }

        /// <summary>
        /// GET BY ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryById(int id)
        {
            var category = await _context.Categories.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category == null) return null;

            return category;
        }
        public async Task Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public async Task Update(Category category)
        {
            _context = new ShopBacth182Context();
            var existingItem = await GetCategoryById(category.CategoryId);
            if (existingItem != null)
            {
                // Cập nhật các thuộc tính cần thiết
                _context.Entry(existingItem).CurrentValues.SetValues(category);
            }
            else
            {
                // Thêm thực thể mới nếu nó chưa tồn tại
                _context.Categories.Add(category);
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
        public async Task Delete(int id)
        {
            _context = new ShopBacth182Context();
            var category = await GetCategoryById(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> GetCategoryByName(string name)
        {
            return _context.Categories.Where(u => u.CategoryName.Contains(name)).ToList();
        }

        public async Task<bool> ChangeStatus(int id)
        {
            var category = await GetCategoryById(id);
            category.Status = !category.Status;
            _context.SaveChanges();
            return category.Status;
        }
    }
}
