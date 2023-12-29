using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Controllers
{
    public class KullaniciController : Controller
    {
        MyBlogSiteDB _db;
        KullaniciRepository _kullaniciRepo;
        public KullaniciController()
        {
            _db = new MyBlogSiteDB();
            _kullaniciRepo = new KullaniciRepository(_db);
        }
        // GET: Kullanici
        public ActionResult GirisIndex(int makaleId=0)
        {
            if (makaleId>0)
            {
                TempData["makaleID"] = makaleId;
            }
            return View();
        }

        [HttpPost]
        public ActionResult GirisIndex(string kullaniciAdi, string sifre)
        {
            var kullaniciGiris = _kullaniciRepo.Giris(kullaniciAdi, sifre);

            if (kullaniciGiris != null)
            {
                Session.Add("userName", kullaniciAdi); //Session oluşturma
                Session.Add("userID", kullaniciGiris.KullanicilarID);
                //var login = Session["userName"]; //oluşturulan Session'u kullanma
                if ((int)TempData["makaleID"]!=0)
                {
                return RedirectToAction("MakaleDetay", "Makaleler",new { id = TempData["makaleID"] });
                }
                return RedirectToAction("AnasayfaIndex", "Anasayfa");
            }
            return View();
        }
    }
}