using System;
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
