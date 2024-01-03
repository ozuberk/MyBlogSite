using MyBlogSite.DLL.RepositoryManager;
using MyBlogSite.DLL.SiteDatabase.Tablolar;
using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.BLL.IRepositories
{
    public interface IYorumRepository:IRepository<Yorumlar>
    {
        int MakaleYorumSayisi(int makaleID);
        int AltYorumSayisi(int yorumID);
        string YorumEkle(string yorum,int yorumUstId,int kullaniciID,int makalelerID);
        string YorumGuncelle(int yorumlarID,string yorum,bool aktifMi);
        string YorumSil(int yorumlarID);
        IEnumerable<Yorumlar> YorumListesi();
        IEnumerable<Yorumlar> YorumListesi(bool aktifMi);
        IEnumerable<Yorumlar> MakaleYorumListesi(int makaleID);
        IEnumerable<Sp_YorumListesiDOM> Sp_YorumListesi();
        IEnumerable<Sp_YorumListesiDOM> Sp_YorumListesi(bool aktifMi);
        IEnumerable<Sp_YorumListesiDOM> MakaleYorumlari(int makaleID);
        IEnumerable<Sp_YorumListesiDOM> MakaleAltYorumlari(int makaleID);

    }
}
