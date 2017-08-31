using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.Administration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using SquirrelFinder.Nuts;
using System.Threading.Tasks;

namespace SquirrelFinder.Tests
{
    [TestClass]
    public class TheSquirrelFinder
    {
        static NutMonitor _monitor;
        static INut _nut;

        [TestInitialize]
        public void Setup()
        {
            _monitor = new NutMonitor();
            _nut = new Nut("http://localhost");
        }

        [TestMethod]
        public void Exists()
        {
            Assert.IsNotNull(_monitor);
        }

        [TestMethod]
        public void CanGetAllSitesInIIS()
        {
            Assert.IsInstanceOfType(_monitor.GetAllSites(), typeof(IEnumerable<string>));
        }

        [TestMethod]
        public void CanGetSiteBindingUrls()
        {
            _monitor = new NutMonitor();
            Assert.IsInstanceOfType(_monitor.GetSiteBindings("Default Web Site"), typeof(IEnumerable<string>));
            foreach (var url in _monitor.GetSiteBindings("Default Web Site"))
                Console.WriteLine(url);
        }

        [TestMethod]
        public void CanAddANut()
        {
            _monitor.AddNut(_nut);
            Assert.AreEqual("localhost", _monitor.Nuts.FirstOrDefault().Url.Host);
        }

        [TestMethod]
        public void CanRemoveANut()
        {
            _monitor.AddNut(_nut);
            _monitor.RemoveNut(_nut);
            Assert.IsTrue(_monitor.Nuts.Count() == 0);
        }

        [TestMethod]
        public void CanPeekANut()
        {
            _monitor.AddNut(new Nut("http://google.com"));
            var response = _monitor.Nuts.FirstOrDefault().Peek();
            Assert.AreEqual(HttpStatusCode.OK, response);
        }

        [TestMethod]
        public async Task CanPeekAllNuts()
        {
            _monitor.AddNut(new Nut("http://google.com"));
            _monitor.AddNut(new Nut("http://github.com"));
            _monitor.AddNut(new Nut("http://codewars.com"));
            _monitor.AddNut(new Nut("http://localhost.com"));
            _monitor.AddNut(new Nut("http://examples.local"));
            await _monitor.PeekAll();
        }

        [TestMethod]
        public void GivenABadUrlReturnsNull()
        {
            _monitor.AddNut(new Nut("http://lkjlkjlkjlkj"));
            var response = _monitor.Nuts.FirstOrDefault().Peek();
            Console.WriteLine(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response);
        }

        [TestMethod]
        public void CanMakeASound()
        {
            _monitor.PlayTone(SquirrelFinderSound.FlatLine);
            _monitor.PlayTone(SquirrelFinderSound.Gears);
            _monitor.PlayTone(SquirrelFinderSound.Squirrel);
            _monitor.PlayTone(SquirrelFinderSound.None);

            _monitor.PlayTone(SquirrelFinderSound.None);
        }

        [TestClass]
        public class InititializedWithALocalNut
        {
            [TestInitialize]
            public void Setup()
            {
                _monitor = new NutMonitor();
                _monitor.AddNut(new LocalNut("http://localhost"));
            }

            [TestMethod]
            public void CanRecycleAppPool()
            {
                _monitor.AddNut(new SitefinityLocalNut("http://basitefinityoob.local"));
                _monitor._nuts.ForEach(n => {
                    if(n.GetType().GetInterfaces().Contains(typeof(ILocalNut)))
                    {
                        var x = (ILocalNut)n;
                        x.RecycleSite();
                    }
                });
            }

            [TestMethod]
            public void CanStartAppPool()
            {
                _monitor.AddNut(new SitefinityLocalNut("http://basitefinityoob.local"));
                _monitor._nuts.ForEach(n => {
                    if (n.GetType().GetInterfaces().Contains(typeof(ILocalNut)))
                    {
                        var x = (ILocalNut)n;
                        x.StartSite();
                    }
                });
            }

            [TestMethod]
            public void CanStopAppPool()
            {
                _monitor.AddNut(new SitefinityLocalNut("http://basitefinityoob.local"));
                _monitor._nuts.ForEach(n => {
                    if (n.GetType().GetInterfaces().Contains(typeof(ILocalNut)))
                    {
                        var x = (ILocalNut)n;
                        x.StopSite();
                    }
                });
            }

            [TestMethod]
            public void GivenASiteUrlReturnsTheSitePath()
            {
                Assert.AreEqual(@"%SystemDrive%\inetpub\wwwroot", _monitor.GetSitePathFromUrl("http://localhost"));
            }

            [TestMethod]
            public void GivenAnEmptyStringReturnsAnEmptyString()
            {
                Assert.AreEqual(@"", _monitor.GetSitePathFromUrl(""));
            }
        }

        [TestClass]
        public class InititializedWithAPublicSite
        {
            [TestInitialize]
            public void Setup()
            {
                _monitor = new NutMonitor();
            }
        }

        [TestClass]
        public class InitializedWithASitefinityNut
        {
            static NutMonitor _finder;
            [TestInitialize]
            public void Setup()
            {
                _finder = new NutMonitor();
                _finder.AddNut(new SitefinityNut("http://basitefinityoob.local/"));
            }
        }

        [TestClass]
        public class InitializedWithASitefinityLocalNut
        {
            static NutMonitor _nutWatcher;
            [TestInitialize]
            public void Setup()
            {
                _nutWatcher = new NutMonitor();
                _nutWatcher.AddNut(new SitefinityLocalNut("http://basitefinity.local/"));
            }

            [TestMethod]
            public void CanGetInfo()
            {
                _nutWatcher.Nuts.First().GetInfo();
            }

            [TestMethod]
            public void CanWatchLogFiles()
            {

            }

            [TestMethod]
            public void CanWatchBinDirectory()
            {

            }
        }
    }
}
