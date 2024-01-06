using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Controllers
{
    public class HakkimdaController : Controller
    {
        MyBlogSiteDB db;
        KullaniciRepository kullaniciRepository;
        public HakkimdaController()
        {

            db = new MyBlogSiteDB();
            kullaniciRepository = new KullaniciRepository(db);
        }
        // GET: Hakkimda
        public ActionResult HakkimdaIndex()
        {
            ViewBag.Kullanicilar = kullaniciRepository.KullaniciListesi().Where(k => k.Yetkiler.YetkilerID == 1 || k.Yetkiler.YetkilerID == 2);
            return View(kullaniciRepository.Get(1));
        }
    }
}