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
        public static InfoSV? LaySV( int id)
        {
            
            var result = SQLConnection.Instance.SinhViens.Join(SQLConnection.Instance.Hes, a => a.MaHe,
                b => b.MaHe, (c, d) => new
                {
                    c.IdUser,
                    c.Msv,
                    c.Hoten,
                    c.GioiTinh,
                    c.NgaySinh,
                    c.NamHoc,
                    c.MaPhong,
                  
                    d.MaHe, d.TenHe
                }).Where(s => s.IdUser == id).Select(s => new InfoSV(s.Msv, s.Hoten, s.GioiTinh, s.NgaySinh, s.NamHoc, s.MaPhong, s.TenHe, (int)s.IdUser)).AsNoTracking().FirstOrDefault();
            
            return result;
        }
        public static String timMH(string tenhe)
        {
            var kq="";
           kq = SQLConnection.Instance.Hes.Where(x => x.TenHe == tenhe).Select(x => x.MaHe).AsNoTracking().FirstOrDefault();
            
            return kq;
        }
        public static int XepPhong(String he, String gt)
        {
            int maphong ;
            using(KTX_KMAContext context = new())
            {
                maphong = context.Phongs.Where(p => p.MaHe.Equals(he)).Where(p => p.TinhTrangPhong.Equals("Còn")).Where(p => p.LoaiPhong.Equals(gt))
                    .Select(x => x.MaPhong).FirstOrDefault();
            }
            return maphong;
        }
      public static int TimMdv (String tdv)
        {
            var kq = SQLConnection.Instance.DichVus.Where(x => x.TenDv.Contains(tdv)).Select(x=> x.MaDv).FirstOrDefault();
            return kq;
        }
      
    }
}
