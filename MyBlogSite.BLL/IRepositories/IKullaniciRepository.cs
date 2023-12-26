using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IKullaniciRepository:IRepository<Kullanicilar>
    {
        int KullaniciSayisi(int kullanicilarId);
        string KullaniciEkle(string adi,string soyadi,string kullaniciAdi,string kullaniciSifresi,string email,string twitter,string github,string linkedln,string meslek,string ulke,string sehir,string hakkinda);

        string KullaniciGuncelle(int kullaniciId, string adi, string soyadi, string kullaniciAdi, string kullaniciSifresi, string email, string twitter, string github, string linkedln, string meslek, string ulke, string sehir, string hakkinda,bool aktifMi,DateTime eklenmeTarihi);

        string KullaniciSil(int kullaniciId);

        IEnumerable<Kullanicilar> KullaniciListesi();
        IEnumerable<Kullanicilar> KullaniciListesi(bool aktifMi);
    }
}
