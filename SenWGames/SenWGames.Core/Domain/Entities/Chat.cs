using SenWGames.Core.Domain.Common;

namespace SenWGames.Core.Domain.Entities
{
    public class Chat : BaseEntity
    {
        public string GroupId { get; private set; }
        public string PlayerId { get; private set; }
        public string Message { get; private set; }

        protected Chat() { }

        public Chat(string groupId, string playerId, string message)
        {
            this.GroupId = groupId;
            this.PlayerId = playerId;
            this.Message = message;
        }

    }
}
