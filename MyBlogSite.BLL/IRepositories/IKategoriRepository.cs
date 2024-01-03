using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IKategoriRepository :IRepository<Kategoriler>
    {//
        int KategoriSayisi(int kategoriID);
        string KategoriEkle(string kategoriAdi, string aciklama);
        string KategoriGuncelle(int kategoriID, string kategoriAdi, string aciklama,bool aktifMi);
        string KategoriSil(int kategoriID);

        IEnumerable<Kategoriler> KategoriListele();
        IEnumerable<Kategoriler> KategoriListele(bool aktifMi);
    }
}
