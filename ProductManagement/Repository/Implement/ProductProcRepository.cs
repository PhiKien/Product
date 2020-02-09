﻿using AutoMapper;
using ProductManagement.Common;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductManagement.Repository.Implement
{
    public class ProductProcRepository : IProductProcRepository
    {
        private ProductContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductProcRepository(ProductContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(Product product)
        {
            var paramName = new SqlParameter("@productName", product.Name);
            var paramDescription = new SqlParameter("@productDescription", product.Description);
            var paramNumberInStock = new SqlParameter("@productNumberInStock", product.NumberInStock);
            var paramCategoryID = new SqlParameter("@categoryID", product.CategoryID);
            _context.Database.ExecuteSqlCommand(CommonConstantProc.PROC_CREATE_PRODUCT, paramName, paramDescription, paramNumberInStock, paramCategoryID);
        }

        public void Delete(int id)
        {
            var paramID = new SqlParameter("@productID", id);
            _context.Database.ExecuteSqlCommand(CommonConstantProc.PROC_DELETE_PRODUCT, paramID);
        }

        public IEnumerable<Product> GetAll()
        {
            var listProduct = _context.Database.SqlQuery<Product>(CommonConstantProc.PROC_GET_ALL_PRODUCT).ToList();
            return listProduct;
        }

        public Product GetById(int? id)
        {
            var listProduct = _context.Database.SqlQuery<Product>(CommonConstantProc.PROC_GET_PRODUCT_BY_ID, new SqlParameter("@productID", id)).Single();
            return listProduct;
        }

        public void Update(Product product)
        {
            var paramID = new SqlParameter("@productID", product.ID);
            var paramName = new SqlParameter("@productName", product.Name);
            var paramDescription = new SqlParameter("@productDescription", product.Description);
            var paramNumberInStock = new SqlParameter("@productNumberInStock", product.NumberInStock);
            var paramCategoryID = new SqlParameter("@categoryID", product.CategoryID);
            _context.Database.ExecuteSqlCommand(CommonConstantProc.PROC_UPDATE_PRODUCT, paramID, paramName, paramDescription, paramNumberInStock, paramCategoryID);
        }
    }
}