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
    /// Interaction logic for EditPhong.xaml
    /// </summary>
    public partial class EditPhong : Window
    {
        private phongs p;
        public event EventHandler onSucess;
        public EditPhong( phongs p)
        {
            InitializeComponent();
            this.p = p;
            this.DataContext = p;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            p.ttphong= ttp.Text;
            p.loaiphong = lp.Text;
            p.tenhe = tenhe.Text;
            p.Maphong = int.Parse(mp.Text);
            p.mahe = p.tenhe switch
            {
                "Quân Sự" => "QS",
                "Dân Sự" => "DS",
                _ => "DS",
            };
            var kq = PhongController.SuaPhong(p);
            if (kq)
            {
                MessageBox.Show("Sửa thành công", "thông báo");
                onSucess(this, new EventArgs());
                this.Hide();
            }
            else { MessageBox.Show("Sửa thất bại", "thông báo"); }
            }
    }
}
