using System.Linq;

namespace LoggingKata
{
    public class DataProcessor
    {
        private TacoParser _tacoParser;

        public DataProcessor()
        {
            _tacoParser = new TacoParser();
        }

        /// <summary>
        /// Transforms a string array into an ITrackable array
        /// </summary>
        /// <param name="fileLines"></param>
        /// <returns>an ITrackable array</returns>
        public ITrackable[] StringArrayToITrackableArray(string[] fileLines)
        {
            //The parser.Parse method is being passed as a delegate (or a method reference) to the Select LINQ method.
            ITrackable[] locations = fileLines.Select(_tacoParser.Parse).ToArray();

            #region OtherParseOptions

            //OR Option 2
            //ITrackable[] locations = lines.Select(line => parser.Parse(line)).ToArray();

            //OR Option 3
            //var tacoList = new List<ITrackable>();
            //foreach (var line in lines)
            //{
            //    tacoList.Add(parser.Parse(line));
            //}

            #endregion

            return locations;
        }
    }
}