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
namespace Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow
{
    /// <summary>
    /// Interaction logic for EditSv.xaml
    /// </summary>
    public partial class EditSv : Window
    {
        private InfoSV sv;
        public event EventHandler onClosed;
        public EditSv(InfoSV s)
        {
            InitializeComponent();
            sv = s;
            this.DataContext = sv;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            sv.MaPhong = int.Parse(mp.Text);
            try
            {
                AddInfoSVController.UpdateInfoSV(sv);
                MessageBox.Show("Cập nhập thành công", "thông báo");
                onClosed(this, new EventArgs());
                this.Hide();
                
            }
            catch(Exception er) { MessageBox.Show("Cập nhập thất bại", "thông báo"); }
        }
    }
}
