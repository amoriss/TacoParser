using System;
using Xunit;

namespace LoggingKata.Test
{
    public class RestaurantParserTests
    {
        [Fact]
        public void Parse_ShouldReturnNOnNull_WhenGivenValidInput()
        {
            //Arrange
            var tacoParser = new RestaurantParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);
        }


        [Theory]
        [InlineData("30.365453,-97.688556,Norwood Park Plaza", 30.365453)]
        [InlineData("30.425159,-97.791797,Walden Park Shopping Center", 30.425159)]
        [InlineData("30.266868,-97.721093,Eastland Plaza Shopping Ctr", 30.266868)]
        public void Parse_ShouldExtractCorrectLatitude_WhenGivenLocationString(string line, double expected)
        {
            // Arrange 
            var tacoParser = new RestaurantParser();

            // Act
            var actual = tacoParser.Parse(line);

            // Assert
            Assert.Equal(actual.Location.Latitude, expected);
        }


        [Theory]
        [InlineData("30.365453,-97.688556,Norwood Park Plaza", -97.688556)]
        [InlineData("30.425159,-97.791797,Walden Park Shopping Center", -97.791797)]
        [InlineData("30.266868,-97.721093,Eastland Plaza Shopping Ctr", -97.721093)]
        public void Parse_ShouldExtractCorrectLongitude_WhenGivenLocationString(string line, double expected)
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