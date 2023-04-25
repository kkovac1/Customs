using Fustalesco.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fustalesco.Infrastructure
{
    public class FutsalescoDbContext : DbContext
    {
        public FutsalescoDbContext(
           DbContextOptions<FutsalescoDbContext> options)
           : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Player>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Match>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Tournament>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Result>()
                .HasKey(p => p.Id);

            // Vise Playera moze biti u jednom Teamu
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            // Vise Matcheva moze biti na jednom tournamentu
            modelBuilder.Entity<Match>()
               .HasOne(p => p.Tournament)
               .WithMany(t => t.Matches)
               .HasForeignKey(p => p.TournamentId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamOne)
                .WithMany()
                .HasForeignKey(m => m.TeamOneId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.TeamTwo)
                .WithMany()
                .HasForeignKey(m => m.TeamTwoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Vise Teamova moze biti u jednom tournamentu
            modelBuilder.Entity<Team>()
               .HasOne(p => p.Tournament)
               .WithMany(t => t.Teams)
               .HasForeignKey(p => p.TournamentId);

            // Jedan Match ima jedan Result
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Result)
                .WithOne(r => r.Match)
                .HasForeignKey<Result>(r => r.MatchId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.WinningTeam)
                .WithMany()
                .HasForeignKey(m => m.WinningTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}