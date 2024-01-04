using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using MyBlogSite.DLL.UnitOfWorkManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Controllers
{
    public class MakaleController : Controller
    {
        YorumRepository yorumRepo;
        MakaleRepository makaleRepo;
        KategoriRepository kategoriRepo;
        KullaniciRepository kullaniciRepo;
        MyBlogSiteDB db = new MyBlogSiteDB();
        UnitOfWork unitOfWork;
        public MakaleController()
        {
            yorumRepo = new YorumRepository(db);
            makaleRepo = new MakaleRepository(db);
            kategoriRepo = new KategoriRepository(db);
            kullaniciRepo = new KullaniciRepository(db);
            unitOfWork = new UnitOfWork(db);
        }
        // GET: Makale
        public ActionResult MakaleIndex()
        {
            TempData["makaleList"] = makaleRepo.MakaleListesi(true);
            TempData["kategoriList"] = kategoriRepo.GetAll();
            TempData["_YazarList"] = kullaniciRepo.GetAll().Where(k=>k.Yetkiler.YetkilerID==1||k.Yetkiler.YetkilerID==2).ToList();
            return View();
        }
        public ActionResult MakaleDetay(int id)
        {
            var makaleGetir = makaleRepo.MakaleListesi(true).Where(m => m.MakalelerID == id).FirstOrDefault();
            var yazarGetir = kullaniciRepo.Find(k => k.KullanicilarID == makaleGetir.Kullanicilar.KullanicilarID).FirstOrDefault();
            var yorumGetir = yorumRepo.Find(y => y.Makaleler.MakalelerID == id);

            var viewModel = new ViewModeller { Makale = makaleGetir, Kullanici = yazarGetir, Yorum = yorumGetir };

            return View(viewModel);
        }
        public class ViewModeller
        {
            public Makaleler Makale { get; set; }
            public Kullanicilar Kullanici { get; set; }
            public IEnumerable<Yorumlar> Yorum { get; set; }
        }





        public ActionResult YorumEkle()
        {
            yorumRepo.YorumEkle("Makale ayrıntılı olmuş", 0, 4, 1);
            ViewBag.kayit = DBKayitSonuc();
            return View();
        }
        public string DBKayitSonuc()
        {
            int sonuc = unitOfWork.SaveChanges();
            if (sonuc > 0)
            {
                return "İşlem Başarılı";
            }
            return "İşlem Başarısız";
        }

    }
}