using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.Enum
{
    public enum DefinationMessages
    {
        Eklenirken_Hata_Olustu = 0,
        Basarisiz = -1,
        Basarili = 1,
        TopluKaydet=2,
        TopluGuncelle=3,
        SilmeHatasi=4,

        Ekleme_islemi_esnasında_hata_olustu = 5,
        Ekleme_basarili = 6,

        Guncelleme_basarili = 7,
        Guncelleme_islemi_esnasında_hata_olustu = 8,

        Pasif_Basarili = 9,
        Pasif_Edilirken_Hata_Olustu = 10
    }
}
