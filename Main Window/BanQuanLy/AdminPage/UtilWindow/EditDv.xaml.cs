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
    /// Interaction logic for EditDv.xaml
    /// </summary>
    public partial class EditDv : Window
    {
        private Infodichvu dv;
        public EditDv( Infodichvu d)
        {
            InitializeComponent();
            dv=d;
            this.DataContext = d;
        }
        public event EventHandler OnUpdated;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            dv.MaDv = int.Parse(mdv.Text);
            dv.GiaDv = int.Parse(gdv.Text);
            dv.TenDv = tdv.Text;
            try
            {
                QLDVController.Controller.CapnhapDv(dv);
                MessageBox.Show("Cập nhập thành công", "thông báo");
                OnUpdated(this, new EventArgs());
                QLDVController.Controller.FreeController();
                this.Hide();
            }
            catch (Exception) { MessageBox.Show("Cập nhập thất bại", "thông báo"); }
            
        }
    }
}
