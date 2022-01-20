using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Quan_Ly_KTX.SVPage
{
    /// <summary>
    /// Interaction logic for AddInfoPage.xaml
    /// </summary>
    public partial class AddInfoPage : Page
    {
        public int ID { get; set; }
        private FormSVDS s;
        public AddInfoPage(int ID, FormSVDS sv)
        {
            InitializeComponent();
            this.ID = ID;
            this.s = sv;
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            String check = "";
            DateTime ngaysinh = System.DateTime.Now;
            if (String.IsNullOrWhiteSpace(Namee.Text)) check += "Tên đang để trống, ";
            if (String.IsNullOrWhiteSpace(msv.Text)) check += "Mã sinh viên đang để trống, ";
            if ((bool)!gtnam.IsChecked && (bool)!gtnu.IsChecked) check += "Giới tính chưa chọn, ";
            else if ((bool)gtnam.IsChecked && (bool)gtnu.IsChecked) check += "Giới tính không được chọn cả 2, ";

            if (String.IsNullOrWhiteSpace(namhoc.Text)) check += "Chưa điền năm học, ";
            if (String.IsNullOrWhiteSpace(ns.Text)) check += "Chưa điền năm sinh, ";
            else try { ngaysinh = DateTime.Parse(ns.Text); } catch (Exception) { check += "Ngày sinh không đúng định dạng, "; }
            if (check.Length > 0)
            {
                check = check.Remove(check.Length - 2);
                _ = MessageBox.Show(check, "Add Page thông báo");

            }
            else
            {
                var hechon = he.SelectedItem as ComboBoxItem;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
                var tenhe = hechon.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                var gt = (bool)gtnam.IsChecked ? "Nam" : "Nữ";
                InfoSV sv = new(msv.Text, Namee.Text, gt, ngaysinh, int.Parse(namhoc.Text)
                    , SQLworker.XepPhong(tenhe, gt), tenhe, ID);
                try
                {
                    QLSVController.Controller.addInfo(sv);
                    MessageBox.Show("thêm thông tin thành công ", "Thêm thông tin");
                    s.Hide();
                    FormSVDS f = new(this.ID);
                    f.Show();
                }
                catch (Exception ex) { MessageBox.Show($"đã có lỗi xảy ra {ex.Message }", "Thêm thông tin"); }

            }

        }



        private void reset_Click(object sender, RoutedEventArgs e)
        {
            Namee.Text = "";
            msv.Text = "";
            namhoc.Text = "";
            ns.Text = "";
        }


    }
}
