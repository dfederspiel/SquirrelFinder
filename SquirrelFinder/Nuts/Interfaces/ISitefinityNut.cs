using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Nuts
{
    public interface ISitefinityNut : INut
    {
        bool LoggingEnabled { get; set; }
        List<SquirrelFinderLogEntry> LogEntries { get; set; }
        List<SquirrelFinderLogEntry> GetLogEntries();
    }
}
