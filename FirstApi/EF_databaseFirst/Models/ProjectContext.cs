using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_databaseFirst.Models;

public partial class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<Phim> Phims { get; set; }

    public virtual DbSet<PhongChieu> PhongChieus { get; set; }

    public virtual DbSet<Rap> Raps { get; set; }

    public virtual DbSet<SuatChieu> SuatChieus { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=hoang;Data Source=.; database=project; Integrated security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__hoa_don__527FA443F301F13E");

            entity.ToTable("hoa_don");

            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ma_hoa_don");
            entity.Property(e => e.HinhThucThanhToan)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Hinh_thuc_thanh_toan");
            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Ma_tai_khoan");
            entity.Property(e => e.ThoiGian)
                .HasColumnType("datetime")
                .HasColumnName("Thoi_gian");
            entity.Property(e => e.TongGia)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Tong_gia");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaTaiKhoan)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__hoa_don__Ma_tai___3D5E1FD2");
        });

        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.MaPhim).HasName("PK__phim__B2DA0C10D87A46EA");

            entity.ToTable("phim");

            entity.Property(e => e.MaPhim)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_phim");
            entity.Property(e => e.TenPhim)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Ten_phim");
            entity.Property(e => e.TheLoai)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("The_loai");
            entity.Property(e => e.ThoiLuong)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("Thoi_luong");
        });

        modelBuilder.Entity<PhongChieu>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__phong_ch__E945AB26ED54F547");

            entity.ToTable("phong_chieu");

            entity.Property(e => e.MaPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ma_phong");
            entity.Property(e => e.LoaiPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Loai_phong");
            entity.Property(e => e.MaRap)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ma_rap");
            entity.Property(e => e.TenPhong)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Ten_phong");

            entity.HasOne(d => d.MaRapNavigation).WithMany(p => p.PhongChieus)
                .HasForeignKey(d => d.MaRap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__phong_chi__Ma_ra__440B1D61");
        });

        modelBuilder.Entity<Rap>(entity =>
        {
            entity.HasKey(e => e.MaRap).HasName("PK__rap__C933BC9348CE3D16");

            entity.ToTable("rap");

            entity.Property(e => e.MaRap)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ma_rap");
            entity.Property(e => e.DanhGia)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Danh_gia");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Dia_chi");
            entity.Property(e => e.TenRap)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Ten_rap");
        });

        modelBuilder.Entity<SuatChieu>(entity =>
        {
            entity.HasKey(e => e.MaSc).HasName("PK__suat_chi__2E62F357A06821CA");

            entity.ToTable("suat_chieu");

            entity.Property(e => e.MaSc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_SC");
            entity.Property(e => e.BatDau)
                .HasColumnType("datetime")
                .HasColumnName("Bat_dau");
            entity.Property(e => e.MaPhim)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_phim");
            entity.Property(e => e.MaPhong)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ma_phong");
            entity.Property(e => e.Ngay).HasColumnType("date");

            entity.HasOne(d => d.MaPhimNavigation).WithMany(p => p.SuatChieus)
                .HasForeignKey(d => d.MaPhim)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__suat_chie__Ma_ph__46E78A0C");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.SuatChieus)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__suat_chie__Ma_ph__47DBAE45");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__tai_khoa__647B300C2716859E");

            entity.ToTable("tai_khoan");

            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Ma_tai_khoan");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MatKhau)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Mat_khau");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.TenKhachHang)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Ten_khach_hang");
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.MaVe).HasName("PK__ve__2E61CEE78BF7B645");

            entity.ToTable("ve");

            entity.Property(e => e.MaVe)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_ve");
            entity.Property(e => e.GiaVe)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("Gia_ve");
            entity.Property(e => e.Hang)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.MaHoaDon)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Ma_hoa_don");
            entity.Property(e => e.MaSc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ma_SC");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ve__Ma_hoa_don__4CA06362");

            entity.HasOne(d => d.MaScNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.MaSc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ve__Ma_SC__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
