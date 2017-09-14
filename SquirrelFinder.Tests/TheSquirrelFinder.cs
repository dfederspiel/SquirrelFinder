using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.Administration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using SquirrelFinder.Nuts;
using System.Threading.Tasks;
using SquirrelFinder.Sounds;

namespace SquirrelFinder.Tests
{
    [TestClass]
    public class TheSquirrelFinder
    {
        static NutManager _monitor;
        static SoundManager _soundManager;
        static INut _nut;

        [TestInitialize]
        public void Setup()
        {
            _monitor = new NutManager();
            _soundManager = new SoundManager();
            _nut = new Nut(new Uri("http://localhost"));
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
            _monitor = new NutManager();
            Assert.IsInstanceOfType(_monitor.GetSiteBindings("Default Web Site"), typeof(IEnumerable<string>));
            foreach (var url in _monitor.GetSiteBindings("Default Web Site"))
                Console.WriteLine(url);
        }

        [TestMethod]
        public void GivenANutAddsANut()
        {
            _monitor.AddNut(_nut);
            Assert.AreEqual("localhost", _monitor.Nuts.FirstOrDefault().Url.Host);
        }

        [TestMethod]
        public void GivenANutRemovesANut()
        {
            _monitor.AddNut(_nut);
            _monitor.RemoveNut(_nut);
            Assert.IsTrue(_monitor.Nuts.Count() == 0);
        }

        [TestMethod]
        public void GivenANutPeeksANut()
        {
            _monitor.AddNut(new Nut(new Uri("http://google.com")));
            _monitor.Nuts.FirstOrDefault().Peek();
        }

        [Ignore]
        [TestMethod]
        public async Task GivenManyNutsPeeksAllNuts()
        {
            _monitor.AddNut(new Nut(new Uri("http://google.com")));
            _monitor.AddNut(new Nut(new Uri("http://github.com")));
            _monitor.AddNut(new Nut(new Uri("http://codewars.com")));
            _monitor.AddNut(new Nut(new Uri("http://localhost.com")));
            _monitor.AddNut(new Nut(new Uri("http://examples.local")));
            await _monitor.PeekAllNuts();
        }

        [TestMethod]
        public void CanMakeASound()
        {
            _soundManager.PlayTone(SquirrelFinderSound.FlatLine);
            _soundManager.PlayTone(SquirrelFinderSound.Gears);
            _soundManager.PlayTone(SquirrelFinderSound.Squirrel);
            _soundManager.PlayTone(SquirrelFinderSound.None);
            _soundManager.PlayTone(SquirrelFinderSound.None);
        }

        [TestClass]
        public class InititializedWithALocalNut
        {
            [TestInitialize]
            public void Setup()
            {
                _monitor = new NutManager();
                _monitor.AddNut(new LocalNut(new Uri("http://localhost")));
            }

            [Ignore]
            [TestMethod]
            public void CanRecycleAppPool()
            {
                _monitor.AddNut(new LocalSitefinityNut(new Uri("http://basitefinityoob.local")));
                _monitor.Nuts.ToList().ForEach(n => {
                    if(n.GetType().GetInterfaces().Contains(typeof(ILocalNut)))
                    {
                        var x = (ILocalNut)n;
                        x.RecycleApplicationPool();
                    }
                });
            }

            [Ignore]
            [TestMethod]
            public void CanStartAppPool()
            {
                _monitor.AddNut(new LocalSitefinityNut(new Uri("http://basitefinityoob.local")));
                _monitor.Nuts.ToList().ForEach(n => {
                    if (n.GetType().GetInterfaces().Contains(typeof(ILocalNut)))
                    {
                        var x = (ILocalNut)n;
                        x.StartApplicationPool();
                    }
                });
            }

            [Ignore]
            [TestMethod]
            public void CanStopAppPool()
            {
                _monitor.AddNut(new LocalSitefinityNut(new Uri("http://basitefinityoob.local")));
                _monitor.Nuts.ToList().ForEach(n => {
                    if (n.GetType().GetInterfaces().Contains(typeof(ILocalNut)))
                    {
                        var x = (ILocalNut)n;
                        x.StopApplicationPool();
                    }
                });
            }

            [TestMethod]
            public void GivenASiteUrlReturnsTheSitePath()
            {
                Assert.AreEqual(@"%SystemDrive%\inetpub\wwwroot", NutHelper.GetDirectoryFromUrl("http://localhost"));
            }

            [TestMethod]
            public void GivenAnEmptyStringReturnsAnEmptyString()
            {
                Assert.AreEqual(@"", NutHelper.GetDirectoryFromUrl(""));
            }
        }

        [TestClass]
        public class InititializedWithARegularNut
        {
            [TestInitialize]
            public void Setup()
            {
                _monitor = new NutManager();
                _nut = new Nut(new Uri("http://google.com"));
            }

            [TestMethod]
            public void CanPeekUrl()
            {
                _nut.Peek();
            }

            [TestMethod]
            public void CanGetANotificationTitle()
            {

            }

            [TestMethod]
            public void CanGetANotificationText()
            {

            }
        }

        [TestClass]
        public class InitializedWithASitefinityNut
        {
            static NutManager _finder;
            [TestInitialize]
            public void Setup()
            {
                _finder = new NutManager();
                _finder.AddNut(new SitefinityNut(new Uri("http://basitefinityoob.local")));
            }
        }

        [TestClass]
        public class InitializedWithASitefinityLocalNut
        {
            static NutManager _nutWatcher;
            [TestInitialize]
            public void Setup()
            {
                _nutWatcher = new NutManager();
                _nutWatcher.AddNut(new LocalSitefinityNut(new Uri("http://basitefinity.local")));
            }

            [Ignore]
            [TestMethod]
            public void CanWatchLogFiles()
            {

            }

            [Ignore]
            [TestMethod]
            public void CanWatchBinDirectory()
            {

            }
        }
    }
}
