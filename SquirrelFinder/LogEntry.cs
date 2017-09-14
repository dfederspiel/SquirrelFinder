using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder
{
    public class SquirrelFinderLogEntry
    {
        public LogEntry LogEntry { get; set; }
        public string HandlingInstanceId { get; set; }
    }
    public class LogEntry
    {
        public Guid ActivityId { get; set; }
        public string ActivityIdString { get; }
        public string AppDomainName { get; set; }
        public ICollection<string> Categories { get; set; }
        public string[] CategoriesStrings { get; }
        public string ErrorMessages { get; }
        public int EventId { get; set; }
        public IDictionary<string, object> ExtendedProperties { get; set; }
        public string LoggedSeverity { get; }
        public string MachineName { get; set; }
        public string ManagedThreadName { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }
        public string ProcessId { get; set; }
        public string ProcessName { get; set; }
        public Guid? RelatedActivityId { get; set; }
        public TraceEventType Severity { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TimeStampString { get; }
        public string Title { get; set; }
        public string Win32ThreadId { get; set; }
    }
}
