using SenWGames.Core.Domain.Entities;
using SenWGames.Core.Domain.Entities.Games;

namespace SenWGames.Web.Hubs
{
    public interface ISenWStateManager
    {
        List<Group> GetGroups();
        Group? GetGroup(string groepId);
        Group CreateGroup(string groepsNaam);
        Group JoinGroup(string groupId, string playerId);
        Player CreatePlayer(string playerName);
        Player GetPlayer(string playerId);
        Game GetGame(long gameId);
        GameLobby CreateGame(string gameTitle, Group group);

        Game NextRoundUselessBox(long uselessBoxId);

    }
}
