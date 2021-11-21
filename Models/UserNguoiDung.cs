using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class UserNguoiDung
    {
        public int IdUser { get; set; }
        public string Username { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public int? RoleId { get; set; }

        public virtual VaiTro? Role { get; set; }
        public virtual SinhVien SinhVien { get; set; } = null!;
    }
}
