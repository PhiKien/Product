using ProductManagement.ViewModels;
using System.Collections.Generic;

namespace ProductManagement.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<ProductViewModel> GetAll();

        void Add(ProductViewModel entity);

        void Delete(ProductViewModel entity);

        void Update(ProductViewModel products);

        ProductViewModel GetById(int id);

        IEnumerable<ProductViewModel> GetByCondition(int? id);

        IEnumerable<ProductViewModel> GetByRoleID(int id);

        void SaveChange();
    }
}
