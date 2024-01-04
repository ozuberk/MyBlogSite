using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminAnasayfaController : Controller
    {
        MyBlogSiteDB _db;
        MakaleRepository _makaleRepo;
        KullaniciRepository _kullaniciRepo;
        ProjeRepository _projeRepo;
        YetkiRepository _yetkiRepo;
        public AdminAnasayfaController()
        {
            _db = new MyBlogSiteDB();
            _makaleRepo = new MakaleRepository(_db);
            _kullaniciRepo = new KullaniciRepository(_db);
            _projeRepo = new ProjeRepository(_db);
            _yetkiRepo=new YetkiRepository(_db);
        }
        // GET: AdminPanel/AdminAnasayfa
        public ActionResult AdminAnasayfaIndex()
        {
            TempData["makaleSayisi"] = _makaleRepo.MakaleListesi().Count();
            TempData["projeSayisi"] = _projeRepo.ProjeListesi().Count();
            TempData["kullaniciSayisi"] = _kullaniciRepo.KullaniciListesi().Count();
            Yetkiler yetki = new Yetkiler();
            yetki.YetkilerID = 2;
            TempData["yazarSayisi"] = _kullaniciRepo.KullaniciListesi().Where(k=>k.Yetkiler.YetkilerID==2).Count();

            return View();
        }
    }
}