using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class MyDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyStockDB"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Laptop"},
                new Category { CategoryId = 2, CategoryName = "Screen" },
                new Category { CategoryId = 3, CategoryName = "Keyboard" },
                new Category { CategoryId = 4, CategoryName = "Mouse" },
                new Category { CategoryId = 5, CategoryName = "Loa Sub" },
                new Category { CategoryId = 6, CategoryName = "Head Phone" }
                );
        }
    }
}
