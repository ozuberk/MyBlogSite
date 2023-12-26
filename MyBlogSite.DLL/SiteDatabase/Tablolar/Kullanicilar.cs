using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Kullanicilar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KullanicilarID { get; set; }

        [StringLength(100), Required]
        public string Adi { get; set; }

        [StringLength(100), Required]
        public string Soyadi { get; set; }

        [StringLength(100), Required]
        public string KullaniciAdi { get; set; }

        [StringLength(100), Required]
        public string KullaniciSifresi { get; set; }
        [StringLength(100), Required]
        public string email { get; set; }
        public string twitter { get; set; }
        public string github { get; set; }
        public string linkedln { get; set; }
        public string meslek { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        public DateTime PasiflikTarihi { get; set; }
        public string YasadigiUlke { get; set; }
        public string YasadigiSehir { get; set; }
        public string KisacaHakkinda { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        public virtual List<Makaleler> Makeleler { get; set; }
        public virtual List<Projeler> Projeler { get; set; }

        public virtual List<Resimler> Resimler { get; set; }
        public virtual Yetkiler Yetkiler { get; set; }

        public virtual List<Yorumlar> Yorumlar { get; set; }

    }
}
