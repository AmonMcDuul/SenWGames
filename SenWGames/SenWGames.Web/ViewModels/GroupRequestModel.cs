using SenWGames.Core.Domain.Entities;
using SenWGames.Core.Domain.Entities.Games;

namespace SenWGames.Web.ViewModels
{
    public class GroupResponseModel
    {
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        public ICollection<PlayerResponseModel>? Players { get; set; }
        public string? GroupLeaderId { get; set; }
        public GroupResponseModel(Group group)
        {
            this.GroupId = group.GroupId;
            this.GroupName = group.GroupName;
            this.Players = group.Players?.Select(player => new PlayerResponseModel(player)).ToList();
            this.GroupLeaderId = group.GroupLeaderId;
        }
    }

    public class PlayerResponseModel
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Avatar { get; set; }
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }
        public PlayerResponseModel(Player player)
        {
            this.PlayerId = player.PlayerId;
            this.PlayerName = player.Name;
            this.Avatar = player.Avatar;
            this.LocationX = player.LocationX;
            this.LocationY = player.LocationY;
        }
    }

    public class GameCreatedModel
    {
        //moet gamelobbymodel worden
        public GameLobby GameLobby { get; set; }
        public GameCreatedModel(GameLobby gameLobby)
        {
            this.GameLobby = gameLobby;
        }
    }

    //public class GameLobbyModel
    //{
    //    public string Name { get; set; }
    //    public ICollection<PlayerResponseModel>? Players { get; set; } = new List<PlayerResponseModel>();
    //    public Game? Game { get; set; }
    //    public bool Active { get; private set; }
    //}

    public class NextRoundUselessBoxModel
    {
        public bool State { get; set; }
        public int Count { get; set; }
        public NextRoundUselessBoxModel(UselessBox uselessBox)
        {
            State = uselessBox.State;
            Count = uselessBox.Count;
        }
    }
}
