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
        public static InfoSV LayDSSV( int id)
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
                    d.TinhTrangPhong,
                    c.MaHe
                }).Join(context.Hes, a => a.MaHe, b => b.MaHe, (c, d) => new
                {
                    c.IdUser,
                    c.Msv,
                    c.Hoten,
                    c.GioiTinh,
                    c.NgaySinh,
                    c.MaPhong,
                    c.NamHoc,
                    c.TinhTrangPhong,
                    d.MaHe,
                    d.TenHe
                }).Where(s => s.IdUser == id).Select(s => new InfoSV(s.Msv, s.Hoten, s.GioiTinh, s.NgaySinh, s.NamHoc, s.MaPhong, s.TenHe, s.TinhTrangPhong)).FirstOrDefault();
            return result;
        }
    }
}
