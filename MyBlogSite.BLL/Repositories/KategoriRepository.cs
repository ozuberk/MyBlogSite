using MyBlogSite.BLL.IRepositories;
using MyBlogSite.DLL.Enum;
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
    public class KategoriRepository:Repository<Kategoriler>,IKategoriRepository
    {
        MyBlogSiteDB _db;

        public KategoriRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public string KategoriEkle(string kategoriAdi, string aciklama)
        {
            try
            {
                Kategoriler kategoriEkle = new Kategoriler();
                kategoriEkle.KategoriAdi = kategoriAdi;
                kategoriEkle.Aciklama = aciklama;
                Add(kategoriEkle);
                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string KategoriGuncelle(int kategoriID, string kategoriAdi, string aciklama,bool aktifMi)
        {
            var kategoriGuncelle = Find(k => k.KategorilerID == kategoriID).FirstOrDefault();
            try
            {
                kategoriGuncelle.KategoriAdi = kategoriAdi;
                kategoriGuncelle.Aciklama = aciklama;
                kategoriGuncelle.AktifMi= aktifMi;
                Update(kategoriGuncelle);
                return "Kategori ekleme başarılı";

            }
            catch (Exception)
            {
                return "Kategori ekleme esnasında bir hata oluştu";
            }
        }

        public IEnumerable<Kategoriler> KategoriListele()
        {
            return GetAll();
        }

        public IEnumerable<Kategoriler> KategoriListele(bool aktifMi)
        {
            return Find(k => k.AktifMi == aktifMi);
        }

        public int KategoriSayisi(int kategoriID)
        {
            return Find(k => k.KategorilerID == kategoriID).Count();
        }

        public string KategoriSil(int kategoriID)
        {
            throw new NotImplementedException();
        }
    }
}
