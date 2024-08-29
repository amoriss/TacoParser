using Xunit;

namespace LoggingKata.Test
{
    public class SubwayParserTests
    {
        [Theory]
        [InlineData("30.365453,-97.688556,Norwood Park Plaza", 30.365453)]
        [InlineData("30.425159,-97.791797,Walden Park Shopping Center", 30.425159)]
        [InlineData("30.266868,-97.721093,Eastland Plaza Shopping Ctr", 30.266868)]
        public void Parse_ShouldExtractCorrectLatitude_WhenGivenSubwayLocationString(string line, double expected)
        {
            // Arrange 
            var subwayParser = new SubwayParser();

            // Act
            var actual = subwayParser.Parse(line);

            // Assert
            Assert.Equal(actual.Location.Latitude, expected);
        }
        [Theory]
        [InlineData("30.365453,-97.688556,Norwood Park Plaza", -97.688556)]
        [InlineData("30.425159,-97.791797,Walden Park Shopping Center", -97.791797)]
        [InlineData("30.266868,-97.721093,Eastland Plaza Shopping Ctr", -97.721093)]
        public void Parse_ShouldExtractCorrectLongitude_WhenGivenSubwayLocationString(string line, double expected)
        {
            //Arrange
            var subwayParser = new SubwayParser();

            //Act
            ITrackable actual = subwayParser.Parse(line);

            //Assert
            Assert.Equal(actual.Location.Longitude, expected);
        }
    }
}