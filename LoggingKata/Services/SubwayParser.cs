using System;
using Serilog;

namespace LoggingKata
{
    public class SubwayParser
    {
        /// <summary>
        /// Parses a comma separated string into a Subway instance
        /// </summary>
        public ITrackable Parse(string line)
        {
            try
            {
                string[] cells = line.Split(',');

                if (cells.Length < 3)
                {
                    Log.Error("Array length is less than three objects. Unable to Parse.");
                    return null;
                }

                var lat = double.Parse(cells[0]);
                var lon = double.Parse(cells[1]);
                string name = cells[2];
                Subway subway = new Subway();

                subway.Name = name;
                subway.Location = new Point { Latitude = lat, Longitude = lon };
                Log.Information("Parsed Subway. Name:  {Name} Latitude: {Latitude} Longitude: {Longitude}", name, lat,
                    lon);
                return subway;
            }
            catch (Exception e)
            {
                Log.Error(e, "Error parsing {Line}", line);
                return null;
            }
        }
    }
}