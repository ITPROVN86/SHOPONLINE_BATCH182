﻿using DemoWebMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoWebMVC
{
    public class CustomerDBContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ExampleCustomerDB"));
        }
    }
}
