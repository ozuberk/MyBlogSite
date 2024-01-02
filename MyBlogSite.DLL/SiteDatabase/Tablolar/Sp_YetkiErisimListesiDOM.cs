using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.SiteDatabase.Tablolar
{
    public class Sp_YetkiErisimListesiDOM
    {
        public int YetkiErisimleriID { get; set; }
        public int ErisimAlanlariID { get; set; }
        public int YetkilerID { get; set; }
        public string YetkiAdi { get; set; }
        public string ViewAdi { get; set; }
        public string ControllerAdi { get; set; }
        public bool AktifMi { get; set; }
        public string Aciklama { get; set; }
    }
}
