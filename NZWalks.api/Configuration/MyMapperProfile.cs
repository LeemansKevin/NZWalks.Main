using AutoMapper;
using NZWalks.api.DTO;
using NZWalks.Api.Business.Models;
using NZWalks.Api.Data.Entities;

namespace NZWalks.api.Configuration
{
    public class MyMapperProfile : Profile
    {
        public MyMapperProfile()
        {
            CreateMap<AddWalkDTO, Walk>();
            CreateMap<WalkEntity, Walk>()
                .ForMember(dest => dest.Altitude, x => x.MapFrom(src => src.Altidude))
                .ReverseMap();

            CreateMap<AddRegionDTO, Region>();
            CreateMap<RegionEntity, Region>()
                .ReverseMap();

            CreateMap<Walk, GetWalkDTO>()
                .ForMember(dest => dest.WalkName, x => x.MapFrom(src => src.Name))
                .ForMember(dest => dest.Region, x => x.MapFrom(src => src.Region.Name))
                .ForMember(dest => dest.Climate, x => x.MapFrom(src => src.Region.Climate.ToString()));

            CreateMap<Region, GetRegionWithWalksDTO>()
                .ForMember(dest => dest.RegionName, x => x.MapFrom(src => src.Name));
        }
    }
}