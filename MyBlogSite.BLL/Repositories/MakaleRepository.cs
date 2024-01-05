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
    public class MakaleRepository : Repository<Makaleler>, IMakaleRepository
    {
        MyBlogSiteDB _db;

        public MakaleRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public string MakaleEkle(int kullanciId, int kategoriId, string makaleBaslik, string makaleIcerik)
        {
            try
            {
                Makaleler makaleEkle = new Makaleler();
                makaleEkle.Kullanicilar = _db.Kullanicilar.Where(k => k.KullanicilarID == kullanciId).FirstOrDefault();
                makaleEkle.MakaleKategorileri = _db.MakaleKategorileri.Where(k => k.KategorilerID == kategoriId).FirstOrDefault();
                makaleEkle.EklenmeTarihi = DateTime.Now;
                makaleEkle.MakaleIcerik = makaleIcerik;
                makaleEkle.MakaleBaslik = makaleBaslik;
                makaleEkle.AktifMi = true;
                Add(makaleEkle);

                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string MakaleGuncelle(int makaleId, int kategoriId, string makaleBaslik, string makaleIcerik, bool aktifMi)
        {
            var makaleGuncelle = Find(k => k.MakalelerID == makaleId).FirstOrDefault();
            try
            {
                makaleGuncelle.MakaleKategorileri = _db.MakaleKategorileri.Where(k => k.KategorilerID == kategoriId).FirstOrDefault();
                makaleGuncelle.EklenmeTarihi = DateTime.Now;
                makaleGuncelle.MakaleIcerik = makaleIcerik;
                makaleGuncelle.MakaleBaslik = makaleBaslik;
                makaleGuncelle.AktifMi = aktifMi;

                return DefinationMessages.Guncelleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Guncelleme_islemi_esnasında_hata_olustu.ToString();

            }
        }

        public IEnumerable<Makaleler> MakaleListesi()
        {
            return GetAll();
        }

        public IEnumerable<Makaleler> MakaleListesi(bool aktifMi)
        {
            return Find(k => k.AktifMi == aktifMi);
        }

        public int MakaleSayisi(int makaleId)
        {
            return Find(k => k.MakalelerID == makaleId).Count();
        }

        public string MakaleSil(int makaleId)
        {
            try
            {
                var pasifEt = Get(makaleId);
                pasifEt.AktifMi = false;
                return DefinationMessages.Pasif_Basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Pasif_Edilirken_Hata_Olustu.ToString();
            }

        }

        public IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi()
        {
            var getSP = _db.Sp_MakaleListesi().ToList();
            return getSP;
        }

        public IEnumerable<Sp_MakaleListesiDOM> Sp_MakaleListesi(bool aktifMi)
        {
          var getSP=  _db.Sp_MakaleListesi().Where(k=>k.AktifMi== aktifMi).ToList();
            return getSP;
        }
       
    }
}
