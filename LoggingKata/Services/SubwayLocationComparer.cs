using System;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class SubwayLocationComparer
    {
        public static void DisplayTheTwoFurthestSubways(ITrackable[] locations)
        {
            var result = GetTwoFurthestSubways(locations);
            var (sb1, sb2, distance) = result;

            //two locations furthest apart from each other
            Console.WriteLine($"{sb1.Name} and {sb2.Name} are the two Subways furthest apart.");
            //Distance in miles
            Console.WriteLine($"They are {Math.Round((distance * 0.00062), 2)} miles apart.");
        }

        public static (ITrackable, ITrackable, double) GetTwoFurthestSubways(ITrackable[] locations)
        {
            ITrackable sb1 = new Subway();
            ITrackable sb2 = new Subway();

            double distance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                #region INSIDE FOR LOOP WORK

                // first location
                var locA = locations[i];

                // set first location's geocooridnates
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int x = 0; x < locations.Length; x++)
                {
                    //second location
                    var locB = locations[x];

                    //set second location's geocoordinates
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    // Comparing and updating the distance 
                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        sb1 = locA;
                        sb2 = locB;
                    }
                }

                #endregion
            }

            return (sb1, sb2, distance);
        }
    }
}