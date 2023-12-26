using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.UnitOfWorkManager
{
    public interface IUnitOfWork
    {
        int SaveChanges();

    }
}
