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
        public static ICollection<InfoHD> LayDSHoaDon()
        {
            List<InfoHD> dshd = new();

            dshd = SQLConnection.Instance.HoaDons.Join(SQLConnection.Instance.Đkdvcns, a => a.MaDk, b => b.MaDk, (c, d) => new
            {
                c.MaHd,
                c.Msv,
                c.GiaHd,
                d.MaDk,
                d.MaDv
            }).Join(SQLConnection.Instance.DichVus, a => a.MaDv, b => b.MaDv, (c, d) => new
            {
                c.MaHd,
                c.Msv,
                c.GiaHd,
                c.MaDk,
                d.MaDv,
                d.TenDv
            }).Join(SQLConnection.Instance.SinhViens, a => a.Msv, b => b.Msv, (c, d) => new
            {
                c.MaHd,
                c.GiaHd,
                c.MaDk,
                c.MaDv,
                c.TenDv,
                d.Msv,
                d.Hoten
            }).Select(a => new InfoHD(a.MaHd, a.Msv, a.MaDv, a.Hoten, a.TenDv, a.GiaHd, a.MaDk)).ToList();

            return dshd;
        }
    }
}
