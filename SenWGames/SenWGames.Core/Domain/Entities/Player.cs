using SenWGames.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
