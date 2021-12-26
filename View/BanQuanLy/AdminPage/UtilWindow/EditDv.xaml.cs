using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System;
using System.Windows;
namespace Quan_Ly_KTX.Main_Window.AdminPage.UtilWindow
{
    /// <summary>
    /// Interaction logic for EditDv.xaml
    /// </summary>
    public partial class EditDv : Window
    {
        private Infodichvu dv;
        public EditDv(Infodichvu d)
        {
            InitializeComponent();
            dv = d;
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
