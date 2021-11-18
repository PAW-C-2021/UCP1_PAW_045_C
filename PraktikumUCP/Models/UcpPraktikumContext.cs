using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PraktikumUCP.Models
{
    public partial class UcpPraktikumContext : DbContext
    {
        public UcpPraktikumContext()
        {
        }

        public UcpPraktikumContext(DbContextOptions<UcpPraktikumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barang { get; set; }
        public virtual DbSet<Pelayan> Pelayan { get; set; }
        public virtual DbSet<Pembayaran> Pembayaran { get; set; }
        public virtual DbSet<Pembeli> Pembeli { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Transaksi> Transaksi { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.Property(e => e.IdBarang)
                    .HasColumnName("ID_Barang")
                    .ValueGeneratedNever();

                entity.Property(e => e.HargaBarang).HasColumnName("Harga_Barang");

                entity.Property(e => e.IdSupplier).HasColumnName("ID_Supplier");

                entity.Property(e => e.NamaBarang)
                    .HasColumnName("Nama_Barang")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StockBarang).HasColumnName("Stock_barang");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Barang)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK_Barang_Supplier");
            });

            modelBuilder.Entity<Pelayan>(entity =>
            {
                entity.HasKey(e => e.IdPelayan);

                entity.Property(e => e.IdPelayan)
                    .HasColumnName("ID_Pelayan")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlamatPelayan)
                    .HasColumnName("Alamat_Pelayan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPelayan)
                    .HasColumnName("Nama_Pelayan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoTelpPelayan)
                    .HasColumnName("NoTelp_Pelayan")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran);

                entity.Property(e => e.IdPembayaran)
                    .HasColumnName("ID_Pembayaran")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPelayan).HasColumnName("ID_Pelayan");

                entity.Property(e => e.IdTransaksi).HasColumnName("ID_Transaksi");

                entity.Property(e => e.TotalPembayaran).HasColumnName("Total_Pembayaran");

                entity.HasOne(d => d.IdPelayanNavigation)
                    .WithMany(p => p.Pembayaran)
                    .HasForeignKey(d => d.IdPelayan)
                    .HasConstraintName("FK_Pembayaran_Pelayan");

                entity.HasOne(d => d.IdTransaksiNavigation)
                    .WithMany(p => p.Pembayaran)
                    .HasForeignKey(d => d.IdTransaksi)
                    .HasConstraintName("FK_Pembayaran_Transaksi");
            });

            modelBuilder.Entity<Pembeli>(entity =>
            {
                entity.HasKey(e => e.IdPembeli);

                entity.Property(e => e.IdPembeli)
                    .HasColumnName("ID_Pembeli")
                    .ValueGeneratedNever();

                entity.Property(e => e.NamaPembeli)
                    .HasColumnName("Nama_Pembeli")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier);

                entity.Property(e => e.IdSupplier)
                    .HasColumnName("ID_Supplier")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlamatSupplier)
                    .HasColumnName("Alamat_Supplier")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JenisBarang)
                    .HasColumnName("Jenis_barang")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NamaSupplier)
                    .HasColumnName("Nama_Supplier")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoTlpSupplier)
                    .HasColumnName("NoTlp_Supplier")
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.Property(e => e.IdTransaksi)
                    .HasColumnName("ID_Transaksi")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdBarang).HasColumnName("ID_Barang");

                entity.Property(e => e.IdPembeli).HasColumnName("ID_Pembeli");

                entity.Property(e => e.JmlBrgDibeli).HasColumnName("Jml_Brg_Dibeli");

                entity.Property(e => e.TglTransaksi)
                    .HasColumnName("Tgl_Transaksi")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK_Transaksi_Barang");

                entity.HasOne(d => d.IdPembeliNavigation)
                    .WithMany(p => p.Transaksi)
                    .HasForeignKey(d => d.IdPembeli)
                    .HasConstraintName("FK_Transaksi_Pembeli");
            });
        }
    }
}
