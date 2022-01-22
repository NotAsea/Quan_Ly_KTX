using Quan_Ly_KTX.Controller;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
namespace Quan_Ly_KTX
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            String mss = "";
            if (String.IsNullOrWhiteSpace(Username.Text)) mss += "Tên đăng nhập đang trống, ";
            if (String.IsNullOrWhiteSpace(Password.Password)) mss += "Mật khẩu đang trống, ";
            if (String.IsNullOrWhiteSpace(RePassword.Password)) mss += "Mật khẩu nhập lại đang trống, ";
            else if (RePassword.Password != Password.Password) mss += "Mật khẩu nhập lại không trùng mật khẩu gốc,  ";
            else if (Username.Text.Length > 30) mss += "Tên Đăng nhập không dài quá 30 ký tự, ";
            else if (Password.Password.Length <= 3) mss += "Mật khẩu ít nhất 3 ký tự, ";
            else if (Password.Password.Length > 30) mss += "Mật khẩu tối đa 30 ký tự, ";
            var username = Regex.Replace(Username.Text.TrimStart().TrimEnd(), @"[^0-9a-zA-Z]+", "");
            var password = Password.Password.Replace(" ", String.Empty);
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            if (await SQLworker.KiemtraTrung(username)) mss += "Tài khoản đã tồn tại, ";
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            if (mss.Length > 0)
            {
                mss = mss.Remove(mss.Length - 2);
                _ = MessageBox.Show(mss, "Form Đăng nhập");
            }
            else
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                _ = await SiginupController.addUser(Username.Text, Password.Password);
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                _ = MessageBox.Show("Đăng Ký  thành công", "Form đăng ký");
                this.Hide();
            }

        }
    }
}
