using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.View;

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
           
            
                ds = SQLConnection.Instance.DichVus.Select(x=> new Infodichvu(x.MaDv,x.TenDv, x.GiaDv)).ToList();
            
            return ds;
        }
       
        public void ThemDV(Infodichvu dv)
        {
            SQLConnection.Instance.DichVus.Add(dv.ToDv());
            SQLConnection.Instance.SaveChanges();
        }
        public  void CapnhapDv(Infodichvu dv)
        {
            SQLConnection.Instance.DichVus.Update(dv.ToDv());
            SQLConnection.Instance.SaveChanges();
        }
        public ICollection<DichVu> LayDsDV()
        {
            List<DichVu> ds = new();

            ds = SQLConnection.Instance.DichVus.ToList();

            return ds;
        }
        public void ĐangKyDV(Đkdvcn[] dk)
        {

            SQLConnection.Instance.Đkdvcns.AddRange(dk);
            SQLConnection.Instance.SaveChanges();
        }
        public  bool XoaDv(Infodichvu dv)
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
