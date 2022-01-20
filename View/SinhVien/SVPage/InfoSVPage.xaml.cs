using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System.Windows;
using System.Windows.Controls;

namespace Quan_Ly_KTX.SVPage
{
    /// <summary>
    /// Interaction logic for EditInfoPage.xaml
    /// </summary>
    public partial class EditInfoPage : Page
    {
       
        
        public EditInfoPage(InfoSV sv)
        {
            InitializeComponent();
            this.DataContext = sv;
          
         }


       
    }
}
