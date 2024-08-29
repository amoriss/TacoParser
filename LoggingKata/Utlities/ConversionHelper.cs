using System;

namespace LoggingKata.Utlities
{
    public static class ConversionHelper
    {
        public static double ConvertMetersToMiles(double distanceInMeters)
        {
            return Math.Round((distanceInMeters * 0.00062), 2);
        }
    }
}