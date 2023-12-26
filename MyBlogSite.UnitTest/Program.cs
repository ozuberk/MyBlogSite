using MyBlogSite.DLL.SiteDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.UnitTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreateSP();
        }
        public static void CreateSP()
        {
            ExistsStoredProcedure createSp = new ExistsStoredProcedure();
            createSp.Sp_MakaleListesi();
            createSp.Sp_ProjeListesi();
        }
    }
    
}
