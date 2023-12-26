using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IResimRepository:IRepository<Resimler>
    {
        string ResimKaydet(string buyukResimKonumu, string kucukResimKonumu, string resimKonumu, string baslik, DateTime eklenmeTarihi, bool aktifMi);
        string ResimGuncelle(int resimlerID, string buyukResimKonumu, string kucukResimKonumu, string resimKonumu, string baslik, DateTime eklenmeTarihi, bool aktifMi);
        string ResimSil(int resimlerID, bool resimAktifMi);

        IEnumerable<Resimler> ResimleriGetir(int resimID);

        IResimRepository ResimGetir(int resimID, string resimAdi);
    }
}
