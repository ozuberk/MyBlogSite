using MyBlogSite.BLL.IRepositories;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.Repositories
{
    public class MenuRepository:Repository<Menu>,IMenuRepository
    {
        MyBlogSiteDB _db;

        public MenuRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public string MenuEkle(string menuAdi, int ustMenuID, string aciklama)
        {
            try
            {
                Menu menu = new Menu();
                menu.MenuAdi = menuAdi;
                menu.UstMenuID = ustMenuID;
                menu.Aciklama = aciklama;

                Add(menu);
                return "İşlem Başarılı";
            }
            catch (Exception)
            {

                return "Ekleme sırasında hata oluştu";
            }
        }

        public string MenuGuncelle(int menuID, string menuAdi, int ustMenuID, string aciklama)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Menu> MenulerListesi()
        {
            throw new NotImplementedException();
        }

        public string MenuSil(int menuID)
        {
            throw new NotImplementedException();
        }
    }
}
