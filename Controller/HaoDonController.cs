using Quan_Ly_KTX.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Controller;
namespace Quan_Ly_KTX.Controller
{
    public sealed class HaoDonController
    {
        private HaoDonController() { }
        private static HaoDonController controller = null;
        public static HaoDonController Controller
        {
            get
            {
                if (controller is null) controller = new();
                return controller;
            }
        }
        public void FreeController()
        {
            SQLConnection.FreeScope();
            controller = null;
        }
        public ICollection<InfoHD> LayDSHoaDon()
        {
            var dshd = SQLConnection.Instance.Đkdvcns.Join(SQLConnection.Instance.SinhViens, a => a.Msv, b => b.Msv, (c, d) => new
            {
                c.MaDk,
                c.MaDv,
                d.Msv,
                d.Hoten,
                d.MaHe
            }).Join(SQLConnection.Instance.Hes, a => a.MaHe, b => b.MaHe, (c, d) => new
            {
                c.MaDv,
                c.Msv,
                c.Hoten,
                d.MaHe
            }).Join(SQLConnection.Instance.Phongs, a => a.MaHe, b => b.MaHe, (c, d) => new
            {
                c.MaDv,
                c.Hoten,
                c.Msv,
                d.MaHe,
                d.MaPhong
            }).Join(SQLConnection.Instance.DienNuocPhongs, a => a.MaPhong, b => b.MaPhong, (c, d) => new
            {
                c.Msv,
                c.Hoten,
                c.MaDv,
                d.MaPhong,
                d.GiaNuoc,
                d.GiaDien
            }).Join(SQLConnection.Instance.DichVus, a => a.MaDv, b => b.MaDv, (c, d) => new
            {
                c.Msv,
                c.Hoten,
                c.GiaNuoc,
                c.GiaDien,
                c.MaPhong,
                d.MaDv,
                d.TenDv,
                d.GiaDv
            })
              .Where(x => x.GiaDien != 0 || x.GiaNuoc != 0)
             .GroupBy(c => new { c.Msv, c.Hoten, c.MaPhong }, (x, y) => new {
                 Msv = x.Msv,
                 TenSV = x.Hoten,
                 Maphong = x.MaPhong,
                 Tongtien = y.Sum(y => y.GiaDien + y.GiaDv + y.GiaNuoc),
                 Dichvurieng = string.Join(",", y.Select(y => y.TenDv))
             }).Select(x => new InfoHD(x.TenSV, x.Maphong, x.Msv, x.Dichvurieng, x.Tongtien)).ToList();
            return dshd;
        }

        public void ThemDienNuoc(DienNuocDS d)
        {
            SQLConnection.Instance.DienNuocPhongs.Add(d.ToDienNuoc());
            SQLConnection.Instance.SaveChanges();
        }
    }
}
