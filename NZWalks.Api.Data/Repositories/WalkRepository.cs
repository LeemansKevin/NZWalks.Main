using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data.Entities;

namespace NZWalks.Api.Data.Repositories
{
    public class WalkRepository : IWalkRepo
    {
        private ApiDBContext _dbContext;

        public WalkRepository(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddWalkAsync(WalkEntity walk)
        {
            _dbContext.Walks.Add(walk); //query
            await _dbContext.SaveChangesAsync(); //execute
        }

        public async Task DeleteWalkAsync(int id)
        {
            WalkEntity entity = new WalkEntity();
            entity.Id = id;
            _dbContext.Walks.Attach(entity);
            _dbContext.Walks.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<WalkEntity>> GetAllWalksAsync()
        {
            return await _dbContext.Walks.Include(x => x.Region).ToListAsync();
        }

        public async Task<WalkEntity> GetWalkAsync(int id)
        {
            return await _dbContext.Walks.FindAsync(id);
        }

        public async Task<WalkEntity?> GetWalkWithRegionAsync(int id)
        {
            WalkEntity result = await _dbContext.Walks
                .Include(x => x.Region)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateWalk(WalkEntity walk)
        {
            throw new NotImplementedException();
        }
    }
}