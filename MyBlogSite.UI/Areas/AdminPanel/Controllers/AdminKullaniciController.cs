using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.Enum;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using MyBlogSite.DLL.UnitOfWorkManager;
using MyBlogSite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminKullaniciController : Controller
    {
        MyBlogSiteDB _db;
        KullaniciRepository _kullaniciRepo;
        YetkiRepository _yetkiRepo;
        UnitOfWork _unitOfWork;
        UyariMesajlari uyariMesaj = new UyariMesajlari();
        public AdminKullaniciController()
        {
            _db = new MyBlogSiteDB();
            _kullaniciRepo = new KullaniciRepository(_db);
            _yetkiRepo = new YetkiRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
        }
        // GET: AdminPanel/AdminKullanici
        public ActionResult AdminKullaniciIndex()
        {
            return View(_kullaniciRepo.KullaniciListesi());
        }
        [HttpGet]
        public ActionResult AdminKullaniciEkle()
        {
            return View(_kullaniciRepo.KullaniciListesi());
        }
        [ValidateInput(false), HttpPost]
        public ActionResult AdminKullaniciEkle(string adi, string soyadi, string kullaniciAdi, string kullaniciSifresi, string email, string twitter, string github, string linkedln, string meslek, string ulke, string sehir, string hakkinda)
        {
            var kullaniciList = _kullaniciRepo.KullaniciListesi();
            var ekle = _kullaniciRepo.KullaniciEkle(adi, soyadi, kullaniciAdi, kullaniciSifresi, email, twitter, github, linkedln, meslek, ulke, sehir, hakkinda);
            if (ekle == DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(ekle);
                return View(kullaniciList);
            }

            int kaydet = _unitOfWork.SaveChanges();

            if (kaydet <= (int)DefinationMessages.Basarisiz)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Eklenirken_Hata_Olustu.ToString());
                return View(kullaniciList);
            }
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString());

            return View(kullaniciList);
        }

        public ActionResult AdminKullaniciGuncelle(int id)
        {
            ViewBag.yetkiKullanici = _yetkiRepo.GetAll();
            var kullaniciBul = _kullaniciRepo.Get(id);
            return View(kullaniciBul);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AdminKullaniciGuncelle(int KullanicilarID, string Adi, string Soyadi, string KullaniciAdi, string KullaniciSifresi, string email, string twitter, string github, string linkedln, string meslek, string YasadigiUlke, string YasadigiSehir, string KisacaHakkinda, bool AktifMi, DateTime EklenmeTarihi)
        {
            ViewBag.yetkiKullanici = _yetkiRepo.GetAll();
            var guncelle = _kullaniciRepo.KullaniciGuncelle(KullanicilarID, Adi, Soyadi, KullaniciAdi, KullaniciSifresi, email, twitter, github, linkedln, meslek, YasadigiUlke, YasadigiSehir, KisacaHakkinda, Convert.ToBoolean(AktifMi), EklenmeTarihi);
            if (guncelle == DefinationMessages.Guncelleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(guncelle);
                return View();
            }
            var sonuc = _unitOfWork.SaveChanges();
            if (sonuc == (int)DefinationMessages.Basarisiz)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Guncelleme_islemi_esnasında_hata_olustu.ToString());
                return View();
            }
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Guncelleme_basarili.ToString());
            var kullaniciBul = _kullaniciRepo.Get(KullanicilarID);


            return View(kullaniciBul);
        }

        [HttpGet]
        public ActionResult AdminKullaniciSil(int id)
        {
            var kullaniciBul = _kullaniciRepo.Get(id);
            return View(kullaniciBul);
        }
        [HttpPost, ActionName("AdminKullaniciSil")]
        public ActionResult AdminKullaniciDelete(int id)
        {
            var pasitEt = _kullaniciRepo.KullaniciSil(id);
            var sonuc = _unitOfWork.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("AdminKullaniciIndex");
            }
            var kullaniciBul = _kullaniciRepo.Get(id);
            return View(kullaniciBul);
        }
    }
}