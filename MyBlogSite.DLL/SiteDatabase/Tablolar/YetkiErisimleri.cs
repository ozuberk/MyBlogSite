using MyBlogSite.DLL.Tablolar;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.SiteDatabase.Tablolar
{
    public class YetkiErisimleri
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YetkiErisimleriID { get; set; }
        [Required]
        public bool AktifMi { get; set; }

        public string Aciklama { get; set; }
        public virtual List<Yetkiler> Yetkiler { get; set; }
        public virtual List<ErisimAlanlari> ErisimAlanlari { get; set; }
    }
}
