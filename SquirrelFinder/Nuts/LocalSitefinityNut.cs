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
    public class LocalSitefinityNut : LocalNut, ISitefinityNut
    {
        public List<SquirrelFinderLogEntry> LogEntries { get; set; }

        public LocalSitefinityNut() : base() { }

        public LocalSitefinityNut(Uri url) : base(url)
        {
            LogEntries = new List<SquirrelFinderLogEntry>();
        }

        public override HttpStatusCode Peek(int timeout = 5000)
        {
            NutState currentState = State;
            ApplicationPoolState = NutHelper.GetApplicationPoolFromUrl(Url).State;

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
                    GetLogEntries();
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

        public List<SquirrelFinderLogEntry> GetLogEntries()
        {
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
                return entries;

            }
            catch (Exception ex)
            {
                // Can't find it.
            }

            return new List<SquirrelFinderLogEntry>();
        }
    }
}
