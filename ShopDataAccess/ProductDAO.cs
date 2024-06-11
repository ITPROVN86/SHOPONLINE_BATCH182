using Microsoft.EntityFrameworkCore;
using ShopBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDataAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        /// <summary>
        /// GET ALL
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProductAll()
        {
            return _context.Products.AsNoTrackingWithIdentityResolution().ToList();
        }

        /// <summary>
        /// GET BY ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            var product = _context.Products.AsNoTrackingWithIdentityResolution().FirstOrDefault(c => c.ProductId == id);
            if (product == null) return null;

            return product;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context = new ShopBacth182Context();
            var existingItem = GetProductById(product.CategoryId);
            if (existingItem != null)
            {
                // Cập nhật các thuộc tính cần thiết
                _context.Entry(existingItem).CurrentValues.SetValues(product);
            }
            else
            {
                // Thêm thực thể mới nếu nó chưa tồn tại
                _context.Products.Add(product);
            }
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public bool ChangeStatus(int id)
        {
            var product = GetProductById(id);
            product.Status = !product.Status;
            _context.SaveChanges();
            return product.Status;
        }
    }
}
