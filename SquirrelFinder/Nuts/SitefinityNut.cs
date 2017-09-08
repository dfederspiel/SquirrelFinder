using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Nuts
{
    public class SitefinityNut : Nut, ISitefinityNut
    {
        public List<SquirrelFinderLogEntry> LogEntries { get; set; }

        public bool LoggingEnabled { get; set; }

        public SitefinityNut() : base() { }

        public SitefinityNut(Uri url) : base(url)
        {
            LogEntries = new List<SquirrelFinderLogEntry>();
            LoggingEnabled = true;
        }

        public override void Peek(int timeout = 5000)
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

                    if (LoggingEnabled)
                        GetLogEntries();

                    OnNutChanged(new NutEventArgs(this));
                }
            }
            catch
            {
                State = NutState.Lost;
            }

            if (currentState != State)
                HasShownMessage = false;

            OnNutChanged(new NutEventArgs(this));
        }

        public override string GetBalloonTipInfo()
        {
            return $"The '{Title}' nut says it's {State.ToString()} - {Guid.NewGuid()}";
        }

        public override string GetBalloonTipTitle()
        {
            return $"Sitefinity Nut Activity ({Title})";
        }

        public List<SquirrelFinderLogEntry> GetLogEntries()
        {
            if (State != NutState.Found) return null;

            var request = WebRequest.Create(Url.ToString() + "/squirrel/logging/get");
            request.Timeout = 5000;
            try
            {

                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                var entries = JsonConvert.DeserializeObject<List<SquirrelFinderLogEntry>>(responseFromServer);
                LogEntries = entries;
                LoggingEnabled = true;
                return entries;

            }
            catch (Exception ex)
            {
                LoggingEnabled = false;
            }

            return null;
        }
    }
}
