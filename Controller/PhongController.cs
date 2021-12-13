using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.View;
using Quan_Ly_KTX.Models;
using Microsoft.EntityFrameworkCore;

namespace Quan_Ly_KTX.Controller
{
    public static  class PhongController
    {
        public static ICollection<phongs> LayDsPhong()
        {
            List<phongs> ds = new();
          
                ds = SQLConnection.Instance.Phongs.Join(SQLConnection.Instance.Hes, a => a.MaHe, b => b.MaHe, (c, d) => new
                {
                    c.MaPhong,
                    c.TinhTrangPhong,
                    c.LoaiPhong,
                    d.MaHe,
                    d.TenHe
                }).Select(x => new phongs(x.TinhTrangPhong, x.LoaiPhong, x.MaPhong, x.TenHe, x.MaHe)).AsNoTracking().ToList();
            
            return ds;
        }
        public static bool ThemPhong(phongs p)
        {
            bool flag = false;
            try
            {
                SQLConnection.Instance.Phongs.Add(p.ToPhong());
                SQLConnection.Instance.SaveChanges();
                flag = true;
            }
            catch (Exception) { }
            return flag;
        }
        public static bool XoaPhong(phongs p)
        {
            bool flag = false;
            try
            {
                SQLConnection.Instance.Phongs.Remove(p.ToPhong());
                SQLConnection.Instance.SaveChanges();
                flag = true;
            }
            catch (Exception) { }
            return flag;
        }
        public static bool SuaPhong(phongs p)
        {
            bool flag = false;
            try
            {
                SQLConnection.Instance.Phongs.Update(p.ToPhong());
                SQLConnection.Instance.SaveChanges();
                flag = true;
            }
            catch (Exception) { }
            return flag;
        }
    }
}
