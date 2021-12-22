using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System;
using System.Windows;
using System.Windows.Controls;
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
            if (String.IsNullOrWhiteSpace(mp.Text)) check += "Mã phòng đang trống ";


            if (check.Length > 0) MessageBox.Show($"{check}", "thông báo");
            else
            {
                var hechon = he.SelectedItem as ComboBoxItem;
                var mahe = hechon.Name;
                var lphongchon = loaiphong.SelectedItem as ComboBoxItem;
                var lp = lphongchon.Name;
                var ttchon = ttphong.SelectedItem as ComboBoxItem;
                var ttp = ttchon.Name;


                phongs ph = new(ttp, lp, int.Parse(mp.Text), mahe switch
                {
                    "QS" => "Quân Sự",
                    "DS" => "Dân Sự",
                    _ => "Dân Sự",
                }, mahe);
                _ = PhongController.Controller.ThemPhong(ph);
                MessageBox.Show("Thêm thành công", "thông báo");
                onSucess(this, new EventArgs());
                PhongController.Controller.FreeController();
                this.Hide();
            }
        }
    }
}
