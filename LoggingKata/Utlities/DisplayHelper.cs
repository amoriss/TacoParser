using System;

namespace LoggingKata.Utlities
{
    public class DisplayHelper
    {
        public static void DisplayTheTwoFurthestTacoBells(ITrackable[] locations)
        {
            var result = TacoBellLocationComparer.GetTwoFurthestTacoBells(locations);
            var (tb1, tb2, distance) = result;

            //two locations furthest apart from each other
            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells furthest apart.");
            //Distance in miles
            Console.WriteLine($"They are {ConversionHelper.ConvertMetersToMiles(distance)} miles apart.");
        }
        public static void DisplayTheTwoFurthestSubways(ITrackable[] locations)
        {
            var result = SubwayLocationComparer.GetTwoFurthestSubways(locations);
            var (sb1, sb2, distance) = result;

            //two locations furthest apart from each other
            Console.WriteLine($"{sb1.Name} and {sb2.Name} are the two Subways furthest apart.");
            //Distance in miles
            Console.WriteLine($"They are {Math.Round((distance * 0.00062), 2)} miles apart.");
        }
        public static void DisplayTheTwoClosestTacoBells(ITrackable[] locations)
        {
            var result = TacoBellLocationComparer.GetTwoClosestTacoBells(locations);
            var (tb1, tb2, distance) = result;

            //two locations furthest apart from each other
            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells closest together.");
            //Distance in miles
            Console.WriteLine($"They are {ConversionHelper.ConvertMetersToMiles(distance)} miles apart.");
        }
        public static void DisplayTheTwoClosestSubways(ITrackable[] locations)
        {
            var result = SubwayLocationComparer.GetTwoClosestSubways(locations);
            var (tb1, tb2, distance) = result;

            //two locations furthest apart from each other
            Console.WriteLine($"{tb1.Name} and {tb2.Name} are the two Taco Bells closest together.");
            //Distance in miles
            Console.WriteLine($"They are {ConversionHelper.ConvertMetersToMiles(distance)} miles apart.");
        }
    }
}