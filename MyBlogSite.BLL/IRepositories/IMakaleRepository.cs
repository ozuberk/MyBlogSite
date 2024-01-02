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
    public interface IMakaleRepository:IRepository<Makaleler>
    {
        int MakaleSayisi(int makaleId);
        string MakaleEkle(int kullanciId, int kategoriId, string makaleBaslik, string makaleIcerik);
        string MakaleGuncelle(int makaleId, int kategoriId, string makaleBaslik, string makaleIcerik, bool aktifMi);
        string MakaleSil(int makaleId);
        IEnumerable<Makaleler> MakaleListesi();
        IEnumerable<Makaleler> MakaleListesi(bool aktifMi);
        IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi();
        IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi(bool aktifMi);
        //

    }
}
