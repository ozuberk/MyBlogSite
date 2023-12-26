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

        public DbSet<Yorumlar> Yorumlar { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }
        public DbSet<Kategoriler> MakaleKategorileri { get; set; }
        public DbSet<Makaleler> Makaleler { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Resimler> Resimler { get; set; }
        public DbSet<Yetkiler> Yetkiler { get; set; }
        public DbSet<Projeler> Projeler { get; set; }

        /// <summary>
        /// Db de olan Sp_MakaleListesi adlı Spyi çağırır.
        /// </summary>
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

    }
    public class CreateDB : CreateDatabaseIfNotExists<MyBlogSiteDB>
    {

        public override void InitializeDatabase(MyBlogSiteDB context)//DB oluşurken çalışacak method
        {
            //Makaleler tablosunun herhangi bir kolonu için işlem gerekirse bu ksımdan ayar yapılır
            base.InitializeDatabase(context);
        }


        protected override void Seed(MyBlogSiteDB context)//DB oluştuktan sonra çalışan method
        {
            base.Seed(context);
        }
    }
}

