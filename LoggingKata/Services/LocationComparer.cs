using System;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class LocationComparer
    {
        public static void FindTwoFurthestTacoBells(ITrackable[] locations)
        {
            ITrackable tb1 = new TacoBell();
            ITrackable tb2 = new TacoBell();

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
                        tb1 = locA;
                        tb2 = locB;
                    }
                }

                #endregion
            }


            //These are the two Taco Bells furthest apart from each other from the .CSV file
            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells furthest apart.");
            //Distance in miles
            Console.WriteLine($"They are {Math.Round((distance * 0.00062), 2)} miles apart.");
        }
    }
}