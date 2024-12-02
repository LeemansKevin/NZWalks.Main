using AutoMapper;
using NZWalks.Api.Business.Models;
using NZWalks.Api.Data.Entities;
using NZWalks.Api.Data.Repositories;

namespace NZWalks.Api.Business.Services
{
    public class WalkService
    {
        private IWalkRepo _repo;
        private IMapper _mapper;

        public WalkService(IWalkRepo repo, IMapper mapper)
        {
            _repo = repo; //Dependency Injection
            _mapper = mapper;
        }

        public async Task<Walk> GetWalkAsync(int id, bool includeRegion = false)
        {
            WalkEntity entity = null;
            if (includeRegion == true)
            {
                entity = await _repo.GetWalkWithRegionAsync(id);
            }
            else
            {
                entity = await _repo.GetWalkAsync(id);
            }

            if (entity == null) { return null; }

            Walk walkModel = new Walk();

            //mapping

            walkModel = _mapper.Map(entity, walkModel);

            //walkModel.Id = entity.Id;
            //walkModel.Name = entity.Name;
            //walkModel.Description = entity.Description;
            //walkModel.Altidude = entity.Altidude;
            //walkModel.PictureUrl = entity.PictureUrl;
            //walkModel.LengthInKm = entity.LengthInKm;

            //Region regionModel = new Region();
            //regionModel.Id = entity.Region.Id;
            //regionModel.Climate = (Climate) entity.Region.Climate;
            //regionModel.Name = entity.Region.Name;
            //regionModel.Walks.Add (walkModel);
            //walkModel.Region = regionModel;

            //TO DO: Business logic

            return walkModel;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            List<WalkEntity> entity = null;
            entity = await _repo.GetAllWalksAsync();
            List<Walk> walkModel = new List<Walk>();

            walkModel = _mapper.Map(entity, walkModel);

            return walkModel;
        }

        public async Task AddWalkAsync(Walk model)
        {
            if (String.IsNullOrWhiteSpace(model.Name))
            {
                throw new ArgumentNullException(model.Name);
            }
            WalkEntity entity = null;
            entity = _mapper.Map(model, entity);
            await _repo.AddWalkAsync(entity);
        }

        public async Task DeleteWalkAsync(int id)
        {
            await _repo.DeleteWalkAsync(id);
        }
    }
}