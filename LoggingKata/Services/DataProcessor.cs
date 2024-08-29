using System.Linq;
using Serilog;

namespace LoggingKata
{
    public class DataProcessor
    {
        private RestaurantParser _restaurantParser;


        public DataProcessor()
        {
            _restaurantParser = new RestaurantParser();
        }

        /// <summary>
        /// Transforms a string array into an ITrackable array
        /// </summary>
        /// <param name="fileLines"></param>
        /// <returns>an ITrackable array</returns>
        public ITrackable[] StringArrayToITrackableArray(string[] fileLines, IParser parser)
        {
            if (fileLines is null)
            {
                Log.Error("File lines are null");
            }

            //The parser.Parse method is being passed as a delegate (or a method reference) to the Select LINQ method.
            ITrackable[] locations = fileLines.Select(parser.Parse).ToArray();

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

        public ITrackable[] ProcessRestaurantData(string[] fileLines)
        {
            var tacoData = StringArrayToITrackableArray(fileLines, _restaurantParser);
            return tacoData;
        }

        
    }
}