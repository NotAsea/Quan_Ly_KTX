using Microsoft.EntityFrameworkCore;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_KTX.Controller
{
    internal static class SQLworker
    {

        public static int XepPhong(String he, String gt)
        {
            int maphong;
            using (KTX_KMAContext context = new())
            {
                maphong = context.Phongs.AsNoTracking().Where(p => p.MaHe.Equals(he)).Where(p => p.TinhTrangPhong.Equals("Còn")).Where(p => p.LoaiPhong.Equals(gt))
                    .Select(x => x.MaPhong).FirstOrDefault();
            }
            return maphong;
        }
        public static int TimMdv(String tdv)
        {
            var kq = SQLConnection.Instance.DichVus.AsNoTracking().Where(x => x.TenDv.Contains(tdv)).Select(x => x.MaDv).FirstOrDefault();
            return kq;
        }
        public static List<tongcong> LayDSMP(string he, string gt, int mp)
        {
            var ds = SQLConnection.Instance.Phongs.AsNoTracking().Where(p => p.MaHe.Equals(he)).Where(p => p.TinhTrangPhong.Equals("Còn")).Where(p => p.LoaiPhong.Equals(gt))
                .Where(p => p.MaPhong != mp)
                     .Select(x => new tongcong(x.MaPhong)).ToList();
            return ds;
        }
        public static int LaySoLuong(int maphong)
        {
            return SQLConnection.Instance.SinhViens.AsNoTracking().Count(x => x.MaPhong == maphong);
        }
        public static List<MaPhongList> LayDSMPtoanbo(List<int> loc)
        {
            var context = SQLConnection.Instance;
            return context.Phongs.AsNoTracking().Where(x=> x.MaHe != "QS" && !loc.Contains(x.MaPhong)).Select(x=> new MaPhongList(x.MaPhong)).ToList();


         }
    }
}
