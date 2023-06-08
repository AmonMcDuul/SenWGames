using Microsoft.EntityFrameworkCore;
using SenWGames.Core.Domain.Entities;
using SenWGames.Infrastructure;

namespace SenWGames.Web.Hubs
{
    public class SenWStateManager : ISenWStateManager
    {
        private readonly DbContextOptionsBuilder<SenwDbContext> _dbContextOptionsBuilder;

        public SenWStateManager(IConfiguration configuration) 
        {
            this._dbContextOptionsBuilder = new DbContextOptionsBuilder<SenwDbContext>();
            this._dbContextOptionsBuilder.UseSqlServer(configuration["ConnectionString"]);
        }

        public Group CreateGroup()
        {
            throw new NotImplementedException();
        }
    }
}
