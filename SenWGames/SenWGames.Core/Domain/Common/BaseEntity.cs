using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenWGames.Core.Domain.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public BaseEntity()
        {
            this.CreatedAt = DateTime.UtcNow;
        }

        public void SetUpdated()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}