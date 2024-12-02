namespace NZWalks.api.Business.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OnePlusTwo_ShouldEqual3()
        {
            //Arrange-hier verzamelen we de nodige gegevens
            int number1 = 1;
            int number2 = 2;
            int expectedResult = 3;

            //Act-hier voor je de methode uit die je wil testen
            int actualResult = number1 + number2;

            //Assert-hier controleer je of het resultaat gelijk is aan het verwachte resultaat
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}