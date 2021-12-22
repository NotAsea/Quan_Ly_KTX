using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quan_Ly_KTX.Controller
{
    internal static class LogginController
    {
        public static async Task<(String, int)> IsLoggin(String username, String password)
        {


            var UserExist = await SQLConnection.Instance.UserNguoiDungs.Join(SQLConnection.Instance.VaiTros, a => a.RoleId, b => b.RoleId, (c, d) => new
            {
                c.IdUser,
                c.Username,
                c.MatKhau,
                d.RoleId,
                d.RoleName
            }).Where(s => s.Username == username).Where(p => p.MatKhau == password).Select(s => new { s.RoleName, s.IdUser }).AsNoTracking().FirstOrDefaultAsync();

            return UserExist != null ? (UserExist.RoleName, UserExist.IdUser) : ("Không có tài khoản", -1);

        }



    }
}
