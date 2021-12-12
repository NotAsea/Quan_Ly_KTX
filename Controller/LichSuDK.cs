using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.View;
using Quan_Ly_KTX.Models;

namespace Quan_Ly_KTX.Controller
{
    public static class LichSuDK
    {
        public static ICollection<HistoryDv> layLsSV( String msv)
        {
            List<HistoryDv> ds;
            
                ds = SQLConnection.Instance.Đkdvcns.Join(SQLConnection.Instance.DichVus, a => a.MaDv, b => b.MaDv, (c, d) => new
                {
                    c.Msv,
                    c.MaDk,
                    d.MaDv,
                    d.GiaDv,
                    d.TenDv
                }).Where(c => c.Msv == msv).Select(a => new HistoryDv( a.MaDk,a.TenDv, a.GiaDv)).ToList();
            
            return ds;
        }
      
    }
}
