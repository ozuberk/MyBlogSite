using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
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
        public AdminYetkiController()
        {
            _db = new MyBlogSiteDB();
            _yetkiRepo=new YetkiRepository(_db);
        }
        // GET: AdminPanel/AdminYetki
        public ActionResult AdminYetkiIndex()
        {
            return View(_yetkiRepo.YetkiListesi());
        }
        public ActionResult AdminYetkiEkle()
        {
            return View();
        }
    }
}