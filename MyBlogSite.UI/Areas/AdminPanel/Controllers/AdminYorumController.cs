using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminYorumController : Controller
    {
        // GET: AdminPanel/AdminYorum
        public ActionResult AdminYorumIndex()
        {
            return View();
        }
    }
}