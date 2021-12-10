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
                }).Where(s => s.IdUser == id).Select(s => new InfoSV(s.Msv, s.Hoten, s.GioiTinh, s.NgaySinh, s.NamHoc, s.MaPhong, s.TenHe)).FirstOrDefault();
            context.Dispose();
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
        public static int XepPhong(String he, String gt)
        {
            int maphong ;
            using(KTX_KMAContext context = new())
            {
                maphong = context.Phongs.Where(p => p.MaHe == he).Where(p => p.TinhTrangPhong.Equals("Còn")).Where(p => p.LoaiPhong.Equals(gt)).Select(x => x.MaPhong).FirstOrDefault();
            }
            return maphong;
        }
        public static ICollection<Phongs> layphong()
        {

            KTX_KMAContext context = new();

            var ds = context.Phongs.Join(context.Hes, a => a.MaHe, b => b.MaHe, (c, d) => new
            {
                c.MaPhong,
                c.LoaiPhong,
                c.TinhTrangPhong,
                d.MaHe,
                d.TenHe
            }).Select(x => new Phongs(x.TinhTrangPhong, x.LoaiPhong, x.MaPhong, x.TenHe)).ToList();
            
            return ds;
        }
    }
}
