using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FootballAnalyticsAPI.ModelsData
{
    public partial class FootballAnalyticsContext : DbContext
    {
        
        public virtual DbSet<Match> Match { get; set; }
        public virtual DbSet<MatchDataTable> MatchDataTable { get; set; }
        public virtual DbSet<PlayerParticipation> PlayerParticipation { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Tournaments> Tournaments { get; set; }

        
            public FootballAnalyticsContext(DbContextOptions<FootballAnalyticsContext> options)
           : base(options)
             { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasIndex(e => e.WhoScoredMatchId)
                    .HasName("IX_Match_1")
                    .IsUnique();

                entity.Property(e => e.WhoScoredDate).HasColumnType("date");

                entity.HasOne(d => d.AwayTeam)
                    .WithMany(p => p.MatchAwayTeam)
                    .HasForeignKey(d => d.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Match_Team");

                entity.HasOne(d => d.HomeTeam)
                    .WithMany(p => p.MatchHomeTeam)
                    .HasForeignKey(d => d.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Match_Team1");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Match)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Match_Season");
            });

            modelBuilder.Entity<MatchDataTable>(entity =>
            {
                entity.Property(e => e.MatchData).IsRequired();

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchDataTable)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_MatchDataTable_Match");
            });

            modelBuilder.Entity<PlayerParticipation>(entity =>
            {
                entity.Property(e => e.Played)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Score)
                    .IsRequired()
                    .HasColumnType("nchar(10)");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerParticipation)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PlayerParticipation_Match");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerParticipation)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PlayerParticipation_Players");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasIndex(e => e.WhoScoredPlayerId)
                    .HasName("IX_Players")
                    .IsUnique();

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasIndex(e => e.WhoScoredSeasonId)
                    .HasName("IX_Season")
                    .IsUnique();

                entity.Property(e => e.SeasonTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Tournaments)
                    .WithMany(p => p.Season)
                    .HasForeignKey(d => d.TournamentsId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Season_Tournaments");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => e.WhoScoredTeamId)
                    .HasName("IX_Team")
                    .IsUnique();

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tournaments>(entity =>
            {
                entity.HasIndex(e => e.WhoScoredTourId)
                    .HasName("IX_Tournaments")
                    .IsUnique();

                entity.Property(e => e.WhoScoredTourName)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}