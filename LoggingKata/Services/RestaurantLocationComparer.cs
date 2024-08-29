using System;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class RestaurantLocationComparer
    {
        
        public static (ITrackable, ITrackable, double) GetTwoFurthestRestaurants(ITrackable[] locations)
        {
            ITrackable sb1 = new Restaurant();
            ITrackable sb2 = new Restaurant();

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
        public static (ITrackable, ITrackable, double) GetTwoClosestRestaurants(ITrackable[] locations)
        {
            ITrackable sb1 = new Restaurant();
            ITrackable sb2 = new Restaurant();

            double minDistance = double.MaxValue;

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
                    double distance = corA.GetDistanceTo(corB);
                    if ( distance > 0 && distance <minDistance)
                    {
                        minDistance = distance;
                        sb1 = locA;
                        sb2 = locB;
                    }
                }

                #endregion
            }

            return (sb1, sb2, minDistance);
        }
    }
}