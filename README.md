# ErikssonSoftware





```C#
public class LogAnalyzer
{
    public IReadOnlyList<(string Type, int Count)> CountByType(IEnumerable<LogEntry> entries) =>
        entries.GroupBy(e => e.EventType)
            .Select(g => (g.Key, g.Count()))
            .OrderBy(x => x.Item2)
            .ToList();

    public IReadOnlyList<(string Message, int Count)> TopMessages(IEnumerable<LogEntry> entries, string type, int top = 3) =>
        entries.Where(e  => e.EventType == type)
            .GroupBy(e => e.Message)
            .OrderByDescending(g => g.Count())
            .Take(top)
            .Select(g => (g.Key, g.Count()))
            .ToList();
}
```
