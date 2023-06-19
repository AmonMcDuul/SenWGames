using SenWGames.Core.Domain.Entities;

namespace SenWGames.Web.ViewModels
{
    public class GroupResponseModel
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public GroupResponseModel(Group group) 
        { 
            this.GroupId = group.GroupId;
            this.GroupName = group.GroupName;
        }
    }

    public class PlayerResponseModel
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Avatar { get; set; }
        public PlayerResponseModel(Player player)
        {
            this.PlayerId = player.PlayerId;
            this.PlayerName = player.Name;
            this.Avatar = player.Avatar;
        }
    }
}
