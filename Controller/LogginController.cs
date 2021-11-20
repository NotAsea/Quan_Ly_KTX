using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;

namespace Quan_Ly_KTX.Controller
{
    internal static class LogginController
    {  
        public static String isLoggin(String username, String password)
        {
            String s = "";
            KTX_KMAContext context = new();
            var UserExist= from u in context.Set<UserNguoiDung>() join r in context.Set<VaiTro>()
                          on u.IdUser equals r.IdUser where u.Username == username && u.MatKhau==password
                           select r.RoleName;
            if (UserExist.Any()) return UserExist.Any().ToString();
            else return "không có tài khoản";
        }
    }
}
