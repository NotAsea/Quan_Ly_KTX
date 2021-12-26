using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.View;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Quan_Ly_KTX.Main_Window.SVPage
{
    /// <summary>
    /// Interaction logic for History_dv.xaml
    /// </summary>
    public partial class History_dv : Page
    {
        private CollectionViewSource LsDangKy;
        private string msv;

        private ICollection<HistoryDv> ds;
        public History_dv(string msv)
        {
            InitializeComponent();
            LsDangKy = (CollectionViewSource)FindResource(nameof(LsDangKy));
            ds = LichSuDK.Controller.layLsSV(msv);
            LsDangKy.Source = ds;
            var tongcong = new tongcong(ds.Sum(x => x.giadv));
            Totalrow.DataContext = tongcong;

        }
    }
}
