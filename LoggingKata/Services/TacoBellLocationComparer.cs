using System;
using GeoCoordinatePortable;
using LoggingKata.Utlities;

namespace LoggingKata
{
    public class TacoBellLocationComparer
    {
        

    
        /// <summary>
        /// iteration through the locations and finds the two Taco Bells furthest apart and the distance between them
        /// </summary>
        /// <param name="locations"></param>
        /// <returns>two ITrackables (Taco Bells) and the distance in meters as a double</returns>
        public static (ITrackable, ITrackable, double) GetTwoFurthestTacoBells(ITrackable[] locations)
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

            return (tb1, tb2, distance);
        }
        
        public static (ITrackable, ITrackable, double) GetTwoClosestTacoBells(ITrackable[] locations)
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

                for (int x = 1; x < locations.Length; x++)
                {
                    //second location
                    var locB = locations[x];

                    //set second location's geocoordinates
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    // Comparing and updating the distance 
                    if (corA.GetDistanceTo(corB) < distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tb1 = locA;
                        tb2 = locB;
                    }
                }

                #endregion
            }

            return (tb1, tb2, distance);
        }

       
    }
}