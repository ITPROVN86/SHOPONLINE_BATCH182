using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static IEnumerable<Product> GetProducts()
        {
            var context = new MyDbContext();
            var products = context.Products;
            return products.ToList();
        }

        public static Product FindById(int id)
        {
            Product p = new Product();
            using (var context = new MyDbContext())
            {
                p = context.Products.SingleOrDefault(p => p.ProductId == id);
            }
            return p;
        }

        public static void Add(Product product) {
            using (var context = new MyDbContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static void Update(Product product)
        {
            using (var context = new MyDbContext())
            {
                context.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public static void Delete(Product product)
        {
            using (var context = new MyDbContext())
            {
                var id = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
                if (id != null)
                {
                    context.Products.Remove(id);
                    context.SaveChanges();
                }
                
            }
        }
    }
}
