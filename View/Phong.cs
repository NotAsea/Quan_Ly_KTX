using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_KTX.View
{
    internal class Phongs
    {
        public String ttphong { get; set; }
        public String loaiphong { get; set; }
        public int Maphong { get; set; }    
        public String tenhe { get; set; }

        public Phongs(string ttphong, string loaiphong, int maphong, string tenhe)
        {
            this.ttphong = ttphong;
            this.loaiphong = loaiphong;
            Maphong = maphong;
            this.tenhe = tenhe;
        }
    }
}
