using SquirrelFinder.Acorn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Telerik.Microsoft.Practices.EnterpriseLibrary.Logging;

namespace SquirrelFinder.Acorn
{
    public class LoggingController : ApiController
    {

        public List<SquirrelFinderLogEntry> Get()
        {
            return SquirrelFinderTraceListener.LogEntries;
        }

        [HttpGet]
        public int Count()
        {
            return SquirrelFinderTraceListener.LogEntries.Count;
        }

        [HttpGet]
        public SquirrelFinderLogEntry Get(int index)
        {
            if (SquirrelFinderTraceListener.LogEntries.Count > 0)
                return SquirrelFinderTraceListener.LogEntries.ElementAt(index);

            return null;
        }

        [HttpGet]
        public void Clear()
        {
            SquirrelFinderTraceListener.LogEntries.Clear();
        }
    }
}
