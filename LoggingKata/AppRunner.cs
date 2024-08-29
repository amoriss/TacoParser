using System;
using GeoCoordinatePortable;
using LoggingKata.Utlities;
using Serilog;

namespace LoggingKata
{
    public class AppRunner
    {
        public void Run()
        {
            // Initialize Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            //file returned as string array
            var lines = FileReader.ReadFile();

            //file as ITrackable array
            var processor = new DataProcessor();
            var subwayData = processor.ProcessSubwayData(lines);

            //displays two Taco Bells Furthest Apart
            DisplayHelper.DisplayTheTwoClosestSubways(subwayData);
        }
    }
}