using MyBlogSite.DLL.SiteDatabase;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.ORMManager
{
    public class MyBlogSiteDB : DbContext
    {

        public DbSet<ErisimAlanlari> ErisimAlanlari { get; set; }
        public DbSet<Kategoriler> MakaleKategorileri { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Makaleler> Makaleler { get; set; }
        public DbSet<Projeler> Projeler { get; set; }
        public DbSet<YetkiErisimleri> YetkiErisimleri { get; set; }
        public DbSet<Yetkiler> Yetkiler { get; set; }
        public DbSet<Yorumlar> Yorumlar { get; set; }


        public IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi()
        {
            var getSp = Database.SqlQuery<Sp_MakaleListesiDOM>("EXEC Sp_MakaleListesi");
            return getSp.ToList();
        }
        public IEnumerable<Sp_ProjeListesiDOM> Sp_ProjeListesi()
        {
            var getSp = Database.SqlQuery<Sp_ProjeListesiDOM>("EXEC Sp_ProjeListesi");
            return getSp.ToList();
        }
        public IEnumerable<Sp_YorumListesiDOM> Sp_YorumListesi()
        {
            var getSp = Database.SqlQuery<Sp_YorumListesiDOM>("EXEC Sp_YorumListesi");
            return getSp.ToList();
        }
        public IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi()
        {
            var getSp = Database.SqlQuery<Sp_YetkiErisimListesiDOM>("EXEC Sp_YetkiErisimListesi");
            return getSp.ToList();
        }

    }
    public class CreateDB : CreateDatabaseIfNotExists<MyBlogSiteDB>
    {

        public override void InitializeDatabase(MyBlogSiteDB context)
        {
            base.InitializeDatabase(context);
        }


        protected override void Seed(MyBlogSiteDB context)
        {
            base.Seed(context);
        }
    }
}

