using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System;
using System.Collections.Generic;
using System.Windows;
namespace Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow
{
    /// <summary>
    /// Interaction logic for AddBill.xaml
    /// </summary>
    public partial class AddBill : Window
    {

        public AddBill(List<int> a)
        {
            InitializeComponent();
            MaPhongList mpl = new(a);
            mpl.LayDSMaPhong();
            this.DataContext = mpl;
        }
        public event EventHandler OnAdded;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var check = "";

            if (String.IsNullOrWhiteSpace(dien.Text)) check += "Số điện đang trống \t";
            if (String.IsNullOrWhiteSpace(nuoc.Text)) check += "Số nước vụ đang trống \t";
            if (check.Length > 0) MessageBox.Show($"{check}", "thông báo");
            else
            {
                var map = maphong.SelectedItem as MaPhongList;
                DienNuocDS hd = new(int.Parse(dien.Text), int.Parse(nuoc.Text), map.mp);
                HaoDonController.Controller.ThemDienNuoc(hd);
                MessageBox.Show("Thêm thành công", "thông báo");
                OnAdded(this, new EventArgs());
                HaoDonController.Controller.FreeController();
                this.Hide();
            }
        }
    }
}
