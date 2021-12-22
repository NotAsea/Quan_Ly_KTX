using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class He
    {
        public He()
        {
            Phongs = new HashSet<Phong>();
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaHe { get; set; } = null!;
        public string TenHe { get; set; } = null!;

        public virtual ICollection<Phong> Phongs { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
