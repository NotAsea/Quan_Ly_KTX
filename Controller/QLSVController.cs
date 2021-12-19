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
    public sealed class QLSVController
    {
        private QLSVController() { }
        private static QLSVController controller = null;
        public static QLSVController Controller
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
        public  InfoSV? LaySV(int id)
        {

            var result = SQLConnection.Instance.SinhViens.Join(SQLConnection.Instance.Hes, a => a.MaHe,
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
                }).Where(s => s.IdUser == id).Select(s => new InfoSV(s.Msv, s.Hoten, s.GioiTinh, s.NgaySinh, s.NamHoc, s.MaPhong, s.TenHe, (int)s.IdUser)).FirstOrDefault();

            return result;
        }
        public  ICollection<InfoSV> LayToanBoSv()
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
               }).Select(s => new InfoSV(s.Msv, s.Hoten, s.GioiTinh, s.NgaySinh, s.NamHoc, s.MaPhong, s.TenHe,(int) s.IdUser)).ToList();
            

          
            return list;
        }
        public  bool XoaSV(InfoSV sv)
        {
            bool flag = false;
             
                try
                {
                SQLConnection.Instance.SinhViens.Remove(sv.ToSV());
                SQLConnection.Instance.SaveChanges();
                    flag = true;
                SQLConnection.Instance.Entry<SinhVien>(sv.ToSV()).State = EntityState.Detached;
                }
                catch(Exception ) { flag = false;  }
            
            return flag;

        }
        public  void addInfo(InfoSV sv)
        {

            SQLConnection.Instance.SinhViens.Add(sv.ToSV());
            SQLConnection.Instance.SaveChanges();
        }

        public  void UpdateInfoSV(InfoSV sv)
        {
            SQLConnection.Instance.SinhViens.Update(sv.ToSV());
            SQLConnection.Instance.SaveChanges();


        }
        
    }
}
