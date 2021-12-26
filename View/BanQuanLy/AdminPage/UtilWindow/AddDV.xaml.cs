using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System;
using System.Windows;
namespace Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow
{
    /// <summary>
    /// Interaction logic for AddDV.xaml
    /// </summary>
    public partial class AddDV : Window
    {

        public AddDV()
        {
            InitializeComponent();
        }
        public event EventHandler onSucess;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var check = "";
            if (String.IsNullOrWhiteSpace(mdv.Text)) check += "Mã dịch vụ đang trống \t";
            if (String.IsNullOrWhiteSpace(tdv.Text)) check += "Tên dịch vụ đang trống \t";
            if (String.IsNullOrWhiteSpace(gdv.Text)) check += "Giá dịch vụ đang trống \t";
            if (check.Length > 0) MessageBox.Show($"{check}", "thông báo");
            else
            {

                Infodichvu dv = new(int.Parse(mdv.Text), tdv.Text, int.Parse(gdv.Text));
                QLDVController.Controller.ThemDV(dv);
                MessageBox.Show("Thêm thành công", "thông báo");
                onSucess(this, new EventArgs());
                QLDVController.Controller.FreeController();
                this.Hide();
            }
        }
    }
}
