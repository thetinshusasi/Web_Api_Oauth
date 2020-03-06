using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DLL.DataModels;

namespace WebAPI.DLL.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
