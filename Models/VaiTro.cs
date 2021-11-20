using System;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class VaiTro
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int IdUser { get; set; }

        public virtual UserNguoiDung IdUserNavigation { get; set; } = null!;
    }
}
