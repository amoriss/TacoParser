using System;

namespace LoggingKata.Utlities
{
    public class DisplayHelper
    {
        public static void DisplayTheTwoFurthestRestaurants(ITrackable[] locations)
        {
            var result = RestaurantLocationComparer.GetTwoFurthestRestaurants(locations);
            var (tb1, tb2, distance) = result;

            //two locations furthest apart from each other
            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells furthest apart.");
            //Distance in miles
            Console.WriteLine($"They are {ConversionHelper.ConvertMetersToMiles(distance)} miles apart.");
        }
        public static void DisplayTheTwoClosestRestaurants(ITrackable[] locations)
        {
            var result = RestaurantLocationComparer.GetTwoClosestRestaurants(locations);
            var (tb1, tb2, distance) = result;

            //two locations furthest apart from each other
            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells closest together.");
            //Distance in miles
            Console.WriteLine($"They are {ConversionHelper.ConvertMetersToMiles(distance)} miles apart.");
        }
    }
}