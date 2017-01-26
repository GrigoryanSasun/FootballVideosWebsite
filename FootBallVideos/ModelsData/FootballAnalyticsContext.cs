using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FootBallVideos.ModelsData
{
    public partial class FootballAnalyticsContext : DbContext
    {
        public virtual DbSet<Flags> Flags { get; set; }
        public virtual DbSet<MatchDataTable> MatchDataTable { get; set; }
        public virtual DbSet<PlayerParticipation> PlayerParticipation { get; set; }
        public virtual DbSet<PlayerProfile> PlayerProfile { get; set; }
        public virtual DbSet<Players> Players { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamTournamentMap> TeamTournamentMap { get; set; }
        public virtual DbSet<TeamsAlternative> TeamsAlternative { get; set; }
        public virtual DbSet<Tournaments> Tournaments { get; set; }
        public object Match { get; internal set; }

        public FootballAnalyticsContext(DbContextOptions<FootballAnalyticsContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flags>(entity =>
            {
                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.FlagLocation)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MatchDataTable>(entity =>
            {
                entity.Property(e => e.MatchData).IsRequired();
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

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerParticipation)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PlayerParticipation_Players");
            });

            modelBuilder.Entity<PlayerProfile>(entity =>
            {
                entity.Property(e => e.Age)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.HeightInCm).HasColumnName("HeightInCM");

                entity.Property(e => e.Nationality).HasMaxLength(250);

                entity.Property(e => e.NationalityFlagUrl)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.PlayerImageUrl)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.WeightInKg).HasColumnName("WeightInKG");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.PlayerProfile)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_PlayerProfile_Flags");

                entity.HasOne(d => d.Players)
                    .WithMany(p => p.PlayerProfile)
                    .HasForeignKey(d => d.PlayersId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_PlayerProfile_Players");
            });

            modelBuilder.Entity<Players>(entity =>
            {
                entity.HasIndex(e => e.WhoScoredPlayerId)
                    .HasName("IX_Players")
                    .IsUnique();

                entity.Property(e => e.PlayerName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CurentTeam)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CurentTeamId)
                    .HasConstraintName("FK_Players_Team");
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

                entity.Property(e => e.WhoScoredTeamId).IsRequired();

                entity.HasOne(d => d.TeamAlternative)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.TeamAlternativeId)
                    .HasConstraintName("FK_Team_TeamsAlternative");
            });

            modelBuilder.Entity<TeamTournamentMap>(entity =>
            {
                entity.HasOne(d => d.Season)
                    .WithMany(p => p.TeamTournamentMap)
                    .HasForeignKey(d => d.SeasonId)
                    .HasConstraintName("FK_TeamTournamentMap_Season");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamTournamentMap)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_TeamTournamentMap_Team");

                entity.HasOne(d => d.Tournament)
                    .WithMany(p => p.TeamTournamentMap)
                    .HasForeignKey(d => d.TournamentId)
                    .HasConstraintName("FK_TeamTournamentMap_Tournaments");
            });

            modelBuilder.Entity<TeamsAlternative>(entity =>
            {
                entity.HasIndex(e => e.TeamAlternativeName)
                    .HasName("IX_TeamsAlternative")
                    .IsUnique();

                entity.Property(e => e.MatchDate).HasColumnType("date");

                entity.Property(e => e.TeamAlternativeName)
                    .IsRequired()
                    .HasMaxLength(250);
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