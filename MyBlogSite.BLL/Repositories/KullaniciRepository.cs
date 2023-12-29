using MyBlogSite.BLL.IRepositories;
using MyBlogSite.DLL.Enum;
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
    public class KullaniciRepository:Repository<Kullanicilar>,IKullaniciRepository
    {
        MyBlogSiteDB _db;

        public KullaniciRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public string KullaniciEkle(string adi, string soyadi, string kullaniciAdi, string kullaniciSifresi, string email, string twitter, string github, string linkedln, string meslek, string ulke, string sehir, string hakkinda)
        {
            try
            {
                Kullanicilar kullaniciEkle = new Kullanicilar();
                kullaniciEkle.Adi = adi;
                kullaniciEkle.Soyadi= soyadi;
                kullaniciEkle.KullaniciAdi = kullaniciAdi;
                kullaniciEkle.KullaniciSifresi = kullaniciSifresi;
                kullaniciEkle.email=email;
                kullaniciEkle.twitter=twitter;
                kullaniciEkle.github=github;
                kullaniciEkle.linkedln=linkedln;
                kullaniciEkle.meslek=meslek;
                kullaniciEkle.YasadigiUlke = ulke;
                kullaniciEkle.YasadigiSehir = sehir;
                kullaniciEkle.KisacaHakkinda = hakkinda;
                kullaniciEkle.AktifMi = true;
                kullaniciEkle.Yetkiler = _db.Yetkiler.Where(y => y.YetkilerID == 2).FirstOrDefault();
                Add(kullaniciEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();

            }
        }

        public string KullaniciGuncelle(int kullaniciId, string adi, string soyadi, string kullaniciAdi, string kullaniciSifresi, string email, string twitter, string github, string linkedln, string meslek, string ulke, string sehir, string hakkinda, bool aktifMi, DateTime eklenmeTarihi)
        {
            var kullaniciGuncelle = Find(k => k.KullanicilarID == kullaniciId).FirstOrDefault();
            try
            {
                Kullanicilar kullaniciEkle = new Kullanicilar();
                kullaniciEkle.Adi = adi;
                kullaniciEkle.Soyadi = soyadi;
                kullaniciEkle.KullaniciAdi = kullaniciAdi;
                kullaniciEkle.KullaniciSifresi = kullaniciSifresi;
                kullaniciEkle.email = email;
                kullaniciEkle.twitter = twitter;
                kullaniciEkle.github = github;
                kullaniciEkle.linkedln = linkedln;
                kullaniciEkle.meslek = meslek;
                kullaniciEkle.YasadigiUlke = ulke;
                kullaniciEkle.YasadigiSehir = sehir;
                kullaniciEkle.KisacaHakkinda = hakkinda;
                kullaniciEkle.AktifMi = aktifMi;
                kullaniciEkle.Yetkiler = _db.Yetkiler.Where(y => y.YetkilerID == 2).FirstOrDefault();
                Add(kullaniciEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();

            }
        }

        public IEnumerable<Kullanicilar> KullaniciListesi()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kullanicilar> KullaniciListesi(bool aktifMi)
        {
            throw new NotImplementedException();
        }

        public int KullaniciSayisi(int kullanicilarId)
        {
            throw new NotImplementedException();
        }

        public string KullaniciSil(int kullaniciId)
        {
            throw new NotImplementedException();
        }
        public Kullanicilar Giris(string kullaniciAdi, string sifre)
        {
            var getir = Find(k => k.KullaniciAdi == kullaniciAdi && k.KullaniciSifresi == sifre).FirstOrDefault();
            return getir;
        }
    }
}
