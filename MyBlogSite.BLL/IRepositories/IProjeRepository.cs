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
        string ProjeEkle(int yazarId,int kategoriId,string projeAdi,string projeLinki);
        string ProjeGuncelle(int projeId,int yazarId, int kategoriId, string projeAdi, string projeLinki, bool aktifMi, int onaylayanKullaniciId);
        string ProjeSil(int projeId);
        IEnumerable<Projeler> ProjeListesi();
        IEnumerable<Projeler> ProjeListesi(bool aktifMi);
        IEnumerable<Sp_ProjeListesiDOM> Sp_ProjeListesi();
        IEnumerable<Sp_ProjeListesiDOM> Sp_ProjeListesi(bool aktifMi);

    }
}
