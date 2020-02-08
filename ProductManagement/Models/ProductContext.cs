using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement.Models
{
    // Enable-Migrations
    // Add-Migration init
    // Update-Database
    public class ProductContext : DbContext
    {
        public ProductContext() : base("ProductManagementDB")
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<User> Users{ get; set; }

        public DbSet<Role> Roles{ get; set; }

       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}