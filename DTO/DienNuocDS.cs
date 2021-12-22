using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
namespace Quan_Ly_KTX.View
{
    public class DienNuocDS
    {
        public const int GiaDienTrenSo = 3000;
        public const int GiaNuocTrenSo = 15000;
        private int sodien;
        private int sonuoc;
        public  int GiaDien { get => sodien * GiaDienTrenSo; }
        public  int GiaNuoc { get => sonuoc * GiaNuocTrenSo; }
        public int MaPhong { get; set; }

        public DienNuocDS(int sodien, int sonuoc, int maPhong)
        {
            this.sodien = sodien;
            this.sonuoc = sonuoc;
            MaPhong = maPhong;
        }
        public DienNuocPhong ToDienNuoc()
        {
            DienNuocPhong dnp = new();
            dnp.GiaDien = GiaDien;
            dnp.GiaNuoc = GiaNuoc;
            dnp.MaPhong= MaPhong;
            return dnp;
        }
    }
}
