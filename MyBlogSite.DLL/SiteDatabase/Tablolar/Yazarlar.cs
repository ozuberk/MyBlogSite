using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Yazarlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YazarlarID { get; set; }

        [StringLength(100), Required]
        public string email { get; set; }

        [Required]
        public string KisacaHakkinda { get; set; }
        public string CalistigiFirma { get; set; }
        public string YasadigiUlke { get; set; }
        public string YasadigiSehir { get; set; }
        [Required]
        public bool AktifMi { get; set; }

        public virtual List<Makaleler> Makeleler { get; set; }//diagram sonsuz taraf
        public virtual List<Projeler> Projeler { get; set; }//diagram sonsuz taraf
        public virtual Kullanicilar Kullanicilar { get; set; }//diagram sonsuz taraf
    }
}
