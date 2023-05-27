using SenWGames.Core.Model;

namespace SenWGames.Core.Interfaces
{
    public interface IValueService
    {
        Task<Value> GetAValue(int id);
    }
}
