using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.UnitTest
{

    public class YorumlarUnit
    {
        MyBlogSiteDB db;
        YorumRepository yorumRepo;
        public YorumlarUnit()
        {
            db = new MyBlogSiteDB();
            yorumRepo = new YorumRepository(db);
        }
        public IEnumerable<Yorumlar> YorumListesi()
        {
            return yorumRepo.GetAll();
        }
    }
}
