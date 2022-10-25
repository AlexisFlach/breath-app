using Api.Models;
using Microsoft.EntityFrameworkCore;    

namespace Api.Data.Repositories
{
    public class LevelRepo : ILevelRepo
    {
        private readonly AppDbContext _context;

        public LevelRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Level>> GetAllLevels()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task<Level> GetLevelById(int id)
        {
            return await _context.Levels.FindAsync(id);
        }

        public async Task<Level> CreateLevel(Level level)
        {
            _context.Levels.Add(level);
            await SaveChangesAsync();
            return level;
        }

        public async Task<Level> UpdateLevel(Level level)
        {
            _context.Entry(level).State = EntityState.Modified;
            await SaveChangesAsync();
            return level;
        }

        public async Task<Level> DeleteLevel(int id)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return null;
            }

            _context.Levels.Remove(level);
            await SaveChangesAsync();
            return level;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}