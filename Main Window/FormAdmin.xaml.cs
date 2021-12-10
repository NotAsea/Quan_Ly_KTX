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
using Quan_Ly_KTX.Main_Window.AdminPage;

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
            MainContent.Content= new Frame() { Content= new QLSV()};
        }

        private void XemDSP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void XemDSDV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void XemDSHD_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
