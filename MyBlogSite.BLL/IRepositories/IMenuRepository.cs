using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IMenuRepository:IRepository<Menu>
    {
        string MenuEkle(string menuAdi, int ustMenuID, string aciklama);
        string MenuGuncelle(int menuID, string menuAdi, int ustMenuID, string aciklama);
        string MenuSil(int menuID);
        IEnumerable<Menu> MenulerListesi();
    }
}
