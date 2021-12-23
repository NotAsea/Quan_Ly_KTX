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
using System.Windows.Shapes;
using Quan_Ly_KTX.View;
using Quan_Ly_KTX.Controller;
namespace Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow
{
    /// <summary>
    /// Interaction logic for AddBill.xaml
    /// </summary>
    public partial class AddBill : Window
    {
        public AddBill()
        {
            InitializeComponent();
        }
        public event EventHandler OnAdded;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var check = "";
            if (String.IsNullOrWhiteSpace(maphong.Text)) check += "Mã phòng đang trống \t";
            if (String.IsNullOrWhiteSpace(dien.Text)) check += "Số điện đang trống \t";
            if (String.IsNullOrWhiteSpace(nuoc.Text)) check += "Số nước vụ đang trống \t";
            if (check.Length > 0) MessageBox.Show($"{check}", "thông báo");
            else
            {

                DienNuocDS hd = new(int.Parse(dien.Text), int.Parse(nuoc.Text), int.Parse(maphong.Text));
                HaoDonController.Controller.ThemDienNuoc(hd);
                MessageBox.Show("Thêm thành công", "thông báo");
                OnAdded(this, new EventArgs());
                HaoDonController.Controller.FreeController();
                this.Hide();
            }
        }
    }
}
