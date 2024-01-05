using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Projeler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjelerID { get; set; }

        [StringLength(250), Required]
        public string ProjeAdi { get; set; }

        [Required]
        public string ProjeLinki { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        [Required]
        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual Kategoriler ProjeKategorileri { get; set; }

        public virtual List<Yorumlar> Yorumlar { get; set; }
    }
}
