using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Quan_Ly_KTX.View;
using Quan_Ly_KTX.Controller;

namespace Quan_Ly_KTX.SVPage
{
    /// <summary>
    /// Interaction logic for AddInfoPage.xaml
    /// </summary>
    public partial class AddInfoPage : Page
    {
        public AddInfoPage()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            String check = "";
            if (String.IsNullOrEmpty(Namee.Text)) check += "Tên đang để trống, ";
            if (String.IsNullOrEmpty(msv.Text)) check += "Mã sinh viên đang để trống, ";
            if ( (bool)!gtnam.IsChecked && (bool)!gtnu.IsChecked) check += "Giới tinh chưa chọn, ";
            if (String.IsNullOrWhiteSpace(maphong.Text)) check += "Chưa điền mã phòng, ";
            if (String.IsNullOrWhiteSpace(namhoc.Text)) check += "Chưa điền năm học, ";
            if (String.IsNullOrWhiteSpace(ns.Text)) check += "Chưa điền năm sinh, ";
            if (check.Length > 0)
            {
                check = check.Replace(',', ' ');
                _ = MessageBox.Show(check, "Add Page thông báo");

            }
            else
            {
                InfoSV sv = new(msv.Text, Namee.Text, (bool)gtnam.IsChecked ? gtnam.Content.ToString() : gtnu.Content.ToString(), DateTime.Parse(ns.Text), int.Parse(namhoc.Text)
                    , int.Parse(maphong.Text), he.Text);
                try { AddInfoSVController.addInfo(sv); }
                catch (Exception) { _ = MessageBox.Show("đã có lỗi xảy ra"); }
            }

        }
    }
}
