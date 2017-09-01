using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Nuts
{
    public interface ILocalNut : INut
    {
        string Path { get; }
        void RecycleSite();
        void StopSite();
        void StartSite();
    }
}
