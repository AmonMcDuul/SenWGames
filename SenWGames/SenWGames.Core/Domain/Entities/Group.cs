using SenWGames.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SenWGames.Core.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string GroupId { get; private set; }
        public string GroupName { get; private set; }
        public GameLobby? GameLobby { get; private set; }
        public ICollection<GameLobby>? PlayedGames { get; private set; }
        public ICollection<Player>? Players { get; private set; }
        public string? GroupLeaderId { get; private set; }

        public Group() { }
        public Group(string groupName, GameLobby? gameLobby, ICollection<GameLobby>? playedGames, Player player, string? groupLeaderId)
        {
            GroupId = Guid.NewGuid().ToString();
            GroupName = groupName;
            GameLobby = gameLobby;
            PlayedGames = playedGames;
            //moet even nagedacht worden over het setten van de player
            List<Player>? players = new List<Player>
            {
                player
            };
            Players = players;
            GroupLeaderId = groupLeaderId;
        }

        public void UpdateName(string newName)
        {
            this.GroupName = newName;        
        }

        public GameLobby CreateGameLobby(string naam)
        {
            //nog iets doen met players.
            this.GameLobby = new GameLobby(naam, this.Players!, naam);
            return this.GameLobby;
        }
    }
}
