using System;
using Xunit;

namespace LoggingKata.Test
{
    public class RestaurantParserTests
    {
        [Fact]
        public void Parse_ShoudlReturnNOnNull_WhenGivenValidInput()
        {
            //Arrange
            var tacoParser = new RestaurantParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);
        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("32.571331,-85.499655,Taco Bell Auburn", 32.571331)]
        [InlineData("31.306794,-85.714414,Taco Bell Daleville.", 31.306794)]
        public void Parse_ShouldExtractCorrectLatitude_WhenGivenTacoLocationString(string line, double expected)
        {
            // Arrange 
            var tacoParser = new RestaurantParser();

            // Act
            var actual = tacoParser.Parse(line);

            // Assert
            Assert.Equal(actual.Location.Latitude, expected);
        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("32.571331,-85.499655,Taco Bell Auburn", -85.499655)]
        [InlineData("31.306794,-85.714414,Taco Bell Daleville.", -85.714414)]
        public void Parse_ShouldExtractCorrectLongitude_WhenGivenTacoLocationString(string line, double expected)
        {
            //Arrange
            var tacoParser = new RestaurantParser();

            //Act
            ITrackable actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(actual.Location.Longitude, expected);
        }
        
    }
}