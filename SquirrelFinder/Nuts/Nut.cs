using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SquirrelFinder.Nuts
{
    public enum NutState
    {
        NotChecked,
        Found,
        Searching,
        Lost
    }

    public class NutEventArgs : EventArgs
    {
        public INut Nut { get; set; }
        public NutEventArgs(INut nut)
        {
            Nut = nut;
        }
    }

    public class Nut : INut
    {
        public Uri Url { get; set; }
        public NutState State { get; set; }
        public HttpStatusCode LastResponse { get; set; }
        
        public event EventHandler<NutEventArgs> NutChanged;

        public bool HasShownMessage { get; set; }

        public Nut(string url)
        {
            Uri u = new Uri(url);
            Url = u;
        }

        public virtual void OnNutChanged(NutEventArgs e)
        {
            NutChanged?.Invoke(this, e);
        }

        public virtual HttpStatusCode Peek(int timeout = 5000)
        {
            NutState currentState = State;
            var request = WebRequest.Create(Url);
            request.Timeout = timeout;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    State = NutState.Found;
                    LastResponse = response.StatusCode;

                    if (currentState != State)
                        HasShownMessage = false;

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

        public virtual string GetInfo()
        {
            return Url.ToString();
        }
    }

   
}