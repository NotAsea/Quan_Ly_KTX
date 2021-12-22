using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.Main_Window;
using System;
using System.Windows;
using System.Windows.Input;
namespace Quan_Ly_KTX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void Loggin_Click(object sender, RoutedEventArgs e)
        {
            String s = "";
            if (String.IsNullOrWhiteSpace(UserName.Text)) s += "Trường tên ĐN còn trống ";

            if (String.IsNullOrWhiteSpace(Password.Password)) s += "Trường mk còn trống";
            if (!String.IsNullOrWhiteSpace(s)) _ = MessageBox.Show(s, "FormĐN");
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            var (result, ID) = await LogginController.IsLoggin(UserName.Text, Password.Password);
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            if (result == "User")
            {
                FormSVDS sv = new(ID);
                this.Close();
                sv.Show();
                SQLConnection.FreeScope();
            }
            else if (result == "Admin")
            {
                FormAdmin ad = new();
                this.Close();
                ad.Show();
                SQLConnection.FreeScope();

            }
            else MessageBox.Show(result, "FormĐN");

        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            Window1 dk = new() { Owner = this };

            dk.Show();
        }
    }
}
