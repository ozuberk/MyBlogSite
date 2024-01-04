using MyBlogSite.BLL.IRepositories;
using MyBlogSite.DLL.Enum;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.Repositories
{
    public class ErisimAlanlariRepository : Repository<ErisimAlanlari>, IErisimAlanlari
    {
        MyBlogSiteDB _db;
        public ErisimAlanlariRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public string SayfaEkle(string controllerAdi, string viewAdi, string aciklama)
        {
            try
            {
                ErisimAlanlari sayfaEkle = new ErisimAlanlari();
                sayfaEkle.ControllerAdi = controllerAdi;
                sayfaEkle.ViewAdi = viewAdi;
                sayfaEkle.Aciklama = aciklama;

                Add(sayfaEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string SayfaEkle(string controllerAdi, string viewAdi, int yetkiErisimID)
        {
            try
            {
                ErisimAlanlari sayfaEkle = new ErisimAlanlari();
                YetkiErisimRepository bul = new YetkiErisimRepository(_db);
                var erisimId = bul.Get(yetkiErisimID);
                sayfaEkle.ControllerAdi = controllerAdi;

                sayfaEkle.ViewAdi = viewAdi;
                sayfaEkle.AktifMi = false;
                sayfaEkle.YetkiErisimleri = erisimId;

                Add(sayfaEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string SayfaGuncelle(int sayfalarId, string controllerAdi, string viewAdi, string aciklama, int yetkiErisimID, bool aktifMi)
        {
            var sayfaGuncelle = Find(k => k.ErisimAlanlariID == sayfalarId).FirstOrDefault();

            try
            {
                sayfaGuncelle.ControllerAdi = controllerAdi;
                sayfaGuncelle.ViewAdi = viewAdi;
                sayfaGuncelle.Aciklama = aciklama;
                sayfaGuncelle.YetkiErisimleri.YetkiErisimleriID = yetkiErisimID;
                sayfaGuncelle.AktifMi = aktifMi;

                return DefinationMessages.Ekleme_basarili.ToString();

            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string SayfaEkleGuncelle(int sayfalarID)
        {
            var sayfaGuncelle = Find(k => k.ErisimAlanlariID == sayfalarID).FirstOrDefault();

            try
            {
                sayfaGuncelle.AktifMi = true;
                return DefinationMessages.Ekleme_basarili.ToString();

            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }
        public IEnumerable<ErisimAlanlari> SayfaListesi()
        {
            //return GetAll2();
            return GetAll(k => k.YetkiErisimleri.YetkiErisimleriID == null);
        }

        public IEnumerable<ErisimAlanlari> SayfaListesi(bool aktifMi)
        {
            return GetAll(k => k.AktifMi == aktifMi);
        }

        public string SayfaSil(int sayfalarId)
        {
            try
            {
                var pasitEt = Get(sayfalarId);
                pasitEt.AktifMi = false;
                return DefinationMessages.Pasif_Basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Pasif_Edilirken_Hata_Olustu.ToString();
            }
        }
    }
}
