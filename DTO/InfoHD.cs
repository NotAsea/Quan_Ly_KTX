using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
namespace Quan_Ly_KTX.View
{
    public class InfoHD
    {
        
        public string TenSV { get; set; }
        public int Maphong { get; set; }
        public string MaSv { get; set; }
        public string DichVuChung => "Điện, Nước";
        public string Dichvurieng { get; set; }
        public int TongTien { get; set; }

        public InfoHD(string tenSV, int maphong, string maSv, string dichvurieng, int tongTien)
        {
            TenSV = tenSV;
            Maphong = maphong;
            MaSv = maSv;
            Dichvurieng = dichvurieng;
            TongTien = tongTien;
        }
    }
}
