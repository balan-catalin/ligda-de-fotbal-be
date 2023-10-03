using LigaDeFotbal.BBL.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LigaDeFotbal.DAL.DataContext
{
    public class LdfContext : DbContext, ILdfContext
    {
        private readonly IConfiguration _configuration;

        public LdfContext(DbContextOptions<LdfContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:ForRentDb"]);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}