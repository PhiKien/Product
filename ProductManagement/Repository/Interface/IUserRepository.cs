using ProductManagement.ViewModels;
using System.Collections.Generic;

namespace ProductManagement.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<UserViewModel> GetAll();

        void Add(UserViewModel entity);

        void Delete(UserViewModel entity);

        void Update(UserViewModel products);

        UserViewModel GetById(long id);

        UserViewModel GetById(string userName);

        IEnumerable<UserViewModel> GetByRole(int? id);

        int Login(string userNmae, string passWord);

        int LoginAdmin(string userNmae, string passWord);

        List<int> GetListRoleId(string userName);

        void SaveChange();
    }
}
