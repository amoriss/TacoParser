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
            // Take the line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            string[] cells = line.Split(',');

            // If array's length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("Error, array length not long enough. Needs three objects");
                return null; 
            }

            var lat = double.Parse(cells[0]);
            var lon = double.Parse(cells[1]);
            string name = cells[2];
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

            //OR 
            //var point = new Point();
            //point.Latitude = lat;
            //point.Longitude = lon;
            //tacoBell1.Location = point;
            
            //CANNOT DO THIS: 
            //tacoBell.Location.Latitude = latitude;

            return tacoBell1;
        }
    }
}