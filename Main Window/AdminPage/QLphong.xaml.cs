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
    /// Interaction logic for QLphong.xaml
    /// </summary>
    public partial class QLphong : Page
    {
        private CollectionViewSource PList;
        private ICollection<phongs> ds;
        public QLphong()
        {
            InitializeComponent();
            PList = (CollectionViewSource)FindResource(nameof(PList));
            ds= PhongController.LayDsPhong();
            PList.Source = ds;

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var item = ElementtoFind.Text;
            if (!String.IsNullOrWhiteSpace(item))
            {
                var number = new String(item.Where(Char.IsDigit).ToArray());

                PList.Source = number.Length switch
                {
                    int x when x == item.Length => ds.Where(x => x.Maphong == int.Parse(item) ),
                    int y when (y == item.Length - 2 || y == 0) => ds.Where(x => x.ttphong.Contains(item) || x.loaiphong.Contains(item) || x.tenhe.Contains( item)),
                    _=> null,
                };
                if (PList.Source is null) ElementtoFind.Text = "không có  bản ghi mời nhập lại";
            }
            else PList.Source = ds;
        }
    

        private void AddNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
