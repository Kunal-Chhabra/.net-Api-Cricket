﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cricket1.Models
{
    public partial class cricketContext : DbContext
    {
        public cricketContext()
        {
        }

        public cricketContext(DbContextOptions<cricketContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Stadium> Stadium { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=cricket;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId)
                    .HasColumnName("Country_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Continent)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("Country_code")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasColumnName("Country_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.ToTable("matches");

                entity.Property(e => e.MatchId)
                    .HasColumnName("match_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateTime)
                    .HasColumnName("date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.StadiumId).HasColumnName("stadium_id");

                entity.Property(e => e.Team1).HasColumnName("team1");

                entity.Property(e => e.Team2).HasColumnName("team2");

                entity.Property(e => e.WasMatchPlayed).HasColumnName("Was_Match_Played");

                entity.HasOne(d => d.Stadium)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.StadiumId)
                    .HasConstraintName("FK__matches__stadium__1332DBDC");

                entity.HasOne(d => d.Team1Navigation)
                    .WithMany(p => p.MatchesTeam1Navigation)
                    .HasForeignKey(d => d.Team1)
                    .HasConstraintName("FK__matches__team1__14270015");

                entity.HasOne(d => d.Team2Navigation)
                    .WithMany(p => p.MatchesTeam2Navigation)
                    .HasForeignKey(d => d.Team2)
                    .HasConstraintName("FK__matches__team2__151B244E");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.PlayerId)
                    .HasColumnName("Player_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PlayerAge).HasColumnName("Player_Age");

                entity.Property(e => e.PlayerCountryid).HasColumnName("Player_countryid");

                entity.Property(e => e.PlayerName)
                    .HasColumnName("Player_Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.PlayerCountry)
                    .WithMany(p => p.Player)
                    .HasForeignKey(d => d.PlayerCountryid)
                    .HasConstraintName("FK__Player__Player_c__01142BA1");
            });

            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.ToTable("stadium");

                entity.Property(e => e.StadiumId)
                    .HasColumnName("Stadium_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NoOfMatchesAllowed).HasColumnName("no_of_matches_allowed");

                entity.Property(e => e.StadiumCountry).HasColumnName("Stadium_country");

                entity.Property(e => e.StadiumName)
                    .HasColumnName("stadium_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.StadiumCountryNavigation)
                    .WithMany(p => p.Stadium)
                    .HasForeignKey(d => d.StadiumCountry)
                    .HasConstraintName("FK__stadium__Stadium__06CD04F7");
            });
        }
    }
}
