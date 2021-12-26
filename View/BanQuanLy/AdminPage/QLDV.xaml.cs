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
    /// Interaction logic for QLDV.xaml
    /// </summary>
    public partial class QLDV : Page
    {
        private CollectionViewSource DVList;
        private ICollection<Infodichvu> ds;
        public QLDV()
        {
            InitializeComponent();
            DVList = (CollectionViewSource)FindResource(nameof(DVList));
            ds = QLDVController.Controller.LayDv();
            DVList.Source = ds;
        }


        private void OnSucess_handle(object sender, EventArgs e)
        {
            ds = QLDVController.Controller.LayDv();
            DVList.Source = ds;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var row = dsdv.SelectedItem as Infodichvu;
            EditDv ed = new(row);
            ed.Show();
            ed.OnUpdated += new EventHandler(OnSucess_handle);

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var row = dsdv.SelectedItem as Infodichvu;
            var kq = QLDVController.Controller.XoaDv(row);
            if (kq)
            {
                MessageBox.Show("Đã xóa ", "thông báo");
                ds = QLDVController.Controller.LayDv();
                DVList.Source = ds;
            }
            else MessageBox.Show("Đã có lỗi xảy ra", "thông báo");
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var item = ElementtoFind.Text;
            if (!String.IsNullOrWhiteSpace(item))
            {
                var number = new String(item.Where(Char.IsDigit).ToArray());

                DVList.Source = number.Length switch
                {
                    int x when x == item.Length => ds.Where(x => x.MaDv == int.Parse(item) || x.GiaDv == int.Parse(item)),
                    int y when (y == item.Length - 2 || y == 0) => ds.Where(x => x.TenDv.Contains(item)),
                    _ => null,
                };
                if (DVList.Source is null) ElementtoFind.Text = "không có  bản ghi mời nhập lại";
            }
            else DVList.Source = ds;
        }


        private void AddNew_Click(object sender, RoutedEventArgs e)
        {
            AddDV ad = new();
            ad.Show();
            ad.onSucess += new EventHandler(OnSucess_handle);
        }
    }
}
