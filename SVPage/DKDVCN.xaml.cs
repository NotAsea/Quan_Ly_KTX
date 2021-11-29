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
    /// Interaction logic for DKDVCN.xaml
    /// </summary>
    public partial class DKDVCN : Page
    {
        private CollectionViewSource DVsource;
        public DKDVCN()
        {
            InitializeComponent();
            DVsource = (CollectionViewSource)FindResource(nameof(DVsource));
            DVsource.Source = DichVuController.LayDsDV();

           
        }
    
    }
}
