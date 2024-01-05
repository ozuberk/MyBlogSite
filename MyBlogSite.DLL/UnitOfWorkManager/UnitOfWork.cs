using MyBlogSite.DLL.Enum;
using MyBlogSite.DLL.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.UnitOfWorkManager
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyBlogSiteDB _db;

        public UnitOfWork(MyBlogSiteDB db)
        {
            _db = db;
        }
        public int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                return DefinationMessages.Basarisiz.GetHashCode();

            }
        }
    }
}
