using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Menu
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenulerID { get; set; }

        [StringLength(250), Required]
        public string MenuAdi { get; set; }

        [Required]
        public int UstMenuID { get; set; }
        [Required]
        public bool AktifMi { get; set; }

        [Required]
        public string Aciklama { get; set; }

    }
}
