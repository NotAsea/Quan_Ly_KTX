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
using Quan_Ly_KTX.SVPage;
using Quan_Ly_KTX.Main_Window.SVPage;
namespace Quan_Ly_KTX
{
    /// <summary>
    /// Interaction logic for FormSVDS.xaml
    /// </summary>
    public partial class FormSVDS : Window
    {
        public int ID { get; init; }

        private static InfoSV? SV;
        public FormSVDS(int id)
        {
            InitializeComponent();
            ID= id;
            SV = SQLworker.LaySV(ID);
           
            if (SV != null)
            {
                AddInfo.Visibility = Visibility.Collapsed;
                inra.DataContext = SV;
            }
            else
            {
                EditInfo.Visibility=Visibility.Collapsed;
                HistoryDV.Visibility=Visibility.Collapsed;
                inra.Visibility = Visibility.Hidden;
                SignDV.Visibility = Visibility.Collapsed;

            }
        }


        private void AddInfo_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Frame() { Content = new AddInfoPage(this.ID, this) };
        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Frame() { Content = new EditInfoPage(SV) };
        }

    

        private void SignDV_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Frame() { Content = new DKDVCN(SV.MSV) };
        }

        private void HistoryDV_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Frame() { Content = new History_dv(SV.MSV) };
        }

        private void Loginout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new();
            m.Show();
            this.Close();
        }
    }
}
