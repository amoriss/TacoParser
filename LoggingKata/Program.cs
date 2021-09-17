using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Find the two Taco Bells that are the furthest from one another.
            // You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();              

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store the two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable tb1 = new TacoBell();
            ITrackable tb2 = new TacoBell();

            double distance = 0; 

            // Include the Geolocation toolbox to compare locations: `using GeoCoordinatePortable;`
        
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for ( int i = 0; i < locations.Length; i ++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int x = 0; x< locations.Length; x++)
                {
                    var locB = locations[x];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tb1 = locA;
                        tb2 = locB; 
                    }
                }
            }

            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells furthest apart");
            Console.WriteLine($"They are {Math.Round(distance * 0.00062, 2)} miles apart.");

            #region 
            // Create a new corA Coordinate with locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (ex. `locB`)

            // Create a new Coordinate with locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            #endregion



        }
    }
}
