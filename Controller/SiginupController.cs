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
       public static async Task addUser(String username, String Password)
        {
            UserNguoiDung u = new();
            u.Username = username;
            u.MatKhau= Password;
            u.RoleId = 1;
            
            SQLConnection.Instance.UserNguoiDungs.Add(u);
             await SQLConnection.Instance.SaveChangesAsync();
        }
    }
}
