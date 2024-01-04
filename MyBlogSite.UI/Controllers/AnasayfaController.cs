using MyBlogSite.BLL.Manager;
using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Controllers
{
    public class AnasayfaController : Controller
    {
        MyBlogSiteDB db;
        KullaniciRepository kullaniciRepository;
        public AnasayfaController()
        {
            db = new MyBlogSiteDB();
            kullaniciRepository=new KullaniciRepository(db);
        }
        // GET: Anasayfa
        public ActionResult AnasayfaIndex()
        {
            MyBlogSiteDB db = new MyBlogSiteDB();

            MakaleManager makaleManager = new MakaleManager();
            makaleManager.MakaleListesi();

            return View(kullaniciRepository.Get(2));
        }
    }
}