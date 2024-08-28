using Serilog;

namespace LoggingKata
{
    /// <summary>
    /// Parses a comma separated string into a TacoBell instance
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            // Take the line and split it up into an array of strings
            //"34.073638,-84.677017,Taco Bell Acwort..."
            string[] cells = line.Split(',');

            // If array's length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                Log.Error("Array length is less than three objects. Unable to Parse.");
                return null;
            }

            var lat = double.Parse(cells[0]);
            var lon = double.Parse(cells[1]);
            string name = cells[2];
            TacoBell tacoBell1 = new TacoBell();

            tacoBell1.Name = name;
            tacoBell1.Location = new Point { Latitude = lat, Longitude = lon };

            return tacoBell1;
        }
    }
}