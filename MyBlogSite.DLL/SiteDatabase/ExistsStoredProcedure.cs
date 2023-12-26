using MyBlogSite.DLL.ORMManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DLL.SiteDatabase
{
    public class ExistsStoredProcedure
    {
        MyBlogSiteDB db = new MyBlogSiteDB();
        /// <summary>
        /// SqlDe yazdığımız spnin aynısını yapacağız
        /// </summary>
        public string Sp_MakaleListesi()
        {
            try
            {
                string sql = @"
            create proc Sp_MakaleListesi
            as
            begin
            select 
            m.MakalelerID,
            ka.KategoriAdi,
            m.MakaleBaslik,
            m.MakaleIcerik,
            m.EklenmeTarihi,
            m.AktifMi
            ,k.Adi+' '+k.Soyadi as YazarAdSoyad
            --k.Adi+' '+k.Soyadi as Yazar
            from Makalelers				as m
            join Kullanicilars			as k	on m.Kullanicilar_KullanicilarID=k.KullanicilarID
            join Kategorilers	as ka	on ka.KategorilerID=m.MakaleKategorileri_KategorilerID
            end
            ";
                var list = db.Database.ExecuteSqlCommand(sql);//sp create etme

                return "Sp_MakaleListesi Başarılı bir şekilde oluşturuldu";

            }
            catch (Exception ex)
            {
                return "Hata : " + ex.Message;
            }
        }
        public string Sp_ProjeListesi()
        {
            try
            {
                string sql = @"
            create proc Sp_ProjeListesi
            as
            begin
            select 
            p.ProjelerID,
            ka.KategoriAdi,
            p.ProjeAdi,
            p.ProjeLinki,
            p.EklenmeTarihi,
            p.AktifMi
            ,k.Adi+' '+k.Soyadi as ProjeSahibiAdSoyad
            from Projelers				as p
            join Kullanicilars			as k	on p.Kullanicilar_KullanicilarID=k.KullanicilarID
            join Kategorilers	as ka	on ka.KategorilerID=p.ProjeKategorileri_KategorilerID
            end
            ";
                var list = db.Database.ExecuteSqlCommand(sql);//sp create etme

                return "Sp_ProjeListesi Başarılı bir şekilde oluşturuldu";

            }
            catch (Exception ex)
            {
                return "Hata : " + ex.Message;
            }
        }
    }
}
