using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Interface
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryViewModel> GetAll();

        void Add(CategoryViewModel entity);

        void Delete(CategoryViewModel entity);

        void Update(CategoryViewModel products);

        CategoryViewModel GetById(int id);

        CategoryViewModel GetByCondition(Object obj);

        void SaveChange();
    }
}
