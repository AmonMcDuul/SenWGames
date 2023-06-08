using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenWGames.Core.Domain.Entities.Games
{
    public class TicTacToe : Game
    {
        public string Description { get; private set; }
        public TicTacToe(string description)
        {
            Description = description;
        }
    }
}
