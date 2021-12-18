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
    public sealed class LichSuDK
    {
        private LichSuDK() { }
        private static LichSuDK controller = null;
        public static LichSuDK Controller
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

        public  ICollection<HistoryDv> layLsSV( String msv)
        {
            List<HistoryDv> ds;
            
                ds = SQLConnection.Instance.Đkdvcns.Join(SQLConnection.Instance.DichVus, a => a.MaDv, b => b.MaDv, (c, d) => new
                {
                    c.Msv,
                    c.MaDk,
                    d.MaDv,
                    d.GiaDv,
                    d.TenDv
                }).Where(c => c.Msv == msv).Select(a => new HistoryDv( a.MaDk,a.TenDv, a.GiaDv)).ToList();
            
            return ds;
        }
        public  ICollection<dvDK> LayDsDK()
        {
           
           var ds = SQLConnection.Instance.Đkdvcns.Join(SQLConnection.Instance.DichVus, a => a.MaDv, b => b.MaDv, (c, d) => new
            {
                c.MaDk,
                c.Msv,
                d.MaDv,
                d.GiaDv,
                d.TenDv
            }).Join(SQLConnection.Instance.SinhViens, a => a.Msv, b => b.Msv, (c, d) => new
            {
                c.MaDk,
                c.GiaDv,
                c.MaDv,
                c.TenDv,
                d.Msv,
                d.Hoten
            }).Select(x => new dvDK(x.Hoten, x.MaDk, x.TenDv, x.GiaDv, x.Msv)).ToList();
            return ds;
        }
      public  bool XoaDvDk(dvDK dv)
        {
            bool flag = false;
            try {
                SQLConnection.Instance.Đkdvcns.Remove(dv.todk());
                SQLConnection.Instance.SaveChanges();
                flag = true;
                   }
            catch (Exception) { }
            return flag;
        }
    }
}
