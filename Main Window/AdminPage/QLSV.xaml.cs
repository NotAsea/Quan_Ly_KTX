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
namespace Quan_Ly_KTX.Main_Window.AdminPage
{
    /// <summary>
    /// Interaction logic for QLSV.xaml
    /// </summary>
    public partial class QLSV : Page
    {
        private CollectionViewSource SVList;
        public QLSV()
        {
            InitializeComponent();
            SVList = (CollectionViewSource)FindResource(nameof(SVList));
            SVList.Source = QLSVController.LayToanBoSv();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
