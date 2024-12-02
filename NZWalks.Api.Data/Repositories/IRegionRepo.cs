using NZWalks.Api.Data.Entities;

namespace NZWalks.Api.Data.Repositories
{
    public interface IRegionRepo
    {
        Task AddRegionAsync(RegionEntity region);

        Task DeleteRegion(RegionEntity region);

        Task<List<RegionEntity>> GetAllRegionsAsync();

        Task<RegionEntity> GetRegionAsync(int id);

        Task<RegionEntity> GetRegionWithWalksAsync(int id);

        Task UpdateRegion(RegionEntity region);
    }
}