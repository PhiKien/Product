using ProductManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProductContext _context;

        public UnitOfWork(ProductContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}