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
using Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow;
namespace Quan_Ly_KTX.Main_Window.AdminPage
{
    /// <summary>
    /// Interaction logic for QLSV.xaml
    /// </summary>
    public partial class QLSV : Page
    {
        private CollectionViewSource SVList;
        private ICollection<InfoSV> ds;
        public QLSV()
        {
            InitializeComponent();
            SVList = (CollectionViewSource)FindResource(nameof(SVList));
            ds= QLSVController.LayToanBoSv();
            SVList.Source = ds;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var row = dssv.SelectedItem as InfoSV;
            EditSv ed = new(row);
            ed.Show();
            ed.onClosed += new EventHandler(ResponseHandler);
        }
        private void ResponseHandler(object sender, EventArgs e)
        {
            ds = QLSVController.LayToanBoSv();
            SVList.Source = ds;
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var row = dssv.SelectedItem as InfoSV;
            var kq = QLSVController.XoaSV(row);
            if (kq) {
                MessageBox.Show("Đã xóa Sinh viên", "yhông báo"); 
                ds = QLSVController.LayToanBoSv(); 
                SVList.Source = ds; 
            }
            else MessageBox.Show("Đã có lỗi xảy ra", "thông báo");

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            var item = ElementtoFind.Text;
            string number = "";
            if (!String.IsNullOrWhiteSpace(item))
            {
                DateTime? d = null;
                try
                {
                    d = DateTime.Parse(item);
                }
                catch (Exception) { }
                if (d == null) { number = new String(item.Where(Char.IsDigit).ToArray()); }
                else number = d.ToString();
                SVList.Source = number.Length switch
                {
                    int x when x == item.Length => ds.Where(x => x.MaPhong == int.Parse(item) || x.Nh == int.Parse(item)),
                    int y when (y == item.Length - 2 || y == 0) => ds.Where(x => x.MSV.Contains(item) || x.HoTen.Contains(item) || x.TenHe.Contains(item) || x.GT == item),
                    _ => ds.Where(x => x.NS == DateTime.Parse(number)),
                };
                if (SVList.Source is null) ElementtoFind.Text = "không có  bản ghi mời nhập lại";
            }
            else SVList.Source = ds;
            
        }
    }
}
