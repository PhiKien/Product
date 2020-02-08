using AutoMapper;
using ProductManagement.Models;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.AutoMappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        //public ViewModelToDomainMappingProfile()
        //{
        //    //CreateMap<ProductViewModel, Product>().ConstructUsing(p => new Product(p.ID, p.Name, p.Description, p.NumberInStock, p.CategoryID));
        //    //CreateMap<CategoryViewModel, Category>().ConstructUsing(c =>new Category(c.ID, c.Name));
        //}
    }
}