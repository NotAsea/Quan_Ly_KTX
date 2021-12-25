using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class Đkdvcn
    {
        public Đkdvcn()
        {
            HoaDons = new HashSet<HoaDon>();
            MaDvs = new HashSet<DichVu>();
        }

        public int MaDk { get; set; }
        public string Msv { get; set; } = null!;
        public int MaDv { get; set; }

        public virtual SinhVien MsvNavigation { get; set; } = null!;
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual ICollection<DichVu> MaDvs { get; set; }
    }
}
