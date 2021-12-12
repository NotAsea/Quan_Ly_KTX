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
using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
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
            else {

                Infodichvu dv = new(int.Parse(mdv.Text),tdv.Text, int.Parse(gdv.Text) );
                QLDVController.ThemDV(dv);
                MessageBox.Show("Thêm thành công", "thông báo");
                onSucess(this, new EventArgs());
                this.Hide();
            }
        }
    }
}
