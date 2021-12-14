using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.View;
using Microsoft.EntityFrameworkCore;

namespace Quan_Ly_KTX.Controller
{
    internal static class SQLworker
    {
        
        public static int XepPhong(String he, String gt)
        {
            int maphong ;
            using(KTX_KMAContext context = new())
            {
                maphong = context.Phongs.AsNoTracking().Where(p => p.MaHe.Equals(he)).Where(p => p.TinhTrangPhong.Equals("Còn")).Where(p => p.LoaiPhong.Equals(gt))
                    .Select(x => x.MaPhong).FirstOrDefault();
            }
            return maphong;
        }
      public static int TimMdv (String tdv)
        {
            var kq = SQLConnection.Instance.DichVus.AsNoTracking().Where(x => x.TenDv.Contains(tdv)).Select(x=> x.MaDv).FirstOrDefault();
            return kq;
        }
      
    }
}
