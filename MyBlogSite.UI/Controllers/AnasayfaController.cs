using MyBlogSite.BLL.Manager;
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
        // GET: Anasayfa
        public ActionResult AnasayfaIndex()
        {
            //MyBlogSiteDB db = new MyBlogSiteDB();

            //MakaleManager makaleManager = new MakaleManager();
            //makaleManager.MakaleListesi();



            return View();
        }
    }
}