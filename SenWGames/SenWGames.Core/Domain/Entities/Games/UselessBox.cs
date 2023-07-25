using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenWGames.Core.Domain.Entities.Games
{
    public class UselessBox : Game
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool State { get; private set; }
        public int Count { get; private set; }


        public UselessBox()
        {
            this.Name = "UselessBox";
            this.Image = "GameAvatar";
            this.Title = "UselessBox";
            this.Description = "description...";
            this.State = true;
            this.Count = 0;
        }
        public void UseUselessBox()
        {
            this.State = !this.State;
            this.Count++;
        }
    }
}
