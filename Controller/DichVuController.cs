using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;

namespace Quan_Ly_KTX.Controller
{
    public static class DichVuController
    {
        public static  ICollection<DichVu> LayDsDV()
        {
            List<DichVu> ds = new();
            using(KTX_KMAContext context= new())
            {
                ds = context.DichVus.ToList();
            }
            return ds;
        }
        public static void ĐangKyDV(ICollection<Đkdvcn> dk)
        {
            using KTX_KMAContext context = new();
            foreach(var d in dk)  context.Đkdvcns.Add(d);
            context.SaveChanges();
        }
    }
}
