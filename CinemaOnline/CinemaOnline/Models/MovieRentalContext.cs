using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CinemaOnline.Models;

public partial class MovieRentalContext : DbContext
{
    public MovieRentalContext()
    {
    }

    public MovieRentalContext(DbContextOptions<MovieRentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Filmovi> Filmovis { get; set; }

    public virtual DbSet<Glumci> Glumcis { get; set; }

    public virtual DbSet<Korisnici> Korisnicis { get; set; }

    public virtual DbSet<Likovi> Likovis { get; set; }

    public virtual DbSet<Rentum> Renta { get; set; }

    public virtual DbSet<Rejting> Rejtings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Filmovi>(entity =>
        {
            entity.HasKey(e => e.FilmId);

            entity.ToTable("Filmovi");

            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Ocena).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.Godina).HasColumnType("int");
            entity.Property(e => e.Opis).HasMaxLength(300);
            entity.Property(e => e.Slika).HasMaxLength(50);
            entity.Property(e => e.Trajanje).HasMaxLength(50);
            entity.Property(e => e.Zanr).HasMaxLength(50);
            entity.Property(e => e.LikoviId).HasColumnName("LikoviID");
            entity.Property(e => e.GlumciId).HasColumnName("GlumciID");

            entity.HasOne(d => d.Likovi).WithMany(p => p.Filmovis)
                .HasForeignKey(d => d.LikoviId)
                .HasConstraintName("FK_Filmovi_Likovi");

            entity.HasOne(d => d.Glumci).WithMany(p => p.Filmovis)
                .HasForeignKey(d => d.GlumciId)
                .HasConstraintName("FK_Filmovi_Glumci");
        });

        modelBuilder.Entity<Glumci>(entity =>
        {
            entity.ToTable("Glumci");

            entity.Property(e => e.GlumciId).HasColumnName("GlumciID");
            entity.Property(e => e.DatumRodjenja)
                .HasColumnType("date")
                .HasColumnName("Datum_rodjenja");
            entity.Property(e => e.Ime).HasMaxLength(50);
            entity.Property(e => e.Nagrade).HasMaxLength(50);
            entity.Property(e => e.ZemljaPorekla)
                .HasMaxLength(50)
                .HasColumnName("Zemlja_porekla");
            
        });

        modelBuilder.Entity<Korisnici>(entity =>
        {
            entity.ToTable("Korisnici");

            entity.Property(e => e.KorisniciId).HasColumnName("KorisniciID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("Email");
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Likovi>(entity =>
        {
            entity.ToTable("Likovi");

            entity.Property(e => e.LikoviId).HasColumnName("LikoviID");
            entity.Property(e => e.Ime).HasMaxLength(50);
        });

        modelBuilder.Entity<Rentum>(entity =>
        {
            entity.HasKey(e => e.RentaId);

            entity.Property(e => e.RentaId).HasColumnName("RentaID");
            entity.Property(e => e.Datum).HasColumnType("date");
            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.KorisniciId).HasColumnName("KorisniciID");
          

            entity.HasOne(d => d.Film).WithMany(p => p.Renta)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("FK_Renta_Filmovi");

            entity.HasOne(d => d.Korisnici).WithMany(p => p.Renta)
                .HasForeignKey(d => d.KorisniciId)
                .HasConstraintName("FK_Renta_Korisnici");
        });

        modelBuilder.Entity<Rejting>(entity =>
        {
            entity.HasKey(e => e.RejtingId);

            entity.ToTable("Rejting");

            entity.Property(e => e.RejtingId).HasColumnName("RejtingID");
            entity.Property(e => e.FilmId).HasColumnName("FilmID");
            entity.Property(e => e.KorisniciId).HasColumnName("KorisniciID");
            entity.Property(e => e.rejting).HasColumnType("int");
            entity.Property(e => e.komentar).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);


            entity.HasOne(d => d.Filmovi).WithMany(p => p.Rejtings)
                .HasForeignKey(d => d.FilmId)
                .HasConstraintName("FK_Rejting_Filmovi");

            entity.HasOne(d => d.Korisnici).WithMany(p => p.Rejtings)
                .HasForeignKey(d => d.KorisniciId)
                .HasConstraintName("FK_Korisnici_Filmovi");

        });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
