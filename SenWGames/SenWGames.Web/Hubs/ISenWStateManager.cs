using SenWGames.Core.Domain.Entities;

namespace SenWGames.Web.Hubs
{
    public interface ISenWStateManager
    {
        List<Group> GetGroups();
        Group? GetGroup(string groepId);
        Group CreateGroup(string groepsNaam);
        Group JoinGroup(string groupId, string playerId);
        Player CreatePlayer(string playerName, double locationX, double locationY);
        Player GetPlayer(string playerId);
    }
}
