using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
using Quan_Ly_KTX.Controller;

namespace Quan_Ly_KTX.View
{
    public class InfoHD
    {
        public int MaHd { get; set; }
        public string Msv { get; set; }
        public int Mdv { get; set; }
        public string Hoten { get; set; }   
        public string Tendv { get; set; }
        public int GiaHd { get; set; }
        public int Madk { get; set; }
        public InfoHD(int maHd, string msv, int mdv, string hoten, string tendv, int giaHd, int madk)
        {
            MaHd = maHd;
            Msv = msv;
            Mdv = mdv;
            Hoten = hoten;
            Tendv = tendv;
            GiaHd = giaHd;
            Madk = madk;
        }
        
    }
}
