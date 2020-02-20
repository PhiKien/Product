using ProductManagement.Models;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Interface
{
    public interface IUserProcRepository
    {
        IEnumerable<UserViewModel2> GetAll();

        void Add(UserViewModel entity);

        void Delete(long? id);

        void Update(User user);

        UserViewModel2 GetById(long? id);
    }
}
