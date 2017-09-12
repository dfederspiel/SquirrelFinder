using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace SquirrelFinder.Acorn
{

    public class SquirrelFinderLogEntry
    {
        private readonly string Type;

        public LogEntry LogEntry { get; private set; }
        public string HandlingInstanceId { get; private set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string CallStack { get; set; }
        public string RequestedUrl { get; set; }
        public string WebEventCode { get; set; }
        public string ErrorCode { get; set; }
        public string Data { get; set; }
        public string TargetSite { get; set; }
        public string[] StackTrace { get; set; }
        public string MachineName { get; set; }
        public SquirrelFinderLogEntry(LogEntry entry, TraceEventCache eventCache)
        {
            LogEntry = entry;
            HandlingInstanceId = GetData(@"^HandlingInstanceID: (\S+)\r\n");
            Type = GetData(@"^Type : (\S\w.+)\r\n");
            Message = GetData(@"^Message : (.*)\r\n");
            Source = GetData(@"^Source : (\S\w.+)");
            RequestedUrl = GetData(@"^Requested URL : (\w\S+)\r\n");
            WebEventCode = GetData(@"^WebEventCode : (\d+)");
            ErrorCode = GetData(@"^ErrorCode : (-?\d+)");
            Data = GetData(@"^Data : (\S\w.+)");
            TargetSite = GetData(@"^TargetSite : (\S\w.+)");
            StackTrace = GetDataLines(@"^[Stack Trace]? {3}(.*)");
            MachineName = GetData(@"^MachineName : (.*)");

            CallStack = eventCache.Callstack;
        }

        private string[] GetDataLines(string pattern)
        {
            RegexOptions options = RegexOptions.Multiline;

            var lines = new List<string>();
            foreach (Match m in Regex.Matches(LogEntry.Message, pattern, options))
            {
                if (m.Groups.Count > 1)
                    lines.Add(m.Groups[1].Value);
            }

            return lines.ToArray();
        }

        string GetData(string pattern)
        {
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(LogEntry.Message, pattern, options))
            {
                if (m.Groups.Count > 1)
                    return m.Groups[1].Value;
            }

            return string.Empty;
        }
    }

    public class SquirrelFinderTraceListener : CustomTraceListener
    {
        public static List<SquirrelFinderLogEntry> LogEntries { get; private set; }

        public SquirrelFinderTraceListener() : this(new SquirrelFinderTraceListenerClient())
        {
            LogEntries = new List<SquirrelFinderLogEntry>();
        }

        public SquirrelFinderTraceListener(SquirrelFinderTraceListenerClient client)
        {
            traceListenerClient = client;
            LogEntries = new List<SquirrelFinderLogEntry>();
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            if ((Filter == null) || Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
            {
                if (data is LogEntry)
                {
                    Write(((LogEntry)data).Message);
                }
                else if (data is string)
                {
                    Write(data as string);
                }

                LogEntries.Add(new SquirrelFinderLogEntry(data as LogEntry, eventCache));
            }
        }

        public override void Write(string message)
        {
            traceListenerClient.LogMessage(message);
        }

        public override void WriteLine(string message)
        {
            traceListenerClient.LogMessage(message + Environment.NewLine);
        }

        private ISquirrelFinderTraceListenerClient traceListenerClient;
    }
}