using Quan_Ly_KTX.View;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var context = SQLConnection.Instance;
            var dshd = context.Phongs.Join(context.DienNuocPhongs, x => x.MaPhong, y => y.MaPhong, (c, d) => new
            {
                c.MaHe,
                c.LoaiPhong,
                d.MaPhong,
                d.GiaDien,
                d.GiaNuoc,
                dienuoc = d.GiaDien + d.GiaNuoc
            }).Where(x => x.GiaDien != 0 && !x.LoaiPhong.Equals("QS"))
              .Join(context.SinhViens, x => x.MaPhong, y => y.MaPhong, (c, d) => new
              {
                  c.MaPhong,
                  c.dienuoc,
                  d.MaHe,
                  d.Msv,
                  d.Hoten
              })
       .Join(context.Đkdvcns, x => x.Msv, y => y.Msv, (c, d) => new
       {
           c.MaPhong,
           c.dienuoc,
           c.Hoten,
           d.Msv,
           d.MaDv
       }).Join(context.DichVus, x => x.MaDv, y => y.MaDv, (c, d) => new
       {
           c.Msv,
           c.MaPhong,
           c.Hoten,
           c.dienuoc,
           d.MaDv,
           d.TenDv,
           d.GiaDv
       }).GroupBy(x => new { x.Hoten, x.Msv, x.MaPhong }, (x, y) => new
       {
           x.Hoten,
           x.MaPhong,
           x.Msv,
           Tongtien = y.Sum(y => y.dienuoc + y.GiaDv),
           DichVuRieng = String.Join(",", y.Select(y => y.TenDv)).TrimEnd(',')
       }).Select(x => new InfoHD(x.Hoten, x.MaPhong, x.Msv, x.DichVuRieng, x.Tongtien)).ToList();
            return dshd;
        }

        public void ThemDienNuoc(DienNuocDS d)
        {
            SQLConnection.Instance.DienNuocPhongs.Add(d.ToDienNuoc());
            SQLConnection.Instance.SaveChanges();
        }
    }
}
