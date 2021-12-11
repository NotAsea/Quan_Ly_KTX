using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.View;

namespace Quan_Ly_KTX.Controller
{
    public static class QLDVController
    {
        public static ICollection<Infodichvu> LayDv()
        {
            List<Infodichvu> ds = new();
            using(KTX_KMAContext context=new())
            {
                ds = context.DichVus.Select(x=> new Infodichvu(x.MaDv,x.TenDv, x.GiaDv)).ToList();
            }
            return ds;
        }
        public static ICollection<InfoHD> LayDSHoaDon()
        {
            List<InfoHD> dshd = new();
            using (KTX_KMAContext context= new())
            {
                dshd = context.HoaDons.Join(context.Đkdvcns, a => a.MaDk, b => b.MaDk, (c, d) => new
                {
                    c.MaHd,
                    c.Msv,
                    c.GiaHd,
                    d.MaDk,
                    d.MaDv
                }).Join(context.DichVus, a => a.MaDv, b => b.MaDv, (c, d) => new
                {
                    c.MaHd,
                    c.Msv,
                    c.GiaHd,
                    c.MaDk,
                    d.MaDv,
                    d.TenDv
                }).Join(context.SinhViens, a => a.Msv, b => b.Msv, (c, d) => new
                {
                    c.MaHd,
                    c.GiaHd,
                    c.MaDk,
                    c.MaDv,
                    c.TenDv,
                    d.Msv,
                    d.Hoten
                }).Select(a => new InfoHD(a.MaHd, a.Msv, a.MaDv, a.Hoten, a.TenDv, a.GiaHd, a.MaDk)).ToList();
            }
            return dshd;
        }
    }
}
