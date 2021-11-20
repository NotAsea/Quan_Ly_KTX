using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class UserNguoiDung
    {
        public UserNguoiDung()
        {
            VaiTros = new HashSet<VaiTro>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; } = null!;
        public string MatKhau { get; set; } = null!;

        public virtual SinhVien SinhVien { get; set; } = null!;
        public virtual ICollection<VaiTro> VaiTros { get; set; }
    }
}
