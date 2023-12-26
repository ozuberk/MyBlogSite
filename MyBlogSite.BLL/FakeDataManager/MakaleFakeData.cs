using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.FakeDataManager
{
    public class MakaleFakeData
    {
        public void FakeMakaleEkle()
        {
            MyBlogSiteDB db = new MyBlogSiteDB();

            if (db.Makaleler.ToList().Count > 10)
            {
                return;
            }
            for (int i = 0; i <= 15; i++)
            {
                Makaleler makaleler = new Makaleler();
                makaleler.AktifMi = true;
                makaleler.EklenmeTarihi = DateTime.Now;
                makaleler.MakaleIcerik = FakeData.TextData.GetSentences(1000);
                makaleler.MakaleBaslik = FakeData.NameData.GetCompanyName();

                makaleler.Kullanicilar.KullanicilarID = db.Kullanicilar.Where(k => k.Yetkiler.YetkiAdi == "Admin").FirstOrDefault().KullanicilarID;//??

                makaleler.MakaleKategorileri = db.MakaleKategorileri.ToList().First();
                db.Makaleler.Add(makaleler);
            }

            db.SaveChanges();
        }
    }
}
