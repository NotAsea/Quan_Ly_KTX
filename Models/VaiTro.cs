using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class VaiTro
    {
        public VaiTro()
        {
            UserNguoiDungs = new HashSet<UserNguoiDung>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<UserNguoiDung> UserNguoiDungs { get; set; }
    }
}
