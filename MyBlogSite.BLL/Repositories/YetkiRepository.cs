using MyBlogSite.BLL.IRepositories;
using MyBlogSite.DLL.Enum;
using MyBlogSite.DLL.ORMManager;
using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.Repositories
{
    public class YetkiRepository : Repository<Yetkiler>, IYetkiRepository
    {
        MyBlogSiteDB _db;
        public YetkiRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public string YetkiEkle(string yetkiAdi, int erisimID)
        {
            try
            {
                YetkiErisimleri yetkiErisimSayfalari = new YetkiErisimleri { YetkiErisimleriID = erisimID };

                Yetkiler yetkiEkle = new Yetkiler();
                yetkiEkle.YetkiAdi= yetkiAdi;
                yetkiEkle.AktifMi = true;
                yetkiEkle.YetkiErisimleri = yetkiErisimSayfalari;

                Add(yetkiEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();

            }
        }

        public string YetkiGuncelle(int yetkiId, string yetkiAdi,bool aktifMi)
        {
            var yetkiGuncelle=Find(y=>y.YetkilerID==yetkiId).FirstOrDefault();
            try
            {
                yetkiGuncelle.YetkiAdi = yetkiAdi;
                yetkiGuncelle.AktifMi= aktifMi;
                //Update(yetkiGuncelle);
                return DefinationMessages.Guncelleme_basarili.ToString();

            }
            catch (Exception)
            {
                return DefinationMessages.Guncelleme_islemi_esnasında_hata_olustu.ToString();

            }
        }

        public IEnumerable<Yetkiler> YetkiListesi()
        {
            return GetAll();
        }

        public IEnumerable<Yetkiler> YetkiListesiAdminHaric()
        {
            return Find(k => k.YetkilerID != 1);
        }

        public int YetkiSayisi(int yetkiId)
        {
            return Find(k => k.YetkilerID == yetkiId).Count();

        }

        public string YetkiSil(int yetkiId)
        {
            try
            {
                var pasitEt = Get(yetkiId);
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
