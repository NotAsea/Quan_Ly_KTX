using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Quan_Ly_KTX.Models
{
    public partial class KTX_KMAContext : DbContext
    {
        public KTX_KMAContext()
        {
        }

        public KTX_KMAContext(DbContextOptions<KTX_KMAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DichVu> DichVus { get; set; } = null!;
        public virtual DbSet<DienNuocPhong> DienNuocPhongs { get; set; } = null!;
        public virtual DbSet<He> Hes { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;
        public virtual DbSet<UserNguoiDung> UserNguoiDungs { get; set; } = null!;
        public virtual DbSet<VaiTro> VaiTros { get; set; } = null!;
        public virtual DbSet<Đkdvcn> Đkdvcns { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q5MH825\\HAILUONG;Initial Catalog=KTX_KMA;Persist Security Info=True;User ID=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasKey(e => e.MaDv)
                    .HasName("PK__DichVu__2725865798DA0E8D");

                entity.ToTable("DichVu");

                entity.HasIndex(e => e.TenDv, "UQ__DichVu__AD1E9A0828711DB2")
                    .IsUnique();

                entity.Property(e => e.MaDv)
                    .ValueGeneratedNever()
                    .HasColumnName("MaDV");

                entity.Property(e => e.GiaDv).HasColumnName("GiaDV");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(15)
                    .HasColumnName("Ten_DV");
            });

            modelBuilder.Entity<DienNuocPhong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__DienNuoc__20BD5E5B29B92346");

                entity.ToTable("DienNuocPhong");

                entity.Property(e => e.MaPhong).ValueGeneratedNever();

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithOne(p => p.DienNuocPhong)
                    .HasForeignKey<DienNuocPhong>(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DienNuocP__MaPho__02FC7413");
            });

            modelBuilder.Entity<He>(entity =>
            {
                entity.HasKey(e => e.MaHe)
                    .HasName("PK__He__2725A6C1FFBB64DF");

                entity.ToTable("He");

                entity.Property(e => e.MaHe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenHe).HasMaxLength(75);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HoaDon__2725A6E008C94F23");

                entity.ToTable("HoaDon");

                entity.Property(e => e.MaHd)
                    .ValueGeneratedNever()
                    .HasColumnName("MaHD");

                entity.Property(e => e.GiaHd).HasColumnName("Gia_HD");

                entity.Property(e => e.MaDk).HasColumnName("MaDK");

                entity.Property(e => e.Msv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MSV")
                    .IsFixedLength();

                entity.HasOne(d => d.MaDkNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaDk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__MaDK__2D27B809");

                entity.HasOne(d => d.MsvNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Msv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HoaDon__MSV__2C3393D0");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__Phong__20BD5E5B907D7152");

                entity.ToTable("Phong");

                entity.Property(e => e.MaPhong).ValueGeneratedNever();

                entity.Property(e => e.LoaiPhong)
                    .HasMaxLength(3)
                    .HasColumnName("Loai_Phong")
                    .IsFixedLength();

                entity.Property(e => e.MaHe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TinhTrangPhong).HasMaxLength(75);

                entity.HasOne(d => d.MaHeNavigation)
                    .WithMany(p => p.Phongs)
                    .HasForeignKey(d => d.MaHe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Phong__MaHe__3B75D760");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.Msv)
                    .HasName("PK__SinhVien__C790E5AC6E28652E");

                entity.ToTable("SinhVien");

                entity.Property(e => e.Msv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MSV")
                    .IsFixedLength();

                entity.Property(e => e.GioiTinh)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("('Nam')");

                entity.Property(e => e.Hoten).HasMaxLength(75);

                entity.Property(e => e.IdUser).HasColumnName("ID_user");

                entity.Property(e => e.MaHe)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__SinhVien__ID_use__6E01572D");

                entity.HasOne(d => d.MaHeNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaHe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SV_MaHe");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("eee");
            });

            modelBuilder.Entity<UserNguoiDung>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User_Ngu__D7B4671EE648CCDD");

                entity.ToTable("User_NguoiDung");

                entity.Property(e => e.IdUser).HasColumnName("ID_user");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Username).HasMaxLength(75);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserNguoiDungs)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_Role");
            });

            modelBuilder.Entity<VaiTro>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__VaiTro__8AFACE3A82FFA4E1");

                entity.ToTable("VaiTro");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Đkdvcn>(entity =>
            {
                entity.HasKey(e => e.MaDk)
                    .HasName("PK__ĐKDVCN__2725866C4C5403DE");

                entity.ToTable("ĐKDVCN");

                entity.Property(e => e.MaDk).HasColumnName("MaDK");

                entity.Property(e => e.MaDv).HasColumnName("MaDV");

                entity.Property(e => e.Msv)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MSV")
                    .IsFixedLength();

                entity.HasOne(d => d.MsvNavigation)
                    .WithMany(p => p.Đkdvcns)
                    .HasForeignKey(d => d.Msv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ĐKDVCN__MSV__29572725");

                entity.HasMany(d => d.MaDvs)
                    .WithMany(p => p.MaDks)
                    .UsingEntity<Dictionary<string, object>>(
                        "DvĐkdvcn",
                        l => l.HasOne<DichVu>().WithMany().HasForeignKey("MaDv").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__DV_ĐKDVCN__MaDV__33D4B598"),
                        r => r.HasOne<Đkdvcn>().WithMany().HasForeignKey("MaDk").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__DV_ĐKDVCN__MaDK__32E0915F"),
                        j =>
                        {
                            j.HasKey("MaDk", "MaDv").HasName("PK__DV_ĐKDVC__4557DE099EA7EDDE");

                            j.ToTable("DV_ĐKDVCN");

                            j.IndexerProperty<int>("MaDk").HasColumnName("MaDK");

                            j.IndexerProperty<int>("MaDv").HasColumnName("MaDV");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
