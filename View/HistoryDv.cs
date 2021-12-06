using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Controller;
using Quan_Ly_KTX.Models;
namespace Quan_Ly_KTX.View
{
    public class HistoryDv
    {
        public int stt { get; set; }
        public String tendv { get; set; }   
        public int giadv { get; set; }

        public HistoryDv(int stt, string tendv, int giadv)
        {
            this.stt = stt;
            this.tendv = tendv;
            this.giadv = giadv;
        }

        
    }
}
