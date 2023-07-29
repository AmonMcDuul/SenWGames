using Microsoft.EntityFrameworkCore;
using SenWGames.Core.Domain.Common;
using SenWGames.Core.Domain.Entities;
using SenWGames.Core.Domain.Entities.Games;

namespace SenWGames.Infrastructure
{
    public class SenWDbContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Chat> Chat { get; set; }

        public SenWDbContext(DbContextOptions<SenWDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FourInARow>().HasBaseType<Game>();
            modelBuilder.Entity<TicTacToe>().HasBaseType<Game>();
            modelBuilder.Entity<UselessBox>().HasBaseType<Game>();
        }

        /// <summary>
        /// Save all changes that are being  tracked
        /// </summary>
        /// <returns>Integer</returns>
        public override int SaveChanges()
        {
            // call BaseEntity.SetUpdated for every modified entity
            var entities = ChangeTracker.Entries();

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Modified)
                {
                    var currentEntity = (BaseEntity)entity.Entity;
                    currentEntity.SetUpdated();
                }
            }

            return base.SaveChanges();
        }

        /// <summary>
        /// Save changes asynchronously
        /// </summary>
        /// <param name="cancellationToken">Cancellation token of type CancellationToken</param>
        /// <returns>Task of type int</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
