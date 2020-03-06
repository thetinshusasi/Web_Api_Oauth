using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DLL.DataModels;
using WebAPI.DLL.IRepositories;

namespace WebAPI.DLL.Repositories
{
    public class SuppilerRepository : Repository<Supplier>, ISuppilerRepository
    {
        public SuppilerRepository(DbContext context) : base(context)
        {
        }
    }
}
