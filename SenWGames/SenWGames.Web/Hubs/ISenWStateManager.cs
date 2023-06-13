using SenWGames.Core.Domain.Entities;

namespace SenWGames.Web.Hubs
{
    public interface ISenWStateManager
    {
        List<Group> GetGroups();
        Group CreateGroup(string groepsNaam);
    }
}
