using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class Phong
    {
        public Phong()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public int MaPhong { get; set; }
        public string MaHe { get; set; } = null!;
        public string TinhTrangPhong { get; set; } = null!;
        public string? LoaiPhong { get; set; }

        public virtual He MaHeNavigation { get; set; } = null!;
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
