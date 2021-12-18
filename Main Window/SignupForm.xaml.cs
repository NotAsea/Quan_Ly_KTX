﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Quan_Ly_KTX.Controller;

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
            if (String.IsNullOrEmpty(Username.Text)) mss += "Tên đăng nhập đang trống, ";
            if (String.IsNullOrEmpty(Password.Password)) mss += "Mật khẩu đang trống, ";
            if (String.IsNullOrEmpty(RePassword.Password)) mss += "Mật khẩu nhập lại đang trống, ";
            else if (RePassword.Password != Password.Password) mss += "Mật khẩu nhập lại không trùng mật khẩu gốc  ";
            if (mss.Length > 0)
            {
                mss = mss.Remove(mss.Length - 2);
                _ = MessageBox.Show(mss, "Form Đăng nhập");
            }
            else
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                _= await SiginupController.addUser(Username.Text, Password.Password);
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                _ =  MessageBox.Show("Đăng Ký  thành công", "Form đăng ký");
                this.Hide();
            }

        }
    }
}
