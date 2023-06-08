using SenWGames.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenWGames.Core.Domain.Entities
{
    public abstract class Game : BaseEntity
    {
        public string Name { get; protected set; }
        public string Image { get; protected set; }
        protected Game() { }
        public Game(string name, string image)
        {
            Name = name;
            Image = image;
        }
    }
}
