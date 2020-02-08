using AutoMapper;
using ProductManagement.AutoMappers;
using ProductManagement.Models;
using ProductManagement.Repository.Implement;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductManagement
{
    public static class UnityConfig
    {
        
         //static IMapper mapper;
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<ProductViewModel, Product>().ConstructUsing(p => new Product(p.ID, p.Name, p.Description, p.NumberInStock, p.CategoryID));
                cfg.CreateMap<CategoryViewModel, Category>().ConstructUsing(c => new Category(c.ID, c.Name));
                cfg.CreateMap<UserViewModel, User>().ConstructUsing(u => new User(u.ID, u.UserName, u.Password, u.Name, u.Address, u.Email, u.Phone, u.CreateDate, u.ModifiedDate, u.Status, u.RoleID));
                //...
            });
            IMapper mapper = config.CreateMapper();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterInstance(mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}