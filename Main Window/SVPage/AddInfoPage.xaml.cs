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
        public int ID { get; set; }
        public AddInfoPage(int ID)
        {
            InitializeComponent();
            this.ID = ID; 
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            String check = "";
            if (String.IsNullOrEmpty(Namee.Text)) check += "Tên đang để trống, ";
            if (String.IsNullOrEmpty(msv.Text)) check += "Mã sinh viên đang để trống, ";
            if ((bool)!gtnam.IsChecked && (bool)!gtnu.IsChecked) check += "Giới tính chưa chọn, ";
            else if ((bool)gtnam.IsChecked && (bool)gtnu.IsChecked) check += "Giới tính không được chọn cả 2, ";
           
            if (String.IsNullOrWhiteSpace(namhoc.Text)) check += "Chưa điền năm học, ";
            if (String.IsNullOrWhiteSpace(ns.Text)) check += "Chưa điền năm sinh, ";
            if (check.Length > 0)
            {
                check = check.Remove(check.Length - 2);
                _ = MessageBox.Show(check, "Add Page thông báo");

            }
            else
            {
                var hechon = he.SelectedItem as ComboBoxItem;
                var tenhe = hechon!.Content.ToString();
                var gt = (bool)gtnam.IsChecked ? "Nam" : "Nữ";
                InfoSV sv = new(msv.Text, Namee.Text,gt, DateTime.Parse(ns.Text), int.Parse(namhoc.Text)
                    , SQLworker.XepPhong(tenhe, gt),tenhe );
              // try {      
                    AddInfoSVController.addInfo(sv);
                    _ = MessageBox.Show("thêm thông tin thành công", "Thêm thông tin");
                    Application.Current.Shutdown();
                    FormSVDS f = new(this.ID);
                    f.Show();
           //    }
          //      catch (Exception ex) {  MessageBox.Show($"đã có lỗi xảy ra {ex.Message }","Thêm thông tin"); }

            }

        }

        private void Namee_TextChanged(object sender, TextChangedEventArgs e)
        {

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
