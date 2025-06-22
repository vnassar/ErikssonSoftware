using static ErikssonSoftware.Data.EntryFromLog;

namespace ErikssonSoftware.Services
{
    public class LogAnalyzer
    {
        // group entries by event type and count the occurrences
        public IReadOnlyList<(string Type, int Count)> CountByType(IEnumerable<LogEntry> entries) =>
            entries.GroupBy(e => e.EventType) // Group into buckets for the appropriate event type: Warning/Info/Error,etc
                .Select(group => (EventType: group.Key, Count: group.Count())) // select the group (bucket) and how many entries in each
                .OrderByDescending(result => result.Count) // Sort so most frequent types come first
                .ToList(); // convert to read only list for UI

        // find most frequent messages for the event type we pass in
        public IReadOnlyList<(string Message, int Count)> TopMessages(IEnumerable<LogEntry> entries, string type) =>
            entries.Where(e  => e.EventType == type) // keep where entries is of this TYPE ... passed in from UI in Log.razor
                .GroupBy(e => e.Message)  // group again, now by the message text
                .OrderByDescending(result => result.Count()) // sort the message groups by how often each one appears (biggest to lowest)
                .Take(3) // get the 3 messages sitting at top 
                .Select(group => (Message: group.Key, Count: group.Count())) // select the group (bucket) and how many entries in each
                .ToList(); // convert to read only list for UI
    }
}
