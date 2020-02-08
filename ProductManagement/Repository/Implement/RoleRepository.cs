using AutoMapper;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.Repository.Implement
{
    public class RoleRepository : IRoleRepository
    {
        private ProductContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleRepository(ProductContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<int> GetListRoleId()
        {
            throw new NotImplementedException();
        }

        //public List<int> GetListRoleId(string userName)
        //{
        //    var roles = _context.Roles.Where().ToList();
        //    List<int> list = new List<int>();
        //    foreach (var item in roles)
        //    {
        //        var id = item.ID;
        //        list.Add(id);
        //    }
        //    return list;
        //}
    }
}