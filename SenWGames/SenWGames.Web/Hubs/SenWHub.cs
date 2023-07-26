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
            await Groups.AddToGroupAsync(Context.ConnectionId, group.GroupId);
            GroupResponseModel result = new GroupResponseModel(group);
            return result;
        }

        public async Task<GroupResponseModel> JoinGroup(string groepId, string playerId)
        {
            //return via listner maken
            Group group = this._senWStateManager.JoinGroup(groepId, playerId);
            await Groups.AddToGroupAsync(Context.ConnectionId, group.GroupId);
            GroupResponseModel result = new GroupResponseModel(group);

            await Clients.Group(group.GroupId).SendAsync("groupJoined", result);

            return result;
        }

        public async Task<PlayerResponseModel> CreatePlayer(string playerName, double locationX, double locationY)
        {
            Player player = this._senWStateManager.CreatePlayer(playerName, locationX, locationY);
            PlayerResponseModel result = new PlayerResponseModel(player);
            return result;
        }

        public async Task<GameCreatedModel> CreateGame(string gameTitle, string groupId)
        {
            GameLobby gameLobby = this._senWStateManager.CreateGame(gameTitle, groupId);
            GameCreatedModel result = new GameCreatedModel(gameLobby);
            await Clients.Group(groupId).SendAsync("gameStarted", result);
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
