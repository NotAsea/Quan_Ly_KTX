using Microsoft.EntityFrameworkCore;
using Quan_Ly_KTX.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_KTX.Controller
{
    public sealed class PhongController
    {
        private PhongController() { }
        private static PhongController controller = null;
        public static PhongController Controller
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
        public ICollection<phongs> LayDsPhong()
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
        public bool ThemPhong(phongs p)
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
        public bool XoaPhong(phongs p)
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
        public bool SuaPhong(phongs p)
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
