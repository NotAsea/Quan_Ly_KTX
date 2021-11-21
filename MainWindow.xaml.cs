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

        private void Loggin_Click(object sender, RoutedEventArgs e)
        {
            String s = "";
            if (String.IsNullOrWhiteSpace(UserName.Text))  s += "Trường tên ĐN còn trống ";
            
            if (String.IsNullOrWhiteSpace(Password.Text)) s += "Trường mk còn trống";
            if (!String.IsNullOrWhiteSpace(s))  _=MessageBox.Show(s, "FormĐN");
            var (result,ID) = LogginController.IsLoggin(UserName.Text, Password.Text);
            if (result == "User")
            {
                FormSVDS sv = new();
                this.Close();
                sv.Show();
            }
            else MessageBox.Show(result, "FormĐN");
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            Window1 dk = new();
            dk.Show();
        }
    }
}
