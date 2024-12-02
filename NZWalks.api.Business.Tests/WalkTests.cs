using AutoMapper;
using Moq;
using NZWalks.api.Configuration;
using NZWalks.Api.Business.Models;
using NZWalks.Api.Business.Services;
using NZWalks.Api.Data.Entities;
using NZWalks.Api.Data.Repositories;

namespace NZWalks.api.Business.Tests
{
    public class WalkTests
    {
        [Test]
        public async Task WhenUserGetsAWalk_ThenRegionIsNotIncludedByDefaultAsync()
        {
            //Arrange

            //Dit is een fake object!
            Mock<IWalkRepo> mockRepo = new Mock<IWalkRepo>();

            //Fake functionaliteit toevoegen
            mockRepo.Setup(x => x.GetWalkAsync(It.IsAny<int>()))
                .ReturnsAsync(GenerateTestWalk());

            //Configure AutoMapper
            var config = new MapperConfiguration
            (cfg => { cfg.AddProfile(new MyMapperProfile()); });
            IMapper mapper = config.CreateMapper(); // Create the IMapper instance

            WalkService service = new WalkService(mockRepo.Object, mapper);

            //Act
            Walk actualWalk = await service.GetWalkAsync(1);

            //Assert
            Assert.AreEqual("testName", actualWalk.Name);
            Assert.AreEqual(5, actualWalk.LengthInKm);
            Assert.IsNull(actualWalk.Region);
        }

        private static WalkEntity GenerateTestWalk()
        {
            WalkEntity expectedWalk = new WalkEntity();
            expectedWalk.Name = "testName";
            expectedWalk.LengthInKm = 5;
            return expectedWalk;
        }

        [TestCase(1, 0.6213)]
        [TestCase(5, 3.1065)]
        [TestCase(20, 12.426)]
        public void ConversionToMileIsCorrect(int kilometer, double expectedMiles)
        {
            //Arrange

            //Act
            Walk walk = new Walk();
            walk.LengthInKm = kilometer;

            //Assert
            Assert.AreEqual(expectedMiles, walk.LengthInMile);
        }
    }
}