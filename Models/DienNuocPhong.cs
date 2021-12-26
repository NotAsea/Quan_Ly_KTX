namespace Quan_Ly_KTX.Models
{
    public partial class DienNuocPhong
    {
        public int MaPhong { get; set; }
        public int GiaDien { get; set; }
        public int GiaNuoc { get; set; }

        public virtual Phong MaPhongNavigation { get; set; } = null!;
    }
}
