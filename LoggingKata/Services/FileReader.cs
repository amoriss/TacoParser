﻿using System;
using System.IO;
using Serilog;

namespace LoggingKata
{
    public class FileReader
    {
        private static string _csvPath = "Data/TacoBell-US-AL.csv";

        /// <summary>
        /// Reads contents of a file
        /// </summary>
        /// <returns>A string array of the csv file</returns>
        public static string[] ReadFile()
        {
            try
            {
                var lines = File.ReadAllLines(_csvPath);
                Log.Information("File read successfully from {CsvPath}.", _csvPath);
                return lines;
            }
            catch (Exception e)
            {
                Log.Error("Unable to read this file: {CsvPath}", _csvPath);
                return null;
            }
        }
    }
}