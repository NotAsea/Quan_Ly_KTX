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
namespace Quan_Ly_KTX
{
    /// <summary>
    /// Interaction logic for FormSVDS.xaml
    /// </summary>
    public partial class FormSVDS : Window
    {
        public int ID { get; init; }
      //  public InfoSV InfoSV { get; init; }
        public FormSVDS()
        {
            InitializeComponent();
        }
        public FormSVDS(int id)
        {
           _= new FormSVDS();
            this.ID = id;
          //  this.InfoSV = SQLworker.LayDSSV(ID);
}

        private void AddInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewDV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignDV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HistoryDV_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
