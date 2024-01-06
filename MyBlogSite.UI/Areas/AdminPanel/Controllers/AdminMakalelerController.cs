using MyBlogSite.BLL.IRepositories;
using MyBlogSite.BLL.Manager;
using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.Enum;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using MyBlogSite.DLL.UnitOfWorkManager;
using MyBlogSite.UI.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminMakalelerController : Controller
    {
        MyBlogSiteDB _db;
        MakaleRepository _makaleRepo;
        KategoriRepository _kategoriRepo;
        UnitOfWork _unitOfWork;
        UyariMesajlari uyariMesaj = new UyariMesajlari();
        public AdminMakalelerController()
        {
          _db = new MyBlogSiteDB();
            _makaleRepo = new MakaleRepository(_db);
            _kategoriRepo = new KategoriRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
        }
        public ActionResult AdminMakalelerIndex()
        {
            return View(_makaleRepo.Sp_MakaleListesi());
        }
        [HttpGet]
        public ActionResult AdminMakaleEkle()
        {
            var kategoriList=_kategoriRepo.KategoriListele();
            return View(kategoriList);
        }
        [ValidateInput(false),HttpPost]
        public ActionResult AdminMakaleEkle(string makaleKategori,string makaleBaslik,string makaleIcerik)
        {
            var kategoriList = _kategoriRepo.KategoriListele();
            var ekle = _makaleRepo.MakaleEkle(2, Convert.ToInt32(makaleKategori), makaleBaslik, makaleIcerik);

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
        public ActionResult AdminMakaleGuncelle(int id)
        {
            ViewBag.makaleKategori = _kategoriRepo.GetAll();
            var makaleBul = _makaleRepo.Get(id);
            return View(makaleBul);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AdminMakaleGuncelle(int MakalelerID, string MakaleBaslik, string MakaleIcerik, DateTime EklenmeTarihi, bool AktifMi, int makaleKategoriId)
        {
            ViewBag.makaleKategori = _kategoriRepo.GetAll();


            var guncelle = _makaleRepo.MakaleGuncelle(MakalelerID, makaleKategoriId, MakaleBaslik, MakaleIcerik, Convert.ToBoolean(AktifMi));
            if (guncelle==DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(guncelle);
                return View();
            }
            var sonuc = _unitOfWork.SaveChanges();
            if (sonuc==(int)DefinationMessages.Basarisiz)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Eklenirken_Hata_Olustu.ToString());
                return View();
            }
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString());
            var makaleBul = _makaleRepo.Get(MakalelerID);


            return View(makaleBul);
        }
        [HttpGet]
        public ActionResult AdminMakaleSil(int id)
        {
            var makaleBul=_makaleRepo.Get(id);
            return View(makaleBul);
        }
        /// <summary>
        /// AdminMakaleSil methodunun post işlemidir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,ActionName("AdminMakaleSil")]
        public ActionResult AdminMakaleDelete(int id)
        {
            var pasitEt = _makaleRepo.MakaleSil(id);
            var sonuc=_unitOfWork.SaveChanges();
            if (sonuc > 0)
            {
               return RedirectToAction("AdminMakalelerIndex");
            }
            var makaleBul = _makaleRepo.Get(id);
            return View(makaleBul);
        }

    }
}