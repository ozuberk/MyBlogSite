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
                kullaniciEkle.EklenmeTarihi=DateTime.Now;
                kullaniciEkle.PasiflikTarihi=DateTime.Now;
                kullaniciEkle.Yetkiler = _db.Yetkiler.Where(y => y.YetkilerID == 3).FirstOrDefault();
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
                kullaniciEkle.EklenmeTarihi = eklenmeTarihi!=null?eklenmeTarihi:DateTime.Now;
                kullaniciEkle.Yetkiler = _db.Yetkiler.Where(y => y.YetkilerID == 3).FirstOrDefault();
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();

            }
        }

        public IEnumerable<Kullanicilar> KullaniciListesi()
        {
            return GetAll();

        }

        public IEnumerable<Kullanicilar> KullaniciListesi(bool aktifMi)
        {
            return Find(k => k.AktifMi == aktifMi);
        }

        public int KullaniciSayisi(int kullanicilarId)
        {
            return Find(k => k.KullanicilarID == kullanicilarId).Count();
        }

        public string KullaniciSil(int kullaniciId)
        {
            try
            {
                var pasifEt = Get(kullaniciId);
                pasifEt.AktifMi = false;
                pasifEt.PasiflikTarihi=DateTime.Now;
                return DefinationMessages.Basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Basarisiz.ToString();
            }
        }
        public Kullanicilar Giris(string kullaniciAdi, string sifre)
        {
            var getir = Find(k => k.KullaniciAdi == kullaniciAdi && k.KullaniciSifresi == sifre).FirstOrDefault();
            return getir;
        }
    }
}
