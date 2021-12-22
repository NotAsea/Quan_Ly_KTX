using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
namespace Quan_Ly_KTX.View
{
    public  class phongs
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
