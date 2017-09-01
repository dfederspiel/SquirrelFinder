using Microsoft.Web.Administration;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Nuts
{
    public class LocalNut : Nut, ILocalNut
    {
        ServerManager _manager;
        Site _site;

        public LocalNut(Uri url) : base(url)
        {
            _manager = new ServerManager();
            _setSiteFromUrl(Url);
        }

        private void _setSiteFromUrl(Uri url)
        {
            foreach (var site in _manager.Sites)
            {
                foreach (var binding in site.Bindings)
                {
                    if (binding.Host == (binding.Host == "" ? "" : url.Host) && binding.Protocol == url.Scheme)
                    {
                        _site = site;
                    }
                }
            }
        }

        public override string GetBalloonTipInfo()
        {
            return $"The '{Title}' nut says it's {State.ToString()} - {Guid.NewGuid()}";
        }
        public override string GetBalloonTipTitle()
        {
            return $"Local Nut Activity ({Title})";
        }

        public virtual IQueryable<string> GetSiteBindingUrls()
        {
            var urls = new List<string>();
            foreach (var binding in _site.Bindings)
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

        public void RecycleSite()
        {
            if (_manager.ApplicationPools[_site.Applications["/"].ApplicationPoolName].State != ObjectState.Stopped)
                _manager.ApplicationPools[_site.Applications["/"].ApplicationPoolName].Recycle();

        }

        public void StopSite()
        {
            if (_manager.ApplicationPools[_site.Applications["/"].ApplicationPoolName].State != ObjectState.Stopped)
                _manager.ApplicationPools[_site.Applications["/"].ApplicationPoolName].Stop();
        }

        public void StartSite()
        {
            if (_manager.ApplicationPools[_site.Applications["/"].ApplicationPoolName].State != ObjectState.Started &&
                _manager.ApplicationPools[_site.Applications["/"].ApplicationPoolName].State != ObjectState.Starting)
                _manager.ApplicationPools[_site.Applications["/"].ApplicationPoolName].Start();
        }
    }
}
