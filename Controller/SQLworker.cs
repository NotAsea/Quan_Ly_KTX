using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.View;

namespace Quan_Ly_KTX.Controller
{
    internal static class SQLworker
    {
        public static ICollection<InfoSV> LayDSSV( int id)
        {
            KTX_KMAContext context = new();
            var result = context.SinhViens.Join(context.Phongs, a => a.MaPhong,
                b => b.MaPhong, (c, d) => new
                {
                    c.IdUser,
                    c.Msv,
                    c.Hoten,
                    c.GioiTinh,
                    c.NgaySinh,
                    c.NamHoc,
                    d.MaPhong,
                  
                    c.MaHe
                }).Join(context.Hes, a => a.MaHe, b => b.MaHe, (c, d) => new
                {
                    c.IdUser,
                    c.Msv,
                    c.Hoten,
                    c.GioiTinh,
                    c.NgaySinh,
                    c.NamHoc,
                    c.MaPhong,
                   
                    d.MaHe,
                    d.TenHe
                }).Where(s => s.IdUser == id).Select(s => new InfoSV(s.Msv, s.Hoten, s.GioiTinh, s.NgaySinh, s.NamHoc, s.MaPhong, s.TenHe)).ToList();
            return result;
        }
        public static String timMH(InfoSV sv)
        {
            var kq="";
            using(KTX_KMAContext context = new())
            {
                kq = context.Hes.Where(x => x.TenHe == sv.TenHe).Select(x => x.MaHe).FirstOrDefault();
            }
            return kq;
        }
    }
}
