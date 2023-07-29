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
        public string Name { get; set; }
        public ICollection<PlayerResponseModel>? Players { get; set; } = new List<PlayerResponseModel>();
        public GameModel? Game { get; set; }
        public bool Active { get; private set; }
        public GameCreatedModel(GameLobby gameLobby)
        {
            this.Name = gameLobby.Name;
            this.Players = gameLobby.Players?.Select(player => new PlayerResponseModel(player)).ToList();
            if (gameLobby.Game is UselessBox uselessBox)
            {
                this.Game = new GameModel(uselessBox);
            }
            this.Active = gameLobby.Active;
        }
    }

    public class GameModel
    {
        public long GameId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? State { get; set; }
        public int? Count { get; set; }
        public GameModel(Game game) 
        {
            this.GameId = game.Id;
            this.Name = game.Name;
            this.Image = game.Image;
            if (game is UselessBox uselessbox)
            { 
                this.Title = uselessbox.Title;
                this.Description = uselessbox.Description;
                this.State = uselessbox.State;
                this.Count = uselessbox.Count;
            }
        }

    }

    public class GameLobbyModel
    {
        public string Name { get; set; }
        public ICollection<PlayerResponseModel>? Players { get; set; } = new List<PlayerResponseModel>();
        public GameModel? Game { get; set; }
        public bool Active { get; private set; }
    }

    public class NextRoundUselessBoxModel
    {
        public long GameId { get; set; }
        public bool State { get; set; }
        public int Count { get; set; }
        public NextRoundUselessBoxModel(UselessBox uselessBox)
        {
            GameId = uselessBox.Id;
            State = uselessBox.State;
            Count = uselessBox.Count;
        }
    }

    public class GetChatMessageModel
    {
        public string GroupId { get; set; }
        public string PlayerId { get; set; }
        public string Message { get; set; }
        public GetChatMessageModel(Chat chatMessage)
        {
            GroupId = chatMessage.GroupId;
            PlayerId = chatMessage.PlayerId;
            Message = chatMessage.Message;
        }
    }
}
