using Quan_Ly_KTX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Controller;

namespace Quan_Ly_KTX.View
{
    public   class InfoSV
    {
        
        public InfoSV(string sVID, string hoTen, string gT, DateTime? nS, int nh, int maPhong, string tenHe)
        {
            MSV = sVID;
            HoTen = hoTen;
            GT = gT;
            NS = nS;
            Nh = nh;
            MaPhong = maPhong;
            TenHe = tenHe;
           
        }
        public InfoSV() { }

        public string MSV { get; set; }
        public string HoTen { get; set; }
        public string GT { get; set; }
        public DateTime? NS { get; set; }
        public int Nh { get; set; }
        public int MaPhong { get; set; }
        public string  TenHe { get; set; }
        

     //   public InfoSV toInfoSV( int IdUser, string Hoten, string GioiTinh, DateTime NgaySinh 
          //  , int NamHoc, int MaPhong,  string tenhe, string ttPhong  ) =>  
         //   new InfoSV(IdUser, Hoten, GioiTinh, NgaySinh, NamHoc, MaPhong, tenhe, ttPhong );
        public List<InfoSV> dsSV;
        public List<InfoSV>  taoDS ( params InfoSV[]? info)
        {
            dsSV = new List<InfoSV>();
            foreach (var item in info) dsSV.Add(item);
            return dsSV;
        }
        public SinhVien ToSV()
        {
            SinhVien sv = new();
            sv.Msv = MSV;
            sv.NamHoc = Nh;
            sv.MaHe = SQLworker.timMH(this);
            sv.Hoten = HoTen;
            sv.GioiTinh = GT;
            sv.MaPhong = MaPhong;
            sv.NgaySinh = NS;
            return sv;

        }
        

        
    }
}
