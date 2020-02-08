using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}