using MyBlogSite.BLL.IRepositories;
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
    public class YorumRepository : Repository<Yorumlar>, IYorumRepository
    {
        MyBlogSiteDB _db;
        public YorumRepository(MyBlogSiteDB context) : base(context)
        {
            _db = context;
        }

        public int AltYorumSayisi(int yorumID)
        {
            return Find(y => y.YorumlarID == yorumID).Count();
        }

        public IEnumerable<Yorumlar> MakaleYorumListesi(int makaleID)
        {
            var getir = Find(k => k.Makaleler.MakalelerID == makaleID);
            return getir;
        }

        public int MakaleYorumSayisi(int makaleID)
        {
            return Find(y => y.Makaleler.MakalelerID == makaleID).Count();

        }

        public IEnumerable<Yorumlar> ProjeYorumListesi(int projeID)
        {
            var getir = Find(k => k.Projeler.ProjelerID == projeID);
            return getir;
        }

        public int ProjeYorumSayisi(int projeID)
        {
            return Find(y => y.Projeler.ProjelerID == projeID).Count();
        }

        public string YorumEkle(string yorum, int yorumUstId, int kullaniciID, int makalelerID)
        {
            try
            {
                Yorumlar yorumEkle = new Yorumlar();
                yorumEkle.Yorum = yorum;
                yorumEkle.YorumTarihi = DateTime.Now;
                yorumEkle.YorumUstId = yorumUstId;
                yorumEkle.Kullanicilar = _db.Kullanicilar.Where(k => k.KullanicilarID == kullaniciID).FirstOrDefault();
                yorumEkle.Makaleler = _db.Makaleler.Where(k => k.MakalelerID == makalelerID).FirstOrDefault();
                Add(yorumEkle);
                return "Ekleme Başarılı";
            }
            catch (Exception)
            {
                return "Ekleme İşlemi Esnasında Hata Oluştu";
            }
        }

        public string YorumGuncelle(int yorumlarID, string yorum, int yorumUstId, int kullaniciID, int makalelerID)
        {
            var yorumGuncelle = Find(y => y.YorumlarID == yorumlarID).FirstOrDefault();
            try
            {
                yorumGuncelle.Yorum = yorum;
                yorumGuncelle.YorumTarihi = DateTime.Now;
                yorumGuncelle.YorumUstId = yorumUstId;
                yorumGuncelle.Kullanicilar = _db.Kullanicilar.Where(k => k.KullanicilarID == kullaniciID).FirstOrDefault();
                yorumGuncelle.Makaleler = _db.Makaleler.Where(k => k.MakalelerID == makalelerID).FirstOrDefault();

                Update(yorumGuncelle);
                return "Güncelleme Başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme İşlemi Esnasında Hata Oluştu";
            }
        }

        public IEnumerable<Yorumlar> YorumListesi()
        {
            return GetAll();
        }

        public IEnumerable<Yorumlar> YorumListesi(bool aktifMi)
        {
            return Find(y => y.AktifMi == aktifMi);
        }

        public string YorumSil(int yorumlarID)
        {
            throw new NotImplementedException();
        }
    }
}
