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
    /// Interaction logic for AddPhong.xaml
    /// </summary>
    public partial class AddPhong : Window
    {
        public AddPhong()
        {
            InitializeComponent();
        }

        public event EventHandler onSucess;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var check = "";
            if (String.IsNullOrWhiteSpace(mp.Text)) check += "Mã phòng đang trống \t";
            if (String.IsNullOrWhiteSpace(tenhe.Text)) check += "Hệ đang trống \t";
            if (String.IsNullOrWhiteSpace(ttp.Text)) check += "Tình trạng phòng  đang trống \t";
            if (String.IsNullOrWhiteSpace(lp.Text)) check += "Loại phòng  đang trống \t";
            if (check.Length > 0) MessageBox.Show($"{check}", "thông báo");
            else
            {
                phongs ph = new(ttp.Text, lp.Text, int.Parse(mp.Text), tenhe.Text, tenhe.Text switch
                {
                    "Quân Sự" => "QS",
                    "Dân Sự" => "DS",
                    _=> "DS",
                }) ;
          _=    PhongController.ThemPhong(ph);
                MessageBox.Show("Thêm thành công", "thông báo");
                onSucess(this, new EventArgs());
                this.Hide();
            }
        }
    }
}
