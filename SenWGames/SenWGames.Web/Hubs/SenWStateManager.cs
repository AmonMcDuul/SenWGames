using Microsoft.EntityFrameworkCore;
using SenWGames.Core.Domain.Entities;
using SenWGames.Core.Domain.Entities.Games;
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
                List<Group> groups = dbContext.Groups.OrderByDescending(g => g.CreatedAt).ToList();
                return groups;
            }
        }
        public Group GetGroup(string groupId)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Group? group = dbContext.Groups.FirstOrDefault(g => g.GroupId == groupId);
                if(group == null)
                {
                    throw new InvalidOperationException();
                }
                return group;
            }
        }

        public Group CreateGroup(string groepsNaam, string playerId)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Player? groupLeader = dbContext.Player.FirstOrDefault(p => p.PlayerId == playerId);
                Group? group = new Group(groepsNaam, null, null, groupLeader, playerId);
                dbContext.Groups.Add(group);
                dbContext.SaveChanges();
                return group;
            }
        }

        public Group JoinGroup(string groupId, string playerId)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Group group = dbContext.Groups.Include(g => g.Players).FirstOrDefault(g => g.GroupId == groupId);
                Player? player = GetPlayer(playerId);
                if (player == null)
                {
                    throw new InvalidOperationException();
                }
                group.Players?.Add(player);
                dbContext.SaveChanges();
                return group;
            }
        }

        public Player CreatePlayer(string playerName, double locationX, double locationY)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Player newPlayer = new Player(playerName);

                newPlayer.setPlayerLocation(locationX, locationY);
                dbContext.Player.Add(newPlayer);
                dbContext.SaveChanges();
                return newPlayer;
            }
        }

        public Player GetPlayer(string playerId)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Player? player = dbContext.Player.FirstOrDefault(p => p.PlayerId == playerId);
                if (player == null)
                {
                    throw new InvalidOperationException();
                }
                return player;
            }
        }

        public Game GetGame(long gameId)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Game? game = dbContext.Game.FirstOrDefault(p => p.Id == gameId);
                if (game == null)
                {
                    throw new InvalidOperationException();
                }
                return game;
            }
        }
        public GameLobby CreateGame(string gameTitle, string groupId)
        {
            using (SenWDbContext dbContext = new SenWDbContext(_dbContextOptionsBuilder.Options))
            {
                Group group = dbContext.Groups.Include(g => g.GameLobby).ThenInclude(gl => gl.Game).FirstOrDefault(g => g.GroupId == groupId);
                GameLobby gameLobby = group.CreateGameLobby(gameTitle);
                if (gameLobby == null)
                {
                    throw new InvalidOperationException();
                }
                dbContext.SaveChanges();
                return gameLobby;
            }
        }

        public Game NextRoundUselessBox(long uselessBoxId)
        {
            Game game = GetGame(uselessBoxId);
            if (game is UselessBox uselessBox)
            {
                uselessBox.UseUselessBox();
            }
            return game;
        }
    }
}
