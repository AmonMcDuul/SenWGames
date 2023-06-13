using Microsoft.EntityFrameworkCore;
using SenWGames.Core.Domain.Entities;
using SenWGames.Infrastructure;
using System.Diagnostics;

namespace SenWGames.Web.Hubs
{
    public class SenWStateManager : ISenWStateManager
    {
        private readonly DbContextOptionsBuilder<SenWDbContext> _dbContextOptionsBuilder;

        public SenWStateManager(IConfiguration configuration) 
        {
            this._dbContextOptionsBuilder = new DbContextOptionsBuilder<SenWDbContext>();
            this._dbContextOptionsBuilder.UseSqlServer(configuration["ConnectionString"]);
        }

        public List<Group> GetGroups()
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                List<Group> groups = dbContext.Groups.ToList();
                return groups;
            }
        }

        public Group CreateGroup(string groepsNaam)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Group? group = new Group(groepsNaam, null, null, null, null);
                dbContext.Groups.Add(group);
                dbContext.SaveChanges();
                return group;
            }
        }
    }
}
