using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IProjeRepository :IRepository<Projeler>
    {
        int ProjeSayisi(int projeId);
        string ProjeEkle(int kullaniciId,int kategoriId,string projeAdi,string projeLinki);
        string ProjeGuncelle(int projeId,int kullaniciId, int kategoriId, string projeAdi, string projeLinki, bool aktifMi);
        string ProjeSil(int projeId);
        IEnumerable<Projeler> ProjeListesi();
        IEnumerable<Projeler> ProjeListesi(bool aktifMi);
        IEnumerable<Sp_ProjeListesiDOM> Sp_ProjeListesi();
        IEnumerable<Sp_ProjeListesiDOM> Sp_ProjeListesi(bool aktifMi);

    }
}
