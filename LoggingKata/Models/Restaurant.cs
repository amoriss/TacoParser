namespace LoggingKata
{
    public class Restaurant : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public Menu Menu { get; set; }
    }
}