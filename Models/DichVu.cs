using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class DichVu
    {
        public DichVu()
        {
            MaDks = new HashSet<Đkdvcn>();
        }

        public int MaDv { get; set; }
        public string? TenDv { get; set; }
        public int GiaDv { get; set; }

        public virtual ICollection<Đkdvcn> MaDks { get; set; }
    }
}
