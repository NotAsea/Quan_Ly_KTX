using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System;
using System.Windows;
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
            sv.LayDsMp();
            this.DataContext = sv;
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            var mp = MaPhong.SelectedItem as tongcong;

            sv.MaPhong = mp.total;
            try
            {
                QLSVController.Controller.UpdateInfoSV(sv);
                MessageBox.Show("Cập nhập thành công", "thông báo");
                onClosed(this, new EventArgs());
                QLSVController.Controller.FreeController();
                this.Hide();

            }
            catch (Exception) { MessageBox.Show("Cập nhập thất bại", "thông báo"); }
        }
    }
}
