using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.SiteDatabase.Tablolar
{
    public class Sp_MakaleListesiDOM
    {
        public int MakalelerID { get; set; }
        public string KategoriAdi { get; set; }
        public string MakaleBaslik { get; set; }
        public string MakaleIcerik { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool AktifMi { get; set; }
        public string YazarAdSoyad { get; set; }
    }
}
