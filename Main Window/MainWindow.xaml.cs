using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Quan_Ly_KTX;
using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.Main_Window;
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
            if (String.IsNullOrWhiteSpace(UserName.Text))  s += "Trường tên ĐN còn trống ";
            
            if (String.IsNullOrWhiteSpace(Password.Password)) s += "Trường mk còn trống";
            if (!String.IsNullOrWhiteSpace(s))  _=MessageBox.Show(s, "FormĐN");
           Mouse.OverrideCursor= System.Windows.Input.Cursors.Wait;
            var (result,ID) =await LogginController.IsLoggin(UserName.Text, Password.Password);
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            if (result == "User" )
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
            else  MessageBox.Show(result, "FormĐN");
           
               }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            Window1 dk = new() { Owner = this };

            dk.Show();
        }
    }
}
