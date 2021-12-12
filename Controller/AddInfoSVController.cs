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
    public static class AddInfoSVController
    {

        public static void addInfo(InfoSV sv)
        {

            SQLConnection.Instance.SinhViens.Add(sv.ToSV());
            SQLConnection.Instance.SaveChanges();
        }

        public static void UpdateInfoSV(InfoSV sv)
        {
            SQLConnection.Instance.SinhViens.Update(sv.ToSV());
            SQLConnection.Instance.SaveChanges();


        }

    }
}
