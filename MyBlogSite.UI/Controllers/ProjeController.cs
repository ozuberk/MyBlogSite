using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Controllers
{
    public class ProjeController : Controller
    {
        MyBlogSiteDB _db=new MyBlogSiteDB();
        ProjeRepository _projeRepo;
        public ProjeController()
        {
          _projeRepo=new ProjeRepository(_db);
        }
        // GET: Proje
        public ActionResult ProjeIndex()
        {
            TempData["projeList"] = _projeRepo.Sp_ProjeListesi(true);
            return View();
        }
    }
}