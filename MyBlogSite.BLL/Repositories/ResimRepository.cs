using MyBlogSite.BLL.IRepositories;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.Repositories
{
    public class ResimRepository:Repository<Resimler>,IResimRepository
    {
        MyBlogSiteDB _db;

        public ResimRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public IResimRepository ResimGetir(int resimID, string resimAdi)
        {
            throw new NotImplementedException();
        }

        public string ResimGuncelle(int resimlerID, string buyukResimKonumu, string kucukResimKonumu, string resimKonumu, string baslik, DateTime eklenmeTarihi, bool aktifMi)
        {
            throw new NotImplementedException();
        }

        public string ResimKaydet(string buyukResimKonumu, string kucukResimKonumu, string resimKonumu, string baslik, DateTime eklenmeTarihi, bool aktifMi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Resimler> ResimleriGetir(int resimID)
        {
            throw new NotImplementedException();
        }

        public string ResimSil(int resimlerID, bool resimAktifMi)
        {
            throw new NotImplementedException();
        }
    }
}
