using Quan_Ly_KTX.Models;
using System;
namespace Quan_Ly_KTX.View
{
    public class phongs
    {
        public String ttphong { get; set; }
        public String loaiphong { get; set; }
        public int Maphong { get; set; }
        public String tenhe { get; set; }
        public string mahe { get; set; }
        public phongs(string ttphong, string loaiphong, int maphong, string tenhe, string mah)
        {
            this.ttphong = ttphong;
            this.loaiphong = loaiphong;
            Maphong = maphong;
            this.tenhe = tenhe;
            mahe = mah;
        }
        public Phong ToPhong()
        {
            Phong ph = new();
            ph.MaPhong = Maphong;
            ph.MaHe = mahe;
            ph.TinhTrangPhong = ttphong;
            ph.LoaiPhong = loaiphong;
            return ph;
        }
    }
}
