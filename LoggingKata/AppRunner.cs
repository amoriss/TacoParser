using System;
using GeoCoordinatePortable;
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
            var tacoData = processor.ProcessTacoBellData(lines);

            //finds two Taco Bells Furthest Apart
            LocationComparer.DisplayTheTwoFurthestTacoBells(tacoData);
        }
    }
}