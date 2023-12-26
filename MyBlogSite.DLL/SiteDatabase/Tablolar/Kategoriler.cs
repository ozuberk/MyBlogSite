using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Kategoriler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KategorilerID { get; set; }

        [StringLength(200), Required]
        public string KategoriAdi { get; set; }

        public string Aciklama { get; set; }
        [Required]
        public bool AktifMi { get; set; }

        public virtual List<Makaleler> Makaleler { get; set; }
        public virtual List<Projeler> Projeler { get; set; }
    }
}
