using Microsoft.EntityFrameworkCore;
using SenWGames.Core.Model;

namespace SenWGames.Infrastructure
{
    /*
     * You would want to generate the model from an existing database via scaffolding.
     * Then move the entities into SenWGames.Core project and keep here the DbContext.
     * See https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli
     */
    public class SenwDbContext : DbContext
    {
        public SenwDbContext(DbContextOptions<SenwDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Value> Values { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Value>(entity => { entity.ToTable("Values"); });
        }
    }
}
