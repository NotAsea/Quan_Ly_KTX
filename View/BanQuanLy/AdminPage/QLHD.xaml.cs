using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow;
using Quan_Ly_KTX.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            bang.Visibility = Visibility.Hidden;
            ThemHD.Visibility = Visibility.Hidden;
        }

        private Visibility IsVisibility;
        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var item = ElementtoFind.Text;
            if (!String.IsNullOrWhiteSpace(item))
            {
                var number = new String(item.Where(Char.IsDigit).ToArray());

                HDList.Source = number.Length switch
                {
                    int x when x == item.Length => ds.Where(x => x.TongTien == int.Parse(item) || x.Maphong == int.Parse(item)),
                    int y when (y == item.Length - 2 || y == 0) =>   ds.Where(x => x.MaSv.Contains(item) || x.TenSV.Contains(item) || x.DichVuChung.Contains(item) || x.Dichvurieng.Contains(item)),

                };

                if (HDList.Source is null) ElementtoFind.Text = "không có  bản ghi mời nhập lại";
            }
            else HDList.Source = ds;
        }

        private void ThemHD_Click(object sender, RoutedEventArgs e)
        {
            var loc = ds.Select(x => x.Maphong).ToList();
            AddBill ab = new(loc);
            ab.Show();
            ab.OnAdded += (sender, e) =>
            {
                ds = HaoDonController.Controller.LayDSHoaDon();
                HDList.Source = ds;
            };
        }
               
        private void DS_Checked(object sender, RoutedEventArgs e)
        {
            bang.Visibility = Visibility.Visible;
            bang.Columns[3].Visibility = Visibility.Visible;
            bang.Columns[0].Visibility = Visibility.Visible;
            ThemHD.Visibility = Visibility.Visible;
            ds = HaoDonController.Controller.LayDSHoaDon();
            HDList.Source = ds;
        }

        private void QS_Checked(object sender, RoutedEventArgs e)
        {
            bang.Visibility = Visibility.Visible;
            HaoDonController.Controller.FreeController();
            bang.Columns[3].Visibility = Visibility.Collapsed;
            bang.Columns[0].Visibility = Visibility.Collapsed;
            ThemHD.Visibility = Visibility.Hidden;
            ds = HaoDonController.Controller.LayDSHdQuanSu();
            HDList.Source = ds;
            HaoDonController.Controller.FreeController();
        }
    }
}
