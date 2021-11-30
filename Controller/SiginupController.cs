using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
namespace Quan_Ly_KTX.Controller
{
    internal static class SiginupController
       {
       public static void addUser(String username, String Password)
        {
            UserNguoiDung u = new();
            u.Username = username;
            u.MatKhau= Password;
            u.RoleId = 1;
            using KTX_KMAContext context = new();
            context.UserNguoiDungs.Add(u);
            context.SaveChanges();
        }
    }
}
