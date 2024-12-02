using NZWalks.Api.Business.Models;
using NZWalks.Api.Business.Services;

namespace NZWalks.api.Business.Tests
{
    internal class WalkScoreCalculatorTests
    {
        // Test-driven design: 5 stappen
        // 1. Schrijf een test.
        // 2. Voer test uit en valideer dat deze faalt.
        // 3. De effectieve businesscode schrijven zodat de test slaagt. (mag brol zijn, maar het moet slagen)
        // 4. Refactoring, code optimaliseren, code proper maken.
        // 5. Repeat tot alle business requirements voldaan zijn.

        [TestCase(4, 5)]
        [TestCase(6, 7)]
        [TestCase(12, 4)]
        [TestCase(5, 5)]
        [TestCase(7, 7)]
        public void CalculatorBerekentBasisscoreOpBasisVanAfstandCorrect(int lengthInKm, int score)

        {
            //Arrang
            Walk walk = new Walk();
            walk.LengthInKm = lengthInKm;
            WalkScoreCalculator service = new WalkScoreCalculator();

            //Act

            walk.Score = service.CalculateBaseScore(walk.LengthInKm);

            //Assert

            Assert.AreEqual(score, walk.Score);
        }

        [TestCase(0)]
        [TestCase(-15)]
        public void CalculatorGooitErrorBijNulofNegatiefGetal(int lengthInKm)
        {
            //Arrange
            WalkScoreCalculator service = new WalkScoreCalculator();

            //Act

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => { service.CalculateBaseScore(lengthInKm); });
            Assert.AreEqual("Getal mag niet nul of negatief zijn.", ex.Message);
        }

        [TestCase(Climate.Sweltering, -1)]
        [TestCase(Climate.Rainy, -1)]
        [TestCase(Climate.Sunny, 2)]
        [TestCase(Climate.Cloudy, -1)]
        [TestCase(Climate.Misty, 0)]
        [TestCase(Climate.Unknown, 0)]
        public void AlsKlimaatSunnyIs_GeefTweePunten(Climate climate, int expectedScore)
        {
            //Arrange
            Walk walk = new Walk();
            WalkScoreCalculator service = new WalkScoreCalculator();
            Region region = new Region();
            region.Climate = climate;
            walk.Region = region;

            //Act
            walk.ClimateScore = service.CalculateClimateScore(walk);

            //Assert
            Assert.AreEqual(expectedScore, walk.ClimateScore);
        }

        [TestCase(3, Climate.Cloudy, 4)]
        [TestCase(13, Climate.Unknown, 4)]
        [TestCase(7, Climate.Sunny, 9)]
        [TestCase(5, Climate.Sweltering, 4)]
        [TestCase(11, Climate.Cloudy, 3)]
        public void TotaalScoreIsGelijkAanScorePlusClimateScore(int lengthInKm, Climate climate, int expectedScore)
        {
            //Arrange
            Walk walk = new Walk();
            walk.LengthInKm = lengthInKm;
            WalkScoreCalculator service = new WalkScoreCalculator();
            Region region = new Region();
            region.Climate = climate;
            walk.Region = region;

            //Act
            int totalScore = service.CalculateTotalScore(walk);

            //Assert
            Assert.AreEqual(expectedScore, totalScore);
        }
    }
}