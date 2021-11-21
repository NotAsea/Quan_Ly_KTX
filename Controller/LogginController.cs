using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_KTX.Models;

namespace Quan_Ly_KTX.Controller
{
    internal static class LogginController
    {  
        public static String IsLoggin(String username, String password)
        {

            KTX_KMAContext context = new();
            var UserExist = context.UserNguoiDungs.Join(context.VaiTros, a => a.RoleId, b => b.RoleId, (c, d) => new
            {
                c.IdUser, c.Username, c.MatKhau, d.RoleId, d.RoleName
            }) .Where(s=> s.Username==username).Where(p=>p.MatKhau==password).Select(s=>s.RoleName).FirstOrDefault()!.ToString();
            return UserExist ?? "Không có tài khoản";

        }
    }
}
