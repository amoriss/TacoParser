using System;
using Serilog;

namespace LoggingKata
{
    /// <summary>
    /// Parses a comma separated string into a TacoBell instance
    /// </summary>
    public class TacoParser
    {
       public ITrackable Parse(string line)
        {
            try
            {
                //ex.: "34.073638,-84.677017,Taco Bell Acwort..."
                //splits line into array of strings
                string[] cells = line.Split(',');

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
                Log.Information("Parsed TacoBell. Name:  {Name} Latitude: {Latitude} Longitude: {Longitude}", name, lat,
                    lon);
                return tacoBell1;
            }
            catch (Exception e)
            {
                Log.Error(e, "Error parsing {Line}", line);
                return null;
            }
        }
    }
}