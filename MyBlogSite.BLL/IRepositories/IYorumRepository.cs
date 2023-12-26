using MyBlogSite.DLL.RepositoryManager;
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
        int ProjeYorumSayisi(int projeID);
        int AltYorumSayisi(int yorumID);
        string YorumEkle(string yorum,int yorumUstId,int kullaniciID,int makalelerID);
        string YorumGuncelle(int yorumlarID,string yorum,int yorumUstId,int kullaniciID,int makalelerID);
        string YorumSil(int yorumlarID);
        IEnumerable<Yorumlar> YorumListesi();
        IEnumerable<Yorumlar> YorumListesi(bool aktifMi);
        IEnumerable<Yorumlar> MakaleYorumListesi(int makaleID);
        IEnumerable<Yorumlar> ProjeYorumListesi(int projeID);
    }
}
