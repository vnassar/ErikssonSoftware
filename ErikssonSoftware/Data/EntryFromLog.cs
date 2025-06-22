namespace ErikssonSoftware.Data
{
    public class EntryFromLog
    {
        // Data Model
        public record LogEntry(DateTime TimeStamp, string EventType, string Message);
    }
}
