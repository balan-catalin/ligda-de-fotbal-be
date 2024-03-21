using LigaDeFotbal.BBL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LigaDeFotbal.BBL.Interfaces
{
    public interface ILdfContext
    {
        DbSet<Bet> Bets { get; }
        DbSet<Competition> Competitions { get; }
        DbSet<Game> Games { get; }
        DbSet<Team> Teams { get; }
        DbSet<UserCompetition> UserCompetitions { get; }
        DbSet<User> Users { get; }
        Task<int> SaveChangesAsync();
    }
}