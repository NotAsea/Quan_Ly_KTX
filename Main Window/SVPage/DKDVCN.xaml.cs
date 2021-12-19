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
using Quan_Ly_KTX.Models;
using System.Data;
namespace Quan_Ly_KTX.SVPage
   
{
    /// <summary>
    /// Interaction logic for DKDVCN.xaml
    /// </summary>
    public partial class DKDVCN : Page
    {
        private string msv;
        private CollectionViewSource DVsource;
        private List<dvDK> dkList = new();
        private List<Đkdvcn> listToAdd = new();
        public DKDVCN(String s)
        {
            InitializeComponent();
            DVsource = (CollectionViewSource)FindResource(nameof(DVsource));
            DVsource.Source = QLDVController.Controller.LayDsDV();
            msv = s;

        }

        private void dichvuList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var row = dvList.SelectedItem as DichVu ;
               dkList.Add(new dvDK(row!.MaDv, row!.TenDv, row.GiaDv ));
            dichvuDK.ItemsSource = null;
            dichvuDK.ItemsSource = dkList;
            var d = new dvDK(row.MaDv, msv);
            
           var r= d.ToDKdv();
            listToAdd.Add(r);

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
          

            try
            {
                QLDVController.Controller.ĐangKyDV(listToAdd.ToArray());
                MessageBox.Show("Đăng ký dịch vụ thành công","Đăng ký dịch vụ");
                dichvuDK.ItemsSource = null;
            }catch(Exception ex)
            {
                MessageBox.Show("đã có lỗi xảy ra " + ex.Message, "Đăng ký dịch vụ");
            }
        }

       
    }
}
