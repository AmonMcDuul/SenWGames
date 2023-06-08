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
        public GameLobby GameLobby { get; private set; }
        public ICollection<GameLobby> PlayedGames { get; private set; }
        public ICollection<Player> Players { get; private set; }
        public Player GroupLeader { get; private set; }

        public Group(string groupName, GameLobby gameLobby, ICollection<GameLobby> playedGames, ICollection<Player> players, Player groupLeader)
        {
            GroupId = Guid.NewGuid().ToString();
            GroupName = groupName;
            GameLobby = gameLobby;
            PlayedGames = playedGames;
            Players = players;
            GroupLeader = groupLeader;
        }
    }
}
