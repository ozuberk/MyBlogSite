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
    public class YetkiErisimRepository : Repository<YetkiErisimleri>, IYetkiErisimRepository
    {
        MyBlogSiteDB _db;
        public YetkiErisimRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }
        public IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi()
        {
            var getSP = _db.Sp_YetkiErisimListesi().ToList();
            return getSP;
        }

        public IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi(bool aktifMi)
        {
            var getSP = _db.Sp_YetkiErisimListesi().Where(k => k.AktifMi == aktifMi).ToList();
            return getSP;
        }

        public IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi(int yetkiID)
        {
            var getSP = _db.Sp_YetkiErisimListesi().Where(k => k.YetkilerID == yetkiID).ToList();
            return getSP;
        }

        public IEnumerable<Sp_YetkiErisimListesiDOM> Sp_YetkiErisimListesi(int yetkiID, bool aktifMi)
        {
            var getSP = _db.Sp_YetkiErisimListesi().Where(k => k.YetkilerID == yetkiID && k.AktifMi == aktifMi).ToList();
            return getSP;
        }

        public string YetkiErisimEkle(string aciklama)
        {
            try
            {
                YetkiErisimleri yetkiErisimEkle = new YetkiErisimleri();
                yetkiErisimEkle.Aciklama = aciklama;
                yetkiErisimEkle.AktifMi = true;

                Add(yetkiErisimEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string YetkiErisimGuncelle(int yetkiErisimId, string aciklama, bool aktifMi)
        {
            var yetkiErisimGuncelle = Find(k => k.YetkiErisimleriID == yetkiErisimId).FirstOrDefault();
            try
            {
                yetkiErisimGuncelle.Aciklama = aciklama;
                yetkiErisimGuncelle.AktifMi = aktifMi;

                return DefinationMessages.Guncelleme_basarili.ToString();

            }
            catch (Exception)
            {
                return DefinationMessages.Guncelleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public IEnumerable<YetkiErisimleri> YetkiErisimListesi()
        {
            return GetAll();
        }

        public IEnumerable<YetkiErisimleri> YetkiErisimListesi(bool aktifMi)
        {
            return GetAll(k => k.AktifMi == aktifMi);
        }

        public string YetkiErisimSil(int yetkiErisimId)
        {
            try
            {
                var pasitEt = Get(yetkiErisimId);
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
