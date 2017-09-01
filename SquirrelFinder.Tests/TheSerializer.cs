using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquirrelFinder.Nuts;
using System.Collections.Generic;

namespace SquirrelFinder.Tests
{
    [TestClass]
    public class TheNutSaver
    {
        private NutManager _nutMonitor;
        private Nut _publicNut;
        private SitefinityNut _sitefinityPublicNut;
        private LocalNut _localNut;
        private LocalSitefinityNut _sitefinityLocalNut;

        [TestInitialize]
        public void Setup()
        {
            _nutMonitor = new NutManager();

            _publicNut = new Nut(new Uri("http://github.com"));
            _sitefinityPublicNut = new SitefinityNut(new Uri("http://basitefinityoob.local"));
            _localNut = new LocalNut(new Uri("http://localhost"));
            _sitefinityLocalNut = new LocalSitefinityNut(new Uri("http://basitefinityoob.local"));
        }

        [TestMethod]
        public void GivenACollectionOfINutsCanSerializeIntoAJSONString()
        {
            var myNuts = new List<INut> { _publicNut, _localNut, _sitefinityLocalNut, _sitefinityPublicNut };
            NutSaver.SaveNuts(myNuts);
        }

        [TestMethod]
        public void CanRetrieveNutsAsAListOfINuts()
        {
            var myNuts = new List<Nut> { _publicNut };
            const string json = "[{'Url':'http://github.com','State':0,'LastResponse':0,'HasShownMessage':false,'Title':'github.com','Type':null},{'Url':'http://localhost','State':0,'LastResponse':0,'HasShownMessage':false,'Title':'localhost','Type':null},{'Type':'SquirrelFinder.Nuts.LocalSitefinityNut','Url':'http://basitefinityoob.local','State':0,'LastResponse':0,'HasShownMessage':false,'Title':'basitefinityoob.local'},{'Type':'SquirrelFinder.Nuts.PublicSitefinityNut','Url':'http://google.com','State':0,'LastResponse':0,'HasShownMessage':false,'Title':'basitefinityoob.local'}]";
            Console.WriteLine(NutSaver.GetNuts(json));
        }
    }
}
