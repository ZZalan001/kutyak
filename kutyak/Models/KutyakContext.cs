using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kutyak.Models;

public partial class KutyakContext : DbContext
{
    public KutyakContext()
    {
    }

    public KutyakContext(DbContextOptions<KutyakContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fajtum> Fajta { get; set; }

    public virtual DbSet<Gazdum> Gazda { get; set; }

    public virtual DbSet<Kutya> Kutyas { get; set; }

    public virtual DbSet<Telepulesek> Telepuleseks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("SERVER=localhost;PORT=3306;DATABASE=kutyak;USER=root;PASSWORD=;SSL MODE=none;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fajtum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fajta");

            entity.HasIndex(e => e.Nev, "Nev").IsUnique();

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Leiras).HasMaxLength(128);
            entity.Property(e => e.Nev).HasMaxLength(32);
        });

        modelBuilder.Entity<Gazdum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gazda");

            entity.HasIndex(e => e.Irszam, "Irszam");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Irszam).HasColumnType("int(4)");
            entity.Property(e => e.Lakcim).HasMaxLength(64);
            entity.Property(e => e.Nev).HasMaxLength(32);

            entity.HasOne(d => d.IrszamNavigation).WithMany(p => p.Gazda)
                .HasForeignKey(d => d.Irszam)
                .HasConstraintName("gazda_ibfk_1");
        });

        modelBuilder.Entity<Kutya>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kutya");

            entity.HasIndex(e => e.ChipNumber, "ChipNumber").IsUnique();

            entity.HasIndex(e => e.FajtaId, "FajtaId");

            entity.HasIndex(e => e.GazdaId, "GazdaId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ChipNumber).HasMaxLength(20);
            entity.Property(e => e.Eletkor).HasColumnType("int(2)");
            entity.Property(e => e.FajtaId).HasColumnType("int(11)");
            entity.Property(e => e.GazdaId).HasColumnType("int(11)");
            entity.Property(e => e.IndexKep).HasColumnType("blob");
            entity.Property(e => e.Kep).HasColumnType("mediumblob");
            entity.Property(e => e.Nev).HasMaxLength(32);

            entity.HasOne(d => d.Fajta).WithMany(p => p.Kutyas)
                .HasForeignKey(d => d.FajtaId)
                .HasConstraintName("kutya_ibfk_1");

            entity.HasOne(d => d.Gazda).WithMany(p => p.Kutyas)
                .HasForeignKey(d => d.GazdaId)
                .HasConstraintName("kutya_ibfk_2");
        });

        modelBuilder.Entity<Telepulesek>(entity =>
        {
            entity.HasKey(e => e.Irszam).HasName("PRIMARY");

            entity.ToTable("telepulesek");

            entity.HasIndex(e => e.Telepules, "Telepules").IsUnique();

            entity.Property(e => e.Irszam).HasColumnType("int(4)");
            entity.Property(e => e.Telepules).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
