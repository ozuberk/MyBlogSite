using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IYetkiRepository:IRepository<Yetkiler>
    {
        int YetkiSayisi(int yetkiId);
        string YetkiEkle(string yetkiAdi);
        string YetkiGuncelle(int yetkiId, string yetkiAdi,bool aktifMi);
        string YetkiSil(int yetkiId);
        IEnumerable<Yetkiler> YetkiListesi();
        IEnumerable<Yetkiler> YetkiListesiAdminHaric();

    }
}
