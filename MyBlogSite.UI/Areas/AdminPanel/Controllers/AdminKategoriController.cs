using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.Enum;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.UnitOfWorkManager;
using MyBlogSite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminKategoriController : Controller
    {
        MyBlogSiteDB _db;
        KategoriRepository _kategoriRepo;
        UyariMesajlari uyariMesaj = new UyariMesajlari();
        UnitOfWork _unitOfWork;


        public AdminKategoriController()
        {
            _db = new MyBlogSiteDB();
            _kategoriRepo = new KategoriRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
        }
        // GET: AdminPanel/AdminKategoris
        public ActionResult AdminKategoriIndex()
        {
            return View(_kategoriRepo.KategoriListele());
        }

        [HttpGet]
        public ActionResult AdminKategoriEkle()
        {
            var kategoriList = _kategoriRepo.KategoriListele();
            return View(kategoriList);
        }

        [ValidateInput(false), HttpPost]
        public ActionResult AdminKategoriEkle(string kategoriAdi, string aciklama)
        {
            var kategoriList = _kategoriRepo.KategoriListele();

            var ekle = _kategoriRepo.KategoriEkle(kategoriAdi, aciklama);

            if (ekle == DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(ekle);
                return View(kategoriList);
            }

            int kaydet = _unitOfWork.SaveChanges();

            if (kaydet <= (int)DefinationMessages.Basarisiz)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Eklenirken_Hata_Olustu.ToString());
                return View(kategoriList);
            }
            //ViewBag.mesaj = @"<div class='alert alert-success' role='alert'>  " + DefinationMessages.Ekleme_basarili.ToString()+ "</div>";
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString());

            return View(kategoriList);
        }
        [HttpGet]
        public ActionResult AdminKategoriGuncelle(int id)
        {
            var kategoriBul = _kategoriRepo.Get(id);
            return View(kategoriBul);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AdminKategoriGuncelle(int KategorilerID,string KategoriAdi,string Aciklama,bool AktifMi)
        {
            var guncelle = _kategoriRepo.KategoriGuncelle(KategorilerID, KategoriAdi, Aciklama,Convert.ToBoolean(AktifMi));
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


            var kategoriBul = _kategoriRepo.Get(KategorilerID);
            return View(kategoriBul);
        }
        [HttpGet]
        public ActionResult AdminKategoriSil(int id)
        {
            var kategoriBul=_kategoriRepo.Get(id);
            return View(kategoriBul);
        }
        [HttpPost, ActionName("AdminKategoriSil")]
        public ActionResult AdminKategoriDelete(int id)
        {
            var pasitEt = _kategoriRepo.KategoriSil(id);
            var sonuc = _unitOfWork.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("AdminKategoriIndex");
            }
            var kategoriBul = _kategoriRepo.Get(id);
            return View(kategoriBul);
        }
    }
}