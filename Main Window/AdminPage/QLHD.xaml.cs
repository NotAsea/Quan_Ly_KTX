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
namespace Quan_Ly_KTX.Main_Window.AdminPage
{
    /// <summary>
    /// Interaction logic for QLHD.xaml
    /// </summary>
    public partial class QLHD : Page
    {
        private CollectionViewSource HDList;
        private ICollection<InfoHD> ds;
        public QLHD()
        {
            InitializeComponent();
            HDList = (CollectionViewSource)FindResource(nameof(HDList));
            ds = QLDVController.LayDSHoaDon();
            HDList.Source = ds;

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var item = ElementtoFind.Text;
            if (!String.IsNullOrWhiteSpace(item))
            {
              var   number = new String(item.Where(Char.IsDigit).ToArray());

                HDList.Source = number.Length switch
                {
                    int x when x == item.Length => ds.Where(x => x.Msv.Contains( item) || x.Hoten.Contains(item) ||  x.Tendv.Contains(item)  ),
                    int y when (y == item.Length - 2 || y == 0) => ds.Where(x=> x.Mdv == int.Parse(item)|| x.GiaHd == int.Parse(item) || x.MaHd == int.Parse(item)) ,
                    
                };
                if (HDList.Source is null) ElementtoFind.Text = "không có  bản ghi mời nhập lại";
            }
            else HDList.Source = ds;
        }
    }
}
