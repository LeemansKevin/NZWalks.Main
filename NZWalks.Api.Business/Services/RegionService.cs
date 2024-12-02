using AutoMapper;
using NZWalks.Api.Business.Models;
using NZWalks.Api.Data.Entities;
using NZWalks.Api.Data.Repositories;

namespace NZWalks.Api.Business.Services
{
    public class RegionService
    {
        private IRegionRepo _repo;
        private IMapper _mapper;

        public RegionService(IRegionRepo repo, IMapper mapper)
        {
            _repo = repo; //Dependency Injection
            _mapper = mapper;
        }

        public async Task<Region> GetRegionAsync(int id, bool includeWalks)
        {
            RegionEntity entity = null;

            if (includeWalks == true)
            {
                entity = await _repo.GetRegionWithWalksAsync(id);
            }
            else
            {
                entity = await _repo.GetRegionAsync(id);
            }

            Region regionModel = new Region();

            regionModel = _mapper.Map(entity, regionModel);

            return regionModel;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            List<RegionEntity> entity = null;
            entity = await _repo.GetAllRegionsAsync();
            List<Region> regionModel = new List<Region>();

            regionModel = _mapper.Map(entity, regionModel);

            return regionModel;
        }

        public void AddRegion(Region model)
        {
            if (String.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentNullException(model.Name);
            }

            RegionEntity entity = null;
            entity = _mapper.Map(model, entity);
            _repo.AddRegionAsync(entity);
        }
    }
}