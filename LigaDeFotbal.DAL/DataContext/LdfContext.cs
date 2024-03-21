using LigaDeFotbal.BBL.Entities;
using LigaDeFotbal.BBL.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LigaDeFotbal.DAL.DataContext
{
    public class LdfContext : DbContext, ILdfContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Bet> Bets {get; set;}

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<Game> Games {get; set;}

        public DbSet<Team> Teams {get; set;}

        public DbSet<UserCompetition> UserCompetitions {get; set;}

        public DbSet<User> Users {get; set;}

        public LdfContext(DbContextOptions<LdfContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:LigaDeFotbalDB"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Game>()
                .HasKey(game => new { game.FirstTeamId, game.SecondTeamId, game.PlayDate });

            modelBuilder.Entity<Bet>()
                .HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => new { b.GameTeamId1, b.GameTeamId2, b.GamePlayDate });

            modelBuilder.Entity<Game>()
                .HasOne(g => g.FirstTeam)
                .WithMany(t => t.Games)
                .HasForeignKey(g => g.FirstTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.SecondTeam)
                .WithMany()
                .HasForeignKey(g => g.SecondTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserCompetition>()
                .Property(uc => uc.Position)
                .HasDefaultValue(-1);

            modelBuilder.Entity<UserCompetition>()
                .Property(uc => uc.Score)
                .HasDefaultValue(0);

            modelBuilder.Entity<UserCompetition>()
                .Property(uc => uc.RightAnswers)
                .HasDefaultValue(0);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}