using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquirrelFinder.Acorn.Mvc.Models
{
    public class SquirrelFinderModel
    {
        public List<SquirrelFinderLogEntry> LogEntries { get; internal set; }
    }
}