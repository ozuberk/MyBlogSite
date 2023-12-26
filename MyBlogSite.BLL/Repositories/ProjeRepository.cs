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
    public class ProjeRepository:Repository<Projeler>,IProjeRepository
    {
        MyBlogSiteDB _db;

        public ProjeRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public string ProjeEkle(int yazarId, int kategoriId, string projeAdi, string projeLinki)
        {
            try
            {
                Projeler projeEkle = new Projeler();
                projeEkle.ProjeKategorileri = _db.MakaleKategorileri.Where(k => k.KategorilerID == kategoriId).FirstOrDefault();
                projeEkle.EklenmeTarihi = DateTime.Now;
                projeEkle.ProjeAdi = projeAdi;
                projeEkle.ProjeLinki = projeLinki;
                projeEkle.AktifMi = false;
                Add(projeEkle);

                return DefinationMessages.Ekleme_basarili.ToString();
            }
            catch (Exception)
            {
                return DefinationMessages.Ekleme_islemi_esnasında_hata_olustu.ToString();
            }
        }

        public string ProjeGuncelle(int projeId, int yazarId, int kategoriId, string projeAdi, string projeLinki, bool aktifMi, int onaylayanKullaniciId)
        {
            var projeGuncelle = Find(k => k.ProjelerID == projeId).FirstOrDefault();
            try
            {
                projeGuncelle.ProjeKategorileri = _db.MakaleKategorileri.Where(k => k.KategorilerID == kategoriId).FirstOrDefault();
                projeGuncelle.EklenmeTarihi = DateTime.Now;
                projeGuncelle.ProjeAdi = projeAdi;
                projeGuncelle.ProjeLinki = projeLinki;
                projeGuncelle.AktifMi = aktifMi;
                Update(projeGuncelle);//????

                return "Güncelleme başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme işlemi esnasında hata oluştu";
            }
        }

        public IEnumerable<Projeler> ProjeListesi()
        {
            return GetAll();
        }

        public IEnumerable<Projeler> ProjeListesi(bool aktifMi)
        {
            return Find(k => k.AktifMi == aktifMi);
        }

        public string ProjeSil(int projeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sp_ProjeListesiDOM> Sp_ProjeListesi()
        {
            var getSP = _db.Sp_ProjeListesi().ToList();
            return getSP;
        }

        public IEnumerable<Sp_ProjeListesiDOM> Sp_ProjeListesi(bool aktifMi)
        {
            var getSP = _db.Sp_ProjeListesi().Where(k => k.AktifMi == aktifMi).ToList();
            return getSP;
        }
    }
}
