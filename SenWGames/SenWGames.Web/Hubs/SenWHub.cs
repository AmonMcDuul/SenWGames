using Microsoft.AspNetCore.SignalR;
using SenWGames.Core.Domain.Entities;
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

        public async Task<GroupResponseModel> CreateGroup(string groepsNaam)
        {
            Group group = this._senWStateManager.CreateGroup(groepsNaam);
            //await Groups.AddToGroupAsync(Context.ConnectionId, group.GroupId);
            GroupResponseModel result = new GroupResponseModel(group);
            return result;
        }
    }
}
