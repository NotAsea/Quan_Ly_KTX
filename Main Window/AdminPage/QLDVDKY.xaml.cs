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
using Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow;
using Quan_Ly_KTX.View;
namespace Quan_Ly_KTX.Main_Window.AdminPage
{
    /// <summary>
    /// Interaction logic for QLDVDKY.xaml
    /// </summary>
    public partial class QLDVDKY : Page
    {
        private CollectionViewSource DVDKList;
        private ICollection<dvDK> ds;
            public QLDVDKY()
        {
            InitializeComponent();
                DVDKList = (CollectionViewSource)FindResource(nameof(DVDKList));
            ds = LichSuDK.LayDsDK();
                DVDKList.Source = ds;
            }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var item = ElementtoFind.Text;
            if (!String.IsNullOrWhiteSpace(item))
            {
                var number = new String(item.Where(Char.IsDigit).ToArray());

                DVDKList.Source = number.Length switch
                {
                    int x when x == item.Length => ds.Where(x => x.giadv == int.Parse(item)),
                    int y when (y == item.Length - 2 || y == 0) => ds.Where(x => x.tendv.Contains(item)|| x.tensv.Contains(item) || x.msv.Contains(item)),
                    _ => null,
                };
                if (DVDKList.Source is null) ElementtoFind.Text = "không có  bản ghi mời nhập lại";
            }
            else DVDKList.Source = ds;
        }

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var row = dsdvdk.SelectedItem as dvDK;
            var kq = LichSuDK.XoaDvDk(row);
            if (kq)
            {
                MessageBox.Show("Đã xóa ", "thông báo");
                ds = LichSuDK.LayDsDK();
                DVDKList.Source = ds;
            }
            else MessageBox.Show("Đã có lỗi xảy ra", "thông báo");
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
