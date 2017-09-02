using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Nuts
{
    public interface ILocalNut : INut
    {
        void OnSiteStateChanged(NutEventArgs e);
        event EventHandler<NutEventArgs> SiteStateChanged;

        ObjectState ApplicationPoolState { get; set; }

        Site Site { get; set; }
        string Path { get; }
        void RecycleApplicationPool();
        void StopApplicationPool();
        void StartApplicationPool();
    }
}
