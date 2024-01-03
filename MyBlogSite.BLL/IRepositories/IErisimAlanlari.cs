using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IErisimAlanlari : IRepository<ErisimAlanlari>
    {
        string SayfaEkle(string controllerAdi, string viewAdi, string aciklama);
        string SayfaEkle(string controllerAdi, string viewAdi, int yetkiErisimID);
        string SayfaGuncelle(int sayfalarId, string controllerAdi, string viewAdi, string aciklama, int yetkiErisimID, bool aktifMi);
        string SayfaSil(int sayfalarId);
        IEnumerable<ErisimAlanlari> SayfaListesi();
        IEnumerable<ErisimAlanlari> SayfaListesi(bool aktifMi);
    }
}
