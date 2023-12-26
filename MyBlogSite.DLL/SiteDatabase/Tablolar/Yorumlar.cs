using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Yorumlar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YorumlarID { get; set; }

        [Required]
        public string Yorum { get; set; }

        [Required]
        public DateTime YorumTarihi { get; set; }

        [Required]
        public int YorumUstId { get; set; }
        [Required]
        public bool AktifMi { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual Makaleler Makaleler { get; set; }
        public virtual Projeler Projeler { get; set; }
    }
}
