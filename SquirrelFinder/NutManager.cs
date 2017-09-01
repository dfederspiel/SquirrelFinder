using Microsoft.Web.Administration;
using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder
{

    public enum SquirrelFinderSound
    {
        None,
        FlatLine,
        Gears,
        Squirrel
    }

    public class NutManager
    {
        static SoundPlayer _player = new SoundPlayer();
        SquirrelFinderSound _currentSound = SquirrelFinderSound.None;

        public event EventHandler<NutCollectionEventArgs> NutCollectionChanged;
        public event EventHandler<NutEventArgs> NutChanged;

        FileSystemWatcher watcher = new FileSystemWatcher();

        public NutState CurrentState = NutState.Found;

        static string _squirrelSound = AppDomain.CurrentDomain.BaseDirectory + "\\sounds\\squirrel.wav";
        static string _gearsSound = AppDomain.CurrentDomain.BaseDirectory + "\\sounds\\gears.wav";
        static string _flatLine = AppDomain.CurrentDomain.BaseDirectory + "\\sounds\\flatline.wav";

        private List<INut> _nuts;
        public List<INut> Nuts { get { return _nuts; } set { _nuts = value; } }

        public NutManager()
        {
            Nuts = new List<INut>();
        }

        public virtual void OnNutCollectionChanged(NutCollectionEventArgs e)
        {
            NutCollectionChanged?.Invoke(this, e);
        }

        public virtual void OnNutChanged(NutEventArgs e)
        {
            NutChanged?.Invoke(this, e);
        }

        #region IISSiteTools

        public IEnumerable<string> GetAllSites()
        {
            var manager = new ServerManager();
            foreach (var site in manager.Sites)
                yield return site.Name;
        }

        //public string GetSitePathFromUrl(string url)
        //{
        //    if (string.IsNullOrEmpty(url))
        //        return string.Empty;

        //    return NutHelper.GetDirectoryFromUrl(url);
        //}

        public IEnumerable<string> GetSiteBindings(string siteName)
        {
            var manager = new ServerManager();
            var site = manager.Sites.Where(s => s.Name == siteName).FirstOrDefault();
            return site.Bindings.Select(b => b.Protocol + "://" + (b.Host == string.Empty ? "localhost" : b.Host));
        }

        #endregion

        public void AddNut(INut nut)
        {
            Nuts.Add(nut);
            nut.NutChanged += Nut_NutChanged;

            OnNutCollectionChanged(new NutCollectionEventArgs(Nuts.ToList()));
        }

        private void Nut_NutChanged(object sender, NutEventArgs e)
        {
            OnNutChanged(e);
        }

        public void RemoveNut(INut nut)
        {
            Nuts.Remove(nut);

            OnNutCollectionChanged(new NutCollectionEventArgs(Nuts.ToList()));
        }

        public async Task PeekAll()
        {
            foreach (var nut in Nuts)
            {
                await Task.Run(() =>
                {
                    nut.Peek();
                });
            }
        }

        public void PlayTone(SquirrelFinderSound sound)
        {
            if (sound == _currentSound) return;
            _currentSound = sound;

            var soundToPlay = "";
            switch (sound)
            {
                case SquirrelFinderSound.FlatLine:
                    soundToPlay = _flatLine;
                    CurrentState = NutState.Lost;
                    break;
                case SquirrelFinderSound.Gears:
                    soundToPlay = _gearsSound;
                    CurrentState = NutState.Searching;
                    break;
                case SquirrelFinderSound.Squirrel:
                    soundToPlay = _squirrelSound;
                    CurrentState = NutState.Found;
                    break;
            }

            if (sound != SquirrelFinderSound.None)
            {
                _player.Stop();
                _player.SoundLocation = soundToPlay;
                _player.Play();
            }
        }
    }
}
