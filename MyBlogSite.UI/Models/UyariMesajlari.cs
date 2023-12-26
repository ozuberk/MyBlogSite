using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogSite.UI.Models
{
    public class UyariMesajlari
    {

        public string Basarili(string mesaj)
        {
            return @"<div class='alert alert-success' role='alert'> " + mesaj + "</div>";

        }

        public string Hatali(string mesaj)
        {
            return @"<div class='alert alert-danger' role='alert'> " + mesaj + "</div>";
        }
    }
}