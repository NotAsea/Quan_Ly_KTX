using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.View;
using Quan_Ly_KTX.Models;

namespace Quan_Ly_KTX.Controller
{
    public  static class AddInfoSVController
    {
       
        public static void addInfo(InfoSV sv)
        {
            using KTX_KMAContext context = new();
            context.SinhViens.Add(sv.ToSV());
            context.SaveChanges();
        }
        public static void UpdateInfoSV (InfoSV sv)
        {
            using KTX_KMAContext context = new();
            context.SinhViens.Update(sv.ToSV());
            context.SaveChanges();
        }
    }
}
