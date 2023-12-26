using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminMenuController : Controller
    {
        // GET: AdminPanel/AdminMenu
        public ActionResult AdminMenuIndex()
        {
            return View();
        }
    }
}