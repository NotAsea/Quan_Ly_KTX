using Quan_Ly_KTX.Controller;
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
        public float TienRieng
        {
            get
            {

                if (TongTien != 0) TongTien /= SQLworker.LaySoLuong(Maphong) == 0 ? TongTien : SQLworker.LaySoLuong(Maphong);
                return TongTien;
            }
        }
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
