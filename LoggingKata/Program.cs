﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Collections.Generic;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();


        static void Main(string[] args)
        {
            // PROGRAM OBJECTIVE:  Find the two Taco Bells that are the furthest from one another.

            //file returned as string array
            var lines = FileReader.ReadFile();

            //file as ITrackable array
            var processor = new DataProcessor();
            var locations = processor.FileStringArrayToITrackableArray(lines);

            CompareITrackables(locations);
        }


        public static void CompareITrackables(ITrackable[] locations)
        {
            ITrackable tb1 = new TacoBell();
            ITrackable tb2 = new TacoBell();

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                #region INSIDE FOR LOOP WORK

                // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
                var locA = locations[i];

                // Create a new corA Coordinate with locA's lat and long
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                //OR
                //var corA = new GeoCoordinate();
                //corA.Latitude = locA.Location.Latitude;
                //corA.Longitude = locA.Location.Longitude;

                for (int x = 0; x < locations.Length; x++)
                {
                    // Create a new Coordinate with locB's lat and long
                    var locB = locations[x];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables set above
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tb1 = locA;
                        tb2 = locB;
                    }
                }

                #endregion
            }


            //These are the two Taco Bells furthest apart from each other from the .CSV file
            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells furthest apart");
            //Distance in miles
            Console.WriteLine($"They are {Math.Round((distance * 0.00062), 2)} miles apart.");
        }
    }
}