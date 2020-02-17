using ProductManagement.Models;
using ProductManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Interface
{
    public interface IProductProcRepository
    {
        IEnumerable<Product> GetAll();

        void Add(Product entity);

        void Delete(int id);

        void Update(Product products);

        Product GetById(int? id);
    }
}
