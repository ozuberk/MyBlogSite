using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.SiteDatabase.Tablolar
{
    public class ErisimAlanlari
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ErisimAlanlariID { get; set; }
        [StringLength(250), Required]
        public string ControllerAdi { get; set; }
        [StringLength(250), Required]
        public string ViewAdi { get; set; }
        public string Aciklama { get; set; }
        [Required]
        public bool AktifMi { get; set; }
        public virtual YetkiErisimleri YetkiErisimleri { get; set; }
    }
}
