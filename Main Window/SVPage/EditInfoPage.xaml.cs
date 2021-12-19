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
using Microsoft.EntityFrameworkCore;
using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;

namespace Quan_Ly_KTX.SVPage
{
    /// <summary>
    /// Interaction logic for EditInfoPage.xaml
    /// </summary>
    public partial class EditInfoPage : Page
    {
        private InfoSV Sv;
        private int ID;
        public EditInfoPage(InfoSV sv)
        {
            InitializeComponent();
            this.DataContext = sv;
            ID = sv.ID;
            Sv = sv;
        }


        private void EditMsv_Click(object sender, RoutedEventArgs e)
        {

            var s = msv.Text;
            Sv.MSV = s;
            MessageBox.Show($"bạn vừa sửa giá trị mới là {s}", "thông báo");
        }
    
    

        private void EditGT_Click(object sender, RoutedEventArgs e)
        {
            
          
        }

        private void EditNS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditNh_Click(object sender, RoutedEventArgs e)
        {
            var s = int.Parse(nh.Text);
            Sv.Nh = s;
            MessageBox.Show($"bạn vừa sửa giá trị mới là {s}", "thông báo");
        }

        private void EditMp_Click(object sender, RoutedEventArgs e)
        {
            var s= int.Parse(mp.Text);
            Sv.MaPhong = s;
        MessageBox.Show($"bạn vừa sửa giá trị mới là {s}", "thông báo");
    }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
                QLSVController.Controller.UpdateInfoSV(Sv);
                MessageBox.Show("Cập nhập thành công", "Form thông báo");
           // Sv = new();
            this.DataContext = QLSVController.Controller.LaySV(ID);
            QLSVController.Controller.FreeController();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
