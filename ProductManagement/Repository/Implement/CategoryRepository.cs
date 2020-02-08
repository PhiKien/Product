using AutoMapper;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Repository.Implement
{
    public class CategoryRepository : ICategoryRepository
    {
        private ProductContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryRepository(ProductContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(CategoryViewModel entity)
        {
            var model = _mapper.Map<CategoryViewModel, Category>(entity);
            _context.Categorys.Add(model);
        }

        public void Delete(CategoryViewModel entity)
        {
            var model = _mapper.Map<CategoryViewModel, Category>(entity);
            _context.Categorys.Remove(model);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var listModel = _context.Categorys.ToList();
            return _mapper.Map<List<Category>, List<CategoryViewModel>>(listModel);
        }

        public CategoryViewModel GetByCondition(object obj)
        {
            throw new NotImplementedException();
        }

        public CategoryViewModel GetById(int id)
        {
            var model = _context.Categorys.FirstOrDefault(c => c.ID == id);
            return _mapper.Map<Category, CategoryViewModel>(model);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryViewModel entity)
        {
            var model = _mapper.Map<CategoryViewModel, Category>(entity);
            var category = _context.Categorys.FirstOrDefault(c => c.ID == model.ID);
            category = model;
        }
    }
}