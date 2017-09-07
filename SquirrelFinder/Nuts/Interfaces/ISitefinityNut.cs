using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Nuts
{
    public interface ISitefinityNut
    {
        List<SquirrelFinderLogEntry> LogEntries { get; set; }
        List<SquirrelFinderLogEntry> GetLogEntries();
    }
}
