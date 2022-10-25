using Api.Models;

namespace Api.Data.Repositories
{
    public interface ILevelRepo
    {
        Task SaveChangesAsync();
        Task<IEnumerable<Level>> GetAllLevels();
        Task<Level> GetLevelById(int id);
        Task<Level> CreateLevel(Level level);
        Task<Level> UpdateLevel(Level level);
        Task<Level> DeleteLevel(int id);

    }
}