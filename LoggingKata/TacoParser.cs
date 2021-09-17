namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take the line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // If one record parsing fails, return null
                return null; 
            }

            // grab the latitude from your array at index 0
            var lat = double.Parse(cells[0]);
            // grab the longitude from your array at index 1
            var lon = double.Parse(cells[1]);
            // grab the name from your array at index 2
            var name = cells[2];
            #region
            // Parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // Create a TacoBell class
            // that conforms to ITrackable

            // Need an instance of the TacoBell class
            // With the name and point set correctly
            #endregion
            TacoBell tacoBell1 = new TacoBell();           

            tacoBell1.Name = name;
            tacoBell1.Location = new Point { Latitude = lat, Longitude = lon };
            

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell1;
        }
    }
}