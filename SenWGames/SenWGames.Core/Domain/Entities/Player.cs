using SenWGames.Core.Domain.Common;

namespace SenWGames.Core.Domain.Entities
{
    public class Player : BaseEntity
    {
        public string PlayerId { get; private set; }
        public string Name { get; private set; }
        public string Avatar { get; private set; }
        public ICollection<GameLobby>? GamesPlayed { get; private set; }
        public int? Wins { get; private set; }
        public int? Loses { get; private set; }
        public int? Draws { get; private set; }
        public double LocationX { get; private set; }
        public double LocationY { get; private set; }

        public Group Group { get; set; } // Reference navigation property to the related Group
        public long? GroupId { get; set; } // The foreign key to Group, nullable

        protected Player() { }

        public Player(string playerName)
        {
            this.PlayerId = Guid.NewGuid().ToString();
            this.Name = playerName;
            this.Avatar = "temp avatar";
        }

        public void setPlayerLocation(double locationX, double locationY)
        { 
            this.LocationX = locationX;
            this.LocationY = locationY; 
        }
    }
}
