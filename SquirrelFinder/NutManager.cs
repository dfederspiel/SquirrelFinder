using Microsoft.Web.Administration;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
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

        private List<INut> _nuts;
        public List<INut> Nuts { get { return _nuts; } set { _nuts = value; } }

        public NutManager()
        {
            Nuts = new List<INut>();
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
            Nuts.Add(nut);
            nut.NutChanged += Nut_NutChanged;

            OnNutCollectionChanged(new NutCollectionEventArgs(Nuts.ToList()));
        }

        private void Nut_NutChanged(object sender, NutEventArgs e)
        {
            OnNutChanged(e);
        }

        public virtual void RemoveNut(INut nut)
        {
            Nuts.Remove(nut);

            OnNutCollectionChanged(new NutCollectionEventArgs(Nuts.ToList()));
        }

        public async Task PeekAllNuts()
        {
            var tempNuts = new List<INut>(Nuts);
            foreach (var nut in tempNuts)
            {
                await Task.Run(() =>
                {
                    nut.Peek();
                });
            }
        }
    }
}
