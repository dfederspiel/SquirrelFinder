using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SquirrelFinder.Nuts
{
    public class LocalSitefinityNut : LocalNut
    {
        FileSystemWatcher _watcher;

        public LocalSitefinityNut() : base() { }

        public LocalSitefinityNut(Uri url) : base(url)
        {
            _watcher = new FileSystemWatcher(NutHelper.GetDirectoryFromUrl(url.ToString()) + "/App_Data/Sitefinity/Logs") { NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName };
            _watcher.EnableRaisingEvents = true;
            _watcher.Changed += _watcher_Changed;
            _watcher.Created += _watcher_Created;
            _watcher.Renamed += _watcher_Renamed;
            _watcher.Deleted += _watcher_Deleted;

            Timer t = new Timer(1000);
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void _watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _watcher_Renamed(object sender, RenamedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            //try
            //{
            //    var lines = File.ReadAllLines(NutHelper.GetDirectoryFromUrl(Url.ToString()) + "/App_Data/Sitefinity/Logs/Error.log");
            //}
            //catch { }
        }

        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            //var watcher = (FileSystemWatcher)sender;
        }

        public override HttpStatusCode Peek(int timeout = 5000)
        {
            NutState currentState = State;
            var request = WebRequest.Create(Url);
            request.Timeout = timeout;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.ResponseUri.ToString() != Url.ToString())
                        State = NutState.Searching;
                    else
                        State = NutState.Found;

                    if (currentState != State)
                        HasShownMessage = false;

                    LastResponse = response.StatusCode;

                    OnNutChanged(new NutEventArgs(this));
                    return response.StatusCode;
                }
            }
            catch
            {
                State = NutState.Lost;
            }

            if (currentState != State)
                HasShownMessage = false;

            OnNutChanged(new NutEventArgs(this));
            return HttpStatusCode.NotFound;
        }

        public override string GetBalloonTipInfo()
        {
            return $"The '{Title}' nut says it's {State.ToString()} - {Guid.NewGuid()}";
        }

        public override string GetBalloonTipTitle()
        {
            return $"Local Sitefinity Nut Activity ({Title})";
        }
    }
}
