using Microsoft.EntityFrameworkCore;
using SenWGames.Infrastructure;

namespace SenWGames.Web.Services
{
    public class DataCleanupService : BackgroundService
    {

        private readonly DbContextOptionsBuilder<SenWDbContext> _dbContextOptionsBuilder;
        private const int inactiveTimeThresholdInMinutes = 60;

        public DataCleanupService(IConfiguration configuration)
        {
            this._dbContextOptionsBuilder = new DbContextOptionsBuilder<SenWDbContext>();
            this._dbContextOptionsBuilder.UseSqlServer(configuration["ConnectionString"]);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(3600000, stoppingToken);
                DateTime thresholdTime = DateTime.UtcNow.AddMinutes(-inactiveTimeThresholdInMinutes);
                DeleteInactiveRows(thresholdTime);
            }
        }

        private void DeleteInactiveRows(DateTime thresholdTime)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                using (var transaction = dbContext.Database.BeginTransaction())
                {
                    var groupsToDelete = dbContext.Groups.Where(e => e.CreatedAt < thresholdTime).ToList();

                    if (groupsToDelete.Any())
                    {
                        foreach (var groupEntity in groupsToDelete)
                        {
                            dbContext.Player.Where(v => v.GroupId == groupEntity.Id).Load();
                            dbContext.Groups.Remove(groupEntity);
                            Console.WriteLine("Deleted " + groupEntity.Id);
                        }

                        dbContext.SaveChanges();
                        transaction.Commit();
                    }
                }
            }
        }
    }

}
