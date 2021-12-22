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
     
        public string Msv { get; set; }
        public int[] Mdv { get; set; }
        public string Hoten { get; set; }   
        public string Tendvrieng { get; set; }
        public int Tongtien { get; set; }
        public string Tendvchung { get; set; }

        public InfoHD(string msv, int[] mdv, string hoten, string tendvrieng, int tongtien, string tendvchung)
        {
            Msv = msv;
            Mdv = mdv;
            Hoten = hoten;
            Tendvrieng = tendvrieng;
            Tongtien = tongtien;

            Tendvchung = tendvchung;
        }
    }
}
