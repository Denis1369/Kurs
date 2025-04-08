using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Kurs.Model;

public partial class Formula12025Context : DbContext
{
    public Formula12025Context()
    {
    }

    public Formula12025Context(DbContextOptions<Formula12025Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Positionscore> Positionscores { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Racer> Racers { get; set; }

    public virtual DbSet<RacingResult> RacingResults { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=formula1_2025", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.IDmanager).HasName("PRIMARY");

            entity.ToTable("managers");

            entity.HasIndex(e => e.IDpost, "iDPost");

            entity.HasIndex(e => e.IDteam, "iDTeam");

            entity.Property(e => e.IDmanager).HasColumnName("iDManager");
            entity.Property(e => e.IDpost).HasColumnName("iDPost");
            entity.Property(e => e.IDteam).HasColumnName("iDTeam");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.HasOne(d => d.IDpostNavigation).WithMany(p => p.Managers)
                .HasForeignKey(d => d.IDpost)
                .HasConstraintName("managers_ibfk_1");

            entity.HasOne(d => d.IDteamNavigation).WithMany(p => p.Managers)
                .HasForeignKey(d => d.IDteam)
                .HasConstraintName("managers_ibfk_2");
        });

        modelBuilder.Entity<Positionscore>(entity =>
        {
            entity.HasKey(e => e.Position).HasName("PRIMARY");

            entity.ToTable("positionscore");

            entity.Property(e => e.Position)
                .HasMaxLength(3)
                .HasColumnName("position");
            entity.Property(e => e.Score).HasColumnName("score");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.IDpost).HasName("PRIMARY");

            entity.ToTable("post");

            entity.Property(e => e.IDpost).HasColumnName("iDPost");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.IDrace).HasName("PRIMARY");

            entity.ToTable("race");

            entity.HasIndex(e => e.IDtrack, "iDTrack");

            entity.Property(e => e.IDrace).HasColumnName("iDRace");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.IDtrack).HasColumnName("iDTrack");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.StartDate).HasColumnName("startDate");

            entity.HasOne(d => d.IDtrackNavigation).WithMany(p => p.Races)
                .HasForeignKey(d => d.IDtrack)
                .HasConstraintName("race_ibfk_1");
        });

        modelBuilder.Entity<Racer>(entity =>
        {
            entity.HasKey(e => e.IDracer).HasName("PRIMARY");

            entity.ToTable("racer");

            entity.HasIndex(e => e.IDteam, "iDTeam");

            entity.Property(e => e.IDracer).HasColumnName("iDRacer");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.IDteam).HasColumnName("iDTeam");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("lastName");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(255)
                .HasColumnName("placeOfBirth");

            entity.HasOne(d => d.IDteamNavigation).WithMany(p => p.Racers)
                .HasForeignKey(d => d.IDteam)
                .HasConstraintName("racer_ibfk_1");
        });

        modelBuilder.Entity<RacingResult>(entity =>
        {
            entity.HasKey(e => e.IDracingResult).HasName("PRIMARY");

            entity.ToTable("racing_result");

            entity.HasIndex(e => e.FinalPosition, "fk_score_idx");

            entity.HasIndex(e => e.IDrace, "iDRace");

            entity.HasIndex(e => e.IDracer, "iDRacer");

            entity.Property(e => e.IDracingResult).HasColumnName("iDRacingResult");
            entity.Property(e => e.FinalPosition)
                .HasMaxLength(3)
                .HasColumnName("finalPosition");
            entity.Property(e => e.IDrace).HasColumnName("iDRace");
            entity.Property(e => e.IDracer).HasColumnName("iDRacer");
            entity.Property(e => e.StartPosition).HasColumnName("startPosition");

            entity.HasOne(d => d.FinalPositionNavigation).WithMany(p => p.RacingResults)
                .HasForeignKey(d => d.FinalPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_score");

            entity.HasOne(d => d.IDraceNavigation).WithMany(p => p.RacingResults)
                .HasForeignKey(d => d.IDrace)
                .HasConstraintName("racing_result_ibfk_2");

            entity.HasOne(d => d.IDracerNavigation).WithMany(p => p.RacingResults)
                .HasForeignKey(d => d.IDracer)
                .HasConstraintName("racing_result_ibfk_1");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.IDteam).HasName("PRIMARY");

            entity.ToTable("team");

            entity.Property(e => e.IDteam).HasColumnName("iDTeam");
            entity.Property(e => e.Base)
                .HasMaxLength(255)
                .HasColumnName("base");
            entity.Property(e => e.DescriptionT)
                .HasColumnType("text")
                .HasColumnName("descriptionT");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.IDtrack).HasName("PRIMARY");

            entity.ToTable("track");

            entity.Property(e => e.IDtrack).HasColumnName("iDTrack");
            entity.Property(e => e.Place)
                .HasMaxLength(255)
                .HasColumnName("place");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
