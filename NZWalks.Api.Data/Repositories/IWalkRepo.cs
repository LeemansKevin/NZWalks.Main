using NZWalks.Api.Data.Entities;

namespace NZWalks.Api.Data.Repositories
{
    public interface IWalkRepo
    {
        Task AddWalkAsync(WalkEntity walk);

        Task DeleteWalkAsync(int id);

        Task<List<WalkEntity>> GetAllWalksAsync();

        Task<WalkEntity> GetWalkAsync(int id);

        Task<WalkEntity?> GetWalkWithRegionAsync(int id);

        Task UpdateWalk(WalkEntity walk);
    }
}