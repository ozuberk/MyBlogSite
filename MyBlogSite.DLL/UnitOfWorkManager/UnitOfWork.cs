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
        /// <summary>
        /// Asıl amaç toplu işlemlerde bir data geri dönüşü sağlamaktır.
        /// </summary>
        /// <param name="db"></param>
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
                //GetHashCode() Enum lar için int değeri getirir

            }
        }
    }
}
