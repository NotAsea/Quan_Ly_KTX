using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
namespace Quan_Ly_KTX.View
{
    public  class Infodichvu
    {
        public int MaDv { get; set; }
        public string TenDv { get; set; }
        public int GiaDv { get; set; }

        public Infodichvu(int maDv, string tenDv, int giaDv)
        {
            MaDv = maDv;
            TenDv = tenDv;
            GiaDv = giaDv;
        }
        public DichVu ToDv()
        {
            DichVu d = new();
            d.MaDv = MaDv;
            d.GiaDv= GiaDv;
            d.TenDv = TenDv;
            return d;
        }
    }
}
