using Quan_Ly_KTX.Models;
using System;
using System.Threading.Tasks;
namespace Quan_Ly_KTX.Controller
{
    internal static class SiginupController
    {
        public static async Task<bool> addUser(String username, String Password)
        {
            bool flag = false;
            UserNguoiDung u = new();
            u.Username = username;
            u.MatKhau = Password;
            u.RoleId = 1;
            try
            {
                SQLConnection.Instance.UserNguoiDungs.Add(u);
                await SQLConnection.Instance.SaveChangesAsync();
                flag = true;
            }
            catch (Exception) { }

            return flag;
        }
    }
}
