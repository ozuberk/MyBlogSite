﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Tablolar
{
    public class Makaleler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MakalelerID { get; set; }

        [StringLength(250), Required]
        public string MakaleBaslik { get; set; }

        [Required]
        public string MakaleIcerik { get; set; }

        [Required]
        public DateTime EklenmeTarihi { get; set; }

        [Required]
        public bool AktifMi { get; set; }

        [Required]
        public virtual Kullanicilar Kullanicilar { get; set; }//diagram 1 lik

        public virtual Kategoriler MakaleKategorileri { get; set; }//diagram 1 lik

        public virtual List<Resimler> Resimler { get; set; }//diagram için sonsuz tarafı işaret eder
        public virtual List<Yorumlar> Yorumlar { get; set; }
    }
}
