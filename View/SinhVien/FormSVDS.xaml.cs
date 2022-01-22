using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.Main_Window.SVPage;
using Quan_Ly_KTX.SVPage;
using Quan_Ly_KTX.View;
using System.Windows;
using System.Windows.Controls;
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
            this.WindowState = WindowState.Maximized;
            this.MaxHeight = SystemParameters.WorkArea.Height + 12;
            this.MaxWidth = SystemParameters.WorkArea.Width + 12;
            InitializeComponent();
            ID = id;
            SV = QLSVController.Controller.LaySV(ID);

            if (SV != null)
            {
                AddInfo.Visibility = Visibility.Collapsed;
                inra.DataContext = SV;
            }
            else
            {
                EditInfo.Visibility = Visibility.Collapsed;
                HistoryDV.Visibility = Visibility.Collapsed;
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

            QLSVController.Controller.FreeController();
            QLDVController.Controller.FreeController();
            LichSuDK.Controller.FreeController();
            this.Close();
        }
    }
}
