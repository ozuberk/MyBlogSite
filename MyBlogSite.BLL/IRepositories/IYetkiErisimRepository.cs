using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IYetkiErisimRepository:IRepository<YetkiErisimleri>
    {
        string YetkiErisimEkle(string aciklama);
        string YetkiErisimGuncelle(int yetkiErisimId, string aciklama, bool aktifMi);
        string YetkiErisimSil(int yetkiErisimId);
        IEnumerable<YetkiErisimleri> YetkiErisimListesi();
        IEnumerable<YetkiErisimleri> YetkiErisimListesi(bool aktifMi);
        IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi();
        IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi(bool aktifMi);
        IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi(int yetkiID);
        IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi(int yetkiID, bool aktifMi);
    }
}
