using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace SquirrelFinder.Sitefinity
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

        public SquirrelFinderLogEntry(LogEntry entry, TraceEventCache eventCache)
        {
            LogEntry = entry;
            HandlingInstanceId = GetData(@"^HandlingInstanceID: (\S+)\r\n");
            Type = GetData(@"^Type : (\S\w.+)\r\n");
            Message = GetData(@"^Message : (\S\W.+)\r\n");
            Source = GetData(@"^Source : (\S\w.+)");
            RequestedUrl = GetData(@"^Requested URL : (\w\S+)\r\n");
            CallStack = eventCache.Callstack;
        }

        string GetData(string pattern)
        {
            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(LogEntry.Message, pattern, options))
            {
                if(m.Captures.Count > 0)
                    return m.Captures[0].Value;
            }

            return string.Empty;
        }
    }
    /// <summary>
    /// A <see cref="CustomTraceListener"/> class for external error logging.
    /// </summary>
    public class SquirrelFinderTraceListener : CustomTraceListener
    {

        public static List<SquirrelFinderLogEntry> LogEntries { get; private set; }
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RaygunTraceListener"/> class.
        /// </summary>
        public SquirrelFinderTraceListener() : this(new SquirrelFinderTraceListenerClient()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RaygunTraceListener"/> class.
        /// </summary>
        /// <param name="client">The <see cref="ITraceListenerClient"/> client which will be used for logging errors .</param>
        public SquirrelFinderTraceListener(SquirrelFinderTraceListenerClient client)
        {
            this.traceListenerClient = client;
            LogEntries = new List<SquirrelFinderLogEntry>();
        }

        #endregion

        #region Public methods

        /// <inheritdoc />
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            if ((this.Filter == null) || this.Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null))
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

        /// <inheritdoc />
        public override void Write(string message)
        {
            this.traceListenerClient.LogMessage(message);
        }

        /// <inheritdoc />
        public override void WriteLine(string message)
        {
            this.traceListenerClient.LogMessage(message + Environment.NewLine);
        }

        #endregion

        #region Private members

        private ISquirrelFinderTraceListenerClient traceListenerClient;

        #endregion
    }
}