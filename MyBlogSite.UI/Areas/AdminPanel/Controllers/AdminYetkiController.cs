using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.Enum;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
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
    public class AdminYetkiController : Controller
    {
        MyBlogSiteDB _db;
        YetkiRepository _yetkiRepo;
        ErisimAlanlariRepository _sayfalarRepo;
        YetkiErisimRepository _yetkiErisimRepo;
        UyariMesajlari uyariMesaj = new UyariMesajlari();
        UnitOfWork _unitOfWork;
        public AdminYetkiController()
        {
            _db = new MyBlogSiteDB();
            _yetkiRepo = new YetkiRepository(_db);
            _yetkiErisimRepo = new YetkiErisimRepository(_db);
            _sayfalarRepo = new ErisimAlanlariRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
        }
        // GET: AdminPanel/AdminYetki
        public ActionResult AdminYetkiIndex()
        {
            var list = _yetkiRepo.YetkiListesi();
            var list2 = _sayfalarRepo.SayfaListesi();

            var viewModel = new AnasayfaViewToplu
            {
                YetkiList = list.ToList(),
                SayfaList = list2.ToList()
            };
            return View(viewModel);
        }
        public ActionResult AdminYetkiEkle()
        {
            var sayfaList = _sayfalarRepo.SayfaListesi();
            var yetkiList = _yetkiRepo.YetkiListesi();
            var erisimList = _yetkiErisimRepo.YetkiErisimListesi();

            var viewModel = new AnasayfaViewToplu
            {
                YetkiList = yetkiList.ToList(),
                SayfaList = sayfaList.ToList(),
                ErisimList = erisimList.ToList()
            };
            return View(viewModel);
        }
        [ValidateInput(false), HttpPost]

        public ActionResult AdminYetkiEkle(string yetkiAdi, string aciklama, int[] selectedSayfalar)
        {
            var sayfaList = _sayfalarRepo.SayfaListesi();
            var yetkiList = _yetkiRepo.YetkiListesi();
            var erisimList = _yetkiErisimRepo.YetkiErisimListesi();

            var viewModel = new AnasayfaViewToplu
            {
                YetkiList = yetkiList.ToList(),
                SayfaList = sayfaList.ToList(),
                ErisimList = erisimList.ToList()
            };

            var erisimEkle = _yetkiErisimRepo.YetkiErisimEkle(aciklama);
            if (erisimEkle == DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(erisimEkle);
                return View(viewModel);
            }
            int kaydet = _unitOfWork.SaveChanges();

            var erisimIdBul = _yetkiErisimRepo.Get2(y => y.Aciklama == aciklama);
            var ekle = _yetkiRepo.YetkiEkle(yetkiAdi, erisimIdBul.YetkiErisimleriID);
            if (ekle == DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString())
            {
                ViewBag.mesaj = uyariMesaj.Hatali(ekle);
                return View(viewModel);
            }
            foreach (var item in selectedSayfalar)
            {
                var sayfa = _sayfalarRepo.Get(item);
                var sayfaEkle = _sayfalarRepo.SayfaEkle(sayfa.ControllerAdi, sayfa.ViewAdi, erisimIdBul.YetkiErisimleriID);
            }
            kaydet = _unitOfWork.SaveChanges();
            if (kaydet <= (int)DefinationMessages.Basarisiz)
            {
                ViewBag.mesaj = uyariMesaj.Hatali(DefinationMessages.Eklenirken_Hata_Olustu.ToString());
                return View(viewModel);
            }
            ViewBag.mesaj = uyariMesaj.Basarili(DefinationMessages.Ekleme_basarili.ToString()); ;
            return View(viewModel);

        }

        public ActionResult AdminYetkiGuncelle(int id)
        {

            var yetkiBul = _yetkiRepo.Get(id);
            var erisimList = _yetkiErisimRepo.Sp_YetkiErisimListesi(id).ToList();

            var viewModel = new AnasayfaViewToplu
            {
                YetkiID = yetkiBul,
                ErisimList2 = erisimList
            };
            return View(viewModel);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AdminYetkiGuncelle(int id, string yetkiAdi, bool aktifMi)
        {
            var yetkiBul = _yetkiRepo.Get(id);
            return View(yetkiBul);

        }




    }
    public class AnasayfaViewToplu
    {
        public Yetkiler YetkiID { get; set; }
        public List<Yetkiler> YetkiList { get; set; }
        public List<ErisimAlanlari> SayfaList { get; set; }
        public List<YetkiErisimleri> ErisimList { get; set; }
        public List<Sp_YetkiErisimListesiDOM> ErisimList2 { get; set; }
    }
}