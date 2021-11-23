using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_120_A.Models
{
    public partial class TokoNusantaraContext : DbContext
    {
        public TokoNusantaraContext()
        {
        }

        public TokoNusantaraContext(DbContextOptions<TokoNusantaraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adminnn> Adminnns { get; set; }
        public virtual DbSet<Barangg> Baranggs { get; set; }
        public virtual DbSet<Pelanggann> Pelangganns { get; set; }
        public virtual DbSet<Trx> Trxes { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Adminnn>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__Adminnn__89472E95E358AF56");

                entity.ToTable("Adminnn");

                entity.Property(e => e.IdAdmin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_admin");

                entity.Property(e => e.AlamatAdmin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("alamat_admin");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nama_admin");
            });

            modelBuilder.Entity<Barangg>(entity =>
            {
                entity.HasKey(e => e.IdBarang)
                    .HasName("PK__Barangg__7DF3604714C4CE4B");

                entity.ToTable("Barangg");

                entity.Property(e => e.IdBarang)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Id_barang");

                entity.Property(e => e.Harga).HasColumnName("harga");

                entity.Property(e => e.JenisBarang)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jenis_barang");

                entity.Property(e => e.NamaBarang)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("nama_barang");

                entity.Property(e => e.UkuranBarang)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ukuran_barang");
            });

            modelBuilder.Entity<Pelanggann>(entity =>
            {
                entity.HasKey(e => e.IdPembeli)
                    .HasName("PK__Pelangga__153D2133F702FFFD");

                entity.ToTable("Pelanggann");

                entity.Property(e => e.IdPembeli)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Id_Pembeli");

                entity.Property(e => e.AlamatPembeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamatPembeli");

                entity.Property(e => e.NamaPembeli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("namaPembeli");
            });

            modelBuilder.Entity<Trx>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Trx");

                entity.Property(e => e.IdAdmin)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("id_admin");

                entity.Property(e => e.IdBarang)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("id_barang");

                entity.Property(e => e.IdPembeli)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id_Pembeli");

                entity.Property(e => e.IdTrx)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("id_trx");

                entity.Property(e => e.TanggalTrx)
                    .HasColumnType("datetime")
                    .HasColumnName("tanggal_trx");

                entity.Property(e => e.TotalTrx).HasColumnName("totalTrx");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK__Trx__id_admin__4AB81AF0");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK__Trx__id_barang__49C3F6B7");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("FK__Trx__id_Pembeli__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
