using static ErikssonSoftware.Data.EntryFromLog;

namespace ErikssonSoftware.Services
{
    public interface IParser
    {
        // Creating Interface
        IEnumerable<LogEntry> Parse(IEnumerable<string> lines);
    }
}
