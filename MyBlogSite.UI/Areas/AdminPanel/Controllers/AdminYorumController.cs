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
    public class AdminYorumController : Controller
    {
        MyBlogSiteDB _db;
        YorumRepository _yorumRepo;
        UnitOfWork _unitOfwork;
        UyariMesajlari uyariMesaj = new UyariMesajlari();
        public AdminYorumController()
        {
            _db = new MyBlogSiteDB();
            _yorumRepo = new YorumRepository(_db);
            _unitOfwork = new UnitOfWork(_db);
        }
        // GET: AdminPanel/AdminYorum
        public ActionResult AdminYorumIndex()
        {
            return View(_yorumRepo.Sp_YorumListesi());
        }
        [HttpGet]
        public ActionResult AdminYorumGuncelle(int id)
        {
            var yorumBul = _yorumRepo.Get(id);
            return View(yorumBul);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AdminYorumGuncelle(int YorumlarID, string Yorum, bool AktifMi)
        {
            var guncelle = _yorumRepo.YorumGuncelle(YorumlarID, Yorum, Convert.ToBoolean(AktifMi));
            if (guncelle == DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(guncelle);
                return View();
            }
            var sonuc = _unitOfwork.SaveChanges();
            if (sonuc == (int)DefinationMessages.Basarisiz)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Eklenirken_Hata_Olustu.ToString());
                return View();
            }
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString());



            var yorumBul = _yorumRepo.Get(YorumlarID);
            return View(yorumBul);
        }
       public ActionResult AdminYorumSil(int id)
        {
            var yorumBul = _yorumRepo.Get(id);
            return View(yorumBul);
        }
        [HttpPost, ActionName("AdminYorumSil")]
        public ActionResult AdminYorumDelete(int id)
        {
            var pasitEt = _yorumRepo.YorumSil(id);
            var sonuc = _unitOfwork.SaveChanges();
            if (sonuc > 0)
            {
                return RedirectToAction("AdminYorumIndex");
            }
            var yorumBul = _yorumRepo.Get(id);
            return View(yorumBul);
        }
    }
}