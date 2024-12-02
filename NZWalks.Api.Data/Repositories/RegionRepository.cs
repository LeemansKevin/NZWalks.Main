using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data.Entities;

namespace NZWalks.Api.Data.Repositories
{
    public class RegionRepository : IRegionRepo
    {
        private ApiDBContext _dbContext;

        public RegionRepository(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddRegionAsync(RegionEntity region)
        {
            _dbContext.Regions.Add(region); //query
            await _dbContext.SaveChangesAsync(); //execute query
        }

        public async Task DeleteRegion(RegionEntity region)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RegionEntity>> GetAllRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<RegionEntity> GetRegionAsync(int id)
        {
            RegionEntity entity = await _dbContext.Regions.FindAsync(id);
            return entity;
        }

        public async Task UpdateRegion(RegionEntity region)
        {
            throw new NotImplementedException();
        }

        public async Task<RegionEntity> GetRegionWithWalksAsync(int id)
        {
            return await _dbContext.Regions
            .Include(r => r.Walks)
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();
        }
    }
}