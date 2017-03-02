using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FootBallVideos.ModelsData
{
    public partial class FootballWebsiteContext : DbContext
    {
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<TeamSeasonTournamentMap> TeamSeasonTournamentMap { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Tournaments> Tournaments { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }

        public FootballWebsiteContext(DbContextOptions<FootballWebsiteContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.Message).IsRequired();
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasIndex(e => e.NativeId)
                    .HasName("IX_Matches")
                    .IsUnique();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchesAwayTeam)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Matches_Teams");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchesHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Matches_Teams1");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Matchs_Season");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasIndex(e => e.NativeId)
                    .HasName("IX_Players")
                    .IsUnique();

                entity.Property(e => e.Age).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Nationality).HasMaxLength(250);

                entity.Property(e => e.Position).HasMaxLength(250);
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasIndex(e => e.NativeId)
                    .HasName("IX_Season")
                    .IsUnique();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TeamSeasonTournamentMap>(entity =>
            {
                entity.HasOne(d => d.Season)
                    .WithMany(p => p.TeamSeasonTournamentMap)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_teamSeasonTournamentMap_Season");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TeamSeasonTournamentMap)
                    .HasForeignKey(d => d.TournamentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_teamSeasonTournamentMap_Tournaments");
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasIndex(e => e.NativeId)
                    .HasName("IX_Teams")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Tournaments>(entity =>
            {
                entity.HasIndex(e => e.NativeId)
                    .HasName("IX_Tournaments")
                    .IsUnique();

                entity.Property(e => e.Country).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Url).IsRequired();

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_Videos_Players");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.SeasonId)
                    .HasConstraintName("FK_Videos_Season");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK_Videos_Tournaments");
            });
        }
    }
}