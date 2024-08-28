using System;
using GeoCoordinatePortable;

namespace LoggingKata
{
    public class AppRunner
    {
      public void Run()
        {
            //file returned as string array
            var lines = FileReader.ReadFile();

            //file as ITrackable array
            var processor = new DataProcessor();
            var locations = processor.StringArrayToITrackableArray(lines);
            
            //finds two Taco Bells Furthest Apart
            LocationComparer.FindTwoFurthestTacoBells(locations);
        }
      
    }
}