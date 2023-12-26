using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Resimler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResimlerID { get; set; }

        public string BuyukResimKonumu { get; set; }

        public string KucukResimKonumu { get; set; }

        [StringLength(250), Required]
        public string Baslik { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        public bool AktifMi { get; set; }
        //1.Güvenlik
        //2.tek bir yerden yönetilmek
        public virtual Makaleler Makaleler { get; set; }
        public virtual Projeler Projeler { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
