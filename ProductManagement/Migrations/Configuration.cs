namespace ProductManagement.Migrations
{
    using ProductManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductManagement.Models.ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductManagement.Models.ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            try
            {
                // Your code...
                // Could also be before try if you know the exception occurs in SaveChanges
                if (!context.Categorys.Any(c => c.Name == "Accessories" && c.ID == 1))
                {
                    context.Categorys.AddRange(new List<Category> {
                    new Category ("Accessories"),
                    new Category ("Desktop"),
                    new Category ("IP Phone"),
                    new Category ("Laptop"),
                    new Category ("Monitor"),
                    new Category ("Server"),
                    new Category ("SmartPhone")
                });
                    context.SaveChanges();
                }

                if (!context.Products.Any(p => p.Name == "Airpods" && p.ID == 1))
                {
                    context.Products.AddRange(new List<Product> {
                    new Product ("Airpods", "Headphone for me!", 1, 1),
                    new Product ("Lenovo", "Desktop for FIT!", 20, 2),
                    new Product ("Lenovo ThinkVision", "LCD Monitor!", 10, 5),
                    new Product ("HP Pavillion", "Laptop for boss!", 5, 4),
                    new Product ("IP Phone", "IP phone for internal connection!", 100, 3),
                    new Product ("TP-Link Server", "Server for company!", 2, 6),
                    new Product ("Samsung galaxy Note 10", "Smart phone for me!", 1, 7)
                });
                    context.SaveChanges();
                }

                if (!context.Roles.Any(p => p.Name == "Admin" && p.ID == 1))
                {
                    context.Roles.AddRange(new List<Role> {
                    new Role ("Admin"),
                    new Role ("PM"),
                    new Role ("Employee")
                });
                    context.SaveChanges();
                }

                if (!context.Users.Any(p => p.UserName == "Admin" && p.ID == 1))
                {
                    context.Users.AddRange(new List<User> {
                    new User ("Admin", "0192023a7bbd73250516f069df18b500", "Admin", "HN", "Admin@gmail.com", "0966015228", DateTime.Now, DateTime.Now,true, 1),
                    new User ("ProductManage", "a2f92fd4b342fd50710b8c8f7ba3fb1f", "PM", "HN", "PM@gmail.com", "0966015771", DateTime.Now, DateTime.Now,true, 2),
                    new User ("Employee", "fa5473530e4d1a5a1e1eb53d2fedb10c", "Employee", "HN", "Employee@gmail.com", "0945815228", DateTime.Now, DateTime.Now,true, 3)
                });
                    context.SaveChanges();
                }

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
