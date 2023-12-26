using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminKullaniciController : Controller
    {
        // GET: AdminPanel/AdminKullanici
        public ActionResult AdminKullaniciIndex()
        {
            return View();
        }
    }
}