using SenWGames.Core.Domain.Common;
using SenWGames.Core.Domain.Entities.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SenWGames.Core.Domain.Entities
{
    public class GameLobby : BaseEntity
    {
        public string Name { get; private set; }
        public ICollection<Player>? Players { get; private set; } = new List<Player>();
        public Game? Game { get; private set; }
        //winner loser iets beters op verzinnen + gelijkspel. misschien gewoon via methode returnen ofzo
       // public Player Winner { get; private set; }
        //public Player Loser { get; private set; }
        public bool Active { get; private set; }
        public GameLobby() { }

        public GameLobby(string name, ICollection<Player> players, string gameTitle)
        {
            this.Name = name;
            this.Players = players;

            //superlelak
            if(gameTitle == "UselessBox")
            {
                this.Game = new UselessBox();
            }
            else
            {
                this.Game = new UselessBox();
            }

            this.Active = true;
        }
    }
}
