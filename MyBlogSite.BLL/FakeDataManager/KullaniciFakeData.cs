using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.FakeDataManager
{
    public class KullaniciFakeData
    {
        public void FakeKullaniciEkle()
        {
            MyBlogSiteDB db = new MyBlogSiteDB();
            if (db.Kullanicilar.ToList().Count > 5)
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                Kullanicilar kullanicilar = new Kullanicilar();
                string ad = FakeData.NameData.GetFirstName();
                kullanicilar.Adi = ad;
                kullanicilar.Soyadi = FakeData.NameData.GetSurname();
                kullanicilar.KullaniciAdi = ad;
                kullanicilar.KullaniciSifresi = FakeData.ArrayData.GetElement(i).ToString();
                kullanicilar.EklenmeTarihi = DateTime.Now;
                kullanicilar.PasiflikTarihi = DateTime.Now;
                kullanicilar.AktifMi = true;
                kullanicilar.Yetkiler = db.Yetkiler.FirstOrDefault();
                db.Kullanicilar.Add(kullanicilar);
            }
            db.SaveChanges();
        }
    }
}
