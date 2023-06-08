using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using SenWGames.Core.Domain.Entities;

namespace SenWGames.Web.Hubs
{
    public class SenWHub : Hub
    {
        private readonly ISenWStateManager _senWStateManager;

        public SenWHub(ISenWStateManager senWStateManager)
        {
            this._senWStateManager = senWStateManager;
        }

        public async Task<Group> CreateGroup()
        {
            Group group = this._senWStateManager.CreateGroup();
            await Groups.AddToGroupAsync(Context.ConnectionId, group.GroupId);
            return group;
        }
    }
}
