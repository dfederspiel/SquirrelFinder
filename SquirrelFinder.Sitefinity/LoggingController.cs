using SquirrelFinderLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging;

namespace SquirrelFinderLogging
{
    public class LoggingController : ApiController
    {
        public List<SquirrelFinderLogEntry> Get()
        {
            return SquirrelFinderTraceListener.LogEntries;
        }

        [HttpGet]
        public SquirrelFinderLogEntry GetLast()
        {
            return SquirrelFinderTraceListener.LogEntries.Last();
        }

        [HttpGet]
        public void Clear()
        {
            SquirrelFinderTraceListener.LogEntries.Clear();
        }
    }
}
