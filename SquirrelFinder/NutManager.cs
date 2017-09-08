using Microsoft.Web.Administration;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder
{

    public class NutManager : INutManager
    {
        public event EventHandler<NutCollectionEventArgs> NutCollectionChanged;
        public event EventHandler<NutEventArgs> NutChanged;
        public virtual void OnNutCollectionChanged(NutCollectionEventArgs e)
        {
            NutCollectionChanged?.Invoke(this, e);
        }

        public virtual void OnNutChanged(NutEventArgs e)
        {
            NutChanged?.Invoke(this, e);
        }

        FileSystemWatcher watcher = new FileSystemWatcher();

        public NutState CurrentState = NutState.Found;

        private readonly List<INut> _nuts;
        public ReadOnlyCollection<INut> Nuts { get; private set; }

        public NutManager()
        {
            _nuts = new List<INut>();
            Nuts = _nuts.AsReadOnly();
        }

        #region IISSiteTools

        public IEnumerable<string> GetAllSites()
        {
            var manager = new ServerManager();
            foreach (var site in manager.Sites)
                yield return site.Name;
        }

        public IEnumerable<string> GetSiteBindings(string siteName)
        {
            var manager = new ServerManager();
            var site = manager.Sites.Where(s => s.Name == siteName).FirstOrDefault();
            return site.Bindings.Select(b => b.Protocol + "://" + (b.Host == string.Empty ? "localhost" : b.Host));
        }

        #endregion

        public virtual void AddNut(INut nut)
        {
            _nuts.Add(nut);
            nut.NutChanged += Nut_NutChanged;

            OnNutCollectionChanged(new NutCollectionEventArgs(_nuts.ToList()));
        }

        private void Nut_NutChanged(object sender, NutEventArgs e)
        {
            OnNutChanged(e);
        }

        public virtual void RemoveNut(INut nut)
        {
            _nuts.Remove(nut);

            OnNutCollectionChanged(new NutCollectionEventArgs(_nuts.ToList()));
        }

        public async Task PeekAllNuts()
        {
            var tempNuts = new List<INut>(_nuts);
            foreach (var nut in tempNuts)
            {
                await Task.Run(() =>
                {
                    nut.Peek();
                });
            }
        }

        public void OpenNutBox(NutBox nutBox)
        {
            _nuts.Clear();
            AddNuts(nutBox.LocalSitefinityNuts.ToList<INut>());
            AddNuts(nutBox.SitefinityNuts.ToList<INut>());
            AddNuts(nutBox.LocalNuts.ToList<INut>());
            AddNuts(nutBox.Nuts.ToList<INut>());
        }

        void AddNuts(List<INut> nuts)
        {
            foreach(var nut in nuts)
            {
                AddNut(nut);
            }
        }

        public void RemoveNuts(List<INut> nuts)
        {
            foreach (var nut in nuts)
            {
                RemoveNut(nut);
            }
        }
    }
}
