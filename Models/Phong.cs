using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class Phong
    {
        public int MaPhong { get; set; }
        public string MaHe { get; set; } = null!;
        public string TinhTrangPhong { get; set; } = null!;
        public string? LoaiPhong { get; set; }

        public virtual He MaHeNavigation { get; set; } = null!;
        public virtual DienNuocPhong DienNuocPhong { get; set; } = null!;
    }
}
