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
    public class MakalelerUnit
    {
        MyBlogSiteDB _db;
        MakaleRepository _makaleRepository;
        public MakalelerUnit()
        {
            _db = new MyBlogSiteDB();
            _makaleRepository = new MakaleRepository(_db);
        }


        public IEnumerable<Makaleler> MakaleListesi()
        {
            var list = _makaleRepository.GetAll();

            return list;
        }
    }
}
