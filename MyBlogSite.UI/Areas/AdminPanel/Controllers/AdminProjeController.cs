using MyBlogSite.BLL.Repositories;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.UnitOfWorkManager;
using MyBlogSite.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.UI.Areas.AdminPanel.Controllers
{
    public class AdminProjeController : Controller
    {
        MyBlogSiteDB _db;
        ProjeRepository _projeRepo;
        KategoriRepository _kategoriRepo;
        UnitOfWork _unitOfWork;
        UyariMesajlari uyariMesaj = new UyariMesajlari();
        public AdminProjeController()
        {
            _db = new MyBlogSiteDB();
            _projeRepo = new ProjeRepository(_db);
            _kategoriRepo = new KategoriRepository(_db);
            _unitOfWork = new UnitOfWork(_db);
        }
        // GET: AdminPanel/AdminProje
        public ActionResult AdminProjeIndex()
        {
            return View(_projeRepo.Sp_ProjeListesi());
        }
    }
}