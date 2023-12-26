using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.Manager
{
    public class MakaleManager
    {
        public List<Makaleler> MakaleListesi()
        {
            MyBlogSiteDB myBlogSiteDB = new MyBlogSiteDB();
            var list = myBlogSiteDB.Makaleler.ToList();
            return list;
        }
    }
}
