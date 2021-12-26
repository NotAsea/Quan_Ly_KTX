using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.Main_Window.AdminPage;
using System.Windows;
using System.Windows.Controls;
namespace Quan_Ly_KTX.Main_Window
{
    /// <summary>
    /// Interaction logic for FormAdmin.xaml
    /// </summary>
    public partial class FormAdmin : Window
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void XemDsSV_Click(object sender, RoutedEventArgs e)
        {
            FreeEverytin();
            MainContent.Content = new Frame() { Content = new QLSV() };
        }
        private void FreeEverytin()
        {
            QLDVController.Controller.FreeController();
            QLSVController.Controller.FreeController();
            PhongController.Controller.FreeController();
            LichSuDK.Controller.FreeController();
        }

        private void XemDSP_Click(object sender, RoutedEventArgs e)
        {
            FreeEverytin();
            MainContent.Content = new Frame() { Content = new QLphong() };
        }

        private void XemDSDV_Click(object sender, RoutedEventArgs e)
        {
            FreeEverytin();
            MainContent.Content = new Frame() { Content = new QLDV() };
        }

        private void XemDSHD_Click(object sender, RoutedEventArgs e)
        {
            FreeEverytin();
            MainContent.Content = new Frame() { Content = new QLHD() };
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            FreeEverytin();
            MainWindow m = new();
            m.Show();
            this.Close();
        }

        private void xemDSSvĐky_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Frame() { Content = new QLDVDKY() };
        }
    }
}
