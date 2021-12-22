using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.Models;
using System;
using System.Collections.Generic;
namespace Quan_Ly_KTX.View
{
    public class InfoSV
    {

        public InfoSV(string sVID, string hoTen, string gT, DateTime? nS, int nh, int maPhong, string tenHe, int id)
        {
            MSV = sVID;
            HoTen = hoTen;
            GT = gT;
            NS = nS;
            Nh = nh;
            MaPhong = maPhong;
            TenHe = tenHe;
            ID = id;
        }
        public InfoSV() { }
        public int ID { get; set; }
        public string MSV { get; set; }
        public string HoTen { get; set; }
        public string GT { get; set; }
        public DateTime? NS { get; set; }
        public int Nh { get; set; }
        public int MaPhong { get; set; }
        public string TenHe { get; set; }
        public List<tongcong> DsMp { get; set; }
        public void LayDsMp()
        {
            DsMp = SQLworker.LayDSMP(TenHe switch
            {
                "Quân Sự" => "QS",
                "Dân Sự" => "DS",
                _ => "DS",
            }, GT, MaPhong);
        }


        public SinhVien ToSV()
        {
            SinhVien sv = new();
            sv.Msv = MSV;
            sv.NamHoc = Nh;
            sv.MaHe = TenHe switch
            {
                "Quân Sự" => "QS",
                "Dân Sự" => "DS",
                _ => "DS",
            };
            sv.Hoten = HoTen;
            sv.GioiTinh = GT;
            sv.MaPhong = MaPhong;
            sv.NgaySinh = NS;
            sv.IdUser = ID;
            return sv;

        }



    }
}
