using Microsoft.AspNetCore.SignalR;
using SenWGames.Core.Domain.Entities;
using SenWGames.Core.Domain.Entities.Games;
using SenWGames.Web.ViewModels;

namespace SenWGames.Web.Hubs
{
    public class SenWHub : Hub
    {
        private readonly ISenWStateManager _senWStateManager;

        public SenWHub(ISenWStateManager senWStateManager)
        {
            this._senWStateManager = senWStateManager;
        }

        public async Task<List<GroupResponseModel>> GetGroups()
        {
            List<Group> groups = this._senWStateManager.GetGroups();
            List<GroupResponseModel> result = groups.Select(group => new GroupResponseModel(group)).ToList();
            return result;
        }

        public async Task<GroupResponseModel> CreateGroup(string groepsNaam, string playerId)
        {
            Group group = this._senWStateManager.CreateGroup(groepsNaam, playerId);
            await Groups.AddToGroupAsync(playerId, group.GroupId);
            GroupResponseModel result = new GroupResponseModel(group);
            return result;
        }

        public async Task<GroupResponseModel> JoinGroup(string groepId, string playerId)
        {
            //return via listner maken
            Group group = this._senWStateManager.JoinGroup(groepId, playerId);
            await Groups.AddToGroupAsync(playerId, group.GroupId);
            GroupResponseModel result = new GroupResponseModel(group);
            return result;
        }

        public async Task<PlayerResponseModel> CreatePlayer(string playerName, double locationX, double locationY)
        {
            Player player = this._senWStateManager.CreatePlayer(playerName, locationX, locationY);
            PlayerResponseModel result = new PlayerResponseModel(player);
            return result;
        }

        public async Task<GameCreatedModel> CreateGame(string groepId, string gameTitle)
        {
            Group? group = this._senWStateManager.GetGroup(groepId);
            GameLobby gameLobby = this._senWStateManager.CreateGame(gameTitle, group);
            GameCreatedModel result = new GameCreatedModel(gameLobby);
            return result;
        }

        public async Task<NextRoundUselessBoxModel> NextRoundUselessBox(long uselessBoxId)
        {
            Game game = this._senWStateManager.NextRoundUselessBox(uselessBoxId);
            NextRoundUselessBoxModel result = new NextRoundUselessBoxModel((UselessBox)game);
            return result;
        }

    }
}
