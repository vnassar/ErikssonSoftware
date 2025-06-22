using ErikssonSoftware.Data;
using static ErikssonSoftware.Data.EntryFromLog;

namespace ErikssonSoftware.Services
{
    public class LogParser : IParser // implementation
    {
        public IEnumerable<LogEntry> Parse(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue; // skip and move on if line is empty or white spaces 


                /* 
                 First 3 lines from sample log are:
                [2024-06-19 10:00:01] INFO User logged in: user123

                [2024-06-19 10:00:05] WARNING Disk space low: /var/log

                [2024-06-19 10:00:10] ERROR Failed to connect to database: Connection refused


                 [TIMESTAMP] EVENT_TYPE MESSAGE
                            or:
                 [Time] Error something happened

                 For each non-empty line we:
                1. Get rid of brackets 
                2. isolate timestamp from first part
                3. extract event type then message from second part
                4. return as LogEntry object
                 */
                // 1.Split the closing brackets
                var parts = line.Split(']', 2, StringSplitOptions.RemoveEmptyEntries);

                // 2. Parse timestamp from first part
                var timeStamp = DateTime.Parse(parts[0].TrimStart('['));

                // get rid of leading white space.
                var rest = parts[1].TrimStart();

                // get the space between event type and message
                int firstSpace = rest.IndexOf(' ');

                // 3. extract event type then message from second part
                var eventType = rest[..firstSpace];
                // extracts the message after the space
                var message = rest[(firstSpace + 1)..];

                yield return new LogEntry(timeStamp, eventType, message); // yield return to continue iterating, otherwise if we do just return it'll only process the first line. 
            }

        }
    }
}
