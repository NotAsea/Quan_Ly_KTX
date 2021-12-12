using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.View;

namespace Quan_Ly_KTX.Controller
{
    public static class DichVuController
    {
        public static  ICollection<DichVu> LayDsDV()
        {
            List<DichVu> ds = new();
            
                ds = SQLConnection.Instance.DichVus .ToList();
            
            return ds;
        }
        public static void ĐangKyDV(Đkdvcn[] dk)
        {

            SQLConnection.Instance.Đkdvcns.AddRange(dk);
            SQLConnection.Instance.SaveChanges();
        }
       public static bool XoaDv(Infodichvu dv)
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
