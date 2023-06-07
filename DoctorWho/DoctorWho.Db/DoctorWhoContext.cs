using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db;

public partial class DoctorWhoContext : DbContext
{
    public DoctorWhoContext()
    {
    }

    public DoctorWhoContext(DbContextOptions<DoctorWhoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAuthor> TblAuthors { get; set; }

    public virtual DbSet<TblCompanion> TblCompanions { get; set; }

    public virtual DbSet<TblDoctor> TblDoctors { get; set; }

    public virtual DbSet<TblEnemy> TblEnemies { get; set; }

    public virtual DbSet<TblEpisode> TblEpisodes { get; set; }

    public virtual DbSet<TblEpisodeCompanion> TblEpisodeCompanions { get; set; }

    public virtual DbSet<TblEpisodeEnemy> TblEpisodeEnemies { get; set; }

    public virtual DbSet<ViewEpisode> ViewEpisodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost; Database=DoctorWho; User Id=sa; Password=Hijazi123; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAuthor>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__tblAutho__70DAFC14745C864A");

            entity.ToTable("tblAuthor");

            entity.Property(e => e.AuthorId)
                .ValueGeneratedNever()
                .HasColumnName("AuthorID");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblCompanion>(entity =>
        {
            entity.HasKey(e => e.CompanionId).HasName("PK__tblCompa__8B53BE8B2BED7BDE");

            entity.ToTable("tblCompanion");

            entity.Property(e => e.CompanionId)
                .ValueGeneratedNever()
                .HasColumnName("CompanionID");
            entity.Property(e => e.CompanionName)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.WhoPlayed)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblDoctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__tblDocto__2DC00EDF6E1BB984");

            entity.ToTable("tblDoctor");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("DoctorID");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEnemy>(entity =>
        {
            entity.HasKey(e => e.EnemyId).HasName("PK__tblEnemy__911A0BD2AC4B36E9");

            entity.ToTable("tblEnemy");

            entity.Property(e => e.EnemyId)
                .ValueGeneratedNever()
                .HasColumnName("EnemyID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EnemyName)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEpisode>(entity =>
        {
            entity.HasKey(e => e.EpisodeId).HasName("PK__tblEpiso__AC66761511820723");

            entity.ToTable("tblEpisode");

            entity.Property(e => e.EpisodeId)
                .ValueGeneratedNever()
                .HasColumnName("EpisodeID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.EpisodeType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.Title)
                .HasMaxLength(35)
                .IsUnicode(false);

            entity.HasOne(d => d.Author).WithMany(p => p.TblEpisodes)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__tblEpisod__Autho__2B3F6F97");

            entity.HasOne(d => d.Doctor).WithMany(p => p.TblEpisodes)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__tblEpisod__Docto__2C3393D0");
        });

        modelBuilder.Entity<TblEpisodeCompanion>(entity =>
        {
            entity.HasKey(e => e.EpisodeCompanionId).HasName("PK__tblEpiso__774F3833F16FC7C1");

            entity.ToTable("tblEpisodeCompanion");

            entity.Property(e => e.EpisodeCompanionId)
                .ValueGeneratedNever()
                .HasColumnName("EpisodeCompanionID");
            entity.Property(e => e.CompanionId).HasColumnName("CompanionID");
            entity.Property(e => e.EpisodeId).HasColumnName("EpisodeID");

            entity.HasOne(d => d.Companion).WithMany(p => p.TblEpisodeCompanions)
                .HasForeignKey(d => d.CompanionId)
                .HasConstraintName("FK__tblEpisod__Compa__398D8EEE");

            entity.HasOne(d => d.Episode).WithMany(p => p.TblEpisodeCompanions)
                .HasForeignKey(d => d.EpisodeId)
                .HasConstraintName("FK__tblEpisod__Episo__38996AB5");
        });

        modelBuilder.Entity<TblEpisodeEnemy>(entity =>
        {
            entity.HasKey(e => e.EpisodeEnemyId).HasName("PK__tblEpiso__6DF24E50BD88F397");

            entity.ToTable("tblEpisodeEnemy");

            entity.Property(e => e.EpisodeEnemyId)
                .ValueGeneratedNever()
                .HasColumnName("EpisodeEnemyID");
            entity.Property(e => e.EnemyId).HasColumnName("EnemyID");
            entity.Property(e => e.EpisodeId).HasColumnName("EpisodeID");

            entity.HasOne(d => d.Enemy).WithMany(p => p.TblEpisodeEnemies)
                .HasForeignKey(d => d.EnemyId)
                .HasConstraintName("FK__tblEpisod__Enemy__3D5E1FD2");

            entity.HasOne(d => d.Episode).WithMany(p => p.TblEpisodeEnemies)
                .HasForeignKey(d => d.EpisodeId)
                .HasConstraintName("FK__tblEpisod__Episo__3C69FB99");
        });

        modelBuilder.Entity<ViewEpisode>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("viewEpisodes");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Companions).IsUnicode(false);
            entity.Property(e => e.DoctorId).HasColumnName("DoctorID");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Enemies).IsUnicode(false);
            entity.Property(e => e.EpisodeId).HasColumnName("EpisodeID");
            entity.Property(e => e.EpisodeType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Notes).HasMaxLength(255);
            entity.Property(e => e.Title)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
