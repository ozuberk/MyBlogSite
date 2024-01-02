using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.SiteDatabase.Tablolar
{
    public class Sp_ProjeListesiDOM
    {
        public int ProjelerID { get; set; }
        public string KategoriAdi { get; set; }
        public string ProjeAdi { get; set; }
        public string ProjeLinki { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string ProjeSahibiAdSoyad { get; set; }
    }
}
