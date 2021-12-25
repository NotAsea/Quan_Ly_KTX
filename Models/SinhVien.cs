using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            HoaDons = new HashSet<HoaDon>();
            Đkdvcns = new HashSet<Đkdvcn>();
        }

        public string Msv { get; set; } = null!;
        public string Hoten { get; set; } = null!;
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int NamHoc { get; set; }
        public string MaHe { get; set; } = null!;
        public int MaPhong { get; set; }
        public int? IdUser { get; set; }

        public virtual UserNguoiDung? IdUserNavigation { get; set; }
        public virtual He MaHeNavigation { get; set; } = null!;
        public virtual Phong MaPhongNavigation { get; set; } = null!;
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<Đkdvcn> Đkdvcns { get; set; }
    }
}
