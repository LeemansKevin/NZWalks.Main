using AutoMapper;
using Moq;
using NZWalks.api.Configuration;
using NZWalks.Api.Business.Models;
using NZWalks.Api.Business.Services;
using NZWalks.Api.Data.Entities;
using NZWalks.Api.Data.Repositories;

namespace NZWalks.api.Business.Tests
{
    public class RegionTests
    {
        [Test]
        public async Task WhenUserGetsARegion_ThenEntityCanBeMappedToModel()

        {
            //Arrange
            Mock<IRegionRepo> mockRepo = new Mock<IRegionRepo>();

            mockRepo.Setup(x => x.GetRegionAsync(It.IsAny<int>()))
                .ReturnsAsync(GenerateTestRegion());

            //Configure AutoMapper
            var config = new MapperConfiguration
            (cfg => { cfg.AddProfile(new MyMapperProfile()); });
            IMapper mapper = config.CreateMapper(); // Create the IMapper instance

            RegionService service = new RegionService(mockRepo.Object, mapper);

            //Act

            Region region = await service.GetRegionAsync(1, false);

            //Assert

            Assert.IsNotNull(region);
            Assert.That(region.Climate, Is.EqualTo(Climate.Rainy));
            Assert.That(region.Name, Is.EqualTo("testName"));
        }

        private RegionEntity GenerateTestRegion()
        {
            RegionEntity expectedRegion = new RegionEntity();
            expectedRegion.Name = "testName";
            expectedRegion.Climate = 2;
            return expectedRegion;
        }
    }
}