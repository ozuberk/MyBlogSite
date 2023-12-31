﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogSite.DLL.SiteDatabase.Tablolar;

namespace MyBlogSite.DLL.Tablolar
{
    public class Yetkiler
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YetkilerID { get; set; }

        [StringLength(200), Required]
        public string YetkiAdi { get; set; }
        [Required]
        public bool AktifMi { get; set; }

        public virtual List<Kullanicilar> KullaniciID { get; set; }
        public virtual YetkiErisimleri YetkiErisimleri { get; set; }
    }
}
