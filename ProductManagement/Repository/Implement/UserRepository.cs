using AutoMapper;
using ProductManagement.Common;
using ProductManagement.Models;
using ProductManagement.Repository.Interface;
using ProductManagement.UnitOfWorks;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductManagement.Repository.Implement
{
    public class UserRepository : IUserRepository
    {
        private ProductContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserRepository()
        {

        }

        public UserRepository(ProductContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(UserViewModel entity)
        {
            var model = _mapper.Map<UserViewModel, User>(entity);
            var users = _context.Users.ToList();

            if (!users.Contains(model))
            {
                _context.Users.Add(model);
                _context.SaveChanges();
            }
        }

        public void Delete(UserViewModel entity)
        {
            var model = _mapper.Map<UserViewModel, User>(entity);
            _context.Users.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var listModel = _context.Users.ToList();
            return _mapper.Map<List<User>, List<UserViewModel>>(listModel);
        }

        public UserViewModel GetById(long id)
        {
            var model = _context.Users.FirstOrDefault(u => u.ID == id);
            return _mapper.Map<User, UserViewModel>(model);
        }

        public IEnumerable<UserViewModel> GetByRole(int? id)
        {
            var listModel = _context.Users.Where(u => u.RoleID == id).ToList();
            return _mapper.Map<List<User>, List<UserViewModel>>(listModel);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }

        public void Update(UserViewModel user)
        {
            var model = _mapper.Map<UserViewModel, User>(user);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int Login(string userName, string passWord)
        {
            var passWordHash = Encryptor.MD5Hash(passWord);
            var result = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWordHash)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public int LoginAdmin(string userName, string passWord)
        {
            var passWordHash = Encryptor.MD5Hash(passWord);

            var result = _context.Users.FirstOrDefault(u => u.UserName == userName && u.RoleID == 1);

            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWordHash)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public UserViewModel GetById(string userName)
        {
            var model = _context.Users.FirstOrDefault(u => u.UserName == userName);
            return _mapper.Map<User, UserViewModel>(model);
        }

        public List<int> GetListRoleId(string userName)
        {
            var users = _context.Users.Where(u => u.UserName == userName).ToList();
            List<int> list = new List<int>();
            foreach (var item in users)
            {
                var id = item.RoleID;
                list.Add(id);
            }
            return list;
        }


    }
}