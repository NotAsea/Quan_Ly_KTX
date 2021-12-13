using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan_Ly_KTX.Models;
namespace Quan_Ly_KTX.View
{
    public class dvDK
    {
        public string tensv { get; set; }
        public int Madk { get; set; }
        public string tendv { get; set; }   
        public int giadv { get; set; }
        public string msv { get; set; }
        public dvDK(int madk, string tendv, int giadv)
        {
            Madk = madk;
            this.tendv = tendv;
            this.giadv = giadv;
           
        }
        public dvDK(int Mdk, string msv)
        {
            Madk = Mdk;
            this.msv = msv;
        }

        public dvDK(string tensv, int madk, string tendv, int giadv, string msv)
        {
            this.tensv = tensv;
            Madk = madk;
            this.tendv = tendv;
            this.giadv = giadv;
            this.msv = msv;
        }

        public Đkdvcn todk()
        {
            Đkdvcn dk = new();
            dk.MaDk = Madk;
            dk.MaDv = Madk;
            dk.Msv = msv;
            return dk;
        }
    }
}
