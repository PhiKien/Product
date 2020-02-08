using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Repository.Interface
{
    public interface IRoleRepository
    {
        List<int> GetListRoleId();
    }
}
