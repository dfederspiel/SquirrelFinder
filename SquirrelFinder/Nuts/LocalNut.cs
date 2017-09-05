using Microsoft.Web.Administration;
using Newtonsoft.Json;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SquirrelFinder.Nuts
{
    public class LocalNut : Nut, ILocalNut
    {
        ServerManager _manager;

        public Site Site { get; set; }
        public string Path { get { return NutHelper.GetDirectoryFromUrl(Url.ToString()); } }
        public ObjectState ApplicationPoolState { get; set; }

        public event EventHandler<NutEventArgs> SiteStateChanged;
        public virtual void OnSiteStateChanged(NutEventArgs e)
        {
            SiteStateChanged?.Invoke(this, e);
        }

        public LocalNut() { }

        public LocalNut(Uri url) : base(url)
        {
            _manager = new ServerManager();
            Site = NutHelper.GetSiteFromUrl(Url);
        }

        public override HttpStatusCode Peek(int timeout = 5000)
        {
            ApplicationPoolState = NutHelper.GetApplicationPoolFromUrl(Url).State;
            return base.Peek(timeout);
        }

        public override string GetBalloonTipInfo()
        {
            return $"The '{Title}' nut says it's {State.ToString()} - {Guid.NewGuid()}";
        }
        public override string GetBalloonTipTitle()
        {
            return $"Local Nut Activity ({Title})";
        }

        [Obsolete("Use NutManager")]
        public virtual IQueryable<string> GetSiteBindingUrls()
        {
            var urls = new List<string>();
            foreach (var binding in Site.Bindings)
            {
                var url = "";
                url += binding.Protocol + "://";
                if (binding.Host == "")
                    url += "localhost";
                else
                    url += binding.Host;

                urls.Add(url);
            }
            return urls.AsQueryable();
        }

        public virtual void RecycleApplicationPool()
        {
            var applicationPool = NutHelper.GetApplicationPoolFromUrl(Url);

            if (applicationPool.State == ObjectState.Started ||
            applicationPool.State == ObjectState.Starting)
            {
                applicationPool.Recycle();
                ApplicationPoolState = ObjectState.Started;
                OnSiteStateChanged(new NutEventArgs(this));
            }
        }

        public virtual void StopApplicationPool()
        {
            var applicationPool = NutHelper.GetApplicationPoolFromUrl(Url);

            if (applicationPool.State == ObjectState.Started ||
            applicationPool.State == ObjectState.Starting) { 
                applicationPool.Stop();
                ApplicationPoolState = ObjectState.Stopped;
                OnSiteStateChanged(new NutEventArgs(this));
            }

        }

        public virtual void StartApplicationPool()
        {
            var applicationPool = NutHelper.GetApplicationPoolFromUrl(Url);

            if (applicationPool.State == ObjectState.Stopped ||
            applicationPool.State == ObjectState.Stopping) { 
                applicationPool.Start();
                ApplicationPoolState = ObjectState.Started;
                OnSiteStateChanged(new NutEventArgs(this));
            }
        }
    }
}
