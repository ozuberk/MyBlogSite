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
            m.AktifMi,
            k.Adi+' '+k.Soyadi as YazarAdSoyad
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
            p.AktifMi,
            k.Adi+' '+k.Soyadi as ProjeSahibiAdSoyad
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
        public string Sp_YorumListesi()
        {
            try
            {
                string sql = @"
                        create proc Sp_YorumListesi
                        as
                        begin
                        select 
                        y.YorumlarID,
                        k.KullanicilarID,
                        y.Makaleler_MakalelerID,
                        k.Adi,
                        k.Soyadi,                        
                        k.AktifMi,
                        y.Yorum,
                        y.YorumUstId,
                        y.YorumTarihi
                        from Kullanicilars as k
                        join Yorumlars as y on y.Kullanicilar_KullanicilarID=k.KullanicilarID
                        end";
                var list = db.Database.ExecuteSqlCommand(sql);
                return "Sp_Yorumlar adındaki SP başarılı bir şekilde oluşturuldu";
            }
            catch (Exception ex)
            {
                return "HATA:" + ex.Message;
            }
        }
        public string Sp_YetkiErisimListele()
        {
            try
            {
                string sql = @"
                    Create proc Sp_YetkiErisimListesi
                    as 
                    begin
                    select 
					ye.YetkiErisimleriID,
					ea.ErisimAlanlariID,
					y.YetkilerID,
                    y.YetkiAdi,
					ea.ViewAdi,
					ea.ControllerAdi,					
					ye.AktifMi,
					ye.Aciklama
                    from YetkiErisimleris   	as ye
                    join ErisimAlanlaris		as ea   on ye.YetkiErisimleriID =   ea.YetkiErisimleri_YetkiErisimleriID
                    join Yetkilers				as  y   on ye.YetkiErisimleriID =   y.YetkiErisimleri_YetkiErisimleriID                   
                    end";
                var list = db.Database.ExecuteSqlCommand(sql);
                return "Sp_YetkiErisimListesi adındaki SP başarılı bir şekilde oluşturuldu";
            }
            catch (Exception ex)
            {
                return "HATA:" + ex.Message;
            }
        }
    }
}
