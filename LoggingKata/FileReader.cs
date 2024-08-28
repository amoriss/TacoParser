﻿using System.IO;

namespace LoggingKata
{
    public class FileReader
    {
        private static string _csvPath;

        public FileReader()
        {
            _csvPath = "TacoBell-US-AL.csv";
        }
        
        public static string[] ReadFile()
        {
            // stores content of the file as a string array
            var lines = File.ReadAllLines(_csvPath);
            return lines;
        }
    }
}