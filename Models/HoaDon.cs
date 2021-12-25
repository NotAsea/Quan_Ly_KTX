using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class HoaDon
    {
        public int MaHd { get; set; }
        public string Msv { get; set; } = null!;
        public int MaDk { get; set; }
        public int GiaHd { get; set; }

        public virtual Đkdvcn MaDkNavigation { get; set; } = null!;
        public virtual SinhVien MsvNavigation { get; set; } = null!;
    }
}
