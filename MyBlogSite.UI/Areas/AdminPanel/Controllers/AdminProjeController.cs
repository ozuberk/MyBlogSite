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
    public class AdminProjeController : Controller
    {
        MyBlogSiteDB _db;
        ProjeRepository _projeRepo;
        KategoriRepository _kategoriRepo;
        UnitOfWork _unitOfWork;
        UyariMesajlari uyariMesaj = new UyariMesajlari();
        public AdminProjeController()
        {
            _db = new MyBlogSiteDB();
            _projeRepo = new ProjeRepository(_db);
            _kategoriRepo = new KategoriRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
        }
        public ActionResult AdminProjeIndex()
        {
            return View(_projeRepo.Sp_ProjeListesi());
        }
        [HttpGet]
        public ActionResult AdminProjeEkle()
        {
            var kategoriList = _kategoriRepo.KategoriListele();
            return View(kategoriList);
        }
        [ValidateInput(false), HttpPost]
        public ActionResult AdminProjeEkle(string projeKategori, string projeAdi, string projeLinki)
        {
            var kategoriList = _kategoriRepo.KategoriListele();
            var ekle = _projeRepo.ProjeEkle(2, Convert.ToInt32(projeKategori), projeAdi, projeLinki);

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
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString());

            return View(kategoriList);
        }
        [HttpGet]
        public ActionResult AdminProjeGuncelle(int id)
        {
            ViewBag.projeKategori = _kategoriRepo.GetAll();

            var projeBul = _projeRepo.Get(id);
            return View(projeBul);

        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AdminProjeGuncelle(int ProjelerID, int KategoriID, int KullanıcıID, string ProjeAdi, string ProjeLinki, bool AktifMi)
        {
            ViewBag.projeKategori = _kategoriRepo.GetAll();

            var guncelle = _projeRepo.ProjeGuncelle(ProjelerID, KullanıcıID, KategoriID, ProjeAdi, ProjeLinki, Convert.ToBoolean(AktifMi));
            if (guncelle == DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(guncelle);
                return View();
            }
            var sonuc = _unitOfWork.SaveChanges();
            if (sonuc == (int)DefinationMessages.Basarisiz)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Eklenirken_Hata_Olustu.ToString());
                return View();
            }
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString());
            var makaleBul = _projeRepo.Get(ProjelerID);


            return View(makaleBul);
        }

        public ActionResult AdminProjeSil(int id)
        {
            var projeBul = _projeRepo.Get(id);
            return View(projeBul);
        }

        [HttpPost, ActionName("AdminProjeSil")]
        public ActionResult AdminProjeDelete(int id)
        {
            var pasitEt = _projeRepo.ProjeSil(id);
            var sonuc = _unitOfWork.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("AdminProjeIndex");
            }
            var makaleBul = _projeRepo.Get(id);
            return View(makaleBul);
        }
    }
}