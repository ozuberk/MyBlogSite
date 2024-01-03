using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.SiteDatabase.Tablolar
{
    public class Sp_YorumListesiDOM
    {
        public int YorumlarID { get; set; }
        public int KullanicilarID { get; set; }
        public int Makaleler_MakalelerID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public bool AktifMi { get; set; }
        public string Yorum { get; set; }
        public int YorumUstId { get; set; }
        public DateTime YorumTarihi { get; set; }
    }
}
