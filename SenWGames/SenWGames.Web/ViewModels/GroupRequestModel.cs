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
}
