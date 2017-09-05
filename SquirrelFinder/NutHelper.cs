using Microsoft.Web.Administration;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder
{
    public static class NutHelper
    {
        public static string GetDirectoryFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;
            var u = new Uri(url);

            var manager = new ServerManager();

            foreach (var site in manager.Sites)
            {
                foreach (var binding in site.Bindings)
                {
                    if (((binding.Host == "" && u.Host == "localhost") || binding.Host == u.Host) && binding.Protocol == u.Scheme)
                    {
                        return site.Applications["/"].VirtualDirectories["/"].PhysicalPath;
                    }
                }
            }
            return null;
        }

        public static Site GetSiteFromUrl(Uri url)
        {
            var manager = new ServerManager();

            foreach (var site in manager.Sites)
            {
                foreach (var binding in site.Bindings)
                {
                    if (((binding.Host == "" && url.Host == "localhost") || binding.Host == url.Host) && binding.Protocol == url.Scheme)
                    {
                        return site;
                    }
                }
            }
            return null;
        }

        public static ApplicationPool GetApplicationPoolFromUrl(Uri url)
        {
            var manager = new ServerManager();

            foreach (var site in manager.Sites)
            {
                foreach (var binding in site.Bindings)
                {
                    if (binding.Host == (url.Host == "localhost" ? "" : url.Host) && binding.Protocol == url.Scheme)
                    {
                        return manager.ApplicationPools[site.Applications["/"].ApplicationPoolName];
                    }
                }
            }
            return null;
        }

        public async static Task<HttpStatusCode> PeekUrl(string url)
        {
            try
            {
                var request = WebRequest.Create(url);
                using (var response = await request.GetResponseAsync())
                {
                    var x = (HttpWebResponse)response;
                    return x.StatusCode;
                }

            }
            catch
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public static IEnumerable<string> GetSiteBindingsFromSite(Site site)
        {
            var manager = new ServerManager();
            return site.Bindings.Select(b => b.Protocol + "://" + (b.Host == string.Empty ? "localhost" : b.Host));
        }

        public static bool LocalSiteExists(ILocalNut nut)
        {
            var site = GetSiteFromUrl(nut.Url);
            if (site == null)
                return false;

            return true;
        }
    }
}
