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
using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;

namespace Quan_Ly_KTX.SVPage
{
    /// <summary>
    /// Interaction logic for EditInfoPage.xaml
    /// </summary>
    public partial class EditInfoPage : Page
    {
        public InfoSV Sv { get; set; }
        public EditInfoPage(InfoSV sv)
        {
            InitializeComponent();
            Sv = sv;
            this.DataContext = Sv;

        }

        private void EditName_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditMsv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditGT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditNS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditNh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditMp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
