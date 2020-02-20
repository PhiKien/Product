using AutoMapper;
using ProductManagement.Common;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductManagement.Repository.Implement
{
    public class UserProcRepository : IUserProcRepository
    {
        private ProductContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserProcRepository(ProductContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(UserViewModel entity)
        {
            var model = _mapper.Map<UserViewModel, User>(entity);

            var paramUserName = new SqlParameter("@userName", model.UserName);
            var paramPassword = new SqlParameter("@password", model.Password);
            var paramName = new SqlParameter("@name", model.Name);
            var paramAddress = new SqlParameter("@address", model.Address);
            var paramEmail = new SqlParameter("@email", model.Email);
            var paramPhone = new SqlParameter("@phone", model.Phone);
            var paramCreateDate = new SqlParameter("@createDate", DateTime.Now);
            var paramModifiedDate = new SqlParameter("@modifiedDate", DateTime.Now);
            var paramStatus = new SqlParameter("@status", model.Status);
            var paramRoleID = new SqlParameter("@roleID", model.RoleID);

            _context.Database.ExecuteSqlCommand(CommonConstantProc.PROC_CREATE_USER, paramUserName, paramPassword, paramName, paramAddress, paramEmail, paramPhone, paramCreateDate, paramModifiedDate, paramStatus, paramRoleID);
        }

        public void Delete(long? id)
        {
            _context.Database.ExecuteSqlCommand(CommonConstantProc.PROC_DELETE_USER, new SqlParameter("@userID", id));            
        }

        public IEnumerable<UserViewModel2> GetAll()
        {
            return _context.Database.SqlQuery<UserViewModel2>(CommonConstantProc.PROC_GET_ALL_USER).ToList();
        }

        public UserViewModel2 GetById(long? id)
        {
            return _context.Database.SqlQuery<UserViewModel2>(CommonConstantProc.PROC_GET_USER_BY_ID, new SqlParameter("@userID", id)).Single();
        }

        public void Update(User model)
        {
            var paramID = new SqlParameter("@ID", model.ID);
            var paramUserName = new SqlParameter("@UserName", model.UserName);
            var paramPassword = new SqlParameter("@Password", model.Password);
            var paramName = new SqlParameter("@Name", model.Name);
            var paramAddress = new SqlParameter("@Address", model.Address);
            var paramEmail = new SqlParameter("@Email", model.Email);
            var paramPhone = new SqlParameter("@Phone", model.Phone);
            var paramCreateDate = new SqlParameter("@CreateDate", model.CreateDate);
            var paramModifiedDate = new SqlParameter("@ModifiedDate", model.ModifiedDate);
            var paramStatus = new SqlParameter("@Status", model.Status);
            var paramRoleID = new SqlParameter("@RoleID", model.RoleID);

            _context.Database.ExecuteSqlCommand(CommonConstantProc.PROC_UPDATE_USER, paramID, paramUserName, paramPassword, paramName, paramAddress, paramEmail, paramPhone, paramCreateDate, paramModifiedDate, paramStatus, paramRoleID);
        }
    }
}