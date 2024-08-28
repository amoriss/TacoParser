using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);
        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...", 34.035985)]
        [InlineData("34.087508,-84.575512,Taco Bell Acworth...", 34.087508)]
        public void ShouldParseLatitude(string line, double expected)
        {
            // Arrange 
            var tacoParser = new TacoParser();

            // Act
            var actual = tacoParser.Parse(line);

            // Assert
            Assert.Equal(actual.Location.Latitude, expected);
        }


        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.035985,-84.683302,Taco Bell Acworth...", -84.683302)]
        [InlineData("34.087508,-84.575512,Taco Bell Acworth...", -84.575512)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            ITrackable actual = tacoParser.Parse(line);

            //Assert
            Assert.Equal(actual.Location.Longitude, expected);
        }
    }
}