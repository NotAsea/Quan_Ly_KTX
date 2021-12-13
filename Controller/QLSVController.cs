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
    public static class QLSVController
    {
        public static ICollection<InfoSV> LayToanBoSv()
        {
            List<InfoSV> list = new();
          
                list = SQLConnection.Instance.SinhViens.Join(SQLConnection.Instance.Hes, a => a.MaHe,
               b => b.MaHe, (c, d) => new
               {
                   c.IdUser,
                   c.Msv,
                   c.Hoten,
                   c.GioiTinh,
                   c.NgaySinh,
                   c.NamHoc,
                    c.MaPhong,

                   d.MaHe,
                   d.TenHe
               }).Select(s => new InfoSV(s.Msv, s.Hoten, s.GioiTinh, s.NgaySinh, s.NamHoc, s.MaPhong, s.TenHe,(int) s.IdUser)).AsNoTracking().ToList();
            

          
            return list;
        }
        public static bool XoaSV(InfoSV sv)
        {
            bool flag = false;
             
                try
                {
                SQLConnection.Instance.SinhViens.Remove(sv.ToSV());
                SQLConnection.Instance.SaveChanges();
                    flag = true;
                }
                catch(Exception ) { flag = false;  }
            
            return flag;

        }
    }
}
