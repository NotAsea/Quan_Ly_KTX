using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_KTX.Controller
{
    public sealed class QLDVController
    {
        private QLDVController() { }
        private static QLDVController controller = null;
        public static QLDVController Controller
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
        public ICollection<Infodichvu> LayDv()
        {
            List<Infodichvu> ds = new();


            ds = SQLConnection.Instance.DichVus.Select(x => new Infodichvu(x.MaDv, x.TenDv, x.GiaDv)).ToList();

            return ds;
        }

        public void ThemDV(Infodichvu dv)
        {
            SQLConnection.Instance.DichVus.Add(dv.ToDv());
            SQLConnection.Instance.SaveChanges();
        }
        public void CapnhapDv(Infodichvu dv)
        {
            SQLConnection.Instance.DichVus.Update(dv.ToDv());
            SQLConnection.Instance.SaveChanges();
        }
        public ICollection<DichVu> LayDsDVDeDK(string msv)
        {
            List<DichVu> ds = new();
            var dv_DaDK = LichSuDK.Controller.LayMdvDaDangKyCuaSv(msv);
            ds = SQLConnection.Instance.DichVus.ToList();
            LichSuDK.Controller.FreeController();
            return ds.Where(d => !dv_DaDK.Any(x => x == d.MaDv)).ToList();
        }

        public void ĐangKyDV(Đkdvcn[] dk)
        {

            SQLConnection.Instance.Đkdvcns.AddRange(dk);
            SQLConnection.Instance.SaveChanges();
        }
        public bool XoaDv(Infodichvu dv)
        {
            bool flag = false;
            try
            {
                SQLConnection.Instance.DichVus.Remove(dv.ToDv());
                SQLConnection.Instance.SaveChanges();
                flag = true;
            }
            catch (Exception) { }
            return flag;
        }
    }
}
