using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Controller;
namespace Quan_Ly_KTX.View
{
    public class MaPhongList
    {
        public int mp { get; set; }
        public List<MaPhongList> DsMp { get; set; }
        private List<int> loc;
        public MaPhongList(int mp)
        {
            this.mp = mp;
        }
        public void LayDSMaPhong()
        {
            DsMp= SQLworker.LayDSMPtoanbo(loc);
        }

        public MaPhongList(List<int> a)
        {
            loc = a;
        }
    }
}
