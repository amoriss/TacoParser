namespace LoggingKata
{
    public interface IParser
    {
        ITrackable Parse(string line);
    }
}